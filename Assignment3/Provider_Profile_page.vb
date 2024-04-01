Imports FxResources.System

Public Class Provider_Profile_page
    ' Define an event to be raised when the edit profile button is clicked
    Public Event EditProfileClicked As EventHandler

    ' Handle the click event of the "Edit_profile_btn" button
    Private Sub Edit_profile_btn_Click(sender As Object, e As EventArgs) Handles Edit_profile_btn.Click, Edit_profile_btn.Click
        ' Raise the EditProfileClicked event
        RaiseEvent EditProfileClicked(Me, EventArgs.Empty)
    End Sub

    Public editprovprof As Boolean = False
    Private Sub Provider_Profile_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Name_label.Text = "Pratham Goyal"
        email_label.Text = "Pratham@gmail.com"
        Service_label.Text = "Decorator"
        location_label.Text = "guwahati,delhi"
        rate_label.Text = "20L/hour"

        Dim Rating As Double = 2.5
        Dim integerPart As Integer = CInt(Math.Truncate(Rating))
        Dim remainder As Double = Rating - integerPart
        For i As Integer = 0 To 4
            If i < integerPart Then
                ' This star is fully filled
                SetStarImage(i, My.Resources.star_filled)
            ElseIf i = integerPart AndAlso remainder >= 0.75 Then
                ' More than three-quarters filled, display filled star
                SetStarImage(i, My.Resources.star_filled)
            ElseIf i = integerPart AndAlso remainder >= 0.25 Then
                ' More than one-quarter filled, display half-filled star
                SetStarImage(i, My.Resources.star_empty1)
            Else
                ' Less than one-quarter filled, display empty star
                SetStarImage(i, My.Resources.star_half_filled)
            End If
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

    Private Sub SetStarImage(index As Integer, image As Image)
        Select Case index
            Case 0
                PictureBox2.Image = image
            Case 1
                PictureBox3.Image = image
            Case 2
                PictureBox4.Image = image
            Case 3
                PictureBox5.Image = image
            Case 4
                PictureBox6.Image = image
        End Select
    End Sub
End Class