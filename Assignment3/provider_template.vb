Public Class provider_template
    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub provider_template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With provider_appointments
            .TopLevel = False
            SplitContainer1.Panel2.Controls.Add(provider_appointments)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Login.Show()
    End Sub
End Class