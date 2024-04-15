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
            Dim query As String = "SELECT Provider_ID, providername FROM provider WHERE Email COLLATE Latin1_General_CS_AS = @Email AND Password COLLATE Latin1_General_CS_AS = @Password"


            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Email", Email)
                        sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user
                        Dim result As Object = sqlCommand.ExecuteScalar()
                        Using reader As SqlDataReader = sqlCommand.ExecuteReader()
                            If reader.HasRows Then
                                reader.Read()
                                Provider_ID = Convert.ToInt32(reader("Provider_ID"))
                                user_name = reader("providername").ToString()
                                Me.Close()
                                provider_template.Show()
                            Else
                                error_label.Text = "Invalid email or password. No such provider account"
                                password_tb.Text = ""
                            End If
                        End Using
                    End Using
                    Dim supportquery As String = "
                            DECLARE @SupportRoomId INT;

                            IF NOT EXISTS (SELECT 1 FROM support_room WHERE user_id = @UserId)
                            BEGIN
                                INSERT INTO support_room (user_id, username, user_type)
                                VALUES (@UserId, @Username, @UserType);
                                SET @SupportRoomId = SCOPE_IDENTITY();
                            END
                            ELSE
                            BEGIN
                                SELECT @SupportRoomId = support_room_id FROM support_room WHERE user_id = @UserId;
                            END

                            SELECT @SupportRoomId AS support_room_id;
                            "
                    Using command As New SqlCommand(supportquery, sqlConnection)
                        ' Set parameter values
                        command.Parameters.AddWithValue("@UserId", Provider_ID)
                        command.Parameters.AddWithValue("@Username", user_name)
                        command.Parameters.AddWithValue("@UserType", "provider")

                        ' Execute the command and retrieve the generated identity value
                        Support_room_id = Convert.ToInt32(command.ExecuteScalar())
                        Role_type = "provider"
                        'MessageBox.Show("support id" & Support_room_id)
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
                        Using reader As SqlDataReader = sqlCommand.ExecuteReader()
                            If reader.HasRows Then
                                reader.Read()
                                User_ID = Convert.ToInt32(reader("User_ID"))
                                user_name = reader("username").ToString()
                                'MessageBox.Show("User_name and user_id" & User_name & User_ID)
                                Me.Close()
                                user_template.Show()
                            Else
                                error_label.Text = "Invalid email or password. No such user account"
                                password_tb.Text = ""
                            End If
                        End Using
                    End Using
                    Dim supportquery As String = "
                            DECLARE @SupportRoomId INT;

                            IF NOT EXISTS (SELECT 1 FROM support_room WHERE user_id = @UserId)
                            BEGIN
                                INSERT INTO support_room (user_id, username, user_type)
                                VALUES (@UserId, @Username, @UserType);
                                SET @SupportRoomId = SCOPE_IDENTITY();
                            END
                            ELSE
                            BEGIN
                                SELECT @SupportRoomId = support_room_id FROM support_room WHERE user_id = @UserId;
                            END

                            SELECT @SupportRoomId AS support_room_id;
                            "
                    Using command As New SqlCommand(supportquery, sqlConnection)
                        ' Set parameter values
                        command.Parameters.AddWithValue("@UserId", User_ID)
                        command.Parameters.AddWithValue("@Username", user_name)
                        command.Parameters.AddWithValue("@UserType", "customer")

                        ' Execute the command and retrieve the generated identity value
                        Support_room_id = Convert.ToInt32(command.ExecuteScalar())
                        Role_type = "customer"
                        'MessageBox.Show("support id" & Support_room_id)
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