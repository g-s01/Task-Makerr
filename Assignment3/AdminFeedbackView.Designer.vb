<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class AdminFeedbackView
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
        userButton = New Button()
        providerButton = New Button()
        separatorLine = New Label()
        Panel1 = New Panel()
        applyButton = New Button()
        ComboBox1 = New ComboBox()
        Panel2 = New Panel()
        Panel1.SuspendLayout()
        SuspendLayout()
        ' 
        ' userButton
        ' 
        userButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        userButton.FlatAppearance.BorderSize = 0
        userButton.FlatStyle = FlatStyle.Flat
        userButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        userButton.Location = New Point(32, 40)
        userButton.Margin = New Padding(4, 5, 4, 5)
        userButton.Name = "userButton"
        userButton.Size = New Size(129, 45)
        userButton.TabIndex = 0
        userButton.Text = "Users "
        userButton.UseVisualStyleBackColor = False
        ' 
        ' providerButton
        ' 
        providerButton.BackColor = SystemColors.Control
        providerButton.FlatAppearance.BorderSize = 0
        providerButton.FlatStyle = FlatStyle.Flat
        providerButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        providerButton.Location = New Point(187, 39)
        providerButton.Margin = New Padding(4, 5, 4, 5)
        providerButton.Name = "providerButton"
        providerButton.Size = New Size(138, 46)
        providerButton.TabIndex = 1
        providerButton.Text = "Providers "
        providerButton.UseVisualStyleBackColor = False
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.Fixed3D
        separatorLine.Location = New Point(31, 85)
        separatorLine.Margin = New Padding(4, 0, 4, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(533, 3)
        separatorLine.TabIndex = 3
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(applyButton)
        Panel1.Controls.Add(ComboBox1)
        Panel1.Controls.Add(Panel2)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(846, 712)
        Panel1.TabIndex = 7
        ' 
        ' applyButton
        ' 
        applyButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        applyButton.FlatAppearance.BorderSize = 0
        applyButton.FlatStyle = FlatStyle.Flat
        applyButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        applyButton.Location = New Point(746, 49)
        applyButton.Name = "applyButton"
        applyButton.Size = New Size(75, 34)
        applyButton.TabIndex = 2
        applyButton.Text = "Apply"
        applyButton.UseVisualStyleBackColor = False
        ' 
        ' ComboBox1
        ' 
        ComboBox1.AccessibleDescription = ""
        ComboBox1.AccessibleName = ""
        ComboBox1.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        ComboBox1.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        ComboBox1.FormattingEnabled = True
        ComboBox1.Items.AddRange(New Object() {"1", "2", "3", "4", "5"})
        ComboBox1.Location = New Point(572, 51)
        ComboBox1.Name = "ComboBox1"
        ComboBox1.Size = New Size(163, 31)
        ComboBox1.TabIndex = 1
        ComboBox1.Tag = ""
        ComboBox1.Text = "Rating Filter"
        ' 
        ' Panel2
        ' 
        Panel2.AutoScroll = True
        Panel2.Location = New Point(22, 105)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(812, 595)
        Panel2.TabIndex = 0
        ' 
        ' AdminFeedbackView
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(846, 712)
        Controls.Add(separatorLine)
        Controls.Add(providerButton)
        Controls.Add(userButton)
        Controls.Add(Panel1)
        Margin = New Padding(4, 5, 4, 5)
        Name = "AdminFeedbackView"
        Text = "Feedback Viewer"
        Panel1.ResumeLayout(False)
        ResumeLayout(False)

    End Sub

    Friend WithEvents userButton As Button
    Friend WithEvents providerButton As Button
    Friend WithEvents separatorLine As Label
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents ComboBox1 As ComboBox
    Friend WithEvents applyButton As Button

End Class
