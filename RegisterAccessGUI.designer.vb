<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class registerAccessGUI

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
        Me.currentLabel.Location = New System.Drawing.Point(139, 16)
        Me.currentLabel.Name = "currentLabel"
        Me.currentLabel.Size = New System.Drawing.Size(74, 13)
        Me.currentLabel.TabIndex = 0
        Me.currentLabel.Text = "Current Value:"
        '
        'newLabel
        '
        Me.newLabel.AutoSize = True
        Me.newLabel.Location = New System.Drawing.Point(139, 43)
        Me.newLabel.Name = "newLabel"
        Me.newLabel.Size = New System.Drawing.Size(62, 13)
        Me.newLabel.TabIndex = 1
        Me.newLabel.Text = "New Value:"
        '
        'selectBox
        '
        Me.selectBox.FormattingEnabled = True
        Me.selectBox.Location = New System.Drawing.Point(9, 12)
        Me.selectBox.Name = "selectBox"
        Me.selectBox.Size = New System.Drawing.Size(124, 21)
        Me.selectBox.TabIndex = 2
        '
        'readButton
        '
        Me.readButton.Location = New System.Drawing.Point(142, 72)
        Me.readButton.Name = "readButton"
        Me.readButton.Size = New System.Drawing.Size(75, 36)
        Me.readButton.TabIndex = 3
        Me.readButton.Text = "Read Register"
        Me.readButton.UseVisualStyleBackColor = True
        '
        'WriteButton
        '
        Me.WriteButton.Location = New System.Drawing.Point(223, 72)
        Me.WriteButton.Name = "WriteButton"
        Me.WriteButton.Size = New System.Drawing.Size(75, 36)
        Me.WriteButton.TabIndex = 4
        Me.WriteButton.Text = "Write Register"
        Me.WriteButton.UseVisualStyleBackColor = True
        '
        'currentValueBox
        '
        Me.currentValueBox.BackColor = System.Drawing.SystemColors.ControlLightLight
        Me.currentValueBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.currentValueBox.Location = New System.Drawing.Point(220, 13)
        Me.currentValueBox.Name = "currentValueBox"
        Me.currentValueBox.Size = New System.Drawing.Size(78, 20)
        Me.currentValueBox.TabIndex = 5
        '
        'NewInputBox
        '
        Me.NewInputBox.Location = New System.Drawing.Point(220, 40)
        Me.NewInputBox.Name = "NewInputBox"
        Me.NewInputBox.Size = New System.Drawing.Size(78, 20)
        Me.NewInputBox.TabIndex = 6
        '
        'DRFreq
        '
        Me.DRFreq.AutoSize = True
        Me.DRFreq.Location = New System.Drawing.Point(6, 47)
        Me.DRFreq.Name = "DRFreq"
        Me.DRFreq.Size = New System.Drawing.Size(0, 13)
        Me.DRFreq.TabIndex = 7
        '
        'ReadDRFreq
        '
        Me.ReadDRFreq.Location = New System.Drawing.Point(9, 72)
        Me.ReadDRFreq.Name = "ReadDRFreq"
        Me.ReadDRFreq.Size = New System.Drawing.Size(62, 35)
        Me.ReadDRFreq.TabIndex = 8
        Me.ReadDRFreq.Text = "Read DR Freq"
        Me.ReadDRFreq.UseVisualStyleBackColor = True
        '
        'registerAccessGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(310, 118)
        Me.Controls.Add(Me.ReadDRFreq)
        Me.Controls.Add(Me.DRFreq)
        Me.Controls.Add(Me.NewInputBox)
        Me.Controls.Add(Me.currentValueBox)
        Me.Controls.Add(Me.WriteButton)
        Me.Controls.Add(Me.readButton)
        Me.Controls.Add(Me.selectBox)
        Me.Controls.Add(Me.newLabel)
        Me.Controls.Add(Me.currentLabel)
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
