'File:          RegisterAccessGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   GUI that allows for single register Read/Writes

Imports System.Timers
Imports RegMapClasses

Public Class registerAccessGUI
    Inherits FormBase

    Private pageList As List(Of Integer)
    Private pageReadTimer As Timer
    Private currentRegList As List(Of RegClass)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'get list of pages
        pageList = New List(Of Integer)
        For Each reg In TopGUI.RegMap
            If Not pageList.Contains(reg.Page) Then
                pageList.Add(reg.Page)
                selectPage.Items.Add(reg.Page)
            End If
        Next

        'Set up list view
        regView.View = View.Details
        regView.LabelEdit = False
        regView.GridLines = True
        regView.Columns.Add("Register", 110, HorizontalAlignment.Left)
        regView.Columns.Add("Page", 60, HorizontalAlignment.Left)
        regView.Columns.Add("Address", 60, HorizontalAlignment.Left)
        regView.Columns.Add("Bytes", 60, HorizontalAlignment.Left)
        regView.Columns.Add("Value", -2, HorizontalAlignment.Left)

        'Set the selected index
        selectPage.SelectedIndex = 0

        pageReadTimer = New Timer(250)
        pageReadTimer.Enabled = False
        AddHandler pageReadTimer.Elapsed, New ElapsedEventHandler(AddressOf TimerCallback)

    End Sub

    Private Sub ReadPage(pageNumber As Integer)
        currentRegList = New List(Of RegClass)
        Dim readRegList As New List(Of RegClass)
        For Each reg In TopGUI.RegMap
            If reg.Page = pageNumber Then
                currentRegList.Add(reg)
                If reg.IsReadable Then
                    readRegList.Add(reg)
                Else
                    'Dummy read reg for unreadable registers
                    readRegList.Add(New RegClass With {.Page = 0, .Address = 0})
                End If
            End If
        Next

        Dim DutValues() As UInteger = TopGUI.Dut.ReadUnsigned(readRegList)

        'Clear the list view
        regView.Items.Clear()

        'Add the DUT values to the regview
        Dim regStr(4) As String
        Dim regIndex As Integer = 0
        For Each reg In currentRegList
            regStr(0) = reg.Label
            regStr(1) = reg.Page.ToString()
            regStr(2) = reg.Address.ToString()
            regStr(3) = reg.NumBytes.ToString()
            If reg.IsReadable Then
                If reg.NumBytes = 1 Then
                    regStr(4) = "0x" + DutValues(regIndex).ToString("x2")
                ElseIf reg.NumBytes = 2 Then
                    regStr(4) = "0x" + DutValues(regIndex).ToString("x4")
                Else
                    regStr(4) = "0x" + DutValues(regIndex).ToString("x8")
                End If

            Else
                regStr(4) = "Not readable"
            End If
            regView.Items.Add(New ListViewItem(regStr))
            regIndex += 1
        Next

    End Sub

    Private Sub TimerCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf readPageWork))
    End Sub

    Private Sub WriteButton_Click(sender As Object, e As EventArgs) Handles WriteButton.Click
        Try
            TopGUI.Dut.WriteUnsigned(TopGUI.RegMap(regLabel.Text), Convert.ToUInt32(newVal.Text, 16))
        Catch ex As Exception
            MsgBox("Error: Invalid register write operation - " + ex.ToString())
        End Try
    End Sub

    Private Sub readBtn_Click(sender As Object, e As EventArgs) Handles readBtn.Click
        curVal.Text = "0x" + TopGUI.Dut.ReadUnsigned(TopGUI.RegMap(regLabel.Text)).ToString("x")
    End Sub

    Private Sub refreshBtn_CheckedChanged(sender As Object, e As EventArgs) Handles refreshBtn.CheckedChanged

        If refreshBtn.Checked Then
            'start a timer to read the selected page every 250ms
            pageReadTimer.Enabled = True
        Else
            'stop the timer
            pageReadTimer.Enabled = False
        End If

    End Sub

    Private Sub selectPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectPage.SelectedIndexChanged
        readPageWork()
    End Sub

    Private Sub regView_SelectedIndexChanged(sender As Object, e As EventArgs) Handles regView.SelectedIndexChanged
        If regView.SelectedItems.Count <> 0 Then
            Dim labelstring As String = regView.SelectedItems.Item(0).ToString()
            labelstring = labelstring.Substring(labelstring.IndexOf("{") + 1)
            labelstring = labelstring.Remove(labelstring.Length - 1)
            regLabel.Text = labelstring
        End If

    End Sub

    Private Sub readPageWork()
        ReadPage(selectPage.SelectedItem)
    End Sub

    Private Sub pageReadBtn_Click(sender As Object, e As EventArgs) Handles pageReadBtn.Click
        readPageWork()
    End Sub

End Class