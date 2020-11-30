'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          BitBangSpiGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Bit bang SPI traffic to a DUT. Allows for robustness testing of the SPI interface.

Imports FX3Api

Public Class BitBangSpiGUI
    Inherits FormBase

    Private numBytes As Integer
    Private transfers As UInteger
    Private bptransfer As UInteger
    Private goodParams As Boolean

    Private Sub BitBangSpiGUI_Load(sender As Object, e As EventArgs) Handles Me.Load
        m_TopGUI.FX3.BitBangSpiConfig = New BitBangSpiConfig(True)
        csLeadLag.Text = m_TopGUI.FX3.BitBangSpiConfig.CSLeadTicks.ToString()
        stallTicks.Text = 10.0
        useHardwareSpi.Checked = True
        cpol.Checked = True
        cpha.Checked = True

        result.ColumnCount = 3
        result.Columns(0).Name = ("Byte Number")
        result.Columns(0).SortMode = DataGridViewColumnSortMode.NotSortable
        result.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        result.Columns(1).Name = ("MISO Value")
        result.Columns(1).SortMode = DataGridViewColumnSortMode.NotSortable
        result.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells
        result.Columns(2).Name = ("MOSI Value")
        result.Columns(2).SortMode = DataGridViewColumnSortMode.NotSortable
        result.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        UpdateParameters()
        SetupResultView()

    End Sub

    Private Sub Shutdown() Handles Me.Closing
        'restore hardware SPI
        m_TopGUI.FX3.RestoreHardwareSpi()
        m_TopGUI.btn_bitBangSPI.Enabled = True
    End Sub

    Private Sub btn_Transfer_Click(sender As Object, e As EventArgs) Handles btn_Transfer.Click
        Dim MOSIData As New List(Of Byte)
        Dim MISOData As Byte()
        Try
            m_TopGUI.FX3.SetBitBangSpiFreq(Convert.ToDouble(sclk_freq.Text))
            m_TopGUI.FX3.SetBitBangStallTime(Convert.ToDouble(stallTicks.Text))
            m_TopGUI.FX3.BitBangSpiConfig.CSLagTicks = Convert.ToUInt16(csLeadLag.Text)
            m_TopGUI.FX3.BitBangSpiConfig.CSLeadTicks = Convert.ToUInt16(csLeadLag.Text)
            m_TopGUI.FX3.BitBangSpiConfig.CPHA = Cpha.Checked
            m_TopGUI.FX3.BitBangSpiConfig.CPOL = cpol.Checked
            m_TopGUI.FX3.BitBangSpiConfig.CS = New FX3PinObject(Convert.ToUInt32(CS.Text))
            m_TopGUI.FX3.BitBangSpiConfig.SCLK = New FX3PinObject(Convert.ToUInt32(SCLK.Text))
            m_TopGUI.FX3.BitBangSpiConfig.MISO = New FX3PinObject(Convert.ToUInt32(MISO.Text))
            m_TopGUI.FX3.BitBangSpiConfig.MOSI = New FX3PinObject(Convert.ToUInt32(MOSI.Text))
            'parse input data
            For i As Integer = 0 To numBytes - 1
                MOSIData.Add(Convert.ToUInt32(result.Item("MOSI Value", i).Value, 16))
            Next
            'transfer SPI data
            MISOData = m_TopGUI.FX3.BitBangSpi(bptransfer, transfers, MOSIData.ToArray(), 5000)
            'update output
            For i As Integer = 0 To numBytes - 1
                result.Item("MISO Value", i).Value = "0x" + MISOData(i).ToString("X2")
            Next
        Catch ex As Exception
            MsgBox("ERROR: " + ex.Message())
        End Try

    End Sub

    Private Sub RestoreSPI() Handles Me.Deactivate
        m_TopGUI.FX3.RestoreHardwareSpi()
    End Sub

    Private Sub ParamsChanged() Handles bitsPerTransfer.TextChanged, numTransfers.TextChanged
        UpdateParameters()
        SetupResultView()
    End Sub

    Private Sub UpdateParameters()
        goodParams = True
        Try
            transfers = Convert.ToUInt32(numTransfers.Text)
            bptransfer = Convert.ToUInt32(bitsPerTransfer.Text)
            numBytes = CUInt(Math.Ceiling(bptransfer / 8)) * transfers
        Catch ex As Exception
            'squash
            goodParams = False
        End Try
    End Sub

    Private Sub SetupResultView()
        If result.ColumnCount <> 3 Then Return
        If Not goodParams Then Return
        If result.RowCount < numBytes Then
            For i As Integer = result.RowCount To numBytes - 1
                result.Rows.Add({i.ToString(), "", "0x00"})
            Next
        ElseIf result.RowCount > numBytes Then
            Dim numRows = result.RowCount - numBytes
            For i As Integer = 0 To numRows - 1
                result.Rows.RemoveAt(result.RowCount - 1)
            Next
        End If

    End Sub

    Private Sub ResizeHandler() Handles Me.SizeChanged
        result.Height = Me.Height - 320
    End Sub

    Private Sub useHardwareSpi_CheckedChanged(sender As Object, e As EventArgs) Handles useHardwareSpi.CheckedChanged
        m_TopGUI.FX3.BitBangSpiConfig = New BitBangSpiConfig(useHardwareSpi.Checked)
        UpdatePinLabels()
    End Sub

    Private Sub UpdatePinLabels()
        CS.Text = m_TopGUI.FX3.BitBangSpiConfig.CS.PinNumber.ToString()
        SCLK.Text = m_TopGUI.FX3.BitBangSpiConfig.SCLK.PinNumber.ToString()
        MOSI.Text = m_TopGUI.FX3.BitBangSpiConfig.MOSI.PinNumber.ToString()
        MISO.Text = m_TopGUI.FX3.BitBangSpiConfig.MISO.PinNumber.ToString()
    End Sub

End Class