Imports System.Drawing.Drawing2D
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports FastReport.DataVisualization.Charting
Imports iText.Forms.Xfdf

Public Class Reschedule_Slots
    Public user As Integer = Module_global.User_ID
    Public provider As Integer = Module_global.Provider_ID
    Public ProviderName As String = "NULL"
    Public user_name As String = "NULL"
    Public binaryImageData As Byte()
    Public availability(7, 23) As Integer ' 7 days, 24 hours , Load it from database
    Public BookedList As New List(Of Integer())
    Public PreviouslyBookedList As New List(Of Integer())
    Public Avaiability_String As String = "NULL"
    Public Sub Reschedule_slots_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run your function here
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Dim provider_query As String = "SELECT providername,working_hour FROM provider WHERE provider_id = @Provider_ID"
        Dim user_query As String = "SELECT username,profile_image FROM customer WHERE user_id = @User_ID"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(provider_query, connection)
                ' Add parameters
                command.Parameters.AddWithValue("@Provider_ID", provider)
                connection.Open()

                ' Execute the select command
                Dim reader As SqlDataReader = command.ExecuteReader()

                While reader.Read()
                    ' Retrieve the provider name from the reader
                    ProviderName = reader.GetString(0)
                    Avaiability_String = reader.GetString(1)
                    ' MessageBox.Show(Avaiability_String)
                    ' Do something with the retrieved values, such as displaying them in a MessageBox
                End While

            End Using
        End Using
        Provider_Name_Loc_Lbl.Text = ProviderName + " > " + " Reschedule Slots"
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(user_query, connection)
                ' Add parameters
                connection.Open()
                command.Parameters.AddWithValue("@User_ID", user)


                ' Execute the select command
                Dim reader As SqlDataReader = command.ExecuteReader()

                While reader.Read()
                    ' Retrieve the provider name from the reader
                    user_name = reader.GetString(0)
                    Dim imageData As Byte() = DirectCast(reader("profile_image"), Byte())
                    binaryImageData = imageData
                    ' Convert byte array to image

                    Username.Text = user_name
                    ' Do something with the retrieved values, such as displaying them in a MessageBox
                End While

            End Using
        End Using

        MakePictureBoxRound(Profile_Pic)
        Make_Schedule_Table()

    End Sub

    Private Sub Make_Schedule_Table()
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Dim currentDayOfWeek As DayOfWeek = DateTime.Today.DayOfWeek

        ' Calculate the index starting from Monday (Monday = 0, Sunday = 6)
        Dim indexFromMonday As Integer = CType(currentDayOfWeek, Integer) - CType(DayOfWeek.Monday, Integer)

        ' If index is negative, adjust it to be positive by adding 7
        If indexFromMonday < 0 Then
            indexFromMonday += 7
        End If
        Dim currentDate As DateTime = DateTime.Now

        ' Set the time to 12:00 AM
        Dim startDate As DateTime = New DateTime(currentDate.Year, currentDate.Month, currentDate.Day, 0, 0, 0)

        For i As Integer = 0 To 7
            Dim nextDate As DateTime = startDate.AddDays(i).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
            Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
            For j As Integer = 0 To 12
                If (Avaiability_String.ElementAt(((i + indexFromMonday) * 13 + j) Mod 84) = "1") Then
                    availability(i, j) = 1
                End If

            Next
        Next
        Dim selectQuery As String = "SELECT user_id, provider_id, time, status, dates, location FROM deals WHERE deal_id = @deal_id"

        ' Define the DELETE query to delete the deal
        Dim deleteQuery As String = "DELETE FROM deals WHERE deal_id = @deal_id"
        Dim deleteSchedule As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"

        ' Create a connection to the database
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Execute the SELECT query to fetch deal information
            Using selectCommand As New SqlCommand(selectQuery, connection)
                ' Add parameters to the SELECT command
                selectCommand.Parameters.AddWithValue("@deal_id", Module_global.DealID_Reschedule)

                ' Execute the SELECT command and obtain a SqlDataReader
                Using reader As SqlDataReader = selectCommand.ExecuteReader()
                    ' Check if the reader has rows
                    If reader.HasRows Then
                        ' Iterate through the results and process each row
                        While reader.Read()
                            ' Retrieve data for each row
                            Dim userId As Integer = reader.GetInt32(0) ' Assuming user_id is an integer
                            Dim providerId As Integer = reader.GetInt32(1) ' Assuming provider_id is an integer
                            Dim slots As String = reader.GetString(2) ' Assuming time is a datetime
                            Dim status As String = reader.GetInt32(3) ' Assuming status is a string
                            Dim dates As DateTime = reader.GetDateTime(4) ' Assuming dates is a datetime
                            'Dim location As String = reader.GetString(5) ' Assuming location is a string
                            ' Find the difference by subtracting one date from the other
                            Dim differenceInDays As Integer = (DateTime.Today - startDate.Date).Days
                            For I As Integer = differenceInDays * 13 To slots.Length - 1
                                Dim bit As Char = slots(I)

                                ' Check if the bit is '1' (indicating working day)
                                If bit = "1"c Then
                                    ' Calculate the day index based on the current day index and the index i
                                    Dim dayIndex As Integer = I / 13 - differenceInDays
                                    Dim slot As Integer = I Mod 13

                                    availability(dayIndex, slot) = 3
                                    PreviouslyBookedList.Add({dayIndex, slot})

                                End If
                            Next
                            ' Process the data as needed

                        End While
                    Else
                        Console.WriteLine("No data found for the specified deal ID.")
                    End If
                End Using
            End Using

            ' Execute the DELETE query to delete the deal
            ' Using deleteCommand As New SqlCommand(deleteQuery, connection)
            ' Add parameters to the DELETE command
            'deleteCommand.Parameters.AddWithValue("@deal_id", Module_global.DealID_Reschedule)

            ' Execute the DELETE command
            'Dim rowsAffected As Integer = deleteCommand.ExecuteNonQuery()

            ' Check if any rows were deleted
            'If rowsAffected > 0 Then
            'MessageBox.Show("Deleted Successfully!")
            'Else
            'MessageBox.Show("Error!")
            'End If
            'End Using



        End Using

        '' Now we have stored the previously booked slots in the PreviouslyBookedList
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()
            For Each pair In PreviouslyBookedList
                Dim deleteCommand As New SqlCommand(deleteSchedule, connection)
                deleteCommand.Parameters.AddWithValue("@user_id", Module_global.User_ID)
                deleteCommand.Parameters.AddWithValue("@provider_id", Module_global.Provider_ID)
                Dim nextDate As DateTime = DateTime.Today.Date.AddDays(pair(0)).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
                Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                deleteCommand.Parameters.AddWithValue("@time", formattedDate)
                deleteCommand.Parameters.AddWithValue("@slots", pair(1))
                Dim rowsAffected As Integer = deleteCommand.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    Console.WriteLine("Deleted")
                Else
                    MessageBox.Show("Error!")
                End If
                ' Execute the DELETE query to delete the Schedules
            Next
        End Using
        Dim query As String = "SELECT user_id, time, slots FROM schedule WHERE provider_id = @providerId"


        ' Create a connection to the database
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()

            ' Create a SqlCommand object with the query and connection
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the command
                command.Parameters.AddWithValue("@providerId", Module_global.Provider_ID)

                ' Execute the command and obtain a SqlDataReader
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Iterate through the results and process each appointment
                    While reader.Read()
                        ' Retrieve data for each appointment
                        Dim userId As Integer = reader.GetInt32(0) ' Assuming userId is an integer
                        Dim appointmentDateTime As DateTime = reader.GetDateTime(1) ' Assuming day is a datetime
                        Dim slot As Integer = reader.GetInt32(2) ' Assuming slot is an integer

                        Dim TodayDate As DateTime = DateTime.Today

                        ' Specify the target date
                        Dim targetDate As DateTime = TodayDate.Date

                        ' Calculate the number of days between the current date and the target date
                        Dim daysDifference As Integer = (appointmentDateTime - targetDate).Days
                        If (daysDifference < 0) Then
                            Continue While
                        End If
                        ' Process the appointment data as needed
                        If userId = Module_global.User_ID Then
                            availability(daysDifference, slot) = 2
                        Else
                            availability(daysDifference, slot) = 0
                        End If

                    End While
                End Using
            End Using
        End Using

        ' MessageBox.Show("-1")'
        ' Populate the schedule table
        PopulateScheduleTable()
    End Sub
    Private Sub PopulateScheduleTable()
        ' Clear existing controls in the table layout panel
        ' MessageBox.Show("0")
        Schedule_Table.Controls.Clear()
        'MessageBox.Show("1")
        ' Clear any existing column and row styles
        Schedule_Table.ColumnStyles.Clear()
        Schedule_Table.RowStyles.Clear() '''
        ' MessageBox.Show("2")

        ' Calculate percentage for each column and row
        Dim columnPercentage As Single = 100.0F / Schedule_Table.ColumnCount
        Dim rowPercentage As Single = 100.0F / Schedule_Table.RowCount

        ' Set equal column and row styles
        For i As Integer = 0 To Schedule_Table.ColumnCount + 1
            Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, columnPercentage))
        Next

        For i As Integer = 0 To Schedule_Table.RowCount + 1
            Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Percent, rowPercentage))
        Next
        Schedule_Table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        For i As Integer = 0 To 6
            Dim dayLabel As New Label()
            dayLabel.Text = DateTime.Today.AddDays(i).ToString("ddd, dd MMM")
            dayLabel.AutoSize = False ' Disable auto-size
            dayLabel.Dock = DockStyle.Fill
            dayLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            Schedule_Table.Controls.Add(dayLabel, 0, i + 1) ' Add to the first row, starting from column index 1
        Next

        ' Add labels for 12-hour format time from 9:00 AM to 9:00 PM
        For i As Integer = 9 To 21
            Dim timeLabel As New Label()
            Dim hour As Integer = If(i > 12, i Mod 12, i) ' Convert to 12-hour format
            Dim suffix As String = If(i >= 12, "PM", "AM") ' Determine AM/PM suffix
            timeLabel.Text = hour.ToString("00") & ":00 " & suffix
            timeLabel.AutoSize = False ' Disable auto-size
            timeLabel.Dock = DockStyle.Fill
            timeLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            Schedule_Table.Controls.Add(timeLabel, i - 8, 0) ' Add to the first column, starting from row index 1
        Next
        For Each control As Control In Schedule_Table.Controls
            Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(control)
            If cellPosition.Column = 0 Or cellPosition.Row = 0 Then
                control.BackColor = ColorTranslator.FromHtml("#F58CD7")
            End If
        Next
        ' Add buttons for each time slot
        For i As Integer = 0 To 6
            For j As Integer = 0 To 12
                Dim btn As New Button()
                btn.Text = ""
                btn.Dock = DockStyle.Fill

                If availability(i, j) = 1 Then
                    btn.BackColor = Color.LightGreen ' Available
                ElseIf availability(i, j) = 2 Then
                    btn.BackColor = Color.DarkGreen ' Unavailable
                ElseIf availability(i, j) = 3 Then
                    btn.BackColor = Color.Gray
                End If
                btn.Margin = New Padding(0)
                btn.FlatStyle = FlatStyle.Flat ' Set the button to have a flat appearance
                Schedule_Table.Controls.Add(btn, j + 1, i + 1)
                AddHandler btn.Click, AddressOf TimeSlot_Click
            Next
        Next
        For Each pair In PreviouslyBookedList
            BookedList.Add(pair)
        Next
    End Sub

    Private Sub TimeSlot_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(btn)

        Dim dayIndex As Integer = cellPosition.Row - 1
        Dim hourIndex As Integer = cellPosition.Column - 1

        If availability(dayIndex, hourIndex) = 1 Or availability(dayIndex, hourIndex) = 3 Then
            'MessageBox.Show("Hi")
            Dim targetPair As Integer() = {dayIndex, hourIndex}

            ' Perform linear search
            Dim foundIndex As Integer = -1
            For i As Integer = 0 To BookedList.Count - 1
                If BookedList(i)(0) = targetPair(0) AndAlso BookedList(i)(1) = targetPair(1) Then
                    foundIndex = i
                    Exit For ' Found the target pair, exit the loop
                End If
            Next

            If (foundIndex = -1) Then
                Dim result As DialogResult = MessageBox.Show("Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo)

                If result = DialogResult.Yes Then
                    ' User clicked Yes button
                    btn.BackColor = Color.Gray
                    BookedList.Add(targetPair)
                Else
                    ' User clicked No button or closed the dialog
                    Console.WriteLine("User clicked No.")
                End If
                ' Schedule available, allow booking or do something else
            Else
                BookedList.RemoveAt(foundIndex)
                MessageBox.Show("Slot removed")
                btn.BackColor = Color.LightGreen
            End If

        Else

            ' Schedule unavailable
            MessageBox.Show($"This time slot is already booked for {DateTime.Today.AddDays(dayIndex).ToString("ddd, dd MMM")} at {(hourIndex + 9).ToString("00")}:00.")

        End If
    End Sub

    Public Sub MakePictureBoxRound(pictureBox As PictureBox)
        ' Create a GraphicsPath to define a circle
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height)

        ' Set the PictureBox's region to the circle defined by the GraphicsPath
        pictureBox.Region = New Region(path)
        'Change according to the user after fetching from the database


        ' Convert binary data back to an image
        Dim image As Image = ImageFromBinary(binaryImageData)

        pictureBox.Image = image
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom
    End Sub
    Function ImageFromBinary(ByVal binaryData As Byte()) As Image
        Using ms As New MemoryStream(binaryData)
            Return Image.FromStream(ms)
        End Using
    End Function

    Private Sub DisplayMessageOnLoad()
        ' Your function code here
        MessageBox.Show("This message appears when the form loads.")
    End Sub

    Private Sub Book_Btn_Click(sender As Object, e As EventArgs) Handles Book_Btn.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Add parameters

            Dim rowsAffected As Integer = 0
            For Each slot As Integer() In BookedList
                Dim provider_query As String = "INSERT INTO schedule (user_id,provider_id,slots,time) VALUES (@User_ID,@Provider_ID,@Slot,@Time);" ' Add the query here
                Using command As New SqlCommand(provider_query, connection)
                    command.Parameters.AddWithValue("@User_ID", user)
                    command.Parameters.AddWithValue("@Provider_ID", provider)
                    command.Parameters.AddWithValue("@Slot", slot(1))
                    command.Parameters.AddWithValue("@Time", DateTime.Today.AddDays(slot(0)))
                    rowsAffected = command.ExecuteNonQuery()
                    If rowsAffected = 0 Then
                        MessageBox.Show("Some unusual error happened.")
                        Exit For
                    End If
                End Using
            Next
            If rowsAffected > 0 Then
                MessageBox.Show("Data ins.rted successfully.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Make_Schedule_Table()

            Else
                MessageBox.Show("Please select some slots to book!")
            End If
            ' Update deals table
            ' Calculate Reschedule cost and display to the user

        End Using
    End Sub

End Class