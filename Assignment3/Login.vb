Public Class Login

    Private email_fill As Boolean = False
    Private password_fill As Boolean = False

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
        showpassword_cb.Visible = False
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

    Private Sub Provider_btn_Click(sender As Object, e As EventArgs) Handles provider_btn.Click
        If Not email_fill Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf Not password_fill Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        Else
            error_label.Text = ""
            ' check from database
            Provider_ID = "12345"
            Me.Hide()
            user_template.Show()
        End If
    End Sub

    Private Sub User_btn_Click(sender As Object, e As EventArgs) Handles user_btn.Click
        If Not email_fill Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf Not password_fill Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        Else
            error_label.Text = ""
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