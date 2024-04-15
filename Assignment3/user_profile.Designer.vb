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
        Edit_btn = New Button()
        email_tb = New TextBox()
        name_tb = New TextBox()
        email_label = New Label()
        name_label = New Label()
        greeting_label = New Label()
        changepic_pb = New PictureBox()
        phone_label = New Label()
        phone_tb = New TextBox()
        Label1 = New Label()
        Panel1 = New Panel()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        CType(changepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' profilepic_pb
        ' 
        profilepic_pb.Anchor = AnchorStyles.None
        profilepic_pb.BackgroundImage = My.Resources.Resources._default
        profilepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        profilepic_pb.Location = New Point(631, 118)
        profilepic_pb.Name = "profilepic_pb"
        profilepic_pb.Size = New Size(198, 197)
        profilepic_pb.SizeMode = PictureBoxSizeMode.StretchImage
        profilepic_pb.TabIndex = 0
        profilepic_pb.TabStop = False
        ' 
        ' Edit_btn
        ' 
        Edit_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Edit_btn.BackgroundImageLayout = ImageLayout.Stretch
        Edit_btn.FlatStyle = FlatStyle.Flat
        Edit_btn.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Edit_btn.ForeColor = Color.White
        Edit_btn.Location = New Point(64, 336)
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
        email_tb.Location = New Point(213, 233)
        email_tb.Name = "email_tb"
        email_tb.ReadOnly = True
        email_tb.Size = New Size(236, 27)
        email_tb.TabIndex = 10
        email_tb.Text = "null"
        ' 
        ' name_tb
        ' 
        name_tb.BackColor = Color.White
        name_tb.BorderStyle = BorderStyle.None
        name_tb.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        name_tb.Location = New Point(213, 197)
        name_tb.Name = "name_tb"
        name_tb.ReadOnly = True
        name_tb.Size = New Size(236, 27)
        name_tb.TabIndex = 9
        name_tb.Text = "null"
        ' 
        ' email_label
        ' 
        email_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        email_label.Location = New Point(64, 230)
        email_label.Name = "email_label"
        email_label.Size = New Size(143, 36)
        email_label.TabIndex = 8
        email_label.Text = "Email    - "
        ' 
        ' name_label
        ' 
        name_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        name_label.Location = New Point(64, 194)
        name_label.Name = "name_label"
        name_label.Size = New Size(143, 36)
        name_label.TabIndex = 7
        name_label.Text = "Name   - "
        ' 
        ' greeting_label
        ' 
        greeting_label.Font = New Font("Arial Rounded MT Bold", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        greeting_label.ForeColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        greeting_label.Location = New Point(64, 79)
        greeting_label.Name = "greeting_label"
        greeting_label.Size = New Size(385, 76)
        greeting_label.TabIndex = 6
        greeting_label.Text = "Hello, "
        greeting_label.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' changepic_pb
        ' 
        changepic_pb.Anchor = AnchorStyles.None
        changepic_pb.BackgroundImage = My.Resources.Resources.more_horiz
        changepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        changepic_pb.Location = New Point(796, 122)
        changepic_pb.Name = "changepic_pb"
        changepic_pb.Size = New Size(30, 30)
        changepic_pb.TabIndex = 5
        changepic_pb.TabStop = False
        ' 
        ' phone_label
        ' 
        phone_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        phone_label.Location = New Point(64, 266)
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
        phone_tb.Location = New Point(213, 269)
        phone_tb.Name = "phone_tb"
        phone_tb.ReadOnly = True
        phone_tb.Size = New Size(236, 27)
        phone_tb.TabIndex = 12
        phone_tb.Text = "null"
        ' 
        ' Label1
        ' 
        Label1.Anchor = AnchorStyles.None
        Label1.Font = New Font("Arial Rounded MT Bold", 16F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Label1.Location = New Point(257, 9)
        Label1.Name = "Label1"
        Label1.Size = New Size(308, 46)
        Label1.TabIndex = 13
        Label1.Text = "User Profile"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = Color.FromArgb(CByte(250), CByte(240), CByte(252))
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(940, 63)
        Panel1.TabIndex = 14
        ' 
        ' user_profile
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.LavenderBlush
        ClientSize = New Size(940, 610)
        Controls.Add(Panel1)
        Controls.Add(phone_tb)
        Controls.Add(Edit_btn)
        Controls.Add(phone_label)
        Controls.Add(changepic_pb)
        Controls.Add(email_tb)
        Controls.Add(email_label)
        Controls.Add(name_tb)
        Controls.Add(profilepic_pb)
        Controls.Add(name_label)
        Controls.Add(greeting_label)
        Name = "user_profile"
        Text = "user_Profile_page"
        CType(profilepic_pb, ComponentModel.ISupportInitialize).EndInit()
        CType(changepic_pb, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents changepic_pb As PictureBox
    Friend WithEvents profilepic_pb As PictureBox
    Friend WithEvents Edit_btn As Button
    Friend WithEvents email_label As Label
    Friend WithEvents name_label As Label
    Friend WithEvents greeting_label As Label
    Friend WithEvents email_tb As TextBox
    Friend WithEvents name_tb As TextBox
    Friend WithEvents phone_label As Label
    Friend WithEvents phone_tb As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label2 As Label
End Class
