<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PulseMeasureGUI

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
        Me.modePages = New System.Windows.Forms.TabControl()
        Me.SpiPage = New System.Windows.Forms.TabPage()
        Me.PinPage = New System.Windows.Forms.TabPage()
        Me.startBtn = New System.Windows.Forms.Button()
        Me.label_result = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.modePages.SuspendLayout()
        Me.SpiPage.SuspendLayout()
        Me.SuspendLayout()
        '
        'modePages
        '
        Me.modePages.Controls.Add(Me.SpiPage)
        Me.modePages.Controls.Add(Me.PinPage)
        Me.modePages.Location = New System.Drawing.Point(12, 12)
        Me.modePages.Name = "modePages"
        Me.modePages.SelectedIndex = 0
        Me.modePages.Size = New System.Drawing.Size(276, 169)
        Me.modePages.TabIndex = 3
        '
        'SpiPage
        '
        Me.SpiPage.Controls.Add(Me.Label3)
        Me.SpiPage.Controls.Add(Me.Label2)
        Me.SpiPage.Location = New System.Drawing.Point(4, 22)
        Me.SpiPage.Name = "SpiPage"
        Me.SpiPage.Padding = New System.Windows.Forms.Padding(3)
        Me.SpiPage.Size = New System.Drawing.Size(268, 143)
        Me.SpiPage.TabIndex = 0
        Me.SpiPage.Text = "SPI Triggered"
        Me.SpiPage.UseVisualStyleBackColor = True
        '
        'PinPage
        '
        Me.PinPage.Location = New System.Drawing.Point(4, 22)
        Me.PinPage.Name = "PinPage"
        Me.PinPage.Padding = New System.Windows.Forms.Padding(3)
        Me.PinPage.Size = New System.Drawing.Size(268, 287)
        Me.PinPage.TabIndex = 1
        Me.PinPage.Text = "Pin Triggered"
        Me.PinPage.UseVisualStyleBackColor = True
        '
        'startBtn
        '
        Me.startBtn.Location = New System.Drawing.Point(109, 478)
        Me.startBtn.Name = "startBtn"
        Me.startBtn.Size = New System.Drawing.Size(75, 42)
        Me.startBtn.TabIndex = 4
        Me.startBtn.Text = "Start Pulse Measure"
        Me.startBtn.UseVisualStyleBackColor = True
        '
        'label_result
        '
        Me.label_result.Location = New System.Drawing.Point(82, 535)
        Me.label_result.Name = "label_result"
        Me.label_result.Size = New System.Drawing.Size(202, 20)
        Me.label_result.TabIndex = 5
        Me.label_result.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 538)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Pulse Width:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(121, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Command Reg Address:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 44)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(110, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Command Reg Value:"
        '
        'PulseMeasureGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(301, 560)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.label_result)
        Me.Controls.Add(Me.startBtn)
        Me.Controls.Add(Me.modePages)
        Me.Name = "PulseMeasureGUI"
        Me.Text = "Pulse Measurement"
        Me.modePages.ResumeLayout(False)
        Me.SpiPage.ResumeLayout(False)
        Me.SpiPage.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents modePages As TabControl
    Friend WithEvents SpiPage As TabPage
    Friend WithEvents PinPage As TabPage
    Friend WithEvents startBtn As Button
    Friend WithEvents label_result As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
End Class
