<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PWMSetupGUI

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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.pinSelect = New System.Windows.Forms.ComboBox()
        Me.startBtn = New System.Windows.Forms.Button()
        Me.DutyCycle = New System.Windows.Forms.TextBox()
        Me.Freq = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select Pin:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 58)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(82, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Frequency (Hz):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(61, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Duty Cycle:"
        '
        'pinSelect
        '
        Me.pinSelect.FormattingEnabled = True
        Me.pinSelect.Location = New System.Drawing.Point(100, 6)
        Me.pinSelect.Name = "pinSelect"
        Me.pinSelect.Size = New System.Drawing.Size(181, 21)
        Me.pinSelect.TabIndex = 3
        '
        'startBtn
        '
        Me.startBtn.Location = New System.Drawing.Point(105, 97)
        Me.startBtn.Name = "startBtn"
        Me.startBtn.Size = New System.Drawing.Size(75, 64)
        Me.startBtn.TabIndex = 20
        Me.startBtn.Text = "Start PWM"
        Me.startBtn.UseVisualStyleBackColor = True
        '
        'DutyCycle
        '
        Me.DutyCycle.Location = New System.Drawing.Point(100, 31)
        Me.DutyCycle.Name = "DutyCycle"
        Me.DutyCycle.Size = New System.Drawing.Size(181, 20)
        Me.DutyCycle.TabIndex = 21
        '
        'Freq
        '
        Me.Freq.Location = New System.Drawing.Point(100, 55)
        Me.Freq.Name = "Freq"
        Me.Freq.Size = New System.Drawing.Size(181, 20)
        Me.Freq.TabIndex = 22
        '
        'PWMSetupGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(291, 173)
        Me.Controls.Add(Me.Freq)
        Me.Controls.Add(Me.DutyCycle)
        Me.Controls.Add(Me.startBtn)
        Me.Controls.Add(Me.pinSelect)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "PWMSetupGUI"
        Me.Text = "PWM Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents pinSelect As ComboBox
    Friend WithEvents startBtn As Button
    Friend WithEvents DutyCycle As TextBox
    Friend WithEvents Freq As TextBox
End Class
