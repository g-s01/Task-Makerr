﻿Imports System.Configuration
Imports iText.IO.Font.Constants
Imports iText.Kernel.Font
Imports iText.Kernel.Pdf
Imports iText.Layout.Element
Imports iText.Layout.Properties
Imports iText.StyledXmlParser.Jsoup.Select.Evaluator
Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports Microsoft.Data.SqlClient
Imports System.Net.Mail
Imports System.Data.SqlClient
Imports System.IO
Imports iText.Layout
Imports Microsoft.Identity.Client.NativeInterop
Imports System.Diagnostics.Eventing
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Tab

Public Class provider_appointment_details
    Public dealID As Integer = Module_global.Appointment_Det_DealId
    Public startTime As TimeSpan
    Public firstDate As DateTime
    Public bookDate As DateTime
    Public advance As Double
    Private slots As Integer = 0
    Private advancePercentage As Integer = 50
    Private user As String
    Private costPerHour As Decimal
    Private status As Integer = 0
    Private email As String
    Private COMPLETED As Integer = 2
    Private CANCELLED As Integer = 4
    Dim user_id As Integer = 0
    Dim provider_id As Integer = 0
    Dim connectionString As String
    Dim provider As String
    Dim time As String = ""
    Dim ID As String = "task-makerr-cs346@outlook.in" ' For debugging


    Private Sub MakeChatVisible()
        SplitContainer1.Panel2.Controls.Clear()
        Dim chatForm As New appointmentChat()

        ' Set TopLevel property to False to allow embedding in another container
        chatForm.TopLevel = False
        chatForm.dealId = dealID
        chatForm.providerId = Module_global.Provider_ID
        chatForm.userId = user

        ' Set the form's Dock property to fill the panel
        chatForm.Dock = DockStyle.Fill

        ' Set the form's border style to None
        chatForm.FormBorderStyle = FormBorderStyle.None

        ' Add the form to the SplitContainer.Panel2
        SplitContainer1.Panel2.Controls.Add(chatForm)

        ' Show the form
        chatForm.Show()
    End Sub

    Private Sub provider_appointment_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'connectionString = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        connectionString = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE deal_id = @DealID"
        provider = 0


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
                            provider_id = reader.GetInt32(reader.GetOrdinal("provider_id"))
                            time = reader.GetString(reader.GetOrdinal("time"))
                            bookDate = reader.GetDateTime(reader.GetOrdinal("dates"))
                            user_id = reader.GetInt32(reader.GetOrdinal("user_id"))
                            status = reader.GetInt32(reader.GetOrdinal("status"))
                            'Dim location As String = reader.GetString(reader.GetOrdinal("location"))
                            ' Access other columns in a similar manner
                            ' Do something with the retrieved data
                            If status = 1 Then

                                btn_cancel.Visible = True
                                btn_cancel.Enabled = True
                                btn_appointment_completed.Visible = True
                                btn_appointment_completed.Enabled = True
                            Else
                                btn_cancel.Visible = False
                                btn_cancel.Enabled = False
                                btn_appointment_completed.Visible = False
                                btn_appointment_completed.Enabled = False
                            End If


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

                            rtb1.Text = vbLf & "   Details of the Booked Slots" & vbLf & vbLf & vbLf & "   Location: " & vbLf & vbLf & "   Date: " & firstDate.ToString("MMM dd yyyy") & "                            Timing: " & times



                        End While
                    Else
                        MessageBox.Show("No data found.")
                    End If

                    reader.Close()
                    MakeChatVisible()
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Dim query2 As String = "SELECT cost_per_hour FROM provider WHERE provider_id = @ProviderID"


        For Each character As Char In time
            If character = "1" Then
                slots += 1
            End If
        Next

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query2, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider_id)

                Try
                    connection.Open()
                    costPerHour = Convert.ToDecimal(command.ExecuteScalar())

                    ' Do something with the retrieved cost per hour
                    rtb2.Text = vbLf & "   Charges for the Appointment" & vbLf & vbLf & vbLf & "   Charges per Slot: Rs" & costPerHour & vbLf & vbLf & "   Overall Service Cost: Rs" & slots * costPerHour


                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Dim startIndex As Integer = rtb1.Text.IndexOf(" Details of the Booked Slots")
        Dim length As Integer = " Details of the Booked Slots".Length
        rtb1.Select(startIndex, length)
        ' rtb1.SelectionFont = New Font(rtb1.Font, FontStyle.Bold)

        startIndex = rtb2.Text.IndexOf(" Charges for the Appointment")
        length = " Charges for the Appointment".Length
        rtb2.Select(startIndex, length)

        Dim query3 As String = "SELECT email FROM provider WHERE provider_id = @ProviderID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query3, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider_id)

                Try
                    connection.Open()
                    email = Convert.ToString(command.ExecuteScalar())

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        'user name
        Dim query4 As String = "SELECT username FROM customer WHERE user_id = @UserID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query3, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserId", user_id)

                Try
                    connection.Open()
                    user = Convert.ToString(command.ExecuteScalar())

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
        'provider name
        Dim query5 As String = "SELECT providername FROM provider WHERE provider_id = @ProviderID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query3, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider_id)

                Try
                    connection.Open()
                    provider = Convert.ToString(command.ExecuteScalar())

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
        ' rtb2.SelectionFont = New Font(rtb2.Font, FontStyle.Bold)

    End Sub

    Private Sub btn_appointment_completed_Click(sender As Object, e As EventArgs) Handles btn_appointment_completed.Click
        Dim result As DialogResult = MessageBox.Show("Mark Appointment as completed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        ' Check the user's response
        If result = DialogResult.Yes Then

            Dim provider_exists As Boolean = False
                        Dim user_exists As Boolean = False
                        Dim provider_balance_sufficients As Boolean = False



                        Dim sqlQuery = "UPDATE deals SET status = @completed_status WHERE deal_id = @DealID;"

                        ' Add parameters to the SQL query to prevent SQL injection
                        Using connection As New SqlConnection(connectionString)
                            Using command As New SqlCommand(sqlQuery, connection)
                                command.Parameters.AddWithValue("@DealID", dealID)
                                command.Parameters.AddWithValue("@completed_status", COMPLETED)
                                connection.Open()
                                command.ExecuteNonQuery()
                            End Using
                        End Using
                        btn_cancel.Visible = False
                        btn_cancel.Enabled = False
                        btn_appointment_completed.Visible = False
            btn_appointment_completed.Enabled = False

        End If


    End Sub
    Private Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim currentDate As DateTime = DateTime.Now

        ' Combine stored date and time
        Dim storedDateTime As DateTime = firstDate.Date.Add(startTime)

        ' Calculate difference in hours
        Dim diff1 As Integer = CInt((currentDate - bookDate).TotalHours)

        Dim diff2 As Integer = CInt((storedDateTime - bookDate).TotalHours)

        Dim refundPercentage As Double = 100

        ' Cancellation Policy
        If diff1 <= diff2 / 24 Then
            refundPercentage = 100
        ElseIf diff1 <= diff2 / 6 Then
            refundPercentage = 105
        ElseIf diff1 <= diff2 / 3 Then
            refundPercentage = 110
        ElseIf diff1 >= 0 Then
            refundPercentage = 115
        Else
            refundPercentage = 125
        End If

        'refundPercentage = 50 ' for debugging
        advance = slots * costPerHour * (advancePercentage / 100)
        Dim refundAmount As Double = advance * (refundPercentage / 100)
        Dim result As DialogResult = MessageBox.Show("Cancellation will result in deduction of " & refundPercentage & "% of the advance payment (" & advancePercentage & "% of the total amount). Refund amount: " & refundAmount & ". Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        ' Check the user's response
        If result = DialogResult.Yes Then
            Dim random As New Random()
            Dim randomNumber As Integer = random.Next(100000, 999999)
            Dim subject As String = "Payment to " + user
            Dim body As String = "You are going to pay User " + user + " an amount of " + refundAmount.ToString
            ' sending otp on mail
            sendEmail(randomNumber, subject, body)
            Dim code As Integer
            If otp_auth.ShowDialog = DialogResult.OK Then
                If Integer.TryParse(otp_auth.InputValue, code) Then
                    If code = randomNumber Then
                        Dim provider_exists As Boolean = False
                        Dim user_exists As Boolean = False
                        Dim provider_balance_sufficients As Boolean = False

                        Dim query As String = "SELECT balance FROM provider WHERE provider_id = @AccountNumber;"
                        Using connection As New SqlConnection(connectionString)
                            Using command As New SqlCommand(query, connection)
                                command.Parameters.AddWithValue("@AccountNumber", provider_id)

                                connection.Open()
                                Dim balance As Object = command.ExecuteScalar()

                                If balance IsNot Nothing AndAlso Not DBNull.Value.Equals(balance) Then
                                    ' Balance is retrieved successfully
                                    provider_exists = True
                                    If Convert.ToInt32(balance) >= refundAmount Then
                                        provider_balance_sufficients = True
                                    Else
                                        MessageBox.Show("Insufficient balance.")
                                    End If

                                Else
                                    ' Account number not found or balance is NULL
                                    MessageBox.Show("Account number " + provider + " not found or balance is NULL")
                                End If
                            End Using
                        End Using

                        query = "SELECT balance FROM customer WHERE user_id = @AccountNumber;"

                        Using connection As New SqlConnection(connectionString)
                            Using command As New SqlCommand(query, connection)
                                command.Parameters.AddWithValue("@AccountNumber", user_id)


                                connection.Open()
                                Dim balance As Object = command.ExecuteScalar()

                                If balance IsNot Nothing AndAlso Not DBNull.Value.Equals(balance) Then
                                    ' Balance is retrieved successfully
                                    user_exists = True

                                Else
                                    ' Account number not found or balance is NULL
                                    MessageBox.Show("Account number " + user + " not found or balance is NULL")
                                End If
                            End Using
                        End Using
                        If user_exists And provider_exists And provider_balance_sufficients Then
                            ' updating balance of both the users
                            Dim sqlQuery As String = "UPDATE provider SET balance = balance - @AmountToUpdate WHERE provider_id = @AccountNumber1;"

                            Using connection As New SqlConnection(connectionString)
                                Using command As New SqlCommand(sqlQuery, connection)
                                    command.Parameters.AddWithValue("@AccountNumber1", provider_id)
                                    command.Parameters.AddWithValue("@AmountToUpdate", refundAmount)
                                    connection.Open()
                                    command.ExecuteNonQuery()
                                End Using
                            End Using
                            sqlQuery = "UPDATE customer SET balance = balance + @AmountToUpdate WHERE user_id = @AccountNumber1;"

                            Using connection As New SqlConnection(connectionString)
                                Using command As New SqlCommand(sqlQuery, connection)
                                    command.Parameters.AddWithValue("@AccountNumber1", user_id)
                                    command.Parameters.AddWithValue("@AmountToUpdate", refundAmount)
                                    connection.Open()
                                    command.ExecuteNonQuery()
                                End Using
                            End Using
                            'receipt generation
                            Dim saveDialog As New SaveFileDialog()
                            saveDialog.Filter = "PDF File (*.pdf)|*.pdf"
                            saveDialog.FileName = "Cancellation.pdf"
                            If saveDialog.ShowDialog() = DialogResult.OK Then
                                Try
                                    Using pdfWriter As New PdfWriter(saveDialog.FileName)
                                        Using pdfDocument As New PdfDocument(pdfWriter)
                                            Dim document As New Document(pdfDocument)
                                            Dim boldFont As PdfFont = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)
                                            ' Add content to the PDF
                                            document.Add(New Paragraph("Receipt").SetTextAlignment(TextAlignment.CENTER).SetFont(boldFont))
                                            document.Add(New Paragraph("------------------------------------------------------------------------------------------------------------------"))
                                            document.Add(New Paragraph("Date: " & DateTime.Now.ToString()))
                                            document.Add(New Paragraph("Amount: " + refundAmount.ToString))
                                            document.Add(New Paragraph("Description: Provider " + provider + " payed User " + user + ": " + refundAmount.ToString))

                                            document.Close()

                                            MessageBox.Show("Cancellation Receipt generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End Using
                                    End Using
                                Catch ex As Exception
                                    MessageBox.Show($"Error generating PDF: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End If

                            sqlQuery = "UPDATE deals SET status = @cancel_status WHERE deal_id = @DealID;"

                            ' Add parameters to the SQL query to prevent SQL injection
                            Using connection As New SqlConnection(connectionString)
                                Using command As New SqlCommand(sqlQuery, connection)
                                    command.Parameters.AddWithValue("@DealID", dealID)
                                    command.Parameters.AddWithValue("@cancel_status", CANCELLED)
                                    connection.Open()
                                    command.ExecuteNonQuery()
                                End Using
                            End Using
                            btn_cancel.Visible = False
                            btn_cancel.Enabled = False
                            btn_appointment_completed.Visible = False
                            btn_appointment_completed.Enabled = False

                        End If



                    Else
                        MessageBox.Show("Write correct OTP please.")
                    End If
                Else
                    MessageBox.Show("The OTP is a 6 digit number, please adhere to the convention.")
                End If
            End If
        Else

        End If


    End Sub

    Private Sub sendEmail(randomNumber As Integer, subject As String, body As String)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("group1b-cs346@outlook.com", email) With {
        .Subject = subject,
            .Body = body & vbCrLf & "Your OTP is " + randomNumber.ToString
        }

        Dim smtpClient As New SmtpClient(smtpServer) With {
            .Port = port,
            .Credentials = New System.Net.NetworkCredential("group1b-cs346@outlook.com", "chillSreehari"),
            .EnableSsl = True
        }

        Try
            smtpClient.Send(message)
            MessageBox.Show("OTP sent successfully to your email.")
        Catch ex As SmtpException
            ' Handle specific SMTP exceptions
            MessageBox.Show("SMTP error: " & ex.Message)
        Catch ex As Exception
            ' Handle other exceptions
            MessageBox.Show("Error sending email: " & ex.Message)
        End Try
    End Sub


    Private Sub SplitContainer1_SplitterMoved(sender As Object, e As SplitterEventArgs) Handles SplitContainer1.SplitterMoved

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

End Class