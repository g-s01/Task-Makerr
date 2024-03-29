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
        line.Top = 130 ' Position the Label 50 pixels from the top of the container
        line.Left = 0 ' Position the Label 10 pixels from the left of the container

        ' Add the Label to the tile (assuming the tile is a Panel or similar control)
        Me.Controls.Add(line)
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(Label1, Label1.Text)
        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(Label2, Label2.Text)
    End Sub

End Class
