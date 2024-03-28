Imports FastReport.DataVisualization.Charting

Public Class provider_dashboard
    Private Sub provider_dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Chart_Init()
        Dim workingDays As String = "011101011010101011110101110110100111111001110111000010001100101101101000101010100101"
        SetWorkingDayColors(workingDays)
    End Sub
    Private Sub ChangeCellBackgroundColor(rowIndex As Integer, colIndex As Integer, backColor As Color)
        ' Check if the specified cell indices are valid
        If rowIndex >= 0 AndAlso rowIndex < slot_matrix_tablelayout.RowCount AndAlso
            colIndex >= 0 AndAlso colIndex < slot_matrix_tablelayout.ColumnCount Then

            ' Create a new Panel control to act as the cell's background
            Dim panel As New Panel()
            panel.BackColor = backColor

            ' Remove any existing controls in the cell (optional)
            slot_matrix_tablelayout.Controls.Remove(slot_matrix_tablelayout.GetControlFromPosition(colIndex, rowIndex))

            ' Add the panel control to the specified cell
            slot_matrix_tablelayout.Controls.Add(panel, colIndex, rowIndex)

            ' Adjust the panel's size to match the cell's size
            panel.Dock = DockStyle.Fill
        End If
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

    Private Sub SetWorkingDayColors(workingDays As String)
        ' Check if the workingDays string has the correct length (168 bits)

        ' Iterate through each bit position (0 to 167)
        For i As Integer = 0 To 83
            ' Check if the bit at position i is '1' in the workingDays string
            If workingDays(i) = "1"c Then
                ' Calculate the row and column indices from the bit position i
                Dim rowIndex As Integer = i \ 7
                Dim colIndex As Integer = (i Mod 12) + 1

                ' Change the background color of the cell at the calculated indices to Red
                ChangeCellBackgroundColor(rowIndex, colIndex, Color.FromArgb(173, 103, 200))
            End If
        Next

    End Sub

End Class