Imports DDRReport_Tool.com.entities

Namespace com.ADO
    Public Class ADODDR
        Inherits com.data.OleDBConnectionObj

        Public Sub SaveAllDDR(ByVal ddr As DDRControl)
            Try
                If ddr.DDRID = -1 Then
                    SaveDDRControl(ddr)
                    ddr.DDRID = GetLastID("DDR_Control", "DDRID")
                    ddr.DDRReport.DDRID = ddr.DDRID
                End If
                If Not IsNothing(ddr.DDRReport) Then
                    UpdateDateAndReportNo(ddr.ReportNo, ddr.ReportDate, ddr.DDRID)
                    ddr.DDRReport.DDRID = ddr.DDRID
                    SaveDDRReport(ddr.DDRReport)


                    'Save DRR hrs
                    If Not IsNothing(ddr.DDRReport.DDRHrs) Then
                        For Each item As com.entities.DDRHrs In ddr.DDRReport.DDRHrs.Items
                            item.DDR_Report_ID = ddr.DDRID
                            SaveDDR_Hrs(item)
                        Next
                    End If

                    'Save BITS
                    If Not IsNothing(ddr.DDRReport.BITS) Then
                        For Each bit As com.entities.BITS In ddr.DDRReport.BITS.Items
                            bit.DDR_Report_ID = ddr.DDRID
                            SaveBits(bit)
                        Next
                    End If

                    'Save Drill String
                    If Not IsNothing(ddr.DDRReport.DrillString) Then
                        For Each bit As com.entities.DrillString In ddr.DDRReport.DrillString.Items
                            bit.DDR_Report_ID = ddr.DDRID
                            SaveDrillString(bit)
                        Next
                    End If

                    'Save Drill String survey
                    If Not IsNothing(ddr.DDRReport.DrillString_Survey) Then
                        For Each item As com.entities.DrillString_Survey In ddr.DDRReport.DrillString_Survey.Items
                            item.DDR_Report_ID = ddr.DDRID
                            SaveDrillString_survey(item)
                        Next
                    End If

                    'Save pumps
                    If Not IsNothing(ddr.DDRReport.Pumps) Then
                        For Each item As com.entities.Pumps In ddr.DDRReport.Pumps.Items
                            item.DDR_Report_ID = ddr.DDRID
                            SavePumps(item)
                        Next
                    End If

                    'Save shakers
                    If Not IsNothing(ddr.DDRReport.Shakers) Then
                        For Each item As com.entities.Shakers In ddr.DDRReport.Shakers.Items
                            item.DDR_Report_ID = ddr.DDRID
                            SaveShakers(item)
                        Next
                    End If

                    'Save Mud
                    If Not IsNothing(ddr.DDRReport.Mud) Then
                        For Each item As com.entities.Mud In ddr.DDRReport.Mud.Items
                            item.DDR_Report_ID = ddr.DDRID
                            SaveMud(item)
                        Next
                    End If

                    'Save Marine Info
                    If Not IsNothing(ddr.DDRReport.MarineInfo) Then
                        ddr.DDRReport.MarineInfo.DDR_Report_ID = ddr.DDRID
                        SaveMarineInfo(ddr.DDRReport.MarineInfo)

                    End If

                    'Save POB
                    If Not IsNothing(ddr.DDRReport.POB) Then
                        ddr.DDRReport.POB.DDR_Report_ID = ddr.DDRID
                        SavePOB(ddr.DDRReport.POB)
                    End If

                    'Save Riser Profile
                    If Not IsNothing(ddr.DDRReport.RiserProfile) Then
                        For Each item As RiserProfile In ddr.DDRReport.RiserProfile.Items
                            item.DDR_Report_ID = ddr.DDRID
                            SaveRiserProfile(item)
                        Next
                    End If

                    'Save SOC
                    If Not IsNothing(ddr.DDRReport.SOC) Then
                        ddr.DDRReport.SOC.DDR_Report_ID = ddr.DDRID
                        SaveSOC(ddr.DDRReport.SOC)
                    End If

                    'Save Logistic Transit Log
                    If Not IsNothing(ddr.DDRReport.LogisticTransitLog) Then
                        For Each item As LogisticTransitLog In ddr.DDRReport.LogisticTransitLog.items
                            item.DDR_Report_ID = ddr.DDRID
                            SaveLogisticTransitLog(item)
                        Next
                    End If

                End If
                MsgBox("DDR Saved.")
            Catch ex As Exception

                Throw
            End Try
        End Sub

        

        Public Sub ModifyALLDDR(ByVal ddr As DDRControl)
            DeleteDDR_Report(ddr.DDRID)
            SaveAllDDR(ddr)
        End Sub


        Public Function GetCompleteDDRReport(ByVal DDRID As Integer) As DDRControl
            Dim ddrc As New DDRControl
            ddrc.DDRID = DDRID
            ddrc = GetDDRControlHeader(DDRID)
            ddrc.DDRReport = GetDDRReport(DDRID)
            ddrc.DDRReport.DDRHrs = GetDDRHrs(DDRID)
            ddrc.DDRReport.BITS = GetDDRBits(DDRID)
            ddrc.DDRReport.DrillString = GetDrillString(DDRID)
            ddrc.DDRReport.DrillString_Survey = GetDrillStringSurvey(DDRID)
            ddrc.DDRReport.MarineInfo = GetMarineInfo(DDRID)
            ddrc.DDRReport.POB = GetPOB(DDRID)
            ddrc.DDRReport.Pumps = GetPumps(DDRID)
            ddrc.DDRReport.Shakers = GetShakers(DDRID)
            ddrc.DDRReport.Mud = GetMud(DDRID)
            ddrc.DDRReport.Activities = GetActivities(DDRID)
            ddrc.DDRReport.RiserProfile = GetRiserProfile(DDRID)
            ddrc.DDRReport.SOC = GetSOC(DDRID)
            ddrc.DDRReport.LogisticTransitLog = GetLogisticTransitLog(DDRID)
            ddrc.DDRReport.UrgentsMR = GetUrgentsMR(DDRID)
            ddrc.DDRReport.WorkOrders = GetWO(DDRID)
            Return ddrc
        End Function

