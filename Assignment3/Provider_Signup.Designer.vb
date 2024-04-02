<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Provider_Signup
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Panel1 = New Panel()
        designlabel1 = New Label()
        taskmakerrbtn = New Button()
        Panel2 = New Panel()
        login_btn = New Button()
        showcnfpassword_cb = New CheckBox()
        showpassword_cb = New CheckBox()
        otp_tb = New TextBox()
        register_btn = New Button()
        sendOTP_btn = New Button()
        error_label = New Label()
        email_tb = New TextBox()
        cnfpassword_tb = New TextBox()
        password_tb = New TextBox()
        name_tb = New TextBox()
        subheadlabel = New Label()
        Label1 = New Label()
        back_btn = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.Provider_Logo
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(designlabel1)
        Panel1.Controls.Add(taskmakerrbtn)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(425, 673)
        Panel1.TabIndex = 0
        ' 
        ' designlabel1
        ' 
        designlabel1.BackColor = Color.Transparent
        designlabel1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        designlabel1.Location = New Point(41, 508)
        designlabel1.Name = "designlabel1"
        designlabel1.Size = New Size(337, 36)
        designlabel1.TabIndex = 3
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
        taskmakerrbtn.TabIndex = 2
        taskmakerrbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.Controls.Add(login_btn)
        Panel2.Controls.Add(showcnfpassword_cb)
        Panel2.Controls.Add(showpassword_cb)
        Panel2.Controls.Add(otp_tb)
        Panel2.Controls.Add(register_btn)
        Panel2.Controls.Add(sendOTP_btn)
        Panel2.Controls.Add(error_label)
        Panel2.Controls.Add(email_tb)
        Panel2.Controls.Add(cnfpassword_tb)
        Panel2.Controls.Add(password_tb)
        Panel2.Controls.Add(name_tb)
        Panel2.Controls.Add(subheadlabel)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(back_btn)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(425, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(709, 673)
        Panel2.TabIndex = 1
        ' 
        ' login_btn
        ' 
        login_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        login_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        login_btn.FlatAppearance.BorderSize = 0
        login_btn.FlatStyle = FlatStyle.Flat
        login_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        login_btn.ForeColor = Color.White
        login_btn.Location = New Point(549, 23)
        login_btn.Name = "login_btn"
        login_btn.Size = New Size(135, 35)
        login_btn.TabIndex = 1
        login_btn.Text = "Log In"
        login_btn.UseVisualStyleBackColor = False
        ' 
        ' showcnfpassword_cb
        ' 
        showcnfpassword_cb.AutoSize = True
        showcnfpassword_cb.Font = New Font("Segoe UI", 8F)
        showcnfpassword_cb.Location = New Point(479, 357)
        showcnfpassword_cb.Name = "showcnfpassword_cb"
        showcnfpassword_cb.Size = New Size(55, 17)
        showcnfpassword_cb.TabIndex = 42
        showcnfpassword_cb.Text = "Show"
        showcnfpassword_cb.UseVisualStyleBackColor = True
        ' 
        ' showpassword_cb
        ' 
        showpassword_cb.AutoSize = True
        showpassword_cb.Font = New Font("Segoe UI", 8F)
        showpassword_cb.Location = New Point(479, 309)
        showpassword_cb.Name = "showpassword_cb"
        showpassword_cb.Size = New Size(55, 17)
        showpassword_cb.TabIndex = 41
        showpassword_cb.Text = "Show"
        showpassword_cb.UseVisualStyleBackColor = True
        ' 
        ' otp_tb
        ' 
        otp_tb.Font = New Font("Segoe UI", 10F)
        otp_tb.ForeColor = SystemColors.WindowText
        otp_tb.Location = New Point(55, 461)
        otp_tb.Name = "otp_tb"
        otp_tb.PlaceholderText = "OTP"
        otp_tb.Size = New Size(418, 25)
        otp_tb.TabIndex = 22
        ' 
        ' register_btn
        ' 
        register_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        register_btn.FlatAppearance.BorderSize = 0
        register_btn.FlatStyle = FlatStyle.Flat
        register_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        register_btn.ForeColor = Color.White
        register_btn.Location = New Point(205, 505)
        register_btn.Name = "register_btn"
        register_btn.Size = New Size(135, 35)
        register_btn.TabIndex = 23
        register_btn.Text = "Register"
        register_btn.UseVisualStyleBackColor = False
        ' 
        ' sendOTP_btn
        ' 
        sendOTP_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        sendOTP_btn.FlatAppearance.BorderSize = 0
        sendOTP_btn.FlatStyle = FlatStyle.Flat
        sendOTP_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendOTP_btn.ForeColor = Color.White
        sendOTP_btn.Location = New Point(205, 405)
        sendOTP_btn.Name = "sendOTP_btn"
        sendOTP_btn.Size = New Size(135, 35)
        sendOTP_btn.TabIndex = 21
        sendOTP_btn.Text = "Send OTP"
        sendOTP_btn.UseVisualStyleBackColor = False
        ' 
        ' error_label
        ' 
        error_label.AutoSize = True
        error_label.Font = New Font("Segoe UI", 8F)
        error_label.ForeColor = Color.Red
        error_label.Location = New Point(55, 380)
        error_label.Name = "error_label"
        error_label.Size = New Size(32, 13)
        error_label.TabIndex = 20
        error_label.Text = "error"
        ' 
        ' email_tb
        ' 
        email_tb.Font = New Font("Segoe UI", 10F)
        email_tb.ForeColor = SystemColors.WindowText
        email_tb.Location = New Point(55, 254)
        email_tb.Name = "email_tb"
        email_tb.PlaceholderText = "Email"
        email_tb.Size = New Size(418, 25)
        email_tb.TabIndex = 17
        ' 
        ' cnfpassword_tb
        ' 
        cnfpassword_tb.Font = New Font("Segoe UI", 10F)
        cnfpassword_tb.ForeColor = SystemColors.WindowText
        cnfpassword_tb.Location = New Point(55, 352)
        cnfpassword_tb.Name = "cnfpassword_tb"
        cnfpassword_tb.PasswordChar = "*"c
        cnfpassword_tb.PlaceholderText = "Confirm Password"
        cnfpassword_tb.Size = New Size(418, 25)
        cnfpassword_tb.TabIndex = 19
        ' 
        ' password_tb
        ' 
        password_tb.Font = New Font("Segoe UI", 10F)
        password_tb.ForeColor = SystemColors.WindowText
        password_tb.Location = New Point(55, 304)
        password_tb.Name = "password_tb"
        password_tb.PasswordChar = "*"c
        password_tb.PlaceholderText = "Password"
        password_tb.Size = New Size(418, 25)
        password_tb.TabIndex = 18
        ' 
        ' name_tb
        ' 
        name_tb.Font = New Font("Segoe UI", 10F)
        name_tb.ForeColor = SystemColors.WindowText
        name_tb.Location = New Point(55, 209)
        name_tb.Name = "name_tb"
        name_tb.PlaceholderText = "Name"
        name_tb.Size = New Size(418, 25)
        name_tb.TabIndex = 16
        ' 
        ' subheadlabel
        ' 
        subheadlabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        subheadlabel.Location = New Point(52, 184)
        subheadlabel.Name = "subheadlabel"
        subheadlabel.Size = New Size(217, 22)
        subheadlabel.TabIndex = 15
        subheadlabel.Text = "Create your provider profile"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(52, 128)
        Label1.Name = "Label1"
        Label1.Size = New Size(258, 34)
        Label1.TabIndex = 14
        Label1.Text = "Create an account"
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
        back_btn.TabIndex = 12
        back_btn.UseVisualStyleBackColor = True
        ' 
        ' Provider_Signup
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1134, 673)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Provider_Signup"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Provider_Signup"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents designlabel1 As Label
    Friend WithEvents taskmakerrbtn As Button
    Friend WithEvents otp_tb As TextBox
    Friend WithEvents register_btn As Button
    Friend WithEvents sendOTP_btn As Button
    Friend WithEvents error_label As Label
    Friend WithEvents email_tb As TextBox
    Friend WithEvents cnfpassword_tb As TextBox
    Friend WithEvents password_tb As TextBox
    Friend WithEvents name_tb As TextBox
    Friend WithEvents subheadlabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents back_btn As Button
    Friend WithEvents showcnfpassword_cb As CheckBox
    Friend WithEvents showpassword_cb As CheckBox
    Friend WithEvents login_btn As Button
End Class
