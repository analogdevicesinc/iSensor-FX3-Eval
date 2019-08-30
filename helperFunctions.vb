'File:          helperFunctions.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Date:          7/25/2019
'Description:   Module of generic helper functions for use in the GUI

Imports System.IO
Imports RegMapClasses

Class RegOffsetPair
    Public Offset As Double
    Public Reg As RegClass
    Public Index As Integer
    Public Color As Color
End Class

Module helperFunctions

    Public Sub saveCSV(ByVal fileHeader As String, ByVal inputData() As String, Optional ByRef Path As String = "")
        Dim currentTime As Date = Date.Now()
        Dim outputStream As StreamWriter
        Dim saveData As New SaveFileDialog
        Dim fileName As String = fileHeader + "_" + currentTime.ToString("s") + ".csv"
        fileName = fileName.Replace(":", "-")
        saveData.FileName = fileName
        saveData.Filter = "Output data file | .csv"
        If Path <> "" Then
            saveData.InitialDirectory = Path
        Else
            saveData.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location
        End If
        If saveData.ShowDialog() = DialogResult.OK Then
            Path = saveData.FileName
            outputStream = New StreamWriter(saveData.OpenFile)
            For Each line In inputData
                outputStream.WriteLine(line)
            Next
            outputStream.Close()
        End If
    End Sub

    Function setSaveLocation(Optional ByRef Path As String = "")
        Dim dialog As New FolderBrowserDialog
        Dim savePath As String
        Try
            dialog.SelectedPath = Path
        Catch ex As Exception
            Path = ""
        End Try
        If dialog.ShowDialog() = DialogResult.OK Then
            savePath = dialog.SelectedPath
            Path = savePath
            Return (savePath)
        Else
            Return Nothing
        End If
    End Function

    Public Sub saveMultipleCSVs(ByVal fileHeader As String, ByVal inputData() As String, ByVal savePath As String, ByVal fileNumber As String)
        Dim currentTime As Date = Date.Now()
        Dim outputStream As StreamWriter
        Dim fileName As String = "\" + fileNumber.PadLeft(4, "0"c) + "_" + fileHeader + "_" + currentTime.ToString("s") + ".csv"
        fileName = fileName.Replace(":", "-")
        fileName = savePath + fileName
        outputStream = New StreamWriter(fileName)
        For Each line In inputData
            outputStream.WriteLine(line)
        Next
        outputStream.Close()
    End Sub

    Public Sub saveText(ByVal fileHeader As String, ByRef inputData As String, Optional ByRef Path As String = "")
        Dim currentTime As Date = Date.Now()
        Dim fileName As String = fileHeader + "_" + currentTime.ToString("s") + ".csv"
        fileName = fileName.Replace(":", "-")
        Dim saveData As New SaveFileDialog
        saveData.FileName = fileName
        saveData.Filter = "Output data file | .csv"
        If Path <> "" Then
            saveData.InitialDirectory = Path
        Else
            saveData.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location
        End If
        If saveData.ShowDialog() = DialogResult.OK Then
            Path = saveData.FileName
            File.WriteAllText(saveData.FileName, inputData)
        End If
    End Sub

    Public Sub saveBinaryFile(ByVal fileHeader As String, ByRef inputData As Byte(), Optional ByRef Path As String = "")
        Dim currentTime As Date = Date.Now()
        Dim fileName As String = fileHeader + "_" + currentTime.ToString("s") + ".bin"
        fileName = fileName.Replace(":", "-")
        Dim saveData As New SaveFileDialog
        saveData.FileName = fileName
        saveData.Filter = "Output data file | .bin"
        If Path <> "" Then
            saveData.InitialDirectory = Path
        Else
            saveData.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location
        End If
        If saveData.ShowDialog() = DialogResult.OK Then
            Path = saveData.FileName
            File.WriteAllBytes(saveData.FileName, inputData)
        End If
    End Sub

    Public Sub saveMultipleBinaryFiles(ByVal fileHeader As String, ByVal inputData As Byte(), ByVal savePath As String, ByVal fileNumber As String)
        Dim currentTime As Date = Date.Now()
        Dim fileName As String = "\" + fileNumber.PadLeft(4, "0"c) + "_" + fileHeader + "_" + currentTime.ToString("s") + ".bin"
        fileName = fileName.Replace(":", "-")
        fileName = savePath + fileName
        File.WriteAllBytes(fileName, inputData)
    End Sub

    Function calcCCITT16(byt() As Byte) As UInteger
        ' byte() values are expected to be swapped as required by ADUC3021 data format
        ' CRC-16-CCITT, initialized with crc = 0xFFFF, No final XOR.
        ' Limit crc accumulation to 16 bits to prevent U32 overflow.
        Dim crc As UInteger = &HFFFF
        Dim poly As UInteger = &H1021
        Dim dat As UInteger
        Dim i As Integer = 0
        Dim j As Integer = 0

        For i = 0 To byt.Count - 1
            dat = byt(i)
            crc = crc Xor (dat << 8)
            For j = 1 To 8
                If ((crc And &H8000) = &H8000) Then
                    crc = crc * 2
                    crc = crc Xor poly
                Else
                    crc = crc * 2
                End If
                crc = crc And &HFFFF
            Next j
        Next i
        Return crc
    End Function

    ''' <summary>
    ''' Converts a UShort enumerable to a byte array
    ''' </summary>
    ''' <param name="ShortArray"></param>
    ''' <returns></returns>
    Public Function UShortToByteArray(ByRef ShortArray As IEnumerable(Of UShort)) As Byte()

        Dim ByteArray(2 * ShortArray.Count - 1) As Byte

        For i As Integer = 0 To ShortArray.Count - 1
            ByteArray(2 * i + 1) = ShortArray(i) And &HFF
            ByteArray(2 * i) = (ShortArray(i) And &HFF00) >> 8
        Next

        Return ByteArray

    End Function

    ''' <summary>
    ''' Checks the CRC for a real time frame
    ''' </summary>
    ''' <param name="frame">The frame to check</param>
    ''' <returns>A boolean indicating if the accel. data CRC matches the frame CRC</returns>
    Function CheckDUTCRC(ByRef frame() As UShort) As Boolean
        'Read CRC from frame
        Dim DUTCRC As UShort = frame(frame.Count - 1)
        Dim temp As UShort = DUTCRC >> 8
        DUTCRC = DUTCRC << 8
        DUTCRC = DUTCRC + temp
        Dim CRCData As New List(Of UShort)
        'Calculate the CRC
        CRCData.Clear()
        For index = 1 To frame.Count - 4
            CRCData.Add(frame(index))
        Next
        Dim expectedCRC = calcCCITT16(CRCData.ToArray)
        Return (expectedCRC = DUTCRC)
    End Function

    ''' <summary>
    ''' Overload for CRC calculation which takes UShort array
    ''' </summary>
    ''' <param name="UShortData">The data to calculate CRC for</param>
    ''' <returns>The CRC value</returns>
    Function calcCCITT16(UShortData() As UShort) As UInteger

        Dim ByteData(2 * UShortData.Count - 1) As Byte

        'Convert shorts to byte array
        For i As Integer = 0 To UShortData.Count - 1
            ByteData(2 * i + 1) = UShortData(i) And &HFF
            ByteData(2 * i) = (UShortData(i) And &HFF00) >> 8
        Next

        Return calcCCITT16(ByteData)

    End Function

End Module