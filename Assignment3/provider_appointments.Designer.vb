<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class provider_appointments
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
        Button1 = New Button()
        Button2 = New Button()
        Panel1 = New Panel()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.AutoSize = True
        Button1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        Button1.FlatAppearance.BorderColor = Color.White
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button1.ForeColor = SystemColors.ControlText
        Button1.Location = New Point(10, 26)
        Button1.Margin = New Padding(3, 2, 3, 2)
        Button1.Name = "Button1"
        Button1.Size = New Size(105, 31)
        Button1.TabIndex = 0
        Button1.Text = "Upcoming"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' Button2
        ' 
        Button2.AutoSize = True
        Button2.FlatAppearance.BorderColor = Color.Black
        Button2.FlatAppearance.BorderSize = 0
        Button2.FlatStyle = FlatStyle.Flat
        Button2.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        Button2.ForeColor = SystemColors.GrayText
        Button2.Location = New Point(113, 26)
        Button2.Margin = New Padding(3, 2, 3, 2)
        Button2.Name = "Button2"
        Button2.Size = New Size(164, 31)
        Button2.TabIndex = 1
        Button2.Text = "Payment Pending"
        Button2.UseVisualStyleBackColor = False
        ' 
        ' Panel1
        ' 
        Panel1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        Panel1.AutoScroll = True
        Panel1.BackColor = SystemColors.Control
        Panel1.Location = New Point(3, 61)
        Panel1.Margin = New Padding(3, 2, 3, 2)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(845, 589)
        Panel1.TabIndex = 2
        ' 
        ' provider_appointments
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoScroll = True
        ClientSize = New Size(850, 650)
        Controls.Add(Panel1)
        Controls.Add(Button2)
        Controls.Add(Button1)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(3, 2, 3, 2)
        Name = "provider_appointments"
        Text = "provider_appointments"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button2 As Button
    Friend WithEvents Panel1 As Panel
End Class
