Imports FX3Api
Imports adisInterface
Imports System.ComponentModel

Public Class TextFileStreamManagerStreaming

    Private conn As Connection
    Private WithEvents fileManager As New TextFileStreamManager
    Private totalFrames As Integer
    Private linesPerFile As Integer
    Private frameTimeCalc As Double
    Private fileSizeEst As Double
    Private fileCounterEnable As Boolean
    Private pinExitEnable As Integer = 0
    Private timeoutEnable As Integer = 0
    Private pinStartEnable As Integer = 0

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Public Sub SetConn(ByRef newConnection As Connection)
        conn = newConnection
        If conn.FX3.PartType = DUTType.ADcmXL3021 Then
            conn.Dut = New adisInterface.AdcmInterface3Axis(conn.FX3)
        ElseIf conn.FX3.PartType = DUTType.ADcmXL2021 Then
            conn.Dut = New adisInterface.AdcmInterface2Axis(conn.FX3)
        ElseIf conn.FX3.PartType = DUTType.ADcmXL1021 Then
            conn.Dut = New adisInterface.AdcmInterface1Axis(conn.FX3)
        End If
    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopLevelGUI.Show()
    End Sub

    Private Sub TextFileStreamManagerStreaming_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TotalFramesInput.Text = 6897
        LinesPerCSVInput.Text = 1000000
        CaptureExitMethod.Text = "Pin Exit"

        statusLabel.Text = "Waiting"
        statusLabel.BackColor = Color.White

        CaptureProgress.Minimum = 0
        CaptureProgress.Maximum = 100

        TFSMCancelButton.Enabled = False
        UpdateGuiCalcs()
    End Sub

    Private Sub startButton_Click(sender As Object, e As EventArgs) Handles startButton.Click
        TFSMCancelButton.Enabled = True
        startButton.Enabled = False

        Dim timeString As String = "_" + DateTime.Now().ToString("s")
        Dim savePath As String
        timeString = timeString.Replace(":", "-")

        UpdateGuiCalcs()
        CheckExitMethod()
        CheckStartMethod()

        'Set REC_CTRL
        If timeoutEnable = 1 Then
            conn.Dut.WriteUnsigned(conn.RegMap("REC_CTRL1"), &H8103)
        ElseIf timeoutEnable = 0 Then
            conn.Dut.WriteUnsigned(conn.RegMap("REC_CTRL1"), &H103)
        End If

        'Get data output save location
        savePath = setSaveLocation()

        'Start stream
        If pinExitEnable = 1 Then
            conn.FX3.PinExit = True
        ElseIf pinExitEnable = 0 Then
            conn.FX3.PinExit = False
        End If

        If pinStartEnable = 1 Then
            conn.FX3.PinStart = True
        Else
            conn.FX3.PinStart = False
        End If

        fileManager.DutInterface = conn.Dut
        fileManager.FileBaseName = "Real_Time_Data" + timeString
        fileManager.FilePath = savePath
        fileManager.Buffers = totalFrames
        fileManager.FileMaxDataRows = linesPerFile
        fileManager.BufferTimeout = 5
        fileManager.BuffersPerWrite = 15625 'Note: This is # frames, but TFSM counts this as samples. Multiply this number * 32 '15625 = 500k samples
        fileManager.IncludeSampleNumberColumn = WriteFrameNumber.Checked
        'Extra properties to make filemanager happy - do nothing
        fileManager.Captures = 1
        fileManager.RegList = conn.Dut.RealTimeSamplingRegList
        fileManager.RunAsync()

        statusLabel.Text = "Writing Data"
        statusLabel.BackColor = Color.White
        TotalFramesInput.Enabled = False
        LinesPerCSVInput.Enabled = False
        WriteFrameNumber.Enabled = False
        CaptureExitMethod.Enabled = False
        CaptureStartMethod.Enabled = False
    End Sub

    Private Sub progressUpdate(sender As Object, e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        CaptureProgress.Value = e.ProgressPercentage
    End Sub

    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        statusLabel.Text = "Done"
        statusLabel.BackColor = Color.Green
        WriteFrameNumber.Enabled = True
        startButton.Enabled = True
        TotalFramesInput.Enabled = True
        LinesPerCSVInput.Enabled = True
        CaptureExitMethod.Enabled = True
        CaptureStartMethod.Enabled = True
        TFSMCancelButton.Enabled = False
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles TFSMCancelButton.Click
        If fileManager.IsBusy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Cancelling"
            statusLabel.BackColor = Color.Red
        End If
    End Sub

    Private Sub TotalFramesInput_TextChanged(sender As Object, e As EventArgs) Handles TotalFramesInput.TextChanged
        UpdateGuiCalcs()
        CheckExitMethod()
        CheckStartMethod()
    End Sub

    Private Sub WriteFrameNumber_CheckedChanged(sender As Object, e As EventArgs) Handles WriteFrameNumber.CheckedChanged
        fileCounterEnable = WriteFrameNumber.Checked
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
        TimeCalcLabel.Text = Math.Round(frameTimeCalc, 5)
        EstFS.Text = Math.Round(fileSizeEst, 3)
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
End Class