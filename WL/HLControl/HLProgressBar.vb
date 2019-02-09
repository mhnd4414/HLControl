Namespace HLControl

    <DefaultEvent("ValueChanged")>
    Public Class HLProgressBar
        Inherits Control

        Public Sub New()
            DoubleBuffered = True
        End Sub

        Private Sub _TextChanged() Handles Me.TextChanged
            If 包含(Text, vbCr, vbLf) Then Text = 替换(Text, vbCrLf, " ", vbLf, " ", vbCr, " ")
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.TextChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
        End Sub

        Private _value As Single

        <DefaultValue(0)>
        Public Property Value As Single
            Get
                Return _value
            End Get
            Set(v As Single)
                If v > 1 Then
                    v = 1
                ElseIf v < 0 Then
                    v = 0
                End If
                If v = _value Then Exit Property
                _value = v
                RaiseEvent ValueChanged()
                If _value > 0.9999 Then
                    RaiseEvent Overflowed()
                    If AutoReset Then _value = 0
                End If
                Invalidate()
            End Set
        End Property

        <DefaultValue(False)>
        Public Property AutoReset As Boolean

        Public Event ValueChanged()
        Public Event Overflowed()

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim h As Integer = 30 * DPI, w As Integer = 12 * DPI, x As Integer = 6 * DPI
            If (Width - x) Mod w <> 0 Then
                Width = w * Int(Width / w) + x
            End If
            If Height < h Then Height = h
            With e.Graphics
                绘制基础矩形(e.Graphics, ClientRectangle, True, False, True)
                h = Height - 12 * DPI
                w = 8 * DPI
                Dim all As Integer = Int((Width) / (w + 4 * DPI) + 0.5)
                Dim n As Integer = Int(Value * all - 0.5)
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