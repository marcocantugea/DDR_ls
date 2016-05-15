<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class closeddrmaintmode
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
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.lbltimetoclose = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.timercloseapp = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(408, 36)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "The system has been entered in mainteanance mode," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & " the DDR application will be c" & _
            "losed in:"
        '
        'lbltimetoclose
        '
        Me.lbltimetoclose.AutoSize = True
        Me.lbltimetoclose.Font = New System.Drawing.Font("Microsoft Sans Serif", 43.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltimetoclose.ForeColor = System.Drawing.Color.Red
        Me.lbltimetoclose.Location = New System.Drawing.Point(36, 70)
        Me.lbltimetoclose.Name = "lbltimetoclose"
        Me.lbltimetoclose.Size = New System.Drawing.Size(173, 67)
        Me.lbltimetoclose.TabIndex = 1
        Me.lbltimetoclose.Text = "00:00"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 43.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Red
        Me.Label2.Location = New System.Drawing.Point(215, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(231, 67)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Minutes"
        '
        'timercloseapp
        '
        Me.timercloseapp.Interval = 60000
        '
        'Button1
        '
        Me.Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.Location = New System.Drawing.Point(38, 149)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(395, 42)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Close DDR"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'closeddrmaintmode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(458, 199)
        Me.ControlBox = False
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lbltimetoclose)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name = "closeddrmaintmode"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Closing DDR for Maintnance Mode"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lbltimetoclose As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents timercloseapp As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
