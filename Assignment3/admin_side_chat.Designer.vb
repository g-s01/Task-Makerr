<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class admin_side_chat
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
        chat_list = New Panel()
        chat = New Panel()
        sendTextBox = New TextBox()
        sendBtn = New Button()
        separatorLine = New Label()
        userButton = New Button()
        providerButton = New Button()
        Panel2 = New Panel()
        Label1 = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(providerButton)
        Panel1.Controls.Add(userButton)
        Panel1.Controls.Add(separatorLine)
        Panel1.Controls.Add(sendBtn)
        Panel1.Controls.Add(sendTextBox)
        Panel1.Controls.Add(chat)
        Panel1.Controls.Add(chat_list)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(852, 672)
        Panel1.TabIndex = 0
        ' 
        ' chat_list
        ' 
        chat_list.AutoSizeMode = AutoSizeMode.GrowAndShrink
        chat_list.BackColor = Color.FromArgb(CByte(242), CByte(209), CByte(245))
        chat_list.Location = New Point(642, 79)
        chat_list.Name = "chat_list"
        chat_list.Size = New Size(195, 530)
        chat_list.TabIndex = 8
        ' 
        ' chat
        ' 
        chat.AutoScroll = True
        chat.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chat.Location = New Point(19, 121)
        chat.Name = "chat"
        chat.Size = New Size(617, 446)
        chat.TabIndex = 7
        ' 
        ' sendTextBox
        ' 
        sendTextBox.BorderStyle = BorderStyle.None
        sendTextBox.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendTextBox.Location = New Point(19, 572)
        sendTextBox.Margin = New Padding(2)
        sendTextBox.Multiline = True
        sendTextBox.Name = "sendTextBox"
        sendTextBox.PlaceholderText = "   write .."
        sendTextBox.Size = New Size(531, 37)
        sendTextBox.TabIndex = 10
        ' 
        ' sendBtn
        ' 
        sendBtn.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        sendBtn.FlatAppearance.BorderSize = 0
        sendBtn.FlatStyle = FlatStyle.Flat
        sendBtn.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendBtn.Location = New Point(549, 572)
        sendBtn.Margin = New Padding(2)
        sendBtn.Name = "sendBtn"
        sendBtn.Size = New Size(87, 37)
        sendBtn.TabIndex = 9
        sendBtn.Text = "Send"
        sendBtn.UseVisualStyleBackColor = False
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(19, 59)
        separatorLine.Margin = New Padding(4, 0, 4, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(680, 2)
        separatorLine.TabIndex = 11
        ' 
        ' userButton
        ' 
        userButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        userButton.FlatAppearance.BorderSize = 0
        userButton.FlatStyle = FlatStyle.Flat
        userButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        userButton.Location = New Point(19, 14)
        userButton.Margin = New Padding(4, 5, 4, 5)
        userButton.Name = "userButton"
        userButton.Size = New Size(129, 45)
        userButton.TabIndex = 12
        userButton.Text = "Users "
        userButton.UseVisualStyleBackColor = False
        ' 
        ' providerButton
        ' 
        providerButton.BackColor = SystemColors.Control
        providerButton.FlatAppearance.BorderSize = 0
        providerButton.FlatStyle = FlatStyle.Flat
        providerButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        providerButton.Location = New Point(156, 13)
        providerButton.Margin = New Padding(4, 5, 4, 5)
        providerButton.Name = "providerButton"
        providerButton.Size = New Size(138, 46)
        providerButton.TabIndex = 13
        providerButton.Text = "Providers "
        providerButton.UseVisualStyleBackColor = False
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        Panel2.Controls.Add(Label1)
        Panel2.Location = New Point(19, 80)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(617, 42)
        Panel2.TabIndex = 14
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.Location = New Point(216, 6)
        Label1.Name = "Label1"
        Label1.Size = New Size(149, 27)
        Label1.TabIndex = 0
        Label1.Text = "Sender Name"
        ' 
        ' admin_side_chat
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(852, 672)
        Controls.Add(Panel1)
        Name = "admin_side_chat"
        Text = "admin_side_chat"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents userButton As Button
    Friend WithEvents separatorLine As Label
    Friend WithEvents sendBtn As Button
    Friend WithEvents sendTextBox As TextBox
    Friend WithEvents chat As Panel
    Friend WithEvents chat_list As Panel
    Friend WithEvents providerButton As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
End Class
