Public Class 主窗体

    Private 工具列表 As Dictionary(Of HLGroupItem, HLForm)

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = 标题
        Icon = 图标
        工具列表 = New Dictionary(Of HLGroupItem, HLForm)
        Dim a As String = "bilibili"
        添加工具(a, "图床", B站图床)
        a = "生活"
        添加工具(a, 中小学生学习水平估测)
        添加工具(a, 每月提醒我)
        a = "系统"
        添加工具(a, 文件图标提取)
        ListTools.SortAll()
        With 消息图标
            .Visible = True
            .Icon = Icon
            .Text = Text
            .ContextMenuStrip = NotifMenu
        End With
    End Sub

    Private Sub 添加工具(组 As String, 窗体 As HLForm)
        添加工具(组, 窗体.Name, 窗体)
    End Sub

    Private Sub 添加工具(组 As String, 名字 As String, 窗体 As HLForm)
        Dim g As HLGroup = ListTools.GetGroup(组)
        If 为空(g) Then
            g = New HLGroup(组)
            ListTools.Groups.Add(g)
        End If
        Dim t As New HLGroupItem(名字, 窗体.Icon)
        AddHandler 窗体.FormClosing, AddressOf 主窗体_FormClosing
        g.Items.Add(t)
        工具列表.Add(t, 窗体)
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
        If Text <> sender.Text AndAlso Me.Visible = False Then
            ShowUp(sender, Me)
            With Me
                .Left = sender.Right - .Width
                .Top = sender.Top
            End With
        End If
        sender.Hide()
    End Sub

    Private Sub 打开主页ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 打开主页ToolStripMenuItem.Click
        ShowUp(Me, Me)
    End Sub

    Private Sub 退出ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles 退出ToolStripMenuItem.Click
        My.MyApplication.正常退出()
    End Sub

End Class
