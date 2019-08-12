'File:          PinAccessGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   GUI to allow for pin reads/writes

Imports FX3Api
Imports AdisApi

Public Class PinAccessGUI
    Inherits FormBase

    ' uses capitalized pin names as keys
    Private Property pins As New Dictionary(Of String, IPinObject)

    Private Sub PinAccessGUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim col As DataGridViewColumn

        ' makes the chart not update until all additions have been made
        dgvPinList.SuspendLayout()

        dgvPinList.ReadOnly = True
        dgvPinList.AutoGenerateColumns = False
        dgvPinList.Columns.Clear()

        col = New DataGridViewTextBoxColumn
        col.DataPropertyName = "PinLabel"
        col.Name = "Pin"
        col.Width = 120
        dgvPinList.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.DataPropertyName = "State"
        col.Name = "High/Low"
        col.Width = 60
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPinList.Columns.Add(col)

        ' create a list of pins to fill in the grid
        Dim FX3Api = GetType(FX3Connection)
        For Each prop In FX3Api.GetProperties()
            If prop.PropertyType = GetType(IPinObject) And Not prop.Name = "Reset" Then
                Dim currPin As IPinObject = TopGUI.FX3.GetType().GetProperty(prop.Name).GetValue(TopGUI.FX3)
                pins.Add(prop.Name.ToUpper, currPin)
                Dim state As String
                If TopGUI.FX3.isPWMPin(currPin) Then
                    state = "PWM"
                    MsgBox(prop.Name & " is in PWM mode, cannot read", MsgBoxStyle.DefaultButton1)
                ElseIf TopGUI.FX3.ReadPin(currPin) = 0 Then
                    state = "Low"
                Else
                    state = "High"
                End If
                dgvPinList.Rows.Add(prop.Name, state)
            End If
        Next

        ' makes the width of the dgv the same as the width of the columns
        'dgvPinList.Width = dgvPinList.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 1
        'dgvPinList.Height = dgvPinList.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 1
        ' prevent it from auto selecting a pin
        dgvPinList.ClearSelection()
        ' allows the chart to update
        dgvPinList.ResumeLayout()
    End Sub

    Private Sub updatePinGrid()
        For Each row As DataGridViewRow In dgvPinList.Rows
            Dim currPin As IPinObject = pins(row.Cells(0).Value.ToUpper)
            Dim state As String
            If TopGUI.FX3.isPWMPin(currPin) Then
                ' only throw a message on first load, doing it repeatedly would be annoying
                state = "PWM"
            ElseIf TopGUI.FX3.ReadPin(currPin) = 0 Then
                state = "Low"
            Else
                state = "High"
            End If
            row.Cells(1).Value = state
        Next
    End Sub

    Private Sub writeLevel(level As Boolean)
        Dim currPin As IPinObject
        Dim pinName As String
        If dgvPinList.SelectedRows.Count = 0 Then
            MsgBox("No pin selected.", MsgBoxStyle.Exclamation)
            Exit Sub
        Else
            ' grid is set up to only allow one row selection
            Dim selectedRow As DataGridViewRow = dgvPinList.SelectedRows(0)
            pinName = selectedRow.Cells(0).Value
        End If
        Try
            currPin = pins(pinName.ToUpper)
        Catch
            MsgBox(pinName & " not found in dictionary.", MsgBoxStyle.Critical)
            Exit Sub
        End Try
        Dim answer As Integer
        If TopGUI.FX3.isPWMPin(currPin) Then
            Dim message As String = pinName & " is in PWM mode, writing to it will terminate that. Do you wish to perform the write?"
            answer = MsgBox(message, vbQuestion + vbYesNo + vbDefaultButton2)
            If answer = vbYes Then
                TopGUI.FX3.SetPin(currPin, level)
            End If
        Else
            TopGUI.FX3.SetPin(currPin, level)
        End If
        ' reading after performing the write will clear the values so don't do it
    End Sub

    Private Sub ButtonWriteHigh_Click(sender As Object, e As EventArgs) Handles ButtonWriteHigh.Click
        writeLevel(1)
    End Sub

    Private Sub ButtonWriteLow_Click(sender As Object, e As EventArgs) Handles ButtonWriteLow.Click
        writeLevel(0)
    End Sub

    Private Sub ButtonReadAll_Click(sender As Object, e As EventArgs) Handles ButtonReadAll.Click
        updatePinGrid()
    End Sub
End Class