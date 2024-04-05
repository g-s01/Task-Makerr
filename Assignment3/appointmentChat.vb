Imports System.Globalization
Imports Microsoft.CodeAnalysis.Text

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
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(3, -1, "customer", "Sure, let's meet at 4!", "2024-01-30 10:00:00"))
        messages.Add(New Tuple(Of Integer, Integer, String, String, String)(4, -1, "provider", "Sounds good!", "2024-03-30 10:35:00"))
        PrintMessages()
    End Sub


    Private Sub sendTextBox_KeyDown(sender As Object, e As KeyEventArgs) Handles inputTextBox.KeyDown
        If e.KeyCode = Keys.Enter Then
            ' Call the sendButton_Click event handler
            sendButton_Click(sender, e)
            ' Prevent the key press from being handled by the TextBox
            e.SuppressKeyPress = True
        End If
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
            Dim timeStamp As String = DateTime.ParseExact(msg.Item5, "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture).ToString("hh:mm")


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
                messageLabel.Left = Chat.Width - messageLabel.PreferredWidth - 10 - 15
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
            Chat.Controls.Add(messageLabel)
            Chat.Controls.Add(label2)

        Next
        ' Ensure the panel scrolls to the bottom to show the latest message
        Chat.AutoScrollPosition = New Point(0, Chat.AutoScrollPosition.Y + yPos)
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
