Imports Org.BouncyCastle.Utilities

Public Class Appointment_history
    Private Sub Appointment_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel2.Visible = False
        PictureBox1.Visible = False

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
        Dim num As Integer = 0

        ' Add panels to the panel3 for each item in the data
        For Each item In data
            Dim panelItem As New Panel()
            panelItem.BackColor = ColorTranslator.FromHtml("#F0DAF8") ' Set background color
            panelItem.Size = New Size(Panel1.Width - 20, 60) ' Set size of panelItem
            panelItem.Location = New Point(0, yPos) ' Set panelItem position
            panelItem.Margin = New Padding(5) ' Add margin for
            panelItem.Name = $"Panel {num}"
            num += 1

            AddHandler panelItem.Click, AddressOf Panel_Click

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
            Panel1.Controls.Add(panelItem)

            ' Update the Y position for the next panelItem
            yPos += panelItem.Height + 5 ' Add spacing between panelItems
        Next
    End Sub

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Panel1.Visible = False
        Panel2.Visible = True
        PictureBox1.Visible = True
        RichTextBox1.Text = vbLf & "   Provider: Provider Name" & vbLf & vbLf & vbLf & "   Location: " & vbLf & vbLf & "   Date: " & vbLf & vbLf & "   Cost: " & vbLf & vbLf & "   First Payment: " & vbLf & vbLf & "   Second Payment: " & vbLf & vbLf & "   Feedback: "

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel1.Visible = True
        Panel2.Visible = False
        PictureBox1.Visible = False
    End Sub
End Class