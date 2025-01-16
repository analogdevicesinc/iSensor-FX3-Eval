'Copyright (c) 2025 Analog Devices, Inc. All Rights Reserved.
'This software is proprietary to Analog Devices, Inc. and its licensors.
'
'File:          Logger.vb
'Author:        Alex Nolan (alex.nolan@analog.com)
'Description:   Async register logging application for ADIS evaluation software

Imports System.Collections.Concurrent
Imports System.IO
Imports System.Threading
Imports System.Timers
Imports System.ComponentModel
Imports System.Text
Imports RegMapClasses
Imports adisInterface

Enum FileCommand
    CreateFile = 0
    WriteData = 1
    FinalizeFile = 2
    WriteCompleteFile = 3
End Enum

Public Class Logger : Implements IDisposable

#Region "Private Members"

    'Track if stream is running
    Private m_StreamRunning As Boolean

    'Stream event producer
    Private WithEvents m_StreamEvents As IStreamEventProducer

    'stream data producer
    Private m_StreamProducer As adisInterface.IBufferedStreamProducer

    'Data queue (thread safe)
    Private m_DataQueue As ConcurrentQueue(Of BufferMetadata)

    'Buffer count
    Private m_BufferCount As Integer

    'Buffers since the last write command was issued
    Private m_BuffersSinceWrite As Integer

    'File write thread
    Private m_WriteThread As Thread

    'File write thread command queue
    Private m_CommandQueue As BlockingCollection(Of FileCommand)

    'Event timer for checking timeout
    Private m_EventTimer As System.Timers.Timer

    'Track progress (0 - 100)
    Private m_Progress As Integer

    'Track if current stream has been finalized
    Private m_StreamFinalized As Boolean

    'Background worker for the stream
    Private WithEvents m_BackgroundWorker As BackgroundWorker

    'Track if stream has been canceled
    Private m_DutStreamRunning As Boolean

    'Track stream running time
    Private m_StreamTimer As Stopwatch

#End Region

