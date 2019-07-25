<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADcmXLStreamingGUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ADcmXLStreamingGUI))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotalFramesInput = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.startButton = New System.Windows.Forms.Button()
        Me.SampleProgress = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.StopBtn = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.TimeCalcLabel = New System.Windows.Forms.Label()
        Me.EstFS = New System.Windows.Forms.Label()
        Me.LinesPerCSVInput = New System.Windows.Forms.TextBox()
        Me.CaptureExitMethod = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CaptureStartMethod = New System.Windows.Forms.ComboBox()
        Me.helpBtn = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.captureCounter = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.WriteFrameNumber = New System.Windows.Forms.CheckBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.DeviceType = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.timeout_label = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.startPolarity = New System.Windows.Forms.ComboBox()
        Me.timeSelect = New System.Windows.Forms.TextBox()
        Me.startPinBox = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.PinTriggerRadioBtn = New System.Windows.Forms.RadioButton()
        Me.TimerTriggerRadioBtn = New System.Windows.Forms.RadioButton()
        Me.numSamples = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(104, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Frames Per Sample: "
        '
        'TotalFramesInput
        '
        Me.TotalFramesInput.Location = New System.Drawing.Point(116, 17)
        Me.TotalFramesInput.Name = "TotalFramesInput"
        Me.TotalFramesInput.Size = New System.Drawing.Size(132, 20)
        Me.TotalFramesInput.TabIndex = 2
        Me.TotalFramesInput.Text = "6897"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 46)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Lines Per File:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 4
        '
        'startButton
        '
        Me.startButton.Location = New System.Drawing.Point(12, 384)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(75, 64)
        Me.startButton.TabIndex = 20
        Me.startButton.Text = "Start Data Capture"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'SampleProgress
        '
        Me.SampleProgress.Location = New System.Drawing.Point(101, 172)
        Me.SampleProgress.Name = "SampleProgress"
        Me.SampleProgress.Size = New System.Drawing.Size(244, 18)
        Me.SampleProgress.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 174)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Sample Progress:"
        '
        'StopBtn
        '
        Me.StopBtn.Location = New System.Drawing.Point(93, 384)
        Me.StopBtn.Name = "StopBtn"
        Me.StopBtn.Size = New System.Drawing.Size(75, 64)
        Me.StopBtn.TabIndex = 24
        Me.StopBtn.Text = "Stop Data Capture"
        Me.StopBtn.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 463)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(43, 13)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Status: "
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(113, 459)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(256, 20)
        Me.statusLabel.TabIndex = 26
        Me.statusLabel.Text = "Not Started"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'TimeCalcLabel
        '
        Me.TimeCalcLabel.AutoSize = True
        Me.TimeCalcLabel.Location = New System.Drawing.Point(253, 20)
        Me.TimeCalcLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TimeCalcLabel.Name = "TimeCalcLabel"
        Me.TimeCalcLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeCalcLabel.Size = New System.Drawing.Size(73, 13)
        Me.TimeCalcLabel.TabIndex = 0
        Me.TimeCalcLabel.Text = "1.00 Seconds"
        Me.TimeCalcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstFS
        '
        Me.EstFS.AutoSize = True
        Me.EstFS.Location = New System.Drawing.Point(253, 46)
        Me.EstFS.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.EstFS.Name = "EstFS"
        Me.EstFS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EstFS.Size = New System.Drawing.Size(70, 13)
        Me.EstFS.TabIndex = 30
        Me.EstFS.Text = "N/A MB (Est)"
        Me.EstFS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LinesPerCSVInput
        '
        Me.LinesPerCSVInput.Location = New System.Drawing.Point(116, 43)
        Me.LinesPerCSVInput.Name = "LinesPerCSVInput"
        Me.LinesPerCSVInput.Size = New System.Drawing.Size(132, 20)
        Me.LinesPerCSVInput.TabIndex = 32
        Me.LinesPerCSVInput.Text = "1000000"
        '
        'CaptureExitMethod
        '
        Me.CaptureExitMethod.FormattingEnabled = True
        Me.CaptureExitMethod.Items.AddRange(New Object() {"Pin Exit", "Timeout", "No Exit"})
        Me.CaptureExitMethod.Location = New System.Drawing.Point(152, 139)
        Me.CaptureExitMethod.Name = "CaptureExitMethod"
        Me.CaptureExitMethod.Size = New System.Drawing.Size(137, 21)
        Me.CaptureExitMethod.TabIndex = 33
        Me.CaptureExitMethod.Text = "Pin Exit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(149, 123)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Sample Exit Method"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(6, 123)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(106, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Sample Start Method"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CaptureStartMethod
        '
        Me.CaptureStartMethod.FormattingEnabled = True
        Me.CaptureStartMethod.Items.AddRange(New Object() {"GLOB_CMD Start", "Pin Start"})
        Me.CaptureStartMethod.Location = New System.Drawing.Point(9, 139)
        Me.CaptureStartMethod.Name = "CaptureStartMethod"
        Me.CaptureStartMethod.Size = New System.Drawing.Size(137, 21)
        Me.CaptureStartMethod.TabIndex = 36
        Me.CaptureStartMethod.Text = "GLOB_CMD Start"
        '
        'helpBtn
        '
        Me.helpBtn.Location = New System.Drawing.Point(294, 384)
        Me.helpBtn.Name = "helpBtn"
        Me.helpBtn.Size = New System.Drawing.Size(75, 64)
        Me.helpBtn.TabIndex = 37
        Me.helpBtn.Text = "Help?"
        Me.helpBtn.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(18, 490)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 13)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Captures Finished:"
        '
        'captureCounter
        '
        Me.captureCounter.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.captureCounter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.captureCounter.ForeColor = System.Drawing.SystemColors.ControlText
        Me.captureCounter.Location = New System.Drawing.Point(113, 486)
        Me.captureCounter.Name = "captureCounter"
        Me.captureCounter.Size = New System.Drawing.Size(92, 20)
        Me.captureCounter.TabIndex = 39
        Me.captureCounter.Text = "0"
        Me.captureCounter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.WriteFrameNumber)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DeviceType)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.SampleProgress)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.LinesPerCSVInput)
        Me.GroupBox1.Controls.Add(Me.TotalFramesInput)
        Me.GroupBox1.Controls.Add(Me.CaptureExitMethod)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.CaptureStartMethod)
        Me.GroupBox1.Controls.Add(Me.TimeCalcLabel)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.EstFS)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(357, 205)
        Me.GroupBox1.TabIndex = 40
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sample Configuration"
        '
        'WriteFrameNumber
        '
        Me.WriteFrameNumber.AutoSize = True
        Me.WriteFrameNumber.Location = New System.Drawing.Point(9, 98)
        Me.WriteFrameNumber.Name = "WriteFrameNumber"
        Me.WriteFrameNumber.Size = New System.Drawing.Size(139, 17)
        Me.WriteFrameNumber.TabIndex = 44
        Me.WriteFrameNumber.Text = "Include Sample Number"
        Me.WriteFrameNumber.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(6, 73)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(71, 13)
        Me.Label11.TabIndex = 43
        Me.Label11.Text = "Device Type:"
        '
        'DeviceType
        '
        Me.DeviceType.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.DeviceType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DeviceType.ForeColor = System.Drawing.SystemColors.ControlText
        Me.DeviceType.Location = New System.Drawing.Point(116, 69)
        Me.DeviceType.Name = "DeviceType"
        Me.DeviceType.Size = New System.Drawing.Size(132, 20)
        Me.DeviceType.TabIndex = 42
        Me.DeviceType.Text = "0"
        Me.DeviceType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.timeout_label)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.startPolarity)
        Me.GroupBox2.Controls.Add(Me.timeSelect)
        Me.GroupBox2.Controls.Add(Me.startPinBox)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.PinTriggerRadioBtn)
        Me.GroupBox2.Controls.Add(Me.TimerTriggerRadioBtn)
        Me.GroupBox2.Controls.Add(Me.numSamples)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 223)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(357, 155)
        Me.GroupBox2.TabIndex = 41
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Capture Configuration"
        '
        'timeout_label
        '
        Me.timeout_label.AutoSize = True
        Me.timeout_label.Location = New System.Drawing.Point(6, 78)
        Me.timeout_label.Name = "timeout_label"
        Me.timeout_label.Size = New System.Drawing.Size(88, 13)
        Me.timeout_label.TabIndex = 53
        Me.timeout_label.Text = "Pin Timeout (ms):"
        Me.timeout_label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(149, 104)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(106, 13)
        Me.Label13.TabIndex = 52
        Me.Label13.Text = "Capture Start Polarity"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(8, 104)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(87, 13)
        Me.Label12.TabIndex = 51
        Me.Label12.Text = "Capture Start Pin"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'startPolarity
        '
        Me.startPolarity.FormattingEnabled = True
        Me.startPolarity.Location = New System.Drawing.Point(152, 120)
        Me.startPolarity.Name = "startPolarity"
        Me.startPolarity.Size = New System.Drawing.Size(137, 21)
        Me.startPolarity.TabIndex = 50
        '
        'timeSelect
        '
        Me.timeSelect.Location = New System.Drawing.Point(114, 75)
        Me.timeSelect.Name = "timeSelect"
        Me.timeSelect.Size = New System.Drawing.Size(132, 20)
        Me.timeSelect.TabIndex = 49
        Me.timeSelect.Text = "1000"
        '
        'startPinBox
        '
        Me.startPinBox.FormattingEnabled = True
        Me.startPinBox.Location = New System.Drawing.Point(9, 120)
        Me.startPinBox.Name = "startPinBox"
        Me.startPinBox.Size = New System.Drawing.Size(137, 21)
        Me.startPinBox.TabIndex = 48
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(6, 54)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(102, 13)
        Me.Label10.TabIndex = 47
        Me.Label10.Text = "Capture Start Mode:"
        '
        'PinTriggerRadioBtn
        '
        Me.PinTriggerRadioBtn.AutoSize = True
        Me.PinTriggerRadioBtn.Location = New System.Drawing.Point(114, 52)
        Me.PinTriggerRadioBtn.Name = "PinTriggerRadioBtn"
        Me.PinTriggerRadioBtn.Size = New System.Drawing.Size(88, 17)
        Me.PinTriggerRadioBtn.TabIndex = 46
        Me.PinTriggerRadioBtn.TabStop = True
        Me.PinTriggerRadioBtn.Text = "Pin Triggered"
        Me.PinTriggerRadioBtn.UseVisualStyleBackColor = True
        '
        'TimerTriggerRadioBtn
        '
        Me.TimerTriggerRadioBtn.AutoSize = True
        Me.TimerTriggerRadioBtn.Location = New System.Drawing.Point(208, 52)
        Me.TimerTriggerRadioBtn.Name = "TimerTriggerRadioBtn"
        Me.TimerTriggerRadioBtn.Size = New System.Drawing.Size(99, 17)
        Me.TimerTriggerRadioBtn.TabIndex = 45
        Me.TimerTriggerRadioBtn.TabStop = True
        Me.TimerTriggerRadioBtn.Text = "Timer Triggered"
        Me.TimerTriggerRadioBtn.UseVisualStyleBackColor = True
        '
        'numSamples
        '
        Me.numSamples.Location = New System.Drawing.Point(114, 26)
        Me.numSamples.Name = "numSamples"
        Me.numSamples.Size = New System.Drawing.Size(132, 20)
        Me.numSamples.TabIndex = 44
        Me.numSamples.Text = "1"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 29)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(102, 13)
        Me.Label7.TabIndex = 39
        Me.Label7.Text = "Number of Samples:"
        '
        'TextFileStreamManagerStreaming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(388, 520)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.captureCounter)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.helpBtn)
        Me.Controls.Add(Me.StopBtn)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "TextFileStreamManagerStreaming"
        Me.Text = "Real Time Data Capture"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TotalFramesInput As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents startButton As Button
    Friend WithEvents SampleProgress As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents StopBtn As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents statusLabel As Label
    Friend WithEvents TimeCalcLabel As Label
    Friend WithEvents EstFS As Label
    Friend WithEvents LinesPerCSVInput As TextBox
    Friend WithEvents CaptureExitMethod As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CaptureStartMethod As ComboBox
    Friend WithEvents helpBtn As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents captureCounter As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents Label11 As Label
    Friend WithEvents DeviceType As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents PinTriggerRadioBtn As RadioButton
    Friend WithEvents TimerTriggerRadioBtn As RadioButton
    Friend WithEvents numSamples As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents timeout_label As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents startPolarity As ComboBox
    Friend WithEvents timeSelect As TextBox
    Friend WithEvents startPinBox As ComboBox
    Friend WithEvents WriteFrameNumber As CheckBox
End Class
