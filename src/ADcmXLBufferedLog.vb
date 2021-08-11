'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          ADcmXLBufferedLog.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   GUI to log buffered capture data (time series or FFT) from ADcmXLx021 series parts.

Imports RegMapClasses

Public Class ADcmXLBufferedLog

    Private Sub ADcmXLBufferedLog_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'default to time domain
        time_cap.Checked = True
        ADcmXLType.Text = m_TopGUI.FX3.PartType.ToString()
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        m_TopGUI.btn_BulkRegRead.Enabled = True
    End Sub

    Private Sub time_cap_CheckedChanged(sender As Object, e As EventArgs) Handles time_cap.CheckedChanged
        If time_cap.Checked Then
            fft_cap.Checked = False
        Else
            fft_cap.Checked = True
        End If
    End Sub

    Private Sub btn_capture_Click(sender As Object, e As EventArgs) Handles btn_capture.Click

        'build reg list based on DUT type
        Dim reglist As New List(Of RegClass)
        Dim regListTemp As New List(Of RegClass)
        Dim data As New List(Of Long)
        Dim result As New List(Of String)
        Dim rc As New RegClass With {.Address = 26, .Page = 0, .NumBytes = 2}
        Dim buf_pntr As New RegClass With {.Address = 10, .Page = 0, .NumBytes = 2}
        Dim waitTime As Double
        Dim sampleLength As Integer
        Dim REC_CTRL1 As UInteger
        Dim index As Integer
        Dim header As String

        Try
            If m_TopGUI.FX3.PartType = FX3Api.DUTType.ADcmXL1021 Then
                reglist.Add(m_TopGUI.RegMap("Z_BUF"))
                reglist.Add(m_TopGUI.RegMap("TEMP_OUT"))
            ElseIf m_TopGUI.FX3.PartType = FX3Api.DUTType.ADcmXL3021 Then
                reglist.Add(m_TopGUI.RegMap("X_BUF"))
                reglist.Add(m_TopGUI.RegMap("Y_BUF"))
                reglist.Add(m_TopGUI.RegMap("Z_BUF"))
                reglist.Add(m_TopGUI.RegMap("TEMP_OUT"))
            ElseIf m_TopGUI.FX3.PartType = FX3Api.DUTType.ADcmXL2021 Then
                reglist.Add(m_TopGUI.RegMap("Y_BUF"))
                reglist.Add(m_TopGUI.RegMap("Z_BUF"))
                reglist.Add(m_TopGUI.RegMap("TEMP_OUT"))
            Else
                Throw New Exception
            End If
        Catch ex As Exception
            MsgBox("ERROR: This form is only usable with machine health sensors - ensure the correct sensor and register map are selected")
            Exit Sub
        End Try

        'establish REC_CTRL1 value, preserving user settings
        REC_CTRL1 = m_TopGUI.Dut.ReadUnsigned(rc)
        'clear lower 2 bits
        REC_CTRL1 = REC_CTRL1 And &HFFFFFFFCUI

        If time_cap.Checked Then
            '2 for time domain
            REC_CTRL1 += 2
            sampleLength = 4096
        Else
            '0 for manual FFT
            REC_CTRL1 += 0
            sampleLength = 2048
        End If
        m_TopGUI.Dut.WriteUnsigned(rc, REC_CTRL1)
        If m_TopGUI.Dut.ReadUnsigned(rc) <> REC_CTRL1 Then
            MsgBox("ERROR: REC_CTRL not set properly - is the DUT connected?")
        End If

        'command 0x800 to start capture
        m_TopGUI.Dut.WriteUnsigned(m_TopGUI.RegMap("COMMAND"), &H800)

        'wait for busy to come back high
        waitTime = m_TopGUI.FX3.PulseWait(m_TopGUI.FX3.DIO2, 1, 0, 10000)

        'update label
        calc_time.Text = waitTime.ToString("#.##") + "ms"

        'read data from ADcmXL
        For Each reg In reglist
            'first ensure buffer pointer is set to 0
            m_TopGUI.Dut.WriteUnsigned(buf_pntr, 0)
            'read each channel individually (all x, then all y, then all z)
            regListTemp.Clear()
            regListTemp.Add(reg)
            data.AddRange(m_TopGUI.Dut.ReadSigned(regListTemp, 1, sampleLength))
        Next

        'data is now formatted x[0], x[1], ... x[n], y[0], y[1], ... y[n]

        'build header
        header = reglist(0).Label
        For i As Integer = 1 To reglist.Count - 1
            header = header + "," + reglist(i).Label
        Next
        result.Add(header)

        'start each row in result CSV
        index = 0
        For i As Integer = 1 To sampleLength
            result.Add(data(index).ToString())
            index += 1
        Next

        'now go through remainder of channels
        For j As Integer = 1 To reglist.Count - 1
            For i As Integer = 1 To sampleLength
                result(i) = result(i) + "," + data(index).ToString()
                index += 1
            Next
        Next

        'log to CSV
        saveCSV("ADcmXL_Buffer_Data", result.ToArray())

    End Sub


End Class