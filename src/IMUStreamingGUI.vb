'File:          IMUStreamingGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   GUI to allow for burst mode streaming from IMU products.

Imports AdisApi
Imports adisInterface
Imports System.ComponentModel
Imports StreamDataLogger
Imports RegMapClasses

Public Class IMUStreamingGUI
    Inherits FormBase

    Private WithEvents fileManager As Logger
    Private totalDRCaptures As Integer = 0
    Private pin As IPinObject
    Private tempRegList As List(Of RegMapClasses.RegClass)
    Private regListCount As Integer = 0

    Public Sub FormSetup() Handles Me.Load
        UpdateRegmap()

        DRDIO.Items.Add("DIO1")
        DRDIO.Items.Add("DIO2")
        DRDIO.Items.Add("DIO3")
        DRDIO.Items.Add("DIO4")

        If m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO1.ToString Then
            DRDIO.SelectedItem = "DIO1"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO2.ToString Then
            DRDIO.SelectedItem = "DIO2"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO3.ToString Then
            DRDIO.SelectedItem = "DIO3"
        ElseIf m_TopGUI.FX3.ReadyPin.ToString = m_TopGUI.FX3.DIO4.ToString Then
            DRDIO.SelectedItem = "DIO4"
        End If

        Label4.Text = ""
        BurstStreamCancelButton.Enabled = False
        NumberDRToCapture.Text = "10000"
        statusLabel.Text = "Waiting"
        statusLabel.BackColor = Color.White
        check_drActive.Checked = m_TopGUI.FX3.DrActive
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        m_TopGUI.btn_RealTime.Enabled = True
    End Sub

    Private Sub MainButton_Click(sender As Object, e As EventArgs) Handles MainButton.Click

        Dim timeString As String = "_" + DateTime.Now().ToString("s")
        Dim savePath As String
        timeString = timeString.Replace(":", "-")

        'Update the data ready pin and measurement
        UpdateDRPin()

        'Check whether the number of samples to capture is valid
        If NumberDRToCapture.Text <= 0 Then
            MessageBox.Show("Please enter a number of samples to capture before starting", "No number of samples entered!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Check whether the measured DR is valid
        If check_drActive.Checked Then
            m_TopGUI.FX3.DrActive = True
            If m_TopGUI.FX3.ReadDRFreq(pin, 1, 2000) > 10000 Or m_TopGUI.FX3.ReadDRFreq(pin, 1, 2000) < 0 Then
                If MessageBox.Show("Data ready frequency invalid. Is the correct DIO selected?", "Invalid Data Ready!", MessageBoxButtons.OKCancel) <> DialogResult.OK Then
                    Exit Sub
                End If
            End If
        End If

        'Get data output save location
        savePath = setSaveLocation(m_TopGUI.lastFilePath)
        If savePath Is Nothing Then
            MessageBox.Show("Please select a folder to save the stream data.", "Invalid save path!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'instantiate stream data logger
        fileManager = New Logger(m_TopGUI.FX3, New adisInterface.adbfInterface(m_TopGUI.FX3, Nothing))

        'set up FX3 specific properties
        If m_TopGUI.FX3.SensorType = FX3Api.DeviceType.AutomotiveSpi Then
            m_TopGUI.FX3.TriggerReg = New RegClass With {.Address = 0, .Page = 0}
            'assign burst read address
            Dim burstHeader As Byte() = {0, 0, &HA, 0}
            m_TopGUI.FX3.BurstMOSIData = burstHeader
            m_TopGUI.FX3.BurstByteCount = tempRegList.Count * 4
            m_TopGUI.FX3.StripBurstTriggerWord = False
            fileManager.LowerWordFirst = False
        Else
            m_TopGUI.FX3.WordCount() = regListCount
            m_TopGUI.FX3.TriggerReg = m_TopGUI.RegMap.BurstReadTrig
            m_TopGUI.FX3.StripBurstTriggerWord = False
            fileManager.LowerWordFirst = True
        End If

        'enable burst mode
        m_TopGUI.FX3.SetupBurstMode()

        'Set up stream data logger properties
        fileManager.RegList = tempRegList
        fileManager.FileBaseName = "BURST" + timeString
        fileManager.FilePath = savePath
        fileManager.Buffers = totalDRCaptures 'Number of times to read all the registers in the reg map
        fileManager.Captures = 1 'Number of times to read each register in the reg map
        fileManager.FileMaxDataRows = 1000000 'Keep this under 1M samples to open in Excel
        fileManager.BufferTimeoutSeconds = 10 'Timeout in seconds
        fileManager.BuffersPerWrite = 10000

        'hide other forms
        InteractWithOtherForms(True, Me)

        'run async
        fileManager.RunAsync()

        statusLabel.Text = "Writing Data"
        statusLabel.BackColor = Color.White

        'Disable user inputs during capture
        BurstStreamCancelButton.Enabled = True
        DRDIO.Enabled = False
        NumberDRToCapture.Enabled = False
        MeasureDR.Enabled = False
        burstRegList.Enabled = False
        MainButton.Enabled = False

    End Sub

    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        If Me.InvokeRequired Then
            Me.Invoke(New MethodInvoker(AddressOf CaptureDoneWork))
        Else
            CaptureDoneWork()
        End If
    End Sub

    Private Sub CaptureDoneWork()
        statusLabel.Text = "Done"
        statusLabel.BackColor = m_TopGUI.GOOD_COLOR
        BurstStreamCancelButton.Enabled = False
        DRDIO.Enabled = True
        NumberDRToCapture.Enabled = True
        MeasureDR.Enabled = True
        burstRegList.Enabled = True
        MainButton.Enabled = True

        'Clear burst mode
        m_TopGUI.FX3.ClearBurstMode()

        'show forms
        InteractWithOtherForms(False, Me)
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles BurstStreamCancelButton.Click
        MainButton.Enabled = True
        If fileManager.Busy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Canceling"
            statusLabel.BackColor = m_TopGUI.ERROR_COLOR
        End If
    End Sub

    Private Sub MeasureDR_Click(sender As Object, e As EventArgs) Handles MeasureDR.Click
        UpdateDRPin()
        Label4.Text = FormatNumber(m_TopGUI.FX3.ReadDRFreq(pin, 1, 2000), 3).ToString + "  Hz"
    End Sub

    Private Sub UpdateDRPin()
        Dim dio As String
        dio = DRDIO.SelectedItem
        Select Case dio
            Case "DIO1"
                pin = m_TopGUI.FX3.DIO1
            Case "DIO2"
                pin = m_TopGUI.FX3.DIO2
            Case "DIO3"
                pin = m_TopGUI.FX3.DIO3
            Case "DIO4"
                pin = m_TopGUI.FX3.DIO4
            Case Else
                pin = m_TopGUI.FX3.DIO1
        End Select
    End Sub

    Private Sub UpdateGUI()
        'Check DR capture input
        If NumberDRToCapture.Text = "" Then
            NumberDRToCapture.Text = 0
        End If
        Try
            totalDRCaptures = Convert.ToInt32(NumberDRToCapture.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid Input")
            Exit Sub
        End Try
    End Sub

    Private Sub UpdateRegmap()
        If Use32BitRegs.Checked Then
            'Handle 32-bit registers
            tempRegList = m_TopGUI.RegMap.BurstReadList
            'Loop through each register and check for 32-bit locations
            For Each item As RegMapClasses.RegClass In m_TopGUI.RegMap.BurstReadList
                'If a register is listed as a 32-bit register
                If item.ReadLen > 16 Then
                    'Remove its lower counterpart from the list (it'll get added to the transfer later anyway)
                    tempRegList.Remove(tempRegList.Find(Function(p) p.Address = (item.Address + 2 / m_TopGUI.Dut.DeviceAddressIncrement)))
                End If
            Next
            'Refresh the register list in the GUI
            burstRegList.Clear()
            burstRegList.View = View.Details
            burstRegList.Columns.Add("Register", burstRegList.Width - 3, HorizontalAlignment.Left)
            For Each reg In tempRegList
                Dim newItem As New ListViewItem()
                newItem.SubItems(0).Text = reg.Label
                burstRegList.Items.Add(newItem)
            Next
        Else
            'Handle 16-bit registers
            tempRegList = m_TopGUI.RegMap.BurstReadList
            'Loop through each register and check for 32-bit locations
            For Each item As RegMapClasses.RegClass In m_TopGUI.RegMap.BurstReadList
                'If a register is listed as a 32-bit register
                If item.NumBytes > 2 Then
                    'Remove its upper counterpart from the list (we're only capturing 16-bit registers)
                    tempRegList.Remove(item)
                End If
            Next
            'Refresh the register list in the GUI
            burstRegList.Clear()
            burstRegList.View = View.Details
            burstRegList.Columns.Add("Register", burstRegList.Width - 3, HorizontalAlignment.Left)
            For Each reg In tempRegList
                Dim newItem As New ListViewItem()
                newItem.SubItems(0).Text = reg.Label
                burstRegList.Items.Add(newItem)
            Next
        End If

        'Add in extra registers for iSensorAutoSpi
        If m_TopGUI.FX3.SensorType = FX3Api.DeviceType.AutomotiveSpi Then
            tempRegList.Add(New RegClass With {.Address = 0, .Page = 0, .Label = "CRC", .NumBytes = 4, .ReadLen = 32})
            tempRegList.Insert(0, New RegClass With {.Address = 0, .Page = 0, .Label = "BURST_HEADER", .NumBytes = 4, .ReadLen = 32})
        End If

        'calculate word count
        regListCount = 0
        For Each reg In tempRegList
            If reg.NumBytes <> 4 Then
                regListCount += 1
            Else
                regListCount += 2
            End If
        Next

    End Sub

    Private Sub NumberDRToCapture_TextChanged(sender As Object, e As EventArgs) Handles NumberDRToCapture.TextChanged
        UpdateGUI()
    End Sub

    Private Sub progressUpdate(e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        Me.Invoke(New MethodInvoker(Sub() CaptureProgressBurst.Value = e.ProgressPercentage))
    End Sub

    Private Sub BitModeCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles Use32BitRegs.CheckedChanged
        UpdateRegmap()
    End Sub

    Private Sub check_drActive_CheckedChanged(sender As Object, e As EventArgs) Handles check_drActive.CheckedChanged
        m_TopGUI.FX3.DrActive = check_drActive.Checked
    End Sub

End Class