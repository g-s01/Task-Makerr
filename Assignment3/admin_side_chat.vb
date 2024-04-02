Public Class admin_side_chat
    ' user name, user type , support room, user id 
    Dim support_rooms As New List(Of Tuple(Of String, String, Integer, Integer))
    ' room_id,sender_type msg_content send timestamp
    Dim support_msgs As New List(Of Tuple(Of Integer, String, String, String))
    Dim user_role = "admin"
    Dim roomId = -1
    Dim rooms_type = "customer"

    Private Sub PopulateRooms()
        ' Clear existing buttons
        room_list.Controls.Clear()

        Dim yPos As Integer = 10 ' Initial y position for buttons

        For Each item As Tuple(Of String, String, Integer, Integer) In support_rooms
            If item.Item2 = rooms_type Then
                Dim newButton As New Button()
                newButton.Name = "btn" & item.Item1 ' Set button name
                newButton.Text = item.Item1 ' Set button text
                newButton.TextAlign = ContentAlignment.MiddleCenter
                newButton.Width = room_list.Width
                newButton.Height = 35 ' Set button height
                newButton.FlatStyle = FlatStyle.Flat ' Use flat style for rounded corners
                newButton.BackColor = Color.FromArgb(220, 189, 232) ' Set background color to pink
                newButton.FlatAppearance.BorderSize = 0 ' Remove border
                newButton.Font = New Font(newButton.Font.FontFamily, 12)
                newButton.ImageAlign = ContentAlignment.MiddleLeft ' Set image alignment
                newButton.TextImageRelation = TextImageRelation.ImageBeforeText ' Position image before text
                ' Resize the image to match the button height
                Dim scaledImagenew As Image = New Bitmap(My.Resources.prov, New Size(35, 35))
                newButton.Image = scaledImagenew
                newButton.Region = New Drawing.Region(New Drawing.Rectangle(0, 0, newButton.Width, newButton.Height)) ' Make corners rounded
                newButton.Location = New Point(10, yPos) ' Set button position
                AddHandler newButton.Click, AddressOf Button_Click ' Add click event handler
                room_list.Controls.Add(newButton) ' Add button to panel
                yPos += 37 ' Increment y position for next button
            End If
        Next
    End Sub




    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        support_rooms.Add(New Tuple(Of String, String, Integer, Integer)("Apple", "provider", 1, 1))
        support_rooms.Add(New Tuple(Of String, String, Integer, Integer)("Banana", "customer", 2, 1))
        support_rooms.Add(New Tuple(Of String, String, Integer, Integer)("Orange", "provider", 3, 3))
        support_rooms.Add(New Tuple(Of String, String, Integer, Integer)("Grapes", "customer", 4, 4))

        support_msgs.Clear()
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Hey there!", "2024-03-30 10:00:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(2, "admin", "How are you?", "2024-03-30 10:05:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(3, "user", "What's up?", "2024-03-30 10:10:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(4, "admin", "Good morning!", "2024-03-30 10:15:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "How's it going?", "2024-03-30 10:20:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(2, "user", "Want to hang out later?", "2024-03-30 10:25:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(3, "admin", "Sure, let's meet at 4!", "2024-03-30 10:30:00"))
        support_msgs.Add(New Tuple(Of Integer, String, String, String)(4, "user", "Sounds good!", "2024-03-30 10:35:00"))

        PopulateRooms()
        chat.Visible = False
        Panel2.Visible = False
    End Sub

    Private Sub userButton_Click(sender As Object, e As EventArgs) Handles userButton.Click
        rooms_type = "customer"
        providerButton.BackColor = SystemColors.Control
        userButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        PopulateRooms()
        chat.Visible = False
        Panel2.Visible = False
    End Sub

    Private Sub providerButton_Click(sender As Object, e As EventArgs) Handles providerButton.Click
        rooms_type = "provider"
        userButton.BackColor = SystemColors.Control
        providerButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        PopulateRooms()
        chat.Visible = False
        Panel2.Visible = False
    End Sub


    Private Sub Button_Click(sender As Object, e As EventArgs)
        ' Handle button click event
        chat.Visible = True

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

        Dim room As Integer

        For Each pair As Tuple(Of String, String, Integer, Integer) In support_rooms
            If pair.Item1 = clickedButton.Text Then

                room = pair.Item3

                Exit For ' Exit loop if the match is found
            End If
        Next

        PrintMessages(room)
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

        ' Iterate through support_msgs
        For Each msg In sortedMessages
            Dim senderType As String = msg.Item2
            Dim messageText As String = msg.Item3

            ' Create a label for the message
            Dim messageLabel As New Label()
            messageLabel.AutoSize = True
            messageLabel.Text = messageText '& " (" & timeStamp & ")"
            messageLabel.Font = New Font(messageLabel.Font.FontFamily, 10)
            messageLabel.Padding = New Padding(5)
            messageLabel.BackColor = ColorTranslator.FromHtml("#D9D9D9")

            ' Assuming label1 is the name of your label control
            messageLabel.TextAlign = ContentAlignment.MiddleLeft

            ' Align labels based on sender
            If senderType <> user_role Then
                messageLabel.Location = New Point(10, yPos)
            Else
                messageLabel.Anchor = AnchorStyles.Right
                messageLabel.Location = New Point(chat.Width - messageLabel.PreferredWidth - 10, yPos)
            End If

            ' Set label position
            yPos += messageLabel.Height + 10

            ' Add label to the chat_list panel
            chat.Controls.Add(messageLabel)
        Next
    End Sub


    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendBtn.Click


        Dim timeStamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim room As Integer
        For Each pair As Tuple(Of String, String, Integer, Integer) In support_rooms
            If pair.Item1 = senderName.Text Then
                room = pair.Item3
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

        Dim newMessage As New Tuple(Of Integer, String, String, String)(room, user_role, messageText, timeStamp)
        ' Add the new message to the messages list
        support_msgs.Add(newMessage)
        ' Optionally, you can clear the TextBox after sending the message
        sendTextBox.Text = ""
        ' Print messages between users
        PrintMessages(room)
    End Sub

End Class