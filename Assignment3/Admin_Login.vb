Imports Microsoft.Data.SqlClient

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
        If String.IsNullOrWhiteSpace(password_tb.Text) Then
            error_label.Text = "* enter password"
            password_tb.Focus()
        Else
            error_label.Text = ""

            Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
            Dim sqlConnection As New SqlConnection(connectionString)

            Try
                sqlConnection.Open()
                MessageBox.Show("Connection successful!")
            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            Finally
                If sqlConnection.State = ConnectionState.Open Then
                    sqlConnection.Close()
                End If
            End Try


        End If
    End Sub
End Class