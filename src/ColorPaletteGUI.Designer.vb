<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ColorPaletteGUI
    Inherits FormBase

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
        Me.good_color = New System.Windows.Forms.TextBox()
        Me.error_color = New System.Windows.Forms.TextBox()
        Me.idle_color = New System.Windows.Forms.TextBox()
        Me.btn_applysettings = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(78, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Success Color:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(59, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Error Color:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 67)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(54, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Idle Color:"
        '
        'good_color
        '
        Me.good_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.good_color.Location = New System.Drawing.Point(102, 12)
        Me.good_color.Name = "good_color"
        Me.good_color.ReadOnly = True
        Me.good_color.Size = New System.Drawing.Size(100, 20)
        Me.good_color.TabIndex = 3
        '
        'error_color
        '
        Me.error_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.error_color.Location = New System.Drawing.Point(102, 38)
        Me.error_color.Name = "error_color"
        Me.error_color.ReadOnly = True
        Me.error_color.Size = New System.Drawing.Size(100, 20)
        Me.error_color.TabIndex = 4
        '
        'idle_color
        '
        Me.idle_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.idle_color.Location = New System.Drawing.Point(102, 64)
        Me.idle_color.Name = "idle_color"
        Me.idle_color.ReadOnly = True
        Me.idle_color.Size = New System.Drawing.Size(100, 20)
        Me.idle_color.TabIndex = 5
        '
        'btn_applysettings
        '
        Me.btn_applysettings.Location = New System.Drawing.Point(63, 107)
        Me.btn_applysettings.Name = "btn_applysettings"
        Me.btn_applysettings.Size = New System.Drawing.Size(75, 64)
        Me.btn_applysettings.TabIndex = 6
        Me.btn_applysettings.Text = "Apply Settings"
        Me.btn_applysettings.UseVisualStyleBackColor = True
        '
        'ColorPaletteGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(221, 183)
        Me.Controls.Add(Me.btn_applysettings)
        Me.Controls.Add(Me.idle_color)
        Me.Controls.Add(Me.error_color)
        Me.Controls.Add(Me.good_color)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ColorPaletteGUI"
        Me.Text = "ColorPaletteGUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents good_color As TextBox
    Friend WithEvents error_color As TextBox
    Friend WithEvents idle_color As TextBox
    Friend WithEvents btn_applysettings As Button
End Class
