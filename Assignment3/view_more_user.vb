Imports Microsoft.Data.SqlClient
Imports System.Configuration
Imports System.Drawing
Imports System.Windows.Forms.AxHost

Public Class view_more_user

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load



        'Example of how to connect to Database using connection string in app.config file.
        'Needs Microsoft.Data.SqlClient.
        'If not present, you need to get it through NuGet package manager
        'Access the same through context menu by clicking on project name.
        'If this is not available locally, you need to get it online.
        'For that you need to add nuget.org as source in Tools->NuGet...
        'Ask GPT for details.
        'As it stands, the System.Data.SqlClient does not work on .NET 5+ or .NET core (I assume default installed will be 8.0)
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                ' MessageBox.Show("Connection successful!")

            Catch ex As Exception
                ' MessageBox.Show("Error connecting to database: " & ex.Message)
            End Try
        End Using





        ComboBox1.Items.Add("Option 1")
        ComboBox1.Items.Add("Option 2")
        ComboBox1.Items.Add("Option 3")

        Dim Locations() As String = {"Option A", "Option B", "Option C"}
        ComboBox2.Items.AddRange(Locations)


        ' Set the default selected item for comboBox1
        ComboBox1.SelectedIndex = 0 ' This will select the first item ("Option 1")

        ' Hide comboBox2 initially
        ComboBox2.Visible = False






        ' Create an inner panel
        Dim innerPanel As New Panel()

        ' Set inner panel properties
        innerPanel.Location = New Point(27, 140) ' Fixed location
        'innerPanel.AutoScroll = False ' Disable scrolling in inner panel
        innerPanel.Size = New Size(1000, 1000)
        ' Add buttons to the inner panel (replace with your button creation logic)
        ' Set panel properties to enable scrolling
        innerPanel.AutoScroll = True ' Enable auto-scrolling




        ' Define button size and spacing
        Dim buttonWidth = 350
        Dim buttonHeight = 150
        Dim buttonSpacing = 35




        Dim data As New List(Of (Username As String, Location As List(Of String), Rating As Integer))()
        data.Add(("User1", New List(Of String) From {"Location1", "Location2", "Location1", "Location2", "Location1", "Location2", "Location1", "Location2"}, 4))
        data.Add(("User2", New List(Of String) From {"Location3", "Location4"}, 3))
        data.Add(("User3", New List(Of String) From {"Location5", "Location6"}, 5))
        data.Add(("User4", New List(Of String) From {"Location1", "Location2"}, 4))
        data.Add(("User5", New List(Of String) From {"Location3", "Location4"}, 3))
        data.Add(("User6", New List(Of String) From {"Location5", "Location6"}, 5))
        data.Add(("User7", New List(Of String) From {"Location1", "Location2"}, 4))
        data.Add(("User8", New List(Of String) From {"Location3", "Location4"}, 3))
        data.Add(("User9", New List(Of String) From {"Location5", "Location6"}, 5))




        Dim numOfTiles As Integer = 11




        Dim numberOfButtons As Integer
        numberOfButtons = numOfTiles



        innerPanel.AutoScrollMinSize = New Size(1000, 500 + (buttonHeight + buttonSpacing) * 1.0 * CInt(Math.Ceiling(numberOfButtons / CDbl(2)))) ' Adjust scroll area size as needed





        Dim photo As Image = My.Resources.User_Logo
        Dim originalImage As Image = My.Resources.prov ' Load the original image
        Dim profile_photo As New Bitmap(originalImage, New Size(100, 100)) ' Resize the image to the desired size



        Dim userTiles(numOfTiles - 1) As viewMore
        Dim tileClickedHandlers(numOfTiles - 1) As Action(Of Object, Integer)


        For i As Integer = 0 To numOfTiles - 1
            ' Calculate startX and startY based on the position in the grid
            Dim currentRow As Integer = i \ 2 ' Integer division to determine the row
            Dim currentColumn As Integer = i Mod 2 ' Modulus to determine the column
            Dim startX As Integer = currentColumn * (buttonWidth + buttonSpacing)
            Dim startY As Integer = currentRow * (buttonHeight + buttonSpacing)

            ' Create a viewMore instance with index, startX, and startY
            Dim userTile As New viewMore(i, startX, startY, New List(Of String) From {"Location3", "Location4"}, 4.5)

            ' Set the username for the viewMore instance
            userTile.Username = "Provider" & (i + 1).ToString()

            ' Add the viewMore instance to the array
            userTiles(i) = userTile

            ' Add event handler for TileClicked event
            AddHandler userTile.TileClicked, AddressOf viewMore_TileClicked

            ' Add the viewMore instance to the innerPanel
            innerPanel.Controls.Add(userTile)
        Next



        SplitContainer1.Panel2.Controls.Add(innerPanel)



    End Sub


    ' Event handler for TileClicked event
    Private Sub viewMore_TileClicked(sender As Object, e As Integer)
        ' Show the index of the clicked tile in a message box
        MessageBox.Show("Index of Clicked Tile: " & e.ToString())
    End Sub









    Private Sub Button7_Click(sender As Object, e As EventArgs) Handles Button7.Click
        MessageBox.Show("Hello World!")
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        ' Check if "Option 3" is selected
        If ComboBox1.SelectedItem IsNot Nothing AndAlso ComboBox1.SelectedItem.ToString() = "Option 3" Then
            ' Show comboBox2 if "Option 3" is selected
            ComboBox2.Visible = True
        Else
            ' Hide comboBox2 if "Option 3" is unselected
            ComboBox2.Visible = False
        End If
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub SplitContainer1_Panel2_Paint(sender As Object, e As PaintEventArgs) Handles SplitContainer1.Panel2.Paint

    End Sub
End Class