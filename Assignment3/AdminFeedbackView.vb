Imports System.Configuration
Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class AdminFeedbackView

    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Private Sub AdminFeedbackView_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the default button colors
        userButton.BackColor = Color.FromArgb(255, 220, 189, 232)
        providerButton.BackColor = Color.FromKnownColor(KnownColor.Control)

        ' Load feedback for customers by default
        LoadFeedback("customer")
    End Sub

    Private Sub userButton_Click(sender As Object, e As EventArgs) Handles userButton.Click
        ' Set button colors
        userButton.BackColor = Color.FromArgb(255, 220, 189, 232)
        providerButton.BackColor = Color.FromKnownColor(KnownColor.Control)

        ' Load feedback for customers
        LoadFeedback("customer")
    End Sub

    Private Sub providerButton_Click(sender As Object, e As EventArgs) Handles providerButton.Click
        ' Set button colors
        providerButton.BackColor = Color.FromArgb(255, 220, 189, 232)
        userButton.BackColor = Color.FromKnownColor(KnownColor.Control)

        ' Load feedback for providers
        LoadFeedback("provider")
    End Sub

    Private Sub applyButton_Click(sender As Object, e As EventArgs) Handles applyButton.Click
        ' Apply filter when the "Apply" button is clicked
        Dim userType As String = If(userButton.BackColor = Color.FromArgb(255, 220, 189, 232), "customer", "provider")
        LoadFeedback(userType)
    End Sub

    Private Sub LoadFeedback(userType As String)
        ' Clear existing feedback panels
        Panel2.Controls.Clear()

        ' Get the selected rating filter
        Dim selectedRating As Integer = GetSelectedRating()

        ' Construct the SQL query
        Dim query As String = "SELECT feedback_id, sendername, rating, feedback_text FROM feedback WHERE user_type=@userType"

        ' Add rating filter if selected
        If selectedRating > 0 Then
            query &= " AND rating=@rating"
        End If

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@userType", userType)

                ' Add rating parameter if selected
                If selectedRating > 0 Then
                    command.Parameters.AddWithValue("@rating", selectedRating)
                End If

                Try
                    connection.Open()
                    Using reader As SqlDataReader = command.ExecuteReader()
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
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using
    End Sub

    Private Function GetSelectedRating() As Integer
        ' Get the selected rating from the ComboBox or RadioButton controls
        If ComboBox1.SelectedIndex <> -1 Then
            Return Convert.ToInt32(ComboBox1.SelectedItem)
        Else
            ' If no rating is selected, return 0 to indicate no filter
            Return 0
        End If
    End Function

End Class
