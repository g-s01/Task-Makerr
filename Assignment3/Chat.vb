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

        For Each msg In messageList
            Dim rtb As New RichTextBox()
            rtb.AutoSize = True
            rtb.WordWrap = True
            rtb.ScrollBars = RichTextBoxScrollBars.None
            rtb.BackColor = Color.DarkGray

            rtb.Padding = New Padding(10)
            rtb.ReadOnly = True
            rtb.BorderStyle = BorderStyle.None

            ' Add message content with different styles for username, message, and time
            rtb.SelectionStart = rtb.TextLength
            rtb.SelectionLength = 0
            rtb.SelectionColor = Color.Blue
            rtb.SelectionFont = New Font(rtb.Font.FontFamily, 9, FontStyle.Bold)
            rtb.SelectedText = msg.Sender_type & Environment.NewLine

            rtb.SelectionStart = rtb.TextLength
            rtb.SelectionLength = 0
            rtb.SelectionColor = Color.SeaShell
            rtb.SelectionFont = New Font(rtb.Font.FontFamily, 9, FontStyle.Bold)
            rtb.SelectedText = msg.Message_content & Environment.NewLine

            rtb.SelectionStart = rtb.TextLength
            rtb.SelectionLength = 0
            rtb.SelectionColor = Color.DimGray
            rtb.SelectionFont = New Font(rtb.Font.FontFamily, 7, FontStyle.Bold)
            rtb.SelectedText = DateTime.Now.ToString("hh:mm")
            rtb.SelectionAlignment = HorizontalAlignment.Right

            rtb.Left = pad 
            rtb.Top = yOffset



            rtb.Width = panelWidth - 2 * pad

            Panel2.Controls.Add(rtb)
            Dim textSize = TextRenderer.MeasureText(rtb.Text, rtb.Font, New Size(panelWidth - 3 * pad, 0), TextFormatFlags.WordBreak)
            rtb.Width = textSize.Width  ' Set the width to the measured width of the text
            rtb.Height = textSize.Height
            ' Increment the vertical position for the next message with gap
            yOffset += rtb.Height + gap
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
