<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class support_chat
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
        inputTextBox = New TextBox()
        sendButton = New Button()
        Support = New Panel()
        SuspendLayout()
        ' 
        ' inputTextBox
        ' 
        inputTextBox.Location = New Point(121, 733)
        inputTextBox.Multiline = True
        inputTextBox.Name = "inputTextBox"
        inputTextBox.Size = New Size(1020, 96)
        inputTextBox.TabIndex = 0
        ' 
        ' sendButton
        ' 
        sendButton.Location = New Point(1209, 733)
        sendButton.Name = "sendButton"
        sendButton.Size = New Size(131, 76)
        sendButton.TabIndex = 1
        sendButton.Text = "send"
        sendButton.UseVisualStyleBackColor = True
        ' 
        ' Support
        ' 
        Support.Location = New Point(121, -16)
        Support.Name = "Support"
        Support.Size = New Size(1268, 700)
        Support.TabIndex = 2
        ' 
        ' support_chat
        ' 
        AutoScaleDimensions = New SizeF(12F, 30F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1451, 845)
        Controls.Add(Support)
        Controls.Add(sendButton)
        Controls.Add(inputTextBox)
        FormBorderStyle = FormBorderStyle.None
        Name = "support_chat"
        Text = "support_chat"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents inputTextBox As TextBox
    Friend WithEvents sendButton As Button
    Friend WithEvents Support As Panel
End Class
