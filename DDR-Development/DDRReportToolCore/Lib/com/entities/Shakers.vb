Namespace com.entities
    Public Class Shakers

        Private _Shakers_ID As Integer = -1
        Private _ShakerNo As String
        Private _MakeAndModel As String
        Private _ScreenSize As String
        Private _Top1 As String
        Private _Top2 As String
        Private _Top3 As String
        Private _Top4 As String
        Private _Bottom1 As String
        Private _Bottom2 As String
        Private _Bottom3 As String
        Private _Bottom4 As String
        Private _DDR_Report_ID As String


        Public Property DDR_Report_ID() As String
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As String)
                _DDR_Report_ID = value
            End Set
        End Property

        Public Property Bottom4() As String
            Get
                Return _Bottom4
            End Get
            Set(ByVal value As String)
                _Bottom4 = value
            End Set
        End Property
        Public Property Bottom3() As String
            Get
                Return _Bottom3
            End Get
            Set(ByVal value As String)
                _Bottom3 = value
            End Set
        End Property
        Public Property Bottom2() As String
            Get
                Return _Bottom2
            End Get
            Set(ByVal value As String)
                _Bottom2 = value
            End Set
        End Property
        Public Property Bottom1() As String
            Get
                Return _Bottom1
            End Get
            Set(ByVal value As String)
                _Bottom1 = value
            End Set
        End Property
        Public Property Top4() As String
            Get
                Return _Top4
            End Get
            Set(ByVal value As String)
                _Top4 = value
            End Set
        End Property

        Public Property Top3() As String
            Get
                Return _Top3
            End Get
            Set(ByVal value As String)
                _Top3 = value
            End Set
        End Property
        Public Property Top2() As String
            Get
                Return _Top2
            End Get
            Set(ByVal value As String)
                _Top2 = value
            End Set
        End Property
        Public Property Top1() As String
            Get
                Return _Top1
            End Get
            Set(ByVal value As String)
                _Top1 = value
            End Set
        End Property
        Public Property ScreenSize() As String
            Get
                Return _ScreenSize
            End Get
            Set(ByVal value As String)
                _ScreenSize = value
            End Set
        End Property
        Public Property MakeAndModel() As String
            Get
                Return _MakeAndModel
            End Get
            Set(ByVal value As String)
                _MakeAndModel = value
            End Set
        End Property
        Public Property ShakerNo() As String
            Get
                Return _ShakerNo
            End Get
            Set(ByVal value As String)
                _ShakerNo = value
            End Set
        End Property

        Public Property Shakers_ID() As Integer
            Get
                Return _Shakers_ID
            End Get
            Set(ByVal value As Integer)
                _Shakers_ID = value
            End Set
        End Property


    End Class
End Namespace