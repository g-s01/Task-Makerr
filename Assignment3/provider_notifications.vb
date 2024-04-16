Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.Drawing.Drawing2D
Imports System.Net.Mail
Public Class provider_notifications

    Dim providerId As Integer = Module_global.Provider_ID

    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Private Sub provider_notifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'feedbacks
        Button4.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button3.BackColor = Color.FromKnownColor(KnownColor.Control)
        Button1.BackColor = Color.FromKnownColor(KnownColor.Control)

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
                              "WHERE d.provider_id = @ProviderId AND d.status = 1" &
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
        Dim query As String = "SELECT c.username as username, d.time as time, d.deal_amount,d.user_id,d.deal_id,d.location,c.email,p.providername " &
                      "FROM Deals d " &
                      "INNER JOIN customer c ON d.user_id = c.user_id " &
                      "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                      "WHERE d.provider_id = @ProviderId AND d.status = 4" ' Assuming 4 represents cancellation of bookings
        ' "INNER JOIN Provider p ON d.provider_id = p.provider_id " &

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
                        Dim dealamount As Integer = Convert.ToInt32(reader("deal_amount"))
                        Dim userId As Integer = Convert.ToInt32(reader("user_id"))
                        Dim dealid As Integer = Convert.ToInt32(reader("deal_id"))
                        Dim location As String = reader("location").ToString()
                        Dim email As String = reader("email").ToString()
                        Dim providername As String = reader("providername").ToString()

                        Dim refundPercentage As Double = 0.0

                        Using refund_connection As New SqlConnection(connectionString)
                            Dim refund_command As New SqlCommand("SELECT refund_percentage FROM refunded_deals WHERE deal_id = @DealId", refund_connection)
                            refund_command.Parameters.AddWithValue("@DealId", dealid)
                            refund_connection.Open()
                            Dim result As Object = refund_command.ExecuteScalar()
                            If result IsNot DBNull.Value Then
                                refundPercentage = Convert.ToDouble(result)
                            End If
                        End Using

                        'amount need to be refunded to the customer
                        Dim refund_amount As Integer = (dealamount / 200) * refundPercentage

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
                        nameLabel.Location = New Point(30, 10) ' Set the location of the label within the panel

                        ' Create labels for Customer Location
                        Dim loc As New Label()
                        loc.Text = location
                        loc.Font = New Font("Microsoft YaHei", 10)
                        loc.AutoSize = True
                        loc.Location = New Point(30, 40)

                        ' Create labels for customer details
                        Dim amount As New Label()
                        amount.Text = $"Refund Amount : ${refund_amount}"
                        amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        amount.AutoSize = True
                        amount.Location = New Point(550, 20) ' Set the location of the label within the panel

                        Dim paid_label As New Label()
                        paid_label.Text = "Status : Refunded"
                        paid_label.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                        paid_label.AutoSize = True
                        paid_label.Location = New Point(550, 50)

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

                                                              ' Retrieve provider balance
                                                              Dim providerBalance As Integer = 0
                                                              'Dim provPassword As String=""
                                                              Using providerConnection As New SqlConnection(connectionString)
                                                                  Dim providerCommand As New SqlCommand("SELECT balance FROM Provider WHERE provider_id = @ProviderId", providerConnection)
                                                                  providerCommand.Parameters.AddWithValue("@ProviderId", providerId)
                                                                  providerConnection.Open()
                                                                  providerBalance = Convert.ToInt32(providerCommand.ExecuteScalar())
                                                              End Using

                                                              ' Check if the provider has sufficient balance
                                                              If providerBalance >= refund_amount Then
                                                                  ' Update provider balance
                                                                  Using providerConnection As New SqlConnection(connectionString)
                                                                      Dim providerCommand As New SqlCommand("UPDATE Provider SET balance = balance - @RefundAmount WHERE provider_id = @ProviderId", providerConnection)
                                                                      providerCommand.Parameters.AddWithValue("@RefundAmount", refund_amount)
                                                                      providerCommand.Parameters.AddWithValue("@ProviderId", providerId)
                                                                      providerConnection.Open()
                                                                      providerCommand.ExecuteNonQuery()
                                                                  End Using

                                                                  ' Update customer balance
                                                                  Using customerConnection As New SqlConnection(connectionString)
                                                                      Dim customerCommand As New SqlCommand("UPDATE customer SET balance = balance + @RefundAmount WHERE user_id = @UserId", customerConnection)
                                                                      customerCommand.Parameters.AddWithValue("@RefundAmount", refund_amount)
                                                                      customerCommand.Parameters.AddWithValue("@UserId", userId)
                                                                      customerConnection.Open()
                                                                      customerCommand.ExecuteNonQuery()
                                                                  End Using

                                                                  ' Update status of the deal_id entry to 1
                                                                  Using updateConnection As New SqlConnection(connectionString)
                                                                      Dim updateCommandText As String = "UPDATE refunded_deals SET status = 1 WHERE deal_id = @DealId"
                                                                      Using updateCommand As New SqlCommand(updateCommandText, updateConnection)
                                                                          updateCommand.Parameters.AddWithValue("@DealId", dealid)
                                                                          updateConnection.Open()
                                                                          updateCommand.ExecuteNonQuery()
                                                                      End Using
                                                                  End Using

                                                                  ' Inform user about successful refund
                                                                  MessageBox.Show("Refund processed for " & customerName & ". Amount: $" & refund_amount.ToString())
                                                                  panel.Controls.Add(paid_label)
                                                                  panel.Controls.Remove(payRefundButton)

                                                                  'mail notification to user
                                                                  Try
                                                                      Dim mail As New MailMessage
                                                                      Dim smtpserver As New SmtpClient("smtp-mail.outlook.com")
                                                                      smtpserver.Port = 587

                                                                      mail.From = New MailAddress("group1b-cs346@outlook.com")
                                                                      mail.To.Add(email)
                                                                      mail.Subject = "CANCELLATION REFUND SUCCESSFUL"
                                                                      mail.Body = "Refund succcesful for appointment with provider : " + providername + " of  Amount : $" + refund_amount.ToString()

                                                                      smtpserver.Credentials = New System.Net.NetworkCredential("group1b-cs346@outlook.com", "chillSreehari")
                                                                      smtpserver.EnableSsl = True
                                                                      smtpserver.Send(mail)

                                                                  Catch ex As Exception
                                                                      MessageBox.Show("SMTP error: " & ex.Message)
                                                                  End Try
                                                              Else
                                                                  ' Inform user about insufficient balance
                                                                  MessageBox.Show("Insufficient balance to process refund.")
                                                              End If
                                                          End Sub

                        ' Add labels to the panel
                        panel.Controls.Add(nameLabel)
                        panel.Controls.Add(amount)
                        panel.Controls.Add(loc)

                        Dim isRefunded As Boolean = False
                        Using checkConnection As New SqlConnection(connectionString)
                            Dim checkCommandText As String = "SELECT status FROM refunded_deals WHERE deal_id = @DealId"
                            Using checkCommand As New SqlCommand(checkCommandText, checkConnection)
                                checkCommand.Parameters.AddWithValue("@DealId", dealid)
                                checkConnection.Open()
                                Dim status As Integer = Convert.ToInt32(checkCommand.ExecuteScalar())
                                isRefunded = (status = 1)
                            End Using
                        End Using

                        ' If the deal_id is present in the refunded_deals table and the status is 1 (refund paid)
                        If isRefunded Then
                            panel.Controls.Add(paid_label)
                        Else
                            panel.Controls.Add(payRefundButton)
                        End If

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
                        review.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
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