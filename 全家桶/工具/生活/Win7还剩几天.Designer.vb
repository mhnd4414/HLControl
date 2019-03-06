<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Win7还剩几天
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Win7还剩几天))
        Me.ButRead = New WL.HLControl.HLButton()
        Me.LabTime = New WL.HLControl.HLLabel()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'ButRead
        '
        Me.ButRead.Location = New System.Drawing.Point(37, 53)
        Me.ButRead.Name = "ButRead"
        Me.ButRead.Size = New System.Drawing.Size(290, 31)
        Me.ButRead.TabIndex = 0
        Me.ButRead.Text = "点我阅读微软官方说明"
        '
        'LabTime
        '
        Me.LabTime.Font = New System.Drawing.Font("微软雅黑", 25.0!)
        Me.LabTime.Location = New System.Drawing.Point(37, 90)
        Me.LabTime.Name = "LabTime"
        Me.LabTime.Size = New System.Drawing.Size(423, 92)
        Me.LabTime.TabIndex = 1
        Me.LabTime.Text = "距离 Windows 7 " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "被微软彻底放弃支持还剩：" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Win7还剩几天
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(684, 282)
        Me.Controls.Add(Me.LabTime)
        Me.Controls.Add(Me.ButRead)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "Win7还剩几天"
        Me.ShowSteamIcon = False
        Me.Text = "对 Windows 7 的支持即将终止"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ButRead As HLButton
    Friend WithEvents LabTime As HLLabel
    Friend WithEvents Timer1 As Timer
End Class
