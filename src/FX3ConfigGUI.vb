'File:          FX3ConfigGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows user to set FX3 configuration.

Imports FX3Api

Public Class FX3ConfigGUI
    Inherits FormBase

    Private m_regmappath As String

    Public Sub FormSetup() Handles Me.Load
        polarityInput.Items.Add("False: Idle Low")
        polarityInput.Items.Add("True: Idle High")

        phaseInput.Items.Add("False: Samples at idle-active edge")
        phaseInput.Items.Add("True: Samples at active-idle edge")

        chipSelectPolarityInput.Items.Add("False: Active Low")
        chipSelectPolarityInput.Items.Add("True: Active High")

        chipSelectControlInput.DataSource = ([Enum].GetValues(GetType(SpiChipselectControl)))

        leadTimeInput.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))

        lagTimeInput.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))

        DutVoltage.DataSource = ([Enum].GetValues(GetType(DutVoltage)))
        If m_TopGUI.FX3.ActiveFX3.BoardType <> FX3BoardType.iSensorFX3Board Then
            DutVoltage.Enabled = False
        End If

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

        SelectedRegMap.Text = m_TopGUI.RegMapPath.Substring(m_TopGUI.RegMapPath.LastIndexOf("\") + 1)
        m_regmappath = ""

        StallCyclesInput.ReadOnly = True

        UpdateFields()

        StatusLabel.Text = "Waiting..."
        StatusLabel.BackColor = Color.Yellow
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        m_TopGUI.btn_FX3Config.Enabled = True
    End Sub

    Private Sub UpdateFields()
        ' Populate the combo boxes and set initial values

        frequencyInput.Text = CStr(m_TopGUI.FX3.SclkFrequency)

        If m_TopGUI.FX3.Cpol Then
            polarityInput.SelectedItem = "True: Idle High"
        Else
            polarityInput.SelectedItem = "False: Idle Low"
        End If

        If m_TopGUI.FX3.Cpha Then
            phaseInput.SelectedItem = "True: Samples at active-idle edge"
        Else
            phaseInput.SelectedItem = "False: Samples at idle-active edge"
        End If

        If m_TopGUI.FX3.ChipSelectPolarity Then
            chipSelectPolarityInput.SelectedItem = "True: Active High"
        Else
            chipSelectPolarityInput.SelectedItem = "False: Active Low"
        End If

        chipSelectControlInput.SelectedItem = m_TopGUI.FX3.ChipSelectControl

        leadTimeInput.SelectedItem = m_TopGUI.FX3.ChipSelectLeadTime

        lagTimeInput.SelectedItem = m_TopGUI.FX3.ChipSelectLagTime

        DutVoltage.SelectedItem = m_TopGUI.FX3.DutSupplyMode

        wordLenInput.Text = CStr(m_TopGUI.FX3.WordLength)

        If m_TopGUI.FX3.IsLSBFirst Then
            lsbFirstInput.SelectedItem = "True: LSB comes first"
        Else
            lsbFirstInput.SelectedItem = "False: MSB comes first"
        End If

        stallTimeInput.Text = CStr(m_TopGUI.FX3.StallTime)
        StallCyclesInput.Text = CStr((m_TopGUI.FX3.StallTime / 1000000) / (1 / m_TopGUI.FX3.SclkFrequency))

        If m_TopGUI.FX3.DrActive Then
            dataReadyActiveInput.SelectedItem = "True: Data ready active"
        Else
            dataReadyActiveInput.SelectedItem = "False: Ignore data ready"
        End If

        If m_TopGUI.FX3.DrPolarity Then
            dataReadyPolarityInput.SelectedItem = "Low-to-High: Trigger on rising edge"
        Else
            dataReadyPolarityInput.SelectedItem = "High-to-Low: Trigger on falling edge"
        End If

        If m_TopGUI.FX3.ReadyPin.pinConfig = m_TopGUI.FX3.DIO1.pinConfig Then
            dataReadyPinInput.SelectedItem = "DIO1"
        ElseIf m_TopGUI.FX3.ReadyPin.pinConfig = m_TopGUI.FX3.DIO2.pinConfig Then
            dataReadyPinInput.SelectedItem = "DIO2"
        ElseIf m_TopGUI.FX3.ReadyPin.pinConfig = m_TopGUI.FX3.DIO3.pinConfig Then
            dataReadyPinInput.SelectedItem = "DIO3"
        ElseIf m_TopGUI.FX3.ReadyPin.pinConfig = m_TopGUI.FX3.DIO4.pinConfig Then
            dataReadyPinInput.SelectedItem = "DIO4"
        End If

        WatchdogEnable.Checked = m_TopGUI.FX3.WatchdogEnable
        WatchdogTimeout.Text = m_TopGUI.FX3.WatchdogTimeoutSeconds
        If Not WatchdogEnable.Checked Then
            WatchdogTimeout.ReadOnly = True
        End If

    End Sub

    Private Sub SetConfig_Click(sender As Object, e As EventArgs) Handles SetConfig.Click

        'Get the current values from the form and check for validity
        m_TopGUI.FX3.ChipSelectControl = chipSelectControlInput.SelectedItem
        m_TopGUI.FX3.ChipSelectLagTime = lagTimeInput.SelectedItem
        m_TopGUI.FX3.ChipSelectLeadTime = leadTimeInput.SelectedItem

        'clock phase
        If phaseInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            m_TopGUI.FX3.Cpha = True
        Else
            m_TopGUI.FX3.Cpha = False
        End If

        'clock polarity
        If polarityInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            m_TopGUI.FX3.Cpol = True
        Else
            m_TopGUI.FX3.Cpol = False
        End If

        'cs polarity
        If chipSelectPolarityInput.SelectedItem.ToString().Substring(0, 1) = "T" Then
            m_TopGUI.FX3.ChipSelectPolarity = True
        Else
            m_TopGUI.FX3.ChipSelectPolarity = False
        End If

        'LSB first mode
        If lsbFirstInput.SelectedItem = "True: LSB comes first" Then
            m_TopGUI.FX3.IsLSBFirst = True
        Else
            m_TopGUI.FX3.IsLSBFirst = False
        End If

        'sclk freq
        Dim frequency As UInt32
        Try
            frequency = Convert.ToUInt32(frequencyInput.Text)
            If frequency > 33000000 Then
                Throw New ArgumentException("ERROR: Frequency must be lower than 33MHz")
            End If
            m_TopGUI.FX3.SclkFrequency = frequency
        Catch ex As Exception
            MsgBox("ERROR: Invalid Frequency Value: " + ex.Message)
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
        End Try

        'SPI word length
        Dim wordLen As Byte
        Try
            wordLen = Convert.ToByte(wordLenInput.Text)
            If wordLen > 32 Or wordLen < 4 Then
                Throw New ArgumentException("ERROR: Word Length must be between 4 and 32 bits")
            End If
            m_TopGUI.FX3.WordLength = wordLen
        Catch ex As Exception
            MsgBox("ERROR: Invalid word length: " + ex.Message)
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
        End Try

        'stall time (us)
        Dim stallTime As UInt16
        Try
            stallTime = Convert.ToUInt16(stallTimeInput.Text)
            m_TopGUI.FX3.StallTime = stallTime
        Catch ex As Exception
            MsgBox("ERROR: Invalid stall time: " + ex.Message)
            StatusLabel.Text = "ERROR"
            StatusLabel.BackColor = Color.Red
        End Try

        'dr active
        If dataReadyActiveInput.SelectedItem = "True: Data ready active" Then
            m_TopGUI.FX3.DrActive = True
        ElseIf dataReadyActiveInput.SelectedItem = "False: Ignore data ready" Then
            m_TopGUI.FX3.DrActive = False
        Else
            MsgBox("ERROR: Invalid data ready active selection. Defaulting to false (asynchronous reads)")
            m_TopGUI.FX3.DrActive = False
        End If

        'dr polarity
        If dataReadyPolarityInput.SelectedItem = "Low-to-High: Trigger on rising edge" Then
            m_TopGUI.FX3.DrPolarity = True
        ElseIf dataReadyPolarityInput.SelectedItem = "High-to-Low: Trigger on falling edge" Then
            m_TopGUI.FX3.DrPolarity = False
        Else
            MsgBox("ERROR: Invalid data ready polarity selection. Defaulting to true (rising edge)")
            m_TopGUI.FX3.DrPolarity = True
        End If

        'selected DIO for dr
        Dim dio As String = dataReadyPinInput.SelectedItem
        Select Case dio
            Case "DIO1"
                m_TopGUI.FX3.ReadyPin = m_TopGUI.FX3.DIO1
            Case "DIO2"
                m_TopGUI.FX3.ReadyPin = m_TopGUI.FX3.DIO2
            Case "DIO3"
                m_TopGUI.FX3.ReadyPin = m_TopGUI.FX3.DIO3
            Case "DIO4"
                m_TopGUI.FX3.ReadyPin = m_TopGUI.FX3.DIO4
            Case Else
                MsgBox("ERROR: Invalid DR pin selected. Defaulting to DIO1")
                m_TopGUI.FX3.ReadyPin = m_TopGUI.FX3.DIO1
        End Select

        'set regmap
        If Not m_regmappath = "" Then
            Try
                m_TopGUI.RegMapPath = m_regmappath
            Catch ex As Exception
                MsgBox("ERROR: Invalid register map path: " + ex.Message)
                StatusLabel.Text = "ERROR"
                StatusLabel.BackColor = Color.Red
            End Try
        End If

        'set power supply mode
        If DutVoltage.SelectedItem <> m_TopGUI.FX3.DutSupplyMode Then
            m_TopGUI.FX3.DutSupplyMode = DutVoltage.SelectedItem
        End If

        'set watchdog parameters
        If WatchdogEnable.Checked <> m_TopGUI.FX3.WatchdogEnable Then
            m_TopGUI.FX3.WatchdogEnable = WatchdogEnable.Checked
        End If

        Dim watchdogTime As Integer = Convert.ToInt32(WatchdogTimeout.Text)
        If watchdogTime <> m_TopGUI.FX3.WatchdogTimeoutSeconds Then
            Try
                m_TopGUI.FX3.WatchdogTimeoutSeconds = watchdogTime
            Catch ex As Exception
                MsgBox("ERROR: Invalid watchdog period. Defaulting to 10s: " + ex.Message)
                StatusLabel.Text = "ERROR"
                StatusLabel.BackColor = Color.Red
                m_TopGUI.FX3.WatchdogTimeoutSeconds = 10
            End Try
        End If

        'save app settings
        m_TopGUI.SaveAppSettings()

        StatusLabel.Text = "Done"
        StatusLabel.BackColor = m_TopGUI.GOOD_COLOR

        UpdateFields()

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

    Private Sub WatchdogEnable_CheckedChanged(sender As Object, e As EventArgs) Handles WatchdogEnable.CheckedChanged
        If WatchdogEnable.Checked Then
            WatchdogTimeout.ReadOnly = False
        Else
            WatchdogTimeout.ReadOnly = True
        End If
    End Sub

End Class