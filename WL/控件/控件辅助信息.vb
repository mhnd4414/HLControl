Public Module 控件辅助信息

    Public ReadOnly DPI As Single = 系统信息.DPI

    Public ReadOnly 线宽 As Single = DPI * 3

    Public ReadOnly 基础绿 As Color = Color.FromArgb(76, 88, 68)
    Public ReadOnly 基础绿笔刷 As New SolidBrush(基础绿)

    Public ReadOnly 白色 As Color = Color.FromArgb(255, 255, 255)
    Public ReadOnly 白色笔刷 As New SolidBrush(白色)

    Public ReadOnly 暗色 As Color = Color.FromArgb(40, 46, 34)
    Public ReadOnly 暗色笔 As New Pen(暗色, 线宽)
    Public ReadOnly 暗色笔刷 As New SolidBrush(暗色)

    Public ReadOnly 边缘白 As Color = Color.FromArgb(134, 145, 128)
    Public ReadOnly 边缘白笔 As New Pen(边缘白, 线宽)
    Public ReadOnly 边缘白笔刷 As New SolidBrush(边缘白)

    Public ReadOnly 黑边框 As New Pen(Color.Black, DPI * 2)
    Public ReadOnly 黑虚线边框 As New Pen(Color.Black, DPI * 2) With {.DashStyle = Drawing2D.DashStyle.Dot}

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

End Module
