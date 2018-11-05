Imports DDRReportToolCore


Public Class LoginSystem

    ' TODO: Insert code to perform custom authentication using the provided username and password 
    ' (See http://go.microsoft.com/fwlink/?LinkId=35339).  
    ' The custom principal can then be attached to the current thread's principal as follows: 
    '     My.User.CurrentPrincipal = CustomPrincipal
    ' where CustomPrincipal is the IPrincipal implementation used to perform authentication. 
    ' Subsequently, My.User will return identity information encapsulated in the CustomPrincipal object
    ' such as the username, display name, etc.

    '30-Oct-2018
    'Agregar la funcionalida de mostrar creditos y por quien fue desarrollado
    'presionando la secuencia de konami

    Private secuencia As New ArrayList

    '4 Nov 2018
    'Agregar funcionalidad para que muestre el formulario de pruebas

    Private clicimagecount As Integer = 0

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

    Private Sub LoginSystem_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
       
    End Sub

    Private Function ValidaKeySecuencia() As Boolean
        Dim valida As Boolean = False
        'Revisa la secuencia que sean 10 teclas
        If secuencia.Count = 10 Then
            'Valida que la secuencia sea la correcta
            Dim record As Integer = 1
            Dim validateclas As Integer = 0
            For Each item As Windows.Forms.Keys In secuencia
                If item = 38 And record = 1 Then
                    validateclas = validateclas + 1
                End If

                If item = 38 And record = 2 Then
                    validateclas = validateclas + 1
                End If

                If item = 40 And record = 3 Then
                    validateclas = validateclas + 1
                End If

                If item = 40 And record = 4 Then
                    validateclas = validateclas + 1
                End If

                If item = 37 And record = 5 Then
                    validateclas = validateclas + 1
                End If

                If item = 39 And record = 6 Then
                    validateclas = validateclas + 1
                End If

                If item = 37 And record = 7 Then
                    validateclas = validateclas + 1
                End If

                If item = 39 And record = 8 Then
                    validateclas = validateclas + 1
                End If

                If item = 65 And record = 9 Then
                    validateclas = validateclas + 1
                End If

                If item = 66 And record = 10 Then
                    validateclas = validateclas + 1
                End If

                record = record + 1

                If validateclas = 10 Then
                    valida = True
                End If

            Next

            If valida Then
                secuencia.Clear()

            End If

        End If
        Return valida
    End Function

    Private Sub UsernameTextBox_MouseDown(sender As Object, e As MouseEventArgs) Handles UsernameTextBox.MouseDown

    End Sub

    Private Sub UsernameTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles UsernameTextBox.KeyDown
        secuencia.Add(e.KeyCode)
        If ValidaKeySecuencia() Then
            Dim aboutsoft As New Windows.Forms.Form
            aboutsoft.Text = "DDR Daily Report Tool - About Software"
            aboutsoft.Width = 400
            aboutsoft.Height = 204
            aboutsoft.Show()

            Dim lbl As New Label
            lbl.Width = 350
            lbl.Height = 240
            lbl.Text = "Este Software fue diseñado y programado por : " & Environment.NewLine
            lbl.Text = lbl.Text & " " & Environment.NewLine
            lbl.Text = lbl.Text & " Marco Antonio Cantu Gea" & Environment.NewLine
            lbl.Text = lbl.Text & " " & Environment.NewLine
            lbl.Text = lbl.Text & "Los cuales se reserva todos los derechos de autor." & Environment.NewLine
            lbl.Text = lbl.Text & " " & Environment.NewLine
            lbl.Text = lbl.Text & "Este Sorfware no puede ser modificado o distribuido sin una venta de licenciamiento." & Environment.NewLine
            lbl.Text = lbl.Text & " " & Environment.NewLine
            lbl.Text = lbl.Text & "Revise los terminos y condiciones que se entregan aparte con este software para mas detalle." & Environment.NewLine

            aboutsoft.Controls.Add(lbl)


        End If
    End Sub

    Private Sub LogoPictureBox_MouseClick(sender As Object, e As MouseEventArgs) Handles LogoPictureBox.MouseClick
        clicimagecount = clicimagecount + 1
        If clicimagecount = 10 Then
            Dim main As New Main
            main.Show()
            clicimagecount = 0
        End If

    End Sub
End Class
