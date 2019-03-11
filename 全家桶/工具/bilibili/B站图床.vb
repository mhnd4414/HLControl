Public Class B站图床

    Private LastUpload As Byte(), bp As Bitmap

    Private Sub B站图床_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        配置.绑定控件(CheckAutoCopy, 控件值类型.Checked)
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
        清理()
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

    Private Sub ButResize_Click(sender As Object, e As EventArgs)
        If 非空(LastUpload) Then
            Dim m As Bitmap = 字节数组转图片(LastUpload)
            Dim x As Integer = m.Width
            Dim y As Integer = m.Height
            If x < 200 Then
                y *= 200 / x
                x = 200
            End If
            If y < 200 Then
                x *= 200 / y
                y = 200
            End If
            m = New Bitmap(m, New Size(x, y))
            Upload(图片转字节数组(m))
        End If
    End Sub

    Private Sub TxtOut_Click(sender As Object, e As EventArgs) Handles TxtOut.Click
        TxtOut.SelectAll()
    End Sub

    Private Sub 清理()
        PicView.Image = Nothing
        If 非空(bp) Then bp.Dispose()
        bp = Nothing
    End Sub

    Private Sub ButUploadLocal_Click(sender As Object, e As EventArgs) Handles ButUploadLocal.Click
        Dim m As String = 系统文件对话框.打开文件("Image files (*.jpg;*.png;*.gif)|*.jpg;*.png;*.gif|All files (*.*)|*.*")
        If m.Length > 3 Then Upload(读文件为字节数组(m))
    End Sub

    Private Sub Upload(m As Byte())
        清理()
        LastUpload = Nothing
        LabInfo.Text = ""
        TxtOut.Text = ""
        If 为空(m) Then
            TxtOut.Text = "图片为空？"
            Exit Sub
        End If
        If m.Length > 8 * 1024 * 1024 Then
            TxtOut.Text = "图片文件过大！"
            Exit Sub
        End If
        bp = 字节数组转图片(m)
        If 为空(bp) Then
            TxtOut.Text = "图片有误"
            Exit Sub
        End If
        Dim gif As String = 缓存文件夹 + "bg.gif"
        Dim s As String = "图片长宽：" & bp.Width & "x" & bp.Height & vbCrLf & "文件大小：" & 文件大小文字(m.Length)
        Dim fp As Integer = 获取帧数(bp)
        If fp > 1 Then
            写字节数组到文件(gif, m)
            bp = Image.FromFile(gif)
            s += vbCrLf + "帧数：" + fp.ToString
        End If
        PicView.Image = bp
        LabInfo.Text = s
        LastUpload = m
        Dim h As New 发送HTTP("https://api.vc.bilibili.com/api/v1/image/upload", "POST")
        h.Accept = ""
        h.超时 = 5
        Dim r As New 生成multipartformdata
        r.写入字节数组("file_up", 随机.小写英文字母 + ".png", "image/jpeg", m)
        r.写入参数("category", "daily")
        h.写入multipartformdata(r)
        s = h.获取回应为字符串(,, True)
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

    Private Sub B站图床_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            ButUploadClipboard.PerformClick()
        End If
    End Sub

End Class
