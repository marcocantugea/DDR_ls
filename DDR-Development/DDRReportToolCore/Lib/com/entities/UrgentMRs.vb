Namespace com.entities
    Public Class UrgentMRs

        Private _MRUrgentID As Integer = -1
        Private _Deparment_ID As Integer
        Private _DDR_Report_ID As Integer
        Private _MRNumber As String
        Private _dateIssued As String
        Private _MRDescription As String
        Private _Status As String

        Public Property Status() As String
            Get
                Return _Status
            End Get
            Set(ByVal value As String)
                _Status = value
            End Set
        End Property

        Public Property MRDescription() As String
            Get
                Return _MRDescription
            End Get
            Set(ByVal value As String)
                _MRDescription = value
            End Set
        End Property

        Public Property dateIssued() As String
            Get
                Return _dateIssued
            End Get
            Set(ByVal value As String)
                _dateIssued = value
            End Set
        End Property
        Public Property MRNumber() As String
            Get
                Return _MRNumber
            End Get
            Set(ByVal value As String)
                _MRNumber = value
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

        Public Property Deparment_ID() As Integer
            Get
                Return _Deparment_ID
            End Get
            Set(ByVal value As Integer)
                _Deparment_ID = value
            End Set
        End Property

        Public Property MRUrgentID() As Integer
            Get
                Return _MRUrgentID
            End Get
            Set(ByVal value As Integer)
                _MRUrgentID = value
            End Set
        End Property


    End Class
End Namespace
