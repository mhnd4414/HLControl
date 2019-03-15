Public Class 博客系统

    Private dir As String, source As String, posts As String
    Private headfile As String, headerfile As String, cssfile As String

    Private Sub 博客系统_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        配置.绑定控件(TxtDir, 控件值类型.Text, "")
        配置.绑定控件(TxtTitle, 控件值类型.Text, "走過去的博客")
    End Sub

    Private Sub ButDir_Click(sender As Object, e As EventArgs) Handles ButDir.Click
        Dim s As String = 系统文件对话框.打开文件夹
        If s.Length > 0 Then TxtDir.Text = s
    End Sub

    Private Sub TxtDir_TextChanged(sender As Object, e As EventArgs) Handles TxtDir.TextChanged
        Pn.Enabled = 文件夹存在(TxtDir.Text)
        If Pn.Enabled Then
            dir = 路径标准化(TxtDir.Text)
            TxtDir.Text = dir
            source = dir + "source\"
            posts = source + "posts\"
            headfile = source + "__head.html"
            headerfile = source + "__header.html"
            cssfile = source + "maincss.css"
        End If
    End Sub

    Private Sub TxtDir_DragEnter(sender As Object, e As DragEventArgs) Handles TxtDir.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    Private Sub TxtDir_DragDrop(sender As Object, e As DragEventArgs) Handles TxtDir.DragDrop
        For Each i As String In e.Data.GetData(DataFormats.FileDrop)
            If 文件夹存在(i) Then TxtDir.Text = 路径标准化(i)
        Next
    End Sub

    Private Sub ButOpenDir_Click(sender As Object, e As EventArgs) Handles ButOpenDir.Click
        If 创建文件夹(source) Then 打开程序(source)
    End Sub

    Private Sub TxtCreate_TextChanged(sender As Object, e As EventArgs) Handles TxtCreate.TextChanged
        TxtCreate.Text = 筛选字符(TxtCreate.Text.ToLower, 阿拉伯数字 + 小写英文字母)
        ButCreate.Enabled = TxtCreate.TextLength > 0
    End Sub

    Private Sub ButCreate_Click(sender As Object, e As EventArgs) Handles ButCreate.Click
        Dim tt As String = TxtCreate.Text
        Dim md As String = posts + Year(Now).ToString + "\" + tt + ".md"
        Dim fs() As String = Directory.GetFiles(posts, "*" + tt + ".md", SearchOption.AllDirectories)
        If fs.Length > 0 Then
            MsgBox("抱歉，文件已经存在！" + vbCrLf + fs(0), MsgBoxStyle.Critical)
            Exit Sub
        End If
        TxtCreate.Text = ""
        If 写文本到文件(md, "---
title: " + tt + "
date: " + 时间格式化(Today, "Y-M-D") + "
---
这里是文章内容。") Then
            打开程序(md)
        End If
    End Sub

    Private Sub editfile(f As String, t As String)
        If 文件存在(f) = False Then
            写文本到文件(f, t)
        End If
        打开程序(f)
    End Sub

    Private Sub ButEditCSS_Click(sender As Object, e As EventArgs) Handles ButEditCSS.Click
        editfile(cssfile, My.Resources.博客系统资源.head)
    End Sub

    Private Sub ButEditHead_Click(sender As Object, e As EventArgs) Handles ButEditHead.Click
        editfile(headfile, My.Resources.博客系统资源.head)
    End Sub

    Private Sub ButEditHeader_Click(sender As Object, e As EventArgs) Handles ButEditHeader.Click
        editfile(headerfile, My.Resources.博客系统资源.header)
    End Sub

    Private Sub ButPush_Click(sender As Object, e As EventArgs)
        Dim bat As String = dir + "push.bat"
        If 文件存在(bat) = False Then
            写文本到文件(bat, "git add -A
git commit -m " + 引(时间格式化(Now)) + "
git push origin master
pause")
        End If
        打开程序(bat)
    End Sub

    Private Sub ButGen_Click(sender As Object, e As EventArgs) Handles ButGen.Click

    End Sub

End Class
