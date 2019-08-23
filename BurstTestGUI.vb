Imports FX3Api

Public Class BurstTestGUI
    Inherits FormBase

    Private numWords As Integer

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        sclk.Text = TopGUI.FX3.SclkFrequency.ToString()
        drActive.Checked = TopGUI.FX3.DrActive
        csDelay.DataSource = ([Enum].GetValues(GetType(SpiLagLeadTime)))
        csDelay.SelectedItem = TopGUI.FX3.ChipSelectLeadTime
        numBytes.Text = "20"
        numWords = 10
        result.Text = ""

    End Sub

    Private Sub captureData_Click(sender As Object, e As EventArgs) Handles captureData.Click
        Dim addr As New List(Of AdisApi.AddrDataPair)
        TopGUI.FX3.TriggerReg = New RegMapClasses.RegClass With {.Address = 0}
        TopGUI.FX3.WordCount = numWords
        TopGUI.FX3.SetupBurstMode()
        TopGUI.FX3.StartBufferedStream(addr, Nothing, 1UI, 10, Nothing)
        TopGUI.FX3.WaitForStreamCompletion(1000)
        Dim buf() As UShort
        buf = TopGUI.FX3.GetBuffer()
        result.Text = ""
        For Each value In buf
            result.Text = result.Text + value.ToString() + ","
        Next
    End Sub

    Private Sub applySettings_Click(sender As Object, e As EventArgs) Handles applySettings.Click
        TopGUI.FX3.SclkFrequency = Convert.ToInt32(sclk.Text)
        TopGUI.FX3.DrActive = drActive.Checked
        TopGUI.FX3.ChipSelectLeadTime = csDelay.SelectedItem
        numWords = Convert.ToInt32(numBytes.Text) / 2
    End Sub

End Class