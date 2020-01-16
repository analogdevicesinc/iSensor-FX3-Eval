<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDUTGUI

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
        Me.DutInput = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btn_ApplySetting = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.sensorInput = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'DutInput
        '
        Me.DutInput.FormattingEnabled = True
        Me.DutInput.Location = New System.Drawing.Point(111, 38)
        Me.DutInput.Name = "DutInput"
        Me.DutInput.Size = New System.Drawing.Size(161, 21)
        Me.DutInput.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select DUT:"
        '
        'btn_ApplySetting
        '
        Me.btn_ApplySetting.Location = New System.Drawing.Point(99, 80)
        Me.btn_ApplySetting.Name = "btn_ApplySetting"
        Me.btn_ApplySetting.Size = New System.Drawing.Size(75, 64)
        Me.btn_ApplySetting.TabIndex = 27
        Me.btn_ApplySetting.Text = "Apply Setting"
        Me.btn_ApplySetting.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(5, 14)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(100, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Select SensorType:"
        '
        'sensorInput
        '
        Me.sensorInput.FormattingEnabled = True
        Me.sensorInput.Location = New System.Drawing.Point(111, 11)
        Me.sensorInput.Name = "sensorInput"
        Me.sensorInput.Size = New System.Drawing.Size(161, 21)
        Me.sensorInput.TabIndex = 29
        '
        'SelectDUTGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 155)
        Me.Controls.Add(Me.sensorInput)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_ApplySetting)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.DutInput)
        Me.Name = "SelectDUTGUI"
        Me.Text = "Select DUT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DutInput As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_ApplySetting As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents sensorInput As ComboBox
End Class
