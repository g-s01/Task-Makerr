<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class user_search
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
        TextBox1 = New TextBox()
        PictureBox1 = New PictureBox()
        TableLayoutPanel1 = New TableLayoutPanel()
        Panel7 = New Panel()
        Label7 = New Label()
        Panel2 = New Panel()
        Label2 = New Label()
        Panel3 = New Panel()
        Label3 = New Label()
        Panel4 = New Panel()
        Label4 = New Label()
        Panel5 = New Panel()
        Label5 = New Label()
        Panel6 = New Panel()
        Label6 = New Label()
        providersTablePanel = New TableLayoutPanel()
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        ComboBox3 = New ComboBox()
        Button1 = New Button()
        PictureBox2 = New PictureBox()
        Label1 = New Label()
        Button2 = New Button()
        Panel1.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        TableLayoutPanel1.SuspendLayout()
        Panel7.SuspendLayout()
        Panel2.SuspendLayout()
        Panel3.SuspendLayout()
        Panel4.SuspendLayout()
        Panel5.SuspendLayout()
        Panel6.SuspendLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BorderStyle = BorderStyle.FixedSingle
        Panel1.Controls.Add(TextBox1)
        Panel1.Controls.Add(PictureBox1)
        Panel1.Location = New Point(36, 22)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(680, 42)
        Panel1.TabIndex = 0
        ' 
        ' TextBox1
        ' 
        TextBox1.BorderStyle = BorderStyle.None
        TextBox1.ForeColor = Color.Gray
        TextBox1.Location = New Point(50, 10)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(622, 20)
        TextBox1.TabIndex = 2
        TextBox1.Text = "Search for providers by name"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.search
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.Location = New Point(1, -1)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(43, 42)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' TableLayoutPanel1
        ' 
        TableLayoutPanel1.AutoScroll = True
        TableLayoutPanel1.BackColor = Color.FromArgb(CByte(240), CByte(218), CByte(248))
        TableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        TableLayoutPanel1.ColumnCount = 6
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 230F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 150F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        TableLayoutPanel1.ColumnStyles.Add(New ColumnStyle())
        TableLayoutPanel1.Controls.Add(Panel7, 5, 0)
        TableLayoutPanel1.Controls.Add(Panel2, 0, 0)
        TableLayoutPanel1.Controls.Add(Panel3, 1, 0)
        TableLayoutPanel1.Controls.Add(Panel4, 2, 0)
        TableLayoutPanel1.Controls.Add(Panel5, 3, 0)
        TableLayoutPanel1.Controls.Add(Panel6, 4, 0)
        TableLayoutPanel1.Location = New Point(36, 148)
        TableLayoutPanel1.Margin = New Padding(0)
        TableLayoutPanel1.Name = "TableLayoutPanel1"
        TableLayoutPanel1.RowCount = 1
        TableLayoutPanel1.RowStyles.Add(New RowStyle(SizeType.Percent, 100F))
        TableLayoutPanel1.Size = New Size(768, 44)
        TableLayoutPanel1.TabIndex = 1
        ' 
        ' Panel7
        ' 
        Panel7.Controls.Add(Label7)
        Panel7.Location = New Point(686, 1)
        Panel7.Margin = New Padding(0)
        Panel7.Name = "Panel7"
        Panel7.Size = New Size(82, 42)
        Panel7.TabIndex = 10
        ' 
        ' Label7
        ' 
        Label7.Anchor = AnchorStyles.None
        Label7.AutoSize = True
        Label7.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label7.Location = New Point(9, 7)
        Label7.Margin = New Padding(0)
        Label7.Name = "Label7"
        Label7.Size = New Size(64, 28)
        Label7.TabIndex = 3
        Label7.Text = "Select"
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(1, 1)
        Panel2.Margin = New Padding(0)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(230, 42)
        Panel2.TabIndex = 2
        ' 
        ' Label2
        ' 
        Label2.Anchor = AnchorStyles.None
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(42, 7)
        Label2.Margin = New Padding(0)
        Label2.Name = "Label2"
        Label2.Size = New Size(143, 28)
        Label2.TabIndex = 3
        Label2.Text = "Provider Name"
        ' 
        ' Panel3
        ' 
        Panel3.Controls.Add(Label3)
        Panel3.Location = New Point(232, 1)
        Panel3.Margin = New Padding(0)
        Panel3.Name = "Panel3"
        Panel3.Size = New Size(100, 42)
        Panel3.TabIndex = 3
        ' 
        ' Label3
        ' 
        Label3.Anchor = AnchorStyles.None
        Label3.AutoSize = True
        Label3.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(13, 7)
        Label3.Margin = New Padding(0)
        Label3.Name = "Label3"
        Label3.Size = New Size(74, 28)
        Label3.TabIndex = 3
        Label3.Text = "Service"
        ' 
        ' Panel4
        ' 
        Panel4.Controls.Add(Label4)
        Panel4.Location = New Point(333, 1)
        Panel4.Margin = New Padding(0)
        Panel4.Name = "Panel4"
        Panel4.Size = New Size(100, 42)
        Panel4.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.Anchor = AnchorStyles.None
        Label4.AutoSize = True
        Label4.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(7, 7)
        Label4.Margin = New Padding(0)
        Label4.Name = "Label4"
        Label4.Size = New Size(87, 28)
        Label4.TabIndex = 3
        Label4.Text = "Location"
        ' 
        ' Panel5
        ' 
        Panel5.Controls.Add(Label5)
        Panel5.Location = New Point(434, 1)
        Panel5.Margin = New Padding(0)
        Panel5.Name = "Panel5"
        Panel5.Size = New Size(150, 42)
        Panel5.TabIndex = 5
        ' 
        ' Label5
        ' 
        Label5.Anchor = AnchorStyles.None
        Label5.AutoSize = True
        Label5.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label5.Location = New Point(15, 7)
        Label5.Margin = New Padding(0)
        Label5.Name = "Label5"
        Label5.Size = New Size(122, 28)
        Label5.TabIndex = 3
        Label5.Text = "Cost per slot"
        ' 
        ' Panel6
        ' 
        Panel6.Controls.Add(Label6)
        Panel6.Location = New Point(585, 1)
        Panel6.Margin = New Padding(0)
        Panel6.Name = "Panel6"
        Panel6.Size = New Size(100, 42)
        Panel6.TabIndex = 6
        ' 
        ' Label6
        ' 
        Label6.Anchor = AnchorStyles.None
        Label6.AutoSize = True
        Label6.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label6.Location = New Point(11, 7)
        Label6.Margin = New Padding(0)
        Label6.Name = "Label6"
        Label6.Size = New Size(77, 28)
        Label6.TabIndex = 3
        Label6.Text = "Ratings"
        ' 
        ' providersTablePanel
        ' 
        providersTablePanel.AutoScroll = True
        providersTablePanel.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        providersTablePanel.ColumnCount = 6
        providersTablePanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 230F))
        providersTablePanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        providersTablePanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        providersTablePanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 150F))
        providersTablePanel.ColumnStyles.Add(New ColumnStyle(SizeType.Absolute, 100F))
        providersTablePanel.ColumnStyles.Add(New ColumnStyle())
        providersTablePanel.Location = New Point(37, 192)
        providersTablePanel.Margin = New Padding(0)
        providersTablePanel.Name = "providersTablePanel"
        providersTablePanel.RowCount = 1
        providersTablePanel.RowStyles.Add(New RowStyle())
        providersTablePanel.RowStyles.Add(New RowStyle(SizeType.Absolute, 20F))
        providersTablePanel.Size = New Size(767, 372)
        providersTablePanel.TabIndex = 2
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Anchor = AnchorStyles.None
        ComboBox1.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox1.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(36, 81)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(151, 31)
        ComboBox1.TabIndex = 3
        ' 
        ' ComboBox2
        ' 
        ComboBox2.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox2.Font = New Font("Segoe UI", 10.2F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(217, 81)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(151, 31)
        ComboBox2.TabIndex = 4
        ' 
        ' ComboBox3
        ' 
        ComboBox3.DropDownStyle = ComboBoxStyle.DropDownList
        ComboBox3.Font = New Font("Segoe UI", 10.2F)
        ComboBox3.FormattingEnabled = True
        ComboBox3.Items.AddRange(New Object() {"Cost (Increasing)", "Cost (Decreasing)", "Ratings"})
        ComboBox3.Location = New Point(397, 81)
        ComboBox3.Name = "ComboBox3"
        ComboBox3.Size = New Size(151, 31)
        ComboBox3.TabIndex = 5
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Button1.FlatStyle = FlatStyle.Popup
        Button1.Location = New Point(604, 81)
        Button1.Margin = New Padding(0)
        Button1.Name = "Button1"
        Button1.Size = New Size(112, 31)
        Button1.TabIndex = 6
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImageLayout = ImageLayout.Stretch
        PictureBox2.InitialImage = Nothing
        PictureBox2.Location = New Point(754, 22)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(50, 50)
        PictureBox2.SizeMode = PictureBoxSizeMode.StretchImage
        PictureBox2.TabIndex = 7
        PictureBox2.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(743, 75)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 20)
        Label1.TabIndex = 8
        Label1.Text = "Username"
        ' 
        ' Button2
        ' 
        Button2.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Button2.FlatStyle = FlatStyle.Popup
        Button2.Location = New Point(366, 597)
        Button2.Margin = New Padding(0)
        Button2.Name = "Button2"
        Button2.Size = New Size(112, 31)
        Button2.TabIndex = 9
        Button2.Text = "Book a Slot"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' user_search
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        ClientSize = New Size(844, 666)
        Controls.Add(Button2)
        Controls.Add(Label1)
        Controls.Add(PictureBox2)
        Controls.Add(Button1)
        Controls.Add(ComboBox3)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        Controls.Add(providersTablePanel)
        Controls.Add(Panel1)
        Controls.Add(TableLayoutPanel1)
        FormBorderStyle = FormBorderStyle.None
        Name = "user_search"
        Text = "user_search"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        TableLayoutPanel1.ResumeLayout(False)
        Panel7.ResumeLayout(False)
        Panel7.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        Panel3.ResumeLayout(False)
        Panel3.PerformLayout()
        Panel4.ResumeLayout(False)
        Panel4.PerformLayout()
        Panel5.ResumeLayout(False)
        Panel5.PerformLayout()
        Panel6.ResumeLayout(False)
        Panel6.PerformLayout()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TableLayoutPanel1 As TableLayoutPanel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents Panel4 As Panel
    Friend WithEvents Label4 As Label
    Friend WithEvents Panel5 As Panel
    Friend WithEvents Label5 As Label
    Friend WithEvents Panel6 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents providersTablePanel As TableLayoutPanel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents ComboBox3 As ComboBox
    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel7 As Panel
    Friend WithEvents Label7 As Label
End Class
