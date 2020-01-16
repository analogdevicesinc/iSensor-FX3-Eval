'File:          ApiInfoGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Show the information for the current version of the FX3Api dll.

Imports System.ComponentModel

Public Class ApiInfoGUI
    Inherits FormBase

    Public Sub FormSetup() Handles Me.Load
        ButtonOpenBrowser.Location = New Point((ClientSize.Width - ButtonOpenBrowser.Width) / 2,
                                       ClientSize.Height - ButtonOpenBrowser.Height - 10)

        label_info.Text = m_TopGUI.FX3.GetFX3ApiInfo.ToString()
    End Sub

    Private Sub ButtonOpenBrowser_Click(sender As Object, e As EventArgs) Handles ButtonOpenBrowser.Click
        Try
            Dim proc = New Process()
            proc.StartInfo.UseShellExecute = True
            proc.StartInfo.FileName = m_TopGUI.FX3.GetFX3ApiInfo.GitCommitURL
            proc.Start()
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class