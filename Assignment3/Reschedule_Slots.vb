Imports System.Drawing.Drawing2D
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports FastReport.DataVisualization.Charting
Imports iText.Forms.Xfdf
Imports iText.IO.Font
Imports Org.BouncyCastle.Crypto.Internal
Imports System.Threading
Imports iText.IO.Font.Otf.Lookuptype8
Imports Microsoft.CodeAnalysis.Emit

Public Class Reschedule_Slots
    Public user As Integer = Module_global.User_ID
    Public provider As Integer = Module_global.Provider_ID
    Public ProviderName As String = "NULL"
    Public user_name As String = "NULL"
    Public binaryImageData As Byte()
    Public availability(7, 12) As Integer ' 7 days, 24 hours , Load it from database
    Public BookedList As New List(Of Integer())
    Public PreviouslyBookedList As New List(Of Integer())
    Public Avaiability_String As String = "NULL"
    Public Cost_per_hour As Integer = -1
    Public is_null_image As Integer = 0
    Dim first As Integer = 1


    Public ResvariableChanged As New ManualResetEvent(False)
    ' Variable to monitor for changes
    Public ResmyVariable As Integer = 0
    ' Store the user home form
    'Public UserHome As New U'serHome()
    Public Async Sub Reschedule_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run your function here
        'MessageBox.Show(1)
        Module_global.DealID_Reschedule = Module_global.Appointment_Det_DealId
        ProgressBar1.Visible = True
        ProgressBar1.Style = ProgressBarStyle.Marquee
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
                                 Cost_per_hour = reader.GetInt32(2)
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

        For i As Integer = 0 To 6
            Dim nextDate As DateTime = startDate.AddDays(i).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
            Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
            For j As Integer = 0 To 11
                If (Avaiability_String.ElementAt(((i + indexFromMonday) * 12 + j) Mod 84) = "1") Then
                    availability(i, j) = 1
                End If

            Next
        Next
        Dim selectQuery As String = "SELECT user_id, provider_id, time, status, dates, location FROM deals WHERE deal_id = @deal_id"

        ' Define the DELETE query to delete the deal
        Dim deleteQuery As String = "DELETE FROM deals WHERE deal_id = @deal_id"

        Dim deleteSchedule As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"
        Dim f1 As Integer = 0
        ' Create a connection to the database
        Using connection As New SqlConnection(connectionString)
            ' Open the connection
            connection.Open()
            If first = 1 Then
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

                                Dim differenceInDays As Integer = (DateTime.Today - dates.Date).Days
                                'MessageBox.Show(differenceInDays)

                                If (differenceInDays >= 7) Then
                                    differenceInDays = 7
                                End If

                                For I As Integer = 0 To (differenceInDays) * 12 - 1
                                    Dim bit As Char = slots(I)

                                    ' Check if the bit is '1' (indicating working day)
                                    If bit = "1"c Then
                                        ' Calculate the day index based on the current day index and the index i
                                        MessageBox.Show("This booking already has started! You can't reschedule it.")
                                        f1 = 1


                                    End If
                                Next

                                If f1 = 0 Then


                                    For I As Integer = differenceInDays * 12 To slots.Length - 1
                                        Dim bit As Char = slots(I)

                                        ' Check if the bit is '1' (indicating working day)
                                        If bit = "1"c Then
                                            ' Calculate the day index based on the current day index and the index i
                                            'MessageBox.Show(Math.Floor(I / 12))
                                            Dim dayIndex As Integer = Math.Floor(I / 12) - differenceInDays
                                            Dim slot As Integer = I Mod 12

                                            availability(dayIndex, slot) = 3
                                            PreviouslyBookedList.Add({dayIndex, slot})
                                            BookedList.Add({dayIndex, slot})

                                        End If
                                    Next
                                    ' Process the data as needed


                                End If
                            End While

                        End If

                        first = 0

                    End Using
                End Using
            End If
        End Using

        If (f1 = 1) Then
            Me.Close()
        End If





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
                            If (availability(daysDifference, slot) <> 3) Then
                                availability(daysDifference, slot) = 2
                            End If


                        Else
                            availability(daysDifference, slot) = 0
                        End If

                    End While
                End Using
            End Using
        End Using
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
                btn.BackColor = If(availability(i, j) = 1, Color.LightGreen, If(availability(i, j) = 2, Color.DarkGreen, If(availability(i, j) = 3, Color.Gray, Color.Transparent)))
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

    Private Sub DisplayMessageOnLoad()
        ' Your function code here
        MessageBox.Show("This message appears when the form loads.")
    End Sub

    Private Async Function WaitForVariableChangeOrTimeoutAsync(timeoutMilliseconds As Integer) As Task
        ' Wait for either the variable to change or the timeout to elapse
        'MessageBox.Show("I")
        Dim delayTask = Task.Delay(timeoutMilliseconds)

        ' Create a task that waits for the variableChanged signal
        Dim waitForSignalTask = Task.Run(Sub() ResvariableChanged.WaitOne())

        ' Wait asynchronously for either of the tasks to complete
        Dim completedTask = Await Task.WhenAny(delayTask, waitForSignalTask)


        ' After the wait, you can check if the variable changed or timeout happened
        If ResmyVariable <> 0 Then
            ' The variable changed
            MessageBox.Show("Paymeny Successful!")

        Else
            ' Timeout occurred
            MessageBox.Show("Timeout occurred or Some error occured during Payment")
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
        Dim currentDate As DateTime = DateTime.Today
        Dim reschedule_cost As Decimal = 0.0
        Dim prevBookListSize As Integer = PreviouslyBookedList.Count
        Dim currBookListSize As Integer = BookedList.Count

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            If prevBookListSize = currBookListSize Then
                ' No description of how to map the slots one to one...
                ' So take one to one in-order map of the sorted lists.
                Dim sortedCurrBookedList As List(Of Integer()) = BookedList
                Dim sortedPrevBookedList As List(Of Integer()) = PreviouslyBookedList
                sortedCurrBookedList.Sort(AddressOf PairComparator)
                sortedPrevBookedList.Sort(AddressOf PairComparator)
                ' y = 1 if postpone
                Dim y As Decimal = 1.0
                For I As Integer = 0 To currBookListSize - 1
                    If PairComparator(sortedCurrBookedList(I), sortedPrevBookedList(I)) < 0 Then
                        'y = 1.05 if prepone
                        y += 0.05
                    End If
                    ' No description of booking time...
                    ' So take booking time as current day with starting slot.
                    reschedule_cost += Math.Abs((84 - ((sortedCurrBookedList(I)(0) * 13 + sortedCurrBookedList(I)(1)) + 1)) * 0.7 + Math.Abs((sortedPrevBookedList(I)(0) * 13 + sortedPrevBookedList(I)(1))) * 0.3)
                    reschedule_cost *= y
                    reschedule_cost /= 84.0
                    y = 1.0
                Next
                reschedule_cost /= 2.0
                reschedule_cost /= currBookListSize
            Else
                MessageBox.Show("Please choose same number of slots. If you want to add or remove slots from the current schedule, you must cancel this booking.")
                GoTo Rollback
            End If
            Dim response As DialogResult = MessageBox.Show($"The rescheduling cost is {reschedule_cost}, Do you wish to continue", "Done", MessageBoxButtons.YesNo, MessageBoxIcon.Information)
            If response = DialogResult.No Then
                ' Roll back Schedule insertion
