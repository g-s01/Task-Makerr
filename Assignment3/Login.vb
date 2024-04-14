Imports System.Reflection
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
            Return
        ElseIf String.IsNullOrWhiteSpace(password_tb.Text) Then
            error_label.Text = "* password is required"
            password_tb.Focus()
            Return
        Else
            error_label.Text = ""
            Dim pass As String = password_tb.Text()
            Email = email_tb.Text()
            ' check from database for the email and password
            Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
            Dim query As String = "SELECT Provider_ID,providername FROM provider WHERE Email COLLATE Latin1_General_CS_AS = @Email AND Password COLLATE Latin1_General_CS_AS = @Password"


            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Email", Email)
                        sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user
                        Dim reader As SqlDataReader = sqlCommand.ExecuteReader()
                        If reader.Read() Then
                            Module_global.Provider_ID = reader.GetInt32(0)
                            Module_global.User_Name = reader.GetString(1)
                            Module_global.User_Role = "provider"
                            Me.Close()
                            user_template.Show()
                        Else
                            error_label.Text = "Invalid email or password. No such user account"
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

    Private Sub User_btn_Click(sender As Object, e As EventArgs) Handles user_btn.Click
        If String.IsNullOrWhiteSpace(email_tb.Text) Then
            error_label.Text = "* email is required"
            email_tb.Focus()
            Return
        ElseIf String.IsNullOrWhiteSpace(password_tb.Text) Then
            error_label.Text = "* password is required"
            password_tb.Focus()
            Return
        Else
            error_label.Text = ""
            Dim pass As String = password_tb.Text()
            Email = email_tb.Text()
            ' check from database for the email and password
            Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
            Dim query As String = "SELECT User_ID, username FROM customer WHERE Email COLLATE Latin1_General_CS_AS = @Email AND Password COLLATE Latin1_General_CS_AS = @Password"

            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Email", Email)
                        sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user
                        Dim reader As SqlDataReader = sqlCommand.ExecuteReader()
                        If reader.Read() Then
                            Module_global.User_ID = reader.GetInt32(0)
                            Module_global.User_Name = reader.GetString(1)
                            Module_global.User_Role = "customer"
                            Me.Close()
                            user_template.Show()
                        Else
                            error_label.Text = "Invalid email or password. No such user account"
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

    Private Sub Register_btn_Click(sender As Object, e As EventArgs) Handles register_btn.Click
        Me.Close()
        Landing.Show()
    End Sub

    Private Sub Admin_ll_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles admin_ll.LinkClicked
        Close()
        Admin_Login.Show()
    End Sub


End Class