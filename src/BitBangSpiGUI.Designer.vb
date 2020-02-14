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
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.btn_Transfer = New System.Windows.Forms.Button()
        Me.MISOData = New System.Windows.Forms.TextBox()
        Me.bitsPerTransfer = New System.Windows.Forms.TextBox()
        Me.MOSIData = New System.Windows.Forms.TextBox()
        Me.numTransfers = New System.Windows.Forms.TextBox()
        Me.btn_restoreSpi = New System.Windows.Forms.Button()
        Me.sclk_freq = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.csLead = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stallTicks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.csLag = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(88, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Bits Per Transfer:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 61)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(89, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "MOSI Data (hex):"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "# Transfers:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 257)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MISO Data (hex):"
        '
        'btn_Transfer
        '
        Me.btn_Transfer.Location = New System.Drawing.Point(15, 195)
        Me.btn_Transfer.Name = "btn_Transfer"
        Me.btn_Transfer.Size = New System.Drawing.Size(90, 42)
        Me.btn_Transfer.TabIndex = 4
        Me.btn_Transfer.Text = "Transfer Data"
        Me.btn_Transfer.UseVisualStyleBackColor = True
        '
        'MISOData
        '
        Me.MISOData.Location = New System.Drawing.Point(105, 254)
        Me.MISOData.Name = "MISOData"
        Me.MISOData.Size = New System.Drawing.Size(167, 20)
        Me.MISOData.TabIndex = 5
        '
        'bitsPerTransfer
        '
        Me.bitsPerTransfer.Location = New System.Drawing.Point(105, 6)
        Me.bitsPerTransfer.Name = "bitsPerTransfer"
        Me.bitsPerTransfer.Size = New System.Drawing.Size(167, 20)
        Me.bitsPerTransfer.TabIndex = 6
        Me.bitsPerTransfer.Text = "16"
        '
        'MOSIData
        '
        Me.MOSIData.Location = New System.Drawing.Point(105, 58)
        Me.MOSIData.Name = "MOSIData"
        Me.MOSIData.Size = New System.Drawing.Size(167, 20)
        Me.MOSIData.TabIndex = 7
        Me.MOSIData.Text = "0000"
        '
        'numTransfers
        '
        Me.numTransfers.Location = New System.Drawing.Point(105, 32)
        Me.numTransfers.Name = "numTransfers"
        Me.numTransfers.Size = New System.Drawing.Size(167, 20)
        Me.numTransfers.TabIndex = 8
        Me.numTransfers.Text = "1"
        '
        'btn_restoreSpi
        '
        Me.btn_restoreSpi.Location = New System.Drawing.Point(182, 195)
        Me.btn_restoreSpi.Name = "btn_restoreSpi"
        Me.btn_restoreSpi.Size = New System.Drawing.Size(90, 42)
        Me.btn_restoreSpi.TabIndex = 9
        Me.btn_restoreSpi.Text = "Restore Hardware SPI"
        Me.btn_restoreSpi.UseVisualStyleBackColor = True
        '
        'sclk_freq
        '
        Me.sclk_freq.Location = New System.Drawing.Point(105, 84)
        Me.sclk_freq.Name = "sclk_freq"
        Me.sclk_freq.Size = New System.Drawing.Size(167, 20)
        Me.sclk_freq.TabIndex = 11
        Me.sclk_freq.Text = "750000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 87)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SCLK Freq (Hz):"
        '
        'csLead
        '
        Me.csLead.Location = New System.Drawing.Point(105, 136)
        Me.csLead.Name = "csLead"
        Me.csLead.Size = New System.Drawing.Size(167, 20)
        Me.csLead.TabIndex = 13
        Me.csLead.Text = "5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 139)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "CS Lead Ticks:"
        '
        'stallTicks
        '
        Me.stallTicks.Location = New System.Drawing.Point(105, 110)
        Me.stallTicks.Name = "stallTicks"
        Me.stallTicks.Size = New System.Drawing.Size(167, 20)
        Me.stallTicks.TabIndex = 15
        Me.stallTicks.Text = "10.0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 113)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(76, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Stall Time (us):"
        '
        'csLag
        '
        Me.csLag.Location = New System.Drawing.Point(105, 162)
        Me.csLag.Name = "csLag"
        Me.csLag.Size = New System.Drawing.Size(167, 20)
        Me.csLag.TabIndex = 17
        Me.csLag.Text = "5"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 165)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(74, 13)
        Me.Label8.TabIndex = 16
        Me.Label8.Text = "CS Lag Ticks:"
        '
        'BitBangSpiGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 289)
        Me.Controls.Add(Me.csLag)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.stallTicks)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.csLead)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.sclk_freq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_restoreSpi)
        Me.Controls.Add(Me.numTransfers)
        Me.Controls.Add(Me.MOSIData)
        Me.Controls.Add(Me.bitsPerTransfer)
        Me.Controls.Add(Me.MISOData)
        Me.Controls.Add(Me.btn_Transfer)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "BitBangSpiGUI"
        Me.Text = "Bit Bang SPI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents btn_Transfer As Button
    Friend WithEvents MISOData As TextBox
    Friend WithEvents bitsPerTransfer As TextBox
    Friend WithEvents MOSIData As TextBox
    Friend WithEvents numTransfers As TextBox
    Friend WithEvents btn_restoreSpi As Button
    Friend WithEvents sclk_freq As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents csLead As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents stallTicks As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents csLag As TextBox
    Friend WithEvents Label8 As Label
End Class
