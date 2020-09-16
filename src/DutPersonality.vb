Imports FX3Api
Imports System.IO

Public Class DutPersonality

    ''' <summary>
    ''' DUT display name (e.g. ADIS16xxx)
    ''' </summary>
    Public DisplayName As String

    ''' <summary>
    ''' Regmap file name (within FX3 Eval GUI)
    ''' </summary>
    Public RegMapFileName As String

    ''' <summary>
    ''' Sensor type required (device type)
    ''' </summary>
    Public SensorType As DeviceType

    ''' <summary>
    ''' Part type required (DUT type)
    ''' </summary>
    Public PartType As DUTType

    ''' <summary>
    ''' SPI clock frequency)
    ''' </summary>
    Public SPIFreq As UInteger

    ''' <summary>
    ''' SPI stall time
    ''' </summary>
    Public SPIStall As UInteger

    ''' <summary>
    ''' SPI Mode (0 - 3). CPHA + CPOL
    ''' </summary>
    Public SPIMode As UInteger

    ''' <summary>
    ''' Data ready polarity
    ''' </summary>
    Public DrPolarity As Boolean

    ''' <summary>
    ''' Data ready DIO number (1 - 4)
    ''' </summary>
    Public DrDIONumber As UInteger

    Public Sub New()
        DisplayName = "NotSet"
        RegMapFileName = "NotSet"
        SensorType = DeviceType.IMU
        PartType = DUTType.IMU
        SPIFreq = 2000000
        SPIStall = 20
        SPIMode = 3
        DrPolarity = True
        DrDIONumber = 1
    End Sub

    ''' <summary>
    ''' Apply selected DUT personality settings to FX3 connection object
    ''' </summary>
    ''' <param name="FX3">FX3 to modify</param>
    Public Sub ApplySettingsToFX3(ByRef FX3 As FX3Connection)
        'do these first since can change other settings
        FX3.PartType = PartType
        FX3.SensorType = SensorType
        FX3.SclkFrequency = SPIFreq
        FX3.StallTime = SPIStall
        If (SPIMode And &H1) <> 0 Then
            FX3.Cpha = True
        Else
            FX3.Cpha = False
        End If
        If (SPIMode And &H2) <> 0 Then
            FX3.Cpol = True
        Else
            FX3.Cpol = False
        End If
        FX3.DrActive = False
        FX3.DrPolarity = DrPolarity
        Select Case DrDIONumber
            Case 1
                FX3.DrPin = FX3.DIO1
            Case 2
                FX3.DrPin = FX3.DIO2
            Case 3
                FX3.DrPin = FX3.DIO3
            Case 4
                FX3.DrPin = FX3.DIO4
        End Select
    End Sub

    Public Shared Function ParseFile(PersonalityFile As String) As List(Of DutPersonality)
        Dim ret As New List(Of DutPersonality)
        Dim lines(), line() As String
        Dim item As DutPersonality
        If File.Exists(PersonalityFile) Then
            lines = File.ReadAllLines(PersonalityFile)
            'parse file
            For i As Integer = 1 To lines.Count - 1
                line = lines(i).Split(",")
                'TODO: Dynamic parsing based on header
                item = New DutPersonality()
                Try
                    item.DisplayName = line(0)
                    item.RegMapFileName = line(1)
                    item.SensorType = [Enum].Parse(GetType(FX3Api.DeviceType), line(2))
                    item.PartType = [Enum].Parse(GetType(FX3Api.DUTType), line(3))
                    item.SPIMode = Convert.ToUInt32(line(4))
                    item.SPIFreq = Convert.ToUInt32(line(5))
                    item.SPIStall = Convert.ToUInt32(line(6))
                    item.DrDIONumber = Convert.ToUInt32(line(7))
                    item.DrPolarity = Convert.ToBoolean(line(8))
                    ret.Add(item)
                Catch ex As Exception
                    'abort
                    Return ret
                End Try
            Next
        End If
        Return ret
    End Function

End Class
