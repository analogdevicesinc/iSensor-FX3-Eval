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
        Me.btn_restoreSpi = New System.Windows.Forms.Button()
        Me.sclk_freq = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.csLeadLag = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.stallTicks = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.result = New System.Windows.Forms.DataGridView()
        Me.useHardwareSpi = New System.Windows.Forms.CheckBox()
        CType(Me.result, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 35)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "# Transfers:"
        '
        'btn_Transfer
        '
        Me.btn_Transfer.Location = New System.Drawing.Point(15, 163)
        Me.btn_Transfer.Name = "btn_Transfer"
        Me.btn_Transfer.Size = New System.Drawing.Size(90, 42)
        Me.btn_Transfer.TabIndex = 4
        Me.btn_Transfer.Text = "Transfer Data"
        Me.btn_Transfer.UseVisualStyleBackColor = True
        '
        'bitsPerTransfer
        '
        Me.bitsPerTransfer.Location = New System.Drawing.Point(121, 6)
        Me.bitsPerTransfer.Name = "bitsPerTransfer"
        Me.bitsPerTransfer.Size = New System.Drawing.Size(125, 20)
        Me.bitsPerTransfer.TabIndex = 6
        Me.bitsPerTransfer.Text = "16"
        '
        'numTransfers
        '
        Me.numTransfers.Location = New System.Drawing.Point(121, 32)
        Me.numTransfers.Name = "numTransfers"
        Me.numTransfers.Size = New System.Drawing.Size(125, 20)
        Me.numTransfers.TabIndex = 8
        Me.numTransfers.Text = "1"
        '
        'btn_restoreSpi
        '
        Me.btn_restoreSpi.Location = New System.Drawing.Point(156, 163)
        Me.btn_restoreSpi.Name = "btn_restoreSpi"
        Me.btn_restoreSpi.Size = New System.Drawing.Size(90, 42)
        Me.btn_restoreSpi.TabIndex = 9
        Me.btn_restoreSpi.Text = "Restore Hardware SPI"
        Me.btn_restoreSpi.UseVisualStyleBackColor = True
        '
        'sclk_freq
        '
        Me.sclk_freq.Location = New System.Drawing.Point(121, 59)
        Me.sclk_freq.Name = "sclk_freq"
        Me.sclk_freq.Size = New System.Drawing.Size(125, 20)
        Me.sclk_freq.TabIndex = 11
        Me.sclk_freq.Text = "750000"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(83, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "SCLK Freq (Hz):"
        '
        'csLeadLag
        '
        Me.csLeadLag.Location = New System.Drawing.Point(121, 111)
        Me.csLeadLag.Name = "csLeadLag"
        Me.csLeadLag.Size = New System.Drawing.Size(125, 20)
        Me.csLeadLag.TabIndex = 13
        Me.csLeadLag.Text = "5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 114)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(103, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "CS Lead/Lag Ticks:"
        '
        'stallTicks
        '
        Me.stallTicks.Location = New System.Drawing.Point(121, 85)
        Me.stallTicks.Name = "stallTicks"
        Me.stallTicks.Size = New System.Drawing.Size(125, 20)
        Me.stallTicks.TabIndex = 15
        Me.stallTicks.Text = "10.0"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 88)
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
        Me.result.Location = New System.Drawing.Point(15, 211)
        Me.result.Name = "result"
        Me.result.RowHeadersVisible = False
        Me.result.Size = New System.Drawing.Size(231, 238)
        Me.result.TabIndex = 18
        '
        'useHardwareSpi
        '
        Me.useHardwareSpi.AutoSize = True
        Me.useHardwareSpi.Location = New System.Drawing.Point(15, 138)
        Me.useHardwareSpi.Name = "useHardwareSpi"
        Me.useHardwareSpi.Size = New System.Drawing.Size(135, 17)
        Me.useHardwareSpi.TabIndex = 19
        Me.useHardwareSpi.Text = "Override Hardware SPI"
        Me.useHardwareSpi.UseVisualStyleBackColor = True
        '
        'BitBangSpiGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(259, 461)
        Me.Controls.Add(Me.useHardwareSpi)
        Me.Controls.Add(Me.result)
        Me.Controls.Add(Me.stallTicks)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.csLeadLag)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.sclk_freq)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.btn_restoreSpi)
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
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents btn_Transfer As Button
    Friend WithEvents bitsPerTransfer As TextBox
    Friend WithEvents numTransfers As TextBox
    Friend WithEvents btn_restoreSpi As Button
    Friend WithEvents sclk_freq As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents csLeadLag As TextBox
    Friend WithEvents Label6 As Label
    Friend WithEvents stallTicks As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents result As DataGridView
    Friend WithEvents useHardwareSpi As CheckBox
End Class
