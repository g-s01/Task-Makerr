Imports System.Configuration
Imports System.Net.Mail
Imports System.Threading
Imports iText.StyledXmlParser.Jsoup.Select.Evaluator
Imports Microsoft.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices


Public Class pending_payment

    Public dealID As Integer = Module_global.Appointment_Det_DealId
    Public slots As Integer
    Public costPerHour As Decimal
    Dim provider As Integer = 0
    Dim ID As String
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
        Dim dates As DateTime
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
                            dates = reader.GetDateTime(reader.GetOrdinal("dates"))
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
                            Dim startTime As TimeSpan = TimeSpan.FromHours(9 + timeIndex)

                            ' Calculate the date and time
                            Dim firstDate As Date = dates.Date.AddDays(dayIndex)

                            Dim times As String = dates.Date.AddDays(dayIndex).Add(startTime).ToString("hh:mm tt")

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

        slots = 0
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
                    costPerHour = Convert.ToDecimal(command.ExecuteScalar())

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

    Public variableChanged As New ManualResetEvent(False)

    ' Variable to monitor for changes
    Public myVariable As Integer = 0

    Private Async Function WaitForVariableChangeOrTimeoutAsync(timeoutMilliseconds As Integer) As Task
        ' Wait for either the variable to change or the timeout to elapse
        Await Task.WhenAny(Task.Delay(timeoutMilliseconds), Task.Run(Sub() variableChanged.WaitOne()))

        ' After the wait, you can check if the variable changed or timeout happened
        If myVariable <> 0 Then
            ' The variable changed
            Console.WriteLine("Payment Successful")

        Else
            ' Timeout occurred
            MessageBox.Show("Timeout occurred.")
            If payments IsNot Nothing AndAlso Not payments.IsDisposed Then
                payments.Close()
            End If
            If otp_auth IsNot Nothing AndAlso Not otp_auth.IsDisposed Then
                otp_auth.Close()
            End If

        End If
    End Function

    Private Sub sendEmail(subject As String, body As String)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("group1b-cs346@outlook.com", ID)
        message.Subject = subject
        message.Body = body

        Dim smtpClient As New SmtpClient(smtpServer)
        smtpClient.Port = port
        smtpClient.Credentials = New System.Net.NetworkCredential("group1b-cs346@outlook.com", "chillSreehari")
        smtpClient.EnableSsl = True

        Try
            smtpClient.Send(message)
        Catch ex As SmtpException
            ' Handle specific SMTP exceptions
            MessageBox.Show("SMTP error: " & ex.Message)
        Catch ex As Exception
            ' Handle other exceptions
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try
    End Sub

    Private Async Sub btn_pay_Click(sender As Object, e As EventArgs) Handles btn_pay.Click
        Dim mail As String
        'MessageBox.Show(slots.ToString + " " + costPerHour.ToString)
        payments.CostOfService = (slots * costPerHour) / 2
        Dim query2 As String = "SELECT email FROM provider WHERE provider_id = @ProviderID"
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query2, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider)

                Try
                    connection.Open()
                    mail = Convert.ToString(command.ExecuteScalar())
                    ID = mail

                    payments.ProviderEmailID = mail

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
        'MessageBox.Show(payments.CostOfService.ToString + " " + payments.ProviderEmailID.ToString)
        variableChanged.Reset()
        myVariable = 0
        payments.Show()
        Await WaitForVariableChangeOrTimeoutAsync(900000)
        If (Module_global.payment_successful = 1) Then


            Dim query As String = "UPDATE deals SET status = 3 WHERE deal_id = @DealID"

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


                    Catch ex As Exception
                        MessageBox.Show("An error occurred: " & ex.Message)
                    End Try
                End Using
            End Using

            MessageBox.Show("Payment done successfully.")

            Dim subject As String = "Payment from " + ID
            Dim body As String = "You have received an amount of " + payments.CostOfService.ToString + " for your service."

            sendEmail(subject, body)

            Module_global.payment_successful = 0
            myVariable = 0
            variableChanged.Reset()


            Me.Hide()
            user_appointments.Show()
        Else

            myVariable = 0
            variableChanged.Reset()

            MessageBox.Show("payment unsuccessful")

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

End Class