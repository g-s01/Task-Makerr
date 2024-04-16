<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class provider_notifications
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
        Panel1 = New Panel()
        separatorLine = New Label()
        FlowLayoutPanel1 = New FlowLayoutPanel()
        Button4 = New Button()
        Button3 = New Button()
        Button2 = New Button()
        Button1 = New Button()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.BackColor = SystemColors.Control
        Panel1.Controls.Add(separatorLine)
        Panel1.Controls.Add(FlowLayoutPanel1)
        Panel1.Controls.Add(Button4)
        Panel1.Controls.Add(Button3)
        Panel1.Controls.Add(Button2)
        Panel1.Controls.Add(Button1)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(865, 677)
        Panel1.TabIndex = 0
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(100, 104)
        separatorLine.Margin = New Padding(4, 0, 4, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(680, 2)
        separatorLine.TabIndex = 4
        ' 
        ' FlowLayoutPanel1
        ' 
        FlowLayoutPanel1.AutoScroll = True
        FlowLayoutPanel1.BackColor = SystemColors.Control
        FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown
        FlowLayoutPanel1.Location = New Point(50, 143)
        FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        FlowLayoutPanel1.Size = New Size(776, 467)
        FlowLayoutPanel1.TabIndex = 7
        FlowLayoutPanel1.WrapContents = False
        ' 
        ' Button4
        ' 
        Button4.BackColor = SystemColors.Control
        Button4.FlatAppearance.BorderSize = 0
        Button4.FlatStyle = FlatStyle.Flat
        Button4.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        Button4.Location = New Point(610, 49)
        Button4.Name = "Button4"
        Button4.Size = New Size(170, 56)
        Button4.TabIndex = 6
        Button4.Text = "Reviews"
        Button4.UseVisualStyleBackColor = False
        ' 
        ' Button3
        ' 
        Button3.FlatAppearance.BorderSize = 0
        Button3.FlatStyle = FlatStyle.Flat
        Button3.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        Button3.Location = New Point(440, 49)
        Button3.Name = "Button3"
        Button3.Size = New Size(170, 56)
        Button3.TabIndex = 5
        Button3.Text = "Cancelled"
        Button3.UseVisualStyleBackColor = True
        ' 
        ' Button2
        ' 
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        Button2.Location = New Point(270, 49)
        Button2.Name = "Button2"
        Button2.Size = New Size(170, 56)
        Button2.TabIndex = 1
        Button2.Text = "Full Payment"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(215), CByte(181), CByte(227))
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        Button1.Location = New Point(100, 49)
        Button1.Margin = New Padding(0)
        Button1.Name = "Button1"
        Button1.Size = New Size(170, 56)
        Button1.TabIndex = 0
        Button1.Text = "Advance Payment"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' provider_notifications
        ' 
        AutoScaleMode = AutoScaleMode.Inherit
        AutoSize = True
        ClientSize = New Size(865, 677)
        Controls.Add(Panel1)
        Name = "provider_notifications"
        Text = "provider_notifications"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Button2 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents Button4 As Button
    Friend WithEvents Button3 As Button
    Friend WithEvents FlowLayoutPanel1 As FlowLayoutPanel
    Friend WithEvents separatorLine As Label
End Class
