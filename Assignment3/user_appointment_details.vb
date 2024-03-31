Imports System.Configuration
Imports Microsoft.Data.SqlClient
Public Class user_appointment_details
    Dim connectionString As String = ConfigurationManager.ConnectionStrings("MyConnectionString").ConnectionString
    Private Sub user_appointment_details_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btn_reschedule_Click(sender As Object, e As EventArgs) Handles btn_reschedule.Click
        ''Calcullate the 
    End Sub
End Class