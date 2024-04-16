Imports System.Globalization
Imports Azure.Messaging
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.Data.SqlClient

Public Class admin_side_chat
    ' user name, user type , support room, user id 
    Dim support_rooms As New List(Of Tuple(Of String, String, Integer, Integer))
    ' room_id,sender_type msg_content send timestamp
    Dim support_msgs As New List(Of Tuple(Of Integer, String, String, String))
    Dim user_role = "admin"
    Dim roomId = -1
    Dim rooms_type = "customer"
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    Private WithEvents messageTimer As New Timer()

    Private Sub PopulateRooms(Optional ByVal filterType As String = Nothing)
        ' Clear existing buttons
        room_list.Controls.Clear()

        Dim yPos As Integer = 10 ' Initial y position for buttons

        Dim roomsToDisplay As IEnumerable(Of Tuple(Of String, String, Integer, Integer)) = support_rooms

        ' Filter rooms based on filterType parameter if provided
        If Not String.IsNullOrEmpty(filterType) Then
            roomsToDisplay = support_rooms.Where(Function(room) room.Item1.ToLower().Contains(filterType.ToLower())).ToList()
        End If

        For Each item As Tuple(Of String, String, Integer, Integer) In roomsToDisplay
            If item.Item2 = rooms_type Then ' Check if room type matches the desired type
                Dim newButton As New Button()
                newButton.Name = "btn" & item.Item1 ' Set button name
                newButton.Text = item.Item1 ' Set button text
                newButton.TextAlign = ContentAlignment.MiddleLeft
                newButton.Width = room_list.Width - 25
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
                room_list.Controls.Add(newButton) ' Add button to panel
                yPos += 37 ' Increment y position for next button
            End If
        Next
    End Sub




    Private Function LoadRoomsFromDatabase() As Boolean
        Dim prevLength As Integer = support_rooms.Count
        Dim query As String = "SELECT username, user_type, support_room_id, user_id FROM support_room"
        support_rooms.Clear()
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create a SqlCommand object
            Using command As New SqlCommand(query, connection)
                ' Execute the query and get a SqlDataReader
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Loop through the results and populate the support_rooms list
                    While reader.Read()
                        ' Read the values from the current row
                        Dim username As String = reader.GetString(0)
                        Dim user_type As String = reader.GetString(1)
                        Dim support_room_id As Integer = reader.GetInt32(2)
                        Dim user_id As Integer = reader.GetInt32(3)

                        ' Add the values to the support_rooms list as a Tuple
                        support_rooms.Add(New Tuple(Of String, String, Integer, Integer)(username, user_type, support_room_id, user_id))
                    End While
                End Using
            End Using
        End Using
        Return (prevLength <> support_rooms.Count)
    End Function


    Private Function LoadMessagesFromDatabase() As Boolean
        Dim prevLength As Integer = support_msgs.Count
        support_msgs.Clear()
        Dim mess_query As String = "SELECT support_room_id, sender_type, message_content, sent_timestamp FROM support_msgs"
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create a SqlCommand object
            Using command As New SqlCommand(mess_query, connection)
                ' Execute the query and get a SqlDataReader
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Loop through the results and populate the support_msgs list
                    While reader.Read()
                        ' Read the values from the current row
                        Dim support_room_id As Integer = reader.GetInt32(0)
                        Dim sender_type As String = reader.GetString(1)
                        Dim message_content As String = reader.GetString(2)
                        Dim sent_timestamp As DateTime = reader.GetDateTime(3)
                        Dim sent_timestamp_str As String = sent_timestamp.ToString("yyyy-MM-dd HH:mm:ss") ' Convert sent_timestamp to the desired format

                        ' Add the values to the support_msgs list as a Tuple
                        support_msgs.Add(New Tuple(Of Integer, String, String, String)(support_room_id, sender_type, message_content, sent_timestamp_str))
                    End While
                End Using
            End Using
        End Using
        Return (prevLength <> support_msgs.Count)
    End Function

    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        messageTimer.Interval = 10000
        AddHandler messageTimer.Tick, AddressOf MessageTimer_Tick

        LoadRoomsFromDatabase()
        PopulateRooms()
        LoadMessagesFromDatabase()
        providerButton.BackColor = SystemColors.Control
        userButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        chat.Visible = False
        Panel2.Visible = False
        sendBtn.Visible = False
        sendTextBox.Visible = False
        messageTimer.Start()
    End Sub

    Private Sub MainForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        ' Stop the timer when the form is closed
        messageTimer.Stop()
    End Sub
    ' Event handler for the tick event of the timer
    Private Sub MessageTimer_Tick(sender As Object, e As EventArgs)
        ' Check if the form is visible
        Dim messages_count_pv As Integer = 0
        Dim after_fetch As Integer = 0
        If Me.Visible Then
            ' Reload and print messages every 30 seconds
            If (LoadRoomsFromDatabase()) Then
                PopulateRooms()
            End If
            If roomId <> -1 Then
                For Each msg As Tuple(Of Integer, String, String, String) In support_msgs
                    If msg.Item1 = roomId Then
                        messages_count_pv += 1
                    End If
                Next
            End If
            LoadMessagesFromDatabase()
            If roomId <> -1 Then
                For Each msg As Tuple(Of Integer, String, String, String) In support_msgs
                    If msg.Item1 = roomId Then
                        after_fetch += 1
                    End If
                Next
            End If

            If roomId <> -1 AndAlso messages_count_pv <> after_fetch Then
                PrintMessages(roomId)
            End If
        End If
    End Sub



    Private Sub userButton_Click(sender As Object, e As EventArgs) Handles userButton.Click
        rooms_type = "customer"
        providerButton.BackColor = SystemColors.Control
        userButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        PopulateRooms()
        chat.Visible = False
        Panel2.Visible = False
        sendBtn.Visible = False
        sendTextBox.Visible = False
    End Sub

    Private Sub sendTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles sendTextBox.KeyDown
        If e.KeyCode = Keys.Enter And sendTextBox.Text <> "" Then
            ' Call the sendButton_Click event handler
            sendButton_Click(sender, e)
            ' Prevent the key press from being handled by the TextBox
            e.SuppressKeyPress = True
        End If
    End Sub

    Private Sub providerButton_Click(sender As Object, e As EventArgs) Handles providerButton.Click
        rooms_type = "provider"
        userButton.BackColor = SystemColors.Control
        providerButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        PopulateRooms()

        chat.Visible = False
        Panel2.Visible = False
        sendBtn.Visible = False
        sendTextBox.Visible = False
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
        For Each ctrl As Control In room_list.Controls
            If TypeOf ctrl Is Button AndAlso ctrl IsNot clickedButton Then
                Dim otherButton As Button = CType(ctrl, Button)
                otherButton.BackColor = Color.FromArgb(220, 189, 232) ' Original color
            End If
        Next



        For Each pair As Tuple(Of String, String, Integer, Integer) In support_rooms
            If pair.Item1 = clickedButton.Text Then

                roomId = pair.Item3

                Exit For ' Exit loop if the match is found
            End If
        Next

        PrintMessages(roomId)
        chat.Visible = True
        Panel2.Visible = True
    End Sub

    Private Sub PrintMessages(roomId As Integer)
        ' Clear existing support_msgs on the chat_list panel
        chat.Controls.Clear()

        ' Filter support_msgs for the given roomId
        Dim messagesInRoom = support_msgs.Where(Function(msg) msg.Item1 = roomId)

        ' Sort support_msgs by timestamp
        Dim sortedMessages = messagesInRoom.OrderBy(Function(msg) DateTime.Parse(msg.Item4))

        ' Y position for labels
        Dim yPos As Integer = 55

        Dim lastDisplayedDate As Date = DateTime.MinValue

        Dim dateLabelPrinted As Boolean = False


        ' Iterate through support_msgs
        For Each msg In sortedMessages
            Dim senderType As String = msg.Item2
            Dim messageText As String = msg.Item3
            Dim timeStamp As String = DateTime.ParseExact(msg.Item4, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm")
            Dim timeStamp1 As Date = DateTime.ParseExact(msg.Item4, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)
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
            messageLabel.Text = messageText '& " (" & timeStamp & ")"
            messageLabel.Font = New Font(messageLabel.Font.FontFamily, 10)
            messageLabel.Padding = New Padding(5)
            messageLabel.BackColor = ColorTranslator.FromHtml("#D9D9D9")
            messageLabel.MaximumSize = New Size(chat.Width - 220, 0)
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
                messageLabel.Left = chat.Width - messageLabel.PreferredWidth - 10 - 15
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
            chat.Controls.Add(messageLabel)
            chat.Controls.Add(label2)

        Next
        ' Ensure the panel scrolls to the bottom to show the latest message
        chat.AutoScrollPosition = New Point(0, chat.AutoScrollPosition.Y + yPos)

    End Sub


    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendBtn.Click


        Dim timeStamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim maxLength As Integer = 30 ' Set the maximum length before inserting a newline
        Dim inputString As String = sendTextBox.Text
        Dim messageText As String = ""

        If inputString <> "" Then
            For i As Integer = 0 To inputString.Length - 1 Step maxLength
                Dim substringLength As Integer = Math.Min(maxLength, inputString.Length - i)
                messageText += inputString.Substring(i, substringLength)
                If i + substringLength < inputString.Length Then
                    messageText += vbCrLf ' Insert a newline character if there are more characters remaining
                End If
            Next

            Dim newMessage As New Tuple(Of Integer, String, String, String)(roomId, user_role, messageText, timeStamp)
            ' Add the new message to the messages list
            support_msgs.Add(newMessage)

            Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
            Dim query As String = "
            INSERT INTO support_msgs (support_msgs.support_room_id, sender_type, message_content,sent_timestamp)
            VALUES (@SupportRoomId, @SenderType, @MessageContent,@timeStamp);
            SELECT SCOPE_IDENTITY();
            "

            ' Create a SqlConnection object
            Using connection As New SqlConnection(connectionString)
                ' Open the connection
                connection.Open()

                ' Create a SqlCommand object
                Using command As New SqlCommand(query, connection)
                    ' Set the parameters for the new message
                    command.Parameters.AddWithValue("@SupportRoomId", roomId)
                    command.Parameters.AddWithValue("@SenderType", user_role)
                    command.Parameters.AddWithValue("@MessageContent", messageText)
                    command.Parameters.AddWithValue("@timeStamp", timeStamp)

                    ' Execute the INSERT command and retrieve the generated message_id
                    Dim messageId As Integer = Convert.ToInt32(command.ExecuteScalar())

                    ' Now you can use messageId as needed
                    'Console.WriteLine("Generated Message ID: " & messageId)
                End Using
            End Using
            ' Optionally, you can clear the TextBox after sending the message
            sendTextBox.Text = ""
            ' Print messages between users
            PrintMessages(roomId)

        Else
            MessageBox.Show("Enter some text")

        End If
    End Sub

    Private Sub SearchTextBox_TextChanged(sender As Object, e As EventArgs) Handles SearchTextBox.TextChanged
        Dim searchText As String = SearchTextBox.Text.ToLower().TrimEnd() ' Convert search text to lower case for case-insensitive comparison and trim trailing spaces
        'ext is empty, call PopulateRooms without any filter
        PopulateRooms(searchText)
    End Sub

End Class