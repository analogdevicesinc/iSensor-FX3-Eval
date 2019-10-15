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

    Private Sub btn_test_Click(sender As Object, e As EventArgs) Handles btn_test.Click
        Dim runner As New CCES_runner
        runner.TimeoutSeconds = 1
        Dim result = runner.RunCommand("--list")


    End Sub

End Class