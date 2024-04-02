Public Class appointmentChat
    Dim roomId As Integer = 1
    Dim dealId As Integer = 1
    Dim user_role As String = "customer"

    Dim room As Tuple(Of String, Integer, Integer) ' providername, chat_room_id, provider_id
    Dim messages As New List(Of Tuple(Of Integer, Integer, String, String, String))()

    Private Sub appointmentChat_Load(sender As Object, e As EventArgs) Handles Me.Load
        room = New Tuple(Of String, Integer, Integer)("Apple", 1, 0)
        messages.Clear()
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(1, -1, "customer", "Hey there!", "2024-03-30 10:00:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(2, -1, "provider", "How are you?", "2024-03-30 10:05:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(3, -1, "provider", "What's up?", "2024-03-30 10:10:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(4, -1, "customer", "Good morning!", "2024-03-30 10:15:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(1, -1, "provider", "How's it going?", "2024-03-30 10:20:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(2, -1, "provider", "Want to hang out later?", "2024-03-30 10:25:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(3, -1, "customer", "Sure, let's meet at 4!", "2024-03-30 10:30:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(4, -1, "provider", "Sounds good!", "2024-03-30 10:35:00"))
        PrintMessages()
    End Sub
    Private Sub PrintMessages()
        Chat.Controls.Clear()
        Dim sortedMessages = messages.OrderBy(Function(msg) DateTime.Parse(msg.Item5))

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
            If senderType <> user_role Then
                messageLabel.Location = New Point(10, yPos)
            Else
                messageLabel.Anchor = AnchorStyles.Right
                messageLabel.Location = New Point(Chat.Width - messageLabel.PreferredWidth - 10, yPos)

            End If

            ' Set label position
            yPos += messageLabel.Height + 10

            ' Add label to the chat_list panel
            Chat.Controls.Add(messageLabel)
        Next
    End Sub
    Private Sub sendButton_Click(sender As Object, e As EventArgs) Handles sendButton.Click
        ' Get the current timestamp
        Dim timeStamp = Date.Now.ToString("yyyy-MM-dd HH:mm:ss")
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
        messages.Add(newMessage)
        ' Optionally, you can clear the TextBox after sending the message
        inputTextBox.Text = ""
        ' Print messages between users
        PrintMessages()
    End Sub

End Class
