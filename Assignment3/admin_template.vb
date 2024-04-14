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
        dashboard_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        chats_btn.BackColor = SystemColors.Control
        feedbacks_btn.BackColor = SystemColors.Control
    End Sub

    Private Sub Dashboard_btn_Click(sender As Object, e As EventArgs) Handles dashboard_btn.Click
        dashboard_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        chats_btn.BackColor = SystemColors.Control
        feedbacks_btn.BackColor = SystemColors.Control
        switchPanel(admin_dashboard)
    End Sub

    Private Sub Chats_btn_Click(sender As Object, e As EventArgs) Handles chats_btn.Click
        dashboard_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        feedbacks_btn.BackColor = SystemColors.Control
        switchPanel(admin_side_chat)
    End Sub

    Private Sub Feedbacks_btn_Click(sender As Object, e As EventArgs) Handles feedbacks_btn.Click
        dashboard_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        feedbacks_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        switchPanel(AdminFeedbackView)
    End Sub


    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Admin_Login.Show()
    End Sub
End Class