Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class provider_feedback_view
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

    Private Sub provider_feedback_view_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load reviews when the form loads
        LoadReviews()
    End Sub

    Private Sub LoadReviews()
        ' Clear existing items in the ListView
        listViewReviews.Items.Clear()
        listViewReviews.Name = "listViewReviews"
        listViewReviews.Width = 830 ' Set width to 1000
        listViewReviews.View = View.Details ' Set view to Details mode
        listViewReviews.FullRowSelect = True ' Select entire row when clicked
        listViewReviews.GridLines = False ' Display grid lines
        listViewReviews.BorderStyle = BorderStyle.None
        listViewReviews.Font = New Font("Arial", 12)
        listViewReviews.Columns.Add("Review", 720)
        listViewReviews.Columns.Add("Rating", 100)

        ' SQL query to retrieve review data including ratings
        Dim query As String = "SELECT [review_text], [rating] FROM [dbo].[review]"

        ' Create SQL connection and command objects
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()

                ' Execute the SQL command
                Using command As New SqlCommand(query, connection)
                    ' Read data using SqlDataReader
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        ' Get data from the reader
                        Dim reviewText As String = reader.GetString(0)
                        Dim rating As Double = reader.GetInt32(1)

                        ' Create a ListViewItem with review text and rating
                        Dim row As New ListViewItem({reviewText, rating})
                        listViewReviews.Items.Add(row) ' Add rating as a subitem
                        row.UseItemStyleForSubItems = False ' Set to allow individual styling


                    End While
                    reader.Close()
                End Using
            Catch ex As Exception
                MessageBox.Show("Error loading reviews: " & ex.Message)
            End Try
        End Using
    End Sub
End Class
