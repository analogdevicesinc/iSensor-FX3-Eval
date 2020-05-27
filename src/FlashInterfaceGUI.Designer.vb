<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FlashInterfaceGUI
    Inherits FormBase

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
        Me.btn_dumpFlash = New System.Windows.Forms.Button()
        Me.btn_dumpLog = New System.Windows.Forms.Button()
        Me.btn_clearError = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.logCount = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_dumpFlash
        '
        Me.btn_dumpFlash.Location = New System.Drawing.Point(174, 12)
        Me.btn_dumpFlash.Name = "btn_dumpFlash"
        Me.btn_dumpFlash.Size = New System.Drawing.Size(75, 64)
        Me.btn_dumpFlash.TabIndex = 2
        Me.btn_dumpFlash.Text = "Dump Flash"
        Me.btn_dumpFlash.UseVisualStyleBackColor = True
        '
        'btn_dumpLog
        '
        Me.btn_dumpLog.Location = New System.Drawing.Point(12, 12)
        Me.btn_dumpLog.Name = "btn_dumpLog"
        Me.btn_dumpLog.Size = New System.Drawing.Size(75, 64)
        Me.btn_dumpLog.TabIndex = 0
        Me.btn_dumpLog.Text = "Dump Error Log"
        Me.btn_dumpLog.UseVisualStyleBackColor = True
        '
        'btn_clearError
        '
        Me.btn_clearError.Location = New System.Drawing.Point(93, 12)
        Me.btn_clearError.Name = "btn_clearError"
        Me.btn_clearError.Size = New System.Drawing.Size(75, 64)
        Me.btn_clearError.TabIndex = 1
        Me.btn_clearError.Text = "Clear Error Log"
        Me.btn_clearError.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Error Log Count:"
        '
        'logCount
        '
        Me.logCount.Location = New System.Drawing.Point(102, 82)
        Me.logCount.Name = "logCount"
        Me.logCount.Size = New System.Drawing.Size(147, 20)
        Me.logCount.TabIndex = 3
        Me.logCount.TabStop = False
        '
        'FlashInterfaceGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(262, 115)
        Me.Controls.Add(Me.logCount)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btn_clearError)
        Me.Controls.Add(Me.btn_dumpLog)
        Me.Controls.Add(Me.btn_dumpFlash)
        Me.Name = "FlashInterfaceGUI"
        Me.Text = "FX3 Error Log"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_dumpFlash As Button
    Friend WithEvents btn_dumpLog As Button
    Friend WithEvents btn_clearError As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents logCount As TextBox
End Class
