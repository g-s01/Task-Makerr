Imports System.Diagnostics.Eventing
Imports System.IO
Imports Microsoft.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices

Public Class Login
    Dim login_status As Boolean = False
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
            Dim query As String = "SELECT Provider_ID, providername,profile_image FROM provider WHERE Email COLLATE Latin1_General_CS_AS = @Email AND Password COLLATE Latin1_General_CS_AS = @Password"


            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Email", Email)
                        sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user
                        Dim reader As SqlDataReader = sqlCommand.ExecuteReader()
                        If reader.Read() Then
                            Module_global.Provider_ID = Convert.ToInt32(reader("Provider_ID"))
                            Module_global.provider_name = reader("providername").ToString()
                            Module_global.User_Role = "provider"
                            ' Check if the profile_image field is not DBNull
                            If Not reader.IsDBNull(reader.GetOrdinal("profile_image")) Then
                                Dim imageData As Byte() = DirectCast(reader("profile_image"), Byte())
                                ' Convert byte array to image
                                Using ms As New MemoryStream(imageData)
                                    Module_global.provider_profilepic = Image.FromStream(ms)
                                End Using
                            Else
                                Module_global.provider_profilepic = My.Resources.male  ' Or set a default image if needed
                            End If
                            login_status = True

                        Else
                            error_label.Text = "Invalid email or password. No such provider account"
                            password_tb.Text = ""
                        End If
                        reader.Close()
                    End Using

                    If login_status Then
                        Dim supportquery As String = "
                        DECLARE @SupportRoomId INT;

                        IF NOT EXISTS (SELECT 1 FROM support_room WHERE user_id = @UserId AND user_type=@UserType)
                        BEGIN
                            INSERT INTO support_room (user_id, username, user_type)
                            VALUES (@UserId, @Username, @UserType);
                            SET @SupportRoomId = SCOPE_IDENTITY();
                        END
                        ELSE
                        BEGIN
                            SELECT @SupportRoomId = support_room_id FROM support_room WHERE user_id = @UserId AND user_type=@UserType;
                        END
                        SELECT @SupportRoomId AS support_room_id;
                        "
                        Using command As New SqlCommand(supportquery, sqlConnection)
                            ' Set parameter values
                            command.Parameters.AddWithValue("@UserId", Module_global.Provider_ID)
                            command.Parameters.AddWithValue("@Username", Module_global.provider_name)
                            command.Parameters.AddWithValue("@UserType", Module_global.User_Role)
                            ' Execute the command and retrieve the generated identity value
                            Module_global.Support_room_id = Convert.ToInt32(command.ExecuteScalar())
                            LoadRoomsFromDatabase(Module_global.Provider_ID, Module_global.User_Role)
                            'MessageBox.Show("support id" & Support_room_id)
                            Me.Close()
                            provider_template.Show()
                        End Using
                    End If

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
            Dim query As String = "SELECT User_ID,username,profile_image FROM customer WHERE Email COLLATE Latin1_General_CS_AS = @Email AND Password COLLATE Latin1_General_CS_AS = @Password"

            Try
                Using sqlConnection As New SqlConnection(connectionString)
                    sqlConnection.Open()
                    Using sqlCommand As New SqlCommand(query, sqlConnection)
                        sqlCommand.Parameters.AddWithValue("@Email", Email)
                        sqlCommand.Parameters.AddWithValue("@Password", pass) ' Use the password entered by the user

                        Dim reader As SqlDataReader = sqlCommand.ExecuteReader()
                        If reader.Read() Then
                            Module_global.User_ID = Convert.ToInt32(reader("User_ID"))
                            Module_global.user_name = reader("username").ToString()
                            Module_global.User_Role = "customer"
                            ' Check if the profile_image field is not DBNull
                            If Not reader.IsDBNull(reader.GetOrdinal("profile_image")) Then
                                Dim imageData As Byte() = DirectCast(reader("profile_image"), Byte())
                                ' Convert byte array to image
                                Using ms As New MemoryStream(imageData)
                                    user_profilepic = Image.FromStream(ms)
                                End Using
                            Else
                                ' Set default image using resource
                                user_profilepic = My.Resources.male ' Replace with your resource name
                            End If
                            login_status = True
                        Else
                            error_label.Text = "Invalid email or password. No such user account"
                            password_tb.Text = ""
                        End If
                        reader.Close()
                    End Using

                    If login_status Then
                        Dim supportquery As String = "
                          DECLARE @SupportRoomId INT;
                         IF NOT EXISTS (SELECT 1 FROM support_room WHERE user_id = @UserId and user_type=@UserType)
                          BEGIN
                              INSERT INTO support_room (user_id, username, user_type)
                              VALUES (@UserId, @Username, @UserType);
                              SET @SupportRoomId = SCOPE_IDENTITY();
                          END
                          ELSE
                          BEGIN
                              SELECT @SupportRoomId = support_room_id FROM support_room WHERE user_id = @UserId and user_type=@UserType;
                          END
                          SELECT @SupportRoomId AS support_room_id;
                          "
                        Using command As New SqlCommand(supportquery, sqlConnection)
                            ' Set parameter values
                            command.Parameters.AddWithValue("@UserId", Module_global.User_ID)
                            command.Parameters.AddWithValue("@Username", Module_global.user_name)
                            command.Parameters.AddWithValue("@UserType", Module_global.User_Role)
                            ' Execute the command and retrieve the generated identity value
                            Module_global.Support_room_id = Convert.ToInt32(command.ExecuteScalar())
                            LoadRoomsFromDatabase(Module_global.User_ID, Module_global.User_Role)
                            Me.Close()
                            user_template.Show()
                        End Using
                    End If

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
    Private Sub LoadRoomsFromDatabase(userId As Integer, user_role As String)
        Module_global.roomchat.Clear()
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

        If Module_global.User_Role = "provider" Then
            Dim query As String = "SELECT chat_room_id, username, provider_id FROM chat_room WHERE provider_id = @ProviderId"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to the SQL query to prevent SQL injection
                    command.Parameters.AddWithValue("@ProviderId", Module_global.Provider_ID)

                    Dim provider_id As Integer
                    Dim username As String
                    Dim chat_room_id As Integer

                    Try
                        connection.Open()
                        Dim reader As SqlDataReader = command.ExecuteReader()

                        If reader.HasRows Then
                            ' Loop through the rows
                            While reader.Read()
                                ' Access columns by name or index
                                provider_id = reader.GetInt32(reader.GetOrdinal("provider_id"))
                                chat_room_id = reader.GetInt32(reader.GetOrdinal("chat_room_id"))
                                username = reader.GetString(reader.GetOrdinal("username"))
                                Module_global.roomchat.Add(New Tuple(Of String, Integer, Integer)(username, chat_room_id, provider_id))
                            End While
                        End If

                        reader.Close()
                    Catch ex As Exception
                        Console.WriteLine("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        ElseIf Module_global.User_Role = "customer" Then
            Dim query As String = "SELECT chat_room_id, providername, provider_id FROM chat_room WHERE user_id = @UserId"
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to the SQL query to prevent SQL injection
                    command.Parameters.AddWithValue("@UserId", Module_global.User_ID)

                    Dim provider_id As Integer
                    Dim providername As String
                    Dim chat_room_id As Integer

                    Try
                        connection.Open()
                        Dim reader As SqlDataReader = command.ExecuteReader()

                        If reader.HasRows Then
                            ' Loop through the rows
                            While reader.Read()
                                ' Access columns by name or index
                                provider_id = reader.GetInt32(reader.GetOrdinal("provider_id"))
                                chat_room_id = reader.GetInt32(reader.GetOrdinal("chat_room_id"))
                                providername = reader.GetString(reader.GetOrdinal("providername"))
                                Module_global.roomchat.Add(New Tuple(Of String, Integer, Integer)(providername, chat_room_id, provider_id))
                            End While
                        End If

                        reader.Close()
                    Catch ex As Exception
                        Console.WriteLine("Error: " & ex.Message)
                    End Try
                End Using
            End Using
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Close()
        Forgot_password.Show()
    End Sub
End Class