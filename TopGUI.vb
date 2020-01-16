'File:          TopGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Top level GUI for the FX3 example application

Imports FX3Api
Imports adisInterface
Imports RegMapClasses
Imports System.IO
Imports System.Reflection
Imports System.Timers
Imports System.Threading

Public Class TopGUI

    'Public member variables accessible to all forms
    Public WithEvents FX3 As FX3Connection
    Public RegMap As RegMapCollection
    Public Dut As IDutInterface

    'List of listviewitems for bulk register read
    Friend BulkRegList As List(Of ListViewItem)
    Friend numRegSamples As Integer
    Friend samplesPerWrite As Integer
    Friend linesPerFile As Integer

    'Last browsed to file location
    Public lastFilePath As String

    'Private member variables
    Private m_FX3Connected As Boolean
    Private WithEvents m_disconnectTimer As Timers.Timer
    Private m_RegMapPath As String
    Private m_AutoSpi As iSensorAutomotiveSpi

    ''' <summary>
    ''' This event is raised when the active board is disconnected unexpectedly (IE unplugged)
    ''' </summary>
    ''' <param name="FX3SerialNum">Serial number of the board which was disconnected</param>
    Event UnexpectedDisconnect(ByVal FX3SerialNum As String)

    Public Sub New()

        ' This call is required by the designer.'

        InitializeComponent()

        Dim firmwarePath As String
        Dim blinkFirmwarePath As String
        Dim flashProgrammerPath As String

        'Create a local copy of embedded firmware file
        Dim firmwareResource As String = "FX3ExampleGUI.FX3_Firmware.img"
        firmwarePath = System.Reflection.Assembly.GetExecutingAssembly.Location
        firmwarePath = firmwarePath.Substring(0, firmwarePath.LastIndexOf("\") + 1)
        firmwarePath = firmwarePath + "FX3_Firmware.img"
        Dim assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim outputStream As New FileStream(firmwarePath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Create a local copy of bootloader firmware file
        firmwareResource = "FX3ExampleGUI.boot_fw.img"
        blinkFirmwarePath = System.Reflection.Assembly.GetExecutingAssembly.Location
        blinkFirmwarePath = blinkFirmwarePath.Substring(0, blinkFirmwarePath.LastIndexOf("\") + 1)
        blinkFirmwarePath = blinkFirmwarePath + "boot_fw.img"
        assembly = System.Reflection.Assembly.GetExecutingAssembly()
        outputStream = New FileStream(blinkFirmwarePath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Create a local copy of the flash programmer
        firmwareResource = "FX3ExampleGUI.USBFlashProg.img"
        flashProgrammerPath = System.Reflection.Assembly.GetExecutingAssembly.Location
        flashProgrammerPath = flashProgrammerPath.Substring(0, flashProgrammerPath.LastIndexOf("\") + 1)
        flashProgrammerPath = flashProgrammerPath + "USBFlashProg.img"
        assembly = System.Reflection.Assembly.GetExecutingAssembly()
        outputStream = New FileStream(flashProgrammerPath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Set the regmap path using the SelectRegMap GUI
        If Not File.Exists(My.Settings.SelectedRegMap) Then
            Dim regMapSelector As New SelectRegmapGUI()
            If Not IsNothing(regMapSelector.SelectedPath) Then
                RegMapPath = regMapSelector.SelectedPath
            ElseIf regMapSelector.ShowDialog() = DialogResult.OK Then
                RegMapPath = regMapSelector.SelectedPath
            Else
                'Bad path will complain without breaking anything
                RegMapPath = ""
            End If
            regMapSelector.Dispose()
        Else
            RegMapPath = My.Settings.SelectedRegMap
        End If

        'Set FX3 connection (defaults to ADcmXL)
        FX3 = New FX3Connection(firmwarePath, blinkFirmwarePath, flashProgrammerPath, FX3Api.DeviceType.IMU)

        'Set bulk reg list
        BulkRegList = New List(Of ListViewItem)
        numRegSamples = 10000
        linesPerFile = 1000000
        samplesPerWrite = 10000

        'Seed random number generator
        Randomize()

        'Set button and label initial values
        ResetButtons()
        ResetLabels()

        'Initialize variables
        m_FX3Connected = False

        'register timeout event handler
        m_disconnectTimer = New Timers.Timer(10000)
        m_disconnectTimer.Enabled = False
        AddHandler m_disconnectTimer.Elapsed, New ElapsedEventHandler(AddressOf timeoutHandler)

        'Add exception handler
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GeneralErrorHandler

        'Set up autospi
        m_AutoSpi = New iSensorAutomotiveSpi(FX3)
        m_AutoSpi.IgnoreExceptions = True

        'Set the API version and build date
        label_apiVersion.Text = "ADI iSensor FX3 Demonstration Platform Version " + FX3.GetFX3ApiInfo.VersionNumber

        'load the last used file path
        lastFilePath = My.Settings.LastFilePath

        'Set tool tips
        SetupToolTips()

        'Register exception handlers
        Dim myApp As AppDomain = AppDomain.CurrentDomain
        AddHandler myApp.UnhandledException, AddressOf GeneralErrorHandler
        AddHandler Application.ThreadException, AddressOf ThreadErrorHandler

    End Sub

    Private Sub SetupToolTips()

        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(Me.btn_APIInfo, "Get information about the version of the FX3 API being used")
        tip0.SetToolTip(Me.btn_BoardInfo, "Get information about the version of the connected FX3 board")
        tip0.SetToolTip(Me.btn_BulkRegRead, "Stream register values to a CSV file")
        tip0.SetToolTip(Me.btn_CheckDUTConnection, "Checks a DUT connection by writing a random value to user scratch and reading it back. Restores the original user scratch register value afterwards")
        tip0.SetToolTip(Me.btn_Connect, "Connect or disconnect from an iSensor FX3 Demonstration Platform")
        tip0.SetToolTip(Me.btn_FX3Config, "View or set all FX3 configuration options (sclk, stall time, etc)")
        tip0.SetToolTip(Me.btn_plotFFT, "Stream and plot frequency domain DUT data in real time")
        tip0.SetToolTip(Me.btn_OtherApps, "Other misc. applications developed for the iSensor FX3 Example GUI")
        tip0.SetToolTip(Me.btn_SelectDUT, "Select the DUT type. Loads the default values for that DUT type")
        tip0.SetToolTip(Me.btn_RealTime, "Real time stream GUI (for ADcmXL type DUTs) or burst stream GUI (for all other DUTs)")
        tip0.SetToolTip(Me.btn_RegAccess, "Read or write all registers in the loaded register map")
        tip0.SetToolTip(Me.btn_plotData, "Plot DUT data in real time, or play back a DUT stream from a saved CSV file")
        tip0.SetToolTip(Me.btn_PinAccess, "Read or set all FX3 digital IO pins (DIO1 - DIO4, FX3GPIO1 - FX3GPIO4)")
        tip0.SetToolTip(Me.btn_PWMSetup, "Configure PWM signal generation on the FX3 digital IO")
        tip0.SetToolTip(Me.label_apiVersion, "The current version of the FX3 API and firmware being used by the iSensor FX3 Example GUI")
        tip0.SetToolTip(Me.regMapPath_Label, "The loaded register map file: " + RegMapPath)
        tip0.SetToolTip(Me.report_issue, "Report an issue with the iSensor FX3 Example GUI. Requires a GitHub account")
        tip0.SetToolTip(Me.btn_ResetDUT, "Drives the reset pin low for 500ms, waits for data ready to be asserted, and checks the DUT connection")

    End Sub

#Region "Properties"

    Public Property RegMapPath As String
        Get
            Return m_RegMapPath
        End Get
        Set(value As String)
            Try
                m_RegMapPath = value
                'Set the regmap
                RegMap = New RegMapCollection
                RegMap.ReadFromCSV(m_RegMapPath)
                If RegMap.Count() = 0 Then
                    Throw New Exception("Regmap produced from selected file contains 0 registers")
                End If
                regMapPath_Label.Text = value.Substring(value.LastIndexOf("\") + 1)
                SetupToolTips()
            Catch ex As Exception
                MsgBox("ERROR: Invalid RegMap Selected! " + ex.Message())
            End Try
        End Set
    End Property

#End Region

#Region "Button Event Handlers"

    Private Sub btn_bit_bang_Click(sender As Object, e As EventArgs)

        FX3.BitBangSpiConfig = New BitBangSpiConfig(True)
        FX3.StreamTimeoutSeconds = 100000
        FX3.SetBitBangSpiFreq(0.9)

        Dim running As Boolean = True

        While running
            Try
                MsgBox(FX3.BitBangReadReg16(Convert.ToUInt32(InputBox("Read Address: "))).ToString("X4"))
            Catch ex As Exception
                running = False
            End Try

        End While

        FX3.RestoreHardwareSpi()

    End Sub

    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click

        Select Case btn_Connect.Text
            Case "Connect to FX3"
                btn_Connect.Text = "Reboot FX3"
                ConnectWork()
            Case "Reboot FX3"
                RebootFX3()
                btn_Connect.Text = "Connect to FX3"
        End Select

    End Sub

    Private Sub btn_SelectDUT_Click(sender As Object, e As EventArgs) Handles btn_SelectDUT.Click
        Dim subGUI As New SelectDUTGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        Hide()
    End Sub

    Private Sub btn_ResetDUT_Click(sender As Object, e As EventArgs) Handles btn_ResetDUT.Click
        FX3.Reset()
        TestDUT()
    End Sub

    Private Sub btn_RegAccess_Click(sender As Object, e As EventArgs) Handles btn_RegAccess.Click
        Dim subGUI As New RegisterGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_RegAccess.Enabled = False
    End Sub

    Private Sub btn_RealTime_Click(sender As Object, e As EventArgs) Handles btn_RealTime.Click

        If FX3.PartType = DUTType.IMU Then
            'For IMU's create a new IMU streaming GUI
            Dim subGUI As New IMUStreamingGUI()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
            Me.Hide()
        Else
            'For machine health create a ADcmXLStreamingGUI
            Dim subGUI As New ADcmXLStreamingGUI()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub btn_BulkRegRead_Click(sender As Object, e As EventArgs) Handles btn_BulkRegRead.Click


        If FX3.SensorType = DeviceType.IMU Then
            Dim subGUI As New RegisterBulkReadGUI()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
            Me.Hide()
        Else
            'For machine health create a ADcmXLStreamingGUI
            Dim subGUI As New ADcmXLBufferedLog()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btn_PinAccess_Click(sender As Object, e As EventArgs) Handles btn_PWMSetup.Click
        Dim subGUI As New PWMSetupGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_FX3Config_Click(sender As Object, e As EventArgs) Handles btn_FX3Config.Click
        Dim subGUI As New FX3ConfigGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_CheckDUTConnection_Click(sender As Object, e As EventArgs) Handles btn_CheckDUTConnection.Click
        TestDUT()
    End Sub

    Private Sub btn_BoardInfo_Click(sender As Object, e As EventArgs) Handles btn_BoardInfo.Click
        Dim fx3info As FX3Api.FX3Board = FX3.ActiveFX3
        MsgBox(fx3info.ToString())
    End Sub

    Private Sub btn_APIInfo_Click(sender As Object, e As EventArgs) Handles btn_APIInfo.Click
        Dim subGUI As New ApiInfoGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_plotFFT_Click(sender As Object, e As EventArgs) Handles btn_plotFFT.Click
        Dim subGUI As New FrequencyPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
    End Sub

    Private Sub btn_PinAccess_Click_1(sender As Object, e As EventArgs) Handles btn_PinAccess.Click
        Dim subGUI As New PinAccessGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_OtherApps_Click(sender As Object, e As EventArgs) Handles btn_OtherApps.Click
        Dim subGUI As New AppBrowseGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
    End Sub

    Private Sub btn_plotData_Click(sender As Object, e As EventArgs) Handles btn_plotData.Click
        Dim subGUI As New DataPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
    End Sub

#End Region

#Region "Other Event Handlers"

    ''' <summary>
    ''' This event handler is used to allow for asynchronous timeouts when reconnecting to an FX3 which was previously disconnected.
    ''' </summary>
    Private Sub timeoutHandler()
        m_disconnectTimer.Enabled = False
        'Timers run in a separate thread from GUI
        Me.BeginInvoke(New MethodInvoker(AddressOf updateTimeoutLabels))
    End Sub

    Public Sub Setup() Handles Me.Load
        Me.Top = My.Settings.LastTop
        Me.Left = My.Settings.LastLeft
    End Sub

    Private Sub Cleanup(sender As Object, e As EventArgs) Handles Me.Closing

        'Save settings
        My.Settings.DeviceType = FX3.PartType
        My.Settings.SensorType = FX3.SensorType
        My.Settings.LastLeft = Me.Left
        My.Settings.LastTop = Me.Top
        My.Settings.LastFilePath = lastFilePath
        My.Settings.SelectedRegMap = m_RegMapPath
        My.Settings.Save()

        'Disconnect the FX3 (does nothing if not already connected)
        FX3.Disconnect()

    End Sub

    'General exception handler
    Public Sub GeneralErrorHandler(sender As Object, e As UnhandledExceptionEventArgs)
        MsgBox("ERROR: Un-handled exception has occurred. " + e.ExceptionObject.ToString())
    End Sub

    ''' <summary>
    ''' Thread exception handler
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ThreadErrorHandler(sender As Object, e As ThreadExceptionEventArgs)
        MsgBox("ERROR: Un-handled thread exception has occurred. " + e.Exception.ToString())
    End Sub

    ''' <summary>
    ''' Event handler for when the board is unplugged
    ''' </summary>
    ''' <param name="FX3SerialNumber">Serial Number of the board which generated the event</param>
    Public Sub DisconnectHandler(FX3SerialNumber As String) Handles FX3.UnexpectedDisconnect

        'Reset GUI state
        FX3.Disconnect()
        m_FX3Connected = False
        'Disable buttons
        ResetButtons()

        'Special error message
        label_FX3Status.Text = "ERROR: FX3 Connection Lost"
        label_FX3Status.BackColor = Color.Red
        label_DUTStatus.Text = "ERROR: FX3 Connection Lost"
        label_DUTStatus.BackColor = Color.Red

        RaiseEvent UnexpectedDisconnect(FX3SerialNumber)

    End Sub

    ''' <summary>
    ''' When the disconnect event finishes re-enable the connect button if needed.
    ''' </summary>
    ''' <param name="FX3SN"></param>
    ''' <param name="DisconnectTime"></param>
    Public Sub DisconnectFinishedHandler(FX3SN As String, DisconnectTime As Integer) Handles FX3.DisconnectFinished
        btn_Connect.Enabled = True
        label_FX3Status.Text = "FX3 Reset"
        label_FX3Status.BackColor = Color.Yellow
        m_disconnectTimer.Enabled = False
    End Sub

#End Region

#Region "Helper Functions"

    Private Sub RebootFX3()

        'Send disconnect command
        FX3.Disconnect()
        ResetButtons()
        ResetLabels()
        btn_Connect.Enabled = False
        label_FX3Status.Text = "FX3 Rebooting"

        'Start a timeout counter
        m_disconnectTimer.Enabled = True

    End Sub

    ''' <summary>
    ''' Update the DUT (and labels) after changing the part 
    ''' </summary>
    ''' <param name="DutType"></param>
    Friend Sub UpdateDutLabel(DutType As DUTType)
        label_DUTType.BackColor = Color.Green
        label_DUTType.Text = FX3.SensorType.ToString() + ": " + FX3.PartType.ToString()

        'Set the DUT
        If FX3.PartType = DUTType.ADcmXL3021 Then
            Dut = New AdcmInterface3Axis(FX3)
        ElseIf FX3.PartType = DUTType.ADcmXL2021 Then
            Dut = New AdcmInterface2Axis(FX3)
        ElseIf FX3.PartType = DUTType.ADcmXL1021 Then
            Dut = New AdcmInterface1Axis(FX3)
        ElseIf FX3.PartType = DUTType.LegacyIMU Then
            Dut = New aducInterface(FX3, Nothing)
        ElseIf FX3.SensorType = DeviceType.AutomotiveSpi Then
            Dut = New ZeusInterface(m_AutoSpi, Nothing)
        Else
            Dut = New adbfInterface(FX3, Nothing)
        End If

        TestDUT()

    End Sub

    ''' <summary>
    ''' Perform all work to connect to and program an FX3
    ''' </summary>
    Private Sub ConnectWork()
        Dim selectedFX3SN As String = Nothing
        m_FX3Connected = False
        'Wait for boards
        FX3.WaitForBoard(1)
        'If only one board use that one
        If FX3.AvailableFX3s.Count = 1 Then
            selectedFX3SN = FX3.AvailableFX3s(0)
        ElseIf FX3.AvailableFX3s.Count > 1 Then
            'Get the serial number from the selectFX3 GUI (sets the active FX3 serial number)
            Dim subGUI As New SelectFX3GUI()
            subGUI.SetTopGUI(Me)
            subGUI.ShowDialog()
            selectedFX3SN = FX3.ActiveFX3SerialNumber
        ElseIf FX3.BusyFX3s.Count > 0 Then
            'FX3s are already running the application firmware
            If ResetAllFX3s() Then
                btn_Connect.Enabled = False
                'Restart connect recursively
                FX3.WaitForBoard(10)
                ConnectWork()
                Exit Sub
            Else
                label_FX3Status.BackColor = Color.Red
                label_FX3Status.Text = "ERROR: All FX3s in Use"
                btn_Connect.Text = "Connect to FX3"
            End If
        Else
            label_FX3Status.BackColor = Color.Red
            label_FX3Status.Text = "ERROR: No FX3 connected"
            btn_Connect.Text = "Connect to FX3"
            Exit Sub
        End If

        'Connect
        If Not IsNothing(selectedFX3SN) Then
            FX3.Connect(selectedFX3SN)
            m_disconnectTimer.Enabled = False
            m_FX3Connected = True
        Else
            MsgBox("ERROR: Invalid FX3 serial number selected")
            Exit Sub
        End If

        btn_APIInfo.Enabled = True
        btn_BoardInfo.Enabled = True
        btn_BulkRegRead.Enabled = True
        btn_CheckDUTConnection.Enabled = True
        btn_Connect.Enabled = True
        btn_FX3Config.Enabled = True
        btn_PWMSetup.Enabled = True
        btn_RealTime.Enabled = True
        btn_RegAccess.Enabled = True
        btn_ResetDUT.Enabled = True
        btn_SelectDUT.Enabled = True
        btn_plotFFT.Enabled = True
        btn_PinAccess.Enabled = True
        btn_OtherApps.Enabled = True
        btn_plotData.Enabled = True

        label_FX3Status.Text = "Connected to " + [Enum].GetName(GetType(FX3BoardType), FX3.ActiveFX3.BoardType) + " (SN: " + FX3.ActiveFX3SerialNumber + ")"
        label_FX3Status.BackColor = Color.Green

        'Select register access button initially
        btn_RegAccess.Select()

        'Load settings
        FX3.SensorType = My.Settings.SensorType
        FX3.PartType = My.Settings.DeviceType

        'disable watchdog
        FX3.WatchdogEnable = False

        'Test the DUT
        UpdateDutLabel(FX3.PartType)

    End Sub

    ''' <summary>
    ''' Reset all connected FX3 boards
    ''' </summary>
    ''' <returns>The success of the reset operation</returns>
    Private Function ResetAllFX3s() As Boolean
        Dim answer = MsgBox("This will reset all " + FX3.BusyFX3s.Count.ToString() + " connected FX3 board(s). Are you sure you want to continue?", MsgBoxStyle.OkCancel)
        If answer <> MsgBoxResult.Ok Then
            Return False
        End If
        btn_Connect.Enabled = False
        label_FX3Status.Text = "Resetting all FX3 board(s)"
        FX3.ResetAllFX3s()
        'Spin up async timer to check the device list
        m_disconnectTimer.Enabled = True
        Return True
    End Function

    ''' <summary>
    ''' Resets all buttons to their default state when the GUI loads
    ''' </summary>
    Private Sub ResetButtons()
        btn_APIInfo.Enabled = False
        btn_BoardInfo.Enabled = False
        btn_BulkRegRead.Enabled = False
        btn_CheckDUTConnection.Enabled = False
        btn_Connect.Enabled = True 'Connect should be enabled by default
        btn_Connect.Text = "Connect to FX3"
        btn_FX3Config.Enabled = False
        btn_PWMSetup.Enabled = False
        btn_RealTime.Enabled = False
        btn_RegAccess.Enabled = False
        btn_ResetDUT.Enabled = False
        btn_SelectDUT.Enabled = False
        btn_plotFFT.Enabled = False
        btn_PinAccess.Enabled = False
        btn_OtherApps.Enabled = False
        btn_plotData.Enabled = False
    End Sub

    ''' <summary>
    ''' Resets all labels to their default state when the GUI loads
    ''' </summary>
    Private Sub ResetLabels()
        label_DUTStatus.Text = "Waiting for FX3 to connect"
        label_DUTStatus.BackColor = Color.Yellow
        label_FX3Status.Text = "Not Connected"
        label_FX3Status.BackColor = Color.Yellow
        label_DUTType.BackColor = Color.Green
        label_DUTType.Text = FX3.SensorType.ToString() + ": " + FX3.PartType.ToString()
    End Sub

    ''' <summary>
    ''' Sets the labels when a timeout event occurs
    ''' </summary>
    Private Sub updateTimeoutLabels()
        ResetButtons()
        ResetLabels()
        label_FX3Status.Text = "Error: Disconnect timed out"
        label_FX3Status.BackColor = Color.Red
    End Sub

    ''' <summary>
    ''' Performs a write and read back test on the user scratch register of the connected DUT
    ''' </summary>
    Private Sub TestDUT()

        'Exit if FX3 not connected
        If Not m_FX3Connected Then
            label_DUTStatus.Text = "Waiting for FX3 to Connect"
            label_DUTStatus.BackColor = Color.Yellow
        End If

        'Check that the ready pin is high
        If FX3.PulseWait(FX3.DrPin, 1, 0, 500) > 500 Then
            label_DUTStatus.Text = "ERROR: DUT data ready pin not active"
            label_DUTStatus.BackColor = Color.Red
            Exit Sub
        End If

        Dim scratchReg As RegClass = Nothing
        Dim scratchRegNames() As String = {"USER_SCRATCH", "USER_SCR1", "USER_SCR_2", "USER_SCR_1", "USER_SCRATCH_1", "ALM_MAG1"}

        For Each regName In scratchRegNames
            If RegMap.Contains(regName) Then
                scratchReg = RegMap(regName)
                Exit For
            End If
        Next

        If IsNothing(scratchReg) Then
            label_DUTStatus.Text = "ERROR: No Scratch Register in RegMap"
            label_DUTStatus.BackColor = Color.Red
            Exit Sub
        End If

        Dim randomValue As UInteger = CInt(Math.Ceiling(Rnd() * &HFFF)) + 1

        Dim orignalScratch As UInteger = Dut.ReadUnsigned(scratchReg)

        Dut.WriteUnsigned(scratchReg, randomValue)
        If Not Dut.ReadUnsigned(scratchReg) = randomValue Then
            label_DUTStatus.Text = "ERROR: DUT Read/Write Failed"
            label_DUTStatus.BackColor = Color.Red
        Else
            label_DUTStatus.Text = "DUT Connected"
            label_DUTStatus.BackColor = Color.Green
        End If

        Dut.WriteUnsigned(scratchReg, orignalScratch)

    End Sub

    Private Sub report_issue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles report_issue.LinkClicked
        report_issue.LinkVisited = True
        System.Diagnostics.Process.Start("https://github.com/juchong/iSensor-FX3-ExampleGui/issues/new")
    End Sub

#End Region

End Class