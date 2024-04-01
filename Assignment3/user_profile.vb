Imports Microsoft.Data.SqlClient

Public Class user_profile

    ' Connection string for connecting to the database
    Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

    Private Sub user_profile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Load user data from the database when the form loads
        LoadUserData()
        ' Load user rating when the form loads
        LoadUserRating()
    End Sub

    Private Sub LoadUserData()
        ' Load user data from the database
        Try
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Example query to retrieve user data
                Dim sql As String = "SELECT username, email FROM customer WHERE user_id = @UserId"
                Using command As New SqlCommand(sql, connection)
                    ' Assuming you have a UserId to identify the user
                    ' Replace @UserId with the actual user ID
                    command.Parameters.AddWithValue("@UserId", User_ID) ' Change 1 to the actual user ID
                    Dim reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        TextBox1.Text = reader("username").ToString()
                        TextBox2.Text = reader("email").ToString()
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading user data: " & ex.Message)
        End Try
    End Sub

    Private Sub LoadUserRating()
        ' Load user's rating from the database
        ' Example code to retrieve user's rating from the database
        ' Replace this with your actual database query

        Try
            ' Your code to retrieve user's rating from the database
            ' and set the stars accordingly
        Catch ex As Exception
            MessageBox.Show("An error occurred while loading user's rating: " & ex.Message)
        End Try
    End Sub

    ' Update the user profile when the "Edit Profile" button is clicked
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Enable editing of textboxes and show the "Save Changes" button
        TextBox1.ReadOnly = False
        TextBox2.ReadOnly = True
        Button2.Visible = True
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
    ' Save the changes made to the user profile when the "Save Changes" button is clicked
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' Connect to the database
            Using connection As New SqlConnection(connectionString)
                connection.Open()

                ' Update the user's information in the database
                Dim sql As String = "UPDATE customer SET username = @Username, email = @Email WHERE user_id = @UserId"
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddWithValue("@Username", TextBox1.Text)
                    command.Parameters.AddWithValue("@Email", TextBox2.Text)
                    ' Assuming you have a UserId to identify the user
                    ' Replace @UserId with the actual user ID
                    command.Parameters.AddWithValue("@UserId", User_ID) ' Change 1 to the actual user ID
                    Dim rowsAffected As Integer = command.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        MessageBox.Show("User profile updated successfully.")
                    Else
                        MessageBox.Show("No user found with the specified ID.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("An error occurred while updating user profile: " & ex.Message)
        End Try

        ' Disable editing of textboxes and hide the "Save Changes" button
        TextBox1.ReadOnly = True
        TextBox2.ReadOnly = True
        Button2.Visible = False
    End Sub
End Class
