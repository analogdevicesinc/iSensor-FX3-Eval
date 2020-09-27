'File:          TopGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Top level GUI for the FX3 iSensor eval application

Imports FX3Api
Imports adisInterface
Imports RegMapClasses
Imports System.IO
Imports System.Timers
Imports System.Threading
Imports System.Net
Imports System.Web.Script.Serialization
Imports AdisApi

Public Class TopGUI

#Region "Variables"

    'Global colors for application
    Public GOOD_COLOR As Color = Color.Chartreuse
    Public ERROR_COLOR As Color = Color.Red
    Public IDLE_COLOR As Color = Color.Yellow
    Public BACK_COLOR As Color = SystemColors.Control

    'Public member variables accessible to all forms
    Public WithEvents FX3 As FX3Connection
    Public RegMap As RegMapCollection
    Public Dut As IDutInterface

    'dut settings management
    Friend SelectedPersonality As String
    Friend DutOptions As List(Of DutPersonality)

    'List of listviewitems for bulk register read
    Friend BulkRegList As List(Of ListViewItem)
    Friend numRegSamples As Integer
    Friend samplesPerWrite As Integer
    Friend linesPerFile As Integer

    'data visualization color palette
    Friend PlotColorPalette As List(Of Color)

    'plotting register lists
    Friend dataPlotRegs As New List(Of String)
    Friend fftPlotRegs As New List(Of String)

    'Last browsed to file location
    Public lastFilePath As String

    'Private member variables
    Private m_FX3Connected As Boolean
    Private WithEvents m_disconnectTimer As Timers.Timer
    Private m_RegMapPath As String
    Friend m_AutoSpi As iSensorAutomotiveSpi

#End Region

#Region "Constructor/Load"

    Public Sub New()

        'This call is required by the designer
        InitializeComponent()

    End Sub

    Public Sub Setup() Handles Me.Load

        Dim firmwarePath As String
        Dim colorPath As String
        Dim colors As String()
        Dim validPersonality As Boolean

        Me.Text = "iSensor FX3 Eval"

        'set up timers for regview
        pageReadTimer = New System.Timers.Timer(500)
        pageReadTimer.Enabled = False
        AddHandler pageReadTimer.Elapsed, New ElapsedEventHandler(AddressOf PageReadCallback)

        drReadTimer = New System.Timers.Timer(750)
        drReadTimer.Enabled = False
        AddHandler drReadTimer.Elapsed, New ElapsedEventHandler(AddressOf DrReadCallBack)

        'firmware images should be in executing assembly directory
        firmwarePath = AppDomain.CurrentDomain.BaseDirectory + "FX3Binaries\"

        'Set FX3 connection (defaults to IMU)
        Try
            FX3 = New FX3Connection(firmwarePath, firmwarePath, firmwarePath, DeviceType.IMU)
        Catch ex As Exception
            MsgBox("Error loading resources! " + ex.Message)
        End Try

        'load colors from settings
        GOOD_COLOR = My.Settings.GoodColor
        ERROR_COLOR = My.Settings.ErrorColor
        IDLE_COLOR = My.Settings.IdleColor
        BACK_COLOR = My.Settings.BackColor

        'apply back color
        Me.BackColor = BACK_COLOR
        For Each formPage As TabPage In dut_access.TabPages
            formPage.BackColor = BACK_COLOR
        Next

        'load plotting color palette
        colorPath = AppDomain.CurrentDomain.BaseDirectory + "UserConfig\plot_colors.txt"
        PlotColorPalette = New List(Of Color)
        Try
            colors = File.ReadAllLines(colorPath)
            For Each color In colors
                PlotColorPalette.Add(ColorTranslator.FromHtml("#" + color))
            Next
        Catch ex As Exception
            'squash
        End Try

        'load dut personality settings
        SelectedPersonality = My.Settings.DutPersonality

        'load DUT personality file(s)
        DutOptions = DutPersonality.ParseFile(AppDomain.CurrentDomain.BaseDirectory + "UserConfig\custom_personality.csv")
        If DutOptions.Count = 0 Then
            'generate custom personality
            SaveCustomPersonality()
            DutOptions.Add(New DutPersonality())
        End If
        DutOptions.AddRange(DutPersonality.ParseFile(AppDomain.CurrentDomain.BaseDirectory + "UserConfig\dut_personalities.csv"))
        DutOptions.AddRange(DutPersonality.ParseFile(AppDomain.CurrentDomain.BaseDirectory + "UserConfig\aux_dut_personalities.csv"))

        'load personality based on last selection
        validPersonality = False
        For Each item In DutOptions
            If item.DisplayName = SelectedPersonality Then
                validPersonality = True
                Exit For
            End If
        Next
        If Not validPersonality Then
            Dim subGUI As New SelectDUTGUI()
            subGUI.SetTopGUI(Me)
            subGUI.isStartup = True
            subGUI.ShowDialog()
            'if valid personality not selected then override
            validPersonality = False
            For Each item In DutOptions
                If item.DisplayName = SelectedPersonality Then
                    validPersonality = True
                    Exit For
                End If
            Next
            'go to custom if none set
            If Not validPersonality Then SelectedPersonality = "Custom"
        End If

        'load regmap
        ApplyDutPersonalityRegmap(SelectedPersonality)

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

        'check screen settings
        Dim goodLoc As Boolean = False
        Dim screens As Screen() = Screen.AllScreens
        Dim formRect As Rectangle = New Rectangle(My.Settings.LastLeft, My.Settings.LastTop, My.Settings.LastWidth, My.Settings.LastHeight)
        For Each screen In screens
            If screen.WorkingArea.Contains(formRect) Then
                goodLoc = True
            End If
        Next
        If goodLoc Then
            Me.Top = My.Settings.LastTop
            Me.Left = My.Settings.LastLeft
            Me.Width = My.Settings.LastWidth
            Me.Height = My.Settings.LastHeight
        ElseIf screens.Count > 0 Then
            Me.Top = (screens(0).WorkingArea.Height / 2) - (Me.Height / 2)
            Me.Left = (screens(0).WorkingArea.Width / 2) - (Me.Width / 2)
        Else
            MsgBox("ERROR: This application requires a screen to function properly...")
        End If

    End Sub

