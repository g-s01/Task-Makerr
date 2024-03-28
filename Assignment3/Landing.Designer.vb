<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Landing
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
        admin_ll = New LinkLabel()
        provider_btn = New Button()
        user_btn = New Button()
        subheadlabel = New Label()
        headlabel = New Label()
        login_btn = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.Landing_Logo
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(designlabel1)
        Panel1.Controls.Add(taskmakerrbtn)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4, 5, 4, 5)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(607, 1018)
        Panel1.TabIndex = 1
        ' 
        ' designlabel1
        ' 
        designlabel1.BackColor = Color.Transparent
        designlabel1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        designlabel1.Location = New Point(64, 763)
        designlabel1.Margin = New Padding(4, 0, 4, 0)
        designlabel1.Name = "designlabel1"
        designlabel1.Size = New Size(481, 60)
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
        taskmakerrbtn.Location = New Point(36, 42)
        taskmakerrbtn.Margin = New Padding(4, 5, 4, 5)
        taskmakerrbtn.Name = "taskmakerrbtn"
        taskmakerrbtn.Size = New Size(80, 93)
        taskmakerrbtn.TabIndex = 0
        taskmakerrbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(admin_ll)
        Panel2.Controls.Add(provider_btn)
        Panel2.Controls.Add(user_btn)
        Panel2.Controls.Add(subheadlabel)
        Panel2.Controls.Add(headlabel)
        Panel2.Controls.Add(login_btn)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(607, 0)
        Panel2.Margin = New Padding(4, 5, 4, 5)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(970, 1018)
        Panel2.TabIndex = 2
        ' 
        ' admin_ll
        ' 
        admin_ll.ActiveLinkColor = Color.FromArgb(CByte(255), CByte(128), CByte(255))
        admin_ll.AutoSize = True
        admin_ll.Font = New Font("Segoe UI", 10F)
        admin_ll.LinkColor = Color.DimGray
        admin_ll.Location = New Point(83, 527)
        admin_ll.Margin = New Padding(4, 0, 4, 0)
        admin_ll.Name = "admin_ll"
        admin_ll.Size = New Size(144, 28)
        admin_ll.TabIndex = 12
        admin_ll.TabStop = True
        admin_ll.Text = "Login as admin"
        admin_ll.VisitedLinkColor = Color.DimGray
        ' 
        ' provider_btn
        ' 
        provider_btn.BackColor = Color.White
        provider_btn.FlatAppearance.BorderSize = 0
        provider_btn.FlatStyle = FlatStyle.Flat
        provider_btn.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        provider_btn.ForeColor = Color.Gray
        provider_btn.Location = New Point(83, 428)
        provider_btn.Margin = New Padding(4, 5, 4, 5)
        provider_btn.Name = "provider_btn"
        provider_btn.Padding = New Padding(17, 0, 0, 0)
        provider_btn.Size = New Size(334, 67)
        provider_btn.TabIndex = 11
        provider_btn.Text = "Business Account"
        provider_btn.TextAlign = ContentAlignment.MiddleLeft
        provider_btn.UseVisualStyleBackColor = False
        ' 
        ' user_btn
        ' 
        user_btn.BackColor = Color.White
        user_btn.FlatAppearance.BorderSize = 0
        user_btn.FlatStyle = FlatStyle.Flat
        user_btn.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        user_btn.ForeColor = Color.Gray
        user_btn.Location = New Point(83, 352)
        user_btn.Margin = New Padding(4, 5, 4, 5)
        user_btn.Name = "user_btn"
        user_btn.Padding = New Padding(17, 0, 0, 0)
        user_btn.Size = New Size(334, 67)
        user_btn.TabIndex = 10
        user_btn.Text = "User Account"
        user_btn.TextAlign = ContentAlignment.MiddleLeft
        user_btn.UseVisualStyleBackColor = False
        ' 
        ' subheadlabel
        ' 
        subheadlabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        subheadlabel.Location = New Point(81, 307)
        subheadlabel.Margin = New Padding(4, 0, 4, 0)
        subheadlabel.Name = "subheadlabel"
        subheadlabel.Size = New Size(310, 37)
        subheadlabel.TabIndex = 5
        subheadlabel.Text = "Register as"
        ' 
        ' headlabel
        ' 
        headlabel.Font = New Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        headlabel.Location = New Point(79, 213)
        headlabel.Margin = New Padding(4, 0, 4, 0)
        headlabel.Name = "headlabel"
        headlabel.Size = New Size(369, 57)
        headlabel.TabIndex = 4
        headlabel.Text = "Create an account"
        ' 
        ' login_btn
        ' 
        login_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        login_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        login_btn.FlatAppearance.BorderSize = 0
        login_btn.FlatStyle = FlatStyle.Flat
        login_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        login_btn.ForeColor = Color.White
        login_btn.Location = New Point(741, 38)
        login_btn.Margin = New Padding(4, 5, 4, 5)
        login_btn.Name = "login_btn"
        login_btn.Size = New Size(193, 58)
        login_btn.TabIndex = 3
        login_btn.Text = "Log In"
        login_btn.UseVisualStyleBackColor = False
        ' 
        ' Landing
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1577, 1018)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Landing"
        StartPosition = FormStartPosition.CenterScreen
        Text = "User_Signup"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents designlabel1 As Label
    Friend WithEvents taskmakerrbtn As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents headlabel As Label
    Friend WithEvents login_btn As Button
    Friend WithEvents subheadlabel As Label
    Friend WithEvents user_btn As Button
    Friend WithEvents admin_ll As LinkLabel
    Friend WithEvents provider_btn As Button

End Class
