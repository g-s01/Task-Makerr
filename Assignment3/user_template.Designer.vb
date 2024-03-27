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
        Button5 = New Button()
        Label2 = New Label()
        Label1 = New Label()
        Button8 = New Button()
        Button6 = New Button()
        Button7 = New Button()
        Button4 = New Button()
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
        SplitContainer1.Panel1.Controls.Add(Button8)
        SplitContainer1.Panel1.Controls.Add(Button6)
        SplitContainer1.Panel1.Controls.Add(Button7)
        SplitContainer1.Panel1.Controls.Add(Button4)
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
        SplitContainer1.TabIndex = 0
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
        ' Button8
        ' 
        Button8.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button8.BackColor = SystemColors.Control
        Button8.FlatAppearance.BorderSize = 0
        Button8.FlatStyle = FlatStyle.Flat
        Button8.Font = New Font("Microsoft YaHei", 10.2F)
        Button8.ForeColor = Color.Red
        Button8.Image = My.Resources.Resources.Vector
        Button8.ImageAlign = ContentAlignment.MiddleLeft
        Button8.Location = New Point(3, 619)
        Button8.Name = "Button8"
        Button8.Padding = New Padding(15, 0, 0, 0)
        Button8.Size = New Size(282, 36)
        Button8.TabIndex = 8
        Button8.Text = "     Logout"
        Button8.TextImageRelation = TextImageRelation.ImageBeforeText
        Button8.UseVisualStyleBackColor = False
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
        ' Button4
        ' 
        Button4.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button4.BackColor = SystemColors.Control
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Microsoft YaHei", 10.2F)
        Button4.Image = My.Resources.Resources.settings
        Button4.ImageAlign = ContentAlignment.MiddleLeft
        Button4.Location = New Point(3, 265)
        Button4.Name = "Button4"
        Button4.Padding = New Padding(15, 0, 0, 0)
        Button4.Size = New Size(282, 36)
        Button4.TabIndex = 5
        Button4.Text = "     Profile"
        Button4.TextImageRelation = TextImageRelation.ImageBeforeText
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        Button3.BackColor = SystemColors.Control
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Microsoft YaHei", 10.2F)
        Button3.Image = My.Resources.Resources.appointments
        Button3.ImageAlign = ContentAlignment.MiddleLeft
        Button3.Location = New Point(3, 223)
        Button3.Name = "Button3"
        Button3.Padding = New Padding(15, 0, 0, 0)
        Button3.Size = New Size(282, 36)
        Button3.TabIndex = 4
        Button3.Text = "     My Appointments"
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
        Button2.Image = My.Resources.Resources.search
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(3, 181)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(15, 0, 0, 0)
        Button2.Size = New Size(282, 36)
        Button2.TabIndex = 3
        Button2.Text = "     Search"
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
        Button1.Text = "     Home"
        Button1.TextImageRelation = TextImageRelation.ImageBeforeText
        Button1.UseVisualStyleBackColor = False
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
        Name = "user_template"
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
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button6 As Button
    Friend WithEvents Button7 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Button5 As Button

End Class
