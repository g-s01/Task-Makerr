Public Class Admin_Login

    Private password_fill As Boolean = False

    Private Sub Admin_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
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

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Close()
        Landing.Show()
    End Sub

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        If Not password_fill Then
            error_label.Text = "* enter password"
            password_tb.Focus()
        Else
            error_label.Text = ""
        End If
    End Sub
End Class