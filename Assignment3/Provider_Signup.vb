Imports System.Net.Mail
Imports System.Configuration
Imports Microsoft.Data.SqlClient
Imports System.IO
Imports System.Drawing
Public Class Provider_Signup

    Dim code As Integer
    Dim location_array(13) As Boolean
    Dim locations() As String = {"Guwahati", "Tezpur", "Jorhat", "Changsari", "Sualkuchi", "Palasbari", "Maliata", "Panbazar", "Panikhati", "Amsing", "Jorabat", "Lalmati", "Kahikuchi"}

    Private Sub Provider_Signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
        For i As Integer = 0 To 12
            location_array(i) = False
        Next

        ' Add checkboxes to the table
        For row As Integer = 0 To 6
            For col As Integer = 1 To 12
                Dim checkBox As New CheckBox()
                checkBox.Name = "cb_" & row.ToString() & "_" & col.ToString()
                checkBox.Dock = DockStyle.Fill
                checkBox.Padding = New Padding(10, 0, 0, 0)
                slot_matrix_tablelayout.Controls.Add(checkBox, col, row)
            Next
        Next
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

    Private Sub Changepic_pb_Click(sender As Object, e As EventArgs) Handles changepic_pb.Click
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif"
        }

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Set the selected image to the PictureBox
            profilepic_pb.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub

    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        If String.IsNullOrWhiteSpace(otp_tb.Text) Then
            otp_tb.Focus()
        ElseIf Not code.ToString = otp_tb.Text.ToString Then
            MessageBox.Show("Wrong OTP: Please enter correct otp!")
        Else

        End If
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click
        Dim timeslotbit As String = ""
        MessageBox.Show("")
    End Sub
End Class