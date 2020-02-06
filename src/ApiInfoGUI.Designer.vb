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
        Me.label_info.Location = New System.Drawing.Point(12, 9)
        Me.label_info.Name = "label_info"
        Me.label_info.Size = New System.Drawing.Size(0, 13)
        Me.label_info.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 27)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 3
        '
        'ButtonOpenBrowser
        '
        Me.ButtonOpenBrowser.Location = New System.Drawing.Point(221, 193)
        Me.ButtonOpenBrowser.Margin = New System.Windows.Forms.Padding(2)
        Me.ButtonOpenBrowser.Name = "ButtonOpenBrowser"
        Me.ButtonOpenBrowser.Size = New System.Drawing.Size(67, 57)
        Me.ButtonOpenBrowser.TabIndex = 4
        Me.ButtonOpenBrowser.Text = "View the Commit"
        Me.ButtonOpenBrowser.UseVisualStyleBackColor = True
        '
        'ApiInfoGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 261)
        Me.Controls.Add(Me.ButtonOpenBrowser)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.label_info)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximumSize = New System.Drawing.Size(530, 300)
        Me.MinimumSize = New System.Drawing.Size(530, 300)
        Me.Name = "ApiInfoGUI"
        Me.Text = "FX3 API Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents label_info As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents ButtonOpenBrowser As Button
End Class
