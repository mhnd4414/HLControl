Namespace HLControl

    <DefaultEvent("ValueChanged")>
    Public Class HLProgressBar
        Inherits Control

        Private _value As Integer, _max As Integer, _min As Integer

        Public Sub New()
            DoubleBuffered = True
            _max = 100
            _min = 0
            _value = 0
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.TextChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
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
            If _value = _max Then
                If AutoReset Then _value = 0
            End If
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

        <DefaultValue(False)>
        Public Property AutoReset As Boolean

        Public Event ValueChanged()

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim h As Integer = 30 * DPI, w As Integer = 12 * DPI, x As Integer = 6 * DPI
            If (Width - x) Mod w <> 0 Then
                Width = w * Int(Width / w) + x
            End If
            If Height < h Then Height = h
            With e.Graphics
                绘制基础矩形(e.Graphics, ClientRectangle, True, False, True)
                If Value = Minimum Then Exit Sub
                h = Height - 12 * DPI
                w = 8 * DPI
                Dim all As Integer = Int((Width) / (w + 4 * DPI) + 0.5)
                Dim v As Single = (Value - Minimum) / (Maximum - Minimum)
                Dim n As Integer = Int(v * all - 0.5)
                x = 4 * DPI
                If n > 0 Then
                    For i As Integer = 1 To n
                        .FillRectangle(内容黄笔刷, x, 5 * DPI, w, h)
                        x += w + 4 * DPI
                    Next
                End If
            End With
        End Sub

    End Class

End Namespace