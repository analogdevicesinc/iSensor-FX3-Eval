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
Imports AdisApi

Public Class TopGUI

    'Public member variables accessable to all forms
    Public WithEvents FX3 As FX3Connection
    Public RegMap As RegMapCollection
    Public Dut As IDutInterface

    'Private member variables
    Private m_FX3Connected As Boolean
    Private WithEvents m_disconnectTimer As Timer
    Private m_RegMapPath As String
    Private m_AutoSpi As iSensorAutomotiveSpi

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim firmwarePath As String
        Dim blinkFirmwarePath As String

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

        'Set the regmap path using the SelectRegMap GUI
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

        'Set FX3 connection (defaults to ADcmXL)
        FX3 = New FX3Connection(firmwarePath, blinkFirmwarePath, FX3Api.DeviceType.IMU)

        'Seed random number generator
        Randomize()

        'Set button and label initial values
        ResetButtons()
        ResetLabels()

        'Initialize variables
        m_FX3Connected = False

        'register timeout event handler
        m_disconnectTimer = New Timer(10000)
        m_disconnectTimer.Enabled = False
        AddHandler m_disconnectTimer.Elapsed, New ElapsedEventHandler(AddressOf timeoutHandler)

        'Add exception handler
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GeneralErrorHandler

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
            Catch ex As Exception
                MsgBox("ERROR: Invalid RegMap Selected! " + ex.Message())
            End Try
        End Set
    End Property

#End Region

#Region "Button Event Handlers"
    Private Sub btn_DisconnectFX3_Click(sender As Object, e As EventArgs) Handles btn_DisconnectFX3.Click

        'Send disconnect command
        FX3.Disconnect()
        ResetButtons()
        ResetLabels()
        btn_Connect.Enabled = False
        label_FX3Status.Text = "FX3 Rebooting"

        'Start a timeout counter
        m_disconnectTimer.Enabled = True

    End Sub

    Private Sub btn_Connect_Click(sender As Object, e As EventArgs) Handles btn_Connect.Click
        ConnectWork()
    End Sub

    Private Sub btn_SelectDUT_Click(sender As Object, e As EventArgs) Handles btn_SelectDUT.Click
        Dim subGUI As New SelectDUTGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_ResetDUT_Click(sender As Object, e As EventArgs) Handles btn_ResetDUT.Click
        FX3.Reset()
        TestDUT()
    End Sub

    Private Sub btn_RegAccess_Click(sender As Object, e As EventArgs) Handles btn_RegAccess.Click
        Dim subGUI As New registerAccessGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_RealTime_Click(sender As Object, e As EventArgs) Handles btn_RealTime.Click

        If FX3.PartType = DUTType.IMU Then
            'For IMU's create a new IMU streaming GUI
            Dim subGUI As New IMUStreamingGUI()
            subGUI.Show()
            Me.Hide()
        Else
            'For machine health create a ADcmXLStreamingGUI
            Dim subGUI As New ADcmXLStreamingGUI()
            subGUI.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub btn_BulkRegRead_Click(sender As Object, e As EventArgs) Handles btn_BulkRegRead.Click
        Dim subGUI As New RegisterBulkReadGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_PinAccess_Click(sender As Object, e As EventArgs) Handles btn_PWMSetup.Click
        Dim subGUI As New PWMSetupGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_FX3Config_Click(sender As Object, e As EventArgs) Handles btn_FX3Config.Click
        Dim subGUI As New FX3ConfigGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_CheckDUTConnection_Click(sender As Object, e As EventArgs) Handles btn_CheckDUTConnection.Click
        TestDUT()
    End Sub

    Private Sub btn_BoardInfo_Click(sender As Object, e As EventArgs) Handles btn_BoardInfo.Click
        Dim fx3info As FX3Api.FX3Board = FX3.ActiveFX3
        MsgBox("Firmware Version: " + fx3info.FirmwareVersion + Environment.NewLine + "Serial Number: " + fx3info.SerialNumber + Environment.NewLine + "Uptime: " + fx3info.Uptime.ToString() + "ms")
    End Sub

    Private Sub btn_APIInfo_Click(sender As Object, e As EventArgs) Handles btn_APIInfo.Click
        Dim subGUI As New ApiInfoGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_measurePulse_Click(sender As Object, e As EventArgs) Handles btn_measurePulse.Click
        Dim subGUI As New PulseMeasureGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_PinAccess_Click_1(sender As Object, e As EventArgs) Handles btn_PinAccess.Click
        Dim subGUI As New PinAccessGUI()
        subGUI.Show()
        Me.Hide()
    End Sub

    Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_test.Click
        'Whatever code you want

        Dim timer As New Stopwatch()
        timer.Start()
        For i As Integer = 0 To 10000
            Dut.ReadUnsigned(RegMap("MSC_CTRL"))
        Next
        timer.Stop()
        MsgBox(timer.ElapsedMilliseconds() / 10000)


    End Sub

