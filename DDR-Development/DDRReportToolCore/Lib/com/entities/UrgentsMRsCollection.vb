Namespace com.entities
    Public Class UrgentsMRsCollection
        Implements IEnumerable, ICollection, IEnumerator

        Private position As Integer = -1
        Private _Items As New List(Of UrgentMRs)
        Private _ADODDR As New ADO.ADODDR

        Public ReadOnly Property items() As List(Of UrgentMRs)
            Get
                Return _Items
            End Get
        End Property

        Public Sub Add(ByVal item As UrgentMRs)
            If Not IsNothing(item) Then
                _Items.Add(item)
            End If
        End Sub

        Public Sub Add(ByVal item As UrgentMRs, ByVal SaveToDataBase As Boolean)
            If Not IsNothing(item) Then
                _Items.Add(item)
                If SaveToDataBase Then
                    _ADODDR.SaveUrgentMRs(item)
                End If
            End If
        End Sub

        Public Sub Modify(ByVal item As UrgentMRs)
            If Not IsNothing(item) Then
                If item.MRUrgentID > 0 Then
                    _ADODDR.UpdateUrgentMR(item)
                    For Each i As UrgentMRs In _Items
                        If i.MRUrgentID.Equals(item.MRUrgentID) Then
                            i.MRNumber = item.MRNumber
                            i.dateIssued = item.dateIssued
                            i.MRDescription = item.MRDescription
                            i.Status = item.Status
                        End If
                    Next
                End If
            End If
        End Sub
        Public Sub Remove(ByVal item As UrgentMRs)
            If Not IsNothing(item) Then
                If item.MRUrgentID > 0 Then
                    _ADODDR.DeleteUrgentMR(item)
                    For Each i As UrgentMRs In _Items
                        If i.MRUrgentID.Equals(item.MRUrgentID) Then
                            _Items.Remove(i)
                            Exit Sub
                        End If
                    Next

                End If
            End If
        End Sub


        Public Sub CopyTo(ByVal array As System.Array, ByVal index As Integer) Implements System.Collections.ICollection.CopyTo

        End Sub

        Public ReadOnly Property Count() As Integer Implements System.Collections.ICollection.Count
            Get
                Return _Items.Count
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
                Return Me.GetEnumerator.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            position += 1
            Return (position <= _Items.Count)
        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            position = -1
        End Sub

        Public Function toStringWO(ByVal DeparmentID As Integer) As String
            Dim sb As New System.Text.StringBuilder
            For Each item As UrgentMRs In _Items
                If item.Deparment_ID.Equals(DeparmentID) Then
                    sb.Append(item.MRNumber & " " & item.MRDescription & "  Date Issued: " & item.dateIssued & " Status:" & item.Status & vbNewLine)
                End If
            Next

            Return sb.ToString
        End Function

        Public Function GetItemsByDeparmentID(ByVal DeparmentID As Integer) As ArrayList
            Dim a As New ArrayList()
            For Each item As UrgentMRs In _Items
                If item.Deparment_ID.Equals(DeparmentID) Then
                    a.Add(item)
                End If
            Next
            Return a
        End Function

    End Class
End Namespace