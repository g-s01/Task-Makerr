Imports System.Configuration
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax
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
        If panel.Name = "UserHome" Then
            If UserHome IsNot Nothing Then
                With UserHome
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    Me.SplitContainer1.Panel2.Controls.Add(UserHome)
                    .ReloadData()
                    .BringToFront()
                    .Show()
                End With
            Else
                With UserHome
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    Me.SplitContainer1.Panel2.Controls.Add(UserHome)
                    .BringToFront()
                    .Show()
                End With
            End If
        ElseIf panel.Name = "user_search" Then
            If user_search IsNot Nothing Then
                With user_search
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    Me.SplitContainer1.Panel2.Controls.Add(user_search)
                    .SimulateLoad()
                    .BringToFront()
                    .Show()
                End With
            Else
                With user_search
                    .TopLevel = False
                    .AutoSize = True
                    .Dock = DockStyle.Fill
                    Me.SplitContainer1.Panel2.Controls.Add(user_search)
                    .BringToFront()
                    .Show()
                End With
            End If
        Else
            With panel
                .TopLevel = False
                .FormBorderStyle = FormBorderStyle.None
                .AutoSize = True
                .Dock = DockStyle.Fill
                .FormBorderStyle = BorderStyle.None
                SplitContainer1.Panel2.Controls.Add(panel)
                .BringToFront()
                .Show()
            End With
        End If
    End Sub

    Sub Reset_Buttons()
        home_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = SystemColors.Control
    End Sub

    ' Home button
    ' author: sarg19
    Private Sub Home_btn_Click(sender As Object, e As EventArgs) Handles home_btn.Click
        home_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = SystemColors.Control

        switchPanel(UserHome)
    End Sub

    ' Search button
    ' author: sarg19
    Private Sub Search_btn_Click(sender As Object, e As EventArgs) Handles search_btn.Click
        home_btn.BackColor = SystemColors.Control
        search_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = SystemColors.Control

        switchPanel(user_search)

    End Sub

    ' Appointments button
    ' author: sarg19
    Private Sub Appointments_btn_Click(sender As Object, e As EventArgs) Handles appointments_btn.Click
        home_btn.BackColor = SystemColors.Control
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = SystemColors.Control

        switchPanel(user_appointments)

    End Sub

    ' Profile button
    ' author: sarg19
    Private Sub Profile_btn_Click(sender As Object, e As EventArgs) Handles profile_btn.Click
        home_btn.BackColor = SystemColors.Control
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = SystemColors.Control

        switchPanel(user_profile)

    End Sub

    ' Chats button
    ' author: sarg19
    Private Sub Chats_btn_Click(sender As Object, e As EventArgs) Handles chats_btn.Click
        home_btn.BackColor = SystemColors.Control
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = SystemColors.Control
        switchPanel(user_provider_chats)
    End Sub


    ' Help button
    ' author: sarg19
    Private Sub Help_btn_Click(sender As Object, e As EventArgs) Handles help_btn.Click
        home_btn.BackColor = SystemColors.Control
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        feedback_btn.BackColor = SystemColors.Control

        switchPanel(support_chat)
    End Sub

    ' Feedback button
    ' author: sarg19
    Private Sub Feedback_btn_Click(sender As Object, e As EventArgs) Handles feedback_btn.Click
        home_btn.BackColor = SystemColors.Control
        search_btn.BackColor = SystemColors.Control
        appointments_btn.BackColor = SystemColors.Control
        profile_btn.BackColor = SystemColors.Control
        chats_btn.BackColor = SystemColors.Control
        help_btn.BackColor = SystemColors.Control
        feedback_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))

        switchPanel(FeedbackForm)
    End Sub

    ' Logout button
    Private Sub Logout_btn_Click(sender As Object, e As EventArgs) Handles logout_btn.Click
        Me.Close()
        Login.Show()
    End Sub
End Class
