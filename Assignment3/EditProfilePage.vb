Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports System.Text

Public Class EditProfilePage

    Dim code As Integer
    Dim location_array(13) As Boolean
    Dim providerID As Integer = Module_global.Provider_ID

    Private Sub Provider_Signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

        ' Set default values for location_array
        For i As Integer = 0 To 12
            location_array(i) = False
        Next

        ' Populate location_checklistbox
        For Each location As String In Module_global.provider_locations
            location_checklistbox.Items.Add(location)
        Next

        ' Add checkboxes to the table
        For row As Integer = 0 To 6
            For col As Integer = 1 To 12
                Dim checkBox As New CheckBox()
                checkBox.Name = "cb_" & row.ToString() & "_" & col.ToString()
                checkBox.Dock = DockStyle.Fill
                checkBox.Padding = New Padding(10, 0, 0, 0)
                slot_matrix_tablelayout.Controls.Add(checkBox, col, row)
            Next
        Next

        ' Fetch provider data from the database
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()

            ' Fetch existing provider data
            Dim query As String = "SELECT * FROM provider WHERE provider_id = @ProviderID"
            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@ProviderID", providerID)
                Dim reader As SqlDataReader = sqlCommand.ExecuteReader()

                If reader.Read() Then
                    ' Populate UI controls with fetched data
                    name_label.Text = reader("providername").ToString()
                    email_label.Text = reader("email").ToString()
                    contactnumber_tb.Text = reader("phone_number").ToString()
                    Dim service As String = reader("service").ToString()
                    If Not servicetype_combox.Items.Contains(service) Then
                        servicetype_combox.Items.Add(service)
                    End If
                    servicetype_combox.SelectedItem = service
                    cos_tb.Text = reader("cost_per_hour").ToString()

                    ' Load profile image if available
                    If Not reader.IsDBNull(reader.GetOrdinal("profile_image")) Then
                        Dim profileImageBytes As Byte() = DirectCast(reader("profile_image"), Byte())
                        Using ms As New MemoryStream(profileImageBytes)
                            profilepic_pb.Image = Image.FromStream(ms)
                        End Using
                    End If

                    ' Fetch the working_hour binary string from the reader
                    Dim workingHour As String = reader("working_hour").ToString()

                    ' Close the initial reader before opening a new one
                    reader.Close()

                    ' Fetch locations associated with the provider from the location table
                    Dim locationQuery As String = "SELECT location FROM location WHERE provider_id = @ProviderID"
                    Using locationCommand As New SqlCommand(locationQuery, sqlConnection)
                        locationCommand.Parameters.AddWithValue("@ProviderID", providerID)
                        Dim locationReader As SqlDataReader = locationCommand.ExecuteReader()

                        ' Mark the locations as checked in the checklistbox
                        While locationReader.Read()
                            Dim locationName As String = locationReader("location").ToString()
                            Dim index As Integer = location_checklistbox.FindString(locationName)
                            If index <> -1 Then
                                location_checklistbox.SetItemChecked(index, True)
                            End If
                        End While

                        locationReader.Close()
                    End Using

                    If String.IsNullOrEmpty(workingHour) Then
                        ' Handle the case where workingHour is NULL or empty
                        ' For example, you can set all checkboxes to unchecked
                        For Each control As Control In slot_matrix_tablelayout.Controls
                            If TypeOf control Is CheckBox Then
                                Dim checkBox As CheckBox = DirectCast(control, CheckBox)
                                checkBox.Checked = False
                            End If
                        Next
                    Else
                        ' Mark the checkboxes in the slot_matrix_tablelayout based on the working_hour bits
                        Dim bitIndex As Integer = 0
                        For row As Integer = 0 To 6
                            For col As Integer = 1 To 12
                                ' Convert the binary string to an integer to check the bit at the current index
                                Dim bit As Integer = Integer.Parse(workingHour.Substring(bitIndex, 1))
                                ' Get the checkbox at the current position
                                Dim checkBox As CheckBox = CType(slot_matrix_tablelayout.GetControlFromPosition(col, row), CheckBox)
                                ' Check the checkbox if the bit is 1
                                checkBox.Checked = (bit = 1)
                                ' Move to the next bit
                                bitIndex += 1
                            Next
                        Next
                    End If

                End If

                reader.Close()
            End Using
        End Using
    End Sub

    Private Sub Changepic_pb_Click(sender As Object, e As EventArgs) Handles changepic_pb.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                ' Set the selected image to the PictureBox
                profilepic_pb.Image = Image.FromFile(openFileDialog.FileName)
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading the image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        provider_template.ShowForm(New Provider_Profile_page())
        Me.Close()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click
        ' Get the values from the UI controls
        Dim providerName As String = name_label.Text
        Dim email As String = email_label.Text
        Dim phoneNumber As String = contactnumber_tb.Text
        Dim service As String = servicetype_combox.SelectedItem.ToString()
        Dim costPerHour As String = cos_tb.Text

        ' Validate phone number
        If phoneNumber.Length <> 10 OrElse Not IsNumeric(phoneNumber) Then
            MessageBox.Show("Please enter a valid 10-digit phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Validate cost per hour
        Dim costPerHourDecimal As Decimal
        If Not Decimal.TryParse(costPerHour, costPerHourDecimal) OrElse costPerHourDecimal < 0 Then
            MessageBox.Show("Please enter a valid non-negative cost per hour.", "Invalid Cost Per Hour", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Convert the profile image to a byte array
        Dim profileImageBytes As Byte() = Nothing

        ' Check if the image is not null and is a valid format
        If profilepic_pb.Image IsNot Nothing AndAlso
    (profilepic_pb.Image.RawFormat.Guid = System.Drawing.Imaging.ImageFormat.Jpeg.Guid OrElse
     profilepic_pb.Image.RawFormat.Guid = System.Drawing.Imaging.ImageFormat.Png.Guid) Then

            Try
                Using ms As New MemoryStream()
                    ' Save the image to the memory stream
                    profilepic_pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)

                    ' Convert the image to a byte array
                    profileImageBytes = ms.ToArray()
                End Using
            Catch ex As Exception
                ' Handle any exceptions that occur during image saving
                MessageBox.Show("Error saving image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        ElseIf profilepic_pb.Image Is Nothing Then
            'just Null
        Else
            ' Handle the case where the image is null or in an unsupported format
            MessageBox.Show("Invalid or unsupported image format", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

        ' Construct the binary string for the working hours
        Dim workingHour As New StringBuilder()
        For row As Integer = 0 To 6
            For col As Integer = 1 To 12
                Dim checkBox As CheckBox = CType(slot_matrix_tablelayout.GetControlFromPosition(col, row), CheckBox)
                If checkBox.Checked Then
                    workingHour.Append("1")
                Else
                    workingHour.Append("0")
                End If
            Next
        Next

        ' Update the provider table and location table
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "UPDATE provider SET providername = @ProviderName, email = @Email, phone_number = @PhoneNumber, service = @Service, cost_per_hour = @CostPerHour, profile_image = CONVERT(varbinary(max), @ProfileImage), working_hour = @WorkingHour WHERE provider_id = @ProviderID"

        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()

            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@ProviderName", providerName)
                sqlCommand.Parameters.AddWithValue("@Email", email)
                sqlCommand.Parameters.AddWithValue("@PhoneNumber", phoneNumber)
                sqlCommand.Parameters.AddWithValue("@Service", service)
                sqlCommand.Parameters.AddWithValue("@CostPerHour", costPerHour)
                sqlCommand.Parameters.AddWithValue("@ProfileImage", If(profileImageBytes IsNot Nothing, CType(profileImageBytes, Object), DBNull.Value))
                sqlCommand.Parameters.AddWithValue("@WorkingHour", workingHour.ToString())
                sqlCommand.Parameters.AddWithValue("@ProviderID", providerID)

                Dim rowsAffected As Integer = sqlCommand.ExecuteNonQuery()
            End Using

            ' Retrieve the list of locations currently stored in the database for the provider
            Dim existingLocations As New List(Of String)()
            Dim existingLocationQuery As String = "SELECT location FROM location WHERE provider_id = @ProviderID"
            Using existingLocationCommand As New SqlCommand(existingLocationQuery, sqlConnection)
                existingLocationCommand.Parameters.AddWithValue("@ProviderID", providerID)
                Dim existingLocationReader As SqlDataReader = existingLocationCommand.ExecuteReader()
                While existingLocationReader.Read()
                    existingLocations.Add(existingLocationReader("location").ToString())
                End While
                existingLocationReader.Close()
            End Using

            ' Compare the existing locations with the checked items in the location_checklistbox
            For Each existingLocation As String In existingLocations
                If Not location_checklistbox.CheckedItems.Contains(existingLocation) Then
                    ' Delete the location from the database
                    Dim deleteLocationQuery As String = "DELETE FROM location WHERE provider_id = @ProviderID AND location = @LocationName"
                    Using deleteLocationCommand As New SqlCommand(deleteLocationQuery, sqlConnection)
                        deleteLocationCommand.Parameters.AddWithValue("@ProviderID", providerID)
                        deleteLocationCommand.Parameters.AddWithValue("@LocationName", existingLocation)
                        Dim deletedRows As Integer = deleteLocationCommand.ExecuteNonQuery()
                    End Using
                End If
            Next

            ' Insert or update the checked locations in the location table
            For Each item As String In location_checklistbox.CheckedItems
                Dim locationQuery As String = "IF EXISTS (SELECT 1 FROM location WHERE provider_id = @ProviderID AND location = @LocationName) " &
                                  "UPDATE location SET provider_id = @ProviderID, location = @LocationName WHERE provider_id = @ProviderID AND location = @LocationName " &
                                  "ELSE " &
                                  "INSERT INTO location (provider_id, location) VALUES (@ProviderID, @LocationName)"

                Using locationCommand As New SqlCommand(locationQuery, sqlConnection)
                    locationCommand.Parameters.AddWithValue("@ProviderID", providerID)
                    locationCommand.Parameters.AddWithValue("@LocationName", item)

                    Dim locationRowsAffected As Integer = locationCommand.ExecuteNonQuery()
                End Using
            Next
        End Using

        MessageBox.Show("Your information updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        provider_template.ShowForm(New Provider_Profile_page())
        Me.Close()
    End Sub


End Class
