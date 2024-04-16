<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class user_feedback
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Label1 = New Label()
        Label2 = New Label()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox5 = New PictureBox()
        txtFeedback = New TextBox()
        Label3 = New Label()
        PictureBox6 = New PictureBox()
        Label4 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.Font = New Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(205, 61)
        Label1.Name = "Label1"
        Label1.Size = New Size(431, 53)
        Label1.TabIndex = 5
        Label1.Text = "We Would Love Some Feedback"
        Label1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label2
        ' 
        Label2.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(271, 126)
        Label2.Name = "Label2"
        Label2.Size = New Size(283, 32)
        Label2.TabIndex = 6
        Label2.Text = "How Would you Rate us?" & vbCrLf
        Label2.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackgroundImage = My.Resources.Resources.grey_star
        PictureBox1.BackgroundImageLayout = ImageLayout.Center
        PictureBox1.ErrorImage = My.Resources.Resources.grey_star
        PictureBox1.InitialImage = My.Resources.Resources.grey_star
        PictureBox1.Location = New Point(254, 184)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(38, 45)
        PictureBox1.TabIndex = 7
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackgroundImage = My.Resources.Resources.grey_star
        PictureBox2.BackgroundImageLayout = ImageLayout.Center
        PictureBox2.Location = New Point(319, 184)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(40, 45)
        PictureBox2.TabIndex = 8
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackgroundImage = My.Resources.Resources.grey_star
        PictureBox3.BackgroundImageLayout = ImageLayout.Center
        PictureBox3.Location = New Point(381, 184)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(41, 45)
        PictureBox3.TabIndex = 9
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackgroundImage = My.Resources.Resources.grey_star
        PictureBox4.BackgroundImageLayout = ImageLayout.Center
        PictureBox4.Location = New Point(446, 184)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(43, 45)
        PictureBox4.TabIndex = 10
        PictureBox4.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackgroundImage = My.Resources.Resources.grey_star
        PictureBox5.BackgroundImageLayout = ImageLayout.Center
        PictureBox5.Location = New Point(511, 184)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(43, 45)
        PictureBox5.TabIndex = 11
        PictureBox5.TabStop = False
        ' 
        ' txtFeedback
        ' 
        txtFeedback.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFeedback.Location = New Point(112, 280)
        txtFeedback.Multiline = True
        txtFeedback.Name = "txtFeedback"
        txtFeedback.Size = New Size(614, 271)
        txtFeedback.TabIndex = 12
        txtFeedback.Text = "Write your feedback here..."
        ' 
        ' Label3
        ' 
        Label3.BackColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Label3.Font = New Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(340, 579)
        Label3.Name = "Label3"
        Label3.Size = New Size(149, 48)
        Label3.TabIndex = 13
        Label3.Text = "Send"
        Label3.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackgroundImage = My.Resources.Resources.Ellipse_6
        PictureBox6.BackgroundImageLayout = ImageLayout.Center
        PictureBox6.Location = New Point(737, 30)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(68, 67)
        PictureBox6.TabIndex = 14
        PictureBox6.TabStop = False
        ' 
        ' Label4
        ' 
        Label4.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(737, 100)
        Label4.Name = "Label4"
        Label4.Size = New Size(75, 25)
        Label4.TabIndex = 15
        Label4.Text = "Username"
        Label4.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' user_feedback
        ' 
        AutoScaleDimensions = New SizeF(7F, 17F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(844, 666)
        Controls.Add(Label4)
        Controls.Add(PictureBox6)
        Controls.Add(Label3)
        Controls.Add(txtFeedback)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox4)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Font = New Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "user_feedback"
        Text = "Form2"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Public WithEvents Label1 As Label
    Public WithEvents Label2 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents txtFeedback As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents Label4 As Label
End Class
