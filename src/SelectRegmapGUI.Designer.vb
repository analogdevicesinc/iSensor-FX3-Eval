<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectRegmapGUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SelectRegmapGUI))
        Me.SelectRegmapComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OKButton = New System.Windows.Forms.Button()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SelectRegmapComboBox
        '
        Me.SelectRegmapComboBox.FormattingEnabled = True
        Me.SelectRegmapComboBox.Location = New System.Drawing.Point(12, 12)
        Me.SelectRegmapComboBox.Name = "SelectRegmapComboBox"
        Me.SelectRegmapComboBox.Size = New System.Drawing.Size(503, 21)
        Me.SelectRegmapComboBox.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 36)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(467, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Select the desired register map from the list and click OK, or Browse to select a" &
    "ny register map file."
        '
        'OKButton
        '
        Me.OKButton.Location = New System.Drawing.Point(163, 57)
        Me.OKButton.Name = "OKButton"
        Me.OKButton.Size = New System.Drawing.Size(75, 32)
        Me.OKButton.TabIndex = 29
        Me.OKButton.Text = "OK"
        Me.OKButton.UseVisualStyleBackColor = True
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(289, 57)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 32)
        Me.BrowseButton.TabIndex = 30
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'SelectRegmapGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(527, 98)
        Me.Controls.Add(Me.BrowseButton)
        Me.Controls.Add(Me.OKButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SelectRegmapComboBox)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SelectRegmapGUI"
        Me.Text = "Select Register Map"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelectRegmapComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents OKButton As Button
    Friend WithEvents BrowseButton As Button
End Class
