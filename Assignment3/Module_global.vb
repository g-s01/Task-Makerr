Imports System.IO
Module Module_global
    ' global variables to encourage information flow between different forms
    Public User_ID As Integer = 2
    Public Provider_ID As Integer = 3
    Public Email As String = ""
    Public provider_name As String = ""
    Public provider_profilepic As Image = My.Resources.male
    Public user_name As String = ""
    Public user_profilepic As Image = My.Resources.male
    Public user_appo_det_dealID_upcoming As Integer = 1
    Public user_appo_det_dealID_completed As Integer = 1
    Public DealID_Reschedule = 2
    Public Appointment_Det_DealId As Integer = 1
    Public slot_back_choice As Integer = 1
    Public cost_of_booking As Integer
    Public payment_successful As Integer = 0
    Public serviceType As String = ""
    Public service_types As List(Of String) = New List(Of String) From {"Cleaning", "Plumbing", "Electrical", "Painting", "Decorating", "Catering", "Photography", "Others"}
    Public provider_locations As List(Of String) = New List(Of String) From {"Panbazar", "Dispur", "Chandmari", "Zoo Road", "Beltola", "Khanapara", "Hatigaon", "Jalukbari", "Maligaon", "Garchuk"}
    Public roomchat As New List(Of Tuple(Of String, Integer, Integer))()
    Public Support_room_id As Integer = -1
    Public User_Role As String = "admin"

    ' Function to check if the password is in the common passwords file
    Function IsCommonPassword(ByVal password As String) As Boolean
        ' Assuming the text file is named "common_passwords" in your resources
        Dim commonPasswords As String() = My.Resources.common_passwords.Split(New String() {Environment.NewLine}, StringSplitOptions.None)

        ' Check if the password is in the list of common passwords
        Return commonPasswords.Contains(password)
    End Function
    Function PasswordStrengthCheck(password As String) As String

        Dim length As Integer = password.Length
        Dim score As Integer = 0
        Dim suggestions As String = ""
        Dim scorelabel As String = ""
        Dim strengthlabel As String = ""

        ' Check password length
        If IsCommonPassword(password) Then
            suggestions &= vbCrLf & "This password is too common."
            scorelabel = "Score: 0/7"
            strengthlabel = "Weak"
        Else
            Dim hasUppercase As Integer = 0
            Dim hasLowercase As Integer = 0
            Dim hasSpecialChar As Integer = 0
            Dim hasDigit As Integer = 0

            ' Check password for uppercase, lowercase, digit, and special character (including spaces)
            For Each ch As Char In password
                If Char.IsUpper(ch) Then
                    hasUppercase = 1
                ElseIf Char.IsLower(ch) Then
                    hasLowercase = 1
                ElseIf Char.IsDigit(ch) Then
                    hasDigit = 1
                Else
                    hasSpecialChar = 1
                End If
            Next

            score = score + hasUppercase + hasDigit + hasLowercase + hasSpecialChar

            ' Assign score based on password length
            If length >= 20 Then
                score += 3
            ElseIf length >= 12 Then
                score += 2
            ElseIf length >= 8 Then
                score += 1
            ElseIf length < 6 AndAlso score > 0 Then
                score -= 1
                suggestions &= vbCrLf & "Password is short." ' Feedback for short password
            End If

            ' Display suggestions for strengthening the password
            If hasUppercase = 0 Then
                suggestions &= vbCrLf & "Add uppercases to strengthen password."
            End If
            If hasLowercase = 0 Then
                suggestions &= vbCrLf & "Add lowercases to strengthen password."
            End If
            If hasSpecialChar = 0 Then
                suggestions &= vbCrLf & "Add special characters to strengthen password."
            End If
            If hasDigit = 0 Then
                suggestions &= vbCrLf & "Add digits to strengthen password."
            End If

            ' Display password score and strength
            scorelabel = "Score: " & score.ToString() & "/7"

            If score >= 5 Then
                strengthlabel = "Strong"
            ElseIf score >= 3 Then
                strengthlabel = "Moderate"
            Else
                strengthlabel = "Weak"
            End If

        End If

        ' Display feedback suggestions
        If suggestions <> "" Then
            suggestions = "Feedback:" & suggestions
        Else
            suggestions = ""
        End If
        ' Return the strength of the password
        PasswordStrengthCheck = scorelabel & vbCrLf & strengthlabel & vbCrLf & suggestions
    End Function
End Module
