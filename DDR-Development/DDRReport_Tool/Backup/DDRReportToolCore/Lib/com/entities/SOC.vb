Namespace com.entities


    Public Class SOC
        Implements ICloneable

        Private _SOCINFOID As Integer = -1
        Private _SOCToday As String
        Private _SOCMonth As String
        Private _SOCSTOPTour As String
        Private _DaysWithoutLTA As String
        Private _DDR_Report_ID As Integer

        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property

        Public Property DaysWithoutLTA() As String
            Get
                Return _DaysWithoutLTA
            End Get
            Set(ByVal value As String)
                _DaysWithoutLTA = value
            End Set
        End Property

        Public Property SOCSTOPTour() As String
            Get
                Return _SOCSTOPTour
            End Get
            Set(ByVal value As String)
                _SOCSTOPTour = value
            End Set
        End Property

        Public Property SOCMonth() As String
            Get
                Return _SOCMonth
            End Get
            Set(ByVal value As String)
                _SOCMonth = value
            End Set
        End Property

        Public Property SOCToday() As String
            Get
                Return _SOCToday
            End Get
            Set(ByVal value As String)
                _SOCToday = value
            End Set
        End Property

        Public Property SOCINFOID() As Integer
            Get
                Return _SOCINFOID
            End Get
            Set(ByVal value As Integer)
                _SOCINFOID = value
            End Set
        End Property

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class
End Namespace