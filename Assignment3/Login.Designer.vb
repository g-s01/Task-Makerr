<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Login
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
        LinkLabel1 = New LinkLabel()
        showpassword_cb = New CheckBox()
        error_label = New Label()
        email_tb = New TextBox()
        password_tb = New TextBox()
        admin_ll = New LinkLabel()
        provider_btn = New Button()
        user_btn = New Button()
        subheadlabel = New Label()
        headlabel = New Label()
        register_btn = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.Landing_Logo1
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(designlabel1)
        Panel1.Controls.Add(taskmakerrbtn)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(425, 673)
        Panel1.TabIndex = 2
        ' 
        ' designlabel1
        ' 
        designlabel1.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        designlabel1.BackColor = Color.Transparent
        designlabel1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        designlabel1.Location = New Point(41, 508)
        designlabel1.Name = "designlabel1"
        designlabel1.Size = New Size(337, 36)
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
        Panel2.Controls.Add(LinkLabel1)
        Panel2.Controls.Add(showpassword_cb)
        Panel2.Controls.Add(error_label)
        Panel2.Controls.Add(email_tb)
        Panel2.Controls.Add(password_tb)
        Panel2.Controls.Add(admin_ll)
        Panel2.Controls.Add(provider_btn)
        Panel2.Controls.Add(user_btn)
        Panel2.Controls.Add(subheadlabel)
        Panel2.Controls.Add(headlabel)
        Panel2.Controls.Add(register_btn)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(425, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(709, 673)
        Panel2.TabIndex = 3
        ' 
        ' LinkLabel1
        ' 
        LinkLabel1.ActiveLinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(255))
        LinkLabel1.AutoSize = True
        LinkLabel1.Font = New Font("Segoe UI", 10F)
        LinkLabel1.LinkColor = Color.DimGray
        LinkLabel1.Location = New Point(374, 340)
        LinkLabel1.Name = "LinkLabel1"
        LinkLabel1.Size = New Size(135, 23)
        LinkLabel1.TabIndex = 46
        LinkLabel1.TabStop = True
        LinkLabel1.Text = "Forgot Password"
        LinkLabel1.VisitedLinkColor = Color.DimGray
        ' 
        ' showpassword_cb
        ' 
        showpassword_cb.AutoSize = True
        showpassword_cb.Font = New Font("Segoe UI", 8F)
        showpassword_cb.Location = New Point(481, 315)
        showpassword_cb.Name = "showpassword_cb"
        showpassword_cb.Size = New Size(64, 23)
        showpassword_cb.TabIndex = 45
        showpassword_cb.Text = "Show"
        showpassword_cb.UseVisualStyleBackColor = True
        ' 
        ' error_label
        ' 
        error_label.AutoSize = True
        error_label.Font = New Font("Segoe UI", 8F)
        error_label.ForeColor = Color.Red
        error_label.Location = New Point(57, 335)
        error_label.Name = "error_label"
        error_label.Size = New Size(39, 19)
        error_label.TabIndex = 24
        error_label.Text = "error"
        ' 
        ' email_tb
        ' 
        email_tb.Font = New Font("Segoe UI", 10F)
        email_tb.ForeColor = SystemColors.WindowText
        email_tb.Location = New Point(57, 260)
        email_tb.Name = "email_tb"
        email_tb.PlaceholderText = "Email"
        email_tb.Size = New Size(418, 30)
        email_tb.TabIndex = 19
        ' 
        ' password_tb
        ' 
        password_tb.Font = New Font("Segoe UI", 10F)
        password_tb.ForeColor = SystemColors.WindowText
        password_tb.Location = New Point(57, 307)
        password_tb.Name = "password_tb"
        password_tb.PasswordChar = "*"c
        password_tb.PlaceholderText = "Password"
        password_tb.Size = New Size(418, 30)
        password_tb.TabIndex = 20
        ' 
        ' admin_ll
        ' 
        admin_ll.ActiveLinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(255))
        admin_ll.AutoSize = True
        admin_ll.Font = New Font("Segoe UI", 10F)
        admin_ll.LinkColor = Color.DimGray
        admin_ll.Location = New Point(211, 418)
        admin_ll.Name = "admin_ll"
        admin_ll.Size = New Size(126, 23)
        admin_ll.TabIndex = 23
        admin_ll.TabStop = True
        admin_ll.Text = "Login as admin"
        admin_ll.VisitedLinkColor = Color.DimGray
        ' 
        ' provider_btn
        ' 
        provider_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        provider_btn.FlatAppearance.BorderSize = 0
        provider_btn.FlatStyle = FlatStyle.Flat
        provider_btn.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        provider_btn.ForeColor = Color.White
        provider_btn.Location = New Point(115, 370)
        provider_btn.Name = "provider_btn"
        provider_btn.Size = New Size(135, 35)
        provider_btn.TabIndex = 21
        provider_btn.Text = "Provider"
        provider_btn.UseVisualStyleBackColor = False
        ' 
        ' user_btn
        ' 
        user_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        user_btn.FlatAppearance.BorderSize = 0
        user_btn.FlatStyle = FlatStyle.Flat
        user_btn.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        user_btn.ForeColor = Color.White
        user_btn.Location = New Point(275, 370)
        user_btn.Name = "user_btn"
        user_btn.Size = New Size(135, 35)
        user_btn.TabIndex = 22
        user_btn.Text = "User"
        user_btn.UseVisualStyleBackColor = False
        ' 
        ' subheadlabel
        ' 
        subheadlabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        subheadlabel.Location = New Point(57, 235)
        subheadlabel.Name = "subheadlabel"
        subheadlabel.Size = New Size(217, 22)
        subheadlabel.TabIndex = 15
        subheadlabel.Text = "Login as"
        ' 
        ' headlabel
        ' 
        headlabel.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        headlabel.Location = New Point(55, 179)
        headlabel.Name = "headlabel"
        headlabel.Size = New Size(258, 34)
        headlabel.TabIndex = 14
        headlabel.Text = "Log into your account"
        ' 
        ' register_btn
        ' 
        register_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        register_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        register_btn.FlatAppearance.BorderSize = 0
        register_btn.FlatStyle = FlatStyle.Flat
        register_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        register_btn.ForeColor = Color.White
        register_btn.Location = New Point(549, 23)
        register_btn.Name = "register_btn"
        register_btn.Size = New Size(135, 35)
        register_btn.TabIndex = 13
        register_btn.Text = "Register"
        register_btn.UseVisualStyleBackColor = False
        ' 
        ' Login
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1134, 673)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "Login"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents designlabel1 As Label
    Friend WithEvents taskmakerrbtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents admin_ll As LinkLabel
    Friend WithEvents provider_btn As Button
    Friend WithEvents user_btn As Button
    Friend WithEvents subheadlabel As Label
    Friend WithEvents headlabel As Label
    Friend WithEvents register_btn As Button
    Friend WithEvents email_tb As TextBox
    Friend WithEvents password_tb As TextBox
    Friend WithEvents error_label As Label
    Friend WithEvents showpassword_cb As CheckBox
    Friend WithEvents LinkLabel1 As LinkLabel
End Class
