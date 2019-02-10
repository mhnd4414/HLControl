Namespace HLControl

    Public Class HLLabel
        Inherits Control

        Private br As Boolean, dark As Boolean, txt As String

        Public Sub New()
            DoubleBuffered = True
            br = False
            dark = False
        End Sub

        <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> <Localizable(True)>
        Public Overrides Property Text As String
            Get
                Return txt
            End Get
            Set(v As String)
                If v <> txt Then
                    txt = v
                    Invalidate()
                End If
            End Set
        End Property

        <DefaultValue(False)>
        Public Property HighLight As Boolean
            Get
                Return br
            End Get
            Set(v As Boolean)
                br = v
                dark = False
                If 非空(Parent) Then
                    For Each i As Control In Parent.Controls
                        If i.GetType = [GetType]() AndAlso i.Name <> Name Then
                            Dim c As HLLabel = i
                            c.br = False
                            c.Invalidate()
                        End If
                    Next
                End If
                Invalidate()
            End Set
        End Property

        <DefaultValue(False)>
        Public Property LowLight As Boolean
            Get
                Return dark
            End Get
            Set(v As Boolean)
                br = False
                dark = v
                Invalidate()
            End Set
        End Property

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            修正Dock(Me, False, False)
            Dim g As Graphics = e.Graphics
            With g
                If txt.Length < 1 Then
                    .Clear(Color.Red)
                    Height = 5
                    Width = 5
                    Exit Sub
                End If
                Size = .MeasureString(txt, Font).ToSize
                绘制文本(g, txt, Font, 0, 0, 获取文本状态(Enabled, HighLight, LowLight))
            End With
            MyBase.OnPaint(e)
        End Sub

    End Class

End Namespace