<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class provider_appointment_details
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
        SplitContainer1 = New SplitContainer()
        Label1 = New Label()
        rtb1 = New RichTextBox()
        rtb2 = New RichTextBox()
        btn_appointment_completed = New Button()
        btn_cancel = New Button()
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
        SplitContainer1.Panel1.Controls.Add(Label1)
        SplitContainer1.Panel1.Controls.Add(rtb1)
        SplitContainer1.Panel1.Controls.Add(rtb2)
        SplitContainer1.Panel1.Controls.Add(btn_appointment_completed)
        SplitContainer1.Panel1.Controls.Add(btn_cancel)
        SplitContainer1.Size = New Size(844, 666)
        SplitContainer1.SplitterDistance = 422
        SplitContainer1.SplitterWidth = 1
        SplitContainer1.TabIndex = 0
        ' 

        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Font = New Font("Segoe UI", 13F, FontStyle.Bold)
        Label1.Location = New Point(14, 42)
        Label1.Name = "Label1"
        Label1.Size = New Size(267, 36)
        Label1.TabIndex = 3
        Label1.Text = "Appointment Details"
        ' 
        ' rtb1
        ' 
        rtb1.BackColor = Color.FromArgb(CByte(240), CByte(218), CByte(248))
        rtb1.BorderStyle = BorderStyle.None
        rtb1.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        rtb1.ForeColor = Color.Black
        rtb1.Location = New Point(15, 120)
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
        ' btn_appointment_completed
        ' 
        btn_appointment_completed.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btn_appointment_completed.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(215))
        btn_appointment_completed.FlatAppearance.BorderSize = 0
        btn_appointment_completed.FlatStyle = FlatStyle.Flat
        btn_appointment_completed.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        btn_appointment_completed.Location = New Point(14, 543)
        btn_appointment_completed.Name = "btn_appointment_completed"
        btn_appointment_completed.Size = New Size(178, 45)
        btn_appointment_completed.TabIndex = 1
        btn_appointment_completed.Text = "Completed"
        btn_appointment_completed.UseVisualStyleBackColor = False
        ' 
        ' btn_cancel
        ' 
        btn_cancel.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        btn_cancel.BackColor = Color.FromArgb(CByte(245), CByte(140), CByte(215))
        btn_cancel.FlatAppearance.BorderSize = 0
        btn_cancel.FlatStyle = FlatStyle.Flat
        btn_cancel.Font = New Font("Microsoft YaHei", 10.2F, FontStyle.Bold)
        btn_cancel.Location = New Point(230, 543)
        btn_cancel.Name = "btn_cancel"
        btn_cancel.Size = New Size(178, 45)
        btn_cancel.TabIndex = 1
        btn_cancel.Text = "Cancel"
        btn_cancel.UseVisualStyleBackColor = False
        ' 
        ' provider_appointment_details
        ' 
        AutoScaleMode = AutoScaleMode.None
        BackColor = Color.White
        ClientSize = New Size(844, 666)
        Controls.Add(SplitContainer1)
        Font = New Font("Microsoft YaHei", 9F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        FormBorderStyle = FormBorderStyle.None
        Name = "provider_appointment_details"
        Text = "Form1"
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel1.PerformLayout()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents btn_appointment_completed As Button
    Friend WithEvents btn_cancel As Button
    Friend WithEvents rtb1 As RichTextBox
    Friend WithEvents rtb2 As RichTextBox
End Class
