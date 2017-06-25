Imports System.Text
Imports System.Net.Mail
Namespace com.Notifier.Email
    Public Class EmailSender

        Private EmailConfig As New EmailConfigurationObj

        Public Sub SendEmails(ByVal Emails As EmailObjCollection)
            Try
                Dim smtpserver As New SmtpClient()
                smtpserver.Credentials = New Net.NetworkCredential(EmailConfig.UserCredential, EmailConfig.PassCredential)
                smtpserver.Host = EmailConfig.SMTPServerHost
                smtpserver.Port = EmailConfig.SMTPServerPort

                For Each Email As EmailObj In Emails.EmailsObjCollection
                    Dim mail As New MailMessage(Email.From, Email.eTo)
                    'If Email.eTo.Length > -1 Then
                    'For Each s As String In Email.From
                    'Dim from As String()
                    'from(0) = Email.From
                    'mail.To.Add(from(0))
                    'Next
                    'Else
                    'Throw New Exception("No email address was found")
                    'End If
                    mail.Subject = Email.Subject
                    mail.Body = Email.Body
                    mail.IsBodyHtml = Email.HTMLBody
                    smtpserver.Send(mail)
                Next
            Catch ex As Exception
                Throw
            End Try

        End Sub


    End Class
End Namespace
