Public Class Tasks

    Public Sub RunTask()
        RunProcess()
    End Sub

    Private Sub LockDDRs()
        'load ddrs from database
        Console.WriteLine("************************************************")
        Console.WriteLine("Task Lock DDR's more than 2 days")
        Dim ddrs As New DDRReportToolCore.com.entities.DDRControl_Collection
        Dim _ADODDR As New DDRReportToolCore.com.ADO.ADODDR
        _ADODDR.GetDDRControlHeader(ddrs)
        For Each item As DDRReportToolCore.com.entities.DDRControl In ddrs.Items
            'Console.WriteLine(item.ReportDate.ToString("yyyy-MM-dd") & " <=" & DateAdd(DateInterval.Day, -2, Date.Now).ToString("yyyy-MM-dd"))
            If item.ReportDate <= DateAdd(DateInterval.Day, -2, Date.Now) And item.Lock = False Then
                Console.WriteLine("Locking DDR Num." & item.DDRID)
                _ADODDR.LockReprot(item.DDRID)
            End If

        Next
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
                        LockDDRs()
                    End If
                End If
                '
            End If
        Next
    End Sub

End Class
