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
        Button1 = New Button()
        SearchTextBox = New TextBox()
        Panel2 = New Panel()
        senderName = New Label()
        providerButton = New Button()
        userButton = New Button()
        separatorLine = New Label()
        sendBtn = New Button()
        sendTextBox = New TextBox()
        chat = New Panel()
        room_list = New Panel()
        Panel1.SuspendLayout()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' Panel1
        ' 
        Panel1.Controls.Add(Button1)
        Panel1.Controls.Add(SearchTextBox)
        Panel1.Controls.Add(Panel2)
        Panel1.Controls.Add(providerButton)
        Panel1.Controls.Add(userButton)
        Panel1.Controls.Add(separatorLine)
        Panel1.Controls.Add(sendBtn)
        Panel1.Controls.Add(sendTextBox)
        Panel1.Controls.Add(chat)
        Panel1.Controls.Add(room_list)
        Panel1.Dock = DockStyle.Fill
        Panel1.Location = New Point(0, 0)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(822, 610)
        Panel1.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.FromArgb(CByte(231), CByte(188), CByte(219))
        Button1.Enabled = False
        Button1.FlatAppearance.BorderSize = 0
        Button1.FlatStyle = FlatStyle.Flat
        Button1.Image = My.Resources.Resources.search
        Button1.Location = New Point(767, 110)
        Button1.Name = "Button1"
        Button1.Size = New Size(43, 31)
        Button1.TabIndex = 18
        Button1.UseVisualStyleBackColor = False
        ' 
        ' SearchTextBox
        ' 
        SearchTextBox.BorderStyle = BorderStyle.FixedSingle
        SearchTextBox.Font = New Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        SearchTextBox.Location = New Point(595, 105)
        SearchTextBox.Name = "SearchTextBox"
        SearchTextBox.Size = New Size(166, 39)
        SearchTextBox.TabIndex = 17
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        Panel2.Controls.Add(senderName)
        Panel2.Location = New Point(23, 100)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(566, 52)
        Panel2.TabIndex = 14
        ' 
        ' senderName
        ' 
        senderName.Anchor = AnchorStyles.Left Or AnchorStyles.Right
        senderName.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        senderName.Location = New Point(172, 5)
        senderName.Name = "senderName"
        senderName.Size = New Size(237, 42)
        senderName.TabIndex = 0
        senderName.Text = "Sender Name"
        senderName.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' providerButton
        ' 
        providerButton.BackColor = SystemColors.Control
        providerButton.FlatAppearance.BorderSize = 0
        providerButton.FlatStyle = FlatStyle.Flat
        providerButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        providerButton.Location = New Point(195, 17)
        providerButton.Margin = New Padding(5, 7, 5, 7)
        providerButton.Name = "providerButton"
        providerButton.Size = New Size(172, 58)
        providerButton.TabIndex = 13
        providerButton.Text = "Providers "
        providerButton.UseVisualStyleBackColor = False
        ' 
        ' userButton
        ' 
        userButton.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        userButton.FlatAppearance.BorderSize = 0
        userButton.FlatStyle = FlatStyle.Flat
        userButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        userButton.Location = New Point(23, 18)
        userButton.Margin = New Padding(5, 7, 5, 7)
        userButton.Name = "userButton"
        userButton.Size = New Size(162, 57)
        userButton.TabIndex = 12
        userButton.Text = "Users "
        userButton.UseVisualStyleBackColor = False
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(23, 75)
        separatorLine.Margin = New Padding(5, 0, 5, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(600, 2)
        separatorLine.TabIndex = 11
        ' 
        ' sendBtn
        ' 
        sendBtn.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        sendBtn.FlatAppearance.BorderSize = 0
        sendBtn.FlatStyle = FlatStyle.Flat
        sendBtn.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendBtn.Location = New Point(489, 513)
        sendBtn.Margin = New Padding(2)
        sendBtn.Name = "sendBtn"
        sendBtn.Size = New Size(100, 47)
        sendBtn.TabIndex = 9
        sendBtn.Text = "Send"
        sendBtn.UseVisualStyleBackColor = False
        ' 
        ' sendTextBox
        ' 
        sendTextBox.BorderStyle = BorderStyle.None
        sendTextBox.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendTextBox.Location = New Point(23, 513)
        sendTextBox.Margin = New Padding(2)
        sendTextBox.Multiline = True
        sendTextBox.Name = "sendTextBox"
        sendTextBox.PlaceholderText = "   write .."
        sendTextBox.Size = New Size(462, 47)
        sendTextBox.TabIndex = 10
        ' 
        ' chat
        ' 
        chat.AutoScroll = True
        chat.BackColor = Color.WhiteSmoke
        chat.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chat.Location = New Point(23, 155)
        chat.Name = "chat"
        chat.Size = New Size(566, 353)
        chat.TabIndex = 7
        ' 
        ' room_list
        ' 
        room_list.AutoScroll = True
        room_list.AutoSizeMode = AutoSizeMode.GrowAndShrink
        room_list.BackColor = Color.FromArgb(CByte(242), CByte(209), CByte(245))
        room_list.Location = New Point(595, 155)
        room_list.Name = "room_list"
        room_list.Size = New Size(200, 405)
        room_list.TabIndex = 8
        ' 
        ' admin_side_chat
        ' 
        AutoScaleMode = AutoScaleMode.None
        ClientSize = New Size(822, 610)
        Controls.Add(Panel1)
        Name = "admin_side_chat"
        Text = "admin_side_chat"
        Panel1.ResumeLayout(False)
        Panel1.PerformLayout()
        Panel2.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents userButton As Button
    Friend WithEvents separatorLine As Label
    Friend WithEvents sendBtn As Button
    Friend WithEvents sendTextBox As TextBox
    Friend WithEvents chat As Panel
    Friend WithEvents room_list As Panel
    Friend WithEvents providerButton As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents senderName As Label
    Friend WithEvents Button1 As Button
    Friend WithEvents SearchTextBox As TextBox
End Class
