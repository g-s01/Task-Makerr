Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
Imports Microsoft.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Imports Org.BouncyCastle.Crypto.Asymmetric.AsymmetricRsaKey
Imports System.Configuration
Imports System.Drawing
Imports System.IO
Imports System.Text
Imports System.Windows.Forms.AxHost
Public Class ViewAllUser

    ' Create an inner panel
    Dim innerPanel As New Panel()
    ' Define button size and spacing
    Dim buttonWidth = 350
    Dim buttonSpacing = 35
    Dim buttonHeight = 150
    Dim load_once = 0
    Dim providers As New Dictionary(Of Integer, ProviderData)()

    ' Function to initialize or reset the form
    Private Sub InitializeForm()
        ' Clear inner panel and reset integer variables
        ClearInnerPanel()
        ResetIntegerVariables()

        ' Empty the providers dictionary
        providers.Clear()
    End Sub

    ' Function to clear all components inside inner panel
    Private Sub ClearInnerPanel()
        innerPanel.Controls.Clear()
    End Sub

    ' Function to reset integer variables
    Private Sub ResetIntegerVariables()
        buttonWidth = 350
        buttonSpacing = 35
        buttonHeight = 150
        load_once = 0
    End Sub




    Public Sub ReloadData()

        InitializeForm()
        load_once = 1
        user_template.SplitContainer1.Panel2.Controls.Clear()
        With Me
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(Me)
            .BringToFront()
            .Show()
        End With
        '   MessageBox.Show("inside reload")
        LoadTasks()
        '  MessageBox.Show("ViewAllUser reloaded!")
        load_once = 0
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        InitializeForm()
        load_once = 1
        user_template.SplitContainer1.Panel2.Controls.Clear()
        With Me
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(Me)
            .BringToFront()
            .Show()
        End With
        '   MessageBox.Show("inside loading")
        LoadTasks()
        load_once = 0



    End Sub

    Private Sub LoadTasks()
        'MessageBox.Show(Module_global.serviceType & " vamos")

        Label3.Text = Module_global.serviceType

        Me.Controls.Add(Username)





        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Sorted by Rating")
        ComboBox1.Items.Add("A-Z by Provider")
        Dim filter_by_loc As String = "Filter by Location"
        ComboBox1.Items.Add(filter_by_loc)



        ' Set the default selected item for comboBox1
        ComboBox1.SelectedIndex = 0 ' This will select the first item ("Option 1")

        ' Hide comboBox2 initially
        ComboBox2.Visible = False



        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

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

                    End Using
                Catch ex As Exception
                    MessageBox.Show("Error reading data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End Using
        End Using






        Username.Text = Module_global.user_name
        PictureBox1.Image = Module_global.user_profilepic
        '   If Module_global.user_profilepic IsNot Nothing Then
        '       PictureBox1.Image = Module_global.user_profilepic
        '   End If


        ' Create a HashSet to store unique locations
        Dim uniqueLocations As New HashSet(Of String)

        ' Iterate through each entry in the providers dictionary
        For Each kvp As KeyValuePair(Of Integer, ProviderData) In providers
            ' Get the ProviderData object
            Dim providerData As ProviderData = kvp.Value

            ' Iterate through each location in the ProviderData.Locations list
            For Each location As String In providerData.Locations
                ' Add the location to the HashSet (automatically handles duplicates)
                uniqueLocations.Add(location)
            Next
        Next

        ' Convert the HashSet to an array of strings (for ComboBox)
        Dim locationsArray() As String = uniqueLocations.ToArray()

        ' Add the locationsArray to the ComboBox
        ComboBox2.Items.AddRange(locationsArray)







        ' Set inner panel properties
        innerPanel.Location = New Point(27, 140) ' Fixed location
        'innerPanel.AutoScroll = False ' Disable scrolling in inner panel
        innerPanel.Size = New Size(1000, 1000)

        ' Set panel properties to enable scrolling
        innerPanel.AutoScroll = True ' Enable auto-scrolling



        innerPanel.AutoScrollMinSize = New Size(1000, 500 + (buttonHeight + buttonSpacing) * 1.0 * providers.Count) ' Adjust scroll area size as needed

        Dim photo As Image = My.Resources.User_Logo
        Dim originalImage As Image = My.Resources.prov ' Load the original image
        Dim profile_photo As New Bitmap(originalImage, New Size(100, 100)) ' Resize the image to the desired size

        ' Sort providers dictionary by AverageRating in descending order
        Dim sortedProviders = providers.OrderByDescending(Function(kvp) kvp.Value.AverageRating)

        ' Loop through sorted providers and display in tiles
        Dim i As Integer = 0
        For Each kvp As KeyValuePair(Of Integer, ProviderData) In sortedProviders
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
        ' MessageBox.Show("Index of Clicked Tile: " & e.ToString())
        ' Get the provider id
        Book_slots.Dispose()
        Module_global.Provider_ID = e
        user_template.SplitContainer1.Panel2.Controls.Clear()
        slot_back_choice = 3
        With Book_slots
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(Book_slots)
            .BringToFront()
            .Show()
        End With
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

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Clear existing controls from the displayPanel
        ComboBox2.Text = "Select Location"
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString() = "Filter by Location" Then
            ' Show comboBox2 if "Option 3" is selected
            ComboBox2.Visible = True
        Else
            ' Hide comboBox2 if "Option 3" is unselected
            ComboBox2.Visible = False
        End If

        ' Get unique locations from the retrieved providers
        Dim uniqueLocations As New HashSet(Of String)()
        For Each kvp As KeyValuePair(Of Integer, ProviderData) In providers
            For Each location As String In kvp.Value.Locations
                uniqueLocations.Add(location)
            Next
        Next

        ' Convert the HashSet to an array of strings (for ComboBox)
        Dim locationsArray() As String = uniqueLocations.ToArray()

        ' Add the locationsArray to ComboBox2
        ComboBox2.Items.Clear() ' Clear existing items before adding new ones
        ComboBox2.Items.AddRange(locationsArray)

        ' Display provider tiles in innerPanel
        Dim sortedProviders = providers.OrderByDescending(Function(kvp) kvp.Value.AverageRating)
        Dim i As Integer = 0

        If ComboBox1.SelectedIndex = 0 Then
            innerPanel.Controls.Clear()
            For Each kvp As KeyValuePair(Of Integer, ProviderData) In sortedProviders
                Dim currentRow As Integer = i \ 2 ' Integer division to determine the row
                Dim currentColumn As Integer = i Mod 2 ' Modulus to determine the column
                Dim startX As Integer = currentColumn * (buttonWidth + buttonSpacing)
                Dim startY As Integer = currentRow * (buttonHeight + buttonSpacing)

                Dim providerData As ProviderData = kvp.Value
                Dim userTile As New viewMore(providerData.ProviderId, startX, startY, providerData.Locations, providerData.AverageRating)
                userTile.Username = providerData.ProviderName
                AddHandler userTile.TileClicked, AddressOf viewMore_TileClicked
                innerPanel.Controls.Add(userTile)

                i += 1
            Next

        ElseIf ComboBox1.SelectedIndex = 1 Then
            ' Clear existing controls from the innerPanel
            innerPanel.Controls.Clear()

            ' Sort providers by username (ProviderName)
            Dim sortedProviders1 = providers.OrderBy(Function(kvp) kvp.Value.ProviderName)

            ' Display sorted providers in innerPanel
            Dim i1 As Integer = 0

            For Each kvp As KeyValuePair(Of Integer, ProviderData) In sortedProviders1
                Dim currentRow As Integer = i1 \ 2 ' Integer division to determine the row
                Dim currentColumn As Integer = i1 Mod 2 ' Modulus to determine the column
                Dim startX As Integer = currentColumn * (buttonWidth + buttonSpacing)
                Dim startY As Integer = currentRow * (buttonHeight + buttonSpacing)

                Dim providerData As ProviderData = kvp.Value
                Dim userTile As New viewMore(providerData.ProviderId, startX, startY, providerData.Locations, providerData.AverageRating)
                userTile.Username = providerData.ProviderName
                AddHandler userTile.TileClicked, AddressOf viewMore_TileClicked
                innerPanel.Controls.Add(userTile)

                i1 += 1
            Next

        Else

        End If


    End Sub


    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        ' Clear existing controls from the innerPanel
        innerPanel.Controls.Clear()

        ' Get the selected location from ComboBox2
        If ComboBox2.SelectedIndex <> -1 Then
            Dim selectedLocation As String = ComboBox2.SelectedItem.ToString()

            ' Filter providers based on the selected location
            Dim filteredProviders = providers.Where(Function(kvp) kvp.Value.Locations.Contains(selectedLocation)).ToList()

            ' Display filtered providers in innerPanel
            Dim i As Integer = 0

            For Each kvp As KeyValuePair(Of Integer, ProviderData) In filteredProviders
                Dim currentRow As Integer = i \ 2 ' Integer division to determine the row
                Dim currentColumn As Integer = i Mod 2 ' Modulus to determine the column
                Dim startX As Integer = currentColumn * (buttonWidth + buttonSpacing)
                Dim startY As Integer = currentRow * (buttonHeight + buttonSpacing)

                Dim providerData As ProviderData = kvp.Value
                Dim userTile As New viewMore(providerData.ProviderId, startX, startY, providerData.Locations, providerData.AverageRating)
                userTile.Username = providerData.ProviderName
                AddHandler userTile.TileClicked, AddressOf viewMore_TileClicked
                innerPanel.Controls.Add(userTile)

                i += 1
            Next
        End If
    End Sub




    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Navigate to another page here
        Dim clickedButton = CType(sender, Button)
        user_template.SplitContainer1.Panel2.Controls.Clear()
        If UserHome IsNot Nothing Then
            With UserHome
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(UserHome)
                .ReloadData()
                .BringToFront()
                .Show()
            End With
        Else
            With UserHome
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(UserHome)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub
End Class