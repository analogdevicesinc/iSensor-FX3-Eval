Imports System.ComponentModel
Imports RegMapClasses
Imports System.Timers

Public Class FormRegisters
    Inherits FormBase

    Private pageList As List(Of Integer)
    Private pageReadTimer As Timer
    Private currentRegList As List(Of RegClass)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'get list of pages
        pageList = New List(Of Integer)
        For Each reg In TopGUI.RegMap
            If Not pageList.Contains(reg.Page) Then
                pageList.Add(reg.Page)
                selectPage.Items.Add(reg.Page)
            End If
        Next

        'Set the selected index
        selectPage.SelectedIndex = 0

        pageReadTimer = New Timer(500)
        pageReadTimer.Enabled = False
        AddHandler pageReadTimer.Elapsed, New ElapsedEventHandler(AddressOf TimerCallback)

    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles ButtonWrite.Click
        Dim writeValue As UInteger
        Dim regLabel As String
        Try
            writeValue = Convert.ToUInt32(newValue.Text, 16)
        Catch ex As Exception
            MsgBox("ERROR: Invalid write value")
        End Try


        Try
            regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
            TopGUI.Dut.WriteUnsigned(TopGUI.RegMap(regLabel), writeValue)
        Catch ex As Exception
            MsgBox("ERROR: Invalid write - " + ex.ToString())
        End Try

    End Sub

    Private Sub ReadPage()
        Dim readRegList As New List(Of RegClass)
        For Each reg In currentRegList
            If reg.IsReadable Then
                readRegList.Add(reg)
            Else
                'Dummy read reg for unreadable registers
                readRegList.Add(New RegClass With {.Page = 0, .Address = 0})
            End If
        Next

        Dim DutValues() As UInteger = TopGUI.Dut.ReadUnsigned(readRegList)

        Dim regIndex As Integer = 0
        For Each value In DutValues
            regView.Item("Contents", regIndex).Value = "0x" + value.ToString("x")
            regIndex += 1
        Next

    End Sub

    Private Sub TimerCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadPage))
    End Sub

    Private Sub closingTimerKill() Handles Me.FormClosing
        pageReadTimer.Enabled = False
    End Sub

    Private Sub selectPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectPage.SelectedIndexChanged

        'Load all the the registers on the given page into the data grid view
        currentRegList = New List(Of RegClass)

        Dim regStr(3) As String
        Dim readStr As String
        Dim regIndex As Integer = 0
        For Each reg In TopGUI.RegMap
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

        While regView.RowCount > currentRegList.Count()
            regView.Rows.Remove(regView.Rows(regView.RowCount() - 1))
        End While

    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        ReadPage()
    End Sub

    Private Sub contRead_CheckedChanged(sender As Object, e As EventArgs) Handles contRead.CheckedChanged
        If contRead.Checked Then
            'start a timer to read the selected page every 250ms
            pageReadTimer.Enabled = True
        Else
            'stop the timer
            pageReadTimer.Enabled = False
        End If
    End Sub

    Private Sub regView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles regView.CellClick
        Dim value As UInteger = 0
        Dim regLabel As String

        Try
            regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
            value = TopGUI.Dut.ReadUnsigned(TopGUI.RegMap(regLabel))
            CurrentValue.Text = "0x" + value.ToString("x")
        Catch ex As Exception
            CurrentValue.Text = "ERROR"
        End Try
    End Sub

End Class