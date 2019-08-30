'File:          IMUStreamingGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   GUI to allow for burst mode streaming from IMU products.

Imports AdisApi
Imports adisInterface
Imports System.ComponentModel

Public Class IMUStreamingGUI
    Inherits FormBase

    Private WithEvents fileManager As New TextFileStreamManager
    Private totalDRCaptures As Integer = 0
    Private pin As IPinObject
    Private tempRegList As List(Of RegMapClasses.RegClass)
    Private regListCount As Integer = 0

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

    End Sub

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
    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        m_TopGUI.Show()
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
        If m_TopGUI.FX3.ReadDRFreq(pin, 1, 2000) > 10000 Or m_TopGUI.FX3.ReadDRFreq(pin, 1, 2000) < 0 Then
            MessageBox.Show("Data ready frequency invalid. Is the correct DIO selected?", "Invalid Data Ready!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Get data output save location
        savePath = setSaveLocation(m_TopGUI.lastFilePath)
        If savePath Is Nothing Then
            MessageBox.Show("Please select a folder to save the stream data.", "Invalid save path!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Generate TFSM settings
        Dim drFreq As UInteger
        Dim numCaptures As UInteger
        Dim numBuffers As UInteger

        drFreq = m_TopGUI.FX3.ReadDRFreq(pin, 1, 2000)
        If totalDRCaptures < drFreq Then
            numCaptures = totalDRCaptures
            numBuffers = 1
        Else
            numCaptures = drFreq
            If totalDRCaptures Mod numCaptures > 0 Then
                numBuffers = (totalDRCaptures / numCaptures) + 1
            Else
                numBuffers = totalDRCaptures / numCaptures
            End If
        End If

        m_TopGUI.FX3.WordCount() = regListCount
        m_TopGUI.FX3.TriggerReg = m_TopGUI.RegMap.BurstReadTrig
        m_TopGUI.FX3.SetupBurstMode()

        'Set up file manager to pass over to TFSM
        fileManager.DutInterface = m_TopGUI.Dut
        fileManager.RegList = tempRegList
        fileManager.FileBaseName = "BURST" + timeString
        fileManager.FilePath = savePath
        fileManager.Buffers = totalDRCaptures 'Number of times to read all the registers in the reg map
        fileManager.Captures = 1 'Number of times to read each register in the reg map
        fileManager.FileMaxDataRows = 1000000 'Keep this under 1M samples to open in Excel
        fileManager.BufferTimeout = 3 'Timeout in seconds
        fileManager.BuffersPerWrite = 10 * drFreq 'Dynamic buffers per write to avoid storing too much data in RAM
        fileManager.IncludeSampleNumberColumn = False
        fileManager.ScaleData = False

        fileManager.RunAsync()

        statusLabel.Text = "Writing Data"
        statusLabel.BackColor = Color.White

        'Disable user inputs during capture
        BurstStreamCancelButton.Enabled = True
        DRDIO.Enabled = False
        NumberDRToCapture.Enabled = False
        MeasureDR.Enabled = False
        ListView1.Enabled = False
        MainButton.Enabled = False

    End Sub

    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        statusLabel.Text = "Done"
        statusLabel.BackColor = Color.Green
        BurstStreamCancelButton.Enabled = False
        DRDIO.Enabled = True
        NumberDRToCapture.Enabled = True
        MeasureDR.Enabled = True
        ListView1.Enabled = True
        MainButton.Enabled = True

        'Clear burst mode
        m_TopGUI.FX3.ClearBurstMode()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles BurstStreamCancelButton.Click
        MainButton.Enabled = True
        If fileManager.IsBusy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Canceling"
            statusLabel.BackColor = Color.Red
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
        If BitModeCheckbox.Checked Then
            'Handle 16-bit registers
            tempRegList = m_TopGUI.RegMap.BurstReadList
            regListCount = m_TopGUI.RegMap.BurstReadList.Count
            'Loop through each register and check for 32-bit locations
            For Each item As RegMapClasses.RegClass In m_TopGUI.RegMap.BurstReadList
                'If a register is listed as a 32-bit register
                If item.ReadLen > 16 Then
                    'Remove its upper counterpart from the list (we're only capturing 16-bit registers)
                    tempRegList.Remove(tempRegList.Find(Function(p) p.Address = item.Address))
                    regListCount = regListCount - 1
                End If
            Next
            'Refresh the register list in the GUI
            ListView1.Clear()
            ListView1.View = View.Details
            ListView1.Columns.Add("Register", 182, HorizontalAlignment.Left)
            For Each reg In tempRegList
                Dim newItem As New ListViewItem()
                newItem.SubItems(0).Text = reg.Label
                ListView1.Items.Add(newItem)
            Next
        Else
            'Handle 32-bit registers
            tempRegList = m_TopGUI.RegMap.BurstReadList
            regListCount = m_TopGUI.RegMap.BurstReadList.Count
            'Loop through each register and check for 32-bit locations
            For Each item As RegMapClasses.RegClass In m_TopGUI.RegMap.BurstReadList
                'If a register is listed as a 32-bit register
                If item.ReadLen > 16 Then
                    'Remove its lower counterpart from the list (it'll get added to the transfer later anyway)
                    tempRegList.Remove(tempRegList.Find(Function(p) p.Address = (item.Address + &H2)))
                End If
            Next
            'Refresh the register list in the GUI
            ListView1.Clear()
            ListView1.View = View.Details
            ListView1.Columns.Add("Register", 182, HorizontalAlignment.Left)
            For Each reg In tempRegList
                Dim newItem As New ListViewItem()
                newItem.SubItems(0).Text = reg.Label
                ListView1.Items.Add(newItem)
            Next
        End If
    End Sub

    Private Sub NumberDRToCapture_TextChanged(sender As Object, e As EventArgs) Handles NumberDRToCapture.TextChanged
        UpdateGUI()
    End Sub

    Private Sub progressUpdate(sender As Object, e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        CaptureProgressBurst.Value = e.ProgressPercentage
    End Sub

    Private Sub BitModeCheckbox_CheckedChanged(sender As Object, e As EventArgs) Handles BitModeCheckbox.CheckedChanged
        UpdateRegmap()
    End Sub
End Class