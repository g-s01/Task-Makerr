Imports System.Net.Mail
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Imports System.IO
Imports iText.Kernel.Pdf
Imports iText.Layout
Imports iText.Layout.Element
Imports iText.Kernel.Font
Imports iText.Layout.Properties
Imports iText.IO.Font.Constants

Public Class payments
    ' to connect with the database
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    ' Define a global identifiers of the user
    Dim ID As String = Email
    ' this is a function to pay money to the provider
    ' author: g-s01
    Private Sub payButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles payButton.Click
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(100000, 999999)
        Dim subject As String = "Payment to " + TextBox1.Text
        Dim body As String = "You are going to pay " + TextBox1.Text + "an amount of " + TextBox2.Text
        ' sending otp on mail
        sendEmail(randomNumber, subject, body)
        Dim code As Integer
        If otp_auth.ShowDialog = DialogResult.OK Then
            If Integer.TryParse(otp_auth.InputValue, code) Then
                If code = randomNumber Then
                    ' updating balance of both the users
                    Dim sqlQuery As String = "UPDATE customer SET balance = CASE WHEN email = @AccountNumber1 THEN balance - @AmountToUpdate WHEN email = @AccountNumber2 THEN balance + @AmountToUpdate END WHERE email IN (@AccountNumber1, @AccountNumber2);"

                    Using connection As New SqlConnection(connectionString)
                        Using command As New SqlCommand(sqlQuery, connection)
                            command.Parameters.AddWithValue("@AccountNumber1", ID)
                            command.Parameters.AddWithValue("@AccountNumber2", TextBox1.Text)
                            command.Parameters.AddWithValue("@AmountToUpdate", TextBox2.Text)

                            connection.Open()
                            command.ExecuteNonQuery()
                        End Using
                    End Using

                    Dim query As String = "SELECT balance FROM customer WHERE email = @AccountNumber;"
                    Using connection As New SqlConnection(connectionString)
                        Using command As New SqlCommand(query, connection)
                            command.Parameters.AddWithValue("@AccountNumber", ID)

                            connection.Open()
                            Dim balance As Object = command.ExecuteScalar()

                            If balance IsNot Nothing AndAlso Not DBNull.Value.Equals(balance) Then
                                ' Balance is retrieved successfully
                                Dim balanceValue As Decimal = Convert.ToDecimal(balance)
                                MessageBox.Show("Balance of account " + ID + ": " + balanceValue.ToString)
                            Else
                                ' Account number not found or balance is NULL
                                MessageBox.Show("Account number " + ID + " not found or balance is NULL")
                            End If
                        End Using
                    End Using
                    'receipt generation
                    Dim saveDialog As New SaveFileDialog()
                    saveDialog.Filter = "PDF File (*.pdf)|*.pdf"
                    saveDialog.FileName = "Receipt.pdf"
                    If saveDialog.ShowDialog() = DialogResult.OK Then
                        Try
                            Using pdfWriter As New PdfWriter(saveDialog.FileName)
                                Using pdfDocument As New PdfDocument(pdfWriter)
                                    Dim document As New Document(pdfDocument)

                                    ' Add content to the PDF
                                    document.Add(New Paragraph("Receipt").SetTextAlignment(TextAlignment.CENTER).SetFont(PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD)))
                                    document.Add(New Paragraph("------------------------------------------------------------------------------------------------------------------"))
                                    document.Add(New Paragraph("Date: " & DateTime.Now.ToString()))
                                    document.Add(New Paragraph("Amount: " + TextBox2.Text))
                                    document.Add(New Paragraph("Description: " + ID + " payed " + TextBox1.Text + ": " + TextBox2.Text))

                                    document.Close()

                                    MessageBox.Show("Receipt generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                End Using
                            End Using
                        Catch ex As Exception
                            MessageBox.Show($"Error generating PDF: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End Try
                    End If
                Else
                    MessageBox.Show("Write correct OTP please.")
                End If
            Else
                MessageBox.Show("The OTP is a 6 digit number, please adhere to the convention.")
            End If
        End If
    End Sub
    ' function to send email from admin
    ' parameter 1: randomNumber -> OTP
    ' parameter 2: subject -> subject of the mail
    ' parameter 3: body -> body of the mail
    ' author: g-s01
    Private Sub sendEmail(randomNumber As Integer, subject As String, body As String)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("task-makerr-cs346@outlook.com", ID)
        message.Subject = subject
        message.Body = body & vbCrLf & "Your OTP is " + randomNumber.ToString

        Dim smtpClient As New SmtpClient(smtpServer)
        smtpClient.Port = port
        smtpClient.Credentials = New System.Net.NetworkCredential("task-makerr-cs346@outlook.com", "hC-aw6:wqmfpMs4")
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
End Class