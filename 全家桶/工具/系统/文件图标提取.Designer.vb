<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 文件图标提取
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
        Me.LabFile = New WL.HLControl.HLLabel()
        Me.PnIco = New System.Windows.Forms.Panel()
        Me.ButSaveIco = New WL.HLControl.HLButton()
        Me.ButSavePNG = New WL.HLControl.HLButton()
        Me.SuspendLayout()
        '
        'LabNote
        '
        Me.LabNote.Location = New System.Drawing.Point(13, 43)
        Me.LabNote.Name = "LabNote"
        Me.LabNote.Size = New System.Drawing.Size(285, 44)
        Me.LabNote.TabIndex = 0
        Me.LabNote.Text = "请从外面拖入任意一个文件到本窗口，" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "然后我会解析文件使用的图标。"
        '
        'LabFile
        '
        Me.LabFile.Location = New System.Drawing.Point(13, 93)
        Me.LabFile.Name = "LabFile"
        Me.LabFile.Size = New System.Drawing.Size(137, 23)
        Me.LabFile.TabIndex = 1
        Me.LabFile.Text = "（尚未选择文件）"
        '
        'PnIco
        '
        Me.PnIco.Location = New System.Drawing.Point(23, 151)
        Me.PnIco.Name = "PnIco"
        Me.PnIco.Size = New System.Drawing.Size(182, 182)
        Me.PnIco.TabIndex = 2
        '
        'ButSaveIco
        '
        Me.ButSaveIco.Location = New System.Drawing.Point(211, 302)
        Me.ButSaveIco.Name = "ButSaveIco"
        Me.ButSaveIco.Size = New System.Drawing.Size(141, 31)
        Me.ButSaveIco.TabIndex = 3
        Me.ButSaveIco.Text = "保存 .ico"
        '
        'ButSavePNG
        '
        Me.ButSavePNG.Location = New System.Drawing.Point(211, 265)
        Me.ButSavePNG.Name = "ButSavePNG"
        Me.ButSavePNG.Size = New System.Drawing.Size(141, 31)
        Me.ButSavePNG.TabIndex = 4
        Me.ButSavePNG.Text = "保存 .png"
        '
        '文件图标提取
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(503, 346)
        Me.Controls.Add(Me.ButSavePNG)
        Me.Controls.Add(Me.ButSaveIco)
        Me.Controls.Add(Me.PnIco)
        Me.Controls.Add(Me.LabFile)
        Me.Controls.Add(Me.LabNote)
        Me.KeyPreview = True
        Me.Name = "文件图标提取"
        Me.ShowSteamIcon = False
        Me.Text = "文件图标提取"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabNote As HLLabel
    Friend WithEvents LabFile As HLLabel
    Friend WithEvents PnIco As Panel
    Friend WithEvents ButSaveIco As HLButton
    Friend WithEvents ButSavePNG As HLButton
End Class
