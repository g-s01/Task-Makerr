Imports System.Configuration
Imports Microsoft.Data.SqlClient

'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class user_provider_chats

    Dim roomchat As New List(Of Tuple(Of String, Integer, Integer))() ' providername, chat_room_id, provider_id
    Dim messages As New List(Of Tuple(Of Integer, Integer, String, String, String))()
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Dim user_role As String = "customer"
    Dim userId As Integer = 1
    Dim dealId As Integer = -1

    ' for getting sql connection
    Private Function GetSqlConnection() As SqlConnection
        Return New SqlConnection(connectionString)
    End Function

    Private Sub LoadRoomsFromDatabase(userId As Integer)
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
                            roomchat.Add(New Tuple(Of String, Integer, Integer)(providername, chat_room_id, provider_id))
                        End While
                    End If

                    reader.Close()
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Sub LoadMessagesFromDatabase(userId As Integer, dealId As Integer)
        Dim query As String = "SELECT m.* FROM chat_room cr JOIN messages m ON cr.chat_room_id = m.chat_room_id WHERE cr.user_id = @UserId and m.deal_id = @DealId"

        Using connection As SqlConnection = GetSqlConnection()
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserId", userId)
                command.Parameters.AddWithValue("@DealId", dealId)

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


    Private Function InsertMessageIntoDatabase(room As Integer, dealId As Integer, user_role As String, messageText As String, timeStamp As DateTime) As Boolean
        Dim query As String = "INSERT INTO messages (chat_room_id, deal_id, sender_type, message_content, sent_timestamp) VALUES (@ChatRoomId, @DealId, @SenderType, @MessageContent, @SentTimestamp)"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ChatRoomId", room)
                command.Parameters.AddWithValue("@DealId", dealId)
                command.Parameters.AddWithValue("@SenderType", user_role)
                command.Parameters.AddWithValue("@MessageContent", messageText)
                command.Parameters.AddWithValue("@SentTimestamp", timeStamp)

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

        For Each item As Tuple(Of String, Integer, Integer) In roomchat
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


    Private Sub HandleTitle()
        ' Create and configure the Label
        Dim newLabel As New Label()
        newLabel.Name = "lblHeader"
        newLabel.Text = "Header Text"
        newLabel.TextAlign = ContentAlignment.MiddleCenter
        newLabel.Width = chat.Width
        newLabel.Height = 35 ' Set label height
        newLabel.BackColor = Color.FromArgb(220, 189, 232) ' Set background color
        newLabel.Font = New Font(newLabel.Font.FontFamily, 12)
        newLabel.Location = New Point(10, 10) ' Set label position at the top of the panel
        newLabel.ImageAlign = ContentAlignment.MiddleLeft ' Set image alignment
        newLabel.TextAlign = ContentAlignment.MiddleCenter
        newLabel.Font = New Font(newLabel.Font.FontFamily, 12)

        ' Resize the image to match the button height
        Dim scaledImage As Image = New Bitmap(My.Resources.prov, New Size(35, 35))
        newLabel.Image = scaledImage
        newLabel.Region = New Drawing.Region(New Drawing.Rectangle(0, 0, newLabel.Width, newLabel.Height)) ' Make corners rounded

        ' Add controls to the panel
        chat.Controls.Add(newLabel)
    End Sub

    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        roomchat.Add(New Tuple(Of String, Integer, Integer)("Apple", 1, 0))
        roomchat.Add(New Tuple(Of String, Integer, Integer)("Banana", 2, 0))
        roomchat.Add(New Tuple(Of String, Integer, Integer)("Orange", 3, 0))
        roomchat.Add(New Tuple(Of String, Integer, Integer)("Grapes", 4, 0))
        messages.Clear()
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(1, -1, "customer", "Hey there!", "2024-03-30 10:00:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(2, -1, "provider", "How are you?", "2024-03-30 10:05:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(3, -1, "provider", "What's up?", "2024-03-30 10:10:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(4, -1, "customer", "Good morning!", "2024-03-30 10:15:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(1, -1, "provider", "How's it going?", "2024-03-30 10:20:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(2, -1, "provider", "Want to hang out later?", "2024-03-30 10:25:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(3, -1, "customer", "Sure, let's meet at 4!", "2024-03-30 10:30:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(4, -1, "provider", "Sounds good!", "2024-03-30 10:35:00"))

        PopulateRooms()
        HandleTitle()

        'chat_list.Visible = False
    End Sub


    Private Sub Button_Click(sender As Object, e As EventArgs)
        ' Handle button click event
        chat.Visible = True

        Dim clickedButton As Button = CType(sender, Button)
        Dim labelHeader As Label = CType(chat.Controls("lblHeader"), Label)



        clickedButton.BackColor = Color.FromArgb(190, 159, 192) ' Set background color

        ' Update the label text with the name of the clicked button
        labelHeader.Text = clickedButton.Text
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


    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendBtn.Click
        'Dim messageText As String = chat_list.Controls("textBox1").Text ' Assuming TextBox1 is the name of the TextBox

        ' Get the receiver name from the label text within the chat_list panel
        Dim receiverName As String = chat.Controls("lblHeader").Text ' Assuming Label1 contains the receiver name

        ' Get the current timestamp
        Dim timeStamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

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

        Dim maxLength As Integer = 30 ' Set the maximum length before inserting a newline
        Dim inputString As String = sendTextBox.Text
        Dim messageText As String = ""

        For i As Integer = 0 To inputString.Length - 1 Step maxLength
            Dim substringLength As Integer = Math.Min(maxLength, inputString.Length - i)
            messageText += inputString.Substring(i, substringLength)
            If i + substringLength < inputString.Length Then
                messageText += vbCrLf ' Insert a newline character if there are more characters remaining
            End If
        Next

        Dim newMessage As New Tuple(Of Integer, Integer, String, String, String)(room, dealId, user_role, messageText, timeStamp)
        ' Add the new message to the messages list
        messages.Add(newMessage)
        ' Optionally, you can clear the TextBox after sending the message
        sendTextBox.Text = ""
        ' Print messages between users
        PrintMessagesBetweenUsers(room)
    End Sub

    Private Sub PrintMessagesBetweenUsers(roomId As Integer)
        ' Clear existing messages on the chat_list panel
        For i As Integer = chat.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = chat.Controls(i)
            ' Check if the control is not lblHeader
            If ctrl.Name <> "lblHeader" Then
                ' Remove the control from the chat_list panel
                chat.Controls.RemoveAt(i)
            End If
        Next

        ' Filter messages for the given roomId
        Dim messagesInRoom = messages.Where(Function(msg) msg.Item1 = roomId)

        ' Sort messages by timestamp
        Dim sortedMessages = messagesInRoom.OrderBy(Function(msg) DateTime.Parse(msg.Item5))

        ' Y position for labels
        Dim yPos As Integer = 55

        ' Iterate through messages
        For Each msg In sortedMessages
            Dim room As Integer = msg.Item1
            Dim deal As Integer = msg.Item2
            Dim senderType As String = msg.Item3
            Dim messageText As String = msg.Item4
            Dim timeStamp As String = msg.Item5

            ' Create a label for the message
            Dim messageLabel As New Label()
            messageLabel.AutoSize = True

            'messageLabel.MaximumSize = New Size(chat_list.Width * 3 \ 4, 25)
            messageLabel.Text = messageText '& " (" & timeStamp & ")"
            messageLabel.Font = New Font(messageLabel.Font.FontFamily, 10)
            messageLabel.Padding = New Padding(5)
            messageLabel.BackColor = ColorTranslator.FromHtml("#D9D9D9")
            Dim textHeight As Integer = TextRenderer.MeasureText(messageText, messageLabel.Font).Height
            Dim labelHeight As Integer = messageLabel.Height

            messageLabel.Padding = New Padding(0, (labelHeight - textHeight) \ 2, 0, 0)

            ' Assuming label1 is the name of your label control
            messageLabel.TextAlign = ContentAlignment.MiddleRight

            ' Align labels based on sender
            If senderType = "provider" Then
                messageLabel.Location = New Point(10, yPos)
            ElseIf senderType = "customer" Then
                messageLabel.Anchor = AnchorStyles.Right
                messageLabel.Location = New Point(chat.Width - messageLabel.PreferredWidth - 10, yPos)

            End If

            ' Set label position
            yPos += messageLabel.Height + 10

            ' Add label to the chat_list panel
            chat.Controls.Add(messageLabel)
        Next
    End Sub
End Class