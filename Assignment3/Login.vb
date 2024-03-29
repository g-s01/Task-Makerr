Imports Microsoft.IdentityModel.Tokens

Public Class Login

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
    End Sub

    Private Sub Showpassword_cb_CheckedChanged(sender As Object, e As EventArgs) Handles showpassword_cb.CheckedChanged
        If showpassword_cb.Checked Then
            password_tb.PasswordChar = ""
        Else
            password_tb.PasswordChar = "*"
        End If
    End Sub

    Private Sub Provider_btn_Click(sender As Object, e As EventArgs) Handles provider_btn.Click
        If email_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf password_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        Else
            error_label.Text = ""
            Email = email_tb.Text()
            ' check from database
            User_ID = "12340"
            Me.Hide()
            provider_template.Show()
        End If
    End Sub

    Private Sub User_btn_Click(sender As Object, e As EventArgs) Handles user_btn.Click
        If email_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf password_tb.Text.IsNullOrEmpty Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        Else
            error_label.Text = ""
            Email = email_tb.Text()
            ' check from database
            User_ID = "12340"
            Me.Hide()
            provider_template.Show()
        End If
    End Sub

    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        Me.Hide()
        Landing.Show()
    End Sub

    Private Sub Admin_ll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles admin_ll.LinkClicked
        Me.Hide()
        Admin_Login.Show()
    End Sub
End Class