Namespace HLControl

    <DefaultEvent("ValueChanged")>
    Public Class HLProgressBar
        Inherits Control

        Private 值 As Integer, 最大 As Integer, 最小 As Integer

        Public Sub New()
            DoubleBuffered = True
            最大 = 100
            最小 = 0
            值 = 0
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.TextChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
        End Sub

        Private Sub FixValue()
            If 过频(GetHashCode, 0.04) Then Exit Sub
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
            If 值 = 最大 Then
                If AutoReset Then 值 = 0
            End If
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
            设最小值(Height, h)
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