Imports System.Drawing.Imaging
Imports System.IO
Imports Microsoft.Data.SqlClient

Public Class user_profile

    ' Connection string for connecting to the database
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
    Dim edit_enable As Boolean = False
    Private Sub user_profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        changepic_pb.Visible = False
        name_tb.ReadOnly = True
        email_tb.ReadOnly = True

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
                    name_tb.Text = reader("username").ToString()
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
                End If
            End Using
        End Using
    End Sub

    ' Update the user profile when the "Edit Profile" button is clicked
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
    ' Save the changes made to the user profile when the "Save Changes" button is clicked
    Private Sub Edit_btn_Click(sender As Object, e As EventArgs) Handles Edit_btn.Click
        If Not edit_enable Then
            phone_tb.ReadOnly = False
            phone_tb.BorderStyle = BorderStyle.Fixed3D
            changepic_pb.Visible = True
            Edit_btn.Text = "Save"

            edit_enable = True
        Else
            ' Connect to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Update the user's information in the database
                Dim sql As String = "UPDATE customer SET phone_number = @phone, profile_image = @ProfileImage WHERE user_id = @UserId"
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@phone", phone_tb.Text)

                    ' Convert the profile image to a byte array
                    Dim profileImageBytes As Byte() = Nothing
                    If profilepic_pb.Image IsNot Nothing Then
                        Using ms As New MemoryStream()
                            ' Set the position of the MemoryStream to the beginning
                            ms.Position = 0
                            profilepic_pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png)
                            profileImageBytes = ms.ToArray()
                            Try
                                ' Save the image
                                profilepic_pb.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg)
                                profileImageBytes = ms.ToArray()
                            Catch ex As Exception
                                ' Handle the exception
                                MessageBox.Show("Error saving the image: " & ex.Message)
                            End Try
                        End Using
                    End If

                    command.Parameters.AddWithValue("@ProfileImage", If(profileImageBytes IsNot Nothing, CType(profileImageBytes, Object), DBNull.Value))
                    command.Parameters.AddWithValue("@UserId", User_ID)

                    Try
                        Dim rowsAffected As Integer = command.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            MessageBox.Show("User profile updated successfully.")
                        Else
                            MessageBox.Show("No user found with the specified ID.")
                        End If
                    Catch ex As Exception
                        MessageBox.Show("Error updating user profile: " & ex.Message)
                    End Try
                End Using
            End Using

            phone_tb.ReadOnly = True
            phone_tb.BorderStyle = BorderStyle.None
            changepic_pb.Visible = False
            Edit_btn.Text = "Edit"

            edit_enable = False
        End If

    End Sub
End Class
