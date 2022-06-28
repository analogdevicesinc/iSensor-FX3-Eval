'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          TopGUI_RegisterForm.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Top level GUI register access form implementation.

Imports System.Timers
Imports RegMapClasses

Partial Class TopGUI

    Private pageList As List(Of Integer)
    Private pagePosition As List(Of Integer)
    Private lastPageIndex As Integer
    Private pageReadTimer As Timer
    Private drReadTimer As Timer
    Private drEnableTimer As Timer
    Private currentRegList As List(Of RegClass)
    Private scaleData As Boolean
    Private m_pageMessageList As List(Of Integer)

    Private Sub RegFormSetup()
        regView.ClearSelection()
        scaleData = False
        numDecimals.Visible = False
        numDecimals_label.Visible = False
        validateSpiData.Checked = False
        validateSpiData.Visible = False
        contRead.Checked = False
        measureDr.Checked = False
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False

        'get list of pages
        pageList = New List(Of Integer)
        pagePosition = New List(Of Integer)
        selectPage.Items.Clear()
        For Each reg In RegMap
            If Not pageList.Contains(reg.Page) Then
                pageList.Add(reg.Page)
                pagePosition.Add(0) 'Start at top
                selectPage.Items.Add(reg.Page)
            End If
        Next

        'clear all register data
        While regView.RowCount > 0
            regView.Rows.RemoveAt(0)
        End While

        'Set the selected index
        selectPage.SelectedIndex = 0
        lastPageIndex = 0
        m_pageMessageList = New List(Of Integer)

        'enable register value copying
        regView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

    End Sub

    Friend Sub RegFormUpdateSensorType()
        If Not IsNothing(FX3) Then
            'check if SPI data can be validated
            If FX3.SensorType = FX3Api.DeviceType.AutomotiveSpi Then
                validateSpiData.Visible = True
            Else
                validateSpiData.Visible = False
            End If
        End If
    End Sub

    Private Sub HiddenHandler() Handles Me.VisibleChanged
        If Not Visible Then
            'disable DR / cont reads
            pageReadTimer.Enabled = False
            drReadTimer.Enabled = False
            'stop timer which enables the DR read timer for slow data ready freq
            If Not IsNothing(drEnableTimer) Then
                drEnableTimer.Enabled = False
                drEnableTimer.Dispose()
            End If
        Else
            pageReadTimer.Enabled = contRead.Checked
            drReadTimer.Enabled = measureDr.Checked
        End If
    End Sub

    Private Sub WriteEnterHandler(sender As Object, e As KeyEventArgs) Handles newValue.KeyUp

        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
            btn_WriteReg.PerformClick()
        End If

    End Sub

    Private Sub AnnoyingNoiseHandler(sender As Object, e As KeyEventArgs) Handles newValue.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles btn_WriteReg.Click

        'turn drActive to false (safer this way)
        If FX3.DrActive Then FX3.DrActive = False

        Dim regLabel As String

        If scaleData Then
            Dim writeValue As Double
            Try
                writeValue = Convert.ToDouble(newValue.Text)
                regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
                Dut.WriteScaledValue(RegMap(regLabel), writeValue)
            Catch ex As Exception
                MsgBox("ERROR: Invalid write - " + ex.Message())
            End Try
        Else
            Dim writeValue As UInteger
            Try
                writeValue = Convert.ToUInt32(newValue.Text, 16)
                regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
                Dut.WriteUnsigned(RegMap(regLabel), writeValue)
            Catch ex As Exception
                MsgBox("ERROR: Invalid write - " + ex.Message())
            End Try
        End If

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub ReadPage()
        Dim readRegList As New List(Of RegClass)
        Dim numDecimalPlaces As UInteger

        'turn drActive to false (safer this way)
        If FX3.DrActive Then FX3.DrActive = False

        For Each reg In currentRegList
            If reg.IsReadable Then
                readRegList.Add(reg)
            Else
                'Dummy read reg for unreadable registers
                readRegList.Add(New RegClass With {.Page = reg.Page, .Address = 0})
            End If
        Next

        If scaleData Then
            Try
                numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
            Catch ex As Exception
                numDecimalPlaces = 2
                numDecimals.Text = "2"
                MsgBox("Invalid number Of Decimal places!" + ex.Message)
            End Try
            Dim DutValuesDoub() As Double
            DutValuesDoub = Dut.ReadScaledValue(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesDoub
                If currentRegList(regIndex).IsReadable Then
                    regView.Item("Contents", regIndex).Value = value.ToString("f" + numDecimalPlaces.ToString())
                Else
                    regView.Item("Contents", regIndex).Value = "Write Only"
                End If
                regIndex += 1
            Next
        Else
            Dim DutValuesUInt() As UInteger
            DutValuesUInt = Dut.ReadUnsigned(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesUInt
                If currentRegList(regIndex).IsReadable Then
                    regView.Item("Contents", regIndex).Value = value.ToString("X" + (currentRegList(regIndex).NumBytes * 2).ToString())
                Else
                    regView.Item("Contents", regIndex).Value = "Write Only"
                End If
                regIndex += 1
            Next
        End If

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

        'check the page register read back only if paged part is in use
        If pageList.Count < 2 Then Exit Sub
        Dim expectedPage As Integer = currentRegList(0).Page
        If m_pageMessageList.Contains(expectedPage) Then
            'only warn about page once per page
            Exit Sub
        End If
        Dim dutPage As Integer = Dut.ReadUnsigned(New RegClass With {.Page = expectedPage, .Address = 0, .NumBytes = 2})
        If dutPage <> expectedPage Then
            m_pageMessageList.Add(expectedPage)
            MsgBox("ERROR: Unable to load page " + expectedPage.ToString(), MsgBoxStyle.Exclamation)
        End If

    End Sub

    Private Sub regView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles regView.CellClick
        Dim regLabel As String
        Dim reg As RegClass
        Dim numDecimalPlaces As UInteger

        'turn drActive to false (safer this way)
        If FX3.DrActive Then FX3.DrActive = False

        Try
            regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
            reg = RegMap(regLabel)
            If scaleData Then
                numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
                Dim value As Double
                value = Dut.ReadScaledValue(reg)
                CurrentValue.Text = value.ToString("f" + numDecimalPlaces.ToString())
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("f" + numDecimalPlaces.ToString())
            Else
                Dim value As UInteger
                value = Dut.ReadUnsigned(reg)
                CurrentValue.Text = value.ToString("X" + (reg.NumBytes * 2).ToString())
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("X" + (reg.NumBytes * 2).ToString())
            End If
            CurrentValue.BackColor = Color.White
        Catch ex As Exception
            CurrentValue.Text = "Write Only"
            CurrentValue.BackColor = ERROR_COLOR
        End Try

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub PageReadCallback()
        If IsNothing(FX3.ActiveFX3) Then Exit Sub
        BeginInvoke(New MethodInvoker(AddressOf ReadPage))
    End Sub

    Private Sub DrReadCallBack()
        If IsNothing(FX3.ActiveFX3) Then Exit Sub
        drReadTimer.Enabled = False
        BeginInvoke(New MethodInvoker(AddressOf ReadDrFreq))
    End Sub

    Private Sub EnableDrTimer()
        drEnableTimer.Dispose()
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub ReadDrFreq()
        Dim dr As Double
        Try
            dr = FX3.MeasurePinFreq(FX3.DrPin, 1, 3000, 2)
        Catch ex As Exception
            dr = Double.PositiveInfinity
        End Try
        DrFreq.Text = FormatNumber(dr).ToString() + "Hz"
        If dr = Double.PositiveInfinity Then
            measureDr.Checked = False
        End If
        'if data ready is less than 10Hz want to shove some delays in here to prevent form from locking up a bunch
        If dr < 10 Then
            're-enable via timer, 5x the sample period delay
            drEnableTimer = New System.Timers.Timer(5000 / dr)
            AddHandler drEnableTimer.Elapsed, New ElapsedEventHandler(AddressOf EnableDrTimer)
            drEnableTimer.Enabled = True
        Else
            drReadTimer.Enabled = measureDr.Checked
        End If
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        'Kill any running timers
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False
        pageReadTimer.Dispose()
        drReadTimer.Dispose()
        If Not IsNothing(drEnableTimer) Then
            drEnableTimer.Enabled = False
            drEnableTimer.Dispose()
        End If
    End Sub

    Private Sub selectPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectPage.SelectedIndexChanged

        'Load all the registers on the given page into the data grid view
        InitializeDataGrid()

        While regView.RowCount > currentRegList.Count()
            regView.Rows.Remove(regView.Rows(regView.RowCount() - 1))
        End While

    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles btn_ReadPage.Click
        ReadPage()
    End Sub

    Private Sub contRead_CheckedChanged(sender As Object, e As EventArgs) Handles contRead.CheckedChanged
        pageReadTimer.Enabled = contRead.Checked
    End Sub

    Private Sub scaledData_CheckedChanged(sender As Object, e As EventArgs) Handles scaledData.CheckedChanged
        scaleData = scaledData.Checked
        If scaleData Then
            readLabel.Text = "Current Value (Decimal)"
            writeLabel.Text = "New Value (Decimal)"
            numDecimals.Visible = True
            numDecimals_label.Visible = True
            regView.Columns("Contents").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            CovertTextFields()
        Else
            readLabel.Text = "Current Value (Hex)"
            writeLabel.Text = "New Value (Hex)"
            numDecimals.Visible = False
            numDecimals_label.Visible = False
            regView.Columns("Contents").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            CovertTextFields()
        End If

    End Sub

    Private Sub CovertTextFields()

        Dim newText As String
        Dim val As Double
        Dim valU As UInteger
        Dim reg As RegClass
        Dim numDecimalPlaces As UInteger

        'get number of decimal places
        numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)

        'register view
        For i As Integer = 0 To regView.RowCount - 1
            newText = regView.Item("Contents", i).Value
            If newText <> "Not Read" Then
                Try
                    'get the reg associated with entry
                    reg = RegMap(regView.Item("Label", i).Value)
                    If scaleData Then
                        'data is in hex, need to scale to decimal
                        valU = Convert.ToUInt32(newText, 16)
                        'scale using DUT function
                        val = Dut.ScaleRegData(reg, valU)
                        'scale value
                        newText = val.ToString("f" + numDecimalPlaces.ToString())
                    Else
                        'data is in decimal, need to scale to hex
                        val = Convert.ToDouble(newText)
                        'un-scale using DUT function
                        valU = Dut.UnscaleRegData(reg, val)
                        'set string
                        newText = valU.ToString("X" + (reg.NumBytes * 2).ToString())
                    End If
                Catch ex As Exception
                    'don't need to explicitly handle anything here
                End Try
                regView.Item("Contents", i).Value = newText
            End If
        Next

        'copy from register view to current value
        newText = CurrentValue.Text
        Try
            CurrentValue.Text = regView.Item("Contents", regView.CurrentCell.RowIndex).Value
        Catch ex As Exception
            CurrentValue.Text = newText
        End Try

        'convert the write data
        newText = newValue.Text
        'grab the last clicked on register
        Try
            reg = RegMap(regView.Item("Label", regView.CurrentCell.RowIndex).Value)
        Catch ex As Exception
            'default to first register
            reg = RegMap.First
        End Try
        Try
            If scaleData Then
                'data is in hex, need to scale to decimal
                valU = Convert.ToUInt32(newText, 16)
                'scale using DUT function
                val = Dut.ScaleRegData(reg, valU)
                'scale value
                newText = val.ToString("f" + numDecimalPlaces.ToString())
            Else
                'data is in decimal, need to scale to hex
                val = Convert.ToDouble(newText)
                'un-scale using DUT function
                valU = Dut.UnscaleRegData(reg, val)
                'set string
                newText = valU.ToString("X" + (reg.NumBytes * 2).ToString())
            End If
        Catch ex As Exception
            'dont change
            newText = newValue.Text
        End Try
        newValue.Text = newText

    End Sub

    Private Sub InitializeDataGrid()

        'Save the scroll position for old page
        If regView.FirstDisplayedScrollingRowIndex <> -1 Then
            pagePosition(lastPageIndex) = regView.FirstDisplayedScrollingRowIndex
        End If

        'Repopulate new page
        Dim regStr(3) As String
        Dim readStr As String
        Dim regIndex As Integer = 0
        currentRegList = New List(Of RegClass)
        For Each reg In RegMap
            'skip registers which are not readable or writeable (example, BURST_RD)
            If reg.IsReadable Or reg.IsWriteable Then
                If reg.Page = selectPage.SelectedItem Then
                    currentRegList.Add(reg)
                    If reg.IsReadable Then
                        readStr = "Not Read"
                    Else
                        readStr = "Write Only"
                    End If
                    If regIndex >= regView.RowCount Then
                        regStr = {reg.Label, reg.Page.ToString(), reg.Address.ToString(), readStr}
                        regView.Rows.Add(regStr)
                    Else
                        regView.Item("Label", regIndex).Value = reg.Label
                        regView.Item("Page", regIndex).Value = reg.Page
                        regView.Item("Address", regIndex).Value = reg.Address
                        regView.Item("Contents", regIndex).Value = readStr
                    End If
                    regIndex += 1
                End If
            End If
        Next

        'set the start position
        regView.FirstDisplayedScrollingRowIndex = pagePosition(selectPage.SelectedIndex)
        lastPageIndex = selectPage.SelectedIndex
    End Sub

    Private Sub btn_DumpRegmap_Click(sender As Object, e As EventArgs) Handles btn_DumpRegmap.Click
        Dim readableRegMap As New List(Of RegClass)
        For Each reg In RegMap
            If reg.IsReadable Then
                readableRegMap.Add(reg)
            End If
        Next

        Dim values() As Long
        values = Dut.ReadSigned(readableRegMap)
        Dim strValues As New List(Of String)

        strValues.Add("Register, Page, Address, Value")
        Dim index As Integer = 0
        For Each reg In readableRegMap
            strValues.Add(reg.Label + "," + reg.Page.ToString() + "," + reg.Address.ToString() + "," + values(index).ToString())
            index += 1
        Next
        saveCSV("RegDump_" + SelectedPersonality, strValues.ToArray(), lastFilePath)

        'check if exceptions occurred
        ValidateAutomotiveSpiData()
    End Sub

    Private Sub measureDr_CheckedChanged(sender As Object, e As EventArgs) Handles measureDr.CheckedChanged
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub btn_writeRegMap_Click(sender As Object, e As EventArgs) Handles btn_writeRegMap.Click
        Dim fileBrowser As New OpenFileDialog
        Dim fileBrowseResult As DialogResult
        Dim loadPath As String
        Dim writeRegs As New List(Of RegClass)
        Dim writeVals As New List(Of UInteger)
        fileBrowser.Title = "Please Select the Register Dump File"
        fileBrowser.Filter = "Register Dump Files|*.csv"
        fileBrowseResult = fileBrowser.ShowDialog()
        If fileBrowseResult <> DialogResult.OK Then
            Exit Sub
        End If
        loadPath = fileBrowser.FileName

        Dim csvReader As New FileIO.TextFieldParser(loadPath)
        csvReader.TextFieldType = FileIO.FieldType.Delimited
        csvReader.SetDelimiters(",")

        Dim regLine As String()
        Dim reg As RegClass
        'clear header
        csvReader.ReadLine()
        While Not csvReader.EndOfData
            Try
                regLine = csvReader.ReadFields()
                'get register object
                reg = RegMap(regLine(0))
                'if readable then add value
                If reg.IsWriteable Then
                    writeRegs.Add(reg)
                    writeVals.Add(Convert.ToUInt32(regLine(3)))
                End If
            Catch ex As Exception
                If MessageBox.Show("Error Parsing CSV file! Continue?", "Error", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    csvReader.Close()
                    Exit Sub
                End If
            End Try
        End While
        csvReader.Close()

        'apply data to DUT
        Dut.WriteUnsigned(writeRegs, writeVals)

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub ValidateAutomotiveSpiData()

        'message string
        Dim msg As String

        'exception
        Dim ex As adisInterface.SpiException

        'number of exceptions logged
        Dim logLength As Integer = 0

        'exit if not set to validate
        If Not validateSpiData.Checked Then Exit Sub

        If m_AutoSpi.LoggedExceptionCount > 0 Then
            msg = m_AutoSpi.LoggedExceptionCount.ToString() + " SPI exception(s) have occurred: "
            ex = m_AutoSpi.DequeueLoggedException()
            While Not IsNothing(ex)
                If Not (TypeOf ex Is adisInterface.StateVectorException) Then
                    'skip logging SV
                    msg += Environment.NewLine + ex.Message
                    logLength += 1
                    If logLength > 9 Then
                        msg += Environment.NewLine + "and " + m_AutoSpi.LoggedExceptionCount.ToString() + " more..."
                        'clear queue
                        m_AutoSpi.LogExceptions = False
                        m_AutoSpi.LogExceptions = validateSpiData.Checked
                        Exit While
                    End If

                End If
                ex = m_AutoSpi.DequeueLoggedException()
            End While
            'disable continuous reads in case of error
            contRead.Checked = False
            MsgBox(msg)
        End If
    End Sub

    Private Sub validateSpiData_CheckedChanged(sender As Object, e As EventArgs) Handles validateSpiData.CheckedChanged
        m_AutoSpi.LogExceptions = validateSpiData.Checked
    End Sub

End Class
