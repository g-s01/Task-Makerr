<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ViewAllUser
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
        ComboBox1 = New ComboBox()
        ComboBox2 = New ComboBox()
        Label3 = New Label()
        SuspendLayout()
        ' 
        ' ComboBox1
        ' 
        ComboBox1.Font = New Font("Microsoft YaHei", 10.2F)
        ComboBox1.FormattingEnabled = True
        ComboBox1.Location = New Point(97, 48)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(151, 31)
        ComboBox1.TabIndex = 2
        ComboBox1.Text = "    Filter"
        ' 
        ' ComboBox2
        ' 
        ComboBox2.Font = New Font("Microsoft YaHei", 10.2F)
        ComboBox2.FormattingEnabled = True
        ComboBox2.Location = New Point(328, 48)
        ComboBox2.Name = "ComboBox2"
        ComboBox2.Size = New Size(151, 31)
        ComboBox2.TabIndex = 3
        ComboBox2.Text = "    Location"
        ' 
        ' Label3
        ' 
        Label3.AutoSize = True
        Label3.Font = New Font("Microsoft YaHei", 13.0F)
        Label3.Location = New Point(97, 141)
        Label3.Name = "Label3"
        Label3.Size = New Size(145, 30)
        Label3.TabIndex = 5
        Label3.Text = "Service Type"
        ' 
        ' ViewAllUser
        ' 
        AutoScaleDimensions = New SizeF(8.0F, 20.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(Label3)
        Controls.Add(ComboBox2)
        Controls.Add(ComboBox1)
        FormBorderStyle = FormBorderStyle.None
        Name = "ViewAllUser"
        Text = "ViewAllUser"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents ComboBox2 As ComboBox
    Friend WithEvents Label3 As Label
End Class
