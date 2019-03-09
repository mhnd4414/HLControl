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
        Me.components = New System.ComponentModel.Container()
        Me.LabNote = New WL.HLControl.HLLabel()
        Me.ButRead = New WL.HLControl.HLButton()
        Me.CheckOn = New WL.HLControl.HLCheckBox()
        Me.LabNext = New WL.HLControl.HLLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.ButTest = New WL.HLControl.HLButton()
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
        'CheckOn
        '
        Me.CheckOn.Location = New System.Drawing.Point(23, 161)
        Me.CheckOn.Name = "CheckOn"
        Me.CheckOn.Size = New System.Drawing.Size(179, 23)
        Me.CheckOn.TabIndex = 2
        Me.CheckOn.Text = "每20分钟提醒我一次（勾选后本软件开启时会自动运行这个）"
        '
        'LabNext
        '
        Me.LabNext.Location = New System.Drawing.Point(23, 190)
        Me.LabNext.Name = "LabNext"
        Me.LabNext.Size = New System.Drawing.Size(137, 23)
        Me.LabNext.TabIndex = 3
        Me.LabNext.Text = "（目前尚未启动）"
        '
        'Timer1
        '
        Me.Timer1.Interval = 1000
        '
        'ButTest
        '
        Me.ButTest.Location = New System.Drawing.Point(156, 124)
        Me.ButTest.Name = "ButTest"
        Me.ButTest.Size = New System.Drawing.Size(127, 31)
        Me.ButTest.TabIndex = 4
        Me.ButTest.Text = "提醒示例"
        '
        '保护视力的20分钟提醒器
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(622, 254)
        Me.Controls.Add(Me.ButTest)
        Me.Controls.Add(Me.LabNext)
        Me.Controls.Add(Me.CheckOn)
        Me.Controls.Add(Me.ButRead)
        Me.Controls.Add(Me.LabNote)
        Me.Name = "保护视力的20分钟提醒器"
        Me.Text = "保护视力的20分钟提醒器"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabNote As HLLabel
    Friend WithEvents ButRead As HLButton
    Friend WithEvents CheckOn As HLCheckBox
    Friend WithEvents LabNext As HLLabel
    Friend WithEvents Timer1 As Timer
    Friend WithEvents ButTest As HLButton
End Class
