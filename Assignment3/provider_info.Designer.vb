

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class provider_info
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
        Profile_Pic = New PictureBox()
        Username = New Label()
        Back_Btn = New Button()
        Provider_Name_Loc_Lbl = New Label()
        Schedule_Table = New TableLayoutPanel()
        Panel1 = New Panel()
        Address_Lbl = New Label()
        mainSplitContainer = New SplitContainer()
        upperHalfSplitContainer = New SplitContainer()
        upperRightPanel = New Panel()
        lowerHalfPanel = New Panel()
        nameLabel = New Label()
        serviceLabel = New Label()
        locationLabel = New Label()
        ratingLabel = New Label()
        SplitContainer1 = New SplitContainer()
        SplitContainer2 = New SplitContainer()
        CType(Profile_Pic, ComponentModel.ISupportInitialize).BeginInit()
        CType(mainSplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        mainSplitContainer.Panel1.SuspendLayout()
        mainSplitContainer.SuspendLayout()
        CType(upperHalfSplitContainer, ComponentModel.ISupportInitialize).BeginInit()
        upperHalfSplitContainer.Panel1.SuspendLayout()
        upperHalfSplitContainer.Panel2.SuspendLayout()
        upperHalfSplitContainer.SuspendLayout()
        upperRightPanel.SuspendLayout()
        lowerHalfPanel.SuspendLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.SuspendLayout()
        CType(SplitContainer2, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer2.SuspendLayout()
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
        Provider_Name_Loc_Lbl.Size = New Size(302, 26)
        Provider_Name_Loc_Lbl.TabIndex = 3
        Provider_Name_Loc_Lbl.Text = "> slot booking > worker profile"
        ' 
        ' Schedule_Table
        ' 
        Schedule_Table.Location = New Point(0, 0)
        Schedule_Table.Name = "Schedule_Table"
        Schedule_Table.Size = New Size(200, 100)
        Schedule_Table.TabIndex = 0
        ' 
        ' Panel1
        ' 
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(200, 100)
        Panel1.TabIndex = 0
        ' 
        ' Address_Lbl
        ' 
        Address_Lbl.Location = New Point(0, 0)
        Address_Lbl.Name = "Address_Lbl"
        Address_Lbl.Size = New Size(100, 23)
        Address_Lbl.TabIndex = 0
        ' 
        ' mainSplitContainer
        ' 
        mainSplitContainer.Dock = DockStyle.Fill
        mainSplitContainer.Location = New Point(0, 0)
        mainSplitContainer.Name = "mainSplitContainer"
        mainSplitContainer.Orientation = Orientation.Horizontal
        ' 
        ' mainSplitContainer.Panel1
        ' 
        mainSplitContainer.Panel1.Controls.Add(upperHalfSplitContainer)
        mainSplitContainer.Size = New Size(932, 920)
        mainSplitContainer.SplitterDistance = 460
        mainSplitContainer.TabIndex = 0
        ' 
        ' upperHalfSplitContainer
        ' 
        upperHalfSplitContainer.Dock = DockStyle.Fill
        upperHalfSplitContainer.Location = New Point(0, 0)
        upperHalfSplitContainer.Name = "upperHalfSplitContainer"
        upperHalfSplitContainer.Orientation = Orientation.Horizontal
        ' 
        ' upperRightPanel
        ' 
        upperRightPanel.Controls.Add(SplitContainer2)
        upperRightPanel.Dock = DockStyle.Fill
        upperRightPanel.Location = New Point(0, 0)
        upperRightPanel.Name = "upperRightPanel"
        upperRightPanel.Size = New Size(932, 325)
        upperRightPanel.TabIndex = 0
        ' 
        ' lowerHalfPanel
        ' 
        lowerHalfPanel.Controls.Add(nameLabel)
        lowerHalfPanel.Controls.Add(serviceLabel)
        lowerHalfPanel.Controls.Add(locationLabel)
        lowerHalfPanel.Controls.Add(ratingLabel)
        lowerHalfPanel.Dock = DockStyle.Fill
        lowerHalfPanel.Location = New Point(0, 0)
        lowerHalfPanel.Name = "lowerHalfPanel"
        lowerHalfPanel.Size = New Size(932, 325)
        lowerHalfPanel.TabIndex = 1
        ' 
        ' upperHalfSplitContainer.Panel1
        ' 
        upperHalfSplitContainer.Panel1.Controls.Add(Profile_Pic)
        upperHalfSplitContainer.Panel1.Controls.Add(Username)
        upperHalfSplitContainer.Panel1.Controls.Add(Back_Btn)
        upperHalfSplitContainer.Panel1.Controls.Add(Provider_Name_Loc_Lbl)
        ' 
        ' upperHalfSplitContainer.Panel2
        ' 
        upperHalfSplitContainer.Panel2.Controls.Add(upperRightPanel)
        upperHalfSplitContainer.Panel2.Controls.Add(lowerHalfPanel)
        upperHalfSplitContainer.Size = New Size(932, 460)
        upperHalfSplitContainer.SplitterDistance = 131
        upperHalfSplitContainer.TabIndex = 0

        ' 
        ' nameLabel
        ' 
        nameLabel.Dock = DockStyle.Top
        nameLabel.Location = New Point(0, 69)
        nameLabel.Name = "nameLabel"
        nameLabel.Size = New Size(932, 23)
        nameLabel.TabIndex = 0
        nameLabel.Text = "Provider Name: John Doe"
        ' 
        ' serviceLabel
        ' 
        serviceLabel.Dock = DockStyle.Top
        serviceLabel.Location = New Point(0, 46)
        serviceLabel.Name = "serviceLabel"
        serviceLabel.Size = New Size(932, 23)
        serviceLabel.TabIndex = 1
        serviceLabel.Text = "Service: Plumbing"
        ' 
        ' locationLabel
        ' 
        locationLabel.Dock = DockStyle.Top
        locationLabel.Location = New Point(0, 23)
        locationLabel.Name = "locationLabel"
        locationLabel.Size = New Size(932, 23)
        locationLabel.TabIndex = 2
        locationLabel.Text = "Location: New York, USA"
        ' 
        ' ratingLabel
        ' 
        ratingLabel.Dock = DockStyle.Top
        ratingLabel.Location = New Point(0, 0)
        ratingLabel.Name = "ratingLabel"
        ratingLabel.Size = New Size(932, 23)
        ratingLabel.TabIndex = 3
        ratingLabel.Text = "Rating: ★★★★☆"
        Dim providerProfilePicture As New PictureBox()
        providerProfilePicture.Dock = DockStyle.Fill
        providerProfilePicture.BackColor = Color.LightGray ' Placeholder color
        providerProfilePicture.SizeMode = PictureBoxSizeMode.Zoom ' Ensure the image fits within the PictureBox
        ' Load and set the image for the provider profile picture
        providerProfilePicture.Image = My.Resources.male ' Specify the correct image path

        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Controls.Add(providerProfilePicture)
        SplitContainer1.Size = New Size(932, 325)
        SplitContainer1.SplitterDistance = 310
        SplitContainer1.TabIndex = 0
        ' 
        ' SplitContainer2
        ' 
        SplitContainer2.Dock = DockStyle.Fill
        SplitContainer2.Location = New Point(0, 0)
        SplitContainer2.Name = "SplitContainer2"
        SplitContainer2.Size = New Size(932, 325)
        SplitContainer2.SplitterDistance = 310
        SplitContainer2.TabIndex = 0
        ' 
        ' provider_info
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(932, 920)
        Controls.Add(mainSplitContainer)
        Font = New Font("Segoe UI", 9.0F)
        FormBorderStyle = FormBorderStyle.None
        Name = "provider_info"
        Text = "Provider_Info"
        CType(Profile_Pic, ComponentModel.ISupportInitialize).EndInit()
        mainSplitContainer.Panel1.ResumeLayout(False)
        CType(mainSplitContainer, ComponentModel.ISupportInitialize).EndInit()
        mainSplitContainer.ResumeLayout(False)
        upperHalfSplitContainer.Panel1.ResumeLayout(False)
        upperHalfSplitContainer.Panel1.PerformLayout()
        upperHalfSplitContainer.Panel2.ResumeLayout(False)
        CType(upperHalfSplitContainer, ComponentModel.ISupportInitialize).EndInit()
        upperHalfSplitContainer.ResumeLayout(False)
        upperRightPanel.ResumeLayout(False)
        lowerHalfPanel.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        CType(SplitContainer2, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer2.ResumeLayout(False)
        ResumeLayout(False)
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
    Friend WithEvents mainSplitContainer As SplitContainer
    Friend WithEvents upperHalfSplitContainer As SplitContainer
    Friend WithEvents upperRightPanel As Panel
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lowerHalfPanel As Panel
    Friend WithEvents nameLabel As Label
    Friend WithEvents serviceLabel As Label
    Friend WithEvents locationLabel As Label
    Friend WithEvents ratingLabel As Label
    Friend WithEvents SplitContainer2 As SplitContainer
End Class
