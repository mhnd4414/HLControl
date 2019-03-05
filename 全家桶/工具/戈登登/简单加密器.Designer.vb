<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 简单加密器
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
        Me.LabKey = New WL.HLControl.HLLabel()
        Me.TxtKey = New WL.HLControl.HLTextBox()
        Me.TxtIn = New WL.HLControl.HLTextBox()
        Me.LabIN = New WL.HLControl.HLLabel()
        Me.LabOut = New WL.HLControl.HLLabel()
        Me.TxtOut = New WL.HLControl.HLTextBox()
        Me.ButEn = New WL.HLControl.HLButton()
        Me.ButDE = New WL.HLControl.HLButton()
        Me.SuspendLayout()
        '
        'LabKey
        '
        Me.LabKey.Location = New System.Drawing.Point(13, 48)
        Me.LabKey.Name = "LabKey"
        Me.LabKey.Size = New System.Drawing.Size(87, 23)
        Me.LabKey.TabIndex = 0
        Me.LabKey.Text = "你的密钥："
        '
        'TxtKey
        '
        Me.TxtKey.HighLightLabel = Nothing
        Me.TxtKey.Lines = New String(-1) {}
        Me.TxtKey.Location = New System.Drawing.Point(104, 48)
        Me.TxtKey.MaxLength = 30
        Me.TxtKey.Modified = False
        Me.TxtKey.Name = "TxtKey"
        Me.TxtKey.SelectedText = ""
        Me.TxtKey.SelectionLength = 0
        Me.TxtKey.SelectionStart = 0
        Me.TxtKey.Size = New System.Drawing.Size(219, 28)
        Me.TxtKey.TabIndex = 1
        '
        'TxtIn
        '
        Me.TxtIn.AcceptsReturn = True
        Me.TxtIn.HighLightLabel = Nothing
        Me.TxtIn.Lines = New String(-1) {}
        Me.TxtIn.Location = New System.Drawing.Point(104, 82)
        Me.TxtIn.Modified = False
        Me.TxtIn.Multiline = True
        Me.TxtIn.Name = "TxtIn"
        Me.TxtIn.ScrollBar = True
        Me.TxtIn.SelectedText = ""
        Me.TxtIn.SelectionLength = 0
        Me.TxtIn.SelectionStart = 0
        Me.TxtIn.Size = New System.Drawing.Size(407, 149)
        Me.TxtIn.TabIndex = 2
        '
        'LabIN
        '
        Me.LabIN.Location = New System.Drawing.Point(44, 82)
        Me.LabIN.Name = "LabIN"
        Me.LabIN.Size = New System.Drawing.Size(54, 23)
        Me.LabIN.TabIndex = 3
        Me.LabIN.Text = "输入："
        '
        'LabOut
        '
        Me.LabOut.Location = New System.Drawing.Point(44, 237)
        Me.LabOut.Name = "LabOut"
        Me.LabOut.Size = New System.Drawing.Size(54, 23)
        Me.LabOut.TabIndex = 4
        Me.LabOut.Text = "输出："
        '
        'TxtOut
        '
        Me.TxtOut.AcceptsReturn = True
        Me.TxtOut.HighLightLabel = Nothing
        Me.TxtOut.Lines = New String(-1) {}
        Me.TxtOut.Location = New System.Drawing.Point(104, 237)
        Me.TxtOut.Modified = False
        Me.TxtOut.Multiline = True
        Me.TxtOut.Name = "TxtOut"
        Me.TxtOut.ScrollBar = True
        Me.TxtOut.SelectedText = ""
        Me.TxtOut.SelectionLength = 0
        Me.TxtOut.SelectionStart = 0
        Me.TxtOut.Size = New System.Drawing.Size(407, 149)
        Me.TxtOut.TabIndex = 5
        '
        'ButEn
        '
        Me.ButEn.Location = New System.Drawing.Point(329, 45)
        Me.ButEn.Name = "ButEn"
        Me.ButEn.Size = New System.Drawing.Size(75, 31)
        Me.ButEn.TabIndex = 6
        Me.ButEn.Text = "加密"
        '
        'ButDE
        '
        Me.ButDE.Location = New System.Drawing.Point(410, 45)
        Me.ButDE.Name = "ButDE"
        Me.ButDE.Size = New System.Drawing.Size(75, 31)
        Me.ButDE.TabIndex = 7
        Me.ButDE.Text = "解密"
        '
        '简单加密器
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(535, 436)
        Me.Controls.Add(Me.ButDE)
        Me.Controls.Add(Me.ButEn)
        Me.Controls.Add(Me.TxtOut)
        Me.Controls.Add(Me.LabOut)
        Me.Controls.Add(Me.LabIN)
        Me.Controls.Add(Me.TxtIn)
        Me.Controls.Add(Me.TxtKey)
        Me.Controls.Add(Me.LabKey)
        Me.KeyPreview = True
        Me.Name = "简单加密器"
        Me.ShowSteamIcon = False
        Me.Text = "走過去的简单加密器"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabKey As HLLabel
    Friend WithEvents TxtKey As HLTextBox
    Friend WithEvents TxtIn As HLTextBox
    Friend WithEvents LabIN As HLLabel
    Friend WithEvents LabOut As HLLabel
    Friend WithEvents TxtOut As HLTextBox
    Friend WithEvents ButEn As HLButton
    Friend WithEvents ButDE As HLButton
End Class
