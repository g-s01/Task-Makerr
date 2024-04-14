<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class appointmentChat
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
        separatorLine = New Label()
        Panel2 = New Panel()
        Label2 = New Label()
        Label1 = New Label()
        Chat = New Panel()
        sendButton = New Button()
        inputTextBox = New TextBox()
        Panel2.SuspendLayout()
        SuspendLayout()
        ' 
        ' separatorLine
        ' 
        separatorLine.BorderStyle = BorderStyle.FixedSingle
        separatorLine.Location = New Point(-480, 74)
        separatorLine.Margin = New Padding(6, 0, 6, 0)
        separatorLine.Name = "separatorLine"
        separatorLine.Size = New Size(830, 2)
        separatorLine.TabIndex = 12
        ' 
        ' Panel2
        ' 
        Panel2.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        Panel2.Controls.Add(Label2)
        Panel2.Location = New Point(13, 91)
        Panel2.Margin = New Padding(4)
        Panel2.Name = "Panel2"
        Panel2.Size = New Size(683, 69)
        Panel2.TabIndex = 11
        ' 
        ' Label2
        ' 
        Label2.AutoSize = True
        Label2.Font = New Font("Microsoft YaHei", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label2.Location = New Point(40, 15)
        Label2.Margin = New Padding(4, 0, 4, 0)
        Label2.Name = "Label2"
        Label2.Size = New Size(111, 37)
        Label2.TabIndex = 0
        Label2.Text = "Admin"
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Microsoft YaHei", 16.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.FromArgb(CByte(173), CByte(103), CByte(200))
        Label1.Location = New Point(0, 21)
        Label1.Margin = New Padding(4, 0, 4, 0)
        Label1.Name = "Label1"
        Label1.Size = New Size(213, 50)
        Label1.TabIndex = 10
        Label1.Text = "Chat Here"
        ' 
        ' Chat
        ' 
        Chat.AutoScroll = True
        Chat.Location = New Point(0, 167)
        Chat.Name = "Chat"
        Chat.Size = New Size(697, 681)
        Chat.TabIndex = 9
        ' 
        ' sendButton
        ' 
        sendButton.BackColor = Color.FromArgb(CByte(214), CByte(179), CByte(227))
        sendButton.FlatAppearance.BorderSize = 0
        sendButton.FlatStyle = FlatStyle.Flat
        sendButton.Font = New Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        sendButton.Location = New Point(492, 851)
        sendButton.Name = "sendButton"
        sendButton.Size = New Size(204, 56)
        sendButton.TabIndex = 8
        sendButton.Text = "send"
        sendButton.UseVisualStyleBackColor = False
        ' 
        ' inputTextBox
        ' 
        inputTextBox.BorderStyle = BorderStyle.None
        inputTextBox.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        inputTextBox.Location = New Point(13, 854)
        inputTextBox.Multiline = True
        inputTextBox.Name = "inputTextBox"
        inputTextBox.PlaceholderText = "   write .."
        inputTextBox.Size = New Size(473, 56)
        inputTextBox.TabIndex = 7
        ' 
        ' appointmentChat
        ' 
        AutoScaleDimensions = New SizeF(12F, 30F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(709, 929)
        Controls.Add(separatorLine)
        Controls.Add(Panel2)
        Controls.Add(Label1)
        Controls.Add(Chat)
        Controls.Add(sendButton)
        Controls.Add(inputTextBox)
        FormBorderStyle = FormBorderStyle.None
        Name = "appointmentChat"
        Text = "appointmentChat"
        Panel2.ResumeLayout(False)
        Panel2.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents separatorLine As Label
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Chat As Panel
    Friend WithEvents sendButton As Button
    Friend WithEvents inputTextBox As TextBox
End Class