#Region "Save Info Functions"

        Private Sub SaveDDRControl(ByVal ddrcontrol As DDRControl)
            Dim qbuilder As New QueryBuilder(Of DDRControl)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = ddrcontrol
            qbuilder.BuildInsert("DDR_Control")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try

        End Sub
        Private Sub SaveDDRReport(ByVal ddr_report As DDRReport)
            Dim qbuilder As New QueryBuilder(Of DDRReport)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = ddr_report
            qbuilder.BuildInsert("DDR_Report")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try

        End Sub
        Private Sub SaveDDR_Bits(ByVal ddr_bits As BITS)
            Dim qbuilder As New QueryBuilder(Of BITS)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = ddr_bits
            qbuilder.BuildInsert("DDR_BITS")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveDDR_Hrs(ByVal ddrhrs As com.entities.DDRHrs)
            Dim qbuilder As New QueryBuilder(Of DDRHrs)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = ddrhrs
            qbuilder.BuildInsert("DDR_Detail_Hrs")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveBits(ByVal bits As com.entities.BITS)
            Dim qbuilder As New QueryBuilder(Of BITS)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = bits
            qbuilder.BuildInsert("DDR_BITS")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveDrillString(ByVal drillstring As com.entities.DrillString)
            Dim qbuilder As New QueryBuilder(Of DrillString)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = drillstring
            qbuilder.BuildInsert("DDR_DrillString")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveDrillString_survey(ByVal drillstring_survey As com.entities.DrillString_Survey)
            Dim qbuilder As New QueryBuilder(Of DrillString_Survey)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = drillstring_survey
            qbuilder.BuildInsert("DDR_DrillString_Surveys")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SavePumps(ByVal pumps As com.entities.Pumps)
            Dim qbuilder As New QueryBuilder(Of Pumps)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = pumps
            qbuilder.BuildInsert("DDR_PUMPS")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveShakers(ByVal shakers As com.entities.Shakers)
            Dim qbuilder As New QueryBuilder(Of Shakers)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = shakers
            qbuilder.BuildInsert("DDR_Shakers")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveMud(ByVal muds As com.entities.Mud)
            Dim qbuilder As New QueryBuilder(Of Mud)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = muds
            qbuilder.BuildInsert("DDR_Mud")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SaveMarineInfo(ByVal marine As com.entities.MarineInfo)
            Dim qbuilder As New QueryBuilder(Of MarineInfo)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = marine
            qbuilder.BuildInsert("DDR_Marine")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Private Sub SavePOB(ByVal pob As com.entities.POB)
            Dim qbuilder As New QueryBuilder(Of POB)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = pob
            qbuilder.BuildInsert("DDR_POB")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        

        Public Sub SaveRiserProfile(ByVal riserprof As com.entities.RiserProfile)
            Dim qbuilder As New QueryBuilder(Of RiserProfile)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = riserprof
            qbuilder.BuildInsert("RiserProfile")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub SaveSOC(ByVal socdata As com.entities.SOC)
            Dim qbuilder As New QueryBuilder(Of SOC)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = socdata
            qbuilder.BuildInsert("DDR_SOC")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub SaveLogisticTransitLog(ByVal TransitLog As com.entities.LogisticTransitLog)
            Dim qbuilder As New QueryBuilder(Of LogisticTransitLog)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = TransitLog
            qbuilder.BuildInsert("DDR_LogisticTransitLog")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub



        Public Function DebugQueryBuilder()
            Dim ddr1 As New DDRControl
            ddr1.ReportDate = Today()
            ddr1.Description = "-7"
            ddr1.ReportNo = "-7"
            ddr1.DDRID = -7

            Dim qbuilder As New QueryBuilder(Of DDRControl)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = ddr1

            'qbuilder.BuildInsert("DDR_Report")
            'qbuilder.BuildUpdate("DDR_Report", "DDR_Report_ID", "99")
            qbuilder.AddToQueryParameterForSelect("DDR_Report_ID=99")
            qbuilder.BuildSelect("DDR_Report")

            Return qbuilder.Query

        End Function
