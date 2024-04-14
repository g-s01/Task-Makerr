Imports Microsoft.Data.SqlClient
Imports Org.BouncyCastle.Crypto.Asymmetric.AsymmetricRsaKey
Imports System.Configuration
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms.AxHost
Public Class ViewAllUser
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        'Example of how to connect to Database using connection string in app.config file.
        'Needs Microsoft.Data.SqlClient.
        'If not present, you need to get it through NuGet package manager
        'Access the same through context menu by clicking on project name.
        'If this is not available locally, you need to get it online.
        'For that you need to add nuget.org as source in Tools->NuGet...
        'Ask GPT for details.
        'As it stands, the System.Data.SqlClient does not work on .NET 5+ or .NET core (I assume default installed will be 8.0)
        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        '  Using connection As New SqlConnection(connectionString)
        '  Try
        '  connection.Open()
        '         ' MessageBox.Show("Connection successful!")
        '
        ' Catch ex As Exception
        ' MessageBox.Show("Error connecting to database: " & ex.Message)
        'End Try
        ' End Using






        Label3.Text = serviceType



        ComboBox1.Items.Add("Sorted by Rating")
        ComboBox1.Items.Add("A-Z by Location")
        Dim filter_by_loc As String = "Filter by Location"
        ComboBox1.Items.Add(filter_by_loc)

        Dim Locations() As String = {"Location A", "Location B", "Location C"}
        ComboBox2.Items.AddRange(Locations)


        ' Set the default selected item for comboBox1
        ComboBox1.SelectedIndex = 0 ' This will select the first item ("Option 1")

        ' Hide comboBox2 initially
        ComboBox2.Visible = False







        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Dim providers As New Dictionary(Of Integer, ProviderData)()
        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Dim query As String = "SELECT " &
              "provider.provider_id, " &
              "provider.providername, " &
              "provider.service, " &
              "location.location, " &
              "COALESCE(SUM(review.rating), -1) AS sum_of_ratings, " &
              "COALESCE(COUNT(review.rating), -1) AS count_of_ratings " &
              "FROM " &
              "provider " &
              "LEFT JOIN deals ON provider.provider_id = deals.provider_id " &
              "LEFT JOIN review ON deals.deal_id = review.deal_id " &
              "JOIN location ON provider.provider_id = location.provider_id " &
              "WHERE " &
              "provider.service = @serviceType " &
              "GROUP BY " &
              "provider.provider_id, provider.providername, provider.service, location.location"

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@serviceType", serviceType)

                Try
                    Using reader As SqlDataReader = command.ExecuteReader()
                        While reader.Read()
                            Dim providerId As Integer = reader.GetInt32(reader.GetOrdinal("provider_id"))
                            Dim providerName As String = reader.GetString(reader.GetOrdinal("providername"))
                            Dim serviceName As String = reader.GetString(reader.GetOrdinal("service"))
                            Dim location As String = reader.GetString(reader.GetOrdinal("location"))
                            Dim sumOfRatings As Integer = reader.GetInt32(reader.GetOrdinal("sum_of_ratings"))
                            Dim countOfRatings As Integer = reader.GetInt32(reader.GetOrdinal("count_of_ratings"))
                            Dim avgRating As Double = If(countOfRatings > 0, sumOfRatings / countOfRatings, -1)

                            If Not providers.ContainsKey(providerId) Then
                                ' If the provider is not already in the dictionary, create a new ProviderData object
                                providers.Add(providerId, New ProviderData(providerId, serviceName, providerName, New List(Of String)(), avgRating))
                            End If

                            ' Add location to the provider's list of locations
                            providers(providerId).Locations.Add(location)
                        End While

                        '  ' Display data in a message box
                        '  Dim message As New StringBuilder()
                        '  For Each kvp In providers
                        '      Dim pr As ProviderData = kvp.Value
                        '      message.AppendLine($"Provider ID: {pr.ProviderId}, Provider Name: {pr.ProviderName}, Service: {pr.ServiceName}, Avg Rating: {pr.AverageRating}")
                        '      message.AppendLine("Locations:")
                        '      For Each lo In pr.Locations
                        '          message.AppendLine($"- {lo}")
                        '      Next
                        '      message.AppendLine() ' Add a blank line between providers
                        '  Next
                        '
                        '  MessageBox.Show(message.ToString(), "Provider Data", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error reading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using










        ' Create an inner panel
        Dim innerPanel As New Panel()

        ' Set inner panel properties
        innerPanel.Location = New Point(27, 140) ' Fixed location
        'innerPanel.AutoScroll = False ' Disable scrolling in inner panel
        innerPanel.Size = New Size(1000, 1000)
        ' Add buttons to the inner panel (replace with your button creation logic)
        ' Set panel properties to enable scrolling
        innerPanel.AutoScroll = True ' Enable auto-scrolling




        ' Define button size and spacing
        Dim buttonWidth = 350
        Dim buttonSpacing = 35
        Dim buttonHeight = 150




        Dim numOfTiles As Integer = 11




        Dim numberOfButtons As Integer
        numberOfButtons = numOfTiles



        innerPanel.AutoScrollMinSize = New Size(1000, 500 + (buttonHeight + buttonSpacing) * 1.0 * providers.Count) ' Adjust scroll area size as needed





        Dim photo As Image = My.Resources.User_Logo
        Dim originalImage As Image = My.Resources.prov ' Load the original image
        Dim profile_photo As New Bitmap(originalImage, New Size(100, 100)) ' Resize the image to the desired size



        Dim userTiles(numOfTiles - 1) As viewMore
        Dim tileClickedHandlers(numOfTiles - 1) As Action(Of Object, Integer)



        Dim i As Integer = 0 ' Initialize i outside the loop

        For Each kvp As KeyValuePair(Of Integer, ProviderData) In providers
            ' Calculate startX and startY based on the position in the grid
            Dim currentRow As Integer = i \ 2 ' Integer division to determine the row
            Dim currentColumn As Integer = i Mod 2 ' Modulus to determine the column
            Dim startX As Integer = currentColumn * (buttonWidth + buttonSpacing)
            Dim startY As Integer = currentRow * (buttonHeight + buttonSpacing)

            ' Create a viewMore instance with data from the ProviderData object
            Dim providerData As ProviderData = kvp.Value
            Dim userTile As New viewMore(providerData.ProviderId, startX, startY, providerData.Locations, providerData.AverageRating)

            ' Set the username for the viewMore instance
            userTile.Username = providerData.ProviderName

            ' Add event handler for TileClicked event
            AddHandler userTile.TileClicked, AddressOf viewMore_TileClicked

            ' Add the viewMore instance to the innerPanel
            innerPanel.Controls.Add(userTile)

            ' Increment i for the next iteration
            i += 1
        Next




        Me.Controls.Add(innerPanel)



    End Sub


    ' Event handler for TileClicked event
    Private Sub viewMore_TileClicked(sender As Object, e As Integer)
        ' Show the index of the clicked tile in a message box
        MessageBox.Show("Index of Clicked Tile: " & e.ToString())
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Check if "Option 3" is selected
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString() = "Filter by Location" Then
            ' Show comboBox2 if "Option 3" is selected
            ComboBox2.Visible = True
        Else
            ' Hide comboBox2 if "Option 3" is unselected
            ComboBox2.Visible = False
        End If
    End Sub
    Public Class ProviderData
        Public Property ProviderId As Integer
        Public Property ProviderName As String
        Public Property ServiceName As String
        Public Property Locations As List(Of String)
        Public Property AverageRating As Double ' Ensure this property exists

        Public Sub New(providerId As Integer, serviceName As String, providerName As String, locations As List(Of String), averageRating As Double)
            Me.ProviderId = providerId
            Me.ProviderName = providerName
            Me.ServiceName = serviceName
            Me.Locations = locations
            Me.AverageRating = averageRating
        End Sub
    End Class

End Class