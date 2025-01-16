'Copyright (c) 2025 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          BufferMetadata.vb
'Author:        Alex Nolan (alex.nolan@analog.com)


''' <summary>
''' Wrapper class to store a buffer and associated timestamp
''' </summary>
Public Class BufferMetadata

    Public Time As DateTime
    Public Buf As UShort()

    Public Sub New(data As UShort())
        Buf = data
        Time = Now
    End Sub

End Class
