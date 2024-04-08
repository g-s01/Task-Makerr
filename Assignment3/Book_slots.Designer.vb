<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Book_slots
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
        Profile_Pic = New PictureBox()
        Username = New Label()
        Back_Btn = New Button()
        Provider_Name_Loc_Lbl = New Label()
        Schedule_Table = New TableLayoutPanel()
        Panel1 = New Panel()
        Address_Lbl = New Label()
        Address_TxtBox = New TextBox()
        Book_Btn = New Button()
        ProgressBar1 = New ProgressBar()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        Label4 = New Label()
        Label5 = New Label()
        Label6 = New Label()
        Label7 = New Label()
        Label8 = New Label()
        CType(Profile_Pic, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Profile_Pic
        ' 
        Profile_Pic.Location = New Point(736, 12)
        Profile_Pic.Name = "Profile_Pic"
        Profile_Pic.Size = New Size(125, 62)
        Profile_Pic.TabIndex = 0
        Profile_Pic.TabStop = False
        ' 
        ' Username
        ' 
        Username.AutoSize = True
        Username.Font = New Font("Microsoft Sans Serif", 10.2F)
        Username.Location = New Point(736, 77)
        Username.Name = "Username"
        Username.Size = New Size(86, 20)
        Username.TabIndex = 1
        Username.Text = "Username"
        ' 
        ' Back_Btn
        ' 
        Back_Btn.BackgroundImage = My.Resources.Resources.back
        Back_Btn.BackgroundImageLayout = ImageLayout.Zoom
        Back_Btn.Location = New Point(12, 37)
        Back_Btn.Name = "Back_Btn"
        Back_Btn.Size = New Size(93, 37)
        Back_Btn.TabIndex = 2
        Back_Btn.UseVisualStyleBackColor = True
        ' 
        ' Provider_Name_Loc_Lbl
        ' 
        Provider_Name_Loc_Lbl.AutoSize = True
        Provider_Name_Loc_Lbl.Font = New Font("Microsoft Sans Serif", 13.0F)
        Provider_Name_Loc_Lbl.Location = New Point(15, 88)
        Provider_Name_Loc_Lbl.Name = "Provider_Name_Loc_Lbl"
        Provider_Name_Loc_Lbl.Size = New Size(77, 26)
        Provider_Name_Loc_Lbl.TabIndex = 3
        Provider_Name_Loc_Lbl.Text = "Label2"
        ' 
        ' Schedule_Table
        ' 
        Schedule_Table.AutoScroll = True
        Schedule_Table.AutoSize = True
        Schedule_Table.BackColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        Schedule_Table.ColumnCount = 13
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19.6245728F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80.37543F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 301.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 32.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 8.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 22.0F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.Location = New Point(3, 3)
        Schedule_Table.Name = "Schedule_Table"
        Schedule_Table.RowCount = 8
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Percent, 26.1083736F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Percent, 73.8916245F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 19.0F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 30.0F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 10.0F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20.0F))
        Schedule_Table.Size = New Size(828, 428)
        Schedule_Table.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Schedule_Table)
        Panel1.Location = New Point(15, 144)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(828, 431)
        Panel1.TabIndex = 5
        ' 
        ' Address_Lbl
        ' 
        Address_Lbl.AutoSize = True
        Address_Lbl.Font = New Font("Microsoft YaHei", 13.0F)
        Address_Lbl.Location = New Point(9, 682)
        Address_Lbl.Name = "Address_Lbl"
        Address_Lbl.Size = New Size(96, 30)
        Address_Lbl.TabIndex = 6
        Address_Lbl.Text = "Address"
        ' 
        ' Address_TxtBox
        ' 
        Address_TxtBox.BackColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        Address_TxtBox.Font = New Font("Microsoft YaHei", 10.2F)
        Address_TxtBox.Location = New Point(133, 685)
        Address_TxtBox.Name = "Address_TxtBox"
        Address_TxtBox.Size = New Size(689, 30)
        Address_TxtBox.TabIndex = 7
        ' 
        ' Book_Btn
        ' 
        Book_Btn.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(215))
        Book_Btn.Font = New Font("Microsoft YaHei", 12.0F)
        Book_Btn.ForeColor = Color.Black
        Book_Btn.Location = New Point(592, 786)
        Book_Btn.Name = "Book_Btn"
        Book_Btn.Size = New Size(230, 51)
        Book_Btn.TabIndex = 8
        Book_Btn.Text = "Book Now"
        Book_Btn.UseVisualStyleBackColor = False
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(265, 109)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(239, 29)
        ProgressBar1.TabIndex = 0
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.LightGreen
        Label1.ForeColor = Color.LightGreen
        Label1.Location = New Point(39, 612)
        Label1.Name = "Label1"
        Label1.Size = New Size(53, 20)
        Label1.TabIndex = 9
        Label1.Text = "Label1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 10.0F)
        Label2.Location = New Point(98, 610)
        Label2.Name = "Label2"
        Label2.Size = New Size(76, 23)
        Label2.TabIndex = 10
        Label2.Text = "Free Slot"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.BackColor = Color.Green
        Label3.ForeColor = Color.Green
        Label3.Location = New Point(265, 613)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 20)
        Label3.TabIndex = 11
        Label3.Text = "Label3"
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 10.0F)
        Label4.Location = New Point(324, 612)
        Label4.Name = "Label4"
        Label4.Size = New Size(118, 23)
        Label4.TabIndex = 12
        Label4.Text = "Your Bookings"
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.BackColor = Color.Gray
        Label5.ForeColor = Color.Gray
        Label5.Location = New Point(503, 614)
        Label5.Name = "Label5"
        Label5.Size = New Size(53, 20)
        Label5.TabIndex = 12
        Label5.Text = "Label5"
        ' 
        ' Label6
        ' 
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 10.0F)
        Label6.Location = New Point(562, 611)
        Label6.Name = "Label6"
        Label6.Size = New Size(74, 23)
        Label6.TabIndex = 13
        Label6.Text = "Selected"
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        Label7.ForeColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        Label7.Location = New Point(702, 611)
        Label7.Name = "Label7"
        Label7.Size = New Size(53, 20)
        Label7.TabIndex = 14
        Label7.Text = "Label7"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.Font = New Font("Segoe UI", 10.0F)
        Label8.Location = New Point(763, 611)
        Label8.Name = "Label8"
        Label8.Size = New Size(98, 23)
        Label8.TabIndex = 15
        Label8.Text = "Unavailable"
        ' 
        ' Book_slots
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(932, 920)
        Controls.Add(Label8)
        Controls.Add(Label7)
        Controls.Add(Label6)
        Controls.Add(Label5)
        Controls.Add(Label4)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(ProgressBar1)
        Controls.Add(Book_Btn)
        Controls.Add(Address_TxtBox)
        Controls.Add(Address_Lbl)
        Controls.Add(Panel1)
        Controls.Add(Provider_Name_Loc_Lbl)
        Controls.Add(Back_Btn)
        Controls.Add(Username)
        Controls.Add(Profile_Pic)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.None
        Name = "Book_slots"
        Text = "Book_slots"
        CType(Profile_Pic, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Profile_Pic As PictureBox
    Friend WithEvents Username As Label
    Friend WithEvents Back_Btn As Button
    Friend WithEvents Provider_Name_Loc_Lbl As Label
    Friend WithEvents Schedule_Table As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Address_Lbl As Label
    Friend WithEvents Address_TxtBox As TextBox
    Friend WithEvents Book_Btn As Button
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
End Class
