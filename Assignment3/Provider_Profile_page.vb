﻿Imports System.Data.SqlClient
Imports Microsoft.Data.SqlClient

Public Class Provider_Profile_page
    ' Define an event to be raised when the edit profile button is clicked
    Public Event EditProfileClicked As EventHandler

    ' Handle the click event of the "Edit_profile_btn" button
    Private Sub Edit_profile_btn_Click(sender As Object, e As EventArgs) Handles Edit_profile_btn.Click
        ' Raise the EditProfileClicked event
        RaiseEvent EditProfileClicked(Me, EventArgs.Empty)
    End Sub

    Public editprovprof As Boolean = False
    Private Sub Provider_Profile_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Add checkboxes to the table
        For row As Integer = 0 To 6
            For col As Integer = 1 To 12
                Dim checkBox As New CheckBox()
                checkBox.Name = "cb_" & row.ToString() & "_" & col.ToString()
                checkBox.Dock = DockStyle.Fill
                checkBox.Padding = New Padding(10, 0, 0, 0)
                checkBox.Enabled = False ' Disable the checkbox
                slot_matrix_tablelayout.Controls.Add(checkBox, col, row)
            Next
        Next

        Dim providerID As Integer = Module_global.Provider_ID ' Replace 1 with the actual provider ID

        ' Connection string
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

        ' SQL query to fetch provider information
        Dim query As String = "SELECT * FROM provider WHERE provider_id = @ProviderID"

        ' Execute SQL query to fetch provider information
        Using connection As New SqlConnection(connectionString)
            connection.Open()

            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ProviderID", providerID)

                Using reader As SqlDataReader = command.ExecuteReader()
                    If reader.Read() Then
                        ' Populate UI controls with fetched data
                        Name_label.Text = reader("providername").ToString()
                        email_label.Text = reader("email").ToString()
                        Service_label.Text = reader("service").ToString()
                        rate_label.Text = reader("cost_per_hour").ToString()
                        contact_label.Text = reader("phone_number").ToString()

                        ' Set star rating (Assuming it's fetched from the database)
                        ' Dim rating As Double = Convert.ToDouble(reader("rating"))
                        SetStarRating(3.5)

                        ' Load working hours into the slot_matrix_tablelayout
                        Dim workingHour As String = reader("working_hour").ToString()
                        LoadWorkingHours(workingHour)
                    End If
                End Using
            End Using
        End Using


    End Sub

    Private Sub SetStarRating(rating As Double)
        Dim integerPart As Integer = CInt(Math.Truncate(rating))
        Dim remainder As Double = rating - integerPart
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

    Private Sub LoadWorkingHours(workingHour As String)
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
            ' Pad the workingHour string with zeros to make its length divisible by 84
            Dim paddedWorkingHour As String = workingHour.PadRight(84, "0"c)

            ' Mark the checkboxes in the slot_matrix_tablelayout based on the working_hour bits
            Dim bitIndex As Integer = 0
            For row As Integer = 0 To 6
                For col As Integer = 1 To 12
                    ' Convert the binary string to an integer to check the bit at the current index
                    Dim bit As Integer = Integer.Parse(paddedWorkingHour.Substring(bitIndex, 1))
                    ' Get the checkbox at the current position
                    Dim checkBox As CheckBox = CType(slot_matrix_tablelayout.GetControlFromPosition(col, row), CheckBox)
                    ' Check if checkBox is not Nothing before accessing its properties
                    If checkBox IsNot Nothing Then
                        ' Check the checkbox if the bit is 1
                        checkBox.Checked = (bit = 1)
                    End If
                    ' Move to the next bit
                    bitIndex += 1
                Next
            Next
        End If
    End Sub




End Class
