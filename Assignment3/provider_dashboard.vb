Imports System.Globalization
Imports FastReport.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class provider_dashboard
    Private Sub provider_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label11.Text = Date.Today.ToString("dd-MM-yyyy")
        Label10.Text = Date.Today.AddDays(1).ToString("dd-MM-yyyy")
        Label9.Text = Date.Today.AddDays(2).ToString("dd-MM-yyyy")
        Label5.Text = Date.Today.AddDays(3).ToString("dd-MM-yyyy")
        Label6.Text = Date.Today.AddDays(4).ToString("dd-MM-yyyy")
        Label7.Text = Date.Today.AddDays(5).ToString("dd-MM-yyyy")
        Label8.Text = Date.Today.AddDays(6).ToString("dd-MM-yyyy")
        Chart_Init()
        GetTimeTable()
    End Sub

    Private Sub ChangeCellBackgroundColor(rowIndex As Integer, colIndex As Integer, backColor As Color)

        ' Create a new Panel control to act as the cell's background
        Dim panel As New Panel()
        panel.BackColor = backColor

        ' Remove any existing controls in the cell (optional)
        Dim existingControl As Control = slot_matrix_tablelayout.GetControlFromPosition(colIndex, rowIndex)
        If existingControl IsNot Nothing Then
            slot_matrix_tablelayout.Controls.Remove(existingControl)
        End If

        ' Add the panel control to the specified cell
        slot_matrix_tablelayout.Controls.Add(panel, colIndex, rowIndex)

        ' Adjust the panel's size to match the cell's size
        panel.Dock = DockStyle.Fill
    End Sub


    Private Sub Chart_Init()
        ' Clear existing series and chart areas
        Chart1.Series.Clear()
        Chart1.ChartAreas.Clear()

        ' Create a new chart area
        Dim chartArea As New ChartArea("MainChartArea")
        Chart1.ChartAreas.Add(chartArea)

        ' Create a new series
        Dim series As New Series("TotalDealAmount")
        series.ChartType = SeriesChartType.Column
        series.ChartArea = "MainChartArea"
        Chart1.Series.Add(series)
        Dim totalSum As Integer = 0
        Dim totalRecords As Integer = 0
        ' Retrieve data from the database
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim providerId As Integer = Provider_ID ' Replace with the actual provider_id value

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Query to get total deal amount for each date (ignoring time) for the past 7 days
            Dim query As String = "SELECT CONVERT(date, dates) AS [Date], SUM(deal_amount) AS total_amount FROM deals WHERE provider_id = @ProviderId AND dates >= DATEADD(day, -7, GETDATE()) GROUP BY CONVERT(date, dates) ORDER BY [Date]"
            Using command As New SqlCommand(query, connection)
                command.Parameters.AddWithValue("@ProviderId", providerId)

                Using reader As SqlDataReader = command.ExecuteReader()
                    While reader.Read()
                        Dim dateValue As Date = reader.GetDateTime(0)
                        Dim totalAmount As Integer = reader.GetInt32(1)
                        totalSum += totalAmount
                        ' Add data to the chart series
                        series.Points.AddXY(dateValue.ToString("dd-MM-yyyy"), totalAmount / 2)
                    End While
                End Using
            End Using
            Dim queryTotalRecords As String = "SELECT COUNT(*) FROM deals WHERE provider_id = @ProviderId AND dates >= DATEADD(day, -7, GETDATE())"
            Using commandTotalRecords As New SqlCommand(queryTotalRecords, connection)
                commandTotalRecords.Parameters.AddWithValue("@ProviderId", providerId)

                totalRecords = Convert.ToInt32(commandTotalRecords.ExecuteScalar())
            End Using
        End Using
        totalSum = totalSum / 2
        Label25.Text = "Rs" + totalSum.ToString()
        Label4.Text = totalRecords.ToString()
    End Sub





    ' Function to extract hours worked from the 84-bit string



    Private Sub GetTimeTable()
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim providerId As Integer = Provider_ID ' Replace with the actual provider_id value
        Dim endDate As Date = Date.Today ' Get today's date
        Dim startDate As Date = endDate.AddDays(-6) ' Subtract 6 days to get the start date
        Dim queryString As String = "SELECT dates, time FROM deals WHERE provider_id = @ProviderId AND status = 1 AND CONVERT(DATE, dates) BETWEEN @StartDate AND @EndDate"

        ' Create a connection to the SQL Server database
        Using connection As New SqlConnection(connectionString)
            ' Create a SqlCommand to execute the query
            Dim command As New SqlCommand(queryString, connection)
            command.Parameters.AddWithValue("@ProviderId", providerId)
            command.Parameters.AddWithValue("@StartDate", startDate)
            command.Parameters.AddWithValue("@EndDate", endDate)

            ' Open the connection
            connection.Open()

            ' Execute the query and retrieve the results
            Using reader As SqlDataReader = command.ExecuteReader()
                ' Check if there are any rows returned
                If reader.HasRows Then
                    ' Iterate through the rows
                    While reader.Read()
                        ' Get the values from the 'dates' and 'time' columns
                        Dim datesValue As Date = reader.GetDateTime(0) ' Assuming 'dates' column is of type DATE or DATETIME
                        Dim timeValue As String = reader.GetString(1) ' Assuming 'time' column is of type VARCHAR or NVARCHAR

                        ' Call the SetWorkingDayColors function with the processed values
                        SetWorkingDayColors(datesValue.ToString("yyyy-MM-dd"), timeValue)
                    End While
                Else
                    Console.WriteLine("No rows found.")
                End If
            End Using
        End Using
    End Sub

    Private Sub SetWorkingDayColors(dates As String, workingDays As String)
        ' Check if the workingDays string has the correct length (168 bits)
        Dim inputDate As Date = Date.ParseExact(dates, "yyyy-MM-dd", CultureInfo.InvariantCulture)

        ' Calculate the difference between the current date and the input date
        Dim diff As Integer = (Date.Today - inputDate).Days
        diff = 12 * diff
        workingDays = workingDays.Substring(diff, 84 - diff)
        For i As Integer = 0 To workingDays.Length - 1
            ' Check if the bit at position i is '1' in the workingDays string
            If workingDays(i) = "1"c Then
                Dim rowIndex As Integer = 0
                ' Calculate the row and column indices from the bit position i
                Dim colIndex As Integer
                If i < 12 Then
                    rowIndex = 0
                    colIndex = i + 1
                ElseIf i < 24 Then
                    rowIndex = 1
                    colIndex = i - 12 + 1
                ElseIf i < 36 Then
                    rowIndex = 2
                    colIndex = i - 24 + 1
                    ' Continue adding ElseIf conditions for each group of 13 values
                ElseIf i < 48 Then
                    rowIndex = 3
                    colIndex = i - 36 + 1
                ElseIf i < 60 Then
                    rowIndex = 4
                    colIndex = i - 48 + 1
                ElseIf i < 72 Then
                    rowIndex = 5
                    colIndex = i - 60 + 1
                ElseIf i < 84 Then
                    rowIndex = 6
                    colIndex = i - 72 + 1
                End If

                ' Change the background color of the cell at the calculated indices to Red
                ChangeCellBackgroundColor(rowIndex, colIndex, Color.FromArgb(173, 103, 200)) ' Change the color as per your requirement
            End If
        Next

    End Sub

End Class