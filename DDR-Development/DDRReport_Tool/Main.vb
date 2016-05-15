
Imports Access = Microsoft.Office.Interop.Access
Imports DDRReportToolCore

Public Class Main

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'Dim ladp As New com.security.LDAP_Auth("LDAP://192.168.2.2/CN=ldapgrm4,CN=Sites,CN=Users,DC=grm4,DC=com")
        MsgBox(System.Security.Principal.WindowsIdentity.GetCurrent().Name)
        Dim ladp As New com.security.LDAP_Auth("LDAP://192.168.2.2")
        If ladp.IsAuthenticated("grm4.com", "marco.cantu", "01Jex81t2") Then
            MsgBox("marco.cantu is aut")
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim ddrform As New DDR_From
        ddrform.FormMode = FormModes.View
        ddrform.Show()

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim oAccess As Access.Application

        oAccess = New Access.ApplicationClass()
        oAccess.Visible = True


        oAccess.OpenCurrentDatabase(filepath:="C:\Users\IT LA MURALLA IV\Documents\Marco.Cantu\Software Development\Digital DDR\Development\reports\reports.accdb")
        oAccess.DoCmd.SelectObject(ObjectType:=Access.AcObjectType.acReport, ObjectName:="DDR_Report", InDatabaseWindow:=True)
        oAccess.DoCmd.OpenReport("DDR_Report", Access.AcView.acViewPreview)

        'oAccess.DoCmd.PrintOut(PrintRange:=Access.AcPrintRange.acSelection, Copies:=1, CollateCopies:=False)

        'oAccess.Quit()
        oAccess = Nothing

    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click

        'Dim ddrcontrol As New com.entities.DDRControl

        'ddrcontrol.ReportDate = Today.ToString("MM/dd/yyyy")
        'ddrcontrol.Description = "this is a test"
        ''ddrcontrol.Active = True
        'ddrcontrol.ReportNo = 8939

        'Dim adoDDr As New com.ADO.ADODDR
        'Try
        '    adoDDr.SaveDDRControl(ddrcontrol)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try


        Dim ddrreport As New com.entities.DDRReport
        ddrreport.Operator_s = "test"
        ddrreport.Country = "test"
        ddrreport.ProposedTD = "test"
        ddrreport.TVD = "test"
        ddrreport.Yest_Rot_Hrs = "test"

        'Dim adoDDr As New com.ADO.ADODDR
        'Try
        '    adoDDr.SaveDDRReport(ddrreport)
        'Catch ex As Exception
        '    MsgBox(ex.ToString)
        'End Try

    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        Dim ddrmainform As New DDR_Main
        ddrmainform.Show()

    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        
    End Sub
End Class