Rollback:
                BookedList.Clear()
                PreviouslyBookedList.Clear()
                Me.Close()
                With user_appointment_details
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    user_template.SplitContainer1.Panel2.Controls.Add(user_appointment_details)
                    .BringToFront()
                    .Show()
                End With
            Else
                Dim NewlyBookedList As New List(Of Integer())
                Try
                    '' Now we have stored the previously booked slots in the PreviouslyBookedList
                    Dim deleteSchedule As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"


                    Dim rowsAffected As Integer = 0
                    Dim Total_slots As Integer = 0

                    For Each slot As Integer() In BookedList
                        Dim found As Integer = -1
                        Total_slots += 1
                        For Each slot1 As Integer() In PreviouslyBookedList
                            If (slot1(0) = slot(0) And slot1(1) = slot(1)) Then
                                found = 1
                                Exit For
                            End If
                        Next
                        If (found <> -1) Then
                            Continue For
                        End If

                        Dim provider_query As String = "INSERT INTO schedule (user_id,provider_id,slots,time) VALUES (@User_ID,@Provider_ID,@Slot,@Time);" ' Add the query here
                        Using command As New SqlCommand(provider_query, connection)
                            command.Parameters.AddWithValue("@User_ID", user)
                            command.Parameters.AddWithValue("@Provider_ID", provider)
                            command.Parameters.AddWithValue("@Slot", slot(1))
                            command.Parameters.AddWithValue("@Time", DateTime.Today.AddDays(slot(0)))
                            rowsAffected = command.ExecuteNonQuery()
                            NewlyBookedList.Add(slot)
                            If rowsAffected = 0 Then
                                MessageBox.Show("Some unusual error happened.")
                                Exit For
                            End If
                        End Using
                    Next
                    If rowsAffected > 0 Then
                        Dim Total_cost As Integer = (Cost_per_hour * Total_slots) / 2 + reschedule_cost * (Cost_per_hour * Total_slots) / 2

                        Module_global.cost_of_booking = Total_cost
                        payments.CostOfService = Total_cost
                        payments.ProviderEmailID = ProviderName
                        ResvariableChanged.Reset()
                        ResmyVariable = 0
                        Dim Total_cost1 As Integer = Total_cost + (Cost_per_hour * Total_slots) / 2
                        MessageBox.Show($"Data inserted successfully, you need to pay a total of {Total_cost}Rs.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        payments.Show()
                        Await WaitForVariableChangeOrTimeoutAsync(90000000)

                        If (Module_global.payment_successful = 1) Then
                            'Dim InsertQuery As String = "INSERT INTO deals (deal_id,user_id,provider_id,time,status,dates,location) VALUES ((SELECT ISNULL(MAX(deal_id), 0) + 1 FROM deals),@User_ID,@Provider_ID,@Time,@Status,@Dates,@Location);"
                            Dim newDealTimeString As String = ""
                            For I As Integer = 0 To 83
                                Dim index As Integer = I
                                If BookedList.Exists(Function(x) x(0) = index \ 12 AndAlso x(1) = index Mod 12) Then
                                    newDealTimeString += "1"
                                Else
                                    newDealTimeString += "0"
                                End If
                            Next

                            'MessageBox.Show(newDealTimeString)

                            Dim dealsupdate As String = "update deals set time = @time, deal_amount = @Deal_amt , dates = @date where deal_id = @deal_id;"
                            Try
                                Using command As New SqlCommand(dealsupdate, connection)
                                    ' Add parameters to the SqlCommand
                                    command.Parameters.AddWithValue("@time", newDealTimeString)
                                    command.Parameters.AddWithValue("@date", currentDate)
                                    command.Parameters.AddWithValue("@deal_id", Module_global.DealID_Reschedule)
                                    command.Parameters.AddWithValue("@Deal_amt", Total_cost1)

                                    ' Execute the command
                                    rowsAffected = command.ExecuteNonQuery()

                                    ' Check the rows affected
                                    If rowsAffected = 0 Then
                                        MessageBox.Show("No rows were updated.")
                                    Else
                                        MessageBox.Show("Update successful.")
                                    End If
                                End Using
                            Catch ex As Exception
                                MessageBox.Show("An error occurred: " & ex.Message)
                            End Try


                            '' Now we have stored the previously booked slots in the PreviouslyBookedList
                            'MessageBox.Show("LEN  " + PreviouslyBookedList.Count.ToString())
                            For Each pair As Integer() In PreviouslyBookedList

                                Dim found As Integer = -1
                                For Each slot1 As Integer() In BookedList
                                    If (slot1(0) = pair(0) And slot1(1) = pair(1)) Then
                                        found = 1
                                        Exit For
                                    End If
                                Next
                                If (found <> -1) Then
                                    Continue For
                                End If

                                Dim deleteCommand As New SqlCommand(deleteSchedule, connection)
                                deleteCommand.Parameters.AddWithValue("@user_id", Module_global.User_ID)
                                deleteCommand.Parameters.AddWithValue("@provider_id", Module_global.Provider_ID)
                                Dim nextDate As DateTime = DateTime.Today.Date.AddDays(pair(0)).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
                                Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                                deleteCommand.Parameters.AddWithValue("@time", formattedDate)
                                deleteCommand.Parameters.AddWithValue("@slots", pair(1))
                                Dim rowsAffected1 As Integer = deleteCommand.ExecuteNonQuery()
                                'MessageBox.Show(formattedDate)
                                'MessageBox.Show(pair(1))

                                If rowsAffected > 0 Then
                                    Console.WriteLine("Deleted")
                                Else
                                    MessageBox.Show("Error!")
                                End If
                                ' Execute the DELETE query to delete the Schedules
                            Next

                            BookedList.Clear()
                            PreviouslyBookedList.Clear()
                            NewlyBookedList.Clear()
                            'Module_global.payment_successful = 0

                            ResmyVariable = 0
                            ResvariableChanged.Reset()
                            Module_global.payment_successful = 0
                            ResmyVariable = 0
                            MessageBox.Show("Successfully Booked the slots!!.")
                            Me.Close()
                        Else
                            MessageBox.Show("Payment was not successful. Please try again.")
                            'Dim deleteSchedule As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"
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
                                ' Execute the DELETE query to delete the Schedules
                            Next
                            ResvariableChanged.Reset()
                            Module_global.payment_successful = 0
                            ResmyVariable = 0
                            BookedList.Clear()
                            PreviouslyBookedList.Clear()
                            NewlyBookedList.Clear()
                            Me.Close()
                            With user_appointment_details
                                .TopLevel = False
                                .AutoSize = True
                                .Dock = DockStyle.Fill
                                user_template.SplitContainer1.Panel2.Controls.Add(user_appointment_details)
                                .BringToFront()
                                .Show()
                            End With
                        End If


                    Else
                        MessageBox.Show("Please select some slots to book!")
                    End If
                Catch ex As SqlException
                    ' Check for specific error number indicating duplicate key violation
                    If ex.Number = 2601 OrElse ex.Number = 2627 Then
                        ' Duplicate key violation error (constraint violation)
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
                            If rowsAffected1 > 0 Then
                                Console.WriteLine("Deleted")
                            Else
                                MessageBox.Show("Error!")
                            End If
                            Module_global.payment_successful = 0
                        Next
                        BookedList.Clear()
                        Book_slots.myVariable = 0
                        Book_slots.variableChanged.Reset()

                        'For Each slot As Integer() In PreviouslyBookedList
                        '    Dim provider_query As String = "INSERT INTO schedule (user_id,provider_id,slots,time) VALUES (@User_ID,@Provider_ID,@Slot,@Time);" ' Add the query here
                        '    Using command As New SqlCommand(provider_query, connection)
                        '        command.Parameters.AddWithValue("@User_ID", user)
                        '        command.Parameters.AddWithValue("@Provider_ID", provider)
                        '        command.Parameters.AddWithValue("@Slot", slot(1))
                        '        command.Parameters.AddWithValue("@Time", currentDate.AddDays(slot(0)))
                        '        Dim rowsAffected1 As Integer = command.ExecuteNonQuery()
                        '        If rowsAffected1 = 0 Then
                        '            MessageBox.Show("Some unusual error happened.")
                        '            Exit For
                        '        End If
                        '    End Using
                        'Next
                        Me.Close()
                        With user_appointment_details
                            .TopLevel = False
                            .AutoSize = True
                            .Dock = DockStyle.Fill
                            user_template.SplitContainer1.Panel2.Controls.Add(user_appointment_details)
                            .BringToFront()
                            .Show()
                        End With

                    Else
                        ' Other SQL error occurred, handle accordingly
                        'MessageBox.Show($"SQL Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    End If
                End Try
            End If

            ' Calculate Reschedule cost and display to the user

        End Using
    End Sub

    Private Function PairComparator(ByVal x As Integer(), ByVal y As Integer()) As Integer
        Return (x(0) + 13 * x(1)).CompareTo(y(0) + 13 * y(1))
    End Function

    Private Sub Back_Btn_Click(sender As Object, e As EventArgs) Handles Back_Btn.Click
        user_template.SplitContainer1.Panel2.Controls.Clear()
        With user_appointment_details
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(user_appointment_details)
            Me.Close()
            .BringToFront()
            .Show()
        End With
    End Sub
End Class