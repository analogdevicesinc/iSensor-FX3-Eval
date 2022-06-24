'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          FrequencyPlotGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Plots FFT data from an IMU in real time

Imports System.Windows.Forms.DataVisualization.Charting
Imports RegMapClasses
Imports SignalProcessing

Public Class FrequencyPlotGUI
    Inherits FormBase

    'FFT streamer
    Private WithEvents m_FFTStream As FFT_Streamer

    'selected register list
    Private selectedRegList As List(Of RegClass)

    'y-axis label
    Private plotYLabel As String

    Public Sub New()
        ' This call is required by the designer.
        InitializeComponent()
    End Sub

    Private Sub FrequencyPlotGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        If m_TopGUI.FFTPlotHeight <> 0 Then Height = m_TopGUI.FFTPlotHeight
        If m_TopGUI.FFTPlotWidth <> 0 Then Width = m_TopGUI.FFTPlotWidth

        'instantiate fft streamer
        m_FFTStream = New FFT_Streamer(m_TopGUI.FX3, m_TopGUI.Dut)

        'populate register list dropdown
        For Each reg In m_TopGUI.RegMap
            regSelect.Items.Add(reg.Label)
        Next
        regSelect.SelectedIndex = 0

        'check for previously plotted regs
        For Each item In m_TopGUI.dataPlotRegs
            If regSelect.Items.Contains(item.Reg.Label) Then RegisterList.Items.Add(item.Reg.Label)
        Next

        'populate NFFT setting dropdown
        For n As Integer = 3 To 14
            NFFT.Items.Add((2 ^ n).ToString)
        Next

        'set up list view
        RegisterList.View = View.Details
        RegisterList.Columns.Add("Register", RegisterList.Width - 1, HorizontalAlignment.Left)
        dataPlot.Series.Clear()

        'initialize variables
        selectedRegList = New List(Of RegClass)
        btn_stopPlot.Enabled = False
        plotYLabel = "FFT Magnitude"

        'Load settings
        NFFT.Text = m_TopGUI.plotSettings.SamplesPerFFT
        FFT_Averages.Text = m_TopGUI.plotSettings.FFTAverages
        input_3db_min.Text = m_TopGUI.plotSettings.MinPassband
        input_3db_max.Text = m_TopGUI.plotSettings.MaxPassband
        check_DCNull.Checked = m_TopGUI.plotSettings.NullDC
        check_logXaxis.Checked = m_TopGUI.plotSettings.LogX
        check_logYaxis.Checked = m_TopGUI.plotSettings.LogY
        check_sciLabel.Checked = m_TopGUI.plotSettings.ScientificLabels

    End Sub

    Private Sub Shutdown() Handles Me.Closing
        m_FFTStream.CancelAsync()
        Dim timer As New Stopwatch()
        timer.Start()
        While timer.ElapsedMilliseconds < 500 And m_FFTStream.IsBusy
            System.Threading.Thread.Sleep(10)
        End While
        m_FFTStream.Dispose()
        m_TopGUI.FFTPlotWidth = Width
        m_TopGUI.FFTPlotHeight = Height

        'save settings
        m_TopGUI.plotSettings.SamplesPerFFT = NFFT.Text
        m_TopGUI.plotSettings.FFTAverages = FFT_Averages.Text
        m_TopGUI.plotSettings.MinPassband = input_3db_min.Text
        m_TopGUI.plotSettings.MaxPassband = input_3db_max.Text
        m_TopGUI.plotSettings.NullDC = check_DCNull.Checked
        m_TopGUI.plotSettings.LogX = check_logXaxis.Checked
        m_TopGUI.plotSettings.LogY = check_logYaxis.Checked
        m_TopGUI.plotSettings.ScientificLabels = check_sciLabel.Checked

        'save register list
        m_TopGUI.dataPlotRegs.Clear()
        For Each reg In selectedRegList
            m_TopGUI.dataPlotRegs.Add(New RegPlotterInfo With {.Reg = reg})
        Next
        m_TopGUI.SaveDataPlotRegList()
        'show other forms
        InteractWithOtherForms(False, Me)
        're-enable main form button
        m_TopGUI.btn_plotFFT.Enabled = True
    End Sub

    Private Sub SetupPlot()
        'Reset the chart area
        dataPlot.ChartAreas.Clear()
        dataPlot.ChartAreas.Add(New ChartArea)

        'configure chart
        dataPlot.ChartAreas(0).AxisY.MajorGrid.Enabled = True
        dataPlot.ChartAreas(0).AxisX.MajorGrid.Enabled = True
        dataPlot.ChartAreas(0).AxisX.Title = "Frequency (Hz)"
        dataPlot.ChartAreas(0).AxisX.LabelStyle.Format = "#.##"
        dataPlot.ChartAreas(0).AxisY.Title = plotYLabel
        dataPlot.ChartAreas(0).AxisX.LogarithmBase = 10
        dataPlot.ChartAreas(0).AxisY.LogarithmBase = 10

        'Remove all existing series
        dataPlot.Series.Clear()

        'Add series for each register
        Dim temp As Series
        Dim count As Integer = 0
        For Each reg In selectedRegList
            temp = New Series
            temp.ChartType = SeriesChartType.Line
            temp.BorderWidth = 2
            temp.Name = reg.Label
            If count < m_TopGUI.PlotColorPalette.Count Then
                temp.Color = m_TopGUI.PlotColorPalette(count)
                count += 1
            End If
            dataPlot.Series.Add(temp)
        Next

    End Sub

    Private Function SetupStream() As Boolean
        'set length
        Dim length As UInteger
        Try
            length = Convert.ToUInt32(NFFT.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid FFT length. Must be a 2^n value, for n = 1 to 14. Defaulting to 4096.")
            length = 4096
            NFFT.Text = "4096"
        End Try
        m_FFTStream.Length = length

        'set FFT averages
        Try
            m_FFTStream.NumAverages = Convert.ToUInt32(FFT_Averages.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid number of FFT averages. Must be a positive integer. Defaulting to 1.")
            m_FFTStream.NumAverages = 1
            FFT_Averages.Text = "1"
        End Try

        selectedRegList.Clear()
        For Each item As ListViewItem In RegisterList.Items
            selectedRegList.Add(m_TopGUI.RegMap(item.Text))
        Next
        m_FFTStream.RegList = selectedRegList

        'add DC null setting
        m_FFTStream.DCNull = check_DCNull.Checked

        'try and cancel any running stream
        m_TopGUI.FX3.StopStream()
        System.Threading.Thread.Sleep(20)

        'set dr active
        m_TopGUI.FX3.DrActive = True

        Return UpdateSampleFreq()
    End Function

    Private Function UpdateSampleFreq() As Boolean
        Dim freq As Double = m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, 1000, 2)
        m_FFTStream.SampleFrequency = freq
        drFreq.Text = FormatNumber(freq, 1).ToString() + "Hz"
        If freq = Double.PositiveInfinity Then
            MsgBox("ERROR: Data ready not toggling. Stopping plot operation...")
            m_TopGUI.FX3.DrActive = False
            btn_stopPlot.PerformClick()
            Return False
        End If
        Return True
    End Function

    Private Sub UpdatePlot()
        'handle invokes after the form is closed
        If IsDisposed Or Disposing Then
            Exit Sub
        End If
        'add each new series
        Dim startIndex As Integer = 0
        'start at bin 1 rather than DC if DC is nulled ("zero" on log scale looks silly)
        If m_FFTStream.DCNull Then startIndex = 1
        For reg As Integer = 0 To selectedRegList.Count() - 1
            dataPlot.Series(reg).Points.Clear()
            For i As Integer = startIndex To m_FFTStream.Result(reg).Count() - 1
                dataPlot.Series(reg).Points.AddXY(m_FFTStream.FrequencyRange(i), Math.Max(m_FFTStream.Result(reg)(i), 0.0000000001))
            Next
        Next
        'check if log axis needed
        dataPlot.ChartAreas(0).AxisX.IsLogarithmic = check_logXaxis.Checked
        dataPlot.ChartAreas(0).AxisY.IsLogarithmic = check_logYaxis.Checked
        'recalculate scale based on newest values
        dataPlot.ChartAreas(0).RecalculateAxesScale()
        'Add title
        dataPlot.Titles.Clear()
        dataPlot.Titles.Add("FFT Plot (Fs = " + drFreq.Text + ", NFFT = " + NFFT.Text + ", " + FFT_Averages.Text + " Averages)")
        dataPlot.Titles(0).Font = New Font(NFFT.Font.Name, 16.0F)
        'measure new sample freq for next render
        UpdateSampleFreq()
    End Sub

    Private Sub FFTDone() Handles m_FFTStream.FFTDone
        'Whenever there is new FFT data update the plot
        If InvokeRequired Then
            Invoke(New MethodInvoker(AddressOf UpdatePlot))
        Else
            UpdatePlot()
        End If
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        dataPlot.Top = 9
        dataPlot.Left = 237
        dataPlot.Width = Width - 259
        dataPlot.Height = Height - 57
        dataPlot.ResetAutoValues()
    End Sub

    Private Sub btn_addreg_Click(sender As Object, e As EventArgs) Handles btn_addreg.Click
        Dim newItem As New ListViewItem()
        Dim reg As RegClass = m_TopGUI.RegMap(regSelect.SelectedItem)
        For Each entry As ListViewItem In RegisterList.Items
            If entry.Text = reg.Label Then
                MsgBox("ERROR: Can only plot each register one time")
                Exit Sub
            End If
        Next
        newItem.SubItems(0).Text = reg.Label
        RegisterList.Items.Add(newItem)
    End Sub

    Private Sub btn_removeReg_Click(sender As Object, e As EventArgs) Handles btn_removeReg.Click
        If IsNothing(RegisterList.FocusedItem) Then
            MessageBox.Show("Please select an Item to Delete", "Remove register warning", MessageBoxButtons.OK)
        Else
            RegisterList.Items.RemoveAt(RegisterList.FocusedItem.Index)
        End If
    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        'check there is a register selected
        If RegisterList.Items.Count = 0 Then
            MsgBox("ERROR: No registers selected")
            Exit Sub
        End If

        'set up stream (FFT_Streamer and register list)
        If Not SetupStream() Then
            Exit Sub
        End If

        'set up plotting
        SetupPlot()

        'start async stream operation
        m_FFTStream.RunAync()

        'disable inputs
        NFFT.Enabled = False
        FFT_Averages.Enabled = False
        regSelect.Enabled = False
        btn_addreg.Enabled = False
        btn_removeReg.Enabled = False
        btn_Clear.Enabled = False
        btn_stopPlot.Enabled = True
        btn_run.Enabled = False

        'hide other forms
        InteractWithOtherForms(True, Me)

    End Sub

    Private Sub btn_stopPlot_Click(sender As Object, e As EventArgs) Handles btn_stopPlot.Click
        'cancel running stream
        m_FFTStream.CancelAsync()
        System.Threading.Thread.Sleep(250)

        'enable inputs
        NFFT.Enabled = True
        FFT_Averages.Enabled = True
        btn_Clear.Enabled = True
        regSelect.Enabled = True
        btn_addreg.Enabled = True
        btn_removeReg.Enabled = True
        btn_run.Enabled = True
        btn_stopPlot.Enabled = False

        'disable DRactive
        m_TopGUI.FX3.DrActive = False

        'show other forms
        InteractWithOtherForms(False, Me)

    End Sub

    Private Sub dataPlot_Click(sender As Object, e As MouseEventArgs) Handles dataPlot.Click

        Dim freq, mag As Double
        Dim formatString As String
        Dim render As Boolean = True
        Try
            freq = dataPlot.ChartAreas(0).AxisX.PixelPositionToValue(e.X)
            mag = dataPlot.ChartAreas(0).AxisY.PixelPositionToValue(e.Y)
        Catch ex As Exception
            render = False
        End Try

        'convert log scale data
        If dataPlot.ChartAreas(0).AxisX.IsLogarithmic Then
            freq = 10 ^ freq
        End If

        If dataPlot.ChartAreas(0).AxisY.IsLogarithmic Then
            mag = 10 ^ mag
        End If

        If render Then
            'place point and label on screen
            Dim loc As Point = New Point
            loc.X = e.X
            loc.Y = e.Y
            Dim pointLabel As New Label()
            Controls.Add(pointLabel)
            'scientific format
            formatString = "#0.0#e0"
            If Not check_sciLabel.Checked Then
                'set format string based on magnitude
                If mag > 1000 Then
                    formatString = "f0"
                ElseIf mag > 10 Then
                    formatString = "f1"
                ElseIf mag > 1 Then
                    formatString = "f2"
                ElseIf mag > 0.1 Then
                    formatString = "f3"
                ElseIf mag > 0.01 Then
                    formatString = "f4"
                ElseIf mag > 0.001 Then
                    formatString = "f5"
                Else
                    formatString = "f6"
                End If
            End If
            pointLabel.Text = freq.ToString("0.#") + "Hz " + mag.ToString(formatString) + " mag" + Environment.NewLine + "●"
            pointLabel.Font = New Font(pointLabel.Font, FontStyle.Bold)
            pointLabel.AutoSize = True
            loc.X = loc.X - (pointLabel.Width / 2)
            loc.Y = loc.Y - (0.85 * pointLabel.Height)
            pointLabel.Location = loc
            pointLabel.Parent = dataPlot
            pointLabel.BackColor = Color.Transparent
            pointLabel.TextAlign = ContentAlignment.BottomCenter
            pointLabel.BringToFront()
        End If

    End Sub

    Private Sub btn_Clear_Click(sender As Object, e As EventArgs) Handles btn_Clear.Click
        RegisterList.Items.Clear()
    End Sub

    Private Sub btn_ClearLabels_Click(sender As Object, e As EventArgs) Handles btn_ClearLabels.Click
        ResetLabels()
    End Sub

    Private Sub ResetLabels()
        Dim labelList As IEnumerable(Of Label) = dataPlot.Controls.OfType(Of Label)
        For i As Integer = 0 To labelList.Count() - 1
            dataPlot.Controls.Remove(labelList(0))
        Next
    End Sub

    Private Sub btn_Export_Click(sender As Object, e As EventArgs) Handles btn_Export.Click
        Dim data As New List(Of String)
        Dim regNames As String
        Dim title As String
        Dim sample As String

        'build title
        title = "FFT_" + NFFT.Text + "Point_" + FFT_Averages.Text + "Averages"

        'build header string
        regNames = "FREQUENCY,"
        For Each reg In selectedRegList
            regNames = regNames + reg.Label + ","
        Next
        regNames = regNames.Remove(regNames.Count() - 1)
        data.Add(regNames)

        'add data
        Try
            For i As Integer = 0 To m_FFTStream.Result(0).Count() - 1
                'get bin frequency
                sample = m_FFTStream.FrequencyRange(i).ToString() + ","
                'add data for each register
                For reg As Integer = 0 To selectedRegList.Count() - 1
                    sample = sample + m_FFTStream.Result(reg)(i).ToString() + ","
                Next
                'remove last comma
                sample = sample.Remove(sample.Count() - 1)
                data.Add(sample)
            Next
        Catch ex As Exception
            'exit
        End Try

        saveCSV(title, data.ToArray())

    End Sub

    Private Sub btn_saveplot_Click(sender As Object, e As EventArgs) Handles btn_saveplot.Click
        Dim filebrowser As New SaveFileDialog
        Dim fileName As String = "FFT_plot_" + m_TopGUI.SelectedPersonality + "_" + GetTime() + ".png"
        Try
            filebrowser.FileName = fileName
            filebrowser.Filter = "Image Files (*.png) | *.png"
            filebrowser.InitialDirectory = m_TopGUI.lastFilePath.Substring(0, m_TopGUI.lastFilePath.LastIndexOf("\") + 1)
        Catch ex As Exception
            'squash
        End Try

        If filebrowser.ShowDialog() = DialogResult.OK Then
            m_TopGUI.lastFilePath = filebrowser.FileName
            Dim bmpForm As Bitmap = New Bitmap(dataPlot.Width, dataPlot.Height)
            dataPlot.DrawToBitmap(bmpForm, New Rectangle(0, 0, bmpForm.Width, bmpForm.Height))
            'save as png
            bmpForm.Save(filebrowser.FileName, Imaging.ImageFormat.Png)
            bmpForm.Dispose()
        Else
            Exit Sub
        End If
    End Sub

    Private Sub btn_apply3db_Click(sender As Object, e As EventArgs) Handles btn_apply3db.Click

        If dataPlot.Series.Count = 0 Then
            MsgBox("ERROR: No data plotted")
            Return
        End If

        If btn_apply3db.Text = "Remove -3dB Lines" Then
            btn_apply3db.Text = "Apply -3dB Lines"
            Remove3dBLines()
        Else
            btn_apply3db.Text = "Remove -3dB Lines"
            Apply3dBLines()
        End If

    End Sub

    Private Sub Apply3dBLines()
        Dim seriesIndex As Integer
        Dim i As Integer
        Dim val As Double
        Dim temp As Series

        seriesIndex = selectedRegList.Count
        i = 0
        For Each reg In selectedRegList
            'get -3dB values
            val = Calculate3dBValue(i)
            'if error then exit
            If val = Double.PositiveInfinity Then Exit Sub
            'apply new line
            If seriesIndex >= dataPlot.Series.Count Then
                temp = New Series
                temp.ChartType = SeriesChartType.Line
                temp.BorderWidth = 2
                temp.Name = reg.Label + " -3dB point"
                dataPlot.Series.Add(temp)
            End If
            'place values into the series
            dataPlot.Series(seriesIndex).Points.Clear()
            For j As Integer = 0 To m_FFTStream.Result(i).Count() - 1
                dataPlot.Series(seriesIndex).Points.AddXY(m_FFTStream.FrequencyRange(j), val)
            Next
            i += 1
            seriesIndex += 1
        Next
    End Sub

    Private Sub Remove3dBLines()
        Dim lineCount As Integer

        'how many lines to remove
        lineCount = (dataPlot.Series.Count - selectedRegList.Count)

        'should not be zero to get here
        For i As Integer = 0 To lineCount - 1
            dataPlot.Series.RemoveAt(selectedRegList.Count)
        Next
    End Sub

    Private Function Calculate3dBValue(index As Integer) As Double
        Dim passBandVal As Double
        Dim minIndex, maxIndex As Integer
        Dim minFreq, maxFreq As Double

        input_3db_max.BackColor = Color.White
        input_3db_min.BackColor = Color.White

        Try
            minFreq = Convert.ToDouble(input_3db_min.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid min freq entered. " + ex.Message)
            input_3db_min.BackColor = m_TopGUI.ERROR_COLOR
            Return Double.PositiveInfinity
        End Try

        Try
            maxFreq = Convert.ToDouble(input_3db_max.Text)
        Catch ex As Exception
            MsgBox("ERROR: Invalid max freq entered. " + ex.Message)
            input_3db_max.BackColor = m_TopGUI.ERROR_COLOR
            Return Double.PositiveInfinity
        End Try

        If minFreq > maxFreq Then
            MsgBox("ERROR: Min freq must be less than max freq")
            input_3db_max.BackColor = m_TopGUI.ERROR_COLOR
            input_3db_min.BackColor = m_TopGUI.ERROR_COLOR
            Return Double.PositiveInfinity
        End If

        'get the index corresponding to those frequencies
        Dim i As Integer = 0
        Dim freq As Double = 0
        Try
            While freq < minFreq
                freq = m_FFTStream.FrequencyRange(i)
                i += 1
            End While
            minIndex = i - 1
            While freq < maxFreq
                freq = m_FFTStream.FrequencyRange(i)
                i += 1
            End While
            maxIndex = i
        Catch ex As Exception
            'catch invalid freq here
            MsgBox("ERROR: Invalid pass band entered. " + ex.Message)
            Return Double.PositiveInfinity
        End Try

        'check distance
        If (maxIndex - minIndex) < 0 Then
            MsgBox("ERROR: Must average over 1 or more samples")
            Return Double.PositiveInfinity
        End If

        'accumulate pass band value
        passBandVal = 0
        For fft_index As Integer = minIndex To maxIndex
            passBandVal += m_FFTStream.Result(index)(fft_index)
        Next

        'average
        passBandVal = passBandVal / (maxIndex - minIndex + 1)

        'multiply by -3dB point ratio
        passBandVal = passBandVal * 0.708

        Return passBandVal

    End Function

    Private Sub logYaxis_CheckedChanged(sender As Object, e As EventArgs) Handles check_logYaxis.CheckedChanged
        UpdateLogScale()
    End Sub

    Private Sub logXaxis_CheckedChanged(sender As Object, e As EventArgs) Handles check_logXaxis.CheckedChanged
        UpdateLogScale()
    End Sub

    Private Sub UpdateLogScale()
        If IsNothing(m_FFTStream) Then Exit Sub
        If IsNothing(m_FFTStream.FrequencyRange) Then Exit Sub
        If m_FFTStream.FrequencyRange.Count = 0 Then Exit Sub

        'check if log axis needed
        dataPlot.ChartAreas(0).AxisX.IsLogarithmic = check_logXaxis.Checked
        dataPlot.ChartAreas(0).AxisY.IsLogarithmic = check_logYaxis.Checked
        'recalculate scale based on newest values
        dataPlot.ChartAreas(0).RecalculateAxesScale()
    End Sub

    Private Sub btn_SetLabel_Click(sender As Object, e As EventArgs) Handles btn_SetLabel.Click
        Dim val As String = InputBox("Enter Y-Axis Label: ", "Input", plotYLabel)
        'check for cancel
        If val = "" Then Exit Sub
        plotYLabel = val
        dataPlot.ChartAreas(0).AxisY.Title = plotYLabel
    End Sub

End Class