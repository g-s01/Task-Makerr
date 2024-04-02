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
            .FormBorderStyle = FormBorderStyle.None
            SplitContainer1.Panel2.Controls.Add(UserHome)
            .BringToFront()
            .Show()
        End With

    End Sub

    ' function to switch panel
    ' author: sarg19
    Sub switchPanel(ByVal panel As Form)
        SplitContainer1.Panel2.Controls.Clear()

        With panel
            .TopLevel = False
            .FormBorderStyle = FormBorderStyle.None
            .AutoSize = True
            .Dock = DockStyle.Fill
            SplitContainer1.Panel2.Controls.Add(panel)
            .BringToFront()
            .Show()
        End With
    End Sub

    Sub Reset_Buttons()
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = SystemColors.Control
    End Sub

    ' Home button
    ' author: sarg19
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = SystemColors.Control

        switchPanel(UserHome)
    End Sub

    ' Search button
    ' author: sarg19
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = SystemColors.Control

        switchPanel(user_search)

    End Sub

    ' Appointments button
    ' author: sarg19
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = SystemColors.Control

        switchPanel(user_appointments)

    End Sub

    ' Profile button
    ' author: sarg19
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = SystemColors.Control

        switchPanel(user_profile)

    End Sub

    ' Chats button
    ' author: sarg19
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = SystemColors.Control
        switchPanel(user_provider_chats)
    End Sub


    ' Help button
    ' author: sarg19
    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button7.BackColor = SystemColors.Control

        switchPanel(support_chat)
    End Sub

    ' Feedback button
    ' author: sarg19
    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        Button1.BackColor = SystemColors.Control
        Button2.BackColor = SystemColors.Control
        Button3.BackColor = SystemColors.Control
        Button4.BackColor = SystemColors.Control
        Button5.BackColor = SystemColors.Control
        Button6.BackColor = SystemColors.Control
        Button7.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))

        switchPanel(FeedbackForm)
    End Sub

    ' Logout button
    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Login.Show()
    End Sub


End Class
