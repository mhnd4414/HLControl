Public Class 文件图标提取

    Private Ic As Icon = Nothing

    Private Sub 文件图标提取_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        e.Effect = DragDropEffects.Link
    End Sub

    Private Sub 文件图标提取_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim s As String = ""
        Ic = Nothing
        For Each i As String In e.Data.GetData(DataFormats.FileDrop)
            If 文件存在(i) Then
                s = i
                Exit For
            End If
        Next
        If 为空(s) Then
            LabFile.Text = "（没有有效的文件）"
            Exit Sub
        End If
        Dim a As String = s, g As Integer = Width / Font.Size
        If s.Length > g Then
            a = "..." + 右(a, g)
        End If
        LabFile.Text = a
        Dim m As Icon = Nothing
        Try
            m = Icon.ExtractAssociatedIcon(s)
            If 非空(m) Then
                Ic = m
                PnIco.Refresh()
            End If
        Catch ex As Exception
            出错(ex)
            LabFile.Text += vbCrLf + "出错：" + ex.Message
        End Try
    End Sub

    Private Sub PnIco_Paint(sender As Object, e As PaintEventArgs) Handles PnIco.Paint
        With e.Graphics
            If 非空(Ic) Then .DrawIcon(Ic, PnIco.ClientRectangle)
        End With
    End Sub

    Private Sub ButSaveIco_Click(sender As Object, e As EventArgs) Handles ButSaveIco.Click
        If 为空(Ic) Then Exit Sub
        Dim f As String = 系统文件对话框.保存文件("Icon File (*.ico)|*.ico")
        If f.Length > 5 AndAlso 删除文件(f) Then
            Dim s As Stream = Nothing
            Try
                s = File.OpenWrite(f)
                Ic.Save(s)
                s.Close()
            Catch ex As Exception
                出错(ex)
            End Try
            If 非空(s) Then s.Dispose()
        End If
    End Sub

    Private Sub ButSavePNG_Click(sender As Object, e As EventArgs) Handles ButSavePNG.Click
        If 为空(Ic) Then Exit Sub
        Dim f As String = 系统文件对话框.保存文件("PNG File (*.png)|*.png")
        If f.Length > 5 AndAlso 删除文件(f) Then
            Dim b As New Bitmap(Ic.Width, Ic.Height)
            Dim g As Graphics = Graphics.FromImage(b)
            g.DrawIcon(Ic, New Rectangle(0, 0, b.Width, b.Height))
            b.Save(f)
        End If
    End Sub

End Class