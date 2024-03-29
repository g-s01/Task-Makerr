Public Class Landing
    Private Sub User_btn_Click(sender As Object, e As EventArgs) Handles user_btn.Click
        Me.Hide()
        User_Signup.Show()
    End Sub

    Private Sub Provider_btn_Click(sender As Object, e As EventArgs) Handles provider_btn.Click
        Me.Hide()
        Provider_Signup.Show()
    End Sub

    Private Sub Login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        Me.Hide()
        Login.Show()
    End Sub

    Private Sub Admin_ll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles admin_ll.LinkClicked
        Me.Hide()
        Admin_Login.Show()
    End Sub
End Class
