Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Drawing.Drawing2D
Public Class provider_notifications

    Dim providerId As Integer = Module_global.Provider_ID
    'Dim providerId As Integer = 3'

    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Private Sub provider_notifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'feedbacks
        Button4.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)


    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button4.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)

        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour,d.location " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 0" ' Assuming 0 represents 50% paid booking status


        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                FlowLayoutPanel1.Controls.Clear()
                'FlowLayoutPanel1.BackColor = Color.Black'

                If Not reader.HasRows Then
                    Dim noEntriesLabel As New Label()
                    noEntriesLabel.Text = "No entries found."
                    noEntriesLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    noEntriesLabel.AutoSize = True
                    noEntriesLabel.Location = New Point(100, 10) ' Adjust location as needed
                    FlowLayoutPanel1.Controls.Add(noEntriesLabel)
                Else
                    While reader.Read()
                        Dim customerName As String = reader("username").ToString()
                        Dim slots As String = reader("time").ToString()
                        Dim costPerHour As Integer = Convert.ToInt32(reader("cost_per_hour"))
                        Dim location As String = reader("location").ToString()

                        ' Calculate the total amount of the deal based on the slot and cost per hour
                        Dim bookedHours As Integer = slots.Count(Function(c) c = "1")
                        Dim totalAmount As Integer = bookedHours * costPerHour / 2

                        ' Create a Panel control for each customer
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Location = New Point(40)
                        panel.Size = New Size(750, 100) ' Set the size of the panel (width: 300, height: 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for customer details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 30) ' Set the location of the label within the panel

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Amount Paid : {totalAmount}"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(550, 30) ' Set the location of the label within the panel

                        Dim loc As New Label()
                        loc.Text = location
                        loc.Font = New Font("Microsoft YaHei", 9, FontStyle.Regular)
                        loc.AutoSize = True

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)


                        ' Add the panel to the FlowLayoutPanel
                        FlowLayoutPanel1.Controls.Add(panel)
                    End While
                End If


            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.FromArgb(215, 181, 227)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button4.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 1" ' Assuming 0 represents 50% paid booking status


        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                FlowLayoutPanel1.Controls.Clear()
                'FlowLayoutPanel1.BackColor = Color.Black'

                If Not reader.HasRows Then
                    Dim noEntriesLabel As New Label()
                    noEntriesLabel.Text = "No entries found."
                    noEntriesLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    noEntriesLabel.AutoSize = True
                    noEntriesLabel.Location = New Point(100, 10) ' Adjust location as needed
                    FlowLayoutPanel1.Controls.Add(noEntriesLabel)
                Else


                    While reader.Read()
                        Dim customerName As String = reader("username").ToString()
                        Dim slots As String = reader("time").ToString()
                        Dim costPerHour As Integer = Convert.ToInt32(reader("cost_per_hour"))

                        ' Calculate the total amount of the deal based on the slot and cost per hour
                        Dim bookedHours As Integer = slots.Count(Function(c) c = "1")
                        Dim totalAmount As Integer = bookedHours * costPerHour

                        ' Create a Panel control for each customer
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Location = New Point(40)
                        panel.Size = New Size(750, 80) ' Set the size of the panel (width: 300, height: 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for customer details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 30) ' Set the location of the label within the panel

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Amount Paid : {totalAmount}"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(550, 30) ' Set the location of the label within the panel

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)


                        ' Add the panel to the FlowLayoutPanel
                        FlowLayoutPanel1.Controls.Add(panel)
                    End While
                End If
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button4.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)

        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 3" ' Assuming 0 represents 50% paid booking status


        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                FlowLayoutPanel1.Controls.Clear()
                'FlowLayoutPanel1.BackColor = Color.Black'

                If Not reader.HasRows Then
                    Dim noEntriesLabel As New Label()
                    noEntriesLabel.Text = "No entries found."
                    noEntriesLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    noEntriesLabel.AutoSize = True
                    noEntriesLabel.Location = New Point(100, 10) ' Adjust location as needed
                    FlowLayoutPanel1.Controls.Add(noEntriesLabel)
                Else

                    While reader.Read()
                        Dim customerName As String = reader("username").ToString()

                        ' Create a Panel control for each customer
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Location = New Point(40)
                        panel.Size = New Size(750, 80) ' Set the size of the panel (width: 300, height: 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for customer details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 30) ' Set the location of the label within the panel

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Cancelled"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(570, 30) ' Set the location of the label within the panel

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)


                        ' Add the panel to the FlowLayoutPanel
                        FlowLayoutPanel1.Controls.Add(panel)
                    End While
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)

        ' Clear existing controls from FlowLayoutPanel
        If FlowLayoutPanel1.Controls.Count > 0 Then
            FlowLayoutPanel1.Controls.Clear()
        End If

        ' Create a Label to display the filter prompt
        Dim filterLabel As New Label()
        filterLabel.Text = "Filter by rating:"
        filterLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Regular)
        filterLabel.AutoSize = True
        filterLabel.Location = New Point(10, 10) ' Adjust the location as needed
        FlowLayoutPanel1.Controls.Add(filterLabel)

        ' Create and add ComboBox dynamically to the FlowLayoutPanel with custom styling
        Dim comboBox As New ComboBox()
        comboBox.DropDownStyle = ComboBoxStyle.DropDownList
        comboBox.Name = "RatingComboBox"
        ' Add the rating options to the ComboBox
        comboBox.Items.AddRange(New Object() {"All Reviews", "0-1", "1-2", "2-3", "3-4", "4-5"})
        comboBox.Location = New Point(filterLabel.Right + 5, 10) ' Adjust the location as needed
        comboBox.Size = New Size(150, 25)
        ' Apply custom styling to the ComboBox
        ApplyComboBoxStyling(comboBox)
        FlowLayoutPanel1.Controls.Add(comboBox)
        AddHandler comboBox.SelectedIndexChanged, AddressOf RatingComboBox_SelectedIndexChanged

        ' Show all reviews initially
        ShowAllReviews()
    End Sub

    Private Sub ShowAllReviews()
        ' Query to retrieve all reviews for the provider
        Dim query As String = "SELECT r.review_text, c.username, r.rating " &
                              "FROM review r " &
                              "INNER JOIN deals d ON r.deal_id = d.deal_id " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "WHERE d.provider_id = @ProviderID;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()

                If Not reader.HasRows Then
                    Dim noEntriesLabel As New Label()
                    noEntriesLabel.Text = "No entries found."
                    noEntriesLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    noEntriesLabel.AutoSize = True
                    noEntriesLabel.Location = New Point(100, 10)
                    FlowLayoutPanel1.Controls.Add(noEntriesLabel)
                Else
                    While reader.Read()
                        Dim customerName As String = reader("username").ToString()
                        Dim review_text As String = reader("review_text").ToString()
                        Dim rating As Integer = Convert.ToInt32(reader("rating"))

                        ' Create a Panel control for each review
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Size = New Size(750, 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for review details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 30)

                        Dim review As New Label()
                        review.Text = $"{review_text}"
                        review.Font = New Font("Microsoft YaHei", 10, FontStyle.Regular)
                        review.AutoSize = True
                        review.Location = New Point(30, 50)

                        Dim customer_rating As New Label()
                        customer_rating.Text = $"Rating : {rating}"
                        customer_rating.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        customer_rating.AutoSize = True
                        customer_rating.Location = New Point(600, 30)

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(review)
                        panel.Controls.Add(customer_rating)

                        ' Add the panel to the FlowLayoutPanel
                        FlowLayoutPanel1.Controls.Add(panel)
                    End While
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub RatingComboBox_SelectedIndexChanged(sender As Object, e As EventArgs)

        ' Clear existing controls from FlowLayoutPanel except the ComboBox
        Dim comboBox As ComboBox = FlowLayoutPanel1.Controls.OfType(Of ComboBox)().FirstOrDefault()
        FlowLayoutPanel1.Controls.Clear()
        FlowLayoutPanel1.Controls.Add(comboBox)

        ' Declare variables for minRating and maxRating
        Dim minRating As Integer = 0
        Dim maxRating As Integer = 5

        ' Check if a rating range is selected
        If comboBox.SelectedItem IsNot Nothing Then
            ' Retrieve the selected rating range from the ComboBox
            Dim selectedRange As String = comboBox.SelectedItem.ToString()

            If selectedRange <> "All Reviews" Then
                ' If any other range is selected, parse the selected range
                minRating = Integer.Parse(selectedRange.Split("-"c)(0))
                maxRating = Integer.Parse(selectedRange.Split("-"c)(1))
            End If
        End If

        ' Query to retrieve reviews for the provider within the selected rating range
        Dim query As String = "SELECT r.review_text, c.username, r.rating " &
                        "FROM review r " &
                        "INNER JOIN deals d ON r.deal_id = d.deal_id " &
                        "INNER JOIN customer c ON d.user_id = c.user_id " &
                        "WHERE d.provider_id = @ProviderID AND r.rating >= @MinRating AND r.rating < @MaxRating;"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)
            command.Parameters.AddWithValue("@MinRating", minRating)
            command.Parameters.AddWithValue("@MaxRating", maxRating)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()

                If Not reader.HasRows Then
                    Dim noEntriesLabel As New Label()
                    noEntriesLabel.Text = "No entries found."
                    noEntriesLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    noEntriesLabel.AutoSize = True
                    noEntriesLabel.Location = New Point(100, 10)
                    FlowLayoutPanel1.Controls.Add(noEntriesLabel)
                Else
                    While reader.Read()
                        Dim customerName As String = reader("username").ToString()
                        Dim review_text As String = reader("review_text").ToString()
                        Dim rating As Integer = Convert.ToInt32(reader("rating"))

                        ' Create a Panel control for each review
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Size = New Size(750, 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for review details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 30)

                        Dim review As New Label()
                        review.Text = $"{review_text}"
                        review.Font = New Font("Microsoft YaHei", 10, FontStyle.Regular)
                        review.AutoSize = True
                        review.Location = New Point(30, 50)

                        Dim customer_rating As New Label()
                        customer_rating.Text = $"Rating : {rating}"
                        customer_rating.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        customer_rating.AutoSize = True
                        customer_rating.Location = New Point(600, 30)

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(review)
                        panel.Controls.Add(customer_rating)

                        ' Add the panel to the FlowLayoutPanel
                        FlowLayoutPanel1.Controls.Add(panel)
                    End While
                End If

            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub ApplyComboBoxStyling(comboBox As ComboBox)
        ' Draw rounded rectangle for the ComboBox
        AddHandler comboBox.DrawItem, Sub(sender As Object, e As DrawItemEventArgs)
                                          Dim rect As Rectangle = e.Bounds
                                          If e.Index >= 0 Then
                                              Dim brush As Brush = New SolidBrush(If((e.State And DrawItemState.Selected) = DrawItemState.Selected, Color.FromArgb(215, 181, 227), comboBox.BackColor))
                                              e.Graphics.FillRectangle(brush, rect)
                                              e.Graphics.DrawString(comboBox.Items(e.Index).ToString(), comboBox.Font, Brushes.Black, rect)
                                              e.DrawFocusRectangle()
                                          End If
                                      End Sub
        ' Draw rounded edges for the ComboBox dropdown
        AddHandler comboBox.DropDown, Sub(sender As Object, e As EventArgs)
                                          Dim cb As ComboBox = DirectCast(sender, ComboBox)
                                          Dim g As Graphics = cb.CreateGraphics()
                                          Dim path As New GraphicsPath()
                                          Dim rect As Rectangle = cb.ClientRectangle
                                          rect.Inflate(-1, -1)
                                          path.AddArc(rect.X, rect.Y, 20, 20, 180, 90)
                                          path.AddArc(rect.Right - 20, rect.Y, 20, 20, 270, 90)
                                          path.AddArc(rect.Right - 20, rect.Bottom - 20, 20, 20, 0, 90)
                                          path.AddArc(rect.X, rect.Bottom - 20, 20, 20, 90, 90)
                                          cb.Region = New Region(path)
                                      End Sub
    End Sub

End Class