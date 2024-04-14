Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Data.SqlClient
Public Class provider_notifications

    Dim providerId As Integer = Module_global.Provider_ID
    'Dim providerId As Integer = 3

    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Private Sub provider_notifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'feedbacks
        Button4.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button3.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)

        Dim query As String = "SELECT r.review_text, c.username, r.rating " &
                      "FROM review r " &
                      "INNER JOIN deals d ON r.deal_id = d.deal_id " &
                      "INNER JOIN customer c ON d.user_id = c.user_id " &
                      "WHERE d.provider_id = @ProviderID;" ' Assuming 0 represents 50% paid booking status


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
                        Dim review_text As String = reader("review_text").ToString()
                        Dim rating As Integer = Convert.ToInt32(reader("rating"))

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

                        Dim review As New Label()
                        review.Text = $"{review_text}"
                        review.Font = New Font("Microsoft YaHei", 10)
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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button3.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button4.BackColor = Color.FromKnownColor(KnownColor.Control)

        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, d.deal_amount, d.dates,d.location " &
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
                        Dim totalAmount As Integer = Convert.ToInt32(reader("deal_amount")) / 2
                        Dim location As String = reader("location").ToString()

                        Dim dateStamp As DateTime
                        If Not IsDBNull(reader("dates")) Then
                            dateStamp = Convert.ToDateTime(reader("dates"))
                        Else
                            ' Handle null value case (optional)
                            dateStamp = DateTime.MinValue ' Or any default value you prefer
                        End If

                        ' Create a Panel control for each customer
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Location = New Point(40)
                        panel.Size = New Size(750, 90) ' Set the size of the panel (width: 300, height: 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for customer details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 10) ' Set the location of the label within the panel

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Amount Paid : {totalAmount}"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(550, 10) ' Set the location of the label within the panel

                        ' Create labels for customer location
                        Dim loc As New Label()
                        loc.Text = location
                        loc.Font = New Font("Microsoft YaHei", 10)
                        loc.AutoSize = True
                        loc.Location = New Point(30, 40)

                        ' Create label for date stamp
                        Dim dateLabel As New Label()
                        dateLabel.Text = $"Date : {dateStamp.ToString("dd-MM-yyyy")}" ' Adjust the format to display date and time
                        dateLabel.Font = New Font("Microsoft YaHei", 10)
                        dateLabel.AutoSize = True
                        dateLabel.Location = New Point(580, 40) ' Set the location of the label within the panel

                        Dim timeLabel As New Label()
                        timeLabel.Text = $"Time : {dateStamp.ToString("HH : mm")}" ' Adjust the format to display date and time
                        timeLabel.Font = New Font("Microsoft YaHei", 10)
                        timeLabel.AutoSize = True
                        timeLabel.Location = New Point(580, 60) ' Set the location of the label within the panel

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)
                        panel.Controls.Add(loc)
                        panel.Controls.Add(dateLabel)
                        panel.Controls.Add(timeLabel)


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
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button3.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button4.BackColor = Color.FromKnownColor(KnownColor.Control)
        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, d.deal_amount, d.dates,d.location " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 2" &
                              "ORDER BY d.dates DESC" ' Assuming 0 represents 50% paid booking status


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
                        Dim totalAmount As Integer = Convert.ToInt32(reader("deal_amount"))
                        Dim location As String = reader("location").ToString()


                        Dim dateStamp As DateTime
                        If Not IsDBNull(reader("dates")) Then
                            dateStamp = Convert.ToDateTime(reader("dates"))
                        Else
                            ' Handle null value case (optional)
                            dateStamp = DateTime.MinValue ' Or any default value you prefer
                        End If

                        ' Create a Panel control for each customer
                        Dim panel As New Panel()
                        panel.BorderStyle = BorderStyle.FixedSingle
                        panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                        panel.Location = New Point(40)
                        panel.Size = New Size(750, 90) ' Set the size of the panel (width: 300, height: 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for customer details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 10) ' Set the location of the label within the panel

                        ' Create labels for Customer Location
                        Dim loc As New Label()
                        loc.Text = location
                        loc.Font = New Font("Microsoft YaHei", 10)
                        loc.AutoSize = True
                        loc.Location = New Point(30, 40)

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Amount Paid : {totalAmount}"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(550, 10) ' Set the location of the label within the panel

                        ' Create label for date stamp
                        Dim dateLabel As New Label()
                        dateLabel.Text = $"Date : {dateStamp.ToString("dd-MM-yyyy")}" ' Adjust the format to display date and time
                        dateLabel.Font = New Font("Microsoft YaHei", 10)
                        dateLabel.AutoSize = True
                        dateLabel.Location = New Point(580, 40) ' Set the location of the label within the panel

                        Dim timeLabel As New Label()
                        timeLabel.Text = $"Time : {dateStamp.ToString("HH : mm")}" ' Adjust the format to display date and time
                        timeLabel.Font = New Font("Microsoft YaHei", 10)
                        timeLabel.AutoSize = True
                        timeLabel.Location = New Point(580, 60) ' Set the location of the label within the panel


                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)
                        panel.Controls.Add(dateLabel)
                        panel.Controls.Add(timeLabel)
                        panel.Controls.Add(loc)

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
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button4.BackColor = Color.FromKnownColor(KnownColor.Control)

        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 4" ' Assuming 0 represents 50% paid booking status


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
                        panel.Size = New Size(750, 110) ' Set the size of the panel (width: 300, height: 100)
                        panel.Margin = New Padding(5)
                        panel.AutoScroll = True

                        ' Create labels for customer details
                        Dim nameLabel As New Label()
                        nameLabel.Text = $"{customerName}"
                        nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        nameLabel.AutoSize = True
                        nameLabel.Location = New Point(30, 20) ' Set the location of the label within the panel

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Cancelled"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(570, 20) ' Set the location of the label within the panel

                        ' Create Pay Refund button dynamically
                        Dim payRefundButton As New Button()
                        payRefundButton.Text = "Pay Refund"
                        payRefundButton.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        payRefundButton.Size = New Size(130, 40)
                        payRefundButton.Location = New Point(570, 50) ' Set the location of the button within the panel
                        payRefundButton.BackColor = Color.FromArgb(245, 140, 215) ' Set the background color of the button
                        payRefundButton.FlatStyle = FlatStyle.Flat ' Flat style without a border
                        AddHandler payRefundButton.Click, Sub(s, ev)
                                                              ' Handle the Pay Refund button click event here
                                                              ' You can implement the logic to process the refund
                                                              ' For example, you can display a message box or call a refund function
                                                              MessageBox.Show("Refund processed for " & customerName)
                                                          End Sub

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)
                        panel.Controls.Add(payRefundButton)


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
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button3.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)

        Dim query As String = "SELECT r.review_text, c.username, r.rating " &
                      "FROM review r " &
                      "INNER JOIN deals d ON r.deal_id = d.deal_id " &
                      "INNER JOIN customer c ON d.user_id = c.user_id " &
                      "WHERE d.provider_id = @ProviderID;" ' Assuming 0 represents 50% paid booking status


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
                        Dim review_text As String = reader("review_text").ToString()
                        Dim rating As Integer = Convert.ToInt32(reader("rating"))

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

                        Dim review As New Label()
                        review.Text = $"{review_text}"
                        review.Font = New Font("Microsoft YaHei", 10)
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
End Class