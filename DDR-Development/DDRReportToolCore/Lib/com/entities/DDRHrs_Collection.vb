Namespace com.entities
    Public Class DDRHrs_Collection
        Implements IEnumerable, IEnumerator, ICollection

        Private position As Integer = -1
        Private _Items As New List(Of DDRHrs)
        Private _ADODDR As New ADO.ADOMySQLDDR

        Public ReadOnly Property Items() As List(Of DDRHrs)
            Get
                Return _Items
            End Get
        End Property
        Public ReadOnly Property CurrentPosition() As Integer
            Get
                Return position
            End Get
        End Property

        Public Sub Add(ByVal DDHr As DDRHrs)
            If Not IsNothing(DDHr) Then
                _Items.Add(DDHr)
            End If
        End Sub

        Public Sub Add(ByVal DDHr As DDRHrs, ByVal addtotable As Boolean)
            If Not IsNothing(DDHr) Then
                If addtotable Then
                    _ADODDR.SaveDDR_Hrs(DDHr)
                End If
                _Items.Add(DDHr)
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

        Public Sub ModifyDDRHrs(ByVal DDHr As DDRHrs)
            If Not IsNothing(DDHr) Then
                If DDHr.Detail_HR_ID > 0 Then
                    _ADODDR.UpdateDDRHrs(DDHr)
                    For Each i As DDRHrs In _Items
                        If i.Detail_HR_ID.Equals(DDHr.Detail_HR_ID) Then
                            i.Fromv = DDHr.Detail_HR_ID
                            i.Tov = DDHr.Tov
                            i.Total = DDHr.Total
                            i.Code = DDHr.Total
                            i.Code = DDHr.Comment
                            i.CommentSpanish = DDHr.CommentSpanish
                        End If
                    Next
                End If
            End If
        End Sub


    End Class
End Namespace