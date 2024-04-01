Imports System.Configuration
Imports Microsoft.Data.SqlClient
Public Class user_template
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Example of how to connect to Database using connection string in app.config file.
        'Needs Microsoft.Data.SqlClient.
        'If not present, you need to get it through NuGet package manager
        'Access the same through context menu by clicking on project name.
        'If this is not available locally, you need to get it online.
        'For that you need to add nuget.org as source in Tools->NuGet...
        'Ask GPT for details.
        'As it stands, the System.Data.SqlClient does not work on .NET 5+ or .NET core (I assume default installed will be 8.0)
        'Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        'Using connection As New SqlConnection(connectionString)
        '    Try
        '        connection.Open()
        '        MessageBox.Show("Connection successful!")

        '    Catch ex As Exception
        '        MessageBox.Show("Error connecting to database: " & ex.Message)
        '    End Try
        'End Using
        SplitContainer1.Panel2.Controls.Clear()
        With UserHome
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            SplitContainer1.Panel2.Controls.Add(UserHome)
            .BringToFront()
            .Show()
        End With

    End Sub

    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MessageBox.Show("Hello World!")
    End Sub

    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Login.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SplitContainer1.Panel2.Controls.Clear()
        With UserHome
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            SplitContainer1.Panel2.Controls.Add(UserHome)
            .BringToFront()
            .Show()
        End With
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        SplitContainer1.Panel2.Controls.Clear()
        With user_appointments
            .TopLevel = False
            .AutoSize = True
            .Dock = DockStyle.Fill
            SplitContainer1.Panel2.Controls.Add(user_appointments)
            .BringToFront()
            .Show()
        End With
    End Sub
End Class
