<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADcmXLBufferedLogGUI
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
        Me.btn_capture = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.calc_time = New System.Windows.Forms.TextBox()
        Me.time_cap = New System.Windows.Forms.RadioButton()
        Me.fft_cap = New System.Windows.Forms.RadioButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ADcmXLType = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'btn_capture
        '
        Me.btn_capture.Location = New System.Drawing.Point(97, 74)
        Me.btn_capture.Name = "btn_capture"
        Me.btn_capture.Size = New System.Drawing.Size(75, 49)
        Me.btn_capture.TabIndex = 0
        Me.btn_capture.Text = "Capture Data"
        Me.btn_capture.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 134)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(133, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "ADcmXL Calculation Time:"
        '
        'calc_time
        '
        Me.calc_time.Location = New System.Drawing.Point(148, 131)
        Me.calc_time.Name = "calc_time"
        Me.calc_time.Size = New System.Drawing.Size(124, 20)
        Me.calc_time.TabIndex = 4
        '
        'time_cap
        '
        Me.time_cap.AutoSize = True
        Me.time_cap.Location = New System.Drawing.Point(15, 44)
        Me.time_cap.Name = "time_cap"
        Me.time_cap.Size = New System.Drawing.Size(127, 17)
        Me.time_cap.TabIndex = 5
        Me.time_cap.TabStop = True
        Me.time_cap.Text = "Time Domain Capture"
        Me.time_cap.UseVisualStyleBackColor = True
        '
        'fft_cap
        '
        Me.fft_cap.AutoSize = True
        Me.fft_cap.Location = New System.Drawing.Point(188, 44)
        Me.fft_cap.Name = "fft_cap"
        Me.fft_cap.Size = New System.Drawing.Size(84, 17)
        Me.fft_cap.TabIndex = 6
        Me.fft_cap.TabStop = True
        Me.fft_cap.Text = "FFT Capture"
        Me.fft_cap.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(79, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "ADcmXL Type:"
        '
        'ADcmXLType
        '
        Me.ADcmXLType.Location = New System.Drawing.Point(97, 14)
        Me.ADcmXLType.Name = "ADcmXLType"
        Me.ADcmXLType.Size = New System.Drawing.Size(175, 20)
        Me.ADcmXLType.TabIndex = 8
        '
        'ADcmXLBufferedLog
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 161)
        Me.Controls.Add(Me.ADcmXLType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.fft_cap)
        Me.Controls.Add(Me.time_cap)
        Me.Controls.Add(Me.calc_time)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btn_capture)
        Me.MaximumSize = New System.Drawing.Size(300, 200)
        Me.MinimumSize = New System.Drawing.Size(300, 200)
        Me.Name = "ADcmXLBufferedLog"
        Me.Text = "ADcmXL Buffer Data"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btn_capture As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents calc_time As TextBox
    Friend WithEvents time_cap As RadioButton
    Friend WithEvents fft_cap As RadioButton
    Friend WithEvents Label1 As Label
    Friend WithEvents ADcmXLType As TextBox
End Class
