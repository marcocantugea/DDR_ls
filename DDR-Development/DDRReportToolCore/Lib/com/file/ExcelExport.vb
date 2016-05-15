﻿'class to open excel document and get information of the transmittal
Imports System
Imports System.Globalization
Imports System.Reflection ' For Missing.Value and BindingFlags
Imports System.Runtime.InteropServices ' For COMException
Imports Microsoft.Office.Interop.Excel
Imports System.Threading
Namespace com.file
    Public Class ExcelExport
        Dim xlApp As Application
        Dim xlWorkBook As Workbook
        Dim xlSheet As Worksheet
        Dim Document As String
        Dim oldCI As CultureInfo

        Public Sub New(ByVal Document As String)
            Me.Document = Document
        End Sub

        Public Sub OpenDocument()
            Try
                'Try
                xlApp = New Application
                ''xlApp.Visible = True
                xlApp.Visible = True
                oldCI = Thread.CurrentThread.CurrentCulture
                Thread.CurrentThread.CurrentCulture = New CultureInfo("en-US")

                xlWorkBook = xlApp.Workbooks.Open(Document)
                xlSheet = xlApp.Workbooks.Application.ActiveSheet

               

            Catch ex As Exception
                Throw New Exception("Error on OpenDocument() Msg:" & ex.Message.ToString & " Document:" & Document)
            End Try
        End Sub

        Public Sub FillDDRonExcel(ByVal DDR As com.entities.DDRControl)
            OpenDocument()
            Dim wksheetAreas As Worksheet
            wksheetAreas = xlApp.Workbooks.Application.Worksheets(1)
            wksheetAreas.Activate()

            If Not IsNothing(DDR) Then
                If Not IsNothing(DDR.DDRReport) Then
                    'fill Header of DDR
                    xlSheet.Cells(3, 4).value = DDR.ReportDate.ToString("MM/dd/yyyy")
                    xlSheet.Cells(6, 4).value = DDR.DDRReport.Midnigth_Depth
                    xlSheet.Cells(7, 4).value = DDR.DDRReport.TVD
                    xlSheet.Cells(8, 4).value = DDR.DDRReport.Yesterdays_Depth
                    xlSheet.Cells(9, 4).value = DDR.DDRReport.Progress
                    xlSheet.Cells(10, 4).value = DDR.DDRReport.Formation
                    xlSheet.Cells(11, 4).value = DDR.DDRReport.Mud_weight

                    xlSheet.Cells(3, 8).value = DDR.ReportNo
                    xlSheet.Cells(4, 8).value = DDR.DDRReport.Well
                    xlSheet.Cells(5, 8).value = DDR.DDRReport.PemexUnit
                    ' xlSheet.Cells(6, 8).value = DDR.DDRReport.PemexUnit
                    xlSheet.Cells(6, 8).value = DDR.DDRReport.Country
                    'xlSheet.Cells(7, 8).value = DDR.DDRReport.KSP_Hrs
                    xlSheet.Cells(7, 8).value = DDR.DDRReport.Washpipehrs

                    xlSheet.Cells(8, 8).value = DDR.DDRReport.Todays_Rot_Hrs
                    xlSheet.Cells(9, 8).value = DDR.DDRReport.Yest_Rot_Hrs
                    xlSheet.Cells(10, 8).value = DDR.DDRReport.Cum_Rot_Hrs
                    xlSheet.Cells(11, 8).value = DDR.DDRReport.Leak_off_test

                    xlSheet.Cells(3, 12).value = DDR.DDRReport.DaysFromSpud
                    xlSheet.Cells(4, 12).value = DDR.DDRReport.ProposedTD
                    xlSheet.Cells(5, 12).value = DDR.DDRReport.RKBToWH
                    xlSheet.Cells(6, 12).value = DDR.DDRReport.RKBtoSeaBeadMtrs
                    xlSheet.Cells(7, 12).value = DDR.DDRReport.TOLSize
                    xlSheet.Cells(8, 12).value = DDR.DDRReport.LastCasing
                    xlSheet.Cells(9, 12).value = DDR.DDRReport.WeightGR
                    xlSheet.Cells(10, 12).value = DDR.DDRReport.CasingID
                    xlSheet.Cells(11, 12).value = DDR.DDRReport.CsgShoeMtrs

                    xlSheet.Cells(3, 15).value = DDR.DDRReport.EstendWell
                    xlSheet.Cells(4, 15).value = DDR.DDRReport.DDRDate

                    'fill total hrs and toolpusher coments onthe excel
                    xlSheet.Cells(35, 4).value = DDR.DDRReport.TotalsHrs
                    xlSheet.Cells(36, 6).value = DDR.DDRReport.Tool_Pusher_Comments
                    xlSheet.Cells(36, 12).value = DDR.DDRReport.Activities_Next24_hrs

                    'Fill Bits header information
                    xlSheet.Cells(46, 4).value = DDR.DDRReport.BITS_AnnVelCsg
                    xlSheet.Cells(46, 7).value = DDR.DDRReport.BITS_AnnVel
                    xlSheet.Cells(46, 10).value = DDR.DDRReport.BITS_DCVel
                    xlSheet.Cells(46, 14).value = DDR.DDRReport.BITS_NozzleVel

                    'Fill Drill string information
                    xlSheet.Cells(56, 4).value = DDR.DDRReport.DrillString_PUWeight
                    xlSheet.Cells(57, 4).value = DDR.DDRReport.DrillString_StringWeight
                    xlSheet.Cells(56, 7).value = DDR.DDRReport.DrillString_StackOffWeigth
                    'xlSheet.Cells(56, 9).value = DDR.DDRReport.DrillString_Static
                    xlSheet.Cells(56, 11).value = DDR.DDRReport.DrillString_WOB
                    xlSheet.Cells(56, 13).value = DDR.DDRReport.DrillString_RPM
                    xlSheet.Cells(56, 15).value = DDR.DDRReport.DrillString_Torque
                    xlSheet.Cells(56, 9).value = DDR.DDRReport.DrillString_RotWeigth

                    'fill BHA
                    xlSheet.Cells(64, 4).value = DDR.DDRReport.BHA_BottomHoleAssembly
                    xlSheet.Cells(65, 5).value = DDR.DDRReport.BHA_BelowJars
                    xlSheet.Cells(65, 9).value = DDR.DDRReport.BHA_BAGWT
                    'xlSheet.Cells(65, 16).value = DDR.DDRReport.BHA_Comments

                    'fill mud
                    xlSheet.Cells(80, 6).value = DDR.DDRReport.Mud_VolumeActivePits
                    xlSheet.Cells(80, 9).value = DDR.DDRReport.Mud_HoleVolume
                    xlSheet.Cells(80, 12).value = DDR.DDRReport.Mud_System
                    'xlSheet.Cells(80, 14).value = DDR.DDRReport.Mud_Percent
                    xlSheet.Cells(80, 16).value = DDR.DDRReport.Mud_MaxGas

                    'fill Marine Info
                    xlSheet.Cells(40, 2).value = DDR.DDRReport.Wind_Dir
                    xlSheet.Cells(40, 3).value = DDR.DDRReport.Wind_Speed
                    xlSheet.Cells(40, 4).value = DDR.DDRReport.Current_Dir
                    xlSheet.Cells(40, 5).value = DDR.DDRReport.Current_Speed
                    xlSheet.Cells(40, 6).value = DDR.DDRReport.Temp_Air
                    xlSheet.Cells(40, 7).value = DDR.DDRReport.Temp_Sea
                    xlSheet.Cells(40, 8).value = DDR.DDRReport.Barometer
                    xlSheet.Cells(40, 9).value = DDR.DDRReport.Sea
                    xlSheet.Cells(40, 10).value = DDR.DDRReport.Swell
                    xlSheet.Cells(40, 11).value = DDR.DDRReport.Roll
                    xlSheet.Cells(40, 12).value = DDR.DDRReport.Pitch
                    xlSheet.Cells(40, 13).value = DDR.DDRReport.Heave
                    xlSheet.Cells(40, 14).value = DDR.DDRReport.Visibilty
                    xlSheet.Cells(38, 16).value = DDR.DDRReport.MarineInfo.Comments


                    If Not IsNothing(DDR.DDRReport.MarineInfo) Then
                        xlSheet.Cells(87, 4).value = DDR.DDRReport.MarineInfo.AirGap
                        xlSheet.Cells(87, 7).value = DDR.DDRReport.MarineInfo.UsedPlayload
                        xlSheet.Cells(87, 10).value = DDR.DDRReport.MarineInfo.RemainingPayload
                        xlSheet.Cells(88, 4).value = DDR.DDRReport.MarineInfo.LastboatDrill.ToString("MM/dd/yyyy")
                        xlSheet.Cells(88, 7).value = DDR.DDRReport.MarineInfo.FireDrill.ToString("MM/dd/yyyy")
                        xlSheet.Cells(88, 10).value = DDR.DDRReport.MarineInfo.BOPTest
                        xlSheet.Cells(88, 12).value = DDR.DDRReport.MarineInfo.COMTest
                        xlSheet.Cells(88, 15).value = DDR.DDRReport.DrillLineSlippedandCut
                        xlSheet.Cells(87, 15).value = DDR.DDRReport.MarineInfo.ToneMilesSinceLastCut
                        'missing totton miles since las cut
                        'xlSheet.Cells(85, 11).value = DDR.DDRReport.MarineInfo.COMTest
                        xlSheet.Cells(91, 4).value = DDR.DDRReport.MarineInfo.YestStock_PotWater
                        xlSheet.Cells(92, 4).value = DDR.DDRReport.MarineInfo.YestStock_Diesel
                        xlSheet.Cells(94, 4).value = DDR.DDRReport.MarineInfo.YestStock_DrillWater
                        xlSheet.Cells(95, 4).value = DDR.DDRReport.MarineInfo.YestStock_LubOil
                        xlSheet.Cells(96, 4).value = DDR.DDRReport.MarineInfo.YestStock_Barite
                        xlSheet.Cells(97, 4).value = DDR.DDRReport.MarineInfo.YestStock_Bentonite
                        xlSheet.Cells(98, 4).value = DDR.DDRReport.MarineInfo.YestStock_Gel
                        xlSheet.Cells(99, 4).value = DDR.DDRReport.MarineInfo.YestStock_CementG
                        xlSheet.Cells(100, 4).value = DDR.DDRReport.MarineInfo.YestStock_CmtBlended

                        xlSheet.Cells(91, 7).value = DDR.DDRReport.MarineInfo.TodayStock_PotWater
                        xlSheet.Cells(92, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Diesel
                        xlSheet.Cells(94, 7).value = DDR.DDRReport.MarineInfo.TodayStock_DrillWater
                        xlSheet.Cells(95, 7).value = DDR.DDRReport.MarineInfo.TodayStock_LubOil
                        xlSheet.Cells(96, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Barite
                        xlSheet.Cells(97, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Bentonite
                        xlSheet.Cells(98, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Gel
                        xlSheet.Cells(99, 7).value = DDR.DDRReport.MarineInfo.TodayStock_CementG
                        xlSheet.Cells(100, 7).value = DDR.DDRReport.MarineInfo.TodayStock_CMTBlended

                        xlSheet.Cells(91, 9).value = DDR.DDRReport.MarineInfo.Used_PotWater
                        xlSheet.Cells(92, 9).value = DDR.DDRReport.MarineInfo.Used_Diesel
                        xlSheet.Cells(94, 9).value = DDR.DDRReport.MarineInfo.Used_DrillWater
                        xlSheet.Cells(95, 9).value = DDR.DDRReport.MarineInfo.Used_LubOil
                        xlSheet.Cells(96, 9).value = DDR.DDRReport.MarineInfo.Used_Barite
                        xlSheet.Cells(97, 9).value = DDR.DDRReport.MarineInfo.Used_Bentoniote
                        xlSheet.Cells(98, 9).value = DDR.DDRReport.MarineInfo.Used_Gel
                        xlSheet.Cells(99, 9).value = DDR.DDRReport.MarineInfo.Used_CementG
                        xlSheet.Cells(100, 9).value = DDR.DDRReport.MarineInfo.Used_CmtBlended

                        xlSheet.Cells(91, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_PotWater
                        xlSheet.Cells(92, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Diesel
                        xlSheet.Cells(94, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_DrillWater
                        xlSheet.Cells(95, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_LubOil
                        xlSheet.Cells(96, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Barite
                        xlSheet.Cells(97, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Bentoniote
                        xlSheet.Cells(98, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Gel
                        xlSheet.Cells(99, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_CementG
                        xlSheet.Cells(100, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_CmtBlended

                        xlSheet.Cells(91, 14).value = DDR.DDRReport.MarineInfo.Helifuel
                        'xlSheet.Cells(89, 14).value = DDR.DDRReport.MarineInfo.LubOil
                        xlSheet.Cells(94, 14).value = DDR.DDRReport.MarineInfo.Nitrogen_FullBottles
                        xlSheet.Cells(95, 14).value = DDR.DDRReport.MarineInfo.Oxygen_FullBottles
                        xlSheet.Cells(96, 14).value = DDR.DDRReport.MarineInfo.Acetyl_FullBottles
                        xlSheet.Cells(98, 14).value = DDR.DDRReport.MarineInfo.Brine
                        xlSheet.Cells(99, 14).value = DDR.DDRReport.MarineInfo.Base_oil

                        xlSheet.Cells(94, 15).value = DDR.DDRReport.MarineInfo.Nitrogen_InUse
                        xlSheet.Cells(95, 15).value = DDR.DDRReport.MarineInfo.Oxygen_InUse
                        xlSheet.Cells(96, 15).value = DDR.DDRReport.MarineInfo.Acetyl_InUse
                        
                        xlSheet.Cells(94, 16).value = DDR.DDRReport.MarineInfo.Nitrogen_Empty
                        xlSheet.Cells(95, 16).value = DDR.DDRReport.MarineInfo.Oxygen_Empty
                        xlSheet.Cells(96, 16).value = DDR.DDRReport.MarineInfo.Acetyl_Empty
                        xlSheet.Cells(93, 9).value = DDR.DDRReport.UsedByPEP
                    End If

                    'save POB
                    If Not IsNothing(DDR.DDRReport.POB) Then
                        xlSheet.Cells(103, 4).value = DDR.DDRReport.POB.GRCrew
                        xlSheet.Cells(103, 7).value = DDR.DDRReport.POB.GRServ
                        xlSheet.Cells(103, 9).value = DDR.DDRReport.POB.Catering
                        xlSheet.Cells(103, 11).value = DDR.DDRReport.POB.Pemex
                        xlSheet.Cells(103, 13).value = DDR.DDRReport.POB.OpSer
                        xlSheet.Cells(104, 16).value = DDR.DDRReport.POB.DaysFromLAstLTA
                        'xlSheet.Cells(100, 16).value = DDR.DDRReport.POB.Total
                        xlSheet.Cells(104, 4).value = DDR.DDRReport.POB.DailyCost
                        xlSheet.Cells(104, 7).value = DDR.DDRReport.POB.AccCost
                        xlSheet.Cells(104, 11).value = DDR.DDRReport.POB.AverageCost
                        xlSheet.Cells(104, 4).value = DDR.DDRReport.POB.DailyCost
                    End If

                    'Save ddr hrs
                    If Not IsNothing(DDR.DDRReport.DDRHrs) Then
                        Dim y As Integer = 14
                        For Each DDRhr As com.entities.DDRHrs In DDR.DDRReport.DDRHrs.Items
                            If y <= 33 Then
                                xlSheet.Cells(y, 2).value = DDRhr.Fromv
                                xlSheet.Cells(y, 3).value = DDRhr.Tov
                                xlSheet.Cells(y, 4).value = DDRhr.Total
                                xlSheet.Cells(y, 5).value = DDRhr.Code
                                xlSheet.Cells(y, 6).value = DDRhr.Comment
                                y = y + 1
                            Else
                                y = 14
                            End If
                        Next
                    End If

                    'save bits
                    If Not IsNothing(DDR.DDRReport.BITS) Then
                        Dim y As Integer = 44
                        For Each bit As com.entities.BITS In DDR.DDRReport.BITS.Items
                            If y <= 45 Then
                                xlSheet.Cells(y, 3).value = bit.bit_No
                                xlSheet.Cells(y, 4).value = bit.bit_Size
                                xlSheet.Cells(y, 6).value = bit.bit_Make
                                xlSheet.Cells(y, 7).value = bit.bit_Serial
                                xlSheet.Cells(y, 8).value = bit.Bit_type
                                xlSheet.Cells(y, 9).value = bit.bit_Jets
                                xlSheet.Cells(y, 11).value = bit.bit_TFA
                                xlSheet.Cells(y, 12).value = bit.bit_Out
                                xlSheet.Cells(y, 13).value = bit.bit_In
                                xlSheet.Cells(y, 14).value = bit.bit_Mtrs
                                xlSheet.Cells(y, 16).value = bit.bit_Comments
                                y = y + 1
                            Else
                                y = 44
                            End If
                        Next
                    End If

                    'save drill string
                    If Not IsNothing(DDR.DDRReport.DrillString) Then
                        Dim y As Integer = 49
                        For Each drillst As com.entities.DrillString In DDR.DDRReport.DrillString.Items
                            If y <= 55 Then
                                xlSheet.Cells(y, 2).value = drillst.Description
                                xlSheet.Cells(y, 4).value = drillst.SizeDR
                                xlSheet.Cells(y, 7).value = drillst.Weight
                                xlSheet.Cells(y, 9).value = drillst.Grade
                                xlSheet.Cells(y, 11).value = drillst.ToolJoint
                                xlSheet.Cells(y, 13).value = drillst.ToolJntOD
                                xlSheet.Cells(y, 15).value = drillst.TotalOnBoard
                                y = y + 1
                            Else
                                y = 49
                            End If
                        Next
                    End If

                    'save drilll string survey
                    If Not IsNothing(DDR.DDRReport.DrillString_Survey) Then
                        Dim y As Integer = 59
                        For Each drillst As com.entities.DrillString_Survey In DDR.DDRReport.DrillString_Survey.Items
                            If y <= 62 Then
                                'xlSheet.Cells(y, 3).value = drillst.DirectionalSurveys
                                xlSheet.Cells(y, 4).value = drillst.MID
                                xlSheet.Cells(y, 6).value = drillst.TVD
                                xlSheet.Cells(y, 8).value = drillst.INC
                                xlSheet.Cells(y, 10).value = drillst.AZM
                                'xlSheet.Cells(y, 16).value = drillst.Comments
                                y = y + 1
                            Else
                                y = 59
                            End If
                        Next
                    End If

                    'save pumps
                    If Not IsNothing(DDR.DDRReport.Pumps) Then
                        Dim y As Integer = 68
                        For Each pump As com.entities.Pumps In DDR.DDRReport.Pumps.Items
                            If y <= 71 Then
                                xlSheet.Cells(y, 7).value = pump.Stroke
                                xlSheet.Cells(y, 8).value = pump.Liners
                                xlSheet.Cells(y, 9).value = pump.SPM
                                xlSheet.Cells(y, 10).value = pump.GPM
                                xlSheet.Cells(y, 12).value = pump.Press
                                xlSheet.Cells(y, 13).value = pump.MP
                                xlSheet.Cells(y, 14).value = pump.CLF
                                xlSheet.Cells(y, 15).value = pump.CLFCK
                                xlSheet.Cells(y, 16).value = pump.s30StrokesChoke
                                xlSheet.Cells(y, 17).value = pump.s30StrokesCK
                                xlSheet.Cells(y, 18).value = pump.s40StrokesChoke
                                xlSheet.Cells(y, 19).value = pump.s40StrokesCK
                                xlSheet.Cells(y, 20).value = pump.s50StrokesChoke
                                xlSheet.Cells(y, 21).value = pump.s50StrokesCK
                                y = y + 1
                            Else
                                y = 68
                            End If
                        Next
                    End If

                    'Save Shakers
                    If Not IsNothing(DDR.DDRReport.Shakers) Then
                        Dim y As Integer = 73
                        For Each shaker As com.entities.Shakers In DDR.DDRReport.Shakers.Items
                            If y <= 78 Then
                                xlSheet.Cells(y, 7).value = shaker.ScreenSize
                                xlSheet.Cells(y, 8).value = shaker.Top1
                                xlSheet.Cells(y, 9).value = shaker.Top2
                                xlSheet.Cells(y, 10).value = shaker.Top3
                                xlSheet.Cells(y, 11).value = shaker.Top4
                                xlSheet.Cells(y, 12).value = shaker.Bottom1
                                xlSheet.Cells(y, 13).value = shaker.Bottom2
                                xlSheet.Cells(y, 14).value = shaker.Bottom3
                                xlSheet.Cells(y, 15).value = shaker.Bottom4
                                y = y + 1
                            Else
                                y = 73
                            End If
                        Next
                    End If

                    'save mud
                    If Not IsNothing(DDR.DDRReport.Mud) Then
                        Dim y As Integer = 82
                        For Each mud As com.entities.Mud In DDR.DDRReport.Mud.Items
                            If y <= 85 Then
                                xlSheet.Cells(y, 3).value = mud.TimeMud
                                xlSheet.Cells(y, 4).value = mud.WT
                                xlSheet.Cells(y, 6).value = mud.VIS
                                xlSheet.Cells(y, 7).value = mud.WL
                                xlSheet.Cells(y, 8).value = mud.Cake
                                xlSheet.Cells(y, 9).value = mud.PH
                                xlSheet.Cells(y, 10).value = mud.Sand
                                xlSheet.Cells(y, 11).value = mud.Solids
                                xlSheet.Cells(y, 12).value = mud.PvYP
                                xlSheet.Cells(y, 13).value = mud.KCL
                                xlSheet.Cells(y, 14).value = mud.Pm
                                xlSheet.Cells(y, 15).value = mud.Comments
                                y = y + 1
                            Else
                                'y = 82
                            End If
                        Next
                    End If

                    'save Riser Profile
                    If Not IsNothing(DDR.DDRReport.RiserProfile) Then
                        Dim y As Integer = 108
                        For Each riserp As com.entities.RiserProfile In DDR.DDRReport.RiserProfile.Items
                            If y <= 114 Then
                                xlSheet.Cells(y, 2).value = riserp.IDBeacon
                                xlSheet.Cells(y, 3).value = riserp.Depth
                                xlSheet.Cells(y, 4).value = riserp.Temp6hrs
                                xlSheet.Cells(y, 5).value = riserp.Temp12hrs
                                xlSheet.Cells(y, 6).value = riserp.Temp18hrs
                                xlSheet.Cells(y, 7).value = riserp.Temp24hrs
                                xlSheet.Cells(y, 8).value = riserp.Current6hrs
                                xlSheet.Cells(y, 9).value = riserp.Current12hrs
                                xlSheet.Cells(y, 10).value = riserp.Current18hrs
                                xlSheet.Cells(y, 11).value = riserp.Current24hrs
                                xlSheet.Cells(y, 12).value = riserp.Direction6hrs
                                xlSheet.Cells(y, 13).value = riserp.Direction12hrs
                                xlSheet.Cells(y, 14).value = riserp.Direction18hrs
                                xlSheet.Cells(y, 15).value = riserp.Direction24hrs
                                y = y + 1
                            End If
                        Next
                    End If

                End If
            End If

            'Dim wksheetAreas As Worksheet
            'wksheetAreas = xlApp.Workbooks.Application.Worksheets(3)
            'wksheetAreas.Activate()


            'If Not IsNothing(DDR.DDRReport.Activities) Then
            '    Dim y As Integer = 2

            '    'Fill Marine
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Marine"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Fill Hydraulic / Mechanic
            '    y = 19
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Hydraulic/ Mechanic"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Subsea
            '    y = 32
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Subsea"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'ET /IT / ET
            '    y = 45
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Elect / ET / IT"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Drilling
            '    y = 58
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Drilling"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Safety
            '    y = 84
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Safety"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Store
            '    y = 97
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Stores"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Project
            '    y = 113
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Project"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next
            '    'Engineering
            '    y = 136
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Engineering"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next
            'End If

            'wksheetAreas = xlApp.Workbooks.Application.Worksheets(1)
            'xlSheet.Activate()
            'xlSheet.Name = "DDR_Report_" & Now.ToString("MMddyyyymmss")
            'CloseDocument()
        End Sub
        Public Sub FillDDRonExcel(ByVal DDR As com.entities.DDRControl, ByVal sheet As Integer, Optional ByVal lenguaje As String = "Eng")
            'OpenDocument()
            xlSheet = xlApp.Workbooks.Application.Worksheets(sheet)
            xlSheet.Activate()

            If Not IsNothing(DDR) Then
                If Not IsNothing(DDR.DDRReport) Then
                    'fill Header of DDR
                    xlSheet.Cells(3, 4).value = DDR.ReportDate.ToString("MM/dd/yyyy")
                    xlSheet.Cells(6, 4).value = DDR.DDRReport.Midnigth_Depth
                    xlSheet.Cells(7, 4).value = DDR.DDRReport.TVD
                    xlSheet.Cells(8, 4).value = DDR.DDRReport.Yesterdays_Depth
                    xlSheet.Cells(9, 4).value = DDR.DDRReport.Progress
                    xlSheet.Cells(10, 4).value = DDR.DDRReport.Formation
                    xlSheet.Cells(11, 4).value = DDR.DDRReport.Mud_weight

                    xlSheet.Cells(3, 8).value = DDR.ReportNo
                    xlSheet.Cells(4, 8).value = DDR.DDRReport.Well
                    xlSheet.Cells(5, 8).value = DDR.DDRReport.PemexUnit
                    ' xlSheet.Cells(6, 8).value = DDR.DDRReport.PemexUnit
                    xlSheet.Cells(6, 8).value = DDR.DDRReport.Country
                    'xlSheet.Cells(7, 8).value = DDR.DDRReport.KSP_Hrs
                    xlSheet.Cells(7, 8).value = DDR.DDRReport.Washpipehrs

                    xlSheet.Cells(8, 8).value = DDR.DDRReport.Todays_Rot_Hrs
                    xlSheet.Cells(9, 8).value = DDR.DDRReport.Yest_Rot_Hrs
                    xlSheet.Cells(10, 8).value = DDR.DDRReport.Cum_Rot_Hrs
                    xlSheet.Cells(11, 8).value = DDR.DDRReport.Leak_off_test

                    xlSheet.Cells(3, 12).value = DDR.DDRReport.DaysFromSpud
                    xlSheet.Cells(4, 12).value = DDR.DDRReport.ProposedTD
                    xlSheet.Cells(5, 12).value = DDR.DDRReport.RKBToWH
                    xlSheet.Cells(6, 12).value = DDR.DDRReport.RKBtoSeaBeadMtrs
                    xlSheet.Cells(7, 12).value = DDR.DDRReport.TOLSize
                    xlSheet.Cells(8, 12).value = DDR.DDRReport.LastCasing
                    xlSheet.Cells(9, 12).value = DDR.DDRReport.WeightGR
                    xlSheet.Cells(10, 12).value = DDR.DDRReport.CasingID
                    xlSheet.Cells(11, 12).value = DDR.DDRReport.CsgShoeMtrs

                    xlSheet.Cells(3, 15).value = DDR.DDRReport.EstendWell
                    xlSheet.Cells(4, 15).value = DDR.DDRReport.DDRDate

                    xlSheet.Cells(64, 15).Value = DDR.DDRReport.PumpsMeasureddepth
                    xlSheet.Cells(65, 15).Value = DDR.DDRReport.PumpsTrueverticaldepth
                    xlSheet.Cells(66, 15).Value = DDR.DDRReport.PumpsMudweigth

                    'fill total hrs and toolpusher coments onthe excel

                    xlSheet.Cells(35, 4).value = DDR.DDRReport.TotalsHrs
                    If lenguaje = "ESP" Then
                        xlSheet.Cells(36, 6).value = DDR.DDRReport.Tool_Pusher_Comments_Spanish
                        xlSheet.Cells(36, 12).value = DDR.DDRReport.Activities_Next24_hrs_spanish
                    Else
                        xlSheet.Cells(36, 6).value = DDR.DDRReport.Tool_Pusher_Comments
                        xlSheet.Cells(36, 12).value = DDR.DDRReport.Activities_Next24_hrs
                    End If
                    

                    'Fill Bits header information
                    xlSheet.Cells(46, 4).value = DDR.DDRReport.BITS_AnnVelCsg
                    xlSheet.Cells(46, 7).value = DDR.DDRReport.BITS_AnnVel
                    xlSheet.Cells(46, 10).value = DDR.DDRReport.BITS_DCVel
                    xlSheet.Cells(46, 14).value = DDR.DDRReport.BITS_NozzleVel

                    'Fill Drill string information
                    xlSheet.Cells(56, 4).value = DDR.DDRReport.DrillString_PUWeight
                    xlSheet.Cells(57, 4).value = DDR.DDRReport.DrillString_StringWeight
                    xlSheet.Cells(57, 7).value = DDR.DDRReport.DrillString_ECD12
                    xlSheet.Cells(57, 10).value = DDR.DDRReport.DrillString_ECD24
                    xlSheet.Cells(56, 7).value = DDR.DDRReport.DrillString_StackOffWeigth
                    'xlSheet.Cells(56, 9).value = DDR.DDRReport.DrillString_Static
                    xlSheet.Cells(56, 11).value = DDR.DDRReport.DrillString_WOB
                    xlSheet.Cells(56, 13).value = DDR.DDRReport.DrillString_RPM
                    xlSheet.Cells(56, 15).value = DDR.DDRReport.DrillString_Torque
                    xlSheet.Cells(56, 9).value = DDR.DDRReport.DrillString_RotWeigth

                    'fill BHA
                    xlSheet.Cells(64, 4).value = DDR.DDRReport.BHA_BottomHoleAssembly
                    xlSheet.Cells(65, 5).value = DDR.DDRReport.BHA_BelowJars
                    xlSheet.Cells(65, 9).value = DDR.DDRReport.BHA_BAGWT
                    'xlSheet.Cells(65, 16).value = DDR.DDRReport.BHA_Comments

                    'fill mud
                    xlSheet.Cells(80, 6).value = DDR.DDRReport.Mud_VolumeActivePits
                    xlSheet.Cells(80, 9).value = DDR.DDRReport.Mud_HoleVolume
                    xlSheet.Cells(80, 12).value = DDR.DDRReport.Mud_System
                    'xlSheet.Cells(80, 14).value = DDR.DDRReport.Mud_Percent
                    xlSheet.Cells(80, 16).value = DDR.DDRReport.Mud_MaxGas

                    'fill Marine Info
                    xlSheet.Cells(40, 2).value = DDR.DDRReport.Wind_Dir
                    xlSheet.Cells(40, 3).value = DDR.DDRReport.Wind_Speed
                    xlSheet.Cells(40, 4).value = DDR.DDRReport.Current_Dir
                    xlSheet.Cells(40, 5).value = DDR.DDRReport.Current_Speed
                    xlSheet.Cells(40, 6).value = DDR.DDRReport.Temp_Air
                    xlSheet.Cells(40, 7).value = DDR.DDRReport.Temp_Sea
                    xlSheet.Cells(40, 8).value = DDR.DDRReport.Barometer
                    xlSheet.Cells(40, 9).value = DDR.DDRReport.Sea
                    xlSheet.Cells(40, 10).value = DDR.DDRReport.Swell
                    xlSheet.Cells(40, 11).value = DDR.DDRReport.Roll
                    xlSheet.Cells(40, 12).value = DDR.DDRReport.Pitch
                    xlSheet.Cells(40, 13).value = DDR.DDRReport.Heave
                    xlSheet.Cells(40, 14).value = DDR.DDRReport.Visibilty
                    xlSheet.Cells(40, 15).value = DDR.DDRReport.MarineInfo.RigWash

                    If lenguaje = "ESP" Then
                        xlSheet.Cells(38, 16).value = DDR.DDRReport.MarineInfo.Comments_spanish
                    Else
                        xlSheet.Cells(38, 16).value = DDR.DDRReport.MarineInfo.Comments
                    End If



                    If Not IsNothing(DDR.DDRReport.MarineInfo) Then
                        xlSheet.Cells(87, 4).value = DDR.DDRReport.MarineInfo.AirGap
                        xlSheet.Cells(87, 7).value = DDR.DDRReport.MarineInfo.UsedPlayload
                        xlSheet.Cells(87, 10).value = DDR.DDRReport.MarineInfo.RemainingPayload
                        xlSheet.Cells(88, 4).value = DDR.DDRReport.MarineInfo.LastboatDrill.ToString("MM/dd/yyyy")
                        xlSheet.Cells(88, 7).value = DDR.DDRReport.MarineInfo.FireDrill.ToString("MM/dd/yyyy")
                        xlSheet.Cells(88, 10).value = DDR.DDRReport.MarineInfo.BOPTest
                        xlSheet.Cells(88, 12).value = DDR.DDRReport.MarineInfo.COMTest
                        xlSheet.Cells(88, 15).value = DDR.DDRReport.DrillLineSlippedandCut
                        xlSheet.Cells(87, 15).value = DDR.DDRReport.MarineInfo.ToneMilesSinceLastCut
                        'missing totton miles since las cut
                        'xlSheet.Cells(85, 11).value = DDR.DDRReport.MarineInfo.COMTest
                        xlSheet.Cells(91, 4).value = DDR.DDRReport.MarineInfo.YestStock_PotWater
                        xlSheet.Cells(92, 4).value = DDR.DDRReport.MarineInfo.YestStock_Diesel
                        xlSheet.Cells(94, 4).value = DDR.DDRReport.MarineInfo.YestStock_DrillWater
                        xlSheet.Cells(95, 4).value = DDR.DDRReport.MarineInfo.YestStock_LubOil
                        xlSheet.Cells(96, 4).value = DDR.DDRReport.MarineInfo.YestStock_Barite
                        xlSheet.Cells(97, 4).value = DDR.DDRReport.MarineInfo.YestStock_Bentonite
                        xlSheet.Cells(98, 4).value = DDR.DDRReport.MarineInfo.YestStock_Gel
                        xlSheet.Cells(99, 4).value = DDR.DDRReport.MarineInfo.YestStock_CementG
                        xlSheet.Cells(100, 4).value = DDR.DDRReport.MarineInfo.YestStock_CmtBlended

                        xlSheet.Cells(91, 7).value = DDR.DDRReport.MarineInfo.TodayStock_PotWater
                        xlSheet.Cells(92, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Diesel
                        xlSheet.Cells(94, 7).value = DDR.DDRReport.MarineInfo.TodayStock_DrillWater
                        xlSheet.Cells(95, 7).value = DDR.DDRReport.MarineInfo.TodayStock_LubOil
                        xlSheet.Cells(96, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Barite
                        xlSheet.Cells(97, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Bentonite
                        xlSheet.Cells(98, 7).value = DDR.DDRReport.MarineInfo.TodayStock_Gel
                        xlSheet.Cells(99, 7).value = DDR.DDRReport.MarineInfo.TodayStock_CementG
                        xlSheet.Cells(100, 7).value = DDR.DDRReport.MarineInfo.TodayStock_CMTBlended

                        xlSheet.Cells(91, 9).value = DDR.DDRReport.MarineInfo.Used_PotWater
                        xlSheet.Cells(92, 9).value = DDR.DDRReport.MarineInfo.Used_Diesel
                        xlSheet.Cells(94, 9).value = DDR.DDRReport.MarineInfo.Used_DrillWater
                        xlSheet.Cells(95, 9).value = DDR.DDRReport.MarineInfo.Used_LubOil
                        xlSheet.Cells(96, 9).value = DDR.DDRReport.MarineInfo.Used_Barite
                        xlSheet.Cells(97, 9).value = DDR.DDRReport.MarineInfo.Used_Bentoniote
                        xlSheet.Cells(98, 9).value = DDR.DDRReport.MarineInfo.Used_Gel
                        xlSheet.Cells(99, 9).value = DDR.DDRReport.MarineInfo.Used_CementG
                        xlSheet.Cells(100, 9).value = DDR.DDRReport.MarineInfo.Used_CmtBlended

                        xlSheet.Cells(91, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_PotWater
                        xlSheet.Cells(92, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Diesel
                        xlSheet.Cells(94, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_DrillWater
                        xlSheet.Cells(95, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_LubOil
                        xlSheet.Cells(96, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Barite
                        xlSheet.Cells(97, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Bentoniote
                        xlSheet.Cells(98, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_Gel
                        xlSheet.Cells(99, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_CementG
                        xlSheet.Cells(100, 11).value = DDR.DDRReport.MarineInfo.RecivedMade_CmtBlended

                        xlSheet.Cells(91, 14).value = DDR.DDRReport.MarineInfo.Helifuel
                        'xlSheet.Cells(89, 14).value = DDR.DDRReport.MarineInfo.LubOil
                        xlSheet.Cells(94, 14).value = DDR.DDRReport.MarineInfo.Nitrogen_FullBottles
                        xlSheet.Cells(95, 14).value = DDR.DDRReport.MarineInfo.Oxygen_FullBottles
                        xlSheet.Cells(96, 14).value = DDR.DDRReport.MarineInfo.Acetyl_FullBottles
                        xlSheet.Cells(98, 14).value = DDR.DDRReport.MarineInfo.Brine
                        xlSheet.Cells(99, 14).value = DDR.DDRReport.MarineInfo.Base_oil

                        xlSheet.Cells(94, 15).value = DDR.DDRReport.MarineInfo.Nitrogen_InUse
                        xlSheet.Cells(95, 15).value = DDR.DDRReport.MarineInfo.Oxygen_InUse
                        xlSheet.Cells(96, 15).value = DDR.DDRReport.MarineInfo.Acetyl_InUse

                        xlSheet.Cells(94, 16).value = DDR.DDRReport.MarineInfo.Nitrogen_Empty
                        xlSheet.Cells(95, 16).value = DDR.DDRReport.MarineInfo.Oxygen_Empty
                        xlSheet.Cells(96, 16).value = DDR.DDRReport.MarineInfo.Acetyl_Empty
                        xlSheet.Cells(93, 9).value = DDR.DDRReport.UsedByPEP
                    End If

                    'save POB
                    If Not IsNothing(DDR.DDRReport.POB) Then
                        xlSheet.Cells(103, 4).value = DDR.DDRReport.POB.GRCrew
                        xlSheet.Cells(103, 7).value = DDR.DDRReport.POB.GRServ
                        xlSheet.Cells(103, 9).value = DDR.DDRReport.POB.Catering
                        xlSheet.Cells(103, 11).value = DDR.DDRReport.POB.Pemex
                        xlSheet.Cells(103, 13).value = DDR.DDRReport.POB.OpSer
                        xlSheet.Cells(104, 16).value = DDR.DDRReport.POB.DaysFromLAstLTA
                        'xlSheet.Cells(100, 16).value = DDR.DDRReport.POB.Total
                        xlSheet.Cells(104, 4).value = DDR.DDRReport.POB.DailyCost
                        xlSheet.Cells(104, 7).value = DDR.DDRReport.POB.AccCost
                        xlSheet.Cells(104, 11).value = DDR.DDRReport.POB.AverageCost
                        xlSheet.Cells(104, 4).value = DDR.DDRReport.POB.DailyCost
                    End If


                    'Save ddr hrs

                    If Not IsNothing(DDR.DDRReport.DDRHrs) Then
                        Dim ddrhrs As New Dictionary(Of String, com.entities.DDRHrs)
                        For Each DDRhr As com.entities.DDRHrs In DDR.DDRReport.DDRHrs.Items
                            ddrhrs.Add(DDRhr.Detail_HR_ID, DDRhr)
                        Next

                        Dim sorted = From pair In ddrhrs Order By pair.Value
                        Dim sotedDictrionary = sorted.ToDictionary(Function(p) p.Key, Function(p) p.Value)


                        Dim y As Integer = 14

                        For Each item As KeyValuePair(Of String, com.entities.DDRHrs) In sotedDictrionary
                            Dim DDRhr As com.entities.DDRHrs = item.Value
                            If y <= 33 Then
                                xlSheet.Cells(y, 2).value = DDRhr.Fromv
                                xlSheet.Cells(y, 3).value = DDRhr.Tov
                                xlSheet.Cells(y, 4).value = DDRhr.Total
                                xlSheet.Cells(y, 5).value = DDRhr.Code
                                If lenguaje.Equals("ESP") Then
                                    xlSheet.Cells(y, 6).value = DDRhr.CommentSpanish
                                Else
                                    xlSheet.Cells(y, 6).value = DDRhr.Comment
                                End If

                                y = y + 1
                            Else
                                y = 14
                            End If
                        Next

                        'For Each DDRhr As com.entities.DDRHrs In DDR.DDRReport.DDRHrs.Items
                        '    If y <= 33 Then
                        '        xlSheet.Cells(y, 2).value = DDRhr.Fromv
                        '        xlSheet.Cells(y, 3).value = DDRhr.Tov
                        '        xlSheet.Cells(y, 4).value = DDRhr.Total
                        '        xlSheet.Cells(y, 5).value = DDRhr.Code
                        '        If lenguaje.Equals("ESP") Then
                        '            xlSheet.Cells(y, 6).value = DDRhr.CommentSpanish
                        '        Else
                        '            xlSheet.Cells(y, 6).value = DDRhr.Comment
                        '        End If

                        '        y = y + 1
                        '    Else
                        '        y = 14
                        '    End If
                        'Next
                    End If

                    'save bits
                    If Not IsNothing(DDR.DDRReport.BITS) Then

                        'se agrega que solo que agarre los dos ultimos.
                        Dim bitstoprint As New List(Of entities.BITS)
                        'Seleciona los dos ultimos objetos de la coleccion
                        bitstoprint.Add(DDR.DDRReport.BITS.Items(DDR.DDRReport.BITS.Items.Count - 2))
                        bitstoprint.Add(DDR.DDRReport.BITS.Items(DDR.DDRReport.BITS.Items.Count - 1))

                        Dim y As Integer = 44
                        'se modificica el loop para que solo obtenga los dos ultimos.

                        'For Each bit As com.entities.BITS In DDR.DDRReport.BITS.Items
                        For Each bit As com.entities.BITS In bitstoprint
                            If y <= 45 Then
                                xlSheet.Cells(y, 3).value = bit.bit_No
                                xlSheet.Cells(y, 4).value = bit.bit_Size
                                xlSheet.Cells(y, 6).value = bit.bit_Make
                                xlSheet.Cells(y, 7).value = bit.bit_Serial
                                xlSheet.Cells(y, 8).value = bit.Bit_type
                                xlSheet.Cells(y, 9).value = bit.bit_Jets
                                xlSheet.Cells(y, 11).value = bit.bit_TFA
                                xlSheet.Cells(y, 12).value = bit.bit_Out
                                xlSheet.Cells(y, 13).value = bit.bit_In
                                xlSheet.Cells(y, 14).value = bit.bit_Mtrs
                                xlSheet.Cells(y, 16).value = bit.bit_Comments
                                y = y + 1
                            Else
                                y = 44
                            End If
                        Next
                    End If

                    'save drill string
                    If Not IsNothing(DDR.DDRReport.DrillString) Then
                        Dim y As Integer = 49
                        For Each drillst As com.entities.DrillString In DDR.DDRReport.DrillString.Items
                            If y <= 55 Then
                                xlSheet.Cells(y, 2).value = drillst.Description
                                xlSheet.Cells(y, 4).value = drillst.SizeDR
                                xlSheet.Cells(y, 7).value = drillst.Weight
                                xlSheet.Cells(y, 9).value = drillst.Grade
                                xlSheet.Cells(y, 11).value = drillst.ToolJoint
                                xlSheet.Cells(y, 13).value = drillst.ToolJntOD
                                xlSheet.Cells(y, 15).value = drillst.TotalOnBoard
                                y = y + 1
                            Else
                                y = 49
                            End If
                        Next
                    End If

                    'save drilll string survey
                    If Not IsNothing(DDR.DDRReport.DrillString_Survey) Then
                        Dim y As Integer = 59
                        For Each drillst As com.entities.DrillString_Survey In DDR.DDRReport.DrillString_Survey.Items
                            If y <= 62 Then
                                'xlSheet.Cells(y, 3).value = drillst.DirectionalSurveys
                                xlSheet.Cells(y, 4).value = drillst.MID
                                xlSheet.Cells(y, 6).value = drillst.TVD
                                xlSheet.Cells(y, 8).value = drillst.INC
                                xlSheet.Cells(y, 10).value = drillst.AZM
                                'xlSheet.Cells(y, 16).value = drillst.Comments
                                y = y + 1
                            Else
                                y = 59
                            End If
                        Next
                    End If

                    'save pumps
                    If Not IsNothing(DDR.DDRReport.Pumps) Then
                        Dim y As Integer = 68
                        For Each pump As com.entities.Pumps In DDR.DDRReport.Pumps.Items
                            If y <= 71 Then
                                xlSheet.Cells(y, 7).value = pump.Stroke
                                xlSheet.Cells(y, 8).value = pump.Liners
                                xlSheet.Cells(y, 9).value = pump.SPM
                                xlSheet.Cells(y, 10).value = pump.GPM
                                xlSheet.Cells(y, 12).value = pump.Press
                                'xlSheet.Cells(y, 13).value = pump.MP
                                xlSheet.Cells(y, 14).value = pump.CLF
                                xlSheet.Cells(y, 15).value = pump.CLFCK
                                xlSheet.Cells(y, 16).value = pump.s30StrokesChoke
                                xlSheet.Cells(y, 17).value = pump.s30StrokesCK
                                xlSheet.Cells(y, 18).value = pump.s40StrokesChoke
                                xlSheet.Cells(y, 19).value = pump.s40StrokesCK
                                xlSheet.Cells(y, 20).value = pump.s50StrokesChoke
                                xlSheet.Cells(y, 21).value = pump.s50StrokesCK
                                y = y + 1
                            Else
                                y = 68
                            End If
                        Next
                    End If



                    'Save Shakers
                    If Not IsNothing(DDR.DDRReport.Shakers) Then
                        Dim y As Integer = 73
                        For Each shaker As com.entities.Shakers In DDR.DDRReport.Shakers.Items
                            If y <= 78 Then
                                xlSheet.Cells(y, 7).value = shaker.ScreenSize
                                xlSheet.Cells(y, 8).value = shaker.Top1
                                xlSheet.Cells(y, 9).value = shaker.Top2
                                xlSheet.Cells(y, 10).value = shaker.Top3
                                xlSheet.Cells(y, 11).value = shaker.Top4
                                xlSheet.Cells(y, 12).value = shaker.Bottom1
                                xlSheet.Cells(y, 13).value = shaker.Bottom2
                                xlSheet.Cells(y, 14).value = shaker.Bottom3
                                xlSheet.Cells(y, 15).value = shaker.Bottom4
                                y = y + 1
                            Else
                                y = 73
                            End If
                        Next
                    End If

                    'save mud
                    If Not IsNothing(DDR.DDRReport.Mud) Then
                        Dim y As Integer = 82
                        For Each mud As com.entities.Mud In DDR.DDRReport.Mud.Items
                            If y <= 85 Then
                                xlSheet.Cells(y, 3).value = mud.TimeMud
                                xlSheet.Cells(y, 4).value = mud.WT
                                xlSheet.Cells(y, 6).value = mud.VIS
                                xlSheet.Cells(y, 7).value = mud.WL
                                xlSheet.Cells(y, 8).value = mud.Cake
                                xlSheet.Cells(y, 9).value = mud.PH
                                xlSheet.Cells(y, 10).value = mud.Sand
                                xlSheet.Cells(y, 11).value = mud.Solids
                                xlSheet.Cells(y, 12).value = mud.PvYP
                                xlSheet.Cells(y, 13).value = mud.KCL
                                xlSheet.Cells(y, 14).value = mud.Pm
                                xlSheet.Cells(y, 15).value = mud.Comments
                                y = y + 1
                            Else
                                'y = 82
                            End If
                        Next
                    End If

                    'save Riser Profile
                    If Not IsNothing(DDR.DDRReport.RiserProfile) Then
                        Dim y As Integer = 108
                        For Each riserp As com.entities.RiserProfile In DDR.DDRReport.RiserProfile.Items
                            If y <= 115 Then
                                xlSheet.Cells(y, 2).value = riserp.IDBeacon
                                xlSheet.Cells(y, 3).value = riserp.Depth
                                xlSheet.Cells(y, 4).value = riserp.Temp6hrs
                                xlSheet.Cells(y, 5).value = riserp.Temp12hrs
                                xlSheet.Cells(y, 6).value = riserp.Temp18hrs
                                xlSheet.Cells(y, 7).value = riserp.Temp24hrs
                                xlSheet.Cells(y, 8).value = riserp.Current6hrs
                                xlSheet.Cells(y, 9).value = riserp.Current12hrs
                                xlSheet.Cells(y, 10).value = riserp.Current18hrs
                                xlSheet.Cells(y, 11).value = riserp.Current24hrs
                                xlSheet.Cells(y, 12).value = riserp.Direction6hrs
                                xlSheet.Cells(y, 13).value = riserp.Direction12hrs
                                xlSheet.Cells(y, 14).value = riserp.Direction18hrs
                                xlSheet.Cells(y, 15).value = riserp.Direction24hrs
                                y = y + 1
                            End If
                        Next
                    End If

                End If
            End If

            'Dim wksheetAreas As Worksheet
            'wksheetAreas = xlApp.Workbooks.Application.Worksheets(3)
            'wksheetAreas.Activate()


            'If Not IsNothing(DDR.DDRReport.Activities) Then
            '    Dim y As Integer = 2

            '    'Fill Marine
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Marine"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Fill Hydraulic / Mechanic
            '    y = 19
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Hydraulic/ Mechanic"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Subsea
            '    y = 32
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Subsea"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'ET /IT / ET
            '    y = 45
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Elect / ET / IT"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Drilling
            '    y = 58
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Drilling"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Safety
            '    y = 84
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Safety"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Store
            '    y = 97
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Stores"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next

            '    'Project
            '    y = 113
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Project"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next
            '    'Engineering
            '    y = 136
            '    For Each item As com.entities.Activities In DDR.DDRReport.Activities.Items
            '        Select Case item.Deparment
            '            Case "Engineering"
            '                wksheetAreas.Cells(y, 1).value = item.Activity
            '                y = y + 1
            '        End Select

            '    Next
            'End If

            'wksheetAreas = xlApp.Workbooks.Application.Worksheets(1)
            'xlSheet.Activate()
            'xlSheet.Name = "DDR_Report_" & Now.ToString("MMddyyyymmss")
            'CloseDocument()
        End Sub

        Public Sub FillActivities(ByVal DDR As com.entities.DDRControl, ByVal sheet As Integer, Optional ByVal lenguaje As String = "ENG")
            'OpenDocument()
            xlSheet = xlApp.Workbooks.Application.Worksheets(sheet)
            xlSheet.Activate()


            If Not IsNothing(DDR) Then
                'imprime fecha 
                xlSheet.Cells(2, 3).value = DDR.ReportDate
                xlSheet.Cells(2, 16).value = DDR.ReportDate
                'imprime generators and thrusters
                xlSheet.Cells(5, 4).value = DDR.DDRReport.MarineInfo.GeneratorsOnline
                xlSheet.Cells(5, 17).value = DDR.DDRReport.MarineInfo.GeneratorsOnline
                'imprime thrusters
                xlSheet.Cells(6, 4).value = DDR.DDRReport.MarineInfo.Thrustersonline
                xlSheet.Cells(6, 17).value = DDR.DDRReport.MarineInfo.Thrustersonline
            End If

            If Not IsNothing(DDR.DDRReport.Activities) Then
                'fill Marine Area
                Dim actvities As com.entities.Activities_Collection = DDR.DDRReport.Activities
                For Each item As com.entities.Activities In actvities.Items
                    Select Case item.Deparment
                        Case "Marine"
                            xlSheet.Cells(9, 1).value = actvities.ToStringAct("ENG", "Marine")
                            xlSheet.Cells(9, 14).value = actvities.ToStringAct("ESP", "Marine")
                        Case "Safety"
                            xlSheet.Cells(41, 1).value = actvities.ToStringAct("ENG", "Safety")
                            xlSheet.Cells(41, 14).value = actvities.ToStringAct("ESP", "Safety")
                        Case "Hydraulic/ Mechanic"
                            xlSheet.Cells(71, 1).value = actvities.ToStringAct("ENG", "Hydraulic/ Mechanic")
                            xlSheet.Cells(71, 14).value = actvities.ToStringAct("ESP", "Hydraulic/ Mechanic")
                        Case "Subsea"
                            xlSheet.Cells(96, 1).value = actvities.ToStringAct("ENG", "Subsea")
                            xlSheet.Cells(96, 14).value = actvities.ToStringAct("ESP", "Subsea")
                        Case "Elect"
                            xlSheet.Cells(121, 1).value = actvities.ToStringAct("ENG", "Elect")
                            xlSheet.Cells(121, 14).value = actvities.ToStringAct("ESP", "Elect")
                        Case "ET"
                            xlSheet.Cells(146, 1).value = actvities.ToStringAct("ENG", "ET")
                            xlSheet.Cells(146, 14).value = actvities.ToStringAct("ESP", "ET")
                        Case "IT"
                            xlSheet.Cells(171, 1).value = actvities.ToStringAct("ENG", "IT")
                            xlSheet.Cells(171, 14).value = actvities.ToStringAct("ESP", "IT")
                        Case "Drilling"
                            xlSheet.Cells(191, 1).value = actvities.ToStringAct("ENG", "Drilling")
                            xlSheet.Cells(191, 14).value = actvities.ToStringAct("ESP", "Drilling")
                        Case "Stores"
                            xlSheet.Cells(216, 1).value = actvities.ToStringAct("ENG", "Stores")
                            xlSheet.Cells(216, 14).value = actvities.ToStringAct("ESP", "Stores")
                        Case "Project"
                            xlSheet.Cells(241, 1).value = actvities.ToStringAct("ENG", "Project")
                            xlSheet.Cells(241, 14).value = actvities.ToStringAct("ESP", "Project")
                        Case "Engineering"
                            xlSheet.Cells(266, 1).value = actvities.ToStringAct("ENG", "Engineering")
                            xlSheet.Cells(266, 14).value = actvities.ToStringAct("ESP", "Engineering")
                        Case "ROV"
                            xlSheet.Cells(291, 1).value = actvities.ToStringAct("ENG", "ROV")
                            xlSheet.Cells(291, 14).value = actvities.ToStringAct("ESP", "ROV")
                        Case "Catering"
                            xlSheet.Cells(315, 1).value = actvities.ToStringAct("ENG", "ROV")
                            xlSheet.Cells(315, 14).value = actvities.ToStringAct("ESP", "ROV")
                    End Select
                Next

                If Not IsNothing(DDR.DDRReport.WorkOrders) Then
                    Dim WorkOrders As com.entities.WorkOrderCollection = DDR.DDRReport.WorkOrders
                    For Each item As com.entities.WorkOrder In WorkOrders.items
                        Select Case item.Deparment_ID
                            Case 1
                                xlSheet.Cells(27, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(27, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 6
                                xlSheet.Cells(56, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(56, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 2
                                xlSheet.Cells(82, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(82, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 3
                                xlSheet.Cells(107, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(107, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 4
                                xlSheet.Cells(132, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(132, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 11
                                xlSheet.Cells(157, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(157, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 12
                                xlSheet.Cells(177, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(177, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 5
                                xlSheet.Cells(202, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(202, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 7
                                xlSheet.Cells(227, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(227, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 8
                                xlSheet.Cells(252, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(252, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 9
                                xlSheet.Cells(277, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(277, 14).value = WorkOrders.toStringWO(item.Deparment_ID)
                            Case 10
                                xlSheet.Cells(302, 1).value = WorkOrders.toStringWO(item.Deparment_ID)
                                xlSheet.Cells(302, 14).value = WorkOrders.toStringWO(item.Deparment_ID)

                        End Select
                    Next

                End If

                Dim y As Integer
                Dim UrgentMRs As com.entities.UrgentsMRsCollection = DDR.DDRReport.UrgentsMR
                If Not IsNothing(UrgentMRs) Then
                    ' print urgent mr
                    'Marine deparment id =1
                    y = 34
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(1)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 37 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'Safety deparment id = 6
                    y = 64
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(6)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 67 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'Hydraulic/mech deparment id = 2
                    y = 89
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(2)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 93 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'subsea deparment id = 3
                    y = 114
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(3)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 117 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'electri deparment id = 4
                    y = 139
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(4)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 142 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'ET deparment id = 11
                    y = 164
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(11)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 167 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next


                    'IT deparment id = 12
                    y = 184
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(12)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 187 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'drilling deparment id = 5
                    y = 209
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(5)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 212 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'store deparment id = 7
                    y = 234
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(7)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 237 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'project deparment id = 8
                    y = 259
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(8)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 263 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'engineering deparment id = 9
                    y = 284
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(9)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 287 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'ROV deparment id = 10
                    y = 309
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(10)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 312 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                    'Catering deparment id = 14
                    y = 333
                    For Each item As Object In UrgentMRs.GetItemsByDeparmentID(14)
                        Dim umr As com.entities.UrgentMRs
                        umr = CType(item, com.entities.UrgentMRs)
                        If y <= 336 Then
                            xlSheet.Cells(y, 1).value = umr.MRNumber
                            xlSheet.Cells(y, 4).value = umr.dateIssued
                            xlSheet.Cells(y, 6).value = umr.MRDescription
                            xlSheet.Cells(y, 11).value = umr.Status

                            xlSheet.Cells(y, 14).value = umr.MRNumber
                            xlSheet.Cells(y, 17).value = umr.dateIssued
                            xlSheet.Cells(y, 19).value = umr.MRDescription
                            xlSheet.Cells(y, 24).value = umr.Status
                            y += 1
                        End If
                    Next

                End If


                'Fill PEMEX Urgent MRs
                y = 316
                For Each item As com.entities.PUMR In DDR.DDRReport.PUMR.Items
                    If y <= 319 Then
                        xlSheet.Cells(y, 1).value = item.MRNumber
                        xlSheet.Cells(y, 4).value = item.DateIssued
                        xlSheet.Cells(y, 6).value = item.MRDesc
                        xlSheet.Cells(y, 11).value = item.Status

                        xlSheet.Cells(y, 14).value = item.MRNumber
                        xlSheet.Cells(y, 17).value = item.DateIssued
                        xlSheet.Cells(y, 19).value = item.MRDesc
                        xlSheet.Cells(y, 24).value = item.Status
                        y += 1
                    End If
                Next

                Dim TransitLog As com.entities.LogisticTransitLogCollection = DDR.DDRReport.LogisticTransitLog

                If Not IsNothing(TransitLog) Then
                    xlSheet.Cells(21, 1).value = TransitLog.ToStringByType("Boat")
                    xlSheet.Cells(21, 14).value = TransitLog.ToStringByType("Boat", "ESP")
                    xlSheet.Cells(21, 7).value = TransitLog.ToStringByType("Helicopter")
                    xlSheet.Cells(21, 20).value = TransitLog.ToStringByType("Helicopter", "ESP")
                End If

                Dim SOCInfo As com.entities.SOC = DDR.DDRReport.SOC

                If Not IsNothing(SOCInfo) Then
                    xlSheet.Cells(51, 4).value = SOCInfo.SOCToday
                    xlSheet.Cells(52, 4).value = SOCInfo.SOCMonth
                    xlSheet.Cells(53, 4).value = SOCInfo.SOCSTOPTour
                    xlSheet.Cells(54, 4).value = SOCInfo.DaysWithoutLTA

                    xlSheet.Cells(51, 17).value = SOCInfo.SOCToday
                    xlSheet.Cells(52, 17).value = SOCInfo.SOCMonth
                    xlSheet.Cells(53, 17).value = SOCInfo.SOCSTOPTour
                    xlSheet.Cells(54, 17).value = SOCInfo.DaysWithoutLTA
                End If


            End If
        End Sub


        Public Sub CloseDocument()
            xlWorkBook.Close()
            xlApp.Quit()
            Thread.CurrentThread.CurrentCulture = oldCI

            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlSheet)
        End Sub

        Private Sub releaseObject(ByVal obj As Object)
            Try
                Marshal.ReleaseComObject(obj)
                obj = Nothing
            Catch ex As Exception
                obj = Nothing
                Throw New Exception("Error on  releaseObject(ByVal obj As Object) Msg:" & ex.Message.ToString)
            Finally
                GC.Collect()
            End Try
        End Sub
    End Class
End Namespace
