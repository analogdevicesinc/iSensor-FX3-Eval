'Copyright (c) 2022 Analog Devices, Inc. All Rights Reserved.
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

Public Class BurstManager
    Implements IBufferedStreamProducer, IStreamEventProducer

    Public Event NewBufferAvailable As IStreamEventProducer.NewBufferAvailableEventHandler Implements IStreamEventProducer.NewBufferAvailable
    Public Event StreamFinished As IStreamEventProducer.StreamFinishedEventHandler Implements IStreamEventProducer.StreamFinished

    Public Sub New(Dut As IDutInterface, FX3 As FX3Connection, Regmap As RegMapCollection, Personality As String)

    End Sub

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

End Class
