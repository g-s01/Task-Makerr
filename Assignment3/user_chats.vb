Imports System.Collections.Generic
Imports System.Configuration
Imports System.Runtime.InteropServices.JavaScript.JSType
Imports Azure.Messaging
Imports Microsoft.Data.SqlClient
'Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class user_chats

    Dim listchat As New List(Of Tuple(Of String, Integer, Integer))() ' providername, chat_room_id, provider_id
    Dim messages As New List(Of List(Of String))()
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString


    Dim user_role As String = "customer"
    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        listchat.Add(New Tuple(Of String, Integer, Integer)("Apple", 1, 0))
        listchat.Add(New Tuple(Of String, Integer, Integer)("Banana", 2, 0))
        listchat.Add(New Tuple(Of String, Integer, Integer)("Orange", 3, 0))
        listchat.Add(New Tuple(Of String, Integer, Integer)("Grapes", 4, 0))

        ' Add items to listChat using sql query

        Dim query As String = "SELECT chat_room_id,providername,provider_id FROM chat_room WHERE user_id = @UserId"
        Debug.WriteLine(0)

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserId", 2)
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
                            listchat.Add(New Tuple(Of String, Integer, Integer)(providername, chat_room_id, provider_id))

                        End While
                    End If

                    reader.Close()
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using


        get_messages()

        Dim yPos As Integer = 10 ' Initial y position for buttons
        For Each item As Tuple(Of String, Integer, Integer) In listchat
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
            newButton.TextImageRelation = TextImageRelation.ImageBeforeText ' Position image before text

            ' Resize the image to match the button height
            Dim scaledImagenew As Image = New Bitmap(My.Resources.prov, New Size(35, 35))
            newButton.Image = scaledImagenew
            newButton.Region = New Drawing.Region(New Drawing.Rectangle(0, 0, newButton.Width, newButton.Height)) ' Make corners rounded
            newButton.Location = New Point(10, yPos) ' Set button position
            AddHandler newButton.Click, AddressOf Button_Click ' Add click event handler
            chat_list.Controls.Add(newButton) ' Add button to panel
            yPos += 37 ' Increment y position for next button
        Next

        ' Create and configure the Label
        Dim newLabel As New Label()
        newLabel.Name = "lblHeader"
        newLabel.Text = "Header Text"
        newLabel.TextAlign = ContentAlignment.MiddleCenter
        newLabel.Width = chat_list.Width
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
        Dim textBox1 As New TextBox()
        textBox1.Name = "textBox1"
        textBox1.Size = New Size(145, 30)

        ' Calculate the Y position for the TextBox
        Dim textBoxYPosition As Integer = chat.Height - textBox1.Height - 10 ' Adjust 10 for padding

        ' Set the location of the TextBox
        textBox1.Location = New Point(10, textBoxYPosition)

        ' Create and configure the Button
        Dim button1 As New Button()
        button1.Name = "button1"
        button1.Text = "Send"
        button1.Size = New Size(70, 30)

        ' Calculate the X position for the Button
        Dim buttonXPosition As Integer = chat.Width - button1.Width - 10 ' Adjust 10 for padding

        ' Set the location of the Button
        button1.Location = New Point(buttonXPosition, textBoxYPosition)
        AddHandler button1.Click, AddressOf sendButton_Click ' Add click event handler


        ' Add the controls to the panel
        chat.Controls.Add(textBox1)
        chat.Controls.Add(button1)
        chat.AutoScroll = True
        chat.Visible = False

        'chat.Visible = False
    End Sub

    Private Sub get_messages()

        messages.Clear()


        messages.Add(New List(Of String)() From {1, -1, "customer", "Hey there!", "2024-03-30 10:00:00"})
        messages.Add(New List(Of String)() From {2, -1, "provider", "How are you?", "2024-03-30 10:05:00"})
        messages.Add(New List(Of String)() From {3, -1, "provider", "What's up?", "2024-03-30 10:10:00"})
        messages.Add(New List(Of String)() From {4, -1, "customer", "Good morning!", "2024-03-30 10:15:00"})
        messages.Add(New List(Of String)() From {1, -1, "provider", "How's it going?", "2024-03-30 10:20:00"})
        messages.Add(New List(Of String)() From {2, -1, "provider", "Want to hang out later?", "2024-03-30 10:25:00"})
        messages.Add(New List(Of String)() From {3, -1, "customer", "Sure, let's meet at 4!", "2024-03-30 10:30:00"})
        messages.Add(New List(Of String)() From {4, -1, "provider", "Sounds good!", "2024-03-30 10:35:00"})

        Dim query As String = "SELECT m.* FROM chat_room cr JOIN messages m ON cr.chat_room_id = m.chat_room_id WHERE cr.user_id = @UserId"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserId", 2)

                Dim message_content As String
                Dim sender_type As String
                Dim chat_room_id As String
                Dim timestamp As String


                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    If reader.HasRows Then
                        ' Loop through the rows
                        While reader.Read()

                            ' Access columns by name or index
                            chat_room_id = reader.GetInt32(reader.GetOrdinal("chat_room_id")).ToString()
                            message_content = reader.GetString(reader.GetOrdinal("message_content"))
                            sender_type = reader.GetString(reader.GetOrdinal("sender_type"))
                            timestamp = reader.GetDateTime(reader.GetOrdinal("sent_timestamp"))
                            messages.Add(New List(Of String)() From {chat_room_id, -1, sender_type, message_content, timestamp})
                        End While

                    End If

                    reader.Close()
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

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

        For Each pair As Tuple(Of String, Integer, Integer) In listchat
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

    Private Sub sendButton_Click(sender As Object, e As EventArgs)
        Dim messageText As String = chat.Controls("textBox1").Text ' Assuming TextBox1 is the name of the TextBox

        ' Get the receiver name from the label text within the chat panel
        Dim receiverName As String = chat.Controls("lblHeader").Text ' Assuming Label1 contains the receiver name

        ' Get the current timestamp
        Dim timeStamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")

        Dim room As Integer

        For Each pair As Tuple(Of String, Integer, Integer) In listchat
            ' Check if the receiver matches the first item in the tuple
            If pair.Item1 = receiverName Then
                ' Fetch the second item (number) in the tuple
                room = pair.Item2
                ' Do something with the number...
                Exit For ' Exit loop if the match is found
            End If
        Next

        ' Create a new list containing sender, receiver, message, and timestamp
        Dim newMessage As New List(Of String)() From {room, -1, user_role, messageText, timeStamp}

        ' Add the new message to the messages list

        Dim query As String = "INSERT INTO messages (chat_room_id, deal_id, sender_type, message_content, sent_timestamp) VALUES (@ChatRoomId, @DealId, @SenderType, @MessageContent, @SentTimestamp)"


        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ChatRoomId", room)
                command.Parameters.AddWithValue("@DealId", -1)
                command.Parameters.AddWithValue("@SenderType", user_role)
                command.Parameters.AddWithValue("@MessageContent", messageText)
                command.Parameters.AddWithValue("@SentTimestamp", timeStamp)



                Try
                    connection.Open()
                    ' Execute the insert query
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()

                    If rowsAffected <= 0 Then
                        MessageBox.Show("Error " & "No rows were inserted")
                    End If
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        ' Optionally, you can clear the TextBox after sending the message
        chat.Controls("textBox1").Text = ""


        messages.Add(newMessage)
        PrintMessagesBetweenUsers(room)

    End Sub

    Private Sub PrintMessagesBetweenUsers(roomId As Integer)
        ' Clear existing messages on the chat panel
        For i As Integer = chat.Controls.Count - 1 To 0 Step -1
            Dim ctrl As Control = chat.Controls(i)
            ' Check if the control is not lblHeader, textBox1, or sendButton
            If ctrl.Name <> "lblHeader" AndAlso ctrl.Name <> "textBox1" AndAlso ctrl.Name <> "button1" Then
                ' Remove the control from the chat panel
                chat.Controls.RemoveAt(i)
            End If
        Next

        ' Sort messages by timestamp
        Dim sortedMessages = messages.OrderBy(Function(msg) DateTime.Parse(msg(4)))

        ' Y position for labels
        Dim yPos As Integer = 55

        ' Iterate through messages
        For Each msg In sortedMessages
            Dim room As Integer = msg(0)
            Dim deal As Integer = msg(1)
            Dim senderType As String = msg(2)
            Dim messageText As String = msg(3)
            Dim timeStamp As String = msg(4)

            ' Check if the message is between the desired users
            If (room = roomId) Then
                ' Create a label for the message
                Dim messageLabel As New Label()
                messageLabel.AutoSize = True
                messageLabel.Text = messageText '& " (" & timeStamp & ")"
                messageLabel.Font = New Font(messageLabel.Font.FontFamily, 10)
                messageLabel.Padding = New Padding(5)

                'MessageBox.Show("height :" & messageLabel.Height & "", "Message Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)


                ' Align labels based on sender
                If senderType = "provider" Then
                    messageLabel.Location = New Point(10, yPos)
                ElseIf senderType = "customer" Then
                    messageLabel.Location = New Point(chat.Width - messageLabel.Width - 10, yPos)
                End If

                ' Set label position
                'messageLabel.Location = New Point(10, yPos)
                yPos += messageLabel.Height + 10

                ' Add label to the chat panel
                chat.Controls.Add(messageLabel)
            End If
        Next

    End Sub

End Class