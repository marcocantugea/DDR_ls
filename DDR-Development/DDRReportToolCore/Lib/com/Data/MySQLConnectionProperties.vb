Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Namespace com.data

    Public Class MySQLConnectionProperties
        Dim _Name As String
        Dim _ConectionString As String
        Dim _Connection As MySqlConnection
        Dim _Adap As MySqlDataAdapter
        Dim _Command As MySqlCommand

        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                _Name = value
            End Set
        End Property

        Public Property ConectionString() As String
            Get
                Return _ConectionString
            End Get
            Set(ByVal value As String)
                _ConectionString = value
                Try
                    SetUpConnection()
                Catch ex As Exception
                    Throw
                End Try
            End Set
        End Property

        Public ReadOnly Property Connection() As MySqlConnection
            Get
                Return _Connection
            End Get
        End Property

        Public Property Adap() As MySqlDataAdapter
            Get
                Return _Adap
            End Get
            Set(ByVal value As MySqlDataAdapter)
                _Adap = value
            End Set
        End Property

        Public Property Command() As MySqlCommand
            Get
                Return _Command
            End Get
            Set(ByVal value As MySqlCommand)
                _Command = value
            End Set
        End Property

        Public Sub SetUpConnection()
            _Connection = New MySqlConnection(_ConectionString)
        End Sub
    End Class
End Namespace