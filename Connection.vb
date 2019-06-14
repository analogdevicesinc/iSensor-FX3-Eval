Imports FX3Interface
Imports RegMapClasses
Imports adisInterface

Public Class Connection
    Public Dut As AdcmInterfaceBase
    Public WithEvents FX3 As FX3Connection
    Public RegMap As RegMapCollection

    'Define events to throw
    Event UnexpectedDisconnect(ByVal FX3SerialNum As String)
    Event DisconnectFinished(ByVal FX3SerialNum As String, ByVal DisconnectTime As Integer)

    ''' <summary>
    ''' Used to throw event up to the GUI, not recommended in general
    ''' </summary>
    Public Sub DisconnectHandler(FX3SerialNumber As String) Handles FX3.UnexpectedDisconnect
        RaiseEvent UnexpectedDisconnect(FX3SerialNumber)
    End Sub

    Public Sub ReconnectHandler(ByVal FX3SerialNum As String, ByVal DisconnectTime As Integer) Handles FX3.DisconnectFinished
        RaiseEvent DisconnectFinished(FX3SerialNum, DisconnectTime)
    End Sub

End Class