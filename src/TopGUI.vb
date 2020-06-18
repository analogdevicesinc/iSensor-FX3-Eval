'File:          TopGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Top level GUI for the FX3 iSensor eval application

Imports FX3Api
Imports adisInterface
Imports RegMapClasses
Imports System.IO
Imports System.Reflection
Imports System.Timers
Imports System.Threading
Imports System.Net
Imports System.Web.Script.Serialization

Public Class TopGUI

    'Global colors for application
    Public GOOD_COLOR As Color = Color.Chartreuse
    Public ERROR_COLOR As Color = Color.Red
    Public IDLE_COLOR As Color = Color.Yellow
    Public BACK_COLOR As Color = SystemColors.Control

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
    Friend m_AutoSpi As iSensorAutomotiveSpi

    Public Sub New()

        ' This call is required by the designer.'
        InitializeComponent()

        Me.Text = "iSensor FX3 Eval"

        Dim firmwarePath As String
        Dim blinkFirmwarePath As String
        Dim flashProgrammerPath As String

        'Create a local copy of embedded firmware file
        Dim firmwareResource As String = "iSensorFX3Eval.FX3_Firmware.img"
        firmwarePath = System.Reflection.Assembly.GetExecutingAssembly.Location
        firmwarePath = firmwarePath.Substring(0, firmwarePath.LastIndexOf("\") + 1)
        firmwarePath = firmwarePath + "FX3_Firmware.img"
        Dim assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim outputStream As New FileStream(firmwarePath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Create a local copy of bootloader firmware file
        firmwareResource = "iSensorFX3Eval.boot_fw.img"
        blinkFirmwarePath = System.Reflection.Assembly.GetExecutingAssembly.Location
        blinkFirmwarePath = blinkFirmwarePath.Substring(0, blinkFirmwarePath.LastIndexOf("\") + 1)
        blinkFirmwarePath = blinkFirmwarePath + "boot_fw.img"
        assembly = Assembly.GetExecutingAssembly()
        outputStream = New FileStream(blinkFirmwarePath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Create a local copy of the flash programmer
        firmwareResource = "iSensorFX3Eval.USBFlashProg.img"
        flashProgrammerPath = System.Reflection.Assembly.GetExecutingAssembly.Location
        flashProgrammerPath = flashProgrammerPath.Substring(0, flashProgrammerPath.LastIndexOf("\") + 1)
        flashProgrammerPath = flashProgrammerPath + "USBFlashProg.img"
        assembly = System.Reflection.Assembly.GetExecutingAssembly()
        outputStream = New FileStream(flashProgrammerPath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'load colors from settings
        GOOD_COLOR = My.Settings.GoodColor
        ERROR_COLOR = My.Settings.ErrorColor
        IDLE_COLOR = My.Settings.IdleColor
        BACK_COLOR = My.Settings.BackColor

        'apply back color
        Me.BackColor = BACK_COLOR

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

        'Set FX3 connection (defaults to IMU)
        FX3 = New FX3Connection(firmwarePath, blinkFirmwarePath, flashProgrammerPath, DeviceType.IMU)

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
        m_AutoSpi.LogExceptions = True

        'Set the API version and build date
        label_apiVersion.Text = "ADI iSensor FX3 Eval GUI v" + Application.ProductVersion

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
        tip0.SetToolTip(Me.btn_BoardInfo, "Get information about the connected FX3 board")
        tip0.SetToolTip(Me.btn_BulkRegRead, "Stream register values to a .CSV file")
        tip0.SetToolTip(Me.btn_CheckDUTConnection, "Check the SPI connection to the DUT by writing a random value to user scratch and reading it back. Restores the original user scratch register value afterwards")
        tip0.SetToolTip(Me.btn_Connect, "Connect or disconnect from an iSensor FX3 Demonstration Platform")
        tip0.SetToolTip(Me.btn_FX3Config, "View or set all FX3 configuration options (sclk, stall time, etc)")
        tip0.SetToolTip(Me.btn_plotFFT, "Stream and plot frequency domain DUT data in real time")
        tip0.SetToolTip(Me.btn_OtherApps, "Other misc. applications developed for the iSensor FX3 Eval GUI")
        tip0.SetToolTip(Me.btn_SelectDUT, "Select the DUT type. Loads the default values for that DUT type")
        tip0.SetToolTip(Me.btn_RealTime, "Real time stream GUI (for ADcmXL type DUTs) or burst stream GUI (for all other DUTs)")
        tip0.SetToolTip(Me.btn_RegAccess, "Read or write all registers in the loaded register map")
        tip0.SetToolTip(Me.btn_plotData, "Plot DUT data in real time, or play back a DUT stream from a saved CSV file")
        tip0.SetToolTip(Me.btn_PinAccess, "Read or set all FX3 digital IO pins (DIO1 - DIO4, FX3GPIO1 - FX3GPIO4)")
        tip0.SetToolTip(Me.btn_PWMSetup, "Configure PWM signal generation on the FX3 digital IO")
        tip0.SetToolTip(Me.label_apiVersion, "The current version of the iSensor FX3 Eval GUI. The three highest version numbers will match the FX3 API version in use")
        tip0.SetToolTip(Me.regMapPath_Label, "The loaded register map file: " + RegMapPath)
        tip0.SetToolTip(Me.report_issue, "Report an issue with the iSensor FX3 Eval GUI. Requires a Internet connection and a GitHub account")
        tip0.SetToolTip(Me.btn_ResetDUT, "Drives the reset pin low for 500ms, waits for data ready to be asserted, and checks the DUT connection")
        tip0.SetToolTip(Me.checkVersion, "Checks for the latest release of the iSensor-FX3-GUI. Requires Internet connection")

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
                MsgBox("ERROR: Invalid RegMap Selected! " + ex.Message() + " " + RegMap.ErrorText)
            End Try
        End Set
    End Property

#End Region

#Region "Button Event Handlers"

    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click

        Select Case btn_Connect.Text
            Case "Connect to FX3"
                btn_Connect.Text = "Connecting to FX3..."
                ConnectWork()
            Case "Reboot FX3"
                Dim result = MessageBox.Show("This will reboot the FX3 and close all running applications. Are you sure you wish to continue?", "Reboot FX3", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
                If result = DialogResult.Yes Then
                    CloseAllForms()
                    RebootFX3()
                    btn_Connect.Text = "Connect to FX3"
                End If
        End Select

    End Sub

    Private Sub btn_SelectDUT_Click(sender As Object, e As EventArgs) Handles btn_SelectDUT.Click
        Dim subGUI As New SelectDUTGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_SelectDUT.Enabled = False
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

        If FX3.PartType = DUTType.IMU Or FX3.SensorType = DeviceType.IMU Then
            'For IMU's create a new IMU streaming GUI
            Dim subGUI As New IMUStreamingGUI()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
        Else
            'For machine health create a ADcmXLStreamingGUI
            Dim subGUI As New ADcmXLStreamingGUI()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
        End If

        'disable button
        btn_RealTime.Enabled = False

    End Sub

    Private Sub btn_BulkRegRead_Click(sender As Object, e As EventArgs) Handles btn_BulkRegRead.Click

        If FX3.PartType = DUTType.IMU Or FX3.SensorType = DeviceType.IMU Then
            Dim subGUI As New RegisterBulkReadGUI()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
        Else
            'For machine health create a ADcmXLStreamingGUI
            Dim subGUI As New ADcmXLBufferedLog()
            subGUI.SetTopGUI(Me)
            subGUI.Show()
        End If

        'disable button
        btn_BulkRegRead.Enabled = False

    End Sub


    Private Sub btn_PWMSetup_Click(sender As Object, e As EventArgs) Handles btn_PWMSetup.Click
        Dim subGUI As New PWMSetupGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_PWMSetup.Enabled = False
    End Sub

    Private Sub btn_FX3Config_Click(sender As Object, e As EventArgs) Handles btn_FX3Config.Click
        Dim subGUI As New FX3ConfigGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_FX3Config.Enabled = False
    End Sub

    Private Sub btn_CheckDUTConnection_Click(sender As Object, e As EventArgs) Handles btn_CheckDUTConnection.Click
        TestDUT()
    End Sub

    Private Sub btn_BoardInfo_Click(sender As Object, e As EventArgs) Handles btn_BoardInfo.Click
        MsgBox(FX3.ActiveFX3.ToString())
    End Sub

    Private Sub btn_APIInfo_Click(sender As Object, e As EventArgs) Handles btn_APIInfo.Click
        Dim subGUI As New ApiInfoGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_APIInfo.Enabled = False
    End Sub

    Private Sub btn_plotFFT_Click(sender As Object, e As EventArgs) Handles btn_plotFFT.Click
        Dim subGUI As New FrequencyPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_plotFFT.Enabled = False
    End Sub

    Private Sub btn_PinAccess_Click(sender As Object, e As EventArgs) Handles btn_PinAccess.Click
        Dim subGUI As New PinAccessGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_PinAccess.Enabled = False
    End Sub

    Private Sub btn_OtherApps_Click(sender As Object, e As EventArgs) Handles btn_OtherApps.Click
        Dim subGUI As New AppBrowseGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_OtherApps.Enabled = False
    End Sub

    Private Sub btn_plotData_Click(sender As Object, e As EventArgs) Handles btn_plotData.Click

        Dim subGUI As New DataPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_plotData.Enabled = False

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
        'check screen settings
        Dim goodLoc As Boolean = False
        Dim screens As Screen() = Screen.AllScreens
        Dim formRect As Rectangle = New Rectangle(My.Settings.LastLeft, My.Settings.LastTop, Me.Width, Me.Height)
        For Each screen In screens
            If screen.WorkingArea.Contains(formRect) Then
                goodLoc = True
            End If
        Next
        If goodLoc Then
            Me.Top = My.Settings.LastTop
            Me.Left = My.Settings.LastLeft
        ElseIf screens.Count > 0 Then
            Me.Top = (screens(0).WorkingArea.Height / 2) - (Me.Height / 2)
            Me.Left = (screens(0).WorkingArea.Width / 2) - (Me.Width / 2)
        Else
            MsgBox("ERROR: This application requires a screen to function properly...")
        End If

    End Sub

    Private Sub Cleanup(sender As Object, e As EventArgs) Handles Me.Closing

        SaveAppSettings()

        'close all other forms
        CloseAllForms()

        'Disconnect the FX3 (does nothing if not already connected)
        FX3.Disconnect()

    End Sub

    ''' <summary>
    ''' Save app settings
    ''' </summary>
    Friend Sub SaveAppSettings()
        'Save settings
        My.Settings.DeviceType = FX3.PartType
        My.Settings.SensorType = FX3.SensorType
        My.Settings.LastLeft = Me.Left
        My.Settings.LastTop = Me.Top
        My.Settings.LastFilePath = lastFilePath
        My.Settings.SelectedRegMap = m_RegMapPath
        My.Settings.GoodColor = GOOD_COLOR
        My.Settings.ErrorColor = ERROR_COLOR
        My.Settings.IdleColor = IDLE_COLOR
        My.Settings.BackColor = BACK_COLOR
        My.Settings.Save()
    End Sub

    'General exception handler
    Public Sub GeneralErrorHandler(sender As Object, e As UnhandledExceptionEventArgs)
        Dim ex As Exception = DirectCast(e.ExceptionObject, Exception)
        LogError(ex)
    End Sub

    ''' <summary>
    ''' Thread exception handler. Calls error logger with base exception
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Sub ThreadErrorHandler(sender As Object, e As ThreadExceptionEventArgs)
        LogError(e.Exception)
    End Sub

    Private Sub LogError(e As Exception)

        If TypeOf (e) Is SpiException Then
            MsgBox("ERROR: Automotive SPI protocol exception has occurred - is the DUT connected properly? " + e.Message)
            Exit Sub
        End If

        Static firstException As Boolean = True
        Dim exStr As String
        Dim currentTime As Date = Date.Now()
        Dim currentTimeStr As String = currentTime.ToString("s")
        Dim FX3Uptime As String = "ERROR"
        Dim FX3SN As String = "ERROR"
        Dim FX3BoardType As String = "ERROR"
        If Not firstException Then
            'force kill after first exception
            Environment.Exit(1)
        Else
            'set first exception flag to false (static means is persistent through calls)
            firstException = False
        End If
        If Not IsNothing(FX3) Then
            If Not IsNothing(FX3.ActiveFX3) Then
                FX3Uptime = FX3.ActiveFX3.Uptime.ToString() + "ms"
                FX3SN = FX3.ActiveFX3.SerialNumber
                FX3BoardType = [Enum].GetName(GetType(FX3BoardType), FX3.ActiveFX3.BoardType)
            End If
        End If
        currentTimeStr = currentTimeStr.Replace(":", "-")
        Dim logPath As String = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "Analog Devices", "iSensorFX3Eval")
        'check dir
        If Not Directory.Exists(logPath) Then
            Directory.CreateDirectory(logPath)
        End If
        'check file
        logPath = Path.Combine(logPath, "ERROR_LOG.csv")
        If Not File.Exists(logPath) Then
            File.WriteAllLines(logPath, {"DATE,USER,OS,REGMAP,FX3VERSION,FX3UPTIME,FX3SN,FX3TYPE,EXCEPTION"})
        End If
        'log error
        exStr = e.ToString()
        exStr = exStr.Replace(Environment.NewLine, " ")
        exStr = exStr.Replace(",", " ")
        File.AppendAllLines(logPath, {currentTimeStr + "," +
                            Environment.UserName + "," +
                            Environment.OSVersion.ToString() + "," +
                            RegMapPath + "," +
                            Application.ProductVersion + "," +
                            FX3Uptime + "," +
                            FX3SN + "," +
                            FX3BoardType + "," +
                            exStr})
        MsgBox("ERROR: Un-handled exception has occurred. Detailed data has been stored at " + logPath)
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
        label_FX3Status.BackColor = ERROR_COLOR
        label_DUTStatus.Text = "ERROR: FX3 Connection Lost"
        label_DUTStatus.BackColor = ERROR_COLOR

        Show()
        BringToFront()

    End Sub

    ''' <summary>
    ''' When the disconnect event finishes re-enable the connect button if needed.
    ''' </summary>
    ''' <param name="FX3SN"></param>
    ''' <param name="DisconnectTime"></param>
    Public Sub DisconnectFinishedHandler(FX3SN As String, DisconnectTime As Integer) Handles FX3.DisconnectFinished
        btn_Connect.Enabled = True
        label_FX3Status.Text = "FX3 Reset"
        label_FX3Status.BackColor = IDLE_COLOR
        m_disconnectTimer.Enabled = False
    End Sub

#End Region

#Region "Helper Functions"

    ''' <summary>
    ''' Loads default color scheme
    ''' </summary>
    Friend Sub LoadDefaultColors()

        GOOD_COLOR = Color.Chartreuse
        ERROR_COLOR = Color.Red
        IDLE_COLOR = Color.Yellow
        BACK_COLOR = SystemColors.Control

        Me.BackColor = BACK_COLOR

    End Sub

    Private Sub RebootFX3()

        'Send disconnect command
        FX3.Disconnect()
        ResetButtons()
        ResetLabels()
        btn_Connect.Enabled = False
        label_FX3Status.Text = "FX3 Rebooting..."

        'Start a timeout counter
        m_disconnectTimer.Enabled = True

    End Sub

    ''' <summary>
    ''' Update the DUT (and labels) after changing the part 
    ''' </summary>
    ''' <param name="DutType"></param>
    Friend Sub UpdateDutLabel(DutType As DUTType)
        label_DUTType.BackColor = GOOD_COLOR
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
                label_FX3Status.BackColor = ERROR_COLOR
                label_FX3Status.Text = "ERROR: All FX3s in Use"
                btn_Connect.Text = "Connect to FX3"
            End If
        Else
            label_FX3Status.BackColor = ERROR_COLOR
            label_FX3Status.Text = "ERROR: No FX3 board connected"
            btn_Connect.Text = "Connect to FX3"
            Exit Sub
        End If

        'Connect
        If Not IsNothing(selectedFX3SN) Then
            FX3.Connect(selectedFX3SN)
            m_disconnectTimer.Enabled = False
            m_FX3Connected = True
        Else
            btn_Connect.Text = "Connect to FX3"
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
        label_FX3Status.BackColor = GOOD_COLOR
        btn_Connect.Text = "Reboot FX3"

        'Select register access button initially
        btn_RegAccess.Select()

        'Load settings
        FX3.SensorType = My.Settings.SensorType
        FX3.PartType = My.Settings.DeviceType

        'disable watchdog
        FX3.WatchdogEnable = False

        'Test the DUT
        UpdateDutLabel(FX3.PartType)

        'disable buttons for any existing open forms
        DisableOpenFormButtons()

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
        label_FX3Status.BackColor = IDLE_COLOR
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
        label_DUTStatus.BackColor = IDLE_COLOR
        label_FX3Status.Text = "Not Connected"
        label_FX3Status.BackColor = IDLE_COLOR
        label_DUTType.BackColor = GOOD_COLOR
        label_DUTType.Text = FX3.SensorType.ToString() + ": " + FX3.PartType.ToString()
    End Sub

    ''' <summary>
    ''' Sets the labels when a timeout event occurs
    ''' </summary>
    Private Sub updateTimeoutLabels()
        ResetButtons()
        ResetLabels()
        label_FX3Status.Text = "Error: Disconnect timed out"
        label_FX3Status.BackColor = ERROR_COLOR
    End Sub

    ''' <summary>
    ''' Performs a write and read back test on the user scratch register of the connected DUT
    ''' </summary>
    Private Sub TestDUT()

        'Exit if FX3 not connected
        If Not m_FX3Connected Then
            label_DUTStatus.Text = "Waiting for FX3 to Connect"
            label_DUTStatus.BackColor = IDLE_COLOR
        End If

        'Check that the ready pin is high
        If FX3.DrActive Then
            If FX3.PulseWait(FX3.DrPin, 1, 0, 500) > 500 Then
                label_DUTStatus.Text = "ERROR: DUT data ready pin not active"
                label_DUTStatus.BackColor = ERROR_COLOR
                Exit Sub
            End If
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
            label_DUTStatus.BackColor = ERROR_COLOR
            Exit Sub
        End If

        Dim randomValue As UInteger = CInt(Math.Ceiling(Rnd() * &HFFF)) + 1

        Dim orignalScratch As UInteger = Dut.ReadUnsigned(scratchReg)

        Dut.WriteUnsigned(scratchReg, randomValue)
        If Not Dut.ReadUnsigned(scratchReg) = randomValue Then
            label_DUTStatus.Text = "ERROR: DUT Read/Write Failed"
            label_DUTStatus.BackColor = ERROR_COLOR
        Else
            label_DUTStatus.Text = "DUT Connected"
            label_DUTStatus.BackColor = GOOD_COLOR
        End If

        Dut.WriteUnsigned(scratchReg, orignalScratch)

    End Sub

    Private Sub CloseAllForms()
        Dim openForms As New List(Of Form)
        For Each form In Application.OpenForms
            If Not ReferenceEquals(Me, form) Then
                openForms.Add(form)
            End If
        Next
        For Each runningForm As Form In openForms
            If Me.InvokeRequired Then
                Me.BeginInvoke(Sub() runningForm.Close())
            Else
                runningForm.Close()
            End If
        Next
    End Sub

    Private Sub DisableOpenFormButtons()
        For Each openForm As Form In Application.OpenForms
            If TypeOf (openForm) Is FX3ConfigGUI Then btn_FX3Config.Enabled = False
            If TypeOf (openForm) Is RegisterBulkReadGUI Then btn_BulkRegRead.Enabled = False
            If TypeOf (openForm) Is ApiInfoGUI Then btn_APIInfo.Enabled = False
            If TypeOf (openForm) Is FrequencyPlotGUI Then btn_plotFFT.Enabled = False
            If TypeOf (openForm) Is DataPlotGUI Then btn_plotData.Enabled = False
            If TypeOf (openForm) Is IMUStreamingGUI Then btn_RealTime.Enabled = False
            If TypeOf (openForm) Is ADcmXLStreamingGUI Then btn_RealTime.Enabled = False
            If TypeOf (openForm) Is PinAccessGUI Then btn_PinAccess.Enabled = False
            If TypeOf (openForm) Is SelectDUTGUI Then btn_SelectDUT.Enabled = False
            If TypeOf (openForm) Is PWMSetupGUI Then btn_PWMSetup.Enabled = False
            If TypeOf (openForm) Is AppBrowseGUI Then btn_OtherApps.Enabled = False
            If TypeOf (openForm) Is RegisterGUI Then btn_RegAccess.Enabled = False
        Next
    End Sub

    Private Sub checkVersion_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles checkVersion.LinkClicked
        checkVersion.LinkVisited = True

        Dim response As WebResponse
        Dim request As HttpWebRequest
        Dim content As Dictionary(Of String, Object)
        Dim contentStr As String
        Dim parser As New JavaScriptSerializer()
        Dim newestVersion, currentVersion As Version
        Dim promptResult As MsgBoxResult

        'get response
        Try
            ServicePointManager.Expect100Continue = True
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
            request = WebRequest.Create("https://api.github.com/repos/juchong/iSensor-FX3-Eval/releases/latest")
            request.ContentType = "application/json"
            request.UserAgent = "request"
            request.Method = "GET"
            request.Accept = "application/json"
            response = request.GetResponse()
        Catch ex As Exception
            MsgBox("Error communicating with GitHub: " + ex.Message)
            Exit Sub
        End Try

        'get content
        Using reader As StreamReader = New StreamReader(response.GetResponseStream())
            contentStr = reader.ReadToEnd()
        End Using

        'parse JSON
        Try
            content = parser.Deserialize(Of Dictionary(Of String, Object))(contentStr)
            contentStr = content("tag_name").ToString()
            contentStr = contentStr.Replace("-pub", "")
            contentStr = contentStr.Replace("v", "")
            newestVersion = Version.Parse(contentStr)
        Catch ex As Exception
            MsgBox("Error: Failed to parse HTTP response: " + ex.Message)
            Exit Sub
        End Try

        'get version of application and latest
        currentVersion = Version.Parse(Me.ProductVersion)
        If currentVersion.CompareTo(newestVersion) < 0 Then
            promptResult = MsgBox("Version " + content("tag_name").ToString() + " available. Download now?", MsgBoxStyle.YesNo)
        Else
            MsgBox("Already up to date! Latest version: " + content("tag_name").ToString())
            Exit Sub
        End If

        If promptResult <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        'get the url to the zip resource to download and open in browser
        Dim proc = New Process()
        Dim assets As ArrayList = DirectCast(content("assets"), ArrayList)
        proc.StartInfo.UseShellExecute = True
        proc.StartInfo.FileName = assets(0)("browser_download_url")
        proc.Start()

    End Sub

    Private Sub report_issue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles report_issue.LinkClicked
        report_issue.LinkVisited = True
        System.Diagnostics.Process.Start("https://github.com/juchong/iSensor-FX3-Eval/issues/new")
    End Sub

#End Region

End Class