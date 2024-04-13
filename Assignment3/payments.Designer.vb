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
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        PictureBox3 = New PictureBox()
        Label1 = New Label()
        Label2 = New Label()
        GroupBox1 = New GroupBox()
        Label5 = New Label()
        TextBox3 = New TextBox()
        TextBox2 = New TextBox()
        Label4 = New Label()
        addButton = New Button()
        TextBox1 = New TextBox()
        Label3 = New Label()
        payButton = New Button()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.TM_Logo_1
        PictureBox1.Location = New Point(14, 16)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(71, 76)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.Image = My.Resources.Resources.Task_Makerr
        PictureBox2.Location = New Point(91, 39)
        PictureBox2.Margin = New Padding(3, 4, 3, 4)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(217, 67)
        PictureBox2.TabIndex = 1
        PictureBox2.TabStop = False
        ' 
        ' PictureBox3
        ' 
        PictureBox3.Image = My.Resources.Resources.backbtn
        PictureBox3.Location = New Point(394, 39)
        PictureBox3.Margin = New Padding(3, 4, 3, 4)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(114, 67)
        PictureBox3.TabIndex = 2
        PictureBox3.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label1.Location = New Point(14, 131)
        Label1.Name = "Label1"
        Label1.Size = New Size(334, 45)
        Label1.TabIndex = 3
        Label1.Text = "Payment Methods"
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label2.ForeColor = SystemColors.ActiveCaptionText
        Label2.Location = New Point(14, 179)
        Label2.Name = "Label2"
        Label2.Size = New Size(495, 20)
        Label2.TabIndex = 4
        Label2.Text = "_________________________________________________________________________________"
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.FromArgb(255, 192, 255)
        GroupBox1.Controls.Add(Label5)
        GroupBox1.Controls.Add(TextBox3)
        GroupBox1.Controls.Add(TextBox2)
        GroupBox1.Controls.Add(Label4)
        GroupBox1.Controls.Add(addButton)
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label3)
        GroupBox1.Location = New Point(26, 220)
        GroupBox1.Margin = New Padding(3, 4, 3, 4)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Padding = New Padding(3, 4, 3, 4)
        GroupBox1.Size = New Size(482, 516)
        GroupBox1.TabIndex = 5
        GroupBox1.TabStop = False
        ' 
        ' Label5
        ' 
        Label5.AutoSize = True
        Label5.Font = New Font("Microsoft YaHei", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label5.Location = New Point(50, 341)
        Label5.Name = "Label5"
        Label5.Size = New Size(338, 31)
        Label5.TabIndex = 6
        Label5.Text = "Add money to your wallet!"
        ' 
        ' TextBox3
        ' 
        TextBox3.Font = New Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        TextBox3.Location = New Point(65, 395)
        TextBox3.Margin = New Padding(3, 4, 3, 4)
        TextBox3.Name = "TextBox3"
        TextBox3.Size = New Size(114, 34)
        TextBox3.TabIndex = 5
        ' 
        ' TextBox2
        ' 
        TextBox2.Font = New Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        TextBox2.Location = New Point(65, 235)
        TextBox2.Margin = New Padding(3, 4, 3, 4)
        TextBox2.Name = "TextBox2"
        TextBox2.Size = New Size(170, 34)
        TextBox2.TabIndex = 4
        ' 
        ' Label4
        ' 
        Label4.AutoSize = True
        Label4.Font = New Font("Microsoft YaHei", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label4.Location = New Point(50, 177)
        Label4.Name = "Label4"
        Label4.Size = New Size(127, 36)
        Label4.TabIndex = 3
        Label4.Text = "Amount"
        ' 
        ' addButton
        ' 
        addButton.BackColor = Color.Purple
        addButton.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        addButton.ForeColor = Color.White
        addButton.Location = New Point(65, 453)
        addButton.Margin = New Padding(3, 4, 3, 4)
        addButton.Name = "addButton"
        addButton.Size = New Size(245, 39)
        addButton.TabIndex = 2
        addButton.Text = "Add money to wallet"
        addButton.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Font = New Font("Microsoft YaHei", 12F, FontStyle.Regular, GraphicsUnit.Point, 0)
        TextBox1.Location = New Point(65, 93)
        TextBox1.Margin = New Padding(3, 4, 3, 4)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(317, 34)
        TextBox1.TabIndex = 1
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft YaHei", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0)
        Label3.Location = New Point(50, 40)
        Label3.Name = "Label3"
        Label3.Size = New Size(101, 36)
        Label3.TabIndex = 0
        Label3.Text = "UPI ID"
        ' 
        ' payButton
        ' 
        payButton.BackColor = Color.Purple
        payButton.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, 0)
        payButton.ForeColor = SystemColors.ButtonHighlight
        payButton.Location = New Point(403, 760)
        payButton.Margin = New Padding(3, 4, 3, 4)
        payButton.Name = "payButton"
        payButton.Size = New Size(105, 53)
        payButton.TabIndex = 6
        payButton.Text = "Pay!"
        payButton.UseVisualStyleBackColor = False
        ' 
        ' payments
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(541, 845)
        Controls.Add(payButton)
        Controls.Add(GroupBox1)
        Controls.Add(Label2)
        Controls.Add(Label1)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Margin = New Padding(3, 4, 3, 4)
        Name = "payments"
        Text = "payments"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents addButton As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents payButton As Button
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents TextBox3 As TextBox
End Class
