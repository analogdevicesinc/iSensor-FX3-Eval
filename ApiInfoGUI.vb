'File:          ApiInfoGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Show the information for the current version of the FX3Api dll.

Public Class ApiInfoGUI
    Inherits FormBase

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        label_info.Text = TopGUI.FX3.GetFX3ApiInfo.ToString()

        'TODO: Add web brower to show last commit source

    End Sub

End Class