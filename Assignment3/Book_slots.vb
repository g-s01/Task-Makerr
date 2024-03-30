Imports System.Drawing.Drawing2D
Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.IO
Imports FastReport.DataVisualization.Charting

Public Class Book_slots
    Public user As Integer = Module_global.User_ID
    Public provider As Integer = Module_global.Provider_ID
    Public ProviderName As String = "NULL"
    Public user_name As String = "NULL"
    Public binaryImageData As Byte()
    Public availability(7, 23) As Boolean ' 7 days, 24 hours , Load it from database
    Public BookedList As New List(Of Integer())
    Public Avaiability_String As String = "NULL"
    Public Sub Book_slots_load(sender As Object, e As EventArgs) Handles MyBase.Load
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
                    ' Do something with the retrieved values, such as displaying them in a MessageBox
                End While

            End Using
        End Using
        Provider_Name_Loc_Lbl.Text = ProviderName
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
        MessageBox.Show("-2")
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
        MessageBox.Show("-1.5")

        For i As Integer = 0 To 7
                Dim nextDate As DateTime = startDate.AddDays(i).Date.AddHours(0).AddMinutes(0).AddSeconds(0) ' Set time to 12:00 AM
                Dim formattedDate As String = nextDate.ToString("yyyy-MM-dd HH:mm:ss.fff")
                For j As Integer = 0 To 12

                    availability(i, j) = Avaiability_String.ElementAt(((i + indexFromMonday) * 12 + j) Mod 84) = "1"
                    If (availability(i, j) = True) Then
                        Dim query As String = "SELECT COUNT(*) AS count_records FROM schedule WHERE  slots= @slotIndex AND time = @selectedDate AND user_id <> 0;"
                    Using connection As New SqlConnection(connectionString)
                        connection.Open()
                        Using command As New SqlCommand(query, connection)
                            ' Add parameters

                            command.Parameters.AddWithValue("@slotIndex", j)
                            command.Parameters.AddWithValue("@selectedDate", formattedDate)


                            ' Execute the select command
                            Dim reader As SqlDataReader = command.ExecuteReader()

                            While reader.Read()
                                ' Retrieve the provider name from the reader

                                ' Convert byte array to image

                                Dim count As Integer = reader(0)

                                If (count > 0) Then
                                    availability(i, j) = 0
                                End If
                                ' Do something with the retrieved values, such as displaying them in a MessageBox
                            End While

                        End Using
                    End Using
                End If
                Next
            Next



        MessageBox.Show("-1")
        ' Populate the schedule table
        PopulateScheduleTable()
    End Sub
    Private Sub PopulateScheduleTable()
        ' Clear existing controls in the table layout panel
        MessageBox.Show("0")
        Schedule_Table.Controls.Clear()
        MessageBox.Show("1")
        ' Clear any existing column and row styles
        Schedule_Table.ColumnStyles.Clear()
        Schedule_Table.RowStyles.Clear() '''
        MessageBox.Show("2")

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

                If availability(i, j) Then
                    btn.BackColor = Color.LightGreen ' Available
                Else
                    btn.BackColor = Color.Transparent ' Unavailable
                End If
                btn.Margin = New Padding(0)
                btn.FlatStyle = FlatStyle.Flat ' Set the button to have a flat appearance
                Schedule_Table.Controls.Add(btn, j + 1, i + 1)
                AddHandler btn.Click, AddressOf TimeSlot_Click
            Next
        Next
    End Sub

    Private Sub TimeSlot_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(btn)

        Dim dayIndex As Integer = cellPosition.Row - 1
        Dim hourIndex As Integer = cellPosition.Column - 1

        If availability(dayIndex, hourIndex) Then
            MessageBox.Show("Hi")
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

        End Using
    End Sub

End Class