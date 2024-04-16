Imports System.Configuration
Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports Microsoft.Data.SqlClient
Imports Microsoft.VisualBasic.ApplicationServices
Public Class user_search


    Dim reviews As New Dictionary(Of Int32, Tuple(Of Integer, Integer))()
    Dim rating_prov As New Dictionary(Of Int32, Double)()
    Dim selected_service As String = "Service"
    Dim selected_location As String = "Location"
    Dim selected_sort As String = "Sort By"
    Public binaryImageData As Byte()
    Public is_null_image As Integer = 0

    ' Define a global array to store providers
    Dim providers As New List(Of Entry)
    Dim temp_providers As New List(Of Entry)

    ' Define a structure to hold provider details
    ' author: sarg19
    Structure Entry
        Public providerID As Integer
        Public providerName As String
        Public service As String
        Public location As String
        Public cost As Integer
        Public rating As String
        Public RadioButton As RadioButton ' Added RadioButton field
    End Structure

    Private Async Sub user_search_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = user_name
        PictureBox2.Image = user_profilepic

        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Service")
        For i As Integer = 0 To service_types.Count - 1
            Dim service As String = service_types(i)
            ComboBox1.Items.Add(service)
        Next
        ComboBox1.Items.Add("Designer")
        ComboBox2.Items.Clear()
        ComboBox2.Items.Add("Location")
        For i As Integer = 0 To provider_locations.Count - 1
            Dim location As String = provider_locations(i)
            ComboBox2.Items.Add(location)
        Next
        ComboBox2.Items.Add("Tezpur")
        ComboBox3.Items.Clear()
        ComboBox3.Items.Add("Sort By")
        ComboBox3.Items.Add("Name")
        ComboBox3.Items.Add("Cost (Increasing)")
        ComboBox3.Items.Add("Cost (Decreasing)")
        ComboBox3.Items.Add("Rating")
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Await Task.WhenAll(
        Task.Run(Async Function()
                     Using connection As New SqlConnection(connectionString)
                         Try
                             Await connection.OpenAsync()
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
                             Parallel.ForEach(reviews, Sub(pair)
                                                           Dim currentValue As Tuple(Of Integer, Integer) = pair.Value
                                                           Dim rating As Double
                                                           rating = Math.Round(currentValue.Item1 / CType(currentValue.Item2, Double), 1)
                                                           rating_prov.TryAdd(pair.Key, rating)
                                                       End Sub)
                         Catch ex As Exception
                             MessageBox.Show("Error connecting to database: " & ex.Message)
                         End Try
                     End Using
                 End Function),
        Task.Run(Async Function()
                     providers.Clear()
                     Using connection As New SqlConnection(connectionString)
                         Try
                             Await connection.OpenAsync()
                             Dim command As New SqlCommand("SELECT provider.*, location.* FROM provider INNER JOIN location ON provider.provider_id = location.provider_id", connection)
                             Using reader As SqlDataReader = command.ExecuteReader()
                                 ' Loop through the SqlDataReader
                                 While reader.Read()
                                     ' Get the values of the current row
                                     Dim service As String = reader.GetString(reader.GetOrdinal("service"))
                                     Dim loc As String = reader.GetString(reader.GetOrdinal("location"))
                                     Dim name As String = reader.GetString(reader.GetOrdinal("providername"))
                                     Dim provider As Int32 = reader.GetInt32(reader.GetOrdinal("provider_id"))
                                     Dim cost As Double = reader.GetInt32(reader.GetOrdinal("cost_per_hour"))
                                     temp_providers.Add(New Entry With {.providerID = provider, .providerName = name, .service = service, .location = loc, .cost = cost})
                                 End While
                             End Using

                         Catch ex As Exception
                             MessageBox.Show("Error connecting to database: " & ex.Message)
                         End Try
                     End Using
                 End Function)
                 )
        For i As Integer = 0 To temp_providers.Count() - 1
            Dim rating As String
            If reviews.ContainsKey(temp_providers(i).providerID) Then
                Dim currentValue As Tuple(Of Integer, Integer) = reviews(temp_providers(i).providerID)
                rating = rating_prov(temp_providers(i).providerID).ToString()
            Else
                rating = "N/A"
            End If
            'providers(i).rating = rating
            providers.Add(New Entry With {.providerID = temp_providers(i).providerID, .providerName = temp_providers(i).providerName, .service = temp_providers(i).service, .location = temp_providers(i).location, .cost = temp_providers(i).cost, .rating = rating, .RadioButton = New RadioButton()})
        Next
        temp_providers.Clear()
        MakePictureBoxRound(PictureBox2)
        'LoadProviders()
        PopulateTable()
    End Sub

    Public Async Sub SimulateLoad()
        Label1.Text = user_name
        PictureBox2.Image = user_profilepic
        ComboBox1.SelectedIndex = 0
        ComboBox2.SelectedIndex = 0
        ComboBox3.SelectedIndex = 0
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Await Task.WhenAll(
        Task.Run(Async Function()
                     Using connection As New SqlConnection(connectionString)
                         Try
                             Await connection.OpenAsync()
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
                             Parallel.ForEach(reviews, Sub(pair)
                                                           Dim currentValue As Tuple(Of Integer, Integer) = pair.Value
                                                           Dim rating As Double
                                                           rating = Math.Round(currentValue.Item1 / CType(currentValue.Item2, Double), 1)
                                                           rating_prov.TryAdd(pair.Key, rating)
                                                       End Sub)
                         Catch ex As Exception
                             MessageBox.Show("Error connecting to database: " & ex.Message)
                         End Try
                     End Using
                 End Function),
        Task.Run(Async Function()
                     providers.Clear()
                     Using connection As New SqlConnection(connectionString)
                         Try
                             Await connection.OpenAsync()
                             Dim command As New SqlCommand("SELECT provider.*, location.* FROM provider INNER JOIN location ON provider.provider_id = location.provider_id", connection)
                             Using reader As SqlDataReader = command.ExecuteReader()
                                 ' Loop through the SqlDataReader
                                 While reader.Read()
                                     ' Get the values of the current row
                                     Dim service As String = reader.GetString(reader.GetOrdinal("service"))
                                     Dim loc As String = reader.GetString(reader.GetOrdinal("location"))
                                     Dim name As String = reader.GetString(reader.GetOrdinal("providername"))
                                     Dim provider As Int32 = reader.GetInt32(reader.GetOrdinal("provider_id"))
                                     Dim cost As Double = reader.GetInt32(reader.GetOrdinal("cost_per_hour"))
                                     temp_providers.Add(New Entry With {.providerID = provider, .providerName = name, .service = service, .location = loc, .cost = cost})
                                 End While
                             End Using

                         Catch ex As Exception
                             MessageBox.Show("Error connecting to database: " & ex.Message)
                         End Try
                     End Using
                 End Function)
                 )
        For i As Integer = 0 To temp_providers.Count() - 1
            Dim rating As String
            If reviews.ContainsKey(temp_providers(i).providerID) Then
                Dim currentValue As Tuple(Of Integer, Integer) = reviews(temp_providers(i).providerID)
                rating = rating_prov(temp_providers(i).providerID).ToString()
            Else
                rating = "N/A"
            End If
            'providers(i).rating = rating
            providers.Add(New Entry With {.providerID = temp_providers(i).providerID, .providerName = temp_providers(i).providerName, .service = temp_providers(i).service, .location = temp_providers(i).location, .cost = temp_providers(i).cost, .rating = rating, .RadioButton = New RadioButton()})
        Next
        temp_providers.Clear()
        MakePictureBoxRound(PictureBox2)
        'LoadProviders()
        PopulateTable()
    End Sub

    Public Function MakePictureBoxRound(pictureBox As PictureBox)
        ' Create a GraphicsPath to define a circle
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height)

        Dim image As Image
        If (is_null_image = 1) Then
            image = My.Resources.male

            ' Convert binary data back to an image
        Else

            image = user_profilepic
        End If

        pictureBox.Image = image
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom
    End Function

    ' author: sarg19
    Private Sub TextBox1_GotFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.GotFocus
        ' When the TextBox gains focus, clear the placeholder text if it's present
        If TextBox1.Text = "Search for providers by name" Then
            TextBox1.Text = ""
            TextBox1.ForeColor = Color.Black ' Set text color back to black
        End If
    End Sub

    ' author: sarg19
    Private Sub TextBox1_LostFocus(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.LostFocus
        ' When the TextBox loses focus and it's empty, display the placeholder text
        If TextBox1.Text = "" Then
            TextBox1.Text = "Search for providers by name"
            TextBox1.ForeColor = Color.Gray ' Set text color to gray for placeholder text
        End If
    End Sub

    ' function to populate the table by the data in providers list
    ' author: sarg19
    Private Sub PopulateTable()

        providersTablePanel.Controls.Clear()
        'LoadProviders()

        providersTablePanel.SuspendLayout()

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

        providersTablePanel.ResumeLayout(True)

    End Sub

    ' To load the initial providers list
    ' author: sarg19
    Private Sub LoadProviders()
        providers.Clear()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                Dim command As New SqlCommand("SELECT provider.*, location.* FROM provider INNER JOIN location ON provider.provider_id = location.provider_id", connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Loop through the SqlDataReader
                    While reader.Read()
                        ' Get the values of the current row
                        Dim service As String = reader.GetString(reader.GetOrdinal("service"))
                        Dim loc As String = reader.GetString(reader.GetOrdinal("location"))
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
                        providers.Add(New Entry With {.providerID = provider, .providerName = name, .service = service, .location = loc, .cost = cost, .rating = rating, .RadioButton = New RadioButton()})
                    End While
                End Using

            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            End Try
        End Using

    End Sub

    ' Search button: Implemented search by name for now
    ' author: sarg19
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        LoadProviders()
        If (TextBox1.Text = "" Or TextBox1.Text = "Search for providers by name") And selected_service = "Service" And selected_location = "Location" Then
            MessageBox.Show("Enter a text or select a service/location to search")
            Return
        End If
        If TextBox1.Text <> "" And TextBox1.Text <> "Search for providers by name" Then
            providers = providers.Where(Function(entry) entry.providerName.IndexOf(TextBox1.Text, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
        End If
        If selected_service <> "Service" Then
            providers = providers.Where(Function(entry) entry.service.IndexOf(selected_service, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
        End If
        If selected_location <> "Location" Then
            providers = providers.Where(Function(entry) entry.location.IndexOf(selected_location, StringComparison.OrdinalIgnoreCase) >= 0).ToList()
        End If
        If selected_sort = "Name" Then
            providers = providers.OrderBy(Function(entry) entry.providerName).ToList()
        ElseIf selected_sort = "Cost (Increasing)" Then
            providers = providers.OrderBy(Function(entry) entry.cost).ToList()
        ElseIf selected_sort = "Cost (Decreasing)" Then
            providers = providers.OrderByDescending(Function(entry) entry.cost).ToList()
        ElseIf selected_sort = "Rating" Then
            providers = providers.OrderBy(Function(entry) If(entry.rating = "N/A", Double.MaxValue, -Double.Parse(entry.rating))).ToList()
        End If
        PopulateTable()

    End Sub

    ' Book slot function: Navigate to book slots page
    ' author: sarg19
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        For Each entry As Entry In providers
            If entry.RadioButton.Checked Then
                ' Get the provider id
                Provider_ID = entry.providerID
                user_template.SplitContainer1.Panel2.Controls.Clear()
                slot_back_choice = 2
                With Book_slots
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    user_template.SplitContainer1.Panel2.Controls.Add(Book_slots)
                    .BringToFront()
                    .Show()
                End With

                Exit Sub
            End If
        Next

        MessageBox.Show("Select a provider first!")

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        selected_service = ComboBox1.SelectedItem.ToString
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        selected_location = ComboBox2.SelectedItem.ToString
    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox3.SelectedIndexChanged
        selected_sort = ComboBox3.SelectedItem.ToString
        If selected_sort = "Name" Then
            providers = providers.OrderBy(Function(entry) entry.providerName).ToList()
        ElseIf selected_sort = "Cost (Increasing)" Then
            providers = providers.OrderBy(Function(entry) entry.cost).ToList()
        ElseIf selected_sort = "Cost (Decreasing)" Then
            providers = providers.OrderByDescending(Function(entry) entry.cost).ToList()
        ElseIf selected_sort = "Rating" Then
            providers = providers.OrderBy(Function(entry) If(entry.rating = "N/A", Double.MaxValue, -Double.Parse(entry.rating))).ToList()
        End If
        PopulateTable()
    End Sub
End Class