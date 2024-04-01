Imports System.Collections.ObjectModel
Imports System.Configuration
Imports System.Data.SqlClient
Imports FxResources.System
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client.Cache
Public Class UserHome

    Dim map As New Dictionary(Of String, List(Of Prov_tile))()
    Dim reviews As New Dictionary(Of Int32, Tuple(Of Integer, Integer))()
    Dim rating_prov As New Dictionary(Of Int32, Double)()

    Private Sub UserHome_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Set the FlowLayoutPanel's properties
        Dim image As Image = My.Resources.Ellipse_6
        'Dim newItem As New Prov_tile(1, "Item 5", "Description 5", 4.5, image)
        'map.Add("electric", New List(Of Prov_tile))
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        'map("electric").Add(newItem)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Using connection As New SqlConnection(connectionString)
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
            Dim command As New SqlCommand("SELECT provider.*, location.* FROM provider INNER JOIN location ON provider.provider_id = location.provider_id", connection)
            For Each pair As KeyValuePair(Of Int32, Tuple(Of Integer, Integer)) In reviews
                Dim currentValue As Tuple(Of Integer, Integer) = pair.Value
                Dim rating As Double
                rating = Math.Round(currentValue.Item1 / CType(currentValue.Item2, Double), 1)
                rating_prov.Add(pair.Key, rating)
            Next
            ' Execute the SqlCommand and get a SqlDataReader
            Using reader As SqlDataReader = command.ExecuteReader()
                ' Loop through the SqlDataReader
                While reader.Read()
                    ' Get the values of the current row
                    Dim service As String = reader.GetString(reader.GetOrdinal("service"))
                    Dim loc As String = reader.GetString(reader.GetOrdinal("location"))
                    Dim name As String = reader.GetString(reader.GetOrdinal("providername"))
                    Dim provider As Int32 = reader.GetInt32(reader.GetOrdinal("provider_id"))
                    Dim rating As Double = 6.0
                    If reviews.ContainsKey(provider) Then
                        Dim currentValue As Tuple(Of Integer, Integer) = reviews(provider)
                        rating = rating_prov(provider)
                    End If
                    If map.ContainsKey(service) Then
                        map(service).Add(New Prov_tile(provider, name, loc, rating, image))
                    Else
                        map.Add(service, New List(Of Prov_tile)())
                        map(service).Add(New Prov_tile(provider, name, loc, rating, image))
                    End If
                End While
            End Using
        End Using
        For Each pair As KeyValuePair(Of String, List(Of Prov_tile)) In map
            ' Sort the list based on the values in the 'rating_prov' dictionary
            pair.Value.Sort(Function(a, b)
                                Dim aValue As Double = If(rating_prov.ContainsKey(a.Provider), rating_prov(a.Provider), -1)
                                Dim bValue As Double = If(rating_prov.ContainsKey(b.Provider), rating_prov(b.Provider), -1)
                                Return bValue.CompareTo(aValue)
                            End Function)
        Next
        ' Add more items as needed
        Dim yPos As Integer = 60 ' Initial vertical position for the first FlowLayoutPanel

        ' Iterate through the dictionary
        For Each pair As KeyValuePair(Of String, List(Of Prov_tile)) In map
            Dim label As New Label()
            label.Text = pair.Key
            label.Font = New Font(label.Font.FontFamily, 12)
            label.Location = New Point(10, yPos)
            Me.Controls.Add(label)
            yPos += (label.Height + 10)
            ' Create a new FlowLayoutPanel
            Dim flowLayoutPanel As New FlowLayoutPanel()
            flowLayoutPanel.AutoScroll = True
            flowLayoutPanel.FlowDirection = FlowDirection.LeftToRight
            flowLayoutPanel.WrapContents = False
            flowLayoutPanel.Size = New Size(Me.Size.Width, 220) ' Set the size of the FlowLayoutPanel
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
    Private Sub tileControl_Click(sender As Object, e As EventArgs)

        Dim clickedTile As Prov_tile = CType(sender, Prov_tile)
        ' Get the provider id
        Provider_ID = clickedTile.Provider
        user_template.SplitContainer1.Panel2.Controls.Clear()
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