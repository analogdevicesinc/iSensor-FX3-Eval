'File:          RegisterAccessGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   GUI that allows for single register Read/Writes

Public Class registerAccessGUI
    Inherits FormBase

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        For Each reg In TopGUI.RegMap
            selectBox.Items.Add(reg.Label)
        Next

    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopGUI.Show()
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
        Dim regValue As UInteger = TopGUI.Dut.ReadUnsigned(TopGUI.RegMap(regName))
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
            TopGUI.Dut.WriteUnsigned(TopGUI.RegMap(regName), regValue)
        Catch ex As Exception
            MsgBox("ERROR: Invalid input value")
        End Try
    End Sub

    Private Sub ReadDRFreq_Click(sender As Object, e As EventArgs) Handles ReadDRFreq.Click
        DRFreq.Text = FormatNumber(TopGUI.FX3.ReadDRFreq(TopGUI.FX3.DIO1, 1, 2000), 3).ToString + "  Hz"
    End Sub

End Class