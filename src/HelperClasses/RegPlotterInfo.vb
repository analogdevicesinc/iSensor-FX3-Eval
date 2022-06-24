'Copyright (c) 2021 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          RegPlotterInfo.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Store user configurable settings for the plotter form(s)

Imports RegMapClasses

''' <summary>
''' Class to store register info + plot color
''' </summary>
Class RegPlotterInfo : Implements IEquatable(Of Object)
    Public Reg As RegClass
    Public Index As Integer
    Public Color As Color
    Public PlotIndex As Integer

    Private Function IEquatable_Equals(other As Object) As Boolean Implements IEquatable(Of Object).Equals
        Dim label As String
        Try
            label = CType(other, String)
        Catch ex As Exception
            Return False
        End Try
        Return label.Equals(Reg.Label)
    End Function

End Class
