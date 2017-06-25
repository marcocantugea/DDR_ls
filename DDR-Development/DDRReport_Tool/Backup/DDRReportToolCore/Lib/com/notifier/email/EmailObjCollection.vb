
Namespace com.Notifier.Email
    Public Class EmailObjCollection
        Implements IEnumerable, IEnumerator, ICollection

        Private position As Integer = -1
        Private _Emails As New List(Of EmailObj)

        Public ReadOnly Property EmailsObjCollection() As List(Of EmailObj)
            Get
                Return _Emails
            End Get
        End Property

        Public Sub Add(ByVal dd As EmailObj)
            If Not IsNothing(dd) Then
                _Emails.Add(dd)
            End If
        End Sub

        Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo

        End Sub

        Public ReadOnly Property Count() As Integer Implements ICollection.Count
            Get
                Return _Emails.Count
            End Get
        End Property

        Public ReadOnly Property IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SyncRoot() As Object Implements ICollection.SyncRoot
            Get
                Return Me
            End Get
        End Property

        Public Function GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return CType(Me, IEnumerator)
        End Function

        Public ReadOnly Property Current() As Object Implements IEnumerator.Current
            Get
                Return _Emails.GetEnumerator.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            position += 1
            Return (position <= _Emails.Count)
        End Function

        Public Sub Reset() Implements IEnumerator.Reset
            position = -1
        End Sub


    End Class
End Namespace
