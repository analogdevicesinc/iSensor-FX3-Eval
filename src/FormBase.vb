'File:          FormBase.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Base form that all others in the project inherit from.

Public Class FormBase
    Inherits System.Windows.Forms.Form

    Protected WithEvents m_TopGUI As TopGUI

    Public Sub Cleanup() Handles Me.Closing
        m_TopGUI.Show()
    End Sub

    Public Sub SetTopGUI(ByRef instance As TopGUI)
        m_TopGUI = instance
        'Set the start position
        Me.Left = m_TopGUI.Left
        Me.Top = m_TopGUI.Top
        Me.BackColor = m_TopGUI.BACK_COLOR
    End Sub

    Public Sub DisconnectHandler(FX3SerialNumber As String) Handles m_TopGUI.UnexpectedDisconnect
        m_TopGUI.Show()
    End Sub

End Class