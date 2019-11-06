'File:          AppBrowseGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Browse form for all misc. applications which don't need to be on main page.

Imports CCES_JTAG_Wrapper

Public Class AppBrowseGUI
    Inherits FormBase

    Private Sub AppBrowseGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'register tool tips
        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(Me.btn_BitBangSpi, "Bit-bang SPI traffic to a DUT")
        tip0.SetToolTip(Me.btn_ADXL375, "Stream data or access registers on an ADXL375")
        tip0.SetToolTip(Me.btn_pulseMeasure, "Measure a DIO pulse width. Can send a pin or register trigger condition")
        tip0.SetToolTip(Me.btn_BurstTest, "Test burst mode implementations with longer SPI transactions")

    End Sub

    Private Sub btn_BurstTest_Click(sender As Object, e As EventArgs) Handles btn_BurstTest.Click
        Dim subGUI As New BurstTestGUI()
        subGUI.SetTopGUI(Me.m_TopGUI)
        subGUI.Show()
    End Sub

    Private Sub btn_BitBangSpi_Click(sender As Object, e As EventArgs) Handles btn_BitBangSpi.Click
        Dim subGUI As New BitBangSpiGUI()
        subGUI.SetTopGUI(Me.m_TopGUI)
        subGUI.Show()
    End Sub

    Private Sub btn_ADXL375_Click(sender As Object, e As EventArgs) Handles btn_ADXL375.Click
        Dim subGUI As New ADXl375GUI()
        subGUI.SetTopGUI(Me.m_TopGUI)
        subGUI.Show()
    End Sub

    Private Sub btn_pulseMeasure_Click(sender As Object, e As EventArgs) Handles btn_pulseMeasure.Click
        Dim subGUI As New PulseMeasureGUI()
        subGUI.SetTopGUI(Me.m_TopGUI)
        subGUI.Show()
        m_TopGUI.Hide()
    End Sub

    Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_test.Click

        Dim expected As New List(Of Double)
        Dim real As New List(Of Double)
        For freq As Double = 100 To 4000 Step 100
            m_TopGUI.FX3.StopPWM(m_TopGUI.FX3.DIO2)
            m_TopGUI.FX3.StartPWM(freq, 0.5, m_TopGUI.FX3.DIO2)
            System.Threading.Thread.Sleep(500)
            expected.Add(freq)
            real.Add(m_TopGUI.FX3.ReadDRFreq(m_TopGUI.FX3.DIO1, 1, 5000))
        Next

        Dim result As New List(Of String)
        result.Add("ExpectedFreq, ActualFreq")
        For i As Integer = 0 To real.Count() - 1
            result.Add(expected(i).ToString() + "," + real(i).ToString())
        Next

        saveCSV("FreqSweep", result.ToArray())

    End Sub


End Class