Imports System.Drawing.Drawing2D
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports FastReport.DataVisualization.Charting
Imports System.Net.NetworkInformation
Imports System.Threading

Public Class provider_info

    Public user As Integer = Module_global.User_ID
    Public provider As Integer = Module_global.Provider_ID
    Public ProviderName As String = "NULL"
    Public user_name As String = "NULL"
    Public binaryImageData As Byte()
    Public availability(7, 12) As Integer ' 7 days, 24 hours , Load it from database
    Public BookedList As New List(Of Integer())
    Public Avaiability_String As String = "NULL"
    Public cost_per_hour As Integer = 0
    Public is_null_image As Integer = 0

    Public Async Sub Book_slots_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run your function here
        'MessageBox.Show(1)
        Try
            ' Execute the LoadDataAsync method asynchronously
            Await LoadData()

            ' Display the result (optional)
            'MessageBox.Show($"Data loaded")
        Catch ex As Exception
            ' MessageBox.Show($"An error occurred: {ex.Message}")
        Finally
            ' Hide the progress bar after the operation completes or fails
        End Try

    End Sub

    Private Async Function LoadData() As Task
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Dim providerQuery As String = "SELECT providername,working_hour,cost_per_hour FROM provider WHERE provider_id = @Provider_ID"
        Dim userQuery As String = "SELECT username,profile_image FROM customer WHERE user_id = @User_ID"
        ' Use Task.WhenAll to run both queries in parallel
        Await Task.WhenAll(
        Task.Run(Async Function()
                     ' Execute provider_query
                     Using connection As New SqlConnection(connectionString)
                         Using command As New SqlCommand(providerQuery, connection)
                             ' Add parameters
                             command.Parameters.AddWithValue("@Provider_ID", provider)
                             Await connection.OpenAsync()

                             ' Execute the select command
                             Dim reader As SqlDataReader = Await command.ExecuteReaderAsync()

                             While Await reader.ReadAsync()
                                 ' Retrieve provider details
                                 ProviderName = reader.GetString(0)
                                 Avaiability_String = reader.GetString(1)
                                 cost_per_hour = reader.GetInt32(2)
                             End While
                         End Using
                     End Using
                 End Function),
        Task.Run(Async Function()
                     ' Execute user_query
                     Using connection As New SqlConnection(connectionString)
                         Using command As New SqlCommand(userQuery, connection)
                             ' Add parameters
                             command.Parameters.AddWithValue("@User_ID", user)
                             Await connection.OpenAsync()

                             ' Execute the select command
                             Dim reader As SqlDataReader = Await command.ExecuteReaderAsync()

                             While Await reader.ReadAsync()
                                 ' Retrieve user details
                                 user_name = reader.GetString(0)
                                 If Not reader.IsDBNull(reader.GetOrdinal("profile_image")) Then
                                     Dim imageData As Byte() = DirectCast(reader("profile_image"), Byte())
                                     binaryImageData = imageData
                                 Else
                                     is_null_image = 1
                                 End If
                             End While
                         End Using
                     End Using
                 End Function)
    )
        'MessageBox.Show(user_name)

        ' Update UI with retrieved data
        'Provider_Name_Loc_Lbl.Text = ProviderName
        'Username.Text = user_name

        'Dim task1 As Task = MakePictureBoxRound(Profile_Pic)
        'Dim task2 As Task = Make_Schedule_Table()

        ' Await completion of both tasks concurrently
        'Await Task.WhenAll(task1, task2)

    End Function

    Private Sub SplitContainer1_Panel1_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel1.Paint

    End Sub

    Private Sub providerProfilePicture_Click(sender As Object, e As EventArgs)

    End Sub
End Class