#End Region

#Region "Other Event Handlers"

    ''' <summary>
    ''' This event handler is used to allow for asynchronous timeouts when reconnecting to an FX3 which was previously disconnected.
    ''' </summary>
    Private Sub timeoutHandler()
        m_disconnectTimer.Enabled = False
        'Timers run in a seperate thread from GUI
        Me.BeginInvoke(New MethodInvoker(AddressOf updateTimeoutLabels))
    End Sub

    Private Sub Cleanup(sender As Object, e As EventArgs) Handles Me.Closing
        'Disconnect the FX3 (does nothing if not already connected)
        FX3.Disconnect()
    End Sub

    'General exception handeler
    Public Sub GeneralErrorHandler(sender As Object, e As UnhandledExceptionEventArgs)
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

    Friend Sub UpdateDutLabel(DutType As DUTType)
        label_DUTType.BackColor = Color.Green
        label_DUTType.Text = FX3.SensorType.ToString() + ": " + FX3.PartType.ToString()

        TestDUT()

    End Sub

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
            End If
        Else
            label_FX3Status.BackColor = Color.Red
            label_FX3Status.Text = "ERROR: No FX3 connected"
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
        btn_Connect.Enabled = False 'Disable connect
        btn_DisconnectFX3.Enabled = True
        btn_FX3Config.Enabled = True
        btn_PWMSetup.Enabled = True
        btn_RealTime.Enabled = True
        btn_RegAccess.Enabled = True
        btn_ResetDUT.Enabled = True
        btn_SelectDUT.Enabled = True
        btn_measurePulse.Enabled = True
        btn_PinAccess.Enabled = True
        btn_test.Enabled = True

        label_FX3Status.Text = "FX3 Connected"
        label_FX3Status.BackColor = Color.Green

        'Select register access button initially
        btn_RegAccess.Select()

        'Test the DUT
        TestDUT()

    End Sub

    Private Function ResetAllFX3s() As Boolean
        Dim answer = MsgBox("This will reset all " + FX3.BusyFX3s.Count.ToString() + " connected FX3 board(s). Are you sure you want to continue?", MsgBoxStyle.OkCancel)
        If answer = MsgBoxResult.Cancel Then
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
        btn_DisconnectFX3.Enabled = False
        btn_FX3Config.Enabled = False
        btn_PWMSetup.Enabled = False
        btn_RealTime.Enabled = False
        btn_RegAccess.Enabled = False
        btn_ResetDUT.Enabled = False
        btn_SelectDUT.Enabled = False
        btn_measurePulse.Enabled = False
        btn_PinAccess.Enabled = False
        btn_test.Enabled = False
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
        label_DUTType.Text = FX3.PartType.ToString()
    End Sub

    ''' <summary>
    ''' Sets the lables when a timeout event occurs
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

        Try
            scratchReg = RegMap("USER_SCRATCH")
        Catch ex As Exception
        End Try

        If IsNothing(scratchReg) Then
            Try
                scratchReg = RegMap("USER_SCR_2")
            Catch ex As Exception
                label_DUTStatus.Text = "ERROR: No Scratch Register in RegMap"
                label_DUTStatus.BackColor = Color.Red
                Exit Sub
            End Try
        End If
        Dim randomValue As UInteger = CInt(Math.Ceiling(Rnd() * &HFFF)) + 1

        If FX3.PartType = DUTType.ADcmXL3021 Then
            Dut = New AdcmInterface3Axis(FX3)
        ElseIf FX3.PartType = DUTType.ADcmXL2021 Then
            Dut = New AdcmInterface2Axis(FX3)
        ElseIf FX3.PartType = DUTType.ADcmXL1021 Then
            Dut = New AdcmInterface1Axis(FX3)
        Else
            Dut = New adbfInterface(FX3, Nothing)
        End If

        Dut.WriteUnsigned(scratchReg, randomValue)
        If Not Dut.ReadUnsigned(scratchReg) = randomValue Then
            label_DUTStatus.Text = "ERROR: DUT Read/Write Failed"
            label_DUTStatus.BackColor = Color.Red
        Else
            label_DUTStatus.Text = "DUT Connected"
            label_DUTStatus.BackColor = Color.Green
        End If

    End Sub

#End Region

End Class