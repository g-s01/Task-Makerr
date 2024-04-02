Imports Microsoft.Data.SqlClient
Imports Org.BouncyCastle.Crypto.General

Public Class user_appointments
    Dim panelArray(2) As System.Windows.Forms.Panel

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button1.BackColor = SystemColors.Control
        Button1.ForeColor = SystemColors.GrayText
        Button2.ForeColor = SystemColors.ControlText
        completed()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button2.BackColor = SystemColors.Control
        Button2.ForeColor = SystemColors.GrayText
        Button1.ForeColor = SystemColors.ControlText
        upcoming()
    End Sub

    Private Sub Panel_Click1(sender As Object, e As EventArgs)
        Dim clickedPanel As Panel = DirectCast(sender, Panel)
        Dim panelIndex As Integer = Array.IndexOf(panelArray, clickedPanel)

        'MessageBox.Show("Upper Panel Clicked - Index: " & panelIndex.ToString() & clickedPanel.Name)

        Module_global.Appointment_Det_DealId = Integer.Parse(clickedPanel.Name)

        Me.Hide()

        With user_appointment_details
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(user_appointment_details)
            .BringToFront()
            .Show()
        End With

        ' Show related form for upper panel click
        'Dim relatedForm As New RelatedForm() ' Replace RelatedForm with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Sub Panel_Click2(sender As Object, e As EventArgs)
        Dim clickedPanel As Panel = DirectCast(sender, Panel)
        Dim panelIndex As Integer = Array.IndexOf(panelArray, clickedPanel)

        'MessageBox.Show("Upper Panel Clicked - Index: " & panelIndex.ToString() & clickedPanel.Name)

        Module_global.Appointment_Det_DealId = Integer.Parse(clickedPanel.Name)

        Me.Hide()
        With pending_payment
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            user_template.SplitContainer1.Panel2.Controls.Add(pending_payment)
            .BringToFront()
            .Show()
        End With

        ' Show related form for upper panel click
        'Dim relatedForm As New RelatedForm() ' Replace RelatedForm with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Function spawnDivs(i As Integer, providerName As String, location As String, CostNum As Integer, Schedule As String, y As Integer, DealId As Integer)
        ReDim panelArray(i)

        Dim x As Integer = 20

        panelArray(i) = New System.Windows.Forms.Panel()
        panelArray(i).Name = DealId.ToString()
        panelArray(i).Location = New System.Drawing.Point(x, y)
        panelArray(i).Size = New System.Drawing.Size(750, 70)
        panelArray(i).BackColor = System.Drawing.Color.FromArgb(CByte(240), CByte(218), CByte(248))
        panelArray(i).AutoSize = True

        AddHandler panelArray(i).Click, AddressOf Panel_Click1

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

    Private Function spawnDivsWithButton(splitContainerArray As SplitContainer(), i As Integer, providerName As String, location As String, CostNum As Integer, Schedule As String, y As Integer, DealId As Integer)
        Dim x As Integer = 20

        ReDim splitContainerArray(i)
        splitContainerArray(i) = New SplitContainer()
        splitContainerArray(i).Location = New System.Drawing.Point(x, y)
        splitContainerArray(i).Size = New System.Drawing.Size(750, 120)
        splitContainerArray(i).Orientation = Orientation.Horizontal
        splitContainerArray(i).SplitterDistance = 70
        splitContainerArray(i).Panel1.BackColor = System.Drawing.Color.FromArgb(CByte(240), CByte(218), CByte(248))

        AddHandler splitContainerArray(i).Panel1.Click, AddressOf Panel_Click2

        splitContainerArray(i).Panel1.Name = DealId.ToString()

        Dim name As New Label()
        name.AutoSize = True
        name.Location = New System.Drawing.Point(25, 10)
        name.Name = "name"
        name.Text = providerName
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

        Dim button As New Button()
        button.Text = "  Proceed to Pay   "
        button.AutoSize = True
        button.Location = New System.Drawing.Point(580, 0)
        button.FlatAppearance.BorderSize = 0
        button.FlatStyle = FlatStyle.Flat
        button.Font = New Font("Microsoft YaHei", 10.2F)
        button.BackColor = System.Drawing.Color.FromArgb(CByte(245), CByte(140), CByte(215))

        AddHandler button.Click, AddressOf Button_Click

        splitContainerArray(i).Panel2.Controls.Add(button)

        Panel1.Controls.Add(splitContainerArray(i))

    End Function

    Private Sub Button_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Button Clicked in Lower Panel")

        ' Show related form for button click
        'Dim relatedForm As New RelatedForm2() ' Replace RelatedForm2 with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Function upcoming()
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE user_id = @UserId AND status = 1"
        Dim query2 As String = "SELECT * FROM provider where provider_id =@ProviderID"
        Panel1.Controls.Clear()
        Dim i As Integer = 0
        Dim y As Integer = 50
        Dim result As SqlDataReader
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@UserId", User_ID) ' Use the password entered by the user
                result = sqlCommand.ExecuteReader()
                Do While result.Read()
                    Dim time As String = result.GetString(3)
                    Dim dateof As Date = result.GetValue(5)
                    Dim ProviderId As Integer = result.GetValue(2)
                    Dim ProviderName As String = ""
                    Dim Location As String = ""
                    Dim Cost As Integer = 0
                    Using sqlConnection2 As New SqlConnection(connectionString)
                        sqlConnection2.Open()
                        Using sqlCommand2 As New SqlCommand(query2, sqlConnection2)
                            sqlCommand2.Parameters.AddWithValue("@ProviderID", ProviderId)
                            Dim providerDb As SqlDataReader = sqlCommand2.ExecuteReader()
                            Do While providerDb.Read()
                                ProviderName = providerDb.GetValue(1)
                                Cost = providerDb.GetValue(6)
                            Loop
                        End Using
                    End Using

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
                    spawnDivs(i, ProviderName, Location, Cost, datefinal, y, result.GetValue(0))
                    i += 1
                    y += 100
                Loop
            End Using
        End Using
    End Function

    Private Function completed()
        Dim splitContainerArray(1) As SplitContainer
        Dim y As Integer = 50
        Panel1.Controls.Clear()
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim query As String = "SELECT * FROM deals WHERE user_id = @UserId AND status = 2"
        Dim query2 As String = "SELECT * FROM provider where provider_id =@ProviderID"
        Dim query3 As String = "SELECT * FROM deals WHERE user_id = @UserId AND status = 3"
        Dim i As Integer = 0

        Dim result As SqlDataReader
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@UserId", User_ID) ' Use the password entered by the user
                result = sqlCommand.ExecuteReader()
                Do While result.Read()
                    Dim time As String = result.GetString(3)
                    Dim dateof As Date = result.GetValue(5)
                    Dim ProviderId As Integer = result.GetValue(2)
                    Dim ProviderName As String = ""
                    Dim Location As String = ""
                    Dim Cost As Integer = 0
                    Using sqlConnection2 As New SqlConnection(connectionString)
                        sqlConnection2.Open()
                        Using sqlCommand2 As New SqlCommand(query2, sqlConnection2)
                            sqlCommand2.Parameters.AddWithValue("@ProviderID", ProviderId)
                            Dim providerDb As SqlDataReader = sqlCommand2.ExecuteReader()
                            Do While providerDb.Read()
                                ProviderName = providerDb.GetValue(1)
                                Cost = providerDb.GetValue(6)
                            Loop
                        End Using
                    End Using

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
                    spawnDivsWithButton(splitContainerArray, i, ProviderName, Location, Cost, dateof, y, result.GetValue(0))
                    i += 1
                    y += 130
                Loop
            End Using
            sqlConnection.Close()
        End Using
        y -= 30
        Using sqlConnection As New SqlConnection(connectionString)
            sqlConnection.Open()
            Using sqlCommand As New SqlCommand(query3, sqlConnection)
                sqlCommand.Parameters.AddWithValue("@UserId", User_ID) ' Use the password entered by the user
                result = sqlCommand.ExecuteReader()
                Do While result.Read()
                    Dim time As String = result.GetString(3)
                    Dim dateof As Date = result.GetValue(5)
                    Dim ProviderId As Integer = result.GetValue(2)
                    Dim ProviderName As String = ""
                    Dim Location As String = ""
                    Dim Cost As Integer = 0
                    Using sqlConnection2 As New SqlConnection(connectionString)
                        sqlConnection2.Open()
                        Using sqlCommand2 As New SqlCommand(query2, sqlConnection2)
                            sqlCommand2.Parameters.AddWithValue("@ProviderID", ProviderId)
                            Dim providerDb As SqlDataReader = sqlCommand2.ExecuteReader()
                            Do While providerDb.Read()
                                ProviderName = providerDb.GetValue(1)
                                Cost = providerDb.GetValue(6)
                            Loop
                        End Using
                    End Using

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
                    spawnDivs(i, ProviderName, Location, Cost, dateof, y, result.GetValue(0))
                    i += 1
                    y += 100
                Loop
            End Using
            sqlConnection.Close()
        End Using
    End Function

    Private Sub user_appointments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upcoming()
    End Sub
End Class
