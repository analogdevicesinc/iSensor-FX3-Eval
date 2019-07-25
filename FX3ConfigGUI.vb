'File:          FX3ConfigGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows user to set FX3 configuration.

Imports FX3Api

Public Class FX3ConfigGUI
    Inherits FormBase

    Private m_regmappath As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

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

        dataReadyActiveInput.Items.Add("True: Data ready active")
        dataReadyActiveInput.Items.Add("False: Ignore data ready")

        dataReadyPolarityInput.Items.Add("Low-to-High: Trigger on rising edge")
        dataReadyPolarityInput.Items.Add("High-to-Low: Trigger on falling edge")

        dataReadyPinInput.Items.Add("DIO1")
        dataReadyPinInput.Items.Add("DIO2")
        dataReadyPinInput.Items.Add("DIO3")
        dataReadyPinInput.Items.Add("DIO4")

        SelectedRegMap.Text = TopGUI.RegMapPath.Substring(TopGUI.RegMapPath.LastIndexOf("\") + 1)
        SelectedRegMap.ReadOnly = True
        m_regmappath = ""

        UpdateFields()

        StatusLabel.Text = "Waiting..."
        StatusLabel.BackColor = Color.Yellow

    End Sub

    Private Sub UpdateFields()
        ' Populate the combo boxes and set initial values

        frequencyInput.Text = CStr(TopGUI.FX3.SclkFrequency)

        If TopGUI.FX3.Cpol Then
            polarityInput.SelectedItem = "True: Idle High"
        Else
            polarityInput.SelectedItem = "False: Idle Low"
        End If

        If TopGUI.FX3.Cpha Then
            phaseInput.SelectedItem = "True: Samples at active-idle edge"
        Else
            phaseInput.SelectedItem = "False: Samples at idle-active edge"
        End If

        If TopGUI.FX3.ChipSelectPolarity Then
            chipSelectPolarityInput.SelectedItem = "True: Active High"
        Else
            chipSelectPolarityInput.SelectedItem = "False: Active Low"
        End If

        chipSelectControlInput.SelectedItem = TopGUI.FX3.ChipSelectControl

        leadTimeInput.SelectedItem = TopGUI.FX3.ChipSelectLeadTime

        lagTimeInput.SelectedItem = TopGUI.FX3.ChipSelectLagTime

        wordLenInput.Text = CStr(TopGUI.FX3.WordLength)

        If TopGUI.FX3.IsLSBFirst Then
            lsbFirstInput.SelectedItem = "True: LSB comes first"
        Else
            lsbFirstInput.SelectedItem = "False: MSB comes first"
        End If

        stallTimeInput.Text = CStr(TopGUI.FX3.StallTime)
        StallCyclesInput.Text = CStr((TopGUI.FX3.StallTime / 1000000) / (1 / TopGUI.FX3.SclkFrequency))

        If TopGUI.FX3.DrActive Then
            dataReadyActiveInput.SelectedItem = "True: Data ready active"
        Else
            dataReadyActiveInput.SelectedItem = "False: Ignore data ready"
        End If

        If TopGUI.FX3.DrPolarity Then
            dataReadyPolarityInput.SelectedItem = "Low-to-High: Trigger on rising edge"
        Else
            dataReadyPolarityInput.SelectedItem = "High-to-Low: Trigger on falling edge"
        End If

        If TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO1.ToString Then
            dataReadyPinInput.SelectedItem = "DIO1"
        ElseIf TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO2.ToString Then
            dataReadyPinInput.SelectedItem = "DIO2"
        ElseIf TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO3.ToString Then
            dataReadyPinInput.SelectedItem = "DIO3"
        ElseIf TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO4.ToString Then
            dataReadyPinInput.SelectedItem = "DIO4"
        End If

        TimerTickMultiplierDisplay.Text = TopGUI.FX3.TimerTickScaleFactor.ToString
        TimerTickMultiplierDisplay.ReadOnly = True

    End Sub

    Private Sub SetConfig_Click(sender As Object, e As EventArgs) Handles SetConfig.Click

        'Get the current values from the form and check for validity
        TopGUI.FX3.ChipSelectControl = chipSelectControlInput.SelectedItem
        TopGUI.FX3.ChipSelectLagTime = lagTimeInput.SelectedItem
        TopGUI.FX3.ChipSelectLeadTime = leadTimeInput.SelectedItem

        If phaseInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            TopGUI.FX3.Cpha = True
        Else
            TopGUI.FX3.Cpha = False
        End If

        If polarityInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            TopGUI.FX3.Cpol = True
        Else
            TopGUI.FX3.Cpol = False
        End If

        If chipSelectPolarityInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            TopGUI.FX3.ChipSelectPolarity = True
        Else
            TopGUI.FX3.ChipSelectPolarity = False
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

        TopGUI.FX3.SclkFrequency = frequency

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

        TopGUI.FX3.WordLength = wordLen

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

        If Not stallTime = TopGUI.FX3.StallTime Then
            TopGUI.FX3.StallTime = stallTime
            stallCycles = (TopGUI.FX3.StallTime / 1000000) / (1 / TopGUI.FX3.SclkFrequency)
        ElseIf Not stallCycles = (TopGUI.FX3.StallTime / 1000000) / (1 / TopGUI.FX3.SclkFrequency) Then
            stallTime = (stallCycles * (1 / TopGUI.FX3.SclkFrequency)) * 1000000
            TopGUI.FX3.StallTime = stallTime
        End If

        If dataReadyActiveInput.SelectedItem = "True: Data ready active" Then
            TopGUI.FX3.DrActive = True
        ElseIf dataReadyActiveInput.SelectedItem = "False: Ignore data ready" Then
            TopGUI.FX3.DrActive = False
        End If

        If dataReadyPolarityInput.SelectedItem = "Low-to-High: Trigger on rising edge" Then
            TopGUI.FX3.DrPolarity = True
        ElseIf dataReadyPolarityInput.SelectedItem = "High-to-Low: Trigger on falling edge" Then
            TopGUI.FX3.DrPolarity = False
        End If

        Dim dio As String = dataReadyPinInput.SelectedItem
        Select Case dio
            Case "DIO1"
                TopGUI.FX3.ReadyPin = TopGUI.FX3.DIO1
            Case "DIO2"
                TopGUI.FX3.ReadyPin = TopGUI.FX3.DIO2
            Case "DIO3"
                TopGUI.FX3.ReadyPin = TopGUI.FX3.DIO3
            Case "DIO4"
                TopGUI.FX3.ReadyPin = TopGUI.FX3.DIO4
            Case Else
                TopGUI.FX3.ReadyPin = TopGUI.FX3.DIO1
        End Select

        If Not m_regmappath = "" Then
            TopGUI.RegMapPath = m_regmappath
        End If

        StatusLabel.Text = "Done"
        StatusLabel.BackColor = Color.Green

        UpdateFields()

    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopGUI.Show()
    End Sub

    Private Sub SelectedRegMap_TextChanged(sender As Object, e As EventArgs) Handles SelectedRegMap.Click
        Dim m_searchpath As String
        m_searchpath = System.Reflection.Assembly.GetExecutingAssembly.Location
        m_searchpath = m_searchpath.Substring(0, m_searchpath.LastIndexOf("\") + 1)
        Dim fileBrowser As New OpenFileDialog
        fileBrowser.Title = "Please Select the Register Map File"
        fileBrowser.InitialDirectory = m_searchpath
        fileBrowser.Filter = "RegMap Files|*.csv"
        fileBrowser.ShowDialog()
        m_regmappath = fileBrowser.FileName
        SelectedRegMap.Text = m_regmappath.Substring(m_regmappath.LastIndexOf("\") + 1)
    End Sub

End Class