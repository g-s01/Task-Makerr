Public Class provider_template
    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub

    Private Sub provider_template_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With provider_appointments
            .TopLevel = False
            SplitContainer1.Panel2.Controls.Add(provider_appointments)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private WithEvents providerprofile As Provider_Profile_page

    Private Sub Profile_Navi_btn_Click(sender As Object, e As EventArgs) Handles Profile_Navi_btn.Click
        ' Create an instance of the Provider_Profile_page form
        providerprofile = New Provider_Profile_page()

        ' Set properties to ensure proper embedding
        providerprofile.TopLevel = False
        providerprofile.FormBorderStyle = FormBorderStyle.None
        providerprofile.Dock = DockStyle.Fill

        ' Subscribe to the EditProfileClicked event
        AddHandler providerprofile.EditProfileClicked, AddressOf ProviderProfile_EditProfileClicked

        ' Add the embedded form to the panel
        SplitContainer1.Panel2.Controls.Add(providerprofile)
        providerprofile.BringToFront()

        ' Show the embedded form
        providerprofile.Show()
    End Sub

    Private Sub ProviderProfile_EditProfileClicked(sender As Object, e As EventArgs)
        ' Embed the edit profile form when the EditProfileClicked event is raised
        Dim editproviderprofile As New EditProfilePage()

        ' Set properties to ensure proper embedding
        editproviderprofile.TopLevel = False
        editproviderprofile.FormBorderStyle = FormBorderStyle.None
        editproviderprofile.Dock = DockStyle.Fill

        ' Add the embedded form to the panel
        SplitContainer1.Panel2.Controls.Add(editproviderprofile)
        editproviderprofile.BringToFront()

        ' Show the embedded form
        editproviderprofile.Show()
    End Sub


    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Login.Show()
    End Sub
End Class