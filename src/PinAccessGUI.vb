'File:          PinAccessGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com), Mason Edwards (mason.edwards@analog.com)
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
        col.HeaderText = "Pin"
        col.SortMode = DataGridViewColumnSortMode.NotSortable
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvPinList.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.HeaderText = "High/Low"
        col.Width = 60
        col.SortMode = DataGridViewColumnSortMode.NotSortable
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPinList.Columns.Add(col)

        ' create a list of pins to fill in the grid
        Dim FX3Api = GetType(FX3Connection)
        For Each prop In FX3Api.GetProperties()
            If prop.PropertyType = GetType(IPinObject) And Not prop.Name = "Reset" Then
                Dim currPin As IPinObject = m_TopGUI.FX3.GetType().GetProperty(prop.Name).GetValue(m_TopGUI.FX3)
                pins.Add(prop.Name.ToUpper, currPin)
                Dim state As String
                If m_TopGUI.FX3.isPWMPin(currPin) Then
                    state = "PWM"
                    MsgBox(prop.Name & " is in PWM mode, cannot read", MsgBoxStyle.DefaultButton1)
                ElseIf m_TopGUI.FX3.ReadPin(currPin) = 0 Then
                    state = "Low"
                Else
                    state = "High"
                End If
                dgvPinList.Rows.Add(prop.Name, state)
            End If
        Next

        ' makes the width of the dgv the same as the width of the columns
        dgvPinList.Height = dgvPinList.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dgvPinList.ColumnHeadersHeight + 2
        ' prevent it from auto selecting a pin
        dgvPinList.ClearSelection()
        ' allows the chart to update
        dgvPinList.ResumeLayout()

        ' set up pulse drive stuff
        ComboBoxHighLow.Items.Add("High")
        ComboBoxHighLow.Items.Add("Low")
        ComboBoxHighLow.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxHighLow.SelectedIndex = 0
        TextBoxPeriod.Text = "100"
        ' TODO: add options for mode selection
    End Sub

    Private Sub updatePinGrid()
        For Each row As DataGridViewRow In dgvPinList.Rows
            Dim currPin As IPinObject = pins(row.Cells(0).Value.ToUpper)
            Dim state As String
            If m_TopGUI.FX3.isPWMPin(currPin) Then
                ' only throw a message on first load, doing it repeatedly would be annoying
                state = "PWM"
            ElseIf m_TopGUI.FX3.ReadPin(currPin) = 0 Then
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
        If Not PinSelected() Then
            Exit Sub
        End If
        ' grid is set up to only allow one row selection
        Dim selectedRow As DataGridViewRow = dgvPinList.SelectedRows(0)
        pinName = selectedRow.Cells(0).Value

        Try
            currPin = pins(pinName.ToUpper)
        Catch
            MsgBox(pinName & " not found in dictionary.", MsgBoxStyle.Critical)
            Exit Sub
        End Try
        Dim answer As Integer
        If m_TopGUI.FX3.isPWMPin(currPin) Then
            Dim message As String = pinName & " is in PWM mode, writing to it will terminate that. Do you wish to perform the write?"
            answer = MsgBox(message, vbQuestion + vbYesNo + vbDefaultButton2)
            If answer = vbYes Then
                m_TopGUI.FX3.SetPin(currPin, level)
            End If
        Else
            m_TopGUI.FX3.SetPin(currPin, level)
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

    Private Sub ButtonPulseDrive_Click(sender As Object, e As EventArgs) Handles ButtonPulseDrive.Click
        Dim period As Double = 0
        Dim level As Boolean
        Dim mode As UInteger = 0
        Dim pin As IPinObject

        If Not PinSelected() Then
            Exit Sub
        End If

        Try
            pin = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToUpper)
        Catch
            MsgBox("Key not found in dictionary", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        ' get period
        Try
            period = Convert.ToDouble(TextBoxPeriod.Text)
            If period < 0 Then
                Throw New Exception("Negative values are invalid")
            End If
        Catch
            MsgBox("Invalid entry in Period box. Must be a positive double or integer.", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        ' get level
        If ComboBoxHighLow.Text = "High" Then
            level = 1
        ElseIf ComboBoxHighLow.Text = "Low" Then
            level = 0
        Else
            MsgBox("No level selected.", MsgBoxStyle.Exclamation)
        End If
        ' get mode
        ' TODO: get mode once it is implemented

        Try
            m_TopGUI.FX3.PulseDrive(pin, level, period, mode)
        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message())
        End Try

    End Sub

    Private Sub ButtonReadSelected_Click(sender As Object, e As EventArgs) Handles ButtonReadSelected.Click
        If Not PinSelected() Then
            Exit Sub
        End If
        Dim currPin As IPinObject = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        Dim state As String
        If m_TopGUI.FX3.isPWMPin(currPin) Then
            ' only throw a message on first load, doing it repeatedly would be annoying
            state = "PWM"
        ElseIf m_TopGUI.FX3.ReadPin(currPin) = 0 Then
            state = "Low"
        Else
            state = "High"
        End If
        dgvPinList.SelectedRows(0).Cells(1).Value = state
    End Sub

    Private Function PinSelected() As Boolean
        If dgvPinList.SelectedRows.Count = 0 Then
            MsgBox("No pin selected.", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function
End Class