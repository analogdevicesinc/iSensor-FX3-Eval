'File:          SelectFX3GUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Allows a user to choose which FX3 board they want to connect to.

Public Class SelectFX3GUI
    Inherits FormBase

    Private blinkingDictionary As New Dictionary(Of String, Boolean)

    Public Sub FormSetup() Handles Me.Load
        For Each item In m_TopGUI.FX3.AvailableFX3s
            'Build combo box list using board serial numbers
            SelectFX3ComboBox.Items.Add(item)
            'Build dictionary by storing serial number and blinking state together
            blinkingDictionary.Add(item, False)
        Next

        'Set combo box to read-only
        SelectFX3ComboBox.DropDownStyle = ComboBoxStyle.DropDownList

        'if last connected fx3 is available select it by default
        If m_TopGUI.FX3.AvailableFX3s.Contains(m_TopGUI.LastFX3SN) Then
            SelectFX3ComboBox.SelectedItem = m_TopGUI.LastFX3SN
        End If
    End Sub

    Private Sub SelectFX3ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectFX3ComboBox.SelectedIndexChanged

        'Exit if the string is empty (default state)
        If String.Equals(SelectFX3ComboBox.Text, "") Then
            Exit Sub
        End If

        'Turn off all other blinking LEDs
        'For each FX3 board that was detected
        For Each item In m_TopGUI.FX3.AvailableFX3s
            'If the board currently being checked isn't the one selected
            If Not String.Equals(item, SelectFX3ComboBox.Text) Then
                'If the board currently being checked is flagged as blinking
                If blinkingDictionary.Item(item) Then
                    'Turn off the LED
                    m_TopGUI.FX3.BootloaderTurnOffLED(item)
                End If
            End If
        Next

        'Enable blinking the selected board and set the led state in the dictionary
        m_TopGUI.FX3.BootloaderBlinkLED(SelectFX3ComboBox.Text)
        blinkingDictionary.Item(SelectFX3ComboBox.Text) = True

    End Sub

    Private Sub SelectFX3OKButton_Click(sender As Object, e As EventArgs) Handles SelectFX3OKButton.Click
        'Set the active serial number in the FX3 Interface
        m_TopGUI.FX3.ActiveFX3SerialNumber = SelectFX3ComboBox.SelectedItem
        'Close the window. Also calls ClosingWindow to clean up the blinking boards
        Close()
    End Sub

    Private Sub ClosingWindow(sender As Object, e As EventArgs) Handles Me.Closing

        'Turn off all blinking LEDs
        'For each FX3 board that was detected
        For Each item In m_TopGUI.FX3.AvailableFX3s
            'If the board currently being checked is flagged as blinking
            If blinkingDictionary.Item(item) Then
                'Turn off the LED
                m_TopGUI.FX3.BootloaderTurnOffLED(item)
            End If
        Next
    End Sub

End Class