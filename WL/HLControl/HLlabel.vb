Namespace HLControl

    Public Class HLLabel
        Inherits Control

        Private lb As Label, br As Boolean, dark As Boolean

        Public Sub New()
            DoubleBuffered = True
            lb = New Label
            br = False
            dark = False
            Controls.Add(lb)
            With lb
                .Left = 0
                .Top = 0
                .Height = 1
                .Width = 1
                .Text = Text
                AddHandler lb.AutoSizeChanged, Sub()
                                                   Size = .Size
                                               End Sub
                AddHandler lb.Click, Sub()
                                         MyBase.OnClick(Nothing)
                                     End Sub
                .AutoSize = True
            End With
        End Sub

        Private Sub FixText() Handles Me.FontChanged
            With lb
                .Text = Text
                .Font = Font
            End With
            Invalidate()
        End Sub

        <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> <Localizable(True)>
        Public Overrides Property Text As String
            Get
                Return lb.Text
            End Get
            Set(value As String)
                lb.Text = value
                FixText()
                MyBase.OnTextChanged(Nothing)
            End Set
        End Property

        <DefaultValue(False)>
        Public Property HighLight As Boolean
            Get
                Return br
            End Get
            Set(v As Boolean)
                br = v
                If dark = False AndAlso 非空(Parent) Then
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
            MyBase.OnPaint(e)
            Size = lb.Size
            With e.Graphics
                Dim c As Color = 内容白
                If LowLight Then
                    c = 淡色
                ElseIf HighLight Then
                    c = 内容黄
                End If
                lb.ForeColor = c
            End With
        End Sub

    End Class

End Namespace