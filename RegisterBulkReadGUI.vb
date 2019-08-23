'File:          RegisterBulkReadGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows for bulk data logging from registers. Can be triggered on a data ready signal for IMUs

Imports AdisApi
Imports adisInterface
Imports System.ComponentModel

Public Class RegisterBulkReadGUI
    Inherits FormBase

    Private WithEvents fileManager As New TextFileStreamManager
    Private totalDRCaptures As Integer = 0
    Private pin As IPinObject

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        For Each reg In TopGUI.RegMap
            RegisterList.Items.Add(reg.Label)
        Next
        RegisterList.SelectedIndex = 0

        DRDIO.Items.Add("DIO1")
        DRDIO.Items.Add("DIO2")
        DRDIO.Items.Add("DIO3")
        DRDIO.Items.Add("DIO4")

        If TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO1.ToString Then
            DRDIO.SelectedItem = "DIO1"
        ElseIf TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO2.ToString Then
            DRDIO.SelectedItem = "DIO2"
        ElseIf TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO3.ToString Then
            DRDIO.SelectedItem = "DIO3"
        ElseIf TopGUI.FX3.ReadyPin.ToString = TopGUI.FX3.DIO4.ToString Then
            DRDIO.SelectedItem = "DIO4"
        End If

        MeasureDR.Enabled = TopGUI.FX3.DrActive
        DrActiveBox.Checked = TopGUI.FX3.DrActive

        ListView1.Items.Clear()
        For Each item In TopGUI.BulkRegList
            ListView1.Items.Add(item)
        Next
        NumberDRToCapture.Text = TopGUI.numRegSamples.ToString()

    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        'Save the list-view contents

        TopGUI.BulkRegList.Clear()
        For Each item In ListView1.Items
            TopGUI.BulkRegList.Add(item)
        Next
        TopGUI.numRegSamples = Convert.ToInt32(NumberDRToCapture.Text)

    End Sub

    Private Sub StreamingAVAR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ListView1.View = View.Details
        ListView1.Columns.Add("Register", 182, HorizontalAlignment.Left)
        Label4.Text = ""
        StreamingAVARCancelButton.Enabled = False
        statusLabel.Text = "Waiting"
        statusLabel.BackColor = Color.White
    End Sub

    Private Sub AddRegisterButton_Click(sender As Object, e As EventArgs) Handles AddRegisterButton.Click
        Dim newItem As New ListViewItem()
        newItem.SubItems(0).Text = RegisterList.SelectedItem
        ListView1.Items.Add(newItem)
    End Sub

    Private Sub RemoveRegisterButton_Click(sender As Object, e As EventArgs) Handles RemoveRegisterButton.Click
        If IsNothing(Me.ListView1.FocusedItem) Then
            MessageBox.Show("Please select an Item to Delete", "Remove register warning", MessageBoxButtons.OK)
        Else
            Me.ListView1.Items.RemoveAt(Me.ListView1.FocusedItem.Index)
        End If
    End Sub

    Private Sub ClearAllButton_Click(sender As Object, e As EventArgs) Handles ClearAllButton.Click
        Dim result As Integer
        result = MessageBox.Show("Are you sure you want to clear all registers?", "Clear all registers?", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            ListView1.Items.Clear()
        End If
    End Sub

    Private Sub MainButton_Click(sender As Object, e As EventArgs) Handles MainButton.Click

        Dim timeString As String = "_" + DateTime.Now().ToString("s")
        Dim savePath As String
        timeString = timeString.Replace(":", "-")

        'Update the data ready pin and measurement
        UpdateDRPin()

        'Check whether user selected registers to stream
        If ListView1.Items.Count <= 0 Then
            MessageBox.Show("Please select registers to stream before starting", "No registers selected!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Check whether the number of samples to capture is valid
        If NumberDRToCapture.Text <= 0 Then
            MessageBox.Show("Please enter a number of samples to capture before starting", "No number of samples entered!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Check whether the measured DR is valid
        If TopGUI.FX3.ReadDRFreq(pin, 1, 2000) > 10000 Or TopGUI.FX3.ReadDRFreq(pin, 1, 2000) < 0 Then
            MessageBox.Show("Data ready frequency invalid. Is the correct DIO selected?", "Invalid Data Ready!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Build list of registers to stream
        Dim regList As New List(Of RegMapClasses.RegClass)
        For Each item As ListViewItem In Me.ListView1.Items
            regList.Add(TopGUI.RegMap(item.Text))
        Next

        'Check the time it will take to capture each frame and ask the user if it exceeds the DR period
        Dim drPeriod As Double = 1 / TopGUI.FX3.ReadDRFreq(pin, 1, 2000)
        Dim calcPeriod As Double = (((TopGUI.FX3.StallTime + 12) / 1000000) * regList.Count)

        If calcPeriod > drPeriod Then
            Dim result1 As DialogResult = MessageBox.Show("Register capture time exceeds data ready period. Would you like to continue?", "Data will take too long to read!", MessageBoxButtons.YesNo)
            If result1 = DialogResult.No Then
                Exit Sub
            End If
        End If

        'Get data output save location
        savePath = setSaveLocation()
        If savePath Is Nothing Then
            MessageBox.Show("Please select a folder to save the stream data.", "Invalid save path!", MessageBoxButtons.OK)
            Exit Sub
        End If

        'Generate TFSM settings
        Dim drFreq As UInteger
        Dim numCaptures As UInteger
        Dim numBuffers As UInteger

        drFreq = TopGUI.FX3.ReadDRFreq(pin, 1, 2000)
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

        'Set up file manager to pass over to TFSM
        fileManager.DutInterface = TopGUI.Dut
        fileManager.RegList = regList
        fileManager.FileBaseName = "AVAR" + timeString
        fileManager.FilePath = savePath
        fileManager.Buffers = totalDRCaptures 'Number of times to read all the registers in the reg map
        fileManager.Captures = 1 'Number of times to read each register in the reg map
        fileManager.FileMaxDataRows = 1000000 'Keep this under 1M samples to open in Excel
        fileManager.BufferTimeout = 10 'Timeout in seconds
        fileManager.BuffersPerWrite = 40000 'Dynamic buffers per write to avoid storing too much data in RAM
        fileManager.IncludeSampleNumberColumn = False
        fileManager.ScaleData = False

        fileManager.RunAsync()

        statusLabel.Text = "Writing Data"
        statusLabel.BackColor = Color.White

        'Disable user inputs during capture
        StreamingAVARCancelButton.Enabled = True
        DRDIO.Enabled = False
        NumberDRToCapture.Enabled = False
        MeasureDR.Enabled = False
        AddRegisterButton.Enabled = False
        RemoveRegisterButton.Enabled = False
        ClearAllButton.Enabled = False
        RegisterList.Enabled = False
        ListView1.Enabled = False
        MainButton.Enabled = False

    End Sub

    Private Sub CaptureComplete() Handles fileManager.RunAsyncCompleted
        statusLabel.Text = "Done"
        statusLabel.BackColor = Color.Green
        StreamingAVARCancelButton.Enabled = False
        DRDIO.Enabled = True
        NumberDRToCapture.Enabled = True
        MeasureDR.Enabled = TopGUI.FX3.DrActive
        AddRegisterButton.Enabled = True
        RemoveRegisterButton.Enabled = True
        ClearAllButton.Enabled = True
        RegisterList.Enabled = True
        ListView1.Enabled = True
        MainButton.Enabled = True
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles StreamingAVARCancelButton.Click
        MainButton.Enabled = True
        If fileManager.IsBusy Then
            fileManager.CancelAsync()
            statusLabel.Text = "Canceling"
            statusLabel.BackColor = Color.Red
        End If
    End Sub

    Private Sub MeasureDR_Click(sender As Object, e As EventArgs) Handles MeasureDR.Click
        UpdateDRPin()
        Label4.Text = FormatNumber(TopGUI.FX3.ReadDRFreq(pin, 1, 2000), 3).ToString + "  Hz"
    End Sub

    Private Sub UpdateDRPin()
        Dim dio As String
        dio = DRDIO.SelectedItem
        Select Case dio
            Case "DIO1"
                pin = TopGUI.FX3.DIO1
            Case "DIO2"
                pin = TopGUI.FX3.DIO2
            Case "DIO3"
                pin = TopGUI.FX3.DIO3
            Case "DIO4"
                pin = TopGUI.FX3.DIO4
            Case Else
                pin = TopGUI.FX3.DIO1
        End Select
    End Sub

    Private Sub progressUpdate(sender As Object, e As ProgressChangedEventArgs) Handles fileManager.ProgressChanged
        CaptureProgressStreaming.Value = e.ProgressPercentage
        If CaptureProgressStreaming.Value = CaptureProgressStreaming.Maximum Then
            CaptureProgressStreaming.Value = CaptureProgressStreaming.Minimum
        End If
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

    Private Sub NumberDRToCapture_TextChanged(sender As Object, e As EventArgs) Handles NumberDRToCapture.TextChanged
        UpdateGUI()
    End Sub

    Private Sub DrActiveBox_CheckedChanged(sender As Object, e As EventArgs) Handles DrActiveBox.CheckedChanged
        TopGUI.FX3.DrActive = DrActiveBox.Checked
        MeasureDR.Enabled = TopGUI.FX3.DrActive
    End Sub

End Class