<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Reschedule_Slots
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
        Book_Btn = New Button()
        Address_TxtBox = New TextBox()
        Address_Lbl = New Label()
        Panel1 = New Panel()
        Schedule_Table = New TableLayoutPanel()
        Provider_Name_Loc_Lbl = New Label()
        Back_Btn = New Button()
        Username = New Label()
        Profile_Pic = New PictureBox()
        ProgressBar1 = New ProgressBar()
        Panel1.SuspendLayout()
        CType(Profile_Pic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Book_Btn
        ' 
        Book_Btn.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(215))
        Book_Btn.Font = New Font("Microsoft YaHei", 12F)
        Book_Btn.ForeColor = Color.Black
        Book_Btn.Location = New Point(571, 594)
        Book_Btn.Name = "Book_Btn"
        Book_Btn.Size = New Size(230, 51)
        Book_Btn.TabIndex = 16
        Book_Btn.Text = "Book Now"
        Book_Btn.UseVisualStyleBackColor = False
        ' 
        ' Address_TxtBox
        ' 
        Address_TxtBox.BackColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        Address_TxtBox.Font = New Font("Microsoft YaHei", 10.2F)
        Address_TxtBox.Location = New Point(138, 508)
        Address_TxtBox.Name = "Address_TxtBox"
        Address_TxtBox.Size = New Size(689, 30)
        Address_TxtBox.TabIndex = 15
        ' 
        ' Address_Lbl
        ' 
        Address_Lbl.AutoSize = True
        Address_Lbl.Font = New Font("Microsoft YaHei", 13F)
        Address_Lbl.Location = New Point(20, 505)
        Address_Lbl.Name = "Address_Lbl"
        Address_Lbl.Size = New Size(96, 30)
        Address_Lbl.TabIndex = 14
        Address_Lbl.Text = "Address"
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Schedule_Table)
        Panel1.Location = New Point(20, 154)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(807, 302)
        Panel1.TabIndex = 13
        ' 
        ' Schedule_Table
        ' 
        Schedule_Table.AutoScroll = True
        Schedule_Table.AutoSize = True
        Schedule_Table.BackColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        Schedule_Table.ColumnCount = 14
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 19.6245728F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 80.37543F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 305F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 22F))
        Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 20F))
        Schedule_Table.Location = New Point(3, 3)
        Schedule_Table.Name = "Schedule_Table"
        Schedule_Table.RowCount = 8
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Percent, 26.1083736F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Percent, 73.8916245F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        Schedule_Table.Size = New Size(801, 293)
        Schedule_Table.TabIndex = 4
        ' 
        ' Provider_Name_Loc_Lbl
        ' 
        Provider_Name_Loc_Lbl.AutoSize = True
        Provider_Name_Loc_Lbl.Font = New Font("Microsoft Sans Serif", 13F)
        Provider_Name_Loc_Lbl.Location = New Point(20, 98)
        Provider_Name_Loc_Lbl.Name = "Provider_Name_Loc_Lbl"
        Provider_Name_Loc_Lbl.Size = New Size(77, 26)
        Provider_Name_Loc_Lbl.TabIndex = 12
        Provider_Name_Loc_Lbl.Text = "Label2"
        ' 
        ' Back_Btn
        ' 
        Back_Btn.BackgroundImage = My.Resources.Resources.back
        Back_Btn.BackgroundImageLayout = ImageLayout.Zoom
        Back_Btn.Location = New Point(17, 47)
        Back_Btn.Name = "Back_Btn"
        Back_Btn.Size = New Size(93, 37)
        Back_Btn.TabIndex = 11
        Back_Btn.UseVisualStyleBackColor = True
        ' 
        ' Username
        ' 
        Username.AutoSize = True
        Username.Font = New Font("Microsoft Sans Serif", 10.2F)
        Username.Location = New Point(702, 87)
        Username.Name = "Username"
        Username.Size = New Size(86, 20)
        Username.TabIndex = 10
        Username.Text = "Username"
        ' 
        ' Profile_Pic
        ' 
        Profile_Pic.Location = New Point(702, 22)
        Profile_Pic.Name = "Profile_Pic"
        Profile_Pic.Size = New Size(125, 62)
        Profile_Pic.TabIndex = 9
        Profile_Pic.TabStop = False
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.Location = New Point(285, 110)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(239, 29)
        ProgressBar1.TabIndex = 17
        ' 
        ' Reschedule_Slots
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(844, 666)
        Controls.Add(ProgressBar1)
        Controls.Add(Book_Btn)
        Controls.Add(Address_TxtBox)
        Controls.Add(Address_Lbl)
        Controls.Add(Panel1)
        Controls.Add(Provider_Name_Loc_Lbl)
        Controls.Add(Back_Btn)
        Controls.Add(Username)
        Controls.Add(Profile_Pic)
        FormBorderStyle = FormBorderStyle.None
        Name = "Reschedule_Slots"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(Profile_Pic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Book_Btn As Button
    Friend WithEvents Address_TxtBox As TextBox
    Friend WithEvents Address_Lbl As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Schedule_Table As TableLayoutPanel
    Friend WithEvents Provider_Name_Loc_Lbl As Label
    Friend WithEvents Back_Btn As Button
    Friend WithEvents Username As Label
    Friend WithEvents Profile_Pic As PictureBox
    Friend WithEvents ProgressBar1 As ProgressBar
End Class
