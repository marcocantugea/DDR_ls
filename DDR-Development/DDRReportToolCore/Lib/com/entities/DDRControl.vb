

Namespace com.entities
    Public Class DDRControl

        Private _DDRID As Integer = -1
        Private _ReportDate As Date
        Private _Description As String
        Private _Locked As Boolean
        Private _Active As Boolean
        Private _ReportNo As Integer
        Private _LastUpdate As Date
        Private _UpdatedBy As String
        Private _DDRHeader As DDRReport
        Private _Well As String
        Private _Lastupdated As Date

        Public Property Lastupdated() As Date
            Get
                Return _LastUpdate
            End Get
            Set(ByVal value As Date)
                _LastUpdate = value
            End Set
        End Property

        Public Property Well() As String
            Get
                Return _Well
            End Get
            Set(ByVal value As String)
                _Well = value
            End Set
        End Property

        Public Property DDRReport() As DDRReport
            Get
                Return _DDRHeader
            End Get
            Set(ByVal value As DDRReport)
                _DDRHeader = value
            End Set
        End Property

        Public Property UpdatedBy() As String
            Get
                Return _UpdatedBy
            End Get
            Set(ByVal value As String)
                _UpdatedBy = value
            End Set
        End Property

        Public Property LastUpdate() As Date
            Get
                Return _LastUpdate
            End Get
            Set(ByVal value As Date)
                _LastUpdate = value
            End Set
        End Property

        Public Property ReportNo() As Integer
            Get
                Return _ReportNo
            End Get
            Set(ByVal value As Integer)
                _ReportNo = value
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

        Public Property Locked() As Boolean
            Get
                Return _Locked
            End Get
            Set(ByVal value As Boolean)
                _Locked = value
            End Set
        End Property

        Public Property Description() As String
            Get
                Return _Description
            End Get
            Set(ByVal value As String)
                _Description = value
            End Set
        End Property

        Public Property ReportDate() As Date
            Get
                Return _ReportDate
            End Get
            Set(ByVal value As Date)
                _ReportDate = value
            End Set
        End Property

        Public Property DDRID() As Integer
            Get
                Return _DDRID
            End Get
            Set(ByVal value As Integer)
                _DDRID = value
            End Set
        End Property

    End Class
End Namespace