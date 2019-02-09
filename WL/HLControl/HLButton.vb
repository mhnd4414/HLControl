﻿Namespace HLControl

    Public Class HLButton
        Inherits Control

        Private 激活 As Boolean, 按住 As Boolean

        Public Sub New()
            DoubleBuffered = True
            激活 = False
            按住 = False
        End Sub

        Private Sub _TextChanged() Handles Me.TextChanged
            If 包含(Text, vbCr, vbLf) Then Text = 替换(Text, vbCrLf, " ", vbLf, " ", vbCr, " ")
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.TextChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
        End Sub

        Private Sub _KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
            If e.KeyCode = Keys.Enter Then
                MyBase.OnClick(Nothing)
            End If
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

        Private Sub _MouseUp() Handles Me.MouseUp
            按住 = False
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            Height = 10 * DPI + Font.GetHeight
            MyBase.OnPaint(e)
            With e.Graphics
                绘制基础矩形(e.Graphics, ClientRectangle, 按住, 激活)
                .DrawString(Text, Font, IFF(Enabled, 白色笔刷, 暗色笔刷), New PointF(6 * DPI, 4 * DPI))
            End With
        End Sub

    End Class

End Namespace