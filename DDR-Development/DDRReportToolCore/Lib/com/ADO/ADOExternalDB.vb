Namespace com.ADO
    Public Class ADOExternalDB
        Inherits com.data.ODBCConnectionObj

        Public Function GetAMOSMR(MRAmosNumber) As String
            Dim string_value As String = ""

            Dim qry As String = "SELECT SUBSTRING(mrtable.documentnumber,0,5)+'-'+SUBSTRING(mrtable.documentnumber,5,2)+'-'+SUBSTRING(mrtable.documentnumber,7,LEN(mrtable.documentnumber)) as MRNumber,mrtable.documentnumber,FLOWSTATUS.DESCRIPTION,mrtable.title,mrtable.createddate FROM spectwosuite.PROCUREMENTDOCUMENT as mrtable LEFT JOIN spectwosuite.BUSINESSFLOWSTATUS AS flowstatus where flowstatus.BUSINESSFLOWSTATUSID = mrtable.BUSINESSFLOWSTATUSID and mrnumber='" & MRAmosNumber & "'"
            OpenDB("DB-AMOS")
            connection.Command = New Odbc.OdbcCommand(qry, connection.Connection)
            connection.Adap = New Odbc.OdbcDataAdapter(connection.Command)
            Dim dts As New DataSet
            connection.Adap.Fill(dts)
            If dts.Tables.Count > 0 Then
                If dts.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In dts.Tables(0).Rows
                        string_value = row("MRNumber") & "|" & row("documentnumber") & "|" & row("DESCRIPTION") & "|" & row("title") & "|" & row("createddate")

                    Next
                End If
            End If
            Return string_value
        End Function

        Public Function GetAMOSWO(AMOSWONumber) As String
            Dim string_value As String = ""
            Dim qry As String = "SELECT SUBSTRING(MW.CODE,0,7)+'-'+SUBSTRING(MW.CODE,7,2)+'-'+SUBSTRING(MW.CODE,9,LEN(MW.CODE)) AS WONUMBER,MW.DESCRIPTION,MT.CODE FROM MAINTWORKORDER MW INNER JOIN MAINTTYPE MT ON MT.MAINTTYPEID=MW.MAINTTYPEID WHERE WONUMBER='" + AMOSWONumber + "'"
            OpenDB("DB-AMOS")
            connection.Command = New Odbc.OdbcCommand(qry, connection.Connection)
            connection.Adap = New Odbc.OdbcDataAdapter(connection.Command)
            Dim dts As New DataSet
            connection.Adap.Fill(dts)
            If dts.Tables.Count > 0 Then
                If dts.Tables(0).Rows.Count > 0 Then
                    For Each row As DataRow In dts.Tables(0).Rows
                        string_value = row("WONUMBER") & "|" & row("DESCRIPTION") & "|" & row("CODE")

                    Next
                End If
            End If
            Return string_value
        End Function

        Public Sub TestDatabaseExternal()
            Try
                OpenDB("DB-AMOS")
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub


    End Class
End Namespace
