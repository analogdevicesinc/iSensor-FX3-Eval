<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ResistorConfigGUI

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
        Me.btn_pullUp = New System.Windows.Forms.Button()
        Me.btn_pullDown = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GPIO_Num = New System.Windows.Forms.TextBox()
        Me.btn_disableResistor = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_pullUp
        '
        Me.btn_pullUp.Location = New System.Drawing.Point(15, 54)
        Me.btn_pullUp.Name = "btn_pullUp"
        Me.btn_pullUp.Size = New System.Drawing.Size(75, 62)
        Me.btn_pullUp.TabIndex = 0
        Me.btn_pullUp.Text = "Enable Pull-Up Resistor"
        Me.btn_pullUp.UseVisualStyleBackColor = True
        '
        'btn_pullDown
        '
        Me.btn_pullDown.Location = New System.Drawing.Point(97, 54)
        Me.btn_pullDown.Name = "btn_pullDown"
        Me.btn_pullDown.Size = New System.Drawing.Size(75, 62)
        Me.btn_pullDown.TabIndex = 1
        Me.btn_pullDown.Text = "Enable Pull-Down Resistor"
        Me.btn_pullDown.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "FX3 GPIO Number:"
        '
        'GPIO_Num
        '
        Me.GPIO_Num.Location = New System.Drawing.Point(116, 12)
        Me.GPIO_Num.Name = "GPIO_Num"
        Me.GPIO_Num.Size = New System.Drawing.Size(138, 20)
        Me.GPIO_Num.TabIndex = 3
        Me.GPIO_Num.Text = "0"
        '
        'btn_disableResistor
        '
        Me.btn_disableResistor.Location = New System.Drawing.Point(179, 54)
        Me.btn_disableResistor.Name = "btn_disableResistor"
        Me.btn_disableResistor.Size = New System.Drawing.Size(75, 62)
        Me.btn_disableResistor.TabIndex = 4
        Me.btn_disableResistor.Text = "Disable Input Resistor"
        Me.btn_disableResistor.UseVisualStyleBackColor = True
        '
        'ResistorConfigGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(274, 131)
        Me.Controls.Add(Me.btn_disableResistor)
        Me.Controls.Add(Me.GPIO_Num)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_pullDown)
        Me.Controls.Add(Me.btn_pullUp)
        Me.MaximumSize = New System.Drawing.Size(290, 170)
        Me.MinimumSize = New System.Drawing.Size(290, 170)
        Me.Name = "ResistorConfigGUI"
        Me.Text = "GPIO Resistor Config"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_pullUp As Button
    Friend WithEvents btn_pullDown As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents GPIO_Num As TextBox
    Friend WithEvents btn_disableResistor As Button
End Class
