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
    Public Sub Book_slots_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run your function here
        'MessageBox.Show(1)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Dim provider_query As String = "SELECT providername,working_hour,cost_per_hour FROM provider WHERE provider_id = @Provider_ID"
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
                    cost_per_hour = reader.GetInt32(2)
                    ' Do something with the retrieved values, such as displaying them in a MessageBox
                End While

            End Using
        End Using
        Provider_Name_Loc_Lbl.Text = ProviderName
        'MessageBox.Show(2)
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
                    If (reader.IsDBNull("profile_image")) Then
                        is_null_image = 1
                    Else
                        Dim imageData As Byte() = DirectCast(reader("profile_image"), Byte())
                        binaryImageData = imageData
                    End If

                    ' Convert byte array to image

                    Username.Text = user_name
                    ' Do something with the retrieved values, such as displaying them in a MessageBox
                End While

            End Using
        End Using
        'MessageBox.Show(3)
        MakePictureBoxRound(Profile_Pic)
        'MessageBox.Show(4)
        Make_Schedule_Table()

    End Sub

    Private Sub Make_Schedule_Table()
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
        PopulateScheduleTable()
    End Sub
    Private Sub PopulateScheduleTable()

        ' Clear existing controls in the table layout panel
        'MessageBox.Show("0")
        Schedule_Table.Controls.Clear()
        'MessageBox.Show("1")
        ' Clear any existing column and row styles
        Schedule_Table.ColumnStyles.Clear()
        Schedule_Table.RowStyles.Clear() '''
        'MessageBox.Show("2")

        ' Calculate percentage for each column and row
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
        For Each control As Control In Schedule_Table.Controls
            Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(control)
            If cellPosition.Column = 0 Or cellPosition.Row = 0 Then
                control.BackColor = ColorTranslator.FromHtml("#F58CD7")
            End If
        Next
        'MessageBox.Show(10)
        ' Add buttons for each time slot
        Schedule_Table.SuspendLayout()
        For i As Integer = 0 To 6
            For j As Integer = 0 To 11
                Dim btn As New Button()
                btn.Text = ""
                btn.Dock = DockStyle.Fill

                If availability(i, j) = 1 Then
                    btn.BackColor = Color.LightGreen ' Available
                ElseIf availability(i, j) = 2 Then
                    btn.BackColor = Color.DarkGreen
                Else
                    btn.BackColor = Color.Transparent ' Unavailable
                End If

                btn.Margin = New Padding(0)
                btn.FlatStyle = FlatStyle.Flat ' Set the button to have a flat appearance
                Schedule_Table.Controls.Add(btn, j + 1, i + 1)
                AddHandler btn.Click, AddressOf TimeSlot_Click
            Next
        Next

        Schedule_Table.ResumeLayout(True)
        'MessageBox.Show(11)
    End Sub

    Private Sub TimeSlot_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(btn)

        Dim dayIndex As Integer = cellPosition.Row - 1
        Dim hourIndex As Integer = cellPosition.Column - 1

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

    Public Sub MakePictureBoxRound(pictureBox As PictureBox)
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
            MessageBox.Show("Timeout occurred.")
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
            For Each slot As Integer() In BookedList
                Total_slots += 1
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
                Dim Total_cost As Integer = (cost_per_hour * Total_slots) / 2
                Module_global.cost_of_booking = Total_cost
                payments.CostOfService = Total_cost
                payments.ProviderEmailID = ProviderName
                MessageBox.Show($"Data inserted successfully, you need to pay a total of {Total_cost}Rs.", "Successful", MessageBoxButtons.OK, MessageBoxIcon.Information)
                payments.Show()
                Await WaitForVariableChangeOrTimeoutAsync(900000000)
                If (Module_global.payment_successful = 1) Then
                    Dim InsertQuery As String = "INSERT INTO deals (deal_id,user_id,provider_id,time,status,dates,location) VALUES ((SELECT ISNULL(MAX(deal_id), 0) + 1 FROM deals),@User_ID,@Provider_ID,@Time,@Status,@Dates,@Location);"
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
                        rowsAffected = command.ExecuteNonQuery()
                        If rowsAffected = 0 Then
                            MessageBox.Show("Some unusual error happened.")
                        End If
                    End Using
                    Module_global.payment_successful = 0
                    myVariable = 0
                    Make_Schedule_Table()
                    MessageBox.Show("Successfully Booked the slots.")
                Else
                    MessageBox.Show("Payment was not successful. Please try again.")
                    Dim deleteSchedule As String = "DELETE FROM schedule WHERE user_id=@user_id AND provider_id=@provider_id AND time=@time AND slots=@slots AND time=@time"
                    For Each pair In BookedList
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
                End If


            Else
                MessageBox.Show("Please select some slots to book!")
            End If

        End Using
    End Sub

    Private Async Sub Sleep()
        ' Perform some actions before sleeping

        ' Pause execution of this form for 1 second (1000 milliseconds)
        Await Task.Delay(10000)

        ' Continue with other actions after sleeping
    End Sub
    Private Sub Back_Btn_Click(sender As Object, e As EventArgs) Handles Back_Btn.Click
        user_template.SplitContainer1.Panel2.Controls.Clear()
        If slot_back_choice = 1 Then
            With UserHome
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(UserHome)
                .BringToFront()
                .Show()

            End With
        ElseIf slot_back_choice = 2 Then
            With user_search
                .TopLevel = False
                .AutoSize = True
                .Dock = DockStyle.Fill
                user_template.SplitContainer1.Panel2.Controls.Add(user_search)
                .BringToFront()
                .Show()

            End With
        End If

    End Sub
End Class