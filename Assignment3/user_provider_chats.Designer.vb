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
        Button1 = New Button()
        SearchTextBox = New TextBox()
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
        chat.BackColor = Color.WhiteSmoke
        chat.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chat.Location = New Point(17, 160)
        chat.Name = "chat"
        chat.Size = New Size(580, 342)
        chat.TabIndex = 0
        ' 
        ' chat_list
        ' 
        chat_list.AutoScroll = True
        chat_list.AutoSizeMode = AutoSizeMode.GrowAndShrink
        chat_list.BackColor = Color.FromArgb(CByte(242), CByte(209), CByte(245))
        chat_list.Location = New Point(603, 136)
        chat_list.Name = "chat_list"
        chat_list.Size = New Size(207, 419)
        chat_list.TabIndex = 1
        ' 
        ' sendBtn
        ' 
        sendBtn.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        sendBtn.FlatAppearance.BorderSize = 0
        sendBtn.FlatStyle = FlatStyle.Flat
        sendBtn.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendBtn.Location = New Point(496, 508)
        sendBtn.Name = "sendBtn"
        sendBtn.Size = New Size(101, 47)
        sendBtn.TabIndex = 3
        sendBtn.Text = "Send"
        sendBtn.UseVisualStyleBackColor = False
        ' 
        ' sendTextBox
        ' 
        sendTextBox.BorderStyle = BorderStyle.None
        sendTextBox.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendTextBox.Location = New Point(17, 508)
        sendTextBox.Multiline = True
        sendTextBox.Name = "sendTextBox"
        sendTextBox.PlaceholderText = "   write .."
        sendTextBox.Size = New Size(471, 47)
        sendTextBox.TabIndex = 4
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(SearchTextBox)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(Label1)
        Panel1.Controls.Add(separatorLine)
        Panel1.Controls.Add(sendBtn)
        Panel1.Controls.Add(sendTextBox)
        Panel1.Controls.Add(chat)
        Panel1.Controls.Add(chat_list)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(822, 610)
        Panel1.TabIndex = 5
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(231), CByte(188), CByte(219))
        Button1.Enabled = False
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.search
        Button1.Location = New Point(767, 99)
        Button1.Name = "Button1"
        Button1.Size = New Size(43, 31)
        Button1.TabIndex = 16
        Button1.UseVisualStyleBackColor = False
        ' 
        ' SearchTextBox
        ' 
        SearchTextBox.BorderStyle = BorderStyle.FixedSingle
        SearchTextBox.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SearchTextBox.Location = New Point(603, 99)
        SearchTextBox.Name = "SearchTextBox"
        SearchTextBox.Size = New Size(166, 39)
        SearchTextBox.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        Panel2.Controls.Add(senderName)
        Panel2.Location = New Point(17, 102)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(580, 53)
        Panel2.TabIndex = 15
        ' 
        ' senderName
        ' 
        senderName.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        senderName.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        senderName.Location = New Point(208, 3)
        senderName.Name = "senderName"
        senderName.Size = New Size(177, 46)
        senderName.TabIndex = 0
        senderName.Text = "Sender Name"
        senderName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Label1.Location = New Point(13, 23)
        Label1.Name = "Label1"
        Label1.Size = New Size(161, 44)
        Label1.TabIndex = 6
        Label1.Text = "Provider"
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(17, 70)
        separatorLine.Margin = New Padding(6, 0, 6, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(600, 2)
        separatorLine.TabIndex = 5
        ' 
        ' user_provider_chats
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(822, 610)
        Controls.Add(Panel1)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Name = "user_provider_chats"
        Text = "user_chats"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
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
    Friend WithEvents SearchTextBox As TextBox
    Friend WithEvents Button1 As Button
End Class
