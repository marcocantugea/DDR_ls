<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ConfigurationForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.BrowseDataBase = New System.Windows.Forms.OpenFileDialog
        Me.txtDataBasePath = New System.Windows.Forms.TextBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtEmailUser = New System.Windows.Forms.TextBox
        Me.Button2 = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtEmailPass = New System.Windows.Forms.TextBox
        Me.Button3 = New System.Windows.Forms.Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtEmailServer = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtPort = New System.Windows.Forms.TextBox
        Me.Button4 = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.DDRTemplate = New System.Windows.Forms.OpenFileDialog
        Me.txtDDRTemplate = New System.Windows.Forms.TextBox
        Me.Button5 = New System.Windows.Forms.Button
        Me.Button6 = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtActiTemplate = New System.Windows.Forms.TextBox
        Me.Button7 = New System.Windows.Forms.Button
        Me.Button8 = New System.Windows.Forms.Button
        Me.ActivitiesTemplate = New System.Windows.Forms.OpenFileDialog
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtWellName = New System.Windows.Forms.TextBox
        Me.Button9 = New System.Windows.Forms.Button
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtMaintMode = New System.Windows.Forms.TextBox
        Me.Button10 = New System.Windows.Forms.Button
        Me.Button11 = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.txtLDAPServer = New System.Windows.Forms.TextBox
        Me.Button12 = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtDomain = New System.Windows.Forms.TextBox
        Me.Button13 = New System.Windows.Forms.Button
        Me.Button14 = New System.Windows.Forms.Button
        Me.Button15 = New System.Windows.Forms.Button
        Me.Button16 = New System.Windows.Forms.Button
        Me.Button17 = New System.Windows.Forms.Button
        Me.Button18 = New System.Windows.Forms.Button
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(133, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "MS Acess Data Base Path"
        '
        'BrowseDataBase
        '
        Me.BrowseDataBase.FileName = "BrowseDataBase"
        '
        'txtDataBasePath
        '
        Me.txtDataBasePath.Location = New System.Drawing.Point(16, 32)
        Me.txtDataBasePath.Name = "txtDataBasePath"
        Me.txtDataBasePath.ReadOnly = True
        Me.txtDataBasePath.Size = New System.Drawing.Size(326, 20)
        Me.txtDataBasePath.TabIndex = 1
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(348, 30)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Browse"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 158)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(97, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Email Configuration"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 179)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(57, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Email User"
        '
        'txtEmailUser
        '
        Me.txtEmailUser.Location = New System.Drawing.Point(15, 195)
        Me.txtEmailUser.Name = "txtEmailUser"
        Me.txtEmailUser.Size = New System.Drawing.Size(162, 20)
        Me.txtEmailUser.TabIndex = 5
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(429, 30)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 23)
        Me.Button2.TabIndex = 6
        Me.Button2.Text = "Save"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(187, 179)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(106, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Email User Password"
        '
        'txtEmailPass
        '
        Me.txtEmailPass.Location = New System.Drawing.Point(190, 195)
        Me.txtEmailPass.Name = "txtEmailPass"
        Me.txtEmailPass.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtEmailPass.Size = New System.Drawing.Size(152, 20)
        Me.txtEmailPass.TabIndex = 8
        Me.txtEmailPass.UseSystemPasswordChar = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(353, 193)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 9
        Me.Button3.Text = "Save"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(13, 225)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(66, 13)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Email Server"
        '
        'txtEmailServer
        '
        Me.txtEmailServer.Location = New System.Drawing.Point(16, 246)
        Me.txtEmailServer.Name = "txtEmailServer"
        Me.txtEmailServer.Size = New System.Drawing.Size(165, 20)
        Me.txtEmailServer.TabIndex = 11
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(187, 225)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(26, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Port"
        '
        'txtPort
        '
        Me.txtPort.Location = New System.Drawing.Point(190, 246)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(62, 20)
        Me.txtPort.TabIndex = 13
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(267, 244)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(75, 23)
        Me.Button4.TabIndex = 14
        Me.Button4.Text = "Save"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 284)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(113, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "DDR Format Template"
        '
        'DDRTemplate
        '
        Me.DDRTemplate.FileName = "OpenFileDialog1"
        '
        'txtDDRTemplate
        '
        Me.txtDDRTemplate.Location = New System.Drawing.Point(16, 302)
        Me.txtDDRTemplate.Name = "txtDDRTemplate"
        Me.txtDDRTemplate.ReadOnly = True
        Me.txtDDRTemplate.Size = New System.Drawing.Size(330, 20)
        Me.txtDDRTemplate.TabIndex = 16
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(352, 300)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 23)
        Me.Button5.TabIndex = 17
        Me.Button5.Text = "Browse"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(433, 300)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(75, 23)
        Me.Button6.TabIndex = 18
        Me.Button6.Text = "Save"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 330)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(131, 13)
        Me.Label8.TabIndex = 19
        Me.Label8.Text = "Activities Format Template"
        '
        'txtActiTemplate
        '
        Me.txtActiTemplate.Location = New System.Drawing.Point(16, 350)
        Me.txtActiTemplate.Name = "txtActiTemplate"
        Me.txtActiTemplate.ReadOnly = True
        Me.txtActiTemplate.Size = New System.Drawing.Size(326, 20)
        Me.txtActiTemplate.TabIndex = 20
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(353, 348)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(75, 23)
        Me.Button7.TabIndex = 21
        Me.Button7.Text = "Browse"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(434, 348)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 23)
        Me.Button8.TabIndex = 22
        Me.Button8.Text = "Save"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'ActivitiesTemplate
        '
        Me.ActivitiesTemplate.FileName = "OpenFileDialog1"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(13, 380)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(92, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "Active Well Name"
        '
        'txtWellName
        '
        Me.txtWellName.Location = New System.Drawing.Point(16, 403)
        Me.txtWellName.Name = "txtWellName"
        Me.txtWellName.Size = New System.Drawing.Size(165, 20)
        Me.txtWellName.TabIndex = 24
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(187, 402)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 23)
        Me.Button9.TabIndex = 25
        Me.Button9.Text = "Save"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(13, 444)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(118, 13)
        Me.Label10.TabIndex = 26
        Me.Label10.Text = "Set Maintenance Mode"
        '
        'txtMaintMode
        '
        Me.txtMaintMode.Location = New System.Drawing.Point(137, 441)
        Me.txtMaintMode.Name = "txtMaintMode"
        Me.txtMaintMode.Size = New System.Drawing.Size(44, 20)
        Me.txtMaintMode.TabIndex = 27
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(187, 441)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 23)
        Me.Button10.TabIndex = 28
        Me.Button10.Text = "Save"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button11
        '
        Me.Button11.Location = New System.Drawing.Point(370, 398)
        Me.Button11.Name = "Button11"
        Me.Button11.Size = New System.Drawing.Size(116, 66)
        Me.Button11.TabIndex = 29
        Me.Button11.Text = "Return to Login"
        Me.Button11.UseVisualStyleBackColor = True
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(13, 59)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(112, 13)
        Me.Label11.TabIndex = 30
        Me.Label11.Text = "LDAP Server for users"
        '
        'txtLDAPServer
        '
        Me.txtLDAPServer.Location = New System.Drawing.Point(16, 80)
        Me.txtLDAPServer.Name = "txtLDAPServer"
        Me.txtLDAPServer.Size = New System.Drawing.Size(326, 20)
        Me.txtLDAPServer.TabIndex = 31
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(348, 77)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 23)
        Me.Button12.TabIndex = 32
        Me.Button12.Text = "Save"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(118, 13)
        Me.Label12.TabIndex = 33
        Me.Label12.Text = "Domain to search users"
        '
        'txtDomain
        '
        Me.txtDomain.Location = New System.Drawing.Point(16, 128)
        Me.txtDomain.Name = "txtDomain"
        Me.txtDomain.Size = New System.Drawing.Size(326, 20)
        Me.txtDomain.TabIndex = 34
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(348, 126)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 23)
        Me.Button13.TabIndex = 35
        Me.Button13.Text = "Save"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(510, 30)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 23)
        Me.Button14.TabIndex = 36
        Me.Button14.Text = "Open"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(510, 300)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 23)
        Me.Button15.TabIndex = 37
        Me.Button15.Text = "Open"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(510, 348)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(75, 23)
        Me.Button16.TabIndex = 38
        Me.Button16.Text = "Open"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(429, 77)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(96, 70)
        Me.Button17.TabIndex = 39
        Me.Button17.Text = "Test LDAP Conf"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(473, 190)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(96, 76)
        Me.Button18.TabIndex = 40
        Me.Button18.Text = "Test email conf"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Checked = True
        Me.CheckBox1.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBox1.Location = New System.Drawing.Point(352, 244)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(112, 17)
        Me.CheckBox1.TabIndex = 41
        Me.CheckBox1.Text = "Send Notifications"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ConfigurationForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(592, 493)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.Button18)
        Me.Controls.Add(Me.Button17)
        Me.Controls.Add(Me.Button16)
        Me.Controls.Add(Me.Button15)
        Me.Controls.Add(Me.Button14)
        Me.Controls.Add(Me.Button13)
        Me.Controls.Add(Me.txtDomain)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Button12)
        Me.Controls.Add(Me.txtLDAPServer)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Button11)
        Me.Controls.Add(Me.Button10)
        Me.Controls.Add(Me.txtMaintMode)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Button9)
        Me.Controls.Add(Me.txtWellName)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Button8)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.txtActiTemplate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Button6)
        Me.Controls.Add(Me.Button5)
        Me.Controls.Add(Me.txtDDRTemplate)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtEmailServer)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.txtEmailPass)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.txtEmailUser)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtDataBasePath)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ConfigurationForm"
        Me.Text = "Sysem configuration"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BrowseDataBase As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtDataBasePath As System.Windows.Forms.TextBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtEmailUser As System.Windows.Forms.TextBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtEmailPass As System.Windows.Forms.TextBox
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtEmailServer As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents DDRTemplate As System.Windows.Forms.OpenFileDialog
    Friend WithEvents txtDDRTemplate As System.Windows.Forms.TextBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtActiTemplate As System.Windows.Forms.TextBox
    Friend WithEvents Button7 As System.Windows.Forms.Button
    Friend WithEvents Button8 As System.Windows.Forms.Button
    Friend WithEvents ActivitiesTemplate As System.Windows.Forms.OpenFileDialog
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtWellName As System.Windows.Forms.TextBox
    Friend WithEvents Button9 As System.Windows.Forms.Button
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtMaintMode As System.Windows.Forms.TextBox
    Friend WithEvents Button10 As System.Windows.Forms.Button
    Friend WithEvents Button11 As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtLDAPServer As System.Windows.Forms.TextBox
    Friend WithEvents Button12 As System.Windows.Forms.Button
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtDomain As System.Windows.Forms.TextBox
    Friend WithEvents Button13 As System.Windows.Forms.Button
    Friend WithEvents Button14 As System.Windows.Forms.Button
    Friend WithEvents Button15 As System.Windows.Forms.Button
    Friend WithEvents Button16 As System.Windows.Forms.Button
    Friend WithEvents Button17 As System.Windows.Forms.Button
    Friend WithEvents Button18 As System.Windows.Forms.Button
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
