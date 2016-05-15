
Namespace com.Notifier.Email
    Public Class EmailObj

        Private _eFrom As String
        Private _eTo As String
        Private _eSubject As String
        Private _Body As String
        Private _HTMLBody As Boolean = True

        Public Property From() As String
            Get
                Return _eFrom
            End Get
            Set(ByVal value As String)
                _eFrom = value
            End Set
        End Property

        Public Property eTo() As String
            Get
                Return _eTo
            End Get
            Set(ByVal value As String)
                _eTo = value
            End Set
        End Property

        Public Property Body() As String
            Get
                Return _Body
            End Get
            Set(ByVal value As String)
                _Body = value
            End Set
        End Property

        Public Property HTMLBody() As Boolean
            Get
                Return _HTMLBody
            End Get
            Set(ByVal value As Boolean)
                _HTMLBody = value
            End Set
        End Property

        Public Property Subject() As String
            Get
                Return _eSubject
            End Get
            Set(ByVal value As String)
                _eSubject = value
            End Set
        End Property

    End Class
End Namespace