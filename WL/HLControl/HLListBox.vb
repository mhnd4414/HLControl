Namespace HLControl

    Public Class HLListBox
        Inherits Control

        Private sr As HLVScrollBar, it As List(Of String), tp As Integer, fh As Integer, fc As Integer

        Public Sub New()
            DoubleBuffered = True
            it = New List(Of String)
            sr = New HLVScrollBar
            tp = 0
            fc = -1
            With sr
                .Width = 25 * DPI
                .Height = Height
                .Top = 0
                .Left = 0
            End With
            Controls.Add(sr)
            AddHandler sr.ValueChanged, Sub()
                                            tp = sr.Value
                                            Invalidate()
                                        End Sub
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.FontChanged, Me.EnabledChanged
            fh = Font.GetHeight + 3 * DPI
            Invalidate()
        End Sub

        <Browsable(False)>
        Public ReadOnly Property Items As List(Of String)
            Get
                Invalidate()
                Return it
            End Get
        End Property

        Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If ShowScrollBar = False OrElse e.X < sr.Left Then
                Dim h As Integer = e.Y - 4 * DPI
                h = Int(h / fh) + tp
                fc = IFF(h < it.Count, h, -1)
                Invalidate()
            End If
        End Sub

        Private Sub _MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
            sr.PerformMouseWheel(sender, e)
        End Sub

        Private Sub _PreviewKeyDown(sender As Object, e As PreviewKeyDownEventArgs) Handles Me.PreviewKeyDown
            Select Case e.KeyCode
                Case Keys.Up
                    SelectedIndex -= 1
                Case Keys.Down
                    SelectedIndex += 1
            End Select
        End Sub

        <Browsable(False)>
        Public Property SelectedIndex As Integer
            Get
                Return fc
            End Get
            Set(v As Integer)
                If v < 0 Then v = -1
                If v >= it.Count Then
                    v = -1
                End If
                If fc <> v Then
                    fc = v
                    sr.Value = v
                    Invalidate()
                End If
            End Set
        End Property

        <Browsable(False)>
        Public Property SelectedItem As String
            Get
                If fc > -1 Then
                    Return it.Item(fc)
                End If
                Return ""
            End Get
            Set(v As String)
                If fc > -1 AndAlso it.Item(fc) <> v Then
                    it.Item(fc) = v
                    Invalidate()
                End If
            End Set
        End Property

        <DefaultValue(True)>
        Public Property ShowScrollBar As Boolean
            Get
                Return sr.Visible
            End Get
            Set(v As Boolean)
                If sr.Visible <> v Then
                    sr.Visible = v
                    Invalidate()
                End If
            End Set
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            If Width < 30 Then Width = 30
            If Height < 50 Then Height = 50
            Dim shown As Integer = Int((Height - 4 * DPI) / fh - 0.5)
            Dim f As Integer = it.Count - shown, y As Integer
            With sr
                .Left = Width - .Width
                .Height = Height
                .Enabled = f > 0
            End With
            Dim g As Graphics = e.Graphics, c As Rectangle = ClientRectangle
            With g
                绘制基础矩形(g, c)
                If f < 1 Then f = 1
                sr.Maximum = f
                y = 4 * DPI
                For i As Integer = tp To tp + shown
                    If it.Count <= i Then Exit For
                    If fc = i Then
                        .FillRectangle(块黄笔刷, New Rectangle(0, y, Width, fh))
                    End If
                    .DrawString(it(i), Font, IFF(fc = i, 白色笔刷, 淡色笔刷), 点F(4 * DPI, y))
                    y += fh
                Next
            End With
        End Sub

    End Class

End Namespace
