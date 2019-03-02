<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class 中小学学习水平估测
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(中小学学习水平估测))
        Me.LabNote = New WL.HLControl.HLLabel()
        Me.LabYourPos = New WL.HLControl.HLLabel()
        Me.LabAll = New WL.HLControl.HLLabel()
        Me.TxtYourPos = New WL.HLControl.HLTextBox()
        Me.TxtAll = New WL.HLControl.HLTextBox()
        Me.LabArea = New WL.HLControl.HLLabel()
        Me.LabUp = New WL.HLControl.HLLabel()
        Me.TxtUp = New WL.HLControl.HLTextBox()
        Me.ButCalc = New WL.HLControl.HLButton()
        Me.LabOut = New WL.HLControl.HLLabel()
        Me.LabPercent = New WL.HLControl.HLLabel()
        Me.LabNote2 = New WL.HLControl.HLLabel()
        Me.ButGood = New WL.HLControl.HLButton()
        Me.ButBad = New WL.HLControl.HLButton()
        Me.SuspendLayout()
        '
        'LabNote
        '
        Me.LabNote.Location = New System.Drawing.Point(30, 36)
        Me.LabNote.LowLight = True
        Me.LabNote.Name = "LabNote"
        Me.LabNote.Size = New System.Drawing.Size(301, 44)
        Me.LabNote.TabIndex = 0
        Me.LabNote.Text = "本测试仅供参考，不代表任何实际价值。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "年级越接近，相互的数值比较越可靠。"
        '
        'LabYourPos
        '
        Me.LabYourPos.Location = New System.Drawing.Point(48, 136)
        Me.LabYourPos.Name = "LabYourPos"
        Me.LabYourPos.Size = New System.Drawing.Size(87, 23)
        Me.LabYourPos.TabIndex = 1
        Me.LabYourPos.Text = "你的排名："
        '
        'LabAll
        '
        Me.LabAll.Location = New System.Drawing.Point(31, 165)
        Me.LabAll.Name = "LabAll"
        Me.LabAll.Size = New System.Drawing.Size(104, 23)
        Me.LabAll.TabIndex = 2
        Me.LabAll.Text = "总参考人数："
        '
        'TxtYourPos
        '
        Me.TxtYourPos.HighLightLabel = Me.LabYourPos
        Me.TxtYourPos.Lines = New String(-1) {}
        Me.TxtYourPos.Location = New System.Drawing.Point(141, 131)
        Me.TxtYourPos.MaxLength = 7
        Me.TxtYourPos.Modified = False
        Me.TxtYourPos.Name = "TxtYourPos"
        Me.TxtYourPos.SelectedText = ""
        Me.TxtYourPos.SelectionLength = 0
        Me.TxtYourPos.SelectionStart = 0
        Me.TxtYourPos.Size = New System.Drawing.Size(128, 28)
        Me.TxtYourPos.TabIndex = 3
        '
        'TxtAll
        '
        Me.TxtAll.HighLightLabel = Me.LabAll
        Me.TxtAll.Lines = New String(-1) {}
        Me.TxtAll.Location = New System.Drawing.Point(141, 165)
        Me.TxtAll.MaxLength = 7
        Me.TxtAll.Modified = False
        Me.TxtAll.Name = "TxtAll"
        Me.TxtAll.SelectedText = ""
        Me.TxtAll.SelectionLength = 0
        Me.TxtAll.SelectionStart = 0
        Me.TxtAll.Size = New System.Drawing.Size(128, 28)
        Me.TxtAll.TabIndex = 4
        '
        'LabArea
        '
        Me.LabArea.Location = New System.Drawing.Point(30, 86)
        Me.LabArea.Name = "LabArea"
        Me.LabArea.Size = New System.Drawing.Size(301, 44)
        Me.LabArea.TabIndex = 5
        Me.LabArea.Text = "请填写你在一定地区范围内的考试排名，" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "比如市里、省里，范围越大越好。"
        '
        'LabUp
        '
        Me.LabUp.Location = New System.Drawing.Point(20, 199)
        Me.LabUp.Name = "LabUp"
        Me.LabUp.Size = New System.Drawing.Size(318, 44)
        Me.LabUp.TabIndex = 6
        Me.LabUp.Text = "你所在的班级的学生" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "进入本科大学（重点高中、初中）的概率："
        '
        'TxtUp
        '
        Me.TxtUp.HighLightLabel = Me.LabUp
        Me.TxtUp.Lines = New String(-1) {}
        Me.TxtUp.Location = New System.Drawing.Point(344, 215)
        Me.TxtUp.MaxLength = 2
        Me.TxtUp.Modified = False
        Me.TxtUp.Name = "TxtUp"
        Me.TxtUp.SelectedText = ""
        Me.TxtUp.SelectionLength = 0
        Me.TxtUp.SelectionStart = 0
        Me.TxtUp.Size = New System.Drawing.Size(60, 28)
        Me.TxtUp.TabIndex = 7
        '
        'ButCalc
        '
        Me.ButCalc.Location = New System.Drawing.Point(20, 262)
        Me.ButCalc.Name = "ButCalc"
        Me.ButCalc.Size = New System.Drawing.Size(162, 31)
        Me.ButCalc.TabIndex = 8
        Me.ButCalc.Text = "计算学习水平"
        '
        'LabOut
        '
        Me.LabOut.Location = New System.Drawing.Point(20, 299)
        Me.LabOut.Name = "LabOut"
        Me.LabOut.Size = New System.Drawing.Size(54, 23)
        Me.LabOut.TabIndex = 9
        Me.LabOut.Text = "结果："
        '
        'LabPercent
        '
        Me.LabPercent.Location = New System.Drawing.Point(410, 215)
        Me.LabPercent.Name = "LabPercent"
        Me.LabPercent.Size = New System.Drawing.Size(19, 23)
        Me.LabPercent.TabIndex = 10
        Me.LabPercent.Text = "%"
        '
        'LabNote2
        '
        Me.LabNote2.Location = New System.Drawing.Point(20, 357)
        Me.LabNote2.LowLight = True
        Me.LabNote2.Name = "LabNote2"
        Me.LabNote2.Size = New System.Drawing.Size(373, 44)
        Me.LabNote2.TabIndex = 11
        Me.LabNote2.Text = "计算结果越大越好，但最大值为100，最小值为0。" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "且通常不可能到达100和0。"
        '
        'ButGood
        '
        Me.ButGood.Location = New System.Drawing.Point(194, 262)
        Me.ButGood.Name = "ButGood"
        Me.ButGood.Size = New System.Drawing.Size(90, 31)
        Me.ButGood.TabIndex = 12
        Me.ButGood.Text = "绝对学霸"
        '
        'ButBad
        '
        Me.ButBad.Location = New System.Drawing.Point(290, 262)
        Me.ButBad.Name = "ButBad"
        Me.ButBad.Size = New System.Drawing.Size(90, 31)
        Me.ButBad.TabIndex = 13
        Me.ButBad.Text = "绝对学渣"
        '
        '中小学学习水平估测
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(511, 414)
        Me.Controls.Add(Me.ButBad)
        Me.Controls.Add(Me.ButGood)
        Me.Controls.Add(Me.LabNote2)
        Me.Controls.Add(Me.LabPercent)
        Me.Controls.Add(Me.LabOut)
        Me.Controls.Add(Me.ButCalc)
        Me.Controls.Add(Me.TxtUp)
        Me.Controls.Add(Me.LabUp)
        Me.Controls.Add(Me.LabArea)
        Me.Controls.Add(Me.TxtAll)
        Me.Controls.Add(Me.TxtYourPos)
        Me.Controls.Add(Me.LabAll)
        Me.Controls.Add(Me.LabYourPos)
        Me.Controls.Add(Me.LabNote)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "中小学学习水平估测"
        Me.ShowSteamIcon = False
        Me.Text = "中小学生学习水平估测"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents LabNote As HLLabel
    Friend WithEvents LabYourPos As HLLabel
    Friend WithEvents LabAll As HLLabel
    Friend WithEvents TxtYourPos As HLTextBox
    Friend WithEvents TxtAll As HLTextBox
    Friend WithEvents LabArea As HLLabel
    Friend WithEvents LabUp As HLLabel
    Friend WithEvents TxtUp As HLTextBox
    Friend WithEvents ButCalc As HLButton
    Friend WithEvents LabOut As HLLabel
    Friend WithEvents LabPercent As HLLabel
    Friend WithEvents LabNote2 As HLLabel
    Friend WithEvents ButGood As HLButton
    Friend WithEvents ButBad As HLButton
End Class
