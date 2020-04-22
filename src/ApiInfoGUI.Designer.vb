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
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.desc = New System.Windows.Forms.Label()
        Me.ver = New System.Windows.Forms.Label()
        Me.buildDate = New System.Windows.Forms.Label()
        Me.commitLink = New System.Windows.Forms.LinkLabel()
        Me.SuspendLayout()
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Location = New System.Drawing.Point(12, 10)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(39, 13)
        Me.nameLabel.TabIndex = 0
        Me.nameLabel.Text = "Label1"
        '
        'desc
        '
        Me.desc.AutoSize = True
        Me.desc.Location = New System.Drawing.Point(12, 32)
        Me.desc.Name = "desc"
        Me.desc.Size = New System.Drawing.Size(39, 13)
        Me.desc.TabIndex = 1
        Me.desc.Text = "Label2"
        '
        'ver
        '
        Me.ver.AutoSize = True
        Me.ver.Location = New System.Drawing.Point(12, 54)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(39, 13)
        Me.ver.TabIndex = 2
        Me.ver.Text = "Label3"
        '
        'buildDate
        '
        Me.buildDate.AutoSize = True
        Me.buildDate.Location = New System.Drawing.Point(12, 76)
        Me.buildDate.Name = "buildDate"
        Me.buildDate.Size = New System.Drawing.Size(39, 13)
        Me.buildDate.TabIndex = 3
        Me.buildDate.Text = "Label4"
        '
        'commitLink
        '
        Me.commitLink.AutoSize = True
        Me.commitLink.Location = New System.Drawing.Point(12, 98)
        Me.commitLink.Name = "commitLink"
        Me.commitLink.Size = New System.Drawing.Size(67, 13)
        Me.commitLink.TabIndex = 4
        Me.commitLink.TabStop = True
        Me.commitLink.Text = "View Commit"
        '
        'ApiInfoGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(449, 121)
        Me.Controls.Add(Me.commitLink)
        Me.Controls.Add(Me.buildDate)
        Me.Controls.Add(Me.ver)
        Me.Controls.Add(Me.desc)
        Me.Controls.Add(Me.nameLabel)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximumSize = New System.Drawing.Size(465, 160)
        Me.MinimumSize = New System.Drawing.Size(465, 160)
        Me.Name = "ApiInfoGUI"
        Me.Text = "FX3 API Info"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents nameLabel As Label
    Friend WithEvents desc As Label
    Friend WithEvents ver As Label
    Friend WithEvents buildDate As Label
    Friend WithEvents commitLink As LinkLabel
End Class
