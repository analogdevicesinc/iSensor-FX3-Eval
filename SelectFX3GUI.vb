Imports CyUSB
Imports AdisApi
Imports FX3Interface
Imports adisInterface

Public Class SelectFX3GUI

    Private conn As Connection
    Private blinkingDictionary As New Dictionary(Of String, Boolean)

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

    End Sub

    Public Sub SetConn(ByRef newConnection As Connection)
        conn = newConnection

        For Each item In conn.FX3.DetectedFX3s
            If Not String.Equals(CType(item, CyFX3Device).FriendlyName, "Cypress FX3 USB StreamerExample Device") Then
                'Build combo box list using board serial numbers
                SelectFX3ComboBox.Items.Add(CType(item, CyFX3Device).SerialNumber)
                'Build dictionary by storing serial number and blinking state together
                blinkingDictionary.Add(CType(item, CyFX3Device).SerialNumber, False)
            End If
        Next

        'Set combo box to read-only
        SelectFX3ComboBox.DropDownStyle = ComboBoxStyle.DropDownList

    End Sub

    Private Sub SelectFX3ComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles SelectFX3ComboBox.SelectedIndexChanged

        'Exit if the string is empty (default state)
        If String.Equals(SelectFX3ComboBox.Text, "") Then
            Exit Sub
        End If

        'Turn off all other blinking LEDs
        'For each FX3 board that was detected
        For Each item In conn.FX3.DetectedFX3s
            'Ignore devices already in streamer mode
            If Not String.Equals(CType(item, CyFX3Device).FriendlyName, "Cypress FX3 USB StreamerExample Device") Then
                'If the board currently being checked isn't the one selected
                If Not String.Equals(CType(item, CyFX3Device).SerialNumber, SelectFX3ComboBox.Text) Then
                    'If the board currently being checked is flagged as blinking
                    If blinkingDictionary.Item(CType(item, CyFX3Device).SerialNumber) Then
                        'Turn off the LED
                        conn.FX3.BootloaderTurnOffLED(CType(item, CyFX3Device).SerialNumber)
                    End If
                End If
            End If
        Next

        'Enable blinking the selected board and set the led state in the dictionary
        conn.FX3.BootloaderBlinkLED(SelectFX3ComboBox.Text)
        blinkingDictionary.Item(SelectFX3ComboBox.Text) = True

    End Sub

    Private Sub SelectFX3OKButton_Click(sender As Object, e As EventArgs) Handles SelectFX3OKButton.Click
        'Set the active serial number in the FX3 Interface
        conn.FX3.ActiveFX3SerialNumber = SelectFX3ComboBox.SelectedItem
        'Close the window. Also calls ClosingWindow to clean up the blinking boards
        Close()
    End Sub

    Private Sub ClosingWindow(sender As Object, e As EventArgs) Handles Me.Closing

        'Turn off all blinking LEDs
        'For each FX3 board that was detected
        For Each item In conn.FX3.DetectedFX3s
            If Not String.Equals(CType(item, CyFX3Device).FriendlyName, "Cypress FX3 USB StreamerExample Device") Then
                'If the board currently being checked is flagged as blinking
                If blinkingDictionary.Item(CType(item, CyFX3Device).SerialNumber) Then
                    'Turn off the LED
                    conn.FX3.BootloaderTurnOffLED(CType(item, CyFX3Device).SerialNumber)
                End If
            End If
        Next
    End Sub

End Class