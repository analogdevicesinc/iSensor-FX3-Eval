Imports System.Threading

Public Class FacResetGUI

    Private m_Personality As DutPersonality
    Private m_testRunner As Thread

    Private Sub FormSetup() Handles Me.Load
        test_progress.Maximum = 11
        test_progress.Minimum = 0
        test_sts.ScrollBars = ScrollBars.Vertical
    End Sub

    Private Sub btn_startReset_Click(sender As Object, e As EventArgs) Handles btn_startReset.Click

        'reset STATUS forms
        test_sts.Text = ""
        test_progress.Value = 0

        'validate inputs
        m_Personality = Nothing
        For Each per In m_TopGUI.DutOptions
            If per.DisplayName = m_TopGUI.SelectedPersonality Then m_Personality = per
        Next
        If IsNothing(m_Personality) Then
            MessageBox.Show("DUT Personality Not Loaded!")
            Return
        End If
        If m_Personality.FlashUpdateCmdBit = -1 Then
            MessageBox.Show("The selected device does not support flash update! Aborting...")
            Return
        End If

        'ask if user wants to continue
        If MessageBox.Show("Are you sure you wish to restore the device to factory settings?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> DialogResult.OK Then
            Return
        End If

        'disable button
        btn_startReset.Enabled = False

        m_testRunner = New Thread(AddressOf FactoryResetWork)
        m_testRunner.Start()

    End Sub

    Private Sub FactoryResetWork()
        Dim freq As Double
        WriteStatus("Selected Device: " + m_Personality.DisplayName)
        m_TopGUI.FX3.DrActive = False
        WriteStatus("Starting SPI comms check...")
        UpdateProgress(1)
        If m_TopGUI.TestDUT() Then
            WriteStatus("DUT SPI communications check passed!")
            UpdateProgress(2)

            'set all regs with default value
            WriteStatus("Setting all registers to default values...")
            For Each reg In m_TopGUI.RegMap
                If Not IsNothing(reg.DefaultValue) Then
                    Try
                        m_TopGUI.Dut.WriteUnsigned(reg, CUInt(reg.DefaultValue))
                    Catch ex As Exception
                        WriteStatus("Error occurred writing " + reg.Label + ": " + ex.Message)
                    End Try
                    'should not need more than 1ms stall between control register writes
                    System.Threading.Thread.Sleep(1)
                End If
            Next
            UpdateProgress(3)

            WriteStatus("Performing readback on all registers...")
            WriteStatus(m_TopGUI.CheckDUTFactoryDefaults())
            UpdateProgress(4)

            'ensure that data ready is set to default, based on personality
            'could do this with reflection, but for 4 options its not really worth it
            WriteStatus("Configuring default data ready pin...")
            Select Case m_Personality.DrDIONumber
                Case 1
                    m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO1
                Case 2
                    m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO2
                Case 3
                    m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO3
                Case 4
                    m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO4
                Case Else
                    'default, dont change
            End Select
            UpdateProgress(5)

            'run flash update command
            WriteStatus("Starting flash update command...")
            m_TopGUI.RunDUTCommand(m_Personality.FlashUpdateCmdBit)
            UpdateProgress(6)

            '200ms delay should cover most IMU products
            System.Threading.Thread.Sleep(200)
            UpdateProgress(7)

            'wait for data ready pulsing (or 1000ms timeout, 1200ms total)
            WriteStatus("Waiting for data ready toggling...")
            freq = m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, 1000, 3)
            If freq = Double.PositiveInfinity Then
                WriteStatus("Warning! Data ready not toggling!")
            End If
            UpdateProgress(8)

            WriteStatus("Resetting DUT...")
            m_TopGUI.FX3.Reset()
            System.Threading.Thread.Sleep(250)
            UpdateProgress(9)
            WriteStatus("Reset Complete!")

            WriteStatus("Starting SPI comms check...")
            If m_TopGUI.TestDUT() Then
                WriteStatus("DUT SPI communications check passed!")
            Else
                WriteStatus("DUT SPI communications check failed!")
            End If
            UpdateProgress(10)

            WriteStatus("Performing readback on all registers...")
            WriteStatus(m_TopGUI.CheckDUTFactoryDefaults())
            UpdateProgress(11)
        Else
            WriteStatus("DUT SPI communications check failed! Cannot start factory reset process")
        End If

        're-enable button
        Invoke(Sub() btn_startReset.Enabled = True)
    End Sub

    Private Sub WriteStatus(line As String)
        If test_sts.InvokeRequired Then
            Invoke(Sub() test_sts.AppendText(line + Environment.NewLine))
        Else
            test_sts.AppendText(line + Environment.NewLine)
        End If
    End Sub

    Private Sub UpdateProgress(ProgressStage As Integer)
        If test_progress.InvokeRequired Then
            Invoke(Sub() test_progress.Value = ProgressStage)
        Else
            test_progress.Value = ProgressStage
        End If
    End Sub

    Private Sub Shutdown() Handles Me.Closed
        m_TopGUI.btn_FactoryReset.Enabled = True
    End Sub
End Class