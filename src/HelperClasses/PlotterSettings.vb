'Copyright (c) 2021 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          PlotterSettings.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Store user configurable settings for the plotter form(s)

<Serializable()>
Public Class PlotterSettings

    Public Sub New()

    End Sub

    'Time domain plotter settings

    Public UpdateRate As String = "20"

    Public SamplesRendered As String = "200"

    Public Autoscale As Boolean = True

    Public LogData As Boolean = False

    Public ScrollBar As Boolean = False

    Public Timestamp As Boolean = False

    Public NumberPlots As Integer = 1

    'FFT plotter settings

    Public SamplesPerFFT As String = "4096"

    Public FFTAverages As String = "1"

    Public MinPassband As String = "10"

    Public MaxPassband As String = "100"

    Public NullDC As Boolean = False

    Public LogX As Boolean = True

    Public LogY As Boolean = True

    Public ScientificLabels As Boolean = False

End Class
