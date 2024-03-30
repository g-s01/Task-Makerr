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

    Private Sub Panel_Click(sender As Object, e As EventArgs)
        Dim clickedPanel As Panel = DirectCast(sender, Panel)
        Dim panelIndex As Integer = Array.IndexOf(panelArray, clickedPanel)

        MessageBox.Show("Upper Panel Clicked - Index: " & panelIndex.ToString())

        ' Show related form for upper panel click
        'Dim relatedForm As New RelatedForm() ' Replace RelatedForm with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Sub Button_Click(sender As Object, e As EventArgs)
        MessageBox.Show("Button Clicked in Lower Panel")

        ' Show related form for button click
        'Dim relatedForm As New RelatedForm2() ' Replace RelatedForm2 with the actual name of your related form class
        'relatedForm.Show()
    End Sub

    Private Function upcoming()
        Dim num_appointments As Integer = 10
        ReDim panelArray(num_appointments - 1)

        Dim x As Integer = 10
        Dim y As Integer = 50
        Dim spacing As Integer = 100
        Panel1.Controls.Clear()
        For i As Integer = 0 To num_appointments - 1
            panelArray(i) = New System.Windows.Forms.Panel()
            panelArray(i).Location = New System.Drawing.Point(x, y)
            panelArray(i).Size = New System.Drawing.Size(700, 70)
            panelArray(i).BackColor = System.Drawing.Color.FromArgb(CByte(240), CByte(218), CByte(248))
            panelArray(i).AutoSize = True

            AddHandler panelArray(i).Click, AddressOf Panel_Click

            Dim name As New Label()
            name.AutoSize = True
            name.Location = New System.Drawing.Point(15, 10)
            name.Name = "name"
            name.Text = "Username"
            panelArray(i).Controls.Add(name)

            Dim place As New Label()
            place.AutoSize = True
            place.Location = New System.Drawing.Point(15, 40)
            place.Name = "place"
            place.Text = "Location"
            panelArray(i).Controls.Add(place)

            Dim cost As New Label()
            cost.AutoSize = True
            cost.Location = New System.Drawing.Point(630, 10)
            cost.Name = "cost"
            cost.Text = "Cost"
            panelArray(i).Controls.Add(cost)

            Dim timings As New Label()
            timings.AutoSize = True
            timings.Location = New System.Drawing.Point(535, 40)
            timings.Name = "timings"
            timings.Text = "Appointment schedule"
            panelArray(i).Controls.Add(timings)

            Panel1.Controls.Add(panelArray(i))
            y += spacing
        Next i
    End Function

    Private Function completed()
        Dim num_appointments As Integer = 10
        Dim splitContainerArray(num_appointments - 1) As SplitContainer
        Dim x As Integer = 10
        Dim y As Integer = 50
        Dim spacing As Integer = 130
        Panel1.Controls.Clear()
        For i As Integer = 0 To num_appointments - 1
            splitContainerArray(i) = New SplitContainer()
            splitContainerArray(i).Location = New System.Drawing.Point(x, y)
            splitContainerArray(i).Size = New System.Drawing.Size(700, 120)
            splitContainerArray(i).Orientation = Orientation.Horizontal
            splitContainerArray(i).SplitterDistance = 70
            splitContainerArray(i).Panel1.BackColor = System.Drawing.Color.FromArgb(CByte(240), CByte(218), CByte(248))

            AddHandler splitContainerArray(i).Panel1.Click, AddressOf Panel_Click

            Dim name As New Label()
            name.AutoSize = True
            name.Location = New System.Drawing.Point(15, 10)
            name.Name = "name"
            name.Text = "Username"
            splitContainerArray(i).Panel1.Controls.Add(name)

            Dim place As New Label()
            place.AutoSize = True
            place.Location = New System.Drawing.Point(15, 40)
            place.Name = "place"
            place.Text = "Location"
            splitContainerArray(i).Panel1.Controls.Add(place)

            Dim cost As New Label()
            cost.AutoSize = True
            cost.Location = New System.Drawing.Point(630, 10)
            cost.Name = "cost"
            cost.Text = "Cost"
            splitContainerArray(i).Panel1.Controls.Add(cost)

            Dim timings As New Label()
            timings.AutoSize = True
            timings.Location = New System.Drawing.Point(535, 40)
            timings.Name = "timings"
            timings.Text = "Appointment schedule"
            splitContainerArray(i).Panel1.Controls.Add(timings)

            Dim button As New Button()
            button.Text = "  Proceed to Pay   "
            button.AutoSize = True
            button.Location = New System.Drawing.Point(570, 0)
            button.FlatAppearance.BorderSize = 0
            button.FlatStyle = FlatStyle.Flat
            button.Font = New Font("Microsoft YaHei", 10.2F)
            button.BackColor = System.Drawing.Color.FromArgb(CByte(245), CByte(140), CByte(215))

            AddHandler button.Click, AddressOf Button_Click

            splitContainerArray(i).Panel2.Controls.Add(button)

            Panel1.Controls.Add(splitContainerArray(i))
            y += spacing
        Next i
    End Function

    Private Sub user_appointments_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        upcoming()
    End Sub
End Class
