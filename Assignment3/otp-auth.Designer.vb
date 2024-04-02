<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class otp_auth
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
        GroupBox1 = New GroupBox()
        TextBox1 = New TextBox()
        Label2 = New Label()
        Label1 = New Label()
        BackgroundWorker1 = New ComponentModel.BackgroundWorker()
        Button1 = New Button()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.FromArgb(CByte(255), CByte(192), CByte(255))
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(Label2)
        GroupBox1.Location = New Point(25, 83)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(412, 100)
        GroupBox1.TabIndex = 0
        GroupBox1.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(144, 57)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(111, 23)
        TextBox1.TabIndex = 1
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(6, 19)
        Label2.Name = "Label2"
        Label2.Size = New Size(402, 22)
        Label2.TabIndex = 0
        Label2.Text = "Write OTP received on your registered mail here"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(116, 37)
        Label1.Name = "Label1"
        Label1.Size = New Size(234, 31)
        Label1.TabIndex = 1
        Label1.Text = "OTP Confirmation"
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Purple
        Button1.Font = New Font("Microsoft YaHei", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(180, 189)
        Button1.Name = "Button1"
        Button1.Size = New Size(88, 34)
        Button1.TabIndex = 2
        Button1.Text = "Check!"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' otp_auth
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.ButtonHighlight
        ClientSize = New Size(463, 249)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Controls.Add(GroupBox1)
        Name = "otp_auth"
        Text = "otp_auth"
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents Label1 As Label
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents BackgroundWorker1 As System.ComponentModel.BackgroundWorker
    Friend WithEvents Button1 As Button
End Class
