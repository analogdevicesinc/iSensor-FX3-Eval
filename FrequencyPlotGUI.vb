'File:          FrequencyPlotGUI.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          10/30/2019
'Description:   Plots FFT data for a DUT

Imports System.Windows.Forms.DataVisualization.Charting
Imports RegMapClasses
Imports SignalProcessing

Public Class FrequencyPlotGUI
    Inherits FormBase

    Private WithEvents m_FFTStream As FFT_Streamer
    Private selectedRegList As List(Of RegClass)
    Private running As Boolean

    Private Sub FrequencyPlotGUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'instantiate fft streamer
        m_FFTStream = New FFT_Streamer(m_TopGUI.FX3, m_TopGUI.Dut)

        'populate register list dropdown
        For Each reg In m_TopGUI.RegMap
            regSelect.Items.Add(reg.Label)
        Next
        regSelect.SelectedIndex = 0

        RegisterList.View = View.Details
        RegisterList.Columns.Add("Register", RegisterList.Width - 1, HorizontalAlignment.Left)

        selectedRegList = New List(Of RegClass)

        btn_stopPlot.Enabled = False
        running = False

        'set DR triggered register reads
        m_TopGUI.FX3.DrActive = True

    End Sub

    Private Sub Shutdown() Handles Me.Closing
        m_FFTStream.CancelAsync()
        running = False
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
        dataPlot.ChartAreas(0).AxisY.Title = "FFT Magnitude"

        'Remove all existing series
        dataPlot.Series.Clear()

        'Add series for each register
        Dim temp As Series
        For Each reg In selectedRegList
            temp = New Series
            temp.ChartType = SeriesChartType.Line
            temp.BorderWidth = 2
            temp.Name = reg.Label
            dataPlot.Series.Add(temp)
        Next

    End Sub

    Private Sub SetupStream()
        m_FFTStream.Length = Convert.ToInt32(NFFT.Text)
        m_FFTStream.NumAverages = Convert.ToUInt32(FFT_Averages.Text)
        selectedRegList.Clear()
        For Each item As ListViewItem In RegisterList.Items
            selectedRegList.Add(m_TopGUI.RegMap(item.Text))
        Next
        m_FFTStream.RegList = selectedRegList
        Dim freq As Double = m_TopGUI.FX3.ReadDRFreq(m_TopGUI.FX3.DrPin, 1, 10000)
        m_FFTStream.SampleFrequency = freq
        drFreq.Text = freq.ToString()
    End Sub

    Private Sub UpdatePlot()
        For reg As Integer = 0 To selectedRegList.Count() - 1
            dataPlot.Series(reg).Points.Clear()
            For i As Integer = 0 To m_FFTStream.Result(reg).Count() - 1
                If logYaxis.Checked Then
                    dataPlot.Series(reg).Points.AddXY(m_FFTStream.FrequencyRange(i), 20 * Math.Log10(m_FFTStream.Result(reg)(i)))
                Else
                    dataPlot.Series(reg).Points.AddXY(m_FFTStream.FrequencyRange(i), m_FFTStream.Result(reg)(i))
                End If
            Next
        Next
        dataPlot.ChartAreas(0).RecalculateAxesScale()
        Dim freq As Double = m_TopGUI.FX3.MeasurePinFreq(m_TopGUI.FX3.DrPin, 1, 5000, 2)
        m_FFTStream.SampleFrequency = freq
        drFreq.Text = FormatNumber(freq, 1).ToString() + "Hz"
    End Sub

    Private Sub FFTDone() Handles m_FFTStream.FFTDone
        If running Then
            Me.Invoke(New MethodInvoker(AddressOf UpdatePlot))
        End If
    End Sub

    Private Sub ResizeHandler() Handles Me.Resize
        dataPlot.Top = 9
        dataPlot.Left = 237
        dataPlot.Width = Me.Width - 257
        dataPlot.Height = Me.Height - 59
        dataPlot.ResetAutoValues()
    End Sub

    Private Sub btn_addreg_Click(sender As Object, e As EventArgs) Handles btn_addreg.Click
        Dim newItem As New ListViewItem()
        newItem.SubItems(0).Text = regSelect.SelectedItem
        RegisterList.Items.Add(newItem)
    End Sub

    Private Sub btn_removeReg_Click(sender As Object, e As EventArgs) Handles btn_removeReg.Click
        If IsNothing(Me.RegisterList.FocusedItem) Then
            MessageBox.Show("Please select an Item to Delete", "Remove register warning", MessageBoxButtons.OK)
        Else
            Me.RegisterList.Items.RemoveAt(Me.RegisterList.FocusedItem.Index)
        End If
    End Sub

    Private Sub btn_run_Click(sender As Object, e As EventArgs) Handles btn_run.Click
        SetupStream()
        SetupPlot()
        m_FFTStream.RunAync()
        btn_stopPlot.Enabled = True
        btn_run.Enabled = False
        running = True
    End Sub

    Private Sub btn_stopPlot_Click(sender As Object, e As EventArgs) Handles btn_stopPlot.Click
        m_FFTStream.CancelAsync()
        btn_run.Enabled = True
        btn_stopPlot.Enabled = False
        running = False
    End Sub

    Private Sub logYaxis_CheckedChanged(sender As Object, e As EventArgs)
        If logYaxis.Checked Then
            dataPlot.ChartAreas(0).AxisY.Title = "FFT Magnitude (dB)"
        Else
            dataPlot.ChartAreas(0).AxisY.Title = "FFT Magnitude"
        End If
    End Sub

End Class