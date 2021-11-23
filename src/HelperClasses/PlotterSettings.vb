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

    Public UpdateRate As String = "20"

    Public SamplesRendered As String = "200"

    Public MinScale As String = "-1000"

    Public MaxScale As String = "1000"

    Public Autoscale As Boolean = True

    Public LogData As Boolean = False

    Public ScrollBar As Boolean = False

    Public Timestamp As Boolean = False

End Class
