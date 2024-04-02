Public Class support_chat
    Dim user_role As String = "user"
    Dim userId As Integer = 1
    Dim dealId As Integer = -1
    Dim roomId As Integer = 1
    ' room,sender_type,msg_content,sent_timestand
    Dim messages As New List(Of Tuple(Of Integer, String, String, String))()

    Private Sub user_chats_Load(sender As Object, e As EventArgs) Handles Me.Load
        messages.Clear()
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Hey there!", "2024-03-30 10:00:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "How are you?", "2024-03-30 10:05:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "What's up?", "2024-03-30 10:10:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Good morning!", "2024-03-30 10:15:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "How's it going?", "2024-03-30 10:20:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "user", "Want to hang out later?", "2024-03-30 10:25:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "Sounds good!", "2024-03-30 10:35:00"))
        messages.Add(New Tuple(Of Integer, String, String, String)(1, "admin", "Sure, let's meet at 4!", "2024-03-30 10:30:00"))
        PrintMessages()
    End Sub


    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click


        ' Get the current timestamp
        Dim timeStamp As String = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
        Dim maxLength As Integer = 30 ' Set the maximum length before inserting a newline
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
        ' Add the new message to the messages list
        messages.Add(newMessage)
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
        Dim sortedMessages = messages.OrderBy(Function(msg) DateTime.Parse(msg.Item4))

        ' Y position for labels
        Dim yPos As Integer = 55

        ' Iterate through messages
        For Each msg In sortedMessages
            Dim room As Integer = msg.Item1
            Dim senderType As String = msg.Item2
            Dim messageText As String = msg.Item3
            Dim timeStamp As String = msg.Item4

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
            If senderType <> user_role Then
                messageLabel.Location = New Point(10, yPos)
            Else
                messageLabel.Anchor = AnchorStyles.Right
                messageLabel.Location = New Point(Support.Width - messageLabel.PreferredWidth - 10, yPos)
            End If

            ' Set label position
            yPos += messageLabel.Height + 10

            ' Add label to the chat_list panel
            Support.Controls.Add(messageLabel)
        Next
    End Sub

End Class
