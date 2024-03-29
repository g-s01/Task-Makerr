Imports Microsoft.IdentityModel.Tokens

Public Class Admin_Login

    Private Sub Admin_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
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
        If password_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* enter password"
            password_tb.Focus()
        Else
            error_label.Text = ""
        End If
    End Sub
End Class