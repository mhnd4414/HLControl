Namespace HLControl
    <DefaultEvent("ValueChanged")>
    Public Class HLVScrollBar
        Inherits Control

        Private 按住上 As Boolean, 按住 As Boolean, 按住下 As Boolean, 值 As Integer, 滚动一次 As Integer, 最大 As Integer, 最小 As Integer

        Public Sub New()
            DoubleBuffered = True
            按住上 = False
            按住下 = False
            按住 = False
            值 = 0
            滚动一次 = 1
            最大 = 100
            最小 = 0
        End Sub

        Private Sub FixValue()
            If 最大 = 最小 Then
                最大 += 1
            ElseIf 最大 < 最小 Then
                互换(最大, 最小)
            End If
            If 值 < 最小 Then
                值 = 最小
            ElseIf 值 > 最大 Then
                值 = 最大
            End If
            If 滚动一次 >= 最大 Then 滚动一次 = 最大 - 1
            If 滚动一次 <= 最小 Then 滚动一次 = 最小 + 1
            Invalidate()
        End Sub

        <DefaultValue(100)>
        Public Property Maximum As Integer
            Get
                Return 最大
            End Get
            Set(v As Integer)
                If v <> 最大 Then
                    最大 = v
                    FixValue()
                End If
            End Set
        End Property

        <DefaultValue(0)>
        Public Property Minimum As Integer
            Get
                Return 最小
            End Get
            Set(v As Integer)
                If v <> 最小 Then
                    最小 = v
                    FixValue()
                End If
            End Set
        End Property

        <DefaultValue(0)>
        Public Property Value As Integer
            Get
                Return 值
            End Get
            Set(v As Integer)
                If v <> 值 AndAlso v <= 最大 AndAlso v >= 最小 Then
                    值 = v
                    FixValue()
                    RaiseEvent ValueChanged()
                End If
            End Set
        End Property

        <DefaultValue(1)>
        Public Property SmallChange As Integer
            Get
                Return 滚动一次
            End Get
            Set(v As Integer)
                If v <> 滚动一次 Then
                    滚动一次 = v
                    FixValue()
                End If
            End Set
        End Property

        Public Event ValueChanged()

        Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            Dim y As Integer = e.Y, h As Integer = Width
            If y <= h Then
                按住上 = True
                Value -= 滚动一次
            ElseIf y >= Height - h Then
                按住下 = True
                Value += 滚动一次
            End If
        End Sub

        Private Sub _MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
            If e.Delta > 0 Then
                Value -= 滚动一次
            Else
                Value += 滚动一次
            End If
        End Sub

        Public Sub PerformMouseWheel(sender As Object, e As MouseEventArgs)
            If Enabled Then _MouseWheel(sender, e)
        End Sub

        Private Sub _MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If e.Button <> MouseButtons.None AndAlso 按住上 = False AndAlso 按住下 = False Then
                Dim y As Integer = e.Y, h As Integer = Width
                If 按住 = False AndAlso y > h AndAlso y < Height - h Then
                    按住 = True
                End If
                If 按住 Then Value = (y - h) / (Height - 2 * h) * (Maximum - Minimum) + Minimum
            End If
        End Sub

        Private Sub _MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            If 按住 OrElse 按住上 OrElse 按住下 Then
                按住上 = False
                按住 = False
                按住下 = False
                Invalidate()
            End If
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            修正Dock(Me, False, True)
            设最小值(Height, 50 * DPI)
            设最小值(Width, 10 * DPI)
            设最大值(Width, Height / 5)
            MyBase.OnPaint(e)
            Dim g As Graphics = e.Graphics, w1 As Integer = Width, w2 As Integer = Width * 0.15
            Dim h As Integer = Height - 2 * w1, h2 As Integer = 2.2 * w1
            With g
                绘制基础矩形(g, New Rectangle(0, 0, w1, w1), 按住上, False)
                绘制基础矩形(g, New Rectangle(0, Height - w1, w1, w1), 按住下, False)
                Dim f As New Font("Segoe UI", 0.4 * Width)
                绘制文本(g, "▲", f, w2, w2, 获取文本状态(Enabled))
                绘制文本(g, "▼", f, w2, Height - w1 + w2, 获取文本状态(Enabled))
                .FillRectangle(滚动绿笔刷, New Rectangle(0, w1, w1, h))
                If Enabled Then
                    Dim v As Single = (Value - Minimum) / (Maximum - Minimum)
                    h = v * (h - h2 - 4 * DPI) + w1 + 1 * DPI
                    绘制基础矩形(g, New Rectangle(0, h, w1, h2))
                End If
            End With
        End Sub

    End Class

End Namespace

