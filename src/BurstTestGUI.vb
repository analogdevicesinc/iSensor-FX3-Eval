'File:          BurstTestGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Testing burst mode for ADIS IMU's

Imports FX3Api
Imports RegMapClasses

Public Class BurstTestGUI
    Inherits FormBase

    Private m_AppGUI As AppBrowseGUI

    Private numWords As Integer

    Friend Sub SetAppGUI(AppGUI As AppBrowseGUI)
        m_AppGUI = AppGUI
    End Sub

    Public Sub FormSetup() Handles Me.Load
        sclk.Text = m_TopGUI.FX3.SclkFrequency.ToString()
        drActive.Checked = m_TopGUI.FX3.DrActive
        csDelay.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))
        csDelay.SelectedItem = m_TopGUI.FX3.ChipSelectLeadTime
        num32words.Text = "12"
        numWords = 12
        m_TopGUI.FX3.StripBurstTriggerWord = False
        m_TopGUI.FX3.TriggerReg = New RegClass With {.Address = 0, .Page = 0}
        result.ColumnCount = 3
        result.Columns(0).Name = ("Word Number")
        result.Columns(1).Name = ("MISO Value")
        result.Columns(2).Name = ("MOSI Value")
        result.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        result.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        result.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        SetupResultView()
    End Sub

    Private Sub captureData_Click(sender As Object, e As EventArgs) Handles captureData.Click
        Dim burstTrigger As New List(Of Byte)
        Dim valueLng As ULong
        For i As Integer = 0 To numWords - 1
            valueLng = Convert.ToUInt32(result.Item("MOSI Value", i).Value, 16)
            burstTrigger.Add((valueLng >> 24) And &HFF)
            burstTrigger.Add((valueLng >> 16) And &HFF)
            burstTrigger.Add((valueLng >> 8) And &HFF)
            burstTrigger.Add((valueLng >> 0) And &HFF)
        Next
        m_TopGUI.FX3.TriggerReg = New RegMapClasses.RegClass With {.Address = 0}
        m_TopGUI.FX3.StripBurstTriggerWord = False
        m_TopGUI.FX3.BurstByteCount = 4 * numWords
        m_TopGUI.FX3.SetupBurstMode()
        m_TopGUI.FX3.StartBurstStream(4, burstTrigger)
        m_TopGUI.FX3.WaitForStreamCompletion(250)
        Dim buf() As UShort
        buf = m_TopGUI.FX3.GetBuffer()
        If IsNothing(buf) Then
            MsgBox("Error: Null buffer received...")
            Exit Sub
        End If
        For i As Integer = 0 To numWords - 1
            valueLng = buf(2 * i + 1)
            valueLng += (buf(2 * i) * 2 ^ 16)
            result.Item("MISO Value", i).Value = "0x" + valueLng.ToString("X8")
        Next
    End Sub

    Private Sub applySettings_Click(sender As Object, e As EventArgs) Handles applySettings.Click
        m_TopGUI.FX3.SclkFrequency = Convert.ToInt32(sclk.Text)
        m_TopGUI.FX3.DrActive = drActive.Checked
        m_TopGUI.FX3.ChipSelectLeadTime = csDelay.SelectedItem
        numWords = Convert.ToInt32(num32words.Text)
        SetupResultView()
    End Sub

    Private Sub SetupResultView()
        If result.RowCount < numWords Then
            For i As Integer = result.RowCount To numWords - 1
                result.Rows.Add({i.ToString(), "", "0x00000000"})
            Next
        ElseIf result.RowCount > numWords Then
            Dim numRows = result.RowCount - numWords
            For i As Integer = 0 To numRows - 1
                result.Rows.RemoveAt(result.RowCount - 1)
            Next
        End If

    End Sub

    Private Sub Shutdown() Handles Me.Closing
        m_TopGUI.FX3.StripBurstTriggerWord = True
        m_AppGUI.btn_BurstTest.Enabled = True
    End Sub

End Class