#End Region

        Private Sub DeleteDDR_Report(ByVal DDR_ID As Integer)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_Report where DDRID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_BITS where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_Detail_Hrs where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_DrillString where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_DrillString_Surveys where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_Marine where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_Mud where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_POB where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_PUMPS where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_Shakers where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from RiserProfile where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_SOC where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
                connection.Command = New OleDb.OleDbCommand("Delete from DDR_LogisticTransitLog where DDR_Report_ID=" & DDR_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        

#Region "Geters Info"

        Public Function GetLastID(ByVal table As String, ByVal field As String) As Integer
            Dim result As Integer = -1
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select max(" & field & ") from " & table, connection.Connection)
                result = connection.Command.ExecuteScalar()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try

            Return result
        End Function
        Public Sub GetDDRControlHeader(ByVal ddr As DDRControl_Collection)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select DDRID,ReportDate,Description,Lock,Active,ReportNo,Lastupdate,UpdatedBy from DDR_Control", connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_ddr As New DDRControl
                            For Each member In o_ddr.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            member.SetValue(o_ddr, row(member.Name), Nothing)
                                        End If
                                    End If
                                End If
                            Next
                            ddr.Add(o_ddr)
                        Next
                    End If
                End If

            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Function GetDDRControlHeader(ByVal DDRID As Integer) As DDRControl
            Dim o_ddr As New DDRControl
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select DDRID,ReportDate,Description,Lock,Active,ReportNo,Lastupdate,UpdatedBy from DDR_Control where DDRID=" & DDRID.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            For Each member In o_ddr.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            member.SetValue(o_ddr, row(member.Name), Nothing)
                                        End If
                                    End If
                                End If
                            Next

                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return o_ddr
        End Function
        Public Function GetDDRReport(ByVal ddrid As Integer) As DDRReport
            Dim ddr_r As New DDRReport
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_Report where DDRID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows

                            For Each member In ddr_r.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(ddr_r, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(ddr_r, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(ddr_r, Date.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return ddr_r
        End Function
        Public Function GetDDRHrs(ByVal ddrid As Integer) As DDRHrs_Collection
            Dim ddrhrs_collected As New DDRHrs_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_Detail_Hrs where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim o_ddrhrs As New DDRHrs
                            For Each member In o_ddrhrs.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(o_ddrhrs, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(o_ddrhrs, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            ddrhrs_collected.Add(o_ddrhrs)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return ddrhrs_collected
        End Function
        Public Function GetDDRBits(ByVal ddrid As Integer) As BITS_Collection
            Dim bits_collected As New BITS_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_BITS where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim bits As New BITS
                            For Each member In bits.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(bits, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(bits, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            bits_collected.Add(bits)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return bits_collected
        End Function
        Public Function GetDrillString(ByVal ddrid As Integer) As DrillString_Collection
            Dim drillstring_collected As New DrillString_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_DrillString where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim drillstring As New DrillString
                            For Each member In drillstring.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(drillstring, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(drillstring, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            drillstring_collected.Add(drillstring)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return drillstring_collected
        End Function
        Public Function GetDrillStringSurvey(ByVal ddrid As Integer) As DrillString_Survey_Collection
            Dim drillstringsurvey_collected As New DrillString_Survey_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_DrillString_Surveys where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim drillstringsurvey As New DrillString_Survey
                            For Each member In drillstringsurvey.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(drillstringsurvey, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(drillstringsurvey, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            drillstringsurvey_collected.Add(drillstringsurvey)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return drillstringsurvey_collected
        End Function
        Public Function GetMarineInfo(ByVal ddrid As Integer) As MarineInfo
            Dim marineinfo As New MarineInfo
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_Marine where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            For Each member In marineinfo.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(marineinfo, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(marineinfo, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(marineinfo, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(marineinfo, Date.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return marineinfo
        End Function
        Public Function GetPOB(ByVal ddrid As Integer) As POB
            Dim POBC As New POB
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_POB where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            For Each member In POBC.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(POBC, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "DateTime" Then
                                                member.SetValue(POBC, row(member.Name), Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(POBC, row(member.Name), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return POBC
        End Function
        Public Function GetPumps(ByVal ddrid As Integer) As Pumps_Collection
            Dim pumps_c As New Pumps_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_PUMPS where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim pumps As New Pumps
                            For Each member In pumps.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(pumps, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(pumps, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            pumps_c.Add(pumps)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return pumps_c
        End Function
        Public Function GetShakers(ByVal ddrid As Integer) As Shakers_Collection
            Dim shakers As New Shakers_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_Shakers where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim shaker As New Shakers
                            For Each member In shaker.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(shaker, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(shaker, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            shakers.Add(shaker)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return shakers
        End Function
        Public Function GetMud(ByVal ddrid As Integer) As Mud_Collection
            Dim muds As New Mud_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_Mud where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim mud As New Mud
                            For Each member In mud.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(mud, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(mud, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            muds.Add(mud)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return muds
        End Function
        Public Function GetActivities(ByVal ddrid As Integer) As Activities_Collection
            Dim activities As New Activities_Collection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from Activities_Details where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim activity As New Activities
                            For Each member In activity.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(activity, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(activity, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            activities.Add(activity)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return activities
        End Function
        Public Function GetRiserProfile(ByVal ddrid As Integer) As RiserProfileCollection
            Dim risersProfiles As New RiserProfileCollection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from RiserProfile where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim rp As New RiserProfile
                            For Each member In rp.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(rp, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(rp, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            risersProfiles.Add(rp)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return risersProfiles
        End Function
        Public Function GetSOC(ByVal ddrid As Integer) As SOC
            Dim socdata As New SOC
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_SOC where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            For Each member In socdata.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(socdata, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(socdata, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return socdata
        End Function
        Public Function GetLogisticTransitLog(ByVal ddrid As Integer) As LogisticTransitLogCollection
            Dim transitlog As New LogisticTransitLogCollection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from DDR_LogisticTransitLog where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim logtransit As New LogisticTransitLog
                            For Each member In logtransit.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(logtransit, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(logtransit, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            transitlog.Add(logtransit)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return transitlog
        End Function

        Public Function GetUrgentsMR(ByVal ddrid As Integer) As UrgentsMRsCollection
            Dim mrs As New UrgentsMRsCollection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from Activities_UrgentMRs where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim mr As New UrgentMRs
                            For Each member In mr.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(mr, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(mr, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            mrs.Add(mr)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return mrs
        End Function

        Public Function GetWO(ByVal ddrid As Integer) As WorkOrderCollection
            Dim wos As New WorkOrderCollection
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select * from Activities_WorkOrders where DDR_Report_ID=" & ddrid.ToString, connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)

                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            Dim wo As New WorkOrder
                            For Each member In wo.GetType.GetProperties
                                If member.CanWrite Then
                                    If member.PropertyType.Name = "String" Or member.PropertyType.Name = "Int32" Or member.PropertyType.Name = "DateTime" Or member.PropertyType.Name = "Boolean" Then
                                        If Not IsDBNull(row(member.Name)) Then
                                            If member.PropertyType.Name = "String" Then
                                                member.SetValue(wo, row(member.Name).ToString, Nothing)
                                            End If
                                            If member.PropertyType.Name = "Int32" Then
                                                member.SetValue(wo, Integer.Parse(row(member.Name)), Nothing)
                                            End If
                                        End If
                                    End If
                                End If
                            Next
                            wos.Add(wo)
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return wos
        End Function


#End Region

        Public Sub LockReprot(ByVal DDRID As Integer)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("update ddr_Control set Lock=-1 where DDRID=" & DDRID.ToString, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub UnlockReprot(ByVal DDRID As Integer)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("update ddr_Control set Lock=0 where DDRID=" & DDRID.ToString, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub GetUserGroup(ByVal suser As com.entities.SessionUser)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select UserGroup from users_group where username='" & suser.User & "'", connection.Connection)
                If Not IsDBNull(connection.Command.ExecuteScalar()) Then
                    suser.Group = connection.Command.ExecuteScalar()
                Else
                    suser.Group = "View"
                End If

            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub GetUserDeparmentID(ByVal suser As com.entities.SessionUser)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select DepartmentID from users_group where username='" & suser.User & "'", connection.Connection)
                suser.DepartmentId = connection.Command.ExecuteScalar()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub GetUseremail(ByVal suser As com.entities.SessionUser)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select email from users_group where username='" & suser.User & "'", connection.Connection)
                suser.email = connection.Command.ExecuteScalar()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Function GetDeparmentID(ByVal DeparmentName As String) As Integer
            Dim deparmentid As Integer
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select Deparment_ID from Activities_Deparments where description='" & DeparmentName & "'", connection.Connection)
                deparmentid = connection.Command.ExecuteScalar()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            Return deparmentid
        End Function
        Public Sub GetUserDeparmentName(ByVal suser As com.entities.SessionUser)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select Description from Activities_Deparments where Deparment_ID=" & suser.DepartmentId, connection.Connection)
                suser.DeparmentName = connection.Command.ExecuteScalar()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub PrepareNotification(ByVal emailcollection As com.Notifier.Email.EmailObjCollection, ByVal templatemessage As com.Notifier.Email.EmailObj, ByVal sender As String)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("select email from Users_Group where notify=-1", connection.Connection)
                connection.Adap = New OleDb.OleDbDataAdapter(connection.Command)
                Dim dts As New DataSet
                connection.Adap.Fill(dts)
                If dts.Tables.Count > 0 Then
                    If dts.Tables(0).Rows.Count > 0 Then
                        For Each row As DataRow In dts.Tables(0).Rows
                            If Not IsDBNull(row(0)) Then
                                Dim message As New com.Notifier.Email.EmailObj
                                message = templatemessage
                                message.eTo = row(0)
                                message.From = sender
                                emailcollection.Add(message)
                            End If
                        Next
                    End If
                End If
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub
        Public Sub UpdateDateAndReportNo(ByVal reportno As Integer, ByVal reportdate As Date, ByVal ddrid As Integer)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("update DDR_Control set ReportDate=#" & reportdate.ToString("MM/dd/yyyy") & "#,ReportNo=" & reportno & " where DDRID=" & ddrid, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

#Region "Activities"


        Public Sub SaveActivities(ByVal ddr As DDRControl)
            If Not IsNothing(ddr.DDRReport.Activities) Then
                For Each item As com.entities.Activities In ddr.DDRReport.Activities.Items
                    SaveActivitie(item)
                Next
            End If

        End Sub

        Public Sub SaveActivitie(ByVal act As com.entities.Activities)
            Dim qbuilder As New QueryBuilder(Of Activities)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = act
            qbuilder.BuildInsert("Activities_Details")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()

            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try

            act.Act_Detail_ID = GetLastID("Activities_Details", "Act_Detail_ID")
        End Sub

        Public Sub ModifyActivities(ByVal ddr As DDRControl)
            If Not IsNothing(ddr.DDRReport.Activities) Then
                For Each item As com.entities.Activities In ddr.DDRReport.Activities.Items
                    UpdateActivitie(item)
                Next
                'DeleteActivities(ddr.DDRID)
                'SaveActivities(ddr)
            End If
        End Sub

        Public Sub UpdateActivitie(ByVal activity As Activities)
            Dim qbuilder As New QueryBuilder(Of Activities)
            qbuilder.TypeQuery = TypeQuery.Update
            qbuilder.Entity = activity
            qbuilder.BuildUpdate("Activities_Details", "Act_Detail_ID", activity.Act_Detail_ID)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub DeleteActivities(ByVal DDRID As Integer)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("Delete from Activities_Details where DDR_Report_ID=" & DDRID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()

            End Try
        End Sub
        Public Sub DeleteActivities(ByVal activity As Activities)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("Delete from Activities_Details where Act_Detail_ID=" & activity.Act_Detail_ID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()

            End Try
        End Sub
#End Region

#Region "MR Urgents"

        Public Sub UpdateUrgentMR(ByVal MR As UrgentMRs)
            Dim qbuilder As New QueryBuilder(Of UrgentMRs)
            qbuilder.TypeQuery = TypeQuery.Update
            qbuilder.Entity = MR
            qbuilder.BuildUpdate("Activities_UrgentMRs", "MRUrgentID", MR.MRUrgentID)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub SaveUrgentMRs(ByVal MR As com.entities.UrgentMRs)
            Dim qbuilder As New QueryBuilder(Of UrgentMRs)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = MR
            qbuilder.BuildInsert("Activities_UrgentMRs")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            MR.MRUrgentID = GetLastID("Activities_UrgentMRs", "MRUrgentID")
        End Sub

        Public Sub DeleteUrgentMR(ByVal MR As UrgentMRs)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("Delete from Activities_UrgentMRs where MRUrgentID=" & MR.MRUrgentID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()

            End Try
        End Sub

#End Region

#Region "Work Orders"

        Public Sub UpdateWorkOrder(ByVal WO As WorkOrder)
            Dim qbuilder As New QueryBuilder(Of WorkOrder)
            qbuilder.TypeQuery = TypeQuery.Update
            qbuilder.Entity = WO
            qbuilder.BuildUpdate("Activities_WorkOrders", "WorkOrderID", WO.WorkOrderID)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
        End Sub

        Public Sub SaveWorkOrder(ByVal WO As WorkOrder)
            Dim qbuilder As New QueryBuilder(Of WorkOrder)
            qbuilder.TypeQuery = TypeQuery.Insert
            qbuilder.Entity = WO
            qbuilder.BuildInsert("Activities_WorkOrders")
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand(qbuilder.Query, connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()
            End Try
            WO.WorkOrderID = GetLastID("Activities_WorkOrders", "WorkOrderID")
        End Sub

        Public Sub DeleteWorkOrder(ByVal WO As WorkOrder)
            Try
                OpenDB("DB-DDR")
                connection.Command = New OleDb.OleDbCommand("Delete from Activities_WorkOrders where WorkOrderID=" & WO.WorkOrderID.ToString & "", connection.Connection)
                connection.Command.ExecuteNonQuery()
            Catch ex As Exception
                Throw
            Finally
                CloseDB()

            End Try
        End Sub

#End Region


    End Class
End Namespace
