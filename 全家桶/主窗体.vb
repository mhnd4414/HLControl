Public Class 主窗体

    Private 工具列表 As Dictionary(Of HLGroupItem, HLForm), RightClose As Boolean

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = 标题
        Icon = 图标
        With 消息图标
            .Visible = True
            .Icon = Icon
            .Text = Text
            .ContextMenuStrip = NotifMenu
            AddHandler .DoubleClick, Sub()
                                         打开主页ToolStripMenuItem.PerformClick()
                                     End Sub
        End With
        工具列表 = New Dictionary(Of HLGroupItem, HLForm)
        Dim a As String = "bilibili"
        添加工具(a, "图床", B站图床)
        a = "生活"
        添加工具(a, 中小学生学习水平估测)
        添加工具(a, 每月提醒我, True)
        a = "系统"
        添加工具(a, 文件图标提取)
        添加工具(a, Win7还剩几天)
        a = "走過去的"
        添加工具(a, 简单加密器)
        ListTools.SortAll()
        RightClose = False
        RandomSaying()
    End Sub

    Private Sub 添加工具(组 As String, 窗体 As HLForm, Optional 预加载 As Boolean = False)
        添加工具(组, 窗体.Name, 窗体, 预加载)
    End Sub

    Private Sub 添加工具(组 As String, 名字 As String, 窗体 As HLForm, Optional 预加载 As Boolean = False)
        Dim g As HLGroup = ListTools.GetGroup(组)
        If 为空(g) Then
            g = New HLGroup(组)
            ListTools.Groups.Add(g)
        End If
        Dim t As New HLGroupItem(名字, 窗体.Icon)
        窗体.KeyPreview = True
        AddHandler 窗体.FormClosing, AddressOf 主窗体_FormClosing
        AddHandler 窗体.KeyDown, AddressOf 主窗体_KeyDown
        g.Items.Add(t)
        工具列表.Add(t, 窗体)
        With 窗体
            If 预加载 Then
                .ShowInTaskbar = False
                .Show()
                .Hide()
                .ShowInTaskbar = True
            End If
        End With
    End Sub

    Private Sub ListTools_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListTools.MouseDoubleClick
        Dim i As HLGroupItem = ListTools.SelectedItem
        If 为空(i) OrElse 工具列表.ContainsKey(i) = False Then Exit Sub
        ShowUp(Me, 工具列表.Item(i))
    End Sub

    Private Sub ShowUp(a As HLForm, m As HLForm)
        With m
            .Show()
            .Left = a.Left
            .Top = a.Top
            .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub

    Private Sub 主窗体_FormClosing(sender As HLForm, e As FormClosingEventArgs) Handles Me.FormClosing
        e.Cancel = True
        Dim m As Integer = 0
        For Each i As Form In My.Application.OpenForms
            If i.Visible Then m += 1
        Next
        If Text <> sender.Text AndAlso Me.Visible = False AndAlso m < 2 Then
            ShowUp(sender, Me)
            With Me
                .Left = sender.Right - .Width
                .Top = sender.Top
            End With
        ElseIf Text = sender.Text Then
            If RightClose Then
                退出ToolStripMenuItem.PerformClick()
            End If
            RandomSaying()
        End If
        sender.Hide()
    End Sub

    Private Sub 打开主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主页ToolStripMenuItem.Click
        ShowUp(Me, Me)
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click
        My.MyApplication.正常退出()
    End Sub

    Private Sub 主窗体_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.W Then
            sender.Close()
        End If
    End Sub

    Private Sub 主窗体_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Right Then RightClose = True
    End Sub

    Private Sub 主窗体_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        RightClose = False
    End Sub

    Private Sub RandomSaying()
        LabFun.Text = 随机.当中一个("你知道吗？鼠标右击主页的关闭按钮可以直接退出程序而不是停在后台。",
"每一个不是清洁工的人都说清洁工很伟大。",
"花钱才是硬道理。",
"一个比一个干净，反过来看，一个比一个肮脏。",
"You forget a thousand things every day, make sure this is one of them.",
"曾经有一个朋友让我电脑登录他的steam账号帮他做点事情，我很高兴，因为他信任我，被信任真好。",
"人啊，不要有点成功就开始来点名言警句教人家做人，结果到头来反而被自己说的大道理压死。——敖厂长", "傻子不是骗子，骗子不是傻子。",
"要想BUG少，女装不能少。",
"高DPI很可能会出各种各样的BUG，烦死了。", "我很不敢相信，有的人碰过智能手机，没有碰过电脑的鼠标键盘。",
"我也想做合法的事情，如果合法手段有用的话。",
"你猜猜这里一共可以出现几句话？",
"做傻瓜式软件救不了中国人。",
"别和差的比，越差越有理。",
"教不会学生自己去学的老师是废物。",
"请和我提理智并且有价值的问题。").ToString
    End Sub

End Class
