Public Class B站图床

    Private LastUpload As Byte()

    Private Sub B站图床_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CheckAutoCopy.Checked = 配置.真假("bilibili_autocopy")
    End Sub

    Private Sub ButUploadClipboard_Click(sender As Object, e As EventArgs) Handles ButUploadClipboard.Click
        Dim m As Bitmap = 剪贴板.图片
        If 为空(m) Then
            TxtOut.Text = "剪贴板里没有图片！"
        Else
            Upload(图片转字节数组(m))
        End If
    End Sub

    Private Sub ButCopyLink_Click(sender As Object, e As EventArgs) Handles ButCopyLink.Click
        If TxtOut.TextLength > 0 Then
            剪贴板.文本 = TxtOut.Text
        End If
    End Sub

    Private Sub B站图床_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        配置.真假("bilibili_autocopy") = CheckAutoCopy.Checked
    End Sub

    Private Sub B站图床_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    Private Sub B站图床_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        For Each i As String In e.Data.GetData(DataFormats.FileDrop)
            Upload(读文件为字节数组(i))
            Exit For
        Next
    End Sub

    Private Sub ButRetry_Click(sender As Object, e As EventArgs) Handles ButRetry.Click
        If 非空(LastUpload) Then
            Upload(LastUpload)
        End If
    End Sub

    Private Sub TxtOut_Click(sender As Object, e As EventArgs) Handles TxtOut.Click
        TxtOut.SelectAll()
    End Sub

    Private Sub Upload(m As Byte())
        PicView.Image = Nothing
        LastUpload = Nothing
        TxtOut.Text = ""
        If 为空(m) Then
            TxtOut.Text = "图片为空？"
            Exit Sub
        End If
        If m.Length > 8 * 1024 * 1024 Then
            TxtOut.Text = "图片文件过大！"
            Exit Sub
        End If
        Dim bp As Bitmap = 字节数组转图片(m)
        If 为空(bp) Then
            TxtOut.Text = "图片有误"
            Exit Sub
        End If
        Dim fm As String = 获取自动图片格式后缀(bp)
        If fm <> "gif" Then
            PicView.Image = bp
        End If
        LastUpload = m
        Dim h As New 发送HTTP("https://api.vc.bilibili.com/api/v1/image/upload", "POST")
        h.UA = 常用UserAgent.Chrome64
        Dim r As New 生成multipartformdata
        r.写入字节数组("file_up", 随机.小写英文字母 + "." + fm, "image/jpeg", m)
        r.写入参数("biz", "draw")
        r.写入参数("category", "daily")
        h.写入multipartformdata(r)
        Dim s As String = h.获取回应为字符串(,, True)
        If s.StartsWith("{code:0,message:success,data:{image_url:") Then
            s = 提取之间(s, "image_url:", ",image_width:").Replace("http:", "https:")
            If CheckAutoCopy.Checked Then 剪贴板.文本 = s
        Else
            TxtOut.Text = "网络出错："
            If s.StartsWith("{code:-1,") Then
                s = 提取之间(s, "message:", ",data:")
            End If
        End If
        TxtOut.Text += s
    End Sub

End Class