#Region "Public Properties"

    ''' <summary>
    ''' Enable or disable appending sample timestamps to data file
    ''' </summary>
    ''' <returns></returns>
    Public Property LogTimestamps As Boolean
        Get
            Return m_logTimestamps
        End Get
        Set(value As Boolean)
            m_logTimestamps = value
        End Set
    End Property
    Private m_logTimestamps As Boolean

    ''' <summary>
    ''' Enable or disable scaling data to native units
    ''' </summary>
    ''' <returns></returns>
    Public Property ScaleData As Boolean
        Get
            Return m_scaleData
        End Get
        Set(value As Boolean)
            m_scaleData = value
        End Set
    End Property
    Private m_scaleData As Boolean

    ''' <summary>
    ''' Property to get/set if the lower word is returned first for a 32-bit register
    ''' </summary>
    ''' <returns></returns>
    Public Property LowerWordFirst As Boolean
        Get
            Return m_lowerFirst
        End Get
        Set(value As Boolean)
            m_lowerFirst = value
        End Set
    End Property
    Private m_lowerFirst As Boolean

    ''' <summary>
    ''' The total number of buffers to read in the stream. Each buffer is the reglist read numcaptures times
    ''' </summary>
    ''' <returns></returns>
    Public Property Buffers As UInteger
        Get
            Return m_Buffers
        End Get
        Set(value As UInteger)
            If value < 1 Then
                Throw New ArgumentException("ERROR: Buffers must be at least 1")
            End If
            m_Buffers = value
        End Set
    End Property
    Private m_Buffers As UInteger

    ''' <summary>
    ''' Number of captures of the reglist to perform in a single buffer.
    ''' </summary>
    ''' <returns></returns>
    Public Property Captures As UInteger
        Get
            Return m_Captures
        End Get
        Set(value As UInteger)
            m_Captures = value
        End Set
    End Property
    Private m_Captures As UInteger

    ''' <summary>
    ''' The number of buffers to accumulate before a file write operation.
    ''' </summary>
    ''' <returns></returns>
    Public Property BuffersPerWrite As UInteger
        Get
            Return m_BuffersPerWrite
        End Get
        Set(value As UInteger)
            If value < 1 Then
                Throw New ArgumentException("ERROR: Buffers per write must be at least 1")
            End If
            m_BuffersPerWrite = value
        End Set
    End Property
    Private m_BuffersPerWrite As UInteger

    ''' <summary>
    ''' Number of data rows in a single file.
    ''' </summary>
    ''' <returns></returns>
    Public Property FileMaxDataRows As UInteger
        Get
            Return m_LinesPerFile
        End Get
        Set(value As UInteger)
            If value < 1 Then
                Throw New ArgumentException("ERROR: Must have at least one buffer per file")
            End If
            m_LinesPerFile = value
        End Set
    End Property
    Private m_LinesPerFile As UInteger

    ''' <summary>
    ''' Timeout period before stream cancellation if a buffer is not recieved.
    ''' </summary>
    ''' <returns></returns>
    Public Property BufferTimeoutSeconds As UInteger
        Get
            Return m_BufferTimeoutSeconds
        End Get
        Set(value As UInteger)
            If value < 1 Then
                Throw New ArgumentException("ERROR: Timeout must be at least one second")
            End If
            m_BufferTimeoutSeconds = value
            m_EventTimer.Interval = value * 1000
        End Set
    End Property
    Private m_BufferTimeoutSeconds As UInteger

    ''' <summary>
    ''' File base name. File numbers will be appended after this.
    ''' </summary>
    ''' <returns></returns>
    Public Property FileBaseName As String
        Get
            Return m_FileBaseName
        End Get
        Set(value As String)
            m_FileBaseName = value
        End Set
    End Property
    Private m_FileBaseName As String

    ''' <summary>
    ''' Base path for the output files
    ''' </summary>
    ''' <returns></returns>
    Public Property FilePath As String
        Get
            Return m_FilePath
        End Get
        Set(value As String)
            m_FilePath = value
            'Ensure that the path ends with '\'
            If Not m_FilePath.Last() = "\" Then m_FilePath = m_FilePath + "\"
        End Set
    End Property
    Private m_FilePath As String

    ''' <summary>
    ''' File extension. Defaults to "csv"
    ''' </summary>
    ''' <returns></returns>
    Public Property FileExtension As String
        Get
            Return m_FileExtension
        End Get
        Set(value As String)
            m_FileExtension = value
            'strip . if included
            m_FileExtension = m_FileExtension.Replace(".", "")
        End Set
    End Property
    Private m_FileExtension As String

    ''' <summary>
    ''' Register list to stream from. Can be on multiple pages
    ''' </summary>
    ''' <returns></returns>
    Public Property RegList As IEnumerable(Of RegClass)
        Get
            Return m_RegList
        End Get
        Set(value As IEnumerable(Of RegClass))
            m_RegList = value
        End Set
    End Property
    Private m_RegList As IEnumerable(Of RegClass)

    ''' <summary>
    ''' String to seperate data elements. Defaults to ','
    ''' </summary>
    ''' <returns></returns>
    Public Property DataSeparator As String
        Get
            Return m_DataSeparator
        End Get
        Set(value As String)
            m_DataSeparator = value
        End Set
    End Property
    Private m_DataSeparator As String

    ''' <summary>
    ''' Readonly property to check if a stream is currently running.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property Busy As Boolean
        Get
            Return m_StreamRunning Or m_DutStreamRunning
        End Get
    End Property

    ''' <summary>
    ''' Readonly property to check if a timeout has occurred.
    ''' </summary>
    ''' <returns></returns>
    Public ReadOnly Property TimeoutOccurred As Boolean
        Get
            Return m_TimeoutOccurred
        End Get
    End Property
    Private m_TimeoutOccurred As Boolean

#End Region

