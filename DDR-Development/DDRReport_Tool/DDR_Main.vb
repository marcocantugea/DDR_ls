Imports DDRReportToolCore
Imports System.Globalization


Public Class DDR_Main

    Private _SessionUser As com.entities.SessionUser
    
    Public Property user() As com.entities.SessionUser
        Get
            Return _SessionUser
        End Get
        Set(ByVal value As com.entities.SessionUser)
            _SessionUser = value
        End Set
    End Property

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim ddr As New com.entities.DDRControl
        Dim ado As New com.ADO.ADODDR

        Dim i As Integer
        i = MsgBox("Do you want to load the last report information?", MsgBoxStyle.YesNo, "DDR New form")
        If i = vbYes Then
            'ddr.Active = True
            'ddr.ReportNo = 1
            Dim lastddr As Integer

            lastddr = ado.GetLastID("DDR_Control", "DDRID")
            ddr = ado.GetCompleteDDRReport(lastddr)

            ddr.ReportDate = Date.Parse(Today.ToString("MM/dd/yyyy"), New Cultureinfo("en-US"))
            ddr.DDRID = -1
            ddr.DDRReport.DDR_Report_ID = -1
            ddr.DDRReport.MarineInfo.Marine_ID = -1
            ddr.DDRReport.POB.POB_ID = -1
            ddr.DDRReport.SOC.SOCINFOID = -1



            If IsNumeric(ddr.ReportNo) Then
                ddr.ReportNo = ddr.ReportNo + 1
            End If

            If IsNumeric(ddr.DDRReport.DaysFromSpud) Then
                ddr.DDRReport.DaysFromSpud = ddr.DDRReport.DaysFromSpud + 1
            End If


            ddr.DDRReport.Activities_Next24_hrs = Nothing
            ddr.DDRReport.MarineInfo.Comments = Nothing

            ddr.DDRReport.MarineInfo.YestStock_Barite = ddr.DDRReport.MarineInfo.TodayStock_Barite
            ddr.DDRReport.MarineInfo.TodayStock_Barite = Nothing

            ddr.DDRReport.MarineInfo.YestStock_Bentonite = ddr.DDRReport.MarineInfo.TodayStock_Bentonite
            ddr.DDRReport.MarineInfo.TodayStock_Bentonite = Nothing

            ddr.DDRReport.MarineInfo.YestStock_CementG = ddr.DDRReport.MarineInfo.TodayStock_CementG
            ddr.DDRReport.MarineInfo.TodayStock_CementG = Nothing

            ddr.DDRReport.MarineInfo.YestStock_CmtBlended = ddr.DDRReport.MarineInfo.TodayStock_CMTBlended
            ddr.DDRReport.MarineInfo.TodayStock_CMTBlended = Nothing

            ddr.DDRReport.MarineInfo.YestStock_Diesel = ddr.DDRReport.MarineInfo.TodayStock_Diesel
            ddr.DDRReport.MarineInfo.TodayStock_Diesel = Nothing

            ddr.DDRReport.MarineInfo.YestStock_DrillWater = ddr.DDRReport.MarineInfo.TodayStock_DrillWater
            ddr.DDRReport.MarineInfo.TodayStock_DrillWater = Nothing

            ddr.DDRReport.MarineInfo.YestStock_Gel = ddr.DDRReport.MarineInfo.TodayStock_Gel
            ddr.DDRReport.MarineInfo.TodayStock_Gel = Nothing

            ddr.DDRReport.MarineInfo.YestStock_LubOil = ddr.DDRReport.MarineInfo.TodayStock_LubOil
            ddr.DDRReport.MarineInfo.TodayStock_LubOil = Nothing

            ddr.DDRReport.MarineInfo.YestStock_PotWater = ddr.DDRReport.MarineInfo.TodayStock_PotWater
            ddr.DDRReport.MarineInfo.TodayStock_PotWater = Nothing

            ddr.DDRReport.Yest_Rot_Hrs = ddr.DDRReport.Todays_Rot_Hrs
            ddr.DDRReport.Todays_Rot_Hrs = Nothing

            ddr.DDRReport.DDRHrs = Nothing
            ddr.DDRReport.POB.GRCrew = Nothing
            ddr.DDRReport.POB.GRServ = Nothing
            ddr.DDRReport.POB.Catering = Nothing
            ddr.DDRReport.POB.Pemex = Nothing
            ddr.DDRReport.POB.OpSer = Nothing

            ddr.DDRReport.Yesterdays_Depth = ddr.DDRReport.Midnigth_Depth
            ddr.DDRReport.Midnigth_Depth = Nothing
            ddr.DDRReport.TVD = Nothing
            ddr.DDRReport.TotalsHrs = Nothing
            ddr.DDRReport.Tool_Pusher_Comments = Nothing
            'ddr.DDRReport.BITS = Nothing
            If Not IsNothing(ddr.DDRReport.BITS) Then
                For Each item As com.entities.BITS In ddr.DDRReport.BITS.Items
                    item.BITS_ID = -1
                    item.bit_Out = Nothing
                    item.bit_Mtrs = Nothing
                Next
            End If
            ddr.DDRReport.BITS_AnnVel = Nothing
            ddr.DDRReport.BITS_AnnVelCsg = Nothing
            ddr.DDRReport.BITS_DCVel = Nothing
            ddr.DDRReport.BITS_NozzleVel = Nothing
            'ddr.DDRReport.Pumps = Nothing

            For Each item As com.entities.Pumps In ddr.DDRReport.Pumps.Items
                item.PUMPS_ID = -1
                'item.SPM = Nothing
                'item.GPM = Nothing
                'item.EFF = Nothing
                'item.Press = Nothing
                'item.MP = Nothing
                'item.CLF = Nothing
                'item.CLFCK = Nothing
                'item.s30StrokesChoke = Nothing
                'item.s30StrokesCK = Nothing
                'item.s40StrokesChoke = Nothing
                'item.s40StrokesCK = Nothing
                'item.s50StrokesChoke = Nothing
                'item.s50StrokesCK = Nothing
            Next


            For Each item As com.entities.DrillString In ddr.DDRReport.DrillString.Items
                item.DrillString_ID = -1
            Next

            For Each item As com.entities.BITS In ddr.DDRReport.BITS.Items
                item.BITS_ID = -1
            Next

            ddr.DDRReport.DrillString_Survey = Nothing
            ddr.DDRReport.MarineInfo.RemainingPayload = Nothing

            If Not IsNothing(ddr.DDRReport.RiserProfile) Then
                For Each item As com.entities.RiserProfile In ddr.DDRReport.RiserProfile.Items
                    item.IDRiserProfile = -1
                    item.Current12hrs = Nothing
                    item.Current18hrs = Nothing
                    item.Current24hrs = Nothing
                    item.Current6hrs = Nothing
                    item.Direction12hrs = Nothing
                    item.Direction18hrs = Nothing
                    item.Direction24hrs = Nothing
                    item.Direction6hrs = Nothing
                    item.Temp12hrs = Nothing
                    item.Temp18hrs = Nothing
                    item.Temp24hrs = Nothing
                    item.Temp6hrs = Nothing

                Next
            End If


            For Each item As com.entities.Shakers In ddr.DDRReport.Shakers.Items
                item.Shakers_ID = -1
            Next

            If Not IsNothing(ddr.DDRReport.Mud) Then
                For Each item As com.entities.Mud In ddr.DDRReport.Mud.Items
                    item.MUD_ID = -1
                    item.Cake = Nothing
                    item.Comments = Nothing
                    item.KCL = Nothing
                    item.PH = Nothing
                    item.Pm = Nothing
                    item.PvYP = Nothing
                    item.Sand = Nothing
                    item.Solids = Nothing
                    item.VIS = Nothing
                    item.WL = Nothing
                    item.WT = Nothing
                Next
            End If

            ddr.DDRReport.POB = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_Barite = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_Bentoniote = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_CementG = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_CmtBlended = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_Diesel = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_DrillWater = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_Gel = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_LubOil = Nothing
            ddr.DDRReport.MarineInfo.RecivedMade_PotWater = Nothing
            ddr.DDRReport.MarineInfo.Used_Barite = Nothing
            ddr.DDRReport.MarineInfo.Used_Bentoniote = Nothing
            ddr.DDRReport.MarineInfo.Used_CementG = Nothing
            ddr.DDRReport.MarineInfo.Used_CmtBlended = Nothing
            ddr.DDRReport.MarineInfo.Used_Diesel = Nothing
            ddr.DDRReport.MarineInfo.Used_DrillWater = Nothing
            ddr.DDRReport.MarineInfo.Used_Gel = Nothing
            ddr.DDRReport.MarineInfo.Used_LubOil = Nothing
            ddr.DDRReport.MarineInfo.Used_PotWater = Nothing
            ddr.DDRReport.MarineInfo.UsedPlayload = Nothing
            ddr.DDRReport.Wind_Dir = Nothing
            ddr.DDRReport.Wind_Speed = Nothing
            ddr.DDRReport.Current_Dir = Nothing
            ddr.DDRReport.Current_Speed = Nothing
            ddr.DDRReport.Temp_Air = Nothing
            ddr.DDRReport.Temp_Sea = Nothing
            ddr.DDRReport.Barometer = Nothing
            ddr.DDRReport.Swell = Nothing
            ddr.DDRReport.Pitch = Nothing
            ddr.DDRReport.Visibilty = Nothing
            ddr.DDRReport.Sea = Nothing
            ddr.DDRReport.Roll = Nothing
            ddr.DDRReport.Heave = Nothing
            ddr.DDRReport.UsedByPEP = Nothing
            ddr.DDRReport.DrillLineSlippedandCut = Nothing
            ddr.DDRReport.DrillString_PUWeight = Nothing
            ddr.DDRReport.DrillString_StringWeight = Nothing
            ddr.DDRReport.DrillString_RotWeigth = Nothing
            ddr.DDRReport.DrillString_WOB = Nothing
            ddr.DDRReport.DrillString_RPM = Nothing
            ddr.DDRReport.DrillString_Torque = Nothing
            ddr.DDRReport.DrillString_StackOffWeigth = Nothing
            ddr.DDRReport.Activities = Nothing
            ddr.DDRReport.SOC = Nothing
            ddr.DDRReport.LogisticTransitLog = Nothing
            ddr.DDRReport.WorkOrders = Nothing

            Dim ddrform As New DDR_From
            ddrform.User = _SessionUser
            ddrform.DDRReport = ddr
            ddrform.FormMode = FormModes.Insert
            ddrform.Show()

            'If Not IsNothing(ddr.DDRReport.Activities) Then
            '    For Each item As com.entities.Activities In ddr.DDRReport.Activities.Items

            '    Next

            'End If



        Else
            ddr.Active = True
            ddr.ReportDate = Today.ToString("MM/dd/yyyy")
            ddr.ReportNo = 1

            Dim ddrform As New DDR_From
            ddrform.User = _SessionUser
            ddrform.DDRReport = ddr
            ddrform.FormMode = FormModes.Insert
            ddrform.Show()
        End If



    End Sub

    Private Sub DDR_Main_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Disposed
        Application.Exit()
    End Sub

    Private Sub DDR_Main_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDDRControlGrid()
        LoadWells()
        CheckPrivilegies()
        Label1.Text = "User: " & _SessionUser.User
        dgv_ControlDDR.Rows(dgv_ControlDDR.Rows.Count - 1).Selected = True
        dgv_ControlDDR.FirstDisplayedScrollingRowIndex = dgv_ControlDDR.Rows.Count - 1
        timerMaintMode.Start()

    End Sub

    Public Sub CheckPrivilegies()
        Select Case _SessionUser.Group
            Case "Administrator"
                Button1.Enabled = True
            Case "Marine"
                Button1.Visible = False
                Button4.Visible = False
                ComboBox1.Enabled = False
            Case "Engineering"
                Button1.Visible = False
                Button4.Visible = False
                ComboBox1.Enabled = False
            Case "View"
                Button1.Visible = False
                Button4.Visible = False
                ComboBox1.Enabled = False
            Case "Activities"
                Button1.Visible = False
                Button4.Visible = False
                ComboBox1.Enabled = False
        End Select
    End Sub

    Public Sub LoadDDRControlGrid()
        Dim adoDDR As New com.ADO.ADODDR
        Dim ddrs_collected As New com.entities.DDRControl_Collection
        adoDDR.GetDDRControlHeader(ddrs_collected)

        dgv_ControlDDR.ColumnCount = 7
        dgv_ControlDDR.Columns(0).Name = "DDR ID"
        dgv_ControlDDR.Columns(1).Name = "Report Date"
        dgv_ControlDDR.Columns(2).Name = "Report No."
        dgv_ControlDDR.Columns(3).Name = "Well Name"
        dgv_ControlDDR.Columns(4).Name = "Description"
        dgv_ControlDDR.Columns(5).Name = "Lock"
        dgv_ControlDDR.Columns(6).Name = "Active"

        Dim row As String()
        For Each o_ddr As com.entities.DDRControl In ddrs_collected.Items
            row = New String() {o_ddr.DDRID.ToString, o_ddr.ReportDate, o_ddr.ReportNo.ToString, o_ddr.Well, o_ddr.Description, o_ddr.Lock.ToString, o_ddr.Active.ToString}
            dgv_ControlDDR.Rows.Add(row)
        Next
        dgv_ControlDDR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_ControlDDR.AllowUserToAddRows = False
        dgv_ControlDDR.AllowUserToDeleteRows = False
        dgv_ControlDDR.AllowUserToResizeRows = False

    End Sub
    Public Sub LoadWells()
        Dim adDDR As New com.ADO.ADODDR
        Dim wells As New Collection
        adDDR.GetWells(wells)

        For Each item As String In wells
            ComboBox1.Items.Add(item)
        Next

        'select the active well

        If Not System.Configuration.ConfigurationSettings.AppSettings("ActiveWellName").Equals("") Then
            ComboBox1.SelectedText = System.Configuration.ConfigurationSettings.AppSettings("ActiveWellName")
            ShowWellOnly()
        End If


    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim s_ddrid As Integer
        For Each row As DataGridViewRow In dgv_ControlDDR.Rows
            For Each cell As DataGridViewCell In row.Cells
                If cell.Selected Then
                    s_ddrid = Integer.Parse(dgv_ControlDDR.Rows(cell.RowIndex).Cells(0).Value)
                End If
            Next
        Next

        Dim frm_DDR_Form As New DDR_From

        Dim ado As New com.ADO.ADODDR
        frm_DDR_Form.DDRReport = ado.GetCompleteDDRReport(s_ddrid)
        frm_DDR_Form.DDROpenDate = Date.Now()


        If frm_DDR_Form.DDRReport.Lock Then
            frm_DDR_Form.FormMode = FormModes.View
        Else
            If _SessionUser.Group.Equals("View") Then
                frm_DDR_Form.FormMode = FormModes.View
            Else
                frm_DDR_Form.FormMode = FormModes.Edit
            End If

        End If

        frm_DDR_Form.User = _SessionUser
        frm_DDR_Form.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        dgv_ControlDDR.Rows.Clear()
        LoadDDRControlGrid()
    End Sub

    Public Sub CopyData(ByVal dgv As DataGridView)
        Dim d As DataObject = dgv.GetClipboardContent()
        Clipboard.SetDataObject(d)
    End Sub



    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim appconfig As New DDRReportToolCore.com.configuration.extras.AppConfigFileSettings
        appconfig.UpdateAppSettings("ActiveWellName", ComboBox1.Text)
        'System.Configuration.ConfigurationSettings.AppSettings.Set("ActiveWellName", ComboBox1.Text)

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        ShowWellOnly()
    End Sub

    Public Sub ShowWellOnly()
        Dim adoDDR As New com.ADO.ADODDR
        Dim ddrs_collected As New com.entities.DDRControl_Collection
        adoDDR.GetDDRControlHeader(ddrs_collected)
        dgv_ControlDDR.Rows.Clear()
        Dim row As String()
        For Each o_ddr As com.entities.DDRControl In ddrs_collected.Items
            If Not IsNothing(o_ddr.Well) Then
                If o_ddr.Well.Equals(ComboBox1.Text) Then
                    row = New String() {o_ddr.DDRID.ToString, o_ddr.ReportDate, o_ddr.ReportNo.ToString, o_ddr.Well, o_ddr.Description, o_ddr.Lock.ToString, o_ddr.Active.ToString}
                    dgv_ControlDDR.Rows.Add(row)
                End If
            End If
        Next

        dgv_ControlDDR.Sort(dgv_ControlDDR.Columns(1), System.ComponentModel.ListSortDirection.Ascending)
    End Sub

    Private Sub dgv_ControlDDR_SortCompare(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewSortCompareEventArgs) Handles dgv_ControlDDR.SortCompare
        If e.Column.Index = 0 Then
            e.SortResult = System.String.Compare(e.CellValue1, e.CellValue2)
        Else
            e.SortResult = System.DateTime.Compare(e.CellValue1, e.CellValue2)
        End If

        e.Handled = True
    End Sub

    Private Sub timerMaintMode_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles timerMaintMode.Tick
        System.Configuration.ConfigurationManager.RefreshSection("appSettings")
       
        If System.Configuration.ConfigurationSettings.AppSettings("MaintenanceMode").Equals("1") Then
            'MsgBox("The system has entered in maintenance mode, please save all your data and close the application.", MsgBoxStyle.Critical, "Maintenance Mode Activated")
            timerMaintMode.Stop()
            closeddrmaintmode.Show()
            'timerMaintMode.Start()
        End If

    End Sub
End Class