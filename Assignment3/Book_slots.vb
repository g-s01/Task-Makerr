Imports System.Drawing.Drawing2D
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports FastReport.DataVisualization.Charting
Imports System.Net.NetworkInformation
Imports System.Threading

Public Class Book_slots
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
    ' Store the user home form
    'Public UserHome As New U'serHome()
    Public Async Sub Book_slots_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run your function here
        'MessageBox.Show(1)
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
        'MessageBox.Show(Module_global.Provider_ID)
        Try
            ' Execute the LoadDataAsync method asynchronously
            Await LoadData()

            ' Display the result (optional)
            'MessageBox.Show($"Data loaded")
        Catch ex As Exception
            ' MessageBox.Show($"An error occurred: {ex.Message}")
        Finally
            ' Hide the progress bar after the operation completes or fails
            ProgressBar1.Visible = False
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
        Provider_Name_Loc_Lbl.Text = ProviderName
        Username.Text = user_name

        Dim task1 As Task = MakePictureBoxRound(Profile_Pic)
        Dim task2 As Task = Make_Schedule_Table()

        ' Await completion of both tasks concurrently
        Await Task.WhenAll(task1, task2)

    End Function

    Private Sub ShowLoadingIndicator()
        ' Display the loading indicator (progress bar)
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee ' Use Marquee style for indeterminate progress
    End Sub

    Private Sub HideLoadingIndicator()
        ' Hide the loading indicator (progress bar)
        ProgressBar1.Visible = False
    End Sub

    Private Async Function Make_Schedule_Table() As Task
        'MessageBox.Show("-2")
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
        'MessageBox.Show(5)
        For i As Integer = 0 To 6
            Dim nextDate As DateTime = startDate.AddDays(i).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
            Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
            For j As Integer = 0 To 11
                If (Avaiability_String.ElementAt(((i + indexFromMonday) * 12 + j) Mod 84) = "1") Then
                    availability(i, j) = 1
                End If

            Next
        Next

        'Dim selectQuery As String = "SELECT user_id, provider_id, time, status, dates, location FROM deals WHERE deal_id = @deal_id"

        ' Define the DELETE query to delete the deal
        'String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"



        '' Now we have stored the previously booked slots in the PreviouslyBookedList

        Dim query As String = "SELECT user_id, time, slots FROM schedule WHERE provider_id = @providerId"

        'MessageBox.Show(Avaiability_String.Length)
        ' Create a connection to the database
        'MessageBox.Show(6)
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
        'MessageBox.Show(7)
        Try
            Await PopulateScheduleTableAsync()
            MessageBox.Show("Schedule populated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            ' Perform cleanup tasks or handle completion/error scenarios (optional)
        End Try
    End Function
    Private Async Function PopulateScheduleTableAsync() As Task

        Schedule_Table.Controls.Clear()
        Schedule_Table.ColumnStyles.Clear()
        Schedule_Table.RowStyles.Clear()

        ' Add column styles for time slots
        Dim columnPercentage As Single = 100.0F / Schedule_Table.ColumnCount
        Dim rowPercentage As Single = 100.0F / Schedule_Table.RowCount
        'MessageBox.Show(8)
        ' Set equal column and row styles
        For i As Integer = 0 To Schedule_Table.ColumnCount + 1
            Schedule_Table.ColumnStyles.Add(New ColumnStyle(SizeType.Percent, columnPercentage))
        Next

        For i As Integer = 0 To Schedule_Table.RowCount + 1
            Schedule_Table.RowStyles.Add(New RowStyle(SizeType.Percent, rowPercentage))
        Next
        Schedule_Table.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single
        ' Create and add labels for days of the week asynchronously
        For i As Integer = 0 To 6
            Dim dayLabel As New Label()
            dayLabel.Text = DateTime.Today.AddDays(i).ToString("ddd, dd MMM")
            dayLabel.AutoSize = False ' Disable auto-size
            dayLabel.Dock = DockStyle.Fill
            dayLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            Schedule_Table.Controls.Add(dayLabel, 0, i + 1) ' Add to the first row, starting from column index 1
        Next
        'MessageBox.Show(9)
        ' Add labels for 12-hour format time from 9:00 AM to 9:00 PM
        For i As Integer = 9 To 20
            Dim timeLabel As New Label()
            Dim hour As Integer = If(i > 12, i Mod 12, i) ' Convert to 12-hour format
            Dim suffix As String = If(i >= 12, "PM", "AM") ' Determine AM/PM suffix
            timeLabel.Text = hour.ToString("00") & ":00 " & suffix
            timeLabel.AutoSize = False ' Disable auto-size
            timeLabel.Dock = DockStyle.Fill
            timeLabel.Font = New Font("Arial", 12, FontStyle.Bold)
            Schedule_Table.Controls.Add(timeLabel, i - 8, 0) ' Add to the first column, starting from row index 1
        Next
        Schedule_Table.SuspendLayout()
        ' Create and add buttons for time slots asynchronously
        For i As Integer = 0 To 6
            For j As Integer = 0 To 11
                Dim btn As New Button()
                btn.Dock = DockStyle.Fill
                btn.FlatStyle = FlatStyle.Flat
                btn.Margin = New Padding(0)
                btn.BackColor = If(availability(i, j) = 1, Color.LightGreen, If(availability(i, j) = 2, Color.DarkGreen, Color.Transparent))
                Await AddControlToScheduleTableAsync(btn, i + 1, j + 1)
            Next
        Next

        Schedule_Table.ResumeLayout(True)
    End Function


    Private Async Function AddControlToScheduleTableAsync(control As Control, column As Integer, row As Integer) As Task
        ' Use Control.Invoke to update the UI on the main UI thread
        Schedule_Table.Invoke(Sub()
                                  Schedule_Table.Controls.Add(control, row, column)
                              End Sub)
        AddHandler control.Click, AddressOf TimeSlot_Click
    End Function


    Private Sub TimeSlot_Click(sender As Object, e As EventArgs)

        Dim btn As Button = DirectCast(sender, Button)
        Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(btn)

        Dim dayIndex As Integer = cellPosition.Row - 1
        Dim hourIndex As Integer = cellPosition.Column - 1
        Dim currentDate As DateTime = DateTime.Now

        ' Example: Attempt to book for 3 days after current day and 3 hours from 9 am
        Dim daysAfterToday As Integer = dayIndex
        Dim hoursFromNineAm As Integer = hourIndex

        ' Calculate target date and time
        Dim targetDate As DateTime = currentDate.AddDays(daysAfterToday).Date.AddHours(9 + hoursFromNineAm)

        ' Check if the target date and time is in the future
        If targetDate <= currentDate Then
            MessageBox.Show("Please select a future time slot!")
            Exit Sub
        End If




        If availability(dayIndex, hourIndex) = 1 Then
                ' MessageBox.Show("Hi")
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
            ElseIf availability(dayIndex, hourIndex) = 2 Then
                MessageBox.Show($"You have already booked this slot({DateTime.Today.AddDays(dayIndex).ToString("ddd, dd MMM")} at {(hourIndex + 9).ToString("00")}:00.")
            Else
                ' Schedule unavailable
                MessageBox.Show($"This time slot is already booked for {DateTime.Today.AddDays(dayIndex).ToString("ddd, dd MMM")} at {(hourIndex + 9).ToString("00")}:00.")

            End If

    End Sub

    Public Function MakePictureBoxRound(pictureBox As PictureBox) As Task
        ' Create a GraphicsPath to define a circle
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height)

        ' Set the PictureBox's region to the circle defined by the GraphicsPath
        pictureBox.Region = New Region(path)
        'Change according to the user after fetching from the database
        Dim image As Image
        If (is_null_image = 1) Then
            image = My.Resources.male

            ' Convert binary data back to an image
        Else

            image = ImageFromBinary(binaryImageData)
        End If

        pictureBox.Image = image
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom
    End Function
    Function ImageFromBinary(ByVal binaryData As Byte()) As Image
        Using ms As New MemoryStream(binaryData)
            Return Image.FromStream(ms)
        End Using
    End Function



    Public variableChanged As New ManualResetEvent(False)
    ' Variable to monitor for changes
    Public myVariable As Integer = 0
    Private Async Function WaitForVariableChangeOrTimeoutAsync(timeoutMilliseconds As Integer) As Task
        ' Wait for either the variable to change or the timeout to elapse
        Await Task.WhenAny(Task.Delay(timeoutMilliseconds), Task.Run(Sub() variableChanged.WaitOne()))

        ' After the wait, you can check if the variable changed or timeout happened
        If myVariable <> 0 Then
            ' The variable changed
            Console.WriteLine("Payment Successful")

        Else
            ' Timeout occurred
            MessageBox.Show("Timeout occurred or some error occured during payment")
            If payments IsNot Nothing AndAlso Not payments.IsDisposed Then
                payments.Close()
            End If
            If otp_auth IsNot Nothing AndAlso Not otp_auth.IsDisposed Then
                otp_auth.Close()
            End If

        End If
    End Function

    Private Async Sub Book_Btn_Click(sender As Object, e As EventArgs) Handles Book_Btn.Click
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Add parameters

            Dim rowsAffected As Integer = 0
            Dim Total_slots As Integer = 0
            Dim NewlyBookedList As New List(Of Integer())
            Dim f As Integer = 1
            For Each slot As Integer() In BookedList
                Total_slots += 1
                Dim slotDate As DateTime = DateTime.Today.AddDays(slot(0))
                Dim provider_query_check As String = "SELECT COUNT(*) FROM schedule WHERE user_id = @User_ID AND provider_id = @Provider_ID AND slots = @Slot AND time = @Time;"

                Using command_check As New SqlCommand(provider_query_check, connection)
                    command_check.Parameters.AddWithValue("@User_ID", user)
                    command_check.Parameters.AddWithValue("@Provider_ID", provider)
                    command_check.Parameters.AddWithValue("@Slot", slot(1))
                    command_check.Parameters.AddWithValue("@Time", slotDate)

                    Dim count As Integer = Convert.ToInt32(command_check.ExecuteScalar())
                    'MessageBox.Show(count)
                    If count = 0 Then
                        ' Slot does not exist, proceed with INSERT
                        Dim provider_query_insert As String = "INSERT INTO schedule (user_id, provider_id, slots, time) VALUES (@User_ID, @Provider_ID, @Slot, @Time);"

                        Using command_insert As New SqlCommand(provider_query_insert, connection)
                            command_insert.Parameters.AddWithValue("@User_ID", user)
                            command_insert.Parameters.AddWithValue("@Provider_ID", provider)
                            command_insert.Parameters.AddWithValue("@Slot", slot(1))
                            command_insert.Parameters.AddWithValue("@Time", slotDate)

                            Try
                                rowsAffected = command_insert.ExecuteNonQuery()

                                If rowsAffected > 0 Then
                                    NewlyBookedList.Add(slot)
                                Else
                                    MessageBox.Show("Failed to book slot.")
                                End If
                            Catch ex As Exception
                                MessageBox.Show("Error occurred while booking slot: " & ex.Message)
                            End Try
                        End Using
                    Else
                        f = 0
                        GoTo Roll_back
                        Continue For
                    End If
                End Using
            Next
            If rowsAffected > 0 Then
                Dim Total_cost As Integer = (cost_per_hour * Total_slots) / 2
                Module_global.cost_of_booking = Total_cost
                payments.CostOfService = Total_cost
                payments.ProviderEmailID = ProviderName
                MessageBox.Show($"Data inserted successfully, you need to pay a total of {Total_cost}Rs.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                variableChanged.Reset()
                myVariable = 0
                payments.Show()
                Await WaitForVariableChangeOrTimeoutAsync(900000000)
                If (Module_global.payment_successful = 1) Then
                    ' MessageBox.Show("ASFN")
                    Dim InsertQuery As String = "INSERT INTO deals (deal_id,user_id,provider_id,time,status,dates,location,deal_amount) VALUES ((SELECT ISNULL(MAX(deal_id), 0) + 1 FROM deals),@User_ID,@Provider_ID,@Time,@Status,@Dates,@Location,@TotalCost);"
                    Dim zeros As String = New String("0"c, 84)
                    Dim charArray() As Char = zeros.ToCharArray()

                    ' Set specific characters to '1' at desired indices

                    For Each Pair In BookedList
                        charArray(Pair(0) * 12 + Pair(1)) = "1"c
                    Next

                    ' Convert the character array back to a string
                    Dim result As New String(charArray)

                    Using command As New SqlCommand(InsertQuery, connection)
                        command.Parameters.AddWithValue("@User_ID", user)
                        command.Parameters.AddWithValue("@Provider_ID", provider)
                        command.Parameters.AddWithValue("@Time", result)
                        command.Parameters.AddWithValue("@Status", 1)
                        command.Parameters.AddWithValue("@Dates", DateTime.Now())
                        command.Parameters.AddWithValue("@Location", Address_TxtBox.Text)
                        command.Parameters.AddWithValue("@TotalCost", Total_cost * 2)
                        rowsAffected = command.ExecuteNonQuery()
                        If rowsAffected = 0 Then
                            MessageBox.Show("Some unusual error happened.")
                        End If
                    End Using
                    Module_global.payment_successful = 0
                    myVariable = 0
                    variableChanged.Reset()


                    ' Call the function to clear the list of lists
                    BookedList.Clear()
                    Make_Schedule_Table()
                    'Await (task2)
                    MessageBox.Show("Successfully Booked the slots.")
                Else
                    MessageBox.Show("Payment was not successful. Please try again.")
                    Dim deleteSchedule1 As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"
                    For Each pair In BookedList
                        Dim deleteCommand As New SqlCommand(deleteSchedule1, connection)
                        deleteCommand.Parameters.AddWithValue("@user_id", Module_global.User_ID)
                        deleteCommand.Parameters.AddWithValue("@provider_id", Module_global.Provider_ID)
                        Dim nextDate As DateTime = DateTime.Today.Date.AddDays(pair(0)).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
                        Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                        deleteCommand.Parameters.AddWithValue("@time", formattedDate)
                        deleteCommand.Parameters.AddWithValue("@slots", pair(1))
                        Dim rowsAffected1 As Integer = deleteCommand.ExecuteNonQuery()
                        If rowsAffected > 0 Then
                            Console.WriteLine("Deleted")
                        Else
                            MessageBox.Show("Error!")
                        End If
                        Module_global.payment_successful = 0
                    Next
                    myVariable = 0
                    variableChanged.Reset()
                    Make_Schedule_Table()
                    BookedList.Clear()
                    ' Await (task2)
                    ' Execute the DELETE query to delete the Schedules
                    connection.Close()


                End If


            Else
                MessageBox.Show("Please select some slots to book!")
                End If

            ' Check for specific error number indicating duplicate key violation
Roll_back:
            ' Duplicate key violation error (constraint violation)
            If (f = 0) Then
                MessageBox.Show("This slot is already booked.", "Booking Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Dim deleteSchedule As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"
                For Each pair In NewlyBookedList
                    Dim deleteCommand As New SqlCommand(deleteSchedule, connection)
                    deleteCommand.Parameters.AddWithValue("@user_id", Module_global.User_ID)
                    deleteCommand.Parameters.AddWithValue("@provider_id", Module_global.Provider_ID)
                    Dim nextDate As DateTime = DateTime.Today.Date.AddDays(pair(0)).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
                    Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                    deleteCommand.Parameters.AddWithValue("@time", formattedDate)
                    deleteCommand.Parameters.AddWithValue("@slots", pair(1))
                    Dim rowsAffected1 As Integer = deleteCommand.ExecuteNonQuery()
                    If rowsAffected > 0 Then
                        Console.WriteLine("Deleted")
                    Else
                        MessageBox.Show("Error!")
                    End If
                    Module_global.payment_successful = 0
                Next
                BookedList.Clear()
                myVariable = 0
                variableChanged.Reset()
                Make_Schedule_Table()
            End If


            'MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)




        End Using
    End Sub

    Private Sub Back_Btn_Click(sender As Object, e As EventArgs) Handles Back_Btn.Click
        user_template.SplitContainer1.Panel2.Controls.Clear()
        If slot_back_choice = 1 Then
            If UserHome IsNot Nothing Then
                With UserHome
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    user_template.SplitContainer1.Panel2.Controls.Add(UserHome)
                    .ReloadData()
                    .BringToFront()
                    .Show()
                End With
            Else
                With UserHome
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    user_template.SplitContainer1.Panel2.Controls.Add(UserHome)
                    .BringToFront()
                    .Show()
                End With
            End If
        ElseIf slot_back_choice = 2 Then
            With user_search
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                Me.Close()
                user_template.SplitContainer1.Panel2.Controls.Add(user_search)
                .BringToFront()
                .Show()

            End With
        ElseIf slot_back_choice = 3 Then
            With ViewAllUser
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(ViewAllUser)
                .ReloadData()
                .BringToFront()
                .Show()
            End With
        End If

    End Sub

End Class