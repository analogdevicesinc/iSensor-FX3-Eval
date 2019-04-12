<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class manualModeGUI
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
        Me.modeSelect = New System.Windows.Forms.ComboBox()
        Me.RSSCheck = New System.Windows.Forms.CheckBox()
        Me.VelocityCheck = New System.Windows.Forms.CheckBox()
        Me.StatCheck = New System.Windows.Forms.CheckBox()
        Me.modeLabel = New System.Windows.Forms.Label()
        Me.captureButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'modeSelect
        '
        Me.modeSelect.FormattingEnabled = True
        Me.modeSelect.Location = New System.Drawing.Point(55, 7)
        Me.modeSelect.Name = "modeSelect"
        Me.modeSelect.Size = New System.Drawing.Size(121, 21)
        Me.modeSelect.TabIndex = 0
        '
        'RSSCheck
        '
        Me.RSSCheck.AutoSize = True
        Me.RSSCheck.Location = New System.Drawing.Point(199, 53)
        Me.RSSCheck.Name = "RSSCheck"
        Me.RSSCheck.Size = New System.Drawing.Size(83, 17)
        Me.RSSCheck.TabIndex = 1
        Me.RSSCheck.Text = "RSS Values"
        Me.RSSCheck.UseVisualStyleBackColor = True
        '
        'VelocityCheck
        '
        Me.VelocityCheck.AutoSize = True
        Me.VelocityCheck.Location = New System.Drawing.Point(199, 30)
        Me.VelocityCheck.Name = "VelocityCheck"
        Me.VelocityCheck.Size = New System.Drawing.Size(63, 17)
        Me.VelocityCheck.TabIndex = 2
        Me.VelocityCheck.Text = "Velocity"
        Me.VelocityCheck.UseVisualStyleBackColor = True
        '
        'StatCheck
        '
        Me.StatCheck.AutoSize = True
        Me.StatCheck.Location = New System.Drawing.Point(199, 7)
        Me.StatCheck.Name = "StatCheck"
        Me.StatCheck.Size = New System.Drawing.Size(68, 17)
        Me.StatCheck.TabIndex = 3
        Me.StatCheck.Text = "Statistics"
        Me.StatCheck.UseVisualStyleBackColor = True
        '
        'modeLabel
        '
        Me.modeLabel.AutoSize = True
        Me.modeLabel.Location = New System.Drawing.Point(12, 10)
        Me.modeLabel.Name = "modeLabel"
        Me.modeLabel.Size = New System.Drawing.Size(37, 13)
        Me.modeLabel.TabIndex = 4
        Me.modeLabel.Text = "Mode:"
        '
        'captureButton
        '
        Me.captureButton.Location = New System.Drawing.Point(124, 83)
        Me.captureButton.Name = "captureButton"
        Me.captureButton.Size = New System.Drawing.Size(74, 47)
        Me.captureButton.TabIndex = 5
        Me.captureButton.Text = "Capture"
        Me.captureButton.UseVisualStyleBackColor = True
        '
        'manualModeGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(311, 140)
        Me.Controls.Add(Me.captureButton)
        Me.Controls.Add(Me.modeLabel)
        Me.Controls.Add(Me.StatCheck)
        Me.Controls.Add(Me.VelocityCheck)
        Me.Controls.Add(Me.RSSCheck)
        Me.Controls.Add(Me.modeSelect)
        Me.Name = "manualModeGUI"
        Me.Text = "Manual Data Capture"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents modeSelect As ComboBox
    Friend WithEvents RSSCheck As CheckBox
    Friend WithEvents VelocityCheck As CheckBox
    Friend WithEvents StatCheck As CheckBox
    Friend WithEvents modeLabel As Label
    Friend WithEvents captureButton As Button
End Class
