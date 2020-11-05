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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
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
        Me.btn_plotFFT = New System.Windows.Forms.Button()
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
        Me.btn_DumpRegmap = New System.Windows.Forms.Button()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.numDecimals = New System.Windows.Forms.TextBox()
        Me.numDecimals_label = New System.Windows.Forms.Label()
        Me.btn_ReadPage = New System.Windows.Forms.Button()
        Me.contRead = New System.Windows.Forms.CheckBox()
        Me.scaledData = New System.Windows.Forms.CheckBox()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.CurrentValue = New System.Windows.Forms.TextBox()
        Me.readLabel = New System.Windows.Forms.Label()
        Me.writeLabel = New System.Windows.Forms.Label()
        Me.newValue = New System.Windows.Forms.TextBox()
        Me.btn_WriteReg = New System.Windows.Forms.Button()
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
        Me.Label7 = New System.Windows.Forms.Label()
        Me.dataPlotRegsView = New System.Windows.Forms.DataGridView()
        Me.reg_label = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plot = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.tab_Pin = New System.Windows.Forms.TabPage()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btn_MeasureFreq = New System.Windows.Forms.Button()
        Me.pinToggleFreq = New System.Windows.Forms.TextBox()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.DutyCycle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Freq = New System.Windows.Forms.TextBox()
        Me.btn_StartPWM = New System.Windows.Forms.Button()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.TextBoxPeriod = New System.Windows.Forms.TextBox()
        Me.LabelHighLow = New System.Windows.Forms.Label()
        Me.btn_PulseDrive = New System.Windows.Forms.Button()
        Me.LabelPeriod = New System.Windows.Forms.Label()
        Me.ComboBoxHighLow = New System.Windows.Forms.ComboBox()
        Me.btn_ReadPin = New System.Windows.Forms.Button()
        Me.dgvPinList = New System.Windows.Forms.DataGridView()
        Me.btn_ReadAllPins = New System.Windows.Forms.Button()
        Me.btn_WritePinHigh = New System.Windows.Forms.Button()
        Me.btn_WritePinLow = New System.Windows.Forms.Button()
        Me.tab_advanced = New System.Windows.Forms.TabPage()
        Me.manualGPIOGroupBox = New System.Windows.Forms.GroupBox()
        Me.GroupBox14 = New System.Windows.Forms.GroupBox()
        Me.btn_SetGPIOLow = New System.Windows.Forms.Button()
        Me.btn_SetGPIOHigh = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btn_ReadGPIO = New System.Windows.Forms.Button()
        Me.GPIO_Value = New System.Windows.Forms.TextBox()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.btn_pullDown = New System.Windows.Forms.Button()
        Me.btn_disableResistor = New System.Windows.Forms.Button()
        Me.btn_pullUp = New System.Windows.Forms.Button()
        Me.GPIO_Num = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.btn_pulseMeasure = New System.Windows.Forms.Button()
        Me.btn_binFile = New System.Windows.Forms.Button()
        Me.btn_ADXL375 = New System.Windows.Forms.Button()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.btn_BitBangSPI = New System.Windows.Forms.Button()
        Me.btn_BurstTest = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btn_checkError = New System.Windows.Forms.Button()
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
        CType(Me.dataPlotRegsView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_Pin.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        Me.GroupBox11.SuspendLayout()
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tab_advanced.SuspendLayout()
        Me.manualGPIOGroupBox.SuspendLayout()
        Me.GroupBox14.SuspendLayout()
        Me.GroupBox13.SuspendLayout()
        Me.GroupBox9.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'text_FX3Status
        '
        Me.text_FX3Status.AutoSize = True
        Me.text_FX3Status.Location = New System.Drawing.Point(8, 50)
        Me.text_FX3Status.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.text_FX3Status.Name = "text_FX3Status"
        Me.text_FX3Status.Size = New System.Drawing.Size(170, 32)
        Me.text_FX3Status.TabIndex = 4
        Me.text_FX3Status.Text = "FX3 Status: "
        '
        'label_FX3Status
        '
        Me.label_FX3Status.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_FX3Status.Location = New System.Drawing.Point(200, 43)
        Me.label_FX3Status.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.label_FX3Status.Name = "label_FX3Status"
        Me.label_FX3Status.Size = New System.Drawing.Size(935, 40)
        Me.label_FX3Status.TabIndex = 5
        Me.label_FX3Status.Text = "Ok"
        Me.label_FX3Status.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_Connect
        '
        Me.btn_Connect.Location = New System.Drawing.Point(16, 45)
        Me.btn_Connect.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_Connect.Name = "btn_Connect"
        Me.btn_Connect.Size = New System.Drawing.Size(200, 148)
        Me.btn_Connect.TabIndex = 0
        Me.btn_Connect.Text = "Connect to FX3"
        Me.btn_Connect.UseVisualStyleBackColor = True
        '
        'text_DUTStatus
        '
        Me.text_DUTStatus.AutoSize = True
        Me.text_DUTStatus.Location = New System.Drawing.Point(8, 107)
        Me.text_DUTStatus.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.text_DUTStatus.Name = "text_DUTStatus"
        Me.text_DUTStatus.Size = New System.Drawing.Size(168, 32)
        Me.text_DUTStatus.TabIndex = 12
        Me.text_DUTStatus.Text = "DUT Status:"
        '
        'label_DUTStatus
        '
        Me.label_DUTStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTStatus.Location = New System.Drawing.Point(200, 100)
        Me.label_DUTStatus.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.label_DUTStatus.Name = "label_DUTStatus"
        Me.label_DUTStatus.Size = New System.Drawing.Size(935, 40)
        Me.label_DUTStatus.TabIndex = 13
        Me.label_DUTStatus.Text = "Waiting for FX3"
        Me.label_DUTStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_ResetDUT
        '
        Me.btn_ResetDUT.Location = New System.Drawing.Point(16, 45)
        Me.btn_ResetDUT.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_ResetDUT.Name = "btn_ResetDUT"
        Me.btn_ResetDUT.Size = New System.Drawing.Size(200, 148)
        Me.btn_ResetDUT.TabIndex = 1
        Me.btn_ResetDUT.Text = "Reset DUT"
        Me.btn_ResetDUT.UseVisualStyleBackColor = True
        '
        'btn_SelectDUT
        '
        Me.btn_SelectDUT.Location = New System.Drawing.Point(16, 45)
        Me.btn_SelectDUT.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_SelectDUT.Name = "btn_SelectDUT"
        Me.btn_SelectDUT.Size = New System.Drawing.Size(200, 148)
        Me.btn_SelectDUT.TabIndex = 3
        Me.btn_SelectDUT.Text = "Select DUT Type"
        Me.btn_SelectDUT.UseVisualStyleBackColor = True
        '
        'text_DUTType
        '
        Me.text_DUTType.AutoSize = True
        Me.text_DUTType.Location = New System.Drawing.Point(8, 165)
        Me.text_DUTType.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.text_DUTType.Name = "text_DUTType"
        Me.text_DUTType.Size = New System.Drawing.Size(150, 32)
        Me.text_DUTType.TabIndex = 18
        Me.text_DUTType.Text = "DUT Type:"
        '
        'label_DUTType
        '
        Me.label_DUTType.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.label_DUTType.Location = New System.Drawing.Point(200, 157)
        Me.label_DUTType.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.label_DUTType.Name = "label_DUTType"
        Me.label_DUTType.Size = New System.Drawing.Size(935, 40)
        Me.label_DUTType.TabIndex = 19
        Me.label_DUTType.Text = "Not Set"
        Me.label_DUTType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btn_RealTime
        '
        Me.btn_RealTime.Location = New System.Drawing.Point(232, 14)
        Me.btn_RealTime.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_RealTime.Name = "btn_RealTime"
        Me.btn_RealTime.Size = New System.Drawing.Size(200, 148)
        Me.btn_RealTime.TabIndex = 6
        Me.btn_RealTime.Text = "Burst Data Capture"
        Me.btn_RealTime.UseVisualStyleBackColor = True
        '
        'btn_BulkRegRead
        '
        Me.btn_BulkRegRead.Location = New System.Drawing.Point(16, 14)
        Me.btn_BulkRegRead.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_BulkRegRead.Name = "btn_BulkRegRead"
        Me.btn_BulkRegRead.Size = New System.Drawing.Size(200, 148)
        Me.btn_BulkRegRead.TabIndex = 7
        Me.btn_BulkRegRead.Text = "Register Logging"
        Me.btn_BulkRegRead.UseVisualStyleBackColor = True
        '
        'btn_CheckDUTConnection
        '
        Me.btn_CheckDUTConnection.Location = New System.Drawing.Point(237, 45)
        Me.btn_CheckDUTConnection.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_CheckDUTConnection.Name = "btn_CheckDUTConnection"
        Me.btn_CheckDUTConnection.Size = New System.Drawing.Size(200, 148)
        Me.btn_CheckDUTConnection.TabIndex = 2
        Me.btn_CheckDUTConnection.Text = "Check DUT Connection"
        Me.btn_CheckDUTConnection.UseVisualStyleBackColor = True
        '
        'btn_FX3Config
        '
        Me.btn_FX3Config.Location = New System.Drawing.Point(237, 45)
        Me.btn_FX3Config.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_FX3Config.Name = "btn_FX3Config"
        Me.btn_FX3Config.Size = New System.Drawing.Size(200, 148)
        Me.btn_FX3Config.TabIndex = 4
        Me.btn_FX3Config.Text = "Manual DUT Config"
        Me.btn_FX3Config.UseVisualStyleBackColor = True
        '
        'btn_APIInfo
        '
        Me.btn_APIInfo.Location = New System.Drawing.Point(237, 45)
        Me.btn_APIInfo.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_APIInfo.Name = "btn_APIInfo"
        Me.btn_APIInfo.Size = New System.Drawing.Size(200, 148)
        Me.btn_APIInfo.TabIndex = 12
        Me.btn_APIInfo.Text = "FX3 Board Info."
        Me.btn_APIInfo.UseVisualStyleBackColor = True
        '
        'btn_plotFFT
        '
        Me.btn_plotFFT.Location = New System.Drawing.Point(891, 50)
        Me.btn_plotFFT.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_plotFFT.Name = "btn_plotFFT"
        Me.btn_plotFFT.Size = New System.Drawing.Size(200, 148)
        Me.btn_plotFFT.TabIndex = 9
        Me.btn_plotFFT.Text = "Frequency Domain Plotting"
        Me.btn_plotFFT.UseVisualStyleBackColor = True
        '
        'label_apiVersion
        '
        Me.label_apiVersion.Location = New System.Drawing.Point(24, 1667)
        Me.label_apiVersion.Name = "label_apiVersion"
        Me.label_apiVersion.Size = New System.Drawing.Size(1069, 31)
        Me.label_apiVersion.TabIndex = 30
        Me.label_apiVersion.Text = "apiVersion"
        '
        'btn_plotData
        '
        Me.btn_plotData.Location = New System.Drawing.Point(675, 50)
        Me.btn_plotData.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_plotData.Name = "btn_plotData"
        Me.btn_plotData.Size = New System.Drawing.Size(200, 148)
        Me.btn_plotData.TabIndex = 8
        Me.btn_plotData.Text = "Time Domain Plotting"
        Me.btn_plotData.UseVisualStyleBackColor = True
        '
        'regMapPath_Label
        '
        Me.regMapPath_Label.AutoSize = True
        Me.regMapPath_Label.Location = New System.Drawing.Point(24, 1712)
        Me.regMapPath_Label.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.regMapPath_Label.Name = "regMapPath_Label"
        Me.regMapPath_Label.Size = New System.Drawing.Size(181, 32)
        Me.regMapPath_Label.TabIndex = 33
        Me.regMapPath_Label.Text = "RegMapPath"
        '
        'report_issue
        '
        Me.report_issue.AutoSize = True
        Me.report_issue.Location = New System.Drawing.Point(1488, 1712)
        Me.report_issue.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.report_issue.Name = "report_issue"
        Me.report_issue.Size = New System.Drawing.Size(174, 32)
        Me.report_issue.TabIndex = 16
        Me.report_issue.TabStop = True
        Me.report_issue.Text = "Report Issue"
        '
        'checkVersion
        '
        Me.checkVersion.AutoSize = True
        Me.checkVersion.Location = New System.Drawing.Point(1416, 1667)
        Me.checkVersion.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.checkVersion.Name = "checkVersion"
        Me.checkVersion.Size = New System.Drawing.Size(243, 32)
        Me.checkVersion.TabIndex = 15
        Me.checkVersion.TabStop = True
        Me.checkVersion.Text = "Check For Update"
        '
        'group_util
        '
        Me.group_util.Controls.Add(Me.btn_ResetDUT)
        Me.group_util.Controls.Add(Me.btn_CheckDUTConnection)
        Me.group_util.Location = New System.Drawing.Point(1203, 258)
        Me.group_util.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.group_util.Name = "group_util"
        Me.group_util.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.group_util.Size = New System.Drawing.Size(453, 215)
        Me.group_util.TabIndex = 34
        Me.group_util.TabStop = False
        Me.group_util.Text = "Utilities"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btn_SelectDUT)
        Me.GroupBox1.Controls.Add(Me.btn_FX3Config)
        Me.GroupBox1.Location = New System.Drawing.Point(1203, 29)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox1.Size = New System.Drawing.Size(453, 215)
        Me.GroupBox1.TabIndex = 35
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Settings"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.btn_Connect)
        Me.GroupBox6.Controls.Add(Me.btn_APIInfo)
        Me.GroupBox6.Location = New System.Drawing.Point(32, 29)
        Me.GroupBox6.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox6.Size = New System.Drawing.Size(453, 215)
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
        Me.GroupBox7.Location = New System.Drawing.Point(32, 258)
        Me.GroupBox7.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox7.Size = New System.Drawing.Size(1155, 215)
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
        Me.dut_access.Location = New System.Drawing.Point(32, 486)
        Me.dut_access.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.dut_access.Name = "dut_access"
        Me.dut_access.SelectedIndex = 0
        Me.dut_access.Size = New System.Drawing.Size(1635, 1173)
        Me.dut_access.TabIndex = 43
        '
        'tab_RegAccess
        '
        Me.tab_RegAccess.Controls.Add(Me.validateSpiData)
        Me.tab_RegAccess.Controls.Add(Me.btn_writeRegMap)
        Me.tab_RegAccess.Controls.Add(Me.btn_DumpRegmap)
        Me.tab_RegAccess.Controls.Add(Me.GroupBox5)
        Me.tab_RegAccess.Controls.Add(Me.GroupBox4)
        Me.tab_RegAccess.Controls.Add(Me.GroupBox3)
        Me.tab_RegAccess.Controls.Add(Me.Label6)
        Me.tab_RegAccess.Controls.Add(Me.selectPage)
        Me.tab_RegAccess.Controls.Add(Me.regView)
        Me.tab_RegAccess.Location = New System.Drawing.Point(10, 48)
        Me.tab_RegAccess.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_RegAccess.Name = "tab_RegAccess"
        Me.tab_RegAccess.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_RegAccess.Size = New System.Drawing.Size(1615, 1115)
        Me.tab_RegAccess.TabIndex = 0
        Me.tab_RegAccess.Text = "Register Access"
        Me.tab_RegAccess.UseVisualStyleBackColor = True
        '
        'validateSpiData
        '
        Me.validateSpiData.AutoSize = True
        Me.validateSpiData.Location = New System.Drawing.Point(1080, 718)
        Me.validateSpiData.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.validateSpiData.Name = "validateSpiData"
        Me.validateSpiData.Size = New System.Drawing.Size(277, 36)
        Me.validateSpiData.TabIndex = 43
        Me.validateSpiData.Text = "Validate SPI Data"
        Me.validateSpiData.UseVisualStyleBackColor = True
        '
        'btn_writeRegMap
        '
        Me.btn_writeRegMap.Location = New System.Drawing.Point(1365, 987)
        Me.btn_writeRegMap.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_writeRegMap.Name = "btn_writeRegMap"
        Me.btn_writeRegMap.Size = New System.Drawing.Size(221, 112)
        Me.btn_writeRegMap.TabIndex = 42
        Me.btn_writeRegMap.Text = "Write All Registers"
        Me.btn_writeRegMap.UseVisualStyleBackColor = True
        '
        'btn_DumpRegmap
        '
        Me.btn_DumpRegmap.Location = New System.Drawing.Point(1064, 985)
        Me.btn_DumpRegmap.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_DumpRegmap.Name = "btn_DumpRegmap"
        Me.btn_DumpRegmap.Size = New System.Drawing.Size(221, 112)
        Me.btn_DumpRegmap.TabIndex = 40
        Me.btn_DumpRegmap.Text = "Log All Registers"
        Me.btn_DumpRegmap.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.numDecimals)
        Me.GroupBox5.Controls.Add(Me.numDecimals_label)
        Me.GroupBox5.Controls.Add(Me.btn_ReadPage)
        Me.GroupBox5.Controls.Add(Me.contRead)
        Me.GroupBox5.Controls.Add(Me.scaledData)
        Me.GroupBox5.Location = New System.Drawing.Point(1064, 14)
        Me.GroupBox5.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox5.Size = New System.Drawing.Size(523, 219)
        Me.GroupBox5.TabIndex = 39
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Control"
        '
        'numDecimals
        '
        Me.numDecimals.Location = New System.Drawing.Point(200, 148)
        Me.numDecimals.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.numDecimals.Name = "numDecimals"
        Me.numDecimals.Size = New System.Drawing.Size(97, 38)
        Me.numDecimals.TabIndex = 28
        Me.numDecimals.Text = "1"
        Me.numDecimals.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'numDecimals_label
        '
        Me.numDecimals_label.AutoSize = True
        Me.numDecimals_label.Location = New System.Drawing.Point(16, 155)
        Me.numDecimals_label.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.numDecimals_label.Name = "numDecimals_label"
        Me.numDecimals_label.Size = New System.Drawing.Size(163, 32)
        Me.numDecimals_label.TabIndex = 27
        Me.numDecimals_label.Text = "# Decimals:"
        '
        'btn_ReadPage
        '
        Me.btn_ReadPage.Location = New System.Drawing.Point(320, 45)
        Me.btn_ReadPage.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_ReadPage.Name = "btn_ReadPage"
        Me.btn_ReadPage.Size = New System.Drawing.Size(187, 150)
        Me.btn_ReadPage.TabIndex = 17
        Me.btn_ReadPage.Text = "Read Page"
        Me.btn_ReadPage.UseVisualStyleBackColor = True
        '
        'contRead
        '
        Me.contRead.AutoSize = True
        Me.contRead.Location = New System.Drawing.Point(16, 45)
        Me.contRead.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.contRead.Name = "contRead"
        Me.contRead.Size = New System.Drawing.Size(287, 36)
        Me.contRead.TabIndex = 26
        Me.contRead.Text = "Continuous Reads"
        Me.contRead.UseVisualStyleBackColor = True
        '
        'scaledData
        '
        Me.scaledData.AutoSize = True
        Me.scaledData.Location = New System.Drawing.Point(16, 100)
        Me.scaledData.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.scaledData.Name = "scaledData"
        Me.scaledData.Size = New System.Drawing.Size(192, 36)
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
        Me.GroupBox4.Controls.Add(Me.btn_WriteReg)
        Me.GroupBox4.Location = New System.Drawing.Point(1064, 248)
        Me.GroupBox4.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox4.Size = New System.Drawing.Size(523, 291)
        Me.GroupBox4.TabIndex = 38
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Selected Register"
        '
        'CurrentValue
        '
        Me.CurrentValue.BackColor = System.Drawing.SystemColors.Window
        Me.CurrentValue.Location = New System.Drawing.Point(16, 86)
        Me.CurrentValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.CurrentValue.Name = "CurrentValue"
        Me.CurrentValue.ReadOnly = True
        Me.CurrentValue.Size = New System.Drawing.Size(185, 38)
        Me.CurrentValue.TabIndex = 16
        Me.CurrentValue.Text = "Not Read"
        Me.CurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'readLabel
        '
        Me.readLabel.AutoSize = True
        Me.readLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.readLabel.Location = New System.Drawing.Point(16, 38)
        Me.readLabel.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.readLabel.Name = "readLabel"
        Me.readLabel.Size = New System.Drawing.Size(264, 32)
        Me.readLabel.TabIndex = 15
        Me.readLabel.Text = "Current Hex Value"
        '
        'writeLabel
        '
        Me.writeLabel.AutoSize = True
        Me.writeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.writeLabel.Location = New System.Drawing.Point(8, 162)
        Me.writeLabel.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.writeLabel.Name = "writeLabel"
        Me.writeLabel.Size = New System.Drawing.Size(222, 32)
        Me.writeLabel.TabIndex = 11
        Me.writeLabel.Text = "New Hex Value"
        '
        'newValue
        '
        Me.newValue.Location = New System.Drawing.Point(16, 207)
        Me.newValue.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.newValue.Name = "newValue"
        Me.newValue.Size = New System.Drawing.Size(185, 38)
        Me.newValue.TabIndex = 10
        Me.newValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btn_WriteReg
        '
        Me.btn_WriteReg.Location = New System.Drawing.Point(224, 207)
        Me.btn_WriteReg.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_WriteReg.Name = "btn_WriteReg"
        Me.btn_WriteReg.Size = New System.Drawing.Size(163, 50)
        Me.btn_WriteReg.TabIndex = 7
        Me.btn_WriteReg.Text = "Write"
        Me.btn_WriteReg.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.measureDr)
        Me.GroupBox3.Controls.Add(Me.DrFreq)
        Me.GroupBox3.Location = New System.Drawing.Point(1064, 553)
        Me.GroupBox3.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox3.Size = New System.Drawing.Size(523, 150)
        Me.GroupBox3.TabIndex = 37
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Data Ready"
        '
        'measureDr
        '
        Me.measureDr.AutoSize = True
        Me.measureDr.Location = New System.Drawing.Point(16, 45)
        Me.measureDr.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.measureDr.Name = "measureDr"
        Me.measureDr.Size = New System.Drawing.Size(319, 36)
        Me.measureDr.TabIndex = 27
        Me.measureDr.Text = "Measure Data Ready"
        Me.measureDr.UseVisualStyleBackColor = True
        '
        'DrFreq
        '
        Me.DrFreq.AutoSize = True
        Me.DrFreq.Location = New System.Drawing.Point(8, 93)
        Me.DrFreq.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.DrFreq.Name = "DrFreq"
        Me.DrFreq.Size = New System.Drawing.Size(296, 32)
        Me.DrFreq.TabIndex = 25
        Me.DrFreq.Text = "Analyzing Data Ready"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(16, 21)
        Me.Label6.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(205, 32)
        Me.Label6.TabIndex = 36
        Me.Label6.Text = "Select a Page"
        '
        'selectPage
        '
        Me.selectPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.selectPage.FormattingEnabled = True
        Me.selectPage.Location = New System.Drawing.Point(261, 14)
        Me.selectPage.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.selectPage.Name = "selectPage"
        Me.selectPage.Size = New System.Drawing.Size(417, 39)
        Me.selectPage.TabIndex = 35
        '
        'regView
        '
        Me.regView.AllowUserToAddRows = False
        Me.regView.AllowUserToDeleteRows = False
        Me.regView.BackgroundColor = System.Drawing.Color.White
        Me.regView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.regView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Label, Me.Page, Me.Address, Me.Contents})
        Me.regView.Location = New System.Drawing.Point(19, 81)
        Me.regView.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.regView.MultiSelect = False
        Me.regView.Name = "regView"
        Me.regView.ReadOnly = True
        Me.regView.RowHeadersVisible = False
        Me.regView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.regView.RowTemplate.Height = 24
        Me.regView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.regView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.regView.Size = New System.Drawing.Size(1027, 1018)
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
        Me.tab_dataPlot.Location = New System.Drawing.Point(10, 48)
        Me.tab_dataPlot.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_dataPlot.Name = "tab_dataPlot"
        Me.tab_dataPlot.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_dataPlot.Size = New System.Drawing.Size(1615, 1115)
        Me.tab_dataPlot.TabIndex = 1
        Me.tab_dataPlot.Text = "Data Logging"
        Me.tab_dataPlot.UseVisualStyleBackColor = True
        '
        'tab_dataLog
        '
        Me.tab_dataLog.Controls.Add(Me.Label7)
        Me.tab_dataLog.Controls.Add(Me.dataPlotRegsView)
        Me.tab_dataLog.Controls.Add(Me.btn_plotFFT)
        Me.tab_dataLog.Controls.Add(Me.btn_plotData)
        Me.tab_dataLog.Location = New System.Drawing.Point(10, 48)
        Me.tab_dataLog.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_dataLog.Name = "tab_dataLog"
        Me.tab_dataLog.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_dataLog.Size = New System.Drawing.Size(1615, 1115)
        Me.tab_dataLog.TabIndex = 2
        Me.tab_dataLog.Text = "Data Plotting"
        Me.tab_dataLog.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(8, 12)
        Me.Label7.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 32)
        Me.Label7.TabIndex = 11
        Me.Label7.Text = "Plot Registers"
        '
        'dataPlotRegsView
        '
        Me.dataPlotRegsView.AllowUserToAddRows = False
        Me.dataPlotRegsView.AllowUserToDeleteRows = False
        Me.dataPlotRegsView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dataPlotRegsView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.reg_label, Me.plot})
        Me.dataPlotRegsView.Location = New System.Drawing.Point(16, 50)
        Me.dataPlotRegsView.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.dataPlotRegsView.Name = "dataPlotRegsView"
        Me.dataPlotRegsView.RowHeadersVisible = False
        Me.dataPlotRegsView.Size = New System.Drawing.Size(643, 835)
        Me.dataPlotRegsView.TabIndex = 10
        '
        'reg_label
        '
        Me.reg_label.HeaderText = "Label"
        Me.reg_label.Name = "reg_label"
        '
        'plot
        '
        Me.plot.HeaderText = "Plot"
        Me.plot.Name = "plot"
        '
        'tab_Pin
        '
        Me.tab_Pin.Controls.Add(Me.Label5)
        Me.tab_Pin.Controls.Add(Me.btn_MeasureFreq)
        Me.tab_Pin.Controls.Add(Me.pinToggleFreq)
        Me.tab_Pin.Controls.Add(Me.GroupBox12)
        Me.tab_Pin.Controls.Add(Me.GroupBox11)
        Me.tab_Pin.Controls.Add(Me.btn_ReadPin)
        Me.tab_Pin.Controls.Add(Me.dgvPinList)
        Me.tab_Pin.Controls.Add(Me.btn_ReadAllPins)
        Me.tab_Pin.Controls.Add(Me.btn_WritePinHigh)
        Me.tab_Pin.Controls.Add(Me.btn_WritePinLow)
        Me.tab_Pin.Location = New System.Drawing.Point(10, 48)
        Me.tab_Pin.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_Pin.Name = "tab_Pin"
        Me.tab_Pin.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_Pin.Size = New System.Drawing.Size(1615, 1115)
        Me.tab_Pin.TabIndex = 3
        Me.tab_Pin.Text = "Pin Access"
        Me.tab_Pin.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(501, 603)
        Me.Label5.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 32)
        Me.Label5.TabIndex = 43
        Me.Label5.Text = "Freq:"
        '
        'btn_MeasureFreq
        '
        Me.btn_MeasureFreq.Location = New System.Drawing.Point(501, 501)
        Me.btn_MeasureFreq.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_MeasureFreq.Name = "btn_MeasureFreq"
        Me.btn_MeasureFreq.Size = New System.Drawing.Size(200, 95)
        Me.btn_MeasureFreq.TabIndex = 42
        Me.btn_MeasureFreq.Text = "Measure Freq"
        Me.btn_MeasureFreq.UseVisualStyleBackColor = True
        '
        'pinToggleFreq
        '
        Me.pinToggleFreq.Location = New System.Drawing.Point(501, 641)
        Me.pinToggleFreq.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.pinToggleFreq.Name = "pinToggleFreq"
        Me.pinToggleFreq.Size = New System.Drawing.Size(193, 38)
        Me.pinToggleFreq.TabIndex = 41
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.Label4)
        Me.GroupBox12.Controls.Add(Me.DutyCycle)
        Me.GroupBox12.Controls.Add(Me.Label3)
        Me.GroupBox12.Controls.Add(Me.Freq)
        Me.GroupBox12.Controls.Add(Me.btn_StartPWM)
        Me.GroupBox12.Location = New System.Drawing.Point(717, 14)
        Me.GroupBox12.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox12.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox12.Size = New System.Drawing.Size(451, 284)
        Me.GroupBox12.TabIndex = 40
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "PWM Setup"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 52)
        Me.Label4.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(140, 32)
        Me.Label4.TabIndex = 29
        Me.Label4.Text = "Freq (Hz):"
        '
        'DutyCycle
        '
        Me.DutyCycle.Location = New System.Drawing.Point(197, 107)
        Me.DutyCycle.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.DutyCycle.Name = "DutyCycle"
        Me.DutyCycle.Size = New System.Drawing.Size(223, 38)
        Me.DutyCycle.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 114)
        Me.Label3.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(159, 32)
        Me.Label3.TabIndex = 30
        Me.Label3.Text = "Duty Cycle:"
        '
        'Freq
        '
        Me.Freq.Location = New System.Drawing.Point(197, 45)
        Me.Freq.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.Freq.Name = "Freq"
        Me.Freq.Size = New System.Drawing.Size(223, 38)
        Me.Freq.TabIndex = 34
        '
        'btn_StartPWM
        '
        Me.btn_StartPWM.Location = New System.Drawing.Point(96, 169)
        Me.btn_StartPWM.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_StartPWM.Name = "btn_StartPWM"
        Me.btn_StartPWM.Size = New System.Drawing.Size(200, 95)
        Me.btn_StartPWM.TabIndex = 32
        Me.btn_StartPWM.Text = "Start PWM"
        Me.btn_StartPWM.UseVisualStyleBackColor = True
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.TextBoxPeriod)
        Me.GroupBox11.Controls.Add(Me.LabelHighLow)
        Me.GroupBox11.Controls.Add(Me.btn_PulseDrive)
        Me.GroupBox11.Controls.Add(Me.LabelPeriod)
        Me.GroupBox11.Controls.Add(Me.ComboBoxHighLow)
        Me.GroupBox11.Location = New System.Drawing.Point(717, 312)
        Me.GroupBox11.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox11.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GroupBox11.Size = New System.Drawing.Size(451, 284)
        Me.GroupBox11.TabIndex = 26
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Pulse Drive"
        '
        'TextBoxPeriod
        '
        Me.TextBoxPeriod.Location = New System.Drawing.Point(197, 110)
        Me.TextBoxPeriod.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.TextBoxPeriod.Name = "TextBoxPeriod"
        Me.TextBoxPeriod.Size = New System.Drawing.Size(223, 38)
        Me.TextBoxPeriod.TabIndex = 12
        '
        'LabelHighLow
        '
        Me.LabelHighLow.AutoSize = True
        Me.LabelHighLow.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelHighLow.Location = New System.Drawing.Point(16, 57)
        Me.LabelHighLow.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelHighLow.Name = "LabelHighLow"
        Me.LabelHighLow.Size = New System.Drawing.Size(142, 32)
        Me.LabelHighLow.TabIndex = 11
        Me.LabelHighLow.Text = "High/Low:"
        '
        'btn_PulseDrive
        '
        Me.btn_PulseDrive.Location = New System.Drawing.Point(120, 172)
        Me.btn_PulseDrive.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_PulseDrive.Name = "btn_PulseDrive"
        Me.btn_PulseDrive.Size = New System.Drawing.Size(200, 95)
        Me.btn_PulseDrive.TabIndex = 17
        Me.btn_PulseDrive.Text = "Pulse Drive"
        Me.btn_PulseDrive.UseVisualStyleBackColor = True
        '
        'LabelPeriod
        '
        Me.LabelPeriod.AutoSize = True
        Me.LabelPeriod.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.LabelPeriod.Location = New System.Drawing.Point(16, 117)
        Me.LabelPeriod.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.LabelPeriod.Name = "LabelPeriod"
        Me.LabelPeriod.Size = New System.Drawing.Size(168, 32)
        Me.LabelPeriod.TabIndex = 13
        Me.LabelPeriod.Text = "Period (ms):"
        '
        'ComboBoxHighLow
        '
        Me.ComboBoxHighLow.FormattingEnabled = True
        Me.ComboBoxHighLow.Location = New System.Drawing.Point(197, 45)
        Me.ComboBoxHighLow.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.ComboBoxHighLow.Name = "ComboBoxHighLow"
        Me.ComboBoxHighLow.Size = New System.Drawing.Size(223, 39)
        Me.ComboBoxHighLow.TabIndex = 15
        '
        'btn_ReadPin
        '
        Me.btn_ReadPin.Location = New System.Drawing.Point(501, 234)
        Me.btn_ReadPin.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_ReadPin.Name = "btn_ReadPin"
        Me.btn_ReadPin.Size = New System.Drawing.Size(200, 95)
        Me.btn_ReadPin.TabIndex = 25
        Me.btn_ReadPin.Text = "Read Pin"
        Me.btn_ReadPin.UseVisualStyleBackColor = True
        '
        'dgvPinList
        '
        Me.dgvPinList.AllowUserToAddRows = False
        Me.dgvPinList.AllowUserToDeleteRows = False
        Me.dgvPinList.BackgroundColor = System.Drawing.Color.White
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.dgvPinList.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.dgvPinList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPinList.Location = New System.Drawing.Point(13, 12)
        Me.dgvPinList.Margin = New System.Windows.Forms.Padding(5, 5, 5, 5)
        Me.dgvPinList.MultiSelect = False
        Me.dgvPinList.Name = "dgvPinList"
        Me.dgvPinList.ReadOnly = True
        Me.dgvPinList.RowHeadersVisible = False
        Me.dgvPinList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.dgvPinList.RowTemplate.Height = 24
        Me.dgvPinList.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.dgvPinList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPinList.Size = New System.Drawing.Size(475, 680)
        Me.dgvPinList.TabIndex = 24
        '
        'btn_ReadAllPins
        '
        Me.btn_ReadAllPins.Location = New System.Drawing.Point(501, 343)
        Me.btn_ReadAllPins.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_ReadAllPins.Name = "btn_ReadAllPins"
        Me.btn_ReadAllPins.Size = New System.Drawing.Size(200, 95)
        Me.btn_ReadAllPins.TabIndex = 23
        Me.btn_ReadAllPins.Text = "Read All"
        Me.btn_ReadAllPins.UseVisualStyleBackColor = True
        '
        'btn_WritePinHigh
        '
        Me.btn_WritePinHigh.Location = New System.Drawing.Point(501, 14)
        Me.btn_WritePinHigh.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_WritePinHigh.Name = "btn_WritePinHigh"
        Me.btn_WritePinHigh.Size = New System.Drawing.Size(200, 95)
        Me.btn_WritePinHigh.TabIndex = 22
        Me.btn_WritePinHigh.Text = "Set High"
        Me.btn_WritePinHigh.UseVisualStyleBackColor = True
        '
        'btn_WritePinLow
        '
        Me.btn_WritePinLow.Location = New System.Drawing.Point(501, 124)
        Me.btn_WritePinLow.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_WritePinLow.Name = "btn_WritePinLow"
        Me.btn_WritePinLow.Size = New System.Drawing.Size(200, 95)
        Me.btn_WritePinLow.TabIndex = 21
        Me.btn_WritePinLow.Text = "Set Low"
        Me.btn_WritePinLow.UseVisualStyleBackColor = True
        '
        'tab_advanced
        '
        Me.tab_advanced.Controls.Add(Me.manualGPIOGroupBox)
        Me.tab_advanced.Controls.Add(Me.GroupBox9)
        Me.tab_advanced.Controls.Add(Me.GroupBox8)
        Me.tab_advanced.Controls.Add(Me.GroupBox2)
        Me.tab_advanced.Location = New System.Drawing.Point(10, 48)
        Me.tab_advanced.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_advanced.Name = "tab_advanced"
        Me.tab_advanced.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.tab_advanced.Size = New System.Drawing.Size(1615, 1115)
        Me.tab_advanced.TabIndex = 4
        Me.tab_advanced.Text = "Advanced"
        Me.tab_advanced.UseVisualStyleBackColor = True
        '
        'manualGPIOGroupBox
        '
        Me.manualGPIOGroupBox.Controls.Add(Me.GroupBox14)
        Me.manualGPIOGroupBox.Controls.Add(Me.GroupBox13)
        Me.manualGPIOGroupBox.Controls.Add(Me.GPIO_Num)
        Me.manualGPIOGroupBox.Controls.Add(Me.Label1)
        Me.manualGPIOGroupBox.Location = New System.Drawing.Point(16, 243)
        Me.manualGPIOGroupBox.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.manualGPIOGroupBox.Name = "manualGPIOGroupBox"
        Me.manualGPIOGroupBox.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.manualGPIOGroupBox.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.manualGPIOGroupBox.Size = New System.Drawing.Size(880, 434)
        Me.manualGPIOGroupBox.TabIndex = 38
        Me.manualGPIOGroupBox.TabStop = False
        Me.manualGPIOGroupBox.Text = "Manual GPIO Access"
        '
        'GroupBox14
        '
        Me.GroupBox14.Controls.Add(Me.btn_SetGPIOLow)
        Me.GroupBox14.Controls.Add(Me.btn_SetGPIOHigh)
        Me.GroupBox14.Controls.Add(Me.Label2)
        Me.GroupBox14.Controls.Add(Me.btn_ReadGPIO)
        Me.GroupBox14.Controls.Add(Me.GPIO_Value)
        Me.GroupBox14.Location = New System.Drawing.Point(24, 136)
        Me.GroupBox14.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox14.Name = "GroupBox14"
        Me.GroupBox14.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox14.Size = New System.Drawing.Size(461, 279)
        Me.GroupBox14.TabIndex = 41
        Me.GroupBox14.TabStop = False
        Me.GroupBox14.Text = "Read/Write"
        '
        'btn_SetGPIOLow
        '
        Me.btn_SetGPIOLow.Location = New System.Drawing.Point(245, 169)
        Me.btn_SetGPIOLow.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_SetGPIOLow.Name = "btn_SetGPIOLow"
        Me.btn_SetGPIOLow.Size = New System.Drawing.Size(200, 95)
        Me.btn_SetGPIOLow.TabIndex = 18
        Me.btn_SetGPIOLow.Text = "Set Low"
        Me.btn_SetGPIOLow.UseVisualStyleBackColor = True
        '
        'btn_SetGPIOHigh
        '
        Me.btn_SetGPIOHigh.Location = New System.Drawing.Point(245, 41)
        Me.btn_SetGPIOHigh.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_SetGPIOHigh.Name = "btn_SetGPIOHigh"
        Me.btn_SetGPIOHigh.Size = New System.Drawing.Size(200, 95)
        Me.btn_SetGPIOHigh.TabIndex = 19
        Me.btn_SetGPIOHigh.Text = "Set High"
        Me.btn_SetGPIOHigh.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 179)
        Me.Label2.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(146, 32)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Pin Value:"
        '
        'btn_ReadGPIO
        '
        Me.btn_ReadGPIO.Location = New System.Drawing.Point(21, 41)
        Me.btn_ReadGPIO.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_ReadGPIO.Name = "btn_ReadGPIO"
        Me.btn_ReadGPIO.Size = New System.Drawing.Size(200, 95)
        Me.btn_ReadGPIO.TabIndex = 20
        Me.btn_ReadGPIO.Text = "Read Pin"
        Me.btn_ReadGPIO.UseVisualStyleBackColor = True
        '
        'GPIO_Value
        '
        Me.GPIO_Value.Location = New System.Drawing.Point(16, 217)
        Me.GPIO_Value.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GPIO_Value.Name = "GPIO_Value"
        Me.GPIO_Value.Size = New System.Drawing.Size(193, 38)
        Me.GPIO_Value.TabIndex = 21
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.btn_pullDown)
        Me.GroupBox13.Controls.Add(Me.btn_disableResistor)
        Me.GroupBox13.Controls.Add(Me.btn_pullUp)
        Me.GroupBox13.Location = New System.Drawing.Point(603, 31)
        Me.GroupBox13.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox13.Size = New System.Drawing.Size(253, 384)
        Me.GroupBox13.TabIndex = 40
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Pin Resistor"
        '
        'btn_pullDown
        '
        Me.btn_pullDown.Location = New System.Drawing.Point(27, 262)
        Me.btn_pullDown.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_pullDown.Name = "btn_pullDown"
        Me.btn_pullDown.Size = New System.Drawing.Size(200, 95)
        Me.btn_pullDown.TabIndex = 36
        Me.btn_pullDown.Text = "Pull-Down Resistor"
        Me.btn_pullDown.UseVisualStyleBackColor = True
        '
        'btn_disableResistor
        '
        Me.btn_disableResistor.Location = New System.Drawing.Point(27, 45)
        Me.btn_disableResistor.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_disableResistor.Name = "btn_disableResistor"
        Me.btn_disableResistor.Size = New System.Drawing.Size(200, 95)
        Me.btn_disableResistor.TabIndex = 39
        Me.btn_disableResistor.Text = "Disable Resistor"
        Me.btn_disableResistor.UseVisualStyleBackColor = True
        '
        'btn_pullUp
        '
        Me.btn_pullUp.Location = New System.Drawing.Point(27, 153)
        Me.btn_pullUp.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_pullUp.Name = "btn_pullUp"
        Me.btn_pullUp.Size = New System.Drawing.Size(200, 95)
        Me.btn_pullUp.TabIndex = 35
        Me.btn_pullUp.Text = "Pull-Up Resistor"
        Me.btn_pullUp.UseVisualStyleBackColor = True
        '
        'GPIO_Num
        '
        Me.GPIO_Num.Location = New System.Drawing.Point(235, 45)
        Me.GPIO_Num.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GPIO_Num.Name = "GPIO_Num"
        Me.GPIO_Num.Size = New System.Drawing.Size(244, 38)
        Me.GPIO_Num.TabIndex = 12
        Me.GPIO_Num.Text = "0"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.Label1.Location = New System.Drawing.Point(16, 52)
        Me.Label1.Margin = New System.Windows.Forms.Padding(8, 0, 8, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(200, 32)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "GPIO Number:"
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.btn_pulseMeasure)
        Me.GroupBox9.Controls.Add(Me.btn_binFile)
        Me.GroupBox9.Controls.Add(Me.btn_ADXL375)
        Me.GroupBox9.Location = New System.Drawing.Point(736, 14)
        Me.GroupBox9.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox9.Size = New System.Drawing.Size(669, 215)
        Me.GroupBox9.TabIndex = 37
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Misc"
        '
        'btn_pulseMeasure
        '
        Me.btn_pulseMeasure.Location = New System.Drawing.Point(16, 45)
        Me.btn_pulseMeasure.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_pulseMeasure.Name = "btn_pulseMeasure"
        Me.btn_pulseMeasure.Size = New System.Drawing.Size(200, 153)
        Me.btn_pulseMeasure.TabIndex = 7
        Me.btn_pulseMeasure.Text = "Measure Signal Pulse Width"
        Me.btn_pulseMeasure.UseVisualStyleBackColor = True
        '
        'btn_binFile
        '
        Me.btn_binFile.Location = New System.Drawing.Point(448, 45)
        Me.btn_binFile.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_binFile.Name = "btn_binFile"
        Me.btn_binFile.Size = New System.Drawing.Size(200, 153)
        Me.btn_binFile.TabIndex = 11
        Me.btn_binFile.Text = "Binary File Writer"
        Me.btn_binFile.UseVisualStyleBackColor = True
        '
        'btn_ADXL375
        '
        Me.btn_ADXL375.Location = New System.Drawing.Point(232, 45)
        Me.btn_ADXL375.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_ADXL375.Name = "btn_ADXL375"
        Me.btn_ADXL375.Size = New System.Drawing.Size(200, 153)
        Me.btn_ADXL375.TabIndex = 9
        Me.btn_ADXL375.Text = "ADXL375 Data Capture"
        Me.btn_ADXL375.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btn_BitBangSPI)
        Me.GroupBox8.Controls.Add(Me.btn_BurstTest)
        Me.GroupBox8.Location = New System.Drawing.Point(267, 14)
        Me.GroupBox8.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox8.Size = New System.Drawing.Size(453, 215)
        Me.GroupBox8.TabIndex = 37
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Custom SPI Traffic"
        '
        'btn_BitBangSPI
        '
        Me.btn_BitBangSPI.Location = New System.Drawing.Point(16, 45)
        Me.btn_BitBangSPI.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_BitBangSPI.Name = "btn_BitBangSPI"
        Me.btn_BitBangSPI.Size = New System.Drawing.Size(200, 153)
        Me.btn_BitBangSPI.TabIndex = 13
        Me.btn_BitBangSPI.Text = "Bit Bang SPI Interface"
        Me.btn_BitBangSPI.UseVisualStyleBackColor = True
        '
        'btn_BurstTest
        '
        Me.btn_BurstTest.Location = New System.Drawing.Point(232, 45)
        Me.btn_BurstTest.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_BurstTest.Name = "btn_BurstTest"
        Me.btn_BurstTest.Size = New System.Drawing.Size(200, 153)
        Me.btn_BurstTest.TabIndex = 8
        Me.btn_BurstTest.Text = "Burst Mode Test"
        Me.btn_BurstTest.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btn_checkError)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 14)
        Me.GroupBox2.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Padding = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.GroupBox2.Size = New System.Drawing.Size(235, 215)
        Me.GroupBox2.TabIndex = 36
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "FX3 Utilities"
        '
        'btn_checkError
        '
        Me.btn_checkError.Location = New System.Drawing.Point(16, 48)
        Me.btn_checkError.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.btn_checkError.Name = "btn_checkError"
        Me.btn_checkError.Size = New System.Drawing.Size(200, 153)
        Me.btn_checkError.TabIndex = 12
        Me.btn_checkError.Text = "Check FX3 Error Log"
        Me.btn_checkError.UseVisualStyleBackColor = True
        '
        'TopGUI
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(16.0!, 31.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1648, 1755)
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
        Me.Margin = New System.Windows.Forms.Padding(8, 7, 8, 7)
        Me.MaximumSize = New System.Drawing.Size(1680, 4647)
        Me.MinimumSize = New System.Drawing.Size(1680, 1524)
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
        Me.tab_dataLog.PerformLayout()
        CType(Me.dataPlotRegsView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_Pin.ResumeLayout(False)
        Me.tab_Pin.PerformLayout()
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        Me.GroupBox11.ResumeLayout(False)
        Me.GroupBox11.PerformLayout()
        CType(Me.dgvPinList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tab_advanced.ResumeLayout(False)
        Me.manualGPIOGroupBox.ResumeLayout(False)
        Me.manualGPIOGroupBox.PerformLayout()
        Me.GroupBox14.ResumeLayout(False)
        Me.GroupBox14.PerformLayout()
        Me.GroupBox13.ResumeLayout(False)
        Me.GroupBox9.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
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
    Friend WithEvents btn_plotFFT As Button
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
    Friend WithEvents btn_BitBangSPI As Button
    Friend WithEvents btn_checkError As Button
    Friend WithEvents btn_binFile As Button
    Friend WithEvents btn_pulseMeasure As Button
    Friend WithEvents btn_ADXL375 As Button
    Friend WithEvents btn_BurstTest As Button
    Friend WithEvents validateSpiData As CheckBox
    Friend WithEvents btn_writeRegMap As Button
    Friend WithEvents btn_DumpRegmap As Button
    Friend WithEvents GroupBox5 As GroupBox
    Friend WithEvents numDecimals As TextBox
    Friend WithEvents numDecimals_label As Label
    Friend WithEvents btn_ReadPage As Button
    Friend WithEvents contRead As CheckBox
    Friend WithEvents scaledData As CheckBox
    Friend WithEvents GroupBox4 As GroupBox
    Friend WithEvents CurrentValue As TextBox
    Friend WithEvents readLabel As Label
    Friend WithEvents writeLabel As Label
    Friend WithEvents newValue As TextBox
    Friend WithEvents btn_WriteReg As Button
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
    Friend WithEvents GroupBox11 As GroupBox
    Friend WithEvents TextBoxPeriod As TextBox
    Friend WithEvents LabelHighLow As Label
    Friend WithEvents btn_PulseDrive As Button
    Friend WithEvents LabelPeriod As Label
    Friend WithEvents ComboBoxHighLow As ComboBox
    Friend WithEvents btn_ReadPin As Button
    Friend WithEvents dgvPinList As DataGridView
    Friend WithEvents btn_ReadAllPins As Button
    Friend WithEvents btn_WritePinHigh As Button
    Friend WithEvents btn_WritePinLow As Button
    Friend WithEvents Freq As TextBox
    Friend WithEvents DutyCycle As TextBox
    Friend WithEvents btn_StartPWM As Button
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBox12 As GroupBox
    Friend WithEvents btn_MeasureFreq As Button
    Friend WithEvents pinToggleFreq As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents manualGPIOGroupBox As GroupBox
    Friend WithEvents GroupBox14 As GroupBox
    Friend WithEvents btn_SetGPIOLow As Button
    Friend WithEvents btn_SetGPIOHigh As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents btn_ReadGPIO As Button
    Friend WithEvents GPIO_Value As TextBox
    Friend WithEvents GroupBox13 As GroupBox
    Friend WithEvents btn_pullDown As Button
    Friend WithEvents btn_disableResistor As Button
    Friend WithEvents btn_pullUp As Button
    Friend WithEvents GPIO_Num As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents dataPlotRegsView As DataGridView
    Friend WithEvents reg_label As DataGridViewTextBoxColumn
    Friend WithEvents plot As DataGridViewCheckBoxColumn
End Class
