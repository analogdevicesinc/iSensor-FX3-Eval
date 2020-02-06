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
        Me.Label4.Location = New System.Drawing.Point(9, 160)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(89, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "MISO Data (hex):"
        '
        'btn_Transfer
        '
        Me.btn_Transfer.Location = New System.Drawing.Point(15, 98)
        Me.btn_Transfer.Name = "btn_Transfer"
        Me.btn_Transfer.Size = New System.Drawing.Size(90, 42)
        Me.btn_Transfer.TabIndex = 4
        Me.btn_Transfer.Text = "Transfer Data"
        Me.btn_Transfer.UseVisualStyleBackColor = True
        '
        'MISOData
        '
        Me.MISOData.Location = New System.Drawing.Point(105, 157)
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
        Me.btn_restoreSpi.Location = New System.Drawing.Point(182, 98)
        Me.btn_restoreSpi.Name = "btn_restoreSpi"
        Me.btn_restoreSpi.Size = New System.Drawing.Size(90, 42)
        Me.btn_restoreSpi.TabIndex = 9
        Me.btn_restoreSpi.Text = "Restore Hardware SPI"
        Me.btn_restoreSpi.UseVisualStyleBackColor = True
        '
        'BitBangSpiGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 191)
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
        Me.MaximumSize = New System.Drawing.Size(300, 230)
        Me.MinimumSize = New System.Drawing.Size(300, 230)
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
End Class
