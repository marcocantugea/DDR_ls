Namespace com.entities
    Public Class DrillString_Survey

        Private _Survey_ID As Integer = -1
        Private _DirectionalSurveys As String
        Private _MD As String
        Private _TVD As String
        Private _INC As String
        Private _AZM As String
        Private _comments As String
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
                Return _comments
            End Get
            Set(ByVal value As String)
                _comments = value
            End Set
        End Property
        Public Property AZM() As String
            Get
                Return _AZM
            End Get
            Set(ByVal value As String)
                _AZM = value
            End Set
        End Property

        Public Property INC() As String
            Get
                Return _INC
            End Get
            Set(ByVal value As String)
                _INC = value
            End Set
        End Property

        Public Property TVD() As String
            Get
                Return _TVD
            End Get
            Set(ByVal value As String)
                _TVD = value
            End Set
        End Property

        Public Property MID() As String
            Get
                Return _MD
            End Get
            Set(ByVal value As String)
                _MD = value
            End Set
        End Property

        Public Property DirectionalSurveys() As String
            Get
                Return _DirectionalSurveys
            End Get
            Set(ByVal value As String)
                _DirectionalSurveys = value
            End Set
        End Property

        Public Property Survey_ID() As Integer
            Get
                Return _Survey_ID
            End Get
            Set(ByVal value As Integer)
                _Survey_ID = value
            End Set
        End Property


    End Class
End Namespace