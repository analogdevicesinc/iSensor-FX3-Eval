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
        Me.num32words = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.result = New System.Windows.Forms.DataGridView()
        CType(Me.result, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'drActive
        '
        Me.drActive.AutoSize = True
        Me.drActive.Location = New System.Drawing.Point(99, 12)
        Me.drActive.Name = "drActive"
        Me.drActive.Size = New System.Drawing.Size(75, 17)
        Me.drActive.TabIndex = 0
        Me.drActive.Text = "DR Active"
        Me.drActive.UseVisualStyleBackColor = True
        '
        'csDelay
        '
        Me.csDelay.FormattingEnabled = True
        Me.csDelay.Location = New System.Drawing.Point(99, 35)
        Me.csDelay.Name = "csDelay"
        Me.csDelay.Size = New System.Drawing.Size(216, 21)
        Me.csDelay.TabIndex = 1
        '
        'sclk
        '
        Me.sclk.Location = New System.Drawing.Point(99, 62)
        Me.sclk.Name = "sclk"
        Me.sclk.Size = New System.Drawing.Size(216, 20)
        Me.sclk.TabIndex = 2
        '
        'applySettings
        '
        Me.applySettings.Location = New System.Drawing.Point(12, 114)
        Me.applySettings.Name = "applySettings"
        Me.applySettings.Size = New System.Drawing.Size(75, 45)
        Me.applySettings.TabIndex = 3
        Me.applySettings.Text = "Apply Settings"
        Me.applySettings.UseVisualStyleBackColor = True
        '
        'captureData
        '
        Me.captureData.Location = New System.Drawing.Point(240, 114)
        Me.captureData.Name = "captureData"
        Me.captureData.Size = New System.Drawing.Size(75, 45)
        Me.captureData.TabIndex = 4
        Me.captureData.Text = "Capture Data"
        Me.captureData.UseVisualStyleBackColor = True
        '
        'num32words
        '
        Me.num32words.Location = New System.Drawing.Point(99, 88)
        Me.num32words.Name = "num32words"
        Me.num32words.Size = New System.Drawing.Size(216, 20)
        Me.num32words.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(54, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "CS Delay:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 65)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 13)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "SCLK:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 91)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "# 32-Bit Words:"
        '
        'result
        '
        Me.result.AllowUserToAddRows = False
        Me.result.AllowUserToDeleteRows = False
        Me.result.AllowUserToResizeColumns = False
        Me.result.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.result.Location = New System.Drawing.Point(12, 165)
        Me.result.Name = "result"
        Me.result.RowHeadersVisible = False
        Me.result.Size = New System.Drawing.Size(303, 293)
        Me.result.TabIndex = 9
        '
        'BurstTestGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(328, 470)
        Me.Controls.Add(Me.result)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.num32words)
        Me.Controls.Add(Me.captureData)
        Me.Controls.Add(Me.applySettings)
        Me.Controls.Add(Me.sclk)
        Me.Controls.Add(Me.csDelay)
        Me.Controls.Add(Me.drActive)
        Me.Name = "BurstTestGUI"
        Me.Text = "Burst Mode Test"
        CType(Me.result, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents drActive As CheckBox
    Friend WithEvents csDelay As ComboBox
    Friend WithEvents sclk As TextBox
    Friend WithEvents applySettings As Button
    Friend WithEvents captureData As Button
    Friend WithEvents num32words As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents result As DataGridView
End Class
