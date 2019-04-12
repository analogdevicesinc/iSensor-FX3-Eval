<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerAccessGUI
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
        Me.currentLabel = New System.Windows.Forms.Label()
        Me.newLabel = New System.Windows.Forms.Label()
        Me.selectBox = New System.Windows.Forms.ComboBox()
        Me.readButton = New System.Windows.Forms.Button()
        Me.WriteButton = New System.Windows.Forms.Button()
        Me.currentValueBox = New System.Windows.Forms.Label()
        Me.NewInputBox = New System.Windows.Forms.TextBox()
        Me.DRFreq = New System.Windows.Forms.Label()
        Me.ReadDRFreq = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'currentLabel
        '
        Me.currentLabel.AutoSize = True
        Me.currentLabel.Location = New System.Drawing.Point(185, 20)
        Me.currentLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.currentLabel.Name = "currentLabel"
        Me.currentLabel.Size = New System.Drawing.Size(99, 17)
        Me.currentLabel.TabIndex = 0
        Me.currentLabel.Text = "Current Value:"
        '
        'newLabel
        '
        Me.newLabel.AutoSize = True
        Me.newLabel.Location = New System.Drawing.Point(185, 53)
        Me.newLabel.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.newLabel.Name = "newLabel"
        Me.newLabel.Size = New System.Drawing.Size(79, 17)
        Me.newLabel.TabIndex = 1
        Me.newLabel.Text = "New Value:"
        '
        'selectBox
        '
        Me.selectBox.FormattingEnabled = True
        Me.selectBox.Location = New System.Drawing.Point(12, 15)
        Me.selectBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.selectBox.Name = "selectBox"
        Me.selectBox.Size = New System.Drawing.Size(164, 24)
        Me.selectBox.TabIndex = 2
        '
        'readButton
        '
        Me.readButton.Location = New System.Drawing.Point(189, 89)
        Me.readButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.readButton.Name = "readButton"
        Me.readButton.Size = New System.Drawing.Size(100, 44)
        Me.readButton.TabIndex = 3
        Me.readButton.Text = "Read Register"
        Me.readButton.UseVisualStyleBackColor = True
        '
        'WriteButton
        '
        Me.WriteButton.Location = New System.Drawing.Point(297, 89)
        Me.WriteButton.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.WriteButton.Name = "WriteButton"
        Me.WriteButton.Size = New System.Drawing.Size(100, 44)
        Me.WriteButton.TabIndex = 4
        Me.WriteButton.Text = "Write Register"
        Me.WriteButton.UseVisualStyleBackColor = True
        '
        'currentValueBox
        '
        Me.currentValueBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.currentValueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentValueBox.Location = New System.Drawing.Point(293, 16)
        Me.currentValueBox.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.currentValueBox.Name = "currentValueBox"
        Me.currentValueBox.Size = New System.Drawing.Size(103, 24)
        Me.currentValueBox.TabIndex = 5
        '
        'NewInputBox
        '
        Me.NewInputBox.Location = New System.Drawing.Point(293, 49)
        Me.NewInputBox.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.NewInputBox.Name = "NewInputBox"
        Me.NewInputBox.Size = New System.Drawing.Size(103, 22)
        Me.NewInputBox.TabIndex = 6
        '
        'DRFreq
        '
        Me.DRFreq.AutoSize = True
        Me.DRFreq.Location = New System.Drawing.Point(8, 58)
        Me.DRFreq.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.DRFreq.Name = "DRFreq"
        Me.DRFreq.Size = New System.Drawing.Size(0, 17)
        Me.DRFreq.TabIndex = 7
        '
        'ReadDRFreq
        '
        Me.ReadDRFreq.Location = New System.Drawing.Point(12, 89)
        Me.ReadDRFreq.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.ReadDRFreq.Name = "ReadDRFreq"
        Me.ReadDRFreq.Size = New System.Drawing.Size(83, 43)
        Me.ReadDRFreq.TabIndex = 8
        Me.ReadDRFreq.Text = "Read DR Freq"
        Me.ReadDRFreq.UseVisualStyleBackColor = True
        '
        'registerAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(407, 146)
        Me.Controls.Add(Me.ReadDRFreq)
        Me.Controls.Add(Me.DRFreq)
        Me.Controls.Add(Me.NewInputBox)
        Me.Controls.Add(Me.currentValueBox)
        Me.Controls.Add(Me.WriteButton)
        Me.Controls.Add(Me.readButton)
        Me.Controls.Add(Me.selectBox)
        Me.Controls.Add(Me.newLabel)
        Me.Controls.Add(Me.currentLabel)
        Me.Margin = New System.Windows.Forms.Padding(4, 4, 4, 4)
        Me.Name = "registerAccessGUI"
        Me.Text = "Register Access"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents currentLabel As Label
    Friend WithEvents newLabel As Label
    Friend WithEvents selectBox As ComboBox
    Friend WithEvents readButton As Button
    Friend WithEvents WriteButton As Button
    Friend WithEvents currentValueBox As Label
    Friend WithEvents NewInputBox As TextBox
    Friend WithEvents DRFreq As Label
    Friend WithEvents ReadDRFreq As Button
End Class
