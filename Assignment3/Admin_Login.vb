Public Class Admin_Login

    Private password_fill As Boolean = False

    Private Sub Admin_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
        showpassword_cb.Visible = False
    End Sub

    Private Sub Password_tb_Enter(sender As Object, e As EventArgs) Handles password_tb.Enter
        If password_tb.Text = "Password" And Not password_fill Then
            showpassword_cb.Visible = True
            password_tb.Text = ""
            password_fill = True
            password_tb.ForeColor = Color.Black
            If showpassword_cb.Checked Then
                password_tb.PasswordChar = ""
            Else
                password_tb.PasswordChar = "*"
            End If
        End If
    End Sub

    Private Sub Password_tb_Leave(sender As Object, e As EventArgs) Handles password_tb.Leave
        If password_tb.Text = "" Then
            password_tb.Text = "Password"
            password_fill = False
            password_tb.ForeColor = Color.Gray
            showpassword_cb.Checked = False
            password_tb.PasswordChar = ""
            showpassword_cb.Visible = False
        End If
    End Sub

    Private Sub Showpassword_cb_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword_cb.CheckedChanged
        If showpassword_cb.Checked Then
            password_tb.PasswordChar = ""
        Else
            password_tb.PasswordChar = "*"
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