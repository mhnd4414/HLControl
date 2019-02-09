Namespace HLControl
    <DefaultEvent("ValueChanged")>
    Public Class HLVScrollBar
        Inherits Control

        Private 按住上 As Boolean, 按住 As Boolean, 按住下 As Boolean, _value As Integer, _small As Integer, _max As Integer, _min As Integer

        Public Sub New()
            DoubleBuffered = True
            按住上 = False
            按住下 = False
            按住 = False
            _value = 0
            _small = 1
            _max = 100
            _min = 0
        End Sub

        Private Sub FixValue()
            If _max = _min Then
                _max += 1
            ElseIf _max < _min Then
                互换(_max, _min)
            End If
            If _value < _min Then
                _value = _min
            ElseIf _value > _max Then
                _value = _max
            End If
            If _small >= _max Then _small = _max - 1
            If _small <= _min Then _small = _min + 1
            Invalidate()
        End Sub

        <DefaultValue(100)>
        Public Property Maximum As Integer
            Get
                Return _max
            End Get
            Set(v As Integer)
                If v <> _max Then
                    _max = v
                    FixValue()
                End If
            End Set
        End Property

        <DefaultValue(0)>
        Public Property Minimum As Integer
            Get
                Return _min
            End Get
            Set(v As Integer)
                If v <> _min Then
                    _min = v
                    FixValue()
                End If
            End Set
        End Property

        <DefaultValue(0)>
        Public Property Value As Integer
            Get
                Return _value
            End Get
            Set(v As Integer)
                If v <> _value AndAlso v <= _max AndAlso v >= _min Then
                    _value = v
                    RaiseEvent ValueChanged()
                    FixValue()
                End If
            End Set
        End Property

        <DefaultValue(1)>
        Public Property SmallChange As Integer
            Get
                Return _small
            End Get
            Set(v As Integer)
                If v <> _small Then
                    _small = v
                    FixValue()
                End If
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

        Private Sub _MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
            If e.Delta > 0 Then
                Value -= _small
            Else
                Value += _small
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
                If Enabled Then
                    Dim v As Single = (Value - Minimum) / (Maximum - Minimum)
                    h = v * (h - h2 - 4 * DPI) + w1 + 1 * DPI
                    绘制基础矩形(g, New Rectangle(0, h, w1, h2))
                End If
            End With
        End Sub

    End Class

End Namespace

