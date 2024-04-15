<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class appointment_history
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
        Panel1 = New Panel()
        Panel2 = New Panel()
        RichTextBox1 = New RichTextBox()
        PictureBox1 = New PictureBox()
        Label1 = New Label()
        Panel2.SuspendLayout()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.AutoScroll = True
        Panel1.Location = New Point(27, 107)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(925, 720)
        Panel1.TabIndex = 1
        ' 
        ' Panel2
        ' 
        Panel2.Controls.Add(RichTextBox1)
        Panel2.Location = New Point(27, 117)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(942, 655)
        Panel2.TabIndex = 0
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.FromArgb(CByte(240), CByte(218), CByte(248))
        RichTextBox1.Font = New Font("Microsoft YaHei", 10.2F)
        RichTextBox1.Location = New Point(0, 0)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(507, 655)
        RichTextBox1.TabIndex = 0
        RichTextBox1.Text = ""
        ' 
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.backbtn
        PictureBox1.Location = New Point(855, 779)
        PictureBox1.Margin = New Padding(3, 4, 3, 4)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(114, 67)
        PictureBox1.TabIndex = 3
        PictureBox1.TabStop = False
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.FromArgb(CByte(244), CByte(217), CByte(255))
        Label1.Font = New Font("Segoe UI", 15F, FontStyle.Bold)
        Label1.Location = New Point(27, 31)
        Label1.Name = "Label1"
        Label1.Size = New Size(240, 35)
        Label1.TabIndex = 0
        Label1.Text = "Past Appointments"
        ' 
        ' appointment_history
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(998, 859)
        Controls.Add(PictureBox1)
        Controls.Add(Panel2)
        Controls.Add(Panel1)
        Controls.Add(Label1)
        Name = "appointment_history"
        Text = "Appointment_history"
        Panel2.ResumeLayout(False)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents RichTextBox1 As RichTextBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents Label1 As Label
End Class
