Public Class admin_template
    Private Sub admin_template_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Admin_Login.Show()
    End Sub
End Class