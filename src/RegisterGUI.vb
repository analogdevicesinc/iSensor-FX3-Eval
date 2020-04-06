'File:          RegisterGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          8/23/2019
'Description:   Form for read/writing values to a DUT.

Imports System.ComponentModel
Imports RegMapClasses
Imports System.Timers

Public Class RegisterGUI
    Inherits FormBase

    Private pageList As List(Of Integer)
    Private pagePosition As List(Of Integer)
    Private lastPageIndex As Integer
    Private pageReadTimer As Timer
    Private drReadTimer As Timer
    Private drEnableTimer As Timer
    Private currentRegList As List(Of RegClass)
    Private scaleData As Boolean
    Private originalDRSetting As Boolean
    Private m_pageMessageList As List(Of Integer)

    Public Sub FormSetup() Handles Me.Load
        regView.ClearSelection()

        'disable dr active reads
        originalDRSetting = m_TopGUI.FX3.DrActive
        m_TopGUI.FX3.DrActive = False

        scaleData = False
        numDecimals.Visible = False
        numDecimals_label.Visible = False

        'get list of pages
        pageList = New List(Of Integer)
        pagePosition = New List(Of Integer)
        For Each reg In m_TopGUI.RegMap
            If Not pageList.Contains(reg.Page) Then
                pageList.Add(reg.Page)
                pagePosition.Add(0) 'Start at top
                selectPage.Items.Add(reg.Page)
            End If
        Next

        If m_TopGUI.FX3.SensorType = FX3Api.DeviceType.ADcmXL Then
            drActive.Enabled = False
        Else
            drActive.Checked = m_TopGUI.FX3.DrActive
        End If

        validateSpiData.Checked = False
        If m_TopGUI.FX3.SensorType = FX3Api.DeviceType.AutomotiveSpi Then
            validateSpiData.Visible = True
        Else
            validateSpiData.Visible = False
        End If

        'Set the selected index
        selectPage.SelectedIndex = 0
        lastPageIndex = 0
        m_pageMessageList = New List(Of Integer)

        pageReadTimer = New Timer(500)
        pageReadTimer.Enabled = False
        AddHandler pageReadTimer.Elapsed, New ElapsedEventHandler(AddressOf PageReadCallback)

        drReadTimer = New Timer(750)
        drReadTimer.Enabled = False
        AddHandler drReadTimer.Elapsed, New ElapsedEventHandler(AddressOf DrReadCallBack)

        'enable register value copying
        regView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

    End Sub

    Private Sub HiddenHandler() Handles Me.VisibleChanged
        If Not Me.Visible Then
            'disable dr / cont reads
            pageReadTimer.Enabled = False
            drReadTimer.Enabled = False
        Else
            pageReadTimer.Enabled = contRead.Checked
            drReadTimer.Enabled = measureDr.Checked
        End If
    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles ButtonWrite.Click

        Dim regLabel As String

        If scaleData Then
            Dim writeValue As Integer
            Try
                writeValue = Convert.ToInt32(newValue.Text, 10)
                regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
                m_TopGUI.Dut.WriteSigned(m_TopGUI.RegMap(regLabel), writeValue)
            Catch ex As Exception
                MsgBox("ERROR: Invalid write - " + ex.ToString())
            End Try
        Else
            Dim writeValue As UInteger
            Try
                writeValue = Convert.ToUInt32(newValue.Text, 16)
                regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
                m_TopGUI.Dut.WriteUnsigned(m_TopGUI.RegMap(regLabel), writeValue)
            Catch ex As Exception
                MsgBox("ERROR: Invalid write - " + ex.ToString())
            End Try
        End If

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub ReadPage()
        Dim readRegList As New List(Of RegClass)
        Dim numDecimalPlaces As UInteger

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
                MsgBox("Invalid number Of Decimal places!" + ex.Message)
                numDecimalPlaces = 2
                numDecimals.Text = "2"
            End Try
            Dim DutValuesDoub() As Double
            DutValuesDoub = m_TopGUI.Dut.ReadScaledValue(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesDoub
                If currentRegList(regIndex).IsReadable Then
                    regView.Item("Contents", regIndex).Value = value.ToString("f" + numDecimalPlaces.ToString())
                Else
                    regView.Item("Contents", regIndex).Value = "Cannot Read"
                End If
                regIndex += 1
            Next
        Else
            Dim DutValuesUInt() As UInteger
            DutValuesUInt = m_TopGUI.Dut.ReadUnsigned(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesUInt
                If currentRegList(regIndex).IsReadable Then
                    regView.Item("Contents", regIndex).Value = value.ToString("X" + (currentRegList(regIndex).NumBytes * 2).ToString())
                Else
                    regView.Item("Contents", regIndex).Value = "Cannot Read"
                End If
                regIndex += 1
            Next
        End If

        'check the page register
        If m_TopGUI.FX3.PartType = FX3Api.DUTType.LegacyIMU Then Exit Sub
        Dim expectedPage As Integer = currentRegList(0).Page
        If m_pageMessageList.Contains(expectedPage) Then
            Exit Sub
        End If
        Dim dutPage As Integer = m_TopGUI.Dut.ReadUnsigned(New RegClass With {.Page = expectedPage, .Address = 0, .NumBytes = 2})
        If dutPage <> expectedPage Then
            m_pageMessageList.Add(expectedPage)
            MsgBox("ERROR: Unable to load page " + expectedPage.ToString())
        End If

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub regView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles regView.CellClick
        Dim regLabel As String
        Dim reg As RegClass
        Dim numDecimalPlaces As UInteger
        Try
            regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
            reg = m_TopGUI.RegMap(regLabel)
            If scaleData Then
                numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
                Dim value As Double
                value = m_TopGUI.Dut.ReadScaledValue(reg)
                CurrentValue.Text = value.ToString("f" + numDecimalPlaces.ToString())
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("f" + numDecimalPlaces.ToString())
            Else
                Dim value As UInteger
                value = m_TopGUI.Dut.ReadUnsigned(reg)
                CurrentValue.Text = value.ToString("X" + (reg.NumBytes * 2).ToString())
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("X" + (reg.NumBytes * 2).ToString())
            End If
        Catch ex As Exception
            CurrentValue.Text = "ERROR"
        End Try

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub PageReadCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadPage))
    End Sub

    Private Sub DrReadCallBack()
        drReadTimer.Enabled = False
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadDrFreq))
    End Sub

    Private Sub EnableDrTimer()
        drEnableTimer.Dispose()
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub ReadDrFreq()
        Dim dr As Double = m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, 2500, 2)
        DrFreq.Text = FormatNumber(dr).ToString() + "Hz"
        If dr = Double.PositiveInfinity Then
            measureDr.Checked = False
        End If
        'if data ready is less than 10Hz want to shove some delays in here to prevent form from locking up a bunch
        If dr < 10 Then
            're-enable via timer, 5x the sample period delay
            drEnableTimer = New Timer(5000 / dr)
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
        m_TopGUI.btn_RegAccess.Enabled = True

        'reset dr active setting
        m_TopGUI.FX3.DrActive = originalDRSetting Or drActive.Checked
    End Sub

    Private Sub selectPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectPage.SelectedIndexChanged

        'Load all the registers on the given page into the data grid view
        initializedDataGrid()

        While regView.RowCount > currentRegList.Count()
            regView.Rows.Remove(regView.Rows(regView.RowCount() - 1))
        End While

    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
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

        'regview
        For i As Integer = 0 To regView.RowCount - 1
            newText = regView.Item("Contents", i).Value
            If newText <> "Not Read" Then
                Try
                    'get the reg associated with entry
                    reg = m_TopGUI.RegMap(regView.Item("Label", i).Value)
                    If scaleData Then
                        'data is in hex, need to scale to decimal
                        valU = Convert.ToUInt32(newText, 16)
                        'scale using DUT function
                        val = m_TopGUI.Dut.ScaleRegData(reg, valU)
                        'get number of decimal places
                        numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
                        'scale value
                        newText = val.ToString("f" + numDecimalPlaces.ToString())
                    Else
                        'data is in decimal, need to scale to hex
                        val = Convert.ToDouble(newText)
                        'un-scale using DUT function
                        valU = m_TopGUI.Dut.UnscaleRegData(reg, val)
                        'set string
                        newText = valU.ToString("X" + (reg.NumBytes * 2).ToString())
                    End If
                Catch ex As Exception
                    'don't need to explicitly handle anything here
                End Try
                regView.Item("Contents", i).Value = newText
            End If
        Next

        'copy from regview to current value
        newText = CurrentValue.Text
        Try
            CurrentValue.Text = regView.Item("Contents", regView.CurrentCell.RowIndex).Value
        Catch ex As Exception
            CurrentValue.Text = newText
        End Try

    End Sub

    Private Sub initializedDataGrid()

        'Save the scroll position for old page
        If regView.FirstDisplayedScrollingRowIndex <> -1 Then
            pagePosition(lastPageIndex) = regView.FirstDisplayedScrollingRowIndex
        End If

        'Repopulate new page
        Dim regStr(3) As String
        Dim readStr As String
        Dim regIndex As Integer = 0
        currentRegList = New List(Of RegClass)
        For Each reg In m_TopGUI.RegMap
            If reg.Page = selectPage.SelectedItem Then
                currentRegList.Add(reg)
                If reg.IsReadable Then
                    readStr = "Not Read"
                Else
                    readStr = "Cannot Read"
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
        Next

        'set the start position
        regView.FirstDisplayedScrollingRowIndex = pagePosition(selectPage.SelectedIndex)
        lastPageIndex = selectPage.SelectedIndex
    End Sub

    Private Sub btn_DumpRegmap_Click(sender As Object, e As EventArgs) Handles btn_DumpRegmap.Click
        Dim readableRegMap As New List(Of RegClass)
        For Each reg In m_TopGUI.RegMap
            If reg.IsReadable Then
                readableRegMap.Add(reg)
            End If
        Next

        Dim values() As UInteger
        values = m_TopGUI.Dut.ReadUnsigned(readableRegMap)
        Dim strValues As New List(Of String)

        strValues.Add("Register, Page, Address, Value")
        Dim index As Integer = 0
        For Each reg In readableRegMap
            strValues.Add(reg.Label + "," + reg.Page.ToString() + "," + reg.Address.ToString() + "," + values(index).ToString())
            index += 1
        Next
        saveCSV("RegDump", strValues.ToArray(), m_TopGUI.lastFilePath)

        'check if exceptions occurred
        ValidateAutomotiveSpiData()
    End Sub

    Private Sub measureDr_CheckedChanged(sender As Object, e As EventArgs) Handles measureDr.CheckedChanged
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub drActive_CheckedChanged(sender As Object, e As EventArgs) Handles drActive.CheckedChanged
        m_TopGUI.FX3.DrActive = drActive.Checked
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        regView.Height = Me.Height - 90
        btn_DumpRegmap.Top = Me.Height - 95
        btn_writeRegMap.Top = Me.Height - 95
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
                reg = m_TopGUI.RegMap(regLine(0))
                'if readable then add value
                If reg.IsWriteable Then
                    writeRegs.Add(reg)
                    writeVals.Add(Convert.ToUInt32(regLine(3)))
                End If
            Catch ex As Exception
                MsgBox("ERROR Parsing CSV file. " + ex.Message())
                csvReader.Close()
                Exit Sub
            End Try
        End While
        csvReader.Close()

        'apply data to DUT
        m_TopGUI.Dut.WriteUnsigned(writeRegs, writeVals)

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

        If m_TopGUI.m_AutoSpi.LoggedExceptionCount > 0 Then
            msg = m_TopGUI.m_AutoSpi.LoggedExceptionCount.ToString() + " SPI exception(s) have occurred: "
            ex = m_TopGUI.m_AutoSpi.DequeueLoggedException()
            While Not IsNothing(ex)
                msg += Environment.NewLine + ex.Message
                logLength += 1
                If logLength > 9 Then
                    msg += Environment.NewLine + "and " + m_TopGUI.m_AutoSpi.LoggedExceptionCount.ToString() + " more..."
                    'clear queue
                    m_TopGUI.m_AutoSpi.LogExceptions = False
                    m_TopGUI.m_AutoSpi.LogExceptions = validateSpiData.Checked
                    Exit While
                End If
                ex = m_TopGUI.m_AutoSpi.DequeueLoggedException()
            End While
            'disable continuous reads in case of error
            contRead.Checked = False
            MsgBox(msg)
        End If
    End Sub

    Private Sub validateSpiData_CheckedChanged(sender As Object, e As EventArgs) Handles validateSpiData.CheckedChanged
        m_TopGUI.m_AutoSpi.LogExceptions = validateSpiData.Checked
    End Sub

End Class