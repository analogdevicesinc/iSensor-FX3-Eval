Imports FX3Interface

Public Class SpiSetupGUI

    Private conn As Connection

    Public Sub SetConn(ByRef newConnection As Connection)
        conn = newConnection

        polarityInput.Items.Add("False: Idle Low")
        polarityInput.Items.Add("True: Idle High")

        phaseInput.Items.Add("False: Samples at idle-active edge")
        phaseInput.Items.Add("True: Samples at active-idle edge")

        chipSelectPolarityInput.Items.Add("False: Active Low")
        chipSelectPolarityInput.Items.Add("True: Active High")

        chipSelectControlInput.DataSource = ([Enum].GetValues(GetType(SpiChipselectControl)))

        leadTimeInput.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))

        lagTimeInput.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))

        lsbFirstInput.Items.Add("True: LSB comes first")
        lsbFirstInput.Items.Add("False: MSB comes first")

        DutInput.DataSource = ([Enum].GetValues(GetType(DUTType)))

        dataReadyActiveInput.Items.Add("True: Data ready active")
        dataReadyActiveInput.Items.Add("False: Ignore data ready")

        dataReadyPolarityInput.Items.Add("Low-to-High: Trigger on rising edge")
        dataReadyPolarityInput.Items.Add("High-to-Low: Trigger on falling edge")

        dataReadyPinInput.Items.Add("DIO1")
        dataReadyPinInput.Items.Add("DIO2")
        dataReadyPinInput.Items.Add("DIO3")
        dataReadyPinInput.Items.Add("DIO4")

        UpdateFields()

        StatusLabel.Text = "Waiting..."
        StatusLabel.BackColor = Color.Yellow
    End Sub

    Private Sub UpdateFields()
        ' Populate the combo boxes and set initial values

        frequencyInput.Text = CStr(conn.FX3.SclkFrequency)

        If conn.FX3.Cpol Then
            polarityInput.SelectedItem = "True: Idle High"
        Else
            polarityInput.SelectedItem = "False: Idle Low"
        End If

        If conn.FX3.Cpha Then
            phaseInput.SelectedItem = "True: Samples at active-idle edge"
        Else
            phaseInput.SelectedItem = "False: Samples at idle-active edge"
        End If

        If conn.FX3.ChipSelectPolarity Then
            chipSelectPolarityInput.SelectedItem = "True: Active High"
        Else
            chipSelectPolarityInput.SelectedItem = "False: Active Low"
        End If

        chipSelectControlInput.SelectedItem = conn.FX3.ChipSelectControl

        leadTimeInput.SelectedItem = conn.FX3.ChipSelectLeadTime

        lagTimeInput.SelectedItem = conn.FX3.ChipSelectLagTime

        wordLenInput.Text = CStr(conn.FX3.WordLength)

        If conn.FX3.IsLSBFirst Then
            lsbFirstInput.SelectedItem = "True: LSB comes first"
        Else
            lsbFirstInput.SelectedItem = "False: MSB comes first"
        End If

        stallTimeInput.Text = CStr(conn.FX3.StallTime)

        StallCyclesInput.Text = conn.FX3.StallCycles.ToString

        If conn.FX3.DrActive Then
            dataReadyActiveInput.SelectedItem = "True: Data ready active"
        Else
            dataReadyActiveInput.SelectedItem = "False: Ignore data ready"
        End If

        If conn.FX3.DrPolarity Then
            dataReadyPolarityInput.SelectedItem = "Low-to-High: Trigger on rising edge"
        Else
            dataReadyPolarityInput.SelectedItem = "High-to-Low: Trigger on falling edge"
        End If

        If conn.FX3.ReadyPin.ToString = conn.FX3.DIO1.ToString Then
            dataReadyPinInput.SelectedItem = "DIO1"
        ElseIf conn.FX3.ReadyPin.ToString = conn.FX3.DIO2.ToString Then
            dataReadyPinInput.SelectedItem = "DIO2"
        ElseIf conn.FX3.ReadyPin.ToString = conn.FX3.DIO3.ToString Then
            dataReadyPinInput.SelectedItem = "DIO3"
        ElseIf conn.FX3.ReadyPin.ToString = conn.FX3.DIO4.ToString Then
            dataReadyPinInput.SelectedItem = "DIO4"
        End If

        DutInput.SelectedItem = conn.FX3.PartType

        TimerTickMultiplierDisplay.Text = conn.FX3.TimerTickScaleFactor.ToString
        TimerTickMultiplierDisplay.ReadOnly = True

    End Sub

    Private Sub SetConfig_Click(sender As Object, e As EventArgs) Handles SetConfig.Click

        'Get the current values from the form and check for validity
        conn.FX3.ChipSelectControl = chipSelectControlInput.SelectedItem
        conn.FX3.ChipSelectLagTime = lagTimeInput.SelectedItem
        conn.FX3.ChipSelectLeadTime = leadTimeInput.SelectedItem

        If phaseInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            conn.FX3.Cpha = True
        Else
            conn.FX3.Cpha = False
        End If

        If polarityInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            conn.FX3.Cpol = True
        Else
            conn.FX3.Cpol = False
        End If

        If chipSelectPolarityInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            conn.FX3.ChipSelectPolarity = True
        Else
            conn.FX3.ChipSelectPolarity = False
        End If

        Dim frequency As UInt32
        Try
            frequency = Convert.ToUInt32(frequencyInput.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid Frequency Value")
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
            Exit Sub
        End Try

        If frequency > 33000000 Then
            MsgBox("ERROR: Frequency must be lower than 33MHz")
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
            Exit Sub
        End If

        conn.FX3.SclkFrequency = frequency

        Dim wordLen As Byte
        Try
            wordLen = Convert.ToInt16(wordLenInput.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid word length")
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
            Exit Sub
        End Try

        If wordLen > 32 Or wordLen < 4 Then
            MsgBox("ERROR: Word Length must be between 4 and 32 bits")
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
            Exit Sub
        End If

        conn.FX3.WordLength = wordLen

        Dim stallTime As UInt16
        Dim stallTimeSet As Boolean = False
        Try
            stallTime = Convert.ToUInt16(stallTimeInput.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid stall time")
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
            Exit Sub
        End Try

        Dim stallCycles As UInt16
        Try
            stallCycles = Convert.ToUInt16(StallCyclesInput.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid stall cycles")
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
            Exit Sub
        End Try

        If Not stallTime = conn.FX3.StallTime Then
            conn.FX3.StallTime = stallTime
            StallCyclesInput.Text = conn.FX3.StallCycles.ToString()
        ElseIf Not stallCycles = conn.FX3.StallCycles Then
            conn.FX3.StallCycles = stallCycles
            stallTimeInput.Text = conn.FX3.StallTime.ToString()
        End If

        conn.FX3.PartType = DutInput.SelectedItem

        If dataReadyActiveInput.SelectedItem = "True: Data ready active" Then
            conn.FX3.DrActive = True
        ElseIf dataReadyActiveInput.SelectedItem = "False: Ignore data ready" Then
            conn.FX3.DrActive = False
        End If

        If dataReadyPolarityInput.SelectedItem = "Low-to-High: Trigger on rising edge" Then
            conn.FX3.DrPolarity = True
        ElseIf dataReadyPolarityInput.SelectedItem = "High-to-Low: Trigger on falling edge" Then
            conn.FX3.DrPolarity = False
        End If

        Dim dio As String = dataReadyPinInput.SelectedItem
        Select Case dio
            Case "DIO1"
                conn.FX3.ReadyPin = conn.FX3.DIO1
            Case "DIO2"
                conn.FX3.ReadyPin = conn.FX3.DIO2
            Case "DIO3"
                conn.FX3.ReadyPin = conn.FX3.DIO3
            Case "DIO4"
                conn.FX3.ReadyPin = conn.FX3.DIO4
            Case Else
                conn.FX3.ReadyPin = conn.FX3.DIO1
        End Select

        StatusLabel.Text = "Done"
        StatusLabel.BackColor = Color.Green

        UpdateFields()

    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopLevelGUI.Show()
    End Sub

    Private Sub SpiSetupGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class