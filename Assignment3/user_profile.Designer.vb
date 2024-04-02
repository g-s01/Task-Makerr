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
        Edit_btn = New Button()
        email_tb = New TextBox()
        name_tb = New TextBox()
        email_label = New Label()
        name_label = New Label()
        greeting_label = New Label()
        changepic_pb = New PictureBox()
        phone_label = New Label()
        phone_tb = New TextBox()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(changepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' profilepic_pb
        ' 
        profilepic_pb.BackgroundImage = My.Resources.Resources._default
        profilepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        profilepic_pb.Location = New Point(571, 78)
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
        Panel1.Location = New Point(553, 295)
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
        ' Edit_btn
        ' 
        Edit_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Edit_btn.BackgroundImageLayout = ImageLayout.Stretch
        Edit_btn.FlatStyle = FlatStyle.Flat
        Edit_btn.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Edit_btn.ForeColor = Color.White
        Edit_btn.Location = New Point(60, 224)
        Edit_btn.Name = "Edit_btn"
        Edit_btn.Size = New Size(114, 36)
        Edit_btn.TabIndex = 5
        Edit_btn.Text = "Edit Button"
        Edit_btn.UseVisualStyleBackColor = False
        ' 
        ' email_tb
        ' 
        email_tb.BackColor = Color.White
        email_tb.BorderStyle = BorderStyle.None
        email_tb.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        email_tb.Location = New Point(209, 121)
        email_tb.Name = "email_tb"
        email_tb.ReadOnly = True
        email_tb.Size = New Size(236, 32)
        email_tb.TabIndex = 10
        email_tb.Text = "null"
        ' 
        ' name_tb
        ' 
        name_tb.BackColor = Color.White
        name_tb.BorderStyle = BorderStyle.None
        name_tb.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        name_tb.Location = New Point(209, 85)
        name_tb.Name = "name_tb"
        name_tb.ReadOnly = True
        name_tb.Size = New Size(236, 32)
        name_tb.TabIndex = 9
        name_tb.Text = "null"
        ' 
        ' email_label
        ' 
        email_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        email_label.Location = New Point(60, 118)
        email_label.Name = "email_label"
        email_label.Size = New Size(143, 36)
        email_label.TabIndex = 8
        email_label.Text = "Email    - "
        ' 
        ' name_label
        ' 
        name_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        name_label.Location = New Point(60, 82)
        name_label.Name = "name_label"
        name_label.Size = New Size(143, 36)
        name_label.TabIndex = 7
        name_label.Text = "Name   - "
        ' 
        ' greeting_label
        ' 
        greeting_label.AutoSize = True
        greeting_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        greeting_label.Location = New Point(60, 46)
        greeting_label.Name = "greeting_label"
        greeting_label.Size = New Size(86, 36)
        greeting_label.TabIndex = 6
        greeting_label.Text = "Hello,"
        ' 
        ' changepic_pb
        ' 
        changepic_pb.BackgroundImage = My.Resources.Resources.more_horiz
        changepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        changepic_pb.Location = New Point(736, 82)
        changepic_pb.Name = "changepic_pb"
        changepic_pb.Size = New Size(30, 30)
        changepic_pb.TabIndex = 5
        changepic_pb.TabStop = False
        ' 
        ' phone_label
        ' 
        phone_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        phone_label.Location = New Point(60, 154)
        phone_label.Name = "phone_label"
        phone_label.Size = New Size(143, 36)
        phone_label.TabIndex = 11
        phone_label.Text = "Phone  - "
        ' 
        ' phone_tb
        ' 
        phone_tb.BackColor = Color.White
        phone_tb.BorderStyle = BorderStyle.None
        phone_tb.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        phone_tb.Location = New Point(209, 157)
        phone_tb.Name = "phone_tb"
        phone_tb.ReadOnly = True
        phone_tb.Size = New Size(236, 32)
        phone_tb.TabIndex = 12
        phone_tb.Text = "null"
        ' 
        ' user_profile
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        ClientSize = New Size(822, 610)
        Controls.Add(phone_tb)
        Controls.Add(Edit_btn)
        Controls.Add(phone_label)
        Controls.Add(changepic_pb)
        Controls.Add(email_tb)
        Controls.Add(email_label)
        Controls.Add(name_tb)
        Controls.Add(Panel1)
        Controls.Add(profilepic_pb)
        Controls.Add(name_label)
        Controls.Add(greeting_label)
        Name = "user_profile"
        Text = "user_Profile_page"
        CType(profilepic_pb, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(changepic_pb, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents changepic_pb As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents profilepic_pb As PictureBox
    Friend WithEvents Edit_btn As Button
    Friend WithEvents email_label As Label
    Friend WithEvents name_label As Label
    Friend WithEvents greeting_label As Label
    Friend WithEvents email_tb As TextBox
    Friend WithEvents name_tb As TextBox
    Friend WithEvents phone_label As Label
    Friend WithEvents phone_tb As TextBox
End Class
