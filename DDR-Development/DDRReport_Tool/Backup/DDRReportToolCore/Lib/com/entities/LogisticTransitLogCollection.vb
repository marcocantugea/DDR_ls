
Namespace com.entities
    Public Class LogisticTransitLogCollection
        Implements IEnumerable, ICollection, IEnumerator

        Private position As Integer = -1
        Private _items As New List(Of LogisticTransitLog)
        Private _ado As New ADO.ADODDR


        Public ReadOnly Property items() As List(Of LogisticTransitLog)
            Get
                Return _items
            End Get
        End Property

        Public Sub Add(ByVal Item As LogisticTransitLog)
            If Not IsNothing(Item) Then
                _items.Add(Item)
            End If
        End Sub

        Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo

        End Sub

        Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
            Get
                Return _items.Count
            End Get
        End Property

        Public ReadOnly Property IsSynchronized() As Boolean Implements System.Collections.ICollection.IsSynchronized
            Get
                Return False
            End Get
        End Property

        Public ReadOnly Property SyncRoot() As Object Implements System.Collections.ICollection.SyncRoot
            Get
                Return Me
            End Get
        End Property

        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return CType(Me, IEnumerator)
        End Function

        Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return _items.GetEnumerator.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            position += 1
            Return (position <= _items.Count)
        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            position = -1
        End Sub

        Public Function ToStringByType(ByVal Type As String, Optional ByVal lenguaje As String = "ENG") As String
            Dim sb As New System.Text.StringBuilder

            For Each item As LogisticTransitLog In items
                If item.Type.Equals(Type) Then
                    If lenguaje.Equals("ENG") Then
                        sb.Append(item.Log & vbNewLine)
                    End If
                    If lenguaje.Equals("ESP") Then
                        sb.Append(item.LogEsp & vbNewLine)
                    End If
                End If
            Next
            'Return MyBase.ToString()
            Return sb.ToString
        End Function

        Public Sub Remove(ByVal item As LogisticTransitLog)
            If Not IsNothing(item) Then
                If item.DDR_Report_ID > 0 Then
                    _ado.DeleteLogisticTransitLog(item)
                    For Each i As LogisticTransitLog In _items
                        If i.LTID = item.LTID Then
                            _items.Remove(i)
                        End If
                    Next
                End If
            End If

        End Sub

    End Class
End Namespace
