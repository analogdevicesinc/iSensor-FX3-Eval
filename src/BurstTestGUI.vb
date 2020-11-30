'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          BurstTestGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Testing burst mode for ADIS IMU's. Includes single transfer and stream modes

Imports FX3Api
Imports RegMapClasses
Imports StreamDataLogger

Public Class BurstTestGUI
    Inherits FormBase

    Private m_numBytes As Integer
    Private WithEvents fileManager As Logger

    Public Sub FormSetup() Handles Me.Load
        sclk.Text = m_TopGUI.FX3.SclkFrequency.ToString()
        drActive.Checked = m_TopGUI.FX3.DrActive
        csDelay.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))
        csDelay.SelectedItem = m_TopGUI.FX3.ChipSelectLeadTime
        numBytes.Text = "48"
        m_numBytes = 48
        m_TopGUI.FX3.StripBurstTriggerWord = False
        m_TopGUI.FX3.TriggerReg = New RegClass With {.Address = 0, .Page = 0}
        result.ColumnCount = 3
        result.Columns(0).Name = ("Byte")
        result.Columns(1).Name = ("MISO Value")
        result.Columns(2).Name = ("MOSI Value")
        result.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        result.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        result.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetupResultView()
    End Sub

    Public Sub ResizeHandler() Handles Me.Resize
        result.Height = Me.Height - 252
    End Sub

    Private Sub captureData_Click(sender As Object, e As EventArgs) Handles captureData.Click

        Dim burstTrigger() As Byte = UpdateBurstParams()
        If IsNothing(burstTrigger) Then Exit Sub
        m_TopGUI.FX3.StartBurstStream(1, burstTrigger)
        While m_TopGUI.FX3.GetNumBuffersRead < 1
            System.Threading.Thread.Sleep(10)
        End While
        Dim buf() As UShort
        buf = m_TopGUI.FX3.GetBuffer()
        If IsNothing(buf) Then
            MsgBox("Error: Null buffer received...")
            Exit Sub
        End If
        Dim miso As Byte() = UShortToByteArray(buf)
        For i As Integer = 0 To m_numBytes - 1
            result.Item("MISO Value", i).Value = "0x" + miso(i).ToString("X2")
        Next
    End Sub

    Private Sub applySettings_Click(sender As Object, e As EventArgs) Handles applySettings.Click
        Try
            m_TopGUI.FX3.SclkFrequency = Convert.ToInt32(sclk.Text)
            m_TopGUI.FX3.DrActive = drActive.Checked
            m_TopGUI.FX3.ChipSelectLeadTime = csDelay.SelectedItem
        Catch ex As Exception
            MsgBox("ERROR: Invalid settings! " + ex.Message)
        End Try
    End Sub

    Private Sub SetupResultView()
        If (m_numBytes And 1UI) <> 0 Then
            m_numBytes += 1
            numBytes.Text = m_numBytes.ToString()
        End If
        If result.RowCount < m_numBytes Then
            For i As Integer = result.RowCount To m_numBytes - 1
                result.Rows.Add({i.ToString(), "", "0x00"})
            Next
        ElseIf result.RowCount > m_numBytes Then
            Dim numRows = result.RowCount - m_numBytes
            For i As Integer = 0 To numRows - 1
                result.Rows.RemoveAt(result.RowCount - 1)
            Next
        End If
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        m_TopGUI.FX3.StripBurstTriggerWord = True
        m_TopGUI.btn_BurstTest.Enabled = True

        'dispose
        If Not IsNothing(fileManager) Then
            fileManager.Dispose()
        End If
        Me.Dispose()
    End Sub

    Private Sub num32words_TextChanged(sender As Object, e As EventArgs) Handles numBytes.LostFocus
        Try
            m_numBytes = Convert.ToInt32(numBytes.Text)
            SetupResultView()
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btn_StartStream_Click(sender As Object, e As EventArgs) Handles btn_StartStream.Click
        Dim savePath As String
        Dim numBursts As UInteger
        Dim burstTrigger() As Byte
        Dim regs As New List(Of RegClass)
        Dim timeString As String

        'check if stream start/stop needed
        If btn_StartStream.Text = "Start Burst Stream" Then
            'check dr (if selected)
            If m_TopGUI.FX3.DrActive Then
                If m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, 100, 2) = Double.PositiveInfinity Then
                    Dim res As DialogResult = MessageBox.Show("Warning, Data Ready not Toggling! Continue?", "Confirm Data Ready Sync", MessageBoxButtons.OKCancel)
                    If res <> DialogResult.OK Then Exit Sub
                End If
            End If

            'save file location
            savePath = setSaveLocation(m_TopGUI.lastFilePath)
            If savePath Is Nothing Then
                MessageBox.Show("Please select a folder to save the stream data.", "Invalid save path!", MessageBoxButtons.OK)
                Exit Sub
            End If

            'get numbursts
            Try
                numBursts = Convert.ToUInt32(numBurstWords.Text)
            Catch ex As Exception
                MsgBox("ERROR: Invalid number of bursts " + ex.Message)
                Exit Sub
            End Try

            'get burst trigger
            burstTrigger = UpdateBurstParams()
            If IsNothing(burstTrigger) Then Exit Sub
            m_TopGUI.FX3.BurstMOSIData = burstTrigger

            'enable burst mode
            m_TopGUI.FX3.SetupBurstMode()

            'set up logger
            For i As Integer = 0 To (m_numBytes >> 1) - 1
                regs.Add(New RegClass With {.Address = 0, .Page = 0, .NumBytes = 2, .ReadLen = 16, .Label = "BURST_" + i.ToString()})
            Next

            If Not IsNothing(fileManager) Then
                fileManager.Dispose()
            End If

            timeString = "_" + DateTime.Now().ToString("s")
            timeString = timeString.Replace(":", "-")

            fileManager = New Logger(m_TopGUI.FX3, m_TopGUI.Dut)

            fileManager.RegList = regs
            fileManager.FileBaseName = "BurstTest" + timeString
            fileManager.FilePath = savePath
            fileManager.Buffers = numBursts
            fileManager.Captures = 1
            fileManager.FileMaxDataRows = 1000000 'max you can open in excel
            fileManager.BuffersPerWrite = 10000
            fileManager.BufferTimeoutSeconds = 10 'Timeout in seconds

            'hide other forms during stream
            InteractWithOtherForms(True, Me)

            'run async
            fileManager.RunAsync()
            btn_StartStream.Text = "Stop Burst Stream"
            captureData.Enabled = False
            applySettings.Enabled = False
        Else
            If fileManager.Busy Then
                fileManager.CancelAsync()
            Else
                CleanupBurstStream()
            End If
        End If
    End Sub

    Private Sub BurstDoneHandler() Handles fileManager.RunAsyncCompleted
        If Me.InvokeRequired Then
            Me.BeginInvoke(Sub() CleanupBurstStream())
        Else
            CleanupBurstStream()
        End If
    End Sub

    Private Sub CleanupBurstStream()
        btn_StartStream.Text = "Start Burst Stream"
        captureData.Enabled = True
        applySettings.Enabled = True
        'show other forms
        InteractWithOtherForms(False, Me)
    End Sub

    Private Function UpdateBurstParams() As Byte()

        Dim burstTrigger As New List(Of Byte)
        Dim byteVal As Byte
        Try
            For i As Integer = 0 To m_numBytes - 1
                byteVal = Convert.ToUInt32(result.Item("MOSI Value", i).Value, 16)
                burstTrigger.Add(byteVal)
            Next
        Catch ex As Exception
            MsgBox("ERROR: Invalid MOSI data. " + ex.Message)
            Return Nothing
        End Try
        m_TopGUI.FX3.TriggerReg = New RegClass With {.Address = 0}
        m_TopGUI.FX3.StripBurstTriggerWord = False
        m_TopGUI.FX3.BurstByteCount = m_numBytes
        m_TopGUI.FX3.SetupBurstMode()
        Return burstTrigger.ToArray()

    End Function

End Class