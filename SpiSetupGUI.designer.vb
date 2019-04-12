<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SpiSetupGUI
    Inherits System.Windows.Forms.Form

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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.frequencyInput = New System.Windows.Forms.TextBox()
        Me.chipSelectControlInput = New System.Windows.Forms.ComboBox()
        Me.phaseInput = New System.Windows.Forms.ComboBox()
        Me.polarityInput = New System.Windows.Forms.ComboBox()
        Me.chipSelectPolarityInput = New System.Windows.Forms.ComboBox()
        Me.leadTimeInput = New System.Windows.Forms.ComboBox()
        Me.lagTimeInput = New System.Windows.Forms.ComboBox()
        Me.wordLenInput = New System.Windows.Forms.TextBox()
        Me.SetConfig = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.StatusLabel = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.lsbFirstInput = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.stallTimeInput = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.StallCyclesInput = New System.Windows.Forms.TextBox()
        Me.DutInput = New System.Windows.Forms.ComboBox()
        Me.dataReadyPinInput = New System.Windows.Forms.ComboBox()
        Me.dataReadyActiveInput = New System.Windows.Forms.ComboBox()
        Me.dataReadyPolarityInput = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.TimerTickMultiplierDisplay = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clock Frequency:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Chip Select Polarity:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 70)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Clock Phase:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 124)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Chip Select Control:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 205)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Word Length:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 151)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Chip Select Lead Time:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 43)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Clock Polarity:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 178)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Chip Select Lag Time:"
        '
        'frequencyInput
        '
        Me.frequencyInput.Location = New System.Drawing.Point(135, 13)
        Me.frequencyInput.Name = "frequencyInput"
        Me.frequencyInput.Size = New System.Drawing.Size(219, 20)
        Me.frequencyInput.TabIndex = 8
        '
        'chipSelectControlInput
        '
        Me.chipSelectControlInput.FormattingEnabled = True
        Me.chipSelectControlInput.Location = New System.Drawing.Point(135, 121)
        Me.chipSelectControlInput.Name = "chipSelectControlInput"
        Me.chipSelectControlInput.Size = New System.Drawing.Size(219, 21)
        Me.chipSelectControlInput.TabIndex = 9
        '
        'phaseInput
        '
        Me.phaseInput.FormattingEnabled = True
        Me.phaseInput.Location = New System.Drawing.Point(135, 67)
        Me.phaseInput.Name = "phaseInput"
        Me.phaseInput.Size = New System.Drawing.Size(219, 21)
        Me.phaseInput.TabIndex = 10
        '
        'polarityInput
        '
        Me.polarityInput.FormattingEnabled = True
        Me.polarityInput.Location = New System.Drawing.Point(135, 40)
        Me.polarityInput.Name = "polarityInput"
        Me.polarityInput.Size = New System.Drawing.Size(219, 21)
        Me.polarityInput.TabIndex = 11
        '
        'chipSelectPolarityInput
        '
        Me.chipSelectPolarityInput.FormattingEnabled = True
        Me.chipSelectPolarityInput.Location = New System.Drawing.Point(135, 94)
        Me.chipSelectPolarityInput.Name = "chipSelectPolarityInput"
        Me.chipSelectPolarityInput.Size = New System.Drawing.Size(219, 21)
        Me.chipSelectPolarityInput.TabIndex = 12
        '
        'leadTimeInput
        '
        Me.leadTimeInput.FormattingEnabled = True
        Me.leadTimeInput.Location = New System.Drawing.Point(135, 148)
        Me.leadTimeInput.Name = "leadTimeInput"
        Me.leadTimeInput.Size = New System.Drawing.Size(219, 21)
        Me.leadTimeInput.TabIndex = 13
        '
        'lagTimeInput
        '
        Me.lagTimeInput.FormattingEnabled = True
        Me.lagTimeInput.Location = New System.Drawing.Point(135, 175)
        Me.lagTimeInput.Name = "lagTimeInput"
        Me.lagTimeInput.Size = New System.Drawing.Size(219, 21)
        Me.lagTimeInput.TabIndex = 14
        '
        'wordLenInput
        '
        Me.wordLenInput.Location = New System.Drawing.Point(135, 202)
        Me.wordLenInput.Name = "wordLenInput"
        Me.wordLenInput.Size = New System.Drawing.Size(219, 20)
        Me.wordLenInput.TabIndex = 15
        '
        'SetConfig
        '
        Me.SetConfig.Location = New System.Drawing.Point(360, 12)
        Me.SetConfig.Name = "SetConfig"
        Me.SetConfig.Size = New System.Drawing.Size(75, 42)
        Me.SetConfig.TabIndex = 16
        Me.SetConfig.Text = "Set Config"
        Me.SetConfig.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(360, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Status:"
        '
        'StatusLabel
        '
        Me.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusLabel.Location = New System.Drawing.Point(360, 83)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(75, 16)
        Me.StatusLabel.TabIndex = 18
        Me.StatusLabel.Text = "Label10"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 231)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(52, 13)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "LSB First:"
        '
        'lsbFirstInput
        '
        Me.lsbFirstInput.FormattingEnabled = True
        Me.lsbFirstInput.Location = New System.Drawing.Point(135, 228)
        Me.lsbFirstInput.Name = "lsbFirstInput"
        Me.lsbFirstInput.Size = New System.Drawing.Size(219, 21)
        Me.lsbFirstInput.TabIndex = 20
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 258)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Stall Time (us):"
        '
        'stallTimeInput
        '
        Me.stallTimeInput.Location = New System.Drawing.Point(135, 255)
        Me.stallTimeInput.Name = "stallTimeInput"
        Me.stallTimeInput.Size = New System.Drawing.Size(219, 20)
        Me.stallTimeInput.TabIndex = 22
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 284)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(61, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Stall Cycles"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 391)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(57, 13)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "DUT Type"
        '
        'StallCyclesInput
        '
        Me.StallCyclesInput.Location = New System.Drawing.Point(135, 281)
        Me.StallCyclesInput.Name = "StallCyclesInput"
        Me.StallCyclesInput.Size = New System.Drawing.Size(219, 20)
        Me.StallCyclesInput.TabIndex = 25
        '
        'DutInput
        '
        Me.DutInput.FormattingEnabled = True
        Me.DutInput.Location = New System.Drawing.Point(135, 388)
        Me.DutInput.Name = "DutInput"
        Me.DutInput.Size = New System.Drawing.Size(219, 21)
        Me.DutInput.TabIndex = 26
        '
        'dataReadyPinInput
        '
        Me.dataReadyPinInput.FormattingEnabled = True
        Me.dataReadyPinInput.Location = New System.Drawing.Point(135, 307)
        Me.dataReadyPinInput.Name = "dataReadyPinInput"
        Me.dataReadyPinInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyPinInput.TabIndex = 27
        '
        'dataReadyActiveInput
        '
        Me.dataReadyActiveInput.FormattingEnabled = True
        Me.dataReadyActiveInput.Location = New System.Drawing.Point(135, 334)
        Me.dataReadyActiveInput.Name = "dataReadyActiveInput"
        Me.dataReadyActiveInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyActiveInput.TabIndex = 28
        '
        'dataReadyPolarityInput
        '
        Me.dataReadyPolarityInput.FormattingEnabled = True
        Me.dataReadyPolarityInput.Location = New System.Drawing.Point(135, 361)
        Me.dataReadyPolarityInput.Name = "dataReadyPolarityInput"
        Me.dataReadyPolarityInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyPolarityInput.TabIndex = 29
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 310)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(82, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Data Ready Pin"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 337)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(97, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Data Ready Active"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 364)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(101, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Data Ready Polarity"
        '
        'TimerTickMultiplierDisplay
        '
        Me.TimerTickMultiplierDisplay.Location = New System.Drawing.Point(135, 415)
        Me.TimerTickMultiplierDisplay.Name = "TimerTickMultiplierDisplay"
        Me.TimerTickMultiplierDisplay.Size = New System.Drawing.Size(219, 20)
        Me.TimerTickMultiplierDisplay.TabIndex = 34
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 418)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(88, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Timer Tick to ms:"
        '
        'SpiSetupGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(441, 450)
        Me.Controls.Add(Me.TimerTickMultiplierDisplay)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dataReadyPolarityInput)
        Me.Controls.Add(Me.dataReadyActiveInput)
        Me.Controls.Add(Me.dataReadyPinInput)
        Me.Controls.Add(Me.DutInput)
        Me.Controls.Add(Me.StallCyclesInput)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.stallTimeInput)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lsbFirstInput)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SetConfig)
        Me.Controls.Add(Me.wordLenInput)
        Me.Controls.Add(Me.lagTimeInput)
        Me.Controls.Add(Me.leadTimeInput)
        Me.Controls.Add(Me.chipSelectPolarityInput)
        Me.Controls.Add(Me.polarityInput)
        Me.Controls.Add(Me.phaseInput)
        Me.Controls.Add(Me.chipSelectControlInput)
        Me.Controls.Add(Me.frequencyInput)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "SpiSetupGUI"
        Me.Text = "SpiSetupGUI"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents frequencyInput As TextBox
    Friend WithEvents chipSelectControlInput As ComboBox
    Friend WithEvents phaseInput As ComboBox
    Friend WithEvents polarityInput As ComboBox
    Friend WithEvents chipSelectPolarityInput As ComboBox
    Friend WithEvents leadTimeInput As ComboBox
    Friend WithEvents lagTimeInput As ComboBox
    Friend WithEvents wordLenInput As TextBox
    Friend WithEvents SetConfig As Button
    Friend WithEvents Label9 As Label
    Friend WithEvents StatusLabel As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents lsbFirstInput As ComboBox
    Friend WithEvents Label11 As Label
    Friend WithEvents stallTimeInput As TextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents StallCyclesInput As TextBox
    Friend WithEvents DutInput As ComboBox
    Friend WithEvents dataReadyPinInput As ComboBox
    Friend WithEvents dataReadyActiveInput As ComboBox
    Friend WithEvents dataReadyPolarityInput As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents TimerTickMultiplierDisplay As TextBox
    Friend WithEvents Label17 As Label
End Class
