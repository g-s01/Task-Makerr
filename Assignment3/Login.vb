Imports Microsoft.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Login

    Private email_fill As Boolean = False
    Private password_fill As Boolean = False

    Private Sub Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        error_label.Text = ""
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
            password_tb.Text = ""
            password_fill = True
            password_tb.ForeColor = Color.Black ' Change text color to default
            ' Optionally, you can set the PasswordChar property to hide the password characters
            password_tb.PasswordChar = "*"
        End If
    End Sub

    Private Sub Password_tb_Leave(sender As Object, e As EventArgs) Handles password_tb.Leave
        If password_tb.Text = "" Then
            password_tb.Text = "Password"
            password_fill = False
            password_tb.ForeColor = Color.Gray ' Change text color to placeholder color
            ' Optionally, reset the PasswordChar property to make the placeholder text visible
            password_tb.PasswordChar = ""
        End If
    End Sub

    'Upon clicking provider button
    Private Sub Provider_btn_Click(sender As Object, e As EventArgs) Handles provider_btn.Click
        If Not email_fill Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf Not password_fill Then
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
        If Not email_fill Then
            error_label.Text = "* email is required"
            email_tb.Focus()
        ElseIf Not password_fill Then
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

    End Sub
End Class