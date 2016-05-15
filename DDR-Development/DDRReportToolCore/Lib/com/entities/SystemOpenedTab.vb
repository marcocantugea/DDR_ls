Namespace com.entities
    Public Class SystemOpenedTab
        Implements ICloneable

        Private _OpenedTab_ID As Integer = -1
        Private _Tab_sel As String
        Private _User_sess As String
        Private _timeAccesed As Date
        Private _Active As Boolean
        Private _ActiveTab As Boolean

        Public Property ActiveTab() As Boolean
            Get
                Return _ActiveTab
            End Get
            Set(ByVal value As Boolean)
                _ActiveTab = value
            End Set
        End Property

        Public Property Active() As Boolean
            Get
                Return _Active
            End Get
            Set(ByVal value As Boolean)
                _Active = value
            End Set
        End Property

        Public Property timeAccesed() As Date
            Get
                Return _timeAccesed
            End Get
            Set(ByVal value As Date)
                _timeAccesed = value
            End Set
        End Property

        Public Property User_sess() As String
            Get
                Return _User_sess
            End Get
            Set(ByVal value As String)
                _User_sess = value
            End Set
        End Property

        Public Property Tab_sel() As String
            Get
                Return _Tab_sel
            End Get
            Set(ByVal value As String)
                _Tab_sel = value
            End Set
        End Property

        Public Property OpenedTab_ID() As Integer
            Get
                Return _OpenedTab_ID
            End Get
            Set(ByVal value As Integer)
                _OpenedTab_ID = value
            End Set
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class
End Namespace
