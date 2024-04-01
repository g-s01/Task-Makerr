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
        Button5 = New Button()
        Label2 = New Label()
        Label1 = New Label()
        logout_btn = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Profile_Navi_btn = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
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
        SplitContainer1.Panel1.Controls.Add(Button5)
        SplitContainer1.Panel1.Controls.Add(Label2)
        SplitContainer1.Panel1.Controls.Add(Label1)
        SplitContainer1.Panel1.Controls.Add(logout_btn)
        SplitContainer1.Panel1.Controls.Add(Button6)
        SplitContainer1.Panel1.Controls.Add(Button7)
        SplitContainer1.Panel1.Controls.Add(Profile_Navi_btn)
        SplitContainer1.Panel1.Controls.Add(Button3)
        SplitContainer1.Panel1.Controls.Add(Button2)
        SplitContainer1.Panel1.Controls.Add(Button1)
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
        ' Button5
        ' 
        Button5.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button5.BackColor = SystemColors.Control
        Button5.FlatAppearance.BorderSize = 0
        Button5.FlatStyle = FlatStyle.Flat
        Button5.Font = New Font("Microsoft YaHei", 10.2F)
        Button5.Image = My.Resources.Resources.chats
        Button5.ImageAlign = ContentAlignment.MiddleLeft
        Button5.Location = New Point(3, 307)
        Button5.Name = "Button5"
        Button5.Padding = New Padding(15, 0, 0, 0)
        Button5.Size = New Size(282, 36)
        Button5.TabIndex = 11
        Button5.Text = "     Chats"
        Button5.TextImageRelation = TextImageRelation.ImageBeforeText
        Button5.UseVisualStyleBackColor = False
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = Color.DimGray
        Label2.Location = New Point(22, 470)
        Label2.Name = "Label2"
        Label2.Size = New Size(92, 28)
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
        Label1.Size = New Size(71, 28)
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
        ' Button6
        ' 
        Button6.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button6.BackColor = SystemColors.Control
        Button6.FlatAppearance.BorderSize = 0
        Button6.FlatStyle = FlatStyle.Flat
        Button6.Font = New Font("Microsoft YaHei", 10.2F)
        Button6.ImageAlign = ContentAlignment.MiddleLeft
        Button6.Location = New Point(3, 509)
        Button6.Name = "Button6"
        Button6.Padding = New Padding(15, 0, 0, 0)
        Button6.Size = New Size(282, 36)
        Button6.TabIndex = 7
        Button6.Text = "Need Help?"
        Button6.TextAlign = ContentAlignment.MiddleLeft
        Button6.UseVisualStyleBackColor = False
        ' 
        ' Button7
        ' 
        Button7.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button7.BackColor = SystemColors.Control
        Button7.FlatAppearance.BorderSize = 0
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Microsoft YaHei", 10.2F)
        Button7.ImageAlign = ContentAlignment.MiddleLeft
        Button7.Location = New Point(3, 551)
        Button7.Name = "Button7"
        Button7.Padding = New Padding(15, 0, 0, 0)
        Button7.Size = New Size(282, 36)
        Button7.TabIndex = 6
        Button7.Text = "Give Feedback"
        Button7.TextAlign = ContentAlignment.MiddleLeft
        Button7.UseVisualStyleBackColor = False
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
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button3.BackColor = SystemColors.Control
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Microsoft YaHei", 10.2F)
        Button3.Image = My.Resources.Resources.notifications
        Button3.ImageAlign = ContentAlignment.MiddleLeft
        Button3.Location = New Point(3, 223)
        Button3.Name = "Button3"
        Button3.Padding = New Padding(15, 0, 0, 0)
        Button3.Size = New Size(282, 36)
        Button3.TabIndex = 4
        Button3.Text = "     Notifications"
        Button3.TextImageRelation = TextImageRelation.ImageBeforeText
        Button3.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button2.BackColor = SystemColors.Control
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Microsoft YaHei", 10.2F)
        Button2.Image = My.Resources.Resources.appointments
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(3, 181)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(15, 0, 0, 0)
        Button2.Size = New Size(282, 36)
        Button2.TabIndex = 3
        Button2.Text = "      Appointments"
        Button2.TextImageRelation = TextImageRelation.ImageBeforeText
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Microsoft YaHei", 10.2F)
        Button1.Image = My.Resources.Resources.home
        Button1.ImageAlign = ContentAlignment.MiddleLeft
        Button1.Location = New Point(3, 139)
        Button1.Name = "Button1"
        Button1.Padding = New Padding(15, 0, 0, 0)
        Button1.Size = New Size(282, 36)
        Button1.TabIndex = 2
        Button1.Text = "     Dashboard"
        Button1.TextImageRelation = TextImageRelation.ImageBeforeText
        Button1.UseVisualStyleBackColor = False
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
    Friend WithEvents Button5 As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents logout_btn As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Profile_Navi_btn As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
