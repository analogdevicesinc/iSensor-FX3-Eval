<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class BurstTestGUI

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
        Me.drActive = New System.Windows.Forms.CheckBox()
        Me.csDelay = New System.Windows.Forms.ComboBox()
        Me.sclk = New System.Windows.Forms.TextBox()
        Me.applySettings = New System.Windows.Forms.Button()
        Me.captureData = New System.Windows.Forms.Button()
        Me.numBytes = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.result = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btn_StartStream = New System.Windows.Forms.Button()
        Me.numBurstWords = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        CType(Me.result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'drActive
        '
        Me.drActive.AutoSize = True
        Me.drActive.Location = New System.Drawing.Point(9, 108)
        Me.drActive.Name = "drActive"
        Me.drActive.Size = New System.Drawing.Size(75, 17)
        Me.drActive.TabIndex = 0
        Me.drActive.Text = "DR Active"
        Me.drActive.UseVisualStyleBackColor = True
        '
        'csDelay
        '
        Me.csDelay.FormattingEnabled = True
        Me.csDelay.Location = New System.Drawing.Point(66, 23)
        Me.csDelay.Name = "csDelay"
        Me.csDelay.Size = New System.Drawing.Size(195, 21)
        Me.csDelay.TabIndex = 1
        '
        'sclk
        '
        Me.sclk.Location = New System.Drawing.Point(66, 50)
        Me.sclk.Name = "sclk"
        Me.sclk.Size = New System.Drawing.Size(195, 20)
        Me.sclk.TabIndex = 2
        '
        'applySettings
        '
        Me.applySettings.Location = New System.Drawing.Point(173, 102)
        Me.applySettings.Name = "applySettings"
        Me.applySettings.Size = New System.Drawing.Size(88, 27)
        Me.applySettings.TabIndex = 3
        Me.applySettings.Text = "Apply Settings"
        Me.applySettings.UseVisualStyleBackColor = True
        '
        'captureData
        '
        Me.captureData.Location = New System.Drawing.Point(12, 150)
        Me.captureData.Name = "captureData"
        Me.captureData.Size = New System.Drawing.Size(75, 45)
        Me.captureData.TabIndex = 4
        Me.captureData.Text = "Capture Burst Word"
        Me.captureData.UseVisualStyleBackColor = True
        '
        'numBytes
        '
        Me.numBytes.Location = New System.Drawing.Point(66, 76)
        Me.numBytes.Name = "numBytes"
        Me.numBytes.Size = New System.Drawing.Size(195, 20)
        Me.numBytes.TabIndex = 5
        Me.numBytes.Text = "48"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CS Delay:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(6, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SCLK:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "# Bytes:"
        '
        'result
        '
        Me.result.AllowUserToAddRows = False
        Me.result.AllowUserToDeleteRows = False
        Me.result.AllowUserToResizeColumns = False
        Me.result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.result.Location = New System.Drawing.Point(12, 201)
        Me.result.Name = "result"
        Me.result.RowHeadersVisible = False
        Me.result.Size = New System.Drawing.Size(267, 258)
        Me.result.TabIndex = 9
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.csDelay)
        Me.GroupBox1.Controls.Add(Me.sclk)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.applySettings)
        Me.GroupBox1.Controls.Add(Me.numBytes)
        Me.GroupBox1.Controls.Add(Me.drActive)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(267, 135)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "SPI Settings"
        '
        'btn_StartStream
        '
        Me.btn_StartStream.Location = New System.Drawing.Point(93, 150)
        Me.btn_StartStream.Name = "btn_StartStream"
        Me.btn_StartStream.Size = New System.Drawing.Size(75, 45)
        Me.btn_StartStream.TabIndex = 11
        Me.btn_StartStream.Text = "Start Burst Stream"
        Me.btn_StartStream.UseVisualStyleBackColor = True
        '
        'numBurstWords
        '
        Me.numBurstWords.Location = New System.Drawing.Point(174, 175)
        Me.numBurstWords.Name = "numBurstWords"
        Me.numBurstWords.Size = New System.Drawing.Size(105, 20)
        Me.numBurstWords.TabIndex = 12
        Me.numBurstWords.Text = "1000"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(174, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "#Burst Words"
        '
        'BurstTestGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 471)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.numBurstWords)
        Me.Controls.Add(Me.btn_StartStream)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.result)
        Me.Controls.Add(Me.captureData)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable
        Me.MaximumSize = New System.Drawing.Size(308, 1500)
        Me.MinimumSize = New System.Drawing.Size(308, 300)
        Me.Name = "BurstTestGUI"
        Me.Text = "Burst Mode Test"
        CType(Me.result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents drActive As CheckBox
    Friend WithEvents csDelay As ComboBox
    Friend WithEvents sclk As TextBox
    Friend WithEvents applySettings As Button
    Friend WithEvents captureData As Button
    Friend WithEvents numBytes As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents result As DataGridView
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btn_StartStream As Button
    Friend WithEvents numBurstWords As TextBox
    Friend WithEvents Label4 As Label
End Class
