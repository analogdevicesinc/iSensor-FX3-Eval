'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          FormBase.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Base form that all others in the project inherit from.

Public Class FormBase
    Inherits Form

    Protected WithEvents m_TopGUI As TopGUI

    ''' <summary>
    ''' Form initializer. This is used to make sure each form starts in the same
    ''' spot as the top GUI
    ''' </summary>
    Public Sub Setup() Handles Me.Load
        'Set the start position
        Left = TopGUI.Left
        Top = TopGUI.Top
    End Sub

    ''' <summary>
    ''' Cleanup. Ensure that the top GUI is visible and brought to the front
    ''' </summary>
    Public Sub Cleanup() Handles Me.Closing
        m_TopGUI.Show()
        Application.DoEvents()
    End Sub

    ''' <summary>
    ''' Register top GUI instance with a child form. This must be called
    ''' after creating the child form
    ''' </summary>
    ''' <param name="instance"></param>
    Public Sub SetTopGUI(ByRef instance As TopGUI)
        m_TopGUI = instance
        BackColor = m_TopGUI.BACK_COLOR
    End Sub

End Class