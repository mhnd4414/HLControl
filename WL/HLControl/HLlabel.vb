Namespace HLControl

    Public Class HLLabel
        Inherits Control

        Private 高亮 As Boolean, 黯淡 As Boolean, 文本 As String

        Public Sub New()
            DoubleBuffered = True
            高亮 = False
            黯淡 = False
        End Sub

        <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> <Localizable(True)>
        Public Overrides Property Text As String
            Get
                Return 文本
            End Get
            Set(v As String)
                If v <> 文本 Then
                    文本 = v
                    Invalidate()
                End If
            End Set
        End Property

        <DefaultValue(False)>
        Public Property HighLight As Boolean
            Get
                Return 高亮
            End Get
            Set(v As Boolean)
                高亮 = v
                Invalidate()
                If v Then 黯淡 = False
                If v = True AndAlso 非空(Parent) Then
                    For Each i As Control In Parent.Controls
                        If i.GetType = [GetType]() AndAlso i.Name <> Name Then
                            Dim c As HLLabel = i
                            c.HighLight = False
                        End If
                    Next
                End If
            End Set
        End Property

        <DefaultValue(False)>
        Public Property LowLight As Boolean
            Get
                Return 黯淡
            End Get
            Set(v As Boolean)
                If v Then 高亮 = False
                黯淡 = v
                Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            修正Dock(Me, False, False)
            Dim g As Graphics = e.Graphics
            With g
                If 文本.Length < 1 Then
                    .Clear(Color.Red)
                    Height = 10
                    Width = Height
                    Exit Sub
                End If
                Size = .MeasureString(文本, Font).ToSize
                绘制文本(g, 文本, Font, 0, 0, 获取文本状态(Enabled, HighLight, LowLight))
            End With
            MyBase.OnPaint(e)
        End Sub

    End Class

End Namespace