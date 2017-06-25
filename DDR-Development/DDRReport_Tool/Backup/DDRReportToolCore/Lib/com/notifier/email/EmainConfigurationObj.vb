
Imports System.Configuration
Imports System.Collections

Namespace com.Notifier.Email
    Public Class EmailConfigurationObj

        Private _UserCredential As String
        Private _PassCredential As String
        Private _SMTPServerPort As Integer
        Private _SMTPServerHost As String

        Public ReadOnly Property UserCredential() As String
            Get
                Return _UserCredential
            End Get
        End Property

        Public ReadOnly Property PassCredential() As String
            Get
                Return _PassCredential
            End Get
        End Property

        Public ReadOnly Property SMTPServerPort() As Integer
            Get
                Return _SMTPServerPort
            End Get
        End Property

        Public ReadOnly Property SMTPServerHost() As String
            Get
                Return _SMTPServerHost
            End Get
        End Property

        Public Sub New()
            LoadDefaultConfiguration()
        End Sub

        Public Sub New(ByVal User As String, ByVal Password As String, ByVal SMTServerPort As Integer, ByVal SMTPServerHost As String)
            _UserCredential = User
            _PassCredential = Password
            _SMTPServerPort = SMTServerPort
            _SMTPServerHost = SMTPServerHost
        End Sub

        Public Overridable Sub LoadDefaultConfiguration()
            Try
                _UserCredential = System.Configuration.ConfigurationSettings.AppSettings("EmailUserCredential")
                _PassCredential = System.Configuration.ConfigurationSettings.AppSettings("EmailPasswordCredential")
                _SMTPServerHost = System.Configuration.ConfigurationSettings.AppSettings("EmailSMTPHost")
                _SMTPServerPort = Integer.Parse(System.Configuration.ConfigurationSettings.AppSettings("EmailSMTPPort"))
            Catch ex As Exception

            End Try
        End Sub


    End Class
End Namespace
