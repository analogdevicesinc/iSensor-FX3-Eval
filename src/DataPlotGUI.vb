'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          DataPlotGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Allows for data plotting and logging, along with playback of logged data.

Imports RegMapClasses
Imports System.Timers
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading
Imports System.IO

Public Class DataPlotGUI
    Inherits FormBase

    Private samplePeriodMs As Integer
    Private plotting As Boolean
    Private selectedRegList As List(Of RegPlotterInfo)
    Private plotTimer As System.Timers.Timer
    Private plotXPosition As Integer
    Private plotYMin As Integer
    Private plotYMax As Integer
    Private numSamples As UInteger
    Private logData As List(Of String)
    Private logTimer As Stopwatch
    Private runTime As Long
    Private playBackRunning As Boolean
    Private playBackMutex As Mutex
    Private plotMutex As Mutex
    Private CSVRegData As List(Of String())
    Private plotYLabel As String
    Private plotFocus As Boolean
    Private numberPlotAreas As Integer

#Region "Event Handlers"

    Public Sub FormSetup() Handles Me.Load
        'set up plot areas
        numberPlotAreas = 0
        PopulateRegView()

        If m_TopGUI.TimePlotHeight <> 0 Then Height = m_TopGUI.TimePlotHeight
        If m_TopGUI.TimePlotWidth <> 0 Then Width = m_TopGUI.TimePlotWidth

        'Set defaults
        plotting = False
        samplePeriodMs = 100
        selectedRegList = New List(Of RegPlotterInfo)
        sampleFreq.Text = "20"
        dataPlot.Series.Clear()
        runTime = Long.MaxValue

        'Set up timer
        plotTimer = New System.Timers.Timer(500)
        plotTimer.Enabled = False
        AddHandler plotTimer.Elapsed, New ElapsedEventHandler(AddressOf PlotTimerCallback)

        'set up display
        btn_stopPlayback.Enabled = False
        btn_stopPlayback.Visible = False
        plotYLabel = "Scaled Value"

        'Load settings
        sampleFreq.Text = m_TopGUI.plotSettings.UpdateRate
        samplesRendered.Text = m_TopGUI.plotSettings.SamplesRendered
        axis_autoscale.Checked = m_TopGUI.plotSettings.Autoscale
        logToCSV.Checked = m_TopGUI.plotSettings.LogData
        x_timestamp.Checked = m_TopGUI.plotSettings.Timestamp

        'create synchronization structures
        logTimer = New Stopwatch()
        playBackMutex = New Mutex()
        plotMutex = New Mutex()

        regView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells
        RegisterToolTips()
    End Sub

    Private Sub ShutDown() Handles Me.Closing
        plotTimer.Enabled = False
        playBackRunning = False
        plotting = False
        playBackMutex.WaitOne()
        plotMutex.WaitOne()
        m_TopGUI.FX3.UserLEDOn()
        m_TopGUI.TimePlotWidth = Width
        m_TopGUI.TimePlotHeight = Height

        'save settings
        m_TopGUI.plotSettings.UpdateRate = sampleFreq.Text
        m_TopGUI.plotSettings.SamplesRendered = samplesRendered.Text
        m_TopGUI.plotSettings.Autoscale = axis_autoscale.Checked
        m_TopGUI.plotSettings.LogData = logToCSV.Checked
        m_TopGUI.plotSettings.Timestamp = x_timestamp.Checked
        m_TopGUI.plotSettings.ScrollBar = x_axis_scroll.Checked
        m_TopGUI.plotSettings.NumberPlots = numberPlotAreas

        'save regs which were plotted
        m_TopGUI.dataPlotRegs.Clear()
        For Each reg In selectedRegList
            m_TopGUI.dataPlotRegs.Add(reg)
        Next
        m_TopGUI.SaveDataPlotRegList()
        m_TopGUI.btn_plotData.Enabled = True
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        regView.Height = Height - 172
        dataPlot.Top = 6
        dataPlot.Left = 532
        dataPlot.Width = Width - 555
        dataPlot.Height = Height - 53
        dataPlot.ResetAutoValues()
    End Sub

    Private Sub btn_startStop_Click(sender As Object, e As EventArgs) Handles btn_startStop.Click
        If plotting Then
            'Stop
            logToCSV.Enabled = True
            plotting = False
            plotTimer.Enabled = False
            'get the plotter mutex (finish plot in progress)
            plotMutex.WaitOne()
            StopPlot()
            'save log if there is data
            If logData.Count > 1 Then
                saveCSV("PLOT_LOG", logData.ToArray(), m_TopGUI.lastFilePath)
                logData.Clear()
            End If
            sampleFreq.Enabled = True
            samplesRendered.Enabled = True
            check_fixedTime.Enabled = True
            playFromCSV.Enabled = True
            playFromCSV.Visible = True
            x_timestamp.Enabled = True
            x_axis_scroll.Enabled = True
            btn_RemovePlot.Enabled = True
            btn_AddPlot.Enabled = True
            m_TopGUI.FX3.UserLEDOn()
            btn_startStop.Text = "Start Plotting"
        Else
            'start
            BuildPlotRegList()
            If selectedRegList.Count() = 0 Then
                MsgBox("ERROR: Must select at least one register to plot")
                Exit Sub
            End If
            logToCSV.Enabled = False
            plotting = True
            ConfigurePlot()
            plotTimer.Interval = samplePeriodMs
            'ask for plot duration
            GetPlotDuration()
            plotTimer.Enabled = True
            sampleFreq.Enabled = False
            samplesRendered.Enabled = False
            playFromCSV.Enabled = False
            playFromCSV.Visible = False
            check_fixedTime.Enabled = False
            x_timestamp.Enabled = False
            x_axis_scroll.Enabled = False
            btn_RemovePlot.Enabled = False
            btn_AddPlot.Enabled = False
            btn_startStop.Text = "Stop Plotting"
            Try
                m_TopGUI.FX3.UserLEDBlink(250 / samplePeriodMs)
            Catch ex As Exception
                'don't do anything, just don't want the program to crash if user is driving a PWM using that timer block on the FX3
            End Try
            logTimer.Restart()
        End If
    End Sub

    Private Sub btn_copyPlot_Click(sender As Object, e As EventArgs) Handles btn_copyPlot.Click
        'copy current plotter image to clipboard
        Using stream As New MemoryStream
            dataPlot.SaveImage(stream, ChartImageFormat.Bmp)
            Clipboard.SetImage(New Bitmap(stream))
        End Using
    End Sub

    Private Sub btn_setTitle_Click(sender As Object, e As EventArgs) Handles btn_setTitle.Click
        'starting title
        Dim startTitle As String = ""
        If dataPlot.Titles.Count > 0 Then
            startTitle = dataPlot.Titles(0).Text
        Else
            startTitle = m_TopGUI.SelectedPersonality + " Time Domain Plot"
        End If

        'If title is empty then remove
        dataPlot.Titles.Clear()

        Dim val As String = InputBox("Enter Plot Title: ", "Input", startTitle)
        'check for cancel
        If val = "" Then Exit Sub
        dataPlot.Titles.Add(val)
        dataPlot.Titles(0).Font = New Font(sampleFreq.Font.Name, 16.0F)

    End Sub

    Private Sub btn_AddPlot_Click(sender As Object, e As EventArgs) Handles btn_AddPlot.Click
        numberPlotAreas += 1
        plotYLabel = plotYLabel + ",Scaled Data"
        Dim col As DataGridViewColumn
        col = New DataGridViewCheckBoxColumn()
        col.HeaderText = "Plot" + numberPlotAreas.ToString()
        col.Name = "Plot" + numberPlotAreas.ToString()
        col.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader
        col.ValueType = GetType(Boolean)
        regView.Columns.Insert(3 + numberPlotAreas, col)
        ResetPlotAreas()
    End Sub

    Private Sub btn_RemovePlot_Click(sender As Object, e As EventArgs) Handles btn_RemovePlot.Click
        Dim index As Integer = plotYLabel.LastIndexOf(",")
        If numberPlotAreas > 1 Then
            regView.Columns.RemoveAt(3 + numberPlotAreas)
            If index > 0 Then
                plotYLabel = plotYLabel.Remove(index)
            End If
            numberPlotAreas -= 1
        End If
        ResetPlotAreas()
    End Sub

    Private Sub btn_autonull_Click(sender As Object, e As EventArgs) Handles btn_autonull.Click
        Dim regValues() As Double
        Dim plotValues As New List(Of Double)

        If selectedRegList.Count() = 0 Then
            Exit Sub
        End If

        'Read the registers
        regValues = GetPlotRegValues()

        For i As Integer = 0 To selectedRegList.Count() - 1
            selectedRegList(i).Reg.Offset += regValues(i)
            regView.Item("Offset", selectedRegList(i).Index).Value = selectedRegList(i).Reg.Offset.ToString()
        Next

    End Sub

    Private Sub saveChart_Click(sender As Object, e As EventArgs) Handles btn_saveChart.Click
        Dim filebrowser As New SaveFileDialog
        Dim fileName As String = "data_plot_" + m_TopGUI.SelectedPersonality + "_" + GetTime() + ".png"
        Try
            filebrowser.FileName = fileName
            filebrowser.Filter = "Image Files (*.png) | *.png"
            filebrowser.InitialDirectory = m_TopGUI.lastFilePath.Substring(0, m_TopGUI.lastFilePath.LastIndexOf("\") + 1)
        Catch ex As Exception
            'squash
        End Try

        If filebrowser.ShowDialog() = DialogResult.OK Then
            m_TopGUI.lastFilePath = filebrowser.FileName
            dataPlot.SaveImage(filebrowser.FileName, ChartImageFormat.Png)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub playFromCSV_Click(sender As Object, e As EventArgs) Handles playFromCSV.Click
        Dim fileBrowser As New OpenFileDialog
        Dim fileBrowseResult As DialogResult
        Dim filePath As String
        fileBrowser.Title = "Please Select the CSV log File"
        fileBrowser.InitialDirectory = m_TopGUI.lastFilePath
        fileBrowser.Filter = "Log Files|*.csv"
        fileBrowseResult = fileBrowser.ShowDialog()
        If fileBrowseResult = DialogResult.OK Then
            filePath = fileBrowser.FileName
            CSVRegData = LoadFromCSV(filePath)
        Else
            Exit Sub
        End If

        If Not SetupCSVRegs() Then
            MsgBox("ERROR: Invalid Log CSV")
            Exit Sub
        End If
        logToCSV.Checked = False
        check_fixedTime.Checked = False
        BuildPlotRegList()
        ConfigurePlot()
        DisablePlaybackButtons()
        playBackRunning = True

        Dim temp As New Thread(AddressOf PlayCSVWorker)
        temp.Start()

    End Sub

    Private Sub stopPlayback_Click(sender As Object, e As EventArgs) Handles btn_stopPlayback.Click
        playBackRunning = False
    End Sub

    Private Sub DataPlotMouseClick() Handles dataPlot.MouseClick
        plotFocus = True
    End Sub

    Private Sub axis_autoscale_CheckedChanged(sender As Object, e As EventArgs) Handles axis_autoscale.CheckedChanged
        Dim zoomFlag As Boolean = Not axis_autoscale.Checked
        For Each chart In dataPlot.ChartAreas
            chart.CursorY.AutoScroll = False
            chart.AxisY.ScaleView.Zoomable = zoomFlag
            chart.CursorY.IsUserSelectionEnabled = zoomFlag
            chart.CursorY.IsUserEnabled = zoomFlag
            'autozoom?
            If Not zoomFlag Then
                chart.AxisY.Minimum = Double.NaN
                chart.AxisY.Maximum = Double.NaN
                chart.AxisY.ScaleView.ZoomReset()
            End If
        Next
    End Sub

    Private Sub HiddenHandler() Handles Me.VisibleChanged
        If Not Visible Then
            'disable plotting
            If plotting Then btn_startStop_Click(Me, Nothing)
        End If
    End Sub

    Private Sub btn_SetLabel_Click(sender As Object, e As EventArgs) Handles btn_SetLabel.Click
        Dim val As String = InputBox("Enter Y-Axis Labels, Comma Separated: ", "Input", plotYLabel)
        'check for cancel
        If val = "" Then Exit Sub
        plotYLabel = val
        ApplyYAxisTitles()
    End Sub

    Private Sub FormClick() Handles Me.Click
        plotFocus = False
    End Sub

    Private Sub WriteEnterHandler(sender As Object, e As KeyEventArgs)

        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If

    End Sub

    Private Sub AnnoyingNoiseHandler(sender As Object, e As KeyEventArgs)
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

#End Region

#Region "Helper Functions"

    Private Sub RegisterToolTips()
        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(label_sampleFreq, "The data sampling frequency for plotting. This is driven by a Windows software timer, and is not very accurate")
        tip0.SetToolTip(label_samplesRendered, "The maximum number of samples to render in a single plot")
        tip0.SetToolTip(btn_startStop, "Start or Stop data plotting")
        tip0.SetToolTip(btn_autonull, "Set the offset values for each register being plotted to the last read value")
        tip0.SetToolTip(btn_saveChart, "Save image of the current plot area")
        tip0.SetToolTip(playFromCSV, "Play back data plot from a CSV plot log")
        tip0.SetToolTip(logToCSV, "Save plot data to a CSV log")
        tip0.SetToolTip(regView, "Select registers to plot, and supply register offset values. The data plotted for each register is scaled by the scale factor defined in the register map CSV file")
        tip0.SetToolTip(check_fixedTime, "Stop plotting automatically after a fixed time interval. This is useful when the data plotting application is being used for logging")
        tip0.SetToolTip(x_timestamp, "Plot sample timestamps on X-axis (default is sample counter)")
        tip0.SetToolTip(btn_SetLabel, "Set the Y-Axis label")
        tip0.SetToolTip(btn_setTitle, "Set the plot title")
        tip0.SetToolTip(btn_copyPlot, "Copy the current plot image to the clipboard (for pasting in office, word, etc)")
        tip0.SetToolTip(btn_AddPlot, "Add a new data plot to the active plotting area")
        tip0.SetToolTip(btn_RemovePlot, "Remove a data plot from the active plotting area")
    End Sub

    Private Sub PopulateRegView()
        Dim regIndex As Integer = 0
        Dim regStr() As String
        Dim readStr As String = "Not Read"
        Dim scaleStr As String
        For Each reg In m_TopGUI.RegMap
            If reg.IsReadable Then
                'scale is 1/register map scale factor to match datasheet better
                scaleStr = (1.0 / reg.Scale).ToString()
                If regIndex >= regView.RowCount Then
                    regStr = {reg.Label, reg.Page.ToString(), reg.Address.ToString(), readStr, reg.Offset.ToString(), scaleStr}
                    regView.Rows.Add(regStr)
                Else
                    regView.Item("Label", regIndex).Value = reg.Label
                    regView.Item("Page", regIndex).Value = reg.Page
                    regView.Item("Address", regIndex).Value = reg.Address
                    regView.Item("Contents", regIndex).Value = readStr
                    regView.Item("Offset", regIndex).Value = reg.Offset.ToString()
                    regView.Item("reg_scale", regIndex).Value = scaleStr
                End If
                regIndex += 1
            End If
        Next
        'add plots
        While numberPlotAreas < m_TopGUI.plotSettings.NumberPlots
            btn_AddPlot_Click(Nothing, Nothing)
        End While
        'select any regs previously selected
        For Each reg In m_TopGUI.dataPlotRegs
            regIndex = -1
            For i As Integer = 0 To regView.RowCount - 1
                If regView.Item("Label", i).Value = reg.Reg.Label Then
                    regIndex = i
                    Exit For
                End If
            Next
            If regIndex >= 0 And reg.PlotIndex < numberPlotAreas Then
                regView.Item("Plot" + (reg.PlotIndex + 1).ToString(), regIndex).Value = True
            End If
        Next

    End Sub

    Private Sub ResetPlotAreas()

        'update autosizing for register labels
        regView.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

        'Reset the chart area and add new plots based on selected number
        dataPlot.Series.Clear()
        dataPlot.ChartAreas.Clear()
        'configure charts
        For i As Integer = 0 To numberPlotAreas - 1
            dataPlot.ChartAreas.Add(New ChartArea)
            dataPlot.ChartAreas(i).AxisY.MajorGrid.Enabled = True
            dataPlot.ChartAreas(i).AxisX.MajorGrid.Enabled = True

            If x_timestamp.Checked Then
                dataPlot.ChartAreas(i).AxisX.Title = "Time (seconds)"
                dataPlot.ChartAreas(i).AxisX.LabelStyle.Format = "f2"
            Else
                dataPlot.ChartAreas(i).AxisX.Title = "Sample Number"
            End If

            dataPlot.ChartAreas(i).AxisX.ScrollBar.IsPositionedInside = False
            dataPlot.ChartAreas(i).AxisY.ScrollBar.IsPositionedInside = False
            If x_axis_scroll.Checked Then
                dataPlot.ChartAreas(i).AxisX.ScaleView.Zoomable = True
                dataPlot.ChartAreas(i).CursorX.IsUserSelectionEnabled = True
            End If
        Next
        ApplyYAxisTitles()

    End Sub

    Private Sub EnablePlaybackButtons()
        logToCSV.Enabled = True
        playFromCSV.Visible = True
        playFromCSV.Enabled = True
        btn_stopPlayback.Visible = False
        btn_stopPlayback.Enabled = False
        btn_startStop.Enabled = True
        samplesRendered.Enabled = True
        check_fixedTime.Enabled = True
        sampleFreq.Enabled = True
        x_timestamp.Enabled = True
        x_axis_scroll.Enabled = True
    End Sub

    Private Sub DisablePlaybackButtons()
        playFromCSV.Visible = False
        playFromCSV.Enabled = False
        btn_stopPlayback.Visible = True
        btn_stopPlayback.Enabled = True
        btn_startStop.Enabled = False
        logToCSV.Enabled = False
        check_fixedTime.Enabled = False
        samplesRendered.Enabled = False
        sampleFreq.Enabled = False
        x_timestamp.Enabled = False
        x_axis_scroll.Enabled = False
    End Sub

    Private Sub ApplyYAxisTitles()
        Dim titles As String()
        'extraordinarily lazy
        Try
            titles = plotYLabel.Split(",")
            For i As Integer = 0 To dataPlot.ChartAreas.Count - 1
                dataPlot.ChartAreas(i).AxisY.Title = titles(i)
            Next
        Catch ex As Exception
            'squash
        End Try

    End Sub

#End Region

#Region "CSV Plotting"

    Private Function SetupCSVRegs() As Boolean
        Dim headers() As String
        Dim regFound As Boolean
        Dim regCnt As Integer
        selectedRegList.Clear()
        If CSVRegData.Count() > 0 Then
            headers = CSVRegData(0)
            CSVRegData.RemoveAt(0)
        Else
            Return False
        End If
        'Check that time stamp values are included
        If Not headers(0) = "TIMESTAMP_MS" Then
            Return False
        End If
        'Check each box in the reg list
        regCnt = 0
        For j As Integer = 0 To regView.RowCount() - 1
            regFound = headers.Contains(regView.Item("Label", j).Value.ToString())
            regView.Item("Plot", j).Value = regFound.ToString()
            If regFound Then
                regCnt += 1
            End If
        Next
        Return regCnt = headers.Count() - 1
    End Function

    Private Sub PlayCSVWorker()
        Dim waitTime As Long
        Dim timer As New Stopwatch()

        playBackMutex.WaitOne()
        timer.Start()
        While CSVRegData.Count() > 0 And playBackRunning
            waitTime = Convert.ToDouble(CSVRegData(0)(0))
            While (timer.ElapsedMilliseconds() < waitTime) And playBackRunning
                Thread.Sleep(1)
            End While
            If playBackRunning Then Invoke(New MethodInvoker(AddressOf PlotWork))
        End While
        Invoke(New MethodInvoker(AddressOf EnablePlaybackButtons))
        playBackRunning = False
        playBackMutex.ReleaseMutex()
    End Sub

    Private Function LoadFromCSV(fileName As String) As List(Of String())
        Dim reader As New IO.StreamReader(fileName)
        Dim result As New List(Of String())
        Dim line As String
        Dim lineValues() As String

        While Not reader.EndOfStream()
            line = reader.ReadLine()
            lineValues = line.Split(",")
            result.Add(lineValues)
        End While

        Return result
    End Function

#End Region

#Region "Real Time Plotting"

    Private Sub PlotTimerCallback()
        If InvokeRequired Then
            BeginInvoke(New MethodInvoker(AddressOf PlotWork))
        End If
    End Sub

    Private Sub PlotWork()
        Dim regValues() As Double
        Dim plotValues As New List(Of Double)
        Dim logStr As String = ""

        'get the plot mutex (exit if cannot)
        If Not plotMutex.WaitOne(100) Then
            Exit Sub
        End If

        regValues = GetPlotRegValues()

        If logToCSV.Checked Then
            logStr = logTimer.ElapsedMilliseconds().ToString()
        End If

        'Update reg view and scale plot values
        Dim index As Integer = 0
        For Each item In selectedRegList
            regView.Item("Contents", item.Index).Value = regValues(index).ToString()
            regView.Item("Contents", item.Index).Style = New DataGridViewCellStyle With {.BackColor = item.Color}
            plotValues.Add(regValues(index))
            'Log if needed
            If logToCSV.Checked Then
                logStr = logStr + "," + regValues(index).ToString()
            End If
            index += 1
        Next

        If logToCSV.Checked Then
            logData.Add(logStr)
        End If

        'Update the series for the plot area
        For i As Integer = 0 To selectedRegList.Count() - 1
            If Not x_axis_scroll.Checked Then
                If dataPlot.Series(i).Points.Count() = numSamples Then
                    dataPlot.Series(i).Points.RemoveAt(0)
                    dataPlot.ResetAutoValues()
                End If
            End If
            If x_timestamp.Checked Then
                dataPlot.Series(i).Points.AddXY((logTimer.ElapsedMilliseconds / 1000.0), plotValues(i))
            Else
                dataPlot.Series(i).Points.AddXY(plotXPosition, plotValues(i))
            End If
        Next

        'move to next plot position
        plotXPosition = plotXPosition + 1

        'check if run time has elapsed
        If (logTimer.ElapsedMilliseconds / 1000.0) >= runTime Then
            'generate click event on plot stop
            btn_startStop.PerformClick()
        End If

        'release plot mutex
        plotMutex.ReleaseMutex()

    End Sub

    Private Function GetPlotRegValues() As Double()
        'Read the registers
        If playBackRunning Then
            Dim doubleVals As New List(Of Double)
            If CSVRegData.Count() > 0 Then
                For i As Integer = 1 To CSVRegData(0).Count() - 1
                    doubleVals.Add(Convert.ToDouble(CSVRegData(0)(i)))
                Next
                CSVRegData.RemoveAt(0)
            End If
            Return doubleVals.ToArray()
        ElseIf plotting Then
            Dim regs As New List(Of RegClass)
            For Each reg In selectedRegList
                regs.Add(reg.Reg)
            Next
            Return m_TopGUI.Dut.ReadScaledValue(regs)
        Else
            'return 0
            Dim doubles(selectedRegList.Count() - 1) As Double
            Return doubles
        End If

    End Function

    Private Sub ConfigurePlot()
        'Set up frequency
        Dim freq As Double
        Try
            freq = Convert.ToDouble(sampleFreq.Text)
            samplePeriodMs = 1000 / freq
            If samplePeriodMs < 10 Then
                Throw New Exception("Cannot run at more than 100Hz")
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
            samplesRendered.Text = "200"
            ConfigurePlot()
            Exit Sub
        End Try

        'reset plot areas
        ResetPlotAreas()

        'Set plotter position
        plotXPosition = 0

        'plot out of focus
        plotFocus = False

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
            Try
                temp.ChartArea = dataPlot.ChartAreas(reg.PlotIndex).Name
            Catch ex As Exception
                'squash, default is ok
            End Try
            dataPlot.Series.Add(temp)
        Next

        'update scaling based on check state
        axis_autoscale_CheckedChanged(Me, Nothing)

    End Sub

    Private Sub GetPlotDuration()
        If check_fixedTime.Checked Then
            Try
                Dim defaultVal As String = "60"
                If runTime <> Long.MaxValue Then defaultVal = runTime.ToString()
                runTime = Convert.ToInt64(InputBox("Enter Plot Duration (seconds):", "Plot Duration", defaultVal))
            Catch ex As Exception
                MsgBox("ERROR: Invalid plot time!")
                check_fixedTime.Checked = False
                runTime = Long.MaxValue
            End Try
        Else
            runTime = Long.MaxValue
        End If
    End Sub

    Private Sub BuildPlotRegList()
        Dim headers As String
        Dim reg As RegClass
        Dim scale As Double
        Dim offset As Double
        selectedRegList.Clear()
        For index As Integer = 0 To regView.RowCount() - 1
            For plotArea As Integer = 1 To numberPlotAreas
                If regView.Item("Plot" + plotArea.ToString(), index).Value = True Then
                    If m_TopGUI.PlotColorPalette.Count() <= selectedRegList.Count() Then
                        m_TopGUI.PlotColorPalette.Add(Color.FromArgb(CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF))))
                    End If
                    Try
                        reg = m_TopGUI.RegMap(regView.Item("Label", index).Value)
                        scale = Convert.ToDouble(regView.Item("reg_scale", index).Value)
                        If scale = 0 Then Throw New ArgumentException("ERROR: Invalid scale!")
                        'reg scale is 1/scale factor
                        reg.Scale = 1.0 / scale
                        offset = Convert.ToDouble(regView.Item("Offset", index).Value)
                        reg.Offset = offset
                        selectedRegList.Add(New RegPlotterInfo With {.PlotIndex = plotArea - 1, .Reg = reg, .Index = index, .Color = m_TopGUI.PlotColorPalette(selectedRegList.Count())})
                    Catch ex As Exception
                        MsgBox("Error loading register! " + ex.Message)
                        regView.Item("Plot", index).Value = False
                    End Try
                End If
            Next
        Next
        logData = New List(Of String)
        headers = "TIMESTAMP_MS"
        For Each selectedreg In selectedRegList
            headers = headers + "," + selectedreg.Reg.Label
        Next
        logData.Add(headers)
    End Sub

    Private Sub StopPlot()
        'Reset the colors
        For Each item In selectedRegList
            regView.Item("Contents", item.Index).Style = New DataGridViewCellStyle With {.BackColor = Color.White}
        Next
    End Sub

#End Region

End Class