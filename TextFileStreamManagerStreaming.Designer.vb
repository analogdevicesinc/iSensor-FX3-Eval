<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class TextFileStreamManagerStreaming
    Inherits System.Windows.Forms.Form

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TotalFramesInput = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.startButton = New System.Windows.Forms.Button()
        Me.CaptureProgress = New System.Windows.Forms.ProgressBar()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TFSMCancelButton = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.WriteFrameNumber = New System.Windows.Forms.CheckBox()
        Me.TimeCalcLabel = New System.Windows.Forms.Label()
        Me.SecondsLabel = New System.Windows.Forms.Label()
        Me.EstFS = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.LinesPerCSVInput = New System.Windows.Forms.TextBox()
        Me.CaptureExitMethod = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.CaptureStartMethod = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Total Frames to Capture: "
        '
        'TotalFramesInput
        '
        Me.TotalFramesInput.Location = New System.Drawing.Point(145, 19)
        Me.TotalFramesInput.Name = "TotalFramesInput"
        Me.TotalFramesInput.Size = New System.Drawing.Size(132, 20)
        Me.TotalFramesInput.TabIndex = 2
        Me.TotalFramesInput.Text = "6897"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 50)
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
        Me.startButton.Location = New System.Drawing.Point(18, 116)
        Me.startButton.Name = "startButton"
        Me.startButton.Size = New System.Drawing.Size(75, 107)
        Me.startButton.TabIndex = 20
        Me.startButton.Text = "Start Data Capture"
        Me.startButton.UseVisualStyleBackColor = True
        '
        'CaptureProgress
        '
        Me.CaptureProgress.Location = New System.Drawing.Point(102, 229)
        Me.CaptureProgress.Name = "CaptureProgress"
        Me.CaptureProgress.Size = New System.Drawing.Size(217, 18)
        Me.CaptureProgress.TabIndex = 22
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 230)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(91, 13)
        Me.Label4.TabIndex = 23
        Me.Label4.Text = "Capture Progress:"
        '
        'TFSMCancelButton
        '
        Me.TFSMCancelButton.Location = New System.Drawing.Point(99, 116)
        Me.TFSMCancelButton.Name = "TFSMCancelButton"
        Me.TFSMCancelButton.Size = New System.Drawing.Size(75, 107)
        Me.TFSMCancelButton.TabIndex = 24
        Me.TFSMCancelButton.Text = "Cancel Data Capture"
        Me.TFSMCancelButton.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(28, 85)
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
        Me.statusLabel.Location = New System.Drawing.Point(73, 82)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(204, 20)
        Me.statusLabel.TabIndex = 26
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'WriteFrameNumber
        '
        Me.WriteFrameNumber.AutoSize = True
        Me.WriteFrameNumber.Location = New System.Drawing.Point(198, 116)
        Me.WriteFrameNumber.Margin = New System.Windows.Forms.Padding(2)
        Me.WriteFrameNumber.Name = "WriteFrameNumber"
        Me.WriteFrameNumber.Size = New System.Drawing.Size(129, 17)
        Me.WriteFrameNumber.TabIndex = 28
        Me.WriteFrameNumber.Text = "Write Frame Number?"
        Me.WriteFrameNumber.UseVisualStyleBackColor = True
        '
        'TimeCalcLabel
        '
        Me.TimeCalcLabel.Location = New System.Drawing.Point(295, 21)
        Me.TimeCalcLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.TimeCalcLabel.Name = "TimeCalcLabel"
        Me.TimeCalcLabel.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TimeCalcLabel.Size = New System.Drawing.Size(38, 13)
        Me.TimeCalcLabel.TabIndex = 0
        Me.TimeCalcLabel.Text = "Label6"
        Me.TimeCalcLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SecondsLabel
        '
        Me.SecondsLabel.AutoSize = True
        Me.SecondsLabel.Location = New System.Drawing.Point(363, 21)
        Me.SecondsLabel.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.SecondsLabel.Name = "SecondsLabel"
        Me.SecondsLabel.Size = New System.Drawing.Size(49, 13)
        Me.SecondsLabel.TabIndex = 29
        Me.SecondsLabel.Text = "Seconds"
        Me.SecondsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'EstFS
        '
        Me.EstFS.AutoSize = True
        Me.EstFS.Location = New System.Drawing.Point(295, 49)
        Me.EstFS.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.EstFS.Name = "EstFS"
        Me.EstFS.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.EstFS.Size = New System.Drawing.Size(39, 13)
        Me.EstFS.TabIndex = 30
        Me.EstFS.Text = "Label6"
        Me.EstFS.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(363, 49)
        Me.Label7.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(44, 13)
        Me.Label7.TabIndex = 31
        Me.Label7.Text = "MB Est."
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'LinesPerCSVInput
        '
        Me.LinesPerCSVInput.Location = New System.Drawing.Point(145, 47)
        Me.LinesPerCSVInput.Name = "LinesPerCSVInput"
        Me.LinesPerCSVInput.Size = New System.Drawing.Size(132, 20)
        Me.LinesPerCSVInput.TabIndex = 32
        Me.LinesPerCSVInput.Text = "1000000"
        '
        'CaptureExitMethod
        '
        Me.CaptureExitMethod.FormattingEnabled = True
        Me.CaptureExitMethod.Items.AddRange(New Object() {"Pin Exit", "Timeout", "No Exit"})
        Me.CaptureExitMethod.Location = New System.Drawing.Point(198, 202)
        Me.CaptureExitMethod.Name = "CaptureExitMethod"
        Me.CaptureExitMethod.Size = New System.Drawing.Size(121, 21)
        Me.CaptureExitMethod.TabIndex = 33
        Me.CaptureExitMethod.Text = "Pin Exit"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(195, 186)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 34
        Me.Label6.Text = "Capture Exit Method"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(195, 140)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(108, 13)
        Me.Label8.TabIndex = 35
        Me.Label8.Text = "Capture Start Method"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'CaptureStartMethod
        '
        Me.CaptureStartMethod.FormattingEnabled = True
        Me.CaptureStartMethod.Items.AddRange(New Object() {"GLOB_CMD Start", "Pin Start"})
        Me.CaptureStartMethod.Location = New System.Drawing.Point(198, 158)
        Me.CaptureStartMethod.Name = "CaptureStartMethod"
        Me.CaptureStartMethod.Size = New System.Drawing.Size(121, 21)
        Me.CaptureStartMethod.TabIndex = 36
        Me.CaptureStartMethod.Text = "GLOB_CMD Start"
        '
        'TextFileStreamManagerStreaming
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(433, 259)
        Me.Controls.Add(Me.CaptureStartMethod)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.CaptureExitMethod)
        Me.Controls.Add(Me.LinesPerCSVInput)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.EstFS)
        Me.Controls.Add(Me.SecondsLabel)
        Me.Controls.Add(Me.TimeCalcLabel)
        Me.Controls.Add(Me.WriteFrameNumber)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.TFSMCancelButton)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.CaptureProgress)
        Me.Controls.Add(Me.startButton)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TotalFramesInput)
        Me.Controls.Add(Me.Label1)
        Me.Name = "TextFileStreamManagerStreaming"
        Me.Text = "Text File Stream Manager Streaming"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As Label
    Friend WithEvents TotalFramesInput As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents startButton As Button
    Friend WithEvents CaptureProgress As ProgressBar
    Friend WithEvents Label4 As Label
    Friend WithEvents TFSMCancelButton As Button
    Friend WithEvents Label5 As Label
    Friend WithEvents statusLabel As Label
    Friend WithEvents WriteFrameNumber As CheckBox
    Friend WithEvents TimeCalcLabel As Label
    Friend WithEvents SecondsLabel As Label
    Friend WithEvents EstFS As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents LinesPerCSVInput As TextBox
    Friend WithEvents CaptureExitMethod As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents CaptureStartMethod As ComboBox
End Class
