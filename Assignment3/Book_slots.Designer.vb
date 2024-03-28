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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Profile_Pic = New PictureBox()
        Label1 = New Label()
        Button1 = New Button()
        Provider_Name_Loc_Lbl = New Label()
        Schedule_Table = New TableLayoutPanel()
        Panel1 = New Panel()
        Address_Lbl = New Label()
        TextBox1 = New TextBox()
        Button2 = New Button()
        CType(Profile_Pic, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Profile_Pic
        ' 
        Profile_Pic.Location = New Point(697, 12)
        Profile_Pic.Name = "Profile_Pic"
        Profile_Pic.Size = New Size(125, 62)
        Profile_Pic.TabIndex = 0
        Profile_Pic.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft Sans Serif", 10.2F)
        Label1.Location = New Point(697, 77)
        Label1.Name = "Label1"
        Label1.Size = New Size(86, 20)
        Label1.TabIndex = 1
        Label1.Text = "Username"
        ' 
        ' Button1
        ' 
        Button1.BackgroundImage = My.Resources.Resources.back
        Button1.BackgroundImageLayout = ImageLayout.Zoom
        Button1.Location = New Point(12, 37)
        Button1.Name = "Button1"
        Button1.Size = New Size(93, 37)
        Button1.TabIndex = 2
        Button1.UseVisualStyleBackColor = True
        ' 
        ' Provider_Name_Loc_Lbl
        ' 
        Provider_Name_Loc_Lbl.AutoSize = True
        Provider_Name_Loc_Lbl.Font = New Font("Microsoft Sans Serif", 13F)
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
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Controls.Add(Schedule_Table)
        Panel1.Location = New Point(15, 144)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(807, 302)
        Panel1.TabIndex = 5
        ' 
        ' Address_Lbl
        ' 
        Address_Lbl.AutoSize = True
        Address_Lbl.Font = New Font("Microsoft YaHei", 13F)
        Address_Lbl.Location = New Point(15, 495)
        Address_Lbl.Name = "Address_Lbl"
        Address_Lbl.Size = New Size(96, 30)
        Address_Lbl.TabIndex = 6
        Address_Lbl.Text = "Address"
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.FromArgb(CByte(247), CByte(231), CByte(248))
        TextBox1.Font = New Font("Microsoft YaHei", 10.2F)
        TextBox1.Location = New Point(133, 498)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(689, 30)
        TextBox1.TabIndex = 7
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(215))
        Button2.Font = New Font("Microsoft YaHei", 12F)
        Button2.ForeColor = Color.Black
        Button2.Location = New Point(566, 584)
        Button2.Name = "Button2"
        Button2.Size = New Size(230, 51)
        Button2.TabIndex = 8
        Button2.Text = "Book Now"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Book_slots
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(844, 666)
        Controls.Add(Button2)
        Controls.Add(TextBox1)
        Controls.Add(Address_Lbl)
        Controls.Add(Panel1)
        Controls.Add(Provider_Name_Loc_Lbl)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(Profile_Pic)
        Font = New Font("Segoe UI", 9F)
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
    Friend WithEvents Label1 As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents Provider_Name_Loc_Lbl As Label
    Friend WithEvents Schedule_Table As TableLayoutPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Address_Lbl As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button2 As Button
End Class
