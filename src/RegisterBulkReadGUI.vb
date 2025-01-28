'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          RegisterBulkReadGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Allows for bulk data logging from registers. Can be triggered on a data ready signal for IMUs

Imports AdisApi
Imports System.ComponentModel
Imports StreamDataLogger

Public Class RegisterBulkReadGUI
    Inherits FormBase

    Private WithEvents fileManager As Logger
    Private totalDRCaptures As Integer = 0
    Private measuredDrFreq As Double = Double.PositiveInfinity

    Private capturesUpdated As Boolean = False
    Private timeUpdated As Boolean = False
    Private recTimeEnabled As Boolean

    Public Sub FormSetup() Handles Me.Load

        'create control handle if needed
        If Not IsHandleCreated Then
            CreateHandle()
        End If

        'populate selected register list from the last run
        For Each reg In m_TopGUI.RegMap
            RegisterList.Items.Add(reg.Label)
        Next
        RegisterList.SelectedIndex = 0

        'add DIO options
        DRDIO.Items.Add("DIO1")
        DRDIO.Items.Add("DIO2")
        DRDIO.Items.Add("DIO3")
        DRDIO.Items.Add("DIO4")
        If m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO1.ToString Then
            DRDIO.SelectedItem = "DIO1"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO2.ToString Then
            DRDIO.SelectedItem = "DIO2"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO3.ToString Then
            DRDIO.SelectedItem = "DIO3"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO4.ToString Then
            DRDIO.SelectedItem = "DIO4"
        End If

        'Check box options
        MeasureDR.Enabled = m_TopGUI.FX3.DrActive
        DrActiveBox.Checked = m_TopGUI.FX3.DrActive
        ValidateDR.Checked = m_TopGUI.FX3.DrActive
        ValidateDR.Enabled = m_TopGUI.FX3.DrActive
        check_LogTimestamps.Checked = m_TopGUI.logTimestampData
        check_ScaleData.Checked = m_TopGUI.logScaledData

        DrFreq.Text = ""
        StreamingAVARCancelButton.Enabled = False
        statusLabel.Text = "Waiting"
        statusLabel.BackColor = Color.White

        'Add columns to register selection and set autosize mode
        selectedRegview.View = View.Details
        selectedRegview.Columns.Add("Register")
        selectedRegview.Columns.Add("Bit Width")
        selectedRegview.Columns(1).Width = 60
        selectedRegview.Columns(0).Width = selectedRegview.Width - selectedRegview.Columns(1).Width - 4

        'Set load register logging list
        selectedRegview.Items.Clear()
        If m_TopGUI.BulkRegList.Count > 0 Then
            For Each item In m_TopGUI.BulkRegList
                selectedRegview.Items.Add(item)
            Next
        Else
            'Load from the register selection
            For Each reg In m_TopGUI.dataPlotRegs
                If m_TopGUI.RegMap.Contains(reg.Reg.Label) Then
                    selectedRegview.Items.Add(New ListViewItem(New String() {reg.Reg.Label, (8 * reg.Reg.NumBytes).ToString()}))
                End If
            Next
        End If

        NumberDRToCapture.Text = m_TopGUI.numRegSamples.ToString()
        linesPerFile.Text = m_TopGUI.linesPerFile.ToString()
        UpdateRegCountLabel()
        SetupToolTips()
        UpdateRecordTimeEstimate()

    End Sub

    ''' <summary>
    ''' This function handles the case where a user updates the FX3 DR
    ''' active setting outside this form
    ''' </summary>
    Private Sub UpdateDrActiveState() Handles Me.Activated
        m_TopGUI.FX3.DrActive = DrActiveBox.Checked
    End Sub

    Private Sub SetupToolTips()

        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(RegisterList, "Select register from the loaded register map")
        tip0.SetToolTip(selectedRegview, "Currently selected registers to stream")
        tip0.SetToolTip(regStreamingList, "Number of registers set to log from")
        tip0.SetToolTip(AddRegisterButton, "Add the currently selected register")
        tip0.SetToolTip(RemoveRegisterButton, "Remove the selected register")
        tip0.SetToolTip(ClearAllButton, "Clear all selected registers")
        tip0.SetToolTip(btn_loadregs, "Load a list of registers to log from a .csv file")
        tip0.SetToolTip(btn_saveregs, "Save the currently selected list of registers to log to a .csv file")
        tip0.SetToolTip(DRDIO, "Select Data Ready Pin")
        tip0.SetToolTip(DrActiveBox, "Select if register reads are synchronized to the data ready signal")
        tip0.SetToolTip(MeasureDR, "Measure the data ready frequency")
        tip0.SetToolTip(RegisterList, "Select register from the loaded register map to log")
        tip0.SetToolTip(DrFreq, "The current data ready frequency")
        tip0.SetToolTip(NumberDRToCapture, "The total number of reads of the selected register list to log")
        tip0.SetToolTip(linesPerFile, "Maximum lines in a single log file")
        tip0.SetToolTip(MainButton, "Start the register stream operation")
        tip0.SetToolTip(StreamingAVARCancelButton, "Cancel a running register stream operation")
        tip0.SetToolTip(text_recTime, "Set or view the capture time (hh:mm:ss). This option is only active when reading synchronous to the IMU data ready")
        tip0.SetToolTip(check_LogTimestamps, "Log USB packet timestamps and log duration to file")
        tip0.SetToolTip(check_ScaleData, "Log data scaled to native units based on the loaded RegMap")
    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing

        'Save the list-view contents
        m_TopGUI.BulkRegList.Clear()
        For Each item In selectedRegview.Items
            m_TopGUI.BulkRegList.Add(item)
        Next

        'sample settings
        m_TopGUI.numRegSamples = Convert.ToInt32(NumberDRToCapture.Text)
        m_TopGUI.linesPerFile = Convert.ToInt32(linesPerFile.Text)
        'Log settings
        m_TopGUI.logTimestampData = check_LogTimestamps.Checked
        m_TopGUI.logScaledData = check_ScaleData.Checked

        're-enable button
        m_TopGUI.btn_BulkRegRead.Enabled = True

        'dispose
        If Not IsNothing(fileManager) Then
            fileManager.Dispose()
        End If
        Dispose()

    End Sub

    Private Sub AddRegisterButton_Click(sender As Object, e As EventArgs) Handles AddRegisterButton.Click
        Dim reg = m_TopGUI.RegMap(RegisterList.SelectedItem)
        selectedRegview.Items.Add(New ListViewItem(New String() {reg.Label, (8 * reg.NumBytes).ToString()}))
        UpdateRegCountLabel()
    End Sub

    Private Sub RemoveRegisterButton_Click(sender As Object, e As EventArgs) Handles RemoveRegisterButton.Click
        If IsNothing(selectedRegview.FocusedItem) Then
            MessageBox.Show("Please select an Item to Delete", "Remove register warning", MessageBoxButtons.OK)
        Else
            selectedRegview.Items.RemoveAt(selectedRegview.FocusedItem.Index)
        End If
        UpdateRegCountLabel()
    End Sub

    Private Sub ClearAllButton_Click(sender As Object, e As EventArgs) Handles ClearAllButton.Click
        Dim result As Integer
        result = MessageBox.Show("Are you sure you want to clear all registers?", "Clear all registers?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            selectedRegview.Items.Clear()
        End If
        UpdateRegCountLabel()
    End Sub

    Private Sub UpdateRegCountLabel()
        regStreamingList.Text = "Register Streaming List (" + selectedRegview.Items.Count.ToString() + ")"
    End Sub

    Private Sub MainButton_Click(sender As Object, e As EventArgs) Handles MainButton.Click

        Dim savePath As String
        Dim timeString As String = "_" + DateTime.Now().ToString("s")
        timeString = timeString.Replace(":", "-")

        'Check whether user selected registers to stream
        If selectedRegview.Items.Count <= 0 Then
            MessageBox.Show("Please select registers to stream before starting", "No registers selected!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Check whether the number of samples to capture is valid
        If NumberDRToCapture.Text <= 0 Then
            MessageBox.Show("Please enter a number of samples to capture before starting", "No number of samples entered!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Check whether the measured DR is valid
        If m_TopGUI.FX3.DrActive And ValidateDR.Checked Then
            'measure data ready frequency
            MeasureDrFreq(10000)
            'allow a freq up to 16KHz
            If measuredDrFreq > 16000 Or measuredDrFreq = Double.PositiveInfinity Then
                If MessageBox.Show("Data ready frequency measured invalid. Continue?", "Invalid Data Ready!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
        End If

        'Build list of registers to stream
        Dim regList As New List(Of RegMapClasses.RegClass)
        For Each item As ListViewItem In selectedRegview.Items
            regList.Add(m_TopGUI.RegMap(item.Text))
        Next

        'Check the time it will take to capture each frame and ask the user if it exceeds the DR period
        If m_TopGUI.FX3.DrActive And ValidateDR.Checked Then
            Dim drPeriod As Double = 1 / measuredDrFreq
            Dim num16bitregs As Integer = 0
            For Each reg In regList
                If reg.NumBytes = 1 Or reg.NumBytes = 2 Then
                    num16bitregs += 1
                Else
                    num16bitregs += 2
                End If
            Next
            Dim calcPeriod As Double = ((m_TopGUI.FX3.StallTime / 1000000) + 17 / m_TopGUI.FX3.SclkFrequency) * num16bitregs
            'remove last stall time
            calcPeriod = calcPeriod - (m_TopGUI.FX3.StallTime / 1000000)

            If calcPeriod > (drPeriod * 0.9) Then
                If MessageBox.Show("Register capture time exceeds data ready period. Continue?", "Data will take too long to read!", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
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

        'Set up file manager
        If Not IsNothing(fileManager) Then
            fileManager.Dispose()
        End If
        fileManager = New Logger(m_TopGUI.FX3, m_TopGUI.Dut)
        fileManager.RegList = regList
        fileManager.FileBaseName = fileBaseName.Text + timeString
        fileManager.FilePath = savePath + "\"
        fileManager.Buffers = totalDRCaptures 'Number of times to read all the registers in the reg map
        fileManager.Captures = 1 'Number of times to read each register in the reg map
        'set the register word order
        fileManager.LowerWordFirst = m_TopGUI.Dut.IsLowerFirst
        fileManager.BuffersPerWrite = 10000
        'Log settings
        fileManager.LogTimestamps = check_LogTimestamps.Checked
        fileManager.ScaleData = check_ScaleData.Checked
        Try
            fileManager.FileMaxDataRows = Convert.ToInt32(linesPerFile.Text()) 'Keep this under 1M samples to open in Excel
        Catch ex As Exception
            fileManager.FileMaxDataRows = 1000000
            linesPerFile.Text = "1000000"
            MsgBox("ERROR: Invalid settings entered, using default")
        End Try
        fileManager.BufferTimeoutSeconds = 10 'Timeout in seconds

        'hide other forms during stream
        InteractWithOtherForms(True, Me)

        'run async
        fileManager.RunAsync()

        'update labels
        statusLabel.Text = "Writing Data"
        statusLabel.BackColor = Color.White

        'Disable user inputs during capture
        StreamingAVARCancelButton.Enabled = True
        DRDIO.Enabled = False
        NumberDRToCapture.Enabled = False
        MeasureDR.Enabled = False
        AddRegisterButton.Enabled = False
        RemoveRegisterButton.Enabled = False
        ClearAllButton.Enabled = False
        RegisterList.Enabled = False
        selectedRegview.Enabled = False
        MainButton.Enabled = False
        linesPerFile.Enabled = False
        btn_loadregs.Enabled = False
        btn_saveregs.Enabled = False
        recTimeEnabled = text_recTime.Enabled
        text_recTime.Enabled = False

    End Sub

    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        If InvokeRequired Then
            Invoke((New MethodInvoker(AddressOf DoneWork)))
        Else
            DoneWork()
        End If
    End Sub

    Private Sub DoneWork()
        statusLabel.Text = "Done"
        statusLabel.BackColor = m_TopGUI.GOOD_COLOR
        StreamingAVARCancelButton.Enabled = False
        DRDIO.Enabled = True
        NumberDRToCapture.Enabled = True
        MeasureDR.Enabled = m_TopGUI.FX3.DrActive
        AddRegisterButton.Enabled = True
        RemoveRegisterButton.Enabled = True
        ClearAllButton.Enabled = True
        RegisterList.Enabled = True
        selectedRegview.Enabled = True
        MainButton.Enabled = True
        linesPerFile.Enabled = True
        btn_loadregs.Enabled = True
        btn_saveregs.Enabled = True
        text_recTime.Enabled = recTimeEnabled
        InteractWithOtherForms(False, Me)
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles StreamingAVARCancelButton.Click
        MainButton.Enabled = True
        If fileManager.Busy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Canceling"
            statusLabel.BackColor = m_TopGUI.ERROR_COLOR
        End If
    End Sub

    Private Sub MeasureDR_Click(sender As Object, e As EventArgs) Handles MeasureDR.Click
        MeasureDrFreq(5000)
    End Sub

    Private Sub UpdateDRPin()
        Dim dio As String
        dio = DRDIO.SelectedItem
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
                'do not change data ready pin
        End Select
    End Sub

    Private Sub progressUpdate(e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        If InvokeRequired Then
            Invoke(New MethodInvoker(Sub() CaptureProgressStreaming.Value = e.ProgressPercentage))
        Else
            CaptureProgressStreaming.Value = e.ProgressPercentage
        End If
    End Sub

    Private Sub NumberDRToCapture_TextChanged(sender As Object, e As EventArgs) Handles NumberDRToCapture.TextChanged
        'ensure user can change time or captures
        If timeUpdated Then
            timeUpdated = False
            Exit Sub
        End If
        capturesUpdated = True
        'Check DR capture input
        If NumberDRToCapture.Text = "" Then
            NumberDRToCapture.Text = 0
        End If
        Try
            totalDRCaptures = Convert.ToInt32(NumberDRToCapture.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid Input")
            Exit Sub
        End Try
        UpdateRecordTimeEstimate()
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
        NumberDRToCapture.Text = totalDRCaptures.ToString()
    End Sub

    Private Sub DrActiveBox_CheckedChanged(sender As Object, e As EventArgs) Handles DrActiveBox.CheckedChanged
        m_TopGUI.FX3.DrActive = DrActiveBox.Checked
        capturesUpdated = True
        MeasureDR.Enabled = DrActiveBox.Checked
        ValidateDR.Enabled = DrActiveBox.Checked
        ValidateDR.Checked = DrActiveBox.Checked
        If DrActiveBox.Checked Then
            MeasureDrFreq(500)
        End If
        UpdateRecordTimeEstimate()
    End Sub

    Private Sub btn_loadregs_Click(sender As Object, e As EventArgs) Handles btn_loadregs.Click
        Dim browser As New OpenFileDialog()
        If browser.ShowDialog() = DialogResult.OK Then
            LoadRegsFromFile(browser.FileName)
        Else
            MsgBox("ERROR: No file selected")
            Exit Sub
        End If
    End Sub

    Private Sub LoadRegsFromFile(path As String)
        Dim regs() As String
        Try
            regs = System.IO.File.ReadAllLines(path)
        Catch ex As Exception
            MsgBox("ERROR: Unable to load file. " + ex.Message())
            Exit Sub
        End Try

        selectedRegview.Items.Clear()
        For Each reg In regs
            If m_TopGUI.RegMap.Contains(reg) Then
                selectedRegview.Items.Add(New ListViewItem() With {.Text = reg})
            Else
                MsgBox("ERROR: Register " + reg + " not found in register map!")
            End If
        Next

        'update register count
        UpdateRegCountLabel()
    End Sub

    Private Sub btn_saveregs_Click(sender As Object, e As EventArgs) Handles btn_saveregs.Click
        Dim regs As New List(Of String)
        For Each item As ListViewItem In selectedRegview.Items
            regs.Add(item.Text)
        Next

        If regs.Count() > 0 Then
            saveCSV("RegList", regs.ToArray())
        Else
            MsgBox("ERROR: No register to save")
        End If

    End Sub

    Private Sub MeasureDrFreq(timeout As Integer)
        UpdateDRPin()
        measuredDrFreq = m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, timeout, 2)
        DrFreq.Text = FormatNumber(measuredDrFreq, 3).ToString + "  Hz"
        capturesUpdated = True
        UpdateRecordTimeEstimate()
    End Sub

    Private Sub UpdateRecordTimeEstimate()
        text_recTime.Enabled = True
        If DrActiveBox.Checked Then
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

End Class