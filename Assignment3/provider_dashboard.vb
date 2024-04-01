Imports FastReport.DataVisualization.Charting
Imports Microsoft.Data.SqlClient

Public Class provider_dashboard
    Private Sub provider_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim series As New Series("DataSeries")
        series.ChartType = SeriesChartType.Column
        series.ChartArea = "MainChartArea"
        Chart1.Series.Add(series)

        ' Add data points for each day of the week manually
        Chart1.Series("DataSeries").Points.AddXY("Mon", 150)
        Chart1.Series("DataSeries").Points.AddXY("Tue", 200)
        Chart1.Series("DataSeries").Points.AddXY("Wed", 180)
        Chart1.Series("DataSeries").Points.AddXY("Thu", 220)
        Chart1.Series("DataSeries").Points.AddXY("Fri", 190)
        Chart1.Series("DataSeries").Points.AddXY("Sat", 210)
        Chart1.Series("DataSeries").Points.AddXY("Sun", 170)
    End Sub

    Private Sub GetTimeTable()
        Dim connectionString As String = "Server=sql5111.site4now.net;Database=db_aa6f6a_cs346assign3;User Id=db_aa6f6a_cs346assign3_admin;Password=swelab@123;"
        Dim providerId As Integer = Provider_ID ' Replace with the actual provider_id value
        Dim queryString As String = "SELECT time FROM deals WHERE provider_id = @ProviderId"

        ' Create a connection to the SQL Server database
        Using connection As New SqlConnection(connectionString)
            ' Create a SqlCommand to execute the query
            Dim command As New SqlCommand(queryString, connection)
            command.Parameters.AddWithValue("@ProviderId", providerId)

            ' Open the connection
            connection.Open()

            ' Execute the query and retrieve the results
            Using reader As SqlDataReader = command.ExecuteReader()
                ' Check if there are any rows returned
                If reader.HasRows Then
                    ' Iterate through the rows
                    While reader.Read()
                        ' Get the value from the 'time' column
                        Dim timeValue As String = reader.GetString(0) ' Assuming 'time' column is of type VARCHAR or NVARCHAR

                        ' Call the SetWorkingDayColors function with the processed value
                        SetWorkingDayColors(timeValue)
                    End While
                Else
                    Console.WriteLine("No rows found.")
                End If
            End Using
        End Using
    End Sub
    Private Sub SetWorkingDayColors(workingDays As String)
        ' Check if the workingDays string has the correct length (168 bits)


        For i As Integer = 0 To 83
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