Imports System.Configuration
Imports Microsoft.Data.SqlClient

Public Class pending_payment
    Private Sub pending_payment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
        Using connection As New SqlConnection(connectionString)
            Try
                connection.Open()
                MessageBox.Show("Connection successful!")

            Catch ex As Exception
                MessageBox.Show("Error connecting to database: " & ex.Message)
            End Try
        End Using
    End Sub
End Class