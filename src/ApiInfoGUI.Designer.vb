<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ApiInfoGUI

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.label_info = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.ButtonOpenBrowser = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'label_info
        '
        Me.label_info.AutoSize = True
        Me.label_info.Location = New System.Drawing.Point(18, 14)
        Me.label_info.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.label_info.Name = "label_info"
        Me.label_info.Size = New System.Drawing.Size(0, 20)
        Me.label_info.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(18, 42)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 20)
        Me.Label4.TabIndex = 3
        '
        'ButtonOpenBrowser
        '
        Me.ButtonOpenBrowser.Location = New System.Drawing.Point(348, 211)
        Me.ButtonOpenBrowser.Name = "ButtonOpenBrowser"
        Me.ButtonOpenBrowser.Size = New System.Drawing.Size(100, 87)
        Me.ButtonOpenBrowser.TabIndex = 4
        Me.ButtonOpenBrowser.Text = "Check the Commit"
        Me.ButtonOpenBrowser.UseVisualStyleBackColor = True
        '
        'ApiInfoGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(778, 374)
        Me.Controls.Add(Me.ButtonOpenBrowser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.label_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(6, 8, 6, 8)
        Me.Name = "ApiInfoGUI"
        Me.Text = "FX3 API Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents label_info As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonOpenBrowser As Button
End Class
