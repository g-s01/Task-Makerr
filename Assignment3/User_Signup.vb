Imports System.Net.Mail
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class User_Signup
    Dim name_fill As Boolean = False
    Dim email_fill As Boolean = False
    Dim password_fill As Boolean = False
    Dim cnfpassword_fill As Boolean = False
    Dim otp_fill As Boolean = False
    Dim code As Integer

    Private Sub User_Signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
    End Sub

    Private Sub Name_tb_Enter(sender As Object, e As EventArgs) Handles name_tb.Enter
        If name_tb.Text = "Name" And Not name_fill Then
            name_tb.Text = ""
            name_fill = True
            name_tb.ForeColor = Color.Black ' Change text color to default
        End If
    End Sub

    Private Sub Name_tb_Leave(sender As Object, e As EventArgs) Handles name_tb.Leave
        If name_tb.Text = "" Then
            name_tb.Text = "Name"
            name_fill = False
            name_tb.ForeColor = Color.Gray ' Change text color to placeholder color
        End If
    End Sub
    Private Sub Email_tb_Enter(sender As Object, e As EventArgs) Handles email_tb.Enter
        If email_tb.Text = "Email" And Not email_fill Then
            email_tb.Text = ""
            email_fill = True
            email_tb.ForeColor = Color.Black ' Change text color to default
        End If
    End Sub

    Private Sub Email_tb_Leave(sender As Object, e As EventArgs) Handles email_tb.Leave
        If email_tb.Text = "" Then
            email_tb.Text = "Email"
            email_fill = False
            email_tb.ForeColor = Color.Gray ' Change text color to placeholder color
        End If
    End Sub

    Private Sub Password_tb_Enter(sender As Object, e As EventArgs) Handles password_tb.Enter
        If password_tb.Text = "Password" And Not password_fill Then
            password_tb.Text = ""
            password_fill = True
            password_tb.ForeColor = Color.Black ' Change text color to default
            ' Optionally, you can set the PasswordChar property to hide the password characters
            password_tb.PasswordChar = "*"
        End If
    End Sub

    Private Sub Password_tb_Leave(sender As Object, e As EventArgs) Handles password_tb.Leave
        If password_tb.Text = "" Then
            password_tb.Text = "Password"
            password_fill = False
            password_tb.ForeColor = Color.Gray ' Change text color to placeholder color
            ' Optionally, reset the PasswordChar property to make the placeholder text visible
            password_tb.PasswordChar = ""
        End If
    End Sub

    Private Sub Cnfpassword_tb_Enter(sender As Object, e As EventArgs) Handles cnfpassword_tb.Enter
        If cnfpassword_tb.Text = "Confirm Password" And Not cnfpassword_fill Then
            cnfpassword_tb.Text = ""
            cnfpassword_fill = True
            cnfpassword_tb.ForeColor = Color.Black ' Change text color to default
            ' Optionally, you can set the PasswordChar property to hide the password characters
            cnfpassword_tb.PasswordChar = "*"
        End If
    End Sub

    Private Sub Cnfpassword_tb_Leave(sender As Object, e As EventArgs) Handles cnfpassword_tb.Leave
        If cnfpassword_tb.Text = "" Then
            cnfpassword_tb.Text = "Confirm Password"
            cnfpassword_fill = False
            cnfpassword_tb.ForeColor = Color.Gray ' Change text color to placeholder color
            ' Optionally, reset the PasswordChar property to make the placeholder text visible
            cnfpassword_tb.PasswordChar = ""
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

        Dim message As New MailMessage("task-makerr-cs346@outlook.com", email_tb.Text)
        message.Subject = "Registration confirmation"
        message.Body = "Welcome to the Taskmakerr! Your OTP is " + randomNumber.ToString

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

    Private Sub SendOTP_btn_Click(sender As Object, e As EventArgs) Handles sendOTP_btn.Click
        If Not name_fill Then
            error_label.Text = "* name is required"
            name_tb.Focus()
        ElseIf Not email_fill Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf Not password_fill Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        ElseIf Not cnfpassword_fill Then
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

    Private Sub Otp_tb_Enter(sender As Object, e As EventArgs) Handles otp_tb.Enter
        If otp_tb.Text = "OTP" Then
            otp_tb.Text = ""
            otp_tb.ForeColor = Color.Black ' Change text color to default
        End If
    End Sub

    Private Sub Otp_tb_Leave(sender As Object, e As EventArgs) Handles otp_tb.Leave
        If otp_tb.Text = "" Then
            email_tb.Text = "OTP"
            otp_fill = False
            email_tb.ForeColor = Color.Gray ' Change text color to placeholder color
        End If
    End Sub

    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        If Not code.ToString = otp_tb.ToString Then
            MessageBox.Show("Wrong OTP: Please enter correct otp!")
        End If
    End Sub
End Class