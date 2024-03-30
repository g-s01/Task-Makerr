Public Class admin_template
    Private Sub admin_template_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ' Create an instance of Chat form
        Dim chatForm As New Chat()

        ' Set the form's AutoSize property to true
        chatForm.AutoSize = True

        ' Set the form's TopLevel property to false
        chatForm.TopLevel = False

        ' Add the form to Panel2
        SplitContainer1.Panel2.Controls.Add(chatForm)

        ' Set padding around the form
        Dim padding As Integer = 5
        chatForm.Location = New Point(padding, padding)
        chatForm.ClientSize = New Size(SplitContainer1.Panel2.ClientSize.Width - 2 * padding, SplitContainer1.Panel2.ClientSize.Height - 2 * padding)

        ' Set the form's Dock property to fill Panel2
        chatForm.Dock = DockStyle.Fill

        ' Display the form
        chatForm.Show()
    End Sub





End Class