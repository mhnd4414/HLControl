Namespace HLControl

    <DefaultEvent("SelectedIndexChanged")>
    Public Class HLComboBox
        Inherits Control

        Private li As HLListBox, oheight As Integer

        Public Sub New()
            DoubleBuffered = True
            li = New HLListBox
            Controls.Add(li)
            With li
                .Visible = False
                .Top = 0
                .Width = 1
                .Left = 0
                .ShowScrollBar = True
                AddHandler .Click, Sub()
                                       HideListBox()
                                   End Sub
                AddHandler .SelectedIndexChanged, Sub()
                                                      RaiseEvent SelectedIndexChanged()
                                                  End Sub
            End With
        End Sub

        Public Property HighLightLabel As HLLabel

        Private Sub _MouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
            If Enabled AndAlso e.Y < oheight Then
                SelectedIndex += IFF(e.Delta < 0, 1, -1)
            End If
        End Sub

        Private Sub ShowListbox()
            If 为空(Parent) OrElse Visible = False OrElse li.Visible OrElse li.Items.Count < 1 Then Exit Sub
            With li
                Dim c As Integer = .Items.Count
                If c < 1 Then Exit Sub
                .Width = Width
                .Top = Height
                .Left = 0
                c = .FullHeight
                Dim h As Integer = Parent.Height - Bottom - 50 * DPI
                If c > h Then c = h
                h = 350 * DPI
                If c > h Then c = h
                .Height = c
                .Visible = True
                Height += .Height
                If 非空(HighLightLabel) Then
                    HighLightLabel.HighLight = True
                End If
                BringToFront()
            End With
            Invalidate()
        End Sub

        Private Sub HideListBox()
            With li
                If .Visible = False Then Exit Sub
                .Visible = False
                Height -= .Height
                If 非空(HighLightLabel) Then
                    HighLightLabel.HighLight = False
                End If
            End With
            Invalidate()
        End Sub

        Private Sub _MouseDown(sender As Object, e As MouseEventArgs) Handles Me.MouseDown
            If li.Visible = False Then
                ShowListbox()
            Else
                HideListBox()
            End If
        End Sub

        <Browsable(False)>
        Public ReadOnly Property Items As List(Of String)
            Get
                Return li.Items
            End Get
        End Property

        <Browsable(False)>
        Public Property SelectedIndex As Integer
            Get
                Return li.SelectedIndex
            End Get
            Set(v As Integer)
                If li.SelectedIndex <> v Then
                    li.SelectedIndex = v
                    Invalidate()
                End If
            End Set
        End Property

        <Browsable(False)>
        Public Property SelectedItem As String
            Get
                Return li.SelectedItem
            End Get
            Set(v As String)
                If li.SelectedItem <> v Then
                    li.SelectedItem = v
                    Invalidate()
                End If
            End Set
        End Property

        Public Event SelectedIndexChanged()

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
        End Sub

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            修正Dock(Me, True, False)
            MyBase.OnPaint(e)
            If Not li.Visible Then
                Height = Font.GetHeight + 6 * DPI
                oheight = Height
            End If
            If 非空(HighLightLabel) Then
                HighLightLabel.HighLight = li.Visible
            End If
            Dim g As Graphics = e.Graphics, c As Rectangle = ClientRectangle
            With g
                绘制基础矩形(g, c, True)
                Dim m As Single = oheight * 0.15
                .DrawString("▼", New Font("Segoe UI", 0.4 * oheight), 内容白笔刷, 点F(Width - oheight + m, m))
                m = 3 * DPI
                绘制文本(g, li.SelectedItem, Font, m, m, 获取文本状态(Enabled))
            End With
        End Sub

    End Class

End Namespace
