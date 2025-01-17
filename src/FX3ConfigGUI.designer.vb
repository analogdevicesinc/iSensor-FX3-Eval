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
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.DutInput = New System.Windows.Forms.ComboBox()
        Me.sensorInput = New System.Windows.Forms.ComboBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.regEndiannessInput = New System.Windows.Forms.ComboBox()
        Me.group_SPIConfig = New System.Windows.Forms.GroupBox()
        Me.group_DataReady = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.group_AppSettings = New System.Windows.Forms.GroupBox()
        Me.check_timestamps = New System.Windows.Forms.CheckBox()
        Me.check_Scaled = New System.Windows.Forms.CheckBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.group_SPIConfig.SuspendLayout()
        Me.group_DataReady.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.group_AppSettings.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 21)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Clock Frequency:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 127)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(101, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Chip Select Polarity:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Clock Phase:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 154)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Chip Select Control:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(9, 235)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(72, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Word Length:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(9, 181)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(117, 13)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Chip Select Lead Time:"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 73)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "Clock Polarity:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 208)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(111, 13)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Chip Select Lag Time:"
        '
        'frequencyInput
        '
        Me.frequencyInput.Location = New System.Drawing.Point(132, 18)
        Me.frequencyInput.Name = "frequencyInput"
        Me.frequencyInput.Size = New System.Drawing.Size(219, 20)
        Me.frequencyInput.TabIndex = 0
        '
        'chipSelectControlInput
        '
        Me.chipSelectControlInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chipSelectControlInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chipSelectControlInput.FormattingEnabled = True
        Me.chipSelectControlInput.Location = New System.Drawing.Point(132, 151)
        Me.chipSelectControlInput.Name = "chipSelectControlInput"
        Me.chipSelectControlInput.Size = New System.Drawing.Size(219, 21)
        Me.chipSelectControlInput.TabIndex = 4
        '
        'phaseInput
        '
        Me.phaseInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.phaseInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.phaseInput.FormattingEnabled = True
        Me.phaseInput.Location = New System.Drawing.Point(132, 97)
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
        Me.polarityInput.Location = New System.Drawing.Point(132, 70)
        Me.polarityInput.Name = "polarityInput"
        Me.polarityInput.Size = New System.Drawing.Size(219, 21)
        Me.polarityInput.TabIndex = 1
        '
        'chipSelectPolarityInput
        '
        Me.chipSelectPolarityInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.chipSelectPolarityInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.chipSelectPolarityInput.FormattingEnabled = True
        Me.chipSelectPolarityInput.Location = New System.Drawing.Point(132, 124)
        Me.chipSelectPolarityInput.Name = "chipSelectPolarityInput"
        Me.chipSelectPolarityInput.Size = New System.Drawing.Size(219, 21)
        Me.chipSelectPolarityInput.TabIndex = 3
        '
        'leadTimeInput
        '
        Me.leadTimeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.leadTimeInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.leadTimeInput.FormattingEnabled = True
        Me.leadTimeInput.Location = New System.Drawing.Point(132, 178)
        Me.leadTimeInput.Name = "leadTimeInput"
        Me.leadTimeInput.Size = New System.Drawing.Size(219, 21)
        Me.leadTimeInput.TabIndex = 5
        '
        'lagTimeInput
        '
        Me.lagTimeInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.lagTimeInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.lagTimeInput.FormattingEnabled = True
        Me.lagTimeInput.Location = New System.Drawing.Point(132, 205)
        Me.lagTimeInput.Name = "lagTimeInput"
        Me.lagTimeInput.Size = New System.Drawing.Size(219, 21)
        Me.lagTimeInput.TabIndex = 6
        '
        'wordLenInput
        '
        Me.wordLenInput.Location = New System.Drawing.Point(132, 232)
        Me.wordLenInput.Name = "wordLenInput"
        Me.wordLenInput.Size = New System.Drawing.Size(219, 20)
        Me.wordLenInput.TabIndex = 7
        '
        'SetConfig
        '
        Me.SetConfig.Location = New System.Drawing.Point(380, 14)
        Me.SetConfig.Name = "SetConfig"
        Me.SetConfig.Size = New System.Drawing.Size(75, 42)
        Me.SetConfig.TabIndex = 19
        Me.SetConfig.Text = "Set Config"
        Me.SetConfig.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(380, 66)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 17
        Me.Label9.Text = "Status:"
        '
        'StatusLabel
        '
        Me.StatusLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.StatusLabel.Location = New System.Drawing.Point(380, 83)
        Me.StatusLabel.Name = "StatusLabel"
        Me.StatusLabel.Size = New System.Drawing.Size(75, 18)
        Me.StatusLabel.TabIndex = 18
        Me.StatusLabel.Text = "Label10"
        Me.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 261)
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
        Me.lsbFirstInput.Location = New System.Drawing.Point(132, 258)
        Me.lsbFirstInput.Name = "lsbFirstInput"
        Me.lsbFirstInput.Size = New System.Drawing.Size(219, 21)
        Me.lsbFirstInput.TabIndex = 8
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 47)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(76, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "Stall Time (us):"
        '
        'stallTimeInput
        '
        Me.stallTimeInput.Location = New System.Drawing.Point(132, 44)
        Me.stallTimeInput.Name = "stallTimeInput"
        Me.stallTimeInput.Size = New System.Drawing.Size(219, 20)
        Me.stallTimeInput.TabIndex = 9
        '
        'dataReadyPinInput
        '
        Me.dataReadyPinInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataReadyPinInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.dataReadyPinInput.FormattingEnabled = True
        Me.dataReadyPinInput.Location = New System.Drawing.Point(132, 20)
        Me.dataReadyPinInput.Name = "dataReadyPinInput"
        Me.dataReadyPinInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyPinInput.TabIndex = 11
        '
        'dataReadyActiveInput
        '
        Me.dataReadyActiveInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataReadyActiveInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.dataReadyActiveInput.FormattingEnabled = True
        Me.dataReadyActiveInput.Location = New System.Drawing.Point(132, 47)
        Me.dataReadyActiveInput.Name = "dataReadyActiveInput"
        Me.dataReadyActiveInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyActiveInput.TabIndex = 12
        '
        'dataReadyPolarityInput
        '
        Me.dataReadyPolarityInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.dataReadyPolarityInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.dataReadyPolarityInput.FormattingEnabled = True
        Me.dataReadyPolarityInput.Location = New System.Drawing.Point(132, 74)
        Me.dataReadyPolarityInput.Name = "dataReadyPolarityInput"
        Me.dataReadyPolarityInput.Size = New System.Drawing.Size(219, 21)
        Me.dataReadyPolarityInput.TabIndex = 13
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(9, 23)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 13)
        Me.Label14.TabIndex = 30
        Me.Label14.Text = "Data Ready Pin:"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(9, 50)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(100, 13)
        Me.Label15.TabIndex = 31
        Me.Label15.Text = "Data Ready Active:"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(9, 77)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(104, 13)
        Me.Label16.TabIndex = 32
        Me.Label16.Text = "Data Ready Polarity:"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(6, 19)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(96, 13)
        Me.Label17.TabIndex = 33
        Me.Label17.Text = "Selected RegMap:"
        '
        'SelectedRegMap
        '
        Me.SelectedRegMap.Location = New System.Drawing.Point(129, 16)
        Me.SelectedRegMap.Name = "SelectedRegMap"
        Me.SelectedRegMap.Size = New System.Drawing.Size(219, 20)
        Me.SelectedRegMap.TabIndex = 17
        '
        'WatchdogTimeout
        '
        Me.WatchdogTimeout.Location = New System.Drawing.Point(129, 75)
        Me.WatchdogTimeout.Name = "WatchdogTimeout"
        Me.WatchdogTimeout.Size = New System.Drawing.Size(219, 20)
        Me.WatchdogTimeout.TabIndex = 15
        '
        'WatchdogEnable
        '
        Me.WatchdogEnable.AutoSize = True
        Me.WatchdogEnable.Location = New System.Drawing.Point(129, 55)
        Me.WatchdogEnable.Name = "WatchdogEnable"
        Me.WatchdogEnable.Size = New System.Drawing.Size(174, 17)
        Me.WatchdogEnable.TabIndex = 14
        Me.WatchdogEnable.Text = "Watchdog Functionality Enable"
        Me.WatchdogEnable.UseVisualStyleBackColor = True
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(7, 78)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(107, 13)
        Me.Label18.TabIndex = 38
        Me.Label18.Text = "Watchdog Period (s):"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(6, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(91, 13)
        Me.Label13.TabIndex = 39
        Me.Label13.Text = "Watchdog Reset:"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(6, 126)
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
        Me.DutVoltage.Location = New System.Drawing.Point(129, 123)
        Me.DutVoltage.Name = "DutVoltage"
        Me.DutVoltage.Size = New System.Drawing.Size(219, 21)
        Me.DutVoltage.TabIndex = 16
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(7, 106)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(111, 13)
        Me.Label20.TabIndex = 42
        Me.Label20.Text = "Set App Color Palette:"
        '
        'btn_edit_colors
        '
        Me.btn_edit_colors.Location = New System.Drawing.Point(129, 101)
        Me.btn_edit_colors.Name = "btn_edit_colors"
        Me.btn_edit_colors.Size = New System.Drawing.Size(219, 22)
        Me.btn_edit_colors.TabIndex = 18
        Me.btn_edit_colors.Text = "Edit Colors"
        Me.btn_edit_colors.UseVisualStyleBackColor = True
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(6, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(60, 13)
        Me.Label21.TabIndex = 46
        Me.Label21.Text = "DUT Type:"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(6, 45)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 45
        Me.Label22.Text = "Sensor Type:"
        '
        'DutInput
        '
        Me.DutInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.DutInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.DutInput.FormattingEnabled = True
        Me.DutInput.Location = New System.Drawing.Point(129, 69)
        Me.DutInput.Name = "DutInput"
        Me.DutInput.Size = New System.Drawing.Size(219, 21)
        Me.DutInput.TabIndex = 44
        '
        'sensorInput
        '
        Me.sensorInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.sensorInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.sensorInput.FormattingEnabled = True
        Me.sensorInput.Location = New System.Drawing.Point(129, 42)
        Me.sensorInput.Name = "sensorInput"
        Me.sensorInput.Size = New System.Drawing.Size(219, 21)
        Me.sensorInput.TabIndex = 43
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(6, 99)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 13)
        Me.Label23.TabIndex = 48
        Me.Label23.Text = "Reg Endianness:"
        '
        'regEndiannessInput
        '
        Me.regEndiannessInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.regEndiannessInput.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.regEndiannessInput.FormattingEnabled = True
        Me.regEndiannessInput.Location = New System.Drawing.Point(129, 96)
        Me.regEndiannessInput.Name = "regEndiannessInput"
        Me.regEndiannessInput.Size = New System.Drawing.Size(219, 21)
        Me.regEndiannessInput.TabIndex = 47
        '
        'group_SPIConfig
        '
        Me.group_SPIConfig.Controls.Add(Me.frequencyInput)
        Me.group_SPIConfig.Controls.Add(Me.Label1)
        Me.group_SPIConfig.Controls.Add(Me.Label11)
        Me.group_SPIConfig.Controls.Add(Me.stallTimeInput)
        Me.group_SPIConfig.Controls.Add(Me.polarityInput)
        Me.group_SPIConfig.Controls.Add(Me.Label2)
        Me.group_SPIConfig.Controls.Add(Me.Label3)
        Me.group_SPIConfig.Controls.Add(Me.Label4)
        Me.group_SPIConfig.Controls.Add(Me.Label5)
        Me.group_SPIConfig.Controls.Add(Me.Label6)
        Me.group_SPIConfig.Controls.Add(Me.Label7)
        Me.group_SPIConfig.Controls.Add(Me.Label8)
        Me.group_SPIConfig.Controls.Add(Me.chipSelectControlInput)
        Me.group_SPIConfig.Controls.Add(Me.phaseInput)
        Me.group_SPIConfig.Controls.Add(Me.chipSelectPolarityInput)
        Me.group_SPIConfig.Controls.Add(Me.leadTimeInput)
        Me.group_SPIConfig.Controls.Add(Me.lagTimeInput)
        Me.group_SPIConfig.Controls.Add(Me.wordLenInput)
        Me.group_SPIConfig.Controls.Add(Me.Label10)
        Me.group_SPIConfig.Controls.Add(Me.lsbFirstInput)
        Me.group_SPIConfig.Location = New System.Drawing.Point(12, 8)
        Me.group_SPIConfig.Name = "group_SPIConfig"
        Me.group_SPIConfig.Size = New System.Drawing.Size(359, 291)
        Me.group_SPIConfig.TabIndex = 49
        Me.group_SPIConfig.TabStop = False
        Me.group_SPIConfig.Text = "SPI Configuration"
        '
        'group_DataReady
        '
        Me.group_DataReady.Controls.Add(Me.Label14)
        Me.group_DataReady.Controls.Add(Me.dataReadyPinInput)
        Me.group_DataReady.Controls.Add(Me.dataReadyActiveInput)
        Me.group_DataReady.Controls.Add(Me.dataReadyPolarityInput)
        Me.group_DataReady.Controls.Add(Me.Label15)
        Me.group_DataReady.Controls.Add(Me.Label16)
        Me.group_DataReady.Location = New System.Drawing.Point(12, 305)
        Me.group_DataReady.Name = "group_DataReady"
        Me.group_DataReady.Size = New System.Drawing.Size(359, 106)
        Me.group_DataReady.TabIndex = 50
        Me.group_DataReady.TabStop = False
        Me.group_DataReady.Text = "Data Ready Configuration"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.SelectedRegMap)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.regEndiannessInput)
        Me.GroupBox1.Controls.Add(Me.DutVoltage)
        Me.GroupBox1.Controls.Add(Me.sensorInput)
        Me.GroupBox1.Controls.Add(Me.DutInput)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 417)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(359, 155)
        Me.GroupBox1.TabIndex = 50
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "IMU Selection"
        '
        'group_AppSettings
        '
        Me.group_AppSettings.Controls.Add(Me.check_timestamps)
        Me.group_AppSettings.Controls.Add(Me.check_Scaled)
        Me.group_AppSettings.Controls.Add(Me.Label12)
        Me.group_AppSettings.Controls.Add(Me.btn_edit_colors)
        Me.group_AppSettings.Controls.Add(Me.Label20)
        Me.group_AppSettings.Controls.Add(Me.Label18)
        Me.group_AppSettings.Controls.Add(Me.Label13)
        Me.group_AppSettings.Controls.Add(Me.WatchdogTimeout)
        Me.group_AppSettings.Controls.Add(Me.WatchdogEnable)
        Me.group_AppSettings.Location = New System.Drawing.Point(12, 578)
        Me.group_AppSettings.Name = "group_AppSettings"
        Me.group_AppSettings.Size = New System.Drawing.Size(359, 131)
        Me.group_AppSettings.TabIndex = 51
        Me.group_AppSettings.TabStop = False
        Me.group_AppSettings.Text = "App Settings"
        '
        'check_timestamps
        '
        Me.check_timestamps.AutoSize = True
        Me.check_timestamps.Location = New System.Drawing.Point(129, 35)
        Me.check_timestamps.Name = "check_timestamps"
        Me.check_timestamps.Size = New System.Drawing.Size(141, 17)
        Me.check_timestamps.TabIndex = 45
        Me.check_timestamps.Text = "Log Sample Timestamps"
        Me.check_timestamps.UseVisualStyleBackColor = True
        '
        'check_Scaled
        '
        Me.check_Scaled.AutoSize = True
        Me.check_Scaled.Location = New System.Drawing.Point(129, 15)
        Me.check_Scaled.Name = "check_Scaled"
        Me.check_Scaled.Size = New System.Drawing.Size(142, 17)
        Me.check_Scaled.TabIndex = 44
        Me.check_Scaled.Text = "Log Scaled Sensor Data"
        Me.check_Scaled.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(112, 13)
        Me.Label12.TabIndex = 43
        Me.Label12.Text = "Datalog Configuration:"
        '
        'FX3ConfigGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(466, 717)
        Me.Controls.Add(Me.group_DataReady)
        Me.Controls.Add(Me.group_AppSettings)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.group_SPIConfig)
        Me.Controls.Add(Me.StatusLabel)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.SetConfig)
        Me.Name = "FX3ConfigGUI"
        Me.Text = "iSensor-FX3-Eval Configuration"
        Me.group_SPIConfig.ResumeLayout(False)
        Me.group_SPIConfig.PerformLayout()
        Me.group_DataReady.ResumeLayout(False)
        Me.group_DataReady.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.group_AppSettings.ResumeLayout(False)
        Me.group_AppSettings.PerformLayout()
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
    Friend WithEvents Label21 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents DutInput As ComboBox
    Friend WithEvents sensorInput As ComboBox
    Friend WithEvents Label23 As Label
    Friend WithEvents regEndiannessInput As ComboBox
    Friend WithEvents group_SPIConfig As GroupBox
    Friend WithEvents group_DataReady As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents group_AppSettings As GroupBox
    Friend WithEvents check_timestamps As CheckBox
    Friend WithEvents check_Scaled As CheckBox
    Friend WithEvents Label12 As Label
End Class
