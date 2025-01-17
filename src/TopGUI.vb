'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          TopGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Top level GUI for the EVAL-ADIS-FX3 iSensor IMU eval application.

Imports FX3Api
Imports adisInterface
Imports RegMapClasses
Imports System.IO
Imports System.Timers
Imports System.Threading
Imports System.Net
Imports System.Web.Script.Serialization
Imports System.Xml.Serialization
Imports System.Text

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

    'DUT settings management
    Friend SelectedPersonalityLabel As String
    Friend SelectedPersonality As DutPersonality
    Friend LastValidSelectedPersonality As String
    Friend DutOptions As List(Of DutPersonality)

    'List of list view items for bulk register read
    Friend BulkRegList As List(Of ListViewItem)
    Friend numRegSamples As Integer
    Friend linesPerFile As Integer
    Friend logScaledData As Boolean
    Friend logTimestampData As Boolean

    'data visualization color palette
    Friend PlotColorPalette As List(Of Color)

    'plotting register lists
    Friend dataPlotRegs As New List(Of RegPlotterInfo)

    'general plotter settings
    Friend plotSettings As PlotterSettings

    'Last browsed to file location
    Public lastFilePath As String

    'Private member variables
    Private m_FX3Connected As Boolean
    Private WithEvents m_disconnectTimer As Timers.Timer
    Private m_RegMapPath As String
    Friend m_AutoSpi As iSensorAutomotiveSpi
    Friend m_CompSpi As ComponentSpi

    'track IDutInterface settings which must be persistent
    Friend m_isLowerWordFirst As Boolean

#End Region

