<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FeedbackForm
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
        lblTitle = New Label()
        lblRateUs = New Label()
        txtFeedback = New TextBox()
        btnSend = New Button()
        Panel1 = New Panel()
        star5 = New PictureBox()
        star4 = New PictureBox()
        star3 = New PictureBox()
        star2 = New PictureBox()
        star1 = New PictureBox()
        Panel1.SuspendLayout()
        CType(star5, ComponentModel.ISupportInitialize).BeginInit()
        CType(star4, ComponentModel.ISupportInitialize).BeginInit()
        CType(star3, ComponentModel.ISupportInitialize).BeginInit()
        CType(star2, ComponentModel.ISupportInitialize).BeginInit()
        CType(star1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Microsoft YaHei", 18F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblTitle.Location = New Point(185, 60)
        lblTitle.Margin = New Padding(4, 0, 4, 0)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(480, 39)
        lblTitle.TabIndex = 0
        lblTitle.Text = "We Would Love Some Feedback"
        lblTitle.TextAlign = ContentAlignment.TopCenter
        ' 
        ' lblRateUs
        ' 
        lblRateUs.AutoSize = True
        lblRateUs.Font = New Font("Microsoft YaHei", 16.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        lblRateUs.Location = New Point(240, 120)
        lblRateUs.Margin = New Padding(4, 0, 4, 0)
        lblRateUs.Name = "lblRateUs"
        lblRateUs.Size = New Size(348, 36)
        lblRateUs.TabIndex = 1
        lblRateUs.Text = "How would you Rate Us?"
        lblRateUs.TextAlign = ContentAlignment.TopCenter
        ' 
        ' txtFeedback
        ' 
        txtFeedback.BorderStyle = BorderStyle.FixedSingle
        txtFeedback.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtFeedback.Location = New Point(183, 310)
        txtFeedback.Margin = New Padding(4, 5, 4, 5)
        txtFeedback.Multiline = True
        txtFeedback.Name = "txtFeedback"
        txtFeedback.PlaceholderText = "Write your feedback here..."
        txtFeedback.Size = New Size(480, 192)
        txtFeedback.TabIndex = 7
        txtFeedback.Text = "Write your feedback here..."
        ' 
        ' btnSend
        ' 
        btnSend.BackColor = Color.FromArgb(CByte(224), CByte(198), CByte(234))
        btnSend.FlatAppearance.BorderSize = 0
        btnSend.FlatStyle = FlatStyle.Flat
        btnSend.Font = New Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSend.Location = New Point(346, 529)
        btnSend.Margin = New Padding(4, 5, 4, 5)
        btnSend.Name = "btnSend"
        btnSend.Size = New Size(133, 46)
        btnSend.TabIndex = 8
        btnSend.Text = "Send"
        btnSend.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.ButtonHighlight
        Panel1.Controls.Add(btnSend)
        Panel1.Controls.Add(star5)
        Panel1.Controls.Add(star4)
        Panel1.Controls.Add(star3)
        Panel1.Controls.Add(star2)
        Panel1.Controls.Add(txtFeedback)
        Panel1.Controls.Add(star1)
        Panel1.Controls.Add(lblTitle)
        Panel1.Controls.Add(lblRateUs)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(840, 670)
        Panel1.TabIndex = 11
        ' 
        ' star5
        ' 
        star5.Image = My.Resources.Resources.bg_star
        star5.Location = New Point(519, 191)
        star5.Name = "star5"
        star5.Size = New Size(62, 52)
        star5.SizeMode = PictureBoxSizeMode.AutoSize
        star5.TabIndex = 10
        star5.TabStop = False
        ' 
        ' star4
        ' 
        star4.Image = My.Resources.Resources.bg_star
        star4.InitialImage = My.Resources.Resources.bg_star
        star4.Location = New Point(451, 191)
        star4.Name = "star4"
        star4.Size = New Size(62, 52)
        star4.SizeMode = PictureBoxSizeMode.AutoSize
        star4.TabIndex = 9
        star4.TabStop = False
        ' 
        ' star3
        ' 
        star3.Image = My.Resources.Resources.bg_star
        star3.Location = New Point(383, 191)
        star3.Name = "star3"
        star3.Size = New Size(62, 52)
        star3.SizeMode = PictureBoxSizeMode.AutoSize
        star3.TabIndex = 8
        star3.TabStop = False
        ' 
        ' star2
        ' 
        star2.Image = My.Resources.Resources.bg_star
        star2.Location = New Point(315, 191)
        star2.Name = "star2"
        star2.Size = New Size(62, 52)
        star2.SizeMode = PictureBoxSizeMode.AutoSize
        star2.TabIndex = 3
        star2.TabStop = False
        ' 
        ' star1
        ' 
        star1.Image = My.Resources.Resources.bg_star
        star1.Location = New Point(247, 191)
        star1.Name = "star1"
        star1.Size = New Size(62, 52)
        star1.SizeMode = PictureBoxSizeMode.AutoSize
        star1.TabIndex = 2
        star1.TabStop = False
        ' 
        ' FeedbackForm
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(840, 670)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        Name = "FeedbackForm"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Feedback Form"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        CType(star5, ComponentModel.ISupportInitialize).EndInit()
        CType(star4, ComponentModel.ISupportInitialize).EndInit()
        CType(star3, ComponentModel.ISupportInitialize).EndInit()
        CType(star2, ComponentModel.ISupportInitialize).EndInit()
        CType(star1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)

    End Sub

    Friend WithEvents lblTitle As Label
    Friend WithEvents lblRateUs As Label
    Friend WithEvents txtFeedback As TextBox
    Friend WithEvents btnSend As Button
    Friend WithEvents Panel1 As Panel
    Friend WithEvents star5 As PictureBox
    Friend WithEvents star4 As PictureBox
    Friend WithEvents star3 As PictureBox
    Friend WithEvents star2 As PictureBox
    Friend WithEvents star1 As PictureBox
End Class