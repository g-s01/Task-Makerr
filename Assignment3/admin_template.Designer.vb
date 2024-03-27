<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class admin_template
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
        SplitContainer1 = New SplitContainer()
        Label1 = New Label()
        Button7 = New Button()
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
        SplitContainer1.Panel1.Controls.Add(Label1)
        SplitContainer1.Panel1.Controls.Add(Button7)
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
        ' Button7
        ' 
        Button7.BackColor = SystemColors.Control
        Button7.FlatAppearance.BorderSize = 0
        Button7.FlatStyle = FlatStyle.Flat
        Button7.Font = New Font("Microsoft YaHei", 10.2F)
        Button7.ForeColor = Color.Red
        Button7.Image = My.Resources.Resources.Vector
        Button7.ImageAlign = ContentAlignment.MiddleLeft
        Button7.Location = New Point(3, 619)
        Button7.Name = "Button7"
        Button7.Padding = New Padding(15, 0, 0, 0)
        Button7.Size = New Size(282, 36)
        Button7.TabIndex = 8
        Button7.Text = "     Logout"
        Button7.TextImageRelation = TextImageRelation.ImageBeforeText
        Button7.UseVisualStyleBackColor = False
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
        Button3.Text = "     Feedbacks"
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
        Button2.Image = My.Resources.Resources.chats
        Button2.ImageAlign = ContentAlignment.MiddleLeft
        Button2.Location = New Point(3, 181)
        Button2.Name = "Button2"
        Button2.Padding = New Padding(15, 0, 0, 0)
        Button2.Size = New Size(282, 36)
        Button2.TabIndex = 3
        Button2.Text = "     Chats"
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
        ' admin_template
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1132, 666)
        Controls.Add(SplitContainer1)
        Name = "admin_template"
        Text = "admin_template"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents Button7 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
End Class
