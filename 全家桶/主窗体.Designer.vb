<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 主窗体
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
        Me.components = New System.ComponentModel.Container()
        Me.ListTools = New WL.HLControl.HLGroupList()
        Me.NotifMenu = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.打开主页ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LabFun = New System.Windows.Forms.Label()
        Me.NotifMenu.SuspendLayout()
        Me.SuspendLayout()
        '
        'ListTools
        '
        Me.ListTools.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListTools.Location = New System.Drawing.Point(10, 50)
        Me.ListTools.Name = "ListTools"
        Me.ListTools.SelectedIndex = -1
        Me.ListTools.SelectedItem = Nothing
        Me.ListTools.Size = New System.Drawing.Size(296, 347)
        Me.ListTools.TabIndex = 0
        Me.ListTools.Text = "HlGroupList1"
        '
        'NotifMenu
        '
        Me.NotifMenu.Font = New System.Drawing.Font("微软雅黑", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotifMenu.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.打开主页ToolStripMenuItem, Me.退出ToolStripMenuItem})
        Me.NotifMenu.Name = "NotifMenu"
        Me.NotifMenu.Size = New System.Drawing.Size(145, 56)
        '
        '打开主页ToolStripMenuItem
        '
        Me.打开主页ToolStripMenuItem.Name = "打开主页ToolStripMenuItem"
        Me.打开主页ToolStripMenuItem.Size = New System.Drawing.Size(144, 26)
        Me.打开主页ToolStripMenuItem.Text = "打开主页"
        '
        '退出ToolStripMenuItem
        '
        Me.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem"
        Me.退出ToolStripMenuItem.Size = New System.Drawing.Size(144, 26)
        Me.退出ToolStripMenuItem.Text = "退出"
        '
        'LabFun
        '
        Me.LabFun.Dock = System.Windows.Forms.DockStyle.Fill
        Me.LabFun.Font = New System.Drawing.Font("微软雅黑", 10.0!)
        Me.LabFun.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabFun.Location = New System.Drawing.Point(10, 397)
        Me.LabFun.Margin = New System.Windows.Forms.Padding(3)
        Me.LabFun.Name = "LabFun"
        Me.LabFun.Padding = New System.Windows.Forms.Padding(3)
        Me.LabFun.Size = New System.Drawing.Size(296, 93)
        Me.LabFun.TabIndex = 1
        Me.LabFun.Text = "我记得我要说什么来着"
        '
        '主窗体
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(316, 500)
        Me.Controls.Add(Me.LabFun)
        Me.Controls.Add(Me.ListTools)
        Me.KeyPreview = True
        Me.Name = "主窗体"
        Me.ShowSteamIcon = False
        Me.Text = "走過去的全家桶"
        Me.NotifMenu.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListTools As HLGroupList
    Friend WithEvents NotifMenu As ContextMenuStrip
    Friend WithEvents 打开主页ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents 退出ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents LabFun As Label
End Class
