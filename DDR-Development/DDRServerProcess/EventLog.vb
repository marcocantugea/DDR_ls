Imports System.Diagnostics


Public Class EventLog

    Protected aLog As System.Diagnostics.EventLog
    Protected DDRLog As New System.Diagnostics.EventLog

    Public Sub New()
        If Not System.Diagnostics.EventLog.SourceExists("DDRServiceLog") Then
            System.Diagnostics.EventLog.CreateEventSource("DDRServerProcess", "DDRServiceLog")
        End If
        DDRLog.Source = "DDRServerProcess"
        DDRLog.Log = "DDRServiceLog"
    End Sub

    Protected Sub WriteLog(ByVal msg As String, ByVal ErrorType As System.Diagnostics.EventLogEntryType)
        DDRLog.WriteEntry(msg, ErrorType)
    End Sub

End Class
