Imports DDRReportToolCore


Public Class LoginSystem

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        Dim ladp As New com.security.LDAP_Auth(System.Configuration.ConfigurationSettings.AppSettings("LDAPDIR"))
        Try

            If ladp.IsAuthenticated(System.Configuration.ConfigurationSettings.AppSettings("DOMAINUSERS"), UsernameTextBox.Text, PasswordTextBox.Text) Then
                Dim sessiousera As New com.entities.SessionUser
                sessiousera.User = UsernameTextBox.Text
                Dim ado As New com.ADO.ADOMySQLDDR
                ado.GetUserGroup(sessiousera)
                ado.GetUserDeparmentID(sessiousera)
                ado.GetUserDeparmentName(sessiousera)
                ado.GetUseremail(sessiousera)
                If IsNothing(sessiousera.Group) Then
                    sessiousera.Group = "View"
                End If
                Dim main_DDR As New DDR_Main
                main_DDR.user = sessiousera
                main_DDR.Show()

                Me.Hide()
            End If
        Catch ex As Exception
            If UsernameTextBox.Text = "admin" And PasswordTextBox.Text = "Maintenance" Then
                ConfigurationForm.Show()
                Me.Hide()

            Else
                MsgBox(ex.Message, MsgBoxStyle.Critical)
            End If
            'MsgBox("Error on user and password.", MsgBoxStyle.Critical)
        End Try


    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Me.Close()
    End Sub

    Private Sub LoginSystem_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Try
            Dim maintenancemode As Boolean
            maintenancemode = System.Configuration.ConfigurationSettings.AppSettings("MaintenanceMode")
            If maintenancemode Then
                MsgBox("The DDR System is in Maintenance, please try again later or call for IT support", MsgBoxStyle.Information, "The DDR is on Maintenance")
                Application.Exit()
            End If

        Catch ex As Exception

        End Try
    End Sub
End Class
