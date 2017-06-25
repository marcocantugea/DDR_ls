
Namespace com.entities
    Public Class PUMR_Collection
        Implements IEnumerable, IEnumerator, ICollection
        Private position As Integer = -1
        Private _Items As New List(Of PUMR)
        Private _ADODDR As New ADO.ADODDR

        Public ReadOnly Property Items() As List(Of PUMR)
            Get
                Return _Items
            End Get
        End Property

        Public Sub Add(ByVal Item As PUMR)
            If Not IsNothing(Item) Then
                _Items.Add(Item)
            End If
        End Sub
        Public Sub Add(ByVal item As PUMR, ByVal AddToTable As Boolean)
            If Not IsNothing(item) Then
                If AddToTable Then
                    _ADODDR.SavePUMR(item)
                End If
                _Items.Add(item)
            End If
        End Sub

        Public Sub Modify(ByVal item As PUMR)
            If Not IsNothing(item) Then
                If item.PRUM_ID > 0 Then
                    _ADODDR.UpdatePUMR(item)
                    For Each i As PUMR In _Items
                        If i.PRUM_ID.Equals(item.PRUM_ID) Then
                            i.DDR_Report_ID = item.DDR_Report_ID
                            i.MRNumber = item.MRNumber
                            i.MRDesc = item.MRDesc
                            i.DateIssued = item.DateIssued
                            i.Status = item.Status
                        End If
                    Next
                End If
            End If
        End Sub

        Public Sub Remove(ByVal item As PUMR)
            If Not IsNothing(item) Then
                If item.DDR_Report_ID > 0 Then
                    _ADODDR.DeletePUMR(item)
                    For Each i As PUMR In _Items
                        If i.DDR_Report_ID.Equals(item.DDR_Report_ID) Then
                            _Items.Remove(i)
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
            Return (CType(Me, IEnumerator))
        End Function

        Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
            Get
                Return _Items.GetEnumerator.Current
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
            position += 1
            Return (position <= _Items.Count)
        End Function

        Public Sub Reset() Implements System.Collections.IEnumerator.Reset
            position = -1
        End Sub
        Public Overrides Function ToString() As String
            Dim sb As New System.Text.StringBuilder
            For Each item As PUMR In _Items
                sb.Append(item.MRNumber & " " & item.MRDesc & "  Date Issued: " & item.DateIssued & " Status:" & item.Status & vbNewLine)
            Next
            Return sb.ToString()
            'Return MyBase.ToString()
        End Function



        'Public Function ToStringAct(ByVal lenguage As String, ByVal Deparment As String) As String
        '    Dim sb As New System.Text.StringBuilder
        '    For Each item As Activities In _Items
        '        If item.Deparment.Equals(Deparment) Then
        '            If lenguage.Equals("ENG") Then
        '                sb.Append(item.Activity & vbNewLine)
        '            End If
        '            If lenguage.Equals("ESP") Then
        '                sb.Append(item.ActivitySpanish & vbNewLine)
        '            End If
        '        End If
        '    Next
        '    Return sb.ToString()
        '    'Return MyBase.ToString()
        'End Function
    End Class
End Namespace