'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          SelectDUTGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Allows a user to select their DUT (ADcmXL series or IMU).

Imports System.Reflection

Public Class SelectDUTGUI
    Inherits FormBase

    Friend isStartup As Boolean = False

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    ''' <summary>
    ''' Initialize device selection list
    ''' </summary>
    Public Sub FormSetup() Handles Me.Load

        Dim defaultPer As DutPersonality = Nothing

        For Each item In m_TopGUI.DutOptions
            'Only add items with no parent. Ignore custom
            If item.Parent = "" And item.DisplayName <> DutPersonality.CUSTOM_PERSONALITY_STRING Then
                familyInput.Items.Add(item.DisplayName)
            End If
            'check if this personality is selected
            If (item.DisplayName = m_TopGUI.SelectedPersonalityLabel) Or (item.DisplayName = m_TopGUI.LastValidSelectedPersonality) Then
                defaultPer = item
            End If
        Next

        'update family input default selection
        If IsNothing(defaultPer) Then
            'Is there no default? go to index 0 for family
            familyInput.SelectedIndex = 0
            'update default personality 
            For Each per In m_TopGUI.DutOptions
                If familyInput.Items(0).ToString() = per.DisplayName Then
                    defaultPer = per
                    Exit For
                End If
            Next
        ElseIf familyInput.Items.Contains(defaultPer.DisplayName) Then
            'Is selected default a parent?
            familyInput.SelectedItem = defaultPer.DisplayName
        ElseIf familyInput.Items.Contains(defaultPer.Parent) Then
            'Is parent of selected default in the family list?
            familyInput.SelectedItem = defaultPer.Parent
        Else
            'Invalid selection, go to 0
            familyInput.SelectedIndex = 0
        End If

        'update model input default selection
        UpdateModelInput()
        If modelInput.Items.Contains(defaultPer.DisplayName) Then
            modelInput.SelectedItem = defaultPer.DisplayName
        Else
            modelInput.SelectedIndex = 0
        End If
        'set product image
        UpdateDeviceImage()

    End Sub

    Private Sub Shutdown() Handles Me.Closing
        're-enable button
        If Not isStartup Then m_TopGUI.btn_SelectDUT.Enabled = True
    End Sub

    Private Sub btn_ApplySetting_Click(sender As Object, e As EventArgs) Handles btn_ApplySetting.Click
        'check for selected item
        Dim selectedDut As Integer = -1
        For i As Integer = 0 To m_TopGUI.DutOptions.Count - 1
            If modelInput.Text = m_TopGUI.DutOptions(i).DisplayName Then
                selectedDut = i
                Exit For
            End If
        Next

        If selectedDut < 0 Then
            MsgBox("Error: Invalid DUT selected!")
        Else
            If isStartup Then
                m_TopGUI.SelectedPersonalityLabel = modelInput.Text
                m_TopGUI.LastValidSelectedPersonality = modelInput.Text
            Else
                Try
                    If m_TopGUI.ApplyDutPersonality(modelInput.Text) Then
                        'only proceed if not canceled
                        m_TopGUI.ApplyDutPersonalityRegmap(modelInput.Text)
                        m_TopGUI.UpdateDutLabel(m_TopGUI.FX3.PartType)
                        m_TopGUI.SaveAppSettings()
                    End If
                Catch ex As Exception
                    MsgBox("Error applying settings! " + ex.Message)
                End Try
            End If
        End If
        Close()
    End Sub

    Private Sub familyInput_Changed(sender As Object, e As EventArgs) Handles familyInput.TextChanged
        UpdateModelInput()
        UpdateDeviceImage()
    End Sub

    Private Sub UpdateDeviceImage()
        devPicture.SizeMode = PictureBoxSizeMode.Zoom
        devPicture.Visible = True
        Dim resourceSet = My.Resources.ResourceManager.GetResourceSet(Globalization.CultureInfo.CurrentCulture, True, True)
        Dim prodImage = resourceSet.GetObject(familyInput.Text)
        If Not IsNothing(prodImage) Then
            devPicture.Image = prodImage
        Else
            devPicture.Image = My.Resources.MEMS_Icon
        End If

    End Sub

    Private Sub UpdateModelInput()
        modelInput.Items.Clear()
        'add top level
        modelInput.Items.Add(familyInput.Text)
        'add all children
        For Each item In m_TopGUI.DutOptions
            If item.Parent = familyInput.Text Then
                modelInput.Items.Add(item.DisplayName)
            End If
        Next
        modelInput.SelectedIndex = 0
    End Sub

End Class