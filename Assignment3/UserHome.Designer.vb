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
        PictureBox1 = New PictureBox()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
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
        ' PictureBox1
        ' 
        PictureBox1.Image = My.Resources.Resources.Ellipse_6
        PictureBox1.Location = New Point(807, 20)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(80, 62)
        PictureBox1.TabIndex = 1
        PictureBox1.TabStop = False
        ' 
        ' UserHome
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(932, 666)
        Controls.Add(PictureBox1)
        Controls.Add(Label1)
        Name = "UserHome"
        Text = "UserHome"
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
End Class
