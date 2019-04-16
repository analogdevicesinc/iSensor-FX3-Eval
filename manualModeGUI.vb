Imports FX3Interface

Public Class manualModeGUI

    Private conn As Connection

    Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        modeSelect.Items.Add("Manual Time")
        modeSelect.Items.Add("Manual FFT")

    End Sub

    Public Sub SetConn(ByRef newConnection As Connection)
        conn = newConnection
    End Sub

    Private Sub ReturnToMain(sender As Object, e As EventArgs) Handles Me.Closing
        TopLevelGUI.Show()
    End Sub

    Private Sub captureButton_Click(sender As Object, e As EventArgs) Handles captureButton.Click

        Dim REC_CTRL1 As Integer = 0
        Dim bufSize As UInteger = 4096
        Dim outputValues As New List(Of String)
        Dim signed As Boolean
        Dim timewaited As Double

        'Set the mode (lower two bits)
        If modeSelect.SelectedItem() = "Manual FFT" Then
            REC_CTRL1 = REC_CTRL1 + 0
            bufSize = 2048
            signed = False
        ElseIf modeSelect.SelectedItem() = "Manual Time" Then
            bufSize = 4096
            REC_CTRL1 = REC_CTRL1 + 2
            signed = True
        Else
            MsgBox("Please Select a capture mode")
            Return
        End If

        'Enable statistics (bit 6)
        If StatCheck.Checked Then
            REC_CTRL1 = REC_CTRL1 + &H40
        End If

        'Enable velocity calc (bit 5)
        If VelocityCheck.Checked Then
            REC_CTRL1 = REC_CTRL1 + &H20
        End If

        'Enable RSS calc (bit 4)
        If RSSCheck.Checked Then
            REC_CTRL1 = REC_CTRL1 + &H10
        End If

        'Select Sample Rate 0
        REC_CTRL1 = REC_CTRL1 + &H100

        conn.Dut.WriteUnsigned(conn.RegMap("REC_CTRL1"), REC_CTRL1)
        conn.Dut.WriteUnsigned(conn.RegMap("COMMAND"), &H800)

        'Wait for data ready high
        timewaited = conn.FX3.PulseWait(conn.FX3.DIO2, 1, 0, 20000)

        Dim xBuf, yBuf, ZBuf

        'Read the buffers
        If signed Then
            conn.Dut.WriteUnsigned(conn.RegMap("BUF_PNTR"), 0)
            xBuf = conn.Dut.ReadSigned(conn.RegMap("X_BUF"), bufSize)
            conn.Dut.WriteUnsigned(conn.RegMap("BUF_PNTR"), 0)
            yBuf = conn.Dut.ReadSigned(conn.RegMap("Y_BUF"), bufSize)
            conn.Dut.WriteUnsigned(conn.RegMap("BUF_PNTR"), 0)
            ZBuf = conn.Dut.ReadSigned(conn.RegMap("Z_BUF"), bufSize)
        Else
            conn.Dut.WriteUnsigned(conn.RegMap("BUF_PNTR"), 0)
            xBuf = conn.Dut.ReadUnsigned(conn.RegMap("X_BUF"), bufSize)
            conn.Dut.WriteUnsigned(conn.RegMap("BUF_PNTR"), 0)
            yBuf = conn.Dut.ReadUnsigned(conn.RegMap("Y_BUF"), bufSize)
            conn.Dut.WriteUnsigned(conn.RegMap("BUF_PNTR"), 0)
            ZBuf = conn.Dut.ReadUnsigned(conn.RegMap("Z_BUF"), bufSize)
        End If

        outputValues.Add("X, Y, Z")

        For i As Integer = 0 To bufSize - 1
            outputValues.Add(xBuf(i).ToString + "," + yBuf(i).ToString() + "," + zBuf(i).ToString)
        Next

        saveCSV("Manual_Capture", outputValues.ToArray)

    End Sub

End Class