Imports Microsoft.Data.SqlClient
Imports System.Threading
Imports System.Configuration

Public Class provider_appointment_details
    Public dealID As Integer = Module_global.Appointment_Det_DealId
    Public startTime As TimeSpan
    Public firstDate As DateTime
    Public bookDate As DateTime
    Public advance As Double
    Private slots As Integer = 0
    Private advancePercentage As Integer = 50
    Private user As String
    Private costPerHour As Decimal
    Private status As Integer = 0
    Private email As String
    Private COMPLETED As Integer = 2
    Private CANCELLED As Integer = 4
    Dim user_id As Integer = 0
    Dim provider_id As Integer = 0
    Dim connectionString As String
    Dim provider As String
    Dim time As String = ""

    Protected Overrides Sub OnVisibleChanged(e As EventArgs)
        MyBase.OnVisibleChanged(e)
        If Me.Visible Then
            loadData()
        End If
    End Sub

    Private Sub MakeChatVisible()
        SplitContainer1.Panel2.Controls.Clear()
        Dim chatForm As New appointmentChat()

        ' Set TopLevel property to False to allow embedding in another container
        chatForm.TopLevel = False
        chatForm.dealId = dealID
        chatForm.providerId = Module_global.Provider_ID
        chatForm.userId = user_id


        ' Set the form's Dock property to fill the panel
        chatForm.Dock = DockStyle.Fill

        ' Set the form's border style to None
        chatForm.FormBorderStyle = FormBorderStyle.None

        ' Add the form to the SplitContainer.Panel2
        SplitContainer1.Panel2.Controls.Add(chatForm)

        ' Show the form
        chatForm.Show()
    End Sub

    Private Sub loadData()
        'connectionString = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        connectionString = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE deal_id = @DealID"
        provider = 0


        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@DealID", dealID)

                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()


                    ' Check if there are rows returned
                    If reader.HasRows Then
                        ' Loop through the rows
                        While reader.Read()

                            ' Access columns by name or index
                            provider_id = reader.GetInt32(reader.GetOrdinal("provider_id"))
                            time = reader.GetString(reader.GetOrdinal("time"))
                            bookDate = reader.GetDateTime(reader.GetOrdinal("dates"))
                            user_id = reader.GetInt32(reader.GetOrdinal("user_id"))
                            status = reader.GetInt32(reader.GetOrdinal("status"))
                            'Dim location As String = reader.GetString(reader.GetOrdinal("location"))
                            ' Access other columns in a similar manner
                            ' Do something with the retrieved data
                            If status = 1 Then

                                btn_cancel.Visible = True
                                btn_cancel.Enabled = True
                                btn_appointment_completed.Visible = True
                                btn_appointment_completed.Enabled = True
                            Else
                                btn_cancel.Visible = False
                                btn_cancel.Enabled = False
                                btn_appointment_completed.Visible = False
                                btn_appointment_completed.Enabled = False
                            End If


                            ' Find the position of the first '1' in the bit string
                            Dim firstOneIndex As Integer = time.IndexOf("1")

                            ' Calculate the day index based on the position of the first '1'
                            Dim dayIndex As Integer = firstOneIndex \ 12

                            ' Calculate the time index within the day
                            Dim timeIndex As Integer = firstOneIndex Mod 12

                            ' Calculate the time corresponding to the first '1'
                            startTime = TimeSpan.FromHours(9 + timeIndex)

                            ' Calculate the date and time
                            firstDate = bookDate.Date.AddDays(dayIndex)

                            Dim times As String = bookDate.Date.AddDays(dayIndex).Add(startTime).ToString("hh:mm tt")

                            rtb1.Text = vbLf & "   Details of the Booked Slots" & vbLf & vbLf & vbLf & "   Location: " & vbLf & vbLf & "   Date: " & firstDate.ToString("MMM dd yyyy") & "                            Timing: " & times



                        End While
                    Else
                        MessageBox.Show("No data found.")
                    End If

                    reader.Close()
                    'MakeChatVisible()
                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using


        Dim query2 As String = "SELECT cost_per_hour FROM provider WHERE provider_id = @ProviderID"


        For Each character As Char In time
            If character = "1" Then
                slots += 1
            End If
        Next

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query2, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider_id)

                Try
                    connection.Open()
                    costPerHour = Convert.ToDecimal(command.ExecuteScalar())

                    ' Do something with the retrieved cost per hour
                    rtb2.Text = vbLf & "   Charges for the Appointment" & vbLf & vbLf & vbLf & "   Charges per Slot: Rs" & costPerHour & vbLf & vbLf & "   Overall Service Cost: Rs" & slots * costPerHour


                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        Dim startIndex As Integer = rtb1.Text.IndexOf(" Details of the Booked Slots")
        Dim length As Integer = " Details of the Booked Slots".Length
        rtb1.Select(startIndex, length)
        ' rtb1.SelectionFont = New Font(rtb1.Font, FontStyle.Bold)

        startIndex = rtb2.Text.IndexOf(" Charges for the Appointment")
        length = " Charges for the Appointment".Length
        rtb2.Select(startIndex, length)
        rtb2.SelectionFont = New Font(rtb2.Font, FontStyle.Bold)

        Dim query3 As String = "SELECT email FROM provider WHERE provider_id = @ProviderID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query3, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider_id)

                Try
                    connection.Open()
                    email = Convert.ToString(command.ExecuteScalar())

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using

        'user name
        Dim query4 As String = "SELECT username FROM customer WHERE user_id = @UserID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query4, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@UserId", user_id)

                Try
                    connection.Open()
                    user = Convert.ToString(command.ExecuteScalar())

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
        'provider name
        Dim query5 As String = "SELECT providername FROM provider WHERE provider_id = @ProviderID"

        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(query5, connection)
                ' Add parameters to the SQL query to prevent SQL injection
                command.Parameters.AddWithValue("@ProviderID", provider_id)

                Try
                    connection.Open()
                    provider = Convert.ToString(command.ExecuteScalar())

                Catch ex As Exception
                    Console.WriteLine("Error: " & ex.Message)
                End Try
            End Using
        End Using
        rtb2.SelectionFont = New Font(rtb2.Font, FontStyle.Bold)

        MakeChatVisible()
    End Sub

    Private Sub btn_appointment_completed_Click(sender As Object, e As EventArgs) Handles btn_appointment_completed.Click
        Dim result As DialogResult = MessageBox.Show("Mark Appointment as completed?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        ' Check the user's response
        If result = DialogResult.Yes Then

            Dim provider_exists As Boolean = False
            Dim user_exists As Boolean = False
            Dim provider_balance_sufficients As Boolean = False



            Dim sqlQuery = "UPDATE deals SET status = @completed_status WHERE deal_id = @DealID;"

            ' Add parameters to the SQL query to prevent SQL injection
            Using connection As New SqlConnection(connectionString)
                Using command As New SqlCommand(sqlQuery, connection)
                    command.Parameters.AddWithValue("@DealID", dealID)
                    command.Parameters.AddWithValue("@completed_status", COMPLETED)
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using
            btn_cancel.Visible = False
            btn_cancel.Enabled = False
            btn_appointment_completed.Visible = False
            btn_appointment_completed.Enabled = False



        End If


    End Sub

    Public provariableChanged As New ManualResetEvent(False)

    ' Variable to monitor for changes
    Public promyVariable As Integer = 0


    Private Async Function WaitForVariableChangeOrTimeoutAsync(timeoutMilliseconds As Integer) As Task
        ' Wait for either the variable to change or the timeout to elapse
        Await Task.WhenAny(Task.Delay(timeoutMilliseconds), Task.Run(Sub() provariableChanged.WaitOne()))

        ' After the wait, you can check if the variable changed or timeout happened
        If promyVariable <> 0 Then

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
    Private Async Sub btn_cancel_Click(sender As Object, e As EventArgs) Handles btn_cancel.Click
        Dim currentDate As DateTime = DateTime.Now

        ' Combine stored date and time
        Dim storedDateTime As DateTime = firstDate.Date.Add(startTime)

        ' Calculate difference in hours
        Dim diff1 As Integer = CInt((currentDate - bookDate).TotalHours)

        Dim diff2 As Integer = CInt((storedDateTime - bookDate).TotalHours)

        Dim refundPercentage As Double = 100

        ' Cancellation Policy
        If diff1 <= diff2 / 24 Then
            refundPercentage = 100
        ElseIf diff1 <= diff2 / 6 Then
            refundPercentage = 105
        ElseIf diff1 <= diff2 / 3 Then
            refundPercentage = 110
        ElseIf diff1 >= 0 Then
            refundPercentage = 115
        Else
            refundPercentage = 125
        End If

        'refundPercentage = 50 ' for debugging
        advance = slots * costPerHour * (advancePercentage / 100)
        Dim selectQuery = "Select provider_id, user_id, time,dates from deals where deal_id = @DealID"
        Dim refundAmount As Double = advance * (refundPercentage / 100)
        Dim userIDCancelled = 0
        Dim providerIDCancelled = 0
        Dim timeCancelled As String = ""
        Dim dateCancelled As DateTime
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(selectQuery, connection)
                command.Parameters.AddWithValue("@DealID", dealID)

                connection.Open()
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Check if there are rows returned
                    If reader.HasRows Then
                        ' Iterate through the rows
                        While reader.Read()
                            ' Access the 'time' column value from the result set
                            MessageBox.Show("Hi")
                            providerIDCancelled = reader.GetInt32(0)
                            userIDCancelled = reader.GetInt32(1)
                            timeCancelled = reader.GetString(2)
                            dateCancelled = reader.GetDateTime(3)
                            ' Now you can work with the 'time' value
                            ' Example: Console.WriteLine(time.ToString())
                        End While
                    Else
                        ' No rows returned
                        Console.WriteLine("No data found for the specified deal_id.")
                    End If
                End Using
                command.ExecuteNonQuery()
            End Using
        End Using

        'Dim datestart As String = dateCancelled.ToString("yyyy-MM-dd HH:mm:ss.fff")


        Dim results As New List(Of String)()

        For I As Integer = 0 To 83
            If (timeCancelled(I) = "1"c) Then
                Dim slot As Integer = I Mod 12
                Dim day As Integer = I \ 12
                Dim datee As DateTime = dateCancelled.AddDays(day)
                Dim datestart As String = datee.ToString("yyyy-MM-dd 00:00:00.000")

                ' Append the datestart value to the results list
                results.Add(datestart)
            End If
        Next

        MessageBox.Show("List of datestart values:" & vbCrLf & String.Join(vbCrLf, results))



        Dim result As DialogResult = MessageBox.Show("Cancellation will result in deduction of " & refundPercentage & "% of the advance payment (" & advancePercentage & "% of the total amount). Refund amount: " & refundAmount & ". Do you want to continue?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question)


        ' Check the user's response
        If result = DialogResult.Yes Then
            provariableChanged.Reset()
            promyVariable = 0
            'MessageBox.Show("hi")
            'payments.Show()
            'Await WaitForVariableChangeOrTimeoutAsync(900000)'
            'If (Module_global.payment_successful = 1) Then
            'MessageBox.Show("yayyyy")

            Dim query As String = "UPDATE deals SET status = 3 WHERE deal_id = @DealID"

                ' Create connection and command objects
                Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(query, connection)
                        ' Add parameters to prevent SQL injection
                        command.Parameters.AddWithValue("@DealID", dealID)

                        Try
                            ' Open connection
                            connection.Open()

                            ' Execute the update query
                            command.ExecuteNonQuery()

                            MessageBox.Show("Deal status updated successfully.")
                        Catch ex As Exception
                            MessageBox.Show("An error occurred: " & ex.Message)
                        End Try
                    End Using
                End Using

            MessageBox.Show("Money Successfully deducted from your balance.")

            Using connection As New SqlConnection(connectionString)
                    Using command As New SqlCommand(selectQuery, connection)
                        command.Parameters.AddWithValue("@DealID", dealID)

                        connection.Open()
                        Using reader As SqlDataReader = command.ExecuteReader()
                            ' Check if there are rows returned
                            If reader.HasRows Then
                                ' Iterate through the rows
                                While reader.Read()
                                ' Access the 'time' column value from the result set

                                providerIDCancelled = reader.GetInt32(0)
                                    userIDCancelled = reader.GetInt32(1)
                                    timeCancelled = reader.GetString(2)
                                    dateCancelled = reader.GetDateTime(3)
                                    ' Now you can work with the 'time' value
                                    ' Example: Console.WriteLine(time.ToString())
                                End While
                            Else
                                ' No rows returned
                                Console.WriteLine("No data found for the specified deal_id.")
                            End If
                        End Using
                        command.ExecuteNonQuery()
                    End Using
                End Using

                'Dim datestart As String = dateCancelled.ToString("yyyy-MM-dd HH:mm:ss.fff")


                Using connection As New SqlConnection(connectionString)
                    connection.Open()
                    For I As Integer = 0 To 83
                        If (timeCancelled(I) = "1"c) Then
                            Dim slot As Integer = I Mod 12
                            Dim day As Integer = I \ 12
                            Dim datee As DateTime = dateCancelled.AddDays(day)
                        Dim datestart As String = datee.ToString("yyyy-MM-dd 00:00:00.000")
                        Dim deleteQuery = "DELETE FROM schedule WHERE provider_id = @ProviderID AND user_id = @UserID AND time = @datestart AND slots = @Slot"

                        MessageBox.Show(datestart)
                        MessageBox.Show(slot)

                        Using command As New SqlCommand(deleteQuery, connection)
                                command.Parameters.AddWithValue("@ProviderID", providerIDCancelled)
                                command.Parameters.AddWithValue("@UserID", userIDCancelled)
                                command.Parameters.AddWithValue("@datestart", datestart)
                                command.Parameters.AddWithValue("@Slot", slot)
                                command.ExecuteNonQuery()
                            End Using
                        End If
                    Next
                End Using
            Me.Close()





        End If


    End Sub
End Class