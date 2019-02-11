Namespace HLControl

    Public Class HLPanel
        Inherits Panel

        Private 边缘 As UInteger

        Public Sub New()
            DoubleBuffered = True
            边缘 = 线宽
            Border = True
        End Sub

        <DefaultValue(True)>
        Public Property Border As Boolean

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.TextChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            MyBase.OnPaint(e)
            AutoScroll = False
            AutoSize = False
            BorderStyle = BorderStyle.None
            Padding = New Padding(边缘)
            BackColor = 基础绿
            For Each i As Control In Controls
                设最小值(i.Top, 边缘)
                设最小值(i.Left, 边缘)
                Dim m As Integer = Height - 边缘
                If i.Bottom > m Then i.Height -= 边缘
                m = Width - 边缘
                If i.Right > m Then i.Width -= 边缘
            Next
            Dim g As Graphics = e.Graphics, c As Rectangle = ClientRectangle
            With g
                c.Height -= 边缘
                c.Width -= 边缘
                If Border Then 绘制基础矩形(g, c,,, 基础绿)
            End With
        End Sub

    End Class

End Namespace

