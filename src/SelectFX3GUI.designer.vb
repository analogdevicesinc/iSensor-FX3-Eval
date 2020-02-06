<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectFX3GUI

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
        Me.SelectFX3ComboBox = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SelectFX3OKButton = New System.Windows.Forms.Button()
        Me.WarningLabel = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SelectFX3ComboBox
        '
        Me.SelectFX3ComboBox.FormattingEnabled = True
        Me.SelectFX3ComboBox.Location = New System.Drawing.Point(15, 38)
        Me.SelectFX3ComboBox.Name = "SelectFX3ComboBox"
        Me.SelectFX3ComboBox.Size = New System.Drawing.Size(241, 21)
        Me.SelectFX3ComboBox.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Select a device:"
        '
        'SelectFX3OKButton
        '
        Me.SelectFX3OKButton.Location = New System.Drawing.Point(89, 124)
        Me.SelectFX3OKButton.Name = "SelectFX3OKButton"
        Me.SelectFX3OKButton.Size = New System.Drawing.Size(75, 23)
        Me.SelectFX3OKButton.TabIndex = 2
        Me.SelectFX3OKButton.Text = "OK"
        Me.SelectFX3OKButton.UseVisualStyleBackColor = True
        '
        'WarningLabel
        '
        Me.WarningLabel.AutoSize = True
        Me.WarningLabel.Location = New System.Drawing.Point(12, 73)
        Me.WarningLabel.Name = "WarningLabel"
        Me.WarningLabel.Size = New System.Drawing.Size(242, 39)
        Me.WarningLabel.TabIndex = 3
        Me.WarningLabel.Text = "If the board you're trying to connect to " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "isn't being detected, close this windo" &
    "w, " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "press the reset button on the board, and try again."
        Me.WarningLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'SelectFX3GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(269, 161)
        Me.Controls.Add(Me.WarningLabel)
        Me.Controls.Add(Me.SelectFX3OKButton)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.SelectFX3ComboBox)
        Me.MaximumSize = New System.Drawing.Size(285, 200)
        Me.MinimumSize = New System.Drawing.Size(285, 200)
        Me.Name = "SelectFX3GUI"
        Me.Text = "Select FX3"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents SelectFX3ComboBox As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents SelectFX3OKButton As Button
    Friend WithEvents WarningLabel As Label
End Class
