Imports System.Drawing.Printing
Imports iText.Kernel.Pdf.Navigation

Public Class Chat
    Private messageList As New List(Of Message)()

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Create a new message and set its properties
        Dim newMessage As New Message()
        newMessage.ChatRoom_id = 1
        newMessage.Deal_id = 3
        newMessage.Sender_type = "Bhogi"
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
        Dim gap As Integer = 10 ' Gap between messages
        Dim pad As Integer = 10
        Dim panelWidth As Integer = Panel2.Width
        Dim isSender As Boolean = False ' Flag to indicate if the message is sent by the user

        For Each msg In messageList
            isSender = (msg.Sender_type = "Bhogi")

            Dim label As New Label()
            label.AutoSize = True
            label.Text = msg.Message_content
            label.BackColor = Color.LightGray
            label.Padding = New Padding(5, 5, 5, 5) ' Set padding to 5 on the left and right, 0 on the top and bottom
            label.MaximumSize = New Size(panelWidth - pad * 3, 0) ' Limit width to panel width with some padding
            label.AutoEllipsis = False ' Allow the label to display all text
            label.Left = If(isSender, panelWidth - label.PreferredWidth - pad - 25, pad)
            If label.Text = "" Then
                label.Text = "."
            End If

            Dim label1 As New Label()
            Dim label2 As New Label()
            label1.AutoSize = True
            label2.AutoSize = True
            label2.Margin = New Padding(0)
            label1.BackColor = Color.Transparent
            label2.BackColor = Color.Transparent
            label1.Padding = New Padding(0, 0, 0, 0)
            label2.Padding = New Padding(0, 0, 0, 0)
            label.ForeColor = Color.Black
            label2.ForeColor = Color.Brown

            label1.Left = If(isSender, Math.Min(label.Left + label.PreferredWidth - 35, label.Right - 100), pad)

            label1.AutoEllipsis = False ' Allow the label to display all text
            label2.AutoEllipsis = False ' Allow the label to display all text
            label1.Text = msg.Sender_type
            label2.Text = DateTime.Now.ToString("hh:mm")
            label1.Top = yOffset
            label2.Font = New Font(label.Font.FontFamily, 7, FontStyle.Italic)
            label1.Font = New Font(label.Font.FontFamily, 7, FontStyle.Bold)
            label.Top = yOffset + label1.Height - 10 ' Set the vertical position
            Dim textSize = TextRenderer.MeasureText(label.Text, label.Font, label.MaximumSize, TextFormatFlags.WordBreak)
            label.Height = textSize.Height

            label2.Left = If(isSender, label.Left + label.PreferredWidth - 35 + label.Width - 88, textSize.Width - 5)
            label2.Top = yOffset + label.Height + label1.Height + 8 - 10
            If isSender Then
                label1.ForeColor = Color.Blue ' Change font color to blue for messages sent by "Bhogi"
            Else
                label1.ForeColor = Color.Green ' Change font color to black for other messages
            End If

            ' Manually calculate the height of the label based on the text and the maximum width

            Panel2.Controls.Add(label1)
            Panel2.Controls.Add(label)
            Panel2.Controls.Add(label2)

            ' Increment the vertical position for the next message with gap
            yOffset += label.Height + gap + label2.Height + label1.Height + 10
        Next


        ' Ensure the panel scrolls to the bottom to show the latest message
        Panel2.AutoScrollPosition = New Point(0, Panel2.AutoScrollPosition.Y + yOffset)
    End Sub


End Class


Public Class Message
    Public Property ChatRoom_id As Integer
    Public Property Deal_id As Integer
    Public Property Sender_type As String
    Public Property Message_content As String
    Public Property SendTimeStamp As DateTime

End Class