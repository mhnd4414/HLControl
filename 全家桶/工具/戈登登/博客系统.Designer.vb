<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 博客系统
    Inherits WL.HLControl.HLForm

    'Form 重写 Dispose，以清理组件列表。
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.LabDir = New WL.HLControl.HLLabel()
        Me.TxtDir = New WL.HLControl.HLTextBox()
        Me.ButDir = New WL.HLControl.HLButton()
        Me.Pn = New System.Windows.Forms.Panel()
        Me.ButEditHead = New WL.HLControl.HLButton()
        Me.ButEditCSS = New WL.HLControl.HLButton()
        Me.ButEditHeader = New WL.HLControl.HLButton()
        Me.TxtJump = New WL.HLControl.HLTextBox()
        Me.LabJump = New WL.HLControl.HLLabel()
        Me.ButGen = New WL.HLControl.HLButton()
        Me.LabCreate = New WL.HLControl.HLLabel()
        Me.TxtCreate = New WL.HLControl.HLTextBox()
        Me.ButCreate = New WL.HLControl.HLButton()
        Me.ButOpenDir = New WL.HLControl.HLButton()
        Me.LabTitle = New WL.HLControl.HLLabel()
        Me.TxtTitle = New WL.HLControl.HLTextBox()
        Me.TxtLog = New WL.HLControl.HLTextBox()
        Me.Pn.SuspendLayout()
        Me.SuspendLayout()
        '
        'LabDir
        '
        Me.LabDir.AutoSize = True
        Me.LabDir.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabDir.Location = New System.Drawing.Point(28, 53)
        Me.LabDir.Name = "LabDir"
        Me.LabDir.Size = New System.Drawing.Size(106, 21)
        Me.LabDir.TabIndex = 0
        Me.LabDir.Text = "博客文件夹："
        '
        'TxtDir
        '
        Me.TxtDir.AllowDrop = True
        Me.TxtDir.HighLightLabel = Nothing
        Me.TxtDir.Lines = New String(-1) {}
        Me.TxtDir.Location = New System.Drawing.Point(127, 53)
        Me.TxtDir.Modified = False
        Me.TxtDir.Name = "TxtDir"
        Me.TxtDir.SelectedText = ""
        Me.TxtDir.SelectionLength = 0
        Me.TxtDir.SelectionStart = 0
        Me.TxtDir.Size = New System.Drawing.Size(525, 28)
        Me.TxtDir.TabIndex = 1
        '
        'ButDir
        '
        Me.ButDir.Location = New System.Drawing.Point(658, 50)
        Me.ButDir.Name = "ButDir"
        Me.ButDir.Size = New System.Drawing.Size(100, 31)
        Me.ButDir.TabIndex = 2
        Me.ButDir.Text = "浏览"
        '
        'Pn
        '
        Me.Pn.Controls.Add(Me.TxtLog)
        Me.Pn.Controls.Add(Me.TxtTitle)
        Me.Pn.Controls.Add(Me.LabTitle)
        Me.Pn.Controls.Add(Me.ButEditHead)
        Me.Pn.Controls.Add(Me.ButEditCSS)
        Me.Pn.Controls.Add(Me.ButEditHeader)
        Me.Pn.Controls.Add(Me.TxtJump)
        Me.Pn.Controls.Add(Me.LabJump)
        Me.Pn.Controls.Add(Me.ButGen)
        Me.Pn.Controls.Add(Me.LabCreate)
        Me.Pn.Controls.Add(Me.TxtCreate)
        Me.Pn.Controls.Add(Me.ButCreate)
        Me.Pn.Controls.Add(Me.ButOpenDir)
        Me.Pn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn.Enabled = False
        Me.Pn.Location = New System.Drawing.Point(10, 87)
        Me.Pn.Name = "Pn"
        Me.Pn.Size = New System.Drawing.Size(776, 421)
        Me.Pn.TabIndex = 3
        '
        'ButEditHead
        '
        Me.ButEditHead.Location = New System.Drawing.Point(399, 122)
        Me.ButEditHead.Name = "ButEditHead"
        Me.ButEditHead.Size = New System.Drawing.Size(171, 31)
        Me.ButEditHead.TabIndex = 10
        Me.ButEditHead.Text = "编辑自定义<head>"
        '
        'ButEditCSS
        '
        Me.ButEditCSS.Location = New System.Drawing.Point(399, 196)
        Me.ButEditCSS.Name = "ButEditCSS"
        Me.ButEditCSS.Size = New System.Drawing.Size(171, 31)
        Me.ButEditCSS.TabIndex = 9
        Me.ButEditCSS.Text = "编辑CSS"
        '
        'ButEditHeader
        '
        Me.ButEditHeader.Location = New System.Drawing.Point(399, 159)
        Me.ButEditHeader.Name = "ButEditHeader"
        Me.ButEditHeader.Size = New System.Drawing.Size(171, 31)
        Me.ButEditHeader.TabIndex = 8
        Me.ButEditHeader.Text = "编辑自定义头部"
        '
        'TxtJump
        '
        Me.TxtJump.AcceptsReturn = True
        Me.TxtJump.HighLightLabel = Me.LabJump
        Me.TxtJump.Lines = New String(-1) {}
        Me.TxtJump.Location = New System.Drawing.Point(3, 123)
        Me.TxtJump.Modified = False
        Me.TxtJump.Multiline = True
        Me.TxtJump.Name = "TxtJump"
        Me.TxtJump.ScrollBar = True
        Me.TxtJump.SelectedText = ""
        Me.TxtJump.SelectionLength = 0
        Me.TxtJump.SelectionStart = 0
        Me.TxtJump.Size = New System.Drawing.Size(390, 150)
        Me.TxtJump.TabIndex = 7
        '
        'LabJump
        '
        Me.LabJump.AutoSize = True
        Me.LabJump.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabJump.Location = New System.Drawing.Point(3, 99)
        Me.LabJump.Name = "LabJump"
        Me.LabJump.Size = New System.Drawing.Size(318, 21)
        Me.LabJump.TabIndex = 6
        Me.LabJump.Text = "自动跳转链接列表：（示例：link1>link2）"
        '
        'ButGen
        '
        Me.ButGen.Location = New System.Drawing.Point(243, 3)
        Me.ButGen.Name = "ButGen"
        Me.ButGen.Size = New System.Drawing.Size(218, 31)
        Me.ButGen.TabIndex = 5
        Me.ButGen.Text = "生成博客文件并推送"
        '
        'LabCreate
        '
        Me.LabCreate.AutoSize = True
        Me.LabCreate.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabCreate.Location = New System.Drawing.Point(3, 37)
        Me.LabCreate.Name = "LabCreate"
        Me.LabCreate.Size = New System.Drawing.Size(442, 21)
        Me.LabCreate.TabIndex = 3
        Me.LabCreate.Text = "在下面输入新文章的名字，只能使用英文字母和阿拉伯数字："
        '
        'TxtCreate
        '
        Me.TxtCreate.HighLightLabel = Me.LabCreate
        Me.TxtCreate.Lines = New String(-1) {}
        Me.TxtCreate.Location = New System.Drawing.Point(3, 68)
        Me.TxtCreate.MaxLength = 20
        Me.TxtCreate.Modified = False
        Me.TxtCreate.Name = "TxtCreate"
        Me.TxtCreate.SelectedText = ""
        Me.TxtCreate.SelectionLength = 0
        Me.TxtCreate.SelectionStart = 0
        Me.TxtCreate.Size = New System.Drawing.Size(299, 28)
        Me.TxtCreate.TabIndex = 2
        '
        'ButCreate
        '
        Me.ButCreate.Enabled = False
        Me.ButCreate.Location = New System.Drawing.Point(308, 68)
        Me.ButCreate.Name = "ButCreate"
        Me.ButCreate.Size = New System.Drawing.Size(153, 31)
        Me.ButCreate.TabIndex = 1
        Me.ButCreate.Text = "新建一篇文章"
        '
        'ButOpenDir
        '
        Me.ButOpenDir.Location = New System.Drawing.Point(0, 3)
        Me.ButOpenDir.Name = "ButOpenDir"
        Me.ButOpenDir.Size = New System.Drawing.Size(237, 31)
        Me.ButOpenDir.TabIndex = 0
        Me.ButOpenDir.Text = "查看文章源文件文件夹"
        '
        'LabTitle
        '
        Me.LabTitle.AutoSize = True
        Me.LabTitle.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabTitle.Location = New System.Drawing.Point(467, 3)
        Me.LabTitle.Name = "LabTitle"
        Me.LabTitle.Size = New System.Drawing.Size(90, 21)
        Me.LabTitle.TabIndex = 11
        Me.LabTitle.Text = "网站标题："
        '
        'TxtTitle
        '
        Me.TxtTitle.HighLightLabel = Me.LabTitle
        Me.TxtTitle.Lines = New String(-1) {}
        Me.TxtTitle.Location = New System.Drawing.Point(549, 6)
        Me.TxtTitle.MaxLength = 20
        Me.TxtTitle.Modified = False
        Me.TxtTitle.Name = "TxtTitle"
        Me.TxtTitle.SelectedText = ""
        Me.TxtTitle.SelectionLength = 0
        Me.TxtTitle.SelectionStart = 0
        Me.TxtTitle.Size = New System.Drawing.Size(211, 28)
        Me.TxtTitle.TabIndex = 12
        '
        'TxtLog
        '
        Me.TxtLog.AcceptsReturn = True
        Me.TxtLog.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.TxtLog.HighLightLabel = Nothing
        Me.TxtLog.Lines = New String(-1) {}
        Me.TxtLog.Location = New System.Drawing.Point(0, 279)
        Me.TxtLog.Modified = False
        Me.TxtLog.Multiline = True
        Me.TxtLog.Name = "TxtLog"
        Me.TxtLog.ReadOnly = True
        Me.TxtLog.ScrollBar = True
        Me.TxtLog.SelectedText = ""
        Me.TxtLog.SelectionLength = 0
        Me.TxtLog.SelectionStart = 0
        Me.TxtLog.Size = New System.Drawing.Size(776, 142)
        Me.TxtLog.TabIndex = 13
        '
        '博客系统
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(796, 518)
        Me.Controls.Add(Me.Pn)
        Me.Controls.Add(Me.ButDir)
        Me.Controls.Add(Me.TxtDir)
        Me.Controls.Add(Me.LabDir)
        Me.Name = "博客系统"
        Me.Text = "博客系统"
        Me.Pn.ResumeLayout(False)
        Me.Pn.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents LabDir As HLLabel
    Friend WithEvents TxtDir As HLTextBox
    Friend WithEvents ButDir As HLButton
    Friend WithEvents Pn As Panel
    Friend WithEvents ButOpenDir As HLButton
    Friend WithEvents ButCreate As HLButton
    Friend WithEvents TxtCreate As HLTextBox
    Friend WithEvents LabCreate As HLLabel
    Friend WithEvents ButGen As HLButton
    Friend WithEvents LabJump As HLLabel
    Friend WithEvents TxtJump As HLTextBox
    Friend WithEvents ButEditHeader As HLButton
    Friend WithEvents ButEditCSS As HLButton
    Friend WithEvents ButEditHead As HLButton
    Friend WithEvents LabTitle As HLLabel
    Friend WithEvents TxtTitle As HLTextBox
    Friend WithEvents TxtLog As HLTextBox
End Class
