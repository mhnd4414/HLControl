Namespace HLControl

    Public Module 控件辅助信息

        Public ReadOnly DPI As Single = 系统信息.DPI

        Public ReadOnly 线宽 As Single = DPI * 4

        Public ReadOnly 基础绿 As Color = Color.FromArgb(76, 88, 68)
        Public ReadOnly 基础绿笔刷 As New SolidBrush(基础绿)

        Public ReadOnly 内容绿 As Color = Color.FromArgb(62, 70, 55)
        Public ReadOnly 内容绿笔刷 As New SolidBrush(内容绿)

        Public ReadOnly 白色 As Color = Color.FromArgb(255, 255, 255)
        Public ReadOnly 白色笔刷 As New SolidBrush(白色)

        Public ReadOnly 淡色 As Color = Color.FromArgb(160, 170, 149)

        Public ReadOnly 暗色 As Color = Color.FromArgb(40, 46, 34)
        Public ReadOnly 暗色笔 As New Pen(暗色, 线宽)
        Public ReadOnly 暗色笔刷 As New SolidBrush(暗色)

        Public ReadOnly 边缘白 As Color = Color.FromArgb(134, 145, 128)
        Public ReadOnly 边缘白笔 As New Pen(边缘白, 线宽)
        Public ReadOnly 边缘白笔刷 As New SolidBrush(边缘白)

        Public ReadOnly 黑边框 As New Pen(Color.Black, DPI * 2)
        Public ReadOnly 黑虚线边框 As New Pen(Color.Black, DPI * 2) With {.DashStyle = Drawing2D.DashStyle.Dot}

        Public ReadOnly 内容黄 As Color = Color.FromArgb(196, 181, 80)
        Public ReadOnly 内容黄笔刷 As New SolidBrush(内容黄)

        Public ReadOnly 内容白 As Color = Color.FromArgb(216, 222, 211)
        Public ReadOnly 内容白笔 As New Pen(内容白, 线宽)
        Public ReadOnly 内容白笔刷 As New SolidBrush(内容白)

        Public Function 点(x As Integer, y As Integer) As Point
            Return New Point(x, y)
        End Function

        Public Function 点F(x As Integer, y As Integer) As PointF
            Return New PointF(x, y)
        End Function

        Public Function 笔(颜色 As Color, Optional 宽度 As Single = 1) As Pen
            Return New Pen(颜色, 宽度)
        End Function

        Public Function 笔刷(颜色 As Color) As SolidBrush
            Return New SolidBrush(颜色)
        End Function

        Public Function 左上角(c As Rectangle, Optional 差 As Integer = 0) As Point
            Return 点(0 - 差, 0 - 差)
        End Function

        Public Function 左下角(c As Rectangle, Optional 差 As Integer = 0) As Point
            Return 点(0 - 差, c.Height - 差)
        End Function

        Public Function 右上角(c As Rectangle, Optional 差 As Integer = 0) As Point
            Return 点(c.Width - 差, 0)
        End Function

        Public Function 右下角(c As Rectangle, Optional 差 As Integer = 0) As Point
            Return 点(c.Width - 差, c.Height - 差)
        End Function

        Public Sub 绘制基础矩形(g As Graphics, c As Rectangle, Optional 按下 As Boolean = False, Optional 黑框 As Boolean = False, Optional 内容框 As Boolean = False)
            With g
                .FillRectangle(IFF(内容框, 内容绿笔刷, 基础绿笔刷), c)
                Dim s1 As Pen = IFF(按下, 暗色笔, 边缘白笔)
                Dim s2 As Pen = IFF(按下, 边缘白笔, 暗色笔)
                .DrawLine(s1, 左上角(c), 左下角(c))
                .DrawLine(s1, 左上角(c), 右上角(c))
                .DrawLine(s2, 右上角(c), 右下角(c))
                .DrawLine(s2, 左下角(c), 右下角(c))
                If 黑框 Then
                    .DrawRectangle(黑边框, c)
                    Dim d As Single = DPI * 4
                    .DrawRectangle(黑虚线边框, d, d, c.Width - d * 2, c.Height - d * 2)
                End If
            End With
        End Sub

        Public Function 文本宽度(文本 As String, 字体 As Font) As Single
            If 为空(文本, 字体) Then Return 0
            Static b As New Bitmap(1, 1)
            Static g As Graphics = Graphics.FromImage(b)
            Dim s As Single = g.MeasureString(文本, 字体).Width - 2
            If s < 0 Then s = 0
            Return s
        End Function

    End Module

End Namespace