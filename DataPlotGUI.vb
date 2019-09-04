Imports RegMapClasses
Imports System.Timers
Imports System.Windows.Forms.DataVisualization.Charting

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
    Private numSamples As UInteger
    Private log As Boolean
    Private logData As List(Of String)
    Private logTimer As Stopwatch

    Public Sub FormSetup() Handles Me.Load
        PopulateRegView()

        'Set defaults
        plotting = False
        samplePeriodMs = 100
        selectedRegList = New List(Of RegOffsetPair)
        sampleFreq.Text = "20"

        'Set color list
        plotColors = New List(Of Color)

        'Set up timer
        plotTimer = New Timer(500)
        plotTimer.Enabled = False
        AddHandler plotTimer.Elapsed, New ElapsedEventHandler(AddressOf PlotTimerCallback)

        samplesRendered.Text = "200"

        logTimer = New Stopwatch()
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        regView.Height = Me.Height - 122
        dataPlot.Top = 6
        dataPlot.Left = 511
        dataPlot.Width = Me.Width - 532
        dataPlot.Height = Me.Height - 50
        dataPlot.ResetAutoValues()
    End Sub

    Private Sub ShutDown() Handles Me.Closing
        plotTimer.Enabled = False
    End Sub

    Private Sub PlotTimerCallback()
        Me.BeginInvoke(New MethodInvoker(AddressOf PlotWork))
    End Sub

    Private Sub PlotWork()
        Dim regValues() As Double
        Dim plotValues As New List(Of Double)
        Dim logStr As String = ""

        'Read the registers
        Dim regs As New List(Of RegClass)
        For Each reg In selectedRegList
            regs.Add(reg.Reg)
        Next
        regValues = m_TopGUI.Dut.ReadScaledValue(regs)

        If log Then
            logStr = logTimer.ElapsedMilliseconds().ToString()
        End If

        'Update reg view and scale plot values
        Dim index As Integer = 0
        For Each item In selectedRegList
            regView.Item("Contents", item.Index).Value = regValues(index).ToString()
            regView.Item("Contents", item.Index).Style = New DataGridViewCellStyle With {.BackColor = item.Color}
            plotValues.Add(regValues(index) - item.Offset)
            'Log if needed
            If log Then
                logStr = logStr + "," + regValues(index).ToString()
            End If
            index += 1
        Next

        If log Then
            logData.Add(logStr)
        End If

        'Update the series for the plot area
        For i As Integer = 0 To selectedRegList.Count() - 1
            'remove leading point if it exists
            If dataPlot.Series(i).Points.Count() = numSamples Then
                dataPlot.Series(i).Points.RemoveAt(0)
                dataPlot.ResetAutoValues()
            End If
            dataPlot.Series(i).Points.AddXY(plotXPosition, plotValues(i))
        Next

        plotXPosition = plotXPosition + 1

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
            If log Then
                saveCSV("PLOT_LOG", logData.ToArray(), m_TopGUI.lastFilePath)
                logData.Clear()
            End If
            btn_startStop.Text = "Start Plotting"
        Else
            log = logToCSV.Checked
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
            logTimer.Restart()
        End If
    End Sub

    Private Sub BuildPlotRegList()
        Dim headers As String
        For index As Integer = 0 To regView.RowCount() - 1
            If regView.Item("Plot", index).Value = True Then
                If plotColors.Count() <= selectedRegList.Count() Then
                    plotColors.Add(Color.FromArgb(CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF))))
                End If
                selectedRegList.Add(New RegOffsetPair With {.Reg = m_TopGUI.RegMap(regView.Item("Label", index).Value), .Offset = Convert.ToDouble(regView.Item("Offset", index).Value), .Index = index, .Color = plotColors(selectedRegList.Count())})
            End If
        Next
        logData = New List(Of String)
        headers = "TIMESTAMP"
        For Each reg In selectedRegList
            headers = headers + "," + reg.Reg.Label
        Next
        logData.Add(headers)
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

        Try
            numSamples = Convert.ToInt32(samplesRendered.Text)
        Catch ex As Exception
            MsgBox("Invalid number of samples")
            samplesRendered.Text = "500"
            ConfigurePlot()
            Exit Sub
        End Try

        'Reset the chart area
        dataPlot.ChartAreas.Clear()
        dataPlot.ChartAreas.Add(New ChartArea)

        'configure chart
        dataPlot.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        dataPlot.ChartAreas(0).AxisX.MajorGrid.Enabled = True
        dataPlot.ChartAreas(0).AxisX.Title = "Sample Number"
        dataPlot.ChartAreas(0).AxisY.Title = "Scaled Value"

        'Set plotter position
        plotXPosition = 0

        'Remove all existing series
        dataPlot.Series.Clear()

        'Add series for each register
        Dim temp As Series
        For Each reg In selectedRegList
            temp = New Series
            temp.ChartType = SeriesChartType.Line
            temp.Color = reg.Color
            temp.BorderWidth = 2
            temp.Name = reg.Reg.Label
            dataPlot.Series.Add(temp)
        Next

    End Sub

    Private Sub StopPlot()
        'Reset the colors
        For Each item In selectedRegList
            regView.Item("Contents", item.Index).Style = New DataGridViewCellStyle With {.BackColor = Color.White}
        Next
        selectedRegList.Clear()
    End Sub

    Private Sub btn_autonull_Click(sender As Object, e As EventArgs) Handles btn_autonull.Click
        Dim regValues() As Double
        Dim plotValues As New List(Of Double)

        If selectedRegList.Count() = 0 Then
            Exit Sub
        End If

        'Read the registers
        Dim regs As New List(Of RegClass)
        For Each reg In selectedRegList
            regs.Add(reg.Reg)
        Next
        regValues = m_TopGUI.Dut.ReadScaledValue(regs)

        For i As Integer = 0 To selectedRegList.Count() - 1
            selectedRegList(i).Offset = regValues(i)
            regView.Item("Offset", selectedRegList(i).Index).Value = regValues(i).ToString()
        Next

    End Sub

    Private Sub saveChart_Click(sender As Object, e As EventArgs) Handles saveChart.Click
        Dim filebrowser As New SaveFileDialog
        Try
            filebrowser.FileName = m_TopGUI.lastFilePath
        Catch ex As Exception
            filebrowser.FileName = "C:\PLOT.png"
        End Try

        If filebrowser.ShowDialog() = DialogResult.OK Then
            m_TopGUI.lastFilePath = filebrowser.FileName
            dataPlot.SaveImage(filebrowser.FileName, ChartImageFormat.Png)
        Else
            Exit Sub
        End If
    End Sub

End Class