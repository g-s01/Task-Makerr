Public Class admin_template
    Private Sub admin_template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Create an instance of the form to embed
        Dim adminDashboardForm As New admin_dashboard()

        ' Set properties to ensure proper embedding
        adminDashboardForm.TopLevel = False
        adminDashboardForm.FormBorderStyle = FormBorderStyle.None
        adminDashboardForm.Dock = DockStyle.Fill ' Optional: Fill the panel with the form

        ' Add the embedded form to the panel
        SplitContainer1.Panel2.Controls.Add(adminDashboardForm)

        ' Show the embedded form
        adminDashboardForm.Show()
    End Sub

    Sub switchPanel(ByVal panel As Form)
        SplitContainer1.Panel2.Controls.Clear()

        With panel
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            .FormBorderStyle = FormBorderStyle.None
            SplitContainer1.Panel2.Controls.Add(panel)
            .BringToFront()
            .Show()
        End With
    End Sub

    Sub Reset_Buttons()
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        switchPanel(admin_dashboard)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        switchPanel(AdminFeedbackView)
    End Sub




    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Admin_Login.Show()
    End Sub


End Class