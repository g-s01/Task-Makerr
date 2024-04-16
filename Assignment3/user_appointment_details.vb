Imports System.Configuration
Imports System.Configuration.Provider
Imports System.Net.Mail
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client.NativeInterop
Public Class user_appointment_details
    Public dealID As Integer = 1
    Public startTime As TimeSpan
    Public firstDate As DateTime
    Public bookDate As DateTime
    Dim provider As Integer = 0
    Dim provider_email As String

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            ReloadData()
            MakeChatVisible()
        End If
    End Sub
    Private Sub MakeChatVisible()
        SplitContainer1.Panel2.Controls.Clear()
        Dim chatForm As New appointmentChat()

        ' Set TopLevel property to False to allow embedding in another container
        chatForm.TopLevel = False
        chatForm.dealId = dealID
        chatForm.providerId = provider
        chatForm.userId = Module_global.User_ID
        ' Set the form's Dock property to fill the panel
        chatForm.Dock = DockStyle.Fill

        ' Set the form's border style to None
        chatForm.FormBorderStyle = FormBorderStyle.None

        ' Add the form to the SplitContainer.Panel2
        SplitContainer1.Panel2.Controls.Add(chatForm)

        ' Show the form
        chatForm.Show()
    End Sub


    Private Sub ReloadData()
        dealID = Module_global.Appointment_Det_DealId
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        Dim query As String = "SELECT * FROM deals WHERE deal_id = @DealID"

        Dim time As String = ""

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@DealID", dealID)

                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()


                    ' Check if there are rows returned
                    If reader.HasRows Then
                        ' Loop through the rows
                        While reader.Read()

                            ' Access columns by name or index
                            provider = reader.GetInt32(reader.GetOrdinal("provider_id"))
                            time = reader.GetString(reader.GetOrdinal("time"))
                            bookDate = reader.GetDateTime(reader.GetOrdinal("dates"))
                            Dim location As String = reader.GetString(reader.GetOrdinal("location"))
                            ' Access other columns in a similar manner
                            ' Do something with the retrieved data


                            ' Find the position of the first '1' in the bit string
                            Dim firstOneIndex As Integer = time.IndexOf("1")

                            ' Calculate the day index based on the position of the first '1'
                            Dim dayIndex As Integer = firstOneIndex \ 12

                            ' Calculate the time index within the day
                            Dim timeIndex As Integer = firstOneIndex Mod 12

                            ' Calculate the time corresponding to the first '1'
                            startTime = TimeSpan.FromHours(9 + timeIndex)

                            ' Calculate the date and time
                            firstDate = bookDate.Date.AddDays(dayIndex)

                            Dim times As String = bookDate.Date.AddDays(dayIndex).Add(startTime).ToString("hh:mm tt")

                            rtb1.Text = vbLf & "   Details of the Booked Slots" & vbLf & vbLf & vbLf & "   Location: " & location & vbLf & vbLf & "   Date: " & firstDate.ToString("MMM dd yyyy") & "                            Timing: " & times



                        End While
                    Else
                        MessageBox.Show("No data found.")
                    End If

                    reader.Close()
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Dim query2 As String = "SELECT cost_per_hour FROM provider WHERE provider_id = @ProviderID"

        Dim slots As Integer = 0
        For Each character As Char In time
            If character = "1" Then
                slots += 1
            End If
        Next

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query2, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider)

                Try
                    connection.Open()
                    Dim costPerHour As Decimal = Convert.ToDecimal(command.ExecuteScalar())

                    ' Do something with the retrieved cost per hour
                    rtb2.Text = vbLf & "   Charges for the Appointment" & vbLf & vbLf & vbLf & "   Charges per Slot: Rs " & costPerHour & vbLf & vbLf & "   Overall Service Cost: Rs " & slots * costPerHour


                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Dim startIndex As Integer = rtb1.Text.IndexOf(" Details of the Booked Slots")
        Dim length As Integer = " Details of the Booked Slots".Length
        rtb1.Select(startIndex, length)
        rtb1.SelectionFont = New Font(rtb1.Font, FontStyle.Bold)

        startIndex = rtb2.Text.IndexOf(" Charges for the Appointment")
        length = " Charges for the Appointment".Length
        rtb2.Select(startIndex, length)
        rtb2.SelectionFont = New Font(rtb2.Font, FontStyle.Bold)
    End Sub

    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim currentDate As DateTime = DateTime.Now

        ' Combine stored date and time
        Dim storedDateTime As DateTime = firstDate.Date.Add(startTime)

        ' Calculate difference in hours
        Dim diff1 As Integer = CInt((currentDate - bookDate).TotalHours)

        Dim diff2 As Integer = CInt((storedDateTime - bookDate).TotalHours)

        Dim fee As Double

        If diff1 <= diff2 / 12 Then
            fee = 0
        ElseIf diff1 <= diff1 / 6 Then
            fee = 5
        ElseIf diff1 <= diff2 / 3 Then
            fee = 10
        ElseIf diff1 <= diff2 / 2 Then
            fee = 15
        ElseIf diff1 <= 24 Then
            fee = 25
        ElseIf diff1 < 2 * diff2 / 3 Then
            fee = 20
        ElseIf diff1 < 3 * diff2 / 4 Then
            fee = 22.5
        Else
            fee = 25
        End If

        Dim result As DialogResult = MessageBox.Show("Cancellation will result in deduction of " & fee & "% of paid amount." & vbCrLf & "Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Check the user's response
        If result = DialogResult.Yes Then
            Dim query As String = "UPDATE deals SET status = 4 WHERE deal_id = @DealID"

            Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString


            ' Create connection and command objects
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@DealID", dealID)

                    Try
                        ' Open connection
                        connection.Open()

                        ' Execute the update query
                        command.ExecuteNonQuery()

                        MessageBox.Show("Deal cancelled successfully.")
                    Catch ex As Exception
                        MessageBox.Show("An error occurred: " & ex.Message)
                    End Try
                End Using
            End Using

            Using connection As New SqlConnection(connectionString)
                query = "INSERT INTO refunded_deals (deal_id, refund_percentage, status) VALUES (@DealId, @percent, 0)"
                Using command As New SqlCommand(query, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@DealId", dealID)
                    command.Parameters.AddWithValue("@percent", 100 - fee)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            Using connection As New SqlConnection(connectionString)
                query = "Select email from provider where provider_id=@provider"
                Using command As New SqlCommand(query, connection)
                    ' Add parameters
                    command.Parameters.AddWithValue("@provider", provider)

                    connection.Open()
                    provider_email = (command.ExecuteScalar()).ToString()
                End Using
            End Using

            'email sent to customer
            Try
                Dim mail As New MailMessage
                Dim smtpserver As New SmtpClient("smtp-mail.outlook.com")
                smtpserver.Port = 587

                mail.From = New MailAddress("group1b-cs346@outlook.com")
                mail.To.Add(Module_global.Email)
                mail.Subject = "APPOINTMENT SUCCESFULLY CANCELLED"
                mail.Body = "Appointment succesfully cancelled from provider ID : " + provider.ToString() + " on date " + bookDate.ToString() + " fee " + (100 - fee).ToString() + "% of paid amount will be credited shortly to your account by the provider."

                smtpserver.Credentials = New System.Net.NetworkCredential("group1b-cs346@outlook.com", "chillSreehari")
                smtpserver.EnableSsl = True
                smtpserver.Send(mail)

                MessageBox.Show("Notification sent to customer")

            Catch ex As Exception
                MessageBox.Show("SMTP error: " & ex.Message)
            End Try

            'email sent to respective provider regarding cancellation
            Try
                Dim mail As New MailMessage
                Dim smtpserver As New SmtpClient("smtp-mail.outlook.com")
                smtpserver.Port = 587

                mail.From = New MailAddress("group1b-cs346@outlook.com")
                mail.To.Add(provider_email)
                mail.Subject = "APPOINTMENT CANCELLED"
                mail.Body = "Customer " + Module_global.user_name + " has cancelled your appointment booked on " + bookDate.ToString() + " . Please transfer the refund amount to the customer ASAP."

                smtpserver.Credentials = New System.Net.NetworkCredential("group1b-cs346@outlook.com", "chillSreehari")
                smtpserver.EnableSsl = True
                smtpserver.Send(mail)
                MessageBox.Show("notification sent to provider")
            Catch ex As Exception
                MessageBox.Show("SMTP error: " & ex.Message)
            End Try

            Me.Hide()
            user_appointments.Show()

        Else

        End If

    End Sub

    Private Sub btn_upcoming_Click(sender As Object, e As EventArgs) Handles btn_upcoming.Click
        Me.Hide()
        user_appointments.Show()
    End Sub

    Private Sub btn_completed_Click(sender As Object, e As EventArgs) Handles btn_completed.Click
        Me.Hide()
        user_appointments.Show()
    End Sub

    Private Sub btn_reschedule_Click(sender As Object, e As EventArgs) Handles btn_reschedule.Click
        'TODO: @Sreehari


        user_template.SplitContainer1.Panel2.Controls.Clear()

        Module_global.Provider_ID = provider
        'MessageBox.Show(provider)
        Module_global.DealID_Reschedule = dealID
        slot_back_choice = 1
        With Reschedule_Slots
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(Reschedule_Slots)
            .BringToFront()
            .Show()
        End With



    End Sub

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub
End Class