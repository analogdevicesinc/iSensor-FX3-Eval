<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PulseMeasureGUI

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
        Me.modePages = New System.Windows.Forms.TabControl()
        Me.SpiPage = New System.Windows.Forms.TabPage()
        Me.triggerData = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.PinPage = New System.Windows.Forms.TabPage()
        Me.drivePolarity = New System.Windows.Forms.TextBox()
        Me.driveTime = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.triggerPin = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.startBtn = New System.Windows.Forms.Button()
        Me.label_result = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.busyPin = New System.Windows.Forms.ComboBox()
        Me.timeout = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.busyPolarity = New System.Windows.Forms.TextBox()
        Me.modePages.SuspendLayout()
        Me.SpiPage.SuspendLayout()
        Me.PinPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'modePages
        '
        Me.modePages.Controls.Add(Me.SpiPage)
        Me.modePages.Controls.Add(Me.PinPage)
        Me.modePages.Location = New System.Drawing.Point(12, 12)
        Me.modePages.Name = "modePages"
        Me.modePages.SelectedIndex = 0
        Me.modePages.Size = New System.Drawing.Size(255, 118)
        Me.modePages.TabIndex = 3
        '
        'SpiPage
        '
        Me.SpiPage.Controls.Add(Me.triggerData)
        Me.SpiPage.Controls.Add(Me.Label2)
        Me.SpiPage.Location = New System.Drawing.Point(4, 22)
        Me.SpiPage.Name = "SpiPage"
        Me.SpiPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SpiPage.Size = New System.Drawing.Size(247, 92)
        Me.SpiPage.TabIndex = 0
        Me.SpiPage.Text = "SPI Triggered"
        Me.SpiPage.UseVisualStyleBackColor = True
        '
        'triggerData
        '
        Me.triggerData.Location = New System.Drawing.Point(9, 25)
        Me.triggerData.Name = "triggerData"
        Me.triggerData.Size = New System.Drawing.Size(232, 20)
        Me.triggerData.TabIndex = 7
        Me.triggerData.Text = "BF08"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "SPI Trigger Data (hex):"
        '
        'PinPage
        '
        Me.PinPage.Controls.Add(Me.drivePolarity)
        Me.PinPage.Controls.Add(Me.driveTime)
        Me.PinPage.Controls.Add(Me.Label6)
        Me.PinPage.Controls.Add(Me.Label5)
        Me.PinPage.Controls.Add(Me.triggerPin)
        Me.PinPage.Controls.Add(Me.Label4)
        Me.PinPage.Location = New System.Drawing.Point(4, 22)
        Me.PinPage.Name = "PinPage"
        Me.PinPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PinPage.Size = New System.Drawing.Size(247, 92)
        Me.PinPage.TabIndex = 1
        Me.PinPage.Text = "Pin Triggered"
        Me.PinPage.UseVisualStyleBackColor = True
        '
        'drivePolarity
        '
        Me.drivePolarity.Location = New System.Drawing.Point(100, 33)
        Me.drivePolarity.Name = "drivePolarity"
        Me.drivePolarity.Size = New System.Drawing.Size(141, 20)
        Me.drivePolarity.TabIndex = 11
        Me.drivePolarity.Text = "0"
        '
        'driveTime
        '
        Me.driveTime.Location = New System.Drawing.Point(100, 59)
        Me.driveTime.Name = "driveTime"
        Me.driveTime.Size = New System.Drawing.Size(141, 20)
        Me.driveTime.TabIndex = 10
        Me.driveTime.Text = "10"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(3, 62)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(91, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Trigger Time (ms):"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(3, 36)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 8
        Me.Label5.Text = "Trigger Polarity:"
        '
        'triggerPin
        '
        Me.triggerPin.FormattingEnabled = True
        Me.triggerPin.Location = New System.Drawing.Point(100, 6)
        Me.triggerPin.Name = "triggerPin"
        Me.triggerPin.Size = New System.Drawing.Size(141, 21)
        Me.triggerPin.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 9)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(61, 13)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "Trigger Pin:"
        '
        'startBtn
        '
        Me.startBtn.Location = New System.Drawing.Point(89, 229)
        Me.startBtn.Name = "startBtn"
        Me.startBtn.Size = New System.Drawing.Size(75, 42)
        Me.startBtn.TabIndex = 4
        Me.startBtn.Text = "Start Pulse Measure"
        Me.startBtn.UseVisualStyleBackColor = True
        '
        'label_result
        '
        Me.label_result.Location = New System.Drawing.Point(78, 290)
        Me.label_result.Name = "label_result"
        Me.label_result.Size = New System.Drawing.Size(185, 20)
        Me.label_result.TabIndex = 5
        Me.label_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 293)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pulse Width:"
        '
        'busyPin
        '
        Me.busyPin.FormattingEnabled = True
        Me.busyPin.Location = New System.Drawing.Point(103, 136)
        Me.busyPin.Name = "busyPin"
        Me.busyPin.Size = New System.Drawing.Size(160, 21)
        Me.busyPin.TabIndex = 7
        '
        'timeout
        '
        Me.timeout.Location = New System.Drawing.Point(103, 190)
        Me.timeout.Name = "timeout"
        Me.timeout.Size = New System.Drawing.Size(160, 20)
        Me.timeout.TabIndex = 8
        Me.timeout.Text = "1000"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 13)
        Me.Label8.TabIndex = 10
        Me.Label8.Text = "Busy Pin:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 166)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(88, 13)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Measure Polarity:"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 194)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(70, 13)
        Me.Label10.TabIndex = 12
        Me.Label10.Text = "Timeout (ms):"
        '
        'busyPolarity
        '
        Me.busyPolarity.Location = New System.Drawing.Point(103, 163)
        Me.busyPolarity.Name = "busyPolarity"
        Me.busyPolarity.Size = New System.Drawing.Size(160, 20)
        Me.busyPolarity.TabIndex = 13
        Me.busyPolarity.Text = "0"
        '
        'PulseMeasureGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(279, 326)
        Me.Controls.Add(Me.busyPolarity)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.timeout)
        Me.Controls.Add(Me.busyPin)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label_result)
        Me.Controls.Add(Me.startBtn)
        Me.Controls.Add(Me.modePages)
        Me.MaximumSize = New System.Drawing.Size(295, 365)
        Me.MinimumSize = New System.Drawing.Size(295, 365)
        Me.Name = "PulseMeasureGUI"
        Me.Text = "Pulse Measurement"
        Me.modePages.ResumeLayout(False)
        Me.SpiPage.ResumeLayout(False)
        Me.SpiPage.PerformLayout()
        Me.PinPage.ResumeLayout(False)
        Me.PinPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents modePages As TabControl
    Friend WithEvents SpiPage As TabPage
    Friend WithEvents PinPage As TabPage
    Friend WithEvents startBtn As Button
    Friend WithEvents label_result As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents triggerData As TextBox
    Friend WithEvents drivePolarity As TextBox
    Friend WithEvents driveTime As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents triggerPin As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents busyPin As ComboBox
    Friend WithEvents timeout As TextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents busyPolarity As TextBox
End Class
