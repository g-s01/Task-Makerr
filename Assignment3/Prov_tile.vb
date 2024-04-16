
Imports System.Configuration
Imports Microsoft.Data.SqlClient

Public Class Prov_tile
    Inherits UserControl

    ' Properties for item data
    Public Property ProviderName As String
    Public Property Loc As String
    Public Property ItemImage As Image
    Public Property Rating As Double
    Public Property Provider As Int32


    ' Constructor
    Public Sub New(provider As Int32, providerName As String, loc As String, rating As Double, itemImage As Image)
        InitializeComponent()
        Me.Provider = provider
        Me.ProviderName = providerName
        Me.Loc = loc
        Me.Rating = rating
        Me.ItemImage = itemImage
        Label1.Text = providerName
        Label2.Text = loc
        If rating = 6.0 Then
            Label3.Text = "No"
        Else
            Label3.Text = rating
        End If
        Dim line As New Label()

        ' Set the Label's properties
        line.AutoSize = False ' Allow the Label to be resized
        line.Height = 5 ' Set the height of the Label to create a thin line
        line.BorderStyle = BorderStyle.Fixed3D ' Set the border style to create a 3D effect
        line.Width = Me.Size.Width ' Set the width of the Label

        ' Position the Label where you want the line to be
        line.Top = 160 ' Position the Label 50 pixels from the top of the container
        line.Left = 0 ' Position the Label 10 pixels from the left of the container

        ' Add the Label to the tile (assuming the tile is a Panel or similar control)
        Me.Controls.Add(line)
        Dim toolTip As New ToolTip()
        toolTip.SetToolTip(Label1, Label1.Text)
        Dim toolTip1 As New ToolTip()
        toolTip1.SetToolTip(Label2, Label2.Text)

        'AddHandler Me.Click, AddressOf UserControl_Click

        ' Add the same Click event handler to the Click events of the child controls
        'For Each control As Control In Me.Controls
        '   AddHandler control.Click, AddressOf UserControl_Click
        'Next
        AddHandler Me.MouseEnter, AddressOf UserControl_MouseEnter
        AddHandler Me.MouseLeave, AddressOf UserControl_MouseLeave

        ' Add the same MouseEnter and MouseLeave event handlers to the events of the child controls
        For Each control As Control In Me.Controls
            AddHandler control.MouseEnter, AddressOf UserControl_MouseEnter
            AddHandler control.MouseLeave, AddressOf UserControl_MouseLeave
        Next
    End Sub

    'Private Sub UserControl_Click(sender As Object, e As EventArgs)
    ' Create an instance of the new form

    'Dim newForm As New Book_slots() ' Replace 'Form2' with the name of your form

    ' Show the new form
    '   newForm.Show()
    'End Sub
    Private Sub UserControl_MouseEnter(sender As Object, e As EventArgs)
        ' Change the BackColor of the UserControl to the hover color
        Me.BackColor = Color.LightBlue ' Replace 'Color.LightBlue' with your hover color
    End Sub

    Private Sub UserControl_MouseLeave(sender As Object, e As EventArgs)
        ' Change the BackColor of the UserControl back to the default color
        Me.BackColor = Color.White ' Replace 'Color.White' with your default color
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents PictureBox1 As PictureBox

    Private Sub InitializeComponent()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        Label3 = New Label()
        PictureBox2 = New PictureBox()
        Button1 = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.prov
        PictureBox1.Location = New Point(27, 5)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(97, 89)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.Location = New Point(16, 175)
        Label1.Name = "Label1"
        Label1.Size = New Size(75, 38)
        Label1.TabIndex = 1
        Label1.Text = "Label1"
        ' 
        ' Label2
        ' 
        Label2.Location = New Point(44, 124)
        Label2.Name = "Label2"
        Label2.Size = New Size(80, 35)
        Label2.TabIndex = 2
        Label2.Text = "Label2"
        ' 
        ' Label3
        ' 
        Label3.Location = New Point(117, 175)
        Label3.Name = "Label3"
        Label3.Size = New Size(53, 20)
        Label3.TabIndex = 3
        Label3.Text = "Label3"
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Star
        PictureBox2.Location = New Point(143, 165)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(25, 30)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 4
        PictureBox2.TabStop = False
        ' 
        ' Button1
        ' 
        Button1.BackColor = SystemColors.HotTrack
        Button1.FlatStyle = FlatStyle.Flat
        Button1.ForeColor = Color.White
        Button1.Location = New Point(-9, 195)
        Button1.Name = "Button1"
        Button1.Size = New Size(191, 40)
        Button1.TabIndex = 5
        Button1.Text = "Chat"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Prov_tile
        ' 
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(Button1)
        Controls.Add(PictureBox2)
        Controls.Add(Label3)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox1)
        Name = "Prov_tile"
        Size = New Size(173, 225)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox2 As PictureBox


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Assuming connectionString is defined elsewhere
        Dim roomId As Integer = -1

        'check whether the rooms are there 
        For Each item As Tuple(Of String, Integer, Integer) In Module_global.roomchat
            If item.Item3 = Provider Then
                ' Return the chat_room_id if the provider_id matches
                roomId = item.Item2
            End If
        Next
        If roomId <> -1 Then
            Dim userTemplate As user_template = Application.OpenForms("user_template")
            If userTemplate IsNot Nothing Then
                Dim user_provider_chats As New user_provider_chats()
                user_provider_chats.roomId = roomId
                userTemplate.switchPanel(user_provider_chats)
                userTemplate.chats_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
                userTemplate.home_btn.BackColor = SystemColors.Control

            End If

        ElseIf roomId = -1 Then
            Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString

            ' Create a SqlConnection object
            Using connection As New SqlConnection(connectionString)
                Try
                    ' Open the connection
                    connection.Open()

                    ' Create the query to select chat room ID
                    Dim userId As String = Module_global.User_ID
                    Dim providerId As String = Provider
                    Dim query As String = "SELECT chat_room_id FROM dbo.chat_room WHERE user_id=@userId AND provider_id=@providerId;"
                    ' Create a SqlCommand object with the select query and connection
                    Using selectCommand As New SqlCommand(query, connection)
                        ' Add parameters for select command
                        selectCommand.Parameters.AddWithValue("@userId", Module_global.User_ID)
                        selectCommand.Parameters.AddWithValue("@providerId", providerId)

                        ' Execute the select command and get the result
                        roomId = Convert.ToInt32(selectCommand.ExecuteScalar())

                        ' Check if the result is not null
                        If roomId > 0 Then
                            'MessageBox.Show("Chat room ID: " & roomId.ToString())
                        Else
                            ' If no chat room found, create a new one
                            Dim insertQuery As String = "INSERT INTO dbo.chat_room (user_id, provider_id, username, providername) VALUES (@userId, @providerId, @username, @providername); SELECT SCOPE_IDENTITY();"

                            ' Create a SqlCommand object with the insert query and connection
                            Using insertCommand As New SqlCommand(insertQuery, connection)
                                ' Add parameters for insert command
                                insertCommand.Parameters.AddWithValue("@userId", userId)
                                insertCommand.Parameters.AddWithValue("@providerId", providerId)
                                insertCommand.Parameters.AddWithValue("@username", Module_global.user_name)
                                insertCommand.Parameters.AddWithValue("@providername", ProviderName) ' Assuming "sahil_the_provider" is the provider name
                                ' Execute the insert command and get the inserted chat room ID
                                roomId = Convert.ToInt32(insertCommand.ExecuteScalar())

                                ' Display the newly created chat room ID
                                ' MessageBox.Show("New Chat room ID: " & roomId.ToString())

                            End Using
                        End If
                    End Using
                    If roomId > 0 Then
                        Dim userTemplate As user_template = Application.OpenForms("user_template")
                        If userTemplate IsNot Nothing Then
                            Dim user_provider_chats As New user_provider_chats()
                            user_provider_chats.roomId = roomId
                            userTemplate.switchPanel(user_provider_chats)
                            userTemplate.chats_btn.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
                            userTemplate.home_btn.BackColor = SystemColors.Control

                        End If
                    End If
                Catch ex As Exception
                    ' Handle any exceptions
                    'MessageBox.Show("An error occurred: " & ex.Message)
                End Try
            End Using
        End If

    End Sub


End Class
