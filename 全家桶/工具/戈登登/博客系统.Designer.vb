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
        Me.ButOpenDir = New WL.HLControl.HLButton()
        Me.ButCreate = New WL.HLControl.HLButton()
        Me.TxtCreate = New WL.HLControl.HLTextBox()
        Me.LabCreate = New WL.HLControl.HLLabel()
        Me.ButPush = New WL.HLControl.HLButton()
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
        Me.Pn.Controls.Add(Me.ButPush)
        Me.Pn.Controls.Add(Me.LabCreate)
        Me.Pn.Controls.Add(Me.TxtCreate)
        Me.Pn.Controls.Add(Me.ButCreate)
        Me.Pn.Controls.Add(Me.ButOpenDir)
        Me.Pn.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Pn.Enabled = False
        Me.Pn.Location = New System.Drawing.Point(10, 101)
        Me.Pn.Name = "Pn"
        Me.Pn.Size = New System.Drawing.Size(776, 170)
        Me.Pn.TabIndex = 3
        '
        'ButOpenDir
        '
        Me.ButOpenDir.Location = New System.Drawing.Point(0, 3)
        Me.ButOpenDir.Name = "ButOpenDir"
        Me.ButOpenDir.Size = New System.Drawing.Size(237, 31)
        Me.ButOpenDir.TabIndex = 0
        Me.ButOpenDir.Text = "查看文章源文件文件夹"
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
        'ButPush
        '
        Me.ButPush.Location = New System.Drawing.Point(243, 3)
        Me.ButPush.Name = "ButPush"
        Me.ButPush.Size = New System.Drawing.Size(218, 31)
        Me.ButPush.TabIndex = 4
        Me.ButPush.Text = "Git Push"
        '
        '博客系统
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(796, 281)
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
    Friend WithEvents ButPush As HLButton
End Class
