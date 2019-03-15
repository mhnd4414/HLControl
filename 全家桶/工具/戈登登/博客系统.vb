Public Class 博客系统

    Private Sub 博客系统_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        配置.绑定控件(TxtDir, 控件值类型.Text, "")
    End Sub

    Private Sub ButDir_Click(sender As Object, e As EventArgs) Handles ButDir.Click
        Dim s As String = 系统文件对话框.打开文件夹
        If s.Length > 0 Then TxtDir.Text = s
    End Sub

    Private Sub TxtDir_TextChanged(sender As Object, e As EventArgs) Handles TxtDir.TextChanged
        Pn.Enabled = 文件夹存在(TxtDir.Text)
        If Pn.Enabled Then
            TxtDir.Text = 路径标准化(TxtDir.Text)
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
        Dim s As String = TxtDir.Text + "source\"
        If 创建文件夹(s) Then 打开程序(s)
    End Sub

    Private Sub TxtCreate_TextChanged(sender As Object, e As EventArgs) Handles TxtCreate.TextChanged
        TxtCreate.Text = 筛选字符(TxtCreate.Text.ToLower, 阿拉伯数字 + 小写英文字母)
        ButCreate.Enabled = TxtCreate.TextLength > 0
    End Sub

    Private Sub ButPush_Click(sender As Object, e As EventArgs) Handles ButPush.Click
        Dim bat As String = TxtDir.Text + "push.bat"
        If 文件存在(bat) = False Then
            写文本到文件(bat, "git add -A
git commit -m " + 引(时间格式化(Now)) + "
git push origin master")
        End If
        打开程序(bat,, ProcessWindowStyle.Maximized)
    End Sub

End Class