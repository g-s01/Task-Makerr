Imports System.Net.Mail
Imports Microsoft.IdentityModel.Tokens

Public Class Provider_Signup

    Dim code As Integer

    Private Sub Provider_Signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Hide()
        Landing.Show()
    End Sub

    Private Sub SendEmail(randomNumber As Integer)
        Dim smtpServer As String = "smtp-mail.outlook.com"
        Dim port As Integer = 587

        Dim message As New MailMessage("task-makerr-cs346@outlook.com", email_tb.Text) With {
            .Subject = "Registration confirmation",
            .Body = "Welcome to the Taskmakerr! Your OTP is " + randomNumber.ToString
        }

        Dim smtpClient As New SmtpClient(smtpServer) With {
            .Port = port,
            .Credentials = New System.Net.NetworkCredential("task-makerr-cs346@outlook.com", "hC-aw6:wqmfpMs4"),
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
        If name_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* name is required"
            name_tb.Focus()
        ElseIf email_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf password_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        ElseIf cnfpassword_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* confirm your password"
            cnfpassword_tb.Focus()
        ElseIf Not password_tb.Text = cnfpassword_tb.Text Then
            error_label.Text = "* password doesn't match"
        Else
            error_label.Text = ""
            ' authenticate through otp
            Dim random As New Random()
            Dim randomNumber As Integer = random.Next(100000, 999999)
            code = randomNumber
            SendEmail(randomNumber)

            ' name_tb.Enabled = False
            ' email_tb.Enabled = False
            ' password_tb.Enabled = False
            ' cnfpassword_tb.Enabled = False

        End If
    End Sub

    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        If Not code.ToString = otp_tb.ToString Then
            MessageBox.Show("Wrong OTP: Please enter correct otp!")
        End If
    End Sub
End Class