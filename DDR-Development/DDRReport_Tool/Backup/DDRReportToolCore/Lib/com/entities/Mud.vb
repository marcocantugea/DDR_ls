Namespace com.entities
    Public Class Mud

        Private _MUD_ID As Integer = -1
        Private _TimeMud As String
        Private _WT As String
        Private _VIS As String
        Private _WL As String
        Private _Cake As String
        Private _PH As String
        Private _Sand As String
        Private _Solids As String
        Private _PvYP As String
        Private _KCL As String
        Private _Pm As String
        Private _Comments As String
        Private _DDR_Report_ID As Integer

        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property

        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        Public Property Pm() As String
            Get
                Return _Pm
            End Get
            Set(ByVal value As String)
                _Pm = value
            End Set
        End Property
        Public Property KCL() As String
            Get
                Return _KCL
            End Get
            Set(ByVal value As String)
                _KCL = value
            End Set
        End Property
        Public Property PvYP() As String
            Get
                Return _PvYP
            End Get
            Set(ByVal value As String)
                _PvYP = value
            End Set
        End Property
        Public Property Solids() As String
            Get
                Return _Solids
            End Get
            Set(ByVal value As String)
                _Solids = value
            End Set
        End Property
        Public Property Sand() As String
            Get
                Return _Sand
            End Get
            Set(ByVal value As String)
                _Sand = value
            End Set
        End Property
        Public Property PH() As String
            Get
                Return _PH
            End Get
            Set(ByVal value As String)
                _PH = value
            End Set
        End Property
        Public Property Cake() As String
            Get
                Return _Cake
            End Get
            Set(ByVal value As String)
                _Cake = value
            End Set
        End Property
        Public Property WL() As String
            Get
                Return _WL
            End Get
            Set(ByVal value As String)
                _WL = value
            End Set
        End Property
        Public Property VIS() As String
            Get
                Return _VIS
            End Get
            Set(ByVal value As String)
                _VIS = value
            End Set
        End Property

        Public Property WT() As String
            Get
                Return _WT
            End Get
            Set(ByVal value As String)
                _WT = value
            End Set
        End Property
        Public Property TimeMud() As String
            Get
                Return _TimeMud
            End Get
            Set(ByVal value As String)
                _TimeMud = value
            End Set
        End Property

        Public Property MUD_ID() As Integer
            Get
                Return _MUD_ID
            End Get
            Set(ByVal value As Integer)
                _MUD_ID = value
            End Set
        End Property

    End Class
End Namespace
