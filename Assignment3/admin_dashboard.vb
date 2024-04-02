Imports FastReport.DataVisualization.Charting
Imports Microsoft.Data.SqlClient
Imports System.Data.SqlClient
Imports System.Windows.Forms.VisualStyles.VisualStyleElement


Public Class admin_dashboard
    Private Sub admin_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' Define your connection string
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"

        ' SQL Query to get counts of records for each day of the week within the last 7 days
        Dim barquery As String = "SELECT CONVERT(date, time_reg) AS Date, COUNT(*) AS Count FROM customer WHERE time_reg >= DATEADD(day, -7, GETDATE()) GROUP BY CONVERT(date, time_reg) ORDER BY CONVERT(date, time_reg)"

        Using connection As New SqlConnection(connectionString)
            connection.Open()
            Using command As New SqlCommand(barquery, connection)
                Using reader As SqlDataReader = command.ExecuteReader()
                    ' Clear existing series and chart areas
                    Chart1.Series.Clear()
                    Chart1.ChartAreas.Clear()

                    ' Create a new chart area
                    Dim chartArea As New ChartArea("MainChartArea")
                    Chart1.ChartAreas.Add(chartArea)

                    ' Create a new series
                    Dim series As New Series("DataSeries")
                    series.ChartType = SeriesChartType.Column
                    series.ChartArea = "MainChartArea"

                    ' Set the color of the series
                    series.Color = Color.FromArgb(220, 189, 232)

                    ' Add data points dynamically based on the query results
                    While reader.Read()
                        Dim dateValue As Date = Convert.ToDateTime(reader("Date"))
                        Dim count As Integer = Convert.ToInt32(reader("Count"))
                        Dim dayName As String = dateValue.ToString("ddd") ' Get day name (e.g., Mon, Tue, etc.)

                        ' Add data point to the series
                        series.Points.AddXY(dayName, count)
                    End While

                    ' Add the series to the chart
                    Chart1.Series.Add(series)
                End Using
            End Using
        End Using

        ' Query to fetch city names and their counts
        Dim doughquery As String = "SELECT location, COUNT(*) AS city_count FROM deals GROUP BY location"

        ' SQL Query to get count of rows in 'customer' table
        Dim customerCountQuery As String = "SELECT COUNT(*) AS CustomerCount FROM customer"

        ' SQL Query to get count of rows in 'provider' table
        Dim providerCountQuery As String = "SELECT COUNT(*) AS ProviderCount FROM provider"


        ' SQL Query to get count of rows in 'deals' table with 'status' column having value 3
        Dim countQuery As String = "SELECT COUNT(*) AS TotalDealCount FROM deals"
        Dim status3CountQuery As String = "SELECT COUNT(*) AS DealCount FROM deals WHERE status = 4"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Get total count of rows in 'deals' table
            Dim totalDealCount As Integer
            Using totalCommand As New SqlCommand(countQuery, connection)
                totalDealCount = Convert.ToInt32(totalCommand.ExecuteScalar())
            End Using

            ' Get count of rows in 'deals' table where 'status' column has value 3
            Dim status3Count As Integer
            Using status3Command As New SqlCommand(status3CountQuery, connection)
                status3Count = Convert.ToInt32(status3Command.ExecuteScalar())
            End Using

            ' Update Label8 with the count of deals with status 3
            Label8.Text = status3Count.ToString()

            ' Calculate the percentage
            Dim percentage As Double = (status3Count / totalDealCount) * 100

            ' Update Label9 with the percentage value
            Label7.Text = percentage.ToString("0.00") & "% of the Total Deals"
        End Using

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Get count of rows in 'customer' table
            Using customerCommand As New SqlCommand(customerCountQuery, connection)
                Dim customerCount As Integer = Convert.ToInt32(customerCommand.ExecuteScalar())
                Label12.Text = customerCount.ToString()
            End Using

            ' Get count of rows in 'provider' table
            Using providerCommand As New SqlCommand(providerCountQuery, connection)
                Dim providerCount As Integer = Convert.ToInt32(providerCommand.ExecuteScalar())
                Label15.Text = providerCount.ToString()
            End Using
        End Using

        ' Create connection and command objects
        Using connection As New SqlConnection(connectionString)
            Using command As New SqlCommand(doughquery, connection)
                Try
                    connection.Open()
                    Dim reader As SqlDataReader = command.ExecuteReader()

                    ' Chart2: Doughnut Chart
                    Chart2.Series.Clear()
                    Chart2.ChartAreas.Clear()

                    ' Create a new chart area
                    Dim chartArea2 As New ChartArea("MainChartArea2")
                    Chart2.ChartAreas.Add(chartArea2)

                    ' Create a new series
                    Dim series2 As New Series("DataSeries2")
                    series2.ChartType = SeriesChartType.Doughnut
                    series2.ChartArea = "MainChartArea2"

                    ' Loop through the result set and add data points to the series
                    While reader.Read()
                        Dim cityName As String = reader("location").ToString()
                        Dim cityCount As Integer = Convert.ToInt32(reader("city_count"))
                        series2.Points.AddXY(cityName, cityCount)
                    End While

                    ' Assign colors to the points (if needed)
                    ' Note: You may want to dynamically generate colors based on the number of cities.
                    series2.Points(0).Color = Color.FromArgb(220, 189, 232)
                    series2.Points(1).Color = Color.FromArgb(180, 149, 202)

                    ' Add the series to the chart
                    Chart2.Series.Add(series2)

                Catch ex As Exception
                    ' Handle any exceptions
                    MessageBox.Show("Error: " & ex.Message)
                End Try
            End Using
        End Using

        ' SQL Query to calculate average rating for customers
        Dim customerRatingQuery As String = "SELECT AVG(CAST(rating AS FLOAT)) AS AvgRating FROM feedback WHERE user_type = 'customer'"

        ' SQL Query to calculate average rating for providers
        Dim providerRatingQuery As String = "SELECT AVG(CAST(rating AS FLOAT)) AS AvgRating FROM feedback WHERE user_type = 'provider'"

        ' SQL Query to calculate overall average rating
        Dim overallRatingQuery As String = "SELECT AVG(CAST(rating AS FLOAT)) AS AvgRating FROM feedback"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Calculate average rating for customers
            Using customerCommand As New SqlCommand(customerRatingQuery, connection)
                Dim customerAvgRating As Double = Convert.ToDouble(customerCommand.ExecuteScalar())

                ' Calculate percentage for progress bar 1
                Dim customerPercentage As Integer = CInt((customerAvgRating / 5) * 100)
                ProgressBar1.Value = customerPercentage
                'Label1.Text = "Average Rating of Customers: " & customerAvgRating.ToString("0.00") & "/5"
            End Using

            ' Calculate average rating for providers
            Using providerCommand As New SqlCommand(providerRatingQuery, connection)
                Dim providerAvgRating As Double = Convert.ToDouble(providerCommand.ExecuteScalar())

                ' Calculate percentage for progress bar 2
                Dim providerPercentage As Integer = CInt((providerAvgRating / 5) * 100)
                ProgressBar2.Value = providerPercentage
                'Label2.Text = "Average Rating of Providers: " & providerAvgRating.ToString("0.00") & "/5"
            End Using

            ' Calculate overall average rating
            Using overallCommand As New SqlCommand(overallRatingQuery, connection)
                Dim overallAvgRating As Double = Convert.ToDouble(overallCommand.ExecuteScalar())
                Label20.Text = "Overall : " & overallAvgRating.ToString("0.00") & "/5"
            End Using
        End Using

        ' SQL Query to calculate the total cost
        Dim query As String = "SELECT SUM(CAST(CHARINDEX('1', time) AS FLOAT) * p.cost_per_hour) AS TotalCost " &
                              "FROM deals d " &
                              "INNER JOIN provider p ON d.provider_id = p.provider_id"

        Using connection As New SqlConnection(connectionString)
            connection.Open()

            ' Calculate the total cost
            Using command As New SqlCommand(query, connection)
                Dim totalCost As Double = Convert.ToDouble(command.ExecuteScalar())

                ' Update label with the total cost
                Label1.Text = totalCost.ToString("0.00")
            End Using
        End Using

    End Sub
End Class
