'File:          AppBrowseGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Browse form for all misc. applications which don't need to be on main page.

Imports CCES_JTAG_Wrapper

Public Class AppBrowseGUI
    Inherits FormBase

    Private Sub AppBrowseGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

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

    Private Sub btn_PlotFFT_Click(sender As Object, e As EventArgs) Handles btn_PlotFFT.Click
        Dim subGUI As New FrequencyPlotGUI()
        subGUI.SetTopGUI(Me.m_TopGUI)
        subGUI.Show()
    End Sub
End Class