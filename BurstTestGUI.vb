'File:          BurstTestGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Testing burst mode for ADIS IMU's

Imports FX3Api

Public Class BurstTestGUI
    Inherits FormBase

    Private numWords As Integer

    Public Sub FormSetup() Handles Me.Load
        sclk.Text = m_TopGUI.FX3.SclkFrequency.ToString()
        drActive.Checked = m_TopGUI.FX3.DrActive
        csDelay.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))
        csDelay.SelectedItem = m_TopGUI.FX3.ChipSelectLeadTime
        numBytes.Text = "20"
        numWords = 9
        m_TopGUI.FX3.StripBurstTriggerWord = False
        result.View = View.Details
        result.Columns.Add("Byte Number")
        result.Columns.Add("Byte Value")
        result.Columns(0).Width = -2
        result.Columns(1).Width = -2
    End Sub

    Private Sub captureData_Click(sender As Object, e As EventArgs) Handles captureData.Click
        Dim addr As New List(Of AdisApi.AddrDataPair)
        m_TopGUI.FX3.TriggerReg = New RegMapClasses.RegClass With {.Address = 0}
        m_TopGUI.FX3.WordCount = numWords
        m_TopGUI.FX3.SetupBurstMode()
        m_TopGUI.FX3.StartBufferedStream(addr, Nothing, 1UI, 10, Nothing)
        m_TopGUI.FX3.WaitForStreamCompletion(250)
        Dim buf() As UShort
        buf = m_TopGUI.FX3.GetBuffer()
        Dim byteNum As Integer = 0
        Dim byteVal As UShort
        result.Items.Clear()
        For Each item In buf
            'lower
            byteVal = (item >> 8)
            result.Items.Add(New ListViewItem(New String() {byteNum.ToString(), byteVal.ToString("X2")}))
            byteNum += 1
            byteVal = item And &HFF
            result.Items.Add(New ListViewItem(New String() {byteNum.ToString(), byteVal.ToString("X2")}))
            byteNum += 1
        Next
    End Sub

    Private Sub applySettings_Click(sender As Object, e As EventArgs) Handles applySettings.Click
        m_TopGUI.FX3.SclkFrequency = Convert.ToInt32(sclk.Text)
        m_TopGUI.FX3.DrActive = drActive.Checked
        m_TopGUI.FX3.ChipSelectLeadTime = csDelay.SelectedItem
        numWords = (Convert.ToInt32(numBytes.Text) / 2) - 1
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        m_TopGUI.FX3.StripBurstTriggerWord = True
    End Sub

End Class