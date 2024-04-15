<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Provider_Profile_page
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
        profilepic_pb = New PictureBox()
        Panel1 = New Panel()
        PictureBox6 = New PictureBox()
        PictureBox5 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox2 = New PictureBox()
        rate_label = New Label()
        location_label = New Label()
        email_label = New Label()
        Service_label = New Label()
        Name_label = New Label()
        Edit_profile_btn = New Button()
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
        contact_label = New Label()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        slot_matrix_tablelayout.SuspendLayout()
        SuspendLayout()
        ' 
        ' profilepic_pb
        ' 
        profilepic_pb.BackgroundImage = My.Resources.Resources.serviceproviderdefault
        profilepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        profilepic_pb.Dock = DockStyle.Top
        profilepic_pb.Location = New Point(0, 0)
        profilepic_pb.Name = "profilepic_pb"
        profilepic_pb.Size = New Size(801, 245)
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
        Panel1.Location = New Point(33, 251)
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
        ' rate_label
        ' 
        rate_label.Font = New Font("Segoe UI", 11F)
        rate_label.Location = New Point(33, 478)
        rate_label.Name = "rate_label"
        rate_label.Size = New Size(394, 34)
        rate_label.TabIndex = 4
        rate_label.Text = "20L/hour"
        ' 
        ' location_label
        ' 
        location_label.Font = New Font("Segoe UI", 11F)
        location_label.Location = New Point(33, 444)
        location_label.Name = "location_label"
        location_label.Size = New Size(391, 34)
        location_label.TabIndex = 3
        location_label.Text = "guwahati, delhi"
        ' 
        ' email_label
        ' 
        email_label.Font = New Font("Segoe UI", 11F)
        email_label.Location = New Point(33, 343)
        email_label.Name = "email_label"
        email_label.Size = New Size(391, 34)
        email_label.TabIndex = 2
        email_label.Text = "Pratham@gmail.com"
        ' 
        ' Service_label
        ' 
        Service_label.Font = New Font("Segoe UI", 11F)
        Service_label.Location = New Point(33, 411)
        Service_label.Name = "Service_label"
        Service_label.Size = New Size(427, 34)
        Service_label.TabIndex = 1
        Service_label.Text = "Decorator"
        ' 
        ' Name_label
        ' 
        Name_label.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Name_label.Location = New Point(33, 309)
        Name_label.Name = "Name_label"
        Name_label.Size = New Size(427, 34)
        Name_label.TabIndex = 0
        Name_label.Text = "Pratham Goyal"
        ' 
        ' Edit_profile_btn
        ' 
        Edit_profile_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Edit_profile_btn.BackgroundImageLayout = ImageLayout.Stretch
        Edit_profile_btn.FlatStyle = FlatStyle.Flat
        Edit_profile_btn.Font = New Font("Segoe UI", 9F, FontStyle.Bold)
        Edit_profile_btn.ForeColor = Color.White
        Edit_profile_btn.Location = New Point(661, 258)
        Edit_profile_btn.Name = "Edit_profile_btn"
        Edit_profile_btn.Size = New Size(114, 36)
        Edit_profile_btn.TabIndex = 5
        Edit_profile_btn.Text = "Edit Profile"
        Edit_profile_btn.UseVisualStyleBackColor = False
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(602, 628)
        Label21.Name = "Label21"
        Label21.Size = New Size(39, 20)
        Label21.TabIndex = 105
        Label21.Text = "9pm"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(434, 628)
        Label15.Name = "Label15"
        Label15.Size = New Size(39, 20)
        Label15.TabIndex = 104
        Label15.Text = "5pm"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(476, 628)
        Label16.Name = "Label16"
        Label16.Size = New Size(39, 20)
        Label16.TabIndex = 103
        Label16.Text = "6pm"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(518, 628)
        Label17.Name = "Label17"
        Label17.Size = New Size(39, 20)
        Label17.TabIndex = 102
        Label17.Text = "7pm"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(560, 628)
        Label18.Name = "Label18"
        Label18.Size = New Size(39, 20)
        Label18.TabIndex = 101
        Label18.Text = "8pm"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(392, 628)
        Label19.Name = "Label19"
        Label19.Size = New Size(39, 20)
        Label19.TabIndex = 100
        Label19.Text = "4pm"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(350, 628)
        Label20.Name = "Label20"
        Label20.Size = New Size(39, 20)
        Label20.TabIndex = 99
        Label20.Text = "3pm"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(179, 628)
        Label14.Name = "Label14"
        Label14.Size = New Size(46, 20)
        Label14.TabIndex = 98
        Label14.Text = "11am"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(222, 628)
        Label13.Name = "Label13"
        Label13.Size = New Size(47, 20)
        Label13.TabIndex = 97
        Label13.Text = "12pm"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(266, 628)
        Label12.Name = "Label12"
        Label12.Size = New Size(39, 20)
        Label12.TabIndex = 96
        Label12.Text = "1pm"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(308, 628)
        Label11.Name = "Label11"
        Label11.Size = New Size(39, 20)
        Label11.TabIndex = 95
        Label11.Text = "2pm"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(137, 628)
        Label10.Name = "Label10"
        Label10.Size = New Size(46, 20)
        Label10.TabIndex = 94
        Label10.Text = "10am"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(98, 628)
        Label9.Name = "Label9"
        Label9.Size = New Size(38, 20)
        Label9.TabIndex = 93
        Label9.Text = "9am"
        ' 
        ' slot_matrix_tablelayout
        ' 
        slot_matrix_tablelayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        slot_matrix_tablelayout.ColumnCount = 13
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 50F))
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
        slot_matrix_tablelayout.Location = New Point(60, 646)
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
        slot_matrix_tablelayout.TabIndex = 92
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
        slot_label.Font = New Font("Segoe UI", 10F)
        slot_label.Location = New Point(33, 581)
        slot_label.Name = "slot_label"
        slot_label.Size = New Size(167, 22)
        slot_label.TabIndex = 91
        slot_label.Text = "Slot Timings :"
        ' 
        ' contact_label
        ' 
        contact_label.Font = New Font("Segoe UI", 10F)
        contact_label.Location = New Point(33, 375)
        contact_label.Name = "contact_label"
        contact_label.Size = New Size(276, 36)
        contact_label.TabIndex = 106
        contact_label.Text = "Contact Number : "
        ' 
        ' Provider_Profile_page
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoScroll = True
        AutoScrollMinSize = New Size(0, 1000)
        BackColor = SystemColors.Control
        ClientSize = New Size(822, 610)
        Controls.Add(contact_label)
        Controls.Add(Label21)
        Controls.Add(Label15)
        Controls.Add(Label16)
        Controls.Add(Label17)
        Controls.Add(Label18)
        Controls.Add(Label19)
        Controls.Add(Label20)
        Controls.Add(Label14)
        Controls.Add(Label13)
        Controls.Add(Label12)
        Controls.Add(Label11)
        Controls.Add(Label10)
        Controls.Add(Label9)
        Controls.Add(slot_matrix_tablelayout)
        Controls.Add(slot_label)
        Controls.Add(rate_label)
        Controls.Add(Edit_profile_btn)
        Controls.Add(location_label)
        Controls.Add(email_label)
        Controls.Add(Panel1)
        Controls.Add(Service_label)
        Controls.Add(profilepic_pb)
        Controls.Add(Name_label)
        Name = "Provider_Profile_page"
        Text = "Provider_Profile_page"
        CType(profilepic_pb, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        slot_matrix_tablelayout.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents profilepic_pb As PictureBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents rate_label As Label
    Friend WithEvents location_label As Label
    Friend WithEvents email_label As Label
    Friend WithEvents Service_label As Label
    Friend WithEvents Name_label As Label
    Friend WithEvents Edit_profile_btn As Button
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
    Friend WithEvents contact_label As Label
End Class