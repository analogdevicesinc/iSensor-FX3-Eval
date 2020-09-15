<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BitBangSpiGUI

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.btn_Transfer = New System.Windows.Forms.Button()
        Me.bitsPerTransfer = New System.Windows.Forms.TextBox()
        Me.numTransfers = New System.Windows.Forms.TextBox()
        Me.sclk_freq = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.csLeadLag = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stallTicks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.result = New System.Windows.Forms.DataGridView()
        Me.useHardwareSpi = New System.Windows.Forms.CheckBox()
        Me.cpol = New System.Windows.Forms.CheckBox()
        Me.cpha = New System.Windows.Forms.CheckBox()
        Me.CS = New System.Windows.Forms.TextBox()
        Me.SCLK = New System.Windows.Forms.TextBox()
        Me.MISO = New System.Windows.Forms.TextBox()
        Me.MOSI = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(7, 220)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(75, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bits Per Word:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(7, 245)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "# Words:"
        '
        'btn_Transfer
        '
        Me.btn_Transfer.Location = New System.Drawing.Point(157, 217)
        Me.btn_Transfer.Name = "btn_Transfer"
        Me.btn_Transfer.Size = New System.Drawing.Size(90, 46)
        Me.btn_Transfer.TabIndex = 4
        Me.btn_Transfer.Text = "Transfer Data"
        Me.btn_Transfer.UseVisualStyleBackColor = True
        '
        'bitsPerTransfer
        '
        Me.bitsPerTransfer.Location = New System.Drawing.Point(88, 217)
        Me.bitsPerTransfer.Name = "bitsPerTransfer"
        Me.bitsPerTransfer.Size = New System.Drawing.Size(52, 20)
        Me.bitsPerTransfer.TabIndex = 6
        Me.bitsPerTransfer.Text = "16"
        '
        'numTransfers
        '
        Me.numTransfers.Location = New System.Drawing.Point(88, 243)
        Me.numTransfers.Name = "numTransfers"
        Me.numTransfers.Size = New System.Drawing.Size(52, 20)
        Me.numTransfers.TabIndex = 8
        Me.numTransfers.Text = "1"
        '
        'sclk_freq
        '
        Me.sclk_freq.Location = New System.Drawing.Point(115, 16)
        Me.sclk_freq.Name = "sclk_freq"
        Me.sclk_freq.Size = New System.Drawing.Size(111, 20)
        Me.sclk_freq.TabIndex = 11
        Me.sclk_freq.Text = "750000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 19)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SCLK Freq (Hz):"
        '
        'csLeadLag
        '
        Me.csLeadLag.Location = New System.Drawing.Point(115, 68)
        Me.csLeadLag.Name = "csLeadLag"
        Me.csLeadLag.Size = New System.Drawing.Size(111, 20)
        Me.csLeadLag.TabIndex = 13
        Me.csLeadLag.Text = "5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(6, 71)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "CS Lead/Lag Ticks:"
        '
        'stallTicks
        '
        Me.stallTicks.Location = New System.Drawing.Point(115, 42)
        Me.stallTicks.Name = "stallTicks"
        Me.stallTicks.Size = New System.Drawing.Size(111, 20)
        Me.stallTicks.TabIndex = 15
        Me.stallTicks.Text = "10.0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Stall Time (us):"
        '
        'result
        '
        Me.result.AllowUserToAddRows = False
        Me.result.AllowUserToDeleteRows = False
        Me.result.AllowUserToResizeColumns = False
        Me.result.AllowUserToResizeRows = False
        Me.result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.result.Location = New System.Drawing.Point(10, 269)
        Me.result.Name = "result"
        Me.result.RowHeadersVisible = False
        Me.result.Size = New System.Drawing.Size(237, 270)
        Me.result.TabIndex = 18
        '
        'useHardwareSpi
        '
        Me.useHardwareSpi.AutoSize = True
        Me.useHardwareSpi.Location = New System.Drawing.Point(9, 118)
        Me.useHardwareSpi.Name = "useHardwareSpi"
        Me.useHardwareSpi.Size = New System.Drawing.Size(135, 17)
        Me.useHardwareSpi.TabIndex = 19
        Me.useHardwareSpi.Text = "Override Hardware SPI"
        Me.useHardwareSpi.UseVisualStyleBackColor = True
        '
        'cpol
        '
        Me.cpol.AutoSize = True
        Me.cpol.Location = New System.Drawing.Point(9, 95)
        Me.cpol.Name = "cpol"
        Me.cpol.Size = New System.Drawing.Size(93, 17)
        Me.cpol.TabIndex = 20
        Me.cpol.Text = "CPOL Mode 1"
        Me.cpol.UseVisualStyleBackColor = True
        '
        'cpha
        '
        Me.cpha.AutoSize = True
        Me.cpha.Location = New System.Drawing.Point(137, 95)
        Me.cpha.Name = "cpha"
        Me.cpha.Size = New System.Drawing.Size(94, 17)
        Me.cpha.TabIndex = 21
        Me.cpha.Text = "CPHA Mode 1"
        Me.cpha.UseVisualStyleBackColor = True
        '
        'CS
        '
        Me.CS.Location = New System.Drawing.Point(49, 141)
        Me.CS.Name = "CS"
        Me.CS.Size = New System.Drawing.Size(52, 20)
        Me.CS.TabIndex = 22
        Me.CS.Text = "16"
        '
        'SCLK
        '
        Me.SCLK.Location = New System.Drawing.Point(49, 167)
        Me.SCLK.Name = "SCLK"
        Me.SCLK.Size = New System.Drawing.Size(52, 20)
        Me.SCLK.TabIndex = 23
        Me.SCLK.Text = "16"
        '
        'MISO
        '
        Me.MISO.Location = New System.Drawing.Point(179, 167)
        Me.MISO.Name = "MISO"
        Me.MISO.Size = New System.Drawing.Size(52, 20)
        Me.MISO.TabIndex = 24
        Me.MISO.Text = "16"
        '
        'MOSI
        '
        Me.MOSI.Location = New System.Drawing.Point(179, 141)
        Me.MOSI.Name = "MOSI"
        Me.MOSI.Size = New System.Drawing.Size(52, 20)
        Me.MOSI.TabIndex = 25
        Me.MOSI.Text = "16"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 144)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 13)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "CS:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 170)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 27
        Me.Label4.Text = "SCLK:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(136, 144)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(37, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "MOSI:"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(136, 170)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "MISO:"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.sclk_freq)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.csLeadLag)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.stallTicks)
        Me.GroupBox1.Controls.Add(Me.MOSI)
        Me.GroupBox1.Controls.Add(Me.useHardwareSpi)
        Me.GroupBox1.Controls.Add(Me.MISO)
        Me.GroupBox1.Controls.Add(Me.cpol)
        Me.GroupBox1.Controls.Add(Me.SCLK)
        Me.GroupBox1.Controls.Add(Me.cpha)
        Me.GroupBox1.Controls.Add(Me.CS)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(237, 199)
        Me.GroupBox1.TabIndex = 30
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SPI Configuration"
        '
        'BitBangSpiGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 551)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.result)
        Me.Controls.Add(Me.numTransfers)
        Me.Controls.Add(Me.bitsPerTransfer)
        Me.Controls.Add(Me.btn_Transfer)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximumSize = New System.Drawing.Size(275, 1200)
        Me.MinimumSize = New System.Drawing.Size(275, 300)
        Me.Name = "BitBangSpiGUI"
        Me.Text = "Bit Bang SPI"
        CType(Me.result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_Transfer As Button
    Friend WithEvents bitsPerTransfer As TextBox
    Friend WithEvents numTransfers As TextBox
    Friend WithEvents sclk_freq As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents csLeadLag As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents stallTicks As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents result As DataGridView
    Friend WithEvents useHardwareSpi As CheckBox
    Friend WithEvents cpol As CheckBox
    Friend WithEvents cpha As CheckBox
    Friend WithEvents CS As TextBox
    Friend WithEvents SCLK As TextBox
    Friend WithEvents MISO As TextBox
    Friend WithEvents MOSI As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents GroupBox1 As GroupBox
End Class
