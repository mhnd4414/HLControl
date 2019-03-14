Public Class 主窗体

    Private RightClose As Boolean
    Private ReadOnly 最后工具按钮列表 As New List(Of ToolStripMenuItem), 最后工具列表 As New List(Of String)

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
        AddHandler Me.KeyDown, AddressOf CtrlW关闭
        Dim a As String = "bilibili"
        添加工具(a, B站图床, My.Resources.图标库.B站)
        a = "生活"
        添加工具(a, 中小学生学习水平估测, My.Resources.图标库.文)
        添加工具(a, 每月提醒我, My.Resources.图标库.历, 配置.非空("日历列表"))
        添加工具(a, 保护视力的20分钟提醒器, My.Resources.图标库._20, 配置.非空(配置.生成控件读取(保护视力的20分钟提醒器.CheckOn)))
        添加工具(a, 跑我的网页脚本, My.Resources.图标库.IE)
        a = "系统"
        添加工具(a, 文件图标提取, My.Resources.图标库.ICO)
        添加工具(a, Win7还剩几天, My.Resources.图标库.win7)
        a = "走過去的"
        添加工具(a, 简单加密器, My.Resources.图标库.贼)
        ListTools.SortAll()
        For i As Integer = 0 To 4
            Dim g As New ToolStripMenuItem()
            最后工具按钮列表.Add(g)
            NotifMenu.Items.Insert(0, g)
            AddHandler g.Click, Sub()
                                    打开工具(g.Text)
                                End Sub
            g.Visible = False
        Next
        For Each i As String In 分行(配置.字符串("最后工具"), True)
            最后工具列表.Add(i)
        Next
        最后工具按钮列表.Reverse()
        RightClose = False
        随机说话()
    End Sub

    Private Sub 添加工具(组 As String, 窗体 As HLForm, 图标 As Icon, Optional 预加载 As Boolean = False)
        添加工具(组, 窗体.Name, 窗体, 图标, 预加载)
    End Sub

    Private Sub 添加工具(组 As String, 名字 As String, 窗体 As HLForm, 图标 As Icon, Optional 预加载 As Boolean = False)
        If 为空(图标, 窗体) Then Exit Sub
        Dim g As HLGroup = ListTools.GetGroup(组)
        If 为空(g) Then
            g = New HLGroup(组)
            ListTools.Groups.Add(g)
        End If
        If 非空(获取工具(名字)) Then
            出错("工具重名", 名字)
            Exit Sub
        End If
        Dim t As New HLGroupItem(名字, 图标)
        g.Items.Add(t)
        Dim a As New 工具(组, 名字, 窗体, 图标, 预加载)
        With a
            AddHandler .打开后, Sub()
                                 最后工具列表.Remove(.名字)
                                 最后工具列表.Insert(0, .名字)
                             End Sub
        End With
        工具列表.Add(a)
    End Sub

    Private Sub ListTools_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles ListTools.MouseDoubleClick
        Dim i As HLGroupItem = ListTools.SelectedItem
        If 为空(i) Then Exit Sub
        打开工具(i.Title)
    End Sub

    Private Sub NotifMenu_Opening(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles NotifMenu.Opening
        Dim m As Integer = 0
        For i As Integer = 0 To 最后工具按钮列表.Count - 1
            Dim t As ToolStripItem = 最后工具按钮列表.Item(i)
            Dim s As String = ""
            If i < 最后工具列表.Count Then s = 最后工具列表.Item(i)
            t.Text = s
            t.Visible = s.Length > 0
        Next
    End Sub

    Private Sub 弹出窗口(a As HLForm, m As HLForm)
        With m
            .Show()
            .Left = a.Left
            .Top = a.Top
            .WindowState = FormWindowState.Normal
            .BringToFront()
        End With
    End Sub

    Private Sub 打开工具(m As String)
        Dim t As 工具 = 获取工具(m)
        If 为空(t) Then Exit Sub
        t.启动()
    End Sub

    Private Sub 主窗体_FormClosing(sender As HLForm, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim s As String = ""
        For i As Integer = 0 To 最后工具列表.Count - 1
            s += 最后工具列表(i) + vbCrLf
        Next
        配置.字符串("最后工具") = s
        e.Cancel = True
        If RightClose Then
            RightClose = False
            退出ToolStripMenuItem.PerformClick()
        Else
            Hide()
            随机说话()
        End If
    End Sub

    Private Sub 打开主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主页ToolStripMenuItem.Click
        弹出窗口(Me, Me)
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click
        正常退出()
    End Sub

    Private Sub 主窗体_MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        If e.Button = MouseButtons.Right Then RightClose = True
    End Sub

    Private Sub 主窗体_MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        RightClose = False
    End Sub

    Private Sub 随机说话()
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
"请和我提理智并且有价值的问题。",
"你知道吗？眼保健操只有中国人做，而且，只有大陆。其他国家地区的人根本不做这个。").ToString
    End Sub

End Class
