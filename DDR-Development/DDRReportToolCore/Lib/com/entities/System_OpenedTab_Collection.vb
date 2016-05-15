Namespace com.entities
    Public Class System_OpenedTab_Collection
        Implements IEnumerable, ICollection, IEnumerator, ICloneable

        Private position As Integer = -1
        Private _Items As New List(Of SystemOpenedTab)
        Private _ADODDR As New ADO.ADODDR

        Public ReadOnly Property items() As List(Of SystemOpenedTab)
            Get
                Return _Items
            End Get
        End Property

        Public Sub Add(ByVal item As SystemOpenedTab)
            If Not IsNothing(item) Then
                _Items.Add(item)
            End If
        End Sub

        Public Sub Add(ByVal item As SystemOpenedTab, ByVal SaveToDataBase As Boolean)
            If Not IsNothing(item) Then
                _Items.Add(item)
                If SaveToDataBase Then
                    _ADODDR.SaveLogOpenTab(item)
                End If
            End If
        End Sub

        Public Sub Modify(ByVal item As SystemOpenedTab)
            If Not IsNothing(item) Then
                If item.OpenedTab_ID > 0 Then
                    _ADODDR.UpdateLogOpenTab(item)
                    For Each i As SystemOpenedTab In _Items
                        If i.OpenedTab_ID.Equals(item.OpenedTab_ID) Then
                            i.Tab_sel = item.Tab_sel
                            i.User_sess = item.User_sess
                            i.timeAccesed = item.timeAccesed
                            i.Active = item.Active
                            i.ActiveTab = item.ActiveTab
                        End If
                    Next
                End If
            End If
        End Sub
        Public Sub Remove(ByVal item As SystemOpenedTab)
            If Not IsNothing(item) Then
                If item.OpenedTab_ID > 0 Then
                    _ADODDR.DeleteLogOpenTab(item)
                    For Each i As SystemOpenedTab In _Items
                        If i.OpenedTab_ID.Equals(item.OpenedTab_ID) Then
                            _Items.Remove(i)
                            Exit Sub
                        End If
                    Next

                End If
            End If
        End Sub

        Public Sub RemoveAllItems(ByVal user_sess As String)
            _Items.Clear()
            Dim opentabs As New SystemOpenedTab
            opentabs.User_sess = user_sess
            _ADODDR.DeleteLogOpenTabs(opentabs)
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


        'Public Function GetItemsByDeparmentID(ByVal DeparmentID As Integer) As ArrayList
        '    Dim a As New ArrayList()
        '    For Each item As UrgentMRs In _Items
        '        If item.Deparment_ID.Equals(DeparmentID) Then
        '            a.Add(item)
        '        End If
        '    Next
        '    Return a
        'End Function

        Public Function Clone() As Object Implements System.ICloneable.Clone
            Return Me.MemberwiseClone
        End Function
    End Class
End Namespace
