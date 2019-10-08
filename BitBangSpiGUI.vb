Imports FX3Api

Public Class BitBangSpiGUI
    Inherits FormBase

    Private Sub BitBangSpiGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_TopGUI.FX3.BitBangSpiConfig = New BitBangSpiConfig(True)
        m_TopGUI.FX3.SetBitBangSpiFreq(500000)
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        'restore hardware SPI
        m_TopGUI.FX3.RestoreHardwareSpi()
    End Sub

    Private Sub btn_Transfer_Click(sender As Object, e As EventArgs) Handles btn_Transfer.Click

        Dim transfers, bptransfer As UInteger
        Dim MOSI As New List(Of Byte)
        Dim MISO As Byte()
        Dim MISOStr As String
        Try
            transfers = Convert.ToUInt32(numTransfers.Text)
            bptransfer = Convert.ToUInt32(bitsPerTransfer.Text)
            Dim byteStr As String
            For i As Integer = 0 To MOSIData.Text.Length() - 1 Step 2
                byteStr = MOSIData.Text.Substring(i, 2)
                MOSI.Add(Convert.ToByte(byteStr, 16))
            Next
            MISO = m_TopGUI.FX3.BitBangSpi(bptransfer, transfers, MOSI.ToArray(), 5000)
            MISOStr = ""
            For Each value In MISO
                MISOStr = MISOStr + value.ToString("X2")
            Next
            MISOData.Text = MISOStr
        Catch ex As Exception
            MsgBox("ERROR: Invalid settings. " + ex.Message())
        End Try

    End Sub

    Private Sub btn_restoreSpi_Click(sender As Object, e As EventArgs) Handles btn_restoreSpi.Click
        m_TopGUI.FX3.RestoreHardwareSpi()
    End Sub

    Private Sub RestoreSPI() Handles Me.LostFocus
        m_TopGUI.FX3.RestoreHardwareSpi()
    End Sub
End Class