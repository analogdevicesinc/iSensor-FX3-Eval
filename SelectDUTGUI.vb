'File:          SelectDUTGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows a user to select their DUT (ADcmXL series or IMU).

Imports FX3Api

Public Class SelectDUTGUI
    Inherits FormBase

    Public Sub FormSetup() Handles Me.Load
        ' Add any initialization after the InitializeComponent() call.
        DutInput.DataSource = ([Enum].GetValues(GetType(DUTType)))
        sensorInput.DataSource = ([Enum].GetValues(GetType(DeviceType)))

        DutInput.SelectedItem = m_TopGUI.FX3.PartType
        sensorInput.SelectedItem = m_TopGUI.FX3.SensorType
    End Sub

    Private Sub btn_ApplySetting_Click(sender As Object, e As EventArgs) Handles btn_ApplySetting.Click

        m_TopGUI.FX3.SensorType = sensorInput.SelectedItem
        m_TopGUI.FX3.PartType = DutInput.SelectedItem
        m_TopGUI.UpdateDutLabel(DutInput.SelectedItem)
        Me.Close()
    End Sub

End Class