'File:          SelectDUTGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows a user to select their DUT (ADcmXL series or IMU).

Imports FX3Api

Public Class SelectDUTGUI
    Inherits FormBase

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        DutInput.DataSource = ([Enum].GetValues(GetType(DUTType)))

        DutInput.SelectedItem = TopGUI.FX3.PartType
    End Sub

    Private Sub btn_ApplySetting_Click(sender As Object, e As EventArgs) Handles btn_ApplySetting.Click
        TopGUI.FX3.PartType = DutInput.SelectedItem
        TopGUI.UpdateDutLabel(DutInput.SelectedItem)
        Me.Close()
    End Sub

End Class