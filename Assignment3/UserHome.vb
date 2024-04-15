Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports FxResources.System
Imports Microsoft.Data.SqlClient
Imports System.Collections.Concurrent
Imports System.Threading.Tasks
Imports Microsoft.Identity.Client.Cache
Imports Microsoft.VisualBasic.ApplicationServices
Imports System.Configuration.Provider
Public Class UserHome

    Dim map As New Dictionary(Of String, List(Of Prov_tile))()
    Dim reviews As New Dictionary(Of Int32, Tuple(Of Integer, Integer))()
    'Dim rating_prov As New Dictionary(Of Int32, Double)()      'provider id,rating
    ' Dictionary to store provider locations
    Dim provider_locations As New Dictionary(Of Integer, List(Of String))
    ' Dictionary to store provider keys
    Dim provider_keys As New Dictionary(Of Integer, String)
    ' Dictionary to store provider services
    Dim provider_service As New Dictionary(Of Integer, String)
    Dim buttonLoc As Integer
    Dim user_name As String
    Dim rating_prov As New ConcurrentDictionary(Of Int32, Double)()

    Private Async Sub UserHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set the FlowLayoutPanel's properties
        Dim image As Image = My.Resources.Ellipse_6

        buttonLoc = Me.Width - 110
        'Dim newItem As New Prov_tile(1, "Item 5", "Description 5", 4.5, image)
        'map.Add("electric", New List(Of Prov_tile))
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        Await Task.WhenAll(
        Task.Run(Async Function()
                     ' Execute provider_query
                     Using connection As New SqlConnection(connectionString)
                         Await connection.OpenAsync()
                         Dim command_rev As New SqlCommand("SELECT review.rating, deals.provider_id FROM review INNER JOIN deals ON review.deal_id = deals.deal_id", connection)
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
                         Parallel.ForEach(reviews, Sub(pair)
                                                       Dim currentValue As Tuple(Of Integer, Integer) = pair.Value
                                                       Dim rating As Double
                                                       rating = Math.Round(currentValue.Item1 / CType(currentValue.Item2, Double), 1)
                                                       rating_prov.TryAdd(pair.Key, rating)
                                                   End Sub)
                     End Using
                 End Function),
        Task.Run(Async Function()
                     ' Execute user_query
                     Using connection As New SqlConnection(connectionString)
                         ' Put the code for the second query here
                         Await connection.OpenAsync()
                         Dim command_user As New SqlCommand("SELECT customer.user_id,customer.username FROM customer ", connection)
                         Using reader As SqlDataReader = command_user.ExecuteReader()
                             While reader.Read()
                                 Dim user As Int32 = reader.GetInt32(reader.GetOrdinal("user_id"))
                                 Dim username As String = reader.GetString(reader.GetOrdinal("username"))
                                 If user = Module_global.User_ID Then
                                     user_name = username
                                 End If
                             End While
                         End Using
                     End Using
                 End Function),
        Task.Run(Async Function()
                     ' Execute user_query
                     Using connection As New SqlConnection(connectionString)
                         Await connection.OpenAsync()
                         Dim command As New SqlCommand("SELECT provider.provider_id, provider.providername, provider.service ,location.location FROM provider INNER JOIN location ON provider.provider_id = location.provider_id", connection)
                         Using reader As SqlDataReader = command.ExecuteReader()
                             ' Loop through the SqlDataReader
                             While reader.Read()
                                 ' Get the values of the current row
                                 Dim service As String = reader.GetString(reader.GetOrdinal("service"))
                                 Dim loc As String = reader.GetString(reader.GetOrdinal("location"))
                                 Dim name As String = reader.GetString(reader.GetOrdinal("providername"))
                                 Dim provider As Int32 = reader.GetInt32(reader.GetOrdinal("provider_id"))

                                 If provider_locations.ContainsKey(provider) Then
                                     provider_locations(provider).Add(loc)
                                 Else
                                     provider_locations.Add(provider, New List(Of String) From {loc})
                                 End If
                                 If Not provider_service.ContainsKey(provider) Then
                                     provider_service(provider) = service
                                 End If
                                 If Not provider_keys.ContainsKey(provider) Then
                                     provider_keys(provider) = name
                                 End If
                             End While
                         End Using
                     End Using
                 End Function)
)
        For Each kvp As KeyValuePair(Of Integer, List(Of String)) In provider_locations
            Dim provider As Integer = kvp.Key
            Dim locations As String = String.Join(", ", kvp.Value)
            Dim name As String = provider_keys(provider)
            Dim service As String = provider_service(provider)
            Dim rating As Double = 6.0

            ' Get rating if available
            If rating_prov.ContainsKey(provider) Then
                rating = rating_prov(provider)
            End If

            ' Add tile to map
            If map.ContainsKey(service) Then
                map(service).Add(New Prov_tile(provider, name, locations, rating, image))
            Else
                map.Add(service, New List(Of Prov_tile) From {New Prov_tile(provider, name, locations, rating, image)})
            End If
        Next
        Username.Text = user_name
        For Each pair As KeyValuePair(Of String, List(Of Prov_tile)) In map
            ' Sort the list based on the values in the 'rating_prov' dictionary
            pair.Value.Sort(Function(a, b)
                                Dim aValue As Double = If(rating_prov.ContainsKey(a.Provider), rating_prov(a.Provider), -1)
                                Dim bValue As Double = If(rating_prov.ContainsKey(b.Provider), rating_prov(b.Provider), -1)
                                Return bValue.CompareTo(aValue)
                            End Function)
        Next
        ' Add more items as needed
        Dim yPos As Integer = 70 ' Initial vertical position for the first FlowLayoutPanel

        ' Iterate through the dictionary
        For Each pair As KeyValuePair(Of String, List(Of Prov_tile)) In map
            Dim label As New Label()
            label.Text = pair.Key
            label.Font = New Font(label.Font.FontFamily, 12)
            label.Location = New Point(10, yPos)
            Me.Controls.Add(label)
            Dim btnViewMore As New Button()
            btnViewMore.Text = "View All"
            btnViewMore.Size = New Size(100, 30)
            btnViewMore.Location = New Point(buttonLoc, yPos)
            btnViewMore.Tag = pair.Key
            ' Inside the UserHome_Load method, after creating the btnViewMore button
            AddHandler btnViewMore.Click, AddressOf btnViewMore_Click
            Me.Controls.Add(btnViewMore)
            yPos += (label.Height + 10)
            ' Create a new FlowLayoutPanel
            Dim flowLayoutPanel As New FlowLayoutPanel()
            flowLayoutPanel.AutoScroll = True
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight
            flowLayoutPanel.WrapContents = False
            flowLayoutPanel.Size = New Size(Me.Size.Width, 250) ' Set the size of the FlowLayoutPanel
            flowLayoutPanel.Location = New Point(10, yPos) ' Set the position of the FlowLayoutPanel

            For Each tile As Prov_tile In pair.Value
                Dim tileControl As New Prov_tile(tile.Provider, tile.ProviderName, tile.Loc, tile.Rating, tile.ItemImage)
                AddHandler tileControl.Click, AddressOf tileControl_Click
                flowLayoutPanel.Controls.Add(tileControl)
            Next
            Me.Controls.Add(flowLayoutPanel)
            ' Update the vertical position for the next FlowLayoutPanel
            yPos += flowLayoutPanel.Height + 20
        Next

        ' Create tile controls for each item
    End Sub

    Private Sub btnViewMore_Click(sender As Object, e As EventArgs)
        ' Navigate to another page here
        Dim clickedButton As Button = CType(sender, Button)
        Module_global.serviceType = CType(clickedButton.Tag, String)
        user_template.SplitContainer1.Panel2.Controls.Clear()

        If ViewAllUser IsNot Nothing Then
            With ViewAllUser
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(ViewAllUser)
                .ReloadData()
                .BringToFront()
                .Show()
            End With
        Else
            With ViewAllUser
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(ViewAllUser)
                .BringToFront()
                .Show()
            End With
        End If

    End Sub

    Private Sub tileControl_Click(sender As Object, e As EventArgs)

        Dim clickedTile As Prov_tile = CType(sender, Prov_tile)
        ' Get the provider id
        Module_global.Provider_ID = clickedTile.Provider
        user_template.SplitContainer1.Panel2.Controls.Clear()
        slot_back_choice = 1
        With Book_slots
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(Book_slots)
            .BringToFront()
            .Show()
        End With

    End Sub

End Class