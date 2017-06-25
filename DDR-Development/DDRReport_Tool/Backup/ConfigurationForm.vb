Imports DDRReportToolCore
Public Class ConfigurationForm
    'This is comment test
    Dim connectionstring As String
    Dim newconnectionstring As String = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source="
    Dim appconfig As New DDRReportToolCore.com.configuration.extras.AppConfigFileSettings

    Private Sub ConfigurationForm_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub ConfigurationForm_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown

        connectionstring = System.Configuration.ConfigurationSettings.AppSettings("DB-DDR")
        Dim val As String()
        val = connectionstring.Split(";")
        Dim path As String
        path = val(1).Substring(12, val(1).Length - 12)
        txtDataBasePath.Text = path
        txtEmailUser.Text = System.Configuration.ConfigurationSettings.AppSettings("EmailUserCredential")
        txtEmailPass.Text = System.Configuration.ConfigurationSettings.AppSettings("EmailPasswordCredential")
        txtEmailServer.Text = System.Configuration.ConfigurationSettings.AppSettings("EmailSMTPHost")
        txtPort.Text = System.Configuration.ConfigurationSettings.AppSettings("EmailSMTPPort")
        txtDDRTemplate.Text = System.Configuration.ConfigurationSettings.AppSettings("ExcelFormatTemplate")
        txtActiTemplate.Text = System.Configuration.ConfigurationSettings.AppSettings("ActivitiesExcelFormatTemplate")
        txtWellName.Text = System.Configuration.ConfigurationSettings.AppSettings("ActiveWellName")
        txtMaintMode.Text = System.Configuration.ConfigurationSettings.AppSettings("MaintenanceMode")
        txtLDAPServer.Text = System.Configuration.ConfigurationSettings.AppSettings("LDAPDIR")
        txtDomain.Text = System.Configuration.ConfigurationSettings.AppSettings("DOMAINUSERS")
        Dim sendnotification As Boolean
        sendnotification = System.Configuration.ConfigurationSettings.AppSettings("SendNotification")
        If sendnotification Then
            CheckBox1.Checked = True
        Else
            CheckBox1.Checked = False
        End If
    End Sub

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        LoginSystem.Show()
        LoginSystem.UsernameTextBox.Text = ""
        LoginSystem.PasswordTextBox.Text = ""
        LoginSystem.UsernameTextBox.Focus()
        Me.Hide()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim conectionstring As String
        conectionstring = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & txtDataBasePath.Text
        appconfig.UpdateAppSettings("DB-DDR", conectionstring)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If BrowseDataBase.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fi As New System.IO.FileInfo(BrowseDataBase.FileName)
            txtDataBasePath.Text = fi.FullName
        End If
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        If DDRTemplate.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fi As New System.IO.FileInfo(DDRTemplate.FileName)
            txtDDRTemplate.Text = fi.FullName
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        If ActivitiesTemplate.ShowDialog = Windows.Forms.DialogResult.OK Then
            Dim fi As New System.IO.FileInfo(ActivitiesTemplate.FileName)
            txtActiTemplate.Text = fi.FullName
        End If
    End Sub

    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        appconfig.UpdateAppSettings("LDAPDIR", txtLDAPServer.Text)
    End Sub

    Private Sub Button13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button13.Click
        appconfig.UpdateAppSettings("DOMAINUSERS", txtDomain.Text)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        appconfig.UpdateAppSettings("EmailUserCredential", txtEmailUser.Text)
        appconfig.UpdateAppSettings("EmailPasswordCredential", txtEmailPass.Text)
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        appconfig.UpdateAppSettings("EmailSMTPHost", txtEmailServer.Text)
        appconfig.UpdateAppSettings("EmailSMTPPort", txtPort.Text)
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        appconfig.UpdateAppSettings("ExcelFormatTemplate", txtDDRTemplate.Text)
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        appconfig.UpdateAppSettings("ActivitiesExcelFormatTemplate", txtActiTemplate.Text)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        appconfig.UpdateAppSettings("ActiveWellName", txtWellName.Text)
    End Sub

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        appconfig.UpdateAppSettings("MaintenanceMode", txtMaintMode.Text)
    End Sub

    Private Sub Button14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button14.Click
        Dim fi As New System.IO.FileInfo(txtDataBasePath.Text)
        Process.Start("explorer.exe", fi.DirectoryName)
    End Sub

    Private Sub Button15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button15.Click
        Dim fi As New System.IO.FileInfo(txtDDRTemplate.Text)
        Process.Start("explorer.exe", fi.DirectoryName)
    End Sub

    Private Sub Button16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button16.Click
        Dim fi As New System.IO.FileInfo(txtActiTemplate.Text)
        Process.Start("explorer.exe", fi.DirectoryName)
    End Sub

    Private Sub Button17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button17.Click
        Try
            Dim ladp As New com.security.LDAP_Auth(txtLDAPServer.Text)
            If ladp.IsAuthenticated(txtDomain.Text, InputBox("User", "User Domain"), InputBox("Password", "Password Domain")) Then
                MsgBox("Connection Sucessfully", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Error on connection")
        End Try
    End Sub

    Private Sub Button18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button18.Click
        Button3_Click(Nothing, Nothing)
        Button4_Click(Nothing, Nothing)

        Dim mailcollection As New com.Notifier.Email.EmailObjCollection
        Dim messageem As com.Notifier.Email.EmailObj
        messageem = New com.Notifier.Email.EmailObj
        messageem.Body = "This is a test message"
        messageem.eTo = InputBox("email TO", "Testing email configuration")
        messageem.From = InputBox("email FROM", "Testing email configuration")
        messageem.HTMLBody = False
        messageem.Subject = "This is a test message"
        mailcollection.Add(messageem)

        Dim emailsender As New com.Notifier.Email.EmailSender

        Try
            emailsender.SendEmails(mailcollection)
            MsgBox("Notification sent.", MsgBoxStyle.Information, "Email sent successfully")
        Catch ex As Exception
            MsgBox("error to send the notification : " & ex.Message.ToString, MsgBoxStyle.Critical, "Error Sending email")
        End Try
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            appconfig.UpdateAppSettings("SendNotification", "true")
        Else
            appconfig.UpdateAppSettings("SendNotification", "false")
        End If
    End Sub
End Class