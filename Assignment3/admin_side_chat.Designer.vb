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
        Panel1.Margin = New Padding(4)
        Panel1.Name = "Panel1"
        Panel1.Size = New Size(1278, 1008)
        Panel1.TabIndex = 0
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        Panel2.Controls.Add(senderName)
        Panel2.Location = New Point(28, 120)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(926, 63)
        Panel2.TabIndex = 14
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
        ' providerButton
        ' 
        providerButton.BackColor = SystemColors.Control
        providerButton.FlatAppearance.BorderSize = 0
        providerButton.FlatStyle = FlatStyle.Flat
        providerButton.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        providerButton.Location = New Point(234, 20)
        providerButton.Margin = New Padding(6, 8, 6, 8)
        providerButton.Name = "providerButton"
        providerButton.Size = New Size(207, 69)
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
        userButton.Location = New Point(28, 21)
        userButton.Margin = New Padding(6, 8, 6, 8)
        userButton.Name = "userButton"
        userButton.Size = New Size(194, 68)
        userButton.TabIndex = 12
        userButton.Text = "Users "
        userButton.UseVisualStyleBackColor = False
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(28, 88)
        separatorLine.Margin = New Padding(6, 0, 6, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(1019, 2)
        separatorLine.TabIndex = 11
        ' 
        ' sendBtn
        ' 
        sendBtn.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        sendBtn.FlatAppearance.BorderSize = 0
        sendBtn.FlatStyle = FlatStyle.Flat
        sendBtn.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendBtn.Location = New Point(824, 858)
        sendBtn.Name = "sendBtn"
        sendBtn.Size = New Size(130, 56)
        sendBtn.TabIndex = 9
        sendBtn.Text = "Send"
        sendBtn.UseVisualStyleBackColor = False
        ' 
        ' sendTextBox
        ' 
        sendTextBox.BorderStyle = BorderStyle.None
        sendTextBox.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendTextBox.Location = New Point(28, 858)
        sendTextBox.Multiline = True
        sendTextBox.Name = "sendTextBox"
        sendTextBox.PlaceholderText = "   write .."
        sendTextBox.Size = New Size(796, 56)
        sendTextBox.TabIndex = 10
        ' 
        ' chat
        ' 
        chat.AutoScroll = True
        chat.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        chat.Location = New Point(28, 182)
        chat.Margin = New Padding(4)
        chat.Name = "chat"
        chat.Size = New Size(926, 669)
        chat.TabIndex = 7
        ' 
        ' room_list
        ' 
        room_list.AutoSizeMode = AutoSizeMode.GrowAndShrink
        room_list.BackColor = Color.FromArgb(CByte(242), CByte(209), CByte(245))
        room_list.Location = New Point(963, 118)
        room_list.Margin = New Padding(4)
        room_list.Name = "room_list"
        room_list.Size = New Size(292, 795)
        room_list.TabIndex = 8
        ' 
        ' admin_side_chat
        ' 
        AutoScaleDimensions = New SizeF(12F, 30F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1278, 1008)
        Controls.Add(Panel1)
        Margin = New Padding(4)
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
    Friend WithEvents room_list As Panel
    Friend WithEvents providerButton As Button
    Friend WithEvents Panel2 As Panel
    Friend WithEvents senderName As Label
End Class
