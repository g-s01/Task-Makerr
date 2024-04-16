<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class pending_payment
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        SplitContainer1 = New SplitContainer()
        btn_upcoming = New Button()
        btn_completed = New Button()
        rtb1 = New RichTextBox()
        rtb2 = New RichTextBox()
        btn_pay = New Button()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(btn_upcoming)
        SplitContainer1.Panel1.Controls.Add(btn_completed)
        SplitContainer1.Panel1.Controls.Add(rtb1)
        SplitContainer1.Panel1.Controls.Add(rtb2)
        SplitContainer1.Panel1.Controls.Add(btn_pay)
        SplitContainer1.Size = New Size(844, 666)
        SplitContainer1.SplitterDistance = 422
        SplitContainer1.SplitterWidth = 1
        SplitContainer1.TabIndex = 0
        ' 
        ' btn_upcoming
        ' 
        btn_upcoming.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btn_upcoming.FlatAppearance.BorderSize = 0
        btn_upcoming.FlatStyle = FlatStyle.Flat
        btn_upcoming.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        btn_upcoming.ForeColor = Color.FromArgb(CByte(124), CByte(124), CByte(124))
        btn_upcoming.Location = New Point(14, 23)
        btn_upcoming.Name = "btn_upcoming"
        btn_upcoming.Size = New Size(178, 45)
        btn_upcoming.TabIndex = 1
        btn_upcoming.Text = "Upcoming"
        btn_upcoming.UseVisualStyleBackColor = False
        ' 
        ' btn_completed
        ' 
        btn_completed.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btn_completed.BackColor = Color.FromArgb(CByte(220), CByte(189), CByte(232))
        btn_completed.FlatAppearance.BorderSize = 0
        btn_completed.FlatStyle = FlatStyle.Flat
        btn_completed.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        btn_completed.Location = New Point(230, 23)
        btn_completed.Name = "btn_completed"
        btn_completed.Size = New Size(178, 45)
        btn_completed.TabIndex = 1
        btn_completed.Text = "Payment Remaining"
        btn_completed.UseVisualStyleBackColor = False
        ' 
        ' rtb1
        ' 
        rtb1.BackColor = Color.FromArgb(CByte(240), CByte(218), CByte(248))
        rtb1.BorderStyle = BorderStyle.None
        rtb1.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtb1.ForeColor = Color.Black
        rtb1.Location = New Point(16, 120)
        rtb1.Name = "rtb1"
        rtb1.Size = New Size(392, 176)
        rtb1.TabIndex = 9
        rtb1.Text = ""
        ' 
        ' rtb2
        ' 
        rtb2.BackColor = Color.FromArgb(CByte(240), CByte(218), CByte(248))
        rtb2.BorderStyle = BorderStyle.None
        rtb2.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtb2.ForeColor = Color.Black
        rtb2.Location = New Point(16, 320)
        rtb2.Name = "rtb2"
        rtb2.Size = New Size(392, 176)
        rtb2.TabIndex = 9
        rtb2.Text = ""
        ' 
        ' btn_pay
        ' 
        btn_pay.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btn_pay.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(215))
        btn_pay.FlatAppearance.BorderSize = 0
        btn_pay.FlatStyle = FlatStyle.Flat
        btn_pay.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        btn_pay.Location = New Point(32, 543)
        btn_pay.Name = "btn_pay"
        btn_pay.Size = New Size(358, 45)
        btn_pay.TabIndex = 1
        btn_pay.Text = "Pay Remaining Amount"
        btn_pay.UseVisualStyleBackColor = False
        ' 
        ' pending_payment
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        ClientSize = New Size(844, 666)
        Controls.Add(SplitContainer1)
        Font = New Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "pending_payment"
        Text = "Form1"
        SplitContainer1.Panel1.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents btn_upcoming As Button
    Friend WithEvents btn_completed As Button
    Friend WithEvents btn_pay As Button
    Friend WithEvents rtb1 As RichTextBox
    Friend WithEvents rtb2 As RichTextBox
End Class
