Namespace com.entities
    Public Class DrillString

        Private _DrillString_ID As Integer = -1
        Private _Description As String
        Private _Weight As String
        Private _Grade As String
        Private _ToolJoint As String
        Private _ToolJntOD As String
        Private _NumberLocation As String
        Private _DDR_Report_ID As Integer
        Private _Size As String
        Private _TotalOnBoard As String
        'new field added 7 may 2016
        Private _BHAinHole As String


        Public Property BHAinHole() As String
            Get
                Return _BHAinHole
            End Get
            Set(ByVal value As String)
                _BHAinHole = value
            End Set
        End Property

        Public Property TotalOnBoard() As String
            Get
                Return _TotalOnBoard
            End Get
            Set(ByVal value As String)
                _TotalOnBoard = value
            End Set
        End Property

        Public Property SizeDR() As String
            Get
                Return _Size
            End Get
            Set(ByVal value As String)
                _Size = value
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


        Public Property NumberLocation() As String
            Get
                Return _NumberLocation
            End Get
            Set(ByVal value As String)
                _NumberLocation = value
            End Set
        End Property
        Public Property ToolJntOD() As String
            Get
                Return _ToolJntOD
            End Get
            Set(ByVal value As String)
                _ToolJntOD = value
            End Set
        End Property
        Public Property ToolJoint() As String
            Get
                Return _ToolJoint
            End Get
            Set(ByVal value As String)
                _ToolJoint = value
            End Set
        End Property
        Public Property Grade() As String
            Get
                Return _Grade
            End Get
            Set(ByVal value As String)
                _Grade = value
            End Set
        End Property
        Public Property Weight() As String
            Get
                Return _Weight
            End Get
            Set(ByVal value As String)
                _Weight = value
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

        Public Property DrillString_ID() As Integer
            Get
                Return _DrillString_ID
            End Get
            Set(ByVal value As Integer)
                _DrillString_ID = value
            End Set
        End Property

    End Class
End Namespace