<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin_Login
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
        Panel1 = New Panel()
        Label1 = New Label()
        designlabel1 = New Label()
        taskmakerrbtn = New Button()
        Panel2 = New Panel()
        showpassword_cb = New CheckBox()
        error_label = New Label()
        back_btn = New Button()
        login_btn = New Button()
        password_tb = New TextBox()
        headlabel = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.Landing_Logo1
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(designlabel1)
        Panel1.Controls.Add(taskmakerrbtn)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(425, 673)
        Panel1.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        Label1.BackColor = Color.Transparent
        Label1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(41, 508)
        Label1.Name = "Label1"
        Label1.Size = New Size(337, 36)
        Label1.TabIndex = 2
        Label1.Text = "Get thousands of services at one click"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' designlabel1
        ' 
        designlabel1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        designlabel1.BackColor = Color.Transparent
        designlabel1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        designlabel1.Location = New Point(41, 794)
        designlabel1.Name = "designlabel1"
        designlabel1.Size = New Size(562, 36)
        designlabel1.TabIndex = 1
        designlabel1.Text = "Get thousands of services at one click"
        designlabel1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' taskmakerrbtn
        ' 
        taskmakerrbtn.BackColor = Color.Transparent
        taskmakerrbtn.BackgroundImage = My.Resources.Resources.TM_Logo_1
        taskmakerrbtn.BackgroundImageLayout = ImageLayout.Stretch
        taskmakerrbtn.FlatAppearance.BorderSize = 0
        taskmakerrbtn.FlatStyle = FlatStyle.Flat
        taskmakerrbtn.Location = New Point(25, 25)
        taskmakerrbtn.Name = "taskmakerrbtn"
        taskmakerrbtn.Size = New Size(56, 56)
        taskmakerrbtn.TabIndex = 0
        taskmakerrbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(showpassword_cb)
        Panel2.Controls.Add(error_label)
        Panel2.Controls.Add(back_btn)
        Panel2.Controls.Add(login_btn)
        Panel2.Controls.Add(password_tb)
        Panel2.Controls.Add(headlabel)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(425, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(709, 673)
        Panel2.TabIndex = 4
        ' 
        ' showpassword_cb
        ' 
        showpassword_cb.AutoSize = True
        showpassword_cb.Font = New Font("Segoe UI", 8F)
        showpassword_cb.Location = New Point(479, 265)
        showpassword_cb.Name = "showpassword_cb"
        showpassword_cb.Size = New Size(75, 25)
        showpassword_cb.TabIndex = 46
        showpassword_cb.Text = "Show"
        showpassword_cb.UseVisualStyleBackColor = True
        ' 
        ' error_label
        ' 
        error_label.AutoSize = True
        error_label.Font = New Font("Segoe UI", 8F)
        error_label.ForeColor = Color.Red
        error_label.Location = New Point(55, 285)
        error_label.Name = "error_label"
        error_label.Size = New Size(45, 21)
        error_label.TabIndex = 27
        error_label.Text = "error"
        ' 
        ' back_btn
        ' 
        back_btn.BackgroundImage = My.Resources.Resources.backbtn
        back_btn.BackgroundImageLayout = ImageLayout.Stretch
        back_btn.FlatAppearance.BorderSize = 0
        back_btn.FlatStyle = FlatStyle.Flat
        back_btn.Location = New Point(21, 22)
        back_btn.Name = "back_btn"
        back_btn.Size = New Size(84, 35)
        back_btn.TabIndex = 26
        back_btn.UseVisualStyleBackColor = True
        ' 
        ' login_btn
        ' 
        login_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        login_btn.FlatAppearance.BorderSize = 0
        login_btn.FlatStyle = FlatStyle.Flat
        login_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        login_btn.ForeColor = Color.White
        login_btn.Location = New Point(201, 318)
        login_btn.Name = "login_btn"
        login_btn.Size = New Size(135, 35)
        login_btn.TabIndex = 25
        login_btn.Text = "Login"
        login_btn.UseVisualStyleBackColor = False
        ' 
        ' password_tb
        ' 
        password_tb.Font = New Font("Segoe UI", 10F)
        password_tb.ForeColor = SystemColors.WindowText
        password_tb.Location = New Point(55, 257)
        password_tb.Name = "password_tb"
        password_tb.PasswordChar = "*"c
        password_tb.PlaceholderText = "Password"
        password_tb.Size = New Size(418, 34)
        password_tb.TabIndex = 20
        ' 
        ' headlabel
        ' 
        headlabel.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        headlabel.Location = New Point(55, 128)
        headlabel.Name = "headlabel"
        headlabel.Size = New Size(258, 85)
        headlabel.TabIndex = 14
        headlabel.Text = "Log in with" & vbCrLf & "Admin password"
        ' 
        ' Admin_Login
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1134, 673)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Admin_Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Admin_Login"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents designlabel1 As Label
    Friend WithEvents taskmakerrbtn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents password_tb As TextBox
    Friend WithEvents user_btn As Button
    Friend WithEvents headlabel As Label
    Friend WithEvents login_btn As Button
    Friend WithEvents back_btn As Button
    Friend WithEvents error_label As Label
    Friend WithEvents showpassword_cb As CheckBox
End Class
