Imports Microsoft.CodeAnalysis.Text

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
            Dim textSize = TextRenderer.MeasureText(messageLabel.Text, messageLabel.Font, messageLabel.MaximumSize, TextFormatFlags.WordBreak)

            Dim textHeight As Integer = textSize.Height
            Dim labelHeight As Integer = messageLabel.Height

            messageLabel.Padding = New Padding(0, (labelHeight - textHeight) \ 2, 0, 0)

            ' Assuming label1 is the name of your label control
            messageLabel.TextAlign = ContentAlignment.MiddleRight


            Dim label2 As New Label()

            label2.AutoSize = True
            label2.Margin = New Padding(0)

            label2.BackColor = Color.Transparent

            label2.Padding = New Padding(0, 0, 0, 0)

            label2.ForeColor = Color.Brown

            If senderType <> user_role Then
                messageLabel.Left = Chat.Width - messageLabel.PreferredWidth - 10 - 25
                label2.Left = messageLabel.Left + messageLabel.PreferredWidth - 35 + messageLabel.Width - 88
            Else
                messageLabel.Left = 10
                label2.Left = textSize.Width - 5
            End If

            label2.AutoEllipsis = False ' Allow the label to display all text

            label2.Text = DateTime.Now.ToString("hh:mm")

            label2.Font = New Font(messageLabel.Font.FontFamily, 7, FontStyle.Italic)

            messageLabel.Height = textSize.Height
            messageLabel.Top = yPos   ' Set the vertical position



            label2.Top = yPos + messageLabel.Height

            ' Manually calculate the height of the label based on the text and the maximum width



            ' Set label position
            yPos += messageLabel.Height + Label1.Height - 5

            ' Add label to the chat_list panel
            Support.Controls.Add(messageLabel)

        Next
        ' Ensure the panel scrolls to the bottom to show the latest message
        Support.AutoScrollPosition = New Point(0, Support.AutoScrollPosition.Y + yPos)
    End Sub

End Class
