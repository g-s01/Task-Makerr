Imports System.Globalization
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.Configuration.Provider
Imports Microsoft.CodeAnalysis.CSharp.Syntax

Public Class appointmentChat
    Dim roomId As Integer = -1
    Public dealId As Integer = -1
    Dim user_role As String = Module_global.User_Role
    Public userId As Integer = -1
    Public providerId As Integer = -1
    Dim providerName As String = ""
    Dim customerName As String = ""
    Private WithEvents messageTimer As New Timer()

    Dim messages As New List(Of Tuple(Of Integer, Integer, String, String, String))()
    ' check whether a room exists or not 


    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Private Function GetSqlConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function


    Private Sub GetSenderName()

        ' Assuming connectionString is defined elsewhere
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        ' Create a SqlConnection object
        If user_role = "customer" Then
            Using connection As New SqlConnection(connectionString)
                Try
                    ' Open the connection
                    connection.Open()

                    ' Create the query
                    Dim query As String = "SELECT providername FROM dbo.provider WHERE provider_id = @providerId;"

                    ' Create a SqlCommand object with the query and connection
                    Using command As New SqlCommand(query, connection)
                        ' Add parameter for provider ID
                        command.Parameters.AddWithValue("@providerId", providerId)

                        ' Execute the command and get the result
                        Dim result As Object = command.ExecuteScalar()

                        ' Check if the result is not null
                        If result IsNot Nothing Then
                            providerName = result.ToString()
                        Else
                            ' Handle if provider name is not found
                            MessageBox.Show("Provider name not found for the given provider ID.")
                        End If
                    End Using
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        ElseIf user_role = "provider" Then
            Using connection As New SqlConnection(connectionString)
                Try
                    ' Open the connection
                    connection.Open()
                    MessageBox.Show(userId)
                    ' Create the query
                    Dim query As String = "SELECT username FROM dbo.customer WHERE user_id = @userId;"

                    ' Create a SqlCommand object with the query and connection
                    Using command As New SqlCommand(query, connection)
                        ' Add parameter for provider ID
                        command.Parameters.AddWithValue("@userId", userId)

                        ' Execute the command and get the result
                        Dim result As Object = command.ExecuteScalar()

                        ' Check if the result is not null
                        If result IsNot Nothing Then
                            customerName = result.ToString()
                        Else
                            ' Handle if provider name is not found
                            MessageBox.Show("UserName name not found for the given user ID.")
                        End If
                    End Using
                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        End If
    End Sub





    Private Function GetRoom()
        Using connection As New SqlConnection(connectionString)
            Try
                ' Open the connection
                connection.Open()


                Dim query As String = "SELECT chat_room_id FROM dbo.chat_room WHERE user_id=@userId AND provider_id=@providerId;"

                ' Create a SqlCommand object with the select query and connection
                Using selectCommand As New SqlCommand(query, connection)
                    ' Add parameters for select command
                    selectCommand.Parameters.AddWithValue("@userId", userId)
                    selectCommand.Parameters.AddWithValue("@providerId", providerId)

                    ' Execute the select command and get the result
                    roomId = Convert.ToInt32(selectCommand.ExecuteScalar())

                    ' Check if the result is not null
                    If roomId > 0 Then
                        MessageBox.Show("Chat room ID: " & roomId.ToString())
                    Else
                        ' If no chat room found, create a new one
                        Dim insertQuery As String = "INSERT INTO dbo.chat_room (user_id, provider_id, username, providername) VALUES (@userId, @providerId, @username, @providername); SELECT SCOPE_IDENTITY();"

                        ' Create a SqlCommand object with the insert query and connection
                        Using insertCommand As New SqlCommand(insertQuery, connection)
                            ' Add parameters for insert command
                            insertCommand.Parameters.AddWithValue("@userId", userId)
                            insertCommand.Parameters.AddWithValue("@providerId", providerId)
                            insertCommand.Parameters.AddWithValue("@username", customerName) ' Assuming "Mokshith" is the username
                            insertCommand.Parameters.AddWithValue("@providername", providerName) ' Assuming "sahil_the_provider" is the provider name

                            ' Execute the insert command and get the inserted chat room ID
                            roomId = Convert.ToInt32(insertCommand.ExecuteScalar())

                            ' Display the newly created chat room ID
                            MessageBox.Show("New Chat room ID: " & roomId.ToString())

                        End Using
                    End If
                End Using
            Catch ex As Exception
                ' Handle any exceptions
                MessageBox.Show("An error occurred: " & ex.Message)
            End Try
        End Using
    End Function


    Private Function InsertMessageIntoDatabase(room As Integer, dealId As Integer, user_role As String, messageText As String) As Boolean
        Dim query As String = "INSERT INTO messages (chat_room_id, deal_id, sender_type, message_content,sent_timestamp) VALUES (@ChatRoomId, @DealId, @SenderType, @MessageContent, @SentTimestamp)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ChatRoomId", room)
                command.Parameters.AddWithValue("@DealId", dealId)
                command.Parameters.AddWithValue("@SenderType", user_role)
                command.Parameters.AddWithValue("@MessageContent", messageText)
                command.Parameters.AddWithValue("@SentTimestamp", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))

                Try
                    connection.Open()
                    ' Execute the insert query
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected <= 0 Then
                        MessageBox.Show("Error: No rows were inserted")
                        Return False
                    Else
                        Return True
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                    Return False
                End Try
            End Using
        End Using
    End Function

    Private Sub LoadMessagesFromDatabase(userId As Integer, user_role As String, dealId As Integer)

        Dim query As String = "SELECT * FROM messages WHERE chat_room_id = @chatRoomId AND deal_id = @dealId;"

        messages.Clear()
        Using connection As SqlConnection = GetSqlConnection()
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@chatRoomId", roomId)
                command.Parameters.AddWithValue("@dealId", dealId)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    If reader.HasRows Then
                        ' Loop through the rows
                        While reader.Read()
                            ' Access columns by name or index
                            Dim chat_room_id As Integer = reader.GetInt32(reader.GetOrdinal("chat_room_id"))
                            Dim deal_id As Integer = reader.GetInt32(reader.GetOrdinal("deal_id"))
                            Dim message_content As String = reader.GetString(reader.GetOrdinal("message_content"))
                            Dim sender_type As String = reader.GetString(reader.GetOrdinal("sender_type"))
                            Dim timestamp As String = reader.GetDateTime(reader.GetOrdinal("sent_timestamp")).ToString()

                            ' Add the message to the messages list
                            messages.Add(New Tuple(Of Integer, Integer, String, String, String)(chat_room_id, deal_id, sender_type, message_content, timestamp))
                        End While
                    End If
                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub MessageTimer_Tick(sender As Object, e As EventArgs)
        ' Call the PrintMessages function
        PrintMessages()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Stop the timer when the form is closed
        messageTimer.Stop()
    End Sub

    Private Sub appointmentChat_Load(sender As Object, e As EventArgs) Handles Me.Load

        messageTimer.Interval = 10000
        'MessageBox.Show(user_role)
        'If user_role = "customer" Then
        '    userId = Module_global.User_ID
        'ElseIf user_role = "provider" Then
        '    providerId = Module_global.Provider_ID
        ' End If
        GetSenderName()
        GetRoom()
        LoadMessagesFromDatabase(userId, user_role, dealId)
        PrintMessages()
        messageTimer.Start()
    End Sub


    Private Sub sendTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles inputTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Call the sendButton_Click event handler
            sendButton_Click(sender, e)
            ' Prevent the key press from being handled by the TextBox
            e.SuppressKeyPress = True
        End If
    End Sub
    Private Sub PrintMessages()

        Chat.Controls.Clear()
        If user_role = "customer" Then
            Label2.Text = providerName
        ElseIf user_role = "provider" Then
            Label2.Text = customerName
        End If
        Dim sortedMessages = messages.OrderBy(Function(msg) DateTime.Parse(msg.Item5))

        ' Y position for labels
        Dim yPos As Integer = 55

        ' Iterate through messages
        For Each msg In sortedMessages
            Dim room As Integer = msg.Item1
            Dim deal As Integer = msg.Item2
            Dim senderType As String = msg.Item3
            Dim messageText As String = msg.Item4
            Dim timeStamp As String = DateTime.ParseExact(msg.Item5, "dd-MM-yyyy HH:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm")


            ' Create a label for the message
            Dim messageLabel As New Label()
            messageLabel.AutoSize = True

            'messageLabel.MaximumSize = New Size(chat_list.Width * 3 \ 4, 25)
            messageLabel.Text = messageText '& " (" & timeStamp & ")"
            messageLabel.Font = New Font(messageLabel.Font.FontFamily, 10)
            messageLabel.Padding = New Padding(5)
            messageLabel.BackColor = ColorTranslator.FromHtml("#D9D9D9")
            messageLabel.MaximumSize = New Size(Chat.Width - 10 * 3, 0)
            Dim textSize = TextRenderer.MeasureText(messageLabel.Text, messageLabel.Font, messageLabel.MaximumSize, TextFormatFlags.WordBreak)

            Dim textHeight As Integer = textSize.Height
            Dim labelHeight As Integer = messageLabel.Height

            messageLabel.Padding = New Padding(0, (labelHeight - textHeight) \ 2, 0, 0)







            Dim label2 As New Label()
            label2.AutoSize = True
            label2.Margin = New Padding(0)

            label2.BackColor = Color.Transparent

            label2.Padding = New Padding(0, 0, 0, 0)

            label2.ForeColor = Color.Brown
            If senderType <> user_role Then
                messageLabel.Left = 10
                label2.Left = textSize.Width - 15

            Else
                messageLabel.Left = Chat.Width - messageLabel.PreferredWidth - 10 - 15
                label2.Left = messageLabel.Left + messageLabel.PreferredWidth + messageLabel.Width - 125
            End If

            label2.AutoEllipsis = False ' Allow the label to display all text

            label2.Text = timeStamp


            label2.Font = New Font(messageLabel.Font.FontFamily, 7, FontStyle.Italic)
            messageLabel.Height = textSize.Height
            messageLabel.Top = yPos   ' Set the vertical position



            label2.Top = yPos + messageLabel.Height

            ' Manually calculate the height of the label based on the text and the maximum width



            ' Set label position
            yPos += messageLabel.Height + label2.Height

            ' Add label to the chat_list panel
            Chat.Controls.Add(messageLabel)
            Chat.Controls.Add(label2)

        Next
        ' Ensure the panel scrolls to the bottom to show the latest message
        Chat.AutoScrollPosition = New Point(0, Chat.AutoScrollPosition.Y + yPos)
    End Sub
    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        ' Get the current timestamp
        Dim timeStamp = Date.Now.ToString("dd-MM-yyyy HH:mm:ss")
        Dim maxLength = 30 ' Set the maximum length before inserting a newline
        Dim inputString As String = inputTextBox.Text
        Dim messageText = ""

        For i = 0 To inputString.Length - 1 Step maxLength
            Dim substringLength = Math.Min(maxLength, inputString.Length - i)
            messageText += inputString.Substring(i, substringLength)
            If i + substringLength < inputString.Length Then
                messageText += vbCrLf ' Insert a newline character if there are more characters remaining
            End If
        Next

        Dim newMessage As New Tuple(Of Integer, Integer, String, String, String)(roomId, dealId, user_role, messageText, timeStamp)
        ' Add the new message to the messages list
        If (messageText.Length <> 0) Then
            InsertMessageIntoDatabase(roomId, dealId, user_role, messageText)
            messages.Add(newMessage)
            ' Optionally, you can clear the TextBox after sending the message
            inputTextBox.Text = ""
            ' Print messages between users
            PrintMessages()
        End If

    End Sub

End Class
