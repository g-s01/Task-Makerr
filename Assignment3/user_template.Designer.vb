<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class user_template
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
        chats_btn = New Button()
        Label2 = New Label()
        Label1 = New Label()
        logout_btn = New Button()
        help_btn = New Button()
        feedback_btn = New Button()
        profile_btn = New Button()
        appointments_btn = New Button()
        search_btn = New Button()
        home_btn = New Button()
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
        SplitContainer1.Panel1.Controls.Add(chats_btn)
        SplitContainer1.Panel1.Controls.Add(Label2)
        SplitContainer1.Panel1.Controls.Add(Label1)
        SplitContainer1.Panel1.Controls.Add(logout_btn)
        SplitContainer1.Panel1.Controls.Add(help_btn)
        SplitContainer1.Panel1.Controls.Add(feedback_btn)
        SplitContainer1.Panel1.Controls.Add(profile_btn)
        SplitContainer1.Panel1.Controls.Add(appointments_btn)
        SplitContainer1.Panel1.Controls.Add(search_btn)
        SplitContainer1.Panel1.Controls.Add(home_btn)
        SplitContainer1.Panel1.Controls.Add(PictureBox2)
        SplitContainer1.Panel1.Controls.Add(PictureBox1)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.BackColor = SystemColors.ActiveBorder
        SplitContainer1.Size = New Size(1132, 666)
        SplitContainer1.SplitterDistance = 288
        SplitContainer1.SplitterWidth = 1
        SplitContainer1.TabIndex = 0
        ' 
        ' chats_btn
        ' 
        chats_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        chats_btn.BackColor = SystemColors.Control
        chats_btn.FlatAppearance.BorderSize = 0
        chats_btn.FlatStyle = FlatStyle.Flat
        chats_btn.Font = New Font("Microsoft YaHei", 10.2F)
        chats_btn.Image = My.Resources.Resources.chats
        chats_btn.ImageAlign = ContentAlignment.MiddleLeft
        chats_btn.Location = New Point(3, 307)
        chats_btn.Name = "chats_btn"
        chats_btn.Padding = New Padding(15, 0, 0, 0)
        chats_btn.Size = New Size(282, 36)
        chats_btn.TabIndex = 11
        chats_btn.Text = "     Chats"
        chats_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        chats_btn.UseVisualStyleBackColor = False
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
        ' help_btn
        ' 
        help_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        help_btn.BackColor = SystemColors.Control
        help_btn.FlatAppearance.BorderSize = 0
        help_btn.FlatStyle = FlatStyle.Flat
        help_btn.Font = New Font("Microsoft YaHei", 10.2F)
        help_btn.ImageAlign = ContentAlignment.MiddleLeft
        help_btn.Location = New Point(3, 509)
        help_btn.Name = "help_btn"
        help_btn.Padding = New Padding(15, 0, 0, 0)
        help_btn.Size = New Size(282, 36)
        help_btn.TabIndex = 7
        help_btn.Text = "Need Help?"
        help_btn.TextAlign = ContentAlignment.MiddleLeft
        help_btn.UseVisualStyleBackColor = False
        ' 
        ' feedback_btn
        ' 
        feedback_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        feedback_btn.BackColor = SystemColors.Control
        feedback_btn.FlatAppearance.BorderSize = 0
        feedback_btn.FlatStyle = FlatStyle.Flat
        feedback_btn.Font = New Font("Microsoft YaHei", 10.2F)
        feedback_btn.ImageAlign = ContentAlignment.MiddleLeft
        feedback_btn.Location = New Point(3, 551)
        feedback_btn.Name = "feedback_btn"
        feedback_btn.Padding = New Padding(15, 0, 0, 0)
        feedback_btn.Size = New Size(282, 36)
        feedback_btn.TabIndex = 6
        feedback_btn.Text = "Give Feedback"
        feedback_btn.TextAlign = ContentAlignment.MiddleLeft
        feedback_btn.UseVisualStyleBackColor = False
        ' 
        ' profile_btn
        ' 
        profile_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        profile_btn.BackColor = SystemColors.Control
        profile_btn.FlatAppearance.BorderSize = 0
        profile_btn.FlatStyle = FlatStyle.Flat
        profile_btn.Font = New Font("Microsoft YaHei", 10.2F)
        profile_btn.Image = My.Resources.Resources.settings
        profile_btn.ImageAlign = ContentAlignment.MiddleLeft
        profile_btn.Location = New Point(3, 265)
        profile_btn.Name = "profile_btn"
        profile_btn.Padding = New Padding(15, 0, 0, 0)
        profile_btn.Size = New Size(282, 36)
        profile_btn.TabIndex = 5
        profile_btn.Text = "     Profile"
        profile_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        profile_btn.UseVisualStyleBackColor = False
        ' 
        ' appointments_btn
        ' 
        appointments_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        appointments_btn.BackColor = SystemColors.Control
        appointments_btn.FlatAppearance.BorderSize = 0
        appointments_btn.FlatStyle = FlatStyle.Flat
        appointments_btn.Font = New Font("Microsoft YaHei", 10.2F)
        appointments_btn.Image = My.Resources.Resources.appointments
        appointments_btn.ImageAlign = ContentAlignment.MiddleLeft
        appointments_btn.Location = New Point(3, 223)
        appointments_btn.Name = "appointments_btn"
        appointments_btn.Padding = New Padding(15, 0, 0, 0)
        appointments_btn.Size = New Size(282, 36)
        appointments_btn.TabIndex = 4
        appointments_btn.Text = "     My Appointments"
        appointments_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        appointments_btn.UseVisualStyleBackColor = False
        ' 
        ' search_btn
        ' 
        search_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        search_btn.BackColor = SystemColors.Control
        search_btn.FlatAppearance.BorderSize = 0
        search_btn.FlatStyle = FlatStyle.Flat
        search_btn.Font = New Font("Microsoft YaHei", 10.2F)
        search_btn.Image = My.Resources.Resources.search
        search_btn.ImageAlign = ContentAlignment.MiddleLeft
        search_btn.Location = New Point(3, 181)
        search_btn.Name = "search_btn"
        search_btn.Padding = New Padding(15, 0, 0, 0)
        search_btn.Size = New Size(282, 36)
        search_btn.TabIndex = 3
        search_btn.Text = "     Search"
        search_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        search_btn.UseVisualStyleBackColor = False
        ' 
        ' home_btn
        ' 
        home_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        home_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        home_btn.FlatAppearance.BorderSize = 0
        home_btn.FlatStyle = FlatStyle.Flat
        home_btn.Font = New Font("Microsoft YaHei", 10.2F)
        home_btn.Image = My.Resources.Resources.home
        home_btn.ImageAlign = ContentAlignment.MiddleLeft
        home_btn.Location = New Point(3, 139)
        home_btn.Name = "home_btn"
        home_btn.Padding = New Padding(15, 0, 0, 0)
        home_btn.Size = New Size(282, 36)
        home_btn.TabIndex = 2
        home_btn.Text = "     Home"
        home_btn.TextImageRelation = TextImageRelation.ImageBeforeText
        home_btn.UseVisualStyleBackColor = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Task_Makerr
        PictureBox2.Location = New Point(88, 26)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(178, 28)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.TM_Logo_1
        PictureBox1.Location = New Point(25, 10)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(57, 57)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' user_template
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1132, 666)
        Controls.Add(SplitContainer1)
        Font = New Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedToolWindow
        Name = "user_template"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Form1"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents home_btn As Button
    Friend WithEvents profile_btn As Button
    Friend WithEvents appointments_btn As Button
    Friend WithEvents search_btn As Button
    Friend WithEvents logout_btn As Button
    Friend WithEvents help_btn As Button
    Friend WithEvents feedback_btn As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents chats_btn As Button

End Class
