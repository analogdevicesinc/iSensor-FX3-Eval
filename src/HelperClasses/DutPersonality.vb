﻿'Copyright (c) 2018-2020 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          DutPersonality.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Class to store an IMU personality. The personality contains all the FX3 settings associated with a given part

Imports FX3Api
Imports System.IO

Public Class DutPersonality

    Public Const CUSTOM_PERSONALITY_STRING As String = "Custom"

    ''' <summary>
    ''' Parent personality (e.g. for ADIS16505, parent is ADIS1650x.
    ''' For a top level personality, parent should be ""
    ''' </summary>
    Public Parent As String

    ''' <summary>
    ''' DUT display name (e.g. ADIS16xxx)
    ''' </summary>
    Public DisplayName As String

    ''' <summary>
    ''' Register Map file name (within FX3 Eval GUI)
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

    ''' <summary>
    ''' DUT supply (3.3V, 5V, or none (other))
    ''' </summary>
    Public Supply As DutVoltage

    ''' <summary>
    ''' IMU digital logic high voltage
    ''' </summary>
    Public VDDIO As Double

    ''' <summary>
    ''' Addr SPI word position (used only for ComponentSpi)
    ''' </summary>
    Public AddrPosition As Integer

    ''' <summary>
    ''' Data SPI word position (used only for ComponentSpi)
    ''' </summary>
    Public DataPosition As Integer

    ''' <summary>
    ''' Write bit SPI word position (used only for ComponentSpi)
    ''' </summary>
    Public WriteBitPosition As Integer

    ''' <summary>
    ''' Write bit SPI word polarity (used only for ComponentSpi)
    ''' </summary>
    Public WriteBitPolarity As Boolean

    ''' <summary>
    ''' For 32-bit registers, track if lower word comes first (addr n) or second
    ''' (addr n+1)
    ''' </summary>
    Public IsLowerFirst As Boolean

    ''' <summary>
    ''' Command register bit to issue a flash update
    ''' </summary>
    Public FlashUpdateCmdBit As Integer

    ''' <summary>
    ''' Command register bit to issue a software reset
    ''' </summary>
    Public SoftResetCmdBit As Integer

    ''' <summary>
    ''' Registers to load to plotter view by default. Space separated, format {RegPattern PlotNumber}
    ''' </summary>
    Public DefaultPlotRegs As String

    Private Const CommaToken As String = "{comma}"

    Public Sub New()
        DisplayName = CUSTOM_PERSONALITY_STRING
        RegMapFileName = "NotSet"
        Parent = ""
        SensorType = DeviceType.IMU
        PartType = DUTType.IMU
        SPIFreq = 2000000
        SPIStall = 20
        SPIMode = 3
        DrPolarity = True
        DrDIONumber = 1
        VDDIO = 3.3
        Supply = DutVoltage.On3_3Volts
        DataPosition = 0
        AddrPosition = 8
        WriteBitPosition = 15
        WriteBitPolarity = True
        IsLowerFirst = True
        DefaultPlotRegs = ""
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
        FX3.DutSupplyMode = Supply
        'cant set VDDIO currently
    End Sub

    ''' <summary>
    ''' Apply DUT personality to configurable component SPI IRegInterface
    ''' </summary>
    ''' <param name="CompSpi">Component SPI IRegInterface to configure</param>
    Public Sub ApplyComponentSpiSettings(ByRef CompSpi As adisInterface.ComponentSpi)
        CompSpi.AddrPosition = AddrPosition
        CompSpi.DataPosition = DataPosition
        CompSpi.WriteBitPosition = WriteBitPosition
        CompSpi.WriteBitPolarity = WriteBitPolarity
    End Sub

    Public Shared Sub WriteToFile(path As String, Personality As DutPersonality)
        Dim personalities As New List(Of DutPersonality)
        personalities.Add(Personality)
        WriteToFile(path, personalities)
    End Sub

    Public Shared Sub WriteToFile(path As String, Personalities As IEnumerable(Of DutPersonality))
        Dim header As New List(Of String)
        Dim vals As New List(Of String)
        Dim writer As New StreamWriter(path, False)
        header.Add("DISPLAYNAME")
        header.Add("PARENT")
        header.Add("REGMAP")
        header.Add("SENSORTYPE")
        header.Add("PARTTYPE")
        header.Add("SPIMODE")
        header.Add("SPIFREQ")
        header.Add("SPISTALL")
        header.Add("DRDIONUMBER")
        header.Add("DRPOLARITY")
        header.Add("SUPPLY")
        header.Add("VDDIO")
        header.Add("ADDRPOS")
        header.Add("DATAPOS")
        header.Add("WRITEBITPOS")
        header.Add("WRITEBITPOLARITY")
        header.Add("ISLOWERFIRST")
        header.Add("SOFTRESETBIT")
        header.Add("FLASHUPDATEBIT")
        header.Add("DEFAULT_PLOT_REGS")
        For Each item In header
            writer.Write(item + ",")
        Next
        writer.Write(Environment.NewLine)

        For Each personality In Personalities
            'Sanitize register map path in case of commas in path name
            If personality.RegMapFileName.Contains(CommaToken) Then
                MsgBox("ERROR: Invalid register map path " + personality.RegMapFileName)
            End If
            Dim sanitizedRegMapPath As String = personality.RegMapFileName.Replace(",", CommaToken)

            'Build each line in CSV
            vals.Clear()
            vals.Add(personality.DisplayName)
            vals.Add(personality.Parent)
            vals.Add(sanitizedRegMapPath)
            vals.Add([Enum].GetName(GetType(DeviceType), personality.SensorType))
            vals.Add([Enum].GetName(GetType(DUTType), personality.PartType))
            vals.Add(personality.SPIMode.ToString())
            vals.Add(personality.SPIFreq.ToString())
            vals.Add(personality.SPIStall.ToString())
            vals.Add(personality.DrDIONumber.ToString())
            vals.Add(personality.DrPolarity.ToString())
            vals.Add([Enum].GetName(GetType(DutVoltage), personality.Supply))
            vals.Add(personality.VDDIO.ToString())
            vals.Add(personality.AddrPosition.ToString())
            vals.Add(personality.DataPosition.ToString())
            vals.Add(personality.WriteBitPosition.ToString())
            vals.Add(personality.WriteBitPolarity.ToString())
            vals.Add(personality.IsLowerFirst.ToString())
            vals.Add(personality.SoftResetCmdBit.ToString())
            vals.Add(personality.FlashUpdateCmdBit.ToString())
            vals.Add(personality.DefaultPlotRegs)
            For Each item In vals
                writer.Write(item + ",")
            Next
            writer.Write(Environment.NewLine)
        Next

        writer.Close()
    End Sub

    Public Sub GetSettingsFromFX3(ByRef FX3 As FX3Connection)
        PartType = FX3.PartType
        SensorType = FX3.SensorType
        SPIFreq = FX3.SclkFrequency
        SPIStall = FX3.StallTime
        SPIMode = 0
        If FX3.Cpha Then
            SPIMode = SPIMode Or &H1
        End If
        If FX3.Cpol Then
            SPIMode = SPIMode Or &H2
        End If
        DrPolarity = FX3.DrPolarity
        DrDIONumber = 1
        If FX3.DrPin.pinConfig = FX3.DIO1.pinConfig Then DrDIONumber = 1
        If FX3.DrPin.pinConfig = FX3.DIO2.pinConfig Then DrDIONumber = 2
        If FX3.DrPin.pinConfig = FX3.DIO3.pinConfig Then DrDIONumber = 3
        If FX3.DrPin.pinConfig = FX3.DIO4.pinConfig Then DrDIONumber = 4
        Supply = FX3.DutSupplyMode
        DrPolarity = FX3.DrPolarity
    End Sub

    Public Shared Function ParseFile(PersonalityFile As String) As List(Of DutPersonality)
        Dim ret As New List(Of DutPersonality)
        Dim lines(), line() As String
        Dim indexes As New List(Of Integer)
        Dim item As DutPersonality
        If File.Exists(PersonalityFile) Then
            lines = File.ReadAllLines(PersonalityFile)
            'get indexes for all parameters from header
            line = lines(0).Split(",")
            indexes.Add(Array.IndexOf(line, "DISPLAYNAME"))     '0
            indexes.Add(Array.IndexOf(line, "REGMAP"))          '1
            indexes.Add(Array.IndexOf(line, "SENSORTYPE"))      '2
            indexes.Add(Array.IndexOf(line, "PARTTYPE"))        '3
            indexes.Add(Array.IndexOf(line, "SPIMODE"))         '4
            indexes.Add(Array.IndexOf(line, "SPIFREQ"))         '5
            indexes.Add(Array.IndexOf(line, "SPISTALL"))        '6
            indexes.Add(Array.IndexOf(line, "DRDIONUMBER"))     '7
            indexes.Add(Array.IndexOf(line, "DRPOLARITY"))      '8
            indexes.Add(Array.IndexOf(line, "SUPPLY"))          '9
            indexes.Add(Array.IndexOf(line, "VDDIO"))           '10
            indexes.Add(Array.IndexOf(line, "ADDRPOS"))         '11
            indexes.Add(Array.IndexOf(line, "DATAPOS"))         '12
            indexes.Add(Array.IndexOf(line, "WRITEBITPOS"))     '13
            indexes.Add(Array.IndexOf(line, "WRITEBITPOLARITY")) '14
            indexes.Add(Array.IndexOf(line, "ISLOWERFIRST"))    '15
            indexes.Add(Array.IndexOf(line, "SOFTRESETBIT"))    '16
            indexes.Add(Array.IndexOf(line, "FLASHUPDATEBIT"))  '17
            indexes.Add(Array.IndexOf(line, "PARENT"))          '18
            indexes.Add(Array.IndexOf(line, "DEFAULT_PLOT_REGS")) '19
            'parse file
            For i As Integer = 1 To lines.Count - 1
                line = lines(i).Split(",")
                item = New DutPersonality()
                Try
                    item.DisplayName = line(indexes(0))
                    item.RegMapFileName = line(indexes(1))
                    'De-sanitize the register map file name
                    item.RegMapFileName = item.RegMapFileName.Replace(CommaToken, ",")
                    item.SensorType = [Enum].Parse(GetType(DeviceType), line(indexes(2)))
                    item.PartType = [Enum].Parse(GetType(DUTType), line(indexes(3)))
                    item.SPIMode = Convert.ToUInt32(line(indexes(4)))
                    item.SPIFreq = Convert.ToUInt32(line(indexes(5)))
                    item.SPIStall = Convert.ToUInt32(line(indexes(6)))
                    item.DrDIONumber = Convert.ToUInt32(line(indexes(7)))
                    item.DrPolarity = Convert.ToBoolean(line(indexes(8)))
                    item.Supply = [Enum].Parse(GetType(DutVoltage), line(indexes(9)))
                    item.VDDIO = Convert.ToDouble(line(indexes(10)))
                    item.AddrPosition = Convert.ToInt32(line(indexes(11)))
                    item.DataPosition = Convert.ToInt32(line(indexes(12)))
                    item.WriteBitPosition = Convert.ToInt32(line(indexes(13)))
                    item.WriteBitPolarity = Convert.ToBoolean(line(indexes(14)))
                    item.IsLowerFirst = Convert.ToBoolean(line(indexes(15)))
                    item.SoftResetCmdBit = Convert.ToInt32(line(indexes(16)))
                    item.FlashUpdateCmdBit = Convert.ToInt32(line(indexes(17)))
                    item.Parent = line(indexes(18))
                    item.DefaultPlotRegs = line(indexes(19))
                    ret.Add(item)
                Catch ex As Exception
                    'Add the personality to the list. This is a lazy way to make this parser
                    'support backwards compatibility with older personality files. It will populate
                    'the existing fields, then throw an exception when it tries to load one
                    'which does not exist
                    ret.Add(item)
                End Try
            Next
        End If
        Return ret
    End Function

End Class
