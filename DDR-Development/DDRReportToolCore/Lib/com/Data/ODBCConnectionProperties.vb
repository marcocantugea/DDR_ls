Imports System.Data.Odbc

Namespace com.data
    Public Class ODBCConnectionProperties
        Dim _Name As String
        Dim _ConectionString As String
        Dim _Connection As OdbcConnection
        Dim _Adap As OdbcDataAdapter
        Dim _Command As OdbcCommand


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

                End Try
            End Set
        End Property

        Public ReadOnly Property Connection() As OdbcConnection
            Get
                Return _Connection
            End Get
        End Property

        Public Property Adap() As OdbcDataAdapter
            Get
                Return _Adap
            End Get
            Set(ByVal value As OdbcDataAdapter)
                _Adap = value
            End Set
        End Property

        Public Property Command() As OdbcCommand
            Get
                Return _Command
            End Get
            Set(ByVal value As OdbcCommand)
                _Command = value
            End Set
        End Property

        Public Sub SetUpConnection()
            _Connection = New OdbcConnection(_ConectionString)
        End Sub
    End Class
End Namespace