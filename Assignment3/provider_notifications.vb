Imports System.Data.SqlClient
Imports System.Configuration
Imports Microsoft.Data.SqlClient
Public Class provider_notifications

    'Dim providerId As Integer=Module_global.Provider_ID
    Dim providerId As Integer = 3
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Private Sub provider_notifications_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'new chats loading
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button4.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)

        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour,d.location " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 0" ' Assuming 0 represents 50% paid booking status


        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                FlowLayoutPanel1.Controls.Clear()
                'FlowLayoutPanel1.BackColor = Color.Black'

                While reader.Read()
                    Dim customerName As String = reader("username").ToString()
                    Dim slots As String = reader("time").ToString()
                    Dim costPerHour As Integer = Convert.ToInt32(reader("cost_per_hour"))
                    Dim location As String = reader("location").ToString()

                    ' Calculate the total amount of the deal based on the slot and cost per hour
                    Dim bookedHours As Integer = slots.Count(Function(c) c = "1")
                    Dim totalAmount As Integer = bookedHours * costPerHour / 2

                    ' Create a Panel control for each customer
                    Dim panel As New Panel()
                    panel.BorderStyle = BorderStyle.FixedSingle
                    panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                    panel.Location = New Point(40)
                    panel.Size = New Size(750, 100) ' Set the size of the panel (width: 300, height: 100)
                    panel.Margin = New Padding(5)
                    panel.AutoScroll = True

                    ' Create labels for customer details
                    Dim nameLabel As New Label()
                    nameLabel.Text = $"{customerName}"
                    nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    nameLabel.AutoSize = True
                    nameLabel.Location = New Point(30, 30) ' Set the location of the label within the panel

                    ' Create labels for customer details
                    Dim amount As New Label()
                    amount.Text = $"Amount Paid : {totalAmount}"
                    amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    amount.AutoSize = True
                    amount.Location = New Point(550, 30) ' Set the location of the label within the panel

                    Dim loc As New Label()
                    loc.Text = location
                    loc.Font = New Font("Microsoft YaHei", 9, FontStyle.Regular)
                    loc.AutoSize = True

                    ' Add labels to the panel
                    panel.Controls.Add(nameLabel)
                    panel.Controls.Add(amount)


                    ' Add the panel to the FlowLayoutPanel
                    FlowLayoutPanel1.Controls.Add(panel)
                End While
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button2.BackColor = Color.FromArgb(215, 181, 227)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button4.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 1" ' Assuming 0 represents 50% paid booking status


        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                FlowLayoutPanel1.Controls.Clear()
                'FlowLayoutPanel1.BackColor = Color.Black'

                While reader.Read()
                    Dim customerName As String = reader("username").ToString()
                    Dim slots As String = reader("time").ToString()
                    Dim costPerHour As Integer = Convert.ToInt32(reader("cost_per_hour"))

                    ' Calculate the total amount of the deal based on the slot and cost per hour
                    Dim bookedHours As Integer = slots.Count(Function(c) c = "1")
                    Dim totalAmount As Integer = bookedHours * costPerHour

                    ' Create a Panel control for each customer
                    Dim panel As New Panel()
                    panel.BorderStyle = BorderStyle.FixedSingle
                    panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                    panel.Location = New Point(40)
                    panel.Size = New Size(750, 80) ' Set the size of the panel (width: 300, height: 100)
                    panel.Margin = New Padding(5)
                    panel.AutoScroll = True

                    ' Create labels for customer details
                    Dim nameLabel As New Label()
                    nameLabel.Text = $"{customerName}"
                    nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    nameLabel.AutoSize = True
                    nameLabel.Location = New Point(30, 30) ' Set the location of the label within the panel

                    ' Create labels for customer details
                    Dim amount As New Label()
                    amount.Text = $"Amount Paid : {totalAmount}"
                    amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    amount.AutoSize = True
                    amount.Location = New Point(550, 30) ' Set the location of the label within the panel

                    ' Add labels to the panel
                    panel.Controls.Add(nameLabel)
                    panel.Controls.Add(amount)


                    ' Add the panel to the FlowLayoutPanel
                    FlowLayoutPanel1.Controls.Add(panel)
                End While
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button3.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button4.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)

        ' Query to retrieve user name, slot, and cost per hour for the given provider ID with 50% paid booking
        Dim query As String = "SELECT c.username as username, d.time as time, p.cost_per_hour " &
                              "FROM Deals d " &
                              "INNER JOIN customer c ON d.user_id = c.user_id " &
                              "INNER JOIN Provider p ON d.provider_id = p.provider_id " &
                              "WHERE d.provider_id = @ProviderId AND d.status = 3" ' Assuming 0 represents 50% paid booking status


        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(query, connection)
            command.Parameters.AddWithValue("@ProviderID", providerId)

            Try
                connection.Open()
                Dim reader As SqlDataReader = command.ExecuteReader()
                FlowLayoutPanel1.Controls.Clear()
                'FlowLayoutPanel1.BackColor = Color.Black'

                While reader.Read()
                    Dim customerName As String = reader("username").ToString()

                    ' Create a Panel control for each customer
                    Dim panel As New Panel()
                    panel.BorderStyle = BorderStyle.FixedSingle
                    panel.BackColor = Color.FromArgb(255, 220, 189, 232)
                    panel.Location = New Point(40)
                    panel.Size = New Size(750, 80) ' Set the size of the panel (width: 300, height: 100)
                    panel.Margin = New Padding(5)
                    panel.AutoScroll = True

                    ' Create labels for customer details
                    Dim nameLabel As New Label()
                    nameLabel.Text = $"{customerName}"
                    nameLabel.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    nameLabel.AutoSize = True
                    nameLabel.Location = New Point(30, 30) ' Set the location of the label within the panel

                    ' Create labels for customer details
                    Dim amount As New Label()
                    amount.Text = $"Cancelled"
                    amount.Font = New Font("Microsoft YaHei", 10, FontStyle.Bold)
                    amount.AutoSize = True
                    amount.Location = New Point(570, 30) ' Set the location of the label within the panel

                    ' Add labels to the panel
                    panel.Controls.Add(nameLabel)
                    panel.Controls.Add(amount)


                    ' Add the panel to the FlowLayoutPanel
                    FlowLayoutPanel1.Controls.Add(panel)
                End While
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            End Try
        End Using
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button4.BackColor = Color.FromArgb(215, 181, 227)
        Button2.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button3.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
        Button1.BackColor = Color.FromKnownColor(KnownColor.ActiveBorder)
    End Sub
End Class