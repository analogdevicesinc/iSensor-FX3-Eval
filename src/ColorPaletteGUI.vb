'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          ColorPaletteGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Allows configuration of the EVAL-ADIS-FX3 GUI color palette

Public Class ColorPaletteGUI

    Private enableButton As Button
    Private goodColor As Boolean

    Friend Sub SetEnableButton(ByRef btn As Button)
        enableButton = btn
    End Sub

    Private Sub SetColors() Handles Me.Load
        good_color.BackColor = m_TopGUI.GOOD_COLOR
        good_color.Text = "0x" + good_color.BackColor.ToArgb.ToString("X4")

        error_color.BackColor = m_TopGUI.ERROR_COLOR
        error_color.Text = "0x" + error_color.BackColor.ToArgb.ToString("X4")

        idle_color.BackColor = m_TopGUI.IDLE_COLOR
        idle_color.Text = "0x" + idle_color.BackColor.ToArgb.ToString("X4")

        back_color.BackColor = m_TopGUI.BACK_COLOR
        back_color.Text = "0x" + back_color.BackColor.ToArgb.ToString("X4")
    End Sub

    Private Sub good_color_Click(sender As Object, e As EventArgs) Handles good_color.Click
        Dim c As Color = GetUserColor()
        If goodColor Then
            good_color.BackColor = c
            good_color.Text = "0x" + good_color.BackColor.ToArgb.ToString("X4")
        End If
    End Sub

    Private Sub error_color_Click(sender As Object, e As EventArgs) Handles error_color.Click
        Dim c As Color = GetUserColor()
        If goodColor Then
            error_color.BackColor = c
            error_color.Text = "0x" + error_color.BackColor.ToArgb.ToString("X4")
        End If
    End Sub

    Private Sub idle_color_Click(sender As Object, e As EventArgs) Handles idle_color.Click
        Dim c As Color = GetUserColor()
        If goodColor Then
            idle_color.BackColor = c
            idle_color.Text = "0x" + idle_color.BackColor.ToArgb.ToString("X4")
        End If
    End Sub

    Private Sub back_color_Click(sender As Object, e As EventArgs) Handles back_color.Click
        Dim c As Color = GetUserColor()
        If goodColor Then
            back_color.BackColor = c
            back_color.Text = "0x" + back_color.BackColor.ToArgb.ToString("X4")
        End If
    End Sub

    Private Sub btn_applysettings_Click(sender As Object, e As EventArgs) Handles btn_applysettings.Click
        m_TopGUI.ERROR_COLOR = error_color.BackColor
        m_TopGUI.GOOD_COLOR = good_color.BackColor
        m_TopGUI.IDLE_COLOR = idle_color.BackColor
        m_TopGUI.BACK_COLOR = back_color.BackColor
        m_TopGUI.BackColor = m_TopGUI.BACK_COLOR
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        enableButton.Enabled = True
    End Sub

    Private Function GetUserColor() As Color
        goodColor = True
        Dim colorBrowse As New ColorDialog
        colorBrowse.AllowFullOpen = True
        colorBrowse.AnyColor = True
        If colorBrowse.ShowDialog() = DialogResult.OK Then
            Return colorBrowse.Color
        Else
            goodColor = False
            Return Nothing
        End If
    End Function

    Private Sub btn_restoreDefaults_Click(sender As Object, e As EventArgs) Handles btn_restoreDefaults.Click
        m_TopGUI.LoadDefaultColors()
        SetColors()
    End Sub

End Class