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
        Me.btn_ApplySetting = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.deviceInput = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btn_ApplySetting
        '
        Me.btn_ApplySetting.Location = New System.Drawing.Point(95, 46)
        Me.btn_ApplySetting.Name = "btn_ApplySetting"
        Me.btn_ApplySetting.Size = New System.Drawing.Size(75, 64)
        Me.btn_ApplySetting.TabIndex = 27
        Me.btn_ApplySetting.Text = "Apply Device Selection"
        Me.btn_ApplySetting.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(77, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Select Device:"
        '
        'deviceInput
        '
        Me.deviceInput.FormattingEnabled = True
        Me.deviceInput.Location = New System.Drawing.Point(95, 12)
        Me.deviceInput.Name = "deviceInput"
        Me.deviceInput.Size = New System.Drawing.Size(161, 21)
        Me.deviceInput.TabIndex = 31
        '
        'SelectDUTGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(271, 122)
        Me.Controls.Add(Me.deviceInput)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_ApplySetting)
        Me.Name = "SelectDUTGUI"
        Me.Text = "Select DUT"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_ApplySetting As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents deviceInput As ComboBox
End Class
