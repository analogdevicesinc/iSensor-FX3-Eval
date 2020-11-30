'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          FormBase.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Base form that all others in the project inherit from.

Public Class FormBase
    Inherits System.Windows.Forms.Form

    Protected WithEvents m_TopGUI As TopGUI

    Public Sub Setup() Handles Me.Load
        'Set the start position
        Me.Left = TopGUI.Left
        Me.Top = TopGUI.Top
    End Sub

    Public Sub Cleanup() Handles Me.Closing
        m_TopGUI.Show()
    End Sub

    Public Sub SetTopGUI(ByRef instance As TopGUI)
        m_TopGUI = instance
        Me.BackColor = m_TopGUI.BACK_COLOR
    End Sub

End Class