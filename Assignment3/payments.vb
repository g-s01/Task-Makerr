Imports System.Net.Mail
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class payments
    ' to connect with the database
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    Dim connection As New SqlConnection(connectionString)
    ' Define a global identifiers of the user
    Dim ID As String = "gautam.sharma@iitg.ac.in"
    ' this is a function to pay money to the provider
    ' author: g-s01
    Private Sub payButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles payButton.Click
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(100000, 999999)
        Dim subject As String = "Payment to " + TextBox1.Text
        Dim body As String = "You are going to pay " + TextBox1.Text + "an amount of " + TextBox2.Text
        sendEmail(randomNumber, subject, body)
        Dim code As Integer
        If otp_auth.ShowDialog = DialogResult.OK Then
            If Integer.TryParse(otp_auth.InputValue, code) Then
                If code = randomNumber Then
                    MessageBox.Show("OTP Matches")
                End If
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