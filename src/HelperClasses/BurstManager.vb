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

''' <summary>
''' Enum for all IMU products which support burst read
''' </summary>
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

''' <summary>
''' Wrapper class to manage IMU burst read transactions. This class provides an interface
''' to set up the properties of the burst read, based on the capability of the connected IMU.
''' When starting a burst, this class configures the DUT and FX3 based on the selected burst
''' read format. Received data is parsed based on the specific burst SPI protocol of the 
''' connected IMU.
''' </summary>
Public Class BurstManager
    Implements IBufferedStreamProducer, IStreamEventProducer

    ' Event wrappers for FX3
    Public Event NewBufferAvailable As IStreamEventProducer.NewBufferAvailableEventHandler Implements IStreamEventProducer.NewBufferAvailable
    Public Event StreamFinished As IStreamEventProducer.StreamFinishedEventHandler Implements IStreamEventProducer.StreamFinished

    ' FX3 Board, DUT, and register map (passed in constructor)
    Private WithEvents m_FX3 As FX3Connection
    Private m_DUT As IDutInterface
    Private m_regMap As RegMapCollection

    ''' <summary>
    ''' Connected IMU product (w/ burst)
    ''' </summary>
    Private m_device As BurstDevice

    ''' <summary>
    ''' Buffered steam producer
    ''' </summary>
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

    ''' <summary>
    ''' Expected size of the burst payload, in bytes. Used for input validation when parsing up to sync word
    ''' </summary>
    Private m_burstPayloadBytes As Integer

    Public Sub New(Dut As IDutInterface, FX3 As FX3Connection, Regmap As RegMapCollection, Personality As String)
        m_regMap = Regmap
        m_DUT = Dut
        m_FX3 = FX3
        m_buffProducer = New adbfInterface(m_FX3, Nothing)
        m_burstRegs = Regmap.BurstReadList
        LoadDeviceInfo(True, Personality)
    End Sub

    ''' <summary>
    ''' The IMU being interfaced to
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Device As BurstDevice
        Get
            Return m_device
        End Get
    End Property

    ''' <summary>
    ''' Error string for if a burst packet parsing error occurs. 
    ''' Empty string if no error
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ParsingError As String
        Get
            Return m_parsingError
        End Get
    End Property
    Private m_parsingError As String

    ''' <summary>
    ''' Does the connected IMU support a configurable burst word size? 16-bit vs 32-bit
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConfigurableWordSize As Boolean
        Get
            Return m_configurableWordSize
        End Get
    End Property
    Private m_configurableWordSize As Boolean

    ''' <summary>
    ''' Does the connected IMU support configurable burst data types? Delta vs inertial
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConfigurableData As Boolean
        Get
            Return m_configurableData
        End Get
    End Property
    Private m_configurableData As Boolean

    ''' <summary>
    ''' Does the connected IMU support an optional burst checksum?
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property ConfigurableChecksum As Boolean
        Get
            Return m_configurableChecksum
        End Get
    End Property
    Private m_configurableChecksum As Boolean

    ''' <summary>
    ''' Select 16-bit burst data or 32-bit burst data
    ''' </summary>
    ''' <returns></returns>
    Public Property Burst16Bit As Boolean
        Get
            Return m_burst16Bit
        End Get
        Set(value As Boolean)
            If ConfigurableWordSize Then
                m_burst16Bit = value
            End If
            UpdateBurstRegs()
        End Set
    End Property
    Private m_burst16Bit As Boolean

    ''' <summary>
    ''' Select inertial burst data or delta burst data
    ''' </summary>
    ''' <returns></returns>
    Public Property BurstInertialData As Boolean
        Get
            Return m_burstInertialData
        End Get
        Set(value As Boolean)
            If ConfigurableData Then
                m_burstInertialData = value
            End If
            UpdateBurstRegs()
        End Set
    End Property
    Private m_burstInertialData As Boolean

    ''' <summary>
    ''' Select checksum enabled or disabled
    ''' </summary>
    ''' <returns></returns>
    Public Property BurstChecksum As Boolean
        Get
            Return m_burstChecksum
        End Get
        Set(value As Boolean)
            If ConfigurableChecksum Then
                m_burstChecksum = value
            End If
            UpdateBurstRegs()
        End Set
    End Property
    Private m_burstChecksum As Boolean

    ''' <summary>
    ''' Registers contained in the burst read
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property BurstRegisters As List(Of RegClass)
        Get
            Return m_burstRegs
        End Get
    End Property
    Private m_burstRegs As List(Of RegClass)

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
        'Clear burst packet parsing error string
        m_parsingError = ""
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
        Dim processedPacket As New List(Of UShort)
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
        Select Case m_device
            Case BurstDevice.ADIS1655x
                'ADIS1655x just return whole packet
                processedPacket = rawPacket.ToList()
            Case BurstDevice.ADIS1649x, BurstDevice.ADIS1654x
                i = 0
                ' I thought .NET used lazy AND evaluation, but apparently not. Even if first
                ' condition is false still evaluates second. Hence try-catch for case where sync 
                ' word is not found, instead of while ((i < len)&&(i != burst sync));
                Try
                    'Search for sync word start
                    While rawPacket(i) <> m_burstSyncWord
                        i += 1
                    End While
                    'go past sync word(s)
                    While rawPacket(i) = m_burstSyncWord
                        i += 1
                    End While
                Catch ex As IndexOutOfRangeException
                    If m_parsingError = "" Then m_parsingError = "Sync word not found!"
                End Try
                'add payload
                While (i < rawPacket.Length)
                    processedPacket.Add(rawPacket(i))
                    i += 1
                End While
            Case Else
                'remove first two bytes
                processedPacket = rawPacket.ToList()
                processedPacket.RemoveAt(0)
        End Select
        If (2 * processedPacket.Count() < m_burstPayloadBytes) Then
            'Some parsing error happened... pad to expected length with zeros
            While (2 * processedPacket.Count()) < m_burstPayloadBytes
                processedPacket.Add(0)
            End While
            If m_parsingError = "" Then m_parsingError = "Invalid burst payload length!"
        End If
        Return processedPacket.ToArray()
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
        Select Case m_device
            Case BurstDevice.ADIS1654x
                'delta vs inertial is bit 8 of CONFIG
                readVal = m_DUT.ReadUnsigned(m_regMap("CONFIG"))
                If BurstInertialData Then
                    readVal = readVal And &HFEFF
                    m_burstSyncWord = &HA5A5
                Else
                    readVal = readVal Or &H100
                    m_burstSyncWord = &HC3C3
                End If
                m_DUT.WriteUnsigned(m_regMap("CONFIG"), readVal)
                Threading.Thread.Sleep(10)
            Case BurstDevice.ADIS1650x
                'delta vs inertial is bit 8 of MSC_CTRL, 32-bit is bit 9
                readVal = m_DUT.ReadUnsigned(m_regMap("MSC_CTRL"))
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
                m_DUT.WriteUnsigned(m_regMap("MSC_CTRL"), readVal)
                Threading.Thread.Sleep(10)
            Case BurstDevice.ADIS1644x
                'CRC enable is bit4 of MSC_CTRL
                readVal = m_DUT.ReadUnsigned(m_regMap("MSC_CTRL"))
                If BurstChecksum Then
                    readVal = readVal Or &H10
                Else
                    readVal = readVal And &HFFEF
                End If
                m_DUT.WriteUnsigned(m_regMap("MSC_CTRL"), readVal)
                Threading.Thread.Sleep(10)
        End Select
    End Sub

    ''' <summary>
    ''' Configure FX3 based on the selected burst transaction
    ''' </summary>
    Private Sub ConfigureFX3ForBurst()
        Dim burstCommand As New List(Of Byte)
        'return full burst data in all cases
        m_FX3.StripBurstTriggerWord = False
        'dummy trigger register
        m_FX3.TriggerReg = New RegClass With {.Address = 0, .Page = 0}
        'build burst request
        If m_device = BurstDevice.ADIS1655x Then
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
            burstCommand.Add(m_regMap.BurstReadTrig.Address)
            burstCommand.Add(0)
        End If
        m_FX3.BurstMOSIData = burstCommand.ToArray()
        'burst length is length of payload (regs) plus padding
        m_burstPayloadBytes = 0
        For Each reg In BurstRegisters
            m_burstPayloadBytes += reg.NumBytes
        Next
        m_FX3.BurstByteCount = m_burstPayloadBytes + m_paddingBytes

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
        m_burstRegs.Clear()

        'Is there a burst header?
        If Not IsNothing(m_burstHeader) Then
            m_burstRegs.Add(m_burstHeader)
        End If

        'add registers from regmap until we hit inertial data
        i = 0
        For Each reg In m_regMap.BurstReadList
            If Not (reg.Label.Contains("GYR") Or reg.Label.Contains("ACC")) Then
                m_burstRegs.Add(reg)
                i += 1
            Else
                Exit For
            End If
        Next
        'move index past inertial regs
        done = False
        While Not done
            If i < m_regMap.BurstReadList.Count Then
                label = m_regMap.BurstReadList(i).Label
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
        m_burstRegs.Add(ParseRegMap("X", dataType, numBytes))
        m_burstRegs.Add(ParseRegMap("Y", dataType, numBytes))
        m_burstRegs.Add(ParseRegMap("Z", dataType, numBytes))
        'accel data second
        If BurstInertialData Then
            dataType = "ACC"
        Else
            dataType = "VEL"
        End If
        m_burstRegs.Add(ParseRegMap("X", dataType, numBytes))
        m_burstRegs.Add(ParseRegMap("Y", dataType, numBytes))
        m_burstRegs.Add(ParseRegMap("Z", dataType, numBytes))

        'add remainder of registers in list
        While i < m_regMap.BurstReadList.Count
            m_burstRegs.Add(m_regMap.BurstReadList(i))
            i += 1
        End While

        'add checksum reg, if enabled
        If Not IsNothing(m_checksum) And BurstChecksum Then
            m_burstRegs.Add(m_checksum)
        End If

    End Sub

    ''' <summary>
    ''' Parse the register map to find a specific output register (accel or gyro)
    ''' </summary>
    ''' <param name="axis">The axis to search for (x, y, z)</param>
    ''' <param name="type">The data type (in register label)</param>
    ''' <param name="numBytes">The size of the register, in bytes</param>
    ''' <returns>Register matching provided axis, type, and size. Dummy register if not found</returns>
    Private Function ParseRegMap(axis As String, type As String, numBytes As Integer) As RegClass
        For Each reg In m_regMap
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
        m_device = BurstDevice.Unknown
        'check personality
        If personality.Contains("1655") Then
            m_device = BurstDevice.ADIS1655x

            'Fixed 32-bit burst
            m_configurableWordSize = False
            m_burst16Bit = False

            'selectable delta vs inertial
            m_configurableData = True
            m_burstInertialData = True

            'CRC included (32-bit), not configurable
            m_configurableChecksum = False
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 32, .NumBytes = 4}

            'Burst requires setup command
            m_burstSetupRequired = True

            'no padding bytes
            m_paddingBytes = 0

            '32-bit burst header included
            m_burstHeader = New RegClass With {.Label = "BURST_HEADER", .ReadLen = 32, .NumBytes = 4}

        ElseIf personality.Contains("1654") Then
            m_device = BurstDevice.ADIS1654x

            'Fixed 32-bit burst
            m_configurableWordSize = False
            m_burst16Bit = False

            'selectable delta vs inertial
            m_configurableData = True
            m_burstInertialData = True

            'CRC included (32-bit), not configurable
            m_configurableChecksum = False
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 32, .NumBytes = 4}

            'Burst does not require setup command
            m_burstSetupRequired = False

            '10 padding bytes to allow for fast SCLK
            m_paddingBytes = 10

        ElseIf personality.Contains("1650") Then
            m_device = BurstDevice.ADIS1650x

            'Configurable 32-bit or 16-bit burst
            m_configurableWordSize = True
            m_burst16Bit = True

            'selectable delta vs inertial
            m_configurableData = True
            m_burstInertialData = True

            'Checksum included (16-bit), not configurable
            m_configurableChecksum = False
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

            '2 padding bytes
            m_paddingBytes = 2

        ElseIf personality.Contains("1649") Then
            m_device = BurstDevice.ADIS1649x

            'Fixed 32-bit burst
            m_configurableWordSize = False
            m_burst16Bit = False

            'Only inertial
            m_configurableData = False
            m_burstInertialData = True

            'CRC included (32-bit), not configurable
            m_configurableChecksum = False
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 32, .NumBytes = 4}

            'Burst does not require setup command
            m_burstSetupRequired = False

            '4 padding bytes
            m_paddingBytes = 4

            'Sync data is fixed
            m_burstSyncWord = &HA5A5

        ElseIf personality.Contains("1647") Then
            m_device = BurstDevice.ADIS1647x

            'Fixed 16-bit burst
            m_configurableWordSize = False
            m_burst16Bit = True

            'Only inertial
            m_configurableData = False
            m_burstInertialData = True

            'Checksum included (16-bit), not configurable
            m_configurableChecksum = False
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

            '2 padding bytes
            m_paddingBytes = 2

        ElseIf personality.Contains("1646") Then
            m_device = BurstDevice.ADIS1646x

            'Fixed 16-bit burst
            m_configurableWordSize = False
            m_burst16Bit = True

            'Only inertial
            m_configurableData = False
            m_burstInertialData = True

            'Checksum included (16-bit), not configurable
            m_configurableChecksum = False
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

            '2 padding bytes
            m_paddingBytes = 2

        ElseIf personality.Contains("16445") Then
            m_device = BurstDevice.ADIS16445

            'Fixed 16-bit burst
            m_configurableWordSize = False
            m_burst16Bit = True

            'Only inertial
            m_configurableData = False
            m_burstInertialData = True

            'No checksum
            m_configurableChecksum = False
            m_burstChecksum = False

            'Burst does not require setup command
            m_burstSetupRequired = False

            '2 padding bytes
            m_paddingBytes = 2

        ElseIf personality.Contains("1644") Then
            m_device = BurstDevice.ADIS1644x

            'Fixed 16-bit burst
            m_configurableWordSize = False
            m_burst16Bit = True

            'Only inertial
            m_configurableData = False
            m_burstInertialData = True

            'Configurable checksum (16-bit)
            m_configurableChecksum = True
            m_burstChecksum = True
            m_checksum = New RegClass With {.Label = "BURST_CHECKSUM", .ReadLen = 16, .NumBytes = 2}

            'Burst does not require setup command
            m_burstSetupRequired = False

            '2 padding bytes
            m_paddingBytes = 2

        Else
            'either no burst on selected device, or personality not found
            Dim prod_id As UInteger = 0
            Try
                prod_id = m_DUT.ReadUnsigned(m_regMap("PROD_ID"))
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
