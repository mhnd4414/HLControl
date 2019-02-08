Public Class 控件
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

End Class
