
Namespace com.entities

    Public Class Activities


        Private _Act_ID As Integer
        Private _DDR_Report_ID As Integer
        Private _Deparment_ID As Integer
        Private _Deparment As String
        Private _Activity As String
        Private _ActivitySpanish As String
        Private _Act_Detail_ID As Integer = -1

        Public Property Act_Detail_ID() As Integer
            Get
                Return _Act_Detail_ID
            End Get
            Set(ByVal value As Integer)
                _Act_Detail_ID = value
            End Set
        End Property

        Public Property ActivitySpanish() As String
            Get
                Return _ActivitySpanish
            End Get
            Set(ByVal value As String)
                _ActivitySpanish = value
            End Set
        End Property

        Public Property Activity() As String
            Get
                Return _Activity
            End Get
            Set(ByVal value As String)
                _Activity = value
            End Set
        End Property

        Public Property Deparment() As String
            Get
                Return _Deparment
            End Get
            Set(ByVal value As String)
                _Deparment = value
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
        Public Property DDR_Report_ID() As Integer
            Get
                Return _DDR_Report_ID
            End Get
            Set(ByVal value As Integer)
                _DDR_Report_ID = value
            End Set
        End Property



        Public Property Act_ID() As Integer
            Get
                Return _Act_ID
            End Get
            Set(ByVal value As Integer)
                _Act_ID = value
            End Set
        End Property

    End Class
End Namespace
