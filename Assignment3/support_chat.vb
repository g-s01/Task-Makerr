﻿Imports System.Globalization
Imports Azure.Messaging
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.Data.SqlClient

Public Class support_chat
    Dim user_role As String = "user"
    Dim userId As Integer = 1
    Dim dealId As Integer = -1
    Dim roomId As Integer = 1
    ' room,sender_type,msg_content,sent_timestand
    'Dim messages As New List(Of Tuple(Of Integer, String, String, String))()
    Dim supportmessages As New List(Of Tuple(Of Integer, String, String, String))()


    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        'messages.Clear()
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Hey there!", "2024-03-30 10:00:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "How are you?", "2024-03-30 10:05:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "What's up?", "2024-03-30 10:10:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Good morning!", "2024-03-30 10:15:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "How's it going?", "2024-03-30 10:20:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Want to hang out later?", "2024-03-30 10:25:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "Sounds good!", "2024-03-30 10:35:00"))
        supportmessages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "Sure, let's meet at 4!", "2024-03-30 10:30:00"))

        ' Define your connection string
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

        ' Define your SQL query to select messages for a specific support_room_id
        Dim query As String = "SELECT message_id, sender_type, message_content, sent_timestamp FROM support_msgs WHERE support_room_id = @SupportRoomId"

        ' Create a SqlConnection object
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create a SqlCommand object
            Using command As New SqlCommand(query, connection)
                ' Set the parameter for the support_room_id
                command.Parameters.AddWithValue("@SupportRoomId", Support_room_id)

                ' Execute the query and get a SqlDataReader
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Loop through the results and populate the supportmessages list
                    While reader.Read()
                        ' Read the values from the current row
                        Dim messageId As Integer = reader.GetInt32(0)
                        Dim senderType As String = reader.GetString(1)
                        Dim messageContent As String = reader.GetString(2)
                        'Dim sentTimestamp As String = reader.GetDateTime(3).ToString() ' Adjust as per your DateTime format
                        Dim formattedTimestamp As DateTime = reader.GetDateTime(3)

                        ' Convert the DateTime to the desired string format "yyyy-MM-dd HH:mm:ss"
                        Dim sentTimestamp As String = formattedTimestamp.ToString("yyyy-MM-dd HH:mm:ss")
                        'MessageBox.Show("sent time" & sentTimestamp)

                        ' Add the values to the supportmessages list as a Tuple
                        supportmessages.Add(New Tuple(Of Integer, String, String, String)(messageId, senderType, messageContent, sentTimestamp))
                    End While
                End Using
            End Using
        End Using

        PrintMessages()
    End Sub

    Private WithEvents sendTextBox As TextBox

    Private Sub sendTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles inputTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Call the sendButton_Click event handler
            sendButton_Click(sender, e)
            ' Prevent the key press from being handled by the TextBox
            e.SuppressKeyPress = True
        End If
    End Sub


    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click


        ' Get the current timestamp
        Dim timeStamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim maxLength As Integer = 70 ' Set the maximum length before inserting a newline
        Dim inputString As String = inputTextBox.Text
        Dim messageText As String = ""

        For i As Integer = 0 To inputString.Length - 1 Step maxLength
            Dim substringLength As Integer = Math.Min(maxLength, inputString.Length - i)
            messageText += inputString.Substring(i, substringLength)
            If i + substringLength < inputString.Length Then
                messageText += vbCrLf ' Insert a newline character if there are more characters remaining
            End If
        Next

        Dim newMessage As New Tuple(Of Integer, String, String, String)(roomId, user_role, messageText, timeStamp)

        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

        Dim query As String = "
            INSERT INTO support_msgs (support_room_id, sender_type, message_content, sent_timestamp)
            VALUES (@SupportRoomId, @SenderType, @MessageContent, @SentTimestamp);
            SELECT SCOPE_IDENTITY();
            "

        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create a SqlCommand object
            Using command As New SqlCommand(query, connection)
                ' Set the parameters for the new message
                command.Parameters.AddWithValue("@SupportRoomId", Support_room_id)
                command.Parameters.AddWithValue("@SenderType", user_role)
                command.Parameters.AddWithValue("@MessageContent", messageText)
                command.Parameters.AddWithValue("@SentTimestamp", timeStamp)

                ' Execute the INSERT command and retrieve the generated message_id
                Dim messageId As Integer = Convert.ToInt32(command.ExecuteScalar())

                ' Now you can use the messageId as needed
                'Console.WriteLine("Generated Message ID: " & messageId)
            End Using
        End Using

        ' Add the new message to the messages list
        supportmessages.Add(newMessage)


        ' Optionally, you can clear the TextBox after sending the message
        inputTextBox.Text = ""
        ' Print messages between users
        PrintMessages()
    End Sub

    Private Sub PrintMessages()
        ' Clear existing messages on the chat_list panel
        For i As Integer = Support.Controls.Count - 1 To 0 Step -1
            Support.Controls.RemoveAt(i)
        Next
        ' Sort messages by timestamp
        Dim sortedMessages = supportmessages.OrderBy(Function(msg) DateTime.Parse(msg.Item4))

        ' Y position for labels
        Dim yPos As Integer = 55

        ' Iterate through messages
        For Each msg In sortedMessages
            Dim room As Integer = msg.Item1
            Dim senderType As String = msg.Item2
            Dim messageText As String = msg.Item3
            'Dim timeStamp As String = DateTime.ParseExact(msg.Item4, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm")
            ' Convert the sentTimestamp string to DateTime using ParseExact
            Dim sentTimestampDateTime As DateTime = DateTime.ParseExact(msg.Item4, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture)

            ' Convert the DateTime to the desired string format "hh:mm"
            Dim timeStamp As String = sentTimestampDateTime.ToString("hh:mm")


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
                messageLabel.Left = Chat.Width - messageLabel.PreferredWidth - 10 - 5
                label2.Left = messageLabel.Left + messageLabel.PreferredWidth - 35 + messageLabel.Width - 88
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
            Support.Controls.Add(messageLabel)
            Support.Controls.Add(label2)

        Next
        ' Ensure the panel scrolls to the bottom to show the latest message
        Support.AutoScrollPosition = New Point(0, Support.AutoScrollPosition.Y + yPos)
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub Support_Paint(sender As Object, e As PaintEventArgs) Handles Support.Paint

    End Sub

    Private Sub inputTextBox_TextChanged(sender As Object, e As EventArgs) Handles inputTextBox.TextChanged

    End Sub
End Class
