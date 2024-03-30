Imports System.Drawing.Printing

Public Class Chat
    Private messageList As New List(Of Message)()
    Private lebel As Object

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create a new message and set its properties
        Dim newMessage As New Message()
        newMessage.ChatRoom_id = 1
        newMessage.Deal_id = 3
        newMessage.Sender_type = "aksdk"
        newMessage.Message_content = TextBox1.Text
        newMessage.SendTimeStamp = DateTime.Now

        ' Add the new message to the message list
        messageList.Add(newMessage)

        ' Display the messages in Panel2
        DisplayMessages()

        ' Clear the text in TextBox1
        TextBox1.Text = ""
    End Sub
    Private Sub DisplayMessages()
        ' Clear existing messages in Panel2
        Panel2.Controls.Clear()

        ' Display each message in the message list
        Dim yOffset As Integer = 10
        Dim gap As Integer = 10 ' Gap between labels
        Dim pad As Integer = 25
        Dim panelWidth As Integer = Panel2.Width

        For Each msg In messageList
            Dim label As New Label()
            label.AutoSize = True
            label.Text = msg.Message_content
            label.BackColor = Color.LightGray
            label.Padding = New Padding(5, 5, 5, 5) ' Set padding to 5 on the left and right, 0 on the top and bottom
            label.MaximumSize = New Size(panelWidth - pad * 2, 0) ' Limit width to panel width with some padding
            label.AutoEllipsis = False ' Allow the label to display all text
            label.Left = panelWidth - label.PreferredWidth - pad
            label.Top = yOffset ' Set the vertical position



            ' Manually calculate the height of the label based on the text and the maximum width
            Dim textSize = TextRenderer.MeasureText(label.Text, label.Font, label.MaximumSize, TextFormatFlags.WordBreak)
            label.Height = textSize.Height

            Panel2.Controls.Add(label)

            ' Increment the vertical position for the next message with gap
            yOffset += label.Height + gap

        Next



        ' Ensure the panel scrolls to the bottom to show the latest message
        Panel2.AutoScrollPosition = New Point(0, Panel2.AutoScrollPosition.Y + yOffset)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub
End Class

Public Class Message
    Public Property ChatRoom_id As Integer
    Public Property Deal_id As Integer
    Public Property Sender_type As String
    Public Property Message_content As String
    Public Property SendTimeStamp As DateTime

End Class