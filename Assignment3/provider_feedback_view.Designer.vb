<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class provider_feedback_view
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
        components = New ComponentModel.Container()
        Label8 = New Label()
        ImageList1 = New ImageList(components)
        listViewReviews = New ListView()
        SuspendLayout()
        ' 
        ' Label8
        ' 
        Label8.BackColor = Color.FromArgb(CByte(252), CByte(233), CByte(255))
        Label8.Font = New Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label8.Location = New Point(41, 32)
        Label8.Margin = New Padding(4, 0, 4, 0)
        Label8.Name = "Label8"
        Label8.Size = New Size(285, 31)
        Label8.TabIndex = 19
        Label8.Text = "Users Feedback"
        Label8.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' ImageList1
        ' 
        ImageList1.ColorDepth = ColorDepth.Depth32Bit
        ImageList1.ImageSize = New Size(16, 16)
        ImageList1.TransparentColor = Color.Transparent
        ' 
        ' listViewReviews
        ' 
        listViewReviews.BackColor = Color.FromArgb(CByte(252), CByte(233), CByte(255))
        listViewReviews.BorderStyle = BorderStyle.None
        listViewReviews.Location = New Point(25, 120)
        listViewReviews.Name = "listViewReviews"
        listViewReviews.Size = New Size(894, 488)
        listViewReviews.TabIndex = 20
        listViewReviews.UseCompatibleStateImageBehavior = False
        ' 
        ' provider_feedback_view
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        ClientSize = New Size(954, 832)
        Controls.Add(listViewReviews)
        Controls.Add(Label8)
        FormBorderStyle = FormBorderStyle.None
        Margin = New Padding(4)
        Name = "provider_feedback_view"
        Text = "provider_feedback_view"
        ResumeLayout(False)
    End Sub
    Friend WithEvents Label8 As Label
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents listViewReviews As ListView
End Class
