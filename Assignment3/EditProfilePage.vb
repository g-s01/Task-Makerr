Public Class EditProfilePage

    Dim code As Integer
    Dim location_array(13) As Boolean
    Dim locations() As String = {"Guwahati", "Tezpur", "Jorhat", "Changsari", "Sualkuchi", "Palasbari", "Maliata", "Panbazar", "Panikhati", "Amsing", "Jorabat", "Lalmati", "Kahikuchi"}

    Private Sub Provider_Signup_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        For i As Integer = 0 To 12
            location_array(i) = False
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
    End Sub

    Private Sub Changepic_pb_Click(sender As Object, e As EventArgs) Handles changepic_pb.Click
        Dim openFileDialog As New OpenFileDialog With {
            .Filter = "Image Files (*.jpg; *.jpeg; *.png; *.gif)|*.jpg; *.jpeg; *.png; *.gif"
        }

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            ' Set the selected image to the PictureBox
            profilepic_pb.Image = Image.FromFile(openFileDialog.FileName)
        End If
    End Sub

    Private Sub Back_btn_Click(sender As Object, e As EventArgs) Handles back_btn.Click
        Me.Close()
    End Sub

    Private Sub Save_btn_Click(sender As Object, e As EventArgs) Handles save_btn.Click, save_btn.Click
        Dim timeslotbit = ""
        MessageBox.Show("")
    End Sub

End Class