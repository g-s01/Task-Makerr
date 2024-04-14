<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class user_provider_chats
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
        chat = New Panel()
        chat_list = New Panel()
        sendBtn = New Button()
        sendTextBox = New TextBox()
        Panel1 = New Panel()
        Panel2 = New Panel()
        senderName = New Label()
        Label1 = New Label()
        separatorLine = New Label()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' chat
        ' 
        chat.AutoScroll = True
        chat.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chat.Location = New Point(21, 193)
        chat.Margin = New Padding(4)
        chat.Name = "chat"
        chat.Size = New Size(926, 653)
        chat.TabIndex = 0
        ' 
        ' chat_list
        ' 
        chat_list.AutoSizeMode = AutoSizeMode.GrowAndShrink
        chat_list.BackColor = Color.FromArgb(CByte(242), CByte(209), CByte(245))
        chat_list.Location = New Point(956, 114)
        chat_list.Margin = New Padding(4)
        chat_list.Name = "chat_list"
        chat_list.Size = New Size(292, 795)
        chat_list.TabIndex = 1
        ' 
        ' sendBtn
        ' 
        sendBtn.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        sendBtn.FlatAppearance.BorderSize = 0
        sendBtn.FlatStyle = FlatStyle.Flat
        sendBtn.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendBtn.Location = New Point(816, 854)
        sendBtn.Name = "sendBtn"
        sendBtn.Size = New Size(130, 56)
        sendBtn.TabIndex = 3
        sendBtn.Text = "Send"
        sendBtn.UseVisualStyleBackColor = False
        ' 
        ' sendTextBox
        ' 
        sendTextBox.BorderStyle = BorderStyle.None
        sendTextBox.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendTextBox.Location = New Point(21, 854)
        sendTextBox.Multiline = True
        sendTextBox.Name = "sendTextBox"
        sendTextBox.PlaceholderText = "   write .."
        sendTextBox.Size = New Size(796, 56)
        sendTextBox.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(separatorLine)
        Panel1.Controls.Add(sendBtn)
        Panel1.Controls.Add(sendTextBox)
        Panel1.Controls.Add(chat)
        Panel1.Controls.Add(chat_list)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1269, 1002)
        Panel1.TabIndex = 5
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        Panel2.Controls.Add(senderName)
        Panel2.Location = New Point(20, 122)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(926, 63)
        Panel2.TabIndex = 15
        ' 
        ' senderName
        ' 
        senderName.AutoSize = True
        senderName.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        senderName.Location = New Point(324, 9)
        senderName.Margin = New Padding(4, 0, 4, 0)
        senderName.Name = "senderName"
        senderName.Size = New Size(207, 37)
        senderName.TabIndex = 0
        senderName.Text = "Sender Name"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Label1.Location = New Point(15, 28)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(184, 50)
        Label1.TabIndex = 6
        Label1.Text = "Provider"
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(21, 84)
        separatorLine.Margin = New Padding(6, 0, 6, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(1019, 2)
        separatorLine.TabIndex = 5
        ' 
        ' user_provider_chats
        ' 
        AutoScaleDimensions = New SizeF(12F, 30F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1269, 1002)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4)
        Name = "user_provider_chats"
        Text = "user_chats"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents chat As Panel
    Friend WithEvents chat_list As Panel
    Friend WithEvents sendBtn As Button
    Friend WithEvents sendTextBox As TextBox
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents separatorLine As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents senderName As Label
End Class
