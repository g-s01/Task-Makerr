<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserHome
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
        Profile_Pic = New PictureBox()
        Username = New Label()
        CType(Profile_Pic, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.ForeColor = SystemColors.ControlDarkDark
        Label1.Location = New Point(12, 34)
        Label1.Name = "Label1"
        Label1.Size = New Size(177, 35)
        Label1.TabIndex = 0
        Label1.Text = "Top Providers"
        ' 
        ' Profile_Pic
        ' 
        Profile_Pic.Image = My.Resources.Resources.Ellipse_6
        Profile_Pic.Location = New Point(756, 12)
        Profile_Pic.Name = "Profile_Pic"
        Profile_Pic.Size = New Size(104, 62)
        Profile_Pic.SizeMode = PictureBoxSizeMode.StretchImage
        Profile_Pic.TabIndex = 2
        Profile_Pic.TabStop = False
        ' 
        ' Username
        ' 
        Username.AutoSize = True
        Username.Font = New Font("Microsoft Sans Serif", 10.2F)
        Username.Location = New Point(775, 77)
        Username.Name = "Username"
        Username.Size = New Size(0, 20)
        Username.TabIndex = 3
        ' 
        ' UserHome
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        BackColor = Color.White
        ClientSize = New Size(929, 920)
        Controls.Add(Username)
        Controls.Add(Profile_Pic)
        Controls.Add(Label1)
        FormBorderStyle = FormBorderStyle.None
        Name = "UserHome"
        Text = "UserHome"
        CType(Profile_Pic, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Profile_Pic As PictureBox
    Friend WithEvents Username As Label
End Class
