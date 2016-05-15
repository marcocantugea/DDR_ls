Namespace com.entities
    Public Class Activities_Collection
        Implements IEnumerable, IEnumerator, ICollection

        Private position As Integer = -1
        Private _Items As New List(Of Activities)
        Private _ADODDR As New ADO.ADODDR

        Public ReadOnly Property Items() As List(Of Activities)
            Get
                Return _Items
            End Get
        End Property
        Public ReadOnly Property CurrentPosition() As Integer
            Get
                Return position
            End Get
        End Property

        Public Sub Add(ByVal item As Activities)
            If Not IsNothing(item) Then
                _Items.Add(item)
            End If
        End Sub
        Public Sub Add(ByVal item As Activities, ByVal AddToTable As Boolean)
            If Not IsNothing(item) Then
                If AddToTable Then
                    _ADODDR.SaveActivitie(item)
                End If
                _Items.Add(item)
            End If
        End Sub

        Public Sub ModifyActivity(ByVal item As Activities)
            If Not IsNothing(item) Then
                If item.Act_Detail_ID > 0 Then
                    _ADODDR.UpdateActivitie(item)
                    For Each i As Activities In _Items
                        If i.Act_Detail_ID.Equals(item.Act_Detail_ID) Then
                            i.Act_ID = item.Act_ID
                            i.Activity = item.Activity
                            i.ActivitySpanish = item.ActivitySpanish
                            i.DDR_Report_ID = item.DDR_Report_ID
                            i.Deparment = item.Deparment
                            i.Deparment_ID = item.Deparment_ID
                        End If
                    Next
                End If
            End If
        End Sub

        Public Sub RemoveActivity(ByVal item As Activities)
            If Not IsNothing(item) Then
                If item.Act_Detail_ID > 0 Then
                    _ADODDR.DeleteActivities(item)
                    For Each i As Activities In _Items
                        If i.Act_Detail_ID.Equals(item.Act_Detail_ID) Then
                            _Items.Remove(i)
                        End If
                    Next

                End If
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

        Public Overrides Function ToString() As String
            Dim sb As New System.Text.StringBuilder
            For Each item As Activities In _Items
                sb.Append(item.Activity & vbNewLine)
            Next
            Return sb.ToString()
            'Return MyBase.ToString()
        End Function



        Public Function ToStringAct(ByVal lenguage As String, ByVal Deparment As String) As String
            Dim sb As New System.Text.StringBuilder
            For Each item As Activities In _Items
                If item.Deparment.Equals(Deparment) Then
                    If lenguage.Equals("ENG") Then
                        sb.Append(item.Activity & vbNewLine)
                    End If
                    If lenguage.Equals("ESP") Then
                        sb.Append(item.ActivitySpanish & vbNewLine)
                    End If
                End If
            Next
            Return sb.ToString()
            'Return MyBase.ToString()
        End Function



    End Class

End Namespace
