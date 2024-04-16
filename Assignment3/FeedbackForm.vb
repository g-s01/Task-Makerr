Imports System.Configuration
Imports Microsoft.Data.SqlClient

Public Class FeedbackForm
    Dim stars As List(Of PictureBox)
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Dim senderId As Integer = -1 ' Global variable for user_id or provider_id
    Dim userType As String = ""
    Dim Rating As Integer = 0
    Dim sendername As String = "sender name"

    Private Sub FeedbackForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Add PictureBoxes to the list
        stars = New List(Of PictureBox) From {star1, star2, star3, star4, star5}

        ' Attach click event handler to each PictureBox
        For Each star In stars
            AddHandler star.Click, AddressOf Star_Click
        Next

        ' Determine user type
        If Module_global.User_ID = -1 Then
            userType = "provider"
            senderId = Module_global.Provider_ID
        Else
            userType = "customer"
            senderId = Module_global.User_ID
        End If

        'query to find the count, to check whether this is new  feedback or not
        Dim query As String = ""

        Dim feedback_count As Integer
        query = " select count(*) from feedback where sender_id = @sender_id"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@sender_id", senderId)
                connection.Open()
                feedback_count = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        'if feedback is already given 
        If feedback_count > 0 Then
            Dim query2 As String = ""
            Dim rating As Integer
            Dim feedbackText As String

            'get the recent rating and feedback given
            query2 = "SELECT TOP 1 rating, feedback_text FROM feedback WHERE sender_id = @sender_id ORDER BY feedback_id DESC"

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query2, connection)
                    command.Parameters.AddWithValue("@sender_id", senderId)
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
                        If reader.Read() Then
                            ' Retrieve rating and feedback text
                            rating = Convert.ToInt32(reader("rating"))
                            feedbackText = reader("feedback_text").ToString()
                        End If
                    End Using
                End Using
            End Using

            'Display the rating as yellow stars
            For i As Integer = 0 To rating - 1
                stars(i).Image = My.Resources.yellow_star
                ' Change to your yellow star image
            Next

            'and the thank you note and feedback text previously given is displayed
            lblTitle.Text = "Thank you for your Feedback"
            lblRateUs.Text = "Want to update it?"
            lblTitle.Location = New Point(185, 30)
            lblRateUs.Location = New Point(250, 70)
            btnSend.Text = "Update"
            txtFeedback.Text = feedbackText
        End If

        ' Center align remaining controls
    End Sub

    Private Sub Star_Click(sender As Object, e As EventArgs)
        Dim clickedStar As PictureBox = DirectCast(sender, PictureBox)

        ' Get the index of the clicked star
        Dim clickedIndex As Integer = stars.IndexOf(clickedStar)
        Rating = clickedIndex + 1
        ' Loop through each star and set its image
        For i As Integer = 0 To clickedIndex
            stars(i).Image = My.Resources.yellow_star
            ' Change to your yellow star image
        Next

        ' Reset images of stars after the clicked star
        For i As Integer = clickedIndex + 1 To stars.Count - 1
            stars(i).Image = My.Resources.bg_star ' Change to your grey star image
        Next
    End Sub

    Private Sub txtFeedback_Enter(sender As Object, e As EventArgs) Handles txtFeedback.Enter
        ' Clear the default text when the TextBox is focused
        If txtFeedback.Text = "Write your feedback here..." Then
            txtFeedback.Text = ""
        End If
    End Sub

    Private Sub txtFeedback_Leave(sender As Object, e As EventArgs) Handles txtFeedback.Leave
        ' Restore the default text if the TextBox is left empty
        If txtFeedback.Text = "" Then
            txtFeedback.Text = "Write your feedback here..."
        End If
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        Dim feedbackId As Integer = GetNextFeedbackId() ' Get the next feedback id

        If feedbackId <> -1 Then
            Dim feedbackText As String = txtFeedback.Text.Trim()
            Dim timestamp As DateTime = DateTime.Now

            'Error handling, if nothing is given user is asked to enter rating
            If Rating = 0 Then
                MessageBox.Show("Kindly give the rating")
                Return
            End If
            If txtFeedback.Text = "Write your feedback here..." Then
                feedbackText = ""
            End If


            'query for the username/providername 
            Dim query As String = ""

            If userType = "customer" Then
                query = " select username from customer where user_id=@sender_id"
            Else
                query = " select providername from provider where provider_id=@sender_id"
            End If

            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(query, connection)
                    command.Parameters.AddWithValue("@sender_id", senderId)
                    connection.Open()
                    sendername = (command.ExecuteScalar()).ToString()
                End Using
            End Using

            'Insert into table

            InsertFeedback(feedbackId, senderId, sendername, userType, feedbackText, timestamp, Rating)

            'after successful insertion show the submitted feedback to user
            MessageBox.Show("Thank you for your feedback!", "Feedback Submitted", MessageBoxButtons.OK, MessageBoxIcon.Information)

            lblTitle.Text = "Thank you for your Feedback"
            lblRateUs.Text = "Want to update it?"
            btnSend.Text = "Update"


        Else
            MessageBox.Show("Error occurred while submitting feedback.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    'new feedback id is the maximum of current +1 that is the next number to the maximum
    Private Function GetNextFeedbackId() As Integer
        Dim nextId As Integer = -1

        Using connection As New SqlConnection(connectionString)
            Dim query As String = "SELECT ISNULL(MAX(feedback_id), 0) + 1 FROM feedback"
            Using command As New SqlCommand(query, connection)
                connection.Open()
                nextId = Convert.ToInt32(command.ExecuteScalar())
            End Using
        End Using

        Return nextId
    End Function

    'Inserting new entry into feedback table
    Private Sub InsertFeedback(feedbackId As Integer, senderId As Integer, senderName As String, userType As String, feedbackText As String, sentTimestamp As DateTime, rating As Integer)
        Using connection As New SqlConnection(connectionString)
            Dim query As String = "INSERT INTO feedback (sender_id, sendername, user_type, feedback_text, sent_timestamp, rating) VALUES (@SenderId, @SenderName, @UserType, @FeedbackText, @SentTimestamp, @Rating)"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@SenderId", senderId)
                command.Parameters.AddWithValue("@SenderName", senderName)
                command.Parameters.AddWithValue("@UserType", userType)
                command.Parameters.AddWithValue("@FeedbackText", feedbackText)
                command.Parameters.AddWithValue("@SentTimestamp", sentTimestamp)
                command.Parameters.AddWithValue("@Rating", rating)
                connection.Open()
                command.ExecuteNonQuery()
            End Using
        End Using
    End Sub

End Class
