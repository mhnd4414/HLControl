Namespace HLControl

    <DefaultEvent("Load")> <Designer("System.Windows.Forms.Design.FormDocumentDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(System.ComponentModel.Design.IRootDesigner))> <DesignerCategory("Form")> <DesignTimeVisible(False)> <InitializationEvent("Load")> <ToolboxItem(False)> <ToolboxItemFilter("System.Windows.Forms.Control.TopLevel")>
    Public Class HLForm
        Inherits Form

        Private 关闭按钮区域 As Rectangle, 最小化按钮区域 As Rectangle
        Private LastX As Integer = -1, LastY As Integer = -1

        Public Sub New()
            DoubleBuffered = True
            _SetDefault()
            Font = New Font("Microsoft Yahei", 12)
        End Sub

        <Browsable(False)>
        Public Overrides Property BackColor As Color

        <Browsable(False)>
        Public Overrides Property AutoScroll As Boolean

        <Browsable(False)>
        Public Overrides Property AutoSize As Boolean

        Private Sub _SetDefault()
            MinimumSize = New Size(80, 80)
            AutoScaleMode = AutoScaleMode.None
            FormBorderStyle = FormBorderStyle.None
            StartPosition = FormStartPosition.CenterScreen
            MaximizeBox = False
        End Sub

        Private Sub _Load(sender As Object, e As EventArgs) Handles Me.Load
            _SetDefault()
            Dim d As Single = DPI
            If d > 1 Then
                Height *= d
                Width *= d
                For Each i As Control In Controls
                    SetDPI(i)
                Next
                Left = (系统信息.屏幕分辨率.Width - Width) * 0.5
                Top = (系统信息.屏幕分辨率.Height - Height) * 0.5
            End If
        End Sub

        Private Sub _MouseUp(sender As Object, e As MouseEventArgs) Handles Me.MouseUp
            If 关闭按钮区域.Contains(e.Location) Then
                Close()
            ElseIf 最小化按钮区域.Contains(e.Location) Then
                WindowState = FormWindowState.Minimized
            End If
            LastX = -1
            LastY = -1
        End Sub

        Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If e.Y < 最小化按钮区域.Bottom AndAlso e.X < 最小化按钮区域.X Then
                拖动窗口(Me)
            End If
        End Sub

        Private Sub SetDPI(c As Control)
            Dim d As Single = DPI
            With c
                .Left *= d
                .Top *= d
                .Height *= d
                .Width *= d
                If 是HL控件(c) = False AndAlso c.HasChildren Then
                    For Each i As Control In c.Controls
                        SetDPI(i)
                    Next
                End If
            End With
        End Sub

        Protected Overrides ReadOnly Property CreateParams As CreateParams
            Get
                Dim cp As CreateParams = MyBase.CreateParams
                cp.Style = &H20000
                Return cp
            End Get
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            Dim g As Graphics = e.Graphics
            With g
                绘制基础矩形(g, ClientRectangle)
                Dim w As Integer = 25 * DPI, p As Integer = 8 * DPI, y As Integer
                Dim r As New Rectangle(Width - p - w, p * 1.5, w, w)
                关闭按钮区域 = r
                绘制基础矩形(g, r)
                y = 7 * DPI
                .DrawLine(白色笔, 左上角(r, y), 右下角(r, y))
                .DrawLine(白色笔, 左下角(r, y), 右上角(r, y))
                r.X -= w + p
                最小化按钮区域 = r
                绘制基础矩形(g, r)
                y = r.Y + w * 0.5
                .DrawLine(白色笔, 点(r.X + w * 0.3, y), 点(r.X + w * 0.7, y))
                绘制文本(g, Text, Font, 27 * DPI, 12 * DPI, 获取文本状态(Enabled))
            End With
        End Sub

    End Class

End Namespace
