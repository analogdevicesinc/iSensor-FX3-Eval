Imports System.Text
Imports FX3Interface

Public Class RealTimeStreamGUI

    Private conn As Connection

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        'Set default values
        numFramesInput.Text = "10000"
        outputModeBox.Items.Add("Write to CSV")
        outputModeBox.Items.Add("Write to Binary File")
        timeOutBox.Checked = False

        outputModeBox.SelectedIndex = 0

    End Sub

    Public Sub SetConn(ByRef newConnection As Connection)
        conn = newConnection
        If conn.FX3.PartType = DUTType.ADcmXL3021 Then
            conn.Dut = New adisInterface.AdcmInterface3Axis(conn.FX3)
        ElseIf conn.FX3.PartType = DUTType.ADcmXL2021 Then
            conn.Dut = New adisInterface.AdcmInterface2Axis(conn.FX3)
        ElseIf conn.FX3.PartType = DUTType.ADcmXL1021 Then
            conn.Dut = New adisInterface.AdcmInterface1Axis(conn.FX3)
        End If
    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopLevelGUI.Show()
    End Sub

    Private Sub captureButton_Click(sender As Object, e As EventArgs) Handles captureButton.Click

        'Parse capture frames
        Dim captureFrames
        Dim numFreqsToCapture As Integer
        Dim writeCSV As Boolean = True

        Try
            captureFrames = Convert.ToInt32(numFramesInput.Text)
            If captureFrames < 1 Then
                Throw New Exception("Invalid number of frames")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid number of frames entered")
            Exit Sub
        End Try

        If outputModeBox.SelectedItem = "Write to CSV" Then
            writeCSV = True
        Else
            writeCSV = False
        End If

        Dim REC_CTRL1 As UInteger = &H103

        'Check timeout box setting
        If timeOutBox.Checked Then
            REC_CTRL1 = REC_CTRL1 + &H8000
        End If

        'Set REC_CTRL1 for real time mode
        conn.Dut.WriteUnsigned(conn.RegMap("REC_CTRL1"), REC_CTRL1)
        If Not REC_CTRL1 = conn.Dut.ReadUnsigned(conn.RegMap("REC_CTRL1")) Then
            MsgBox("ERROR: REC_CTRL1 Write Failed")
            Exit Sub
        End If

        'Variables to store output data
        Dim stringData As New List(Of String)
        Dim binData As New List(Of Byte)
        Dim binFrame() As Byte
        Dim line As New List(Of String)
        Dim frame() As UShort
        Dim streamRunning As Boolean = True
        Dim savePath As String
        Dim numFramesRead As Integer
        Dim pinLevel As Boolean = False


        If captureMultipleFrames.Checked Then
            numFreqsToCapture = Convert.ToInt32(numStepsToCapture.Text)
        Else
            numFreqsToCapture = 1
        End If

        Try
            If DIOSelector.Value < 0 Or DIOSelector.Value > 7 Then
                Throw New Exception("Invalid DIO selected. Please select a value between 0 and 7")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid DIO selected. Please select a value between 0 and 7")
            Exit Sub
        End Try

        'Disable checkboxes so users don't change settings mid-capture
        timeOutBox.Enabled = False
        PurgeFramesBox.Enabled = False
        captureMultipleFrames.Enabled = False
        enableExternalTrigger.Enabled = False
        DIOSelector.Enabled = False

        'Get data output save location
        savePath = setSaveLocation()

        'Loop through n number of sample captures
        For stepCount As Integer = 1 To numFreqsToCapture

            'Wait for external trigger, if enabled
            If enableExternalTrigger.Checked Then
                While Not pinLevel
                    System.Threading.Thread.Sleep(5)
                    pinLevel = conn.FX3.ReadPin(New FX3PinObject(DIOSelector.Value))
                End While
                pinLevel = False
            End If

            'Capture real time data
            conn.FX3.StartRealTimeStreaming(captureFrames)

            'Check if the user wants to purge bad frames
            If Not PurgeFramesBox.Checked Then

                While conn.FX3.GetNumBuffersRead < captureFrames

                    'Get the frame
                    frame = conn.FX3.GetBuffer

                    If writeCSV Then
                        'Build output string array for save to CSV
                        'This round-a-bout method must be used to avoid string
                        ' concatenation errors
                        If IsNothing(frame) Then
                            Exit While
                        End If

                        For Each value In frame
                            line.Add(Convert.ToString(value))
                        Next

                        Dim temp As String = String.Join(",", line)
                        stringData.Add(temp)
                        line.Clear()
                        temp = Nothing

                    Else
                        'Save binary data
                        binFrame = UShortToByteArray(frame)
                        For Each value In binFrame
                            binData.Add(value)
                        Next

                    End If

                End While

            Else

                conn.FX3.StreamTimeoutSeconds = 1
                'Wait for data 
                While conn.FX3.GetNumBuffersRead < captureFrames
                    'Wait
                    System.Threading.Thread.Sleep(5)
                End While

                'Purge bad frames
                conn.FX3.PurgeBadFrameData()

                numFramesRead = 0
                While numFramesRead < conn.FX3.GetNumBuffersRead
                    'Get the buffer
                    frame = conn.FX3.GetBuffer
                    numFramesRead = numFramesRead + 1

                    If writeCSV Then
                        'Build output string array for save to CSV
                        If IsNothing(frame) Then
                            Exit While
                        End If

                        For Each value In frame
                            line.Add(Convert.ToString(value))
                        Next

                        Dim temp As String = String.Join(",", line)
                        stringData.Add(temp)
                        line.Clear()
                        temp = Nothing

                    Else
                        'Save binary data
                        binFrame = UShortToByteArray(frame)
                        For Each value In binFrame
                            binData.Add(value)
                        Next

                    End If

                End While

            End If

            'Save data
            If writeCSV Then
                saveMultipleCSVs("Real_Time_Stream", stringData.ToArray, savePath, CStr(stepCount))
                stringData.Clear()
            Else
                saveMultipleBinaryFiles("Real_Time_Stream", binData.ToArray, savePath, CStr(stepCount))
                binData.Clear()
            End If

            System.Threading.Thread.Sleep(500)

        Next

        'Update frame counter
        numFramesCaptured.Text = conn.FX3.GetNumBuffersRead.ToString()
        framesPurged.Text = conn.FX3.NumFramesPurged.ToString()

        'Re-enable check boxes
        timeOutBox.Enabled = True
        PurgeFramesBox.Enabled = True
        captureMultipleFrames.Enabled = True
        enableExternalTrigger.Enabled = True
        DIOSelector.Enabled = True

    End Sub

    Private Sub RealTimeStreamGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class