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
            Dim query As String = "SELECT password FROM admin"

            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        Dim pass As Object = sqlCommand.ExecuteScalar()
                        If pass IsNot Nothing AndAlso pass.ToString() = password_tb.Text Then
                            Me.Close()
                            admin_template.Show()
                        Else
                            error_label.Text = "Invalid password!!"
                            password_tb.Text = ""
                        End If
                    End Using
                End Using
            Catch ex As Exception
                ' Handle any exceptions that occur during database operations
                MessageBox.Show("An error occurred: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub
End Class