<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Provider_Signup
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
        changepic_pb = New PictureBox()
        profilepic_pb = New PictureBox()
        contactnumber_tb = New TextBox()
        contact_label = New Label()
        login_btn = New Button()
        save_btn = New Button()
        profileheading_label = New Label()
        cos_tb = New TextBox()
        cps_label = New Label()
        type_label = New Label()
        servicetype_combox = New ComboBox()
        Label21 = New Label()
        Label15 = New Label()
        Label16 = New Label()
        Label17 = New Label()
        Label18 = New Label()
        Label19 = New Label()
        Label20 = New Label()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        Label11 = New Label()
        Label10 = New Label()
        Label9 = New Label()
        slot_matrix_tablelayout = New TableLayoutPanel()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label4 = New Label()
        Label3 = New Label()
        Label2 = New Label()
        slot_label = New Label()
        location_checklistbox = New CheckedListBox()
        location_label = New Label()
        showcnfpassword_cb = New CheckBox()
        showpassword_cb = New CheckBox()
        otp_tb = New TextBox()
        register_btn = New Button()
        sendOTP_btn = New Button()
        error_label = New Label()
        email_tb = New TextBox()
        cnfpassword_tb = New TextBox()
        password_tb = New TextBox()
        name_tb = New TextBox()
        subheadlabel = New Label()
        Label1 = New Label()
        back_btn = New Button()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        CType(changepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        slot_matrix_tablelayout.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackgroundImage = My.Resources.Resources.Provider_Logo
        Panel1.BackgroundImageLayout = ImageLayout.Stretch
        Panel1.Controls.Add(designlabel1)
        Panel1.Controls.Add(taskmakerrbtn)
        Panel1.Dock = DockStyle.Left
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(425, 673)
        Panel1.TabIndex = 0
        ' 
        ' designlabel1
        ' 
        designlabel1.BackColor = Color.Transparent
        designlabel1.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        designlabel1.Location = New Point(41, 508)
        designlabel1.Name = "designlabel1"
        designlabel1.Size = New Size(337, 36)
        designlabel1.TabIndex = 3
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
        taskmakerrbtn.TabIndex = 2
        taskmakerrbtn.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.AutoScrollMinSize = New Size(0, 1600)
        Panel2.Controls.Add(changepic_pb)
        Panel2.Controls.Add(profilepic_pb)
        Panel2.Controls.Add(contactnumber_tb)
        Panel2.Controls.Add(contact_label)
        Panel2.Controls.Add(login_btn)
        Panel2.Controls.Add(save_btn)
        Panel2.Controls.Add(profileheading_label)
        Panel2.Controls.Add(cos_tb)
        Panel2.Controls.Add(cps_label)
        Panel2.Controls.Add(type_label)
        Panel2.Controls.Add(servicetype_combox)
        Panel2.Controls.Add(Label21)
        Panel2.Controls.Add(Label15)
        Panel2.Controls.Add(Label16)
        Panel2.Controls.Add(Label17)
        Panel2.Controls.Add(Label18)
        Panel2.Controls.Add(Label19)
        Panel2.Controls.Add(Label20)
        Panel2.Controls.Add(Label14)
        Panel2.Controls.Add(Label13)
        Panel2.Controls.Add(Label12)
        Panel2.Controls.Add(Label11)
        Panel2.Controls.Add(Label10)
        Panel2.Controls.Add(Label9)
        Panel2.Controls.Add(slot_matrix_tablelayout)
        Panel2.Controls.Add(slot_label)
        Panel2.Controls.Add(location_checklistbox)
        Panel2.Controls.Add(location_label)
        Panel2.Controls.Add(showcnfpassword_cb)
        Panel2.Controls.Add(showpassword_cb)
        Panel2.Controls.Add(otp_tb)
        Panel2.Controls.Add(register_btn)
        Panel2.Controls.Add(sendOTP_btn)
        Panel2.Controls.Add(error_label)
        Panel2.Controls.Add(email_tb)
        Panel2.Controls.Add(cnfpassword_tb)
        Panel2.Controls.Add(password_tb)
        Panel2.Controls.Add(name_tb)
        Panel2.Controls.Add(subheadlabel)
        Panel2.Controls.Add(Label1)
        Panel2.Controls.Add(back_btn)
        Panel2.Dock = DockStyle.Fill
        Panel2.Location = New Point(425, 0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(709, 673)
        Panel2.TabIndex = 1
        ' 
        ' changepic_pb
        ' 
        changepic_pb.BackgroundImage = My.Resources.Resources.more_horiz
        changepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        changepic_pb.Location = New Point(581, 768)
        changepic_pb.Name = "changepic_pb"
        changepic_pb.Size = New Size(30, 30)
        changepic_pb.TabIndex = 77
        changepic_pb.TabStop = False
        ' 
        ' profilepic_pb
        ' 
        profilepic_pb.BackgroundImage = My.Resources.Resources._default
        profilepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        profilepic_pb.Location = New Point(419, 763)
        profilepic_pb.Name = "profilepic_pb"
        profilepic_pb.Size = New Size(198, 197)
        profilepic_pb.SizeMode = PictureBoxSizeMode.StretchImage
        profilepic_pb.TabIndex = 76
        profilepic_pb.TabStop = False
        ' 
        ' contactnumber_tb
        ' 
        contactnumber_tb.Font = New Font("Segoe UI", 10.0F)
        contactnumber_tb.ForeColor = SystemColors.WindowText
        contactnumber_tb.Location = New Point(59, 1445)
        contactnumber_tb.Name = "contactnumber_tb"
        contactnumber_tb.Size = New Size(297, 34)
        contactnumber_tb.TabIndex = 75
        ' 
        ' contact_label
        ' 
        contact_label.Font = New Font("Segoe UI", 10.0F)
        contact_label.Location = New Point(59, 1420)
        contact_label.Name = "contact_label"
        contact_label.Size = New Size(167, 22)
        contact_label.TabIndex = 74
        contact_label.Text = "Contact Number : "
        ' 
        ' login_btn
        ' 
        login_btn.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        login_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        login_btn.FlatAppearance.BorderSize = 0
        login_btn.FlatStyle = FlatStyle.Flat
        login_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        login_btn.ForeColor = Color.White
        login_btn.Location = New Point(529, 23)
        login_btn.Name = "login_btn"
        login_btn.Size = New Size(135, 35)
        login_btn.TabIndex = 1
        login_btn.Text = "Log In"
        login_btn.UseVisualStyleBackColor = False
        ' 
        ' save_btn
        ' 
        save_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        save_btn.FlatAppearance.BorderSize = 0
        save_btn.FlatStyle = FlatStyle.Flat
        save_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        save_btn.ForeColor = Color.White
        save_btn.Location = New Point(517, 1508)
        save_btn.Name = "save_btn"
        save_btn.Size = New Size(135, 35)
        save_btn.TabIndex = 65
        save_btn.Text = "Save"
        save_btn.UseVisualStyleBackColor = False
        ' 
        ' profileheading_label
        ' 
        profileheading_label.Font = New Font("Segoe UI", 15.0F)
        profileheading_label.Location = New Point(55, 633)
        profileheading_label.Name = "profileheading_label"
        profileheading_label.Size = New Size(301, 66)
        profileheading_label.TabIndex = 64
        profileheading_label.Text = "Profile Information"
        ' 
        ' cos_tb
        ' 
        cos_tb.Font = New Font("Segoe UI", 10.0F)
        cos_tb.ForeColor = SystemColors.WindowText
        cos_tb.Location = New Point(59, 1036)
        cos_tb.Name = "cos_tb"
        cos_tb.Size = New Size(297, 34)
        cos_tb.TabIndex = 63
        ' 
        ' cps_label
        ' 
        cps_label.Font = New Font("Segoe UI", 10.0F)
        cps_label.Location = New Point(59, 1011)
        cps_label.Name = "cps_label"
        cps_label.Size = New Size(167, 22)
        cps_label.TabIndex = 62
        cps_label.Text = "Cost Per Slots :"
        ' 
        ' type_label
        ' 
        type_label.Font = New Font("Segoe UI", 10.0F)
        type_label.Location = New Point(59, 708)
        type_label.Name = "type_label"
        type_label.Size = New Size(167, 22)
        type_label.TabIndex = 61
        type_label.Text = "Select Service Type :"
        ' 
        ' servicetype_combox
        ' 
        servicetype_combox.FormattingEnabled = True
        servicetype_combox.Items.AddRange(New Object() {"Painter", "Designer", "Kuchh", "Kuchh", "Kuchh"})
        servicetype_combox.Location = New Point(59, 733)
        servicetype_combox.Name = "servicetype_combox"
        servicetype_combox.Size = New Size(297, 33)
        servicetype_combox.TabIndex = 60
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(601, 1127)
        Label21.Name = "Label21"
        Label21.Size = New Size(49, 25)
        Label21.TabIndex = 59
        Label21.Text = "9pm"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(433, 1127)
        Label15.Name = "Label15"
        Label15.Size = New Size(49, 25)
        Label15.TabIndex = 58
        Label15.Text = "5pm"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(475, 1127)
        Label16.Name = "Label16"
        Label16.Size = New Size(49, 25)
        Label16.TabIndex = 57
        Label16.Text = "6pm"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(517, 1127)
        Label17.Name = "Label17"
        Label17.Size = New Size(49, 25)
        Label17.TabIndex = 56
        Label17.Text = "7pm"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(559, 1127)
        Label18.Name = "Label18"
        Label18.Size = New Size(49, 25)
        Label18.TabIndex = 55
        Label18.Text = "8pm"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(391, 1127)
        Label19.Name = "Label19"
        Label19.Size = New Size(49, 25)
        Label19.TabIndex = 54
        Label19.Text = "4pm"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(349, 1127)
        Label20.Name = "Label20"
        Label20.Size = New Size(49, 25)
        Label20.TabIndex = 53
        Label20.Text = "3pm"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(178, 1127)
        Label14.Name = "Label14"
        Label14.Size = New Size(57, 25)
        Label14.TabIndex = 52
        Label14.Text = "11am"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(221, 1127)
        Label13.Name = "Label13"
        Label13.Size = New Size(59, 25)
        Label13.TabIndex = 51
        Label13.Text = "12pm"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(265, 1127)
        Label12.Name = "Label12"
        Label12.Size = New Size(49, 25)
        Label12.TabIndex = 50
        Label12.Text = "1pm"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(307, 1127)
        Label11.Name = "Label11"
        Label11.Size = New Size(49, 25)
        Label11.TabIndex = 49
        Label11.Text = "2pm"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(136, 1127)
        Label10.Name = "Label10"
        Label10.Size = New Size(57, 25)
        Label10.TabIndex = 48
        Label10.Text = "10am"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(97, 1127)
        Label9.Name = "Label9"
        Label9.Size = New Size(47, 25)
        Label9.TabIndex = 47
        Label9.Text = "9am"
        ' 
        ' slot_matrix_tablelayout
        ' 
        slot_matrix_tablelayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        slot_matrix_tablelayout.ColumnCount = 13
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50.0F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.333335F))
        slot_matrix_tablelayout.Controls.Add(Label8, 0, 6)
        slot_matrix_tablelayout.Controls.Add(Label7, 0, 5)
        slot_matrix_tablelayout.Controls.Add(Label6, 0, 4)
        slot_matrix_tablelayout.Controls.Add(Label5, 0, 3)
        slot_matrix_tablelayout.Controls.Add(Label4, 0, 2)
        slot_matrix_tablelayout.Controls.Add(Label3, 0, 1)
        slot_matrix_tablelayout.Controls.Add(Label2, 0, 0)
        slot_matrix_tablelayout.Location = New Point(59, 1145)
        slot_matrix_tablelayout.Name = "slot_matrix_tablelayout"
        slot_matrix_tablelayout.RowCount = 7
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.Size = New Size(558, 259)
        slot_matrix_tablelayout.TabIndex = 46
        ' 
        ' Label8
        ' 
        Label8.Dock = DockStyle.Fill
        Label8.Location = New Point(4, 217)
        Label8.Name = "Label8"
        Label8.Size = New Size(44, 41)
        Label8.TabIndex = 6
        Label8.Text = "Sun"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Fill
        Label7.Location = New Point(4, 181)
        Label7.Name = "Label7"
        Label7.Size = New Size(44, 35)
        Label7.TabIndex = 5
        Label7.Text = "Sat"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Fill
        Label6.Location = New Point(4, 145)
        Label6.Name = "Label6"
        Label6.Size = New Size(44, 35)
        Label6.TabIndex = 4
        Label6.Text = "Fri"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Location = New Point(4, 109)
        Label5.Name = "Label5"
        Label5.Size = New Size(44, 35)
        Label5.TabIndex = 3
        Label5.Text = "Thru"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label4
        ' 
        Label4.Dock = DockStyle.Fill
        Label4.Location = New Point(4, 73)
        Label4.Name = "Label4"
        Label4.Size = New Size(44, 35)
        Label4.TabIndex = 2
        Label4.Text = "Wed"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label3
        ' 
        Label3.Dock = DockStyle.Fill
        Label3.Location = New Point(4, 37)
        Label3.Name = "Label3"
        Label3.Size = New Size(44, 35)
        Label3.TabIndex = 1
        Label3.Text = "Tue"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Dock = DockStyle.Fill
        Label2.Location = New Point(4, 1)
        Label2.Name = "Label2"
        Label2.Size = New Size(44, 35)
        Label2.TabIndex = 0
        Label2.Text = "Mon"
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' slot_label
        ' 
        slot_label.Font = New Font("Segoe UI", 10.0F)
        slot_label.Location = New Point(59, 1081)
        slot_label.Name = "slot_label"
        slot_label.Size = New Size(167, 22)
        slot_label.TabIndex = 45
        slot_label.Text = "Select Slot Timings :"
        ' 
        ' location_checklistbox
        ' 
        location_checklistbox.FormattingEnabled = True
        location_checklistbox.Items.AddRange(New Object() {"Guwahati", "Tezpur", "Jorhat", "Changsari", "Sualkuchi", "Palasbari", "Maliata", "Panbazar", "Panikhaiti", "Amsing", "Jorabat", "Lalmati", "Kahikuchi"})
        location_checklistbox.Location = New Point(59, 803)
        location_checklistbox.Name = "location_checklistbox"
        location_checklistbox.Size = New Size(297, 172)
        location_checklistbox.TabIndex = 44
        ' 
        ' location_label
        ' 
        location_label.Font = New Font("Segoe UI", 10.0F)
        location_label.Location = New Point(59, 778)
        location_label.Name = "location_label"
        location_label.Size = New Size(167, 22)
        location_label.TabIndex = 43
        location_label.Text = "Select Service Locations :"
        ' 
        ' showcnfpassword_cb
        ' 
        showcnfpassword_cb.AutoSize = True
        showcnfpassword_cb.Font = New Font("Segoe UI", 8.0F)
        showcnfpassword_cb.Location = New Point(479, 357)
        showcnfpassword_cb.Name = "showcnfpassword_cb"
        showcnfpassword_cb.Size = New Size(75, 25)
        showcnfpassword_cb.TabIndex = 42
        showcnfpassword_cb.Text = "Show"
        showcnfpassword_cb.UseVisualStyleBackColor = True
        ' 
        ' showpassword_cb
        ' 
        showpassword_cb.AutoSize = True
        showpassword_cb.Font = New Font("Segoe UI", 8.0F)
        showpassword_cb.Location = New Point(479, 309)
        showpassword_cb.Name = "showpassword_cb"
        showpassword_cb.Size = New Size(75, 25)
        showpassword_cb.TabIndex = 41
        showpassword_cb.Text = "Show"
        showpassword_cb.UseVisualStyleBackColor = True
        ' 
        ' otp_tb
        ' 
        otp_tb.Font = New Font("Segoe UI", 10.0F)
        otp_tb.ForeColor = SystemColors.WindowText
        otp_tb.Location = New Point(55, 461)
        otp_tb.Name = "otp_tb"
        otp_tb.PlaceholderText = "OTP"
        otp_tb.Size = New Size(418, 34)
        otp_tb.TabIndex = 22
        ' 
        ' register_btn
        ' 
        register_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        register_btn.FlatAppearance.BorderSize = 0
        register_btn.FlatStyle = FlatStyle.Flat
        register_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        register_btn.ForeColor = Color.White
        register_btn.Location = New Point(205, 505)
        register_btn.Name = "register_btn"
        register_btn.Size = New Size(135, 35)
        register_btn.TabIndex = 23
        register_btn.Text = "Register"
        register_btn.UseVisualStyleBackColor = False
        ' 
        ' sendOTP_btn
        ' 
        sendOTP_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        sendOTP_btn.FlatAppearance.BorderSize = 0
        sendOTP_btn.FlatStyle = FlatStyle.Flat
        sendOTP_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendOTP_btn.ForeColor = Color.White
        sendOTP_btn.Location = New Point(205, 405)
        sendOTP_btn.Name = "sendOTP_btn"
        sendOTP_btn.Size = New Size(135, 35)
        sendOTP_btn.TabIndex = 21
        sendOTP_btn.Text = "Send OTP"
        sendOTP_btn.UseVisualStyleBackColor = False
        ' 
        ' error_label
        ' 
        error_label.AutoSize = True
        error_label.Font = New Font("Segoe UI", 8.0F)
        error_label.ForeColor = Color.Red
        error_label.Location = New Point(55, 380)
        error_label.Name = "error_label"
        error_label.Size = New Size(45, 21)
        error_label.TabIndex = 20
        error_label.Text = "error"
        ' 
        ' email_tb
        ' 
        email_tb.Font = New Font("Segoe UI", 10.0F)
        email_tb.ForeColor = SystemColors.WindowText
        email_tb.Location = New Point(55, 254)
        email_tb.Name = "email_tb"
        email_tb.PlaceholderText = "Email"
        email_tb.Size = New Size(418, 34)
        email_tb.TabIndex = 17
        ' 
        ' cnfpassword_tb
        ' 
        cnfpassword_tb.Font = New Font("Segoe UI", 10.0F)
        cnfpassword_tb.ForeColor = SystemColors.WindowText
        cnfpassword_tb.Location = New Point(55, 352)
        cnfpassword_tb.Name = "cnfpassword_tb"
        cnfpassword_tb.PasswordChar = "*"c
        cnfpassword_tb.PlaceholderText = "Confirm Password"
        cnfpassword_tb.Size = New Size(418, 34)
        cnfpassword_tb.TabIndex = 19
        ' 
        ' password_tb
        ' 
        password_tb.Font = New Font("Segoe UI", 10.0F)
        password_tb.ForeColor = SystemColors.WindowText
        password_tb.Location = New Point(55, 304)
        password_tb.Name = "password_tb"
        password_tb.PasswordChar = "*"c
        password_tb.PlaceholderText = "Password"
        password_tb.Size = New Size(418, 34)
        password_tb.TabIndex = 18
        ' 
        ' name_tb
        ' 
        name_tb.Font = New Font("Segoe UI", 10.0F)
        name_tb.ForeColor = SystemColors.WindowText
        name_tb.Location = New Point(55, 209)
        name_tb.Name = "name_tb"
        name_tb.PlaceholderText = "Name"
        name_tb.Size = New Size(418, 34)
        name_tb.TabIndex = 16
        ' 
        ' subheadlabel
        ' 
        subheadlabel.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        subheadlabel.Location = New Point(52, 184)
        subheadlabel.Name = "subheadlabel"
        subheadlabel.Size = New Size(217, 22)
        subheadlabel.TabIndex = 15
        subheadlabel.Text = "Create your provider profile"
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 15.0F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(52, 128)
        Label1.Name = "Label1"
        Label1.Size = New Size(258, 34)
        Label1.TabIndex = 14
        Label1.Text = "Create an account"
        ' 
        ' back_btn
        ' 
        back_btn.BackgroundImage = My.Resources.Resources.backbtn
        back_btn.BackgroundImageLayout = ImageLayout.Stretch
        back_btn.FlatAppearance.BorderSize = 0
        back_btn.FlatStyle = FlatStyle.Flat
        back_btn.Location = New Point(21, 22)
        back_btn.Name = "back_btn"
        back_btn.Size = New Size(84, 35)
        back_btn.TabIndex = 12
        back_btn.UseVisualStyleBackColor = True
        ' 
        ' Provider_Signup
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(1134, 673)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "Provider_Signup"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Provider_Signup"
        Panel1.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(changepic_pb, ComponentModel.ISupportInitialize).EndInit()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).EndInit()
        slot_matrix_tablelayout.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents designlabel1 As Label
    Friend WithEvents taskmakerrbtn As Button
    Friend WithEvents otp_tb As TextBox
    Friend WithEvents register_btn As Button
    Friend WithEvents sendOTP_btn As Button
    Friend WithEvents error_label As Label
    Friend WithEvents email_tb As TextBox
    Friend WithEvents cnfpassword_tb As TextBox
    Friend WithEvents password_tb As TextBox
    Friend WithEvents name_tb As TextBox
    Friend WithEvents subheadlabel As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents back_btn As Button
    Friend WithEvents showcnfpassword_cb As CheckBox
    Friend WithEvents showpassword_cb As CheckBox
    Friend WithEvents profileheading_label As Label
    Friend WithEvents cos_tb As TextBox
    Friend WithEvents cps_label As Label
    Friend WithEvents type_label As Label
    Friend WithEvents servicetype_combox As ComboBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents slot_matrix_tablelayout As TableLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents slot_label As Label
    Friend WithEvents location_checklistbox As CheckedListBox
    Friend WithEvents location_label As Label
    Friend WithEvents save_btn As Button
    Friend WithEvents login_btn As Button
    Friend WithEvents contactnumber_tb As TextBox
    Friend WithEvents contact_label As Label
    Friend WithEvents changepic_pb As PictureBox
    Friend WithEvents profilepic_pb As PictureBox
End Class
