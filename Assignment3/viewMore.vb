Imports System.Drawing
Imports System.Windows.Forms

Public Class viewMore
    Inherits UserControl

    Private _startX As Integer
    Private _startY As Integer
    Private _index As Integer
    Private _locations As List(Of String)
    Private _rating As Double

    ' Define the TileClicked event
    Public Event TileClicked As EventHandler(Of Integer)

    ' Constructor with parameters
    Public Sub New(index As Integer, startX As Integer, startY As Integer, locations As List(Of String), rating As Double)
        InitializeComponent()

        ' Set the index, startX, and startY
        _index = index
        _startX = startX
        _startY = startY

        ' Set the locations and rating
        _locations = locations
        _rating = rating

        ' Set the Tag property to store the index of the tile
        Me.Tag = _index

        ' Update the location based on startX and startY
        Me.Location = New Point(_startX, _startY)

        ' Set label text
        label2.Text = "Locations :" & Environment.NewLine & String.Join(", ", locations)

        If rating = -1 Then
            label3.Text = "Rating: " & "Not rated"
        Else

            ' Format the rating to one decimal place
            Dim formattedRating As String = rating.ToString("0.0")

            ' Display the formatted rating (e.g., assign it to a Label)
            label3.Text = "Rating: " & formattedRating
        End If

    End Sub

    ' Property to get the index
    Public ReadOnly Property Index As Integer
        Get
            Return _index
        End Get
    End Property

    ' Property to set and get the username
    Public Property Username As String
        Get
            Return usernamelabel.Text
        End Get
        Set(value As String)
            usernamelabel.Text = value
        End Set
    End Property

    ' Property to set and get the locations
    Public Property Locations As List(Of String)
        Get
            Return _locations
        End Get
        Set(value As List(Of String))
            _locations = value
            Me.Invalidate() ' Invalidate the control to trigger repaint
        End Set
    End Property

    ' Property to set and get the rating
    Public Property Rating As Double
        Get
            Return _rating
        End Get
        Set(value As Double)
            _rating = value
            Me.Invalidate() ' Invalidate the control to trigger repaint
        End Set
    End Property

    ' Add click event handlers for the entire control
    Private Sub viewMore_Click(sender As Object, e As EventArgs) Handles MyBase.Click
        ' Raise the TileClicked event with the index of this tile
        RaiseEvent TileClicked(Me, _index)
    End Sub

    ' Click event handler for the label
    Private Sub usernamelabel_Click(sender As Object, e As EventArgs) Handles usernamelabel.Click
        ' Raise the TileClicked event with the index of this tile
        RaiseEvent TileClicked(Me, _index)
    End Sub

    ' Click event handler for the picture box
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        ' Raise the TileClicked event with the index of this tile
        RaiseEvent TileClicked(Me, _index)
    End Sub

    ' Click event handler for label2
    Private Sub label2_Click(sender As Object, e As EventArgs) Handles label2.Click
        ' Raise the TileClicked event with the index of this tile
        RaiseEvent TileClicked(Me, _index)
    End Sub

    ' Click event handler for label3
    Private Sub label3_Click(sender As Object, e As EventArgs) Handles label3.Click
        ' Raise the TileClicked event with the index of this tile
        RaiseEvent TileClicked(Me, _index)
    End Sub

    ' Override the OnPaint method to customize the appearance
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        ' Draw rounded rectangle with border
        Using pen As New Pen(Color.FromArgb(55, 200, 170), 2)
            Using path As New Drawing2D.GraphicsPath()
                Dim rect As New Rectangle(1, 1, Me.Width - 3, Me.Height - 3)
                path.AddArc(rect.Left, rect.Top, 10, 10, 180, 90)
                path.AddArc(rect.Right - 10, rect.Top, 10, 10, 270, 90)
                path.AddArc(rect.Right - 10, rect.Bottom - 10, 10, 10, 0, 90)
                path.AddArc(rect.Left, rect.Bottom - 10, 10, 10, 90, 90)
                path.CloseFigure()

                e.Graphics.DrawPath(pen, path)
            End Using
        End Using
    End Sub
End Class
