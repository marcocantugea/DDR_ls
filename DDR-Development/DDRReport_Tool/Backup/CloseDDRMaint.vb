Public Class closeddrmaintmode

    Dim startTime As DateTime
    Dim minutestoclose As Integer = 5
    Dim secondstoclose As Integer = 0
    
    Private Sub closeddrmaintmode_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        timercloseapp.Start()
        lbltimetoclose.Text = "0" & minutestoclose & ":0" & secondstoclose
        timercloseapp.Interval = 1000 '1 tick every second
        timercloseapp.Start()
    End Sub

    Private Sub timercloseapp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timercloseapp.Tick
        If secondstoclose = 0 Then
            minutestoclose = minutestoclose - 1
            secondstoclose = 59
        Else
            secondstoclose = secondstoclose - 1
        End If

        If secondstoclose <= 9 Then
            lbltimetoclose.Text = "0" & minutestoclose & ":0" & secondstoclose
        Else
            lbltimetoclose.Text = "0" & minutestoclose & ":" & secondstoclose
        End If

        If minutestoclose = 0 Then
            timercloseapp.Stop()
            Application.Exit()
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        timercloseapp.Stop()
        Application.Exit()

    End Sub
End Class