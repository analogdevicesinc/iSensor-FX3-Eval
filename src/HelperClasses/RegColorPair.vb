'Copyright (c) 2021 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          RegColorPair.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Store user configurable settings for the plotter form(s)

Imports RegMapClasses

''' <summary>
''' Class to store register info + plot color
''' </summary>
Class RegColorPair
    Public Reg As RegClass
    Public Index As Integer
    Public Color As Color
End Class
