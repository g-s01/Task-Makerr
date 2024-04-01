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
        sendTextBox = New TextBox()
        sendBtn = New Button()
        SuspendLayout()
        ' 
        ' chat
        ' 
        chat.AutoScroll = True
        chat.Location = New Point(115, 94)
        chat.Margin = New Padding(4)
        chat.Name = "chat"
        chat.Size = New Size(970, 720)
        chat.TabIndex = 0
        ' 
        ' chat_list
        ' 
        chat_list.AutoSizeMode = AutoSizeMode.GrowAndShrink
        chat_list.Location = New Point(1093, 94)
        chat_list.Margin = New Padding(4)
        chat_list.Name = "chat_list"
        chat_list.Size = New Size(360, 720)
        chat_list.TabIndex = 1
        ' 
        ' sendTextBox
        ' 
        sendTextBox.Location = New Point(115, 849)
        sendTextBox.Multiline = True
        sendTextBox.Name = "sendTextBox"
        sendTextBox.ScrollBars = ScrollBars.Vertical
        sendTextBox.Size = New Size(835, 101)
        sendTextBox.TabIndex = 2
        ' 
        ' sendBtn
        ' 
        sendBtn.Location = New Point(956, 849)
        sendBtn.Name = "sendBtn"
        sendBtn.Size = New Size(131, 75)
        sendBtn.TabIndex = 3
        sendBtn.Text = "Send"
        sendBtn.UseVisualStyleBackColor = True
        ' 
        ' user_provider_chats
        ' 
        AutoScaleDimensions = New SizeF(12F, 30F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1493, 929)
        Controls.Add(sendBtn)
        Controls.Add(sendTextBox)
        Controls.Add(chat_list)
        Controls.Add(chat)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4)
        Name = "user_provider_chats"
        Text = "user_chats"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents chat As Panel
    Friend WithEvents chat_list As Panel
    Friend WithEvents sendTextBox As TextBox
    Friend WithEvents sendBtn As Button
End Class
