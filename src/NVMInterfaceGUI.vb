'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          FlashInterfaceGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   GUI to allow users to dump the FX3 error log to a CSV file, or read the full contents of the EEPROM

Public Class NVMInterfaceGUI

    Public Sub Shutdown() Handles Me.Closing
        m_TopGUI.btn_checkError.Enabled = True
    End Sub

    Private Sub btn_dumpFlash_Click(sender As Object, e As EventArgs) Handles btn_dumpFlash.Click

        Dim rawData As New List(Of Byte)

        Dim addr As UInteger = 0
        For i As Integer = 0 To 63
            rawData.AddRange(m_TopGUI.FX3.ReadFlash(addr, 4096))
            addr += 4096
        Next

        Dim str As New List(Of String)
        addr = 0
        For Each item In rawData
            str.Add("0x" + addr.ToString("X4") + "," + item.ToString("X2"))
            addr += 1
        Next

        saveCSV("fx3_flash_dump", str.ToArray())

    End Sub

    Private Sub btn_dumpLog_Click(sender As Object, e As EventArgs) Handles btn_dumpLog.Click

        Dim logData As New List(Of String)
        Dim log As List(Of FX3Api.FX3ErrorLog) = m_TopGUI.FX3.GetErrorLog()
        If log.Count = 0 Then
            MsgBox("No errors logged!")
            Exit Sub
        End If
        logData.Add("FileIdentifier,Line,ErrorCode,BootTimeStamp,ParsedBootTimeStamp,Uptime(ms),FirmwareRev")
        For Each item In log
            logData.Add(item.FileIdentifier.ToString() + "," +
                        item.Line.ToString() + "," +
                        "0x" + item.ErrorCode.ToString("X4") + "," +
                        item.BootTimeStamp.ToString() + "," +
                        GetDateTime(item.BootTimeStamp).ToString() + "," +
                        item.OSUptime.ToString() + "," +
                        item.FirmwareRev)
        Next
        saveCSV("fx3_error_log", logData.ToArray())
    End Sub

    Private Function GetDateTime(Timestamp As UInteger) As Date
        Dim result As System.DateTime = New System.DateTime(1970, 1, 1, 0, 0, 0, 0)
        Return result.AddSeconds(Timestamp)
    End Function

    Private Sub btn_clearError_Click(sender As Object, e As EventArgs) Handles btn_clearError.Click
        If MessageBox.Show("This cannot be reversed! Are you sure you wish to continue?", "Confirmation", MessageBoxButtons.YesNo) <> MsgBoxResult.Yes Then
            Exit Sub
        End If
        m_TopGUI.FX3.ClearErrorLog()
        logCount.Text = m_TopGUI.FX3.GetErrorLogCount().ToString()
    End Sub

    Private Sub FlashInterfaceGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        logCount.Text = m_TopGUI.FX3.GetErrorLogCount().ToString()
    End Sub

    Private Sub logCount_OnClick(sender As Object, e As EventArgs) Handles logCount.Click
        logCount.Text = m_TopGUI.FX3.GetErrorLogCount().ToString()
    End Sub

End Class