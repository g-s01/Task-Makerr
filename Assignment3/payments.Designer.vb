<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class payments
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(payments))
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        WebView21 = New Microsoft.Web.WebView2.WinForms.WebView2()
        TextBox2 = New TextBox()
        Label4 = New Label()
        verifyButton = New Button()
        TextBox1 = New TextBox()
        Label3 = New Label()
        payButton = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.TM_Logo_1
        PictureBox1.Location = New Point(12, 12)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(62, 57)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Task_Makerr
        PictureBox2.Location = New Point(80, 29)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(190, 50)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.backbtn
        PictureBox3.Location = New Point(1022, 19)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(100, 50)
        PictureBox3.TabIndex = 2
        PictureBox3.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(12, 98)
        Label1.Name = "Label1"
        Label1.Size = New Size(266, 36)
        Label1.TabIndex = 3
        Label1.Text = "Payment Methods"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(12, 134)
        Label2.Name = "Label2"
        Label2.Size = New Size(1057, 15)
        Label2.TabIndex = 4
        Label2.Text = resources.GetString("Label2.Text")
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(255))
        GroupBox1.Controls.Add(WebView21)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(verifyButton)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(23, 165)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(1038, 387)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        ' 
        ' WebView21
        ' 
        WebView21.CreationProperties = Nothing
        WebView21.DefaultBackgroundColor = Color.White
        WebView21.Location = New Point(288, 221)
        WebView21.Name = "WebView21"
        WebView21.Size = New Size(75, 23)
        WebView21.TabIndex = 5
        WebView21.ZoomFactor = 1R
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox2.Location = New Point(68, 320)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(149, 29)
        TextBox2.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft YaHei", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label4.Location = New Point(57, 280)
        Label4.Name = "Label4"
        Label4.Size = New Size(100, 28)
        Label4.TabIndex = 3
        Label4.Text = "Amount"
        ' 
        ' verifyButton
        ' 
        verifyButton.BackColor = Color.Purple
        verifyButton.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        verifyButton.ForeColor = Color.White
        verifyButton.Location = New Point(375, 70)
        verifyButton.Name = "verifyButton"
        verifyButton.Size = New Size(113, 29)
        verifyButton.TabIndex = 2
        verifyButton.Text = "Verify"
        verifyButton.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        TextBox1.Location = New Point(57, 70)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(278, 29)
        TextBox1.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft YaHei", 15.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label3.Location = New Point(44, 30)
        Label3.Name = "Label3"
        Label3.Size = New Size(79, 28)
        Label3.TabIndex = 0
        Label3.Text = "UPI ID"
        ' 
        ' payButton
        ' 
        payButton.BackColor = Color.Purple
        payButton.Font = New Font("Microsoft YaHei", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        payButton.ForeColor = SystemColors.ButtonHighlight
        payButton.Location = New Point(969, 621)
        payButton.Name = "payButton"
        payButton.Size = New Size(92, 40)
        payButton.TabIndex = 6
        payButton.Text = "Pay!"
        payButton.UseVisualStyleBackColor = False
        ' 
        ' payments
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(1134, 673)
        Controls.Add(payButton)
        Controls.Add(GroupBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Name = "payments"
        Text = "payments"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        CType(WebView21, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents verifyButton As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents payButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents WebView21 As Microsoft.Web.WebView2.WinForms.WebView2
End Class
