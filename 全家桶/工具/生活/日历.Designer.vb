<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class 日历
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(日历))
        Me.ListT = New WL.HLControl.HLListView()
        Me.ButAdd = New WL.HLControl.HLButton()
        Me.LabDate = New WL.HLControl.HLLabel()
        Me.Dates = New System.Windows.Forms.DateTimePicker()
        Me.LabJob = New WL.HLControl.HLLabel()
        Me.TxtJob = New WL.HLControl.HLTextBox()
        Me.ButRemove = New WL.HLControl.HLButton()
        Me.LabOften = New WL.HLControl.HLLabel()
        Me.ListOften = New WL.HLControl.HLComboBox()
        Me.SuspendLayout()
        '
        'ListT
        '
        Me.ListT.Dock = System.Windows.Forms.DockStyle.Top
        Me.ListT.Location = New System.Drawing.Point(10, 50)
        Me.ListT.Name = "ListT"
        Me.ListT.SelectedIndex = -1
        Me.ListT.SelectedItem = Nothing
        Me.ListT.ShowCount = False
        Me.ListT.Size = New System.Drawing.Size(539, 366)
        Me.ListT.TabIndex = 0
        Me.ListT.Text = "HlListView1"
        '
        'ButAdd
        '
        Me.ButAdd.Enabled = False
        Me.ButAdd.Location = New System.Drawing.Point(360, 422)
        Me.ButAdd.Name = "ButAdd"
        Me.ButAdd.Size = New System.Drawing.Size(186, 31)
        Me.ButAdd.TabIndex = 1
        Me.ButAdd.Text = "添加该事件到列表中"
        '
        'LabDate
        '
        Me.LabDate.Location = New System.Drawing.Point(13, 455)
        Me.LabDate.Name = "LabDate"
        Me.LabDate.Size = New System.Drawing.Size(87, 23)
        Me.LabDate.TabIndex = 2
        Me.LabDate.Text = "选出日期："
        '
        'Dates
        '
        Me.Dates.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.Dates.Location = New System.Drawing.Point(106, 455)
        Me.Dates.MaxDate = New Date(2030, 12, 31, 0, 0, 0, 0)
        Me.Dates.MinDate = New Date(2017, 1, 1, 0, 0, 0, 0)
        Me.Dates.Name = "Dates"
        Me.Dates.Size = New System.Drawing.Size(249, 29)
        Me.Dates.TabIndex = 3
        '
        'LabJob
        '
        Me.LabJob.Location = New System.Drawing.Point(13, 490)
        Me.LabJob.Name = "LabJob"
        Me.LabJob.Size = New System.Drawing.Size(87, 23)
        Me.LabJob.TabIndex = 4
        Me.LabJob.Text = "事件内容："
        '
        'TxtJob
        '
        Me.TxtJob.HighLightLabel = Me.LabJob
        Me.TxtJob.Lines = New String(-1) {}
        Me.TxtJob.Location = New System.Drawing.Point(106, 490)
        Me.TxtJob.Modified = False
        Me.TxtJob.Name = "TxtJob"
        Me.TxtJob.SelectedText = ""
        Me.TxtJob.SelectionLength = 0
        Me.TxtJob.SelectionStart = 0
        Me.TxtJob.Size = New System.Drawing.Size(249, 28)
        Me.TxtJob.TabIndex = 5
        '
        'ButRemove
        '
        Me.ButRemove.Enabled = False
        Me.ButRemove.Location = New System.Drawing.Point(361, 459)
        Me.ButRemove.Name = "ButRemove"
        Me.ButRemove.Size = New System.Drawing.Size(186, 31)
        Me.ButRemove.TabIndex = 6
        Me.ButRemove.Text = "删除列表中选中的事件"
        '
        'LabOften
        '
        Me.LabOften.Location = New System.Drawing.Point(13, 422)
        Me.LabOften.Name = "LabOften"
        Me.LabOften.Size = New System.Drawing.Size(87, 23)
        Me.LabOften.TabIndex = 7
        Me.LabOften.Text = "提醒频率："
        '
        'ListOften
        '
        Me.ListOften.HighLightLabel = Nothing
        Me.ListOften.Items.Add("0每年的X月X日提醒")
        Me.ListOften.Items.Add("1每月的X日提醒")
        Me.ListOften.Location = New System.Drawing.Point(106, 422)
        Me.ListOften.Name = "ListOften"
        Me.ListOften.SelectedIndex = -1
        Me.ListOften.SelectedItem = ""
        Me.ListOften.Size = New System.Drawing.Size(249, 27)
        Me.ListOften.TabIndex = 8
        Me.ListOften.Text = "HlComboBox1"
        '
        '日历
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(559, 540)
        Me.Controls.Add(Me.ListOften)
        Me.Controls.Add(Me.LabOften)
        Me.Controls.Add(Me.ButRemove)
        Me.Controls.Add(Me.TxtJob)
        Me.Controls.Add(Me.LabJob)
        Me.Controls.Add(Me.Dates)
        Me.Controls.Add(Me.LabDate)
        Me.Controls.Add(Me.ButAdd)
        Me.Controls.Add(Me.ListT)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "日历"
        Me.ShowSteamIcon = False
        Me.Text = "日历"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ListT As HLListView
    Friend WithEvents ButAdd As HLButton
    Friend WithEvents LabDate As HLLabel
    Friend WithEvents Dates As DateTimePicker
    Friend WithEvents LabJob As HLLabel
    Friend WithEvents TxtJob As HLTextBox
    Friend WithEvents ButRemove As HLButton
    Friend WithEvents LabOften As HLLabel
    Friend WithEvents ListOften As HLComboBox
End Class
