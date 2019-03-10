<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class B站图床
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
        Me.PicView = New System.Windows.Forms.PictureBox()
        Me.ButUploadClipboard = New WL.HLControl.HLButton()
        Me.TxtOut = New WL.HLControl.HLTextBox()
        Me.ButCopyLink = New WL.HLControl.HLButton()
        Me.CheckAutoCopy = New WL.HLControl.HLCheckBox()
        Me.ButRetry = New WL.HLControl.HLButton()
        Me.LabNote = New WL.HLControl.HLLabel()
        Me.ButUploadLocal = New WL.HLControl.HLButton()
        Me.LabInfo = New WL.HLControl.HLLabel()
        CType(Me.PicView, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PicView
        '
        Me.PicView.Dock = System.Windows.Forms.DockStyle.Top
        Me.PicView.Location = New System.Drawing.Point(10, 50)
        Me.PicView.Name = "PicView"
        Me.PicView.Size = New System.Drawing.Size(533, 150)
        Me.PicView.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.PicView.TabIndex = 0
        Me.PicView.TabStop = False
        '
        'ButUploadClipboard
        '
        Me.ButUploadClipboard.Location = New System.Drawing.Point(10, 234)
        Me.ButUploadClipboard.Name = "ButUploadClipboard"
        Me.ButUploadClipboard.Size = New System.Drawing.Size(158, 31)
        Me.ButUploadClipboard.TabIndex = 1
        Me.ButUploadClipboard.Text = "上传剪贴板图片"
        '
        'TxtOut
        '
        Me.TxtOut.Dock = System.Windows.Forms.DockStyle.Top
        Me.TxtOut.HideSelection = False
        Me.TxtOut.HighLightLabel = Nothing
        Me.TxtOut.Lines = New String(-1) {}
        Me.TxtOut.Location = New System.Drawing.Point(10, 200)
        Me.TxtOut.Modified = False
        Me.TxtOut.Name = "TxtOut"
        Me.TxtOut.ReadOnly = True
        Me.TxtOut.SelectedText = ""
        Me.TxtOut.SelectionLength = 0
        Me.TxtOut.SelectionStart = 0
        Me.TxtOut.Size = New System.Drawing.Size(533, 28)
        Me.TxtOut.TabIndex = 2
        '
        'ButCopyLink
        '
        Me.ButCopyLink.Location = New System.Drawing.Point(10, 271)
        Me.ButCopyLink.Name = "ButCopyLink"
        Me.ButCopyLink.Size = New System.Drawing.Size(199, 31)
        Me.ButCopyLink.TabIndex = 3
        Me.ButCopyLink.Text = "复制链接或相关信息"
        '
        'CheckAutoCopy
        '
        Me.CheckAutoCopy.Location = New System.Drawing.Point(10, 312)
        Me.CheckAutoCopy.Name = "CheckAutoCopy"
        Me.CheckAutoCopy.Size = New System.Drawing.Size(193, 23)
        Me.CheckAutoCopy.TabIndex = 4
        Me.CheckAutoCopy.Text = "上传成功自动复制链接"
        '
        'ButRetry
        '
        Me.ButRetry.Location = New System.Drawing.Point(376, 234)
        Me.ButRetry.Name = "ButRetry"
        Me.ButRetry.Size = New System.Drawing.Size(158, 31)
        Me.ButRetry.TabIndex = 5
        Me.ButRetry.Text = "重试上传"
        '
        'LabNote
        '
        Me.LabNote.AutoSize = True
        Me.LabNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabNote.Location = New System.Drawing.Point(215, 268)
        Me.LabNote.Name = "LabNote"
        Me.LabNote.Size = New System.Drawing.Size(0, 21)
        Me.LabNote.TabIndex = 7
        '
        'ButUploadLocal
        '
        Me.ButUploadLocal.Location = New System.Drawing.Point(174, 234)
        Me.ButUploadLocal.Name = "ButUploadLocal"
        Me.ButUploadLocal.Size = New System.Drawing.Size(196, 31)
        Me.ButUploadLocal.TabIndex = 8
        Me.ButUploadLocal.Text = "选择本地图片并上传"
        '
        'LabInfo
        '
        Me.LabInfo.AutoSize = True
        Me.LabInfo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(216, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(211, Byte), Integer))
        Me.LabInfo.Location = New System.Drawing.Point(215, 271)
        Me.LabInfo.Name = "LabInfo"
        Me.LabInfo.Size = New System.Drawing.Size(138, 21)
        Me.LabInfo.TabIndex = 9
        Me.LabInfo.Text = "（尚未上传图片）"
        '
        'B站图床
        '
        Me.AllowDrop = True
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(553, 363)
        Me.Controls.Add(Me.LabInfo)
        Me.Controls.Add(Me.ButUploadLocal)
        Me.Controls.Add(Me.LabNote)
        Me.Controls.Add(Me.ButRetry)
        Me.Controls.Add(Me.CheckAutoCopy)
        Me.Controls.Add(Me.ButCopyLink)
        Me.Controls.Add(Me.TxtOut)
        Me.Controls.Add(Me.ButUploadClipboard)
        Me.Controls.Add(Me.PicView)
        Me.KeyPreview = True
        Me.Name = "B站图床"
        Me.ShowSteamIcon = False
        Me.Text = "B站图床（支持小于8MB的 jpg png gif）"
        CType(Me.PicView, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PicView As PictureBox
    Friend WithEvents ButUploadClipboard As HLButton
    Friend WithEvents TxtOut As HLTextBox
    Friend WithEvents ButCopyLink As HLButton
    Friend WithEvents CheckAutoCopy As HLCheckBox
    Friend WithEvents ButRetry As HLButton
    Friend WithEvents LabNote As HLLabel
    Friend WithEvents ButUploadLocal As HLButton
    Friend WithEvents LabInfo As HLLabel
End Class
