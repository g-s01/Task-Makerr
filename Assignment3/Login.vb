Imports Microsoft.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

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
        If String.IsNullOrWhiteSpace(email_tb.Text) Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf String.IsNullOrWhiteSpace(password_tb.Text) Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        Else
            error_label.Text = ""
            Dim pass As String = password_tb.Text()
            Email = email_tb.Text()
            ' check from database for the email and password
            Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
            Dim query As String = "SELECT Provider_ID FROM provider WHERE Email = @Email AND Password = @Password"

            Using sqlConnection As New SqlConnection(connectionString)
                sqlConnection.Open()
                Using sqlCommand As New SqlCommand(query, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@Email", Email)
                    sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user
                    Dim result As Object = sqlCommand.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        Provider_ID = Convert.ToInt32(result)
                        MessageBox.Show("Provider ID: " & Provider_ID.ToString(), "Provider ID Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        provider_template.Show()
                    Else
                        error_label.Text = "Invalid email or password. No such account"
                        password_tb.Text = ""
                    End If
                End Using
            End Using
        End If
    End Sub


    'Upon clicking user button
    Private Sub User_btn_Click(sender As Object, e As EventArgs) Handles user_btn.Click
        If String.IsNullOrWhiteSpace(email_tb.Text) Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf String.IsNullOrWhiteSpace(password_tb.Text) Then
            error_label.Text = "* password is required"
            password_tb.Focus()
        Else
            error_label.Text = ""
            Dim pass As String = password_tb.Text()
            Email = email_tb.Text()
            ' check from database for the email and password
            Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
            Dim query As String = "SELECT User_ID FROM customer WHERE Email = @Email AND Password = @Password"

            Using sqlConnection As New SqlConnection(connectionString)
                sqlConnection.Open()
                Using sqlCommand As New SqlCommand(query, sqlConnection)
                    sqlCommand.Parameters.AddWithValue("@Email", Email)
                    sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user
                    Dim result As Object = sqlCommand.ExecuteScalar()
                    If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                        User_ID = Convert.ToInt32(result)
                        MessageBox.Show("User ID: " & User_ID.ToString(), "User ID Found", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Me.Hide()
                        user_template.Show()
                    Else
                        error_label.Text = "Invalid email or password. No such account"
                        password_tb.Text = ""
                    End If
                End Using
            End Using
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