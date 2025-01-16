'Copyright (c) 2025 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          SignedConverter.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Signed to unsigned register conversion support

Public Class SignedConverter

    Shared Function ToSignedByte(value As UShort, isUpper As Boolean) As Short
        'Pull byte value
        Dim byteVal As Short
        If isUpper Then
            byteVal = value >> 8
        Else
            byteVal = value And &HFF
        End If

        'Perform signed conversion
        If byteVal >= 2 ^ 7 Then
            byteVal = byteVal - 2 ^ 8
        End If

        'Return signed byte value
        Return byteVal
    End Function

    Shared Function ToUnsignedByte(value As UShort, isUpper As Boolean) As UShort
        'Pull byte value
        Dim byteVal As UShort
        If isUpper Then
            byteVal = value >> 8
        Else
            byteVal = value And &HFF
        End If

        'return byte value
        Return CByte(byteVal)
    End Function

    Shared Function ToSignedShort(value As UShort) As Integer
        'read into an int
        Dim shortVal As Integer = value

        'perform signed conversion
        If shortVal >= 2 ^ 15 Then
            shortVal = shortVal - 2 ^ 16
        End If

        'return short value
        Return shortVal
    End Function

    Shared Function ToSignedInt(upper As UShort, lower As UShort) As Long
        'Build combined long
        Dim intVal As Long
        intVal = upper
        intVal = intVal << 16
        intVal += lower

        'perform signed conversion
        If intVal >= 2 ^ 31 Then
            intVal = intVal - 2 ^ 32
        End If

        'return value as integer
        Return intVal
    End Function

    Shared Function ToUnsignedInt(upper As UShort, lower As UShort) As ULong
        'Build combined ulong
        Dim intVal As ULong
        intVal = upper
        intVal = intVal << 16
        intVal += lower

        'return uinteger
        Return intVal
    End Function

End Class
