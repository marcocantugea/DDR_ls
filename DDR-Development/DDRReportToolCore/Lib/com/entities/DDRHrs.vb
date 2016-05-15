Namespace com.entities
    Public Class DDRHrs
        Implements IComparable


        Private _Detail_HR_ID As Integer = -1
        Private _From As String
        Private _To As String
        Private _Total As String
        Private _Code As String
        Private _Comment As String
        Private _CommentSpanish As String
        Private _DDR_Report_ID As Integer

        Public Property CommentSpanish() As String
            Get
                Return _CommentSpanish
            End Get
            Set(ByVal value As String)
                _CommentSpanish = value
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
        Public Property Comment() As String
            Get
                Return _Comment
            End Get
            Set(ByVal value As String)
                _Comment = value
            End Set
        End Property

        Public Property Code() As String
            Get
                Return _Code
            End Get
            Set(ByVal value As String)
                _Code = value
            End Set
        End Property
        Public Property Total() As String
            Get
                Return _Total
            End Get
            Set(ByVal value As String)
                _Total = value
            End Set
        End Property
        Public Property Tov() As String
            Get
                Return _To
            End Get
            Set(ByVal value As String)
                _To = value
            End Set
        End Property
        Public Property Fromv() As String
            Get
                Return _From
            End Get
            Set(ByVal value As String)
                _From = value
            End Set
        End Property

        Public Property Detail_HR_ID() As Integer
            Get
                Return _Detail_HR_ID
            End Get
            Set(ByVal value As Integer)
                _Detail_HR_ID = value
            End Set
        End Property

        Public Function CompareTo(ByVal obj As Object) As Integer Implements System.IComparable.CompareTo
            If obj Is Nothing Then
                Return 1
            Else
                Try
                    Return Me.Fromv.CompareTo(CType(obj, com.entities.DDRHrs).Fromv)
                Catch ex As Exception
                    Return 1
                End Try

            End If
        End Function
    End Class
End Namespace
