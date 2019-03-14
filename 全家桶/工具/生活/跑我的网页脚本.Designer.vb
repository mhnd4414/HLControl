<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 跑我的网页脚本
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
        Me.WB = New System.Windows.Forms.WebBrowser()
        Me.Pn = New System.Windows.Forms.Panel()
        Me.SuspendLayout()
        '
        'WB
        '
        Me.WB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.WB.IsWebBrowserContextMenuEnabled = False
        Me.WB.Location = New System.Drawing.Point(10, 175)
        Me.WB.Margin = New System.Windows.Forms.Padding(0)
        Me.WB.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WB.Name = "WB"
        Me.WB.ScriptErrorsSuppressed = True
        Me.WB.Size = New System.Drawing.Size(844, 313)
        Me.WB.TabIndex = 0
        Me.WB.TabStop = False
        '
        'Pn
        '
        Me.Pn.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Pn.Location = New System.Drawing.Point(10, 50)
        Me.Pn.Name = "Pn"
        Me.Pn.Size = New System.Drawing.Size(844, 125)
        Me.Pn.TabIndex = 1
        '
        '跑我的网页脚本
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(864, 498)
        Me.Controls.Add(Me.Pn)
        Me.Controls.Add(Me.WB)
        Me.Name = "跑我的网页脚本"
        Me.Text = "跑我的网页脚本"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents WB As WebBrowser
    Friend WithEvents Pn As Panel
End Class