#End Region

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
                RegFormSetup()
            Catch ex As Exception
                MsgBox("ERROR: Invalid RegMap Selected! " + ex.Message() + " " + RegMap.ErrorText)
            End Try
        End Set
    End Property

#End Region

#Region "Button Event Handlers"

    Private Sub btn_BurstTest_Click(sender As Object, e As EventArgs) Handles btn_BurstTest.Click
        Dim subGUI As New BurstTestGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_BurstTest.Enabled = False
    End Sub

    Private Sub btn_ADXL375_Click(sender As Object, e As EventArgs) Handles btn_ADXL375.Click
        Dim subGUI As New ADXl375GUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_ADXL375.Enabled = False
    End Sub

    Private Sub btn_pulseMeasure_Click(sender As Object, e As EventArgs) Handles btn_pulseMeasure.Click
        Dim subGUI As New PulseMeasureGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_pulseMeasure.Enabled = False
    End Sub

    Private Sub btn_binFile_Click(sender As Object, e As EventArgs) Handles btn_binFile.Click
        Dim subGUI As New BinaryFileWriterGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_binFile.Enabled = False
    End Sub

    Private Sub btn_checkError_Click(sender As Object, e As EventArgs) Handles btn_checkError.Click
        Dim subGUI As New FlashInterfaceGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_checkError.Enabled = False
    End Sub

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

    Private Sub btn_bitBangSPI_Click(sender As Object, e As EventArgs) Handles btn_BitBangSPI.Click
        Dim subGUI As New BitBangSpiGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_BitBangSPI.Enabled = False
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

    Private Sub btn_plotData_Click(sender As Object, e As EventArgs) Handles btn_plotData.Click

        Dim subGUI As New DataPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_plotData.Enabled = False

    End Sub

#End Region

