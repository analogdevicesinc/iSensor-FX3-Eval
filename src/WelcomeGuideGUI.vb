'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          WelcomeGuideGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Displays a GUI welcome guide and walkthrough on first run.

Imports System.IO

Public Class WelcomeGuideGUI

    Private currentSlide As Integer
    Private slideImageText As String()
    Private basePath As String

    Public Sub Setup() Handles Me.Load
        Me.Top = My.Settings.LastTop
        Me.Left = My.Settings.LastLeft
        Me.BackColor = My.Settings.BackColor
        InitializeGuideResources()
        LoadGuideSlide()
        btn_Next.Focus()
        check_doNotShow.Checked = Not My.Settings.ShowWelcome
    End Sub

    Public Sub ShutDown() Handles Me.Closed
        'save do not show setting
        My.Settings.ShowWelcome = Not check_doNotShow.Checked
    End Sub

    Private Sub InitializeGuideResources()
        currentSlide = 0
        basePath = AppDomain.CurrentDomain.BaseDirectory + "guide\"
        Try
            slideImageText = File.ReadAllLines(Path.Combine(basePath, "guide.txt"))
        Catch ex As Exception
            MsgBox("Error loading guide!")
            check_doNotShow.Checked = True
            slideImageText = {"No guide file loaded"}
        End Try
        displayImage.SizeMode = PictureBoxSizeMode.Zoom
    End Sub

    Private Sub LoadGuideSlide()
        Dim imagePath As String

        btn_Next.Enabled = True
        btn_prev.Enabled = True
        If currentSlide >= (slideImageText.Count - 1) Then
            'limit to last entry and disable next button
            currentSlide = slideImageText.Count - 1
            btn_Next.Enabled = False
        End If
        If currentSlide <= 0 Then
            'limit to entry 0 and disable prev button
            currentSlide = 0
            btn_prev.Enabled = False
        End If
        'update slide number
        slideNum.Text = "Slide " + (currentSlide + 1).ToString() + "/" + slideImageText.Count.ToString()

        messageText.Text = slideImageText(currentSlide)
        'image (if exits) will be under guide/img_currentSlide.png
        imagePath = Path.Combine(basePath, "image_" + currentSlide.ToString() + ".png")
        If File.Exists(imagePath) Then
            displayImage.Image = Image.FromFile(imagePath)
        Else
            displayImage.Image = Nothing
        End If

    End Sub

    Private Sub btn_Next_Click(sender As Object, e As EventArgs) Handles btn_Next.Click
        currentSlide += 1
        LoadGuideSlide()
    End Sub

    Private Sub btn_prev_Click(sender As Object, e As EventArgs) Handles btn_prev.Click
        currentSlide -= 1
        LoadGuideSlide()
    End Sub

    Private Sub wikiLink_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles wikiLink.LinkClicked
        wikiLink.LinkVisited = True
        System.Diagnostics.Process.Start("https://wiki.analog.com/resources/eval/user-guides/inertial-mems/evaluation-systems/eval-adis-fx3")
    End Sub
End Class