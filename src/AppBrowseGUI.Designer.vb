<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AppBrowseGUI

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
        Me.btn_BurstTest = New System.Windows.Forms.Button()
        Me.btn_BitBangSpi = New System.Windows.Forms.Button()
        Me.btn_ADXL375 = New System.Windows.Forms.Button()
        Me.btn_pulseMeasure = New System.Windows.Forms.Button()
        Me.btn_resistorConfig = New System.Windows.Forms.Button()
        Me.btn_binFile = New System.Windows.Forms.Button()
        Me.btn_checkError = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btn_BurstTest
        '
        Me.btn_BurstTest.Location = New System.Drawing.Point(174, 12)
        Me.btn_BurstTest.Name = "btn_BurstTest"
        Me.btn_BurstTest.Size = New System.Drawing.Size(75, 64)
        Me.btn_BurstTest.TabIndex = 2
        Me.btn_BurstTest.Text = "Burst Mode Test"
        Me.btn_BurstTest.UseVisualStyleBackColor = True
        '
        'btn_BitBangSpi
        '
        Me.btn_BitBangSpi.Location = New System.Drawing.Point(93, 12)
        Me.btn_BitBangSpi.Name = "btn_BitBangSpi"
        Me.btn_BitBangSpi.Size = New System.Drawing.Size(75, 64)
        Me.btn_BitBangSpi.TabIndex = 1
        Me.btn_BitBangSpi.Text = "Bit Bang SPI Interface"
        Me.btn_BitBangSpi.UseVisualStyleBackColor = True
        '
        'btn_ADXL375
        '
        Me.btn_ADXL375.Location = New System.Drawing.Point(255, 12)
        Me.btn_ADXL375.Name = "btn_ADXL375"
        Me.btn_ADXL375.Size = New System.Drawing.Size(75, 64)
        Me.btn_ADXL375.TabIndex = 3
        Me.btn_ADXL375.Text = "ADXL375 Data Capture"
        Me.btn_ADXL375.UseVisualStyleBackColor = True
        '
        'btn_pulseMeasure
        '
        Me.btn_pulseMeasure.Location = New System.Drawing.Point(12, 12)
        Me.btn_pulseMeasure.Name = "btn_pulseMeasure"
        Me.btn_pulseMeasure.Size = New System.Drawing.Size(75, 64)
        Me.btn_pulseMeasure.TabIndex = 0
        Me.btn_pulseMeasure.Text = "Measure Signal Pulse Width"
        Me.btn_pulseMeasure.UseVisualStyleBackColor = True
        '
        'btn_resistorConfig
        '
        Me.btn_resistorConfig.Location = New System.Drawing.Point(12, 82)
        Me.btn_resistorConfig.Name = "btn_resistorConfig"
        Me.btn_resistorConfig.Size = New System.Drawing.Size(75, 64)
        Me.btn_resistorConfig.TabIndex = 4
        Me.btn_resistorConfig.Text = "Input Pin Resistor Config"
        Me.btn_resistorConfig.UseVisualStyleBackColor = True
        '
        'btn_binFile
        '
        Me.btn_binFile.Location = New System.Drawing.Point(93, 82)
        Me.btn_binFile.Name = "btn_binFile"
        Me.btn_binFile.Size = New System.Drawing.Size(75, 64)
        Me.btn_binFile.TabIndex = 5
        Me.btn_binFile.Text = "Binary File Writer"
        Me.btn_binFile.UseVisualStyleBackColor = True
        '
        'btn_checkError
        '
        Me.btn_checkError.Location = New System.Drawing.Point(174, 82)
        Me.btn_checkError.Name = "btn_checkError"
        Me.btn_checkError.Size = New System.Drawing.Size(75, 64)
        Me.btn_checkError.TabIndex = 6
        Me.btn_checkError.Text = "Check Error Log"
        Me.btn_checkError.UseVisualStyleBackColor = True
        '
        'AppBrowseGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(344, 161)
        Me.Controls.Add(Me.btn_checkError)
        Me.Controls.Add(Me.btn_binFile)
        Me.Controls.Add(Me.btn_resistorConfig)
        Me.Controls.Add(Me.btn_pulseMeasure)
        Me.Controls.Add(Me.btn_ADXL375)
        Me.Controls.Add(Me.btn_BitBangSpi)
        Me.Controls.Add(Me.btn_BurstTest)
        Me.MaximumSize = New System.Drawing.Size(360, 200)
        Me.MinimumSize = New System.Drawing.Size(360, 200)
        Me.Name = "AppBrowseGUI"
        Me.Text = "App Browser"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents btn_BurstTest As Button
    Friend WithEvents btn_BitBangSpi As Button
    Friend WithEvents btn_ADXL375 As Button
    Friend WithEvents btn_pulseMeasure As Button
    Friend WithEvents btn_resistorConfig As Button
    Friend WithEvents btn_binFile As Button
    Friend WithEvents btn_checkError As Button
End Class
