Imports System.Net.Mail
Imports System.Security.Cryptography.X509Certificates
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Drawing


Public Class User_Signup
    Dim code As Integer

    Private Sub User_Signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
    End Sub

    Private Sub Showpassword_cb_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword_cb.CheckedChanged
        If showpassword_cb.Checked Then
            password_tb.PasswordChar = ""
        Else
            password_tb.PasswordChar = "*"
        End If
    End Sub

    Private Sub Showcnfpassword_cb_CheckedChanged(sender As Object, e As EventArgs) Handles showcnfpassword_cb.CheckedChanged
        If showcnfpassword_cb.Checked Then
            cnfpassword_tb.PasswordChar = ""
        Else
            cnfpassword_tb.PasswordChar = "*"
        End If
    End Sub

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Close()
        Landing.Show()
    End Sub

    Private Sub SendEmail(randomNumber As Integer)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("group1b-cs346@outlook.com", email_tb.Text) With {
            .Subject = "Registration confirmation",
            .Body = "Welcome to the Taskmakerr! Your OTP is " + randomNumber.ToString
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

    Private Sub SendOTP_btn_Click(sender As Object, e As EventArgs) Handles sendOTP_btn.Click
        ' authenticate through otp
        Dim random As New Random()
        Dim randomNumber As Integer = random.Next(100000, 999999)
        code = randomNumber
        SendEmail(randomNumber)
    End Sub

    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        If String.IsNullOrWhiteSpace(name_tb.Text) Then
            error_label.Text = "* name is required"
            name_tb.Focus()
        ElseIf String.IsNullOrWhiteSpace(email_tb.Text) Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf String.IsNullOrWhiteSpace(password_tb.Text) Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        ElseIf String.IsNullOrWhiteSpace(cnfpassword_tb.Text) Then
            error_label.Text = "* confirm your password"
            cnfpassword_tb.Focus()
        ElseIf Not password_tb.Text = cnfpassword_tb.Text Then
            error_label.Text = "* password doesn't match"
        Else
            error_label.Text = ""

            Dim result As String
            Dim editPassword As Integer
            ' Validate the password and display the result in a message box
            result = PasswordStrengthCheck(password_tb.Text)
            editPassword = MsgBox(result & vbCrLf & "Are you satisfied with your password strength ?", vbYesNo, "Password Strength Checker")
            ' Check the user's response
            If editPassword = vbNo Then
                ' User wants to edit the password, return void.
                Return
            End If

            If String.IsNullOrWhiteSpace(otp_tb.Text) Then
                otp_tb.Focus()
            ElseIf Not code.ToString = otp_tb.Text.ToString Then
                MessageBox.Show("Wrong OTP: Please enter correct otp!")
            Else
                Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
                Dim query As String = "SELECT COUNT(*) FROM customer WHERE email = @Email"
                Dim insertQuery As String = "INSERT INTO customer (username, email, password, balance) VALUES (@Username, @Email, @Password, 0)"

                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()

                    ' Check if the email already exists in the database
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Email", email_tb.Text)
                        Dim count As Integer = Convert.ToInt32(sqlCommand.ExecuteScalar())
                        If count > 0 Then
                            ' If email already exists, display an error message and exit
                            error_label.Text = "Email already registered as User!"
                            Return
                        End If
                    End Using

                    ' If email doesn't exist, proceed with inserting into the database
                    Using sqlCommand As New SqlCommand(insertQuery, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Username", name_tb.Text)
                        sqlCommand.Parameters.AddWithValue("@Email", email_tb.Text)
                        sqlCommand.Parameters.AddWithValue("@Password", password_tb.Text)
                        sqlCommand.ExecuteNonQuery()
                    End Using
                    Me.Close()
                    Login.Show()
                End Using

            End If
        End If
    End Sub


End Class