
Namespace com.entities
    Public Class POB

        Private _POB_ID As Integer = -1
        Private _GRCrew As Integer
        Private _GRServ As Integer
        Private _Catering As Integer
        Private _Pemex As Integer
        Private _OpSer As Integer
        Private _Aker As Integer
        Private _Total As Integer
        Private _DailyCost As Double
        Private _AccCost As Double
        Private _AverageCost As Double
        Private _DaysFromLAstLTA As Double
        Private _DDR_Report_ID As Integer


        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property
        Public Property DaysFromLAstLTA() As Integer
            Get
                Return _DaysFromLAstLTA
            End Get
            Set(ByVal value As Integer)
                _DaysFromLAstLTA = value
            End Set
        End Property
        Public Property AverageCost() As Integer
            Get
                Return _AverageCost
            End Get
            Set(ByVal value As Integer)
                _AverageCost = value
            End Set
        End Property
        Public Property AccCost() As Integer
            Get
                Return _AccCost
            End Get
            Set(ByVal value As Integer)
                _AccCost = value
            End Set
        End Property
        Public Property DailyCost() As Integer
            Get
                Return _DailyCost
            End Get
            Set(ByVal value As Integer)
                _DailyCost = value
            End Set
        End Property
        Public Property Total() As Integer
            Get
                Return _Total
            End Get
            Set(ByVal value As Integer)
                _Total = value
            End Set
        End Property
        Public Property Aker() As Integer
            Get
                Return _Aker
            End Get
            Set(ByVal value As Integer)
                _Aker = value
            End Set
        End Property
        Public Property OpSer() As Integer
            Get
                Return _OpSer
            End Get
            Set(ByVal value As Integer)
                _OpSer = value
            End Set
        End Property
        Public Property Pemex() As Integer
            Get
                Return _Pemex
            End Get
            Set(ByVal value As Integer)
                _Pemex = value
            End Set
        End Property
        Public Property Catering() As Integer
            Get
                Return _Catering
            End Get
            Set(ByVal value As Integer)
                _Catering = value
            End Set
        End Property
        Public Property GRServ() As Integer
            Get
                Return _GRServ
            End Get
            Set(ByVal value As Integer)
                _GRServ = value
            End Set
        End Property

        Public Property GRCrew() As Integer
            Get
                Return _GRCrew
            End Get
            Set(ByVal value As Integer)
                _GRCrew = value
            End Set
        End Property
        Public Property POB_ID() As Integer
            Get
                Return _POB_ID
            End Get
            Set(ByVal value As Integer)
                _POB_ID = value
            End Set
        End Property

    End Class
End Namespace