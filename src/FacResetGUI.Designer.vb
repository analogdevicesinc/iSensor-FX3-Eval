<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FacResetGUI
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
        Me.test_progress = New System.Windows.Forms.ProgressBar()
        Me.btn_startReset = New System.Windows.Forms.Button()
        Me.test_sts = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'test_progress
        '
        Me.test_progress.Location = New System.Drawing.Point(12, 80)
        Me.test_progress.Name = "test_progress"
        Me.test_progress.Size = New System.Drawing.Size(258, 23)
        Me.test_progress.TabIndex = 0
        '
        'btn_startReset
        '
        Me.btn_startReset.Location = New System.Drawing.Point(105, 12)
        Me.btn_startReset.Name = "btn_startReset"
        Me.btn_startReset.Size = New System.Drawing.Size(75, 62)
        Me.btn_startReset.TabIndex = 1
        Me.btn_startReset.Text = "Start DUT Factory Reset"
        Me.btn_startReset.UseVisualStyleBackColor = True
        '
        'test_sts
        '
        Me.test_sts.Location = New System.Drawing.Point(12, 131)
        Me.test_sts.Multiline = True
        Me.test_sts.Name = "test_sts"
        Me.test_sts.Size = New System.Drawing.Size(258, 134)
        Me.test_sts.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 115)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Factory Reset Status"
        '
        'FacResetGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(282, 275)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.test_sts)
        Me.Controls.Add(Me.btn_startReset)
        Me.Controls.Add(Me.test_progress)
        Me.Name = "FacResetGUI"
        Me.Text = "Factory Reset"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents test_progress As ProgressBar
    Friend WithEvents btn_startReset As Button
    Friend WithEvents test_sts As TextBox
    Friend WithEvents Label1 As Label
End Class
