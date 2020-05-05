<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FX3ConfigGUI

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
        Me.StallCyclesInput = New System.Windows.Forms.TextBox()
        Me.dataReadyPinInput = New System.Windows.Forms.ComboBox()
        Me.dataReadyActiveInput = New System.Windows.Forms.ComboBox()
        Me.dataReadyPolarityInput = New System.Windows.Forms.ComboBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.SelectedRegMap = New System.Windows.Forms.TextBox()
        Me.WatchdogTimeout = New System.Windows.Forms.TextBox()
        Me.WatchdogEnable = New System.Windows.Forms.CheckBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.DutVoltage = New System.Windows.Forms.ComboBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.btn_edit_colors = New System.Windows.Forms.Button()
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
        Me.frequencyInput.TabIndex = 0
        '
        'chipSelectControlInput
        '
        Me.chipSelectControlInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chipSelectControlInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chipSelectControlInput.FormattingEnabled = True
        Me.chipSelectControlInput.Location = New System.Drawing.Point(135, 121)
        Me.chipSelectControlInput.Name = "chipSelectControlInput"
        Me.chipSelectControlInput.Size = New System.Drawing.Size(219, 21)
        Me.chipSelectControlInput.TabIndex = 4
        '
        'phaseInput
        '
        Me.phaseInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.phaseInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.phaseInput.FormattingEnabled = True
        Me.phaseInput.Location = New System.Drawing.Point(135, 67)
        Me.phaseInput.Name = "phaseInput"
        Me.phaseInput.Size = New System.Drawing.Size(219, 21)
        Me.phaseInput.TabIndex = 2
        '
        'polarityInput
        '
        Me.polarityInput.BackColor = System.Drawing.SystemColors.Window
        Me.polarityInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.polarityInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.polarityInput.FormattingEnabled = True
        Me.polarityInput.Location = New System.Drawing.Point(135, 40)
        Me.polarityInput.Name = "polarityInput"
        Me.polarityInput.Size = New System.Drawing.Size(219, 21)
        Me.polarityInput.TabIndex = 1
        '
        'chipSelectPolarityInput
        '
        Me.chipSelectPolarityInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chipSelectPolarityInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chipSelectPolarityInput.FormattingEnabled = True
        Me.chipSelectPolarityInput.Location = New System.Drawing.Point(135, 94)
        Me.chipSelectPolarityInput.Name = "chipSelectPolarityInput"
        Me.chipSelectPolarityInput.Size = New System.Drawing.Size(219, 21)
        Me.chipSelectPolarityInput.TabIndex = 3
        '
        'leadTimeInput
        '
        Me.leadTimeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.leadTimeInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.leadTimeInput.FormattingEnabled = True
        Me.leadTimeInput.Location = New System.Drawing.Point(135, 148)
        Me.leadTimeInput.Name = "leadTimeInput"
        Me.leadTimeInput.Size = New System.Drawing.Size(219, 21)
        Me.leadTimeInput.TabIndex = 5
        '
        'lagTimeInput
        '
        Me.lagTimeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lagTimeInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lagTimeInput.FormattingEnabled = True
        Me.lagTimeInput.Location = New System.Drawing.Point(135, 175)
        Me.lagTimeInput.Name = "lagTimeInput"
        Me.lagTimeInput.Size = New System.Drawing.Size(219, 21)
        Me.lagTimeInput.TabIndex = 6
        '
        'wordLenInput
        '
        Me.wordLenInput.Location = New System.Drawing.Point(135, 202)
        Me.wordLenInput.Name = "wordLenInput"
        Me.wordLenInput.Size = New System.Drawing.Size(219, 20)
        Me.wordLenInput.TabIndex = 7
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
        Me.StatusLabel.Size = New System.Drawing.Size(75, 18)
        Me.StatusLabel.TabIndex = 18
        Me.StatusLabel.Text = "Label10"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.lsbFirstInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lsbFirstInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lsbFirstInput.FormattingEnabled = True
        Me.lsbFirstInput.Location = New System.Drawing.Point(135, 228)
        Me.lsbFirstInput.Name = "lsbFirstInput"
        Me.lsbFirstInput.Size = New System.Drawing.Size(219, 21)
        Me.lsbFirstInput.TabIndex = 8
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
        Me.stallTimeInput.TabIndex = 9
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 284)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 13)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Stall Cycles:"
        '
        'StallCyclesInput
        '
        Me.StallCyclesInput.Location = New System.Drawing.Point(135, 281)
        Me.StallCyclesInput.Name = "StallCyclesInput"
        Me.StallCyclesInput.Size = New System.Drawing.Size(219, 20)
        Me.StallCyclesInput.TabIndex = 10
        '
        'dataReadyPinInput
        '
        Me.dataReadyPinInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataReadyPinInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.dataReadyPinInput.FormattingEnabled = True
        Me.dataReadyPinInput.Location = New System.Drawing.Point(135, 307)
        Me.dataReadyPinInput.Name = "dataReadyPinInput"
        Me.dataReadyPinInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyPinInput.TabIndex = 11
        '
        'dataReadyActiveInput
        '
        Me.dataReadyActiveInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataReadyActiveInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.dataReadyActiveInput.FormattingEnabled = True
        Me.dataReadyActiveInput.Location = New System.Drawing.Point(135, 334)
        Me.dataReadyActiveInput.Name = "dataReadyActiveInput"
        Me.dataReadyActiveInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyActiveInput.TabIndex = 12
        '
        'dataReadyPolarityInput
        '
        Me.dataReadyPolarityInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataReadyPolarityInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.dataReadyPolarityInput.FormattingEnabled = True
        Me.dataReadyPolarityInput.Location = New System.Drawing.Point(135, 361)
        Me.dataReadyPolarityInput.Name = "dataReadyPolarityInput"
        Me.dataReadyPolarityInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyPolarityInput.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 310)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Data Ready Pin:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 337)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Data Ready Active:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 364)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Data Ready Polarity:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(12, 467)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Selected RegMap:"
        '
        'SelectedRegMap
        '
        Me.SelectedRegMap.Location = New System.Drawing.Point(135, 464)
        Me.SelectedRegMap.Name = "SelectedRegMap"
        Me.SelectedRegMap.Size = New System.Drawing.Size(219, 20)
        Me.SelectedRegMap.TabIndex = 14
        '
        'WatchdogTimeout
        '
        Me.WatchdogTimeout.Location = New System.Drawing.Point(135, 411)
        Me.WatchdogTimeout.Name = "WatchdogTimeout"
        Me.WatchdogTimeout.Size = New System.Drawing.Size(219, 20)
        Me.WatchdogTimeout.TabIndex = 36
        '
        'WatchdogEnable
        '
        Me.WatchdogEnable.AutoSize = True
        Me.WatchdogEnable.Location = New System.Drawing.Point(135, 388)
        Me.WatchdogEnable.Name = "WatchdogEnable"
        Me.WatchdogEnable.Size = New System.Drawing.Size(174, 17)
        Me.WatchdogEnable.TabIndex = 37
        Me.WatchdogEnable.Text = "Watchdog Functionality Enable"
        Me.WatchdogEnable.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 414)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Watchdog Period (s):"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 389)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Watchdog Reset:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(12, 440)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 13)
        Me.Label19.TabIndex = 41
        Me.Label19.Text = "DUT Voltage:"
        '
        'DutVoltage
        '
        Me.DutVoltage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DutVoltage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DutVoltage.FormattingEnabled = True
        Me.DutVoltage.Location = New System.Drawing.Point(135, 437)
        Me.DutVoltage.Name = "DutVoltage"
        Me.DutVoltage.Size = New System.Drawing.Size(219, 21)
        Me.DutVoltage.TabIndex = 40
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(12, 495)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(89, 13)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Set Color Palette:"
        '
        'btn_edit_colors
        '
        Me.btn_edit_colors.Location = New System.Drawing.Point(135, 490)
        Me.btn_edit_colors.Name = "btn_edit_colors"
        Me.btn_edit_colors.Size = New System.Drawing.Size(219, 22)
        Me.btn_edit_colors.TabIndex = 43
        Me.btn_edit_colors.Text = "Edit Colors"
        Me.btn_edit_colors.UseVisualStyleBackColor = True
        '
        'FX3ConfigGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(444, 520)
        Me.Controls.Add(Me.btn_edit_colors)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.DutVoltage)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.WatchdogEnable)
        Me.Controls.Add(Me.WatchdogTimeout)
        Me.Controls.Add(Me.SelectedRegMap)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.dataReadyPolarityInput)
        Me.Controls.Add(Me.dataReadyActiveInput)
        Me.Controls.Add(Me.dataReadyPinInput)
        Me.Controls.Add(Me.StallCyclesInput)
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
        Me.Name = "FX3ConfigGUI"
        Me.Text = "FX3 Configuration"
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
    Friend WithEvents StallCyclesInput As TextBox
    Friend WithEvents dataReadyPinInput As ComboBox
    Friend WithEvents dataReadyActiveInput As ComboBox
    Friend WithEvents dataReadyPolarityInput As ComboBox
    Friend WithEvents Label14 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents SelectedRegMap As TextBox
    Friend WithEvents WatchdogTimeout As TextBox
    Friend WithEvents WatchdogEnable As CheckBox
    Friend WithEvents Label18 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents DutVoltage As ComboBox
    Friend WithEvents Label20 As Label
    Friend WithEvents btn_edit_colors As Button
End Class
