Imports System.Configuration
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Data.SqlClient
Public Class user_search


    Dim reviews As New Dictionary(Of Int32, Tuple(Of Integer, Integer))()
    Dim rating_prov As New Dictionary(Of Int32, Double)()

    ' Define a global array to store providers
    Dim providers As New List(Of Entry)

    ' Define a structure to hold provider details
    Structure Entry
        Public providerID As Integer
        Public providerName As String
        Public service As String
        Public location As String
        Public cost As Integer
        Public rating As Double
        Public RadioButton As RadioButton ' Added RadioButton field
    End Structure

    Private Sub user_search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim command_rev As New SqlCommand("SELECT review.*, deals.* FROM review INNER JOIN deals ON review.deal_id = deals.deal_id", connection)
                Using reader As SqlDataReader = command_rev.ExecuteReader()
                    While reader.Read()
                        Dim provider As Int32 = reader.GetInt32(reader.GetOrdinal("provider_id"))
                        Dim rate As String = reader.GetInt32(reader.GetOrdinal("rating"))
                        If reviews.ContainsKey(provider) Then
                            Dim currentValue As Tuple(Of Integer, Integer) = reviews(provider)
                            Dim newValue As New Tuple(Of Integer, Integer)(currentValue.Item1 + rate, currentValue.Item2 + 1)
                            reviews(provider) = newValue
                        Else
                            reviews.Add(provider, New Tuple(Of Integer, Integer)(rate, 1))
                        End If
                    End While
                End Using
                For Each pair As KeyValuePair(Of Int32, Tuple(Of Integer, Integer)) In reviews
                    Dim currentValue As Tuple(Of Integer, Integer) = pair.Value
                    Dim rating As Double
                    rating = Math.Round(currentValue.Item1 / CType(currentValue.Item2, Double), 1)
                    rating_prov.Add(pair.Key, rating)
                Next
            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            End Try
        End Using
        LoadProviders()
        PopulateTable()
    End Sub

    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.GotFocus
        ' When the TextBox gains focus, clear the placeholder text if it's present
        If TextBox1.Text = "Search for providers by name" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.LostFocus
        ' When the TextBox loses focus and it's empty, display the placeholder text
        If TextBox1.Text = "" Then
            TextBox1.Text = "Search for providers by name"
            TextBox1.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    Private Sub PopulateTable()

        providersTablePanel.Controls.Clear()
        'LoadProviders()

        ' Add borrowedBooks to the table
        For rowIndex As Integer = 0 To providers.Count - 1
            Dim entry As Entry = providers(rowIndex)

            ' Add provider details
            Dim providerNameLabel As New Label()
            providerNameLabel.Text = entry.providerName.ToString()
            providersTablePanel.Controls.Add(providerNameLabel, 0, rowIndex)
            providerNameLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            providerNameLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim serviceLabel As New Label()
            serviceLabel.Text = entry.service
            providersTablePanel.Controls.Add(serviceLabel, 1, rowIndex)
            serviceLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            serviceLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim locationLabel As New Label()
            locationLabel.Text = entry.location
            locationLabel.AutoSize = True
            providersTablePanel.Controls.Add(locationLabel, 2, rowIndex)
            locationLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            locationLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim costLabel As New Label()
            costLabel.Text = entry.cost
            providersTablePanel.Controls.Add(costLabel, 3, rowIndex)
            costLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            costLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            Dim ratingLabel As New Label()
            ratingLabel.Text = entry.rating
            providersTablePanel.Controls.Add(ratingLabel, 4, rowIndex)
            ratingLabel.TextAlign = ContentAlignment.MiddleCenter ' Center the label
            ratingLabel.Anchor = AnchorStyles.None ' Set Anchor to None

            ' Add radio button for options
            providersTablePanel.Controls.Add(entry.RadioButton, 5, rowIndex)
            entry.RadioButton.TextAlign = ContentAlignment.MiddleCenter ' Center the radio button
            entry.RadioButton.Anchor = AnchorStyles.None ' Set Anchor to None
            entry.RadioButton.Size = New Size(16, 16) ' Set the size of the radio button

        Next

        Dim adjustLabel As New Label()
        adjustLabel.Text = ""
        providersTablePanel.Controls.Add(adjustLabel, 1, providers.Count)

    End Sub

    Private Sub LoadProviders()
        providers.Clear()
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerID = 123, .providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox1.Text = "Search for providers by name" Then
            MessageBox.Show("Enter a text to search")
        Else
            providers.Clear()
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
            Using connection As New SqlConnection(connectionString)
                Try
                    connection.Open()
                    Dim command As New SqlCommand("SELECT * FROM provider WHERE providername like '" & TextBox1.Text & "'", connection)
                    Using reader As SqlDataReader = command.ExecuteReader()
                        ' Loop through the SqlDataReader
                        While reader.Read()
                            ' Get the values of the current row
                            Dim service As String = reader.GetString(reader.GetOrdinal("service"))
                            'Dim loc As String = reader.GetString(reader.GetOrdinal("location"))
                            Dim name As String = reader.GetString(reader.GetOrdinal("providername"))
                            Dim provider As Int32 = reader.GetInt32(reader.GetOrdinal("provider_id"))
                            Dim cost As Double = reader.GetInt32(reader.GetOrdinal("cost_per_hour"))
                            Dim rating As String
                            If reviews.ContainsKey(provider) Then
                                Dim currentValue As Tuple(Of Integer, Integer) = reviews(provider)
                                rating = rating_prov(provider).ToString()
                            Else
                                rating = "N/A"
                            End If
                            providers.Add(New Entry With {.providerID = provider, .providerName = name, .service = service, .location = "loc", .cost = cost, .rating = rating, .RadioButton = New RadioButton()})
                        End While
                    End Using

                Catch ex As Exception
                    MessageBox.Show("Error connecting to database: " & ex.Message)
                End Try
            End Using
            PopulateTable()
        End If

    End Sub
End Class