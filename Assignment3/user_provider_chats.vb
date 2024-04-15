Imports System.Configuration
Imports System.Globalization
Imports System.Reflection
Imports Microsoft.Data.SqlClient

'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class user_provider_chats

    Dim messages As New List(Of Tuple(Of Integer, Integer, String, String, String))()

    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Dim user_role As String = Module_global.User_Role

    Dim userId As Integer = 2
    Dim dealId As Integer = -1
    Public roomId As Integer = -1

    Private WithEvents timer As New Timer()


    ' for getting sql connection
    Private Function GetSqlConnection() As SqlConnection

        Return New SqlConnection(connectionString)
    End Function

    Private Sub LoadRoomsFromDatabase(userId As Integer, user_role As String)
        Module_global.roomchat.Clear()
        If user_role = "provider" Then
            Dim query As String = "SELECT chat_room_id, username, provider_id FROM chat_room WHERE provider_id = @UserId"
            Using connection As SqlConnection = GetSqlConnection()
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to the SQL query to prevent SQL injection
                    command.Parameters.AddWithValue("@UserId", userId)

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
        ElseIf user_role = "customer" Then
            Dim query As String = "SELECT chat_room_id, providername, provider_id FROM chat_room WHERE user_id = @UserId"
            Using connection As SqlConnection = GetSqlConnection()
                Using command As New SqlCommand(query, connection)
                    ' Add parameters to the SQL query to prevent SQL injection
                    command.Parameters.AddWithValue("@UserId", userId)

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

    Private Sub LoadMessagesFromDatabase(userId As Integer, user_role As String)

        Dim query As String = "SELECT m.* FROM chat_room cr JOIN messages m ON cr.chat_room_id = m.chat_room_id WHERE cr.provider_id = @UserId;"

        messages.Clear()
        If user_role = "customer" Then
            query = "SELECT m.* FROM chat_room cr JOIN messages m ON cr.chat_room_id = m.chat_room_id WHERE cr.user_id = @UserId;"
        End If


        Using connection As SqlConnection = GetSqlConnection()
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserId", userId)
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



    Private Function InsertMessageIntoDatabase(room As Integer, dealId As Integer, user_role As String, messageText As String) As Boolean
        Dim query As String = "INSERT INTO messages (chat_room_id, deal_id, sender_type, message_content) VALUES (@ChatRoomId, @DealId, @SenderType, @MessageContent)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ChatRoomId", room)
                command.Parameters.AddWithValue("@DealId", dealId)
                command.Parameters.AddWithValue("@SenderType", user_role)
                command.Parameters.AddWithValue("@MessageContent", messageText)

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

    Private Sub PopulateRooms()
        Dim yPos As Integer = 10 ' Initial y position for buttons

        For Each item As Tuple(Of String, Integer, Integer) In Module_global.roomchat
            Dim newButton As New Button()
            newButton.Name = "btn" & item.Item1 ' Set button name
            newButton.Text = item.Item1 ' Set button text
            newButton.TextAlign = ContentAlignment.MiddleCenter
            newButton.Width = chat_list.Width
            newButton.Height = 35 ' Set button height
            newButton.FlatStyle = FlatStyle.Flat ' Use flat style for rounded corners
            newButton.BackColor = Color.FromArgb(220, 189, 232) ' Set background color to pink
            newButton.FlatAppearance.BorderSize = 0 ' Remove border
            newButton.Font = New Font(newButton.Font.FontFamily, 12)
            newButton.ImageAlign = ContentAlignment.MiddleLeft ' Set image alignment
            newButton.TextImageRelation = TextImageRelation.ImageBeforeText ' Position image before tex
            ' Resize the image to match the button height
            Dim scaledImagenew As Image = New Bitmap(My.Resources.prov, New Size(35, 35))
            newButton.Image = scaledImagenew
            newButton.Region = New Drawing.Region(New Drawing.Rectangle(0, 0, newButton.Width, newButton.Height)) ' Make corners rounded
            newButton.Location = New Point(10, yPos) ' Set button position
            AddHandler newButton.Click, AddressOf Button_Click ' Add click event handler
            chat_list.Controls.Add(newButton) ' Add button to panel
            yPos += 37 ' Increment y position for next button
        Next
    End Sub



    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        If user_role = "customer" Then
            userId = Module_global.User_ID
        ElseIf user_role = "provider" Then
            userId = Module_global.Provider_ID
        End If
        timer.Interval = 3000
        LoadRoomsFromDatabase(userId, user_role)
        LoadMessagesFromDatabase(userId, user_role)
        PopulateRooms()

        'chat_list.Visible = False
        timer.Start()
        If roomId <> 0 Then
            ' Call the function to print messages between users
            PrintMessagesBetweenUsers(roomId)
        End If
    End Sub


    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        ' Reload rooms and messages every 30 seconds
        LoadRoomsFromDatabase(userId, user_role)
        LoadMessagesFromDatabase(userId, user_role)
        PopulateRooms()
    End Sub





    Private Sub Button_Click(sender As Object, e As EventArgs)
        ' Handle button click event
        chat.Visible = True

        Dim clickedButton As Button = CType(sender, Button)




        clickedButton.BackColor = Color.FromArgb(190, 159, 192) ' Set background color

        ' Update the label text with the name of the clicked button
        senderName.Text = clickedButton.Text
        For Each ctrl As Control In chat_list.Controls
            If TypeOf ctrl Is Button AndAlso ctrl IsNot clickedButton Then
                Dim otherButton As Button = CType(ctrl, Button)
                otherButton.BackColor = Color.FromArgb(220, 189, 232) ' Original color
            End If
        Next

        Dim room As Integer

        For Each pair As Tuple(Of String, Integer, Integer) In roomchat
            ' Check if the receiver matches the first item in the tuple
            If pair.Item1 = clickedButton.Text Then
                ' Fetch the second item (number) in the tuple
                room = pair.Item2
                ' Do something with the number...
                Exit For ' Exit loop if the match is found
            End If
        Next

        PrintMessagesBetweenUsers(room)
    End Sub

    Private Sub sendTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles sendTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Call the sendButton_Click event handler
            sendButton_Click(sender, e)
            ' Prevent the key press from being handled by the TextBox
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendBtn.Click
        'Dim messageText As String = chat_list.Controls("textBox1").Text ' Assuming TextBox1 is the name of the TextBox

        ' Get the receiver name from the label text within the chat_list panel
        Dim receiverName As String = senderName.Text ' Assuming Label1 contains the receiver name

        Dim room As Integer

        For Each pair As Tuple(Of String, Integer, Integer) In roomchat
            ' Check if the receiver matches the first item in the tuple
            If pair.Item1 = receiverName Then
                ' Fetch the second item (number) in the tuple
                room = pair.Item2
                ' Do something with the number...
                Exit For ' Exit loop if the match is found
            End If
        Next

        Dim maxLength As Integer = 50 ' Set the maximum length before inserting a newline
        Dim inputString As String = sendTextBox.Text
        Dim messageText As String = ""

        For i As Integer = 0 To inputString.Length - 1 Step maxLength
            Dim substringLength As Integer = Math.Min(maxLength, inputString.Length - i)
            messageText += inputString.Substring(i, substringLength)
            If i + substringLength < inputString.Length Then
                messageText += vbCrLf ' Insert a newline character if there are more characters remaining
            End If
        Next


        ' Add the new message to the messages list

        ' Optionally, you can clear the TextBox after sending the message
        sendTextBox.Text = ""

        InsertMessageIntoDatabase(room, dealId, user_role, messageText)
        ' Print messages between users
        Dim timeStamp As String = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss")
        Dim newMessage As New Tuple(Of Integer, Integer, String, String, String)(room, dealId, user_role, messageText, timeStamp)
        messages.Add(newMessage)
        PrintMessagesBetweenUsers(room)
    End Sub

    Private Sub PrintMessagesBetweenUsers(roomId As Integer)

        ' Clear existing messages on the chat_list panel
        For i As Integer = chat.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = chat.Controls(i)
            chat.Controls.RemoveAt(i)
        Next

        ' Filter messages for the given roomId
        Dim messagesInRoom = messages.Where(Function(msg) msg.Item1 = roomId)

        ' Sort messages by timestamp
        Dim sortedMessages = messagesInRoom.OrderBy(Function(msg) DateTime.Parse(msg.Item5))

        ' Y position for labels


        Dim yPos As Integer = 20



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

            messageLabel.MaximumSize = New Size(chat.Width - 10 * 3, 0)
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

            If senderType = user_role Then
                messageLabel.Left = chat.Width - messageLabel.PreferredWidth - 10 - 20
                label2.Left = messageLabel.Left + messageLabel.PreferredWidth - 35 + messageLabel.Width - 88
            ElseIf senderType <> user_role Then
                messageLabel.Left = 10
                label2.Left = textSize.Width - 15
            End If

            label2.AutoEllipsis = False ' Allow the label to display all text

            label2.Text = timeStamp

            label2.Font = New Font(messageLabel.Font.FontFamily, 7, FontStyle.Italic)

            messageLabel.Height = textSize.Height
            messageLabel.Top = yPos   ' Set the vertical position



            label2.Top = yPos + messageLabel.Height

            ' Manually calculate the height of the label based on the text and the maximum width




            ' Increment the vertical position for the next message with gap

            yPos += messageLabel.Height + label2.Height - 5

            ' Add label to the chat_list panel
            chat.Controls.Add(messageLabel)
            chat.Controls.Add(label2)
        Next


        ' Ensure the panel scrolls to the bottom to show the latest message
        chat.AutoScrollPosition = New Point(0, chat.AutoScrollPosition.Y + yPos)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class