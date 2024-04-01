<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class user_chats
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
        chat_list = New Panel()
        chat = New Panel()
        SuspendLayout()
        ' 
        ' chat_list
        ' 
        chat_list.Location = New Point(96, 78)
        chat_list.Name = "chat_list"
        chat_list.Size = New Size(300, 600)
        chat_list.TabIndex = 0
        ' 
        ' chat
        ' 
        chat.Location = New Point(402, 78)
        chat.Name = "chat"
        chat.Size = New Size(808, 600)
        chat.TabIndex = 1
        ' 
        ' user_chats
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1244, 708)
        Controls.Add(chat)
        Controls.Add(chat_list)
        FormBorderStyle = FormBorderStyle.None
        Name = "user_chats"
        Text = "user_chats"
        ResumeLayout(False)
    End Sub

    Friend WithEvents chat_list As Panel
    Friend WithEvents chat As Panel
End Class
