Imports DDRReportToolCore

Public Class DDR_From
    Implements IMessageFilter



    Private _FormMode As Integer = FormModes.Insert
    Private _DDR As com.entities.DDRControl
    Private _saved As Boolean = False
    Private _SessionUser As com.entities.SessionUser
    Private _Clipboard As String
    Private _DDROpenDate As Date
    Private ddrloaded As com.entities.DDRControl

    '28 - Oct 2018
    'Se Agrego vairable para identificar la opcion de borrar en los gridviews
    Private _deleteRowFrom As String = ""
    Private _deleteRowIDindex As Integer = -1


    Public Property DDROpenDate() As Date
        Get
            Return _DDROpenDate
        End Get
        Set(ByVal value As Date)
            _DDROpenDate = value
        End Set
    End Property

    Public Property User() As com.entities.SessionUser
        Get
            Return _SessionUser
        End Get
        Set(ByVal value As com.entities.SessionUser)
            _SessionUser = value
        End Set
    End Property

    Public Property DDRReport() As com.entities.DDRControl
        Get
            Return _DDR
        End Get
        Set(ByVal value As com.entities.DDRControl)
            _DDR = value
        End Set
    End Property

    Public Property FormMode() As FormModes
        Get
            Return _FormMode
        End Get
        Set(ByVal value As FormModes)
            _FormMode = value
        End Set
    End Property

    Private Sub DDR_From_Disposed(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.FormClosing

        'CType(Application.OpenForms("DDR_Main").Controls("dgv_ControlDDR"), DataGridView).Rows.Clear()
        'Dim form As DDR_Main
        'form = Application.OpenForms("DDR_Main")
        'form.LoadDDRControlGrid()
        'form.ShowWellOnly()

        _SessionUser.TabController.RemoveAllItems(_SessionUser.User)


    End Sub

    Private Sub DDR_From_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        LoadDataGrids()
        Select Case _FormMode
            Case FormModes.Insert
                If Not IsNothing(_DDR.DDRReport) Then
                    FillForm()
                End If
                If Not IsNothing(_DDR) Then
                    TextBox9.Text = _DDR.ReportDate.ToString("MM/dd/yyyy")
                End If
            Case FormModes.View
                LockForm()
                FillForm()
                Button1.Enabled = False
            Case FormModes.Edit
                FillForm()
        End Select

        DDRUpdateChecker.Enabled = True
        CheckInTab()

    End Sub

    Public Sub CheckPrivilegies()
        Select Case _SessionUser.Group
            Case "Marine"
                If FormMode = FormModes.Edit Then

                    For Each page_control As TabPage In TabControl1.TabPages
                        If Not page_control.Name.Equals("tp_MarineInfo") Then
                            If Not page_control.Name.Equals("tpPOB") Then
                                If Not page_control.Name.Equals("tb_DeparmentAct") Then
                                    If Not page_control.Name.Equals("tb_RiserProfile") Then
                                        TabControl1.TabPages.Remove(page_control)
                                    End If
                                End If
                            End If
                        End If
                    Next
                    Button2.Visible = False
                    Button3.Visible = False
                    Button4.Visible = False
                Else
                    Button2.Visible = False
                    Button3.Visible = False
                    Button4.Visible = False
                    Button1.Visible = False
                End If

            Case "Engineering"
                If FormMode = FormModes.Edit Then
                    For Each page_control As TabPage In TabControl1.TabPages
                        If Not page_control.Name.Equals("tpEngInfo") Then
                            If Not page_control.Name.Equals("tb_DeparmentAct") Then
                                TabControl1.TabPages.Remove(page_control)
                            End If
                        End If
                    Next
                    Button2.Visible = False
                    Button3.Visible = False
                    Button4.Visible = False
                Else
                    Button2.Visible = False
                    Button3.Visible = False
                    Button4.Visible = False
                    Button1.Visible = False
                End If

            Case "View"
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
                Button1.Visible = False
                Button5.Visible = False
                Button6.Visible = False
            Case "Activities"
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
                Button1.Visible = False
                If FormMode = FormModes.Edit Then
                    For Each page_control As TabPage In TabControl1.TabPages
                        If Not page_control.Name.Equals("tb_DeparmentAct") Then
                            TabControl1.TabPages.Remove(page_control)
                        End If
                    Next
                End If
            Case "Drilling"
                For Each page_control As TabPage In TabControl1.TabPages
                    If page_control.Name.Equals("tp_MarineInfo") Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                    If page_control.Name.Equals("tpPOB") Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                    If page_control.Name.Equals("tb_RiserProfile") Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                    If page_control.Name.Equals("tpEngInfo") Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                    If page_control.Name.Equals("tb_SOC") Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                    If page_control.Name.Equals("tb_LogisticTransitLog") Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                Next
            Case "Safety"
                For Each page_control As TabPage In TabControl1.TabPages
                    Dim removetab As Boolean = True
                    If page_control.Name.Equals("tb_DeparmentAct") Then
                        removetab = False
                    End If
                    If page_control.Name.Equals("tb_SOC") Then
                        removetab = False
                    End If
                    If removetab Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                Next
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
            Case "Radio"
                For Each page_control As TabPage In TabControl1.TabPages
                    Dim removetab As Boolean = True
                    If page_control.Name.Equals("tb_LogisticTransitLog") Then
                        removetab = False
                    End If
                    If page_control.Name.Equals("tpPOB") Then
                        removetab = False
                    End If
                    If removetab Then
                        TabControl1.TabPages.Remove(page_control)
                    End If
                Next
                Button2.Visible = False
                Button3.Visible = False
                Button4.Visible = False
            Case "Administrator"
                lbl_f1superint.Visible = True
                lbl_f1supername.Visible = True
                txt_f1superintname.Visible = True
                txt_f1supername.Visible = True
        End Select
    End Sub

    Public Sub LoadDataGrids()
        LoadDDRHrsGrid()
        LoadBITSGrid()
        LoadDrillStringGrid()
        LoadDrillStringSurveyGrid()
        LoadPumpsGrid()
        LoadShakerGrid()
        LoadMudGrid()
        LoadDeparmentBox()
        LoadActivityGrid()
        LoadRiserProfileGrid()
        LoadLogisticTransitLog()
        LoadUrgentMrs()
        LoadWorkOrdersGrid()
        LoadPUMRGrid()

    End Sub

#Region "Load Grids"

    Private Sub LoadDDRHrsGrid()
        dgv_DDRHrs.ColumnCount = 7
        dgv_DDRHrs.Columns(0).Name = "From"
        dgv_DDRHrs.Columns(1).Name = "To"
        dgv_DDRHrs.Columns(2).Name = "Total"
        dgv_DDRHrs.Columns(3).Name = "Code"
        dgv_DDRHrs.Columns(4).Name = "Comments"
        dgv_DDRHrs.Columns(5).Name = "Comments on spanish"
        dgv_DDRHrs.Columns(6).Name = "ID"

        Dim row As String() = New String() {"", "", "", "", "", "", ""}
        dgv_DDRHrs.Rows.Add(row)
        dgv_DDRHrs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        dgv_DDRHrs.Columns(2).ReadOnly = True
        dgv_DDRHrs.Columns(4).Width = 500
        dgv_DDRHrs.Columns(5).Width = 500
        dgv_DDRHrs.Columns(6).Width = 35
        dgv_DDRHrs.Columns(6).ReadOnly = True
        dgv_DDRHrs.DefaultCellStyle.WrapMode = DataGridViewTriState.True

        'dgv_DDRHrs.RowHeadersVisible = False
    End Sub

    Private Sub LoadBITSGrid()
        dgv_BITS.ColumnCount = 13
        dgv_BITS.Columns(0).Name = "BITS No."
        dgv_BITS.Columns(1).Name = "Size(inches)"
        dgv_BITS.Columns(2).Name = "Make"
        dgv_BITS.Columns(3).Name = "Serial#"
        dgv_BITS.Columns(4).Name = "Type"
        dgv_BITS.Columns(5).Name = "Jets"
        dgv_BITS.Columns(6).Name = "TFA in2"
        dgv_BITS.Columns(7).Name = "Out"
        dgv_BITS.Columns(8).Name = "In"
        '28-Oct-2018
        ' SE modifico el codigo para agregar la columna de Hrs
        dgv_BITS.Columns(9).Name = "Mtrs"
        dgv_BITS.Columns(10).Name = "Hrs"
        dgv_BITS.Columns(11).Name = "BIT Grading"
        dgv_BITS.Columns(12).Name = "ID"

        Dim row As String() = New String() {"", "", "", "", "", "", "", "", "", "", "", "", ""}
        dgv_BITS.Rows.Add(row)
        dgv_BITS.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
        'dgv_BITS.RowHeadersVisible = False
        dgv_BITS.Columns(12).ReadOnly = True
        dgv_BITS.Columns(12).Width = 35

    End Sub

    Private Sub LoadDrillStringGrid()
        dgv_String.ColumnCount = 9
        dgv_String.Columns(0).Name = "Drill String"
        dgv_String.Columns(1).Name = "Size(inches)"
        dgv_String.Columns(2).Name = "Weight lb/ft"
        dgv_String.Columns(3).Name = "Grade"
        dgv_String.Columns(4).Name = "Tool Joint"
        dgv_String.Columns(5).Name = "Tool Jnt OD"""
        dgv_String.Columns(6).Name = "Total onboard"
        dgv_String.Columns(7).Name = "BHA in Hole"
        dgv_String.Columns(8).Name = "ID"

        Dim row As String() = New String() {"Drill pipe", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        row = New String() {"Drill pipe", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        row = New String() {"HW Drill pipe", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        row = New String() {"HW Drill pipe", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        row = New String() {"Drill collars", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        row = New String() {"Drill collars", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        row = New String() {"Drill collars", "", "", "", "", "", "", "", ""}
        dgv_String.Rows.Add(row)
        dgv_String.RowHeadersVisible = False
        dgv_String.AllowUserToAddRows = False
        dgv_String.Columns(8).ReadOnly = True
        dgv_String.Columns(8).Width = 35
    End Sub

    Private Sub LoadDrillStringSurveyGrid()
        dgv_String_Survey.ColumnCount = 7
        dgv_String_Survey.Columns(0).Name = "Directional Surveys"
        dgv_String_Survey.Columns(1).Name = "MD"
        dgv_String_Survey.Columns(2).Name = "TVD"
        dgv_String_Survey.Columns(3).Name = "INC"
        dgv_String_Survey.Columns(4).Name = "AZM"
        dgv_String_Survey.Columns(5).Name = "Comments"
        dgv_String_Survey.Columns(6).Name = "ID"
        Dim row As String() = New String() {"", "", "", "", "", "", ""}
        dgv_String_Survey.Rows.Add(row)
        dgv_String_Survey.Columns(5).AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
        dgv_String_Survey.Columns(6).ReadOnly = True
        dgv_String_Survey.Columns(6).Width = 35
    End Sub

    Private Sub LoadPumpsGrid()
        dgv_pumps.ColumnCount = 18
        dgv_pumps.Columns(0).Name = "Pump No."
        dgv_pumps.Columns(1).Name = "Make and Model"
        dgv_pumps.Columns(2).Name = "Stroke"""
        dgv_pumps.Columns(3).Name = "Liners"""
        dgv_pumps.Columns(4).Name = "SPM"
        dgv_pumps.Columns(5).Name = "GPM"
        dgv_pumps.Columns(6).Name = "%Eff"
        dgv_pumps.Columns(7).Name = "Press"
        dgv_pumps.Columns(8).Name = "C&K Frict."
        dgv_pumps.Columns(9).Name = "20 strokes"
        dgv_pumps.Columns(10).Name = "30 strokes"
        dgv_pumps.Columns(11).Name = "10 strokes" & vbNewLine & " SCR's"
        dgv_pumps.Columns(12).Name = "10 strokes" & vbNewLine & " CLF"
        dgv_pumps.Columns(13).Name = "20 strokes" & vbNewLine & " SCR's"
        dgv_pumps.Columns(14).Name = "20 strokes" & vbNewLine & " CLF"
        dgv_pumps.Columns(15).Name = "30 strokes" & vbNewLine & " SCR's"
        dgv_pumps.Columns(16).Name = "30 strokes" & vbNewLine & " CLF"
        dgv_pumps.Columns(17).Name = "ID"
        dgv_pumps.Columns(8).ReadOnly = True

        Dim row As String() = New String() {"1", "Wirth TPK2200", "14", "", "", "", "97", "", "1", "", "", "", "", "", "", "", "", ""}
        dgv_pumps.Rows.Add(row)
        row = New String() {"2", "Wirth TPK2200", "14", "", "", "", "97", "", "2", "", "", "", "", "", "", "", "", ""}
        dgv_pumps.Rows.Add(row)
        row = New String() {"3", "Wirth TPK2200", "14", "", "", "", "97", "", "3", "", "", "", "", "", "", "", "", ""}
        dgv_pumps.Rows.Add(row)
        row = New String() {"4", "Wirth TPK2200", "14", "", "", "", "97", "", "4", "", "", "", "", "", "", "", "", ""}
        dgv_pumps.Rows.Add(row)

        dgv_pumps.RowHeadersVisible = False
        dgv_pumps.AllowUserToAddRows = False

        dgv_pumps.Columns(17).ReadOnly = True
        dgv_pumps.Columns(17).Width = 35
    End Sub

    Private Sub LoadShakerGrid()
        dgv_Shakers.ColumnCount = 12
        dgv_Shakers.Columns(0).Name = "Shaker No."
        dgv_Shakers.Columns(1).Name = "Make and Model"
        dgv_Shakers.Columns(2).Name = "Screen Size"
        dgv_Shakers.Columns(3).Name = "Top"
        dgv_Shakers.Columns(4).Name = "Top"
        dgv_Shakers.Columns(5).Name = "Top"
        dgv_Shakers.Columns(6).Name = "Top"
        dgv_Shakers.Columns(7).Name = "Bottom"
        dgv_Shakers.Columns(8).Name = "Bottom"
        dgv_Shakers.Columns(9).Name = "Bottom"
        dgv_Shakers.Columns(10).Name = "Bottom"
        dgv_Shakers.Columns(11).Name = "ID"

        Dim row As String() = New String() {"1", "MI Swaco BEM-650", "Desilter", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)
        row = New String() {"2", "MI Swaco BEM-650", "Desilter", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)
        row = New String() {"3", "MI Swaco BEM-650", "Desilter", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)
        row = New String() {"4", "MI Swaco BEM-650", "Desilter", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)
        row = New String() {"5", "MI Swaco BEM-650", "Desilter", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)
        row = New String() {"6", "MI Swaco BEM-650", "Desilter", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)


        dgv_Shakers.RowHeadersVisible = False
        dgv_Shakers.Columns(11).ReadOnly = True
        dgv_Shakers.Columns(11).Width = 35

    End Sub

    Private Sub LoadMudGrid()
        dgv_Mud.ColumnCount = 13
        dgv_Mud.Columns(0).Name = "Time"
        dgv_Mud.Columns(1).Name = "Wt"
        dgv_Mud.Columns(2).Name = "Vis"
        dgv_Mud.Columns(3).Name = "WL"
        dgv_Mud.Columns(4).Name = "Cake"
        dgv_Mud.Columns(5).Name = "Ph"
        dgv_Mud.Columns(6).Name = "Sand"
        dgv_Mud.Columns(7).Name = "Solids"
        dgv_Mud.Columns(8).Name = "Pv/Yp"
        dgv_Mud.Columns(9).Name = "KCL"
        dgv_Mud.Columns(10).Name = "Pm"
        dgv_Mud.Columns(11).Name = "Comments"
        dgv_Mud.Columns(12).Name = "ID"


        Dim row As String() = New String() {"", "", "", "", "", "", "", "", "", "", "", "", ""}
        dgv_Shakers.Rows.Add(row)

        dgv_Mud.Columns(12).ReadOnly = True
        dgv_Mud.Columns(12).Width = 35

    End Sub

    Public Sub LoadDeparmentBox()



        ComboBox1.Items.Add("Marine")
        ComboBox1.Items.Add("Hydraulic/ Mechanic")
        ComboBox1.Items.Add("Subsea")
        ComboBox1.Items.Add("Elect")
        ComboBox1.Items.Add("ET")
        ComboBox1.Items.Add("IT")
        ComboBox1.Items.Add("Drilling")
        ComboBox1.Items.Add("Safety")
        ComboBox1.Items.Add("Stores")
        ComboBox1.Items.Add("Project")
        ComboBox1.Items.Add("Engineering")
        ComboBox1.Items.Add("ROV")
        ComboBox1.Items.Add("Catering")


        ComboBox1.SelectedItem = _SessionUser.DeparmentName
        If Not _SessionUser.Group.Equals("Administrator") Then
            ComboBox1.Enabled = False
        End If

        If _SessionUser.DepartmentId = 4 Then
            ComboBox1.Items.Remove("Marine")
            ComboBox1.Items.Remove("Hydraulic/ Mechanic")
            ComboBox1.Items.Remove("Subsea")
            ComboBox1.Items.Remove("Drilling")
            ComboBox1.Items.Remove("Safety")
            ComboBox1.Items.Remove("Stores")
            ComboBox1.Items.Remove("Project")
            ComboBox1.Items.Remove("Engineering")
            ComboBox1.Items.Remove("ROV")
            ComboBox1.Enabled = True
        End If
    End Sub

    Public Sub LoadActivityGrid()
        dgv_activities.ColumnCount = 3
        dgv_activities.Columns(0).Name = "Activity Detail"
        dgv_activities.Columns(1).Name = "Activity Detail Spanish"
        dgv_activities.Columns(2).Name = "ID"

        Dim row As String()
        row = New String() {"", "", ""}
        dgv_activities.Rows.Add(row)
        dgv_activities.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_activities.DefaultCellStyle.WrapMode = DataGridViewTriState.True
        dgv_activities.Columns(2).ReadOnly = True
        dgv_activities.Columns(2).Width = 30

    End Sub

    Public Sub LoadRiserProfileGrid()
        dgv_RiserProfile.ColumnCount = 15
        dgv_RiserProfile.Columns(0).Name = "ID Beacon"
        dgv_RiserProfile.Columns(1).Name = "depth(m)"
        dgv_RiserProfile.Columns(2).Name = "Temp. 06:00 hrs"
        dgv_RiserProfile.Columns(3).Name = "Temp. 12:00 hrs"
        dgv_RiserProfile.Columns(4).Name = "Temp. 18:00 hrs"
        dgv_RiserProfile.Columns(5).Name = "Temp. 24:00 hrs"
        dgv_RiserProfile.Columns(6).Name = "Current 06:00 hrs"
        dgv_RiserProfile.Columns(7).Name = "Current 12:00 hrs"
        dgv_RiserProfile.Columns(8).Name = "Current 18:00 hrs"
        dgv_RiserProfile.Columns(9).Name = "Current 24:00 hrs"
        dgv_RiserProfile.Columns(10).Name = "Direction 06:00 hrs"
        dgv_RiserProfile.Columns(11).Name = "Direction 12:00 hrs"
        dgv_RiserProfile.Columns(12).Name = "Direction 18:00 hrs"
        dgv_RiserProfile.Columns(13).Name = "Direction 24:00 hrs"
        dgv_RiserProfile.Columns(14).Name = "ID"

        Dim row As String()
        row = New String() {"", "", "", "", "", "", "", "", "", "", "", "", "", "", ""}
        dgv_RiserProfile.Rows.Add(row)
        dgv_RiserProfile.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_RiserProfile.Columns(14).ReadOnly = True
        dgv_RiserProfile.Columns(14).Width = 35

    End Sub

    Public Sub LoadLogisticTransitLog()
        dgv_LogTranLogBoat.ColumnCount = 3
        dgv_LogTranLogBoat.Columns(0).Name = "Log"
        dgv_LogTranLogBoat.Columns(1).Name = "Log Spanish"
        dgv_LogTranLogBoat.Columns(2).Name = "ID"

        'Modificado 22-Sep-2016
        'Agregar opcion para que exporte al reporte F1
        Dim chk_ToF1 As New DataGridViewCheckBoxColumn
        'chk_ToF1.Width = 15
        chk_ToF1.Name = "To F1"
        dgv_LogTranLogBoat.Columns.Add(chk_ToF1)

        Dim row As String()
        row = New String() {"", "", ""}
        dgv_LogTranLogBoat.Rows.Add(row)
        dgv_LogTranLogBoat.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_LogTranLogBoat.Columns(2).ReadOnly = True
        dgv_LogTranLogBoat.Columns(2).Width = 45
        dgv_LogTranLogBoat.Columns(3).Width = 35

        dgv_LogTranLogHeli.ColumnCount = 3
        dgv_LogTranLogHeli.Columns(0).Name = "Log"
        dgv_LogTranLogHeli.Columns(1).Name = "Log Spanish"
        dgv_LogTranLogHeli.Columns(2).Name = "ID"
        dgv_LogTranLogHeli.Rows.Add(row)
        dgv_LogTranLogHeli.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_LogTranLogHeli.Columns(2).ReadOnly = True
        dgv_LogTranLogHeli.Columns(2).Width = 35
        'Modificado 22-Sep-2016
        'Agregar opcion para que exporte al reporte F1
        Dim chk_ToF12 As New DataGridViewCheckBoxColumn
        'chk_ToF12.Width = 15
        chk_ToF12.Name = "To F1"
        dgv_LogTranLogHeli.Columns.Add(chk_ToF12)
        dgv_LogTranLogHeli.Columns(3).Width = 35
    End Sub

    Public Sub LoadUrgentMrs()
        dgv_UrgentsMRs.ColumnCount = "5"
        dgv_UrgentsMRs.Columns(0).Name = "MR Number"
        dgv_UrgentsMRs.Columns(1).Name = "Date Issued"
        dgv_UrgentsMRs.Columns(2).Name = "MR Description"
        dgv_UrgentsMRs.Columns(3).Name = "MR Status"
        dgv_UrgentsMRs.Columns(4).Name = "ID"
        dgv_UrgentsMRs.Columns(4).ReadOnly = True

        'Dim row As String()
        'row = New String() {"", "", "", "", ""}
        'dgv_UrgentsMRs.Rows.Add(row)
        dgv_UrgentsMRs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_UrgentsMRs.Columns(4).Width = 30
    End Sub

    Public Sub LoadWorkOrdersGrid()
        'Agregado el dia 5 Agosto 2017
        'Agregar funcionalidad para llenar F1

        Dim chk_preventive As New DataGridViewCheckBoxColumn
        chk_preventive.Width = 30
        chk_preventive.Name = "P"
        dgv_WorkOrders.Columns.Add(chk_preventive)

        Dim chk_corrective As New DataGridViewCheckBoxColumn
        chk_corrective.Width = 30
        chk_corrective.Name = "C"
        dgv_WorkOrders.Columns.Add(chk_corrective)

        '-------------------------------------------


        dgv_WorkOrders.ColumnCount = "6"
        dgv_WorkOrders.Columns(2).Name = "WO Number"
        dgv_WorkOrders.Columns(3).Name = "WO Description"
        dgv_WorkOrders.Columns(4).Name = "WO Description Spanish"
        dgv_WorkOrders.Columns(5).Name = "ID"
        dgv_WorkOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_WorkOrders.Columns(5).Width = 30
        dgv_WorkOrders.Columns(0).Width = 30
        dgv_WorkOrders.Columns(1).Width = 30

        'Agregado el dia 3-Sep-2018
        'Agregar la funcinoalidad  de desplazar texto a la siguiente linea
        dgv_WorkOrders.RowsDefaultCellStyle.WrapMode = DataGridViewTriState.True



        'Agregado el dia 5 Agosto 2017
        'Agregar funcionalidad para llenar F1

        Dim chk As New DataGridViewCheckBoxColumn
        dgv_WorkOrders.Columns.Add(chk)
        chk.HeaderText = "WO to F1"
        chk.Name = "WOtoF1"
        chk.Width = 30


    End Sub

    Public Sub LoadPUMRGrid()
        dgv_PUMR.ColumnCount = "5"
        dgv_PUMR.Columns(0).Name = "MR Number"
        dgv_PUMR.Columns(1).Name = "Date Issued"
        dgv_PUMR.Columns(2).Name = "MR Description"
        dgv_PUMR.Columns(3).Name = "MR Status"
        dgv_PUMR.Columns(4).Name = "ID"
        dgv_PUMR.Columns(4).ReadOnly = True

        dgv_PUMR.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgv_PUMR.Columns(4).Width = 30
        Dim row As String()
        row = New String() {"", "", "", "", ""}
        dgv_PUMR.Rows.Add(row)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Select Case _FormMode
            Case FormModes.Insert
                Dim adoDDr As New com.ADO.ADOMySQLDDR

                Try
                    LoadDataToMem()
                    adoDDr.SaveAllDDR(_DDR)
                    _FormMode = 1
                    _saved = True

                Catch ex As Exception
                    MsgBox(ex.Message.ToString, MsgBoxStyle.Critical, "DDR Error")
                End Try

                Dim ado As New com.ADO.ADOMySQLDDR
                'SaveActivityOnMemory()
                'ado.SaveActivities(_DDR)

            Case FormModes.Edit
                Dim adoDDr As New com.ADO.ADOMySQLDDR
                ''MsgBox(_DDR.DDRID)
                Dim selectedTabName As String
                selectedTabName = TabControl1.SelectedTab.Name

                Try
                    LoadDataToMem()
                    Dim ddrhrs_savedata As com.entities.DDRReport
                    Select Case selectedTabName
                        Case "tp_DDR_Header"
                            Dim marineinfo As New com.entities.MarineInfo
                            marineinfo.DDR_Report_ID = _DDR.DDRReport.DDRID
                            marineinfo.Marine_ID = _DDR.DDRReport.MarineInfo.Marine_ID
                            marineinfo.ToneMilesSinceLastCut = _DDR.DDRReport.MarineInfo.ToneMilesSinceLastCut
                            If marineinfo.Marine_ID = -1 Then
                                adoDDr.SaveMarineInfo(marineinfo)
                            Else
                                adoDDr.UpdateMarineinfo(marineinfo)
                            End If


                            adoDDr.UpdateDDRReport(_DDR.DDRReport)
                        Case "tp_DDRHrs"
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID
                            ddrhrs_savedata.TotalsHrs = _DDR.DDRReport.TotalsHrs
                            ddrhrs_savedata.Tool_Pusher_Comments = _DDR.DDRReport.Tool_Pusher_Comments
                            ddrhrs_savedata.Tool_Pusher_Comments_Spanish = _DDR.DDRReport.Tool_Pusher_Comments_Spanish
                            ddrhrs_savedata.Activities_Next24_hrs = _DDR.DDRReport.Activities_Next24_hrs
                            ddrhrs_savedata.Activities_Next24_hrs_spanish = _DDR.DDRReport.Activities_Next24_hrs_spanish

                            adoDDr.UpdateDDRReport(ddrhrs_savedata)
                        Case "tp_BITS"
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID

                            ddrhrs_savedata.BITS_AnnVel = _DDR.DDRReport.BITS_AnnVel
                            ddrhrs_savedata.BITS_AnnVelCsg = _DDR.DDRReport.BITS_AnnVelCsg
                            ddrhrs_savedata.BITS_DCVel = _DDR.DDRReport.BITS_DCVel
                            ddrhrs_savedata.BITS_NozzleVel = _DDR.DDRReport.BITS_NozzleVel
                            adoDDr.UpdateDDRReport(ddrhrs_savedata)

                            For Each item As com.entities.BITS In _DDR.DDRReport.BITS.Items

                                item.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If item.BITS_ID = -1 Then
                                    adoDDr.SaveBits(item)
                                Else
                                    adoDDr.UpdateBITS(item)
                                End If

                            Next
                        Case "tp_DrillingString"
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID

                            ddrhrs_savedata.DrillString_StringWeight = TextBox26.Text
                            ddrhrs_savedata.DrillString_StackOffWeigth = TextBox27.Text
                            ddrhrs_savedata.DrillString_WOB = TextBox28.Text
                            ddrhrs_savedata.DrillString_RPM = TextBox29.Text
                            ddrhrs_savedata.DrillString_Torque = TextBox30.Text
                            ddrhrs_savedata.DrillString_RotWeigth = TextBox132.Text
                            '!@- Added fields ECD 22 oct 2015
                            ddrhrs_savedata.DrillString_ECD12 = txtECD12.Text
                            ddrhrs_savedata.DrillString_ECD24 = txtECD24.Text

                            'Added 8-Aug-2017
                            'Missing item to save 
                            ddrhrs_savedata.DrillString_PUWeight = TextBox138.Text

                            adoDDr.UpdateDDRReport(ddrhrs_savedata)

                            For Each item As com.entities.DrillString In _DDR.DDRReport.DrillString.Items
                                item.DDR_Report_ID = _DDR.DDRReport.DDRID

                                adoDDr.UpdateDrillString(item)
                            Next

                            For Each item As com.entities.DrillString_Survey In _DDR.DDRReport.DrillString_Survey.Items
                                item.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If item.Survey_ID = -1 Then
                                    adoDDr.SaveDrillString_survey(item)

                                Else
                                    adoDDr.UpdateDrillStringSurvey(item)
                                End If

                            Next

                        Case "tp_BHA"
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID

                            ddrhrs_savedata.BHA_BAGWT = _DDR.DDRReport.BHA_BAGWT
                            ddrhrs_savedata.BHA_BelowJars = _DDR.DDRReport.BHA_BelowJars
                            ddrhrs_savedata.BHA_BottomHoleAssembly = _DDR.DDRReport.BHA_BottomHoleAssembly
                            ddrhrs_savedata.BHA_Comments = _DDR.DDRReport.BHA_Comments

                            adoDDr.UpdateDDRReport(ddrhrs_savedata)
                        Case "tp_Pumps"
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID
                            ddrhrs_savedata.PumpsMeasureddepth = _DDR.DDRReport.PumpsMeasureddepth
                            ddrhrs_savedata.PumpsMudweigth = _DDR.DDRReport.PumpsMudweigth
                            ddrhrs_savedata.PumpsTrueverticaldepth = _DDR.DDRReport.PumpsTrueverticaldepth
                            adoDDr.UpdateDDRReport(ddrhrs_savedata)

                            For Each item As com.entities.Pumps In _DDR.DDRReport.Pumps.Items
                                item.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If item.PUMPS_ID = -1 Then
                                    adoDDr.SavePumps(item)
                                Else
                                    adoDDr.UpdatePumps(item)
                                End If


                            Next
                        Case "tpShakers"
                            For Each item As com.entities.Shakers In _DDR.DDRReport.Shakers.Items
                                item.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If item.Shakers_ID = -1 Then
                                    adoDDr.SaveShakers(item)
                                Else
                                    adoDDr.UpdateShakers(item)
                                End If


                            Next
                        Case "tp_Mud"
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID
                            ddrhrs_savedata.Mud_Comments = _DDR.DDRReport.Mud_Comments
                            ddrhrs_savedata.Mud_HoleVolume = _DDR.DDRReport.Mud_HoleVolume
                            ddrhrs_savedata.Mud_MaxGas = _DDR.DDRReport.Mud_MaxGas
                            ddrhrs_savedata.Mud_Percent = _DDR.DDRReport.Mud_Percent
                            ddrhrs_savedata.Mud_System = _DDR.DDRReport.Mud_System
                            ddrhrs_savedata.Mud_VolumeActivePits = _DDR.DDRReport.Mud_VolumeActivePits
                            ddrhrs_savedata.Mud_weight = _DDR.DDRReport.Mud_weight
                            adoDDr.UpdateDDRReport(ddrhrs_savedata)

                            For Each items As com.entities.Mud In _DDR.DDRReport.Mud.Items
                                items.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If items.MUD_ID = -1 Then
                                    adoDDr.SaveMud(items)
                                Else
                                    adoDDr.UpdateMud(items)
                                End If

                            Next
                        Case "tp_MarineInfo"
                            Dim marineinfo As com.entities.MarineInfo
                            marineinfo = _DDR.DDRReport.MarineInfo.Clone

                            marineinfo.DDR_Report_ID = _DDR.DDRReport.DDRID
                            marineinfo.Marine_ID = _DDR.DDRReport.MarineInfo.Marine_ID

                            marineinfo.YestStock_Diesel = Nothing
                            marineinfo.YestStock_DrillWater = Nothing
                            marineinfo.YestStock_LubOil = Nothing

                            marineinfo.TodayStock_Diesel = Nothing
                            marineinfo.TodayStock_DrillWater = Nothing
                            marineinfo.TodayStock_LubOil = Nothing

                            marineinfo.Used_Diesel = Nothing
                            marineinfo.Used_DrillWater = Nothing
                            marineinfo.Used_LubOil = Nothing

                            marineinfo.RecivedMade_Diesel = Nothing
                            marineinfo.RecivedMade_DrillWater = Nothing
                            marineinfo.RecivedMade_LubOil = Nothing

                            marineinfo.Nitrogen_Empty = Nothing
                            marineinfo.Nitrogen_FullBottles = Nothing
                            marineinfo.Nitrogen_InUse = Nothing

                            marineinfo.Oxygen_Empty = Nothing
                            marineinfo.Oxygen_FullBottles = Nothing
                            marineinfo.Oxygen_InUse = Nothing

                            marineinfo.Acetyl_Empty = Nothing
                            marineinfo.Acetyl_FullBottles = Nothing
                            marineinfo.Acetyl_InUse = Nothing


                            If marineinfo.Marine_ID = -1 Then
                                adoDDr.SaveMarineInfo(marineinfo)
                            Else
                                adoDDr.UpdateMarineinfo(marineinfo)
                            End If

                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID
                            ddrhrs_savedata.Wind_Dir = _DDR.DDRReport.Wind_Dir
                            ddrhrs_savedata.Wind_Speed = _DDR.DDRReport.Wind_Speed
                            ddrhrs_savedata.Current_Dir = _DDR.DDRReport.Current_Dir
                            ddrhrs_savedata.Current_Speed = _DDR.DDRReport.Current_Speed
                            ddrhrs_savedata.Temp_Air = _DDR.DDRReport.Temp_Air
                            ddrhrs_savedata.Temp_Sea = _DDR.DDRReport.Temp_Sea
                            ddrhrs_savedata.Barometer = _DDR.DDRReport.Barometer
                            ddrhrs_savedata.Swell = _DDR.DDRReport.Swell
                            ddrhrs_savedata.Pitch = _DDR.DDRReport.Pitch
                            ddrhrs_savedata.Visibilty = _DDR.DDRReport.Visibilty
                            ddrhrs_savedata.Sea = _DDR.DDRReport.Sea
                            ddrhrs_savedata.Roll = _DDR.DDRReport.Roll
                            ddrhrs_savedata.Heave = _DDR.DDRReport.Heave
                            marineinfo.RigWash = _DDR.DDRReport.MarineInfo.RigWash
                            adoDDr.UpdateDDRReport(ddrhrs_savedata)

                        Case "tpPOB"
                            Dim POB_tosave As com.entities.POB
                            POB_tosave = _DDR.DDRReport.POB
                            POB_tosave.DDR_Report_ID = _DDR.DDRReport.DDRID

                            If POB_tosave.POB_ID = -1 Then
                                adoDDr.SavePOB(POB_tosave)
                                _DDR.DDRReport.POB.POB_ID = POB_tosave.POB_ID
                            Else
                                adoDDr.UpdatePOB(POB_tosave)
                            End If

                        Case "tpEngInfo"
                            Dim marineinfo As New com.entities.MarineInfo
                            ddrhrs_savedata = New com.entities.DDRReport
                            ddrhrs_savedata.DDR_Report_ID = _DDR.DDRReport.DDR_Report_ID
                            ddrhrs_savedata.UsedByPEP = _DDR.DDRReport.UsedByPEP
                            adoDDr.UpdateDDRReport(ddrhrs_savedata)

                            marineinfo.DDR_Report_ID = _DDR.DDRReport.DDRID
                            marineinfo.Marine_ID = _DDR.DDRReport.MarineInfo.Marine_ID

                            marineinfo.YestStock_Diesel = _DDR.DDRReport.MarineInfo.YestStock_Diesel
                            marineinfo.YestStock_DrillWater = _DDR.DDRReport.MarineInfo.YestStock_DrillWater
                            marineinfo.YestStock_LubOil = _DDR.DDRReport.MarineInfo.YestStock_LubOil

                            marineinfo.TodayStock_Diesel = _DDR.DDRReport.MarineInfo.TodayStock_Diesel
                            marineinfo.TodayStock_DrillWater = _DDR.DDRReport.MarineInfo.TodayStock_DrillWater
                            marineinfo.TodayStock_LubOil = _DDR.DDRReport.MarineInfo.TodayStock_LubOil

                            marineinfo.Used_Diesel = _DDR.DDRReport.MarineInfo.Used_Diesel
                            marineinfo.Used_DrillWater = _DDR.DDRReport.MarineInfo.Used_DrillWater
                            marineinfo.Used_LubOil = _DDR.DDRReport.MarineInfo.Used_LubOil

                            marineinfo.RecivedMade_Diesel = _DDR.DDRReport.MarineInfo.RecivedMade_Diesel
                            marineinfo.RecivedMade_DrillWater = _DDR.DDRReport.MarineInfo.RecivedMade_DrillWater
                            marineinfo.RecivedMade_LubOil = _DDR.DDRReport.MarineInfo.RecivedMade_LubOil

                            marineinfo.Nitrogen_Empty = _DDR.DDRReport.MarineInfo.Nitrogen_Empty
                            marineinfo.Nitrogen_FullBottles = _DDR.DDRReport.MarineInfo.Nitrogen_FullBottles
                            marineinfo.Nitrogen_InUse = _DDR.DDRReport.MarineInfo.Nitrogen_InUse

                            marineinfo.Oxygen_Empty = _DDR.DDRReport.MarineInfo.Oxygen_Empty
                            marineinfo.Oxygen_FullBottles = _DDR.DDRReport.MarineInfo.Oxygen_FullBottles
                            marineinfo.Oxygen_InUse = _DDR.DDRReport.MarineInfo.Oxygen_InUse

                            marineinfo.Acetyl_Empty = _DDR.DDRReport.MarineInfo.Acetyl_Empty
                            marineinfo.Acetyl_FullBottles = _DDR.DDRReport.MarineInfo.Acetyl_FullBottles
                            marineinfo.Acetyl_InUse = _DDR.DDRReport.MarineInfo.Acetyl_InUse
                            marineinfo.RigWash = _DDR.DDRReport.MarineInfo.RigWash


                            If marineinfo.Marine_ID = -1 Then
                                adoDDr.SaveMarineInfo(marineinfo)
                            Else
                                adoDDr.UpdateMarineinfo(marineinfo)
                            End If
                        Case "tb_RiserProfile"
                            For Each item As com.entities.RiserProfile In _DDR.DDRReport.RiserProfile.Items
                                item.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If item.IDRiserProfile = -1 Then
                                    adoDDr.SaveRiserProfile(item)
                                Else
                                    adoDDr.UpdateRiserProfile(item)
                                End If

                            Next

                        Case "tb_SOC"
                            Dim SOC_tosave As New com.entities.SOC
                            SOC_tosave = _DDR.DDRReport.SOC
                            SOC_tosave.DDR_Report_ID = _DDR.DDRReport.DDRID

                            If SOC_tosave.SOCINFOID = -1 Then
                                adoDDr.SaveSOC(SOC_tosave)
                            Else
                                adoDDr.UpdateSOC(SOC_tosave)
                            End If


                        Case "tb_LogisticTransitLog"

                            For Each item As com.entities.LogisticTransitLog In _DDR.DDRReport.LogisticTransitLog.items
                                item.DDR_Report_ID = _DDR.DDRReport.DDRID
                                If item.LTID = -1 Then
                                    adoDDr.SaveLogisticTransitLog(item)
                                Else
                                    adoDDr.UpdateLogisticTransitLog(item)
                                End If

                            Next


                    End Select
                    'adoDDr.ModifyALLDDR(_DDR)
                    _saved = True
                    _FormMode = 1
                    'FillForm()
                    MsgBox("DDR Saved.", MsgBoxStyle.Information, "DDR Saved Successfully")
                Catch ex As Exception
                    MsgBox(ex.Message.ToString)
                Finally
                    _DDR.LastUpdate = Now()
                    adoDDr.UpdateDDRControl(_DDR)
                End Try


                Dim ado As New com.ADO.ADOMySQLDDR
                'SaveActivityOnMemory()
                'ado.ModifyActivities(_DDR)

        End Select

    End Sub
    'toma toda la info para ponerla en el objeto
    Private Sub LoadDataToMem()

        'Modificacion 18 Jul 2016 error de logica 
        Dim _DDRReport As com.entities.DDRReport
        If _FormMode.Equals(FormMode.Insert) Then
            _DDRReport = New com.entities.DDRReport
        End If

        If _FormMode.Equals(FormMode.Edit) Then
            _DDRReport = _DDR.DDRReport
        End If

        Dim umrs As com.entities.UrgentsMRsCollection

        'Modificacion 18 Jul 2016 error al crear un nuevo reporte limpio
        Try
            If Not IsNothing(DDRReport.DDRReport.UrgentsMR) Then
                umrs = DDRReport.DDRReport.UrgentsMR
            Else
                umrs = New com.entities.UrgentsMRsCollection
            End If
        Catch ex As Exception
            umrs = New com.entities.UrgentsMRsCollection
            DDRReport.DDRReport.UrgentsMR = New com.entities.UrgentsMRsCollection
        End Try



        If TextBox10.Text.Equals("") Then
            _DDR.ReportNo = 0
        Else
            _DDR.ReportNo = TextBox10.Text
        End If

        _DDR.LastUpdate = Now()

        If Not TextBox147.Text.Equals("") Then
            _DDR.Well = TextBox147.Text
        End If

        If Not TextBox148.Text.Equals("") Then
            _DDR.Description = TextBox148.Text
        End If


        Try
            _DDR.ReportDate = TextBox9.Text
        Catch ex As Exception

        End Try

        Dim ddrid As Integer = _DDR.DDRReport.DDR_Report_ID




        _DDRReport.DDR_Report_ID = ddrid
        _DDRReport.Operator_s = txtOperator.Text
        _DDRReport.Contractor = TextBox2.Text
        _DDRReport.Midnigth_Depth = TextBox3.Text
        _DDRReport.TVD = TextBox4.Text
        _DDRReport.Yesterdays_Depth = TextBox5.Text
        _DDRReport.Progress = TextBox6.Text
        _DDRReport.Formation = TextBox7.Text
        _DDRReport.Mud_weight = TextBox8.Text
        _DDRReport.Well = TextBox11.Text
        _DDRReport.Block = TextBox12.Text
        _DDRReport.Country = TextBox13.Text
        _DDRReport.KSP_Hrs = TextBox14.Text
        _DDRReport.Todays_Rot_Hrs = TextBox15.Text
        _DDRReport.Yest_Rot_Hrs = TextBox16.Text
        _DDRReport.Cum_Rot_Hrs = TextBox17.Text
        _DDRReport.Leak_off_test = TextBox18.Text
        _DDRReport.DaysFromSpud = TextBox80.Text
        _DDRReport.ProposedTD = TextBox81.Text
        _DDRReport.RKBToWH = TextBox82.Text
        _DDRReport.RKBtoSeaBeadMtrs = TextBox83.Text
        _DDRReport.TOLSize = TextBox84.Text
        _DDRReport.LastCasing = TextBox85.Text
        _DDRReport.WeightGR = TextBox86.Text
        _DDRReport.CasingID = TextBox87.Text
        _DDRReport.CsgShoeMtrs = TextBox88.Text
        _DDRReport.TotalsHrs = TextBox19.Text
        _DDRReport.Tool_Pusher_Comments = TextBox20.Text
        _DDRReport.Activities_Next24_hrs = TextBox21.Text
        _DDRReport.BITS_AnnVelCsg = TextBox22.Text
        _DDRReport.BITS_AnnVel = TextBox23.Text
        _DDRReport.BITS_DCVel = TextBox24.Text
        _DDRReport.BITS_NozzleVel = TextBox25.Text
        _DDRReport.DrillString_StringWeight = TextBox26.Text
        _DDRReport.DrillString_StackOffWeigth = TextBox27.Text
        _DDRReport.DrillString_WOB = TextBox28.Text
        _DDRReport.DrillString_RPM = TextBox29.Text
        _DDRReport.DrillString_Torque = TextBox30.Text
        _DDRReport.DrillString_RotWeigth = TextBox132.Text
        _DDRReport.BHA_BottomHoleAssembly = TextBox129.Text
        _DDRReport.BHA_BelowJars = TextBox31.Text
        _DDRReport.BHA_BAGWT = TextBox32.Text
        _DDRReport.BHA_Comments = TextBox33.Text
        _DDRReport.Mud_VolumeActivePits = TextBox89.Text
        _DDRReport.Mud_HoleVolume = TextBox90.Text
        _DDRReport.Mud_System = TextBox91.Text
        _DDRReport.Mud_Percent = TextBox92.Text
        '_DDRReport.Mud_MaxGas = TextBox93.Text
        _DDRReport.Mud_Comments = TextBox94.Text
        _DDRReport.Wind_Dir = TextBox34.Text
        _DDRReport.Wind_Speed = TextBox35.Text
        _DDRReport.Current_Dir = TextBox36.Text
        _DDRReport.Current_Speed = TextBox37.Text
        _DDRReport.Temp_Air = TextBox38.Text
        _DDRReport.Temp_Sea = TextBox39.Text
        _DDRReport.Barometer = TextBox40.Text
        _DDRReport.Sea = TextBox41.Text
        _DDRReport.Swell = TextBox42.Text
        _DDRReport.Roll = TextBox43.Text
        _DDRReport.Pitch = TextBox44.Text
        _DDRReport.Heave = TextBox45.Text
        _DDRReport.Visibilty = TextBox46.Text
        _DDRReport.PemexUnit = TextBox50.Text
        _DDRReport.Washpipehrs = TextBox51.Text
        _DDRReport.EstendWell = TextBox130.Text
        _DDRReport.DDRDate = DateTimePicker6.Value
        _DDRReport.UsedByPEP = TextBox100.Text
        _DDRReport.DrillLineSlippedandCut = TextBox133.Text
        _DDRReport.DrillString_PUWeight = TextBox138.Text
        _DDRReport.Tool_Pusher_Comments_Spanish = TextBox144.Text
        _DDRReport.Activities_Next24_hrs_spanish = TextBox145.Text
        _DDRReport.PumpsMeasureddepth = TextBox149.Text
        _DDRReport.PumpsTrueverticaldepth = TextBox150.Text
        _DDRReport.PumpsMudweigth = TextBox151.Text
        _DDRReport.DrillString_ECD12 = txtECD12.Text
        _DDRReport.DrillString_ECD24 = txtECD24.Text


        'Save SOC information
        Dim socnewinfo As New com.entities.SOC
        If Not TextBox143.Text = "" Then
            socnewinfo.SOCINFOID = Integer.Parse(TextBox143.Text)
        End If
        socnewinfo.SOCToday = TextBox134.Text
        socnewinfo.SOCMonth = TextBox135.Text
        socnewinfo.SOCSTOPTour = TextBox136.Text
        socnewinfo.DaysWithoutLTA = TextBox137.Text
        _DDRReport.SOC = socnewinfo


        'load DDR Hrs for saving
        If _FormMode = FormModes.Insert Then

            Dim ddrhrs_c As New com.entities.DDRHrs_Collection
            For Each row As DataGridViewRow In dgv_DDRHrs.Rows
                Dim ddrhrs As New com.entities.DDRHrs
                If Not IsNothing(row.Cells(0).Value) Or Not IsNothing(row.Cells(1).Value) Or Not IsNothing(row.Cells(2).Value) Or Not IsNothing(row.Cells(3).Value) Then
                    If row.Cells(0).Value <> "" Or row.Cells(1).Value <> "" Or row.Cells(2).Value <> "" Or row.Cells(3).Value <> "" Then

                        If Not isValidatedHrsFormatDDRHrs(row.Cells(0).Value) Then

                            Throw New Exception("Error on the DDR hrs, the format is wrong entered")
                        Else
                            ddrhrs.Fromv = row.Cells(0).Value
                        End If

                        If Not isValidatedHrsFormatDDRHrs(row.Cells(1).Value) Then
                            Throw New Exception("Error on the DDR hrs, the format is wrong entered")
                        Else
                            ddrhrs.Tov = row.Cells(1).Value
                        End If


                        Try
                            ddrhrs.Total = row.Cells(2).Value
                        Catch ex As Exception

                        End Try
                        If ddrhrs.Total > 24 Then
                            Throw New Exception("The total of hrs is greater than 24hrs")
                        End If

                        ddrhrs.Code = row.Cells(3).Value
                        ddrhrs.Comment = row.Cells(4).Value
                        ddrhrs.CommentSpanish = row.Cells(5).Value
                        ddrhrs.DDR_Report_ID = _DDRReport.DDR_Report_ID
                        If Not IsNothing(row.Cells(6).Value) Then
                            ddrhrs.Detail_HR_ID = row.Cells(6).Value
                        End If
                        ddrhrs_c.Add(ddrhrs)
                    End If
                End If

            Next

            If ddrhrs_c.Count > 0 Then
                _DDRReport.DDRHrs = ddrhrs_c
            End If

        End If

        'load bits for saving
        Dim bits As New com.entities.BITS_Collection
        For Each row As DataGridViewRow In dgv_BITS.Rows
            Dim bit As New com.entities.BITS
            If Not IsNothing(row.Cells(0).Value) Then
                If row.Cells(0).Value <> "" Then
                    bit.bit_No = row.Cells(0).Value

                    If IsNothing(row.Cells(1).Value) Then
                        bit.bit_Size = ""
                    Else
                        bit.bit_Size = row.Cells(1).Value
                    End If

                    If IsNothing(row.Cells(2).Value) Then
                        bit.bit_Make = ""
                    Else
                        bit.bit_Make = row.Cells(2).Value
                    End If

                    If IsNothing(row.Cells(3).Value) Then
                        bit.bit_Serial = ""
                    Else
                        bit.bit_Serial = row.Cells(3).Value
                    End If

                    If IsNothing(row.Cells(4).Value) Then
                        bit.Bit_type = ""
                    Else
                        bit.Bit_type = row.Cells(4).Value
                    End If

                    If IsNothing(row.Cells(5).Value) Then
                        bit.bit_Jets = ""
                    Else
                        bit.bit_Jets = row.Cells(5).Value
                    End If

                    If IsNothing(row.Cells(6).Value) Then
                        bit.bit_TFA = ""
                    Else
                        bit.bit_TFA = row.Cells(6).Value
                    End If


                    If IsNothing(row.Cells(7).Value) Then
                        bit.bit_Out = ""
                    Else
                        bit.bit_Out = row.Cells(7).Value
                    End If

                    If IsNothing(row.Cells(8).Value) Then
                        bit.bit_In = ""
                    Else
                        bit.bit_In = row.Cells(8).Value
                    End If

                    If IsNothing(row.Cells(9).Value) Then
                        bit.bit_Mtrs = ""
                    Else

                        bit.bit_Mtrs = row.Cells(9).Value
                    End If

                    '28-Oct-2018
                    ' Se agrego la siguiente seccion ya que se agrego el campo de bits_hrs
                    If IsNothing(row.Cells(10).Value) Then
                        bit.bit_Hrs = ""
                    Else
                        bit.bit_Hrs = row.Cells(10).Value
                    End If

                    bit.bit_Comments = row.Cells(11).Value

                    If Not IsNothing(row.Cells(12).Value) Then
                        bit.BITS_ID = row.Cells(12).Value
                    End If
                    bits.Add(bit)
                End If
            End If
        Next

        If bits.Count > 0 Then
            _DDRReport.BITS = bits
        End If


        'load drilling string for saving
        Dim drillstring As New com.entities.DrillString_Collection
        For Each row As DataGridViewRow In dgv_String.Rows
            Dim drillstring_row As New com.entities.DrillString
            If row.Cells(0).Value <> "" Then
                drillstring_row.Description = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    drillstring_row.SizeDR = ""
                Else
                    drillstring_row.SizeDR = row.Cells(1).Value
                End If
                If IsNothing(row.Cells(2).Value) Then
                    drillstring_row.Weight = ""
                Else
                    drillstring_row.Weight = row.Cells(2).Value
                End If
                If IsNothing(row.Cells(3).Value) Then
                    drillstring_row.Grade = ""
                Else
                    drillstring_row.Grade = row.Cells(3).Value
                End If
                If IsNothing(row.Cells(4).Value) Then
                    drillstring_row.ToolJoint = ""
                Else

                    drillstring_row.ToolJoint = row.Cells(4).Value
                End If
                If IsNothing(row.Cells(5).Value) Then
                    drillstring_row.ToolJntOD = ""
                Else

                    drillstring_row.ToolJntOD = row.Cells(5).Value
                End If
                If IsNothing(row.Cells(6).Value) Then
                    drillstring_row.TotalOnBoard = ""
                Else
                    drillstring_row.TotalOnBoard = row.Cells(6).Value
                End If

                If Not IsNothing(row.Cells(7).Value) Then
                    drillstring_row.BHAinHole = row.Cells(7).Value
                End If

                If Not IsNothing(row.Cells(8).Value) Then
                    drillstring_row.DrillString_ID = row.Cells(8).Value
                End If
                drillstring.Add(drillstring_row)
            End If
        Next

        If drillstring.Count > 0 Then
            _DDRReport.DrillString = drillstring
        End If


        ' save drill string survey
        Dim drillstring_suvey As New com.entities.DrillString_Survey_Collection
        For Each row As DataGridViewRow In dgv_String_Survey.Rows
            Dim survey As New com.entities.DrillString_Survey
            If row.Cells(0).Value <> "" Or row.Cells(1).Value <> "" Then
                survey.DirectionalSurveys = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    survey.MID = ""
                Else
                    survey.MID = row.Cells(1).Value
                End If
                If IsNothing(row.Cells(2).Value) Then
                    survey.TVD = ""
                Else
                    survey.TVD = row.Cells(2).Value
                End If
                If IsNothing(row.Cells(3).Value) Then
                    survey.INC = ""
                Else
                    survey.INC = row.Cells(3).Value
                End If
                If IsNothing(row.Cells(4).Value) Then
                    survey.AZM = ""
                Else
                    survey.AZM = row.Cells(4).Value
                End If
                If IsNothing(row.Cells(5).Value) Then
                    survey.Comments = ""
                Else
                    survey.Comments = row.Cells(5).Value
                End If

                If Not IsNothing(row.Cells(6).Value) Then
                    survey.Survey_ID = row.Cells(6).Value
                End If
                drillstring_suvey.Add(survey)
            End If
        Next


        If drillstring_suvey.Count > 0 Then
            _DDRReport.DrillString_Survey = drillstring_suvey
        End If

        'Save pumps
        Dim pumps As New com.entities.Pumps_Collection
        For Each row As DataGridViewRow In dgv_pumps.Rows
            Dim pump As New com.entities.Pumps
            If row.Cells(0).Value <> "" Then
                pump.PumpNo = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    pump.MakeandModel = ""
                Else
                    pump.MakeandModel = row.Cells(1).Value
                End If
                If IsNothing(row.Cells(2).Value) Then
                    pump.Stroke = ""
                Else
                    pump.Stroke = row.Cells(2).Value
                End If
                If IsNothing(row.Cells(3).Value) Then
                    pump.Liners = row.Cells(3).Value
                Else
                    pump.Liners = row.Cells(3).Value
                End If
                If IsNothing(row.Cells(4).Value) Then
                    pump.SPM = ""
                Else
                    pump.SPM = row.Cells(4).Value
                End If
                If IsNothing(row.Cells(5).Value) Then
                    pump.GPM = row.Cells(5).Value
                Else
                    pump.GPM = row.Cells(5).Value
                End If
                If IsNothing(row.Cells(6).Value) Then
                    pump.EFF = ""
                Else
                    pump.EFF = row.Cells(6).Value
                End If
                If IsNothing(row.Cells(7).Value) Then
                    pump.Press = ""
                Else
                    pump.Press = row.Cells(7).Value
                End If
                If IsNothing(row.Cells(8).Value) Then
                    pump.MP = "'"
                Else
                    pump.MP = row.Cells(8).Value
                End If
                If IsNothing(row.Cells(9).Value) Then
                    pump.CLF = ""
                Else
                    pump.CLF = row.Cells(9).Value
                End If
                If IsNothing(row.Cells(10).Value) Then
                    pump.CLFCK = ""
                Else
                    pump.CLFCK = row.Cells(10).Value
                End If

                'pump.Comments = row.Cells(11).Value
                If IsNothing(row.Cells(11).Value) Then
                    pump.s30StrokesChoke = ""
                Else
                    pump.s30StrokesChoke = row.Cells(11).Value
                End If
                If IsNothing(row.Cells(12).Value) Then
                    pump.s30StrokesCK = ""
                Else
                    pump.s30StrokesCK = row.Cells(12).Value
                End If
                If IsNothing(row.Cells(13).Value) Then
                    pump.s40StrokesChoke = ""
                Else
                    pump.s40StrokesChoke = row.Cells(13).Value
                End If

                'If Not IsNothing(row.Cells(13).Value) Then
                '    pump.s40StrokesChoke = row.Cells(13).Value
                'Else
                '    pump.s40StrokesChoke = row.Cells(13).Value
                'End If
                If IsNothing(row.Cells(14).Value) Then
                    pump.s40StrokesCK = ""
                Else
                    pump.s40StrokesCK = row.Cells(14).Value
                End If
                If IsNothing(row.Cells(15).Value) Then
                    pump.s50StrokesChoke = ""
                Else
                    pump.s50StrokesChoke = row.Cells(15).Value
                End If
                If IsNothing(row.Cells(16).Value) Then
                    pump.s50StrokesCK = ""
                Else
                    pump.s50StrokesCK = row.Cells(16).Value
                End If

                If Not IsNothing(row.Cells(17).Value) Then
                    If Not row.Cells(17).Value.Equals("") Then
                        pump.PUMPS_ID = row.Cells(17).Value
                    End If
                End If
                pumps.Add(pump)
            End If
        Next

        If pumps.Count > 0 Then
            _DDRReport.Pumps = pumps
        End If


        'Save Shakers 
        Dim shakers As New com.entities.Shakers_Collection
        For Each row As DataGridViewRow In dgv_Shakers.Rows
            Dim shaker As New com.entities.Shakers
            If row.Cells(0).Value <> "" Then
                shaker.ShakerNo = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    shaker.MakeAndModel = ""
                Else
                    shaker.MakeAndModel = row.Cells(1).Value
                End If
                If IsNothing(row.Cells(2).Value) Then
                    shaker.ScreenSize = ""
                Else
                    shaker.ScreenSize = row.Cells(2).Value
                End If
                If IsNothing(row.Cells(3).Value) Then
                    shaker.Top1 = ""
                Else
                    shaker.Top1 = row.Cells(3).Value
                End If
                If IsNothing(row.Cells(4).Value) Then
                    shaker.Top2 = ""
                Else
                    shaker.Top2 = row.Cells(4).Value
                End If
                If IsNothing(row.Cells(5).Value) Then
                    shaker.Top3 = ""
                Else
                    shaker.Top3 = row.Cells(5).Value
                End If
                If IsNothing(row.Cells(6).Value) Then
                    shaker.Top4 = ""
                Else
                    shaker.Top4 = row.Cells(6).Value
                End If
                If IsNothing(row.Cells(7).Value) Then
                    shaker.Bottom1 = ""
                Else
                    shaker.Bottom1 = row.Cells(7).Value
                End If
                If IsNothing(row.Cells(8).Value) Then
                    shaker.Bottom2 = ""
                Else
                    shaker.Bottom2 = row.Cells(8).Value
                End If
                If IsNothing(row.Cells(9).Value) Then
                    shaker.Bottom3 = ""
                Else
                    shaker.Bottom3 = row.Cells(9).Value
                End If
                If IsNothing(row.Cells(10).Value) Then
                    shaker.Bottom4 = ""
                Else
                    shaker.Bottom4 = row.Cells(10).Value
                End If

                If Not IsNothing(row.Cells(11).Value) Then
                    shaker.Shakers_ID = row.Cells(11).Value
                End If
                shakers.Add(shaker)
            End If
        Next

        If shakers.Count > 0 Then
            _DDRReport.Shakers = shakers
        End If

        'Save Mud
        Dim muds As New com.entities.Mud_Collection
        For Each row As DataGridViewRow In dgv_Mud.Rows
            Dim mud As New com.entities.Mud
            If row.Cells(0).Value <> "" Then
                mud.TimeMud = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    mud.WT = ""
                Else
                    mud.WT = row.Cells(1).Value
                End If
                If IsNothing(row.Cells(2).Value) Then
                    mud.VIS = ""
                Else
                    mud.VIS = row.Cells(2).Value
                End If
                If IsNothing(row.Cells(3).Value) Then
                    mud.WL = ""
                Else
                    mud.WL = row.Cells(3).Value
                End If
                If IsNothing(row.Cells(4).Value) Then
                    mud.Cake = ""
                Else
                    mud.Cake = row.Cells(4).Value
                End If
                If IsNothing(row.Cells(5).Value) Then
                    mud.PH = ""
                Else
                    mud.PH = row.Cells(5).Value
                End If
                If IsNothing(row.Cells(6).Value) Then
                    mud.Sand = ""
                Else
                    mud.Sand = row.Cells(6).Value
                End If
                If IsNothing(row.Cells(7).Value) Then
                    mud.Solids = ""
                Else
                    mud.Solids = row.Cells(7).Value
                End If
                If IsNothing(row.Cells(8).Value) Then
                    mud.PvYP = ""
                Else
                    mud.PvYP = row.Cells(8).Value
                End If
                If IsNothing(row.Cells(9).Value) Then
                    mud.KCL = ""
                Else
                    mud.KCL = row.Cells(9).Value
                End If
                If IsNothing(row.Cells(10).Value) Then
                    mud.Pm = ""
                Else
                    mud.Pm = row.Cells(10).Value
                End If

                If IsNothing(row.Cells(11).Value) Then
                    mud.Comments = ""
                Else
                    mud.Comments = row.Cells(11).Value
                End If

                If Not IsNothing(row.Cells(12).Value) Then
                    mud.MUD_ID = row.Cells(12).Value
                End If
                muds.Add(mud)
            End If
        Next

        If muds.Count > 0 Then
            _DDRReport.Mud = muds
        End If

        'Save the riser profile
        Dim risersprofileCol As New com.entities.RiserProfileCollection
        For Each row As DataGridViewRow In dgv_RiserProfile.Rows
            Dim riserprofile As New com.entities.RiserProfile
            If row.Cells(0).Value <> "" Then
                riserprofile.IDBeacon = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    riserprofile.Depth = ""
                Else
                    riserprofile.Depth = row.Cells(1).Value
                End If
                If IsNothing(row.Cells(2).Value) Then
                    riserprofile.Temp6hrs = ""
                Else
                    riserprofile.Temp6hrs = row.Cells(2).Value
                End If
                If IsNothing(row.Cells(3).Value) Then
                    riserprofile.Temp12hrs = ""
                Else
                    riserprofile.Temp12hrs = row.Cells(3).Value
                End If
                If IsNothing(row.Cells(4).Value) Then
                    riserprofile.Temp18hrs = ""
                Else
                    riserprofile.Temp18hrs = row.Cells(4).Value
                End If
                If IsNothing(row.Cells(5).Value) Then
                    riserprofile.Temp24hrs = ""
                Else
                    riserprofile.Temp24hrs = row.Cells(5).Value
                End If
                If IsNothing(row.Cells(6).Value) Then
                    riserprofile.Current6hrs = ""
                Else
                    riserprofile.Current6hrs = row.Cells(6).Value
                End If
                If IsNothing(row.Cells(7).Value) Then
                    riserprofile.Current12hrs = ""
                Else
                    riserprofile.Current12hrs = row.Cells(7).Value
                End If
                If IsNothing(row.Cells(8).Value) Then
                    riserprofile.Current18hrs = ""
                Else
                    riserprofile.Current18hrs = row.Cells(8).Value
                End If
                If IsNothing(row.Cells(9).Value) Then
                    riserprofile.Current24hrs = ""
                Else
                    riserprofile.Current24hrs = row.Cells(9).Value
                End If
                If IsNothing(row.Cells(10).Value) Then
                    riserprofile.Direction6hrs = ""
                Else
                    riserprofile.Direction6hrs = row.Cells(10).Value
                End If
                If IsNothing(row.Cells(11).Value) Then
                    riserprofile.Direction12hrs = ""
                Else
                    riserprofile.Direction12hrs = row.Cells(11).Value
                End If

                If IsNothing(row.Cells(12).Value) Then
                    riserprofile.Direction18hrs = ""
                Else
                    riserprofile.Direction18hrs = row.Cells(12).Value
                End If
                If IsNothing(row.Cells(13).Value) Then
                    riserprofile.Direction24hrs = ""
                Else
                    riserprofile.Direction24hrs = row.Cells(13).Value
                End If

                If Not IsNothing(row.Cells(14).Value) Then
                    riserprofile.IDRiserProfile = row.Cells(14).Value
                End If
                risersprofileCol.Add(riserprofile)
            End If
        Next

        If risersprofileCol.Count > 0 Then
            _DDRReport.RiserProfile = risersprofileCol
        End If


        'Save marine information
        Dim marineinfo As New com.entities.MarineInfo
        If Not TextBox141.Text = "" Then
            marineinfo.Marine_ID = Integer.Parse(TextBox141.Text)
        End If
        marineinfo.AirGap = TextBox47.Text
        marineinfo.UsedPlayload = TextBox48.Text
        marineinfo.RemainingPayload = TextBox49.Text
        marineinfo.LastboatDrill = DateTimePicker1.Value
        marineinfo.FireDrill = DateTimePicker2.Value
        marineinfo.BOPTest = DateTimePicker3.Value
        marineinfo.COMTest = DateTimePicker4.Value
        marineinfo.YestStock_PotWater = TextBox53.Text
        marineinfo.YestStock_Diesel = TextBox110.Text
        marineinfo.YestStock_DrillWater = TextBox109.Text
        marineinfo.YestStock_LubOil = TextBox108.Text
        marineinfo.YestStock_Barite = TextBox57.Text
        marineinfo.YestStock_Bentonite = TextBox61.Text
        marineinfo.YestStock_Gel = TextBox65.Text
        marineinfo.YestStock_CementG = TextBox69.Text
        marineinfo.YestStock_CmtBlended = TextBox73.Text
        marineinfo.TodayStock_PotWater = TextBox54.Text
        marineinfo.TodayStock_Diesel = TextBox107.Text
        marineinfo.TodayStock_DrillWater = TextBox106.Text
        marineinfo.TodayStock_LubOil = TextBox105.Text
        marineinfo.TodayStock_Barite = TextBox58.Text
        marineinfo.TodayStock_Bentonite = TextBox62.Text
        marineinfo.TodayStock_Gel = TextBox66.Text
        marineinfo.TodayStock_CementG = TextBox70.Text
        marineinfo.TodayStock_CMTBlended = TextBox74.Text
        marineinfo.Used_PotWater = TextBox55.Text
        marineinfo.Used_Diesel = TextBox113.Text
        marineinfo.Used_DrillWater = TextBox112.Text
        marineinfo.Used_LubOil = TextBox111.Text
        marineinfo.Used_Barite = TextBox59.Text
        marineinfo.Used_Bentoniote = TextBox63.Text
        marineinfo.Used_Gel = TextBox67.Text
        marineinfo.Used_CementG = TextBox71.Text
        marineinfo.Used_CmtBlended = TextBox75.Text
        marineinfo.RecivedMade_PotWater = TextBox56.Text
        marineinfo.RecivedMade_Diesel = TextBox116.Text
        marineinfo.RecivedMade_DrillWater = TextBox115.Text
        marineinfo.RecivedMade_LubOil = TextBox114.Text
        marineinfo.RecivedMade_Barite = TextBox60.Text
        marineinfo.RecivedMade_Bentoniote = TextBox64.Text
        marineinfo.RecivedMade_Gel = TextBox68.Text
        marineinfo.RecivedMade_CementG = TextBox72.Text
        marineinfo.RecivedMade_CmtBlended = TextBox76.Text
        marineinfo.Helifuel = TextBox77.Text
        marineinfo.Brine = TextBox78.Text
        marineinfo.Base_oil = TextBox79.Text
        'marineinfo.LubOil = TextBox117.Text
        marineinfo.Nitrogen_FullBottles = TextBox118.Text
        marineinfo.Nitrogen_InUse = TextBox121.Text
        marineinfo.Nitrogen_Empty = TextBox124.Text
        marineinfo.Oxygen_FullBottles = TextBox119.Text
        marineinfo.Oxygen_InUse = TextBox122.Text
        marineinfo.Oxygen_Empty = TextBox125.Text
        marineinfo.Acetyl_FullBottles = TextBox120.Text
        marineinfo.Acetyl_InUse = TextBox123.Text
        marineinfo.Acetyl_Empty = TextBox126.Text
        marineinfo.Comments = TextBox131.Text
        marineinfo.ToneMilesSinceLastCut = TextBox52.Text
        marineinfo.GeneratorsOnline = TextBox139.Text
        marineinfo.Thrustersonline = TextBox140.Text
        marineinfo.Comments_spanish = TextBox146.Text
        marineinfo.RigWash = txtRigwash.Text

        _DDRReport.MarineInfo = marineinfo


        'Save POB info

        Try
            Dim POB As New com.entities.POB
            If Not TextBox142.Text = "" Then
                POB.POB_ID = Integer.Parse(TextBox142.Text)
            End If
            If Not TextBox95.Text.Equals("") Then
                If IsNumeric(TextBox95.Text) Then
                    POB.GRCrew = Integer.Parse(TextBox95.Text)
                End If
            End If
            If Not TextBox96.Text.Equals("") Then
                If IsNumeric(TextBox96.Text) Then
                    POB.GRServ = Integer.Parse(TextBox96.Text)
                End If
            End If

            If Not TextBox97.Text.Equals("") Then
                If IsNumeric(TextBox97.Text) Then
                    POB.Catering = Integer.Parse(TextBox97.Text)
                End If
            End If
            If Not TextBox98.Text.Equals("") Then
                If IsNumeric(TextBox98.Text) Then
                    POB.Pemex = Integer.Parse(TextBox98.Text)
                End If
            End If

            If Not TextBox99.Text.Equals("") Then
                If IsNumeric(TextBox99.Text) Then
                    POB.OpSer = Integer.Parse(TextBox99.Text)
                End If
            End If

            If Not TextBox101.Text.Equals("") Then
                If IsNumeric(TextBox101.Text) Then
                    POB.DailyCost = Integer.Parse(TextBox101.Text)
                End If
            End If

            'POB.Total = Integer.Parse(TextBox100.Text)
            If Not TextBox102.Text.Equals("") Then
                If IsNumeric(TextBox102.Text) Then
                    POB.AccCost = Integer.Parse(TextBox102.Text)
                End If
            End If

            If Not TextBox103.Text.Equals("") Then
                If IsNumeric(TextBox103.Text) Then
                    POB.AverageCost = Integer.Parse(TextBox103.Text)
                End If
            End If
            If Not TextBox104.Text.Equals("") Then
                If IsNumeric(TextBox104.Text) Then
                    POB.DaysFromLAstLTA = Integer.Parse(TextBox104.Text)
                End If
            End If


            _DDRReport.POB = POB
        Catch ex As Exception
            MsgBox("Error to save POB data filled not numeric")
        End Try

        'Save Logistic Transit Log
        Dim ltlc As New com.entities.LogisticTransitLogCollection
        For Each row As DataGridViewRow In dgv_LogTranLogBoat.Rows
            If row.Cells(0).Value <> "" Then
                Dim logitem As New com.entities.LogisticTransitLog
                logitem.Type = "Boat"
                logitem.Log = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    logitem.LogEsp = ""
                Else
                    logitem.LogEsp = row.Cells(1).Value
                End If

                If Not IsNothing(row.Cells(2).Value) Then
                    logitem.LTID = row.Cells(2).Value
                End If
                ltlc.Add(logitem)
            End If
        Next

        For Each row As DataGridViewRow In dgv_LogTranLogHeli.Rows
            If row.Cells(0).Value <> "" Then
                Dim logitem As New com.entities.LogisticTransitLog
                logitem.Type = "Helicopter"
                logitem.Log = row.Cells(0).Value
                If IsNothing(row.Cells(1).Value) Then
                    logitem.LogEsp = ""
                Else
                    logitem.LogEsp = row.Cells(1).Value
                End If

                If Not IsNothing(row.Cells(2).Value) Then
                    logitem.LTID = row.Cells(2).Value
                End If
                ltlc.Add(logitem)
            End If
        Next
        If ltlc.Count > 0 Then
            _DDRReport.LogisticTransitLog = ltlc
        End If

        If _FormMode = FormModes.Insert Then
            If Not IsNothing(umrs) Then
                For Each item As com.entities.UrgentMRs In umrs.items
                    item.MRUrgentID = -1
                    _DDRReport.UrgentsMR.Add(item)
                Next
            End If
        End If
        _DDR.DDRReport = _DDRReport
    End Sub

    Private Sub LockForm()

        For Each Control As System.Windows.Forms.Control In Me.Controls
            If TypeOf (Control) Is TextBox Then
                CType(Control, TextBox).Enabled = False
            End If
            If TypeOf (Control) Is TabControl Then
                For Each page As TabPage In CType(Control, TabControl).TabPages
                    For Each page_control As System.Windows.Forms.Control In page.Controls
                        If TypeOf (page_control) Is TextBox Then
                            CType(page_control, TextBox).Enabled = False
                        End If
                        If TypeOf (page_control) Is GroupBox Then
                            For Each groupbox_control As System.Windows.Forms.Control In CType(page_control, GroupBox).Controls
                                If TypeOf (groupbox_control) Is TextBox Then
                                    CType(groupbox_control, TextBox).Enabled = False
                                End If
                            Next
                        End If
                        If TypeOf (page_control) Is DateTimePicker Then
                            CType(page_control, DateTimePicker).Enabled = False
                        End If
                        If TypeOf (page_control) Is DataGridView Then
                            CType(page_control, DataGridView).ReadOnly = True
                        End If
                    Next
                Next
            End If
        Next
        Button5.Enabled = False
        Button6.Enabled = False
    End Sub

    Private Sub UnlockForm()

        For Each Control As System.Windows.Forms.Control In Me.Controls
            If TypeOf (Control) Is TextBox Then
                CType(Control, TextBox).Enabled = True
            End If
            If TypeOf (Control) Is TabControl Then
                For Each page As TabPage In CType(Control, TabControl).TabPages
                    For Each page_control As System.Windows.Forms.Control In page.Controls
                        If TypeOf (page_control) Is TextBox Then
                            CType(page_control, TextBox).Enabled = True
                        End If
                        If TypeOf (page_control) Is GroupBox Then
                            For Each groupbox_control As System.Windows.Forms.Control In CType(page_control, GroupBox).Controls
                                If TypeOf (groupbox_control) Is TextBox Then
                                    CType(groupbox_control, TextBox).Enabled = True
                                End If
                            Next
                        End If
                        If TypeOf (page_control) Is DateTimePicker Then
                            CType(page_control, DateTimePicker).Enabled = True
                        End If
                        If TypeOf (page_control) Is DataGridView Then
                            CType(page_control, DataGridView).ReadOnly = False
                        End If
                    Next
                Next
            End If
        Next
        Button5.Enabled = True
        Button6.Enabled = True
    End Sub

    Private Sub FillForm()
        If Not IsNothing(_DDR) Then
            'Load Grids and clean data
            'LoadDataGrids()
            dgv_BITS.Rows.Clear()
            dgv_DDRHrs.Rows.Clear()
            dgv_Mud.Rows.Clear()
            If Not IsNothing(_DDR.DDRReport.Pumps) Then
                dgv_pumps.Rows.Clear()
            End If
            dgv_Shakers.Rows.Clear()
            dgv_String.Rows.Clear()
            dgv_String_Survey.Rows.Clear()
            dgv_activities.Rows.Clear()
            dgv_RiserProfile.Rows.Clear()
            dgv_LogTranLogBoat.Rows.Clear()
            dgv_LogTranLogHeli.Rows.Clear()
            dgv_PUMR.Rows.Clear()


            TextBox9.Text = _DDR.ReportDate.ToString("MM/dd/yyyy")
            TextBox10.Text = _DDR.ReportNo
            TextBox147.Text = _DDR.Well
            TextBox148.Text = _DDR.Description

            'Load DDR Data
            If Not IsNothing(_DDR.DDRReport) Then
                txtOperator.Text = _DDR.DDRReport.Operator_s
                TextBox2.Text = _DDR.DDRReport.Contractor
                TextBox3.Text = _DDR.DDRReport.Midnigth_Depth
                TextBox4.Text = _DDR.DDRReport.TVD
                TextBox5.Text = _DDR.DDRReport.Yesterdays_Depth
                TextBox6.Text = _DDR.DDRReport.Progress
                TextBox7.Text = _DDR.DDRReport.Formation
                TextBox8.Text = _DDR.DDRReport.Mud_weight
                TextBox11.Text = _DDR.DDRReport.Well
                TextBox12.Text = _DDR.DDRReport.Block
                TextBox13.Text = _DDR.DDRReport.Country
                TextBox14.Text = _DDR.DDRReport.KSP_Hrs
                TextBox15.Text = _DDR.DDRReport.Todays_Rot_Hrs
                TextBox16.Text = _DDR.DDRReport.Yest_Rot_Hrs
                TextBox17.Text = _DDR.DDRReport.Cum_Rot_Hrs
                TextBox18.Text = _DDR.DDRReport.Leak_off_test
                TextBox80.Text = _DDR.DDRReport.DaysFromSpud
                TextBox81.Text = _DDR.DDRReport.ProposedTD
                TextBox82.Text = _DDR.DDRReport.RKBToWH
                TextBox83.Text = _DDR.DDRReport.RKBtoSeaBeadMtrs
                TextBox84.Text = _DDR.DDRReport.TOLSize
                TextBox85.Text = _DDR.DDRReport.LastCasing
                TextBox86.Text = _DDR.DDRReport.WeightGR
                TextBox87.Text = _DDR.DDRReport.CasingID
                TextBox88.Text = _DDR.DDRReport.CsgShoeMtrs
                TextBox19.Text = _DDR.DDRReport.TotalsHrs
                TextBox20.Text = _DDR.DDRReport.Tool_Pusher_Comments
                TextBox21.Text = _DDR.DDRReport.Activities_Next24_hrs
                TextBox22.Text = _DDR.DDRReport.BITS_AnnVelCsg
                TextBox23.Text = _DDR.DDRReport.BITS_AnnVel
                TextBox24.Text = _DDR.DDRReport.BITS_DCVel
                TextBox25.Text = _DDR.DDRReport.BITS_NozzleVel()
                TextBox26.Text = _DDR.DDRReport.DrillString_StringWeight
                TextBox27.Text = _DDR.DDRReport.DrillString_StackOffWeigth
                TextBox28.Text = _DDR.DDRReport.DrillString_WOB
                TextBox29.Text = _DDR.DDRReport.DrillString_RPM
                TextBox30.Text = _DDR.DDRReport.DrillString_Torque
                TextBox132.Text = _DDR.DDRReport.DrillString_RotWeigth
                TextBox144.Text = DDRReport.DDRReport.Tool_Pusher_Comments_Spanish
                TextBox145.Text = DDRReport.DDRReport.Activities_Next24_hrs_spanish
                TextBox129.Text = _DDR.DDRReport.BHA_BottomHoleAssembly
                TextBox31.Text = _DDR.DDRReport.BHA_BelowJars
                TextBox32.Text = _DDR.DDRReport.BHA_BAGWT
                TextBox33.Text = _DDR.DDRReport.BHA_Comments
                TextBox89.Text = _DDR.DDRReport.Mud_VolumeActivePits
                TextBox90.Text = _DDR.DDRReport.Mud_HoleVolume
                TextBox91.Text = _DDR.DDRReport.Mud_System
                TextBox92.Text = _DDR.DDRReport.Mud_Percent
                TextBox93.Text = _DDR.DDRReport.Mud_MaxGas
                TextBox94.Text = _DDR.DDRReport.Mud_Comments
                TextBox34.Text = _DDR.DDRReport.Wind_Dir
                TextBox35.Text = _DDR.DDRReport.Wind_Speed
                TextBox36.Text = _DDR.DDRReport.Current_Dir
                TextBox37.Text = _DDR.DDRReport.Current_Speed
                TextBox38.Text = _DDR.DDRReport.Temp_Air
                TextBox39.Text = _DDR.DDRReport.Temp_Sea
                TextBox40.Text = _DDR.DDRReport.Barometer
                TextBox41.Text = _DDR.DDRReport.Sea
                TextBox42.Text = _DDR.DDRReport.Swell
                TextBox43.Text = _DDR.DDRReport.Roll
                TextBox44.Text = _DDR.DDRReport.Pitch
                TextBox45.Text = _DDR.DDRReport.Heave
                TextBox46.Text = _DDR.DDRReport.Visibilty
                TextBox50.Text = _DDR.DDRReport.PemexUnit
                TextBox51.Text = _DDR.DDRReport.Washpipehrs
                TextBox130.Text = _DDR.DDRReport.EstendWell
                TextBox133.Text = _DDR.DDRReport.DrillLineSlippedandCut
                TextBox138.Text = _DDR.DDRReport.DrillString_PUWeight
                TextBox149.Text = _DDR.DDRReport.PumpsMeasureddepth
                TextBox150.Text = _DDR.DDRReport.PumpsTrueverticaldepth
                TextBox151.Text = _DDR.DDRReport.PumpsMudweigth
                txtECD12.Text = _DDR.DDRReport.DrillString_ECD12
                txtECD24.Text = _DDR.DDRReport.DrillString_ECD24

                'Modificado 22-Sep-2017
                'Se agrego los campos de F1SupervisorName  y F1RigSuperintName 
                ' Se agregaron los controles de text para estas variables
                txt_f1supername.Text = _DDR.DDRReport.F1SupervisorName
                txt_f1superintname.Text = _DDR.DDRReport.F1RigSuperintName

                If Not IsNothing(_DDR.DDRReport.MarineInfo) Then

                    TextBox141.Text = _DDR.DDRReport.MarineInfo.Marine_ID
                    TextBox47.Text = _DDR.DDRReport.MarineInfo.AirGap
                    TextBox48.Text = _DDR.DDRReport.MarineInfo.UsedPlayload
                    TextBox49.Text = _DDR.DDRReport.MarineInfo.RemainingPayload
                    If Not _DDR.DDRReport.MarineInfo.LastboatDrill.ToString("MM/dd/yyyy").Equals("01/01/0001") Then
                        Try
                            DateTimePicker1.Value = _DDR.DDRReport.MarineInfo.LastboatDrill.ToString("MM/dd/yyyy")
                        Catch ex As Exception
                            MsgBox("Error trying to get the Last boar drill date from the database")
                        End Try

                    End If
                    If Not _DDR.DDRReport.MarineInfo.FireDrill.ToString("MM/dd/yyyy").Equals("01/01/0001") Then
                        Try
                            DateTimePicker2.Value = _DDR.DDRReport.MarineInfo.FireDrill.ToString("MM/dd/yyyy")
                        Catch ex As Exception
                            MsgBox("Error trying to get the Fire drill date from the database")
                        End Try

                    End If

                    If Not IsNothing(_DDR.DDRReport.MarineInfo.BOPTest) Then
                        Try
                            DateTimePicker3.Value = Date.Parse(_DDR.DDRReport.MarineInfo.BOPTest)
                        Catch ex As Exception
                            MsgBox("Error trying to get the BOP Test date from the database")
                        End Try

                    End If

                    If Not IsNothing(_DDR.DDRReport.MarineInfo.COMTest) Then
                        Try
                            DateTimePicker4.Value = Date.Parse(_DDR.DDRReport.MarineInfo.COMTest)
                        Catch ex As Exception
                            MsgBox("Error trying to get COM Test date from the database")
                        End Try

                    End If


                    If Not IsNothing(_DDR.DDRReport.DDRDate) Then
                        Try
                            DateTimePicker6.Value = Date.Parse(_DDR.DDRReport.DDRDate)
                        Catch ex As Exception
                            MsgBox("Error trying to get COM Test date from the database")
                        End Try

                    End If
                    TextBox53.Text = _DDR.DDRReport.MarineInfo.YestStock_PotWater
                    TextBox110.Text = _DDR.DDRReport.MarineInfo.YestStock_Diesel
                    TextBox109.Text = _DDR.DDRReport.MarineInfo.YestStock_DrillWater
                    TextBox108.Text = _DDR.DDRReport.MarineInfo.YestStock_LubOil
                    TextBox57.Text = _DDR.DDRReport.MarineInfo.YestStock_Barite
                    TextBox61.Text = _DDR.DDRReport.MarineInfo.YestStock_Bentonite
                    TextBox65.Text = _DDR.DDRReport.MarineInfo.YestStock_Gel
                    TextBox69.Text = _DDR.DDRReport.MarineInfo.YestStock_CementG
                    TextBox73.Text = _DDR.DDRReport.MarineInfo.YestStock_CmtBlended
                    TextBox54.Text = _DDR.DDRReport.MarineInfo.TodayStock_PotWater
                    TextBox107.Text = _DDR.DDRReport.MarineInfo.TodayStock_Diesel
                    TextBox106.Text = _DDR.DDRReport.MarineInfo.TodayStock_DrillWater
                    TextBox105.Text = _DDR.DDRReport.MarineInfo.TodayStock_LubOil
                    TextBox58.Text = _DDR.DDRReport.MarineInfo.TodayStock_Barite
                    TextBox62.Text = _DDR.DDRReport.MarineInfo.TodayStock_Bentonite
                    TextBox66.Text = _DDR.DDRReport.MarineInfo.TodayStock_Gel
                    TextBox70.Text = _DDR.DDRReport.MarineInfo.TodayStock_CementG
                    TextBox74.Text = _DDR.DDRReport.MarineInfo.TodayStock_CMTBlended
                    TextBox55.Text = _DDR.DDRReport.MarineInfo.Used_PotWater
                    TextBox113.Text = _DDR.DDRReport.MarineInfo.Used_Diesel
                    TextBox112.Text = _DDR.DDRReport.MarineInfo.Used_DrillWater
                    TextBox111.Text = _DDR.DDRReport.MarineInfo.Used_LubOil
                    TextBox59.Text = _DDR.DDRReport.MarineInfo.Used_Barite
                    TextBox63.Text = _DDR.DDRReport.MarineInfo.Used_Bentoniote
                    TextBox67.Text = _DDR.DDRReport.MarineInfo.Used_Gel
                    TextBox71.Text = _DDR.DDRReport.MarineInfo.Used_CementG
                    TextBox75.Text = _DDR.DDRReport.MarineInfo.Used_CmtBlended
                    TextBox56.Text = _DDR.DDRReport.MarineInfo.RecivedMade_PotWater
                    TextBox116.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Diesel
                    TextBox115.Text = _DDR.DDRReport.MarineInfo.RecivedMade_DrillWater
                    TextBox114.Text = _DDR.DDRReport.MarineInfo.RecivedMade_LubOil
                    TextBox60.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Barite
                    TextBox64.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Bentoniote
                    TextBox68.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Gel
                    TextBox72.Text = _DDR.DDRReport.MarineInfo.RecivedMade_CementG
                    TextBox76.Text = _DDR.DDRReport.MarineInfo.RecivedMade_CmtBlended
                    TextBox77.Text = _DDR.DDRReport.MarineInfo.Helifuel
                    TextBox78.Text = _DDR.DDRReport.MarineInfo.Brine
                    TextBox79.Text = _DDR.DDRReport.MarineInfo.Base_oil
                    TextBox117.Text = _DDR.DDRReport.MarineInfo.LubOil
                    TextBox118.Text = _DDR.DDRReport.MarineInfo.Nitrogen_FullBottles
                    TextBox121.Text = _DDR.DDRReport.MarineInfo.Nitrogen_InUse
                    TextBox124.Text = _DDR.DDRReport.MarineInfo.Nitrogen_Empty
                    TextBox119.Text = _DDR.DDRReport.MarineInfo.Oxygen_FullBottles
                    TextBox122.Text = _DDR.DDRReport.MarineInfo.Oxygen_InUse
                    TextBox125.Text = _DDR.DDRReport.MarineInfo.Oxygen_Empty
                    TextBox120.Text = _DDR.DDRReport.MarineInfo.Acetyl_FullBottles
                    TextBox123.Text = _DDR.DDRReport.MarineInfo.Acetyl_InUse
                    TextBox126.Text = _DDR.DDRReport.MarineInfo.Acetyl_Empty
                    TextBox100.Text = _DDR.DDRReport.UsedByPEP
                    TextBox131.Text = _DDR.DDRReport.MarineInfo.Comments
                    TextBox52.Text = _DDR.DDRReport.MarineInfo.ToneMilesSinceLastCut
                    TextBox139.Text = _DDR.DDRReport.MarineInfo.GeneratorsOnline
                    TextBox140.Text = _DDR.DDRReport.MarineInfo.Thrustersonline
                    TextBox146.Text = _DDR.DDRReport.MarineInfo.Comments_spanish
                    txtRigwash.Text = _DDR.DDRReport.MarineInfo.RigWash


                End If
                'Load POB
                If Not IsNothing(_DDR.DDRReport.POB) Then
                    TextBox95.Text = _DDR.DDRReport.POB.GRCrew
                    TextBox96.Text = _DDR.DDRReport.POB.GRServ
                    TextBox97.Text = _DDR.DDRReport.POB.Catering
                    TextBox98.Text = _DDR.DDRReport.POB.Pemex
                    TextBox99.Text = _DDR.DDRReport.POB.OpSer
                    'TextBox100.Text = _DDR.DDRReport.POB.Total
                    TextBox101.Text = _DDR.DDRReport.POB.DailyCost
                    TextBox102.Text = _DDR.DDRReport.POB.AccCost
                    TextBox103.Text = _DDR.DDRReport.POB.AverageCost
                    TextBox104.Text = _DDR.DDRReport.POB.DaysFromLAstLTA
                    TextBox142.Text = _DDR.DDRReport.POB.POB_ID
                End If

                Dim row As String()
                'Load DDR Hrs
                If Not IsNothing(_DDR.DDRReport.DDRHrs) Then
                    For Each item As com.entities.DDRHrs In _DDR.DDRReport.DDRHrs.Items
                        row = New String() {item.Fromv, item.Tov, item.Total, item.Code, item.Comment, item.CommentSpanish, item.Detail_HR_ID}
                        dgv_DDRHrs.Rows.Add(row)

                    Next
                    dgv_DDRHrs.Sort(dgv_DDRHrs.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
                    dgv_DDRHrs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
                    dgv_DDRHrs.Columns(4).Width = 500
                End If

                'Load BITS
                If Not IsNothing(_DDR.DDRReport.BITS) Then
                    For Each item As com.entities.BITS In _DDR.DDRReport.BITS.Items
                        row = New String() {item.bit_No, item.bit_Size, item.bit_Make, item.bit_Serial, item.Bit_type, item.bit_Jets, item.bit_TFA, item.bit_Out, item.bit_In, item.bit_Mtrs, item.bit_Hrs, item.bit_Comments, item.BITS_ID}
                        dgv_BITS.Rows.Add(row)
                    Next

                End If

                'Load Drill String
                If Not IsNothing(_DDR.DDRReport.DrillString) Then
                    If _DDR.DDRReport.DrillString.Count > 0 Then
                        For Each item As com.entities.DrillString In _DDR.DDRReport.DrillString.Items
                            row = New String() {item.Description, item.SizeDR, item.Weight, item.Grade, item.ToolJoint, item.ToolJntOD, item.TotalOnBoard, item.BHAinHole, item.DrillString_ID}
                            dgv_String.Rows.Add(row)
                        Next
                        If _DDR.DDRReport.DrillString.Count = 6 Then
                            row = New String() {"Drill Collar", "", "", "", "", "", "", ""}
                            dgv_String.Rows.Add(row)
                        End If
                    Else
                        row = New String() {"", "", "", "", "", "", "", ""}
                        dgv_String.Rows.Add(row)
                    End If
                End If
                'Load Drill String survey
                If Not IsNothing(_DDR.DDRReport.DrillString_Survey) Then
                    For Each item As com.entities.DrillString_Survey In _DDR.DDRReport.DrillString_Survey.Items
                        row = New String() {item.DirectionalSurveys, item.MID, item.TVD, item.INC, item.AZM, item.Comments, item.Survey_ID}
                        dgv_String_Survey.Rows.Add(row)
                    Next

                End If

                'Load pumps
                If Not IsNothing(_DDR.DDRReport.Pumps) Then
                    For Each item As com.entities.Pumps In _DDR.DDRReport.Pumps.Items
                        row = New String() {item.PumpNo, item.MakeandModel, item.Stroke, item.Liners, item.SPM, item.GPM, item.EFF, item.Press, item.MP, item.CLF, item.CLFCK, item.s30StrokesChoke, item.s30StrokesCK, item.s40StrokesChoke, item.s40StrokesCK, item.s50StrokesChoke, item.s50StrokesCK, item.PUMPS_ID}
                        dgv_pumps.Rows.Add(row)
                    Next
                End If

                'Load Shakers
                If Not IsNothing(_DDR.DDRReport.Shakers) Then
                    For Each item As com.entities.Shakers In _DDR.DDRReport.Shakers.Items
                        row = New String() {item.ShakerNo, item.MakeAndModel, item.ScreenSize, item.Top1, item.Top2, item.Top3, item.Top4, item.Bottom1, item.Bottom2, item.Bottom3, item.Bottom4, item.Shakers_ID}
                        dgv_Shakers.Rows.Add(row)
                    Next
                End If

                'Load MUD
                If Not IsNothing(_DDR.DDRReport.Mud) Then
                    For Each item As com.entities.Mud In _DDR.DDRReport.Mud.Items
                        row = New String() {item.TimeMud, item.WT, item.VIS, item.WL, item.Cake, item.PH, item.Sand, item.Solids, item.PvYP, item.KCL, item.Pm, item.Comments, item.MUD_ID}
                        dgv_Mud.Rows.Add(row)
                    Next
                End If

                'Load Activities
                If Not IsNothing(_DDR.DDRReport.Activities) Then
                    LoadAcitivyOnChangeBox(ComboBox1.Text)
                End If

                'Load Riser profile
                If Not IsNothing(_DDR.DDRReport.RiserProfile) Then
                    For Each item As com.entities.RiserProfile In _DDR.DDRReport.RiserProfile.Items
                        row = New String() {item.IDBeacon, item.Depth, item.Temp6hrs, item.Temp12hrs, item.Temp18hrs, item.Temp24hrs, item.Current6hrs, item.Current12hrs, item.Current18hrs, item.Current24hrs, item.Direction6hrs, item.Direction12hrs, item.Direction18hrs, item.Direction24hrs, item.IDRiserProfile}
                        dgv_RiserProfile.Rows.Add(row)
                    Next
                End If

                'Load SOC
                If Not IsNothing(_DDR.DDRReport.SOC) Then
                    TextBox134.Text = _DDR.DDRReport.SOC.SOCToday
                    TextBox135.Text = _DDR.DDRReport.SOC.SOCMonth
                    TextBox136.Text = _DDR.DDRReport.SOC.SOCSTOPTour
                    TextBox137.Text = _DDR.DDRReport.SOC.DaysWithoutLTA
                    TextBox143.Text = _DDR.DDRReport.SOC.SOCINFOID
                End If

                'Load Logistic Transit Log
                If Not IsNothing(_DDR.DDRReport.LogisticTransitLog) Then
                    For Each item As com.entities.LogisticTransitLog In _DDR.DDRReport.LogisticTransitLog.items
                        'Dim row As String()
                        Select Case item.Type
                            Case "Boat"
                                row = New String() {item.Log, item.LogEsp, item.LTID, item.ToF1}
                                dgv_LogTranLogBoat.Rows.Add(row)
                            Case "Helicopter"
                                row = New String() {item.Log, item.LogEsp, item.LTID, item.ToF1}
                                dgv_LogTranLogHeli.Rows.Add(row)
                        End Select
                    Next
                End If

                If Not IsNothing(_DDR.DDRReport.UrgentsMR) Then
                    'For Each item As com.entities.UrgentMRs In _DDR.DDRReport.UrgentsMR.items
                    '    row = New String() {item.MRNumber, item.dateIssued, item.MRDescription, item.Status, item.MRUrgentID}
                    '    dgv_UrgentsMRs.Rows.Add(row)
                    'Next
                    LoadAcitivyOnChangeBox(ComboBox1.Text)
                End If


                'Load PEMEX Urgent MRs
                If Not IsNothing(_DDR.DDRReport.PUMR) Then
                    For Each item As com.entities.PUMR In _DDR.DDRReport.PUMR.Items
                        row = New String() {item.MRNumber, item.DateIssued, item.MRDesc, item.Status, item.PRUM_ID}
                        dgv_PUMR.Rows.Add(row)
                    Next
                End If

            End If

        End If
    End Sub
    Private Sub FillForm(ByVal TabException As String)
        If Not IsNothing(_DDR) Then
            'Load DDR Data
            If Not IsNothing(_DDR.DDRReport) Then
                Select Case TabException
                    Case "tp_DDR_Header"
                        'UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()

                    Case "tp_DDRHrs"
                        UpdateTabDDR()
                        'UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()

                    Case "tp_BITS"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        'UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tp_DrillString"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        'UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tp_BHA"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        'UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tp_Pumps"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        'UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tpShakers"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        'UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tp_Mud"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        'UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tp_MarineInfo"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        'UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tpPOB"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        'UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tpEngInfo"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        'UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tb_DeparmentAct"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        'LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tb_RiserProfile"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        'UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tb_SOC"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        'UpdateTabSoc()
                        UpdateTabLog()
                        UpdateTabPUMR()
                    Case "tb_LogisticTransitLog"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        'UpdateTabLog()
                        UpdateTabPUMR()

                    Case "tb_PUMR"
                        UpdateTabDDR()
                        UpdateTabDDRHrs()
                        UpdateTabBITS()
                        UpdateTabDrillString()
                        UpdatedTabBHA()
                        UpdateTabPumps()
                        UpdateTabShakers()
                        UpdateTabMud()
                        UpdateTabMarine()
                        UpdateTabPOB()
                        UpdateTabEngInfo()
                        LoadAcitivyOnChangeBox(ComboBox1.Text)
                        UpdateTabRiserPro()
                        UpdateTabSoc()
                        UpdateTabLog()
                        'UpdateTabPUMR()
                End Select

                'If Not IsNothing(_DDR.DDRReport.MarineInfo) Then
                'End If
                ''Load POB
                'If Not IsNothing(_DDR.DDRReport.POB) Then

                'End If

                ''Load DDR Hrs
                'If Not IsNothing(_DDR.DDRReport.DDRHrs) Then

                'End If

                ''Load BITS
                'If Not IsNothing(_DDR.DDRReport.BITS) Then

                'End If

                ''Load Drill String
                'If Not IsNothing(_DDR.DDRReport.DrillString) Then
                'End If
                ''Load Drill String survey
                'If Not IsNothing(_DDR.DDRReport.DrillString_Survey) Then
                'End If

                ''Load pumps
                'If Not IsNothing(_DDR.DDRReport.Pumps) Then
                'End If

                ''Load Shakers
                'If Not IsNothing(_DDR.DDRReport.Shakers) Then
                'End If

                ''Load MUD
                'If Not IsNothing(_DDR.DDRReport.Mud) Then
                'End If

                ''Load Activities
                'If Not IsNothing(_DDR.DDRReport.Activities) Then
                '    LoadAcitivyOnChangeBox(ComboBox1.Text)
                'End If

                ''Load Riser profile
                'If Not IsNothing(_DDR.DDRReport.RiserProfile) Then
                'End If

                ''Load SOC
                'If Not IsNothing(_DDR.DDRReport.SOC) Then
                'End If

                ''Load Logistic Transit Log
                'If Not IsNothing(_DDR.DDRReport.LogisticTransitLog) Then
                'End If

                'If Not IsNothing(_DDR.DDRReport.UrgentsMR) Then
                '    LoadAcitivyOnChangeBox(ComboBox1.Text)
                'End If

            End If

        End If
    End Sub
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ado As New com.ADO.ADOMySQLDDR
        If Not IsNothing(_DDR) Then
            ado.LockReprot(_DDR.DDRID)
            LockForm()
            Button1.Enabled = False
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Dim ado As New com.ADO.ADOMySQLDDR
        If Not IsNothing(_DDR) Then
            ado.UnlockReprot(_DDR.DDRID)
            UnlockForm()
            Button1.Enabled = True
        End If
    End Sub

    Private Sub DDR_From_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        CheckPrivilegies()

    End Sub
#Region "Functions disabled"



    'Public Sub SaveActivityOnMemory()
    '    Dim ado As New com.ADO.ADODDR
    '    Dim deparmentid As Integer
    '    deparmentid = ado.GetDeparmentID(ComboBox1.Text)
    '    If FormMode = FormModes.Insert Then
    '        If Not IsNothing(DDRReport.DDRReport.Activities) Then
    '            For Each row As DataGridViewRow In dgv_activities.Rows
    '                If Not IsNothing(row.Cells(0).Value) Then
    '                    Dim activitie As New com.entities.Activities
    '                    activitie.DDR_Report_ID = _DDR.DDRID
    '                    activitie.Deparment_ID = deparmentid
    '                    activitie.Deparment = ComboBox1.Text
    '                    activitie.Activity = row.Cells(0).Value
    '                    activitie.ActivitySpanish = row.Cells(1).Value
    '                    DDRReport.DDRReport.Activities.Add(activitie)
    '                End If

    '            Next
    '        Else
    '            Dim activitiescollected As New com.entities.Activities_Collection
    '            For Each row As DataGridViewRow In dgv_activities.Rows
    '                If Not IsNothing(row.Cells(0).Value) Then
    '                    Dim activitie As New com.entities.Activities
    '                    activitie.DDR_Report_ID = _DDR.DDRID
    '                    activitie.Deparment_ID = deparmentid
    '                    activitie.Deparment = ComboBox1.Text
    '                    activitie.Activity = row.Cells(0).Value
    '                    activitie.ActivitySpanish = row.Cells(1).Value
    '                    activitiescollected.Add(activitie)
    '                End If
    '            Next
    '            _DDR.DDRReport.Activities = activitiescollected
    '        End If
    '    End If
    '    If FormMode = FormModes.Edit Then
    '        Dim newactivities As New com.entities.Activities_Collection
    '        If Not IsNothing(_DDR.DDRReport.Activities) Then
    '            For Each item As com.entities.Activities In _DDR.DDRReport.Activities.Items
    '                If item.Deparment_ID <> deparmentid Then
    '                    newactivities.Add(item)
    '                End If
    '            Next
    '        End If

    '        For Each row As DataGridViewRow In dgv_activities.Rows
    '            If Not IsNothing(row.Cells(0).Value) Then
    '                Dim activitie As New com.entities.Activities
    '                activitie.DDR_Report_ID = _DDR.DDRID
    '                activitie.Deparment_ID = deparmentid
    '                activitie.Deparment = ComboBox1.Text
    '                activitie.Activity = row.Cells(0).Value
    '                activitie.ActivitySpanish = row.Cells(1).Value
    '                newactivities.Add(activitie)
    '            End If
    '        Next
    '        _DDR.DDRReport.Activities = newactivities
    '    End If
    'End Sub

    'Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
    '    Select Case FormMode
    '        Case FormModes.Insert
    '            Dim ado As New com.ADO.ADODDR
    '            'SaveActivityOnMemory()
    '            'ado.SaveActivities(_DDR)
    '            'Case FormModes.Edit
    '            'Dim ado As New com.ADO.ADODDR
    '            'SaveActivityOnMemory()
    '            'ado.ModifyActivities(_DDR)
    '    End Select

    'End Sub
#End Region
    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Try
            LoadAcitivyOnChangeBox(ComboBox1.Text)
        Catch ex As Exception

        End Try

    End Sub

    Private Sub ComboBox1_SelectionChangeCommitted(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectionChangeCommitted
        'SaveActivityOnMemory()
    End Sub

    Public Sub LoadAcitivyOnChangeBox(ByVal deparmentName As String)
        'for activities
        dgv_activities.Rows.Clear()
        Dim row As String()
        If Not IsNothing(_DDR.DDRReport.Activities) Then
            For Each activity As com.entities.Activities In _DDR.DDRReport.Activities.Items
                If activity.Deparment.Equals(deparmentName) Then
                    row = New String() {activity.Activity, activity.ActivitySpanish, activity.Act_Detail_ID}
                    dgv_activities.Rows.Add(row)
                End If
            Next
        End If

        ' for urgent mrs
        dgv_UrgentsMRs.Rows.Clear()
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        deparmentid = ado.GetDeparmentID(deparmentName)
        If Not IsNothing(DDRReport.DDRReport.UrgentsMR) Then
            For Each item As com.entities.UrgentMRs In _DDR.DDRReport.UrgentsMR.items
                If item.Deparment_ID.Equals(deparmentid) Then
                    If _FormMode = FormModes.Insert Then
                        row = New String() {item.MRNumber, item.dateIssued, item.MRDescription, item.Status, -1}
                    End If
                    If _FormMode = FormModes.Edit Or _FormMode = FormMode.View Then
                        row = New String() {item.MRNumber, item.dateIssued, item.MRDescription, item.Status, item.MRUrgentID}
                    End If


                    Try
                        dgv_UrgentsMRs.Rows.Add(row)
                    Catch ex As Exception

                    End Try

                End If
            Next
        End If

        'For Work Orders
        dgv_WorkOrders.Rows.Clear()
        If Not IsNothing(DDRReport.DDRReport.WorkOrders) Then
            For Each item As com.entities.WorkOrder In _DDR.DDRReport.WorkOrders.items
                If item.Deparment_ID.Equals(deparmentid) Then
                    'Agregado el dia 5 de Agosto 2017
                    ' Funcionalidad para el F1
                    Dim chk As Boolean = False
                    If item.WOToF1 Then
                        chk = True
                    End If

                    Dim chk_p As Boolean = False
                    If item.WOPreventive Then
                        chk_p = True
                    End If

                    Dim chk_c As Boolean = False
                    If item.WOCorrective Then
                        chk_c = True
                    End If

                    row = New String() {chk_p, chk_c, item.WONumber, item.WODescription, item.WODescriptionSpanish, item.WorkOrderID, chk}
                    dgv_WorkOrders.Rows.Add(row)
                End If
            Next
        End If

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim emailstonotify As New com.Notifier.Email.EmailObjCollection
        Dim templatemessage As New com.Notifier.Email.EmailObj
        Dim emailsender As New com.Notifier.Email.EmailSender
        Dim ado As New com.ADO.ADOMySQLDDR
        templatemessage.Body = "the user: " & _SessionUser.User & " is notifying that the activy report is completed, please check the DDR System for more detail"
        templatemessage.Subject = "user " & _SessionUser.User & " has finished the activity report"
        ado.PrepareNotification(emailstonotify, templatemessage, _SessionUser.email)
        Dim sendnotification As Boolean
        sendnotification = Configuration.ConfigurationSettings.AppSettings("SendNotification")
        
        If sendnotification Then
            Try
                emailsender.SendEmails(emailstonotify)
                MsgBox("Notification sent.")
            Catch ex As Exception
                MsgBox("error to send the notification : " & ex.Message.ToString)
            End Try
        End If
    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Dim excelformat As New com.file.ExcelExport(Configuration.ConfigurationSettings.AppSettings("ExcelFormatTemplate"))
        Dim activitiesformat As New com.file.ExcelExport(Configuration.ConfigurationSettings.AppSettings("ActivitiesExcelFormatTemplate"))
        'Agregado 7-Ago-2017
        'Agragar funcionalidad de reporte de F1
        Dim f1format As New com.file.ExcelExport(Configuration.ConfigurationSettings.AppSettings("F1Template"))

        Try

            'Activities excel format
            activitiesformat.OpenDocument()
            activitiesformat.FillActivities(_DDR, 1)


            'ddr template 
            excelformat.OpenDocument()
            'Spanish DDR
            excelformat.FillDDRonExcelV2(_DDR, 1, "ENG")
            'English DDR
            excelformat.FillDDRonExcelV2(_DDR, 2, "ESP")

            'Agregado 7-Ago-2017
            'Agragar funcionalidad de reporte de F1
            'Llena Formato F1
            f1format.OpenDocument()
            f1format.FillF1(_DDR, 1, "ENG")
            f1format.FillF1(_DDR, 2, "ESP")


            MsgBox("Report exported successfully")

        Catch ex As Exception
            MsgBox("Error to open the excel file, Error:" & ex.Message.ToString)
        End Try


    End Sub

    Private Sub CopyOnMem(ByVal value As String)
        _Clipboard = value
    End Sub

    Private Function PasetValue()
        Return _Clipboard
    End Function

    Private Sub dgv_DDRHrs_CellBeginEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs)

    End Sub

    Private Sub dgv_DDRHrs_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_DDRHrs.CellEndEdit
        If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
            Dim str_value As String = dgv_DDRHrs.Rows(e.RowIndex).Cells(e.ColumnIndex).Value
            ' valida que la captura sea correcta
            If Not isValidatedHrsFormatDDRHrs(str_value) Then
                MsgBox("The value that you enter is incorrect, you must enter the following format 18:00 ")
            Else
                'obtenemos los datos de las celdas
                Try
                    Dim str_hr1 As String
                    Dim str_hr2 As String
                    If e.ColumnIndex = 0 Then
                        str_hr1 = Date.Today & " " & dgv_DDRHrs.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                    Else
                        str_hr1 = Date.Today & " " & dgv_DDRHrs.Rows(e.RowIndex).Cells(e.ColumnIndex - 1).Value.ToString()
                    End If
                    If e.ColumnIndex = 0 Then
                        str_hr2 = Date.Today & " " & dgv_DDRHrs.Rows(e.RowIndex).Cells(e.ColumnIndex + 1).Value.ToString()
                    Else
                        str_hr2 = Date.Today & " " & dgv_DDRHrs.Rows(e.RowIndex).Cells(e.ColumnIndex).Value.ToString()
                    End If

                    Dim dt1 As Date = Date.Parse(str_hr1)
                    Dim dt2 As Date = Date.Parse(str_hr2)
                    Dim diference As Integer = DateDiff(DateInterval.Minute, dt1, dt2)
                    dgv_DDRHrs.Rows(e.RowIndex).Cells(2).Value = Format(diference / 60, "0.0")
                    CalculateTotalHRSDDR()
                    'Dim hrs1 As Date = 
                Catch ex As Exception
                    'MsgBox(ex.Message)

                End Try

            End If
        End If
        'Save data
        If _FormMode = FormModes.Edit Then

            Try
                'aver el objeto a modificar
                ' modificar el objeto en el model
                ' modificar el objeto en la base de datos
                If Not isValidatedHrsFormatDDRHrs(dgv_DDRHrs.Rows(e.RowIndex).Cells(0).Value) Then

                    Throw New Exception("Error on the DDR hrs, the format is wrong entered")
                End If

                If Not isValidatedHrsFormatDDRHrs(dgv_DDRHrs.Rows(e.RowIndex).Cells(1).Value) Then
                    Throw New Exception("Error on the DDR hrs, the format is wrong entered")

                End If

                If Not TextBox19.Text.Equals("") Then
                    If TextBox19.Text > 24 Then
                        Throw New Exception("The total of hrs is greater than 24hrs")
                    End If
                End If

                Dim ado As New com.ADO.ADOMySQLDDR

                If dgv_DDRHrs.Rows(e.RowIndex).Cells(0).Value <> "" Or dgv_DDRHrs.Rows(e.RowIndex).Cells(4).Value <> "" Then
                    If IsNothing(dgv_DDRHrs.Rows(e.RowIndex).Cells(6).Value) Or dgv_DDRHrs.Rows(e.RowIndex).Cells(6).Value = "-1" Then
                        Dim ddrhrs_tosavea As New com.entities.DDRHrs
                        ddrhrs_tosavea.Fromv = dgv_DDRHrs.Rows(e.RowIndex).Cells(0).Value
                        ddrhrs_tosavea.Tov = dgv_DDRHrs.Rows(e.RowIndex).Cells(1).Value
                        ddrhrs_tosavea.Total = dgv_DDRHrs.Rows(e.RowIndex).Cells(2).Value
                        ddrhrs_tosavea.Code = dgv_DDRHrs.Rows(e.RowIndex).Cells(3).Value
                        ddrhrs_tosavea.Comment = dgv_DDRHrs.Rows(e.RowIndex).Cells(4).Value
                        ddrhrs_tosavea.CommentSpanish = dgv_DDRHrs.Rows(e.RowIndex).Cells(5).Value
                        ddrhrs_tosavea.Detail_HR_ID = -1
                        ddrhrs_tosavea.DDR_Report_ID = DDRReport.DDRID
                        DDRReport.DDRReport.DDRHrs.Add(ddrhrs_tosavea, True)
                        dgv_DDRHrs.Rows(e.RowIndex).Cells(6).Value = ddrhrs_tosavea.Detail_HR_ID
                    Else
                        Dim ddrhrs_tosavea As New com.entities.DDRHrs
                        ddrhrs_tosavea.Fromv = dgv_DDRHrs.Rows(e.RowIndex).Cells(0).Value
                        ddrhrs_tosavea.Tov = dgv_DDRHrs.Rows(e.RowIndex).Cells(1).Value
                        ddrhrs_tosavea.Total = dgv_DDRHrs.Rows(e.RowIndex).Cells(2).Value
                        ddrhrs_tosavea.Code = dgv_DDRHrs.Rows(e.RowIndex).Cells(3).Value

                        ddrhrs_tosavea.Comment = dgv_DDRHrs.Rows(e.RowIndex).Cells(4).Value
                        If IsNothing(ddrhrs_tosavea.Comment) Then
                            ddrhrs_tosavea.Comment = ""
                        End If
                        ddrhrs_tosavea.CommentSpanish = dgv_DDRHrs.Rows(e.RowIndex).Cells(5).Value
                        If IsNothing(ddrhrs_tosavea.CommentSpanish) Then
                            ddrhrs_tosavea.CommentSpanish = ""
                        End If

                        ddrhrs_tosavea.Detail_HR_ID = dgv_DDRHrs.Rows(e.RowIndex).Cells(6).Value
                        ddrhrs_tosavea.DDR_Report_ID = _DDR.DDRID

                        DDRReport.DDRReport.DDRHrs.ModifyDDRHrs(ddrhrs_tosavea)
                    End If
                End If
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try

        End If

    End Sub

    Private Function isValidatedHrsFormatDDRHrs(ByVal str_value As String) As Boolean
        Dim result As Boolean = True
        'Valida que contenga el signo de :
        If Not IsNothing(str_value) Then
            If str_value.Contains(":") Then
                'valida que los datos sean nuemros
                Dim splitvalue() As String
                splitvalue = str_value.Split(":")
                If IsNumeric(splitvalue(0)) And IsNumeric(splitvalue(1)) Then
                    'valida si el primer digito esta dentro de los numeros estan dentro 0 a 23
                    If splitvalue(0) <= 23 And splitvalue(1) <= 59 Then
                        result = True
                    Else
                        result = False
                    End If
                Else
                    result = False
                    'dgv_DDRHrs.CurrentCell = dgv_DDRHrs.Rows(e.RowIndex).Cells(e.ColumnIndex)
                    'dgv_DDRHrs.BeginEdit(True)

                End If

            Else
                result = False
            End If
        End If

        Return result
    End Function

    Private Sub CalculateTotalHRSDDR()
        Dim result As Decimal
        For Each row As DataGridViewRow In dgv_DDRHrs.Rows
            result = result + row.Cells("Total").Value
        Next

        TextBox19.Text = result
        If result >= 24.01 Then
            TextBox19.BackColor = Color.Red
        Else
            TextBox19.BackColor = Color.LightBlue
        End If

    End Sub

    Public Sub CopyData(ByVal dgv As DataGridView)
        Dim d As DataObject = dgv.GetClipboardContent()
        Clipboard.SetDataObject(d)
    End Sub

    Public Sub PasteData(ByVal dgv As DataGridView)
        Dim cell As DataGridViewCell = dgv.Rows(dgv.CurrentCell.RowIndex).Cells(dgv.CurrentCell.ColumnIndex)
        Dim s As String = Clipboard.GetText()
        cell.Value = s
    End Sub

    Private Sub dgv_DDRHrs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_DDRHrs.KeyDown, dgv_String.KeyDown, dgv_BITS.KeyDown, dgv_String_Survey.KeyDown, dgv_Shakers.KeyDown, dgv_pumps.KeyDown, dgv_Mud.KeyDown
        If (e.KeyCode = Keys.Up) Or (e.KeyCode = Keys.Down) Or (e.KeyCode = Keys.Left) Or (e.KeyCode = Keys.Right) Then
        Else
            If (e.Control) Then
                e.Handled = True
            End If
        End If

    End Sub

    Private Sub dgv_DDRHrs_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_DDRHrs.KeyUp, dgv_String.KeyUp, dgv_BITS.KeyUp, dgv_String_Survey.KeyUp, dgv_Shakers.KeyUp, dgv_pumps.KeyUp, dgv_Mud.KeyUp
        If e.Control And e.KeyCode = 67 Then
            CopyData(sender)
            'MsgBox(Clipboard.GetText)
        End If
        If e.Control And e.KeyCode = 86 Then
            PasteData(sender)
        End If
    End Sub

    Private Sub DDR_From_SizeChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        'Dim actual_width As Integer
        'Dim actual_heigt As Integer

        'actual_heigt = Me.Size.Height
        'actual_width = Me.Size.Width

        'If Me.Size.Width > 805 Then
        '    TabControl1.Width = Me.Size.Width - 40

        'Else
        '    TabControl1.Width = 766
        'End If

        If Me.Size.Height > 504 Or Me.Size.Width >= 805 Then
            Button2.Location = New Point(14, Me.Size.Height - (Button2.Size.Height + 43))
            Button7.Location = New Point(148, Me.Size.Height - (Button2.Size.Height + 43))
            Button4.Location = New Point(280, Me.Size.Height - (Button2.Size.Height + 43))
            Button3.Location = New Point(424, Me.Size.Height - (Button2.Size.Height + 43))
            Button1.Location = New Point(Me.Size.Width - (Button1.Width + 27), Me.Size.Height - (Button1.Size.Height + 43))
            TabControl1.Size = New Size(Me.Size.Width - 40, Me.Size.Height - (Button1.Size.Height + 79))

            dgv_DDRHrs.Size = New Size(TabControl1.Size.Width - 10, TabControl1.Size.Height - 135)
            Label24.Location = New Point(Label24.Location.X, TabControl1.Size.Height - 119)
            TextBox19.Location = New Point(TextBox19.Location.X, TabControl1.Size.Height - 122)
            Label25.Location = New Point(Label25.Location.X, TabControl1.Size.Height - 122)
            TextBox20.Location = New Point(TextBox20.Location.X, (TabControl1.Size.Height + Label25.Size.Height) - 122)
            Label26.Location = New Point(Label26.Location.X, TabControl1.Size.Height - 122)
            Label177.Location = New Point(Label177.Location.X, TabControl1.Size.Height - 122)
            Label178.Location = New Point(Label178.Location.X, TabControl1.Size.Height - 122)

            TextBox21.Location = New Point(TextBox21.Location.X, (TabControl1.Size.Height + Label25.Size.Height) - 122)
            TextBox144.Location = New Point(TextBox144.Location.X, (TabControl1.Size.Height + Label25.Size.Height) - 122)
            TextBox145.Location = New Point(TextBox145.Location.X, (TabControl1.Size.Height + Label25.Size.Height) - 122)

            dgv_BITS.Size = New Size(TabControl1.Size.Width - 10, dgv_BITS.Size.Height)

            'Drill stirng tab
            dgv_String.Size = New Size(TabControl1.Size.Width - 10, (TabControl1.Size.Height / 2) - 52)
            'dgv_String_Survey.Location = New Point(dgv_String_Survey.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + 27))
            dgv_String_Survey.Size = New Size(TabControl1.Size.Width - 10, (TabControl1.Size.Height / 2) - 72)
            dgv_String_Survey.Location = New Point(dgv_String_Survey.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + 27))
            Label41.Location = New Point(Label41.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 32))

            Label35.Location = New Point(Label35.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))

            TextBox26.Location = New Point(TextBox26.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))

            Label37.Location = New Point(Label37.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))
            TextBox27.Location = New Point(TextBox27.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))

            Label38.Location = New Point(Label38.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))
            TextBox28.Location = New Point(TextBox28.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))

            Label39.Location = New Point(Label39.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))
            TextBox29.Location = New Point(TextBox29.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))

            Label40.Location = New Point(Label40.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))
            TextBox30.Location = New Point(TextBox30.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))

            Label162.Location = New Point(Label162.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))
            TextBox138.Location = New Point(TextBox138.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))


            Label36.Location = New Point(Label36.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 68))
            TextBox132.Location = New Point(TextBox132.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 71))

            'ECD labels and text box
            Label184.Location = New Point(Label184.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 91))
            txtECD12.Location = New Point(txtECD12.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 94))

            Label185.Location = New Point(Label185.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 91))
            txtECD24.Location = New Point(txtECD24.Location.X, TabControl1.Size.Height - (dgv_String_Survey.Height + Label41.Size.Height + 94))


            'pumps
            dgv_pumps.Size = New Size(TabControl1.Size.Width - 10, TabControl1.Size.Height - 87)
            Label181.Location = New Point(Label181.Location.X, TabControl1.Size.Height - 57)
            Label182.Location = New Point(Label182.Location.X, TabControl1.Size.Height - 57)
            Label183.Location = New Point(Label183.Location.X, TabControl1.Size.Height - 57)
            TextBox149.Location = New Point(TextBox149.Location.X, TabControl1.Height - 57)
            TextBox150.Location = New Point(TextBox150.Location.X, TabControl1.Height - 57)
            TextBox151.Location = New Point(TextBox151.Location.X, TabControl1.Height - 57)

            'shakers
            dgv_Shakers.Size = New Size(TabControl1.Size.Width - 10, TabControl1.Size.Height - 27)

            dgv_Mud.Size = New Size(TabControl1.Size.Width - 10, TabControl1.Size.Height - 142)
            Label119.Location = New Point(Label119.Location.X, TabControl1.Height - (TextBox94.Size.Height + Label119.Size.Height + 35))
            TextBox94.Location = New Point(TextBox94.Location.X, TabControl1.Height - (TextBox94.Size.Height + 35))

            'Activities
            dgv_activities.Size = New Size(TabControl1.Size.Width - 25, (TabControl1.Size.Height / 3) - 55)
            dgv_UrgentsMRs.Size = New Size(TabControl1.Size.Width - 25, (TabControl1.Size.Height / 3) - 45)
            dgv_WorkOrders.Size = New Size(TabControl1.Size.Width - 25, (TabControl1.Size.Height / 3) - 45)
            Button6.Location = New Point(TabControl1.Size.Width - (Button6.Size.Width + 25), Button6.Location.Y)
            Label172.Location = New Point(Label172.Location.X, (TabControl1.Size.Height / 3))
            dgv_UrgentsMRs.Location = New Point(dgv_UrgentsMRs.Location.X, TabControl1.Location.Y + dgv_activities.Size.Height + Label172.Height + 25)
            Label173.Location = New Point(Label172.Location.X, TabControl1.Location.Y + dgv_activities.Size.Height + Label172.Height + 28 + dgv_UrgentsMRs.Height)
            dgv_WorkOrders.Location = New Point(dgv_WorkOrders.Location.X, TabControl1.Location.Y + dgv_activities.Size.Height + Label172.Height + 28 + dgv_UrgentsMRs.Height + Label173.Height)
            'Button5.Location = New Point(TabControl1.Size.Width - (Button5.Size.Width - 15), Button5.Location.Y)

            dgv_RiserProfile.Size = New Size(TabControl1.Size.Width - 25, TabControl1.Size.Height - 45)

            ' Logistic Transit Log resize 
            dgv_LogTranLogBoat.Size = New Size(TabControl1.Size.Width - 25, (TabControl1.Size.Height / 2) - (Label170.Size.Height + 25))
            Label170.Location = New Point(Label170.Location.X, (TabControl1.Size.Height / 2) - (Label170.Size.Height))
            '
            dgv_LogTranLogHeli.Size = New Size(TabControl1.Size.Width - 25, (TabControl1.Size.Height / 2) - (Label170.Size.Height + 10))
            dgv_LogTranLogHeli.Location = New Point(dgv_LogTranLogHeli.Location.X, TabControl1.Size.Height - (dgv_LogTranLogHeli.Height + Label170.Size.Height))
            'dgv_LogTranLogBoat.Size = New Size(TabControl1.Size.Width - 25, (TabControl1.Size.Height / 2) - (Label170.Size.Height + 25))

            'Pemex Urgent MR (PUMR)
            dgv_PUMR.Size = New Size(TabControl1.Size.Width - 10, TabControl1.Size.Height - 27)
        Else
            Button2.Location = New Point(14, 427)
            Button7.Location = New Point(148, 427)
            Button4.Location = New Point(280, 427)
            Button3.Location = New Point(424, 427)
            Button1.Location = New Point(647, 427)
            TabControl1.Size = New Size(766, 389)
        End If

    End Sub

    Public Sub CalculateDDRProgress()
        'validate both values are numeric
        Dim canwecalculae As Boolean = False
        If IsNumeric(TextBox5.Text) And IsNumeric(TextBox3.Text) Then
            canwecalculae = True
        End If

        If canwecalculae Then
            Dim mdndepth As Integer
            Dim yestdepth As Integer
            Dim progress As Integer

            Try
                yestdepth = Integer.Parse(TextBox5.Text)
                mdndepth = Integer.Parse(TextBox3.Text)
                progress = mdndepth - yestdepth
                TextBox6.Text = progress
            Catch ex As Exception

            End Try

        End If

    End Sub

    Private Sub TextBox3_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox3.KeyUp
        CalculateDDRProgress()
    End Sub

    Private Sub TextBox5_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox5.KeyUp
        CalculateDDRProgress()
    End Sub

    Private Sub dgv_activities_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_activities.CellEndEdit
        'aver el objeto a modificar
        ' modificar el objeto en el model
        ' modificar el objeto en la base de datos
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        If dgv_activities.Rows(e.RowIndex).Cells(0).Value <> "" Or dgv_activities.Rows(e.RowIndex).Cells(1).Value <> "" Then
            If IsNothing(dgv_activities.Rows(e.RowIndex).Cells(2).Value) Then
                deparmentid = ado.GetDeparmentID(ComboBox1.Text)
                Dim activitie As New com.entities.Activities
                activitie.DDR_Report_ID = _DDR.DDRID
                activitie.Deparment_ID = deparmentid
                activitie.Deparment = ComboBox1.Text
                activitie.Activity = dgv_activities.Rows(e.RowIndex).Cells(0).Value
                activitie.ActivitySpanish = dgv_activities.Rows(e.RowIndex).Cells(1).Value
                DDRReport.DDRReport.Activities.Add(activitie, True)
                dgv_activities.Rows(e.RowIndex).Cells(2).Value = activitie.Act_Detail_ID
            Else
                deparmentid = ado.GetDeparmentID(ComboBox1.Text)
                Dim activitie As New com.entities.Activities
                activitie.DDR_Report_ID = _DDR.DDRID
                activitie.Deparment_ID = deparmentid
                activitie.Deparment = ComboBox1.Text
                activitie.Activity = dgv_activities.Rows(e.RowIndex).Cells(0).Value
                activitie.ActivitySpanish = dgv_activities.Rows(e.RowIndex).Cells(1).Value
                activitie.Act_Detail_ID = dgv_activities.Rows(e.RowIndex).Cells(2).Value
                DDRReport.DDRReport.Activities.ModifyActivity(activitie)
            End If
        End If
    End Sub

    Private Sub dgv_activities_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_activities.UserDeletedRow
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        Try
            If Not IsNothing(e.Row.Cells(2).Value) Then
                Dim result As Integer = MsgBox("Do you want to remove the record?", MsgBoxStyle.OkCancel, "Remove record")
                If result = vbOK Then
                    deparmentid = ado.GetDeparmentID(ComboBox1.Text)
                    Dim activitie As New com.entities.Activities
                    activitie.DDR_Report_ID = _DDR.DDRID
                    activitie.Deparment_ID = deparmentid
                    activitie.Deparment = ComboBox1.Text
                    activitie.Activity = e.Row.Cells(0).Value
                    activitie.ActivitySpanish = e.Row.Cells(1).Value
                    activitie.Act_Detail_ID = e.Row.Cells(2).Value
                    DDRReport.DDRReport.Activities.RemoveActivity(activitie)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dgv_UrgentsMRs_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_UrgentsMRs.CellEndEdit
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        deparmentid = ado.GetDeparmentID(ComboBox1.Text)
        If dgv_UrgentsMRs.Rows(e.RowIndex).Cells(0).Value <> "" Or dgv_UrgentsMRs.Rows(e.RowIndex).Cells(1).Value <> "" Or dgv_UrgentsMRs.Rows(e.RowIndex).Cells(2).Value <> "" Or dgv_UrgentsMRs.Rows(e.RowIndex).Cells(3).Value <> "" Then
            If IsNothing(dgv_UrgentsMRs.Rows(e.RowIndex).Cells(4).Value) Then
                Dim umr As New com.entities.UrgentMRs
                umr.DDR_Report_ID = _DDR.DDRID
                umr.Deparment_ID = deparmentid
                umr.MRNumber = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(0).Value
                umr.dateIssued = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(1).Value
                umr.MRDescription = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(2).Value
                umr.Status = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(3).Value
                _DDR.DDRReport.UrgentsMR.Add(umr, True)
                dgv_UrgentsMRs.Rows(e.RowIndex).Cells(4).Value = umr.MRUrgentID
            Else
                Dim umr As New com.entities.UrgentMRs
                umr.DDR_Report_ID = _DDR.DDRID
                umr.Deparment_ID = deparmentid
                umr.MRNumber = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(0).Value
                umr.dateIssued = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(1).Value
                umr.MRDescription = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(2).Value
                umr.Status = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(3).Value
                umr.MRUrgentID = dgv_UrgentsMRs.Rows(e.RowIndex).Cells(4).Value
                _DDR.DDRReport.UrgentsMR.Modify(umr)
            End If
        End If
    End Sub

    'Funcion modificada 8-Agosto-2017
    ' Agrego funcionadlida y campos para marcar si la WO es Correctiva o Preventiva asi como marcarla para el reporte de F1

    Private Sub dgv_WorkOrders_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_WorkOrders.CellEndEdit
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        deparmentid = ado.GetDeparmentID(ComboBox1.Text)
        If dgv_WorkOrders.Rows(e.RowIndex).Cells(2).Value <> "" Or dgv_WorkOrders.Rows(e.RowIndex).Cells(3).Value <> "" Then

            If IsNothing(dgv_WorkOrders.Rows(e.RowIndex).Cells(5).Value) Then
                Dim wo As New com.entities.WorkOrder
                wo.WONumber = dgv_WorkOrders.Rows(e.RowIndex).Cells(2).Value
                wo.WODescription = dgv_WorkOrders.Rows(e.RowIndex).Cells(3).Value
                wo.WODescriptionSpanish = dgv_WorkOrders.Rows(e.RowIndex).Cells(4).Value
                Dim chk_p As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(0)
                wo.WOPreventive = chk_p.Value
                Dim chk_c As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(1)
                wo.WOCorrective = chk_c.Value
                wo.WOToF1 = dgv_WorkOrders.Rows(e.RowIndex).Cells(6).Value
                wo.DDR_Report_ID = _DDR.DDRID
                wo.Deparment_ID = deparmentid
                _DDR.DDRReport.WorkOrders.Add(wo, True)
                dgv_WorkOrders.Rows(e.RowIndex).Cells(5).Value = wo.WorkOrderID
            Else
                Dim wo As New com.entities.WorkOrder
                wo.WONumber = dgv_WorkOrders.Rows(e.RowIndex).Cells(2).Value
                wo.WODescription = dgv_WorkOrders.Rows(e.RowIndex).Cells(3).Value
                wo.WODescriptionSpanish = dgv_WorkOrders.Rows(e.RowIndex).Cells(4).Value
                Dim chk_p As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(0)
                wo.WOPreventive = chk_p.Value
                Dim chk_c As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(1)
                wo.WOCorrective = chk_c.Value
                wo.WOToF1 = dgv_WorkOrders.Rows(e.RowIndex).Cells(6).Value
                wo.DDR_Report_ID = _DDR.DDRID
                wo.Deparment_ID = deparmentid
                wo.WorkOrderID = dgv_WorkOrders.Rows(e.RowIndex).Cells(5).Value
                _DDR.DDRReport.WorkOrders.Modify(wo)
            End If
        End If

    End Sub

    Private Sub dgv_WorkOrders_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_WorkOrders.UserDeletedRow
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        Try
            If Not IsNothing(e.Row.Cells(5).Value) Then
                Dim result As Integer = MsgBox("Do you want to remove the record?", MsgBoxStyle.OkCancel, "Remove record")
                If result = vbOK Then
                    deparmentid = ado.GetDeparmentID(ComboBox1.Text)
                    Dim wo As New com.entities.WorkOrder
                    wo.WONumber = e.Row.Cells(2).Value
                    wo.WODescription = e.Row.Cells(3).Value
                    wo.DDR_Report_ID = _DDR.DDRID
                    wo.Deparment_ID = deparmentid
                    wo.WorkOrderID = e.Row.Cells(5).Value
                    DDRReport.DDRReport.WorkOrders.Remove(wo)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgv_UrgentsMRs_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_UrgentsMRs.KeyDown
        Dim ado As New com.ADO.ADOMySQLDDR
        Dim deparmentid As Integer
        deparmentid = ado.GetDeparmentID(ComboBox1.Text)
        If e.KeyCode = Keys.F3 Then
            Dim i As Integer
            i = MsgBox("Do you want to load the last report information?", MsgBoxStyle.YesNo, "DDR New form")
            If i = vbYes Then
                'ddr.Active = True
                'ddr.ReportNo = 1
                Dim lastddr As Integer
                'lastddr = ado.GetLastID("DDR_Control", "DDRID")
                lastddr = _DDR.DDRID
                ddrloaded = ado.GetCompleteDDRReport(lastddr - 1)
                For Each item As com.entities.UrgentMRs In ddrloaded.DDRReport.UrgentsMR.items
                    If item.Deparment_ID.Equals(deparmentid) Then
                        item.MRUrgentID = -1
                        item.DDR_Report_ID = _DDR.DDRID
                        _DDR.DDRReport.UrgentsMR.Add(item, True)
                        Dim row As String() = {item.MRNumber, item.dateIssued, item.MRDescription, item.Status, item.MRUrgentID}
                        dgv_UrgentsMRs.Rows.Add(row)
                    End If
                Next
            End If
        End If
    End Sub

    Private Sub dgv_DDRHrs_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles dgv_DDRHrs.MouseDown
        If e.Button = MouseButtons.Right Then
            ContextMenuStrip1.Show(dgv_DDRHrs, New Point(e.X, e.Y))
        End If
    End Sub

    Private Sub AddRowToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRowToolStripMenuItem.Click
        Dim selectedcell As DataGridViewCell
        selectedcell = dgv_DDRHrs.CurrentCell

        Dim tmprow As New DataGridViewRow
        tmprow.Height = selectedcell.Size.Height
        dgv_DDRHrs.Rows.Insert(selectedcell.RowIndex, tmprow)




    End Sub

    Private Sub AddRowAtBottomToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddRowAtBottomToolStripMenuItem.Click
        Dim selectedcell As DataGridViewCell
        selectedcell = dgv_DDRHrs.CurrentCell

        Dim tmprow As New DataGridViewRow
        tmprow.Height = selectedcell.Size.Height
        dgv_DDRHrs.Rows.Insert(selectedcell.RowIndex + 1, tmprow)
    End Sub

    Private Sub DeleteRwToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DeleteRwToolStripMenuItem.Click
        Dim response As Integer
        response = MsgBox("Do you want to delete the row?", MsgBoxStyle.YesNo)
        If response = vbYes Then
            Dim selectedcell As DataGridViewCell
            selectedcell = dgv_DDRHrs.CurrentCell
            Dim ado As New com.ADO.ADOMySQLDDR
            Dim ddrhrs As New com.entities.DDRHrs
            ddrhrs.Detail_HR_ID = dgv_DDRHrs.Rows(selectedcell.RowIndex).Cells(6).Value
            ado.DeleteDDHrs(ddrhrs)
            dgv_DDRHrs.Rows.RemoveAt(selectedcell.RowIndex)
        End If

    End Sub

    Private Sub dgv_DDRHrs_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_DDRHrs.UserDeletedRow
        Dim ado As New com.ADO.ADOMySQLDDR
        Dim ddrhrs As New com.entities.DDRHrs
        ddrhrs.Detail_HR_ID = e.Row.Cells(6).Value
        ado.DeleteDDHrs(ddrhrs)
    End Sub

    Private Sub dgv_BITS_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_BITS.UserDeletedRow
        Dim response As Integer
        response = MsgBox("Do you want to delete the row?", MsgBoxStyle.YesNo)
        If response = vbYes Then
            Dim ado As New com.ADO.ADOMySQLDDR
            Dim bits As New com.entities.BITS
            bits.BITS_ID = e.Row.Cells(12).Value
            ado.DeleteBITS(bits)
            'dgv_BITS.Rows.RemoveAt(selectedcell.RowIndex)
        End If
    End Sub

    Private Sub dgv_Shakers_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Shakers.UserDeletedRow
        Dim response As Integer
        response = MsgBox("Do you want to delete the row?", MsgBoxStyle.YesNo)
        If response = vbYes Then
            Dim ado As New com.ADO.ADOMySQLDDR
            Dim shaker As New com.entities.Shakers
            shaker.Shakers_ID = e.Row.Cells(11).Value
            ado.DeleteShaker(shaker)
            'dgv_BITS.Rows.RemoveAt(selectedcell.RowIndex)
        End If
    End Sub

    Private Sub dgv_Mud_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_Mud.UserDeletedRow
        Dim response As Integer
        response = MsgBox("Do you want to delete the row?", MsgBoxStyle.YesNo)
        If response = vbYes Then
            Dim ado As New com.ADO.ADOMySQLDDR
            Dim mud As New com.entities.Mud
            mud.MUD_ID = e.Row.Cells(12).Value
            ado.DeleteMud(mud)
            'dgv_BITS.Rows.RemoveAt(selectedcell.RowIndex)
        End If
    End Sub

    Private Sub dgv_UrgentsMRs_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_UrgentsMRs.UserDeletedRow
        Dim response As Integer
        response = MsgBox("Do you want to delete the row?", MsgBoxStyle.YesNo)
        If response = vbYes Then
            Dim ado As New com.ADO.ADOMySQLDDR
            Dim UrgentMR As New com.entities.UrgentMRs
            UrgentMR.MRUrgentID = e.Row.Cells(4).Value
            ado.DeleteUrgentMR(UrgentMR)
            _DDR.DDRReport.UrgentsMR.Remove(UrgentMR)
            'dgv_BITS.Rows.RemoveAt(selectedcell.RowIndex)
        End If
    End Sub

    Private Sub checkUpdDDR(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not upd_ddr.Checked Then
            upd_ddr.Checked = True
            MsgBox("cheked")
        End If
    End Sub

    Private Sub DDRUpdateChecker_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DDRUpdateChecker.Tick
        Dim adoddr As New com.ADO.ADOMySQLDDR
        Dim lastddrupdate As New Date

        If Not _FormMode = FormModes.View Then

            lastddrupdate = adoddr.GetLastDDRUpdate(_DDR.DDRID)
            If _DDROpenDate >= lastddrupdate Then

            Else
                'MsgBox("Version Conflict")
                DDRUpdateChecker.Enabled = False

                'Dim res As Integer = MsgBox("A new version of DDR was detected, the aplication will update the information and keep all the changes made it on the report", MsgBoxStyle.Question, "Updated version of DDR")
                Dim ado As New com.ADO.ADOMySQLDDR
                _DDR = ado.GetCompleteDDRReport(_DDR.DDRID)
                _DDROpenDate = _DDR.LastUpdate
                FillForm(TabControl1.SelectedTab.Name)
                DDRUpdateChecker.Enabled = True
            End If
        Else
            DDRUpdateChecker.Enabled = False
        End If
    End Sub

    Private Sub UpdateTabDDR()
        txtOperator.Text = _DDR.DDRReport.Operator_s
        TextBox2.Text = _DDR.DDRReport.Contractor
        TextBox3.Text = _DDR.DDRReport.Midnigth_Depth
        TextBox4.Text = _DDR.DDRReport.TVD
        TextBox5.Text = _DDR.DDRReport.Yesterdays_Depth
        TextBox6.Text = _DDR.DDRReport.Progress
        TextBox7.Text = _DDR.DDRReport.Formation
        TextBox8.Text = _DDR.DDRReport.Mud_weight
        TextBox11.Text = _DDR.DDRReport.Well
        TextBox12.Text = _DDR.DDRReport.Block
        TextBox13.Text = _DDR.DDRReport.Country
        TextBox14.Text = _DDR.DDRReport.KSP_Hrs
        TextBox15.Text = _DDR.DDRReport.Todays_Rot_Hrs
        TextBox16.Text = _DDR.DDRReport.Yest_Rot_Hrs
        TextBox17.Text = _DDR.DDRReport.Cum_Rot_Hrs
        TextBox18.Text = _DDR.DDRReport.Leak_off_test
        TextBox80.Text = _DDR.DDRReport.DaysFromSpud
        TextBox81.Text = _DDR.DDRReport.ProposedTD
        TextBox82.Text = _DDR.DDRReport.RKBToWH
        TextBox83.Text = _DDR.DDRReport.RKBtoSeaBeadMtrs
        TextBox84.Text = _DDR.DDRReport.TOLSize
        TextBox85.Text = _DDR.DDRReport.LastCasing
        TextBox86.Text = _DDR.DDRReport.WeightGR
        TextBox87.Text = _DDR.DDRReport.CasingID
        TextBox88.Text = _DDR.DDRReport.CsgShoeMtrs
        TextBox50.Text = _DDR.DDRReport.PemexUnit
        TextBox51.Text = _DDR.DDRReport.Washpipehrs
        TextBox130.Text = _DDR.DDRReport.EstendWell
        TextBox133.Text = _DDR.DDRReport.DrillLineSlippedandCut
        TextBox52.Text = _DDR.DDRReport.MarineInfo.ToneMilesSinceLastCut
        If Not IsNothing(_DDR.DDRReport.DDRDate) Then
            Try
                DateTimePicker6.Value = Date.Parse(_DDR.DDRReport.DDRDate)
            Catch ex As Exception
                MsgBox("Error trying to get COM Test date from the database")
            End Try
        End If

    End Sub

    Private Sub UpdateTabDDRHrs()
        TextBox9.Text = _DDR.ReportDate.ToString("MM/dd/yyyy")
        TextBox10.Text = _DDR.ReportNo
        TextBox147.Text = _DDR.Well
        TextBox148.Text = _DDR.Description

        TextBox19.Text = _DDR.DDRReport.TotalsHrs
        TextBox20.Text = _DDR.DDRReport.Tool_Pusher_Comments
        TextBox21.Text = _DDR.DDRReport.Activities_Next24_hrs
        TextBox144.Text = DDRReport.DDRReport.Tool_Pusher_Comments_Spanish
        TextBox145.Text = DDRReport.DDRReport.Activities_Next24_hrs_spanish

        dgv_DDRHrs.Rows.Clear()
        Dim row As String()
        'Load DDR Hrs
        If Not IsNothing(_DDR.DDRReport.DDRHrs) Then
            For Each item As com.entities.DDRHrs In _DDR.DDRReport.DDRHrs.Items
                row = New String() {item.Fromv, item.Tov, item.Total, item.Code, item.Comment, item.CommentSpanish, item.Detail_HR_ID}
                dgv_DDRHrs.Rows.Add(row)

            Next
            dgv_DDRHrs.Sort(dgv_DDRHrs.Columns(0), System.ComponentModel.ListSortDirection.Ascending)
            dgv_DDRHrs.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None
            dgv_DDRHrs.Columns(4).Width = 500
        End If
    End Sub

    Private Sub UpdateTabBITS()
        TextBox22.Text = _DDR.DDRReport.BITS_AnnVelCsg
        TextBox23.Text = _DDR.DDRReport.BITS_AnnVel
        TextBox24.Text = _DDR.DDRReport.BITS_DCVel
        TextBox25.Text = _DDR.DDRReport.BITS_NozzleVel
        dgv_BITS.Rows.Clear()
        'Load BITS
        Dim row As String()
        If Not IsNothing(_DDR.DDRReport.BITS) Then
            For Each item As com.entities.BITS In _DDR.DDRReport.BITS.Items
                row = New String() {item.bit_No, item.bit_Size, item.bit_Make, item.bit_Serial, item.Bit_type, item.bit_Jets, item.bit_TFA, item.bit_Out, item.bit_In, item.bit_Mtrs, item.bit_Hrs, item.bit_Comments, item.BITS_ID}
                dgv_BITS.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub UpdateTabDrillString()
        TextBox26.Text = _DDR.DDRReport.DrillString_StringWeight
        TextBox27.Text = _DDR.DDRReport.DrillString_StackOffWeigth
        TextBox28.Text = _DDR.DDRReport.DrillString_WOB
        TextBox29.Text = _DDR.DDRReport.DrillString_RPM
        TextBox30.Text = _DDR.DDRReport.DrillString_Torque
        TextBox132.Text = _DDR.DDRReport.DrillString_RotWeigth
        TextBox138.Text = _DDR.DDRReport.DrillString_PUWeight
        dgv_String.Rows.Clear()
        dgv_String_Survey.Rows.Clear()
        Dim row As String()
        'Load Drill String
        If Not IsNothing(_DDR.DDRReport.DrillString) Then
            If _DDR.DDRReport.DrillString.Count > 0 Then
                For Each item As com.entities.DrillString In _DDR.DDRReport.DrillString.Items
                    row = New String() {item.Description, item.SizeDR, item.Weight, item.Grade, item.ToolJoint, item.ToolJntOD, item.TotalOnBoard, item.DrillString_ID}
                    dgv_String.Rows.Add(row)
                Next
                If _DDR.DDRReport.DrillString.Count = 6 Then
                    row = New String() {"Drill Collar", "", "", "", "", "", ""}
                    dgv_String.Rows.Add(row)
                End If
            Else
                row = New String() {"", "", "", "", "", "", ""}
                dgv_String.Rows.Add(row)
            End If
        End If
        'Load Drill String survey
        If Not IsNothing(_DDR.DDRReport.DrillString_Survey) Then
            For Each item As com.entities.DrillString_Survey In _DDR.DDRReport.DrillString_Survey.Items
                row = New String() {item.DirectionalSurveys, item.MID, item.TVD, item.INC, item.AZM, item.Comments, item.Survey_ID}
                dgv_String_Survey.Rows.Add(row)
            Next

        End If
    End Sub

    Private Sub UpdatedTabBHA()
        TextBox129.Text = _DDR.DDRReport.BHA_BottomHoleAssembly
        TextBox31.Text = _DDR.DDRReport.BHA_BelowJars
        TextBox32.Text = _DDR.DDRReport.BHA_BAGWT
        TextBox33.Text = _DDR.DDRReport.BHA_Comments

    End Sub

    Private Sub UpdateTabPumps()
        If Not IsNothing(_DDR.DDRReport.Pumps) Then
            dgv_pumps.Rows.Clear()
        End If
        'Load pumps
        Dim row As String()
        If Not IsNothing(_DDR.DDRReport.Pumps) Then
            For Each item As com.entities.Pumps In _DDR.DDRReport.Pumps.Items
                row = New String() {item.PumpNo, item.MakeandModel, item.Stroke, item.Liners, item.SPM, item.GPM, item.EFF, item.Press, item.MP, item.CLF, item.CLFCK, item.s30StrokesChoke, item.s30StrokesCK, item.s50StrokesChoke, item.s40StrokesCK, item.s50StrokesChoke, item.s50StrokesCK, item.PUMPS_ID}
                dgv_pumps.Rows.Add(row)
            Next
        End If

        TextBox149.Text = _DDR.DDRReport.PumpsMeasureddepth
        TextBox150.Text = _DDR.DDRReport.PumpsTrueverticaldepth
        TextBox151.Text = _DDR.DDRReport.PumpsMudweigth
    End Sub

    Private Sub UpdateTabShakers()
        dgv_Shakers.Rows.Clear()
        Dim row As String()
        'Load Shakers
        If Not IsNothing(_DDR.DDRReport.Shakers) Then
            For Each item As com.entities.Shakers In _DDR.DDRReport.Shakers.Items
                row = New String() {item.ShakerNo, item.MakeAndModel, item.ScreenSize, item.Top1, item.Top2, item.Top3, item.Top4, item.Bottom1, item.Bottom2, item.Bottom3, item.Bottom4, item.Shakers_ID}
                dgv_Shakers.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub UpdateTabMud()
        TextBox89.Text = _DDR.DDRReport.Mud_VolumeActivePits
        TextBox90.Text = _DDR.DDRReport.Mud_HoleVolume
        TextBox91.Text = _DDR.DDRReport.Mud_System
        TextBox92.Text = _DDR.DDRReport.Mud_Percent
        TextBox93.Text = _DDR.DDRReport.Mud_MaxGas
        TextBox94.Text = _DDR.DDRReport.Mud_Comments
        dgv_Mud.Rows.Clear()
        Dim row As String()
        'Load MUD
        If Not IsNothing(_DDR.DDRReport.Mud) Then
            For Each item As com.entities.Mud In _DDR.DDRReport.Mud.Items
                row = New String() {item.TimeMud, item.WT, item.VIS, item.WL, item.Cake, item.PH, item.Sand, item.Solids, item.PvYP, item.KCL, item.Pm, item.Comments, item.MUD_ID}
                dgv_Mud.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub UpdateTabMarine()
        TextBox34.Text = _DDR.DDRReport.Wind_Dir
        TextBox35.Text = _DDR.DDRReport.Wind_Speed
        TextBox36.Text = _DDR.DDRReport.Current_Dir
        TextBox37.Text = _DDR.DDRReport.Current_Speed
        TextBox38.Text = _DDR.DDRReport.Temp_Air
        TextBox39.Text = _DDR.DDRReport.Temp_Sea
        TextBox40.Text = _DDR.DDRReport.Barometer
        TextBox41.Text = _DDR.DDRReport.Sea
        TextBox42.Text = _DDR.DDRReport.Swell
        TextBox43.Text = _DDR.DDRReport.Roll
        TextBox44.Text = _DDR.DDRReport.Pitch
        TextBox45.Text = _DDR.DDRReport.Heave
        TextBox46.Text = _DDR.DDRReport.Visibilty
        TextBox50.Text = _DDR.DDRReport.PemexUnit
        TextBox51.Text = _DDR.DDRReport.Washpipehrs
        TextBox130.Text = _DDR.DDRReport.EstendWell
        TextBox133.Text = _DDR.DDRReport.DrillLineSlippedandCut
        TextBox141.Text = _DDR.DDRReport.MarineInfo.Marine_ID
        TextBox47.Text = _DDR.DDRReport.MarineInfo.AirGap
        TextBox48.Text = _DDR.DDRReport.MarineInfo.UsedPlayload
        TextBox49.Text = _DDR.DDRReport.MarineInfo.RemainingPayload

        If Not _DDR.DDRReport.MarineInfo.LastboatDrill.ToString("MM/dd/yyyy").Equals("01/01/0001") Then
            Try
                DateTimePicker1.Value = _DDR.DDRReport.MarineInfo.LastboatDrill.ToString("MM/dd/yyyy")
            Catch ex As Exception
                MsgBox("Error trying to get the Last boar drill date from the database")
            End Try

        End If
        If Not _DDR.DDRReport.MarineInfo.FireDrill.ToString("MM/dd/yyyy").Equals("01/01/0001") Then
            Try
                DateTimePicker2.Value = _DDR.DDRReport.MarineInfo.FireDrill.ToString("MM/dd/yyyy")
            Catch ex As Exception
                MsgBox("Error trying to get the Fire drill date from the database")
            End Try

        End If

        If Not IsNothing(_DDR.DDRReport.MarineInfo.BOPTest) Then
            Try
                DateTimePicker3.Value = Date.Parse(_DDR.DDRReport.MarineInfo.BOPTest)
            Catch ex As Exception
                MsgBox("Error trying to get the BOP Test date from the database")
            End Try

        End If

        If Not IsNothing(_DDR.DDRReport.MarineInfo.COMTest) Then
            Try
                DateTimePicker4.Value = Date.Parse(_DDR.DDRReport.MarineInfo.COMTest)
            Catch ex As Exception
                MsgBox("Error trying to get COM Test date from the database")
            End Try

        End If



        TextBox53.Text = _DDR.DDRReport.MarineInfo.YestStock_PotWater
        TextBox57.Text = _DDR.DDRReport.MarineInfo.YestStock_Barite
        TextBox61.Text = _DDR.DDRReport.MarineInfo.YestStock_Bentonite
        TextBox65.Text = _DDR.DDRReport.MarineInfo.YestStock_Gel
        TextBox69.Text = _DDR.DDRReport.MarineInfo.YestStock_CementG
        TextBox73.Text = _DDR.DDRReport.MarineInfo.YestStock_CmtBlended
        TextBox54.Text = _DDR.DDRReport.MarineInfo.TodayStock_PotWater
        TextBox58.Text = _DDR.DDRReport.MarineInfo.TodayStock_Barite
        TextBox62.Text = _DDR.DDRReport.MarineInfo.TodayStock_Bentonite
        TextBox66.Text = _DDR.DDRReport.MarineInfo.TodayStock_Gel
        TextBox70.Text = _DDR.DDRReport.MarineInfo.TodayStock_CementG
        TextBox74.Text = _DDR.DDRReport.MarineInfo.TodayStock_CMTBlended
        TextBox55.Text = _DDR.DDRReport.MarineInfo.Used_PotWater
        TextBox59.Text = _DDR.DDRReport.MarineInfo.Used_Barite
        TextBox63.Text = _DDR.DDRReport.MarineInfo.Used_Bentoniote
        TextBox67.Text = _DDR.DDRReport.MarineInfo.Used_Gel
        TextBox71.Text = _DDR.DDRReport.MarineInfo.Used_CementG
        TextBox75.Text = _DDR.DDRReport.MarineInfo.Used_CmtBlended
        TextBox56.Text = _DDR.DDRReport.MarineInfo.RecivedMade_PotWater
        TextBox60.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Barite
        TextBox64.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Bentoniote
        TextBox68.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Gel
        TextBox72.Text = _DDR.DDRReport.MarineInfo.RecivedMade_CementG
        TextBox76.Text = _DDR.DDRReport.MarineInfo.RecivedMade_CmtBlended
        TextBox77.Text = _DDR.DDRReport.MarineInfo.Helifuel
        TextBox78.Text = _DDR.DDRReport.MarineInfo.Brine
        TextBox79.Text = _DDR.DDRReport.MarineInfo.Base_oil
        TextBox117.Text = _DDR.DDRReport.MarineInfo.LubOil
        TextBox131.Text = _DDR.DDRReport.MarineInfo.Comments
        TextBox52.Text = _DDR.DDRReport.MarineInfo.ToneMilesSinceLastCut
        TextBox139.Text = _DDR.DDRReport.MarineInfo.GeneratorsOnline
        TextBox140.Text = _DDR.DDRReport.MarineInfo.Thrustersonline
        TextBox146.Text = _DDR.DDRReport.MarineInfo.Comments_spanish
    End Sub

    Private Sub UpdateTabPOB()
        'Load POB
        If Not IsNothing(_DDR.DDRReport.POB) Then
            TextBox95.Text = _DDR.DDRReport.POB.GRCrew
            TextBox96.Text = _DDR.DDRReport.POB.GRServ
            TextBox97.Text = _DDR.DDRReport.POB.Catering
            TextBox98.Text = _DDR.DDRReport.POB.Pemex
            TextBox99.Text = _DDR.DDRReport.POB.OpSer
            'TextBox100.Text = _DDR.DDRReport.POB.Total
            TextBox101.Text = _DDR.DDRReport.POB.DailyCost
            TextBox102.Text = _DDR.DDRReport.POB.AccCost
            TextBox103.Text = _DDR.DDRReport.POB.AverageCost
            TextBox104.Text = _DDR.DDRReport.POB.DaysFromLAstLTA
            TextBox142.Text = _DDR.DDRReport.POB.POB_ID
        End If
    End Sub

    Private Sub UpdateTabEngInfo()
        TextBox110.Text = _DDR.DDRReport.MarineInfo.YestStock_Diesel
        TextBox109.Text = _DDR.DDRReport.MarineInfo.YestStock_DrillWater
        TextBox108.Text = _DDR.DDRReport.MarineInfo.YestStock_LubOil
        TextBox107.Text = _DDR.DDRReport.MarineInfo.TodayStock_Diesel
        TextBox106.Text = _DDR.DDRReport.MarineInfo.TodayStock_DrillWater
        TextBox105.Text = _DDR.DDRReport.MarineInfo.TodayStock_LubOil
        TextBox113.Text = _DDR.DDRReport.MarineInfo.Used_Diesel
        TextBox112.Text = _DDR.DDRReport.MarineInfo.Used_DrillWater
        TextBox111.Text = _DDR.DDRReport.MarineInfo.Used_LubOil
        TextBox116.Text = _DDR.DDRReport.MarineInfo.RecivedMade_Diesel
        TextBox115.Text = _DDR.DDRReport.MarineInfo.RecivedMade_DrillWater
        TextBox114.Text = _DDR.DDRReport.MarineInfo.RecivedMade_LubOil
        TextBox100.Text = _DDR.DDRReport.UsedByPEP
        TextBox118.Text = _DDR.DDRReport.MarineInfo.Nitrogen_FullBottles
        TextBox121.Text = _DDR.DDRReport.MarineInfo.Nitrogen_InUse
        TextBox124.Text = _DDR.DDRReport.MarineInfo.Nitrogen_Empty
        TextBox119.Text = _DDR.DDRReport.MarineInfo.Oxygen_FullBottles
        TextBox122.Text = _DDR.DDRReport.MarineInfo.Oxygen_InUse
        TextBox125.Text = _DDR.DDRReport.MarineInfo.Oxygen_Empty
        TextBox120.Text = _DDR.DDRReport.MarineInfo.Acetyl_FullBottles
        TextBox123.Text = _DDR.DDRReport.MarineInfo.Acetyl_InUse
        TextBox126.Text = _DDR.DDRReport.MarineInfo.Acetyl_Empty

    End Sub

    Private Sub UpdateTabRiserPro()
        dgv_RiserProfile.Rows.Clear()
        Dim row As String()
        'Load Riser profile
        If Not IsNothing(_DDR.DDRReport.RiserProfile) Then
            For Each item As com.entities.RiserProfile In _DDR.DDRReport.RiserProfile.Items
                row = New String() {item.IDBeacon, item.Depth, item.Temp6hrs, item.Temp12hrs, item.Temp18hrs, item.Temp24hrs, item.Current6hrs, item.Current12hrs, item.Current18hrs, item.Current24hrs, item.Direction6hrs, item.Direction12hrs, item.Direction18hrs, item.Direction24hrs, item.IDRiserProfile}
                dgv_RiserProfile.Rows.Add(row)
            Next
        End If
    End Sub

    Private Sub UpdateTabSoc()
        'Load SOC
        If Not IsNothing(_DDR.DDRReport.SOC) Then
            TextBox134.Text = _DDR.DDRReport.SOC.SOCToday
            TextBox135.Text = _DDR.DDRReport.SOC.SOCMonth
            TextBox136.Text = _DDR.DDRReport.SOC.SOCSTOPTour
            TextBox137.Text = _DDR.DDRReport.SOC.DaysWithoutLTA
            TextBox143.Text = _DDR.DDRReport.SOC.SOCINFOID
        End If
    End Sub

    Private Sub UpdateTabLog()
        dgv_LogTranLogBoat.Rows.Clear()
        dgv_LogTranLogHeli.Rows.Clear()
        Dim row As String()
        'Load Logistic Transit Log
        If Not IsNothing(_DDR.DDRReport.LogisticTransitLog) Then
            For Each item As com.entities.LogisticTransitLog In _DDR.DDRReport.LogisticTransitLog.items
                'Dim row As String()
                Select Case item.Type
                    Case "Boat"
                        row = New String() {item.Log, item.LogEsp, item.LTID}
                        dgv_LogTranLogBoat.Rows.Add(row)
                    Case "Helicopter"
                        row = New String() {item.Log, item.LogEsp, item.LTID}
                        dgv_LogTranLogHeli.Rows.Add(row)
                End Select
            Next
        End If
    End Sub

    Private Sub UpdateTabPUMR()
        dgv_PUMR.Rows.Clear()
        Dim row As String()
        'Load Riser profile
        If Not IsNothing(_DDR.DDRReport.PUMR) Then
            For Each item As com.entities.PUMR In _DDR.DDRReport.PUMR.Items
                row = New String() {item.MRNumber, item.DateIssued, item.MRDesc, item.Status, item.PRUM_ID}
                dgv_PUMR.Rows.Add(row)
            Next
        End If
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()
        Application.AddMessageFilter(Me)
        Timer1.Enabled = True
        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub dgv_PUMR_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_PUMR.CellEndEdit
        Dim ado As New DDRReportToolCore.com.ADO.ADOMySQLDDR

        If IsNothing(dgv_PUMR.Rows(e.RowIndex).Cells(4).Value) Then
            If dgv_PUMR.Rows(e.RowIndex).Cells(0).Value <> "" Or dgv_PUMR.Rows(e.RowIndex).Cells(1).Value <> "" Then
                Dim pumr As New com.entities.PUMR
                'pumr.PRUM_ID = dgv_PUMR.Rows(e.RowIndex).Cells(4).Value
                pumr.DDR_Report_ID = _DDR.DDRID
                pumr.MRNumber = dgv_PUMR.Rows(e.RowIndex).Cells(0).Value
                pumr.DateIssued = dgv_PUMR.Rows(e.RowIndex).Cells(1).Value
                pumr.MRDesc = dgv_PUMR.Rows(e.RowIndex).Cells(2).Value
                pumr.Status = dgv_PUMR.Rows(e.RowIndex).Cells(3).Value
                _DDR.DDRReport.PUMR.Add(pumr, True)
                dgv_PUMR.Rows(e.RowIndex).Cells(4).Value = pumr.PRUM_ID
                _DDR.LastUpdate = Now()
                ado.UpdateDDRLastUpdate(_DDR)
            End If
        Else
            If IsNumeric(dgv_PUMR.Rows(e.RowIndex).Cells(4).Value) Then
                If dgv_PUMR.Rows(e.RowIndex).Cells(0).Value <> "" Or dgv_PUMR.Rows(e.RowIndex).Cells(1).Value <> "" Then
                    Dim pumr As New com.entities.PUMR
                    pumr.PRUM_ID = dgv_PUMR.Rows(e.RowIndex).Cells(4).Value
                    pumr.DDR_Report_ID = _DDR.DDRID
                    pumr.MRNumber = dgv_PUMR.Rows(e.RowIndex).Cells(0).Value
                    pumr.DateIssued = dgv_PUMR.Rows(e.RowIndex).Cells(1).Value
                    pumr.MRDesc = dgv_PUMR.Rows(e.RowIndex).Cells(2).Value
                    pumr.Status = dgv_PUMR.Rows(e.RowIndex).Cells(3).Value
                    _DDR.DDRReport.PUMR.Modify(pumr)
                    _DDR.LastUpdate = Now()
                    ado.UpdateDDRLastUpdate(_DDR)
                End If
            End If
        End If

    End Sub

    Private Sub dgv_PUMR_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_PUMR.UserDeletedRow
        Dim ado As New DDRReportToolCore.com.ADO.ADOMySQLDDR
        Try
            If Not IsNothing(e.Row.Cells(4).Value) Then
                Dim result As Integer = MsgBox("Do you want to remove the record?", MsgBoxStyle.OkCancel, "Remove record")
                If result = vbOK Then
                    Dim pumr As New com.entities.PUMR

                    pumr.DDR_Report_ID = _DDR.DDRID
                    pumr.PRUM_ID = e.Row.Cells(4).Value
                    pumr.MRNumber = e.Row.Cells(0).Value
                    pumr.DateIssued = e.Row.Cells(1).Value
                    pumr.MRDesc = e.Row.Cells(2).Value
                    pumr.Status = e.Row.Cells(3).Value
                    DDRReport.DDRReport.PUMR.Remove(pumr)
                    _DDR.LastUpdate = Now()
                    ado.UpdateDDRLastUpdate(_DDR)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub TextBox151_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox151.Leave
        If IsNumeric(TextBox151.Text) Then
            TextBox151.Text = FormatNumber(TextBox151.Text, 3)
        End If

    End Sub


    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Stop()
        Me.Close()

    End Sub

    Public Function PreFilterMessage(ByRef m As System.Windows.Forms.Message) As Boolean Implements System.Windows.Forms.IMessageFilter.PreFilterMessage
        If (m.Msg >= &H100 And m.Msg <= &H109) Or (m.Msg >= &H200 And m.Msg <= &H20E) Then
            Timer1.Stop()
            Timer1.Start()
        End If
    End Function

    Private Sub dgv_activities_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles dgv_activities.KeyDown
        Dim ado As New com.ADO.ADOMySQLDDR
        Dim deparmentid As Integer
        deparmentid = ado.GetDeparmentID(ComboBox1.Text)
        If e.KeyCode = Keys.F3 Then
            Dim i As Integer
            i = MsgBox("Do you want to load the last report information?", MsgBoxStyle.YesNo, "DDR New form")
            If i = vbYes Then
                'ddr.Active = True
                'ddr.ReportNo = 1
                Dim lastddr As Integer
                'lastddr = ado.GetLastID("DDR_Control", "DDRID")
                lastddr = _DDR.DDRID
                ddrloaded = ado.GetCompleteDDRReport(lastddr - 1)
                For Each item As com.entities.Activities In ddrloaded.DDRReport.Activities.Items
                    If item.Deparment_ID.Equals(deparmentid) Then
                        item.Act_Detail_ID = -1
                        item.DDR_Report_ID = _DDR.DDRID
                        _DDR.DDRReport.Activities.Add(item, True)
                        '_DDR.DDRReport.UrgentsMR.Add(item, True)
                        Dim row As String() = {item.Activity, item.ActivitySpanish, item.Act_Detail_ID}
                        dgv_activities.Rows.Add(row)
                    End If
                Next
            End If
        End If
    End Sub

    Public Sub DisableControlsTab(ByVal TabPage As String, ByVal OptionEnable As Boolean)
        Select Case TabPage
            Case "tp_DDR_Header"
                DisableTabPage(tp_DDR_Header, OptionEnable)
            Case "tp_DDRHrs"
                DisableTabPage(tp_DDRHrs, OptionEnable)
            Case "tp_BITS"
                DisableTabPage(tp_BITS, OptionEnable)
            Case "tp_DrillingString"
                DisableTabPage(tp_DrillingString, OptionEnable)

            Case "tp_BHA"
                DisableTabPage(tp_BHA, OptionEnable)

            Case "tp_Pumps"
                DisableTabPage(tp_Pumps, OptionEnable)

            Case "tpShakers"
                DisableTabPage(tpShakers, OptionEnable)
            Case "tp_Mud"
                DisableTabPage(tp_Mud, OptionEnable)

            Case "tp_MarineInfo"
                DisableTabPage(tp_MarineInfo, OptionEnable)

            Case "tpPOB"
                DisableTabPage(tpPOB, OptionEnable)

            Case "tpEngInfo"
                DisableTabPage(tpEngInfo, OptionEnable)
            Case "tb_RiserProfile"
                DisableTabPage(tb_RiserProfile, OptionEnable)
            Case "tb_SOC"
                DisableTabPage(tb_SOC, OptionEnable)
            Case tb_LogisticTransitLog.Name
                DisableTabPage(tb_LogisticTransitLog, OptionEnable)


        End Select
        Button1.Enabled = OptionEnable
    End Sub

    Private Sub DisableTabPage(ByVal tabPage As TabPage, ByVal OptionEnable As Boolean)
        For i = 0 To tabPage.Controls.Count - 1
            Dim control As Control
            control = tabPage.Controls.Item(i)
            'If control.GetType.Name.Equals("TextBox") Then
            control.Enabled = OptionEnable
            ' End If
            'i = i + 1
        Next
    End Sub

    Public Sub CheckInTab()
        Dim _ado As New com.ADO.ADOMySQLDDR
        Dim tab_tosearch As New com.entities.SystemOpenedTab
        tab_tosearch.Active = True
        tab_tosearch.Tab_sel = TabControl1.SelectedTab.Name
        tab_tosearch.User_sess = _SessionUser.User
        Dim tabfound As com.entities.SystemOpenedTab
        tabfound = _ado.GetTabSelected(tab_tosearch)

        If tabfound.User_sess = "" Then
            Dim userfoundtab As com.entities.SystemOpenedTab
            userfoundtab = _ado.GetTabSelectedUser(tab_tosearch)

            If userfoundtab.User_sess = _SessionUser.User Then
                If _SessionUser.TabController.Count = 0 Then
                    _SessionUser.TabController.Add(userfoundtab)
                End If
                Dim opentab_mod As com.entities.SystemOpenedTab
                opentab_mod = userfoundtab.Clone
                opentab_mod.Tab_sel = TabControl1.SelectedTab.Name
                opentab_mod.timeAccesed = Now()
                _SessionUser.TabController.Modify(opentab_mod)
                Button1.Enabled = True
            Else
                Dim opentab As New com.entities.SystemOpenedTab
                opentab.Tab_sel = TabControl1.SelectedTab.Name
                opentab.timeAccesed = Now()
                opentab.User_sess = _SessionUser.User
                opentab.Active = True
                opentab.ActiveTab = True

                _SessionUser.TabController.Add(opentab, True)
                Button1.Enabled = True
            End If
        Else

            If _SessionUser.User = tabfound.User_sess Then
                _SessionUser.TabController.Add(tabfound)
                Dim opentab_mod As com.entities.SystemOpenedTab
                opentab_mod = tabfound.Clone
                opentab_mod.Tab_sel = TabControl1.SelectedTab.Name
                opentab_mod.timeAccesed = Now()
                _SessionUser.TabController.Modify(opentab_mod)
                Button1.Enabled = True
            Else
                DisableControlsTab(TabControl1.SelectedTab.Name, False)

                MsgBox("This page is using it by  " & tabfound.User_sess.ToUpper & " and it's blocked", MsgBoxStyle.Critical, "This tab is blocked")

            End If
        End If

    End Sub



    Private Sub TabControl1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TabControl1.SelectedIndexChanged
       


    End Sub

    Private Sub dgv_LogTranLogBoat_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_LogTranLogBoat.UserDeletedRow

        Dim ado As New com.ADO.ADOMySQLDDR
        Try
            If Not IsNothing(e.Row.Cells(2).Value) Then
                Dim result As Integer = MsgBox("Do you want to remove the record?", MsgBoxStyle.OkCancel, "Remove record")
                If result = vbOK Then
                    Dim tl As New com.entities.LogisticTransitLog
                    tl.DDR_Report_ID = _DDR.DDRID
                    tl.LTID = e.Row.Cells(2).Value
                    tl.Log = e.Row.Cells(0).Value
                    tl.LogEsp = e.Row.Cells(1).Value
                    tl.Type = "Boat"
                    DDRReport.DDRReport.LogisticTransitLog.Remove(tl)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub dgv_LogTranLogBoat_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_LogTranLogBoat.CellEndEdit

        Dim ado As New com.ADO.ADOMySQLDDR
        'Dim deparmentid As Integer 

        Dim tl As New com.entities.LogisticTransitLog
        tl.DDR_Report_ID = _DDR.DDRID
        tl.Log = dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(0).Value
        tl.LogEsp = dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(1).Value
        tl.Type = "Boat"
        'Modificado 22-Sep-2017
        'Agrega la columna To F1
        Dim chk_c As DataGridViewCheckBoxCell = dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(3)
        tl.ToF1 = chk_c.Value

        If dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(0).Value <> "" Then
            If IsNothing(dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(2).Value) Then
                ado.SaveLogisticTransitLog(tl)
                'DDRReport.DDRReport.LogisticTransitLog.Add(tl)
                dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(2).Value = tl.LTID

            Else
                tl.LTID = dgv_LogTranLogBoat.Rows(e.RowIndex).Cells(2).Value
                ado.UpdateLogisticTransitLog(tl)
            End If
        End If
    End Sub

    Private Sub dgv_LogTranLogHeli_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgv_LogTranLogHeli.CellEndEdit
        Dim ado As New com.ADO.ADOMySQLDDR
        'Dim deparmentid As Integer 

        Dim tl As New com.entities.LogisticTransitLog
        tl.DDR_Report_ID = _DDR.DDRID
        tl.Log = dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(0).Value
        tl.LogEsp = dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(1).Value
        tl.Type = "Helicopter"
        'Modificado 22-Sep-2017
        'Agrega la columna To F1
        Dim chk_c As DataGridViewCheckBoxCell = dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(3)
        tl.ToF1 = chk_c.Value

        If dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(0).Value <> "" Then
            If IsNothing(dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(2).Value) Then
                ado.SaveLogisticTransitLog(tl)
                'DDRReport.DDRReport.LogisticTransitLog.Add(tl)
                dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(2).Value = tl.LTID

            Else
                tl.LTID = dgv_LogTranLogHeli.Rows(e.RowIndex).Cells(2).Value
                ado.UpdateLogisticTransitLog(tl)
            End If
        End If
    End Sub

    Private Sub dgv_LogTranLogHeli_UserDeletedRow(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewRowEventArgs) Handles dgv_LogTranLogHeli.UserDeletedRow
        Dim ado As New com.ADO.ADOMySQLDDR
        Try
            If Not IsNothing(e.Row.Cells(2).Value) Then
                Dim result As Integer = MsgBox("Do you want to remove the record?", MsgBoxStyle.OkCancel, "Remove record")
                If result = vbOK Then
                    Dim tl As New com.entities.LogisticTransitLog
                    tl.DDR_Report_ID = _DDR.DDRID
                    tl.LTID = e.Row.Cells(2).Value
                    tl.Log = e.Row.Cells(0).Value
                    tl.LogEsp = e.Row.Cells(1).Value
                    tl.Type = "Helicopter"
                    DDRReport.DDRReport.LogisticTransitLog.Remove(tl)
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    'Funcion modificada 8-Ago-2017
    ' se modifico la funcion para cargar los nuevos campos de Correctivo,preventivo y WOtoF1
    Private Sub dgv_WorkOrders_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv_WorkOrders.KeyDown
        Dim ado As New com.ADO.ADOMySQLDDR
        Dim deparmentid As Integer
        deparmentid = ado.GetDeparmentID(ComboBox1.Text)
        If e.KeyCode = Keys.F3 Then
            Dim i As Integer
            i = MsgBox("Do you want to load the last report information?", MsgBoxStyle.YesNo, "DDR New form")
            If i = vbYes Then
                'ddr.Active = True
                'ddr.ReportNo = 1
                Dim lastddr As Integer
                'lastddr = ado.GetLastID("DDR_Control", "DDRID")
                lastddr = _DDR.DDRID
                ddrloaded = ado.GetCompleteDDRReport(lastddr - 1)
                For Each item As com.entities.WorkOrder In ddrloaded.DDRReport.WorkOrders.items
                    If item.Deparment_ID.Equals(deparmentid) Then
                        item.WorkOrderID = -1
                        item.DDR_Report_ID = _DDR.DDRID
                        _DDR.DDRReport.WorkOrders.Add(item, True)
                        '_DDR.DDRReport.UrgentsMR.Add(item, True)
                        Dim row As String() = {item.WOPreventive, item.WOCorrective, item.WONumber, item.WODescription, item.WODescriptionSpanish, item.WorkOrderID, item.WOToF1}
                        dgv_WorkOrders.Rows.Add(row)
                    End If
                Next
            End If
        End If
    End Sub

    ' Funcionalidad Agregada 8-Agosto-2017
    ' Al momento de selecionar una opcion de C o P que revise que solo una este seleccionada.

    Private Sub dgv_WorkOrders_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_WorkOrders.CellContentClick
        Dim deparmentid As Integer
        Dim ado As New com.ADO.ADOMySQLDDR
        deparmentid = ado.GetDeparmentID(ComboBox1.Text)
        Try
            If e.ColumnIndex = 0 Or e.ColumnIndex = 1 Then
                Dim chk_selected As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(e.ColumnIndex)
                If e.ColumnIndex = 0 Then
                    Dim chk As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(1)
                    If chk.Value = True Then
                        chk.Value = False
                    End If

                End If
                If e.ColumnIndex = 1 Then
                    Dim chk As DataGridViewCheckBoxCell = dgv_WorkOrders.Rows(e.RowIndex).Cells(0)
                    If chk.Value = True Then
                        chk.Value = False
                    End If
                End If
            End If

        Catch ex As Exception

        End Try
    End Sub


    Private Sub dgv_BITS_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles dgv_BITS.CellEndEdit

    End Sub

    Private Sub txt_f1supername_Leave(sender As Object, e As EventArgs) Handles txt_f1supername.Leave
        If txt_f1superintname.Text = "" Then

        Else
            Dim ADODDR As New com.ADO.ADOMySQLDDR
            _DDR.DDRReport.F1SupervisorName = txt_f1supername.Text
            Try
                ADODDR.UpdateF1SupervisorName(_DDR.DDRReport.DDR_Report_ID, _DDR.DDRReport.F1SupervisorName)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If
    End Sub

    Private Sub txt_f1superintname_Leave(sender As Object, e As EventArgs) Handles txt_f1superintname.Leave
        If txt_f1superintname.Text = "" Then
        Else
            Try
                Dim ADODDR As New com.ADO.ADOMySQLDDR
                _DDR.DDRReport.F1RigSuperintName = txt_f1superintname.Text
                ADODDR.UpdateF1SuperintendentName(_DDR.DDRReport.DDR_Report_ID, _DDR.DDRReport.F1RigSuperintName)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

        End If

    End Sub

    Private Sub TabControl1_TabIndexChanged(sender As Object, e As EventArgs) Handles TabControl1.TabIndexChanged
      
    End Sub

    Private Sub TabControl1_Selected(sender As Object, e As TabControlEventArgs) Handles TabControl1.Selected
        If TabControl1.SelectedTab.Name.Equals(tb_DeparmentAct.Name) Then
            Try
                _SessionUser.TabController.RemoveAllItems(_SessionUser.User)
            Catch ex As Exception

            End Try

        Else
            _SessionUser.TabController.RemoveAllItems(_SessionUser.User)
            CheckInTab()
        End If
    End Sub

    '28 - Oct 2018
    'Se agrega funcionalidad para borrar filas de los controles de Gridview

    Private Sub dgv_BITS_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_BITS.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_BITS, New Point(e.X, e.Y))
            _deleteRowFrom = "BITS"
            _deleteRowIDindex = 12
        End If
    End Sub

    Private Sub DeleteRowToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DeleteRowToolStripMenuItem.Click
        Dim response As Integer
        response = MsgBox("Do you want to delete the row?", MsgBoxStyle.YesNo)
        If response = vbYes Then
            Try
                Dim selectedcell As DataGridViewCell
                selectedcell = CType(RigthOptionMenu.SourceControl, DataGridView).CurrentCell
                Dim ado As New com.ADO.ADOMySQLDDR

                Select Case _deleteRowFrom
                    Case "BITS"
                        Dim bits As New com.entities.BITS
                        bits.BITS_ID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteBITS(bits)

                    Case "StringSurvey"
                        Dim string_survey As New com.entities.DrillString_Survey
                        string_survey.Survey_ID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteStringSurvey(string_survey)
                    Case "Mud"
                        Dim Mud As New com.entities.Mud
                        Mud.MUD_ID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteMud(Mud)
                    Case "Activities"
                        Dim activity As New com.entities.Activities
                        activity.Act_Detail_ID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteActivities(activity)
                    Case "ActivitiesUrgentMRs"
                        Dim urgentmr As New com.entities.UrgentMRs
                        urgentmr.MRUrgentID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteUrgentMR(urgentmr)
                    Case "ActivitiesWorkOrders"
                        Dim workorder As New com.entities.WorkOrder
                        workorder.WorkOrderID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteWorkOrder(workorder)
                    Case "RiserProfile"
                        Dim riserprofile As New com.entities.RiserProfile
                        riserprofile.IDRiserProfile = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteRiserProfile(riserprofile)
                    Case "Logistic"
                        Dim logistic As New com.entities.LogisticTransitLog
                        logistic.LTID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeleteLogisticTransitLog(logistic)
                    Case "PUMR"
                        Dim pumr As New com.entities.PUMR
                        pumr.PRUM_ID = CType(RigthOptionMenu.SourceControl, DataGridView).Rows(selectedcell.RowIndex).Cells(_deleteRowIDindex).Value
                        ado.DeletePUMR(pumr)
                End Select

                CType(RigthOptionMenu.SourceControl, DataGridView).Rows.RemoveAt(selectedcell.RowIndex)

                _deleteRowFrom = ""
                _deleteRowIDindex = -1

            Catch ex As Exception

            Finally
                _deleteRowFrom = ""
                _deleteRowIDindex = -1

            End Try
            
            'Dim ddrhrs As New com.entities.DDRHrs
            'ddrhrs.Detail_HR_ID = dgv_DDRHrs.Rows(selectedcell.RowIndex).Cells(6).Value

            'ado.DeleteDDHrs(ddrhrs)
            'dgv_DDRHrs.Rows.RemoveAt(selectedcell.RowIndex)
        End If
    End Sub

    Private Sub dgv_String_Survey_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_String_Survey.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_String_Survey, New Point(e.X, e.Y))
            _deleteRowFrom = "StringSurvey"
            _deleteRowIDindex = 6
        End If
    End Sub

    Private Sub dgv_Mud_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_Mud.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_Mud, New Point(e.X, e.Y))
            _deleteRowFrom = "Mud"
            _deleteRowIDindex = 12
        End If
    End Sub

    Private Sub dgv_activities_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_activities.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_activities, New Point(e.X, e.Y))
            _deleteRowFrom = "Activities"
            _deleteRowIDindex = 2
        End If
    End Sub

    Private Sub dgv_UrgentsMRs_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_UrgentsMRs.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_UrgentsMRs, New Point(e.X, e.Y))
            _deleteRowFrom = "ActivitiesUrgentMRs"
            _deleteRowIDindex = 4
        End If
    End Sub

    Private Sub dgv_WorkOrders_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_WorkOrders.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_WorkOrders, New Point(e.X, e.Y))
            _deleteRowFrom = "ActivitiesWorkOrders"
            _deleteRowIDindex = 5
        End If
    End Sub

    Private Sub dgv_RiserProfile_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_RiserProfile.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_RiserProfile, New Point(e.X, e.Y))
            _deleteRowFrom = "RiserProfile"
            _deleteRowIDindex = 14
        End If
    End Sub

    Private Sub dgv_LogTranLogBoat_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_LogTranLogBoat.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_LogTranLogBoat, New Point(e.X, e.Y))
            _deleteRowFrom = "Logistic"
            _deleteRowIDindex = 2
        End If
    End Sub

    Private Sub dgv_LogTranLogHeli_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_LogTranLogHeli.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_LogTranLogHeli, New Point(e.X, e.Y))
            _deleteRowFrom = "Logistic"
            _deleteRowIDindex = 2
        End If
    End Sub

    Private Sub dgv_PUMR_MouseDown(sender As Object, e As MouseEventArgs) Handles dgv_PUMR.MouseDown
        If e.Button = MouseButtons.Right Then
            RigthOptionMenu.Show(dgv_PUMR, New Point(e.X, e.Y))
            _deleteRowFrom = "PUMR"
            _deleteRowIDindex = 4
        End If
    End Sub
End Class
Public Enum FormModes
    Insert = 0
    Edit = 1
    View = 2
End Enum