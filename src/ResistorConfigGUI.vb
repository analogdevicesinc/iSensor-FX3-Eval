Public Class ResistorConfigGUI
    Inherits FormBase

    Private Sub Shutdown() Handles Me.Closing
        m_TopGUI.btn_resistorConfig.Enabled = True
    End Sub

    Private Sub btn_pullUp_Click(sender As Object, e As EventArgs) Handles btn_pullUp.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        m_TopGUI.FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.PullUp)

    End Sub

    Private Sub btn_pullDown_Click(sender As Object, e As EventArgs) Handles btn_pullDown.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        m_TopGUI.FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.PullDown)

    End Sub

    Private Sub btn_disableResistor_Click(sender As Object, e As EventArgs) Handles btn_disableResistor.Click
        Dim pinNum As UInteger
        Try
            pinNum = Convert.ToUInt32(GPIO_Num.Text)
            If pinNum > 64 Then
                Throw New ArgumentException("ERROR: Max pin index possible is 64")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid pin number. " + ex.ToString())
            Exit Sub
        End Try

        m_TopGUI.FX3.SetPinResistorSetting(New FX3Api.FX3PinObject(pinNum), FX3Api.FX3PinResistorSetting.None)

    End Sub

End Class