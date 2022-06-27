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
    Private WithEvents m_FX3 As FX3Connection
    Private m_Dut As IDutInterface
    Private m_RegMap As RegMapCollection

    'buffered steam producer
    Private m_buffProducer As adbfInterface

    ''' <summary>
    ''' Does burst require a setup command?
    ''' </summary>
    Private m_burstSetupRequired As Boolean

    ''' <summary>
    ''' Track if we are on first packet in a given stream
    ''' </summary>
    Private m_firstPacket As Boolean

    ''' <summary>
    ''' Burst sync word
    ''' </summary>
    Private m_burstSyncWord As UShort

    ''' <summary>
    ''' Burst checksum register
    ''' </summary>
    Private m_checksum As RegClass

    ''' <summary>
    ''' Burst header register (if any)
    ''' </summary>
    Private m_burstHeader As RegClass

    ''' <summary>
    ''' Number of extra bytes (excluding burst payload) which must be added to transaction
    ''' </summary>
    Private m_paddingBytes As Integer

    Public Sub New(Dut As IDutInterface, FX3 As FX3Connection, Regmap As RegMapCollection, Personality As String)
        m_RegMap = Regmap
        m_Dut = Dut
        m_FX3 = FX3
        m_buffProducer = New adbfInterface(m_FX3, Nothing)
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
            If ConfigurableWordSize Then
                m_Burst16Bit = value
            End If
            UpdateBurstRegs()
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
            If ConfigurableData Then
                m_BurstInertialData = value
            End If
            UpdateBurstRegs()
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
            If ConfigurableChecksum Then
                m_BurstChecksum = value
            End If
            UpdateBurstRegs()
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

    ''' <summary>
    ''' Wraps the FX3 cancel stream async
    ''' </summary>
    Public Sub CancelStreamAsync() Implements IStreamEventProducer.CancelStreamAsync
        m_FX3.CancelStreamAsync()
    End Sub

    ''' <summary>
    ''' Wrap FX3 event
    ''' </summary>
    ''' <param name="count"></param>
    Public Sub FX3BufAvailable(count As UInteger) Handles m_FX3.NewBufferAvailable
        RaiseEvent NewBufferAvailable(count)
    End Sub

    ''' <summary>
    ''' Wrap FX3 event
    ''' </summary>
    ''' <param name="count"></param>
    Public Sub FX3BufAvailable() Handles m_FX3.StreamFinished
        RaiseEvent StreamFinished()
    End Sub

    ''' <summary>
    ''' Start a stream. Sets up FX3 then DUT, then dispatches to the lower level producer
    ''' </summary>
    ''' <param name="regList"></param>
    ''' <param name="numCaptures"></param>
    ''' <param name="numBuffers"></param>
    ''' <param name="timeoutSeconds"></param>
    ''' <param name="worker"></param>
    Public Sub StartBufferedStream(regList As IEnumerable(Of RegClass), numCaptures As UInteger, numBuffers As UInteger, timeoutSeconds As Integer, worker As BackgroundWorker) Implements IBufferedStreamProducer.StartBufferedStream
        'Configure DUT, then FX3, then start the stream
        ConfigureDUTForBurst()
        ConfigureFX3ForBurst()
        'is burst setup needed? Then request one extra capture
        If m_burstSetupRequired Then
            numBuffers += 1
            m_firstPacket = True
        End If
        'dispatch stream to lower level implementation
        m_buffProducer.StartBufferedStream(regList, numCaptures, numBuffers, timeoutSeconds, worker)
    End Sub

    ''' <summary>
    ''' Retrieve a burst data packet. This function calls the lower level implementation, the post-processes the
    ''' data packet to ensure that only the register data is contained
    ''' </summary>
    ''' <returns></returns>
    Public Function GetBufferedStreamDataPacket() As UShort() Implements IBufferedStreamProducer.GetBufferedStreamDataPacket
        Dim rawPacket As UShort() = m_buffProducer.GetBufferedStreamDataPacket()
        Dim processedPacked As New List(Of UShort)
        Dim i As Integer
        'first run?
        If m_firstPacket Then
            m_firstPacket = False
            If m_burstSetupRequired Then
                'trash packet
                Return Nothing
            End If
        End If

        'Did we somehow get a null packet?
        If IsNothing(rawPacket) Then
            Return Nothing
        End If

        'process packet
        Select Case m_Device
            Case BurstDevice.ADIS1655x
                'ADIS1655x just return whole packet
                processedPacked = rawPacket.ToList()
            Case BurstDevice.ADIS1649x, BurstDevice.ADIS1654x
                'Search for sync word start
                i = 0
                While (i < rawPacket.Length) And (rawPacket(i) <> m_burstSyncWord)
                    i += 1
                End While
                'go past sync word(s)
                While (i < rawPacket.Length) And (rawPacket(i) = m_burstSyncWord)
                    i += 1
                End While
                'add payload
                While (i < rawPacket.Length)
                    processedPacked.Add(rawPacket(i))
                    i += 1
                End While
            Case Else
                'remove first two bytes
                processedPacked = rawPacket.ToList()
                processedPacked.RemoveAt(0)
        End Select
        Return processedPacked.ToArray()
    End Function

    ''' <summary>
    ''' Wrapper
    ''' </summary>
    ''' <param name="regList"></param>
    ''' <param name="u16data"></param>
    ''' <returns></returns>
    Public Function ConvertReadDataToU32(regList As IEnumerable(Of RegClass), u16data As IEnumerable(Of UShort)) As UInteger() Implements IBufferedStreamProducer.ConvertReadDataToU32
        Return m_buffProducer.ConvertReadDataToU32(regList, u16data)
    End Function

    ''' <summary>
    ''' Wrapper
    ''' </summary>
    ''' <param name="regList"></param>
    ''' <param name="uintData"></param>
    ''' <returns></returns>
    Public Function ScaleRegData(regList As IEnumerable(Of RegClass), uintData As IEnumerable(Of UInteger)) As Double() Implements IBufferedStreamProducer.ScaleRegData
        Return m_buffProducer.ScaleRegData(regList, uintData)
    End Function

    ''' <summary>
    ''' Configure the DUT control registers based on the selected burst read mode
    ''' </summary>
    Private Sub ConfigureDUTForBurst()
        Dim readVal As UInteger
        Select Case m_Device
            Case BurstDevice.ADIS1654x
                'delta vs inertial is bit 8 of CONFIG
                readVal = m_Dut.ReadUnsigned(m_RegMap("CONFIG"))
                If BurstInertialData Then
                    readVal = readVal And &HFEFF
                    m_burstSyncWord = &HA5A5
                Else
                    readVal = readVal Or &H100
                    m_burstSyncWord = &HC3C3
                End If
                m_Dut.WriteUnsigned(m_RegMap("CONFIG"), readVal)
                Threading.Thread.Sleep(10)
            Case BurstDevice.ADIS1650x
                'delta vs inertial is bit 8 of MSC_CTRL, 32-bit is bit 9
                readVal = m_Dut.ReadUnsigned(m_RegMap("MSC_CTRL"))
                If BurstInertialData Then
                    readVal = readVal And &HFEFF
                Else
                    readVal = readVal Or &H100
                End If
                If Burst16Bit Then
                    readVal = readVal And &HFDFF
                Else
                    readVal = readVal Or &H200
                End If
                m_Dut.WriteUnsigned(m_RegMap("MSC_CTRL"), readVal)
                Threading.Thread.Sleep(10)
            Case BurstDevice.ADIS1644x
                'CRC enable is bit4 of MSC_CTRL
                readVal = m_Dut.ReadUnsigned(m_RegMap("MSC_CTRL"))
                If BurstChecksum Then
                    readVal = readVal Or &H10
                Else
                    readVal = readVal And &HFFEF
                End If
                m_Dut.WriteUnsigned(m_RegMap("MSC_CTRL"), readVal)
                Threading.Thread.Sleep(10)
        End Select
    End Sub

    ''' <summary>
    ''' Configure FX3 based on the selected burst transaction
    ''' </summary>
    Private Sub ConfigureFX3ForBurst()
        Dim burstCommand As New List(Of Byte)
        Dim burstLen As UInteger
        'return full burst data in all cases
        m_FX3.StripBurstTriggerWord = False
        'dummy trigger register
        m_FX3.TriggerReg = New RegClass With {.Address = 0, .Page = 0}
        'build burst request
        If m_Device = BurstDevice.ADIS1655x Then
            'burst header depends on delta vs inertial
            If BurstInertialData Then
                burstCommand.Add(0)
                burstCommand.Add(0)
                burstCommand.Add(&HA)
                burstCommand.Add(0)
            Else
                burstCommand.Add(0)
                burstCommand.Add(0)
                burstCommand.Add(&HB)
                burstCommand.Add(&H1)
            End If
        Else
            'burst header is just address of burst trigger register
            burstCommand.Add(m_RegMap.BurstReadTrig.Address)
            burstCommand.Add(0)
        End If
        m_FX3.BurstMOSIData = burstCommand.ToArray()
        'burst length is length of payload (regs) plus padding
        burstLen = m_paddingBytes
        For Each reg In BurstRegisters
            burstLen += reg.NumBytes
        Next
        m_FX3.BurstByteCount = burstLen

        'enable burst mode
        m_FX3.SetupBurstMode()
    End Sub

    ''' <summary>
    ''' Update the burst registers based on the selected configuration.
    ''' 
    ''' I'm not in love with how this is being done, but here we are. This
    ''' method relies on the burst inertial data being transmitted as
    ''' X/Y/Z gyro then X/Y/Z accel, which is the case for all IMU products
    ''' </summary>
    Private Sub UpdateBurstRegs()
        Dim i As Integer
        Dim dataType As String
        Dim numBytes As Integer
        Dim done As Boolean
        Dim label As String

        'initially clear
        m_regs.Clear()

        'Is there a burst header?
        If Not IsNothing(m_burstHeader) Then
            m_regs.Add(m_burstHeader)
        End If

        'add registers from regmap until we hit inertial data
        i = 0
        For Each reg In m_RegMap.BurstReadList
            If Not (reg.Label.Contains("GYR") Or reg.Label.Contains("ACC")) Then
                m_regs.Add(reg)
                i += 1
            Else
                Exit For
            End If
        Next
        'move index past inertial regs
        done = False
        While Not done
            If i < m_RegMap.BurstReadList.Count Then
                label = m_RegMap.BurstReadList(i).Label
                done = Not (label.Contains("GYR") Or label.Contains("ACC"))
            Else
                done = True
            End If
            If Not done Then i += 1
        End While

        'now we add the 6 inertial output channels based on selected config
        If Burst16Bit Then
            numBytes = 2
        Else
            numBytes = 4
        End If
        'gyro data first
        If BurstInertialData Then
            dataType = "GYR"
        Else
            dataType = "ANG"
        End If
        m_regs.Add(ParseRegMap("X", dataType, numBytes))
        m_regs.Add(ParseRegMap("Y", dataType, numBytes))
        m_regs.Add(ParseRegMap("Z", dataType, numBytes))
        'accel data second
        If BurstInertialData Then
            dataType = "ACC"
        Else
            dataType = "VEL"
        End If
        m_regs.Add(ParseRegMap("X", dataType, numBytes))
        m_regs.Add(ParseRegMap("Y", dataType, numBytes))
        m_regs.Add(ParseRegMap("Z", dataType, numBytes))

        'add remainder of registers in list
        While i < m_RegMap.BurstReadList.Count
            m_regs.Add(m_RegMap.BurstReadList(i))
            i += 1
        End While

        'add checksum reg, if enabled
        If Not IsNothing(m_checksum) And BurstChecksum Then
            m_regs.Add(m_checksum)
        End If

    End Sub

    Private Function ParseRegMap(axis As String, type As String, numBytes As Integer) As RegClass
        For Each reg In m_RegMap
            If reg.Label.Contains(axis) And reg.Label.Contains(type) And reg.NumBytes = numBytes Then Return reg
        Next
        Return New RegClass With {.Label = "ERROR", .NumBytes = numBytes, .ReadLen = 8 * numBytes}
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

            'no padding bytes
            m_paddingBytes = 0

            '32-bit burst header included
            m_burstHeader = New RegClass With {.Label = "BURST_HEADER", .ReadLen = 32, .NumBytes = 4}

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

            '6 padding bytes
            m_paddingBytes = 6

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

            '2 padding bytes
            m_paddingBytes = 2

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

            '4 padding bytes
            m_paddingBytes = 4

            'Sync data is fixed
            m_burstSyncWord = &HA5A5

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

            '2 padding bytes
            m_paddingBytes = 2

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

            '2 padding bytes
            m_paddingBytes = 2

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

            '2 padding bytes
            m_paddingBytes = 2

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

            '2 padding bytes
            m_paddingBytes = 2

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