#Region "Public Events"

    ''' <summary>
    ''' This event is raised when a new progress tick has been made during a stream. Values will be in range (0 - 100)
    ''' </summary>
    ''' <param name="e"></param>
    Public Event ProgressChanged(e As ProgressChangedEventArgs)

    ''' <summary>
    ''' This event is raised when all data is done being written to the disk.
    ''' </summary>
    Public Event RunAsyncCompleted()

#End Region

#Region "Public Functions"

    ''' <summary>
    ''' Constructor, takes stream producer and event producer
    ''' </summary>
    ''' <param name="EventProducer"></param>
    ''' <param name="DataProducer"></param>
    Public Sub New(ByRef EventProducer As IStreamEventProducer, ByRef DataProducer As adisInterface.IBufferedStreamProducer)
        m_StreamProducer = DataProducer
        m_StreamEvents = EventProducer
        LoadDefaultValues()
    End Sub

    ''' <summary>
    ''' Starts an asynchronous stream
    ''' </summary>
    ''' <returns>If the stream start was successful. A stream cannot be started until previous stream has been terminated</returns>
    Public Function RunAsync() As Boolean

        'Exit if stream is already running (return false)
        If m_StreamRunning Then Return False

        'Reset stream state variables
        ResetStateVariables()

        'Raise initial progress changed event
        RaiseEvent ProgressChanged(New ProgressChangedEventArgs(0, Nothing))

        'set stream running flag
        m_StreamRunning = True

        'Create file write thread and start
        m_WriteThread = New Thread(AddressOf WriteThreadWorker)
        m_WriteThread.IsBackground = True
        m_WriteThread.Start()

        'send initial create file command
        m_CommandQueue.Add(FileCommand.CreateFile)

        'Start the buffered stream
        m_StreamProducer.StartBufferedStream(m_RegList, m_Captures, m_Buffers, m_BufferTimeoutSeconds, m_BackgroundWorker)
        m_DutStreamRunning = True

        'return true
        Return True

    End Function

    ''' <summary>
    ''' Cancels a currently running stream.
    ''' </summary>
    Public Sub CancelAsync()

        'If stream running then perform cancel
        If m_StreamRunning Then
            'Send cancel command to BufferedStreamProducer
            m_StreamEvents.CancelStreamAsync()
            'dequeue any remaining data
            NewDataHandler(0)
            'stop event handler from queueing more data
            m_StreamFinalized = True
            'send finalize command
            m_CommandQueue.Add(FileCommand.FinalizeFile)
        End If

    End Sub

    Public Sub Dispose() Implements IDisposable.Dispose
        'dispose of command queue
        If Not IsNothing(m_CommandQueue) Then m_CommandQueue.Dispose()

        'dispose of event timer
        If Not IsNothing(m_EventTimer) Then m_EventTimer.Dispose()
    End Sub

#End Region

#Region "Private Functions"

    ''' <summary>
    ''' Cancels if the timeout occurred
    ''' </summary>
    Private Sub TimeoutCallback()
        m_TimeoutOccurred = True
        CancelAsync()
    End Sub

    Private Sub NewDataHandler(BufferCount As Integer) Handles m_StreamEvents.NewBufferAvailable

        'Exit if finalize sent
        If m_StreamFinalized Then
            Exit Sub
        End If

        'New progress percent
        Dim newProgress As Long
        Dim longBufferCount As Long

        'reset timer
        m_EventTimer.Enabled = False

        'Buffer to dequeue
        Dim buf As UShort()

        'Get the first buffer available
        buf = m_StreamProducer.GetBufferedStreamDataPacket()

        'dequeue all available buffers
        While (Not IsNothing(buf)) And (m_BufferCount < m_Buffers)
            'Enqueue buffer
            m_DataQueue.Enqueue(New BufferMetadata(buf))
            'Increment counters
            Interlocked.Increment(m_BufferCount)
            Interlocked.Increment(m_BuffersSinceWrite)
            'If there is more than the buffers per write data in queue write to file
            If m_BuffersSinceWrite >= m_BuffersPerWrite Then
                m_CommandQueue.Add(FileCommand.WriteData)
                m_BuffersSinceWrite = 0
            End If
            'Get new buffer
            buf = m_StreamProducer.GetBufferedStreamDataPacket()
            'Check progress
            longBufferCount = m_BufferCount
            longBufferCount = longBufferCount * 100
            newProgress = longBufferCount / m_Buffers
            If newProgress <> m_Progress Then
                RaiseEvent ProgressChanged(New ProgressChangedEventArgs(newProgress, Nothing))
                m_Progress = newProgress
            End If
        End While

        'Finalize if the total number of buffers has been read
        If m_BufferCount >= m_Buffers Then
            m_CommandQueue.Add(FileCommand.FinalizeFile)
            m_StreamFinalized = True
        Else
            'Re-enable timeout timer
            m_EventTimer.Enabled = True
        End If

    End Sub

    Private Sub StreamFinished() Handles m_StreamEvents.StreamFinished
        'Raise completion event if the file writer thread is already done
        If Not m_StreamRunning Then
            RaiseEvent RunAsyncCompleted()
        End If
        m_DutStreamRunning = False
    End Sub

    Private Sub WriteThreadWorker()

        Dim writer As StreamWriter = Nothing
        Dim fileCount As Integer = 0
        Dim currentFileLines As Integer = 0
        Dim running As Boolean = True
        Dim command As FileCommand
        Dim buf As BufferMetadata = Nothing
        Dim goodData As Boolean
        Dim buffersWritten As Integer = 0

        While running
            'dequeue command
            command = m_CommandQueue.Take()

            'Perform file IO operation based on the command
            Select Case command
                Case FileCommand.CreateFile 'create new file, called at start
                    writer = CreateFile(fileCount)
                Case FileCommand.WriteData 'write data to current file, create new as needed
                    For writeCount As Integer = 1 To m_BuffersPerWrite
                        'dequeue data
                        goodData = m_DataQueue.TryDequeue(buf)
                        'exit if no items (shouldn't happen)
                        If Not goodData Then Exit For
                        'write line to file
                        writer.Write(BuildLines(buf))
                        buffersWritten += 1
                        'increment counter for current file
                        currentFileLines += m_Captures
                        'Check if new file needed
                        If currentFileLines >= m_LinesPerFile Then
                            writer.Close()
                            fileCount += 1
                            currentFileLines = 0
                            If buffersWritten < m_Buffers Then
                                writer = CreateFile(fileCount)
                            End If
                        End If
                    Next
                Case FileCommand.FinalizeFile 'write remaining data to file
                    While m_DataQueue.Count <> 0 And buffersWritten < m_Buffers
                        'dequeue data
                        goodData = m_DataQueue.TryDequeue(buf)
                        'exit if no items (shouldn't happen)
                        If Not goodData Then Exit While
                        'write line to file
                        writer.Write(BuildLines(buf))
                        buffersWritten += 1
                        'increment counter for current file
                        currentFileLines += m_Captures
                        'Check if new file needed
                        If currentFileLines >= m_LinesPerFile Then
                            writer.Close()
                            fileCount += 1
                            currentFileLines = 0
                            If buffersWritten < m_Buffers Then
                                writer = CreateFile(fileCount)
                            End If
                        End If
                    End While
                    'setting the running flag to false will cause writer thread to exit
                    running = False
                    'close file
                    writer.Close()
                Case FileCommand.WriteCompleteFile
                    writer = CreateFile(fileCount)
                    currentFileLines = 0
                    While m_DataQueue.Count <> 0 And currentFileLines < m_LinesPerFile
                        'dequeue data
                        goodData = m_DataQueue.TryDequeue(buf)
                        'exit if no items (shouldn't happen)
                        If Not goodData Then Exit While
                        'write lines to file
                        writer.Write(BuildLines(buf))
                        buffersWritten += 1
                        'increment counter for current file
                        currentFileLines += m_Captures
                    End While
                    writer.Close()
                    fileCount += 1
            End Select

        End While

        'Set the stream running flag to false
        m_StreamRunning = False

        'raise completion event if the DUT stream is finished
        If Not m_DutStreamRunning Then
            RaiseEvent RunAsyncCompleted()
        End If

    End Sub

    Private Function CreateFile(FileNumber As Integer) As StreamWriter
        Dim writer As StreamWriter = New StreamWriter(GetFileName(FileNumber), True)
        writer.WriteLine(BuildHeader())
        Return writer
    End Function

    Private Function BuildHeader() As String
        Dim header As String = ""
        For Each reg In m_RegList
            header = header + reg.Label + m_DataSeparator
        Next
        If m_logTimestamps Then
            'Add buffer time field
            header += "PACKET_TIME" + m_DataSeparator
            'Add stream duration time
            header += "STREAM_DURATION_MS"
        Else
            'remove last separator
            Return header.Substring(0, header.Length() - m_DataSeparator.Length())
        End If
        Return header
    End Function

    Private Function BuildLines(Buf As BufferMetadata) As String
        'allocate space for string builder (reglist.count * numcaptures * 12 characters per entry should be good)
        Dim sb As New StringBuilder(Buf.Buf.Count() * 12 + 48)
        Dim upper, lower As UShort
        Dim bufIndex As Integer = 0
        'Save values in 64-bit long for both signed and unsigned (32-bit)
        Dim regVal As Long
        'Iterate through all captures
        For captures As Integer = 0 To m_Captures - 1
            For Each reg In m_RegList
                Select Case reg.NumBytes
                    Case 1
                        If reg.IsTwosComp Then
                            'signed byte
                            regVal = SignedConverter.ToSignedByte(Buf.Buf(bufIndex), (reg.Address Mod 2) <> 0)
                        Else
                            'byte
                            regVal = SignedConverter.ToUnsignedByte(Buf.Buf(bufIndex), (reg.Address Mod 2) <> 0)
                        End If
                        bufIndex += 1
                    Case 2
                        If reg.IsTwosComp Then
                            'short
                            regVal = SignedConverter.ToSignedShort(Buf.Buf(bufIndex))
                        Else
                            'ushort
                            regVal = Buf.Buf(bufIndex)
                        End If
                        bufIndex += 1
                    Case 4
                        If LowerWordFirst Then
                            lower = Buf.Buf(bufIndex)
                            upper = Buf.Buf(bufIndex + 1)
                        Else
                            upper = Buf.Buf(bufIndex)
                            lower = Buf.Buf(bufIndex + 1)
                        End If
                        If reg.IsTwosComp Then
                            'signed
                            regVal = SignedConverter.ToSignedInt(upper, lower)
                        Else
                            'unsigned
                            regVal = SignedConverter.ToUnsignedInt(upper, lower)
                        End If

                        bufIndex += 2
                    Case Else
                        'Shouldn't happen
                        Throw New Exception("ERROR: Register should only be 1, 2, or 4 bytes")
                End Select
                'Does value need to be scaled?
                If ScaleData Then
                    Dim scaledVal As Double = (regVal * reg.Scale) + reg.Offset
                    sb.Append(scaledVal.ToString())
                Else
                    sb.Append(regVal.ToString())
                End If
                sb.Append(m_DataSeparator)
            Next
            If m_logTimestamps Then
                'add USB packet time
                sb.Append(Buf.Time.ToString("hh:mm:ss:fff"))
                sb.Append(m_DataSeparator)
                'add stream running time
                sb.Append(m_StreamTimer.ElapsedMilliseconds.ToString())
            Else
                'remove last separator
                sb.Remove(sb.Length - m_DataSeparator.Length, m_DataSeparator.Length)
            End If
            'add a new line
            sb.AppendLine()
        Next
        Return sb.ToString()
    End Function

    Private Function GetFileName(FileNumber As Integer) As String
        Dim fileName As String
        fileName = m_FileBaseName + "_" + FileNumber.ToString("D4") + "." + m_FileExtension
        Return m_FilePath + fileName
    End Function

    Private Sub LoadDefaultValues()

        ResetStateVariables()

        'initialize public property values
        m_DataSeparator = ","
        m_BufferTimeoutSeconds = 10
        m_FileExtension = "csv"
        m_Captures = 1
        m_lowerFirst = True
        m_logTimestamps = False
        m_scaleData = False

        'Set up timeout timer
        m_EventTimer = New Timers.Timer(m_BufferTimeoutSeconds * 1000)
        m_EventTimer.Enabled = False
        AddHandler m_EventTimer.Elapsed, New ElapsedEventHandler(AddressOf TimeoutCallback)

        'Set up stopwatch for logging stream times
        m_StreamTimer = New Stopwatch()

    End Sub

    Private Sub ResetStateVariables()
        'Initialize private members
        m_BufferCount = 0
        m_BuffersSinceWrite = 0
        m_DataQueue = New ConcurrentQueue(Of BufferMetadata)
        m_CommandQueue = New BlockingCollection(Of FileCommand)
        m_TimeoutOccurred = False
        m_Progress = 0
        m_StreamFinalized = False
        m_DutStreamRunning = False

        'start timer
        m_StreamTimer.Restart()
    End Sub

#End Region

End Class
