Public Class Prov_tile
    Inherits UserControl

    ' Properties for item data
    Public Property ProviderName As String
    Public Property Loc As String
    Public Property ItemImage As Image
    Public Property Rating As Double
    Public Property Provider As Int32

    ' Constructor
    Public Sub New(provider As Int32, providerName As String, loc As String, rating As Double, itemImage As Image)
        InitializeComponent()
        Me.Provider = provider
        Me.ProviderName = providerName
        Me.Loc = loc
        Me.Rating = rating
        Me.ItemImage = itemImage
        Label1.Text = providerName
        Label2.Text = loc
        If rating = 6.0 Then
            Label3.Text = "No"
        Else
            Label3.Text = rating
        End If
        Dim line As New Label()

        ' Set the Label's properties
        line.AutoSize = False ' Allow the Label to be resized
        line.Height = 5 ' Set the height of the Label to create a thin line
        line.BorderStyle = BorderStyle.Fixed3D ' Set the border style to create a 3D effect
        line.Width = Me.Size.Width ' Set the width of the Label

        ' Position the Label where you want the line to be
        line.Top = 160 ' Position the Label 50 pixels from the top of the container
        line.Left = 0 ' Position the Label 10 pixels from the left of the container

        ' Add the Label to the tile (assuming the tile is a Panel or similar control)
        Me.Controls.Add(line)
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(Label1, Label1.Text)
        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(Label2, Label2.Text)

        AddHandler Me.Click, AddressOf UserControl_Click

        ' Add the same Click event handler to the Click events of the child controls
        For Each control As Control In Me.Controls
            AddHandler control.Click, AddressOf UserControl_Click
        Next
        AddHandler Me.MouseEnter, AddressOf UserControl_MouseEnter
        AddHandler Me.MouseLeave, AddressOf UserControl_MouseLeave

        ' Add the same MouseEnter and MouseLeave event handlers to the events of the child controls
        For Each control As Control In Me.Controls
            AddHandler control.MouseEnter, AddressOf UserControl_MouseEnter
            AddHandler control.MouseLeave, AddressOf UserControl_MouseLeave
        Next
    End Sub

    Private Sub UserControl_Click(sender As Object, e As EventArgs)
        ' Create an instance of the new form

        Dim newForm As New Book_slots() ' Replace 'Form2' with the name of your form

        ' Show the new form
        newForm.Show()
    End Sub
    Private Sub UserControl_MouseEnter(sender As Object, e As EventArgs)
        ' Change the BackColor of the UserControl to the hover color
        Me.BackColor = Color.LightBlue ' Replace 'Color.LightBlue' with your hover color
    End Sub

    Private Sub UserControl_MouseLeave(sender As Object, e As EventArgs)
        ' Change the BackColor of the UserControl back to the default color
        Me.BackColor = Color.White ' Replace 'Color.White' with your default color
    End Sub
    Friend WithEvents PictureBox1 As PictureBox

    Private Sub InitializeComponent()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PictureBox2 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.prov
        PictureBox1.Location = New Point(27, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(97, 89)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(16, 175)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 38)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(44, 124)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 35)
        Label2.TabIndex = 2
        Label2.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(117, 175)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 20)
        Label3.TabIndex = 3
        Label3.Text = "Label3"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Star
        PictureBox2.Location = New Point(143, 165)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(25, 30)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 4
        PictureBox2.TabStop = False
        ' 
        ' Prov_tile
        ' 
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(PictureBox2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Name = "Prov_tile"
        Size = New Size(173, 195)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox
End Class
