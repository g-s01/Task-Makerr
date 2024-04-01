Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient
Public Class AdminFeedbackView

    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Private Sub AdminFeedbackView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        userButton.BackColor = Color.FromArgb(255, 220, 189, 232)
        providerButton.BackColor = Color.FromKnownColor(KnownColor.Control)

        Dim query As String = "SELECT feedback_id, sendername, rating, feedback_text FROM feedback WHERE user_type='customer'"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Panel2.Controls.Clear()

                Dim verticalPosition As Integer = 0

                While reader.Read()
                    Dim feedbackPanel As New Panel()
                    feedbackPanel.BorderStyle = BorderStyle.FixedSingle
                    feedbackPanel.AutoSize = False
                    feedbackPanel.BackColor = Color.FromArgb(220, 189, 232)
                    feedbackPanel.Width = Panel2.Width
                    feedbackPanel.Location = New Point(0, verticalPosition)
                    verticalPosition += feedbackPanel.Height + 5 ' Add some spacing between panels

                    ' Create labels to display feedback information
                    Dim senderNameLabel As New Label()
                    senderNameLabel.Text = reader("sendername").ToString()
                    senderNameLabel.AutoSize = True
                    senderNameLabel.Location = New Point(10, 10)
                    senderNameLabel.Font = New Font("Arial", 12, FontStyle.Bold)

                    Dim ratingLabel As New Label()
                    ratingLabel.Text = "Rating : " & reader("rating").ToString()
                    ratingLabel.AutoSize = True
                    ratingLabel.Location = New Point(10, 30)
                    ratingLabel.Font = New Font("Arial", 10, FontStyle.Regular) ' Set font and size


                    Dim feedbackTextLabel As New Label()
                    feedbackTextLabel.Text = reader("feedback_text").ToString()
                    feedbackTextLabel.AutoSize = True
                    feedbackTextLabel.Location = New Point(10, 50)
                    feedbackTextLabel.Font = New Font("Arial", 10, FontStyle.Regular)

                    ' Add labels to the feedback panel
                    feedbackPanel.Controls.Add(senderNameLabel)
                    feedbackPanel.Controls.Add(ratingLabel)
                    feedbackPanel.Controls.Add(feedbackTextLabel)

                    ' Add the feedback panel to the scrollable panel
                    Panel2.Controls.Add(feedbackPanel)
                End While
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub userButton_Click(sender As Object, e As EventArgs) Handles userButton.Click
        userButton.BackColor = Color.FromArgb(255, 220, 189, 232)
        providerButton.BackColor = Color.FromKnownColor(KnownColor.Control)

        Dim query As String = "SELECT feedback_id, sendername, rating, feedback_text FROM feedback WHERE user_type='customer'"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Panel2.Controls.Clear()

                Dim verticalPosition As Integer = 0

                While reader.Read()
                    Dim feedbackPanel As New Panel()
                    feedbackPanel.BorderStyle = BorderStyle.FixedSingle
                    feedbackPanel.AutoSize = False
                    feedbackPanel.BackColor = Color.FromArgb(220, 189, 232)
                    feedbackPanel.Width = Panel2.Width
                    feedbackPanel.Location = New Point(0, verticalPosition)
                    verticalPosition += feedbackPanel.Height + 5 ' Add some spacing between panels

                    ' Create labels to display feedback information
                    Dim senderNameLabel As New Label()
                    senderNameLabel.Text = reader("sendername").ToString()
                    senderNameLabel.AutoSize = True
                    senderNameLabel.Location = New Point(10, 10)
                    senderNameLabel.Font = New Font("Arial", 12, FontStyle.Bold)

                    Dim ratingLabel As New Label()
                    ratingLabel.Text = "Rating: " & reader("rating").ToString()
                    ratingLabel.AutoSize = True
                    ratingLabel.Location = New Point(10, 30)
                    ratingLabel.Font = New Font("Arial", 10, FontStyle.Regular) ' Set font and size


                    Dim feedbackTextLabel As New Label()
                    feedbackTextLabel.Text = reader("feedback_text").ToString()
                    feedbackTextLabel.AutoSize = True
                    feedbackTextLabel.Location = New Point(10, 50)
                    feedbackTextLabel.Font = New Font("Arial", 10, FontStyle.Regular)

                    ' Add labels to the feedback panel
                    feedbackPanel.Controls.Add(senderNameLabel)
                    feedbackPanel.Controls.Add(ratingLabel)
                    feedbackPanel.Controls.Add(feedbackTextLabel)

                    ' Add the feedback panel to the scrollable panel
                    Panel2.Controls.Add(feedbackPanel)
                End While
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub providerButton_Click(sender As Object, e As EventArgs) Handles providerButton.Click
        providerButton.BackColor = Color.FromArgb(255, 220, 189, 232)
        userButton.BackColor = Color.FromKnownColor(KnownColor.Control)

        Dim query As String = "SELECT feedback_id, sendername, rating, feedback_text FROM feedback WHERE user_type='provider'"

        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                Panel2.Controls.Clear()

                Dim verticalPosition As Integer = 0

                While reader.Read()
                    Dim feedbackPanel As New Panel()
                    feedbackPanel.BorderStyle = BorderStyle.FixedSingle
                    feedbackPanel.AutoSize = False
                    feedbackPanel.BackColor = Color.FromArgb(220, 189, 232)
                    feedbackPanel.Width = Panel2.Width
                    feedbackPanel.Location = New Point(0, verticalPosition)
                    verticalPosition += feedbackPanel.Height + 5 ' Add some spacing between panels

                    ' Create labels to display feedback information
                    Dim senderNameLabel As New Label()
                    senderNameLabel.Text = reader("sendername").ToString()
                    senderNameLabel.AutoSize = True
                    senderNameLabel.Location = New Point(10, 10)
                    senderNameLabel.Font = New Font("Arial", 12, FontStyle.Bold)

                    Dim ratingLabel As New Label()
                    ratingLabel.Text = "Rating: " & reader("rating").ToString()
                    ratingLabel.AutoSize = True
                    ratingLabel.Location = New Point(10, 30)
                    ratingLabel.Font = New Font("Arial", 10, FontStyle.Regular)

                    Dim feedbackTextLabel As New Label()
                    feedbackTextLabel.Text = reader("feedback_text").ToString()
                    feedbackTextLabel.AutoSize = True
                    feedbackTextLabel.Location = New Point(10, 50)
                    feedbackTextLabel.Font = New Font("Arial", 10, FontStyle.Regular)

                    ' Add labels to the feedback panel
                    feedbackPanel.Controls.Add(senderNameLabel)
                    feedbackPanel.Controls.Add(ratingLabel)
                    feedbackPanel.Controls.Add(feedbackTextLabel)

                    ' Add the feedback panel to the scrollable panel
                    Panel2.Controls.Add(feedbackPanel)
                End While
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub


    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
End Class