#Region "Constructor/Load"

    ''' <summary>
    ''' Constructor
    ''' </summary>
    Public Sub New()

        'This call is required by the designer
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' Initializer. Loads settings, shows welcome guide, prompts for
    ''' DUT personality selection, and initializes register map
    ''' </summary>
    Public Sub Setup() Handles Me.Load

        Dim firmwarePath As String
        Dim colorPath As String
        Dim colors As String()
        Dim validPersonality As Boolean

        'Register exception handlers
        AddHandler Application.ThreadException, AddressOf ThreadErrorHandler
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GeneralErrorHandler

        'show welcome guide if selected
        If My.Settings.ShowWelcome Then
            Dim welcomeGuide As New WelcomeGuideGUI()
            'show dialog blocks - can't proceed until closed
            welcomeGuide.ShowDialog()
        End If

        Text = "iSensor FX3 Eval"

        'set up timers for register view
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

        'apply colors
        ApplyBackgroundColors()

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

        'load plotter settings
        If My.Settings.PlotSettings <> "" Then
            Dim serializer As New XmlSerializer(GetType(PlotterSettings))
            Try
                plotSettings = CType(serializer.Deserialize(New MemoryStream(Encoding.Unicode.GetBytes(My.Settings.PlotSettings))), PlotterSettings)
            Catch ex As Exception
                plotSettings = New PlotterSettings()
            End Try
        Else
            plotSettings = New PlotterSettings()
        End If

        'load DUT personality settings
        SelectedPersonalityLabel = My.Settings.DutPersonality
        LastValidSelectedPersonality = My.Settings.LastValidDutPersonality
        LoadDUTOptions()

        'load personality based on last selection
        validPersonality = False
        For Each item In DutOptions
            If item.DisplayName = SelectedPersonalityLabel Then
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
                If item.DisplayName = SelectedPersonalityLabel Then
                    validPersonality = True
                    Exit For
                End If
            Next
            'go to custom if none set
            If Not validPersonality Then SelectedPersonalityLabel = DutPersonality.CUSTOM_PERSONALITY_STRING
        End If

        'Check that all the register maps required for the application are properly bundled
        CheckRegmapResources()

        'load register map
        ApplyDutPersonalityRegmap(SelectedPersonalityLabel)

        'Set bulk reg list
        BulkRegList = New List(Of ListViewItem)
        numRegSamples = 10000
        linesPerFile = 1000000
        'Load saved settings for data logging
        logScaledData = My.Settings.LogScaledData
        logTimestampData = My.Settings.LogTimestampData

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

        'Set up automotive SPI interface
        m_AutoSpi = New iSensorAutomotiveSpi(FX3)
        m_AutoSpi.IgnoreExceptions = True
        m_AutoSpi.LogExceptions = True

        'set up component sensor SPI interface
        m_CompSpi = New ComponentSpi(FX3)

        'Set the API version and build date
        label_apiVersion.Text = "ADI iSensor FX3 Eval GUI v" + Application.ProductVersion

        'load the last used file path
        lastFilePath = My.Settings.LastFilePath

        'Set tool tips
        SetupToolTips()

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
            Top = My.Settings.LastTop
            Left = My.Settings.LastLeft
            Width = My.Settings.LastWidth
            Height = My.Settings.LastHeight
        ElseIf screens.Count > 0 Then
            Top = (screens(0).WorkingArea.Height / 2) - (Height / 2)
            Left = (screens(0).WorkingArea.Width / 2) - (Width / 2)
        Else
            MsgBox("ERROR: This application requires a screen to function properly...")
        End If

    End Sub

#End Region

#Region "Properties"

    ''' <summary>
    ''' Set/get the loaded register map path. Setting this property will trigger
    ''' the RegMap dictionary to be re-loaded from the provided CSV
    ''' </summary>
    ''' <returns>Path to currently loaded register map</returns>
    Public Property RegMapPath As String
        Get
            Return m_RegMapPath
        End Get
        Set(value As String)
            Try
                m_RegMapPath = value
                'Set the register map
                RegMap = New RegMapCollection
                RegMap.ReadFromCSV(m_RegMapPath)
                If RegMap.Count() = 0 Then
                    Throw New Exception("Register map produced from selected file contains 0 registers")
                End If
                regMapPath_Label.Text = value.Substring(value.LastIndexOf("\") + 1)
                SetupToolTips()
                RegFormSetup()
                DataPlotRegsInit()
                'Ensure we are set to read in hex by default
                scaledData.Checked = False
            Catch ex As Exception
                MsgBox("ERROR: Invalid RegMap Selected! " + ex.Message() + " " + RegMap.ErrorText)
            End Try
        End Set
    End Property

#End Region

#Region "Button Event Handlers"

    ''' <summary>
    ''' Open ADcmXL buffered data capture GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_ADcmXlBufCapture_Click(sender As Object, e As EventArgs) Handles btn_ADcmXlBufCapture.Click
        'For machine health create a ADcmXLStreamingGUI
        Dim subGUI As New ADcmXLBufferedLogGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_ADcmXlBufCapture.Enabled = False
    End Sub

    ''' <summary>
    ''' Open a new factory reset GUI
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_FactoryReset_Click(sender As Object, e As EventArgs) Handles btn_FactoryReset.Click
        Dim subGUI As New FacResetGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_FactoryReset.Enabled = False
    End Sub

    ''' <summary>
    ''' Helper function to generate a correct ADXC1500 SPI CRC, based on 
    ''' a 32-bit input word
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_CRC4WordGen_Click(sender As Object, e As EventArgs) Handles btn_CRC4WordGen.Click
        Dim input As UInteger
        Dim crc As UInteger
        Dim res As String
        Try
            input = Convert.ToUInt32(InputBox("Enter full input word (hex):", "Input", "0x00000000"), 16)
        Catch ex As Exception
            MsgBox("Invalid Input! " + ex.Message)
            Exit Sub
        End Try

        'calc CRC
        crc = HelperFunctions.CalcCRC28Bit(input >> 4)

        'add to input
        input = input And &HFFFFFFF0UI
        input = input Or crc
        res = "0x" + input.ToString("X8")
        'copy to clipboard
        If MessageBox.Show(res + " Copy to clipboard?", "Result", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) = DialogResult.OK Then
            Clipboard.SetText(res)
        End If
    End Sub

    ''' <summary>
    ''' Open a new burst test sub-form. This allows the user to generate custom burst reads
    ''' with whatever SPI protocol and SCLK freq is desired
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_BurstTest_Click(sender As Object, e As EventArgs) Handles btn_BurstTest.Click
        Dim subGUI As New BurstTestGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_BurstTest.Enabled = False
    End Sub

    ''' <summary>
    ''' Open a new GPIO pulse measurement sub-form. This form can be used to transact SPI 
    ''' data and accurately measure the following pulse on a DIO line (for example, measuring
    ''' flash update time)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_pulseMeasure_Click(sender As Object, e As EventArgs) Handles btn_pulseMeasure.Click
        Dim subGUI As New PulseMeasureGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_pulseMeasure.Enabled = False
    End Sub

    ''' <summary>
    ''' Opens a new binary file writer GUI. This is a misc application, not really useful for
    ''' IMUs. Should probably be removed at some point
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_binFile_Click(sender As Object, e As EventArgs) Handles btn_binFile.Click
        Dim subGUI As New BinaryFileWriterGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_binFile.Enabled = False
    End Sub

    ''' <summary>
    ''' Open a new FX3 board error log sub-form. This GUI allows the user to 
    ''' dump the RTOS error log from the FX3 EEPROM to a CSV file
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_checkError_Click(sender As Object, e As EventArgs) Handles btn_checkError.Click
        Dim subGUI As New NVMInterfaceGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_checkError.Enabled = False
    End Sub

    ''' <summary>
    ''' Connects to the FX3, or reboots the connected FX3 board if
    ''' it is already connected
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click

        Select Case btn_Connect.Text
            Case "Connect to FX3"
                btn_Connect.Text = "Connecting to FX3..."
                ConnectWork()
            Case "Reboot FX3"
                If MessageBox.Show("This will reboot the FX3 and close all running applications. Are you sure you wish to continue?",
                                             "Reboot FX3", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                    CloseAllForms()
                    RebootFX3()
                    btn_Connect.Text = "Connect to FX3"
                End If
        End Select

    End Sub

    ''' <summary>
    ''' Open a new DUT personality selection sub-form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_SelectDUT_Click(sender As Object, e As EventArgs) Handles btn_SelectDUT.Click
        Dim subGUI As New SelectDUTGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_SelectDUT.Enabled = False
    End Sub

    ''' <summary>
    ''' Resets the connected DUT via the hardware reset line, then checks SPI comms after the reset
    ''' has completed
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_ResetDUT_Click(sender As Object, e As EventArgs) Handles btn_ResetDUT.Click
        FX3.Reset()
        TestDUT()
    End Sub

    ''' <summary>
    ''' Open a new burst data streaming sub-form. If the part selected is an IMU, 
    ''' the IMUStreamingGUI is opened. If the part selected is an ADcmXL series,
    ''' then the ADcmXL real time streaming GUI is opened
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Open a new bulk register logging sub-form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_BulkRegRead_Click(sender As Object, e As EventArgs) Handles btn_BulkRegRead.Click

        Dim subGUI As New RegisterBulkReadGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_BulkRegRead.Enabled = False

    End Sub

    ''' <summary>
    ''' Open a new FX3 configuration sub-form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_FX3Config_Click(sender As Object, e As EventArgs) Handles btn_FX3Config.Click
        Dim subGUI As New FX3ConfigGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_FX3Config.Enabled = False
    End Sub

    ''' <summary>
    ''' Performs on-demand DUT SPI comms check
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_CheckDUTConnection_Click(sender As Object, e As EventArgs) Handles btn_CheckDUTConnection.Click
        TestDUT()
    End Sub

    ''' <summary>
    ''' Open a new bit bang SPI sub-form. The bit bang SPI form is 
    ''' responsible for restoring FX3 hardware SPI functionality when
    ''' it loses focus
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_bitBangSPI_Click(sender As Object, e As EventArgs) Handles btn_BitBangSPI.Click
        Dim subGUI As New BitBangSpiGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()
        btn_BitBangSPI.Enabled = False
    End Sub

    ''' <summary>
    ''' Open a new API/firmware info sub-form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_APIInfo_Click(sender As Object, e As EventArgs) Handles btn_APIInfo.Click
        Dim subGUI As New ApiInfoGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_APIInfo.Enabled = False
    End Sub

    ''' <summary>
    ''' Updated the selected plot data register list then 
    ''' open a new frequency domain plotting sub-form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_plotFFT_Click(sender As Object, e As EventArgs) Handles btn_plotFFT.Click

        LoadDataPlotRegList()

        Dim subGUI As New FrequencyPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_plotFFT.Enabled = False
    End Sub

    ''' <summary>
    ''' Updated the selected plot data register list then 
    ''' open a new time domain plotting sub-form
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_plotData_Click(sender As Object, e As EventArgs) Handles btn_plotData.Click

        LoadDataPlotRegList()

        Dim subGUI As New DataPlotGUI()
        subGUI.SetTopGUI(Me)
        subGUI.Show()

        'disable button
        btn_plotData.Enabled = False

    End Sub

    ''' <summary>
    ''' Measure average round trip USB command latency
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub btn_MeasureUSB_Click(sender As Object, e As EventArgs) Handles btn_MeasureUSB.Click

        Const NUM_TRIALS As Integer = 1000
        Dim timer As New Stopwatch()
        Dim usbTimeUs As Double
        'GPIO 14 is not used
        Dim pin As New FX3PinObject(14)

        'expect USB time to be in 150us range. 1000 transfers should take ~15ms
        timer.Start()
        For i As Integer = 1 To NUM_TRIALS
            FX3.SetPin(FX3.FX3_LOOPBACK1, 1)
        Next
        timer.Stop()

        usbTimeUs = (timer.ElapsedTicks * (1000000.0 / Stopwatch.Frequency)) / NUM_TRIALS
        MsgBox("Average USB Transfer Time: " + usbTimeUs.ToString("f2") + "us")
    End Sub

#End Region

#Region "Other Event Handlers"

    ''' <summary>
    ''' Open the welcome GUI when the help link is clicked
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub link_help_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles link_help.LinkClicked
        link_help.LinkVisited = True
        Dim subGUI As New WelcomeGuideGUI()
        subGUI.Show()
    End Sub

    ''' <summary>
    ''' Handle top GUI resize events. Only allows expansion on the
    ''' Y-axis (height)
    ''' </summary>
    Private Sub ResizeHandler() Handles Me.Resize
        'resize register view
        regView.Height = Height - 351
        btn_DumpRegmap.Top = Height - 362
        btn_writeRegMap.Top = Height - 362

        'resize tab control
        dut_access.Height = Height - 286

        'bottom labels need to move too
        label_apiVersion.Top = Height - 79
        checkVersion.Top = Height - 79
        report_issue.Top = Height - 60
        regMapPath_Label.Top = Height - 60
        link_help.Top = Height - 60
    End Sub

    ''' <summary>
    ''' This event handler is used to allow for asynchronous timeouts when reconnecting to an FX3 which was previously disconnected.
    ''' </summary>
    Private Sub timeoutHandler()
        m_disconnectTimer.Enabled = False
        'Timers run in a separate thread from GUI
        BeginInvoke(New MethodInvoker(AddressOf UpdateTimeoutLabels))
    End Sub

    ''' <summary>
    ''' Handles application closing. Performs any misc cleanup which is required then
    ''' disconnects the FX3 (reboot back to the USB bootloader)
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub Cleanup(sender As Object, e As EventArgs) Handles Me.Closing

        'Process anything in app event queue
        Application.DoEvents()

        'save user settings
        SaveAppSettings()

        'close all other child forms
        CloseAllForms()

        'Disconnect the FX3 (does nothing if not already connected)
        FX3.Disconnect()

    End Sub

    ''' <summary>
    ''' Gets the latest release version from the GitHub API. If the current version is older
    ''' than the newest release, allows direct download of the new binary
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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
            request = WebRequest.Create("https://api.github.com/repos/analogdevicesinc/iSensor-FX3-Eval/releases/latest")
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
        currentVersion = Version.Parse(ProductVersion)
        If currentVersion.CompareTo(newestVersion) < 0 Then
            promptResult = MsgBox("Version " + content("tag_name").ToString() + " available. Download now?", MsgBoxStyle.YesNo)
        Else
            MsgBox("Already up to date! Latest version: " + content("tag_name").ToString())
            Exit Sub
        End If

        If promptResult <> MsgBoxResult.Yes Then
            Exit Sub
        End If

        'get the URL to the zip resource to download and open in browser
        Dim proc = New Process()
        Dim assets As ArrayList = DirectCast(content("assets"), ArrayList)
        proc.StartInfo.UseShellExecute = True
        proc.StartInfo.FileName = assets(0)("browser_download_url")
        proc.Start()

    End Sub

    ''' <summary>
    ''' Open new issue page on GitHub when the user clicks on the report issue label.
    ''' Maybe someone will eventually use this. People seem much more fond of sending
    ''' emails.
    ''' 
    ''' Update - some people actually used the GitHub issue tracker!
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    Private Sub report_issue_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles report_issue.LinkClicked
        report_issue.LinkVisited = True
        System.Diagnostics.Process.Start("https://github.com/analogdevicesinc/iSensor-FX3-Eval/issues/new")
    End Sub

    ''' <summary>
    ''' Handle any exceptions which are not caught by the code
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
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

    ''' <summary>
    ''' Log an un-handled exception to a file on the PC
    ''' </summary>
    ''' <param name="e">Exception which was raised</param>
    Private Sub LogError(e As Exception)

        If TypeOf (e) Is SpiException Then
            MessageBox.Show("ERROR: Automotive SPI protocol exception has occurred - is the DUT connected properly? " + e.Message,
                            "Unexpected Error!", MessageBoxButtons.OK, MessageBoxIcon.Error)
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
            'shut down the FX3
            Try
                FX3.Disconnect()
            Catch ex As Exception
                'squash - might not be able to talk to the FX3 board here
            End Try
            'force kill the process
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
        Dim logPath As String = Environment.CurrentDirectory
        'check file
        logPath = Path.Combine(logPath, "iSensor_FX3_Eval_Error_Log.csv")
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
        MsgBox("Error: Un-handled exception has occurred: " + e.Message + Environment.NewLine + "Detailed data has been stored at " + logPath)
    End Sub

    ''' <summary>
    ''' Event handler for when the board is unplugged
    ''' </summary>
    ''' <param name="FX3SerialNumber">Serial Number of the board which generated the event</param>
    Public Sub DisconnectHandler(FX3SerialNumber As String) Handles FX3.UnexpectedDisconnect

        'prior to disconnecting the FX3, ensure settings are saved
        SaveAppSettings()
        'reload custom personalities from file
        LoadDUTOptions()

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

        'ensure that the top GUI is at front
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

#Region "DUT Interface Functions"

    ''' <summary>
    ''' Waits for data ready to begin toggling, then performs a write and read back 
    ''' test on the user scratch register of the connected DUT
    ''' </summary>
    Friend Function TestDUT() As Boolean

        Dim scratchReg As RegClass = Nothing
        Dim scratchRegNames() As String = {"USER_SCRATCH", "USER_SCR1", "USER_SCR_1", "USER_SCRATCH_1", "SCRATCH_A", "USER_SCR_2", "APPLICATION_SPACE_7", "USER_ID", "XACCL_NULL", "ALM_MAG1"}
        Dim drActive As Boolean = FX3.DrActive
        Dim randomValue As UInteger
        Dim orignalScratch As UInteger
        Dim testResult As Boolean

        'Exit if FX3 not connected
        If Not m_FX3Connected Then
            label_DUTStatus.Text = "Waiting for FX3 to Connect"
            label_DUTStatus.BackColor = IDLE_COLOR
            Return False
        End If

        For Each regName In scratchRegNames
            If RegMap.Contains(regName) Then
                scratchReg = RegMap(regName)
                'stop at the first register we find. This lets us program essentially a priority order
                'for which register is treated as the scratch register (in the event a device has multiple)
                Exit For
            End If
        Next

        If IsNothing(scratchReg) Then
            label_DUTStatus.Text = "ERROR: No Scratch Register in RegMap"
            label_DUTStatus.BackColor = IDLE_COLOR
            Return False
        End If

        'make DR active false for this test
        FX3.DrActive = False

        'wait for DR to reach DR polarity level (500ms timeout)
        Try
            If FX3.SensorType <> DeviceType.ADcmXL Then
                'wait for toggle (500ms)
                FX3.MeasurePinFreq(FX3.DrPin, 0, 500, 3)
            Else
                'wait for busy to go high for ADcmXL
                FX3.PulseWait(FX3.DrPin, True, 100, 400)
            End If
        Catch ex As Exception
            'squash - don't want to throw error for PWM or special function pin
        End Try

        'generate new test value and save starting value
        randomValue = CInt(Math.Ceiling(Rnd() * &HFFF)) + 1
        orignalScratch = Dut.ReadUnsigned(scratchReg)

        Dut.WriteUnsigned(scratchReg, randomValue)
        If Not Dut.ReadUnsigned(scratchReg) = randomValue Then
            label_DUTStatus.Text = "ERROR: DUT Read/Write Failed"
            label_DUTStatus.BackColor = ERROR_COLOR
            testResult = False
        Else
            label_DUTStatus.Text = "DUT Connected"
            label_DUTStatus.BackColor = GOOD_COLOR
            testResult = True
        End If
        'restore value
        Dut.WriteUnsigned(scratchReg, orignalScratch)

        'restore DR active setting
        FX3.DrActive = drActive

        Return testResult
    End Function

    ''' <summary>
    ''' Check if the connected DUT has all registers at factory default values
    ''' </summary>
    ''' <returns>String containing list of all regs not at default values</returns>
    Friend Function CheckDUTFactoryDefaults() As String
        Dim goodRead As Boolean
        Dim invalidRegs As String

        invalidRegs = ""
        goodRead = True
        For Each reg In RegMap
            If Not IsNothing(reg.DefaultValue) Then
                If Dut.ReadUnsigned(reg) <> reg.DefaultValue Then
                    goodRead = False
                    invalidRegs += (reg.Label + ", ")
                End If
            End If
        Next
        If Not goodRead Then
            'remove lagging comma
            invalidRegs = invalidRegs.Remove(invalidRegs.Length - 2)
            Return ("Write to " + invalidRegs + " failed!")
        Else
            Return "Factory default values verified!"
        End If
    End Function

    ''' <summary>
    ''' Execute a command on a connected DUT
    ''' </summary>
    ''' <param name="CommandBit">Bit of the DUT command register to set</param>
    Friend Sub RunDUTCommand(CommandBit As Integer)

        'Need to find the COMMAND reg in the register map. Has a few possible names
        Dim cmdReg As RegClass = Nothing
        Dim cmdRegNames() As String = {"COMMAND", "GLOB_CMD", "USER_COMMAND"}

        'Exit if FX3 not connected
        If Not m_FX3Connected Then
            Return
        End If

        For Each regName In cmdRegNames
            If RegMap.Contains(regName) Then
                cmdReg = RegMap(regName)
                Exit For
            End If
        Next

        'issue write
        If (Not IsNothing(cmdReg)) And (CommandBit < 32) Then
            Dut.WriteUnsigned(cmdReg, 1UI << CommandBit)
        Else
            MessageBox.Show("No Command Register Found!")
        End If

    End Sub

#End Region

#Region "Helper Functions"

    Friend Sub ApplyBackgroundColors()
        'apply to all open forms
        For Each openForm As Form In Application.OpenForms
            openForm.BackColor = BACK_COLOR
        Next
        'apply to tabs
        For Each formPage As TabPage In dut_access.TabPages
            formPage.BackColor = BACK_COLOR
        Next
    End Sub

    ''' <summary>
    ''' Load DUT options from the CSV files packaged with the application to the 
    ''' DUTOptions list (of DUTPersonality)
    ''' </summary>
    Private Sub LoadDUTOptions()
        'load DUT personality file(s)
        DutOptions = DutPersonality.ParseFile(AppDomain.CurrentDomain.BaseDirectory + "UserConfig\custom_personality.csv")
        If DutOptions.Count = 0 Then
            'generate custom personality
            SaveCustomPersonality()
            DutOptions.Add(New DutPersonality())
        End If
        DutOptions.AddRange(DutPersonality.ParseFile(AppDomain.CurrentDomain.BaseDirectory + "UserConfig\dut_personalities.csv"))
        DutOptions.AddRange(DutPersonality.ParseFile(AppDomain.CurrentDomain.BaseDirectory + "UserConfig\aux_dut_personalities.csv"))
    End Sub

    ''' <summary>
    ''' Save a custom personality to the custom personality
    ''' CSV file in the application active directory
    ''' </summary>
    Private Sub SaveCustomPersonality()

        Dim path As String = AppDomain.CurrentDomain.BaseDirectory + "UserConfig\custom_personality.csv"
        Dim personality As New DutPersonality()
        personality.DisplayName = DutPersonality.CUSTOM_PERSONALITY_STRING
        If Not IsNothing(RegMapPath) Then personality.RegMapFileName = RegMapPath
        personality.IsLowerFirst = m_isLowerWordFirst
        If Not IsNothing(FX3) Then personality.GetSettingsFromFX3(FX3)

        'save to CSV
        DutPersonality.WriteToFile(path, personality)

    End Sub

    ''' <summary>
    ''' Populate all tool tip texts for the top GUI
    ''' </summary>
    Private Sub SetupToolTips()

        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(btn_APIInfo, "Get information about the version of the FX3 API being used, and the connected FX3 hardware")
        tip0.SetToolTip(btn_BitBangSPI, "Bit-bang custom SPI traffic to a DUT")
        tip0.SetToolTip(btn_BulkRegRead, "Stream register data to a .CSV file")
        tip0.SetToolTip(btn_CheckDUTConnection, "Check the SPI connection to the DUT by writing a random value to user scratch and reading it back. Restores the original user scratch register value afterwards")
        tip0.SetToolTip(btn_Connect, "Connect or disconnect from an EVAL-ADIS-FX3 board")
        tip0.SetToolTip(btn_FX3Config, "View or set all FX3 configuration options (SPI clock, stall time, etc)")
        tip0.SetToolTip(btn_plotFFT, "Stream and plot frequency domain DUT data in real time")
        tip0.SetToolTip(btn_SelectDUT, "Select the active DUT personality. Loads the default values for that DUT")
        tip0.SetToolTip(btn_RealTime, "Real time stream GUI (for ADcmXL type DUTs) or burst stream GUI (for all other DUTs)")
        tip0.SetToolTip(btn_plotData, "Plot DUT data in real time, or play back a DUT stream from a saved CSV file")
        tip0.SetToolTip(label_apiVersion, "The current version of the iSensor FX3 IMU Evaluation GUI. The three highest version numbers will match the FX3 API version in use")
        tip0.SetToolTip(regMapPath_Label, "The loaded register map file: " + RegMapPath)
        tip0.SetToolTip(report_issue, "Report an issue with the iSensor FX3 IMU Evaluation GUI. Requires a Internet connection and a GitHub account")
        tip0.SetToolTip(btn_ResetDUT, "Drives the reset pin low for 10ms, waits for data ready to be asserted, and checks the DUT connection")
        tip0.SetToolTip(checkVersion, "Checks for the latest release of the iSensor-FX3-GUI. Requires Internet connection")
        tip0.SetToolTip(btn_pulseMeasure, "Measure a DIO pulse width. Can send a pin or register trigger condition")
        tip0.SetToolTip(btn_BurstTest, "Test burst mode implementations with longer SPI transactions")
        tip0.SetToolTip(btn_binFile, "Generate a binary data file filled with an arbitrary pattern")
        tip0.SetToolTip(btn_ReadPage, "Read all registers on the selected page")
        tip0.SetToolTip(btn_WriteReg, "Write a new value to the selected register")
        tip0.SetToolTip(btn_writeRegMap, "Write all valid registers from a register dump file back to the connected DUT")
        tip0.SetToolTip(btn_DumpRegmap, "Read and log all registers in the register map to a CSV file")
        tip0.SetToolTip(btn_disableResistor, "Disable resistor on the input stage of the selected FX3 GPIO")
        tip0.SetToolTip(btn_pullDown, "Enable internal weak pull down resistor on the input stage of the selected FX3 GPIO")
        tip0.SetToolTip(btn_pullUp, "Enable internal weak pull up resistor on the input stage of the selected FX3 GPIO")
        tip0.SetToolTip(btn_StartPWM, "Start/Stop PWM signal generation on the selected DIO")
        tip0.SetToolTip(btn_PulseDrive, "Drive a single fixed duration pulse on the selected DIO")
        tip0.SetToolTip(btn_ReadAllPins, "Configure all DIO pins as inputs and read the input values")
        tip0.SetToolTip(btn_ReadPin, "Configure the selected DIO pin as an input and read the input value")
        tip0.SetToolTip(btn_WritePinLow, "Configure the selected DIO pin as an output and drive low")
        tip0.SetToolTip(btn_WritePinHigh, "Configure the selected DIO pin as an output and drive high")
        tip0.SetToolTip(btn_MeasureFreq, "Measure the toggle frequency on the selected DIO")
        tip0.SetToolTip(btn_ReadGPIO, "Configure the selected FX3 GPIO as an input and read the input value")
        tip0.SetToolTip(btn_SetGPIOHigh, "Configure the selected FX3 GPIO as an output and drive high")
        tip0.SetToolTip(btn_SetGPIOLow, "Configure the selected FX3 GPIO as an output and drive low")
        tip0.SetToolTip(btn_checkError, "Check the contents of the FX3 firmware error log")
        tip0.SetToolTip(contRead, "Read all registers on the selected page continuously (500ms interval)")
        tip0.SetToolTip(scaledData, "Display register data in hex or decimal")
        tip0.SetToolTip(btn_CRC4WordGen, "Generate a 32-bit SPI word with CRC4 (Seed 0xA) appended")
        tip0.SetToolTip(btn_MeasureUSB, "Measure the average USB command latency between the EVAL-ADIS-FX3 and the PC")
        tip0.SetToolTip(btn_FactoryReset, "Restore all DUT registers to factory defaults, and save the register settings to NVM")

    End Sub

    ''' <summary>
    ''' Save application settings to the config file. If a new setting is added, the
    ''' setting object must be updated here, or wherever the setting is changed
    ''' </summary>
    Friend Sub SaveAppSettings()
        'Save settings
        My.Settings.LastLeft = Left
        My.Settings.LastTop = Top
        My.Settings.LastWidth = Width
        My.Settings.LastHeight = Height
        My.Settings.LastFilePath = lastFilePath
        My.Settings.GoodColor = GOOD_COLOR
        My.Settings.ErrorColor = ERROR_COLOR
        My.Settings.IdleColor = IDLE_COLOR
        My.Settings.BackColor = BACK_COLOR
        My.Settings.LastFX3Board = FX3.ActiveFX3SerialNumber
        My.Settings.DutPersonality = SelectedPersonalityLabel
        My.Settings.LastValidDutPersonality = LastValidSelectedPersonality
        My.Settings.LogScaledData = logScaledData
        My.Settings.LogTimestampData = logTimestampData
        'serialize plot settings and save. Should probably refactor this
        Dim serializer As New XmlSerializer(GetType(PlotterSettings))
        Using writer As New StringWriter
            serializer.Serialize(writer, plotSettings)
            My.Settings.PlotSettings = writer.ToString()
        End Using
        My.Settings.Save()
        If SelectedPersonalityLabel = DutPersonality.CUSTOM_PERSONALITY_STRING Then
            SaveCustomPersonality()
        End If
    End Sub

    ''' <summary>
    ''' Friend getter for last connected FX3 board SN. This is used by the
    ''' FX3 selection GUI to ensure that the last board in use is the default
    ''' board selected
    ''' </summary>
    ''' <returns>SN of the previously connected board</returns>
    Friend ReadOnly Property LastFX3SN As String
        Get
            Return My.Settings.LastFX3Board
        End Get
    End Property

    ''' <summary>
    ''' Loads default application color scheme
    ''' </summary>
    Friend Sub LoadDefaultColors()

        GOOD_COLOR = Color.Chartreuse
        ERROR_COLOR = Color.Red
        IDLE_COLOR = Color.Yellow
        BACK_COLOR = SystemColors.Control

        BackColor = BACK_COLOR

    End Sub

    ''' <summary>
    ''' Reboot connected FX3 board
    ''' </summary>
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
    ''' Update the IDUTInterface (and labels) after changing the part 
    ''' </summary>
    ''' <param name="DutType">Desired DUT type</param>
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
        ElseIf FX3.SensorType = DeviceType.ComponentSensor Then
            Dut = New ComponentInterface(m_CompSpi, Nothing)
        Else
            Dut = New adbfInterface(FX3, Nothing)
        End If

        'update lower word first setting
        Dut.IsLowerFirst = m_isLowerWordFirst

        If Not IsNothing(FX3.ActiveFX3) Then TestDUT()

    End Sub

    ''' <summary>
    ''' Check that all register maps listed in the DUT personalities
    ''' manifest file exist
    ''' </summary>
    Private Sub CheckRegmapResources()
        Dim savedRegmapPath As String = ""

        For Each item In DutOptions
            If item.DisplayName <> DutPersonality.CUSTOM_PERSONALITY_STRING Then
                savedRegmapPath = AppDomain.CurrentDomain.BaseDirectory + "RegMaps\" + item.RegMapFileName
                If Not File.Exists(savedRegmapPath) Then
                    MsgBox("Register map " + savedRegmapPath + " Not found!")
                    Exit Sub
                End If
            End If
        Next

    End Sub

    ''' <summary>
    ''' Load register map based on selected personality. This does not change
    ''' any FX3 settings, just the register map, so it can be safely called before
    ''' the FX3 is connected
    ''' </summary>
    ''' <param name="displayName">Personality name</param>
    Friend Sub ApplyDutPersonalityRegmap(displayName As String)

        Dim savedRegmapPath As String = ""

        'Set the register map path using the SelectRegMap GUI
        For i As Integer = 0 To DutOptions.Count - 1
            If DutOptions(i).DisplayName = displayName Then
                'Save selected personality for use later
                SelectedPersonality = DutOptions(i)
                'load DUT endianness setting here
                m_isLowerWordFirst = DutOptions(i).IsLowerFirst
                If displayName = DutPersonality.CUSTOM_PERSONALITY_STRING Then
                    'custom uses absolute path
                    savedRegmapPath = DutOptions(i).RegMapFileName
                Else
                    savedRegmapPath = AppDomain.CurrentDomain.BaseDirectory + "RegMaps\" + DutOptions(i).RegMapFileName
                End If
                Exit For
            End If
        Next
        If Not File.Exists(savedRegmapPath) Then
            'go to custom personality and manually select register map
            SelectedPersonalityLabel = DutPersonality.CUSTOM_PERSONALITY_STRING
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
                If DutOptions(i).DisplayName = DutPersonality.CUSTOM_PERSONALITY_STRING Then
                    DutOptions(i).RegMapFileName = RegMapPath
                End If
            Next
        Else
            RegMapPath = savedRegmapPath
        End If

    End Sub

    ''' <summary>
    ''' Apply a selected DUT personality to the FX3
    ''' </summary>
    ''' <param name="displayName">Name of the selected personality</param>
    ''' <returns>If the personality selected was successful</returns>
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

        'Save personality last applied for use elsewhere
        SelectedPersonality = personality

        If (personality.Supply = DutVoltage.On5_0Volts) And (FX3.ActiveFX3.BoardType <> FX3BoardType.CypressFX3Board) Then
            If MessageBox.Show("Enabling 5V supply can cause damage to 3.3V devices - Continue?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> DialogResult.OK Then
                Return False
            End If
        End If

        'Note - VDDIO is not used currently
        If personality.VDDIO <> 3.3 Then
            If MessageBox.Show("FX3 directly supports VDDIO of 3.3V, other values may cause damage - Continue?", "Confirmation",
                               MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) <> DialogResult.OK Then
                Return False
            End If
        End If

        'apply settings
        If Not IsNothing(FX3.ActiveFX3) Then personality.ApplySettingsToFX3(FX3)
        If FX3.SensorType = DeviceType.ComponentSensor Then personality.ApplyComponentSpiSettings(m_CompSpi)

        'apply the isLowerfirst option to the DUT object
        If Not IsNothing(Dut) Then Dut.IsLowerFirst = personality.IsLowerFirst
        'save setting
        m_isLowerWordFirst = personality.IsLowerFirst

        'Save personality setting
        SelectedPersonalityLabel = displayName
        If SelectedPersonalityLabel <> DutPersonality.CUSTOM_PERSONALITY_STRING Then
            LastValidSelectedPersonality = SelectedPersonalityLabel
        End If

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

        label_FX3Status.Text = "Connected to " + [Enum].GetName(GetType(FX3BoardType), FX3.ActiveFX3.BoardType) +
            " (SN: " + FX3.ActiveFX3SerialNumber + ")"
        label_FX3Status.BackColor = GOOD_COLOR
        btn_Connect.Text = "Reboot FX3"

        'Select DUT access panel initially
        dut_access.Select()

        'Load settings
        ApplyDutPersonality(SelectedPersonalityLabel)

        'disable watchdog
        FX3.WatchdogEnable = False

        'Test the DUT
        UpdateDutLabel(FX3.PartType)

        'disable buttons for any existing open forms
        DisableOpenFormButtons()

        'Initialize pin tab
        PinTabInit()

    End Sub

    ''' <summary>
    ''' Ask user if they wish to reset all connected FX3 boards, and perform
    ''' the reset if the user selects yes
    ''' </summary>
    ''' <returns>The user selected (reset or not)</returns>
    Private Function ResetAllFX3s() As Boolean
        Dim answer = MsgBox("This will reset all " + FX3.BusyFX3s.Count.ToString() +
                            " connected FX3 board(s). Are you sure you want to continue?", MsgBoxStyle.OkCancel)
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
        'kill register form timers
        pageReadTimer.Enabled = False
        drReadTimer.Enabled = False
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

    ''' <summary>
    ''' Populate the DUT type label based on the current FX3 settings and selected
    ''' DUT personality. Also updates the visibility on any DUT type specific controls
    ''' </summary>
    Private Sub SetDUTTypeLabel()
        label_DUTType.BackColor = GOOD_COLOR
        label_DUTType.Text = SelectedPersonalityLabel + " - " + FX3.SensorType.ToString() +
            ": " + FX3.PartType.ToString() +
            ", Supply " + FX3.DutSupplyMode.ToString()

        'set register form sensor type (for auto SPI)
        RegFormUpdateSensorType()

        'check if we are using an ADcmXL
        If FX3.SensorType = DeviceType.ADcmXL Then
            btn_ADcmXlBufCapture.Visible = True
        Else
            btn_ADcmXlBufCapture.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Sets the GUI state when an FX3 disconnect timeout event occurs
    ''' </summary>
    Private Sub UpdateTimeoutLabels()
        ResetButtons()
        ResetLabels()
        label_FX3Status.Text = "Error: Disconnect timed out"
        label_FX3Status.BackColor = ERROR_COLOR
    End Sub

    ''' <summary>
    ''' Halt any background operations on the top GUI and
    ''' close all open sub-forms
    ''' </summary>
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
            If InvokeRequired Then
                BeginInvoke(Sub() runningForm.Close())
            Else
                runningForm.Close()
            End If
        Next
    End Sub

    ''' <summary>
    ''' Goes through all open sub-forms and ensures that the corresponding 
    ''' button for that form is disabled. This is done to ensure the user cannot
    ''' open two instances of the same form.
    ''' </summary>
    Private Sub DisableOpenFormButtons()
        For Each openForm As Form In Application.OpenForms
            If TypeOf (openForm) Is FX3ConfigGUI Then btn_FX3Config.Enabled = False
            If TypeOf (openForm) Is RegisterBulkReadGUI Then btn_BulkRegRead.Enabled = False
            If TypeOf (openForm) Is ApiInfoGUI Then btn_APIInfo.Enabled = False
            If TypeOf (openForm) Is FrequencyPlotGUI Then btn_plotFFT.Enabled = False
            If TypeOf (openForm) Is DataPlotGUI Then btn_plotData.Enabled = False
            If TypeOf (openForm) Is IMUStreamingGUI Then btn_RealTime.Enabled = False
            If TypeOf (openForm) Is ADcmXLStreamingGUI Then btn_RealTime.Enabled = False
            If TypeOf (openForm) Is ADcmXLBufferedLogGUI Then btn_ADcmXlBufCapture.Enabled = False
            If TypeOf (openForm) Is SelectDUTGUI Then btn_SelectDUT.Enabled = False
            If TypeOf (openForm) Is BurstTestGUI Then btn_BurstTest.Enabled = False
            If TypeOf (openForm) Is PulseMeasureGUI Then btn_pulseMeasure.Enabled = False
            If TypeOf (openForm) Is BinaryFileWriterGUI Then btn_binFile.Enabled = False
            If TypeOf (openForm) Is NVMInterfaceGUI Then btn_checkError.Enabled = False
            If TypeOf (openForm) Is FacResetGUI Then btn_FactoryReset.Enabled = False
        Next
    End Sub

    ''' <summary>
    ''' Property override to allow the form to open without taking focus
    ''' </summary>
    ''' <returns>True</returns>
    Protected Overrides ReadOnly Property ShowWithoutActivation() As Boolean
        Get
            Return True
        End Get
    End Property

#End Region

#Region "Data Plotting"

    'Variables to track sub-form size
    Friend TimePlotWidth, TimePlotHeight, FFTPlotWidth, FFTPlotHeight As Integer

    ''' <summary>
    ''' Initialize data plotting register list on top form. This register list is shared
    ''' between the time domain and frequency domain plotters
    ''' </summary>
    Friend Sub DataPlotRegsInit()
        Dim regIndex As Integer = 0
        Dim regStr() As String
        'clear when register map is changed
        dataPlotRegs.Clear()

        dataPlotRegsView.Rows.Clear()
        For Each reg In RegMap
            If reg.IsReadable Then
                regStr = {reg.Label, "False"}
                dataPlotRegsView.Rows.Add(regStr)
                regIndex += 1
            End If
        Next
        dataPlotRegsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        dataPlotRegsView.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill

        'Populate the plot settings based on the loaded regmap / personality
        If SelectedPersonality.DefaultPlotRegs <> "" Then
            Dim defaultRegInfo As String() = SelectedPersonality.DefaultPlotRegs.Split(" ")
            'Reset plot info
            dataPlotRegs.Clear()
            plotSettings.NumberPlots = 0
            Try
                For i As Integer = 0 To (defaultRegInfo.Length - 1) Step 2
                    Dim pattern As String = defaultRegInfo(i)
                    Dim plotIndex As Integer = Convert.ToInt32(defaultRegInfo(i + 1))
                    'Limit to 3 matches per plot
                    Dim matchCount As Integer = 0
                    For Each reg In RegMap
                        If reg.Label.Contains(pattern) Then
                            dataPlotRegs.Add(New RegPlotterInfo With {.Reg = reg, .Index = plotIndex})
                            matchCount += 1
                        End If
                        If matchCount >= 3 Then Exit For
                    Next
                    If matchCount > 0 Then plotSettings.NumberPlots += 1
                Next
            Catch ex As Exception
                'Don't configure
                Return
            End Try
            'Update checks in top GUI based on new defaults loaded
            SaveDataPlotRegList()
        End If

    End Sub

    ''' <summary>
    ''' Set the plotter reg list based on the registers selected by the user
    ''' </summary>
    Private Sub LoadDataPlotRegList()
        Dim regFound As Boolean
        Dim newRegList As New List(Of RegPlotterInfo)
        For Each row As DataGridViewRow In dataPlotRegsView.Rows
            If row.Cells(1).Value Then
                'check if regplotterinfo has already been saved
                regFound = False
                For Each reg In dataPlotRegs
                    If reg.Reg.Label = row.Cells(0).Value Then
                        regFound = True
                        newRegList.Add(reg)
                        Exit For
                    End If
                Next
                If Not regFound Then
                    newRegList.Add(New RegPlotterInfo With {.Reg = RegMap(row.Cells(0).Value)})
                End If
            End If
        Next
        'update the data plot regs list with the new reglist contents
        dataPlotRegs.Clear()
        For Each reg In newRegList
            dataPlotRegs.Add(reg)
        Next
    End Sub

    ''' <summary>
    ''' Update the selected registers based on the current plotter reg list
    ''' </summary>
    Friend Sub SaveDataPlotRegList()
        dataPlotRegsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        Dim regFound As Boolean
        For Each row As DataGridViewRow In dataPlotRegsView.Rows
            'check if register is selected
            regFound = False
            For Each reg In dataPlotRegs
                If reg.Reg.Label = row.Cells(0).Value.ToString() Then
                    regFound = True
                    Exit For
                End If
            Next
            row.Cells(1).Value = regFound
        Next
        dataPlotRegsView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
    End Sub

#End Region

End Class