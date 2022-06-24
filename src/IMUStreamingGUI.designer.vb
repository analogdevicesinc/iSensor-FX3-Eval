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
        Me.burstRegList = New System.Windows.Forms.ListView()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CaptureProgressBurst = New System.Windows.Forms.ProgressBar()
        Me.check_drActive = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.radio_inertial = New System.Windows.Forms.RadioButton()
        Me.radio_delta = New System.Windows.Forms.RadioButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.radio_32bit = New System.Windows.Forms.RadioButton()
        Me.radio_16bit = New System.Windows.Forms.RadioButton()
        Me.check_checksum = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(78, 28)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 13)
        Me.Label5.TabIndex = 28
        Me.Label5.Text = "DR DIO:"
        '
        'DRDIO
        '
        Me.DRDIO.FormattingEnabled = True
        Me.DRDIO.Location = New System.Drawing.Point(81, 44)
        Me.DRDIO.Name = "DRDIO"
        Me.DRDIO.Size = New System.Drawing.Size(111, 21)
        Me.DRDIO.TabIndex = 27
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(78, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(39, 13)
        Me.Label4.TabIndex = 26
        Me.Label4.Text = "Label4"
        '
        'MeasureDR
        '
        Me.MeasureDR.Location = New System.Drawing.Point(12, 12)
        Me.MeasureDR.Name = "MeasureDR"
        Me.MeasureDR.Size = New System.Drawing.Size(60, 76)
        Me.MeasureDR.TabIndex = 25
        Me.MeasureDR.Text = "Measure Data Ready Freq"
        Me.MeasureDR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 197)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "# Burst Reads:"
        '
        'NumberDRToCapture
        '
        Me.NumberDRToCapture.Location = New System.Drawing.Point(93, 194)
        Me.NumberDRToCapture.Name = "NumberDRToCapture"
        Me.NumberDRToCapture.Size = New System.Drawing.Size(99, 20)
        Me.NumberDRToCapture.TabIndex = 23
        '
        'BurstStreamCancelButton
        '
        Me.BurstStreamCancelButton.Location = New System.Drawing.Point(106, 220)
        Me.BurstStreamCancelButton.Name = "BurstStreamCancelButton"
        Me.BurstStreamCancelButton.Size = New System.Drawing.Size(86, 30)
        Me.BurstStreamCancelButton.TabIndex = 22
        Me.BurstStreamCancelButton.Text = "Cancel"
        Me.BurstStreamCancelButton.UseVisualStyleBackColor = True
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(12, 220)
        Me.MainButton.Name = "MainButton"
        Me.MainButton.Size = New System.Drawing.Size(86, 30)
        Me.MainButton.TabIndex = 21
        Me.MainButton.Text = "Start"
        Me.MainButton.UseVisualStyleBackColor = True
        '
        'burstRegList
        '
        Me.burstRegList.Location = New System.Drawing.Point(201, 12)
        Me.burstRegList.Name = "burstRegList"
        Me.burstRegList.Size = New System.Drawing.Size(207, 314)
        Me.burstRegList.TabIndex = 20
        Me.burstRegList.UseCompatibleStateImageBehavior = False
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(55, 262)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(137, 20)
        Me.statusLabel.TabIndex = 30
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Status: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 292)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Capture Progress:"
        '
        'CaptureProgressBurst
        '
        Me.CaptureProgressBurst.Location = New System.Drawing.Point(12, 308)
        Me.CaptureProgressBurst.Name = "CaptureProgressBurst"
        Me.CaptureProgressBurst.Size = New System.Drawing.Size(180, 18)
        Me.CaptureProgressBurst.TabIndex = 31
        '
        'check_drActive
        '
        Me.check_drActive.AutoSize = True
        Me.check_drActive.Location = New System.Drawing.Point(81, 71)
        Me.check_drActive.Name = "check_drActive"
        Me.check_drActive.Size = New System.Drawing.Size(75, 17)
        Me.check_drActive.TabIndex = 34
        Me.check_drActive.Text = "DR Active"
        Me.check_drActive.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.check_checksum)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 94)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(180, 91)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Burst Configuration"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.radio_inertial)
        Me.Panel2.Controls.Add(Me.radio_delta)
        Me.Panel2.Location = New System.Drawing.Point(2, 40)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(176, 24)
        Me.Panel2.TabIndex = 6
        '
        'radio_inertial
        '
        Me.radio_inertial.AutoSize = True
        Me.radio_inertial.Location = New System.Drawing.Point(4, 4)
        Me.radio_inertial.Name = "radio_inertial"
        Me.radio_inertial.Size = New System.Drawing.Size(82, 17)
        Me.radio_inertial.TabIndex = 2
        Me.radio_inertial.TabStop = True
        Me.radio_inertial.Text = "Inertial Data"
        Me.radio_inertial.UseVisualStyleBackColor = True
        '
        'radio_delta
        '
        Me.radio_delta.AutoSize = True
        Me.radio_delta.Location = New System.Drawing.Point(87, 4)
        Me.radio_delta.Name = "radio_delta"
        Me.radio_delta.Size = New System.Drawing.Size(76, 17)
        Me.radio_delta.TabIndex = 3
        Me.radio_delta.TabStop = True
        Me.radio_delta.Text = "Delta Data"
        Me.radio_delta.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.radio_32bit)
        Me.Panel1.Controls.Add(Me.radio_16bit)
        Me.Panel1.Location = New System.Drawing.Point(2, 16)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(176, 24)
        Me.Panel1.TabIndex = 5
        '
        'radio_32bit
        '
        Me.radio_32bit.AutoSize = True
        Me.radio_32bit.Location = New System.Drawing.Point(87, 3)
        Me.radio_32bit.Name = "radio_32bit"
        Me.radio_32bit.Size = New System.Drawing.Size(78, 17)
        Me.radio_32bit.TabIndex = 0
        Me.radio_32bit.TabStop = True
        Me.radio_32bit.Text = "32-Bit Data"
        Me.radio_32bit.UseVisualStyleBackColor = True
        '
        'radio_16bit
        '
        Me.radio_16bit.AutoSize = True
        Me.radio_16bit.Location = New System.Drawing.Point(4, 3)
        Me.radio_16bit.Name = "radio_16bit"
        Me.radio_16bit.Size = New System.Drawing.Size(78, 17)
        Me.radio_16bit.TabIndex = 1
        Me.radio_16bit.TabStop = True
        Me.radio_16bit.Text = "16-Bit Data"
        Me.radio_16bit.UseVisualStyleBackColor = True
        '
        'check_checksum
        '
        Me.check_checksum.AutoSize = True
        Me.check_checksum.Location = New System.Drawing.Point(7, 68)
        Me.check_checksum.Name = "check_checksum"
        Me.check_checksum.Size = New System.Drawing.Size(103, 17)
        Me.check_checksum.TabIndex = 4
        Me.check_checksum.Text = "Burst Checksum"
        Me.check_checksum.UseVisualStyleBackColor = True
        '
        'IMUStreamingGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 338)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.check_drActive)
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
        Me.Controls.Add(Me.burstRegList)
        Me.Name = "IMUStreamingGUI"
        Me.Text = "IMU Burst Data Capture"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
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
    Friend WithEvents burstRegList As ListView
    Friend WithEvents statusLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CaptureProgressBurst As ProgressBar
    Friend WithEvents check_drActive As CheckBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents check_checksum As CheckBox
    Friend WithEvents radio_delta As RadioButton
    Friend WithEvents radio_inertial As RadioButton
    Friend WithEvents radio_16bit As RadioButton
    Friend WithEvents radio_32bit As RadioButton
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Panel1 As Panel
End Class
