Public Module 公共成员

    Public ReadOnly 版本 As New Version(1, 0)
    Public ReadOnly 标题 As String = "走過去的全家桶 v" + 版本.ToString
    Public ReadOnly 图标 As Icon = My.Resources.图标库.主图标
    Public ReadOnly 配置 As New WSave(本程序.路径 + "wbin.wsave")
    Public ReadOnly 缓存文件夹 As String = 本程序.路径 + "wbin_temp\"
    Public ReadOnly 消息图标 As New NotifyIcon
    Public ReadOnly 工具列表 As New List(Of 工具)
    Public 缓存文件夹保护文件 As Stream

    Public Sub 弹出消息(t As String, m As String, Optional i As ToolTipIcon = ToolTipIcon.Info)
        If 非空(消息图标) Then 消息图标.ShowBalloonTip(999, t, m, i)
    End Sub

    Public Sub 正常退出()
        For Each i As Form In My.Application.OpenForms
            i.Close()
        Next
        消息图标.Visible = False
        消息图标.Dispose()
        缓存文件夹保护文件.Close()
        缓存文件夹保护文件.Dispose()
        删除文件(缓存文件夹)
        配置.保存到本地()
        本程序.退出()
    End Sub

    Public Sub CtrlW关闭(sender As Object, e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.W Then
            sender.Close()
        End If
    End Sub

    Public Function 获取工具(m As String) As 工具
        If 为空(m) Then Return Nothing
        m = m.ToLower.Trim
        For Each i As 工具 In 工具列表
            If i.窗体.Text.ToLower.Contains(m) OrElse i.名字.ToLower.Contains(m) Then
                Return i
            End If
        Next
        Return Nothing
    End Function

    Public Class 工具

        Private 开始清除 As Boolean

        Public Sub New(组 As String, 名字 As String, 窗体 As HLForm, 图标 As Icon, Optional 预加载 As Boolean = False)
            开始清除 = False
            Me.组 = 组
            Me.名字 = 名字
            Me.窗体 = 窗体
            Me.图标 = 图标
            With 窗体
                If 预加载 Then
                    .ShowInTaskbar = False
                    .Show()
                    .Hide()
                    .ShowInTaskbar = True
                End If
                .ShowSteamIcon = False
                AddHandler .FormClosing, Sub(sender As HLForm, e As FormClosingEventArgs)
                                             If 开始清除 Then
                                                 Exit Sub
                                             End If
                                             e.Cancel = True
                                             .Hide()
                                             RaiseEvent 退出后()
                                         End Sub
                AddHandler .KeyDown, AddressOf CtrlW关闭
            End With
        End Sub

        Public Event 打开后()
        Public Event 退出后()

        Public ReadOnly Property 组 As String
        Public ReadOnly Property 名字 As String
        Public ReadOnly Property 窗体 As HLForm

        Public Property 图标 As Icon
            Get
                Return 窗体.Icon
            End Get
            Set(v As Icon)
                窗体.Icon = v
            End Set
        End Property

        Public Sub 启动()
            With 窗体
                .Show()
                If 主窗体.Visible Then
                    .Left = 主窗体.Left
                    .Top = 主窗体.Top
                Else
                    .Left = (系统信息.屏幕分辨率.Width - .Width) / 2
                    .Top = (系统信息.屏幕分辨率.Height - .Height) / 2
                End If
                .WindowState = FormWindowState.Normal
                .BringToFront()
            End With
            RaiseEvent 打开后()
        End Sub

        Public Overrides Function Equals(obj As Object) As Boolean
            If obj.GetType = [GetType]() Then
                Dim o As 工具 = obj
                If o.名字.ToLower = 名字.ToLower OrElse o.窗体.Text.ToLower = 窗体.Text.ToLower Then
                    Return True
                End If
            End If
            Return False
        End Function

        Public Sub 清除()
            开始清除 = True
            窗体.Close()
            窗体.Dispose()
            Finalize()
        End Sub

    End Class

End Module
