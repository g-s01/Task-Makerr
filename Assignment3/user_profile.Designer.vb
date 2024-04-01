<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class user_profile
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        profilepic_pb = New PictureBox()
        Panel1 = New Panel()
        PictureBox6 = New PictureBox()
        PictureBox5 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        Panel2 = New Panel()
        Button2 = New Button()
        TextBox2 = New TextBox()
        TextBox1 = New TextBox()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        Button1 = New Button()
        Panel3 = New Panel()
        Label1 = New Label()
        changepic_pb = New PictureBox()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel2.SuspendLayout()
        CType(changepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' profilepic_pb
        ' 
        profilepic_pb.BackgroundImage = My.Resources.Resources._default
        profilepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        profilepic_pb.Location = New Point(59, 29)
        profilepic_pb.Name = "profilepic_pb"
        profilepic_pb.Size = New Size(198, 197)
        profilepic_pb.SizeMode = PictureBoxSizeMode.StretchImage
        profilepic_pb.TabIndex = 0
        profilepic_pb.TabStop = False
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(PictureBox6)
        Panel1.Controls.Add(PictureBox5)
        Panel1.Controls.Add(PictureBox4)
        Panel1.Controls.Add(PictureBox3)
        Panel1.Controls.Add(PictureBox2)
        Panel1.Location = New Point(33, 234)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(236, 43)
        Panel1.TabIndex = 1
        ' 
        ' PictureBox6
        ' 
        PictureBox6.Location = New Point(193, 0)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(43, 43)
        PictureBox6.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox6.TabIndex = 6
        PictureBox6.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.Location = New Point(146, 0)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(43, 43)
        PictureBox5.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox5.TabIndex = 5
        PictureBox5.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.Location = New Point(97, 0)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(43, 43)
        PictureBox4.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox4.TabIndex = 4
        PictureBox4.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.Location = New Point(48, 0)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(43, 43)
        PictureBox3.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(0, 0)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(43, 43)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 2
        PictureBox2.TabStop = False
        ' 
        ' Panel2
        ' 
        Panel2.BorderStyle = BorderStyle.FixedSingle
        Panel2.Controls.Add(Button2)
        Panel2.Controls.Add(TextBox2)
        Panel2.Controls.Add(TextBox1)
        Panel2.Controls.Add(Label4)
        Panel2.Controls.Add(Label3)
        Panel2.Controls.Add(Label2)
        Panel2.Controls.Add(Button1)
        Panel2.Location = New Point(361, 12)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(411, 265)
        Panel2.TabIndex = 2
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Button2.BackgroundImageLayout = ImageLayout.Stretch
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Button2.ForeColor = Color.White
        Button2.Location = New Point(227, 207)
        Button2.Name = "Button2"
        Button2.Size = New Size(114, 36)
        Button2.TabIndex = 11
        Button2.Text = "Apply"
        Button2.UseVisualStyleBackColor = False
        Button2.Visible = False
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TextBox2.Location = New Point(155, 141)
        TextBox2.Name = "TextBox2"
        TextBox2.ReadOnly = True
        TextBox2.Size = New Size(236, 34)
        TextBox2.TabIndex = 10
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold)
        TextBox1.Location = New Point(155, 88)
        TextBox1.Name = "TextBox1"
        TextBox1.ReadOnly = True
        TextBox1.Size = New Size(236, 34)
        TextBox1.TabIndex = 9
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label4.Location = New Point(54, 136)
        Label4.Name = "Label4"
        Label4.Size = New Size(90, 30)
        Label4.TabIndex = 8
        Label4.Text = "Email - "
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label3.Location = New Point(54, 83)
        Label3.Name = "Label3"
        Label3.Size = New Size(95, 30)
        Label3.TabIndex = 7
        Label3.Text = "Name - "
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label2.Location = New Point(54, 30)
        Label2.Name = "Label2"
        Label2.Size = New Size(73, 30)
        Label2.TabIndex = 6
        Label2.Text = "Hello,"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Button1.BackgroundImageLayout = ImageLayout.Stretch
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 9.0F, FontStyle.Bold)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(39, 207)
        Button1.Name = "Button1"
        Button1.Size = New Size(114, 36)
        Button1.TabIndex = 5
        Button1.Text = "Edit Button"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Panel3
        ' 
        Panel3.AutoScroll = True
        Panel3.Location = New Point(33, 332)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(760, 283)
        Panel3.TabIndex = 3
        ' 
        ' Label1
        ' 
        Label1.BackColor = Color.LightGray
        Label1.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label1.Location = New Point(33, 295)
        Label1.Name = "Label1"
        Label1.Size = New Size(739, 34)
        Label1.TabIndex = 4
        Label1.Text = "Past Appointments"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' changepic_pb
        ' 
        changepic_pb.BackgroundImage = My.Resources.Resources.more_horiz
        changepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        changepic_pb.Location = New Point(224, 33)
        changepic_pb.Name = "changepic_pb"
        changepic_pb.Size = New Size(30, 30)
        changepic_pb.TabIndex = 5
        changepic_pb.TabStop = False
        ' 
        ' user_profile
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        ClientSize = New Size(825, 619)
        Controls.Add(changepic_pb)
        Controls.Add(Label1)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(profilepic_pb)
        FormBorderStyle = FormBorderStyle.None
        Name = "user_profile"
        Text = "user_Profile_page"
        CType(profilepic_pb, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(changepic_pb, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents changepic_pb As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents profilepic_pb As PictureBox
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Button1 As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
End Class
