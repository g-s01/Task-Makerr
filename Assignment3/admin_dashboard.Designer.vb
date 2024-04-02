<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class admin_dashboard
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
        Chart1 = New FastReport.DataVisualization.Charting.Chart()
        Chart2 = New FastReport.DataVisualization.Charting.Chart()
        Label1 = New Label()
        Label2 = New Label()
        Panel1 = New Panel()
        PictureBox1 = New PictureBox()
        Panel3 = New Panel()
        PictureBox3 = New PictureBox()
        Label7 = New Label()
        Label8 = New Label()
        Label9 = New Label()
        Panel4 = New Panel()
        PictureBox4 = New PictureBox()
        Label12 = New Label()
        Label13 = New Label()
        Panel5 = New Panel()
        PictureBox5 = New PictureBox()
        Label15 = New Label()
        Label16 = New Label()
        Label11 = New Label()
        Label14 = New Label()
        ProgressBar1 = New ProgressBar()
        Panel6 = New Panel()
        Label28 = New Label()
        Label27 = New Label()
        Label26 = New Label()
        Label25 = New Label()
        Label24 = New Label()
        Label23 = New Label()
        Label22 = New Label()
        Label21 = New Label()
        PictureBox6 = New PictureBox()
        Label20 = New Label()
        Label19 = New Label()
        Label18 = New Label()
        ProgressBar2 = New ProgressBar()
        Label17 = New Label()
        CType(Chart1, ComponentModel.ISupportInitialize).BeginInit()
        CType(Chart2, ComponentModel.ISupportInitialize).BeginInit()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        Panel3.SuspendLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        Panel4.SuspendLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        Panel5.SuspendLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        Panel6.SuspendLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Chart1
        ' 
        Chart1.Anchor = AnchorStyles.None
        Chart1.Location = New Point(3, 275)
        Chart1.Name = "Chart1"
        Chart1.Size = New Size(431, 333)
        Chart1.TabIndex = 0
        Chart1.Text = "Chart1"
        ' 
        ' Chart2
        ' 
        Chart2.Anchor = AnchorStyles.None
        Chart2.Location = New Point(452, 0)
        Chart2.Name = "Chart2"
        Chart2.Size = New Size(368, 227)
        Chart2.TabIndex = 1
        Chart2.Text = "Chart2"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ImageAlign = ContentAlignment.MiddleLeft
        Label1.Location = New Point(12, 86)
        Label1.Name = "Label1"
        Label1.Size = New Size(175, 38)
        Label1.TabIndex = 2
        Label1.Text = "Rs. 5,00,000"
        Label1.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ControlDarkDark
        Label2.ImageAlign = ContentAlignment.MiddleLeft
        Label2.Location = New Point(12, 123)
        Label2.Name = "Label2"
        Label2.Size = New Size(134, 32)
        Label2.TabIndex = 3
        Label2.Text = "Total Sales"
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.None
        Panel1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Panel1.Controls.Add(PictureBox1)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(Label2)
        Panel1.Location = New Point(31, 22)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(176, 205)
        Panel1.TabIndex = 5
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.totalsalesicon
        PictureBox1.Location = New Point(26, 17)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(49, 53)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Panel3
        ' 
        Panel3.Anchor = AnchorStyles.None
        Panel3.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Panel3.Controls.Add(PictureBox3)
        Panel3.Controls.Add(Label7)
        Panel3.Controls.Add(Label8)
        Panel3.Controls.Add(Label9)
        Panel3.Location = New Point(244, 22)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(176, 205)
        Panel3.TabIndex = 6
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.cancellationsicon
        PictureBox3.Location = New Point(26, 17)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(49, 53)
        PictureBox3.TabIndex = 3
        PictureBox3.TabStop = False
        ' 
        ' Label7
        ' 
        Label7.AutoSize = True
        Label7.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label7.Font = New Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.ForeColor = Color.LightSeaGreen
        Label7.Location = New Point(12, 166)
        Label7.Name = "Label7"
        Label7.Size = New Size(170, 25)
        Label7.TabIndex = 4
        Label7.Text = "66% from User Side"
        ' 
        ' Label8
        ' 
        Label8.AutoSize = True
        Label8.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label8.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.ImageAlign = ContentAlignment.MiddleLeft
        Label8.Location = New Point(12, 86)
        Label8.Name = "Label8"
        Label8.Size = New Size(33, 38)
        Label8.TabIndex = 2
        Label8.Text = "3"
        Label8.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label9
        ' 
        Label9.AutoSize = True
        Label9.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label9.ForeColor = SystemColors.ControlDarkDark
        Label9.ImageAlign = ContentAlignment.MiddleLeft
        Label9.Location = New Point(12, 123)
        Label9.Name = "Label9"
        Label9.Size = New Size(166, 32)
        Label9.TabIndex = 3
        Label9.Text = "Cancellations"
        ' 
        ' Panel4
        ' 
        Panel4.Anchor = AnchorStyles.None
        Panel4.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Panel4.Controls.Add(PictureBox4)
        Panel4.Controls.Add(Label12)
        Panel4.Controls.Add(Label13)
        Panel4.Location = New Point(447, 275)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(176, 169)
        Panel4.TabIndex = 6
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackgroundImage = My.Resources.Resources.totalusersicon
        PictureBox4.Location = New Point(26, 17)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(49, 45)
        PictureBox4.TabIndex = 3
        PictureBox4.TabStop = False
        ' 
        ' Label12
        ' 
        Label12.AutoSize = True
        Label12.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label12.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label12.ImageAlign = ContentAlignment.MiddleLeft
        Label12.Location = New Point(12, 86)
        Label12.Name = "Label12"
        Label12.Size = New Size(81, 38)
        Label12.TabIndex = 2
        Label12.Text = "1200"
        Label12.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label13
        ' 
        Label13.AutoSize = True
        Label13.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label13.ForeColor = SystemColors.ControlDarkDark
        Label13.ImageAlign = ContentAlignment.MiddleLeft
        Label13.Location = New Point(12, 115)
        Label13.Name = "Label13"
        Label13.Size = New Size(139, 32)
        Label13.TabIndex = 3
        Label13.Text = "Total Users"
        ' 
        ' Panel5
        ' 
        Panel5.Anchor = AnchorStyles.None
        Panel5.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Panel5.Controls.Add(PictureBox5)
        Panel5.Controls.Add(Label15)
        Panel5.Controls.Add(Label16)
        Panel5.Location = New Point(634, 275)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(176, 169)
        Panel5.TabIndex = 6
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackgroundImage = My.Resources.Resources.totalprovidersicon
        PictureBox5.Location = New Point(26, 17)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(49, 45)
        PictureBox5.TabIndex = 3
        PictureBox5.TabStop = False
        ' 
        ' Label15
        ' 
        Label15.AutoSize = True
        Label15.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label15.Font = New Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label15.ImageAlign = ContentAlignment.MiddleLeft
        Label15.Location = New Point(12, 86)
        Label15.Name = "Label15"
        Label15.Size = New Size(65, 38)
        Label15.TabIndex = 2
        Label15.Text = "200"
        Label15.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label16
        ' 
        Label16.AutoSize = True
        Label16.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label16.ForeColor = SystemColors.ControlDarkDark
        Label16.ImageAlign = ContentAlignment.MiddleLeft
        Label16.Location = New Point(12, 115)
        Label16.Name = "Label16"
        Label16.Size = New Size(186, 32)
        Label16.TabIndex = 3
        Label16.Text = "Total Providers"
        ' 
        ' Label11
        ' 
        Label11.Anchor = AnchorStyles.None
        Label11.AutoSize = True
        Label11.BackColor = SystemColors.Control
        Label11.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label11.ImageAlign = ContentAlignment.MiddleLeft
        Label11.Location = New Point(536, 231)
        Label11.Name = "Label11"
        Label11.Size = New Size(285, 32)
        Label11.TabIndex = 5
        Label11.Text = "Deals Mapping by Citites"
        Label11.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label14
        ' 
        Label14.Anchor = AnchorStyles.None
        Label14.AutoSize = True
        Label14.BackColor = SystemColors.Control
        Label14.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label14.ImageAlign = ContentAlignment.MiddleLeft
        Label14.Location = New Point(86, 247)
        Label14.Name = "Label14"
        Label14.Size = New Size(337, 32)
        Label14.TabIndex = 7
        Label14.Text = "New Users per day Last Week"
        Label14.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ProgressBar1
        ' 
        ProgressBar1.BackColor = Color.FromArgb(CByte(192), CByte(0), CByte(192))
        ProgressBar1.Location = New Point(125, 53)
        ProgressBar1.Name = "ProgressBar1"
        ProgressBar1.Size = New Size(228, 14)
        ProgressBar1.TabIndex = 8
        ' 
        ' Panel6
        ' 
        Panel6.Anchor = AnchorStyles.None
        Panel6.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Panel6.Controls.Add(Label28)
        Panel6.Controls.Add(Label27)
        Panel6.Controls.Add(Label26)
        Panel6.Controls.Add(Label25)
        Panel6.Controls.Add(Label24)
        Panel6.Controls.Add(Label23)
        Panel6.Controls.Add(Label22)
        Panel6.Controls.Add(Label21)
        Panel6.Controls.Add(PictureBox6)
        Panel6.Controls.Add(Label20)
        Panel6.Controls.Add(Label19)
        Panel6.Controls.Add(Label18)
        Panel6.Controls.Add(ProgressBar2)
        Panel6.Controls.Add(Label17)
        Panel6.Controls.Add(ProgressBar1)
        Panel6.Location = New Point(447, 473)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(363, 114)
        Panel6.TabIndex = 7
        ' 
        ' Label28
        ' 
        Label28.Location = New Point(310, 81)
        Label28.Name = "Label28"
        Label28.Size = New Size(10, 16)
        Label28.TabIndex = 19
        ' 
        ' Label27
        ' 
        Label27.Location = New Point(262, 80)
        Label27.Name = "Label27"
        Label27.Size = New Size(10, 16)
        Label27.TabIndex = 18
        ' 
        ' Label26
        ' 
        Label26.Location = New Point(217, 80)
        Label26.Name = "Label26"
        Label26.Size = New Size(10, 16)
        Label26.TabIndex = 17
        ' 
        ' Label25
        ' 
        Label25.Location = New Point(171, 81)
        Label25.Name = "Label25"
        Label25.Size = New Size(10, 16)
        Label25.TabIndex = 16
        ' 
        ' Label24
        ' 
        Label24.Location = New Point(305, 49)
        Label24.Name = "Label24"
        Label24.Size = New Size(10, 16)
        Label24.TabIndex = 15
        ' 
        ' Label23
        ' 
        Label23.Location = New Point(260, 49)
        Label23.Name = "Label23"
        Label23.Size = New Size(10, 16)
        Label23.TabIndex = 14
        ' 
        ' Label22
        ' 
        Label22.Location = New Point(210, 49)
        Label22.Name = "Label22"
        Label22.Size = New Size(10, 16)
        Label22.TabIndex = 13
        ' 
        ' Label21
        ' 
        Label21.Location = New Point(160, 51)
        Label21.Name = "Label21"
        Label21.Size = New Size(10, 16)
        Label21.TabIndex = 12
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackgroundImage = My.Resources.Resources.staradmindash
        PictureBox6.Location = New Point(334, 6)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(25, 25)
        PictureBox6.TabIndex = 5
        PictureBox6.TabStop = False
        ' 
        ' Label20
        ' 
        Label20.AutoSize = True
        Label20.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label20.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label20.ImageAlign = ContentAlignment.MiddleLeft
        Label20.Location = New Point(215, 7)
        Label20.Name = "Label20"
        Label20.Size = New Size(144, 32)
        Label20.TabIndex = 11
        Label20.Text = "Overall : 4.2"
        Label20.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label19
        ' 
        Label19.AutoSize = True
        Label19.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label19.Font = New Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label19.ImageAlign = ContentAlignment.MiddleLeft
        Label19.Location = New Point(10, 7)
        Label19.Name = "Label19"
        Label19.Size = New Size(111, 38)
        Label19.TabIndex = 4
        Label19.Text = "Ratings"
        Label19.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' Label18
        ' 
        Label18.AutoSize = True
        Label18.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label18.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label18.ImageAlign = ContentAlignment.MiddleLeft
        Label18.Location = New Point(11, 77)
        Label18.Name = "Label18"
        Label18.Size = New Size(121, 32)
        Label18.TabIndex = 10
        Label18.Text = "Providers'"
        Label18.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ProgressBar2
        ' 
        ProgressBar2.Location = New Point(132, 83)
        ProgressBar2.Name = "ProgressBar2"
        ProgressBar2.Size = New Size(228, 14)
        ProgressBar2.TabIndex = 9
        ' 
        ' Label17
        ' 
        Label17.AutoSize = True
        Label17.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Label17.Font = New Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label17.ImageAlign = ContentAlignment.MiddleLeft
        Label17.Location = New Point(11, 48)
        Label17.Name = "Label17"
        Label17.Size = New Size(79, 32)
        Label17.TabIndex = 8
        Label17.Text = "Users'"
        Label17.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' admin_dashboard
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(822, 610)
        Controls.Add(Panel6)
        Controls.Add(Label14)
        Controls.Add(Label11)
        Controls.Add(Panel5)
        Controls.Add(Panel4)
        Controls.Add(Panel3)
        Controls.Add(Panel1)
        Controls.Add(Chart2)
        Controls.Add(Chart1)
        Name = "admin_dashboard"
        Text = "Form2"
        CType(Chart1, ComponentModel.ISupportInitialize).EndInit()
        CType(Chart2, ComponentModel.ISupportInitialize).EndInit()
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Chart1 As FastReport.DataVisualization.Charting.Chart

    Private Sub Chart1_Click(sender As Object, e As EventArgs) Handles Chart1.Click

    End Sub

    Friend WithEvents Chart2 As FastReport.DataVisualization.Charting.Chart
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Panel3 As Panel
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Panel4 As Panel
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents Label12 As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents Label15 As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label14 As Label
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label17 As Label
    Friend WithEvents Label18 As Label
    Friend WithEvents ProgressBar2 As ProgressBar
    Friend WithEvents Label20 As Label
    Friend WithEvents Label19 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label21 As Label
    Friend WithEvents Label27 As Label
    Friend WithEvents Label26 As Label
    Friend WithEvents Label25 As Label
    Friend WithEvents Label24 As Label
    Friend WithEvents Label23 As Label
    Friend WithEvents Label22 As Label
    Friend WithEvents Label28 As Label
End Class
