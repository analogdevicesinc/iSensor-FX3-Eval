Public Class FlashInterfaceGUI

    Private m_AppGUI As AppBrowseGUI

    Friend Sub SetAppGUI(AppGUI As AppBrowseGUI)
        m_AppGUI = AppGUI
    End Sub

    Public Sub Shutdown() Handles Me.Closing
        m_AppGUI.btn_checkError.Enabled = True
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
        logData.Add("FileIdentifier,Line,ErrorCode,BootTimeStamp,FirmwareRev")
        For Each item In log
            logData.Add(item.FileIdentifier.ToString() + "," +
                        item.Line.ToString() + "," +
                        "0x" + item.ErrorCode.ToString("X4") + "," +
                        item.BootTimeStamp.ToString() + "," +
                        item.FirmwareRev)
        Next
        saveCSV("fx3_error_log", logData.ToArray())
    End Sub

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