'File:          SelectRegmapGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows a user to select what RegMap CSV they want to load. If there is only one it selects that file.

Imports System.IO

Public Class SelectRegmapGUI

    'Private member variables
    Private m_regmaps() As String
    Private m_selectedpath As String
    Private m_searchpath As String

    Sub New()
        ' This call is required by the designer.
        InitializeComponent()

        'Look for a register map contained within the project directory
        m_searchpath = System.Reflection.Assembly.GetExecutingAssembly.Location
        m_searchpath = m_searchpath.Substring(0, m_searchpath.LastIndexOf("\") + 1)
        m_searchpath += "RegMaps\"
        m_regmaps = Directory.GetFiles(m_searchpath, "*.csv", SearchOption.TopDirectoryOnly)
        'If there is a single Regmap use that, else use the form
        If m_regmaps.Count = 1 Then
            If m_regmaps(0).Contains("RegDataFile") Then
                m_selectedpath = m_regmaps(0)
                ValidatePath()
            End If
        Else
            If m_regmaps Is Nothing Or m_regmaps.Count = 0 Then
                'If zero passed strings use file browser
                Dim fileBrowser As New OpenFileDialog
                Dim fileBrowseResult As DialogResult
                fileBrowser.Title = "Please Select the Register Map File"
                fileBrowser.InitialDirectory = m_searchpath
                fileBrowser.Filter = "RegMap Files|*.csv"
                fileBrowseResult = fileBrowser.ShowDialog()
                m_selectedpath = fileBrowser.FileName
                ValidatePath()
            Else
                'Else add the passed strings to a drop down menu
                For Each item In m_regmaps
                    SelectRegmapComboBox.Items.Add(item)
                Next
                ' default option
                SelectRegmapComboBox.SelectedIndex = 0
            End If
        End If

    End Sub

    Public Sub Setup() Handles Me.Load
        Me.Top = My.Settings.LastTop
        Me.Left = My.Settings.LastLeft
    End Sub

    Public ReadOnly Property SelectedPath() As String
        Get
            Return m_selectedpath
        End Get
    End Property

    Private Sub SelectRegmapGUI_Close(sender As Object, e As FormClosingEventArgs) Handles MyBase.Closing
        ValidatePath()
    End Sub

    Private Sub ValidatePath()
        If Not File.Exists(m_selectedpath) Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me.DialogResult = DialogResult.OK
        End If
    End Sub

    Private Sub OKButton_Click(sender As Object, e As EventArgs) Handles OKButton.Click
        m_selectedpath = SelectRegmapComboBox.SelectedItem
        ValidatePath()
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        'If zero passed strings use file browser
        Dim fileBrowser As New OpenFileDialog
        fileBrowser.Title = "Please Select the Register Map File"
        fileBrowser.InitialDirectory = m_searchpath
        fileBrowser.Filter = "RegMap Files|*.csv"
        fileBrowser.ShowDialog()
        m_selectedpath = fileBrowser.FileName
        ValidatePath()
    End Sub

End Class