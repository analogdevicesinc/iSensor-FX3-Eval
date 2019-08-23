Imports RegMapClasses
Imports System.Timers

Structure RegOffsetPair
    Public Offset As Double
    Public Reg As RegClass
    Public Index As Integer
    Public Color As Color
End Structure

Public Class DataPlotGUI
    Inherits FormBase

    Private samplePeriodMs As Integer
    Private plotting As Boolean
    Private selectedRegList As List(Of RegOffsetPair)
    Private plotTimer As Timer
    Private plotXPosition As Integer
    Private plotYMin As Integer
    Private plotYMax As Integer
    Private plotColors As List(Of Color)

    Public Sub FormSetup() Handles Me.Load
        PopulateRegView()

        'Set defaults
        plotting = False
        samplePeriodMs = 100
        selectedRegList = New List(Of RegOffsetPair)
        sampleFreq.Text = "10"

        'Set color list
        plotColors = New List(Of Color)
        'plotColors.Add(Color.FromArgb(&HFC5C65))
        'plotColors.Add(Color.FromArgb(&HFD9644))
        'plotColors.Add(Color.FromArgb(&HFED330))
        'plotColors.Add(Color.FromArgb(&H26DE81))
        'plotColors.Add(Color.FromArgb(&H2BCBBA))
        'plotColors.Add(Color.FromArgb(&H45AAF2))
        'plotColors.Add(Color.FromArgb(&H4B7BEC))
        'plotColors.Add(Color.FromArgb(&HA55EEA))
        'plotColors.Add(Color.FromArgb(&H778CA3))

        'Set up timer
        plotTimer = New Timer(500)
        plotTimer.Enabled = False
        AddHandler plotTimer.Elapsed, New ElapsedEventHandler(AddressOf PlotTimerCallback)
    End Sub

    Private Sub PlotTimerCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf PlotWork))
    End Sub

    Private Sub PlotWork()
        Dim regValues() As Double
        Dim plotValues As New List(Of Double)

        'Read the registers
        Dim regs As New List(Of RegClass)
        For Each reg In selectedRegList
            regs.Add(reg.Reg)
        Next
        regValues = m_TopGUI.Dut.ReadScaledValue(regs)

        'Update reg view and scale plot values
        Dim index As Integer = 0
        For Each item In selectedRegList
            regView.Item("Contents", item.Index).Value = regValues(index).ToString()
            regView.Item("Contents", item.Index).Style = New DataGridViewCellStyle With {.BackColor = item.Color}
            plotValues.Add(regValues(index) - item.Offset)
            index += 1
        Next

    End Sub

    Private Sub PopulateRegView()
        Dim regIndex As Integer = 0
        Dim regStr() As String
        Dim readStr As String = "Not Read"
        For Each reg In m_TopGUI.RegMap
            If reg.IsReadable Then
                If regIndex >= regView.RowCount Then
                    regStr = {reg.Label, reg.Page.ToString(), reg.Address.ToString(), readStr, "False", "0"}
                    regView.Rows.Add(regStr)
                Else
                    regView.Item("Label", regIndex).Value = reg.Label
                    regView.Item("Page", regIndex).Value = reg.Page
                    regView.Item("Address", regIndex).Value = reg.Address
                    regView.Item("Contents", regIndex).Value = readStr
                    regView.Item("Plot", regIndex).Value = True
                    regView.Item("Offset", regIndex).Value = "0"
                End If
                regIndex += 1
            End If
        Next
    End Sub

    Private Sub btn_startStop_Click(sender As Object, e As EventArgs) Handles btn_startStop.Click
        If plotting Then
            'Stop
            plotting = False
            plotTimer.Enabled = False
            StopPlot()
            btn_startStop.Text = "Start Plotting"
        Else
            BuildPlotRegList()
            If selectedRegList.Count() = 0 Then
                MsgBox("ERROR: Must select at least one register to plot")
                Exit Sub
            End If
            plotting = True
            ConfigurePlot()
            plotTimer.Interval = samplePeriodMs
            plotTimer.Enabled = True
            btn_startStop.Text = "Stop Plotting"
        End If
    End Sub

    Private Sub BuildPlotRegList()
        For index As Integer = 0 To regView.RowCount() - 1
            If regView.Item("Plot", index).Value = True Then
                If plotColors.Count() <= selectedRegList.Count() Then
                    plotColors.Add(Color.FromArgb(CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF))))
                End If
                selectedRegList.Add(New RegOffsetPair With {.Reg = m_TopGUI.RegMap(regView.Item("Label", index).Value), .Offset = Convert.ToDouble(regView.Item("Offset", index).Value), .Index = index, .Color = plotColors(selectedRegList.Count())})
            End If
        Next
    End Sub

    Private Sub ConfigurePlot()
        'Set up frequency
        Dim freq As Double
        Try
            freq = Convert.ToDouble(sampleFreq.Text)
            samplePeriodMs = 1000 / freq
            If samplePeriodMs < 5 Then
                Throw New Exception("Cannot run at more than 200Hz")
            End If
        Catch ex As Exception
            MsgBox("ERROR: Invalid sample frequency. " + ex.ToString())
            sampleFreq.Text = "10"
            samplePeriodMs = 100
        End Try

    End Sub

    Private Sub StopPlot()
        'Reset the colors
        For Each item In selectedRegList
            regView.Item("Contents", item.Index).Style = New DataGridViewCellStyle With {.BackColor = Color.White}
        Next
        selectedRegList.Clear()
    End Sub

End Class