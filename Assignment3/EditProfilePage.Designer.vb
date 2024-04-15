<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class EditProfilePage
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
        contactnumber_tb = New TextBox()
        changepic_pb = New PictureBox()
        profilepic_pb = New PictureBox()
        contact_label = New Label()
        save_btn = New Button()
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
        name_label = New Label()
        email_label = New Label()
        back_btn = New Button()
        CType(changepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).BeginInit()
        slot_matrix_tablelayout.SuspendLayout()
        SuspendLayout()
        ' 
        ' contactnumber_tb
        ' 
        contactnumber_tb.Font = New Font("Segoe UI", 10F)
        contactnumber_tb.ForeColor = SystemColors.WindowText
        contactnumber_tb.Location = New Point(222, 320)
        contactnumber_tb.Name = "contactnumber_tb"
        contactnumber_tb.Size = New Size(297, 30)
        contactnumber_tb.TabIndex = 99
        ' 
        ' changepic_pb
        ' 
        changepic_pb.BackgroundImage = My.Resources.Resources.more_horiz
        changepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        changepic_pb.Location = New Point(762, 197)
        changepic_pb.Name = "changepic_pb"
        changepic_pb.Size = New Size(30, 30)
        changepic_pb.TabIndex = 98
        changepic_pb.TabStop = False
        ' 
        ' profilepic_pb
        ' 
        profilepic_pb.BackgroundImage = My.Resources.Resources.serviceproviderdefault
        profilepic_pb.BackgroundImageLayout = ImageLayout.Stretch
        profilepic_pb.Dock = DockStyle.Top
        profilepic_pb.Location = New Point(0, 0)
        profilepic_pb.Name = "profilepic_pb"
        profilepic_pb.Size = New Size(801, 246)
        profilepic_pb.SizeMode = PictureBoxSizeMode.StretchImage
        profilepic_pb.TabIndex = 97
        profilepic_pb.TabStop = False
        ' 
        ' contact_label
        ' 
        contact_label.Font = New Font("Segoe UI", 10F)
        contact_label.Location = New Point(49, 323)
        contact_label.Name = "contact_label"
        contact_label.Size = New Size(167, 22)
        contact_label.TabIndex = 96
        contact_label.Text = "Contact Number : "
        ' 
        ' save_btn
        ' 
        save_btn.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        save_btn.FlatAppearance.BorderSize = 0
        save_btn.FlatStyle = FlatStyle.Flat
        save_btn.Font = New Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        save_btn.ForeColor = Color.White
        save_btn.Location = New Point(613, 1033)
        save_btn.Name = "save_btn"
        save_btn.Size = New Size(135, 35)
        save_btn.TabIndex = 95
        save_btn.Text = "Save"
        save_btn.UseVisualStyleBackColor = False
        ' 
        ' cos_tb
        ' 
        cos_tb.Font = New Font("Segoe UI", 10F)
        cos_tb.ForeColor = SystemColors.WindowText
        cos_tb.Location = New Point(222, 633)
        cos_tb.Name = "cos_tb"
        cos_tb.Size = New Size(298, 30)
        cos_tb.TabIndex = 94
        ' 
        ' cps_label
        ' 
        cps_label.Font = New Font("Segoe UI", 10F)
        cps_label.Location = New Point(49, 636)
        cps_label.Name = "cps_label"
        cps_label.Size = New Size(167, 22)
        cps_label.TabIndex = 93
        cps_label.Text = "Cost Per Slots :"
        ' 
        ' type_label
        ' 
        type_label.Font = New Font("Segoe UI", 10F)
        type_label.Location = New Point(49, 369)
        type_label.Name = "type_label"
        type_label.Size = New Size(167, 22)
        type_label.TabIndex = 92
        type_label.Text = "Service Type :"
        ' 
        ' servicetype_combox
        ' 
        servicetype_combox.FormattingEnabled = True
        servicetype_combox.Items.AddRange(New Object() {"Cleaning", "Plumbing", "Electrical", "Painting", "Decorating", "Catering", "Photography", "Others"})
        servicetype_combox.Location = New Point(222, 368)
        servicetype_combox.Name = "servicetype_combox"
        servicetype_combox.Size = New Size(298, 28)
        servicetype_combox.TabIndex = 91
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(618, 741)
        Label21.Name = "Label21"
        Label21.Size = New Size(39, 20)
        Label21.TabIndex = 90
        Label21.Text = "9pm"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(450, 741)
        Label15.Name = "Label15"
        Label15.Size = New Size(39, 20)
        Label15.TabIndex = 89
        Label15.Text = "5pm"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(492, 741)
        Label16.Name = "Label16"
        Label16.Size = New Size(39, 20)
        Label16.TabIndex = 88
        Label16.Text = "6pm"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(534, 741)
        Label17.Name = "Label17"
        Label17.Size = New Size(39, 20)
        Label17.TabIndex = 87
        Label17.Text = "7pm"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(576, 741)
        Label18.Name = "Label18"
        Label18.Size = New Size(39, 20)
        Label18.TabIndex = 86
        Label18.Text = "8pm"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(408, 741)
        Label19.Name = "Label19"
        Label19.Size = New Size(39, 20)
        Label19.TabIndex = 85
        Label19.Text = "4pm"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(366, 741)
        Label20.Name = "Label20"
        Label20.Size = New Size(39, 20)
        Label20.TabIndex = 84
        Label20.Text = "3pm"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(195, 741)
        Label14.Name = "Label14"
        Label14.Size = New Size(46, 20)
        Label14.TabIndex = 83
        Label14.Text = "11am"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(238, 741)
        Label13.Name = "Label13"
        Label13.Size = New Size(47, 20)
        Label13.TabIndex = 82
        Label13.Text = "12pm"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(282, 741)
        Label12.Name = "Label12"
        Label12.Size = New Size(39, 20)
        Label12.TabIndex = 81
        Label12.Text = "1pm"
        ' 
        ' Label11
        ' 
        Label11.AutoSize = True
        Label11.Location = New Point(324, 741)
        Label11.Name = "Label11"
        Label11.Size = New Size(39, 20)
        Label11.TabIndex = 80
        Label11.Text = "2pm"
        ' 
        ' Label10
        ' 
        Label10.AutoSize = True
        Label10.Location = New Point(153, 741)
        Label10.Name = "Label10"
        Label10.Size = New Size(46, 20)
        Label10.TabIndex = 79
        Label10.Text = "10am"
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Location = New Point(114, 741)
        Label9.Name = "Label9"
        Label9.Size = New Size(38, 20)
        Label9.TabIndex = 78
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
        slot_matrix_tablelayout.Location = New Point(76, 759)
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
        slot_matrix_tablelayout.TabIndex = 77
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
        slot_label.Location = New Point(49, 694)
        slot_label.Name = "slot_label"
        slot_label.Size = New Size(167, 22)
        slot_label.TabIndex = 76
        slot_label.Text = "Slot Timings :"
        ' 
        ' location_checklistbox
        ' 
        location_checklistbox.FormattingEnabled = True
        location_checklistbox.Location = New Point(223, 420)
        location_checklistbox.Name = "location_checklistbox"
        location_checklistbox.Size = New Size(297, 158)
        location_checklistbox.TabIndex = 75
        ' 
        ' location_label
        ' 
        location_label.Font = New Font("Segoe UI", 10F)
        location_label.Location = New Point(49, 420)
        location_label.Name = "location_label"
        location_label.Size = New Size(167, 22)
        location_label.TabIndex = 74
        location_label.Text = "Service Locations :"
        ' 
        ' name_label
        ' 
        name_label.Font = New Font("Segoe UI", 10F)
        name_label.Location = New Point(606, 257)
        name_label.Name = "name_label"
        name_label.Size = New Size(167, 22)
        name_label.TabIndex = 100
        name_label.Text = "Pratham Goyal"
        name_label.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' email_label
        ' 
        email_label.Font = New Font("Segoe UI", 10F)
        email_label.Location = New Point(606, 282)
        email_label.Name = "email_label"
        email_label.Size = New Size(167, 22)
        email_label.TabIndex = 101
        email_label.Text = "sahiljaiswal@iitg.ac.in"
        email_label.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' back_btn
        ' 
        back_btn.BackgroundImage = My.Resources.Resources.backbtn
        back_btn.BackgroundImageLayout = ImageLayout.Stretch
        back_btn.FlatAppearance.BorderSize = 0
        back_btn.FlatStyle = FlatStyle.Flat
        back_btn.Location = New Point(40, 257)
        back_btn.Name = "back_btn"
        back_btn.Size = New Size(84, 35)
        back_btn.TabIndex = 102
        back_btn.UseVisualStyleBackColor = True
        ' 
        ' EditProfilePage
        ' 
        AutoScaleMode = AutoScaleMode.None
        AutoScroll = True
        AutoScrollMinSize = New Size(0, 1100)
        ClientSize = New Size(822, 610)
        Controls.Add(back_btn)
        Controls.Add(email_label)
        Controls.Add(name_label)
        Controls.Add(contactnumber_tb)
        Controls.Add(changepic_pb)
        Controls.Add(profilepic_pb)
        Controls.Add(contact_label)
        Controls.Add(save_btn)
        Controls.Add(cos_tb)
        Controls.Add(cps_label)
        Controls.Add(type_label)
        Controls.Add(servicetype_combox)
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
        Controls.Add(location_checklistbox)
        Controls.Add(location_label)
        Name = "EditProfilePage"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Provider_Profile_page"
        CType(changepic_pb, ComponentModel.ISupportInitialize).EndInit()
        CType(profilepic_pb, ComponentModel.ISupportInitialize).EndInit()
        slot_matrix_tablelayout.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents contactnumber_tb As TextBox
    Friend WithEvents changepic_pb As PictureBox
    Friend WithEvents profilepic_pb As PictureBox
    Friend WithEvents contact_label As Label
    Friend WithEvents save_btn As Button
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
    Friend WithEvents name_label As Label
    Friend WithEvents email_label As Label
    Friend WithEvents back_btn As Button
End Class
