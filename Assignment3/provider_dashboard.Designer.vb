Imports System.Windows.Forms.DataVisualization.Charting

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class provider_dashboard
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
        Label24 = New Label()
        Label23 = New Label()
        Label22 = New Label()
        Label21 = New Label()
        Label20 = New Label()
        Label19 = New Label()
        Label18 = New Label()
        Label17 = New Label()
        Label16 = New Label()
        Label15 = New Label()
        Label14 = New Label()
        Label13 = New Label()
        Label12 = New Label()
        slot_matrix_tablelayout = New TableLayoutPanel()
        Label8 = New Label()
        Label7 = New Label()
        Label6 = New Label()
        Label5 = New Label()
        Label9 = New Label()
        Label10 = New Label()
        Label11 = New Label()
        Label1 = New Label()
        Panel2 = New Panel()
        PictureBox3 = New PictureBox()
        Chart1 = New FastReport.DataVisualization.Charting.Chart()
        Label2 = New Label()
        Panel3 = New Panel()
        Panel4 = New Panel()
        Label25 = New Label()
        Label26 = New Label()
        PictureBox2 = New PictureBox()
        Panel5 = New Panel()
        Label4 = New Label()
        Label3 = New Label()
        PictureBox1 = New PictureBox()
        Panel1.SuspendLayout()
        slot_matrix_tablelayout.SuspendLayout()
        Panel2.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ButtonHighlight
        Panel1.BorderStyle = BorderStyle.Fixed3D
        Panel1.Controls.Add(Label24)
        Panel1.Controls.Add(Label23)
        Panel1.Controls.Add(Label22)
        Panel1.Controls.Add(Label21)
        Panel1.Controls.Add(Label20)
        Panel1.Controls.Add(Label19)
        Panel1.Controls.Add(Label18)
        Panel1.Controls.Add(Label17)
        Panel1.Controls.Add(Label16)
        Panel1.Controls.Add(Label15)
        Panel1.Controls.Add(Label14)
        Panel1.Controls.Add(Label13)
        Panel1.Controls.Add(Label12)
        Panel1.Controls.Add(slot_matrix_tablelayout)
        Panel1.Controls.Add(Label1)
        Panel1.Dock = DockStyle.Top
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Padding = New Padding(10)
        Panel1.Size = New Size(842, 330)
        Panel1.TabIndex = 0
        ' 
        ' Label24
        ' 
        Label24.AutoSize = True
        Label24.Location = New Point(789, 64)
        Label24.Name = "Label24"
        Label24.Size = New Size(39, 20)
        Label24.TabIndex = 41
        Label24.Text = "9pm"
        ' 
        ' Label23
        ' 
        Label23.AutoSize = True
        Label23.Location = New Point(733, 64)
        Label23.Name = "Label23"
        Label23.Size = New Size(39, 20)
        Label23.TabIndex = 40
        Label23.Text = "8pm"
        ' 
        ' Label22
        ' 
        Label22.AutoSize = True
        Label22.Location = New Point(676, 64)
        Label22.Name = "Label22"
        Label22.Size = New Size(39, 20)
        Label22.TabIndex = 39
        Label22.Text = "7pm"
        ' 
        ' Label21
        ' 
        Label21.AutoSize = True
        Label21.Location = New Point(613, 64)
        Label21.Name = "Label21"
        Label21.Size = New Size(39, 20)
        Label21.TabIndex = 38
        Label21.Text = "6pm"
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.Location = New Point(557, 64)
        Label20.Name = "Label20"
        Label20.Size = New Size(39, 20)
        Label20.TabIndex = 37
        Label20.Text = "5pm"
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.Location = New Point(503, 64)
        Label19.Name = "Label19"
        Label19.Size = New Size(39, 20)
        Label19.TabIndex = 36
        Label19.Text = "4pm"
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.Location = New Point(444, 64)
        Label18.Name = "Label18"
        Label18.Size = New Size(39, 20)
        Label18.TabIndex = 35
        Label18.Text = "3pm"
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.Location = New Point(383, 64)
        Label17.Name = "Label17"
        Label17.Size = New Size(39, 20)
        Label17.TabIndex = 34
        Label17.Text = "2pm"
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Location = New Point(329, 64)
        Label16.Name = "Label16"
        Label16.Size = New Size(39, 20)
        Label16.TabIndex = 33
        Label16.Text = "1pm"
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.Location = New Point(265, 64)
        Label15.Name = "Label15"
        Label15.Size = New Size(47, 20)
        Label15.TabIndex = 32
        Label15.Text = "12pm"
        ' 
        ' Label14
        ' 
        Label14.AutoSize = True
        Label14.Location = New Point(203, 64)
        Label14.Name = "Label14"
        Label14.Size = New Size(46, 20)
        Label14.TabIndex = 31
        Label14.Text = "11am"
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Location = New Point(151, 64)
        Label13.Name = "Label13"
        Label13.Size = New Size(46, 20)
        Label13.TabIndex = 30
        Label13.Text = "10am"
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.Location = New Point(98, 64)
        Label12.Name = "Label12"
        Label12.Size = New Size(38, 20)
        Label12.TabIndex = 29
        Label12.Text = "9am"
        ' 
        ' slot_matrix_tablelayout
        ' 
        slot_matrix_tablelayout.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        slot_matrix_tablelayout.ColumnCount = 13
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 8.387292F))
        slot_matrix_tablelayout.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, 7.73979425F))
        slot_matrix_tablelayout.Controls.Add(Label8, 0, 6)
        slot_matrix_tablelayout.Controls.Add(Label7, 0, 5)
        slot_matrix_tablelayout.Controls.Add(Label6, 0, 4)
        slot_matrix_tablelayout.Controls.Add(Label5, 0, 3)
        slot_matrix_tablelayout.Controls.Add(Label9, 0, 2)
        slot_matrix_tablelayout.Controls.Add(Label10, 0, 1)
        slot_matrix_tablelayout.Controls.Add(Label11, 0, 0)
        slot_matrix_tablelayout.Location = New Point(13, 88)
        slot_matrix_tablelayout.Margin = New Padding(3, 4, 3, 4)
        slot_matrix_tablelayout.Name = "slot_matrix_tablelayout"
        slot_matrix_tablelayout.RowCount = 7
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.RowStyles.Add(New RowStyle(SizeType.Percent, 14.2857141F))
        slot_matrix_tablelayout.Size = New Size(795, 218)
        slot_matrix_tablelayout.TabIndex = 28
        ' 
        ' Label8
        ' 
        Label8.Dock = DockStyle.Fill
        Label8.Location = New Point(4, 187)
        Label8.Name = "Label8"
        Label8.Size = New Size(94, 30)
        Label8.TabIndex = 6
        Label8.Text = "Sun"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label7
        ' 
        Label7.Dock = DockStyle.Fill
        Label7.Location = New Point(4, 156)
        Label7.Name = "Label7"
        Label7.Size = New Size(94, 30)
        Label7.TabIndex = 5
        Label7.Text = "Sat"
        Label7.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label6
        ' 
        Label6.Dock = DockStyle.Fill
        Label6.Location = New Point(4, 125)
        Label6.Name = "Label6"
        Label6.Size = New Size(94, 30)
        Label6.TabIndex = 4
        Label6.Text = "Fri"
        Label6.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label5
        ' 
        Label5.Dock = DockStyle.Fill
        Label5.Location = New Point(4, 94)
        Label5.Name = "Label5"
        Label5.Size = New Size(94, 30)
        Label5.TabIndex = 3
        Label5.Text = "Thru"
        Label5.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label9
        ' 
        Label9.Dock = DockStyle.Fill
        Label9.Location = New Point(4, 63)
        Label9.Name = "Label9"
        Label9.Size = New Size(94, 30)
        Label9.TabIndex = 2
        Label9.Text = "Wed"
        Label9.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label10
        ' 
        Label10.Dock = DockStyle.Fill
        Label10.Location = New Point(4, 32)
        Label10.Name = "Label10"
        Label10.Size = New Size(94, 30)
        Label10.TabIndex = 1
        Label10.Text = "Tue"
        Label10.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label11
        ' 
        Label11.Dock = DockStyle.Fill
        Label11.Location = New Point(4, 1)
        Label11.Name = "Label11"
        Label11.Size = New Size(94, 30)
        Label11.TabIndex = 0
        Label11.Text = "Mon"
        Label11.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label1.Location = New Point(41, 19)
        Label1.Name = "Label1"
        Label1.Size = New Size(134, 30)
        Label1.TabIndex = 3
        Label1.Text = "Weekly Slot"
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = SystemColors.ButtonHighlight
        Panel2.BorderStyle = BorderStyle.Fixed3D
        Panel2.Controls.Add(PictureBox3)
        Panel2.Controls.Add(Chart1)
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(0, 338)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(677, 323)
        Panel2.TabIndex = 1
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.more_horiz
        PictureBox3.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox3.Location = New Point(624, 15)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(28, 26)
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' Chart1
        ' 
        Chart1.Location = New Point(31, 72)
        Chart1.Name = "Chart1"
        Chart1.Size = New Size(621, 233)
        Chart1.TabIndex = 2
        Chart1.Text = "Chart1"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 13.0F, FontStyle.Bold)
        Label2.Location = New Point(31, 11)
        Label2.Name = "Label2"
        Label2.Size = New Size(154, 30)
        Label2.TabIndex = 1
        Label2.Text = "Your Earnings"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Panel4)
        Panel3.Controls.Add(Panel5)
        Panel3.Dock = DockStyle.Right
        Panel3.Location = New Point(678, 330)
        Panel3.Name = "Panel3"
        Panel3.Padding = New Padding(5)
        Panel3.Size = New Size(164, 336)
        Panel3.TabIndex = 2
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        Panel4.BackColor = Color.FromArgb(CByte(244), CByte(217), CByte(255))
        Panel4.BorderStyle = BorderStyle.Fixed3D
        Panel4.Controls.Add(Label25)
        Panel4.Controls.Add(Label26)
        Panel4.Controls.Add(PictureBox2)
        Panel4.Location = New Point(5, 164)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(154, 167)
        Panel4.TabIndex = 5
        ' 
        ' Label25
        ' 
        Label25.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label25.Location = New Point(8, 73)
        Label25.Name = "Label25"
        Label25.Size = New Size(132, 25)
        Label25.TabIndex = 2
        Label25.Text = "Rs 12000"
        Label25.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label26
        ' 
        Label26.Location = New Point(3, 103)
        Label26.Name = "Label26"
        Label26.Size = New Size(137, 29)
        Label26.TabIndex = 1
        Label26.Text = "Total Earnings"
        Label26.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.FromArgb(CByte(244), CByte(217), CByte(255))
        PictureBox2.BackgroundImage = My.Resources.Resources.iconamoon_delivery_free_duotone
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.Location = New Point(8, 12)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(46, 40)
        PictureBox2.TabIndex = 0
        PictureBox2.TabStop = False
        ' 
        ' Panel5
        ' 
        Panel5.BackColor = Color.FromArgb(CByte(244), CByte(217), CByte(255))
        Panel5.BorderStyle = BorderStyle.Fixed3D
        Panel5.Controls.Add(Label4)
        Panel5.Controls.Add(Label3)
        Panel5.Controls.Add(PictureBox1)
        Panel5.Dock = DockStyle.Top
        Panel5.Location = New Point(5, 5)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(154, 163)
        Panel5.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        Label4.Location = New Point(8, 73)
        Label4.Name = "Label4"
        Label4.Size = New Size(132, 25)
        Label4.TabIndex = 2
        Label4.Text = "120"
        Label4.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(8, 115)
        Label3.Name = "Label3"
        Label3.Size = New Size(137, 29)
        Label3.TabIndex = 1
        Label3.Text = "Total Customers"
        Label3.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(244), CByte(217), CByte(255))
        PictureBox1.BackgroundImage = My.Resources.Resources.Total_customer
        PictureBox1.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox1.Location = New Point(8, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(46, 40)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' provider_dashboard
        ' 
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(842, 666)
        Controls.Add(Panel3)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Name = "provider_dashboard"
        Text = "provider_dashboard"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        slot_matrix_tablelayout.ResumeLayout(False)
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel4.ResumeLayout(False)
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents slot_matrix_tablelayout As TableLayoutPanel
    Friend WithEvents Label8 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents Label17 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label15 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label21 As Label
    Friend WithEvents Chart1 As FastReport.DataVisualization.Charting.Chart
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label25 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
End Class


