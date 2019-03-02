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
        Me.ListTools = New WL.HLControl.HLGroupList()
        Me.SuspendLayout()
        '
        'ListTools
        '
        Me.ListTools.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListTools.Location = New System.Drawing.Point(10, 50)
        Me.ListTools.Name = "ListTools"
        Me.ListTools.SelectedIndex = -1
        Me.ListTools.SelectedItem = Nothing
        Me.ListTools.Size = New System.Drawing.Size(278, 372)
        Me.ListTools.TabIndex = 0
        Me.ListTools.Text = "HlGroupList1"
        '
        '主窗体
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(298, 476)
        Me.Controls.Add(Me.ListTools)
        Me.KeyPreview = True
        Me.Name = "主窗体"
        Me.ShowSteamIcon = False
        Me.Text = "走過去的全家桶"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListTools As HLGroupList
End Class