#Region "Other Event Handlers"

    'handle app resize events
    Private Sub ResizeHandler() Handles Me.Resize
        'resize regview
        regView.Height = Me.Height - 351
        btn_DumpRegmap.Top = Me.Height - 362
        btn_writeRegMap.Top = Me.Height - 362

        'resize tab control
        dut_access.Height = Me.Height - 286

        'bottom labels need to move too
        label_apiVersion.Top = Me.Height - 79
        checkVersion.Top = Me.Height - 79
        report_issue.Top = Me.Height - 60
        regMapPath_Label.Top = Me.Height - 60
    End Sub

    ''' <summary>
    ''' This event handler is used to allow for asynchronous timeouts when reconnecting to an FX3 which was previously disconnected.
    ''' </summary>
    Private Sub timeoutHandler()
        m_disconnectTimer.Enabled = False
        'Timers run in a separate thread from GUI
        Me.BeginInvoke(New MethodInvoker(AddressOf updateTimeoutLabels))
    End Sub

    Private Sub Cleanup(sender As Object, e As EventArgs) Handles Me.Closing

        SaveAppSettings()

        'close all other forms
        CloseAllForms()

        'Disconnect the FX3 (does nothing if not already connected)
        FX3.Disconnect()

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

    Private Sub SaveCustomPersonality()

        Dim path As String = AppDomain.CurrentDomain.BaseDirectory + "UserConfig\custom_personality.csv"
        Dim personality As New DutPersonality()
        personality.DisplayName = "Custom"
        personality.RegMapFileName = RegMapPath
        If Not IsNothing(FX3.ActiveFX3) Then personality.GetSettingsFromFX3(FX3)

        'save to CSV
        DutPersonality.WriteToFile(path, personality)

    End Sub

    Private Sub SetupToolTips()

        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(Me.btn_APIInfo, "Get information about the version of the FX3 API being used, and the connected FX3 hardware")
        tip0.SetToolTip(Me.btn_BitBangSPI, "Bit-bang custom SPI traffic to a DUT")
        tip0.SetToolTip(Me.btn_BulkRegRead, "Stream register values to a .CSV file")
        tip0.SetToolTip(Me.btn_CheckDUTConnection, "Check the SPI connection to the DUT by writing a random value to user scratch and reading it back. Restores the original user scratch register value afterwards")
        tip0.SetToolTip(Me.btn_Connect, "Connect or disconnect from an iSensor FX3 Demonstration Platform")
        tip0.SetToolTip(Me.btn_FX3Config, "View or set all FX3 configuration options (sclk, stall time, etc)")
        tip0.SetToolTip(Me.btn_plotFFT, "Stream and plot frequency domain DUT data in real time")
        tip0.SetToolTip(Me.btn_SelectDUT, "Select the DUT type. Loads the default values for that DUT type")
        tip0.SetToolTip(Me.btn_RealTime, "Real time stream GUI (for ADcmXL type DUTs) or burst stream GUI (for all other DUTs)")
        tip0.SetToolTip(Me.btn_plotData, "Plot DUT data in real time, or play back a DUT stream from a saved CSV file")
        tip0.SetToolTip(Me.label_apiVersion, "The current version of the iSensor FX3 Eval GUI. The three highest version numbers will match the FX3 API version in use")
        tip0.SetToolTip(Me.regMapPath_Label, "The loaded register map file: " + RegMapPath)
        tip0.SetToolTip(Me.report_issue, "Report an issue with the iSensor FX3 Eval GUI. Requires a Internet connection and a GitHub account")
        tip0.SetToolTip(Me.btn_ResetDUT, "Drives the reset pin low for 500ms, waits for data ready to be asserted, and checks the DUT connection")
        tip0.SetToolTip(Me.checkVersion, "Checks for the latest release of the iSensor-FX3-GUI. Requires Internet connection")
        tip0.SetToolTip(Me.btn_ADXL375, "Stream data or access registers on an ADXL375")
        tip0.SetToolTip(Me.btn_pulseMeasure, "Measure a DIO pulse width. Can send a pin or register trigger condition")
        tip0.SetToolTip(Me.btn_BurstTest, "Test burst mode implementations with longer SPI transactions")
        tip0.SetToolTip(Me.btn_binFile, "Generate a binary data file filled with an arbitrary pattern")

    End Sub

    ''' <summary>
    ''' Save app settings
    ''' </summary>
    Friend Sub SaveAppSettings()
        'Save settings
        My.Settings.LastLeft = Me.Left
        My.Settings.LastTop = Me.Top
        My.Settings.LastWidth = Me.Width
        My.Settings.LastHeight = Me.Height
        My.Settings.LastFilePath = lastFilePath
        My.Settings.GoodColor = GOOD_COLOR
        My.Settings.ErrorColor = ERROR_COLOR
        My.Settings.IdleColor = IDLE_COLOR
        My.Settings.BackColor = BACK_COLOR
        My.Settings.LastFX3Board = FX3.ActiveFX3SerialNumber
        My.Settings.DutPersonality = SelectedPersonality
        My.Settings.Save()
        If SelectedPersonality = "Custom" Then
            SaveCustomPersonality()
        End If
    End Sub

    ''' <summary>
    ''' Friend getter for last connected FX3 board SN
    ''' </summary>
    ''' <returns></returns>
    Friend ReadOnly Property LastFX3SN As String
        Get
            Return My.Settings.LastFX3Board
        End Get
    End Property

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
        SetDUTTypeLabel()

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

        If Not IsNothing(FX3.ActiveFX3) Then TestDUT()

    End Sub

    Friend Sub ApplyDutPersonalityRegmap(displayName As String)

        Dim savedRegmapPath As String = ""

        'Set the regmap path using the SelectRegMap GUI
        For i As Integer = 0 To DutOptions.Count - 1
            If DutOptions(i).DisplayName = displayName Then
                If displayName = "Custom" Then
                    'custom uses absolute path
                    savedRegmapPath = DutOptions(i).RegMapFileName
                Else
                    savedRegmapPath = AppDomain.CurrentDomain.BaseDirectory + "RegMaps\" + DutOptions(i).RegMapFileName
                End If
                Exit For
            End If
        Next
        If Not File.Exists(savedRegmapPath) Then
            'go to custom personality and manually select regmap
            SelectedPersonality = "Custom"
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
            For i As Integer = 0 To DutOptions.Count - 1
                If DutOptions(i).DisplayName = "Custom" Then
                    DutOptions(i).RegMapFileName = RegMapPath
                End If
            Next
        Else
            RegMapPath = savedRegmapPath
        End If

    End Sub

    Friend Function ApplyDutPersonality(displayName As String) As Boolean

        Dim personality As DutPersonality = Nothing

        For i As Integer = 0 To DutOptions.Count - 1
            If displayName = DutOptions(i).DisplayName Then
                personality = DutOptions(i)
                Exit For
            End If
        Next

        If IsNothing(personality) Then
            MsgBox("ERROR: Selected DUT personality " + displayName + " not found!")
            Return False
        End If

        If personality.Supply = DutVoltage.On5_0Volts Then
            If MessageBox.Show("Enabling 5V supply can cause damage to 3.3V devices - Continue?", "Confirmation", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                Return False
            End If
        End If

        If personality.VDDIO <> 3.3 Then
            If MessageBox.Show("FX3 directly supports VDDIO of 3.3V, other values may cause damage - Continue?", "Confirmation", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                Return False
            End If
        End If

        If Not IsNothing(FX3.ActiveFX3) Then personality.ApplySettingsToFX3(FX3)

        SelectedPersonality = displayName

        Return True

    End Function

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

        'enable buttons
        btn_APIInfo.Enabled = True
        btn_CheckDUTConnection.Enabled = True
        btn_Connect.Enabled = True
        btn_FX3Config.Enabled = True
        btn_ResetDUT.Enabled = True
        btn_SelectDUT.Enabled = True
        dut_access.Enabled = True

        label_FX3Status.Text = "Connected to " + [Enum].GetName(GetType(FX3BoardType), FX3.ActiveFX3.BoardType) + " (SN: " + FX3.ActiveFX3SerialNumber + ")"
        label_FX3Status.BackColor = GOOD_COLOR
        btn_Connect.Text = "Reboot FX3"

        'Select DUT access panel initially
        dut_access.Select()

        'Load settings
        ApplyDutPersonality(SelectedPersonality)

        'disable watchdog
        FX3.WatchdogEnable = False

        'Test the DUT
        UpdateDutLabel(FX3.PartType)

        'disable buttons for any existing open forms
        DisableOpenFormButtons()

        'init pin tab
        PinTabInit()

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
        btn_CheckDUTConnection.Enabled = False
        btn_Connect.Enabled = True 'Connect should be enabled by default
        btn_Connect.Text = "Connect to FX3"
        btn_FX3Config.Enabled = False
        btn_ResetDUT.Enabled = False
        btn_SelectDUT.Enabled = False
        dut_access.Enabled = False
    End Sub

    ''' <summary>
    ''' Resets all labels to their default state when the GUI loads
    ''' </summary>
    Private Sub ResetLabels()
        label_DUTStatus.Text = "Waiting for FX3 to connect"
        label_DUTStatus.BackColor = IDLE_COLOR
        label_FX3Status.Text = "Not Connected"
        label_FX3Status.BackColor = IDLE_COLOR
        SetDUTTypeLabel()
    End Sub

    Private Sub SetDUTTypeLabel()
        label_DUTType.BackColor = GOOD_COLOR
        label_DUTType.Text = SelectedPersonality + " - " + FX3.SensorType.ToString() + ": " + FX3.PartType.ToString()
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

        Dim scratchReg As RegClass = Nothing
        Dim scratchRegNames() As String = {"USER_SCRATCH", "USER_SCR1", "USER_SCR_2", "USER_SCR_1", "USER_SCRATCH_1", "ALM_MAG1"}
        Dim drActive As Boolean = FX3.DrActive

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

        'make DR active false for this test
        FX3.DrActive = False

        'wait for DR to reach DR polarity level (500ms timeout)
        FX3.PulseWait(FX3.DrPin, FX3.DrPolarity, 100, 400)

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

        'restore dr active setting
        FX3.DrActive = drActive

    End Sub

    Private Sub CloseAllForms()
        Dim openForms As New List(Of Form)
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False
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
            If TypeOf (openForm) Is SelectDUTGUI Then btn_SelectDUT.Enabled = False
            If TypeOf (openForm) Is BurstTestGUI Then btn_BurstTest.Enabled = False
            If TypeOf (openForm) Is ADXl375GUI Then btn_ADXL375.Enabled = False
            If TypeOf (openForm) Is PulseMeasureGUI Then btn_pulseMeasure.Enabled = False
            If TypeOf (openForm) Is BinaryFileWriterGUI Then btn_binFile.Enabled = False
            If TypeOf (openForm) Is FlashInterfaceGUI Then btn_checkError.Enabled = False
        Next
    End Sub

#End Region

#Region "Register Access Form"

    Private pageList As List(Of Integer)
    Private pagePosition As List(Of Integer)
    Private lastPageIndex As Integer
    Private pageReadTimer As System.Timers.Timer
    Private drReadTimer As System.Timers.Timer
    Private drEnableTimer As System.Timers.Timer
    Private currentRegList As List(Of RegClass)
    Private scaleData As Boolean
    Private originalDRSetting As Boolean
    Private m_pageMessageList As List(Of Integer)

    Private Sub RegFormSetup()
        regView.ClearSelection()
        drActive.Checked = False
        scaleData = False
        numDecimals.Visible = False
        numDecimals_label.Visible = False
        validateSpiData.Checked = False
        validateSpiData.Visible = False
        contRead.Checked = False
        measureDr.Checked = False
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False

        'get list of pages
        pageList = New List(Of Integer)
        pagePosition = New List(Of Integer)
        selectPage.Items.Clear()
        For Each reg In RegMap
            If Not pageList.Contains(reg.Page) Then
                pageList.Add(reg.Page)
                pagePosition.Add(0) 'Start at top
                selectPage.Items.Add(reg.Page)
            End If
        Next

        'Set the selected index
        selectPage.SelectedIndex = 0
        lastPageIndex = 0
        m_pageMessageList = New List(Of Integer)

        'enable register value copying
        regView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText

        If Not IsNothing(FX3.ActiveFX3) Then
            'save setting and disable dr active reads
            originalDRSetting = FX3.DrActive
            FX3.DrActive = False

            'check if SPI data can be validated
            If FX3.SensorType = FX3Api.DeviceType.AutomotiveSpi Then
                validateSpiData.Visible = True
            Else
                validateSpiData.Visible = False
            End If

        End If

    End Sub

    Private Sub HiddenHandler() Handles Me.VisibleChanged
        If Not Me.Visible Then
            'disable dr / cont reads
            pageReadTimer.Enabled = False
            drReadTimer.Enabled = False
        Else
            pageReadTimer.Enabled = contRead.Checked
            drReadTimer.Enabled = measureDr.Checked
        End If
    End Sub

    Private Sub WriteEnterHandler(sender As Object, e As KeyEventArgs) Handles newValue.KeyUp

        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
            ButtonWrite.PerformClick()
        End If

    End Sub

    Private Sub AnnoyingNoiseHandler(sender As Object, e As KeyEventArgs) Handles newValue.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub ButtonWrite_Click(sender As Object, e As EventArgs) Handles ButtonWrite.Click

        Dim regLabel As String

        If scaleData Then
            Dim writeValue As Integer
            Try
                writeValue = Convert.ToInt32(newValue.Text, 10)
                regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
                Dut.WriteSigned(RegMap(regLabel), writeValue)
            Catch ex As Exception
                MsgBox("ERROR: Invalid write - " + ex.Message())
            End Try
        Else
            Dim writeValue As UInteger
            Try
                writeValue = Convert.ToUInt32(newValue.Text, 16)
                regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
                Dut.WriteUnsigned(RegMap(regLabel), writeValue)
            Catch ex As Exception
                MsgBox("ERROR: Invalid write - " + ex.Message())
            End Try
        End If

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub ReadPage()
        Dim readRegList As New List(Of RegClass)
        Dim numDecimalPlaces As UInteger

        For Each reg In currentRegList
            If reg.IsReadable Then
                readRegList.Add(reg)
            Else
                'Dummy read reg for unreadable registers
                readRegList.Add(New RegClass With {.Page = reg.Page, .Address = 0})
            End If
        Next

        If scaleData Then
            Try
                numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
            Catch ex As Exception
                numDecimalPlaces = 2
                numDecimals.Text = "2"
                MsgBox("Invalid number Of Decimal places!" + ex.Message)
            End Try
            Dim DutValuesDoub() As Double
            DutValuesDoub = Dut.ReadScaledValue(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesDoub
                If currentRegList(regIndex).IsReadable Then
                    regView.Item("Contents", regIndex).Value = value.ToString("f" + numDecimalPlaces.ToString())
                Else
                    regView.Item("Contents", regIndex).Value = "Write Only"
                End If
                regIndex += 1
            Next
        Else
            Dim DutValuesUInt() As UInteger
            DutValuesUInt = Dut.ReadUnsigned(readRegList)
            Dim regIndex As Integer = 0
            For Each value In DutValuesUInt
                If currentRegList(regIndex).IsReadable Then
                    regView.Item("Contents", regIndex).Value = value.ToString("X" + (currentRegList(regIndex).NumBytes * 2).ToString())
                Else
                    regView.Item("Contents", regIndex).Value = "Write Only"
                End If
                regIndex += 1
            Next
        End If

        'check the page register
        If FX3.PartType = FX3Api.DUTType.LegacyIMU Then Exit Sub
        Dim expectedPage As Integer = currentRegList(0).Page
        If m_pageMessageList.Contains(expectedPage) Then
            Exit Sub
        End If
        Dim dutPage As Integer = Dut.ReadUnsigned(New RegClass With {.Page = expectedPage, .Address = 0, .NumBytes = 2})
        If dutPage <> expectedPage Then
            m_pageMessageList.Add(expectedPage)
            MsgBox("ERROR: Unable to load page " + expectedPage.ToString())
        End If

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub regView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles regView.CellClick
        Dim regLabel As String
        Dim reg As RegClass
        Dim numDecimalPlaces As UInteger
        Try
            regLabel = regView.Item("Label", regView.CurrentCell.RowIndex).Value
            reg = RegMap(regLabel)
            If scaleData Then
                numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
                Dim value As Double
                value = Dut.ReadScaledValue(reg)
                CurrentValue.Text = value.ToString("f" + numDecimalPlaces.ToString())
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("f" + numDecimalPlaces.ToString())
            Else
                Dim value As UInteger
                value = Dut.ReadUnsigned(reg)
                CurrentValue.Text = value.ToString("X" + (reg.NumBytes * 2).ToString())
                regView.Item("Contents", regView.CurrentCell.RowIndex).Value = value.ToString("X" + (reg.NumBytes * 2).ToString())
            End If
            CurrentValue.BackColor = Color.White
        Catch ex As Exception
            CurrentValue.Text = "Write Only"
            CurrentValue.BackColor = ERROR_COLOR
        End Try

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub PageReadCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadPage))
    End Sub

    Private Sub DrReadCallBack()
        drReadTimer.Enabled = False
        Me.BeginInvoke(New MethodInvoker(AddressOf ReadDrFreq))
    End Sub

    Private Sub EnableDrTimer()
        drEnableTimer.Dispose()
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub ReadDrFreq()
        Dim dr As Double
        Try
            dr = FX3.MeasurePinFreq(FX3.DrPin, 1, 3000, 2)
        Catch ex As Exception
            dr = Double.PositiveInfinity
        End Try
        DrFreq.Text = FormatNumber(dr).ToString() + "Hz"
        If dr = Double.PositiveInfinity Then
            measureDr.Checked = False
        End If
        'if data ready is less than 10Hz want to shove some delays in here to prevent form from locking up a bunch
        If dr < 10 Then
            're-enable via timer, 5x the sample period delay
            drEnableTimer = New System.Timers.Timer(5000 / dr)
            AddHandler drEnableTimer.Elapsed, New ElapsedEventHandler(AddressOf EnableDrTimer)
            drEnableTimer.Enabled = True
        Else
            drReadTimer.Enabled = measureDr.Checked
        End If
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        'Kill any running timers
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False

        'reset dr active setting
        FX3.DrActive = originalDRSetting Or drActive.Checked
    End Sub

    Private Sub selectPage_SelectedIndexChanged(sender As Object, e As EventArgs) Handles selectPage.SelectedIndexChanged

        'Load all the registers on the given page into the data grid view
        InitializeDataGrid()

        While regView.RowCount > currentRegList.Count()
            regView.Rows.Remove(regView.Rows(regView.RowCount() - 1))
        End While

    End Sub

    Private Sub ButtonRead_Click(sender As Object, e As EventArgs) Handles ButtonRead.Click
        ReadPage()
    End Sub

    Private Sub contRead_CheckedChanged(sender As Object, e As EventArgs) Handles contRead.CheckedChanged
        pageReadTimer.Enabled = contRead.Checked
    End Sub

    Private Sub scaledData_CheckedChanged(sender As Object, e As EventArgs) Handles scaledData.CheckedChanged
        scaleData = scaledData.Checked
        If scaleData Then
            readLabel.Text = "Current Value (Decimal)"
            writeLabel.Text = "New Value (Decimal)"
            numDecimals.Visible = True
            numDecimals_label.Visible = True
            regView.Columns("Contents").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
            CovertTextFields()
        Else
            readLabel.Text = "Current Value (Hex)"
            writeLabel.Text = "New Value (Hex)"
            numDecimals.Visible = False
            numDecimals_label.Visible = False
            regView.Columns("Contents").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft
            CovertTextFields()
        End If

    End Sub

    Private Sub CovertTextFields()

        Dim newText As String
        Dim val As Double
        Dim valU As UInteger
        Dim reg As RegClass
        Dim numDecimalPlaces As UInteger

        'regview
        For i As Integer = 0 To regView.RowCount - 1
            newText = regView.Item("Contents", i).Value
            If newText <> "Not Read" Then
                Try
                    'get the reg associated with entry
                    reg = RegMap(regView.Item("Label", i).Value)
                    If scaleData Then
                        'data is in hex, need to scale to decimal
                        valU = Convert.ToUInt32(newText, 16)
                        'scale using DUT function
                        val = Dut.ScaleRegData(reg, valU)
                        'get number of decimal places
                        numDecimalPlaces = Convert.ToUInt32(numDecimals.Text)
                        'scale value
                        newText = val.ToString("f" + numDecimalPlaces.ToString())
                    Else
                        'data is in decimal, need to scale to hex
                        val = Convert.ToDouble(newText)
                        'un-scale using DUT function
                        valU = Dut.UnscaleRegData(reg, val)
                        'set string
                        newText = valU.ToString("X" + (reg.NumBytes * 2).ToString())
                    End If
                Catch ex As Exception
                    'don't need to explicitly handle anything here
                End Try
                regView.Item("Contents", i).Value = newText
            End If
        Next

        'copy from regview to current value
        newText = CurrentValue.Text
        Try
            CurrentValue.Text = regView.Item("Contents", regView.CurrentCell.RowIndex).Value
        Catch ex As Exception
            CurrentValue.Text = newText
        End Try

    End Sub

    Private Sub InitializeDataGrid()

        'Save the scroll position for old page
        If regView.FirstDisplayedScrollingRowIndex <> -1 Then
            pagePosition(lastPageIndex) = regView.FirstDisplayedScrollingRowIndex
        End If

        'Repopulate new page
        Dim regStr(3) As String
        Dim readStr As String
        Dim regIndex As Integer = 0
        currentRegList = New List(Of RegClass)
        For Each reg In RegMap
            If reg.Page = selectPage.SelectedItem Then
                currentRegList.Add(reg)
                If reg.IsReadable Then
                    readStr = "Not Read"
                Else
                    readStr = "Write Only"
                End If
                If regIndex >= regView.RowCount Then
                    regStr = {reg.Label, reg.Page.ToString(), reg.Address.ToString(), readStr}
                    regView.Rows.Add(regStr)
                Else
                    regView.Item("Label", regIndex).Value = reg.Label
                    regView.Item("Page", regIndex).Value = reg.Page
                    regView.Item("Address", regIndex).Value = reg.Address
                    regView.Item("Contents", regIndex).Value = readStr
                End If
                regIndex += 1
            End If
        Next

        'set the start position
        regView.FirstDisplayedScrollingRowIndex = pagePosition(selectPage.SelectedIndex)
        lastPageIndex = selectPage.SelectedIndex
    End Sub

    Private Sub btn_DumpRegmap_Click(sender As Object, e As EventArgs) Handles btn_DumpRegmap.Click
        Dim readableRegMap As New List(Of RegClass)
        For Each reg In RegMap
            If reg.IsReadable Then
                readableRegMap.Add(reg)
            End If
        Next

        Dim values() As UInteger
        values = Dut.ReadUnsigned(readableRegMap)
        Dim strValues As New List(Of String)

        strValues.Add("Register, Page, Address, Value")
        Dim index As Integer = 0
        For Each reg In readableRegMap
            strValues.Add(reg.Label + "," + reg.Page.ToString() + "," + reg.Address.ToString() + "," + values(index).ToString())
            index += 1
        Next
        saveCSV("RegDump", strValues.ToArray(), lastFilePath)

        'check if exceptions occurred
        ValidateAutomotiveSpiData()
    End Sub

    Private Sub measureDr_CheckedChanged(sender As Object, e As EventArgs) Handles measureDr.CheckedChanged
        drReadTimer.Enabled = measureDr.Checked
    End Sub

    Private Sub drActive_CheckedChanged(sender As Object, e As EventArgs) Handles drActive.CheckedChanged
        Dim freq As Double
        If drActive.Checked Then
            'perform quick check of dr freq
            freq = FX3.MeasurePinFreq(FX3.DrPin, 1, 100, 2)
            If freq = Double.PositiveInfinity Then
                Dim res As DialogResult = MessageBox.Show("Warning, Data Ready not Toggling! Continue?", "Confirm Data Ready Sync", MessageBoxButtons.OKCancel)
                If res <> DialogResult.OK Then drActive.Checked = False
            End If
        End If
        FX3.DrActive = drActive.Checked
    End Sub

    Private Sub btn_writeRegMap_Click(sender As Object, e As EventArgs) Handles btn_writeRegMap.Click
        Dim fileBrowser As New OpenFileDialog
        Dim fileBrowseResult As DialogResult
        Dim loadPath As String
        Dim writeRegs As New List(Of RegClass)
        Dim writeVals As New List(Of UInteger)
        fileBrowser.Title = "Please Select the Register Dump File"
        fileBrowser.Filter = "Register Dump Files|*.csv"
        fileBrowseResult = fileBrowser.ShowDialog()
        If fileBrowseResult <> DialogResult.OK Then
            Exit Sub
        End If
        loadPath = fileBrowser.FileName

        Dim csvReader As New FileIO.TextFieldParser(loadPath)
        csvReader.TextFieldType = FileIO.FieldType.Delimited
        csvReader.SetDelimiters(",")

        Dim regLine As String()
        Dim reg As RegClass
        'clear header
        csvReader.ReadLine()
        While Not csvReader.EndOfData
            Try
                regLine = csvReader.ReadFields()
                'get register object
                reg = RegMap(regLine(0))
                'if readable then add value
                If reg.IsWriteable Then
                    writeRegs.Add(reg)
                    writeVals.Add(Convert.ToUInt32(regLine(3)))
                End If
            Catch ex As Exception
                If MessageBox.Show("Error Parsing CSV file! Continue?", "Error", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    csvReader.Close()
                    Exit Sub
                End If
            End Try
        End While
        csvReader.Close()

        'apply data to DUT
        Dut.WriteUnsigned(writeRegs, writeVals)

        'check if exceptions occurred
        ValidateAutomotiveSpiData()

    End Sub

    Private Sub ValidateAutomotiveSpiData()

        'message string
        Dim msg As String

        'exception
        Dim ex As adisInterface.SpiException

        'number of exceptions logged
        Dim logLength As Integer = 0

        'exit if not set to validate
        If Not validateSpiData.Checked Then Exit Sub

        If m_AutoSpi.LoggedExceptionCount > 0 Then
            msg = m_AutoSpi.LoggedExceptionCount.ToString() + " SPI exception(s) have occurred: "
            ex = m_AutoSpi.DequeueLoggedException()
            While Not IsNothing(ex)
                msg += Environment.NewLine + ex.Message
                logLength += 1
                If logLength > 9 Then
                    msg += Environment.NewLine + "and " + m_AutoSpi.LoggedExceptionCount.ToString() + " more..."
                    'clear queue
                    m_AutoSpi.LogExceptions = False
                    m_AutoSpi.LogExceptions = validateSpiData.Checked
                    Exit While
                End If
                ex = m_AutoSpi.DequeueLoggedException()
            End While
            'disable continuous reads in case of error
            contRead.Checked = False
            MsgBox(msg)
        End If
    End Sub

    Private Sub validateSpiData_CheckedChanged(sender As Object, e As EventArgs) Handles validateSpiData.CheckedChanged
        m_AutoSpi.LogExceptions = validateSpiData.Checked
    End Sub

#End Region

#Region "GPIO Tab"

    Private StartPWM As Boolean

    ' uses capitalized pin names as keys
    Private Property pins As New Dictionary(Of String, IPinObject)

    Private Sub btn_pullUp_Click(sender As Object, e As EventArgs) Handles btn_pullUp.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.PullUp)

    End Sub

    Private Sub btn_pullDown_Click(sender As Object, e As EventArgs) Handles btn_pullDown.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.PullDown)

    End Sub

    Private Sub btn_disableResistor_Click(sender As Object, e As EventArgs) Handles btn_disableResistor.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.None)

    End Sub

    Private Sub UpdateButton(Pin As IPinObject)
        If IsNothing(Pin) Then Exit Sub
        Dim PWMInfo As PinPWMInfo
        Try
            If FX3.isPWMPin(Pin) Then
                PWMInfo = FX3.GetPinPWMInfo(Pin)
                btn_StartPWM.Text = "Stop Pin PWM"
                StartPWM = False
                Freq.ReadOnly = True
                Freq.Text = PWMInfo.IdealFrequency.ToString()
                DutyCycle.ReadOnly = True
                DutyCycle.Text = PWMInfo.IdealDutyCycle.ToString()
            Else
                btn_StartPWM.Text = "Start Pin PWM"
                StartPWM = True
                Freq.ReadOnly = False
                DutyCycle.ReadOnly = False
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub PinSelectionChanged() Handles dgvPinList.SelectionChanged
        If dgvPinList.SelectedRows.Count > 0 Then
            UpdateButton(pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper))
        End If
    End Sub

    Private Sub startBtn_Click(sender As Object, e As EventArgs) Handles btn_StartPWM.Click
        If Not PinSelected() Then Exit Sub
        Dim pin As IPinObject = Nothing
        Try
            pin = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
            If StartPWM Then
                FX3.StartPWM(Convert.ToDouble(Freq.Text), Convert.ToDouble(DutyCycle.Text), pin)
                dgvPinList.SelectedRows(0).Cells(1).Value = "PWM"
            Else
                FX3.StopPWM(pin)
                'read after to report level on form
                If FX3.ReadPin(pin) = 0 Then
                    dgvPinList.SelectedRows(0).Cells(1).Value = "Low"
                Else
                    dgvPinList.SelectedRows(0).Cells(1).Value = "High"
                End If
            End If
        Catch ex As Exception
            MsgBox("ERROR: Caught exception " + ex.ToString())
        End Try
        UpdateButton(pin)
    End Sub

    Private Sub updatePinGrid()
        For Each row As DataGridViewRow In dgvPinList.Rows
            Dim currPin As IPinObject = pins(row.Cells(0).Value.ToUpper)
            Dim state As String
            If FX3.isPWMPin(currPin) Then
                ' only throw a message on first load, doing it repeatedly would be annoying
                state = "PWM"
            ElseIf FX3.ReadPin(currPin) = 0 Then
                state = "Low"
            Else
                state = "High"
            End If
            row.Cells(1).Value = state
        Next
    End Sub

    Private Sub writeLevel(level As Boolean)
        Dim currPin As IPinObject
        Dim pinName As String
        If Not PinSelected() Then
            Exit Sub
        End If
        ' grid is set up to only allow one row selection
        Dim selectedRow As DataGridViewRow = dgvPinList.SelectedRows(0)
        pinName = selectedRow.Cells(0).Value

        Try
            currPin = pins(pinName.ToUpper)
        Catch
            MsgBox(pinName & " not found in dictionary.", MsgBoxStyle.Critical)
            Exit Sub
        End Try
        Dim answer As Integer
        If FX3.isPWMPin(currPin) Then
            Dim message As String = pinName & " is in PWM mode, writing to it will terminate that. Do you wish to perform the write?"
            answer = MsgBox(message, vbQuestion + vbYesNo + vbDefaultButton2)
            If answer = vbYes Then
                FX3.StopPWM(currPin)
                FX3.SetPin(currPin, level)
            Else
                Exit Sub
            End If
        Else
            FX3.SetPin(currPin, level)
        End If
        ' reading after performing the write will clear the values so don't do it
        If level = 0 Then
            dgvPinList.SelectedRows(0).Cells(1).Value = "Set Low"
        Else
            dgvPinList.SelectedRows(0).Cells(1).Value = "Set High"
        End If
    End Sub

    Private Sub ButtonWriteHigh_Click(sender As Object, e As EventArgs) Handles ButtonWriteHigh.Click
        writeLevel(1)
    End Sub

    Private Sub ButtonWriteLow_Click(sender As Object, e As EventArgs) Handles ButtonWriteLow.Click
        writeLevel(0)
    End Sub

    Private Sub ButtonReadAll_Click(sender As Object, e As EventArgs) Handles ButtonReadAll.Click
        updatePinGrid()
    End Sub

    Private Sub ButtonPulseDrive_Click(sender As Object, e As EventArgs) Handles btn_PulseDrive.Click
        Dim period As Double = 0
        Dim level As Boolean
        Dim mode As UInteger = 0
        Dim pin As IPinObject

        If Not PinSelected() Then
            Exit Sub
        End If

        Try
            pin = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToUpper)
        Catch
            MsgBox("Key not found in dictionary", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        ' get period
        Try
            period = Convert.ToDouble(TextBoxPeriod.Text)
            If period < 0 Then
                Throw New Exception("Negative values are invalid")
            End If
        Catch
            MsgBox("Invalid entry in Period box. Must be a positive double or integer.", MsgBoxStyle.Exclamation)
            Exit Sub
        End Try

        ' get level
        If ComboBoxHighLow.Text = "High" Then
            level = 1
        ElseIf ComboBoxHighLow.Text = "Low" Then
            level = 0
        Else
            MsgBox("No level selected.", MsgBoxStyle.Exclamation)
        End If

        Try
            FX3.PulseDrive(pin, level, period, mode)
        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message())
        End Try

    End Sub

    Private Sub ButtonReadSelected_Click(sender As Object, e As EventArgs) Handles ButtonReadSelected.Click
        If Not PinSelected() Then Exit Sub
        Dim currPin As IPinObject = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        Dim state As String
        If FX3.isPWMPin(currPin) Then
            ' only throw a message on first load, doing it repeatedly would be annoying
            state = "PWM"
        ElseIf FX3.ReadPin(currPin) = 0 Then
            state = "Low"
        Else
            state = "High"
        End If
        dgvPinList.SelectedRows(0).Cells(1).Value = state
    End Sub

    Private Function PinSelected() As Boolean
        If dgvPinList.SelectedRows.Count = 0 Then
            MsgBox("No pin selected.", MsgBoxStyle.Exclamation)
            Return False
        Else
            Return True
        End If
    End Function

    Private Sub btn_ReadGPIO_Click(sender As Object, e As EventArgs) Handles btn_ReadGPIO.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 63 Then
                Throw New ArgumentException("Pin number out of range. Max value 64")
            End If
        Catch ex As Exception
            MsgBox("Invalid Pin! " + ex.Message)
            Exit Sub
        End Try

        GPIO_Value.Text = FX3.ReadPin(New FX3PinObject(pinNum)).ToString()
    End Sub

    Private Sub btn_SetGPIOHigh_Click(sender As Object, e As EventArgs) Handles btn_SetGPIOHigh.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 63 Then
                Throw New ArgumentException("Pin number out of range. Max value 63")
            End If
        Catch ex As Exception
            MsgBox("Invalid Pin! " + ex.Message)
            Exit Sub
        End Try

        FX3.SetPin(New FX3PinObject(pinNum), 1)
    End Sub

    Private Sub btn_SetGPIOLow_Click(sender As Object, e As EventArgs) Handles btn_SetGPIOLow.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 63 Then
                Throw New ArgumentException("Pin number out of range. Max value 63")
            End If
        Catch ex As Exception
            MsgBox("Invalid Pin! " + ex.Message)
            Exit Sub
        End Try

        FX3.SetPin(New FX3PinObject(pinNum), 0)

    End Sub

    Private Sub btn_MeasureFreq_Click(sender As Object, e As EventArgs) Handles btn_MeasureFreq.Click
        If Not PinSelected() Then Exit Sub
        Dim currPin As IPinObject = pins(dgvPinList.SelectedRows(0).Cells(0).Value.ToString.ToUpper)
        If FX3.isPWMPin(currPin) Then
            Dim message As String = "Pin is in PWM mode, reading will terminate. Do you wish to read?"
            Dim answer = MsgBox(message, vbQuestion + vbYesNo + vbDefaultButton2)
            If answer = vbYes Then
                FX3.StopPWM(currPin)
                'read after to report level on form
                If FX3.ReadPin(currPin) = 0 Then
                    dgvPinList.SelectedRows(0).Cells(1).Value = "Low"
                Else
                    dgvPinList.SelectedRows(0).Cells(1).Value = "High"
                End If
            Else
                Exit Sub
            End If
        End If
        Dim val As Double = FX3.MeasurePinFreq(currPin, 1, 1000, 2)
        If val = Double.PositiveInfinity Then
            pinToggleFreq.Text = "Timeout"
        Else
            pinToggleFreq.Text = val.ToString("f1") + "Hz"
        End If
    End Sub

    Private Sub PinTabInit()
        'Defaults
        DutyCycle.Text = "0.5"
        Freq.Text = "2000.0"
        StartPWM = True

        Dim col As DataGridViewColumn

        'makes the chart not update until all additions have been made
        dgvPinList.SuspendLayout()

        dgvPinList.ReadOnly = True
        dgvPinList.AutoGenerateColumns = False
        dgvPinList.Columns.Clear()

        col = New DataGridViewTextBoxColumn
        col.HeaderText = "Pin"
        col.SortMode = DataGridViewColumnSortMode.NotSortable
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgvPinList.Columns.Add(col)

        col = New DataGridViewTextBoxColumn
        col.HeaderText = "High/Low"
        col.Width = 60
        col.SortMode = DataGridViewColumnSortMode.NotSortable
        col.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        dgvPinList.Columns.Add(col)

        ' create a list of pins to fill in the grid
        Dim FX3Api = GetType(FX3Connection)
        For Each prop In FX3Api.GetProperties()
            If prop.PropertyType = GetType(IPinObject) And Not prop.Name = "ReadyPin" Then
                Dim currPin As IPinObject = FX3.GetType().GetProperty(prop.Name).GetValue(FX3)
                pins.Add(prop.Name.ToUpper, currPin)
                Dim state As String
                If FX3.isPWMPin(currPin) Then
                    state = "PWM"
                ElseIf FX3.ReadPin(currPin) = 0 Then
                    state = "Low"
                Else
                    state = "High"
                End If
                dgvPinList.Rows.Add(prop.Name, state)
            End If
        Next

        ' makes the width of the dgv the same as the width of the columns
        dgvPinList.Height = dgvPinList.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + dgvPinList.ColumnHeadersHeight
        ' prevent it from auto selecting a pin
        dgvPinList.ClearSelection()
        ' allows the chart to update
        dgvPinList.ResumeLayout()

        ' set up pulse drive stuff
        ComboBoxHighLow.Items.Add("High")
        ComboBoxHighLow.Items.Add("Low")
        ComboBoxHighLow.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBoxHighLow.SelectedIndex = 0
        TextBoxPeriod.Text = "100"

    End Sub

#End Region

End Class