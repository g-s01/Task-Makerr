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
    Dim header As String = ""

    Private WithEvents timer As New Timer()


    ' for getting sql connection
    Private Function GetSqlConnection() As SqlConnection

        Return New SqlConnection(connectionString)
    End Function

    Private Function LoadRoomsFromDatabase(userId As Integer, user_role As String)
        Dim prevLength As Integer = Module_global.roomchat.Count
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
        Return (prevLength <> Module_global.roomchat.Count)
    End Function

    Private Function LoadMessagesFromDatabase(userId As Integer, user_role As String)
        Dim prevLength As Integer = messages.Count

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
                            Dim timestamp As String = reader.GetDateTime(reader.GetOrdinal("sent_timestamp")).ToString("yyyy-MM-dd HH:mm:ss")
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
        Return (prevLength <> messages.Count)
    End Function



    Private Function InsertMessageIntoDatabase(room As Integer, dealId As Integer, user_role As String, messageText As String, timeStamp As String) As Boolean
        Dim query As String = "INSERT INTO messages (chat_room_id, deal_id, sender_type, message_content,sent_timestamp) VALUES (@ChatRoomId, @DealId, @SenderType, @MessageContent,@timeStamp)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ChatRoomId", room)
                command.Parameters.AddWithValue("@DealId", dealId)
                command.Parameters.AddWithValue("@SenderType", user_role)
                command.Parameters.AddWithValue("@MessageContent", messageText)
                command.Parameters.AddWithValue("@timeStamp", timeStamp)
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

    Private Sub PopulateRooms(Optional ByVal rooms As List(Of Tuple(Of String, Integer, Integer)) = Nothing)
        Dim yPos As Integer = 10 ' Initial y position for buttons

        ' Clear previously populated rooms
        chat_list.Controls.Clear()

        ' Check if rooms parameter is provided
        If rooms Is Nothing Then
            ' Use default Module_global.roomchat if no parameter is provided
            rooms = Module_global.roomchat
        End If

        For Each item As Tuple(Of String, Integer, Integer) In rooms
            Dim newButton As New Button()
            newButton.Name = "btn" & item.Item1 ' Set button name
            newButton.Text = item.Item1 ' Set button text
            newButton.TextAlign = ContentAlignment.MiddleCenter
            newButton.Width = chat_list.Width - 25
            newButton.Height = 35 ' Set button height
            newButton.FlatStyle = FlatStyle.Flat ' Use flat style for rounded corners
            newButton.BackColor = Color.FromArgb(220, 189, 232) ' Set background color to pink
            newButton.FlatAppearance.BorderSize = 0 ' Remove border
            newButton.Font = New Font(newButton.Font.FontFamily, 12)
            newButton.ImageAlign = ContentAlignment.MiddleLeft ' Set image alignment
            newButton.TextImageRelation = TextImageRelation.ImageBeforeText ' Position image before text
            ' Resize the image to match the button height
            Dim scaledImage As Image = New Bitmap(My.Resources.prov, New Size(35, 35))
            newButton.Image = scaledImage
            newButton.Region = New Drawing.Region(New Drawing.Rectangle(0, 0, newButton.Width, newButton.Height)) ' Make corners rounded
            newButton.Location = New Point(5, yPos) ' Set button position
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
        timer.Interval = 10000
        LoadRoomsFromDatabase(userId, user_role)
        LoadMessagesFromDatabase(userId, user_role)
        PopulateRooms()

        'chat_list.Visible = False
        timer.Start()
        If roomId <> 0 Or roomId <> -1 Then
            ' Call the function to print messages between users
            For Each pair As Tuple(Of String, Integer, Integer) In Module_global.roomchat
                If pair.Item2 = roomId Then
                    header = pair.Item1
                    Exit For ' Exit loop if the match is found
                End If
            Next
            For Each ctrl As Control In chat_list.Controls
                If TypeOf ctrl Is Button Then
                    Dim otherButton As Button = CType(ctrl, Button)
                    If otherButton.Text = header Then
                        otherButton.BackColor = Color.FromArgb(190, 159, 192) ' Set background color
                    Else
                        otherButton.BackColor = Color.FromArgb(220, 189, 232) ' Original color
                    End If
                End If
            Next
            senderName.Text = header
            PrintMessagesBetweenUsers(roomId)
            sendBtn.Visible = True
            sendTextBox.Visible = True
        Else
            sendBtn.Visible = False
            sendTextBox.Visible = False
        End If
    End Sub

    Private Sub timer_Tick(sender As Object, e As EventArgs) Handles timer.Tick
        ' Reload rooms and messages every 30 seconds
        If Me.Visible Then
            If (LoadRoomsFromDatabase(userId, user_role)) Then
                PopulateRooms()
            End If
            Dim messages_count_pv As Integer = 0
            Dim after_fetch As Integer = 0

            If roomId <> -1 Then
                For Each msg As Tuple(Of Integer, Integer, String, String, String) In messages
                    If msg.Item1 = roomId Then
                        messages_count_pv += 1
                    End If
                Next
            End If

            ' Reload messages from the database
            LoadMessagesFromDatabase(userId, user_role)
            If roomId <> -1 Then
                For Each msg As Tuple(Of Integer, Integer, String, String, String) In messages
                    If msg.Item1 = roomId Then
                        after_fetch += 1
                    End If
                Next
            End If

            ' Check if the number of messages for the current room has changed
            If roomId <> -1 AndAlso messages_count_pv <> after_fetch Then
                PrintMessagesBetweenUsers(roomId)
            End If
        End If
    End Sub




    Private Sub Button_Click(sender As Object, e As EventArgs)
        ' Handle button click event
        chat.Visible = True
        sendBtn.Visible = True
        sendTextBox.Visible = True

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

        For Each pair As Tuple(Of String, Integer, Integer) In Module_global.roomchat
            ' Check if the receiver matches the first item in the tuple
            If pair.Item1 = clickedButton.Text Then
                ' Fetch the second item (number) in the tuple
                roomId = pair.Item2
                ' Do something with the number...
                Exit For ' Exit loop if the match is found
            End If
        Next
        PrintMessagesBetweenUsers(roomId)
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

        Dim timeStamp As String = DateTime.Now.ToString("yyy-MM-dd HH:mm:ss")
        If (messageText.Length = 0) Then
            Return
        End If
        InsertMessageIntoDatabase(roomId, dealId, user_role, messageText, timeStamp)
        ' Print messages between users
        Dim newMessage As New Tuple(Of Integer, Integer, String, String, String)(roomId, dealId, user_role, messageText, timeStamp)
        messages.Add(newMessage)
        PrintMessagesBetweenUsers(roomId)
    End Sub
    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Stop the timer when the form is closed
        timer.Stop()
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

        Dim sortedMessages = messagesInRoom.OrderBy(Function(msg) DateTime.ParseExact(msg.Item5, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture))


        ' Y position for labels


        Dim yPos As Integer = 20

        Dim lastDisplayedDate As Date = DateTime.MinValue

        Dim dateLabelPrinted As Boolean = False

        ' Iterate through messages
        For Each msg In sortedMessages
            Dim room As Integer = msg.Item1
            Dim deal As Integer = msg.Item2
            Dim senderType As String = msg.Item3
            Dim messageText As String = msg.Item4

            Dim timeStamp As String = DateTime.ParseExact(msg.Item5, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm")
            Dim timeStamp1 As Date = DateTime.ParseExact(msg.Item5, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
            Dim messageDate As Date = timeStamp1.Date

            If Not dateLabelPrinted OrElse messageDate <> lastDisplayedDate Then
                ' Create a label for the date
                Dim dateLabel As New Label()
                dateLabel.AutoSize = True
                dateLabel.Text = messageDate.ToString("MMMM dd, yyyy") ' Format the date to display only date without time
                dateLabel.Font = New Font(dateLabel.Font.FontFamily, 10, FontStyle.Bold)
                dateLabel.Padding = New Padding(5)
                dateLabel.BackColor = SystemColors.Control ' Use system color for background
                dateLabel.TextAlign = ContentAlignment.MiddleCenter ' Center-align the text
                dateLabel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right ' Allow resizing with the panel width
                dateLabel.Top = yPos ' Center the label vertically
                dateLabel.Left = (chat.Width - dateLabel.Width) \ 2 ' Center the label horizontally

                ' Add the date label to the chat_list panel
                chat.Controls.Add(dateLabel)

                dateLabelPrinted = True

                ' Update the last displayed date
                lastDisplayedDate = messageDate
                yPos += dateLabel.Height
            End If

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

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged
        Dim searchText As String = SearchTextBox.Text.TrimEnd().ToLower() ' Convert search text to lower case for case-insensitive comparison and trim trailing spaces
        ' Filter rooms list based on search text
        Dim filteredRooms As List(Of Tuple(Of String, Integer, Integer)) = Module_global.roomchat.Where(Function(room) room.Item1.ToLower().Contains(searchText)).ToList()

        ' If search text is empty, show all rooms
        If String.IsNullOrEmpty(searchText) Then
            filteredRooms = Module_global.roomchat
        End If

        ' Populate rooms list with filtered rooms
        PopulateRooms(filteredRooms)
    End Sub


End Class