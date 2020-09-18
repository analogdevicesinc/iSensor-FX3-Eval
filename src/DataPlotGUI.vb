'File:          DataPlotGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          9/23/2019
'Description:   Allows for data plotting and logging, along with playback of logged data.

Imports RegMapClasses
Imports System.Timers
Imports System.Windows.Forms.DataVisualization.Charting
Imports System.Threading

Public Class DataPlotGUI
    Inherits FormBase

    Private samplePeriodMs As Integer
    Private plotting As Boolean
    Private selectedRegList As List(Of RegOffsetPair)
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

    Public Sub FormSetup() Handles Me.Load
        PopulateRegView()

        'Set defaults
        plotting = False
        samplePeriodMs = 100
        selectedRegList = New List(Of RegOffsetPair)
        sampleFreq.Text = "20"
        dataPlot.Series.Clear()
        runTime = Long.MaxValue

        'Set up timer
        plotTimer = New System.Timers.Timer(500)
        plotTimer.Enabled = False
        AddHandler plotTimer.Elapsed, New ElapsedEventHandler(AddressOf PlotTimerCallback)

        'set up display
        samplesRendered.Text = "200"
        minScale.Text = "-1000"
        maxscale.Text = "1000"
        btn_stopPlayback.Enabled = False
        btn_stopPlayback.Visible = False
        axis_autoscale.Checked = True
        plotYLabel = "Scaled Value"

        'create synchronization structures
        logTimer = New Stopwatch()
        playBackMutex = New Mutex()
        plotMutex = New Mutex()

        regView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells

        RegisterToolTips()
    End Sub

    Private Sub RegisterToolTips()
        Dim tip0 As ToolTip = New ToolTip()
        tip0.SetToolTip(Me.label_sampleFreq, "The data sampling frequency for plotting. This is driven by a Windows software timer, and is not very accurate")
        tip0.SetToolTip(Me.label_samplesRendered, "The maximum number of samples to render in a single plot")
        tip0.SetToolTip(Me.btn_startStop, "Start or Stop data plotting")
        tip0.SetToolTip(Me.btn_autonull, "Set the offset values for each register being plotted to the last read value")
        tip0.SetToolTip(Me.btn_saveChart, "Save image of the current plot area")
        tip0.SetToolTip(Me.playFromCSV, "Play back data plot from a CSV plot log")
        tip0.SetToolTip(Me.logToCSV, "Save plot data to a CSV log")
        tip0.SetToolTip(Me.regView, "Select registers to plot, and supply register offset values. The data plotted for each register is scaled by the scale factor defined in the register map CSV file")
        tip0.SetToolTip(Me.check_fixedTime, "Stop plotting automatically after a fixed time interval. This is useful when the data plotting application is being used for logging")
        tip0.SetToolTip(Me.x_timestamp, "Plot sample timestamps on X-axis (default is sample counter)")
        tip0.SetToolTip(Me.btn_SetLabel, "Set the Y-Axis label")
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        regView.Height = Me.Height - 172
        dataPlot.Top = 6
        dataPlot.Left = 532
        dataPlot.Width = Me.Width - 555
        dataPlot.Height = Me.Height - 53
        dataPlot.ResetAutoValues()
    End Sub

    Private Sub ShutDown() Handles Me.Closing
        plotTimer.Enabled = False
        playBackRunning = False
        playBackMutex.WaitOne()
        plotMutex.WaitOne()
        m_TopGUI.FX3.UserLEDOn()
        'save regs which were plotted
        m_TopGUI.dataPlotRegs.Clear()
        For Each item In selectedRegList
            m_TopGUI.dataPlotRegs.Add(item.Reg.Label)
        Next
        m_TopGUI.btn_plotData.Enabled = True
    End Sub

    Private Sub PlotTimerCallback()
        If Me.InvokeRequired Then
            Me.BeginInvoke(New MethodInvoker(AddressOf PlotWork))
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
            plotValues.Add(regValues(index) - item.Offset)
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
            'remove leading point if it exists
            If dataPlot.Series(i).Points.Count() = numSamples Then
                dataPlot.Series(i).Points.RemoveAt(0)
                dataPlot.ResetAutoValues()
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

    Private Sub PopulateRegView()
        Dim regIndex As Integer = 0
        Dim regStr() As String
        Dim readStr As String = "Not Read"
        For Each reg In m_TopGUI.RegMap
            If reg.IsReadable Then
                If regIndex >= regView.RowCount Then
                    regStr = {reg.Label, reg.Page.ToString(), reg.Address.ToString(), readStr, "False", "0", reg.Scale.ToString()}
                    regView.Rows.Add(regStr)
                Else
                    regView.Item("Label", regIndex).Value = reg.Label
                    regView.Item("Page", regIndex).Value = reg.Page
                    regView.Item("Address", regIndex).Value = reg.Address
                    regView.Item("Contents", regIndex).Value = readStr
                    regView.Item("Plot", regIndex).Value = False
                    regView.Item("Offset", regIndex).Value = "0"
                    regView.Item("Scale", regIndex).Value = reg.Scale.ToString()
                End If
                'check if previously selected
                If m_TopGUI.dataPlotRegs.Contains(reg.Label) Then regView.Item("Plot", regIndex).Value = True
                regIndex += 1
            End If
        Next
    End Sub

    Private Sub btn_startStop_Click(sender As Object, e As EventArgs) Handles btn_startStop.Click
        If plotting Then
            'Stop
            logToCSV.Enabled = True
            plotting = False
            plotTimer.Enabled = False
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
            btn_startStop.Text = "Stop Plotting"
            Try
                m_TopGUI.FX3.UserLEDBlink(250 / samplePeriodMs)
            Catch ex As Exception
                'don't do anything, just don't want the program to crash if user is driving a PWM using that timer block on the FX3
            End Try
            logTimer.Restart()
        End If
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
            If regView.Item("Plot", index).Value = True Then
                If m_TopGUI.PlotColorPalette.Count() <= selectedRegList.Count() Then
                    m_TopGUI.PlotColorPalette.Add(Color.FromArgb(CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF)), CByte(Math.Floor(Rnd() * &HFF))))
                End If
                Try
                    reg = m_TopGUI.RegMap(regView.Item("Label", index).Value)
                    scale = Convert.ToDouble(regView.Item("Scale", index).Value)
                    reg.Scale = scale
                    offset = Convert.ToDouble(regView.Item("Offset", index).Value)
                    selectedRegList.Add(New RegOffsetPair With {.Reg = reg, .Offset = offset, .Index = index, .Color = m_TopGUI.PlotColorPalette(selectedRegList.Count())})
                Catch ex As Exception
                    MsgBox("Error loading register! " + ex.Message)
                    regView.Item("Plot", index).Value = False
                End Try
            End If
        Next
        logData = New List(Of String)
        headers = "TIMESTAMP_MS"
        For Each selectedreg In selectedRegList
            headers = headers + "," + selectedreg.Reg.Label
        Next
        logData.Add(headers)
    End Sub

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

        'Reset the chart area
        dataPlot.ChartAreas.Clear()
        dataPlot.ChartAreas.Add(New ChartArea)

        'configure chart
        dataPlot.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        dataPlot.ChartAreas(0).AxisX.MajorGrid.Enabled = True

        dataPlot.ChartAreas(0).AxisY.Title = plotYLabel

        If x_timestamp.Checked Then
            dataPlot.ChartAreas(0).AxisX.Title = "Time (seconds)"
            dataPlot.ChartAreas(0).AxisX.LabelStyle.Format = "f2"
        Else
            dataPlot.ChartAreas(0).AxisX.Title = "Sample Number"
        End If

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
        regValues = GetPlotRegValues()

        For i As Integer = 0 To selectedRegList.Count() - 1
            selectedRegList(i).Offset = regValues(i)
            regView.Item("Offset", selectedRegList(i).Index).Value = regValues(i).ToString()
        Next

    End Sub

    Private Sub saveChart_Click(sender As Object, e As EventArgs) Handles btn_saveChart.Click
        Dim filebrowser As New SaveFileDialog
        Try
            filebrowser.FileName = m_TopGUI.lastFilePath.Substring(0, m_TopGUI.lastFilePath.LastIndexOf("\") + 1) + "PLOT.png"
            filebrowser.Filter = "Image Files (*.png) | *.png"
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
            regFound = headers.Contains(regView.Item("Label", j).Value)
            regView.Item("Plot", j).Value = regFound
            If regFound Then
                regCnt += 1
            End If
        Next
        Return regCnt = headers.Count() - 1
    End Function

    Private Sub PlayCSVWorker()
        playBackMutex.WaitOne()
        Dim waitTime As Long
        logTimer.Restart()

        While CSVRegData.Count() > 0 And playBackRunning
            waitTime = Convert.ToDouble(CSVRegData(0)(0))
            While logTimer.ElapsedMilliseconds() < waitTime And playBackRunning
                System.Threading.Thread.Sleep(1)
            End While
            If Not playBackRunning Then
                Exit While
            End If
            Me.Invoke(New MethodInvoker(AddressOf PlotWork))
        End While
        Me.Invoke(New MethodInvoker(AddressOf EnablePlaybackButtons))
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

    Private Sub stopPlayback_Click(sender As Object, e As EventArgs) Handles btn_stopPlayback.Click
        playBackRunning = False
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
    End Sub

    Private Sub axis_autoscale_CheckedChanged(sender As Object, e As EventArgs) Handles axis_autoscale.CheckedChanged
        If axis_autoscale.Checked Then
            minScale.Enabled = False
            maxscale.Enabled = False
            dataPlot.ChartAreas(0).AxisY.Minimum = Double.NaN
            dataPlot.ChartAreas(0).AxisY.Maximum = Double.NaN
        Else
            minScale.Enabled = True
            maxscale.Enabled = True
            ScaleValuesChanges()
        End If
    End Sub

    Private Sub HiddenHandler() Handles Me.VisibleChanged
        If Not Me.Visible Then
            'disable plotting
            If plotting Then btn_startStop_Click(Me, Nothing)
        End If
    End Sub

    Private Sub btn_SetLabel_Click(sender As Object, e As EventArgs) Handles btn_SetLabel.Click
        Dim val As String = InputBox("Enter Y-Axis Label: ", "Input", plotYLabel)
        'check for cancel
        If val = "" Then Exit Sub
        plotYLabel = val
        dataPlot.ChartAreas(0).AxisY.Title = plotYLabel
    End Sub

    Private Sub ScaleValuesChanges() Handles minScale.LostFocus, maxscale.LostFocus

        'Set scale (if needed)
        Dim yMin, yMax As Double
        Dim goodscale As Boolean = False
        If Not axis_autoscale.Checked Then
            goodscale = True
            'min
            Try
                yMin = Convert.ToDouble(minScale.Text())
                minScale.BackColor = Color.White
            Catch ex As Exception
                goodscale = False
                minScale.BackColor = m_TopGUI.ERROR_COLOR
            End Try

            'max
            Try
                yMax = Convert.ToDouble(maxscale.Text())
                maxscale.BackColor = Color.White
            Catch ex As Exception
                goodscale = False
                maxscale.BackColor = m_TopGUI.ERROR_COLOR
            End Try

            'check values
            If yMin > yMax Then
                yMax = yMin + 1
                maxscale.Text = yMax.ToString()
            End If

        End If

        If goodscale Then
            'Value must be good
            dataPlot.ChartAreas(0).AxisY.Maximum = yMax
            dataPlot.ChartAreas(0).AxisY.Minimum = yMin
        End If

    End Sub

    Private Sub WriteEnterHandler(sender As Object, e As KeyEventArgs) Handles minScale.KeyUp, maxscale.KeyUp

        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
            If minScale.Focused Or maxscale.Focused Then
                ScaleValuesChanges()
            End If
        End If

    End Sub

    Private Sub AnnoyingNoiseHandler(sender As Object, e As KeyEventArgs) Handles minScale.KeyDown, maxscale.KeyDown
        If e.KeyCode = Keys.Return Then
            e.Handled = True
            e.SuppressKeyPress = True
        End If
    End Sub

End Class