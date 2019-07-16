Imports FX3Api
Imports RegMapClasses
Imports System.IO
Imports System.Reflection
Imports System.Timers

Public Class TopLevelGUI
    Private FX3Connected As Boolean
    Private WithEvents conn As Connection
    Private firmwarePath As String
    Private regMapPath As String
    Private WithEvents disconnectTimer As Timer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Dim firmwarePath As String
        Dim blinkFirmwarePath As String
        Dim regMapPath As String

        'Create a local copy of embedded firmware file
        Dim firmwareResource As String = "FX3Gui.FX3_Firmware.img"
        firmwarePath = System.Reflection.Assembly.GetExecutingAssembly.Location
        firmwarePath = firmwarePath.Substring(0, firmwarePath.LastIndexOf("\") + 1)
        firmwarePath = firmwarePath + "FX3_Firmware.img"
        Dim assembly = System.Reflection.Assembly.GetExecutingAssembly()
        Dim outputStream As New FileStream(firmwarePath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Create a local copy of bootloader firmware file
        firmwareResource = "FX3Gui.boot_fw.img"
        blinkFirmwarePath = System.Reflection.Assembly.GetExecutingAssembly.Location
        blinkFirmwarePath = blinkFirmwarePath.Substring(0, blinkFirmwarePath.LastIndexOf("\") + 1)
        blinkFirmwarePath = blinkFirmwarePath + "boot_fw.img"
        assembly = System.Reflection.Assembly.GetExecutingAssembly()
        outputStream = New FileStream(blinkFirmwarePath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Create local copy of regmap CSV
        firmwareResource = "FX3Gui.adcmxl3021_regmap_adisAPI.csv"
        regMapPath = System.Reflection.Assembly.GetExecutingAssembly.Location
        regMapPath = regMapPath.Substring(0, regMapPath.LastIndexOf("\") + 1)
        regMapPath = regMapPath + "adcmxl3021_regmap_adisAPI.csv"
        assembly = System.Reflection.Assembly.GetExecutingAssembly()
        outputStream = New FileStream(regMapPath, FileMode.Create)
        assembly.GetManifestResourceStream(firmwareResource).CopyTo(outputStream)
        outputStream.Close()

        'Set connection
        conn = New Connection()
        conn.FX3 = New FX3Connection(firmwarePath, blinkFirmwarePath, FX3Api.DeviceType.ADcmXL)

        conn.RegMap = New RegMapCollection
        conn.RegMap.ReadFromCSV(regMapPath)

        'Add exception handler
        AddHandler AppDomain.CurrentDomain.UnhandledException, AddressOf GeneralErrorHandler

        'Seed random number generator
        Randomize()

        'Initialize status box
        StatusText.Text = "Not Connected"
        StatusText.BackColor = Color.Yellow

        'Initialize variables
        FX3Connected = False

        DUTStatusBox.Text = "Waiting For FX3 to Connect"
        DUTStatusBox.BackColor = Color.Yellow

        'Disable buttons initially
        FX3BoardInfoBtn.Enabled = FX3Connected
        RegisterAccess.Enabled = FX3Connected
        ManualMode.Enabled = FX3Connected
        configureSPI.Enabled = FX3Connected
        checkConnection.Enabled = FX3Connected
        ReadPinButton.Enabled = FX3Connected
        ResetDUTButton.Enabled = FX3Connected
        ResetButton.Enabled = FX3Connected
        TextFileStreamingButton.Enabled = FX3Connected
        APIInfoBtn.Enabled = FX3Connected

        'Update the part type to 3021
        conn.FX3.PartType = DUTType.ADcmXL3021

        'register timeout event handler
        disconnectTimer = New Timer(10000)
        AddHandler disconnectTimer.Elapsed, New ElapsedEventHandler(AddressOf timeoutHandler)

    End Sub

    ''' <summary>
    ''' Event handler for when the board is unplugged
    ''' </summary>
    ''' <param name="FX3SerialNumber">Serial Number of the board which generated the event</param>
    Public Sub DisconnectHandler(FX3SerialNumber As String) Handles conn.UnexpectedDisconnect

        'Reset GUI state
        conn.FX3.Disconnect()
        FX3Connected = False
        'Disable buttons
        FX3BoardInfoBtn.Enabled = FX3Connected
        RegisterAccess.Enabled = FX3Connected
        ManualMode.Enabled = FX3Connected
        configureSPI.Enabled = FX3Connected
        checkConnection.Enabled = FX3Connected
        ReadPinButton.Enabled = FX3Connected
        ResetDUTButton.Enabled = FX3Connected
        TextFileStreamingButton.Enabled = FX3Connected
        APIInfoBtn.Enabled = FX3Connected
        ResetButton.Enabled = False
        ConnectButton.Enabled = True

        'Special error message
        StatusText.Text = "ERROR: FX3 Connection Lost"
        StatusText.BackColor = Color.Red
        DUTStatusBox.Text = "ERROR: FX3 Connection Lost"
        DUTStatusBox.BackColor = Color.Red

    End Sub

    ''' <summary>
    ''' When the disconnect event finishes re-enable the connect button if needed.
    ''' </summary>
    ''' <param name="FX3SN"></param>
    ''' <param name="DisconnectTime"></param>
    Public Sub DisconnectFinishedHandler(FX3SN As String, DisconnectTime As Integer) Handles conn.DisconnectFinished
        ConnectButton.Enabled = True
        StatusText.Text = "FX3 Reset"
        StatusText.BackColor = Color.Yellow
        disconnectTimer.Enabled = False
    End Sub

    Private Sub ConnectButton_Click(sender As Object, e As EventArgs) Handles ConnectButton.Click

        'Exit if no available FX3's
        Dim boardsInUse As Integer = conn.FX3.BusyFX3s.Count
        Dim ResetResult As MsgBoxResult
        If conn.FX3.AvailableFX3s.Count = 0 Then
            If boardsInUse > 0 Then
                ResetResult = MsgBox("ERROR: All " + boardsInUse.ToString() + " connected board(s) are currently in use. Attempt to reset all boards?", MsgBoxStyle.YesNo)
                If ResetResult = MsgBoxResult.Yes Then
                    conn.FX3.ResetAllFX3s()
                End If
            End If
            FX3Connected = False
            StatusText.Text = "ERROR: No FX3 Attached"
            StatusText.BackColor = Color.Red
            Exit Sub
        End If

        'Get list of connected FX3s and pop up selection window if more than one is detected
        If conn.FX3.AvailableFX3s.Count > 1 Then
            'Create a new instance of the selection form and show the dialog box. Block until the box is closed.
            Dim selectFX3 = New SelectFX3GUI()
            selectFX3.SetConn(conn)
            selectFX3.ShowDialog()
            'Check to make sure the user actually selected a board
            If conn.FX3.ActiveFX3SerialNumber Is Nothing Then
                MessageBox.Show("Please select an FX3 board to connect to.", "Invalid FX3 selected!", MessageBoxButtons.OK)
                Exit Sub
            End If
            'Connect to the selected board
            conn.FX3.Connect(conn.FX3.ActiveFX3SerialNumber)
        Else
            'Select the first (and only) board in the list
            conn.FX3.Connect(conn.FX3.AvailableFX3s(0))
        End If

        FX3Connected = conn.FX3.FX3CodeRunningOnTarget
        FX3BoardInfoBtn.Enabled = FX3Connected
        RegisterAccess.Enabled = FX3Connected
        ManualMode.Enabled = FX3Connected
        configureSPI.Enabled = FX3Connected
        checkConnection.Enabled = FX3Connected
        ReadPinButton.Enabled = FX3Connected
        ResetDUTButton.Enabled = FX3Connected
        TextFileStreamingButton.Enabled = FX3Connected
        APIInfoBtn.Enabled = FX3Connected
        ResetButton.Enabled = FX3Connected
        ConnectButton.Enabled = False
        TestDUT()
        If FX3Connected Then
            StatusText.Text = "Connected to FX3"
            StatusText.BackColor = Color.Green
        Else
            StatusText.Text = "Programming FX3 Failed"
            StatusText.BackColor = Color.Red
        End If

    End Sub

    Private Sub TestDUT()
        Dim randomValue As UInteger = CInt(Math.Ceiling(Rnd() * &HFFF)) + 1
        Dim DUTValue As UInteger

        If conn.FX3.PartType = DUTType.ADcmXL3021 Then
            conn.Dut = New adisInterface.AdcmInterface3Axis(conn.FX3)
        ElseIf conn.FX3.PartType = DUTType.ADcmXL2021 Then
            conn.Dut = New adisInterface.AdcmInterface2Axis(conn.FX3)
        ElseIf conn.FX3.PartType = DUTType.ADcmXL1021 Then
            conn.Dut = New adisInterface.AdcmInterface1Axis(conn.FX3)
        End If

        If FX3Connected Then
            conn.Dut.WriteUnsigned(conn.RegMap("USER_SCRATCH"), randomValue)
            DUTValue = conn.Dut.ReadUnsigned(conn.RegMap("USER_SCRATCH"))
            If Not DUTValue = randomValue Then
                DUTStatusBox.Text = "ERROR: DUT Read/Write Failed"
                DUTStatusBox.BackColor = Color.Red
            ElseIf conn.FX3.ReadPin(conn.FX3.DIO2) = 0 Then
                DUTStatusBox.Text = "ERROR: DUT Busy line low"
                DUTStatusBox.BackColor = Color.Red
            Else
                DUTStatusBox.Text = "DUT Connected"
                DUTStatusBox.BackColor = Color.Green
            End If
        End If
    End Sub

    Private Sub RegisterAccess_Click(sender As Object, e As EventArgs) Handles RegisterAccess.Click
        If FX3Connected Then
            Dim regAccess = New registerAccessGUI()
            regAccess.SetConn(conn)
            regAccess.Show()
            Hide()
        Else
            MsgBox("ERROR: FX3 not connected")
        End If
    End Sub

    Private Sub ManualMode_Click(sender As Object, e As EventArgs) Handles ManualMode.Click
        If FX3Connected Then
            Dim manualMode = New manualModeGUI()
            manualMode.SetConn(conn)
            manualMode.Show()
            Hide()
        Else
            MsgBox("ERROR: FX3 not connected")
        End If
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs) Handles ResetButton.Click

        conn.FX3.Disconnect()
        FX3Connected = False
        'Disable buttons
        FX3BoardInfoBtn.Enabled = FX3Connected
        RegisterAccess.Enabled = FX3Connected
        ManualMode.Enabled = FX3Connected
        configureSPI.Enabled = FX3Connected
        checkConnection.Enabled = FX3Connected
        ReadPinButton.Enabled = FX3Connected
        ResetDUTButton.Enabled = FX3Connected
        TextFileStreamingButton.Enabled = FX3Connected
        APIInfoBtn.Enabled = FX3Connected
        ConnectButton.Enabled = True
        ResetButton.Enabled = False

        StatusText.Text = "FX3 Reset"
        DUTStatusBox.Text = "Waiting for FX3 to connect"
        StatusText.BackColor = Color.Yellow
        DUTStatusBox.BackColor = Color.Yellow

        'Start a time out event (10 seconds)
        disconnectTimer.Enabled = True
        StatusText.Text = "FX3 Rebooting"
        ConnectButton.Enabled = False

    End Sub

    Private Sub timeoutHandler(source As Object, e As ElapsedEventArgs)
        disconnectTimer.Enabled = False
        'Timers run in a seperate thread from GUI
        Me.BeginInvoke(New MethodInvoker(AddressOf updateLabels))
    End Sub

    Private Sub updateLabels()
        ConnectButton.Enabled = True
        StatusText.Text = "Error: Disconnect timed out"
        StatusText.BackColor = Color.Red
    End Sub

    Private Sub readIDButton_Click(sender As Object, e As EventArgs) Handles FX3BoardInfoBtn.Click
        MsgBox(conn.FX3.ActiveFX3.ToString())
    End Sub

    Private Sub checkConnection_Click(sender As Object, e As EventArgs) Handles checkConnection.Click
        TestDUT()
    End Sub

    Private Sub configureSPI_Click(sender As Object, e As EventArgs) Handles configureSPI.Click
        If FX3Connected Then
            Dim spiSetup = New SpiSetupGUI()
            SpiSetupGUI.SetConn(conn)
            SpiSetupGUI.Show()
            Hide()
        Else
            MsgBox("ERROR: FX3 not connected")
        End If
    End Sub

    Private Sub ReadPinButton_Click(sender As Object, e As EventArgs) Handles ReadPinButton.Click
        Dim GPIONumber As Integer
        Try
            GPIONumber = Convert.ToInt32(InputBox("Enter GPIO Pin Number: ", "", "0"))
            If GPIONumber > 63 Or GPIONumber < 0 Then
                Throw New IndexOutOfRangeException
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid Pin Number")
            Exit Sub
        End Try
        Dim pinValue As UInteger = conn.FX3.ReadPin(New FX3PinObject(GPIONumber))
        MsgBox("Pin " + GPIONumber.ToString + ": " + pinValue.ToString())
    End Sub

    Private Sub TextFileStreamingButton_Click(sender As Object, e As EventArgs) Handles TextFileStreamingButton.Click
        If FX3Connected Then
            Dim realTimeStream = New TextFileStreamManagerStreaming()
            realTimeStream.SetConn(conn)
            realTimeStream.Show()
            Hide()
        Else
            MsgBox("ERROR: FX3 not connected")
        End If
    End Sub

    Private Sub ResetDUTButton_Click(sender As Object, e As EventArgs) Handles ResetDUTButton.Click

        conn.FX3.Reset()
        TestDUT()

    End Sub

    Private Sub Cleanup(sender As Object, e As EventArgs) Handles Me.Closing
        If FX3Connected Then
            conn.FX3.Disconnect()
        End If
    End Sub

    Private Sub TopLevelGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = "FX3 Evaluation GUI"
    End Sub

    'General exception handeler
    Public Sub GeneralErrorHandler(sender As Object, e As UnhandledExceptionEventArgs)
        FX3Connected = False
        StatusText.Text = "ERROR: Unhandled Exception Occured"
        StatusText.BackColor = Color.Red
        DUTStatusBox.Text = "Waiting for FX3 to connect"
        DUTStatusBox.BackColor = Color.Yellow
    End Sub

    Private Sub APIInfoBtn_Click(sender As Object, e As EventArgs) Handles APIInfoBtn.Click
        MsgBox(conn.FX3.GetFX3ApiInfo.ToString())
    End Sub

End Class