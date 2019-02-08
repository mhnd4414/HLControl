Public Class 按钮
    Inherits Control

    Private 激活 As Boolean, 按住 As Boolean

    Public Sub New()
        激活 = False
        按住 = False
    End Sub

    Private Sub _TextChanged() Handles Me.TextChanged
        If 包含(Text, vbCr, vbLf) Then Text = 替换(Text, vbCrLf, " ", vbLf, " ", vbCr, " ")
    End Sub

    Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.TextChanged, Me.FontChanged, Me.EnabledChanged
        Invalidate()
    End Sub

    Private Sub _GotFocus() Handles Me.GotFocus
        激活 = True
        Invalidate()
    End Sub

    Private Sub _LostFocus() Handles Me.LostFocus
        激活 = False
        Invalidate()
    End Sub

    Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
        按住 = True
        If 激活 Then
            Invalidate()
        Else
            Focus()
        End If
    End Sub

    Private Sub _MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
        按住 = False
        Invalidate()
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Height = 10 * DPI + Font.GetHeight
        MyBase.OnPaint(e)
        With e.Graphics
            Dim c As Rectangle = ClientRectangle
            .FillRectangle(基础绿笔刷, c)
            Dim s1 As Pen = IFF(按住, 暗色笔, 边缘白笔)
            Dim s2 As Pen = IFF(按住 = False, 暗色笔, 边缘白笔)
            .DrawLine(s1, 左上角(c), 左下角(c))
            .DrawLine(s1, 左上角(c), 右上角(c))
            .DrawLine(s2, 右上角(c), 右下角(c))
            .DrawLine(s2, 左下角(c), 右下角(c))
            If 激活 Then
                .DrawRectangle(黑边框, c)
                Dim d As Single = DPI * 4
                .DrawRectangle(黑虚线边框, d, d, Width - d * 2, Height - d * 2)
            End If
            .DrawString(Text, Font, IFF(Enabled, 白色笔刷, 暗色笔刷), New PointF(6 * DPI, 4 * DPI))
        End With
    End Sub

End Class
