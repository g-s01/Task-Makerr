Imports Microsoft.Data.SqlClient
Imports Org.BouncyCastle.Utilities

Public Class Appointment_history

    Dim data As New List(Of (Name As String, Location As String, Cost As Decimal, Dateof As Date))
    Private Sub Appointment_history_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Panel2.Visible = False
        PictureBox1.Visible = False

        Dim y As Integer = 50
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE user_id = @UserId AND status = 2"
        Dim query2 As String = "SELECT * FROM customer where user_id =@UserId"
        Dim query3 As String = "SELECT * FROM deals WHERE provider_id = @ProviderID AND status = 3"
        Dim i As Integer = 0

        Dim result As SqlDataReader
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query3, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@ProviderID", Provider_ID) ' Use the password entered by the user
                result = sqlCommand.ExecuteReader()
                Do While result.Read()
                    Dim user As Integer = result.GetValue(1)
                    Dim time As String = result.GetString(3)
                    Dim dateof As Date = result.GetValue(5)
                    Dim ProviderId As Integer = result.GetValue(2)
                    Dim ProviderName As String = ""
                    Dim Location As String = result.GetString(6)
                    Dim Cost As Integer = result.GetValue(7)
                    Using sqlConnection2 As New SqlConnection(connectionString)
                        sqlConnection2.Open()
                        Using sqlCommand2 As New SqlCommand(query2, sqlConnection2)
                            sqlCommand2.Parameters.AddWithValue("@UserId", user)
                            Dim providerDb As SqlDataReader = sqlCommand2.ExecuteReader()
                            Do While providerDb.Read()
                                ProviderName = providerDb.GetValue(1)
                            Loop
                        End Using
                    End Using

                    dateof = dateof.AddMinutes(-dateof.Minute)
                    dateof = dateof.AddSeconds(-dateof.Second)
                    Dim count As Integer = 0
                    For Each c As Char In time
                        If c = "1" Then
                            Dim slotTime = count Mod 12 + 9
                            dateof = dateof.AddHours(slotTime - dateof.Hour)
                            Exit For
                        End If
                        count = count + 1
                        If (count Mod 12 = 0) Then
                            dateof = dateof.AddDays(1)
                        End If
                    Next
                    data.Add((ProviderName, Location, Cost, dateof))
                    i += 1
                    y += 100
                Loop
            End Using
            sqlConnection.Close()
        End Using

        ' Add labels to the panel for each item in the data
        ' Set initial Y position
        Dim yPos As Integer = 0
        Dim num As Integer = 0

        ' Add panels to the panel3 for each item in the data
        For Each item In Data
            Dim panelItem As New Panel()
            panelItem.BackColor = ColorTranslator.FromHtml("#F0DAF8") ' Set background color
            panelItem.Size = New Size(Panel1.Width - 20, 60) ' Set size of panelItem
            panelItem.Location = New Point(0, yPos) ' Set panelItem position
            panelItem.Margin = New Padding(5) ' Add margin for
            panelItem.Name = $"Panel {num}"
            panelItem.Tag = num
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
            costLabel.Location = New Point(panelItem.Width - costLabel.Width - 30, (panelItem.Height - costLabel.Height) \ 2) ' Position cost label on the right side and vertically centered

            ' Add labels to the panelItem
            panelItem.Controls.Add(nameLabel)
            panelItem.Controls.Add(locationLabel)
            panelItem.Controls.Add(costLabel)

            AddHandler panelItem.MouseEnter, AddressOf Label_MouseEnter
            AddHandler panelItem.MouseLeave, AddressOf Label_MouseLeave

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
        Dim clickedPanel As Panel = DirectCast(sender, Panel)

        ' Get the name and tag of the clicked panel
        Dim panelName As String = clickedPanel.Name
        Dim panelTag As Integer = CStr(clickedPanel.Tag)
        RichTextBox1.Text = vbLf & "   Customer: " & data(panelTag).Name & vbLf & vbLf & vbLf & "   Location: " & data(panelTag).Location & vbLf & vbLf & "   Date: " & data(panelTag).Dateof & vbLf & vbLf & "   Cost: " & data(panelTag).Cost & vbLf & vbLf & "   First Payment: " & data(panelTag).Cost / 2 & vbLf & vbLf & "   Second Payment: " & data(panelTag).Cost / 2

    End Sub

    Private Sub Label_MouseEnter(sender As Object, e As EventArgs)
        ' Change the color when the mouse enters the label
        DirectCast(sender, Panel).BackColor = Color.Gray
    End Sub

    ' Event handler for MouseLeave event of labels
    Private Sub Label_MouseLeave(sender As Object, e As EventArgs)
        ' Change the color back to default when the mouse leaves the label
        DirectCast(sender, Panel).BackColor = ColorTranslator.FromHtml("#F0DAF8") ' Or set to the panel's back color

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Panel1.Visible = True
        Panel2.Visible = False
        PictureBox1.Visible = False
    End Sub
End Class