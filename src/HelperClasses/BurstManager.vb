﻿'Copyright (c) 2022 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          BurstManager.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Format burst packets based on the defined IMU burst protocol

Imports System.ComponentModel
Imports adisInterface
Imports RegMapClasses
Imports StreamDataLogger
Imports FX3Api

Public Enum BurstDevice
    ADIS1655x
    ADIS1654x
    ADIS1650x
    ADIS1649x
    ADIS1647x
    ADIS1646x
    ADIS16445
    ADIS1644x
    Unknown
End Enum

Public Class BurstManager
    Implements IBufferedStreamProducer, IStreamEventProducer

    Public Event NewBufferAvailable As IStreamEventProducer.NewBufferAvailableEventHandler Implements IStreamEventProducer.NewBufferAvailable
    Public Event StreamFinished As IStreamEventProducer.StreamFinishedEventHandler Implements IStreamEventProducer.StreamFinished

    Private m_Device As BurstDevice
    Private m_FX3 As FX3Connection
    Private m_Dut As IDutInterface
    Private m_RegMap As RegMapCollection

    ''' <summary>
    ''' Does burst require a setup command?
    ''' </summary>
    Private m_burstSetupRequired As Boolean

    ''' <summary>
    ''' Burst checksum register
    ''' </summary>
    Private m_checksum As RegClass

    Public Sub New(Dut As IDutInterface, FX3 As FX3Connection, Regmap As RegMapCollection, Personality As String)
        m_RegMap = Regmap
        m_Dut = Dut
        m_FX3 = FX3
        m_regs = Regmap.BurstReadList
        LoadDeviceInfo(True, Personality)
    End Sub

    ''' <summary>
    ''' The IMU being interfaced to
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Device As BurstDevice
        Get
            Return m_Device
        End Get
    End Property

    ''' <summary>
    ''' Does the connected IMU support a configurable burst word size? 16-bit vs 32-bit
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConfigurableWordSize As Boolean
        Get
            Return m_ConfigurableWordSize
        End Get
    End Property
    Private m_ConfigurableWordSize As Boolean

    ''' <summary>
    ''' Does the connected IMU support configurable burst data types? Delta vs inertial
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConfigurableData As Boolean
        Get
            Return m_ConfigurableData
        End Get
    End Property
    Private m_ConfigurableData As Boolean

    ''' <summary>
    ''' Does the connected IMU support an optional burst checksum?
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConfigurableChecksum As Boolean
        Get
            Return m_ConfigurableChecksum
        End Get
    End Property
    Private m_ConfigurableChecksum As Boolean

    ''' <summary>
    ''' Select 16-bit burst data or 32-bit burst data
    ''' </summary>
    ''' <returns></returns>
    Public Property Burst16Bit As Boolean
        Get
            Return m_Burst16Bit
        End Get
        Set(value As Boolean)
            If ConfigurableWordSize Then m_Burst16Bit = value
        End Set
    End Property
    Private m_Burst16Bit As Boolean

    ''' <summary>
    ''' Select inertial burst data or delta burst data
    ''' </summary>
    ''' <returns></returns>
    Public Property BurstInertialData As Boolean
        Get
            Return m_BurstInertialData
        End Get
        Set(value As Boolean)
            If ConfigurableData Then m_BurstInertialData = value
        End Set
    End Property
    Private m_BurstInertialData As Boolean

    ''' <summary>
    ''' Select checksum enabled or disabled
    ''' </summary>
    ''' <returns></returns>
    Public Property BurstChecksum As Boolean
        Get
            Return m_BurstChecksum
        End Get
        Set(value As Boolean)
            If ConfigurableChecksum Then m_BurstChecksum = value
        End Set
    End Property
    Private m_BurstChecksum As Boolean

    ''' <summary>
    ''' Registers contained in the burst read
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property BurstRegisters As List(Of RegClass)
        Get
            Return m_regs
        End Get
    End Property
    Private m_regs As List(Of RegClass)

    Public Sub CancelStreamAsync() Implements IStreamEventProducer.CancelStreamAsync
        Throw New NotImplementedException()
    End Sub

    Public Sub StartBufferedStream(regList As IEnumerable(Of RegClass), numCaptures As UInteger, numBuffers As UInteger, timeoutSeconds As Integer, worker As BackgroundWorker) Implements IBufferedStreamProducer.StartBufferedStream
        Throw New NotImplementedException()
    End Sub

    Public Function ConvertReadDataToU32(regList As IEnumerable(Of RegClass), u16data As IEnumerable(Of UShort)) As UInteger() Implements IBufferedStreamProducer.ConvertReadDataToU32
        Throw New NotImplementedException()
    End Function

    Public Function GetBufferedStreamDataPacket() As UShort() Implements IBufferedStreamProducer.GetBufferedStreamDataPacket
        Throw New NotImplementedException()
    End Function

    Public Function ScaleRegData(regList As IEnumerable(Of RegClass), uintData As IEnumerable(Of UInteger)) As Double() Implements IBufferedStreamProducer.ScaleRegData
        Throw New NotImplementedException()
    End Function

    ''' <summary>
    ''' Validate the selected device. First use the provided personality, then
    ''' try and read from the PROD_ID register, if the personality is not found.
    ''' 
    ''' Then load properties based on the selected device
    ''' </summary>
    Private Sub LoadDeviceInfo(firstRun As Boolean, personality As String)

        'initially set device to unknown
        m_Device = BurstDevice.Unknown
        'check personality
        If personality.Contains("1655") Then
            m_Device = BurstDevice.ADIS1655x

            'Fixed 32-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = False

            'selectable delta vs inertial
            m_ConfigurableData = True
            m_BurstInertialData = True

            'CRC included (32-bit), not configurable
            m_ConfigurableChecksum = False
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 32, .NumBytes = 4}

            'Burst requires setup command
            m_burstSetupRequired = True

        ElseIf personality.Contains("1654") Then
            m_Device = BurstDevice.ADIS1654x

            'Fixed 32-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = False

            'selectable delta vs inertial
            m_ConfigurableData = True
            m_BurstInertialData = True

            'CRC included (32-bit), not configurable
            m_ConfigurableChecksum = False
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 32, .NumBytes = 4}

            'Burst does not require setup command
            m_burstSetupRequired = False

        ElseIf personality.Contains("1650") Then
            m_Device = BurstDevice.ADIS1650x

            'Configurable 32-bit or 16-bit burst
            m_ConfigurableWordSize = True
            m_Burst16Bit = True

            'selectable delta vs inertial
            m_ConfigurableData = True
            m_BurstInertialData = True

            'Checksum included (16-bit), not configurable
            m_ConfigurableChecksum = False
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

        ElseIf personality.Contains("1649") Then
            m_Device = BurstDevice.ADIS1649x

            'Fixed 32-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = False

            'Only inertial
            m_ConfigurableData = False
            m_BurstInertialData = True

            'CRC included (32-bit), not configurable
            m_ConfigurableChecksum = False
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 32, .NumBytes = 4}

            'Burst does not require setup command
            m_burstSetupRequired = False

        ElseIf personality.Contains("1647") Then
            m_Device = BurstDevice.ADIS1647x

            'Fixed 16-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = True

            'Only inertial
            m_ConfigurableData = False
            m_BurstInertialData = True

            'Checksum included (16-bit), not configurable
            m_ConfigurableChecksum = False
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

        ElseIf personality.Contains("1646") Then
            m_Device = BurstDevice.ADIS1646x

            'Fixed 16-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = True

            'Only inertial
            m_ConfigurableData = False
            m_BurstInertialData = True

            'Checksum included (16-bit), not configurable
            m_ConfigurableChecksum = False
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

        ElseIf personality.Contains("16445") Then
            m_Device = BurstDevice.ADIS16445

            'Fixed 16-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = True

            'Only inertial
            m_ConfigurableData = False
            m_BurstInertialData = True

            'No checksum
            m_ConfigurableChecksum = False
            m_BurstChecksum = False

            'Burst does not require setup command
            m_burstSetupRequired = False

        ElseIf personality.Contains("1644") Then
            m_Device = BurstDevice.ADIS1644x

            'Fixed 16-bit burst
            m_ConfigurableWordSize = False
            m_Burst16Bit = True

            'Only inertial
            m_ConfigurableData = False
            m_BurstInertialData = True

            'Configurable checksum (16-bit)
            m_ConfigurableChecksum = True
            m_BurstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

        Else
            'either no burst on selected device, or personality not found
            Dim prod_id As UInteger = 0
            Try
                prod_id = m_Dut.ReadUnsigned(m_RegMap("PROD_ID"))
            Catch ex As Exception
                'squash
            End Try
            'If we read a valid product ID, then check again (once!)
            If (prod_id <> 0) And firstRun Then
                LoadDeviceInfo(False, prod_id.ToString())
            End If
        End If

    End Sub

End Class
