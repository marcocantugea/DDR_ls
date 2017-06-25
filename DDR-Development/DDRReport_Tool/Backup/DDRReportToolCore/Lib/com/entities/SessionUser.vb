
Namespace com.entities
    Public Class SessionUser

        Private _User As String
        Private _Group As String
        Private _DepartmentId As Integer
        Private _DeparmentName As String
        Private _email As String
        Public TabController As New System_OpenedTab_Collection

        Public Property email() As String
            Get
                Return _email
            End Get
            Set(ByVal value As String)
                _email = value
            End Set
        End Property

        Public Property DeparmentName() As String
            Get
                Return _DeparmentName
            End Get
            Set(ByVal value As String)
                _DeparmentName = value
            End Set
        End Property
        Public Property DepartmentId() As Integer
            Get
                Return _DepartmentId
            End Get
            Set(ByVal value As Integer)
                _DepartmentId = value
            End Set
        End Property

        Public Property User() As String
            Get
                Return _User
            End Get
            Set(ByVal value As String)
                _User = value
            End Set
        End Property

        Public Property Group() As String
            Get
                Return _Group
            End Get
            Set(ByVal value As String)
                _Group = value
            End Set
        End Property
    End Class
End Namespace
