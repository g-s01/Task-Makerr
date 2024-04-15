Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Drawing.Text
Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class captcha
    Dim rnd As New Random()
    Dim captchaText As String = GenerateRandomText()

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DrawCaptcha()
    End Sub

    Private Sub DrawCaptcha()
        Dim imgWidth As Integer = PictureBox1.Width
        Dim imgHeight As Integer = PictureBox1.Height

        Dim bmp As New Bitmap(imgWidth, imgHeight)
        Dim g As Graphics = Graphics.FromImage(bmp)
        g.Clear(Color.White)

        Dim font As New Font("Arial", 20, FontStyle.Bold)
        Dim brush As New SolidBrush(Color.Black)

        ' Draw random text
        g.DrawString(captchaText, font, brush, New Point(10, 10))

        ' Add noise to the image
        For i As Integer = 0 To 100
            bmp.SetPixel(rnd.Next(0, imgWidth), rnd.Next(0, imgHeight), Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)))
        Next

        ' Draw lines on the image
        For i As Integer = 0 To 5
            Dim pen As New Pen(Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)))
            g.DrawLine(pen, rnd.Next(0, imgWidth), rnd.Next(0, imgHeight), rnd.Next(0, imgWidth), rnd.Next(0, imgHeight))
        Next

        PictureBox1.Image = bmp
    End Sub

    Private Function GenerateRandomText() As String
        Dim possibleChars As String = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"
        Dim captcha As String = ""

        For i As Integer = 1 To 6 ' Generate a 6-character captcha
            captcha &= possibleChars(rnd.Next(0, possibleChars.Length))
        Next

        Return captcha
    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If TextBox1.Text.ToLower() = captchaText.ToLower() Then
            MessageBox.Show("CAPTCHA passed!")
            DialogResult = DialogResult.OK
            captchaText = GenerateRandomText()
            TextBox1.Clear()
            Close()
        Else
            MessageBox.Show("CAPTCHA failed! Please try again.")
            TextBox1.Clear()
            captchaText = GenerateRandomText()
            DrawCaptcha() ' Redraw the captcha image
        End If
    End Sub
End Class
