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
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.board_info = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.nameLabel = New System.Windows.Forms.Label()
        Me.desc = New System.Windows.Forms.Label()
        Me.commitLink = New System.Windows.Forms.LinkLabel()
        Me.ver = New System.Windows.Forms.Label()
        Me.buildDate = New System.Windows.Forms.Label()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.board_info)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(447, 117)
        Me.GroupBox2.TabIndex = 6
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FX3 Board Info"
        '
        'board_info
        '
        Me.board_info.AutoSize = True
        Me.board_info.Location = New System.Drawing.Point(6, 19)
        Me.board_info.Name = "board_info"
        Me.board_info.Size = New System.Drawing.Size(39, 13)
        Me.board_info.TabIndex = 0
        Me.board_info.Text = "Label1"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.nameLabel)
        Me.GroupBox1.Controls.Add(Me.desc)
        Me.GroupBox1.Controls.Add(Me.commitLink)
        Me.GroupBox1.Controls.Add(Me.ver)
        Me.GroupBox1.Controls.Add(Me.buildDate)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(447, 132)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "FX3 API Info"
        '
        'nameLabel
        '
        Me.nameLabel.AutoSize = True
        Me.nameLabel.Location = New System.Drawing.Point(6, 19)
        Me.nameLabel.Name = "nameLabel"
        Me.nameLabel.Size = New System.Drawing.Size(39, 13)
        Me.nameLabel.TabIndex = 0
        Me.nameLabel.Text = "Label1"
        '
        'desc
        '
        Me.desc.AutoSize = True
        Me.desc.Location = New System.Drawing.Point(6, 41)
        Me.desc.Name = "desc"
        Me.desc.Size = New System.Drawing.Size(39, 13)
        Me.desc.TabIndex = 1
        Me.desc.Text = "Label2"
        '
        'commitLink
        '
        Me.commitLink.AutoSize = True
        Me.commitLink.Location = New System.Drawing.Point(6, 107)
        Me.commitLink.Name = "commitLink"
        Me.commitLink.Size = New System.Drawing.Size(67, 13)
        Me.commitLink.TabIndex = 4
        Me.commitLink.TabStop = True
        Me.commitLink.Text = "View Commit"
        '
        'ver
        '
        Me.ver.AutoSize = True
        Me.ver.Location = New System.Drawing.Point(6, 63)
        Me.ver.Name = "ver"
        Me.ver.Size = New System.Drawing.Size(39, 13)
        Me.ver.TabIndex = 2
        Me.ver.Text = "Label3"
        '
        'buildDate
        '
        Me.buildDate.AutoSize = True
        Me.buildDate.Location = New System.Drawing.Point(6, 85)
        Me.buildDate.Name = "buildDate"
        Me.buildDate.Size = New System.Drawing.Size(39, 13)
        Me.buildDate.TabIndex = 3
        Me.buildDate.Text = "Label4"
        '
        'ApiInfoGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(472, 279)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.Name = "ApiInfoGUI"
        Me.Text = "Connected FX3 Info"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents nameLabel As Label
    Friend WithEvents desc As Label
    Friend WithEvents ver As Label
    Friend WithEvents buildDate As Label
    Friend WithEvents commitLink As LinkLabel
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents board_info As Label
End Class
