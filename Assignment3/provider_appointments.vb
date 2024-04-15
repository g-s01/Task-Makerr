Imports Microsoft.Data.SqlClient

Public Class provider_appointments
    Dim panelArray(2) As System.Windows.Forms.Panel

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button1.BackColor = SystemColors.Control
        Button1.ForeColor = SystemColors.GrayText
        Button2.ForeColor = SystemColors.ControlText
        Payment()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button2.BackColor = SystemColors.Control
        Button2.ForeColor = SystemColors.GrayText
        Button1.ForeColor = SystemColors.ControlText
        upcoming()
    End Sub

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Dim clickedPanel As Panel = DirectCast(sender, Panel)
        Dim panelIndex As Integer = Array.IndexOf(panelArray, clickedPanel)

        ' Show related form for upper panel click
        'Dim relatedForm As New RelatedForm() ' Replace RelatedForm with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Sub Button_ClickCompleted(sender As Object, e As EventArgs)
        Dim ButtonClicked As Button = DirectCast(sender, Button)
        Dim dealId As Integer = Integer.Parse(ButtonClicked.Name)
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "Update deals Set status=2 where deal_id=@DealId"
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@DealId", dealId)
                Dim result As Object = sqlCommand.ExecuteNonQuery()
            End Using
        End Using
        MessageBox.Show("Service Completed")
        upcoming()
        ' Show related form for button click
        'Dim relatedForm As New RelatedForm2() ' Replace RelatedForm2 with the actual name of your related form class
        'relatedForm.Show()
    End Sub
    Private Sub Button_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Button Clicked in Lower Panel")

        ' Show related form for button click
        'Dim relatedForm As New RelatedForm2() ' Replace RelatedForm2 with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Function spawnDivs(i As Integer, providerName As String, location As String, CostNum As Integer, Schedule As String, y As Integer)
        ReDim panelArray(i)

        Dim x As Integer = 20

        panelArray(i) = New System.Windows.Forms.Panel()
        panelArray(i).Location = New System.Drawing.Point(x, y)
        panelArray(i).Size = New System.Drawing.Size(750, 70)
        panelArray(i).BackColor = System.Drawing.Color.FromArgb(CByte(240), CByte(218), CByte(248))
        panelArray(i).AutoSize = True

        AddHandler panelArray(i).Click, AddressOf Panel_Click

        Dim name As New Label()
        name.AutoSize = True
        name.Location = New System.Drawing.Point(25, 10)
        name.Name = "name"
        name.Text = providerName
        panelArray(i).Controls.Add(name)

        Dim place As New Label()
        place.AutoSize = True
        place.Location = New System.Drawing.Point(25, 40)
        place.Name = "place"
        place.Text = location
        panelArray(i).Controls.Add(place)

        Dim cost As New Label()
        cost.AutoSize = True
        cost.Location = New System.Drawing.Point(610, 10)
        cost.Name = "cost"
        cost.Text = "Cost : " + CostNum.ToString()
        panelArray(i).Controls.Add(cost)

        Dim timings As New Label()
        timings.AutoSize = True
        timings.Location = New System.Drawing.Point(520, 40)
        timings.Name = "timings"
        timings.Text = "Appointment schedule :  " + Schedule
        panelArray(i).Controls.Add(timings)

        Panel1.Controls.Add(panelArray(i))

    End Function

    Private Async Function Payment() As Task
        Dim y As Integer = 50
        Dim i As Integer = 0
        Panel1.Controls.Clear()
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE provider_id = @ProviderId AND status = 2"
        Dim query2 As String = "SELECT * FROM provider where provider_id =@ProviderID"
        Dim query3 As String = "SELECT * FROM customer where user_id =@UserId"
        Dim result As SqlDataReader
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@ProviderId", Provider_ID) ' Use the password entered by the user
                result = Await sqlCommand.ExecuteReaderAsync()
                Do While Await result.ReadAsync()
                    Dim time As String = result.GetString(3)
                    Dim dateof As Date = result.GetValue(5)
                    Dim UserId As Integer = result.GetValue(1)
                    Dim ProviderId As Integer = result.GetValue(2)
                    Dim UserName As String = ""
                    Dim Location As String = ""
                    Dim Cost As Integer = 0
                    Await Task.WhenAll(
                        Task.Run(Async Function()
                                     Using sqlConnection2 As New SqlConnection(connectionString)
                                         sqlConnection2.Open()
                                         Using sqlCommand2 As New SqlCommand(query2, sqlConnection2)
                                             sqlCommand2.Parameters.AddWithValue("@ProviderID", ProviderId)
                                             Dim providerDb As SqlDataReader = Await sqlCommand2.ExecuteReaderAsync()
                                             Do While Await providerDb.ReadAsync()
                                                 Cost = providerDb.GetValue(6)
                                             Loop
                                         End Using
                                     End Using
                                 End Function),
                        Task.Run(Async Function()
                                     Using sqlConnection2 As New SqlConnection(connectionString)
                                         sqlConnection2.Open()
                                         Using sqlCommand2 As New SqlCommand(query3, sqlConnection2)
                                             sqlCommand2.Parameters.AddWithValue("@UserId", UserId)
                                             Dim UserDb As SqlDataReader = Await sqlCommand2.ExecuteReaderAsync()
                                             Do While Await UserDb.ReadAsync()
                                                 UserName = UserDb.GetValue(1)
                                             Loop
                                         End Using
                                     End Using
                                 End Function)
                    )



                    dateof = dateof.AddMinutes(-dateof.Minute)
                    dateof = dateof.AddSeconds(-dateof.Second)
                    Dim count As Integer = 0
                    For Each c As Char In time
                        If c = "1" Then
                            Dim slotTime = count Mod 12 + 9
                            dateof = dateof.AddHours(slotTime - dateof.Hour)
                            Exit For

                        End If
                        count = count + 1
                        If (count Mod 12 = 0) Then
                            dateof = dateof.AddDays(1)
                        End If
                    Next
                    spawnDivs(i, UserName, Location, Cost, dateof, y)
                    i += 1
                    y += 100
                Loop
            End Using
        End Using
    End Function

    Private Function spawnUpcomingDiv(splitContainerArray As SplitContainer(), i As Integer, UserName As String, location As String, CostNum As Integer, Schedule As String, y As Integer, DealId As Integer)
        Dim x As Integer = 20
        ReDim splitContainerArray(i)
        splitContainerArray(i) = New SplitContainer()
        splitContainerArray(i).Location = New System.Drawing.Point(x, y)
        splitContainerArray(i).Size = New System.Drawing.Size(750, 120)
        splitContainerArray(i).Orientation = Orientation.Horizontal
        splitContainerArray(i).SplitterDistance = 70
        splitContainerArray(i).Panel1.BackColor = System.Drawing.Color.FromArgb(CByte(240), CByte(218), CByte(248))

        AddHandler splitContainerArray(i).Panel1.Click, AddressOf Panel_Click

        Dim name As New Label()
        name.AutoSize = True
        name.Location = New System.Drawing.Point(25, 10)
        name.Name = "name"
        name.Text = UserName
        splitContainerArray(i).Panel1.Controls.Add(name)

        Dim place As New Label()
        place.AutoSize = True
        place.Location = New System.Drawing.Point(25, 40)
        place.Name = "place"
        place.Text = location
        splitContainerArray(i).Panel1.Controls.Add(place)

        Dim cost As New Label()
        cost.AutoSize = True
        cost.Location = New System.Drawing.Point(610, 10)
        cost.Name = "cost"
        cost.Text = "Cost : " + CostNum.ToString()
        splitContainerArray(i).Panel1.Controls.Add(cost)

        Dim timings As New Label()
        timings.AutoSize = True
        timings.Location = New System.Drawing.Point(490, 40)
        timings.Name = "timings"
        timings.Text = "Appointment schedule :  " + Schedule
        splitContainerArray(i).Panel1.Controls.Add(timings)

        Dim button_com As New Button()
        button_com.Name = DealId.ToString()
        button_com.Text = " Completed "
        button_com.AutoSize = True
        button_com.Location = New System.Drawing.Point(480, 0)
        button_com.FlatAppearance.BorderSize = 0
        button_com.FlatStyle = FlatStyle.Flat
        button_com.Font = New Font("Microsoft YaHei", 10.2F)
        button_com.BackColor = System.Drawing.Color.FromArgb(CByte(245), CByte(140), CByte(215))

        AddHandler button_com.Click, AddressOf Button_ClickCompleted

        splitContainerArray(i).Panel2.Controls.Add(button_com)

        Dim button_cancel As New Button()
        button_cancel.Text = "  Cancel  "
        button_cancel.AutoSize = True
        button_cancel.Location = New System.Drawing.Point(600, 0)
        button_cancel.FlatAppearance.BorderSize = 0
        button_cancel.FlatStyle = FlatStyle.Flat
        button_cancel.Font = New Font("Microsoft YaHei", 10.2F)
        button_cancel.BackColor = System.Drawing.Color.FromArgb(CByte(245), CByte(140), CByte(215))

        AddHandler button_cancel.Click, AddressOf Button_Click

        splitContainerArray(i).Panel2.Controls.Add(button_cancel)

        Panel1.Controls.Add(splitContainerArray(i))

    End Function
    Private Async Function upcoming() As Task
        Panel1.Controls.Clear()
        Dim splitContainerArray(1) As SplitContainer
        Dim y As Integer = 50
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE provider_id = @ProviderId AND status = 1"
        Dim query2 As String = "SELECT * FROM provider where provider_id =@ProviderID"
        Dim query3 As String = "SELECT * FROM customer where user_id =@UserId"
        Dim i As Integer = 0
        Dim result As SqlDataReader
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@ProviderId", Provider_ID) ' Use the password entered by the user
                result = Await sqlCommand.ExecuteReaderAsync()
                Do While Await result.ReadAsync()
                    Dim time As String = result.GetString(3)
                    Dim dateof As Date = result.GetValue(5)
                    Dim UserId As Integer = result.GetValue(1)
                    Dim ProviderId As Integer = result.GetValue(2)
                    Dim UserName As String = ""
                    Dim Location As String = ""
                    Dim Cost As Integer = 0
                    Await Task.WhenAll(
                    Task.Run(Async Function()
                                 Using sqlConnection2 As New SqlConnection(connectionString)
                                     sqlConnection2.Open()
                                     Using sqlCommand2 As New SqlCommand(query2, sqlConnection2)
                                         sqlCommand2.Parameters.AddWithValue("@ProviderID", ProviderId)
                                         Dim providerDb As SqlDataReader = Await sqlCommand2.ExecuteReaderAsync()
                                         Do While Await providerDb.ReadAsync()
                                             Cost = providerDb.GetValue(6)
                                         Loop
                                     End Using
                                 End Using
                             End Function),
                    Task.Run(Async Function()
                                 Using sqlConnection2 As New SqlConnection(connectionString)
                                     sqlConnection2.Open()
                                     Using sqlCommand2 As New SqlCommand(query3, sqlConnection2)
                                         sqlCommand2.Parameters.AddWithValue("@UserId", UserId)
                                         Dim UserDb As SqlDataReader = Await sqlCommand2.ExecuteReaderAsync()
                                         Do While Await UserDb.ReadAsync()
                                             UserName = UserDb.GetValue(1)
                                         Loop
                                     End Using
                                 End Using
                             End Function)
                    )


                    dateof = dateof.AddMinutes(-dateof.Minute)
                    dateof = dateof.AddSeconds(-dateof.Second)
                    Dim datefinal As Date = Now
                    Dim count As Integer = 0
                    For Each c As Char In time
                        If c = "1" Then
                            Dim slotTime = count Mod 12 + 9
                            dateof = dateof.AddHours(slotTime - dateof.Hour)
                            datefinal = dateof
                            If dateof.CompareTo(Now) > 0 Then
                                Exit For
                            End If
                        End If
                        count = count + 1
                        If (count Mod 12 = 0) Then
                            dateof = dateof.AddDays(1)
                        End If
                    Next
                    spawnUpcomingDiv(splitContainerArray, i, UserName, Location, Cost, datefinal, y, result.GetValue(0))
                    i += 1
                    y += 130
                Loop
            End Using
        End Using
    End Function

    Private Sub provider_appointments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upcoming()
    End Sub
End Class