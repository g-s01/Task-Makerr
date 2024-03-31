Imports FxResources.System

Public Class Provider_Profile_page
    ' Define an event to be raised when the edit profile button is clicked
    Public Event EditProfileClicked As EventHandler

    ' Handle the click event of the "Edit_profile_btn" button
    Private Sub Edit_profile_btn_Click(sender As Object, e As EventArgs) Handles Edit_profile_btn.Click
        ' Raise the EditProfileClicked event
        RaiseEvent EditProfileClicked(Me, EventArgs.Empty)
    End Sub

    Public editprovprof As Boolean = False
    Private Sub Provider_Profile_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Name_label.Text = "Pratham Goyal"
        email_label.Text = "Pratham@gmail.com"
        Service_label.Text = "Decorator"
        location_label.Text = "guwahati,delhi"
        rate_label.Text = "20L/hour"

        Dim Rating As Double = 2.5
        Dim integerPart As Integer = CInt(Math.Truncate(Rating))
        Dim remainder As Double = Rating - integerPart
        For i As Integer = 0 To 4
            If i < integerPart Then
                ' This star is fully filled
                SetStarImage(i, My.Resources.star_filled)
            ElseIf i = integerPart AndAlso remainder >= 0.75 Then
                ' More than three-quarters filled, display filled star
                SetStarImage(i, My.Resources.star_filled)
            ElseIf i = integerPart AndAlso remainder >= 0.25 Then
                ' More than one-quarter filled, display half-filled star
                SetStarImage(i, My.Resources.star_empty1)
            Else
                ' Less than one-quarter filled, display empty star
                SetStarImage(i, My.Resources.star_half_filled)
            End If
        Next

        Dim data As New List(Of (Name As String, Location As String, Cost As Decimal)) From
        {
            ("Product 1", "Location 1", 10.5),
            ("Product 2", "Location 2", 15.75),
            ("Product 3", "Location 3", 20.0),
            ("Product 1", "Location 1", 10.5),
            ("Product 2", "Location 2", 15.75),
            ("Product 3", "Location 3", 20.0)
        }

        ' Add labels to the panel for each item in the data
        ' Set initial Y position
        Dim yPos As Integer = 0

        ' Add panels to the panel3 for each item in the data
        For Each item In data
            Dim panelItem As New Panel()
            panelItem.BackColor = ColorTranslator.FromHtml("#F0DAF8") ' Set background color
            panelItem.Size = New Size(740, 60) ' Set size of panelItem
            panelItem.Location = New Point(0, yPos) ' Set panelItem position
            panelItem.Margin = New Padding(5) ' Add margin for spacing

            Dim nameLabel As New Label()
            nameLabel.Text = item.Name
            nameLabel.Font = New Font("Arial", 12, FontStyle.Bold) ' Larger font for the name
            nameLabel.AutoSize = True
            nameLabel.Location = New Point(5, 5) ' Position name label within panelItem

            Dim locationLabel As New Label()
            locationLabel.Text = item.Location
            locationLabel.Font = New Font("Arial", 10) ' Smaller font for the location
            locationLabel.AutoSize = True
            locationLabel.Location = New Point(5, nameLabel.Bottom + 5) ' Position location label below name label

            Dim costLabel As New Label()
            costLabel.Text = $"Cost: {item.Cost:C}"
            costLabel.Font = New Font("Arial", 12, FontStyle.Bold) ' Font for the cost
            costLabel.AutoSize = True
            costLabel.Location = New Point(panelItem.Width - costLabel.Width - 10, (panelItem.Height - costLabel.Height) \ 2) ' Position cost label on the right side and vertically centered

            ' Add labels to the panelItem
            panelItem.Controls.Add(nameLabel)
            panelItem.Controls.Add(locationLabel)
            panelItem.Controls.Add(costLabel)

            ' Add the panelItem to the panel3
            Panel3.Controls.Add(panelItem)

            ' Update the Y position for the next panelItem
            yPos += panelItem.Height + 5 ' Add spacing between panelItems
        Next

    End Sub

    Private Sub SetStarImage(index As Integer, image As Image)
        Select Case index
            Case 0
                PictureBox2.Image = image
            Case 1
                PictureBox3.Image = image
            Case 2
                PictureBox4.Image = image
            Case 3
                PictureBox5.Image = image
            Case 4
                PictureBox6.Image = image
        End Select
    End Sub

    Private Sub Changepic_pb_Click(sender As Object, e As EventArgs) Handles changepic_pb.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Set the selected image to the PictureBox
            profilepic_pb.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub



End Class