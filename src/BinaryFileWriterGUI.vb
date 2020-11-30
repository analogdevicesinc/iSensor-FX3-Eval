'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          AppBrowseGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Allows for writing binary data patterns to a file. Might not fit great in here, but I use it, and I didn't want to make an entire tool for it.

Public Class BinaryFileWriterGUI
    Inherits FormBase

    Private Sub btn_GenFile_Click(sender As Object, e As EventArgs) Handles btn_GenFile.Click

        Dim bytes As UInteger
        Dim inputData As New List(Of Byte)
        Dim writeData As New List(Of Byte)
        Dim byteStr As String
        Dim index As Integer
        Dim saveBrowser As SaveFileDialog

        Try
            bytes = Convert.ToUInt32(numBytes.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid number of bytes. " + ex.Message())
            Exit Sub
        End Try

        'build input data
        If (fillPattern.Text.Length Mod 2 <> 0) Or (fillPattern.Text.Length = 0) Then
            MsgBox("ERROR: Invalid fill data. Must be even bytes (multiple of two hex chars)")
            Exit Sub
        End If

        Try
            For i As Integer = 0 To fillPattern.Text.Length() - 1 Step 2
                byteStr = fillPattern.Text.Substring(i, 2)
                inputData.Add(Convert.ToByte(byteStr, 16))
            Next
        Catch ex As Exception
            MsgBox("ERROR: Invalid fill data. " + ex.Message)
            Exit Sub
        End Try

        'build output data array
        index = 0
        While writeData.Count < bytes
            writeData.Add(inputData(index))
            index += 1
            index = index Mod inputData.Count
        End While

        'get file location
        saveBrowser = New SaveFileDialog()
        If saveBrowser.ShowDialog <> DialogResult.OK Then
            Exit Sub
        End If
        Try
            My.Computer.FileSystem.WriteAllBytes(saveBrowser.FileName, writeData.ToArray(), False)
        Catch ex As Exception
            MsgBox("ERROR while writing file. " + ex.Message())
        End Try

    End Sub

    Private Sub ResizeHandler() Handles Me.SizeChanged
        fillPattern.Width = Me.Width - 40
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        m_TopGUI.btn_binFile.Enabled = True
    End Sub

End Class