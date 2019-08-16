'File:          FormBase.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Base form that all others in the project inherit from.

Public Class FormBase
    Inherits System.Windows.Forms.Form

    Public Sub Setup() Handles Me.Load
        'Set the start position
        Me.Left = My.Forms.TopGUI.Left
        Me.Top = My.Forms.TopGUI.Top

        'Fix the size
        Me.MaximumSize = Me.Size
        Me.MinimumSize = Me.Size
    End Sub

    Public Sub Cleanup() Handles Me.Closing
        TopGUI.Show()
    End Sub

End Class