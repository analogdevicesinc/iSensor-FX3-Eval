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
    Private currentRegList As List(Of RegClass)
    Private scaleData As Boolean

    Public Sub FormSetup() Handles Me.Load
        scaleData = False

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


        'Set the selected index
        selectPage.SelectedIndex = 0
        lastPageIndex = 0

        pageReadTimer = New Timer(500)
        pageReadTimer.Enabled = False
        AddHandler pageReadTimer.Elapsed, New ElapsedEventHandler(AddressOf PageReadCallback)

        drReadTimer = New Timer(500)
        drReadTimer.Enabled = False
        AddHandler drReadTimer.Elapsed, New ElapsedEventHandler(AddressOf DrReadCallBack)

    End Sub

    Private Sub FormRegisters_Load(sender As Object, e As EventArgs) Handles Me.Load
        regView.ClearSelection()
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
    End Sub

    Private Sub ReadPage()
        Dim readRegList As New List(Of RegClass)

        For Each reg In currentRegList
            If reg.IsReadable Then
                readRegList.Add(reg)
            Else
                'Dummy read reg for unreadable registers
                readRegList.Add(New RegClass With {.Page = reg.Page, .Address = 0})
            End If
        Next

        If scaleData Then
            Dim DutValuesDoub() As Double
            DutValuesDoub = m_TopGUI.Dut.ReadScaledValue(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesDoub
                regView.Item("Contents", regIndex).Value = value.ToString()
                regIndex += 1
            Next
        Else
            Dim DutValuesUInt() As UInteger
            DutValuesUInt = m_TopGUI.Dut.ReadUnsigned(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesUInt
                regView.Item("Contents", regIndex).Value = value.ToString("X")
                regIndex += 1
            Next
        End If

        'check the page register
        Dim expectedPage As Integer = currentRegList(0).Page
        Dim dutPage As Integer = m_TopGUI.Dut.ReadUnsigned(New RegClass With {.Page = expectedPage, .Address = 0, .NumBytes = 2})
        If dutPage <> expectedPage Then
            MsgBox("ERROR: Unable to load page " + expectedPage.ToString())
        End If


    End Sub

    Private Sub regView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles regView.CellClick
        Dim regLabel As String
        Try
            regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
            If scaleData Then
                Dim value As Double
                value = m_TopGUI.Dut.ReadScaledValue(m_TopGUI.RegMap(regLabel))
                CurrentValue.Text = value.ToString()
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString()
            Else
                Dim value As UInteger
                value = m_TopGUI.Dut.ReadUnsigned(m_TopGUI.RegMap(regLabel))
                CurrentValue.Text = value.ToString("X")
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("X")
            End If
        Catch ex As Exception
            CurrentValue.Text = "ERROR"
        End Try
    End Sub

    Private Sub PageReadCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadPage))
    End Sub

    Private Sub DrReadCallBack()
        drReadTimer.Enabled = False
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadDrFreq))
    End Sub

    Private Sub ReadDrFreq()
        Dim dr As Double = m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, 5000, 2)
        DrFreq.Text = FormatNumber(dr).ToString() + "Hz"
        If dr = Double.PositiveInfinity Then
            measureDr.Checked = False
        End If
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub closingTimerKill() Handles Me.FormClosing
        'Kill any running timers
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False
        m_TopGUI.btn_RegAccess.Enabled = True
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
        Else
            readLabel.Text = "Current Value (Hex)"
            writeLabel.Text = "New Value (Hex)"
        End If
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

        strValues.Add("Register, Value")
        Dim index As Integer = 0
        For Each reg In readableRegMap
            strValues.Add(reg.Label + "," + values(index).ToString())
            index += 1
        Next
        saveCSV("RegDump", strValues.ToArray(), m_TopGUI.lastFilePath)
    End Sub

    Private Sub measureDr_CheckedChanged(sender As Object, e As EventArgs) Handles measureDr.CheckedChanged
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub drActive_CheckedChanged(sender As Object, e As EventArgs) Handles drActive.CheckedChanged
        m_TopGUI.FX3.DrActive = drActive.Checked
    End Sub
End Class