<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TopGUI
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TopGUI))
        Me.text_FX3Status = New System.Windows.Forms.Label()
        Me.label_FX3Status = New System.Windows.Forms.Label()
        Me.btn_Connect = New System.Windows.Forms.Button()
        Me.text_DUTStatus = New System.Windows.Forms.Label()
        Me.label_DUTStatus = New System.Windows.Forms.Label()
        Me.btn_ResetDUT = New System.Windows.Forms.Button()
        Me.btn_SelectDUT = New System.Windows.Forms.Button()
        Me.text_DUTType = New System.Windows.Forms.Label()
        Me.label_DUTType = New System.Windows.Forms.Label()
        Me.btn_RealTime = New System.Windows.Forms.Button()
        Me.btn_BulkRegRead = New System.Windows.Forms.Button()
        Me.btn_CheckDUTConnection = New System.Windows.Forms.Button()
        Me.btn_FX3Config = New System.Windows.Forms.Button()
        Me.btn_APIInfo = New System.Windows.Forms.Button()
        Me.btn_PWMSetup = New System.Windows.Forms.Button()
        Me.btn_plotFFT = New System.Windows.Forms.Button()
        Me.btn_PinAccess = New System.Windows.Forms.Button()
        Me.label_apiVersion = New System.Windows.Forms.Label()
        Me.btn_plotData = New System.Windows.Forms.Button()
        Me.regMapPath_Label = New System.Windows.Forms.Label()
        Me.report_issue = New System.Windows.Forms.LinkLabel()
        Me.checkVersion = New System.Windows.Forms.LinkLabel()
        Me.group_util = New System.Windows.Forms.GroupBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.dut_access = New System.Windows.Forms.TabControl()
        Me.tab_RegAccess = New System.Windows.Forms.TabPage()
        Me.validateSpiData = New System.Windows.Forms.CheckBox()
        Me.btn_writeRegMap = New System.Windows.Forms.Button()
        Me.drActive = New System.Windows.Forms.CheckBox()
        Me.btn_DumpRegmap = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.numDecimals = New System.Windows.Forms.TextBox()
        Me.numDecimals_label = New System.Windows.Forms.Label()
        Me.ButtonRead = New System.Windows.Forms.Button()
        Me.contRead = New System.Windows.Forms.CheckBox()
        Me.scaledData = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CurrentValue = New System.Windows.Forms.TextBox()
        Me.readLabel = New System.Windows.Forms.Label()
        Me.writeLabel = New System.Windows.Forms.Label()
        Me.newValue = New System.Windows.Forms.TextBox()
        Me.ButtonWrite = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.measureDr = New System.Windows.Forms.CheckBox()
        Me.DrFreq = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.selectPage = New System.Windows.Forms.ComboBox()
        Me.regView = New System.Windows.Forms.DataGridView()
        Me.Label = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Page = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Address = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Contents = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.tab_dataPlot = New System.Windows.Forms.TabPage()
        Me.tab_dataLog = New System.Windows.Forms.TabPage()
        Me.tab_Pin = New System.Windows.Forms.TabPage()
        Me.btn_resistorConfig = New System.Windows.Forms.Button()
        Me.tab_advanced = New System.Windows.Forms.TabPage()
        Me.btn_BitBangSPI = New System.Windows.Forms.Button()
        Me.btn_checkError = New System.Windows.Forms.Button()
        Me.btn_binFile = New System.Windows.Forms.Button()
        Me.btn_pulseMeasure = New System.Windows.Forms.Button()
        Me.btn_ADXL375 = New System.Windows.Forms.Button()
        Me.btn_BurstTest = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.group_util.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.dut_access.SuspendLayout()
        Me.tab_RegAccess.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.regView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_dataPlot.SuspendLayout()
        Me.tab_dataLog.SuspendLayout()
        Me.tab_Pin.SuspendLayout()
        Me.tab_advanced.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.SuspendLayout()
        '
        'text_FX3Status
        '
        Me.text_FX3Status.AutoSize = True
        Me.text_FX3Status.Location = New System.Drawing.Point(3, 21)
        Me.text_FX3Status.Name = "text_FX3Status"
        Me.text_FX3Status.Size = New System.Drawing.Size(65, 13)
        Me.text_FX3Status.TabIndex = 4
        Me.text_FX3Status.Text = "FX3 Status: "
        '
        'label_FX3Status
        '
        Me.label_FX3Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_FX3Status.Location = New System.Drawing.Point(75, 18)
        Me.label_FX3Status.Name = "label_FX3Status"
        Me.label_FX3Status.Size = New System.Drawing.Size(352, 18)
        Me.label_FX3Status.TabIndex = 5
        Me.label_FX3Status.Text = "Ok"
        Me.label_FX3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(6, 19)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(75, 62)
        Me.btn_Connect.TabIndex = 0
        Me.btn_Connect.Text = "Connect to FX3"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'text_DUTStatus
        '
        Me.text_DUTStatus.AutoSize = True
        Me.text_DUTStatus.Location = New System.Drawing.Point(3, 45)
        Me.text_DUTStatus.Name = "text_DUTStatus"
        Me.text_DUTStatus.Size = New System.Drawing.Size(66, 13)
        Me.text_DUTStatus.TabIndex = 12
        Me.text_DUTStatus.Text = "DUT Status:"
        '
        'label_DUTStatus
        '
        Me.label_DUTStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTStatus.Location = New System.Drawing.Point(75, 42)
        Me.label_DUTStatus.Name = "label_DUTStatus"
        Me.label_DUTStatus.Size = New System.Drawing.Size(352, 18)
        Me.label_DUTStatus.TabIndex = 13
        Me.label_DUTStatus.Text = "Waiting for FX3"
        Me.label_DUTStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_ResetDUT
        '
        Me.btn_ResetDUT.Location = New System.Drawing.Point(6, 19)
        Me.btn_ResetDUT.Name = "btn_ResetDUT"
        Me.btn_ResetDUT.Size = New System.Drawing.Size(75, 62)
        Me.btn_ResetDUT.TabIndex = 1
        Me.btn_ResetDUT.Text = "Reset DUT"
        Me.btn_ResetDUT.UseVisualStyleBackColor = True
        '
        'btn_SelectDUT
        '
        Me.btn_SelectDUT.Location = New System.Drawing.Point(6, 19)
        Me.btn_SelectDUT.Name = "btn_SelectDUT"
        Me.btn_SelectDUT.Size = New System.Drawing.Size(75, 62)
        Me.btn_SelectDUT.TabIndex = 3
        Me.btn_SelectDUT.Text = "Select DUT Type"
        Me.btn_SelectDUT.UseVisualStyleBackColor = True
        '
        'text_DUTType
        '
        Me.text_DUTType.AutoSize = True
        Me.text_DUTType.Location = New System.Drawing.Point(3, 69)
        Me.text_DUTType.Name = "text_DUTType"
        Me.text_DUTType.Size = New System.Drawing.Size(60, 13)
        Me.text_DUTType.TabIndex = 18
        Me.text_DUTType.Text = "DUT Type:"
        '
        'label_DUTType
        '
        Me.label_DUTType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTType.Location = New System.Drawing.Point(75, 66)
        Me.label_DUTType.Name = "label_DUTType"
        Me.label_DUTType.Size = New System.Drawing.Size(352, 18)
        Me.label_DUTType.TabIndex = 19
        Me.label_DUTType.Text = "Not Set"
        Me.label_DUTType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_RealTime
        '
        Me.btn_RealTime.Location = New System.Drawing.Point(87, 6)
        Me.btn_RealTime.Name = "btn_RealTime"
        Me.btn_RealTime.Size = New System.Drawing.Size(75, 62)
        Me.btn_RealTime.TabIndex = 6
        Me.btn_RealTime.Text = "Burst Data Capture"
        Me.btn_RealTime.UseVisualStyleBackColor = True
        '
        'btn_BulkRegRead
        '
        Me.btn_BulkRegRead.Location = New System.Drawing.Point(6, 6)
        Me.btn_BulkRegRead.Name = "btn_BulkRegRead"
        Me.btn_BulkRegRead.Size = New System.Drawing.Size(75, 62)
        Me.btn_BulkRegRead.TabIndex = 7
        Me.btn_BulkRegRead.Text = "Register Logging"
        Me.btn_BulkRegRead.UseVisualStyleBackColor = True
        '
        'btn_CheckDUTConnection
        '
        Me.btn_CheckDUTConnection.Location = New System.Drawing.Point(89, 19)
        Me.btn_CheckDUTConnection.Name = "btn_CheckDUTConnection"
        Me.btn_CheckDUTConnection.Size = New System.Drawing.Size(75, 62)
        Me.btn_CheckDUTConnection.TabIndex = 2
        Me.btn_CheckDUTConnection.Text = "Check DUT Connection"
        Me.btn_CheckDUTConnection.UseVisualStyleBackColor = True
        '
        'btn_FX3Config
        '
        Me.btn_FX3Config.Location = New System.Drawing.Point(89, 19)
        Me.btn_FX3Config.Name = "btn_FX3Config"
        Me.btn_FX3Config.Size = New System.Drawing.Size(75, 62)
        Me.btn_FX3Config.TabIndex = 4
        Me.btn_FX3Config.Text = "Manual DUT Config"
        Me.btn_FX3Config.UseVisualStyleBackColor = True
        '
        'btn_APIInfo
        '
        Me.btn_APIInfo.Location = New System.Drawing.Point(89, 19)
        Me.btn_APIInfo.Name = "btn_APIInfo"
        Me.btn_APIInfo.Size = New System.Drawing.Size(75, 62)
        Me.btn_APIInfo.TabIndex = 12
        Me.btn_APIInfo.Text = "FX3 Board Info."
        Me.btn_APIInfo.UseVisualStyleBackColor = True
        '
        'btn_PWMSetup
        '
        Me.btn_PWMSetup.Location = New System.Drawing.Point(87, 6)
        Me.btn_PWMSetup.Name = "btn_PWMSetup"
        Me.btn_PWMSetup.Size = New System.Drawing.Size(75, 62)
        Me.btn_PWMSetup.TabIndex = 11
        Me.btn_PWMSetup.Text = "Pin PWM Setup"
        Me.btn_PWMSetup.UseVisualStyleBackColor = True
        '
        'btn_plotFFT
        '
        Me.btn_plotFFT.Location = New System.Drawing.Point(87, 6)
        Me.btn_plotFFT.Name = "btn_plotFFT"
        Me.btn_plotFFT.Size = New System.Drawing.Size(75, 62)
        Me.btn_plotFFT.TabIndex = 9
        Me.btn_plotFFT.Text = "Frequency Domain Plotting"
        Me.btn_plotFFT.UseVisualStyleBackColor = True
        '
        'btn_PinAccess
        '
        Me.btn_PinAccess.Location = New System.Drawing.Point(6, 6)
        Me.btn_PinAccess.Name = "btn_PinAccess"
        Me.btn_PinAccess.Size = New System.Drawing.Size(75, 62)
        Me.btn_PinAccess.TabIndex = 10
        Me.btn_PinAccess.Text = "Pin Read/Write Access"
        Me.btn_PinAccess.UseVisualStyleBackColor = True
        '
        'label_apiVersion
        '
        Me.label_apiVersion.Location = New System.Drawing.Point(9, 699)
        Me.label_apiVersion.Margin = New System.Windows.Forms.Padding(1, 0, 1, 0)
        Me.label_apiVersion.Name = "label_apiVersion"
        Me.label_apiVersion.Size = New System.Drawing.Size(401, 13)
        Me.label_apiVersion.TabIndex = 30
        Me.label_apiVersion.Text = "apiVersion"
        '
        'btn_plotData
        '
        Me.btn_plotData.Location = New System.Drawing.Point(6, 6)
        Me.btn_plotData.Name = "btn_plotData"
        Me.btn_plotData.Size = New System.Drawing.Size(75, 62)
        Me.btn_plotData.TabIndex = 8
        Me.btn_plotData.Text = "Time Domain Plotting"
        Me.btn_plotData.UseVisualStyleBackColor = True
        '
        'regMapPath_Label
        '
        Me.regMapPath_Label.AutoSize = True
        Me.regMapPath_Label.Location = New System.Drawing.Point(9, 718)
        Me.regMapPath_Label.Name = "regMapPath_Label"
        Me.regMapPath_Label.Size = New System.Drawing.Size(70, 13)
        Me.regMapPath_Label.TabIndex = 33
        Me.regMapPath_Label.Text = "RegMapPath"
        '
        'report_issue
        '
        Me.report_issue.AutoSize = True
        Me.report_issue.Location = New System.Drawing.Point(558, 718)
        Me.report_issue.Name = "report_issue"
        Me.report_issue.Size = New System.Drawing.Size(67, 13)
        Me.report_issue.TabIndex = 16
        Me.report_issue.TabStop = True
        Me.report_issue.Text = "Report Issue"
        '
        'checkVersion
        '
        Me.checkVersion.AutoSize = True
        Me.checkVersion.Location = New System.Drawing.Point(531, 699)
        Me.checkVersion.Name = "checkVersion"
        Me.checkVersion.Size = New System.Drawing.Size(94, 13)
        Me.checkVersion.TabIndex = 15
        Me.checkVersion.TabStop = True
        Me.checkVersion.Text = "Check For Update"
        '
        'group_util
        '
        Me.group_util.Controls.Add(Me.btn_ResetDUT)
        Me.group_util.Controls.Add(Me.btn_CheckDUTConnection)
        Me.group_util.Location = New System.Drawing.Point(451, 108)
        Me.group_util.Name = "group_util"
        Me.group_util.Size = New System.Drawing.Size(170, 90)
        Me.group_util.TabIndex = 34
        Me.group_util.TabStop = False
        Me.group_util.Text = "Utilities"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_SelectDUT)
        Me.GroupBox1.Controls.Add(Me.btn_FX3Config)
        Me.GroupBox1.Location = New System.Drawing.Point(451, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(170, 90)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_Connect)
        Me.GroupBox6.Controls.Add(Me.btn_APIInfo)
        Me.GroupBox6.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(170, 90)
        Me.GroupBox6.TabIndex = 40
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "EVAL-ADIS-FX3 Connection"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.label_DUTType)
        Me.GroupBox7.Controls.Add(Me.text_FX3Status)
        Me.GroupBox7.Controls.Add(Me.label_FX3Status)
        Me.GroupBox7.Controls.Add(Me.text_DUTStatus)
        Me.GroupBox7.Controls.Add(Me.label_DUTStatus)
        Me.GroupBox7.Controls.Add(Me.text_DUTType)
        Me.GroupBox7.Location = New System.Drawing.Point(12, 108)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(433, 90)
        Me.GroupBox7.TabIndex = 41
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "FX3/DUT Status"
        '
        'dut_access
        '
        Me.dut_access.Controls.Add(Me.tab_RegAccess)
        Me.dut_access.Controls.Add(Me.tab_dataPlot)
        Me.dut_access.Controls.Add(Me.tab_dataLog)
        Me.dut_access.Controls.Add(Me.tab_Pin)
        Me.dut_access.Controls.Add(Me.tab_advanced)
        Me.dut_access.Location = New System.Drawing.Point(12, 204)
        Me.dut_access.Name = "dut_access"
        Me.dut_access.SelectedIndex = 0
        Me.dut_access.Size = New System.Drawing.Size(613, 492)
        Me.dut_access.TabIndex = 43
        '
        'tab_RegAccess
        '
        Me.tab_RegAccess.Controls.Add(Me.validateSpiData)
        Me.tab_RegAccess.Controls.Add(Me.btn_writeRegMap)
        Me.tab_RegAccess.Controls.Add(Me.drActive)
        Me.tab_RegAccess.Controls.Add(Me.btn_DumpRegmap)
        Me.tab_RegAccess.Controls.Add(Me.GroupBox5)
        Me.tab_RegAccess.Controls.Add(Me.GroupBox4)
        Me.tab_RegAccess.Controls.Add(Me.GroupBox3)
        Me.tab_RegAccess.Controls.Add(Me.Label6)
        Me.tab_RegAccess.Controls.Add(Me.selectPage)
        Me.tab_RegAccess.Controls.Add(Me.regView)
        Me.tab_RegAccess.Location = New System.Drawing.Point(4, 22)
        Me.tab_RegAccess.Name = "tab_RegAccess"
        Me.tab_RegAccess.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_RegAccess.Size = New System.Drawing.Size(605, 466)
        Me.tab_RegAccess.TabIndex = 0
        Me.tab_RegAccess.Text = "Register Access"
        Me.tab_RegAccess.UseVisualStyleBackColor = True
        '
        'validateSpiData
        '
        Me.validateSpiData.AutoSize = True
        Me.validateSpiData.Location = New System.Drawing.Point(405, 324)
        Me.validateSpiData.Name = "validateSpiData"
        Me.validateSpiData.Size = New System.Drawing.Size(110, 17)
        Me.validateSpiData.TabIndex = 43
        Me.validateSpiData.Text = "Validate SPI Data"
        Me.validateSpiData.UseVisualStyleBackColor = True
        '
        'btn_writeRegMap
        '
        Me.btn_writeRegMap.Location = New System.Drawing.Point(512, 414)
        Me.btn_writeRegMap.Name = "btn_writeRegMap"
        Me.btn_writeRegMap.Size = New System.Drawing.Size(83, 47)
        Me.btn_writeRegMap.TabIndex = 42
        Me.btn_writeRegMap.Text = "Write All Registers"
        Me.btn_writeRegMap.UseVisualStyleBackColor = True
        '
        'drActive
        '
        Me.drActive.AutoSize = True
        Me.drActive.Location = New System.Drawing.Point(405, 301)
        Me.drActive.Name = "drActive"
        Me.drActive.Size = New System.Drawing.Size(145, 17)
        Me.drActive.TabIndex = 41
        Me.drActive.Text = "DR Sync Register Reads"
        Me.drActive.UseVisualStyleBackColor = True
        '
        'btn_DumpRegmap
        '
        Me.btn_DumpRegmap.Location = New System.Drawing.Point(399, 413)
        Me.btn_DumpRegmap.Name = "btn_DumpRegmap"
        Me.btn_DumpRegmap.Size = New System.Drawing.Size(83, 47)
        Me.btn_DumpRegmap.TabIndex = 40
        Me.btn_DumpRegmap.Text = "Log All Registers"
        Me.btn_DumpRegmap.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.numDecimals)
        Me.GroupBox5.Controls.Add(Me.numDecimals_label)
        Me.GroupBox5.Controls.Add(Me.ButtonRead)
        Me.GroupBox5.Controls.Add(Me.contRead)
        Me.GroupBox5.Controls.Add(Me.scaledData)
        Me.GroupBox5.Location = New System.Drawing.Point(399, 6)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(196, 92)
        Me.GroupBox5.TabIndex = 39
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Control"
        '
        'numDecimals
        '
        Me.numDecimals.Location = New System.Drawing.Point(75, 62)
        Me.numDecimals.Name = "numDecimals"
        Me.numDecimals.Size = New System.Drawing.Size(39, 20)
        Me.numDecimals.TabIndex = 28
        Me.numDecimals.Text = "0"
        Me.numDecimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numDecimals_label
        '
        Me.numDecimals_label.AutoSize = True
        Me.numDecimals_label.Location = New System.Drawing.Point(6, 65)
        Me.numDecimals_label.Name = "numDecimals_label"
        Me.numDecimals_label.Size = New System.Drawing.Size(63, 13)
        Me.numDecimals_label.TabIndex = 27
        Me.numDecimals_label.Text = "# Decimals:"
        '
        'ButtonRead
        '
        Me.ButtonRead.Location = New System.Drawing.Point(120, 19)
        Me.ButtonRead.Name = "ButtonRead"
        Me.ButtonRead.Size = New System.Drawing.Size(70, 63)
        Me.ButtonRead.TabIndex = 17
        Me.ButtonRead.Text = "Read Page"
        Me.ButtonRead.UseVisualStyleBackColor = True
        '
        'contRead
        '
        Me.contRead.AutoSize = True
        Me.contRead.Location = New System.Drawing.Point(6, 19)
        Me.contRead.Name = "contRead"
        Me.contRead.Size = New System.Drawing.Size(113, 17)
        Me.contRead.TabIndex = 26
        Me.contRead.Text = "Continuous Reads"
        Me.contRead.UseVisualStyleBackColor = True
        '
        'scaledData
        '
        Me.scaledData.AutoSize = True
        Me.scaledData.Location = New System.Drawing.Point(6, 42)
        Me.scaledData.Name = "scaledData"
        Me.scaledData.Size = New System.Drawing.Size(79, 17)
        Me.scaledData.TabIndex = 20
        Me.scaledData.Text = "Scale Data"
        Me.scaledData.UseVisualStyleBackColor = True
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.CurrentValue)
        Me.GroupBox4.Controls.Add(Me.readLabel)
        Me.GroupBox4.Controls.Add(Me.writeLabel)
        Me.GroupBox4.Controls.Add(Me.newValue)
        Me.GroupBox4.Controls.Add(Me.ButtonWrite)
        Me.GroupBox4.Location = New System.Drawing.Point(399, 104)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(196, 122)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selected Register"
        '
        'CurrentValue
        '
        Me.CurrentValue.BackColor = System.Drawing.SystemColors.Window
        Me.CurrentValue.Location = New System.Drawing.Point(6, 36)
        Me.CurrentValue.Name = "CurrentValue"
        Me.CurrentValue.ReadOnly = True
        Me.CurrentValue.Size = New System.Drawing.Size(72, 20)
        Me.CurrentValue.TabIndex = 16
        Me.CurrentValue.Text = "Not Read"
        Me.CurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'readLabel
        '
        Me.readLabel.AutoSize = True
        Me.readLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.readLabel.Location = New System.Drawing.Point(6, 16)
        Me.readLabel.Name = "readLabel"
        Me.readLabel.Size = New System.Drawing.Size(110, 13)
        Me.readLabel.TabIndex = 15
        Me.readLabel.Text = "Current Hex Value"
        '
        'writeLabel
        '
        Me.writeLabel.AutoSize = True
        Me.writeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.writeLabel.Location = New System.Drawing.Point(3, 68)
        Me.writeLabel.Name = "writeLabel"
        Me.writeLabel.Size = New System.Drawing.Size(94, 13)
        Me.writeLabel.TabIndex = 11
        Me.writeLabel.Text = "New Hex Value"
        '
        'newValue
        '
        Me.newValue.Location = New System.Drawing.Point(6, 87)
        Me.newValue.Name = "newValue"
        Me.newValue.Size = New System.Drawing.Size(72, 20)
        Me.newValue.TabIndex = 10
        Me.newValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ButtonWrite
        '
        Me.ButtonWrite.Location = New System.Drawing.Point(84, 87)
        Me.ButtonWrite.Name = "ButtonWrite"
        Me.ButtonWrite.Size = New System.Drawing.Size(61, 21)
        Me.ButtonWrite.TabIndex = 7
        Me.ButtonWrite.Text = "Write"
        Me.ButtonWrite.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.measureDr)
        Me.GroupBox3.Controls.Add(Me.DrFreq)
        Me.GroupBox3.Location = New System.Drawing.Point(399, 232)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(196, 63)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Ready"
        '
        'measureDr
        '
        Me.measureDr.AutoSize = True
        Me.measureDr.Location = New System.Drawing.Point(6, 19)
        Me.measureDr.Name = "measureDr"
        Me.measureDr.Size = New System.Drawing.Size(127, 17)
        Me.measureDr.TabIndex = 27
        Me.measureDr.Text = "Measure Data Ready"
        Me.measureDr.UseVisualStyleBackColor = True
        '
        'DrFreq
        '
        Me.DrFreq.AutoSize = True
        Me.DrFreq.Location = New System.Drawing.Point(3, 39)
        Me.DrFreq.Name = "DrFreq"
        Me.DrFreq.Size = New System.Drawing.Size(112, 13)
        Me.DrFreq.TabIndex = 25
        Me.DrFreq.Text = "Analyzing Data Ready"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(87, 13)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Select a Page"
        '
        'selectPage
        '
        Me.selectPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selectPage.FormattingEnabled = True
        Me.selectPage.Location = New System.Drawing.Point(98, 6)
        Me.selectPage.Margin = New System.Windows.Forms.Padding(2)
        Me.selectPage.Name = "selectPage"
        Me.selectPage.Size = New System.Drawing.Size(159, 21)
        Me.selectPage.TabIndex = 35
        '
        'regView
        '
        Me.regView.AllowUserToAddRows = False
        Me.regView.AllowUserToDeleteRows = False
        Me.regView.BackgroundColor = System.Drawing.Color.White
        Me.regView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.regView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Label, Me.Page, Me.Address, Me.Contents})
        Me.regView.Location = New System.Drawing.Point(7, 34)
        Me.regView.Margin = New System.Windows.Forms.Padding(2)
        Me.regView.MultiSelect = False
        Me.regView.Name = "regView"
        Me.regView.ReadOnly = True
        Me.regView.RowHeadersVisible = False
        Me.regView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.regView.RowTemplate.Height = 24
        Me.regView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.regView.Size = New System.Drawing.Size(385, 427)
        Me.regView.TabIndex = 34
        '
        'Label
        '
        Me.Label.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill
        Me.Label.HeaderText = "Label"
        Me.Label.Name = "Label"
        Me.Label.ReadOnly = True
        Me.Label.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Label.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        '
        'Page
        '
        Me.Page.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Page.HeaderText = "Page"
        Me.Page.Name = "Page"
        Me.Page.ReadOnly = True
        Me.Page.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Page.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Page.Width = 35
        '
        'Address
        '
        Me.Address.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Address.HeaderText = "Address"
        Me.Address.Name = "Address"
        Me.Address.ReadOnly = True
        Me.Address.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Address.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Address.Width = 50
        '
        'Contents
        '
        Me.Contents.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.Contents.HeaderText = "Contents"
        Me.Contents.Name = "Contents"
        Me.Contents.ReadOnly = True
        Me.Contents.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Contents.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Contents.Width = 110
        '
        'tab_dataPlot
        '
        Me.tab_dataPlot.Controls.Add(Me.btn_RealTime)
        Me.tab_dataPlot.Controls.Add(Me.btn_BulkRegRead)
        Me.tab_dataPlot.Location = New System.Drawing.Point(4, 22)
        Me.tab_dataPlot.Name = "tab_dataPlot"
        Me.tab_dataPlot.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_dataPlot.Size = New System.Drawing.Size(605, 466)
        Me.tab_dataPlot.TabIndex = 1
        Me.tab_dataPlot.Text = "Data Logging"
        Me.tab_dataPlot.UseVisualStyleBackColor = True
        '
        'tab_dataLog
        '
        Me.tab_dataLog.Controls.Add(Me.btn_plotFFT)
        Me.tab_dataLog.Controls.Add(Me.btn_plotData)
        Me.tab_dataLog.Location = New System.Drawing.Point(4, 22)
        Me.tab_dataLog.Name = "tab_dataLog"
        Me.tab_dataLog.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_dataLog.Size = New System.Drawing.Size(605, 466)
        Me.tab_dataLog.TabIndex = 2
        Me.tab_dataLog.Text = "Data Plotting"
        Me.tab_dataLog.UseVisualStyleBackColor = True
        '
        'tab_Pin
        '
        Me.tab_Pin.Controls.Add(Me.btn_PWMSetup)
        Me.tab_Pin.Controls.Add(Me.btn_PinAccess)
        Me.tab_Pin.Controls.Add(Me.btn_resistorConfig)
        Me.tab_Pin.Location = New System.Drawing.Point(4, 22)
        Me.tab_Pin.Name = "tab_Pin"
        Me.tab_Pin.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_Pin.Size = New System.Drawing.Size(605, 466)
        Me.tab_Pin.TabIndex = 3
        Me.tab_Pin.Text = "Pin Access"
        Me.tab_Pin.UseVisualStyleBackColor = True
        '
        'btn_resistorConfig
        '
        Me.btn_resistorConfig.Location = New System.Drawing.Point(168, 6)
        Me.btn_resistorConfig.Name = "btn_resistorConfig"
        Me.btn_resistorConfig.Size = New System.Drawing.Size(75, 62)
        Me.btn_resistorConfig.TabIndex = 10
        Me.btn_resistorConfig.Text = "Pin Resistor Config"
        Me.btn_resistorConfig.UseVisualStyleBackColor = True
        '
        'tab_advanced
        '
        Me.tab_advanced.Controls.Add(Me.GroupBox9)
        Me.tab_advanced.Controls.Add(Me.GroupBox8)
        Me.tab_advanced.Controls.Add(Me.GroupBox2)
        Me.tab_advanced.Location = New System.Drawing.Point(4, 22)
        Me.tab_advanced.Name = "tab_advanced"
        Me.tab_advanced.Padding = New System.Windows.Forms.Padding(3)
        Me.tab_advanced.Size = New System.Drawing.Size(605, 466)
        Me.tab_advanced.TabIndex = 4
        Me.tab_advanced.Text = "Advanced"
        Me.tab_advanced.UseVisualStyleBackColor = True
        '
        'btn_BitBangSPI
        '
        Me.btn_BitBangSPI.Location = New System.Drawing.Point(6, 19)
        Me.btn_BitBangSPI.Name = "btn_BitBangSPI"
        Me.btn_BitBangSPI.Size = New System.Drawing.Size(75, 64)
        Me.btn_BitBangSPI.TabIndex = 13
        Me.btn_BitBangSPI.Text = "Bit Bang SPI Interface"
        Me.btn_BitBangSPI.UseVisualStyleBackColor = True
        '
        'btn_checkError
        '
        Me.btn_checkError.Location = New System.Drawing.Point(6, 20)
        Me.btn_checkError.Name = "btn_checkError"
        Me.btn_checkError.Size = New System.Drawing.Size(75, 64)
        Me.btn_checkError.TabIndex = 12
        Me.btn_checkError.Text = "Check FX3 Error Log"
        Me.btn_checkError.UseVisualStyleBackColor = True
        '
        'btn_binFile
        '
        Me.btn_binFile.Location = New System.Drawing.Point(168, 19)
        Me.btn_binFile.Name = "btn_binFile"
        Me.btn_binFile.Size = New System.Drawing.Size(75, 64)
        Me.btn_binFile.TabIndex = 11
        Me.btn_binFile.Text = "Binary File Writer"
        Me.btn_binFile.UseVisualStyleBackColor = True
        '
        'btn_pulseMeasure
        '
        Me.btn_pulseMeasure.Location = New System.Drawing.Point(6, 19)
        Me.btn_pulseMeasure.Name = "btn_pulseMeasure"
        Me.btn_pulseMeasure.Size = New System.Drawing.Size(75, 64)
        Me.btn_pulseMeasure.TabIndex = 7
        Me.btn_pulseMeasure.Text = "Measure Signal Pulse Width"
        Me.btn_pulseMeasure.UseVisualStyleBackColor = True
        '
        'btn_ADXL375
        '
        Me.btn_ADXL375.Location = New System.Drawing.Point(87, 19)
        Me.btn_ADXL375.Name = "btn_ADXL375"
        Me.btn_ADXL375.Size = New System.Drawing.Size(75, 64)
        Me.btn_ADXL375.TabIndex = 9
        Me.btn_ADXL375.Text = "ADXL375 Data Capture"
        Me.btn_ADXL375.UseVisualStyleBackColor = True
        '
        'btn_BurstTest
        '
        Me.btn_BurstTest.Location = New System.Drawing.Point(87, 19)
        Me.btn_BurstTest.Name = "btn_BurstTest"
        Me.btn_BurstTest.Size = New System.Drawing.Size(75, 64)
        Me.btn_BurstTest.TabIndex = 8
        Me.btn_BurstTest.Text = "Burst Mode Test"
        Me.btn_BurstTest.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_checkError)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(593, 90)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FX3 Utilities"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btn_BitBangSPI)
        Me.GroupBox8.Controls.Add(Me.btn_BurstTest)
        Me.GroupBox8.Location = New System.Drawing.Point(6, 102)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(593, 90)
        Me.GroupBox8.TabIndex = 37
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Custom SPI Traffic"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btn_pulseMeasure)
        Me.GroupBox9.Controls.Add(Me.btn_binFile)
        Me.GroupBox9.Controls.Add(Me.btn_ADXL375)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 198)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(593, 90)
        Me.GroupBox9.TabIndex = 37
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Misc"
        '
        'TopGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(634, 736)
        Me.Controls.Add(Me.dut_access)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.group_util)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.checkVersion)
        Me.Controls.Add(Me.report_issue)
        Me.Controls.Add(Me.regMapPath_Label)
        Me.Controls.Add(Me.label_apiVersion)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(650, 2000)
        Me.MinimumSize = New System.Drawing.Size(650, 730)
        Me.Name = "TopGUI"
        Me.Text = "iSensor FX3 Eval"
        Me.group_util.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.dut_access.ResumeLayout(False)
        Me.tab_RegAccess.ResumeLayout(False)
        Me.tab_RegAccess.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.regView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_dataPlot.ResumeLayout(False)
        Me.tab_dataLog.ResumeLayout(False)
        Me.tab_Pin.ResumeLayout(False)
        Me.tab_advanced.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents text_FX3Status As Label
    Friend WithEvents label_FX3Status As Label
    Friend WithEvents btn_Connect As Button
    Friend WithEvents text_DUTStatus As Label
    Friend WithEvents label_DUTStatus As Label
    Friend WithEvents btn_ResetDUT As Button
    Friend WithEvents btn_SelectDUT As Button
    Friend WithEvents text_DUTType As Label
    Friend WithEvents label_DUTType As Label
    Friend WithEvents btn_RealTime As Button
    Friend WithEvents btn_BulkRegRead As Button
    Friend WithEvents btn_CheckDUTConnection As Button
    Friend WithEvents btn_FX3Config As Button
    Friend WithEvents btn_APIInfo As Button
    Friend WithEvents btn_PWMSetup As Button
    Friend WithEvents btn_plotFFT As Button
    Friend WithEvents btn_PinAccess As Button
    Friend WithEvents label_apiVersion As Label
    Friend WithEvents btn_plotData As Button
    Friend WithEvents regMapPath_Label As Label
    Friend WithEvents report_issue As LinkLabel
    Friend WithEvents checkVersion As LinkLabel
    Friend WithEvents group_util As GroupBox
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox6 As GroupBox
    Friend WithEvents GroupBox7 As GroupBox
    Friend WithEvents dut_access As TabControl
    Friend WithEvents tab_RegAccess As TabPage
    Friend WithEvents tab_dataPlot As TabPage
    Friend WithEvents tab_dataLog As TabPage
    Friend WithEvents tab_Pin As TabPage
    Friend WithEvents tab_advanced As TabPage
    Friend WithEvents btn_resistorConfig As Button
    Friend WithEvents btn_BitBangSPI As Button
    Friend WithEvents btn_checkError As Button
    Friend WithEvents btn_binFile As Button
    Friend WithEvents btn_pulseMeasure As Button
    Friend WithEvents btn_ADXL375 As Button
    Friend WithEvents btn_BurstTest As Button
    Friend WithEvents validateSpiData As CheckBox
    Friend WithEvents btn_writeRegMap As Button
    Friend WithEvents drActive As CheckBox
    Friend WithEvents btn_DumpRegmap As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents numDecimals As TextBox
    Friend WithEvents numDecimals_label As Label
    Friend WithEvents ButtonRead As Button
    Friend WithEvents contRead As CheckBox
    Friend WithEvents scaledData As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CurrentValue As TextBox
    Friend WithEvents readLabel As Label
    Friend WithEvents writeLabel As Label
    Friend WithEvents newValue As TextBox
    Friend WithEvents ButtonWrite As Button
    Friend WithEvents GroupBox3 As GroupBox
    Friend WithEvents measureDr As CheckBox
    Friend WithEvents DrFreq As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents selectPage As ComboBox
    Friend WithEvents regView As DataGridView
    Friend WithEvents Label As DataGridViewTextBoxColumn
    Friend WithEvents Page As DataGridViewTextBoxColumn
    Friend WithEvents Address As DataGridViewTextBoxColumn
    Friend WithEvents Contents As DataGridViewTextBoxColumn
    Friend WithEvents GroupBox9 As GroupBox
    Friend WithEvents GroupBox8 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
End Class
