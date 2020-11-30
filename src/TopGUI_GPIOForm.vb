'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          TopGUI_RegisterForm.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Top level GUI Pin access form implementation.

Imports AdisApi
Imports FX3Api

Partial Class TopGUI

    Private StartPWM As Boolean

    ' uses capitalized pin names as keys
    Private Property pins As New Dictionary(Of String, IPinObject)

    Private Sub btn_pullUp_Click(sender As Object, e As EventArgs) Handles btn_pullUp.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.PullUp)

    End Sub

    Private Sub btn_pullDown_Click(sender As Object, e As EventArgs) Handles btn_pullDown.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.PullDown)

    End Sub

    Private Sub btn_disableResistor_Click(sender As Object, e As EventArgs) Handles btn_disableResistor.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.None)

    End Sub

    Private Sub UpdateButton(Pin As IPinObject)
        If IsNothing(Pin) Then Exit Sub
        Dim PWMInfo As PinPWMInfo
        Try
            If FX3.isPWMPin(Pin) Then
                PWMInfo = FX3.GetPinPWMInfo(Pin)
                btn_StartPWM.Text = "Stop Pin PWM"
                StartPWM = False
                Freq.ReadOnly = True
                Freq.Text = PWMInfo.IdealFrequency.ToString()
                DutyCycle.ReadOnly = True
                DutyCycle.Text = PWMInfo.IdealDutyCycle.ToString()
            Else
                btn_StartPWM.Text = "Start Pin PWM"
                StartPWM = True
                Freq.ReadOnly = False
                DutyCycle.ReadOnly = False
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub PinSelectionChanged() Handles dgvPinList.SelectionChanged
        If dgvPinList.SelectedRows.Count > 0 Then
            UpdateButton(pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper))
        End If
    End Sub

    Private Sub startBtn_Click(sender As Object, e As EventArgs) Handles btn_StartPWM.Click
        If Not PinSelected() Then Exit Sub
        Dim pin As IPinObject = Nothing
        Try
            pin = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
            If StartPWM Then
                FX3.StartPWM(Convert.ToDouble(Freq.Text), Convert.ToDouble(DutyCycle.Text), pin)
                dgvPinList.SelectedRows(0).Cells(1).Value = "PWM"
            Else
                FX3.StopPWM(pin)
                'read after to report level on form
                If FX3.ReadPin(pin) = 0 Then
                    dgvPinList.SelectedRows(0).Cells(1).Value = "Low"
                Else
                    dgvPinList.SelectedRows(0).Cells(1).Value = "High"
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR: Caught exception " + ex.ToString())
        End Try
        UpdateButton(pin)
    End Sub

    Private Sub updatePinGrid()
        For Each row As DataGridViewRow In dgvPinList.Rows
            Dim currPin As IPinObject = pins(row.Cells(0).Value.ToUpper)
            Dim state As String
            If FX3.isPWMPin(currPin) Then
                ' only throw a message on first load, doing it repeatedly would be annoying
                state = "PWM"
            ElseIf FX3.ReadPin(currPin) = 0 Then
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
        If FX3.isPWMPin(currPin) Then
            Dim message As String = pinName & " is in PWM mode, writing to it will terminate that. Do you wish to perform the write?"
            answer = MsgBox(message, vbQuestion + vbYesNo + vbDefaultButton2)
            If answer = vbYes Then
                FX3.StopPWM(currPin)
                FX3.SetPin(currPin, level)
            Else
                Exit Sub
            End If
        Else
            FX3.SetPin(currPin, level)
        End If
        ' reading after performing the write will clear the values so don't do it
        If level = 0 Then
            dgvPinList.SelectedRows(0).Cells(1).Value = "Set Low"
        Else
            dgvPinList.SelectedRows(0).Cells(1).Value = "Set High"
        End If
    End Sub

    Private Sub ButtonWriteHigh_Click(sender As Object, e As EventArgs) Handles btn_WritePinHigh.Click
        writeLevel(1)
    End Sub

    Private Sub ButtonWriteLow_Click(sender As Object, e As EventArgs) Handles btn_WritePinLow.Click
        writeLevel(0)
    End Sub

    Private Sub ButtonReadAll_Click(sender As Object, e As EventArgs) Handles btn_ReadAllPins.Click
        updatePinGrid()
    End Sub

    Private Sub ButtonPulseDrive_Click(sender As Object, e As EventArgs) Handles btn_PulseDrive.Click
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

        Try
            FX3.PulseDrive(pin, level, period, mode)
        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message())
        End Try

    End Sub

    Private Sub ButtonReadSelected_Click(sender As Object, e As EventArgs) Handles btn_ReadPin.Click
        If Not PinSelected() Then Exit Sub
        Dim currPin As IPinObject = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        Dim state As String
        If FX3.isPWMPin(currPin) Then
            ' only throw a message on first load, doing it repeatedly would be annoying
            state = "PWM"
        ElseIf FX3.ReadPin(currPin) = 0 Then
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

    Private Sub btn_ReadGPIO_Click(sender As Object, e As EventArgs) Handles btn_ReadGPIO.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 63 Then
                Throw New ArgumentException("Pin number out of range. Max value 64")
            End If
        Catch ex As Exception
            MsgBox("Invalid Pin! " + ex.Message)
            Exit Sub
        End Try

        GPIO_Value.Text = FX3.ReadPin(New FX3PinObject(pinNum)).ToString()
    End Sub

    Private Sub btn_SetGPIOHigh_Click(sender As Object, e As EventArgs) Handles btn_SetGPIOHigh.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 63 Then
                Throw New ArgumentException("Pin number out of range. Max value 63")
            End If
        Catch ex As Exception
            MsgBox("Invalid Pin! " + ex.Message)
            Exit Sub
        End Try

        FX3.SetPin(New FX3PinObject(pinNum), 1)
    End Sub

    Private Sub btn_SetGPIOLow_Click(sender As Object, e As EventArgs) Handles btn_SetGPIOLow.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 63 Then
                Throw New ArgumentException("Pin number out of range. Max value 63")
            End If
        Catch ex As Exception
            MsgBox("Invalid Pin! " + ex.Message)
            Exit Sub
        End Try

        FX3.SetPin(New FX3PinObject(pinNum), 0)

    End Sub

    Private Sub btn_MeasureFreq_Click(sender As Object, e As EventArgs) Handles btn_MeasureFreq.Click
        If Not PinSelected() Then Exit Sub
        Dim currPin As IPinObject = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        If FX3.isPWMPin(currPin) Then
            Dim message As String = "Pin is in PWM mode, reading will terminate. Do you wish to read?"
            Dim answer = MsgBox(message, vbQuestion + vbYesNo + vbDefaultButton2)
            If answer = vbYes Then
                FX3.StopPWM(currPin)
                'read after to report level on form
                If FX3.ReadPin(currPin) = 0 Then
                    dgvPinList.SelectedRows(0).Cells(1).Value = "Low"
                Else
                    dgvPinList.SelectedRows(0).Cells(1).Value = "High"
                End If
            Else
                Exit Sub
            End If
        End If
        Dim val As Double = FX3.MeasurePinFreq(currPin, 1, 1000, 2)
        If val = Double.PositiveInfinity Then
            pinToggleFreq.Text = "Timeout"
        Else
            pinToggleFreq.Text = val.ToString("f1") + "Hz"
        End If
    End Sub

    Private Sub PinTabInit()
        'Defaults
        DutyCycle.Text = "0.5"
        Freq.Text = "2000.0"
        StartPWM = True

        Dim col As DataGridViewColumn

        'makes the chart not update until all additions have been made
        dgvPinList.SuspendLayout()

        dgvPinList.ReadOnly = True
        dgvPinList.AutoGenerateColumns = False
        dgvPinList.Columns.Clear()

        're-init
        pins.Clear()
        dgvPinList.Rows.Clear()

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
            If prop.PropertyType = GetType(IPinObject) And Not prop.Name = "ReadyPin" And Not prop.Name = "DrPin" Then
                Dim currPin As IPinObject = FX3.GetType().GetProperty(prop.Name).GetValue(FX3)
                pins.Add(prop.Name.ToUpper, currPin)
                Dim state As String
                If FX3.isPWMPin(currPin) Then
                    state = "PWM"
                ElseIf FX3.ReadPin(currPin) = 0 Then
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

    End Sub

End Class
