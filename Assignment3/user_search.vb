Imports System.Configuration
Imports Microsoft.Data.SqlClient
Public Class user_search

    ' Define a global array to store providers
    Dim providers As New List(Of Entry)

    ' Define a structure to hold provider details
    Structure Entry
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
                MessageBox.Show("Connection successful!")

            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            End Try
        End Using
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
        LoadProviders()

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
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})
        providers.Add(New Entry With {.providerName = "testProvider", .service = "testService", .location = "testLocation", .cost = 100, .rating = 4.4, .RadioButton = New RadioButton()})

    End Sub

End Class