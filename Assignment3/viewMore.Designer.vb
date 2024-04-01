<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class viewMore
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        usernamelabel = New Label()
        label3 = New Label()
        label2 = New Label()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        PictureBox1.Image = My.Resources.Resources.prov
        PictureBox1.Location = New Point(12, 15)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(114, 133)
        PictureBox1.TabIndex = 0
        PictureBox1.TabStop = False
        ' 
        ' usernamelabel
        ' 
        usernamelabel.AutoSize = True
        usernamelabel.Font = New Font("Microsoft YaHei", 10.2F)
        usernamelabel.ImageAlign = ContentAlignment.BottomCenter
        usernamelabel.Location = New Point(208, 5)
        usernamelabel.Name = "usernamelabel"
        usernamelabel.Size = New Size(64, 23)
        usernamelabel.TabIndex = 1
        usernamelabel.Text = "Label1"
        ' 
        ' label3
        ' 
        label3.AutoSize = True
        label3.Font = New Font("Microsoft YaHei", 10.2F)
        label3.Location = New Point(23, 170)
        label3.Name = "label3"
        label3.Size = New Size(64, 23)
        label3.TabIndex = 2
        label3.Text = "Label3"
        ' 
        ' label2
        ' 
        label2.AutoSize = True
        label2.Font = New Font("Microsoft YaHei", 10.2F)
        label2.ImageAlign = ContentAlignment.TopLeft
        label2.Location = New Point(150, 40)
        label2.Name = "label2"
        label2.Size = New Size(64, 23)
        label2.TabIndex = 3
        label2.Text = "Label2"
        ' 
        ' viewMore
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Controls.Add(label2)
        Controls.Add(label3)
        Controls.Add(usernamelabel)
        Controls.Add(PictureBox1)
        Name = "viewMore"
        Size = New Size(419, 223)
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents usernamelabel As Label
    Friend WithEvents label3 As Label
    Friend WithEvents label2 As Label


End Class
