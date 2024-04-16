Imports System.Configuration
Imports System.Net.Mail
Imports System.Reflection.Metadata.Ecma335
Imports Microsoft.Data.SqlClient
Imports Org.BouncyCastle.Math.EC

Public Class Forgot_password
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    Dim randnum As String
    Dim temp As String
    Private Sub send_Click(sender As Object, e As EventArgs) Handles send.Click
        ' Validate email address
        If String.IsNullOrWhiteSpace(Email.Text) Then
            Label14.Visible = False
            incorrect.Visible = True
            Email.Text = ""
            Email.Focus()
        ElseIf Not customer.Checked And Not provider.Checked Then
            incorrect.Visible = False
            Label14.Text = "Please select one box"
            Label14.Visible = True
        ElseIf IsValidEmail(Email.Text) Then
            ' Generate and send OTP to the email address
            incorrect.Visible = False
            Dim randomNumber As Integer = New Random().Next(1000, 10000)
            randnum = randomNumber.ToString()
            'MessageBox.Show(randnum)
            temp = Email.Text
            If SendEmail(Email.Text, randnum) Then
                otp.Focus()
                MessageBox.Show("OTP sent successfully to your email address.", "OTP Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("OTP can not be sent.", "Sending Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End If
        Else
            incorrect.Visible = True
            Email.Text = ""
            Email.Focus()
            'MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub proceed_Click(sender As Object, e As EventArgs) Handles proceed.Click
        ' Validate OTP
        If otp.Text = randnum Then
            Label7.Visible = False
            Panel4.Visible = False
            Panel3.Visible = True
        Else
            Label7.Visible = True
            otp.Text = ""
            otp.Focus()
        End If
    End Sub

    Private Sub save_Click(sender As Object, e As EventArgs) Handles save.Click
        If String.IsNullOrWhiteSpace(password.Text) Then
            Label8.Text = "new password is required"
            Label8.Visible = True
            password.Focus()
        ElseIf String.IsNullOrWhiteSpace(confirm_password.Text) Then
            Label8.Text = "confirm password your password"
            Label8.Visible = True
            confirm_password.Focus()
        ElseIf password.Text = confirm_password.Text Then
            Label8.Visible = False
            Dim result As String
            Dim editPassword As Integer
            ' Validate the password and display the result in a message box
            result = PasswordStrengthCheck(password.Text)
            editPassword = MsgBox(result & vbCrLf & "Are you satisfied with your password strength ?", vbYesNo, "Password Strength Checker")
            ' Check the user's response
            If editPassword = vbNo Then
                ' User wants to edit the password, return void.
                Return
            End If
            If customer.Checked Then
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE customer SET password = @NewPassword WHERE email = @Email"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@NewPassword", password.Text)
                        command.Parameters.AddWithValue("@Email", temp)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Password reset successfully.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    Dim query As String = "UPDATE provider SET password = @NewPassword WHERE email = @Email"
                    Using command As New SqlCommand(query, connection)
                        command.Parameters.AddWithValue("@NewPassword", password.Text)
                        command.Parameters.AddWithValue("@Email", temp)
                        command.ExecuteNonQuery()
                    End Using
                End Using
                MessageBox.Show("Password reset successfully.", "Password Reset", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
            Me.Close()
            Login.Show()
        Else
            Label8.Text = "password didn't match"
            Label8.Visible = True
            ' MessageBox.Show("Passwords do not match or do not meet the criteria.", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Function IsValidEmail(email As String) As Boolean
        If customer.Checked Then
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT COUNT(*) FROM customer WHERE email = @Email"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Email", email)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        Else
            Using connection As New SqlConnection(connectionString)
                connection.Open()
                Dim query As String = "SELECT COUNT(*) FROM provider WHERE email = @Email"
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@Email", email)
                    Dim count As Integer = Convert.ToInt32(command.ExecuteScalar())
                    Return count > 0
                End Using
            End Using
        End If
        Return True
    End Function

    Private Function SendEmail(recipientEmail As String, randomNumber As String)
        Try
            Dim smtpClient As New SmtpClient()
            Dim message As New MailMessage()

            Dim from, pass As String
            from = "flutterprojectnews@gmail.com"
            pass = "dlds lruz uasl ufqx"

            ' Configure SMTP settings
            smtpClient.Host = "smtp.gmail.com" ' SMTP server address
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
            smtpClient.Port = 587 ' the SMTP port number
            smtpClient.EnableSsl = True ' Enable SSL if required
            smtpClient.UseDefaultCredentials = False
            smtpClient.Credentials = New System.Net.NetworkCredential(from, pass)
            ' SMTP username and password

            ' Configure email message
            message.From = New MailAddress(from) ' the sender's email address
            message.To.Add(recipientEmail) ' the recipient's email address
            message.Subject = "Password Reset - Taskmakerr"

            ' Plain text content with dynamic random number
            Dim plainTextContent As String =
            "Hi," & vbCrLf & vbCrLf &
            "Welcome to Taskmakerr." & vbCrLf & vbCrLf &
            "Use the following OTP to reset the password of your account:  " & randomNumber & vbCrLf & vbCrLf &
            "Regards," & vbCrLf &
            "Taskmakerr"

            ' Set plain text content to the email body
            message.Body = plainTextContent

            ' Send the email
            smtpClient.Send(message)
            Return True
            MsgBox("An email with the OTP has been sent to your registered email address.")
        Catch ex As Exception
            Return False
            MsgBox(ex.Message)
        End Try

    End Function

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            password.PasswordChar = ""
        Else
            password.PasswordChar = "*"
        End If
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        If CheckBox2.Checked Then
            confirm_password.PasswordChar = ""
        Else
            confirm_password.PasswordChar = "*"
        End If
    End Sub

    Private Sub back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        If Panel4.Visible Then
            Me.Close()
            Login.Show()
        Else
            Panel3.Visible = False
            Panel4.Visible = True
        End If
    End Sub
End Class
