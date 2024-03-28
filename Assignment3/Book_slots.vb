Imports System.Drawing.Drawing2D

Public Class Book_slots
    Public user As Integer = 0
    Public provider As Integer = 0
    Public ProviderName As String = "NULL"
    Private availability(6, 23) As Boolean ' 7 days, 24 hours , Load it from database
    Public Sub Book_slots_load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Run your function here
        MakePictureBoxRound(Profile_Pic)
        Dim rnd As New Random()

        Provider_Name_Loc_Lbl.Text = ProviderName + "     >     Slot Booking"
        ' Load availability from database
        For i As Integer = 0 To 6
            For j As Integer = 0 To 23
                Dim randomNumber As Integer = Math.Round(rnd.NextDouble())
                availability(i, j) = randomNumber

            Next
        Next

        ' Populate the schedule table
        PopulateScheduleTable()
    End Sub
    Private Sub PopulateScheduleTable()
        ' Clear existing controls in the table layout panel

        Schedule_Table.Controls.Clear()
        ' Clear any existing column and row styles
        Schedule_Table.ColumnStyles.Clear()
        Schedule_Table.RowStyles.Clear()

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
                AddHandler btn.Click, AddressOf TimeSlot_Click
                If availability(i, j) Then
                    btn.BackColor = Color.LightGreen ' Available
                Else
                    btn.BackColor = Color.Transparent ' Unavailable
                End If
                btn.Margin = New Padding(0)
                btn.FlatStyle = FlatStyle.Flat ' Set the button to have a flat appearance
                Schedule_Table.Controls.Add(btn, j + 1, i + 1)
            Next
        Next
    End Sub

    Private Sub TimeSlot_Click(sender As Object, e As EventArgs)
        Dim btn As Button = DirectCast(sender, Button)
        Dim cellPosition As TableLayoutPanelCellPosition = Schedule_Table.GetPositionFromControl(btn)

        Dim dayIndex As Integer = cellPosition.Row - 1
        Dim hourIndex As Integer = cellPosition.Column - 1

        If availability(dayIndex, hourIndex) Then
            ' Schedule available, allow booking or do something else
            MessageBox.Show($"Schedule available for {DateTime.Today.AddDays(dayIndex).ToString("ddd, dd MMM")} at {hourIndex.ToString("00")}:00. You can book this time slot.")
        Else
            ' Schedule unavailable
            MessageBox.Show($"This time slot is already booked for {DateTime.Today.AddDays(dayIndex).ToString("ddd, dd MMM")} at {hourIndex.ToString("00")}:00.")
        End If
    End Sub

    Public Sub MakePictureBoxRound(pictureBox As PictureBox)
        ' Create a GraphicsPath to define a circle
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, pictureBox.Width, pictureBox.Height)

        ' Set the PictureBox's region to the circle defined by the GraphicsPath
        pictureBox.Region = New Region(path)
        'Change according to the user after fetching from the database
        pictureBox.Image = My.Resources.download
        pictureBox.SizeMode = PictureBoxSizeMode.Zoom
    End Sub
    Private Sub DisplayMessageOnLoad()
        ' Your function code here
        MessageBox.Show("This message appears when the form loads.")
    End Sub


End Class