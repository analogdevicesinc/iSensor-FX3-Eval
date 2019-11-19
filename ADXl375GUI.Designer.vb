<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ADXl375GUI

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
        Me.readBtn = New System.Windows.Forms.Button()
        Me.writeBtn = New System.Windows.Forms.Button()
        Me.addr = New System.Windows.Forms.TextBox()
        Me.value = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.readBox = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.readFIFO = New System.Windows.Forms.Button()
        Me.configure = New System.Windows.Forms.Button()
        Me.numBuffers = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.parseLA = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'readBtn
        '
        Me.readBtn.Location = New System.Drawing.Point(197, 79)
        Me.readBtn.Name = "readBtn"
        Me.readBtn.Size = New System.Drawing.Size(75, 30)
        Me.readBtn.TabIndex = 0
        Me.readBtn.Text = "Read"
        Me.readBtn.UseVisualStyleBackColor = True
        '
        'writeBtn
        '
        Me.writeBtn.Location = New System.Drawing.Point(197, 42)
        Me.writeBtn.Name = "writeBtn"
        Me.writeBtn.Size = New System.Drawing.Size(75, 30)
        Me.writeBtn.TabIndex = 1
        Me.writeBtn.Text = "Write"
        Me.writeBtn.UseVisualStyleBackColor = True
        '
        'addr
        '
        Me.addr.Location = New System.Drawing.Point(91, 12)
        Me.addr.Name = "addr"
        Me.addr.Size = New System.Drawing.Size(100, 20)
        Me.addr.TabIndex = 2
        Me.addr.Text = "0"
        '
        'value
        '
        Me.value.Location = New System.Drawing.Point(91, 48)
        Me.value.Name = "value"
        Me.value.Size = New System.Drawing.Size(100, 20)
        Me.value.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(3, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Addr (Hex):"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(3, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(81, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Write Val (Hex):"
        '
        'readBox
        '
        Me.readBox.Location = New System.Drawing.Point(91, 85)
        Me.readBox.Name = "readBox"
        Me.readBox.Size = New System.Drawing.Size(100, 20)
        Me.readBox.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(3, 88)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(76, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Reg Val (Hex):"
        '
        'readFIFO
        '
        Me.readFIFO.Location = New System.Drawing.Point(6, 206)
        Me.readFIFO.Name = "readFIFO"
        Me.readFIFO.Size = New System.Drawing.Size(89, 43)
        Me.readFIFO.TabIndex = 8
        Me.readFIFO.Text = "Read Data"
        Me.readFIFO.UseVisualStyleBackColor = True
        '
        'configure
        '
        Me.configure.Location = New System.Drawing.Point(91, 122)
        Me.configure.Name = "configure"
        Me.configure.Size = New System.Drawing.Size(89, 43)
        Me.configure.TabIndex = 9
        Me.configure.Text = "Configure ADXL375"
        Me.configure.UseVisualStyleBackColor = True
        '
        'numBuffers
        '
        Me.numBuffers.Location = New System.Drawing.Point(91, 178)
        Me.numBuffers.Name = "numBuffers"
        Me.numBuffers.Size = New System.Drawing.Size(100, 20)
        Me.numBuffers.TabIndex = 10
        Me.numBuffers.Text = "100"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(3, 181)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(68, 13)
        Me.Label4.TabIndex = 11
        Me.Label4.Text = "Num Buffers:"
        '
        'parseLA
        '
        Me.parseLA.Location = New System.Drawing.Point(186, 206)
        Me.parseLA.Name = "parseLA"
        Me.parseLA.Size = New System.Drawing.Size(86, 43)
        Me.parseLA.TabIndex = 12
        Me.parseLA.Text = "Parse Logic Analyzer"
        Me.parseLA.UseVisualStyleBackColor = True
        '
        'ADXl375GUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 258)
        Me.Controls.Add(Me.parseLA)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numBuffers)
        Me.Controls.Add(Me.configure)
        Me.Controls.Add(Me.readFIFO)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.readBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.value)
        Me.Controls.Add(Me.addr)
        Me.Controls.Add(Me.writeBtn)
        Me.Controls.Add(Me.readBtn)
        Me.Name = "ADXl375GUI"
        Me.Text = "ADXL375 Interface"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents readBtn As Button
    Friend WithEvents writeBtn As Button
    Friend WithEvents addr As TextBox
    Friend WithEvents value As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents readBox As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents readFIFO As Button
    Friend WithEvents configure As Button
    Friend WithEvents numBuffers As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents parseLA As Button
End Class
