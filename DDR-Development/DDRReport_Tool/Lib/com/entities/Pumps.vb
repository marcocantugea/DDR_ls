Namespace com.entities
    Public Class Pumps

        Private _pumps_id As Integer = -1
        Private _PumpNo As String
        Private _MakeandModel As String
        Private _Stroke As String
        Private _Liners As String
        Private _SPM As String
        Private _GPM As String
        Private _EFF As String
        Private _Press As String
        Private _MP As String
        Private _CLF As String
        Private _CLFCK As String
        Private _Comments As String
        Private _DDR_Report_ID As Integer
        Private _s30StrokesChoke As String
        Private _s30StrokesCK As String
        Private _s40StrokesChoke As String
        Private _s40StrokesCK As String
        Private _s50StrokesChoke As String
        Private _s50StrokesCK As String


        Public Property s50StrokesCK() As String
            Get
                Return _s50StrokesCK
            End Get
            Set(ByVal value As String)
                _s50StrokesCK = value
            End Set
        End Property

        Public Property s50StrokesChoke() As String
            Get
                Return _s50StrokesChoke
            End Get
            Set(ByVal value As String)
                _s50StrokesChoke = value
            End Set
        End Property

        Public Property s40StrokesCK() As String
            Get
                Return _s40StrokesCK
            End Get
            Set(ByVal value As String)
                _s40StrokesCK = value
            End Set
        End Property

        Public Property s40StrokesChoke() As String
            Get
                Return _s40StrokesChoke
            End Get
            Set(ByVal value As String)
                _s40StrokesChoke = value
            End Set
        End Property

        Public Property s30StrokesCK() As String
            Get
                Return _s30StrokesCK
            End Get
            Set(ByVal value As String)
                _s30StrokesCK = value
            End Set
        End Property

        Public Property s30StrokesChoke() As String
            Get
                Return _s30StrokesChoke
            End Get
            Set(ByVal value As String)
                _s30StrokesChoke = value
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

        Public Property Comments() As String
            Get
                Return _Comments
            End Get
            Set(ByVal value As String)
                _Comments = value
            End Set
        End Property
        Public Property CLFCK() As String
            Get
                Return _CLFCK
            End Get
            Set(ByVal value As String)
                _CLFCK = value
            End Set
        End Property
        Public Property CLF() As String
            Get
                Return _CLF
            End Get
            Set(ByVal value As String)
                _CLF = value
            End Set
        End Property
        Public Property MP() As String
            Get
                Return _MP
            End Get
            Set(ByVal value As String)
                _MP = value
            End Set
        End Property

        Public Property Press() As String
            Get
                Return _Press
            End Get
            Set(ByVal value As String)
                _Press = value
            End Set
        End Property
        Public Property EFF() As String
            Get
                Return _EFF
            End Get
            Set(ByVal value As String)
                _EFF = value
            End Set
        End Property
        Public Property GPM() As String
            Get
                Return _GPM
            End Get
            Set(ByVal value As String)
                _GPM = value
            End Set
        End Property
        Public Property SPM() As String
            Get
                Return _SPM
            End Get
            Set(ByVal value As String)
                _SPM = value
            End Set
        End Property

        Public Property Liners() As String
            Get
                Return _Liners
            End Get
            Set(ByVal value As String)
                _Liners = value
            End Set
        End Property
        Public Property Stroke() As String
            Get
                Return _Stroke
            End Get
            Set(ByVal value As String)
                _Stroke = value
            End Set
        End Property
        Public Property MakeandModel() As String
            Get
                Return _MakeandModel
            End Get
            Set(ByVal value As String)
                _MakeandModel = value
            End Set
        End Property
        Public Property PumpNo() As String
            Get
                Return _PumpNo
            End Get
            Set(ByVal value As String)
                _PumpNo = value
            End Set
        End Property
        Public Property pumps_id() As Integer
            Get
                Return _pumps_id
            End Get
            Set(ByVal value As Integer)
                _pumps_id = value
            End Set
        End Property

    End Class
End Namespace
