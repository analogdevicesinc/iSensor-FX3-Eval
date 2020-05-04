'File:          AppBrowseGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Browse form for all misc. applications which don't need to be on main page.

Imports FX3Api

Public Class AppBrowseGUI
    Inherits FormBase

    Private Sub AppBrowseGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'register tool tips
        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(Me.btn_BitBangSpi, "Bit-bang SPI traffic to a DUT")
        tip0.SetToolTip(Me.btn_ADXL375, "Stream data or access registers on an ADXL375")
        tip0.SetToolTip(Me.btn_pulseMeasure, "Measure a DIO pulse width. Can send a pin or register trigger condition")
        tip0.SetToolTip(Me.btn_BurstTest, "Test burst mode implementations with longer SPI transactions")
        tip0.SetToolTip(Me.btn_binFile, "Generate a binary data file filled with an arbitrary pattern")

        'check other open forms to dis-allow duplicate forms being open
        For Each openForm As Form In Application.OpenForms
            If TypeOf (openForm) Is BurstTestGUI Then
                btn_BurstTest.Enabled = False
                Dim subGUI As BurstTestGUI = DirectCast(openForm, BurstTestGUI)
                subGUI.SetAppGUI(Me)
            End If
            If TypeOf (openForm) Is BitBangSpiGUI Then
                btn_BitBangSpi.Enabled = False
                Dim subGUI As BitBangSpiGUI = DirectCast(openForm, BitBangSpiGUI)
                subGUI.SetAppGUI(Me)
            End If
            If TypeOf (openForm) Is ADXl375GUI Then
                btn_ADXL375.Enabled = False
                Dim subGUI As ADXl375GUI = DirectCast(openForm, ADXl375GUI)
                subGUI.SetAppGUI(Me)
            End If
            If TypeOf (openForm) Is PulseMeasureGUI Then
                btn_pulseMeasure.Enabled = False
                Dim subGUI As PulseMeasureGUI = DirectCast(openForm, PulseMeasureGUI)
                subGUI.SetAppGUI(Me)
            End If
            If TypeOf (openForm) Is ResistorConfigGUI Then
                btn_resistorConfig.Enabled = False
                Dim subGUI As ResistorConfigGUI = DirectCast(openForm, ResistorConfigGUI)
                subGUI.SetAppGUI(Me)
            End If
            If TypeOf (openForm) Is BinaryFileWriterGUI Then
                btn_binFile.Enabled = False
                Dim subGUI As BinaryFileWriterGUI = DirectCast(openForm, BinaryFileWriterGUI)
                subGUI.SetAppGUI(Me)
            End If
            If TypeOf (openForm) Is FlashInterfaceGUI Then
                btn_checkError.Enabled = False
                Dim subGUI As FlashInterfaceGUI = DirectCast(openForm, FlashInterfaceGUI)
                subGUI.SetAppGUI(Me)
            End If
        Next

    End Sub

    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        m_TopGUI.btn_OtherApps.Enabled = True
    End Sub

    Private Sub btn_BurstTest_Click(sender As Object, e As EventArgs) Handles btn_BurstTest.Click
        Dim subGUI As New BurstTestGUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_BurstTest.Enabled = False
    End Sub

    Private Sub btn_BitBangSpi_Click(sender As Object, e As EventArgs) Handles btn_BitBangSpi.Click
        Dim subGUI As New BitBangSpiGUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_BitBangSpi.Enabled = False
    End Sub

    Private Sub btn_ADXL375_Click(sender As Object, e As EventArgs) Handles btn_ADXL375.Click
        Dim subGUI As New ADXl375GUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_ADXL375.Enabled = False
    End Sub

    Private Sub btn_pulseMeasure_Click(sender As Object, e As EventArgs) Handles btn_pulseMeasure.Click
        Dim subGUI As New PulseMeasureGUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_pulseMeasure.Enabled = False
    End Sub

    Private Sub btn_resistorConfig_Click(sender As Object, e As EventArgs) Handles btn_resistorConfig.Click
        Dim subGUI As New ResistorConfigGUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_resistorConfig.Enabled = False
    End Sub

    Private Sub btn_binFile_Click(sender As Object, e As EventArgs) Handles btn_binFile.Click
        Dim subGUI As New BinaryFileWriterGUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_binFile.Enabled = False
    End Sub

    Private Sub btn_checkError_Click(sender As Object, e As EventArgs) Handles btn_checkError.Click
        Dim subGUI As New FlashInterfaceGUI()
        subGUI.SetTopGUI(m_TopGUI)
        subGUI.SetAppGUI(Me)
        subGUI.Show()
        btn_checkError.Enabled = False
    End Sub

End Class