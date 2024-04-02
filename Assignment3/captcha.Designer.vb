<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class captcha
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
        Label1 = New Label()
        PictureBox1 = New PictureBox()
        TextBox1 = New TextBox()
        Button1 = New Button()
        GroupBox1 = New GroupBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        GroupBox1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(100, 27)
        Label1.Name = "Label1"
        Label1.Size = New Size(167, 22)
        Label1.TabIndex = 0
        Label1.Text = "Match the Captcha!"
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Location = New Point(34, 25)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(224, 50)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' TextBox1
        ' 
        TextBox1.Location = New Point(34, 105)
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(224, 23)
        TextBox1.TabIndex = 2
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Purple
        Button1.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Button1.ForeColor = Color.White
        Button1.Location = New Point(149, 213)
        Button1.Name = "Button1"
        Button1.Size = New Size(75, 30)
        Button1.TabIndex = 3
        Button1.Text = "Match!"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' GroupBox1
        ' 
        GroupBox1.BackColor = Color.FromArgb(CByte(255), CByte(128), CByte(255))
        GroupBox1.Controls.Add(TextBox1)
        GroupBox1.Controls.Add(PictureBox1)
        GroupBox1.Location = New Point(46, 52)
        GroupBox1.Name = "GroupBox1"
        GroupBox1.Size = New Size(292, 155)
        GroupBox1.TabIndex = 4
        GroupBox1.TabStop = False
        ' 
        ' captcha
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(386, 251)
        Controls.Add(GroupBox1)
        Controls.Add(Button1)
        Controls.Add(Label1)
        Name = "captcha"
        Text = "Form1"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        GroupBox1.ResumeLayout(False)
        GroupBox1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents GroupBox1 As GroupBox
End Class
