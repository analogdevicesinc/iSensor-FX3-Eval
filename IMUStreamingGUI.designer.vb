<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class IMUStreamingGUI

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
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DRDIO = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.MeasureDR = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.NumberDRToCapture = New System.Windows.Forms.TextBox()
        Me.BurstStreamCancelButton = New System.Windows.Forms.Button()
        Me.MainButton = New System.Windows.Forms.Button()
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CaptureProgressBurst = New System.Windows.Forms.ProgressBar()
        Me.BitModeCheckbox = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(83, 40)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "DR DIO:"
        '
        'DRDIO
        '
        Me.DRDIO.FormattingEnabled = True
        Me.DRDIO.Location = New System.Drawing.Point(83, 53)
        Me.DRDIO.Name = "DRDIO"
        Me.DRDIO.Size = New System.Drawing.Size(111, 21)
        Me.DRDIO.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(82, 21)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Label4"
        '
        'MeasureDR
        '
        Me.MeasureDR.Location = New System.Drawing.Point(9, 20)
        Me.MeasureDR.Name = "MeasureDR"
        Me.MeasureDR.Size = New System.Drawing.Size(59, 94)
        Me.MeasureDR.TabIndex = 25
        Me.MeasureDR.Text = "Measure DR"
        Me.MeasureDR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(83, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "# DR To Capture:"
        '
        'NumberDRToCapture
        '
        Me.NumberDRToCapture.Location = New System.Drawing.Point(83, 94)
        Me.NumberDRToCapture.Name = "NumberDRToCapture"
        Me.NumberDRToCapture.Size = New System.Drawing.Size(111, 20)
        Me.NumberDRToCapture.TabIndex = 23
        '
        'BurstStreamCancelButton
        '
        Me.BurstStreamCancelButton.Location = New System.Drawing.Point(114, 128)
        Me.BurstStreamCancelButton.Name = "BurstStreamCancelButton"
        Me.BurstStreamCancelButton.Size = New System.Drawing.Size(77, 61)
        Me.BurstStreamCancelButton.TabIndex = 22
        Me.BurstStreamCancelButton.Text = "Cancel"
        Me.BurstStreamCancelButton.UseVisualStyleBackColor = True
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(13, 128)
        Me.MainButton.Name = "MainButton"
        Me.MainButton.Size = New System.Drawing.Size(77, 61)
        Me.MainButton.TabIndex = 21
        Me.MainButton.Text = "Start"
        Me.MainButton.UseVisualStyleBackColor = True
        '
        'ListView1
        '
        Me.ListView1.Location = New System.Drawing.Point(219, 12)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(192, 280)
        Me.ListView1.TabIndex = 20
        Me.ListView1.UseCompatibleStateImageBehavior = False
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(50, 228)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(138, 20)
        Me.statusLabel.TabIndex = 30
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 232)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Status: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 256)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Capture Progress:"
        '
        'CaptureProgressBurst
        '
        Me.CaptureProgressBurst.Location = New System.Drawing.Point(13, 272)
        Me.CaptureProgressBurst.Name = "CaptureProgressBurst"
        Me.CaptureProgressBurst.Size = New System.Drawing.Size(175, 18)
        Me.CaptureProgressBurst.TabIndex = 31
        '
        'BitModeCheckbox
        '
        Me.BitModeCheckbox.AutoSize = True
        Me.BitModeCheckbox.Location = New System.Drawing.Point(15, 202)
        Me.BitModeCheckbox.Name = "BitModeCheckbox"
        Me.BitModeCheckbox.Size = New System.Drawing.Size(131, 17)
        Me.BitModeCheckbox.TabIndex = 33
        Me.BitModeCheckbox.Text = "16-Bit Mode Enabled?"
        Me.BitModeCheckbox.UseVisualStyleBackColor = True
        '
        'IMUStreamingGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(426, 309)
        Me.Controls.Add(Me.BitModeCheckbox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CaptureProgressBurst)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.DRDIO)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.MeasureDR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.NumberDRToCapture)
        Me.Controls.Add(Me.BurstStreamCancelButton)
        Me.Controls.Add(Me.MainButton)
        Me.Controls.Add(Me.ListView1)
        Me.Name = "IMUStreamingGUI"
        Me.Text = "IMU Burst Data Capture"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents DRDIO As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents MeasureDR As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents NumberDRToCapture As TextBox
    Friend WithEvents BurstStreamCancelButton As Button
    Friend WithEvents MainButton As Button
    Friend WithEvents ListView1 As ListView
    Friend WithEvents statusLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CaptureProgressBurst As ProgressBar
    Friend WithEvents BitModeCheckbox As CheckBox
End Class
