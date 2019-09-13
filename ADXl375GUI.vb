Imports FX3Api
Imports Microsoft.VisualBasic.FileIO

Public Class ADXl375GUI
    Inherits FormBase

    Private Sub writeBtn_Click(sender As Object, e As EventArgs) Handles writeBtn.Click
        Dim writeVal As UInteger
        Dim writeAddr As UInteger
        Dim mask As UInteger
        Try
            writeAddr = Convert.ToUInt32(addr.Text, 16)
            writeVal = Convert.ToUInt32(value.Text, 16)
        Catch ex As Exception
            MsgBox("ERROR: Invalid values")
        End Try

        writeReg(writeAddr, writeVal)
    End Sub

    Private Sub readBtn_Click(sender As Object, e As EventArgs) Handles readBtn.Click
        Dim readVal As UInteger
        Dim readAddr As UInteger
        Try
            readAddr = Convert.ToUInt32(addr.Text, 16)
        Catch ex As Exception
            MsgBox("ERROR: Invalid values")
        End Try
        readAddr = readAddr Or &H80
        readAddr = readAddr << 8
        readVal = m_TopGUI.FX3.Transfer(readAddr) And &HFF
        readBox.Text = readVal.ToString("X2")
    End Sub

    Private Sub ADXl375GUI_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        m_TopGUI.FX3.WordLength = 16
        m_TopGUI.FX3.DrActive = False
    End Sub

    Private Sub configure_Click(sender As Object, e As EventArgs) Handles configure.Click

        'set power control to 0
        writeReg(&H2D, &H0)

        'set shock_axis to 0
        writeReg(&H2A, &H0)

        'set BW rate
        writeReg(&H2C, &HF)

        'set data format
        writeReg(&H31, &HF)

        'set interrupt mapping
        writeReg(&H2F, &H1)

        'set FIFO control
        'writeReg(&H38, &H54)
        writeReg(&H38, &H4F)

        'set interrupt enable for watermark only
        writeReg(&H2E, &H3)

        'set power control
        writeReg(&H2D, &H8)

    End Sub

    Private Sub readFIFO_Click(sender As Object, e As EventArgs) Handles readFIFO.Click

        Dim buf() As UShort
        Dim byteBuf() As Byte
        Dim tempShort As UShort
        Dim addr As New List(Of AdisApi.AddrDataPair)
        Dim result As String
        m_TopGUI.FX3.TriggerReg = New RegMapClasses.RegClass With {.Address = &HF2}
        m_TopGUI.FX3.WordCount = 3
        m_TopGUI.FX3.StripBurstTriggerWord = False
        m_TopGUI.FX3.SetupBurstMode()

        'grab number of FIFO buffers
        Dim numBuf As Integer
        numBuf = Convert.ToInt32(numBuffers.Text)

        Dim logData As New List(Of String)
        logData.Add("x, y, z")

        For i As Integer = 0 To numBuf - 1
            'wait for interrupt
            m_TopGUI.FX3.PulseWait(m_TopGUI.FX3.DIO1, 1, 0, 1000)
            'stream data
            m_TopGUI.FX3.StartBufferedStream(addr, Nothing, 16UI, 10, Nothing)
            For j As Integer = 1 To 16
                buf = Nothing
                While IsNothing(buf)
                    buf = m_TopGUI.FX3.GetBuffer()
                End While
                byteBuf = UShortToByteArray(buf)
                'parse x, y, z
                result = ""
                For k As Integer = 1 To 5 Step 2
                    tempShort = byteBuf(k + 1)
                    tempShort = tempShort << 8
                    tempShort += byteBuf(k)
                    result = result + ConvertToInt(tempShort).ToString() + ","
                Next
                logData.Add(result)
            Next
        Next

        saveCSV("ADXL375_Data", logData.ToArray())

    End Sub

    Private Sub writeReg(addr As UInteger, value As UInteger)
        Dim mask As UInteger
        mask = (addr << 8) Or value
        m_TopGUI.FX3.Transfer(mask)
    End Sub

    Private Sub parseLA_Click(sender As Object, e As EventArgs) Handles parseLA.Click

        Dim fileBrowser As New OpenFileDialog
        fileBrowser.Title = "Please Select the DS Logic MISO data file"
        fileBrowser.Filter = "Data Files|*.csv"
        fileBrowser.ShowDialog()
        Dim CSVReader As TextFieldParser = New TextFieldParser(fileBrowser.FileName)
        CSVReader.TextFieldType = FieldType.Delimited
        CSVReader.SetDelimiters(",")
        Dim outputData As New List(Of String)
        Dim result As String
        Dim tempShort As UShort
        Dim currentSample As String()
        Dim rawXLData(5) As String
        Dim rawIndex As Integer

        outputData.Add("x, y, z")
        While Not CSVReader.EndOfData
            'grab a line
            currentSample = CSVReader.ReadFields()

            'check if the sample value is "F2" trigger word for FIFO read
            If currentSample(3) = "F2" Then
                rawIndex = 0
                'grab all XL data
                While rawIndex < 6
                    currentSample = CSVReader.ReadFields()
                    rawXLData(rawIndex) = currentSample(2)
                    rawIndex += 1
                End While

                'convert the data to signed and place in output data array
                result = ""
                For k As Integer = 0 To 4 Step 2
                    tempShort = Convert.ToUInt16(rawXLData(k + 1), 16)
                    tempShort = tempShort << 8
                    tempShort += Convert.ToUInt16(rawXLData(k), 16)
                    result = result + ConvertToInt(tempShort).ToString() + ","
                Next
                outputData.Add(result)
            End If

        End While

        saveCSV("ADXL375_Data", outputData.ToArray())
    End Sub

End Class