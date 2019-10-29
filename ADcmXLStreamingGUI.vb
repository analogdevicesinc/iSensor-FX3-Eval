'File:          ADclXLStreamingGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   GUI for real time data streaming from the ADcmXLx021 series parts.

Imports FX3Api
Imports adisInterface
Imports System.ComponentModel
Imports AdisApi
Imports System.Threading
Imports RegMapClasses
Imports StreamDataLogger

Public Class ADcmXLStreamingGUI
    Inherits FormBase

    Private WithEvents fileManager As Logger
    Private totalFrames As Integer
    Private linesPerFile As Integer
    Private frameTimeCalc As Double
    Private fileSizeEst As Double
    Private fileCounterEnable As Boolean
    Private pinExitEnable As Integer = 0
    Private timeoutEnable As Integer = 0
    Private pinStartEnable As Integer = 0

    'Capture related fields
    Private pinCaptureStart As Boolean
    Private PinList As List(Of IPinObject)
    Private startPin As IPinObject
    Private pinCapturePolarity As UInteger
    Private captureTime As UInteger
    Private numSampleCaptures As Integer
    Private sampleCounter As Integer

    Private CancelCapture As Boolean
    Private SampleDone As Boolean
    Private runOnce As Boolean

    'File related fields
    Private savePath As String

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub TextFileStreamManagerStreaming_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If m_TopGUI.FX3.PartType = DUTType.ADcmXL3021 Then
            m_TopGUI.Dut = New adisInterface.AdcmInterface3Axis(m_TopGUI.FX3)
        ElseIf m_TopGUI.FX3.PartType = DUTType.ADcmXL2021 Then
            m_TopGUI.Dut = New adisInterface.AdcmInterface2Axis(m_TopGUI.FX3)
        ElseIf m_TopGUI.FX3.PartType = DUTType.ADcmXL1021 Then
            m_TopGUI.Dut = New adisInterface.AdcmInterface1Axis(m_TopGUI.FX3)
        Else
            Throw New Exception("ERROR: This form is only usable with machine health parts")
        End If

        'Set the device type
        DeviceType.Text = m_TopGUI.FX3.PartType.ToString()

        TotalFramesInput.Text = 6897
        LinesPerCSVInput.Text = 1000000
        CaptureExitMethod.Text = "Pin Exit"

        statusLabel.Text = "Waiting"
        statusLabel.BackColor = Color.White

        SampleProgress.Minimum = 0
        SampleProgress.Maximum = 100

        StopBtn.Enabled = False
        UpdateGuiCalcs()

        'Populate pin box
        PinList = New List(Of IPinObject)
        startPinBox.DropDownStyle = ComboBoxStyle.DropDownList
        Dim FX3Api = GetType(FX3Api.FX3Connection)
        For Each prop In FX3Api.GetProperties()
            If prop.PropertyType = GetType(IPinObject) Then
                startPinBox.Items.Add(prop.Name)
                PinList.Add(m_TopGUI.FX3.GetType().GetProperty(prop.Name).GetValue(m_TopGUI.FX3))
            End If
        Next
        If startPinBox.Items.Count > 0 Then
            startPinBox.SelectedIndex = 0
        End If

        startPolarity.DropDownStyle = ComboBoxStyle.DropDownList
        startPolarity.Items.Add("High")
        startPolarity.Items.Add("Low")
        startPolarity.SelectedIndex = 0

        TimerTriggerRadioBtn.Checked = True
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        StopBtn.Enabled = True
        startButton.Enabled = False

        UpdateGuiCalcs()
        CheckExitMethod()
        CheckStartMethod()

        'Get data output save location
        savePath = setSaveLocation()

        'validate settings
        Try
            numSampleCaptures = Convert.ToInt32(numSamples.Text)
        Catch ex As Exception
            statusLabel.Text = "Invalid number of samples"
            statusLabel.BackColor = Color.Red
            Exit Sub
        End Try

        Try
            captureTime = Convert.ToUInt32(timeSelect.Text)
        Catch ex As Exception
            statusLabel.Text = "Invalid time selection"
            statusLabel.BackColor = Color.Red
            Exit Sub
        End Try

        'Set the capture polarity
        If startPolarity.SelectedIndex = 0 Then
            pinCapturePolarity = 1
        Else
            pinCapturePolarity = 0
        End If

        'Get the start pin
        startPin = PinList(startPinBox.SelectedIndex)

        sampleCounter = 0
        captureCounter.Text = sampleCounter.ToString()

        CancelCapture = False
        startButton.Enabled = False
        StopBtn.Enabled = True
        TotalFramesInput.Enabled = False
        LinesPerCSVInput.Enabled = False
        CaptureExitMethod.Enabled = False
        CaptureStartMethod.Enabled = False
        numSamples.Enabled = False
        startPinBox.Enabled = False
        startPolarity.Enabled = False

        If numSampleCaptures > 1 Or pinCaptureStart Then
            runOnce = False
            Dim temp As Thread
            temp = New Thread(AddressOf CaptureWorker)
            temp.Start()
        Else
            runOnce = True
            CaptureSample()
        End If

    End Sub

    Private Sub CaptureWorker()

        Dim pinWaitTime As Double

        'Iterate through
        While sampleCounter < numSampleCaptures And Not CancelCapture
            If pinCaptureStart Then
                'Pin mode
                Me.Invoke(New MethodInvoker(Sub() statusLabel.Text = "Starting Pin Wait"))
                Me.Invoke(New MethodInvoker(Sub() statusLabel.BackColor = Color.White))
                pinWaitTime = m_TopGUI.FX3.PulseWait(startPin, pinCapturePolarity, 0, captureTime)
                If pinWaitTime >= captureTime Then
                    Me.Invoke(New MethodInvoker(Sub() statusLabel.Text = "Pin wait timed out, exiting capture loop"))
                    Exit While
                End If

                'Perform sample
                Me.Invoke(New MethodInvoker(Sub() statusLabel.Text = "Starting sample"))
                Me.Invoke(New MethodInvoker(Sub() statusLabel.BackColor = Color.Yellow))
                CaptureSample()

                'Wait for sample completion
                While Not SampleDone
                    System.Threading.Thread.Sleep(100)
                End While
                sampleCounter += 1
                Me.Invoke(New MethodInvoker(Sub() captureCounter.Text = sampleCounter.ToString()))
            Else
                Me.Invoke(New MethodInvoker(Sub() statusLabel.Text = "Starting sample"))
                Me.Invoke(New MethodInvoker(Sub() statusLabel.BackColor = Color.Yellow))
                CaptureSample()

                'wait for sample completion
                While Not SampleDone
                    System.Threading.Thread.Sleep(100)
                End While
                sampleCounter += 1
                Me.Invoke(New MethodInvoker(Sub() captureCounter.Text = sampleCounter.ToString()))

                'Perform sleep
                Me.Invoke(New MethodInvoker(Sub() statusLabel.Text = "Starting Sleep for capture period"))
                Me.Invoke(New MethodInvoker(Sub() statusLabel.BackColor = Color.White))
                System.Threading.Thread.Sleep(captureTime)
            End If
        End While

        Me.Invoke(New MethodInvoker(AddressOf UpdateLabelsStop))

    End Sub

    Private Sub UpdateLabelsStop()

        statusLabel.BackColor = Color.Green
        If CancelCapture Then
            statusLabel.Text = "Cancel Finished"
        Else
            statusLabel.Text = "Capture Finished"
        End If

        startButton.Enabled = True
        TotalFramesInput.Enabled = True
        LinesPerCSVInput.Enabled = True
        CaptureExitMethod.Enabled = True
        CaptureStartMethod.Enabled = True
        numSamples.Enabled = True
        startPinBox.Enabled = True
        startPolarity.Enabled = True
        StopBtn.Enabled = False
    End Sub

    Private Sub CaptureSample()

        Dim timeString As String = "_" + DateTime.Now().ToString("s")
        timeString = timeString.Replace(":", "-")

        Dim regListDUT As AdcmInterfaceBase
        If m_TopGUI.FX3.PartType = DUTType.ADcmXL3021 Then
            regListDUT = New adisInterface.AdcmInterface3Axis(m_TopGUI.FX3)
        ElseIf m_TopGUI.FX3.PartType = DUTType.ADcmXL2021 Then
            regListDUT = New adisInterface.AdcmInterface2Axis(m_TopGUI.FX3)
        ElseIf m_TopGUI.FX3.PartType = DUTType.ADcmXL1021 Then
            regListDUT = New adisInterface.AdcmInterface1Axis(m_TopGUI.FX3)
        Else
            Throw New Exception("ERROR: This form is only usable with machine health parts")
        End If

        'Set REC_CTRL
        If timeoutEnable = 1 Then
            m_TopGUI.Dut.WriteUnsigned(m_TopGUI.RegMap("REC_CTRL1"), &H8103)
        ElseIf timeoutEnable = 0 Then
            m_TopGUI.Dut.WriteUnsigned(m_TopGUI.RegMap("REC_CTRL1"), &H103)
        End If
        System.Threading.Thread.Sleep(100)

        'Start stream
        If pinExitEnable = 1 Then
            m_TopGUI.FX3.PinExit = True
        ElseIf pinExitEnable = 0 Then
            m_TopGUI.FX3.PinExit = False
        End If

        If pinStartEnable = 1 Then
            m_TopGUI.FX3.PinStart = True
        Else
            m_TopGUI.FX3.PinStart = False
        End If

        fileManager = New Logger(m_TopGUI.FX3, m_TopGUI.Dut)
        fileManager.FileBaseName = "Real_Time_Data" + timeString
        fileManager.FilePath = savePath
        fileManager.Buffers = totalFrames
        fileManager.FileMaxDataRows = linesPerFile
        fileManager.BufferTimeoutSeconds = 10
        fileManager.BuffersPerWrite = 1000 'Note: This is # frames, but TFSM counts this as samples. Multiply this number * 32 '15625 = 500k samples
        fileManager.Captures = 1
        fileManager.RegList = regListDUT.RealTimeSamplingRegList
        fileManager.RunAsync()
        SampleDone = False
    End Sub

    Private Sub progressUpdate(e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        Me.Invoke(New MethodInvoker(Sub() SampleProgress.Value = e.ProgressPercentage))
    End Sub

    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        Me.Invoke(New MethodInvoker(AddressOf SampleDoneLabels))
        SampleDone = True
        If runOnce Then
            UpdateLabelsStop()
        End If
    End Sub

    Private Sub SampleDoneLabels()
        statusLabel.Text = "Done with sample"
        statusLabel.BackColor = Color.LightGreen
        SampleProgress.Value = 0
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles StopBtn.Click
        CancelCapture = True
        If fileManager.Busy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Canceling in capture"
            statusLabel.BackColor = Color.Red
        End If
    End Sub

    Private Sub TotalFramesInput_TextChanged(sender As Object, e As EventArgs) Handles TotalFramesInput.TextChanged
        UpdateGuiCalcs()
        CheckExitMethod()
        CheckStartMethod()
    End Sub

    Private Sub UpdateGuiCalcs()
        If TotalFramesInput.Text = "" Then
            TotalFramesInput.Text = 6897
        End If
        If LinesPerCSVInput.Text = "" Then
            LinesPerCSVInput.Text = 1000000
        End If

        Try
            totalFrames = Convert.ToInt32(TotalFramesInput.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid Input")
            Exit Sub
        End Try

        Try
            linesPerFile = Convert.ToInt32(LinesPerCSVInput.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid Input")
            Exit Sub
        End Try

        If (totalFrames <= 0 Or linesPerFile <= 0) Then
            MsgBox("ERROR: Invalid Input")
            Exit Sub
        End If

        frameTimeCalc = totalFrames / 6897

        If fileCounterEnable Then
            fileSizeEst = totalFrames * 0.0013986875
        Else
            fileSizeEst = totalFrames * 0.00115465625
        End If
        TimeCalcLabel.Text = Math.Round(frameTimeCalc, 5).ToString() + " Seconds"
        EstFS.Text = Math.Round(fileSizeEst, 3).ToString() + " MB (est)"
    End Sub

    Private Sub CheckExitMethod()
        If CaptureExitMethod.Text = "Pin Exit" Then
            pinExitEnable = 1
            timeoutEnable = 0
        ElseIf CaptureExitMethod.Text = "Timeout" Then
            pinExitEnable = 0
            timeoutEnable = 1
        ElseIf CaptureExitMethod.Text = "No Exit" Then
            pinExitEnable = 0
            timeoutEnable = 0
        ElseIf CaptureExitMethod.Text = "" Then
            CaptureExitMethod.Text = "Pin Exit"
            Exit Sub
        End If
    End Sub

    Private Sub CheckStartMethod()
        If CaptureStartMethod.Text = "Pin Start" Then
            pinStartEnable = 1
        ElseIf CaptureStartMethod.Text = "GLOB_CMD Start" Then
            pinStartEnable = 0
        ElseIf CaptureStartMethod.Text = "" Then
            CaptureStartMethod.Text = "GLOB_CMD Start"
            Exit Sub
        End If
    End Sub

    Private Sub CaptureExitMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CaptureExitMethod.SelectedIndexChanged
        CheckExitMethod()
        CheckStartMethod()
    End Sub

    Private Sub CaptureStartMethod_SelectedIndexChanged(sender As Object, e As EventArgs) Handles CaptureStartMethod.SelectedIndexChanged
        CheckStartMethod()
        CheckExitMethod()
    End Sub

    Private Sub WriteFrameNumber_CheckedChanged(sender As Object, e As EventArgs)
        UpdateGuiCalcs()
        CheckExitMethod()
        CheckStartMethod()
    End Sub

    Private Sub PinTriggerRadioBtn_CheckedChanged(sender As Object, e As EventArgs) Handles PinTriggerRadioBtn.CheckedChanged
        If PinTriggerRadioBtn.Checked Then
            TimerTriggerRadioBtn.Checked = False
            pinCaptureStart = True
            timeout_label.Text = "Pin Timeout (ms):"
            startPinBox.Enabled = True
            startPolarity.Enabled = True
        End If
    End Sub

    Private Sub TimerTriggerRadioBtn_CheckedChanged(sender As Object, e As EventArgs) Handles TimerTriggerRadioBtn.CheckedChanged
        If TimerTriggerRadioBtn.Checked Then
            PinTriggerRadioBtn.Checked = False
            pinCaptureStart = False
            timeout_label.Text = "Sample Period (ms):"
            startPinBox.Enabled = False
            startPolarity.Enabled = False
        End If
    End Sub

    Private Sub helpBtn_Click(sender As Object, e As EventArgs) Handles helpBtn.Click
        MsgBox("The ""Sample Configuration"" section refers to each individual real time stream from the ADcmXL DUT. ""Capture Configuration"" controls how each sample is triggered (by a timer or a GPIO pin on the FX3)")
    End Sub
End Class