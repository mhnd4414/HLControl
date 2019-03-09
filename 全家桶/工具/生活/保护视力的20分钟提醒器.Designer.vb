<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 保护视力的20分钟提醒器
    Inherits WL.HLControl.HLForm

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。  
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.LabNote = New WL.HLControl.HLLabel()
        Me.ButRead = New WL.HLControl.HLButton()
        Me.SuspendLayout()
        '
        'LabNote
        '
        Me.LabNote.Location = New System.Drawing.Point(23, 53)
        Me.LabNote.Name = "LabNote"
        Me.LabNote.Size = New System.Drawing.Size(583, 65)
        Me.LabNote.TabIndex = 0
        Me.LabNote.Text = "美国验光协会（The American Academy of Ophthalmology）提倡：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "20/20/20原则" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "每看电子屏幕20分钟就起来休息20秒，" &
    "然后看向20英尺（约6米）以外的物品。"
        '
        'ButRead
        '
        Me.ButRead.Location = New System.Drawing.Point(23, 124)
        Me.ButRead.Name = "ButRead"
        Me.ButRead.Size = New System.Drawing.Size(127, 31)
        Me.ButRead.TabIndex = 1
        Me.ButRead.Text = "阅读相关文章"
        '
        '保护视力的20分钟提醒器
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(633, 358)
        Me.Controls.Add(Me.ButRead)
        Me.Controls.Add(Me.LabNote)
        Me.Name = "保护视力的20分钟提醒器"
        Me.Text = "保护视力的20分钟提醒器"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabNote As HLLabel
    Friend WithEvents ButRead As HLButton
End Class
