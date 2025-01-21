<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SelectDUTGUI

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
        Me.btn_ApplySetting = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.familyInput = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.modelInput = New System.Windows.Forms.ComboBox()
        Me.devPicture = New System.Windows.Forms.PictureBox()
        CType(Me.devPicture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btn_ApplySetting
        '
        Me.btn_ApplySetting.Location = New System.Drawing.Point(169, 78)
        Me.btn_ApplySetting.Name = "btn_ApplySetting"
        Me.btn_ApplySetting.Size = New System.Drawing.Size(75, 64)
        Me.btn_ApplySetting.TabIndex = 27
        Me.btn_ApplySetting.Text = "Apply Device Selection"
        Me.btn_ApplySetting.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 15)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(112, 13)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Select Product Family:"
        '
        'familyInput
        '
        Me.familyInput.FormattingEnabled = True
        Me.familyInput.Location = New System.Drawing.Point(130, 12)
        Me.familyInput.Name = "familyInput"
        Me.familyInput.Size = New System.Drawing.Size(161, 21)
        Me.familyInput.TabIndex = 31
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 42)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 32
        Me.Label1.Text = "Select Model:"
        '
        'modelInput
        '
        Me.modelInput.FormattingEnabled = True
        Me.modelInput.Location = New System.Drawing.Point(130, 39)
        Me.modelInput.Name = "modelInput"
        Me.modelInput.Size = New System.Drawing.Size(161, 21)
        Me.modelInput.TabIndex = 33
        '
        'devPicture
        '
        Me.devPicture.Location = New System.Drawing.Point(297, 12)
        Me.devPicture.Name = "devPicture"
        Me.devPicture.Size = New System.Drawing.Size(130, 130)
        Me.devPicture.TabIndex = 34
        Me.devPicture.TabStop = False
        '
        'SelectDUTGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(437, 152)
        Me.Controls.Add(Me.devPicture)
        Me.Controls.Add(Me.modelInput)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.familyInput)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btn_ApplySetting)
        Me.Name = "SelectDUTGUI"
        Me.Text = "Select DUT"
        CType(Me.devPicture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btn_ApplySetting As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents familyInput As ComboBox
    Friend WithEvents Label1 As Label
    Friend WithEvents modelInput As ComboBox
    Friend WithEvents devPicture As PictureBox
End Class
