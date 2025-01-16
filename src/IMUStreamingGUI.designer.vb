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
        Me.combo_DrSelect = New System.Windows.Forms.ComboBox()
        Me.label_measuredFreq = New System.Windows.Forms.Label()
        Me.btn_measureDR = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.text_numSamples = New System.Windows.Forms.TextBox()
        Me.btn_cancel = New System.Windows.Forms.Button()
        Me.btn_start = New System.Windows.Forms.Button()
        Me.burstRegList = New System.Windows.Forms.ListView()
        Me.statusLabel = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CaptureProgressBurst = New System.Windows.Forms.ProgressBar()
        Me.check_drActive = New System.Windows.Forms.CheckBox()
        Me.group_config = New System.Windows.Forms.GroupBox()
        Me.panel_dataformat = New System.Windows.Forms.Panel()
        Me.radio_inertial = New System.Windows.Forms.RadioButton()
        Me.radio_delta = New System.Windows.Forms.RadioButton()
        Me.panel_wordsize = New System.Windows.Forms.Panel()
        Me.radio_32bit = New System.Windows.Forms.RadioButton()
        Me.radio_16bit = New System.Windows.Forms.RadioButton()
        Me.check_checksum = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.text_recTime = New System.Windows.Forms.TextBox()
        Me.check_scaleData = New System.Windows.Forms.CheckBox()
        Me.check_logTimestamps = New System.Windows.Forms.CheckBox()
        Me.group_config.SuspendLayout()
        Me.panel_dataformat.SuspendLayout()
        Me.panel_wordsize.SuspendLayout()
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
        'combo_DrSelect
        '
        Me.combo_DrSelect.FormattingEnabled = True
        Me.combo_DrSelect.Location = New System.Drawing.Point(81, 44)
        Me.combo_DrSelect.Name = "combo_DrSelect"
        Me.combo_DrSelect.Size = New System.Drawing.Size(111, 21)
        Me.combo_DrSelect.TabIndex = 27
        '
        'label_measuredFreq
        '
        Me.label_measuredFreq.AutoSize = True
        Me.label_measuredFreq.Location = New System.Drawing.Point(78, 12)
        Me.label_measuredFreq.Name = "label_measuredFreq"
        Me.label_measuredFreq.Size = New System.Drawing.Size(47, 13)
        Me.label_measuredFreq.TabIndex = 26
        Me.label_measuredFreq.Text = "DR Freq"
        '
        'btn_measureDR
        '
        Me.btn_measureDR.Location = New System.Drawing.Point(12, 12)
        Me.btn_measureDR.Name = "btn_measureDR"
        Me.btn_measureDR.Size = New System.Drawing.Size(60, 76)
        Me.btn_measureDR.TabIndex = 25
        Me.btn_measureDR.Text = "Measure Data Ready Freq"
        Me.btn_measureDR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(10, 239)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "# Burst Reads:"
        '
        'text_numSamples
        '
        Me.text_numSamples.Location = New System.Drawing.Point(98, 236)
        Me.text_numSamples.Name = "text_numSamples"
        Me.text_numSamples.Size = New System.Drawing.Size(94, 20)
        Me.text_numSamples.TabIndex = 23
        '
        'btn_cancel
        '
        Me.btn_cancel.Location = New System.Drawing.Point(107, 291)
        Me.btn_cancel.Name = "btn_cancel"
        Me.btn_cancel.Size = New System.Drawing.Size(86, 30)
        Me.btn_cancel.TabIndex = 22
        Me.btn_cancel.Text = "Cancel"
        Me.btn_cancel.UseVisualStyleBackColor = True
        '
        'btn_start
        '
        Me.btn_start.Location = New System.Drawing.Point(13, 291)
        Me.btn_start.Name = "btn_start"
        Me.btn_start.Size = New System.Drawing.Size(86, 30)
        Me.btn_start.TabIndex = 21
        Me.btn_start.Text = "Start"
        Me.btn_start.UseVisualStyleBackColor = True
        '
        'burstRegList
        '
        Me.burstRegList.Location = New System.Drawing.Point(201, 12)
        Me.burstRegList.Name = "burstRegList"
        Me.burstRegList.Size = New System.Drawing.Size(207, 342)
        Me.burstRegList.TabIndex = 20
        Me.burstRegList.UseCompatibleStateImageBehavior = False
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(55, 328)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(137, 20)
        Me.statusLabel.TabIndex = 30
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 332)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Status: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 354)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Capture Progress:"
        '
        'CaptureProgressBurst
        '
        Me.CaptureProgressBurst.Location = New System.Drawing.Point(12, 370)
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
        'group_config
        '
        Me.group_config.Controls.Add(Me.panel_dataformat)
        Me.group_config.Controls.Add(Me.panel_wordsize)
        Me.group_config.Controls.Add(Me.check_checksum)
        Me.group_config.Location = New System.Drawing.Point(12, 94)
        Me.group_config.Name = "group_config"
        Me.group_config.Size = New System.Drawing.Size(180, 91)
        Me.group_config.TabIndex = 35
        Me.group_config.TabStop = False
        Me.group_config.Text = "Burst Configuration"
        '
        'panel_dataformat
        '
        Me.panel_dataformat.Controls.Add(Me.radio_inertial)
        Me.panel_dataformat.Controls.Add(Me.radio_delta)
        Me.panel_dataformat.Location = New System.Drawing.Point(2, 40)
        Me.panel_dataformat.Name = "panel_dataformat"
        Me.panel_dataformat.Size = New System.Drawing.Size(176, 24)
        Me.panel_dataformat.TabIndex = 6
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
        'panel_wordsize
        '
        Me.panel_wordsize.Controls.Add(Me.radio_32bit)
        Me.panel_wordsize.Controls.Add(Me.radio_16bit)
        Me.panel_wordsize.Location = New System.Drawing.Point(2, 16)
        Me.panel_wordsize.Name = "panel_wordsize"
        Me.panel_wordsize.Size = New System.Drawing.Size(176, 24)
        Me.panel_wordsize.TabIndex = 5
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
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 267)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 36
        Me.Label2.Text = "Rec. Time (est):"
        '
        'text_recTime
        '
        Me.text_recTime.Location = New System.Drawing.Point(98, 264)
        Me.text_recTime.Name = "text_recTime"
        Me.text_recTime.Size = New System.Drawing.Size(94, 20)
        Me.text_recTime.TabIndex = 37
        '
        'check_scaleData
        '
        Me.check_scaleData.AutoSize = True
        Me.check_scaleData.Location = New System.Drawing.Point(18, 192)
        Me.check_scaleData.Name = "check_scaleData"
        Me.check_scaleData.Size = New System.Drawing.Size(115, 17)
        Me.check_scaleData.TabIndex = 38
        Me.check_scaleData.Text = "Scale Sensor Data"
        Me.check_scaleData.UseVisualStyleBackColor = True
        '
        'check_logTimestamps
        '
        Me.check_logTimestamps.AutoSize = True
        Me.check_logTimestamps.Location = New System.Drawing.Point(18, 215)
        Me.check_logTimestamps.Name = "check_logTimestamps"
        Me.check_logTimestamps.Size = New System.Drawing.Size(103, 17)
        Me.check_logTimestamps.TabIndex = 39
        Me.check_logTimestamps.Text = "Log Timestamps"
        Me.check_logTimestamps.UseVisualStyleBackColor = True
        '
        'IMUStreamingGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 394)
        Me.Controls.Add(Me.check_logTimestamps)
        Me.Controls.Add(Me.check_scaleData)
        Me.Controls.Add(Me.text_recTime)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.group_config)
        Me.Controls.Add(Me.check_drActive)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CaptureProgressBurst)
        Me.Controls.Add(Me.statusLabel)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.combo_DrSelect)
        Me.Controls.Add(Me.label_measuredFreq)
        Me.Controls.Add(Me.btn_measureDR)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.text_numSamples)
        Me.Controls.Add(Me.btn_cancel)
        Me.Controls.Add(Me.btn_start)
        Me.Controls.Add(Me.burstRegList)
        Me.Name = "IMUStreamingGUI"
        Me.Text = "IMU Burst Data Capture"
        Me.group_config.ResumeLayout(False)
        Me.group_config.PerformLayout()
        Me.panel_dataformat.ResumeLayout(False)
        Me.panel_dataformat.PerformLayout()
        Me.panel_wordsize.ResumeLayout(False)
        Me.panel_wordsize.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label5 As Label
    Friend WithEvents combo_DrSelect As ComboBox
    Friend WithEvents label_measuredFreq As Label
    Friend WithEvents btn_measureDR As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents text_numSamples As TextBox
    Friend WithEvents btn_cancel As Button
    Friend WithEvents btn_start As Button
    Friend WithEvents burstRegList As ListView
    Friend WithEvents statusLabel As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CaptureProgressBurst As ProgressBar
    Friend WithEvents check_drActive As CheckBox
    Friend WithEvents group_config As GroupBox
    Friend WithEvents check_checksum As CheckBox
    Friend WithEvents radio_delta As RadioButton
    Friend WithEvents radio_inertial As RadioButton
    Friend WithEvents radio_16bit As RadioButton
    Friend WithEvents radio_32bit As RadioButton
    Friend WithEvents panel_dataformat As Panel
    Friend WithEvents panel_wordsize As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents text_recTime As TextBox
    Friend WithEvents check_scaleData As CheckBox
    Friend WithEvents check_logTimestamps As CheckBox
End Class
