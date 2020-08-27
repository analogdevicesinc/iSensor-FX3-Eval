'File:          BurstTestGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Testing burst mode for ADIS IMU's

Imports FX3Api
Imports RegMapClasses

Public Class BurstTestGUI
    Inherits FormBase

    Private m_AppGUI As AppBrowseGUI

    Private m_numBytes As Integer

    Friend Sub SetAppGUI(AppGUI As AppBrowseGUI)
        m_AppGUI = AppGUI
    End Sub

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
        result.Height = Me.Height - 217
    End Sub

    Private Sub captureData_Click(sender As Object, e As EventArgs) Handles captureData.Click
        Dim burstTrigger As New List(Of Byte)
        Dim byteVal As Byte
        Try
            For i As Integer = 0 To m_numBytes - 1
                byteVal = Convert.ToUInt32(result.Item("MOSI Value", i).Value, 16)
                burstTrigger.Add(byteVal)
            Next
        Catch ex As Exception
            MsgBox("ERROR: Invalid MOSI data. " + ex.Message)
        End Try
        m_TopGUI.FX3.TriggerReg = New RegMapClasses.RegClass With {.Address = 0}
        m_TopGUI.FX3.StripBurstTriggerWord = False
        m_TopGUI.FX3.BurstByteCount = m_numBytes
        m_TopGUI.FX3.SetupBurstMode()
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
        m_AppGUI.btn_BurstTest.Enabled = True
    End Sub

    Private Sub num32words_TextChanged(sender As Object, e As EventArgs) Handles numBytes.LostFocus
        Try
            m_numBytes = Convert.ToInt32(numBytes.Text)
            SetupResultView()
        Catch ex As Exception
        End Try
    End Sub

End Class