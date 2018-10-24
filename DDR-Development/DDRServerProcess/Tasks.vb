Public Class Tasks
    Inherits EventLog

    Public Sub RunTask()
        WriteLog("Starting DDR Server Process Tasks", EventLogEntryType.Information)
        RunProcess()
        WriteLog("Finished DDR Server Process Tasks", EventLogEntryType.Information)
    End Sub

    Private Sub LockDDRs()
        'load ddrs from database
        Console.WriteLine("************************************************")
        Console.WriteLine("Task Lock DDR's more than 2 days")
        Dim ddrs As New DDRReportToolCore.com.entities.DDRControl_Collection
        Dim _ADODDR As DDRReportToolCore.com.ADO.ADOMySQLDDR
        Dim lockeddrs As String = ""
        Try
            _ADODDR = New DDRReportToolCore.com.ADO.ADOMySQLDDR
            _ADODDR.GetDDRControlHeader(ddrs)
        Catch ex As Exception
            WriteLog(ex.Message, EventLogEntryType.Error)
        End Try


        For Each item As DDRReportToolCore.com.entities.DDRControl In ddrs.Items
            'Console.WriteLine(item.ReportDate.ToString("yyyy-MM-dd") & " <=" & DateAdd(DateInterval.Day, -2, Date.Now).ToString("yyyy-MM-dd"))
            If item.ReportDate <= DateAdd(DateInterval.Day, -2, Date.Now) And item.Locked = False Then
                Console.WriteLine("Locking DDR Num." & item.DDRID)
                Try
                    _ADODDR.LockReprot(item.DDRID)
                    lockeddrs = lockeddrs & item.DDRID & "; "
                Catch ex As Exception
                    WriteLog(ex.Message, EventLogEntryType.Error)
                End Try
            End If
        Next
        If lockeddrs.Length > 0 Then
            WriteLog("Locked DDR's : " & lockeddrs, EventLogEntryType.Information)
        Else
            WriteLog("No DDRs founds to lock", EventLogEntryType.Information)
        End If

        _ADODDR = Nothing
        ddrs = Nothing
        Console.WriteLine("Task Lock DDR's finishied.")
        Console.WriteLine("************************************************")
    End Sub

    Public Sub RunProcess()
        For Each s As String In System.Configuration.ConfigurationSettings.AppSettings
            If s.Contains("Task-") Then
                If s = "Task-LockDDR" Then
                    If System.Configuration.ConfigurationSettings.AppSettings(s) = "true" Then
                        WriteLog("Performing Task - Lock DDR's older than 2 days", EventLogEntryType.Information)
                        LockDDRs()
                    End If
                End If
                '
            End If
        Next
    End Sub

End Class
