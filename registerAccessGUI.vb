Imports RegMapClasses
Imports FX3Interface

Public Class registerAccessGUI

    Private conn As Connection

    Public Sub SetConn(ByRef newConnection As Connection)
        conn = newConnection
        For Each reg In conn.RegMap
            selectBox.Items.Add(reg.Label)
        Next
        selectBox.SelectedIndex = 0
    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopLevelGUI.Show()
    End Sub

    Private Sub RegSelected(sender As Object, e As EventArgs) Handles selectBox.TextChanged
        currentValueBox.Text = ""
    End Sub

    Private Sub readButton_Click(sender As Object, e As EventArgs) Handles readButton.Click
        Dim regName As String = selectBox.SelectedItem
        If IsNothing(regName) Then
            selectBox.SelectedIndex = 0
            regName = selectBox.SelectedItem
        End If
        Dim regValue As UInteger = conn.Dut.ReadUnsigned(conn.RegMap(regName))
        currentValueBox.Text = "0x" + regValue.ToString("X4")
    End Sub

    Private Sub WriteButton_Click(sender As Object, e As EventArgs) Handles WriteButton.Click
        Dim regName As String = selectBox.SelectedItem
        Dim regValue As Integer
        If IsNothing(regName) Then
            selectBox.SelectedIndex = 0
            regName = selectBox.SelectedItem
        End If
        Try
            regValue = Convert.ToInt32(NewInputBox.Text, 16)
            If regValue > &HFFFF Then
                Throw New ArgumentOutOfRangeException
            End If
            conn.Dut.WriteUnsigned(conn.RegMap(regName), regValue)
        Catch ex As Exception
            MsgBox("ERROR: Invalid input value")
        End Try
    End Sub

    Private Sub ReadDRFreq_Click(sender As Object, e As EventArgs) Handles ReadDRFreq.Click
        DRFreq.Text = FormatNumber(conn.FX3.ReadDRFreq(conn.FX3.DIO1, 1, 2000), 3).ToString + "  Hz"
    End Sub

    Private Sub registerAccessGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class