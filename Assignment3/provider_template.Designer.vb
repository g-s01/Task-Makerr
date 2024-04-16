<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class provider_template
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
        SplitContainer1 = New SplitContainer()
        history_navi_btn = New Button()
        Chats_Navi_btn = New Button()
        Label2 = New Label()
        Label1 = New Label()
        logout_btn = New Button()
        Needhelp_btn = New Button()
        Feedback_btn = New Button()
        Profile_Navi_btn = New Button()
        Notifications_Navi_btn = New Button()
        Appointments_Navi_btn = New Button()
        Dashboard_Navi_btn = New Button()
        PictureBox2 = New PictureBox()
        PictureBox1 = New PictureBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.BackColor = Color.White
        SplitContainer1.Panel1.Controls.Add(history_navi_btn)
        SplitContainer1.Panel1.Controls.Add(Chats_Navi_btn)
        SplitContainer1.Panel1.Controls.Add(Label2)
        SplitContainer1.Panel1.Controls.Add(Label1)
        SplitContainer1.Panel1.Controls.Add(logout_btn)
        SplitContainer1.Panel1.Controls.Add(Needhelp_btn)
        SplitContainer1.Panel1.Controls.Add(Feedback_btn)
        SplitContainer1.Panel1.Controls.Add(Profile_Navi_btn)
        SplitContainer1.Panel1.Controls.Add(Notifications_Navi_btn)
        SplitContainer1.Panel1.Controls.Add(Appointments_Navi_btn)
        SplitContainer1.Panel1.Controls.Add(Dashboard_Navi_btn)
        SplitContainer1.Panel1.Controls.Add(PictureBox2)
        SplitContainer1.Panel1.Controls.Add(PictureBox1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.BackColor = SystemColors.ActiveBorder
        SplitContainer1.Size = New Size(1132, 666)
        SplitContainer1.SplitterDistance = 288
        SplitContainer1.SplitterWidth = 1
        SplitContainer1.TabIndex = 1
        ' 
        ' history_navi_btn
        ' 
        history_navi_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        history_navi_btn.BackColor = SystemColors.Control
        history_navi_btn.FlatAppearance.BorderSize = 0
        history_navi_btn.FlatStyle = FlatStyle.Flat
        history_navi_btn.Font = New Font("Microsoft YaHei", 10.2F)
        history_navi_btn.Image = My.Resources.Resources.chats
        history_navi_btn.ImageAlign = ContentAlignment.MiddleLeft
        history_navi_btn.Location = New Point(3, 352)
        history_navi_btn.Name = "history_navi_btn"
        history_navi_btn.Padding = New Padding(15, 0, 0, 0)
        history_navi_btn.Size = New Size(282, 36)
        history_navi_btn.TabIndex = 12
        history_navi_btn.Text = "     Past Appointments"
        history_navi_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        history_navi_btn.UseVisualStyleBackColor = False
        ' 
        ' Chats_Navi_btn
        ' 
        Chats_Navi_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Chats_Navi_btn.BackColor = SystemColors.Control
        Chats_Navi_btn.FlatAppearance.BorderSize = 0
        Chats_Navi_btn.FlatStyle = FlatStyle.Flat
        Chats_Navi_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Chats_Navi_btn.Image = My.Resources.Resources.chats
        Chats_Navi_btn.ImageAlign = ContentAlignment.MiddleLeft
        Chats_Navi_btn.Location = New Point(3, 307)
        Chats_Navi_btn.Name = "Chats_Navi_btn"
        Chats_Navi_btn.Padding = New Padding(15, 0, 0, 0)
        Chats_Navi_btn.Size = New Size(282, 36)
        Chats_Navi_btn.TabIndex = 11
        Chats_Navi_btn.Text = "     Chats"
        Chats_Navi_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        Chats_Navi_btn.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DimGray
        Label2.Location = New Point(22, 470)
        Label2.Name = "Label2"
        Label2.Size = New Size(75, 23)
        Label2.TabIndex = 10
        Label2.Text = "Support"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.DimGray
        Label1.Location = New Point(22, 100)
        Label1.Name = "Label1"
        Label1.Size = New Size(57, 23)
        Label1.TabIndex = 9
        Label1.Text = "Menu"
        ' 
        ' logout_btn
        ' 
        logout_btn.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        logout_btn.BackColor = SystemColors.Control
        logout_btn.FlatAppearance.BorderSize = 0
        logout_btn.FlatStyle = FlatStyle.Flat
        logout_btn.Font = New Font("Microsoft YaHei", 10.2F)
        logout_btn.ForeColor = Color.Red
        logout_btn.Image = My.Resources.Resources.Vector
        logout_btn.ImageAlign = ContentAlignment.MiddleLeft
        logout_btn.Location = New Point(3, 619)
        logout_btn.Name = "logout_btn"
        logout_btn.Padding = New Padding(15, 0, 0, 0)
        logout_btn.Size = New Size(282, 36)
        logout_btn.TabIndex = 8
        logout_btn.Text = "     Logout"
        logout_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        logout_btn.UseVisualStyleBackColor = False
        ' 
        ' Needhelp_btn
        ' 
        Needhelp_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Needhelp_btn.BackColor = SystemColors.Control
        Needhelp_btn.FlatAppearance.BorderSize = 0
        Needhelp_btn.FlatStyle = FlatStyle.Flat
        Needhelp_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Needhelp_btn.ImageAlign = ContentAlignment.MiddleLeft
        Needhelp_btn.Location = New Point(3, 509)
        Needhelp_btn.Name = "Needhelp_btn"
        Needhelp_btn.Padding = New Padding(15, 0, 0, 0)
        Needhelp_btn.Size = New Size(282, 36)
        Needhelp_btn.TabIndex = 7
        Needhelp_btn.Text = "Need Help?"
        Needhelp_btn.TextAlign = ContentAlignment.MiddleLeft
        Needhelp_btn.UseVisualStyleBackColor = False
        ' 
        ' Feedback_btn
        ' 
        Feedback_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Feedback_btn.BackColor = SystemColors.Control
        Feedback_btn.FlatAppearance.BorderSize = 0
        Feedback_btn.FlatStyle = FlatStyle.Flat
        Feedback_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Feedback_btn.ImageAlign = ContentAlignment.MiddleLeft
        Feedback_btn.Location = New Point(3, 551)
        Feedback_btn.Name = "Feedback_btn"
        Feedback_btn.Padding = New Padding(15, 0, 0, 0)
        Feedback_btn.Size = New Size(282, 36)
        Feedback_btn.TabIndex = 6
        Feedback_btn.Text = "Give Feedback"
        Feedback_btn.TextAlign = ContentAlignment.MiddleLeft
        Feedback_btn.UseVisualStyleBackColor = False
        ' 
        ' Profile_Navi_btn
        ' 
        Profile_Navi_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Profile_Navi_btn.BackColor = SystemColors.Control
        Profile_Navi_btn.FlatAppearance.BorderSize = 0
        Profile_Navi_btn.FlatStyle = FlatStyle.Flat
        Profile_Navi_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Profile_Navi_btn.Image = My.Resources.Resources.settings
        Profile_Navi_btn.ImageAlign = ContentAlignment.MiddleLeft
        Profile_Navi_btn.Location = New Point(3, 265)
        Profile_Navi_btn.Name = "Profile_Navi_btn"
        Profile_Navi_btn.Padding = New Padding(15, 0, 0, 0)
        Profile_Navi_btn.Size = New Size(282, 36)
        Profile_Navi_btn.TabIndex = 5
        Profile_Navi_btn.Text = "     Profile"
        Profile_Navi_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        Profile_Navi_btn.UseVisualStyleBackColor = False
        ' 
        ' Notifications_Navi_btn
        ' 
        Notifications_Navi_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Notifications_Navi_btn.BackColor = SystemColors.Control
        Notifications_Navi_btn.FlatAppearance.BorderSize = 0
        Notifications_Navi_btn.FlatStyle = FlatStyle.Flat
        Notifications_Navi_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Notifications_Navi_btn.Image = My.Resources.Resources.notifications
        Notifications_Navi_btn.ImageAlign = ContentAlignment.MiddleLeft
        Notifications_Navi_btn.Location = New Point(3, 223)
        Notifications_Navi_btn.Name = "Notifications_Navi_btn"
        Notifications_Navi_btn.Padding = New Padding(15, 0, 0, 0)
        Notifications_Navi_btn.Size = New Size(282, 36)
        Notifications_Navi_btn.TabIndex = 4
        Notifications_Navi_btn.Text = "     Notifications"
        Notifications_Navi_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        Notifications_Navi_btn.UseVisualStyleBackColor = False
        ' 
        ' Appointments_Navi_btn
        ' 
        Appointments_Navi_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Appointments_Navi_btn.BackColor = SystemColors.Control
        Appointments_Navi_btn.FlatAppearance.BorderSize = 0
        Appointments_Navi_btn.FlatStyle = FlatStyle.Flat
        Appointments_Navi_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Appointments_Navi_btn.Image = My.Resources.Resources.appointments
        Appointments_Navi_btn.ImageAlign = ContentAlignment.MiddleLeft
        Appointments_Navi_btn.Location = New Point(3, 181)
        Appointments_Navi_btn.Name = "Appointments_Navi_btn"
        Appointments_Navi_btn.Padding = New Padding(15, 0, 0, 0)
        Appointments_Navi_btn.Size = New Size(282, 36)
        Appointments_Navi_btn.TabIndex = 3
        Appointments_Navi_btn.Text = "      Appointments"
        Appointments_Navi_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        Appointments_Navi_btn.UseVisualStyleBackColor = False
        ' 
        ' Dashboard_Navi_btn
        ' 
        Dashboard_Navi_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Dashboard_Navi_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Dashboard_Navi_btn.FlatAppearance.BorderSize = 0
        Dashboard_Navi_btn.FlatStyle = FlatStyle.Flat
        Dashboard_Navi_btn.Font = New Font("Microsoft YaHei", 10.2F)
        Dashboard_Navi_btn.Image = My.Resources.Resources.home
        Dashboard_Navi_btn.ImageAlign = ContentAlignment.MiddleLeft
        Dashboard_Navi_btn.Location = New Point(3, 139)
        Dashboard_Navi_btn.Name = "Dashboard_Navi_btn"
        Dashboard_Navi_btn.Padding = New Padding(15, 0, 0, 0)
        Dashboard_Navi_btn.Size = New Size(282, 36)
        Dashboard_Navi_btn.TabIndex = 2
        Dashboard_Navi_btn.Text = "     Dashboard"
        Dashboard_Navi_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        Dashboard_Navi_btn.UseVisualStyleBackColor = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Task_Makerr
        PictureBox2.Location = New Point(88, 26)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(175, 24)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.TM_Logo_1
        PictureBox1.Location = New Point(25, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(56, 56)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' provider_template
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1132, 666)
        Controls.Add(SplitContainer1)
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "provider_template"
        StartPosition = FormStartPosition.CenterScreen
        Text = "provider_template"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Chats_Navi_btn As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents logout_btn As Button
    Friend WithEvents Needhelp_btn As Button
    Friend WithEvents Feedback_btn As Button
    Friend WithEvents Profile_Navi_btn As Button
    Friend WithEvents Notifications_Navi_btn As Button
    Friend WithEvents Appointments_Navi_btn As Button
    Friend WithEvents Dashboard_Navi_btn As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents history_navi_btn As Button
End Class
