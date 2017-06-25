
Namespace com.entities
    Public Class LogisticTransitLog

        Private _LTID As Integer = -1
        Private _DDR_Report_ID As Integer
        Private _Type As String
        Private _Log As String
        Private _LogEsp As String

        Public Property LogEsp() As String
            Get
                Return _LogEsp
            End Get
            Set(ByVal value As String)
                _LogEsp = value
            End Set
        End Property

        Public Property Log() As String
            Get
                Return _Log
            End Get
            Set(ByVal value As String)
                _Log = value
            End Set
        End Property

        Public Property Type() As String
            Get
                Return _Type
            End Get
            Set(ByVal value As String)
                _Type = value
            End Set
        End Property

        Public Property LTID() As Integer
            Get
                Return _LTID
            End Get
            Set(ByVal value As Integer)
                _LTID = value
            End Set
        End Property

        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property

    End Class

End Namespace
