'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          ApiInfoGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Show the information for the current version of the FX3Api DLL.

Public Class ApiInfoGUI
    Inherits FormBase

    Private info As FX3Api.FX3ApiInfo

    Public Sub FormSetup() Handles Me.Load
        info = m_TopGUI.FX3.GetFX3ApiInfo()
        nameLabel.Text = "Project: " + info.Name
        desc.Text = "Description: " + info.Description
        buildDate.Text = "Build Date: " + info.BuildDateTime
        ver.Text = "Version: " + info.VersionNumber
        board_info.Text = m_TopGUI.FX3.ActiveFX3.ToString()
    End Sub

    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        m_TopGUI.btn_APIInfo.Enabled = True
    End Sub

    Private Sub commitLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles commitLink.LinkClicked
        commitLink.LinkVisited = True
        System.Diagnostics.Process.Start(info.GitCommitURL)
    End Sub

End Class