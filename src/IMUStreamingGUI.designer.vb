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
        Me.Use32BitRegs = New System.Windows.Forms.CheckBox()
        Me.check_drActive = New System.Windows.Forms.CheckBox()
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
        Me.MeasureDR.Size = New System.Drawing.Size(60, 138)
        Me.MeasureDR.TabIndex = 25
        Me.MeasureDR.Text = "Measure Data Ready Freq"
        Me.MeasureDR.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(78, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(105, 13)
        Me.Label3.TabIndex = 24
        Me.Label3.Text = "# Bursts To Capture:"
        '
        'NumberDRToCapture
        '
        Me.NumberDRToCapture.Location = New System.Drawing.Point(81, 130)
        Me.NumberDRToCapture.Name = "NumberDRToCapture"
        Me.NumberDRToCapture.Size = New System.Drawing.Size(111, 20)
        Me.NumberDRToCapture.TabIndex = 23
        '
        'BurstStreamCancelButton
        '
        Me.BurstStreamCancelButton.Location = New System.Drawing.Point(106, 163)
        Me.BurstStreamCancelButton.Name = "BurstStreamCancelButton"
        Me.BurstStreamCancelButton.Size = New System.Drawing.Size(86, 30)
        Me.BurstStreamCancelButton.TabIndex = 22
        Me.BurstStreamCancelButton.Text = "Cancel"
        Me.BurstStreamCancelButton.UseVisualStyleBackColor = True
        '
        'MainButton
        '
        Me.MainButton.Location = New System.Drawing.Point(12, 163)
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
        Me.burstRegList.Size = New System.Drawing.Size(207, 257)
        Me.burstRegList.TabIndex = 20
        Me.burstRegList.UseCompatibleStateImageBehavior = False
        '
        'statusLabel
        '
        Me.statusLabel.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.statusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.statusLabel.ForeColor = System.Drawing.SystemColors.ControlText
        Me.statusLabel.Location = New System.Drawing.Point(55, 205)
        Me.statusLabel.Name = "statusLabel"
        Me.statusLabel.Size = New System.Drawing.Size(137, 20)
        Me.statusLabel.TabIndex = 30
        Me.statusLabel.Text = "Label6"
        Me.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 209)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(43, 13)
        Me.Label6.TabIndex = 29
        Me.Label6.Text = "Status: "
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 235)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(91, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Capture Progress:"
        '
        'CaptureProgressBurst
        '
        Me.CaptureProgressBurst.Location = New System.Drawing.Point(12, 251)
        Me.CaptureProgressBurst.Name = "CaptureProgressBurst"
        Me.CaptureProgressBurst.Size = New System.Drawing.Size(180, 18)
        Me.CaptureProgressBurst.TabIndex = 31
        '
        'Use32BitRegs
        '
        Me.Use32BitRegs.AutoSize = True
        Me.Use32BitRegs.Location = New System.Drawing.Point(81, 94)
        Me.Use32BitRegs.Name = "Use32BitRegs"
        Me.Use32BitRegs.Size = New System.Drawing.Size(114, 17)
        Me.Use32BitRegs.TabIndex = 33
        Me.Use32BitRegs.Text = "32-Bit Burst Reads"
        Me.Use32BitRegs.UseVisualStyleBackColor = True
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
        'IMUStreamingGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 281)
        Me.Controls.Add(Me.check_drActive)
        Me.Controls.Add(Me.Use32BitRegs)
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
    Friend WithEvents Use32BitRegs As CheckBox
    Friend WithEvents check_drActive As CheckBox
End Class
