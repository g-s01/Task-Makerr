Imports FastReport.DataVisualization.Charting

Public Class admin_dashboard
    Private Sub admin_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Chart1.Series.Add(series)

        ' Add data points for each day of the week manually
        Chart1.Series("DataSeries").Points.AddXY("Mon", 150)
        Chart1.Series("DataSeries").Points.AddXY("Tue", 200)
        Chart1.Series("DataSeries").Points.AddXY("Wed", 180)
        Chart1.Series("DataSeries").Points.AddXY("Thu", 220)
        Chart1.Series("DataSeries").Points.AddXY("Fri", 190)
        Chart1.Series("DataSeries").Points.AddXY("Sat", 210)
        Chart1.Series("DataSeries").Points.AddXY("Sun", 170)

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

        ' Set different shades of the color for each section
        series2.Points.AddXY("Bangalore", 30)
        series2.Points.AddXY("Delhi", 25)
        series2.Points.AddXY("Guwahati", 20)
        series2.Points.AddXY("Others", 25)

        ' Assign colors to the points
        series2.Points(0).Color = Color.FromArgb(220, 189, 232)
        series2.Points(1).Color = Color.FromArgb(180, 149, 202) ' You can adjust the shade as needed
        series2.Points(2).Color = Color.FromArgb(140, 109, 172) ' You can adjust the shade as needed
        series2.Points(3).Color = Color.FromArgb(100, 69, 142)  ' You can adjust the shade as needed

        Chart2.Series.Add(series2)

        ' Assuming rating is out of 5
        Dim rating As Integer = 4 ' Example rating, change this to your actual rating

        ' Calculate the value for the progress bar based on the rating
        Dim progressValue As Integer = (rating / 5) * ProgressBar1.Maximum

        ' Set the value for the progress bar
        ProgressBar1.Value = progressValue

        ' Assuming rating is out of 5
        Dim rating2 As Integer = 4 ' Example rating, change this to your actual rating

        ' Calculate the value for the progress bar based on the rating
        Dim progressValue2 As Integer = (rating2 / 5) * ProgressBar2.Maximum

        ' Set the value for the progress bar
        ProgressBar2.Value = progressValue2

    End Sub
End Class
