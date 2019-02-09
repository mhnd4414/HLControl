Namespace HLControl
    <DefaultEvent("ValueChanged")>
    Public Class HLVScrollBar
        Inherits Control

        Private 按住上 As Boolean, 按住 As Boolean, 按住下 As Boolean, _value As Single, _small As Single

        Public Sub New()
            DoubleBuffered = True
            按住上 = False
            按住下 = False
            按住 = False
            _value = 0
            _small = 0.02
        End Sub

        <DefaultValue(0)>
        Public Property Value As Single
            Get
                Return _value
            End Get
            Set(v As Single)
                If v > 0.99 Then v = 1
                If v < 0.01 Then v = 0
                If v <> _value Then
                    _value = v
                    RaiseEvent ValueChanged()
                    Invalidate()
                End If
            End Set
        End Property

        <DefaultValue(0.02)>
        Public Property SmallChange As Single
            Get
                Return _small
            End Get
            Set(v As Single)
                If v > 0.99 Then v = 0.99
                If v < 0.01 Then v = 0.01
                _small = v
            End Set
        End Property

        Public Event ValueChanged()

        Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            Dim y As Integer = e.Y, h As Integer = Width
            If y <= h Then
                按住上 = True
                Value -= _small
            ElseIf y >= Height - h Then
                按住下 = True
                Value += _small
            End If
        End Sub

        Private Sub _MouseMove(sender As Object, e As MouseEventArgs) Handles Me.MouseMove
            If e.Button <> MouseButtons.None AndAlso 按住上 = False AndAlso 按住下 = False Then
                Dim y As Integer = e.Y, h As Integer = Width
                If y > h AndAlso y < Height - h Then
                    按住 = True
                    Value = (y - h) / (Height - 2 * h)
                End If
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
            If Height < 50 Then
                Height = 50
            End If
            If Width < 10 Then
                Width = 10
            ElseIf Width > Height / 5 Then
                Width = Height / 5
            End If
            MyBase.OnPaint(e)
            Dim g As Graphics = e.Graphics, w1 As Integer = Width, w2 As Integer = Width * 0.15
            Dim h As Integer = Height - 2 * w1, h2 As Integer = 2.2 * w1
            With g
                绘制基础矩形(g, New Rectangle(0, 0, w1, w1), 按住上, False, False)
                绘制基础矩形(g, New Rectangle(0, Height - w1, w1, w1), 按住下, False, False)
                .DrawString("▲", New Font("Segoe UI", 0.4 * Width), 内容白笔刷, 点F(w2, w2))
                .DrawString("▼", New Font("Segoe UI", 0.4 * Width), 内容白笔刷, 点F(w2, Height - w1 + w2))
                .FillRectangle(滚动绿笔刷, New Rectangle(0, w1, w1, h))
                h = _value * (h - h2 - 3 * DPI) + w1 + 3 * DPI
                绘制基础矩形(g, New Rectangle(0, h, w1, h2))
            End With
        End Sub

    End Class

End Namespace

