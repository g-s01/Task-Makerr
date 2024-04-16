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
Imports Microsoft.Identity.Client.NativeInterop
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Collections.ObjectModel
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Public Class payments
    ' to connect with the database
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    ' Define a global identifiers of the user
    Dim ID As String = Email
    Public ProviderEmailID As String
    Public CostOfService As Integer
    ' this is a function to pay money to the provider
    ' author: g-s01

    Public Sub Payment_load(sender As Object, e As EventArgs) Handles MyBase.Load
        Module_global.payment_successful = 0
        'Book_slots'.variableChanged.Set()
        Book_slots.myVariable = 0
        Reschedule_Slots.ResmyVariable = 0
        pending_payment.myVariable = 0
        provider_appointment_details.PromyVariable = 0

    End Sub
    Private Sub payButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles payButton.Click
        If captcha.ShowDialog = DialogResult.OK Then
            Dim random As New Random()
            Dim randomNumber As Integer = random.Next(100000, 999999)
            Dim subject As String = "Payment to " + TextBox1.Text
            Dim body As String = "You are going to pay " + TextBox1.Text + "an amount of " + TextBox2.Text
            ' sending otp on mail
            sendEmail(randomNumber, subject, body)
            Dim code As Integer
            If otp_auth.ShowDialog = DialogResult.OK Then
                If Integer.TryParse(otp_auth.input, code) Then
                    If code = randomNumber Then
                        ' checks if the user has enough money in his account or not
                        Dim bal As Decimal = 0
                        Dim balanceQuery As String = "SELECT balance FROM customer WHERE email = @UserID;"
                        Using connection As New SqlConnection(connectionString)
                            connection.Open()
                            Using command As New SqlCommand(balanceQuery, connection)
                                command.Parameters.AddWithValue("@UserId", ID)
                                Using reader As SqlDataReader = command.ExecuteReader()
                                    If reader.Read() AndAlso Not reader.IsDBNull(0) Then
                                        bal = Convert.ToDecimal(reader("balance"))
                                        'MessageBox.Show(bal)
                                    Else
                                        MessageBox.Show("User balance not found.")
                                        Return
                                    End If
                                End Using
                            End Using
                        End Using
                        If bal >= Decimal.Parse(TextBox2.Text) Then
                            Module_global.payment_successful = 1
                            Book_slots.myVariable = 1
                            Book_slots.variableChanged.Set()
                            Reschedule_Slots.ResmyVariable = 1
                            Reschedule_Slots.ResvariableChanged.Set()
                            pending_payment.myVariable = 1
                            pending_payment.variableChanged.Set()
                            provider_appointment_details.PromyVariable = 1
                            provider_appointment_details.ProvariableChanged.Set()
                            'MessageBox.Show(Module_global.payment_successful)
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
                                            document.Add(New Paragraph("Description: " + ID + " paid " + TextBox1.Text + ": " + TextBox2.Text))

                                            document.Close()

                                            MessageBox.Show("Receipt generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                                        End Using
                                    End Using
                                Catch ex As Exception
                                    MessageBox.Show($"Error generating PDF: {ex.ToString()}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                                End Try
                            End If
                            Dim paymentAmount As Decimal
                            If Decimal.TryParse(TextBox2.Text, paymentAmount) Then
                                ' Apply cashback
                                ApplyCashback(ID, paymentAmount)
                            End If
                        Else
                            MessageBox.Show("Your balance is less than the amount to be paid, kindly update your balance and try again")
                        End If
                    Else
                        MessageBox.Show("Write correct OTP please.")
                    End If
                Else
                    MessageBox.Show("The OTP is a 6 digit number, please adhere to the convention.")
                End If
            End If
            Close()
        End If
    End Sub
    ' function to send email from admin
    ' parameter 1: randomNumber -> OTP
    ' parameter 2: subject -> subject of the mail
    ' parameter 3: body -> body of the mail
    ' author: g-s01
    Private Sub PaymentForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Book_slots.myVariable = 0  Then
            ' Notify the book_slots form about incomplete payment
            Module_global.payment_successful = 0
            Book_slots.variableChanged.Set()
            Book_slots.myVariable = 0
            Reschedule_Slots.ResmyVariable = 0
            Reschedule_Slots.ResvariableChanged.Set()
            pending_payment.variableChanged.Set()
            pending_payment.myVariable = 0
            provider_appointment_details.PromyVariable = 0
            provider_appointment_details.ProvariableChanged.Set()
        Else
            Module_global.payment_successful = 1
            'Book_slots.variableChanged.Set()

            'receipt generation
        End If


    End Sub
    Private Sub sendEmail(randomNumber As Integer, subject As String, body As String)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("group1b-cs346@outlook.com", ID)
        message.Subject = subject
        message.Body = body & vbCrLf & "Your OTP is " + randomNumber.ToString

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
    ' Function to update user balance with cashback
    ' author: nikhitha
    Sub ApplyCashback(email As String, paymentAmount As Decimal)
        ' Generate a random number between 0 and 1
        Dim random As New Random()
        Dim CashbackPercentage As Decimal = random.NextDouble() * 0.05D
        Dim randomNumber As Integer = random.Next(2)

        If randomNumber = 1 Then
            ' Check if the randomly generated number falls within the cashback probability
            Dim cashbackAmount As Decimal = paymentAmount * CashbackPercentage
            Dim sqlQuery As String = "UPDATE customer SET balance = balance + @CashbackAmount WHERE email = @Email;"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sqlQuery, connection)
                    command.Parameters.AddWithValue("@CashbackAmount", cashbackAmount)
                    command.Parameters.AddWithValue("@Email", email)

                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            MessageBox.Show("Cashback of Rs" & cashbackAmount.ToString("0.00") & " applied successfully!", "Cashback Applied", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Uhoh! No cashback awarded this time.", "Cashback", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub
    ' function which controls the loading logic of the form
    ' author: g-s01
    Private Sub payments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.Text = ProviderEmailID
        TextBox1.Enabled = False
        TextBox2.Text = CostOfService.ToString
        TextBox2.Enabled = False
    End Sub

    ' function to add money to wallet
    ' author: g-s01
    Private Sub addButton_Click(sender As Object, e As EventArgs) Handles addButton.Click
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(100000, 999999)
        Dim subject As String = "Adding Money to Wallet"
        Dim body As String = "You are adding an amount of " + TextBox3.Text + " to your wallet."
        ' sending otp on mail
        sendEmail(randomNumber, subject, body)
        Dim code As Integer
        If otp_auth.ShowDialog = DialogResult.OK Then
            If Integer.TryParse(otp_auth.input, code) Then
                If code = randomNumber Then
                    'updating the balance of the account
                    Dim sqlQuery As String = "UPDATE customer SET balance = balance + @CashbackAmount WHERE email = @Email;"

                    Using connection As New SqlConnection(connectionString)
                        Using command As New SqlCommand(sqlQuery, connection)
                            command.Parameters.AddWithValue("@CashbackAmount", TextBox3.Text)
                            command.Parameters.AddWithValue("@Email", Email)

                            connection.Open()
                            command.ExecuteNonQuery()
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
                                    document.Add(New Paragraph("Amount: " + TextBox3.Text))
                                    document.Add(New Paragraph("Description: " + ID + " updated their balance with an amount of " + TextBox3.Text))

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

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        Close()
    End Sub
End Class
