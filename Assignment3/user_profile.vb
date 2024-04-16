Imports System.Drawing.Imaging
Imports System.IO
Imports System.Runtime.InteropServices
Imports Microsoft.Data.SqlClient

Public Class user_profile

    ' Connection string for connecting to the database
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    Dim edit_enable As Boolean = False

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            ReloadData()
        End If
    End Sub

    Private Sub ReloadData()
        changepic_pb.Visible = False
        name_tb.ReadOnly = True
        email_tb.ReadOnly = True

        Try
            ' Load user data from the database when the form loads
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Example query to retrieve user data
                Dim sql As String = "SELECT * FROM customer WHERE user_id = @UserId"
                Using command As New SqlCommand(sql, connection)
                    ' Replace @UserId with the actual user ID
                    command.Parameters.AddWithValue("@UserId", User_ID)
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        Dim username As String = reader("username").ToString()
                        name_tb.Text = username
                        email_tb.Text = reader("email").ToString()
                        If reader("phone_number") Is DBNull.Value Then
                            phone_tb.Text = "----------"
                        Else
                            phone_tb.Text = reader("phone_number").ToString()
                        End If
                        ' Load profile image if available
                        If Not reader.IsDBNull(reader.GetOrdinal("profile_image")) Then
                            Dim profileImageBytes As Byte() = DirectCast(reader("profile_image"), Byte())
                            Using ms As New MemoryStream(profileImageBytes)
                                profilepic_pb.Image = Image.FromStream(ms)
                            End Using
                        End If
                        ' Display greeting with dynamic font size
                        ' Assuming the greeting_label contains the text "Hello, "
                        Dim greetingText As String = "Hello, "

                        ' Get the default font size of the label
                        Dim defaultFontSize As Single = greeting_label.Font.Size

                        ' Modify the font size for the username
                        Dim usernameFontSize As Single = defaultFontSize * 5 / 3

                        ' Create a font with the modified size
                        Dim usernameFont As New Font(greeting_label.Font.FontFamily, usernameFontSize)

                        ' Set the label text with modified font size for the username
                        greeting_label.Text = greetingText & username
                        greeting_label.Font = usernameFont
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading user profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub Changepic_pb_Click(sender As Object, e As EventArgs) Handles changepic_pb.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.bmp;*.jpg;*.jpeg;*.png;*.gif;*.tif;*.tiff"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Try
                ' Load the selected image into a temporary PictureBox for compression
                Dim tempPictureBox As New PictureBox()
                tempPictureBox.Image = Image.FromFile(openFileDialog.FileName)

                ' Compress the image
                Dim compressedImage As Image = CompressImageIfNeeded(tempPictureBox.Image)

                ' Set the compressed image to the main PictureBox
                profilepic_pb.Image = compressedImage
            Catch ex As Exception
                MessageBox.Show("An error occurred while loading the image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End If
    End Sub

    ' Method to compress an image if its size is greater than 1MB
    Private Function CompressImageIfNeeded(originalImage As Image) As Image
        Try
            ' Check if image size is already less than 1MB
            Dim imageSize As Long = GetImageSize(originalImage)
            If imageSize <= 1024 * 1024 Then
                ' Image size is already less than 1MB, no need to compress
                Return originalImage
            End If

            ' Image size is greater than 1MB, compress it
            Dim quality As Single = 0.1F ' Adjust the quality level as needed (0 to 1)

            Dim encoderParams As New EncoderParameters(1)
            Dim qualityParam As New EncoderParameter(Imaging.Encoder.Quality, CType(quality * 100, Int32))

            Dim jpgEncoder As ImageCodecInfo = GetEncoderInfo(ImageFormat.Jpeg)

            encoderParams.Param(0) = qualityParam

            Dim memoryStream As New MemoryStream()
            originalImage.Save(memoryStream, jpgEncoder, encoderParams)

            Return Image.FromStream(memoryStream)
        Catch ex As Exception
            MessageBox.Show("An error occurred while compressing the image: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return Nothing
        End Try
    End Function

    ' Method to get the size of an image in bytes
    Private Function GetImageSize(image As Image) As Long
        Using ms As New MemoryStream()
            image.Save(ms, ImageFormat.Jpeg)
            Return ms.Length
        End Using
    End Function

    ' Method to get JPEG encoder information
    Private Function GetEncoderInfo(format As ImageFormat) As ImageCodecInfo
        Dim codecs As ImageCodecInfo() = ImageCodecInfo.GetImageEncoders()
        For Each codec As ImageCodecInfo In codecs
            If codec.FormatID = format.Guid Then
                Return codec
            End If
        Next
        Return Nothing
    End Function




    ' Save the changes made to the user profile when the "Save Changes" button is clicked
    Private Sub Edit_btn_Click(sender As Object, e As EventArgs) Handles Edit_btn.Click
        If Not edit_enable Then
            phone_tb.ReadOnly = False
            phone_tb.BorderStyle = BorderStyle.Fixed3D
            changepic_pb.Visible = True
            Edit_btn.Text = "Save"

            edit_enable = True
        Else

            Dim phoneNumber As String = phone_tb.Text
            ' Validate phone number
            If phoneNumber.Length <> 10 OrElse Not IsNumeric(phoneNumber) Then
                MessageBox.Show("Please enter a valid 10-digit phone number.", "Invalid Phone Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            Try
                ' Connect to the database
                Using connection As New SqlConnection(connectionString)
                    connection.Open()

                    ' Update the user's information in the database
                    Dim sql As String = "UPDATE customer SET phone_number = @phone, profile_image = @ProfileImage WHERE user_id = @UserId"
                    Using command As New SqlCommand(sql, connection)
                        command.Parameters.AddWithValue("@phone", phone_tb.Text)

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
                        command.Parameters.AddWithValue("@ProfileImage", If(profileImageBytes IsNot Nothing, CType(profileImageBytes, Object), DBNull.Value))
                        command.Parameters.AddWithValue("@UserId", User_ID)

                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show("User profile updated successfully.")
                            Module_global.user_profilepic = profilepic_pb.Image
                        Else
                            MessageBox.Show("No user found with the specified ID.")
                        End If
                    End Using
                End Using
            Catch ex As Exception
                MessageBox.Show("Error updating user profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try

            phone_tb.ReadOnly = True
            phone_tb.BorderStyle = BorderStyle.None
            changepic_pb.Visible = False
            Edit_btn.Text = "Edit"

            edit_enable = False
        End If
    End Sub

    Private Sub greeting_label_Click(sender As Object, e As EventArgs) Handles greeting_label.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs)

    End Sub
End Class
