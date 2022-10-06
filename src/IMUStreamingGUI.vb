'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          IMUStreamingGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   GUI to allow for burst mode streaming from IMU products.

Imports System.ComponentModel
Imports StreamDataLogger

Public Class IMUStreamingGUI
    Inherits FormBase

    Private WithEvents fileManager As Logger
    Private manager As BurstManager
    Private initialized As Boolean = False
    Private totalDRCaptures As Integer = 0
    Private measuredDrFreq As Double = Double.PositiveInfinity

    Private capturesUpdated As Boolean = False
    Private timeUpdated As Boolean = False
    Private recTimeEnabled As Boolean

    ''' <summary>
    ''' Load the application
    ''' </summary>
    Public Sub FormSetup() Handles Me.Load
        'Set up data ready drop down
        combo_DrSelect.Items.Add("DIO1")
        combo_DrSelect.Items.Add("DIO2")
        combo_DrSelect.Items.Add("DIO3")
        combo_DrSelect.Items.Add("DIO4")
        combo_DrSelect.Items.Add("Other")
        If m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO1.ToString Then
            combo_DrSelect.SelectedItem = "DIO1"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO2.ToString Then
            combo_DrSelect.SelectedItem = "DIO2"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO3.ToString Then
            combo_DrSelect.SelectedItem = "DIO3"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO4.ToString Then
            combo_DrSelect.SelectedItem = "DIO4"
        Else
            combo_DrSelect.SelectedItem = "Other"
        End If

        'Set up labels
        label_measuredFreq.Text = ""
        btn_cancel.Enabled = False
        text_numSamples.Text = "10000"

        'set up burst manager
        manager = New BurstManager(m_TopGUI.Dut, m_TopGUI.FX3, m_TopGUI.RegMap, m_TopGUI.SelectedPersonality)

        'Check if the manager knows about the selected device
        If manager.Device = BurstDevice.Unknown Then
            statusLabel.Text = "ERROR: Unknown IMU!"
            statusLabel.BackColor = m_TopGUI.ERROR_COLOR
            btn_start.Enabled = False
            group_config.Enabled = False
        ElseIf manager.Device = BurstDevice.NoBurst Then
            statusLabel.Text = "Burst read not supported!"
            statusLabel.BackColor = m_TopGUI.ERROR_COLOR
            btn_start.Enabled = False
            group_config.Enabled = False
        Else
            'set up config options based on burst manager
            If manager.Burst16Bit Then
                radio_16bit.Checked = True
            Else
                radio_32bit.Checked = True
            End If
            If manager.BurstInertialData Then
                radio_inertial.Checked = True
            Else
                radio_delta.Checked = True
            End If
            check_checksum.Checked = manager.BurstChecksum

            'disable options which are not available for current IMU
            panel_dataformat.Enabled = manager.ConfigurableData
            panel_wordsize.Enabled = manager.ConfigurableWordSize
            check_checksum.Enabled = manager.ConfigurableChecksum

            'set status
            statusLabel.Text = "Waiting"
            statusLabel.BackColor = Color.White
            check_drActive.Checked = m_TopGUI.FX3.DrActive
        End If

        'Set initialized flag
        initialized = True
        UpdateConfiguration()

    End Sub

    ''' <summary>
    ''' Handle app shutdown. Ensure all resources are properly disposed
    ''' </summary>
    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        m_TopGUI.btn_RealTime.Enabled = True
        If Not IsNothing(fileManager) Then fileManager.Dispose()
        Dispose()
    End Sub

    ''' <summary>
    ''' This function handles the case where a user updates the FX3 DR
    ''' active setting outside this form
    ''' </summary>
    Private Sub UpdateDrActiveState() Handles Me.Activated
        m_TopGUI.FX3.DrActive = check_drActive.Checked
    End Sub

    ''' <summary>
    ''' Handle capture start button being clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_start_Click(sender As Object, e As EventArgs) Handles btn_start.Click

        'generate time string for file name
        Dim timeString As String = "_" + DateTime.Now().ToString("s")
        Dim savePath As String
        timeString = timeString.Replace(":", "-")

        'Check whether the measured DR is valid
        If check_drActive.Checked Then
            m_TopGUI.FX3.DrActive = True
            If m_TopGUI.FX3.ReadDRFreq(m_TopGUI.FX3.DrPin, 1, 2000) > 10000 Or m_TopGUI.FX3.ReadDRFreq(m_TopGUI.FX3.DrPin, 1, 2000) < 0 Then
                If MessageBox.Show("Data ready frequency invalid. Is the correct DIO selected?", "Invalid Data Ready!", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
        End If

        'Get data output save location
        savePath = setSaveLocation(m_TopGUI.lastFilePath)
        If savePath Is Nothing Then
            MessageBox.Show("Please select a folder to save the stream data.", "Invalid save path!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'instantiate stream data logger
        fileManager = New Logger(manager, manager)

        'Set up stream data logger properties
        fileManager.RegList = manager.BurstRegisters
        fileManager.FileBaseName = m_TopGUI.SelectedPersonality + "_Burst" + timeString
        fileManager.FilePath = savePath
        fileManager.Buffers = totalDRCaptures
        fileManager.Captures = 1 'Number of times to read each register in the reg map
        fileManager.FileMaxDataRows = 1000000 'Keep this under 1M samples to open in Excel
        fileManager.BufferTimeoutSeconds = 10 'Timeout in seconds
        fileManager.BuffersPerWrite = 10000
        'set the register word order
        fileManager.LowerWordFirst = m_TopGUI.Dut.IsLowerFirst
        'for ADIS1655x product, the burst read transmits data upper 16-bits first
        'However, upper 16-bits have a higher address
        If manager.Device = BurstDevice.ADIS1655x Then
            fileManager.LowerWordFirst = False
        End If

        'hide other forms
        InteractWithOtherForms(True, Me)

        'run async. Note, this calls the BurstManager, which configures the FX3 as required for the connected IMU
        fileManager.RunAsync()

        'set up status label
        statusLabel.Text = "Writing Data"
        statusLabel.BackColor = Color.White

        'Disable user inputs during capture
        btn_cancel.Enabled = True
        combo_DrSelect.Enabled = False
        text_numSamples.Enabled = False
        btn_measureDR.Enabled = False
        check_drActive.Enabled = False
        btn_start.Enabled = False
        group_config.Enabled = False
        recTimeEnabled = text_recTime.Enabled
        text_recTime.Enabled = False

    End Sub

    ''' <summary>
    ''' Handle capture finishing after all data has been received
    ''' </summary>
    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        If InvokeRequired Then
            Invoke(New MethodInvoker(AddressOf CaptureDoneWork))
        Else
            CaptureDoneWork()
        End If
    End Sub

    ''' <summary>
    ''' Handle user clicking cancel button during capture
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        btn_start.Enabled = True
        If fileManager.Busy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Canceling"
            statusLabel.BackColor = m_TopGUI.ERROR_COLOR
        End If
    End Sub

    ''' <summary>
    ''' Measure data ready frequency when the button is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub MeasureDR_Click(sender As Object, e As EventArgs) Handles btn_measureDR.Click
        MeasureDrFreq(2000)
    End Sub

    ''' <summary>
    ''' Update register list whenever an option is changed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub config_Changed(sender As Object, e As EventArgs) Handles radio_16bit.CheckedChanged, radio_inertial.CheckedChanged, check_checksum.CheckedChanged
        UpdateConfiguration()
    End Sub

    ''' <summary>
    ''' Handle changes to the selected data ready pin
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub combo_DrSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles combo_DrSelect.SelectedIndexChanged
        Dim dio As String
        dio = combo_DrSelect.SelectedItem
        Select Case dio
            Case "DIO1"
                m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO1
            Case "DIO2"
                m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO2
            Case "DIO3"
                m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO3
            Case "DIO4"
                m_TopGUI.FX3.DrPin = m_TopGUI.FX3.DIO4
            Case Else
                'do not change data ready
        End Select
    End Sub

    ''' <summary>
    ''' Apply DR active setting to the EVAL-ADIS-FX3
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub check_drActive_CheckedChanged(sender As Object, e As EventArgs) Handles check_drActive.CheckedChanged
        m_TopGUI.FX3.DrActive = check_drActive.Checked
        If check_drActive.Checked Then
            MeasureDrFreq(500)
        Else
            capturesUpdated = True
            UpdateRecordTimeEstimate()
        End If
    End Sub

    ''' <summary>
    ''' Validate the number of samples entered
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub text_numSamples_TextChanged(sender As Object, e As EventArgs) Handles text_numSamples.TextChanged
        'ensure user can change time or captures
        If timeUpdated Then
            timeUpdated = False
            Exit Sub
        End If
        capturesUpdated = True
        'Check DR capture input
        Try
            totalDRCaptures = Convert.ToInt32(text_numSamples.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid Input")
            text_numSamples.Text = "10000"
            totalDRCaptures = 10000
        End Try
        UpdateRecordTimeEstimate()
    End Sub

    ''' <summary>
    ''' Update progress bar during capture
    ''' </summary>
    ''' <param name="e"></param>
    Private Sub progressUpdate(e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        Invoke(New MethodInvoker(Sub() CaptureProgressBurst.Value = e.ProgressPercentage))
    End Sub

#Region "Helper Functions"

    Private Sub MeasureDrFreq(timeout As Integer)
        measuredDrFreq = m_TopGUI.FX3.ReadDRFreq(m_TopGUI.FX3.DrPin, 1, 2000)
        label_measuredFreq.Text = FormatNumber(measuredDrFreq, 3).ToString + "  Hz"
        capturesUpdated = True
        UpdateRecordTimeEstimate()
    End Sub

    ''' <summary>
    ''' Clean up after a burst read capture has completed
    ''' </summary>
    Private Sub CaptureDoneWork()

        'check if a parsing error occurred?
        If manager.ParsingError <> "" Then
            statusLabel.Text = manager.ParsingError
            statusLabel.BackColor = m_TopGUI.ERROR_COLOR
        Else
            statusLabel.Text = "Done"
            statusLabel.BackColor = m_TopGUI.GOOD_COLOR
        End If

        'reset buttons
        btn_cancel.Enabled = False
        combo_DrSelect.Enabled = True
        text_numSamples.Enabled = True
        btn_measureDR.Enabled = True
        btn_start.Enabled = True
        group_config.Enabled = True
        check_drActive.Enabled = True
        text_recTime.Enabled = recTimeEnabled

        'Clear burst mode
        m_TopGUI.FX3.ClearBurstMode()

        'show forms
        InteractWithOtherForms(False, Me)
    End Sub

    ''' <summary>
    ''' Synchronize configuration between GUI and burst manager
    ''' </summary>
    Private Sub UpdateConfiguration()
        'exit if in the load method
        If Not initialized Then Exit Sub

        'apply settings
        manager.Burst16Bit = radio_16bit.Checked
        manager.BurstChecksum = check_checksum.Checked
        manager.BurstInertialData = radio_inertial.Checked

        'Refresh the register list in the GUI
        burstRegList.Clear()
        burstRegList.View = View.Details
        burstRegList.Columns.Add("Register", burstRegList.Width - 3, HorizontalAlignment.Left)
        For Each reg In manager.BurstRegisters
            Dim newItem As New ListViewItem()
            newItem.SubItems(0).Text = reg.Label
            burstRegList.Items.Add(newItem)
        Next
    End Sub

    Private Sub text_recTime_TextChanged(sender As Object, e As EventArgs) Handles text_recTime.TextChanged
        'ensure user can change time or captures
        If capturesUpdated Then
            capturesUpdated = False
            Exit Sub
        End If
        timeUpdated = True
        Dim seconds As Integer
        Dim values() As String
        Try
            values = text_recTime.Text.Split(":")
            seconds = Convert.ToInt32(values(2))
            seconds += (60 * Convert.ToInt32(values(1)))
            seconds += (60 * 60 * Convert.ToInt32(values(0)))
        Catch ex As Exception
            timeUpdated = False
            Exit Sub
        End Try
        totalDRCaptures = CInt(seconds * measuredDrFreq)
        text_numSamples.Text = totalDRCaptures.ToString()
    End Sub

    Private Sub UpdateRecordTimeEstimate()
        text_recTime.Enabled = True
        If check_drActive.Checked Then
            If Not Double.IsPositiveInfinity(measuredDrFreq) Then
                If Not timeUpdated Then
                    Dim seconds As Integer = 0
                    Dim minutes As Integer
                    Dim hours As Integer
                    seconds = totalDRCaptures / measuredDrFreq
                    minutes = Math.Floor(seconds / 60)
                    hours = Math.Floor(minutes / 60)
                    seconds = seconds Mod 60
                    minutes = minutes Mod 60
                    text_recTime.Text = hours.ToString() + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2")
                End If
            Else
                text_recTime.Text = "No data ready detected"
                text_recTime.Enabled = False
            End If
        Else
            text_recTime.Text = "Async Capture"
            text_recTime.Enabled = False
        End If
    End Sub

#End Region

End Class