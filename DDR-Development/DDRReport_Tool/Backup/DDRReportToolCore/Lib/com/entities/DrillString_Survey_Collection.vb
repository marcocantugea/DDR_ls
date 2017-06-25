
Namespace com.entities
    Public Class DrillString_Survey_Collection
        Implements IEnumerable, IEnumerator, ICollection

        Private position As Integer = -1
        Private _Items As New List(Of DrillString_Survey)

        Public ReadOnly Property Items() As List(Of DrillString_Survey)
            Get
                Return _Items
            End Get
        End Property
        Public ReadOnly Property CurrentPosition() As Integer
            Get
                Return position
            End Get
        End Property

        Public Sub Add(ByVal Item As DrillString_Survey)
            If Not IsNothing(Item) Then
                _Items.Add(Item)
            End If
        End Sub

        Public Sub CopyTo(ByVal array As Array, ByVal index As Integer) Implements ICollection.CopyTo

        End Sub

        Public ReadOnly Property Count() As Integer Implements ICollection.Count
            Get
                Return _Items.Count
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
                Return _Items.GetEnumerator.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            position += 1
            Return (position <= _Items.Count)
        End Function

        Public Sub Reset() Implements IEnumerator.Reset
            position = -1
        End Sub
    End Class
End Namespace