'File:          PWMSetupGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows a user to configure the FX3 pins as PWM outputs for clock signal generation.

Imports FX3Api
Imports AdisApi

Public Class PWMSetupGUI
    Inherits FormBase

    Private PinList As List(Of IPinObject)
    Private StartPWM As Boolean

    Private Sub PWMSetupGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Defaults
        DutyCycle.Text = "0.5"
        Freq.Text = "2000.0"
        StartPWM = True

        'Populate pin box
        PinList = New List(Of IPinObject)
        pinSelect.DropDownStyle = ComboBoxStyle.DropDownList
        Dim FX3Api = GetType(FX3Connection)
        For Each prop In FX3Api.GetProperties()
            If prop.PropertyType = GetType(IPinObject) Then
                If Not prop.Name = "Reset" Then
                    pinSelect.Items.Add(prop.Name)
                    PinList.Add(m_TopGUI.FX3.GetType().GetProperty(prop.Name).GetValue(m_TopGUI.FX3))
                End If
            End If
        Next
        If pinSelect.Items.Count > 0 Then
            pinSelect.SelectedIndex = 0
        End If

        'Update the button
        UpdateButton(0)

    End Sub

    Private Sub pinSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles pinSelect.SelectedIndexChanged
        UpdateButton(pinSelect.SelectedIndex)
    End Sub

    Private Sub UpdateButton(SelectedIndex As Integer)
        Dim PWMInfo As PinPWMInfo
        Try
            If m_TopGUI.FX3.isPWMPin(PinList(SelectedIndex)) Then
                PWMInfo = m_TopGUI.FX3.GetPinPWMInfo(PinList(SelectedIndex))
                startBtn.Text = "Stop Pin PWM"
                StartPWM = False
                Freq.ReadOnly = True
                Freq.Text = PWMInfo.IdealFrequency.ToString()
                DutyCycle.ReadOnly = True
                DutyCycle.Text = PWMInfo.IdealDutyCycle.ToString()
            Else
                startBtn.Text = "Start Pin PWM"
                StartPWM = True
                Freq.ReadOnly = False
                DutyCycle.ReadOnly = False
            End If
        Catch ex As Exception
            Exit Sub
        End Try
    End Sub

    Private Sub startBtn_Click(sender As Object, e As EventArgs) Handles startBtn.Click
        Try
            If StartPWM Then
                m_TopGUI.FX3.StartPWM(Convert.ToDouble(Freq.Text), Convert.ToDouble(DutyCycle.Text), PinList(pinSelect.SelectedIndex))
            Else
                m_TopGUI.FX3.StopPWM(PinList(pinSelect.SelectedIndex))
            End If
        Catch ex As Exception
            MsgBox("ERROR: Caught exception " + ex.ToString())
        End Try
        UpdateButton(pinSelect.SelectedIndex)
    End Sub

End Class