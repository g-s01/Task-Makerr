Public Class otp_auth
    Public ReadOnly Property InputValue As String
        Get
            Return TextBox1.Text
        End Get
    End Property

    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        ' Close the form when OK button is clicked
        DialogResult = DialogResult.OK
        Close()
    End Sub
End Class