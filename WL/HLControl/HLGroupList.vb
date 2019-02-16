Namespace HLControl

    Public Class HLGroupList
        Inherits Control

        Private 滚动条 As HLVScrollBar, 物品 As List(Of HLGroup), 最高栏 As Integer, 行高 As Integer, 选中 As Integer
        Private 边缘 As Single

        Public Sub New()
            DoubleBuffered = True
            物品 = New List(Of HLGroup)
            滚动条 = New HLVScrollBar
            最高栏 = 0
            选中 = -1
            With 滚动条
                .Width = 25 * DPI
                .Height = Height
                .Top = 0
                .Left = 0
            End With
            Controls.Add(滚动条)
            AddHandler 滚动条.ValueChanged, Sub()
                                             最高栏 = 滚动条.Value
                                             Invalidate()
                                         End Sub
            行高 = Font.GetHeight + 3 * DPI
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.FontChanged, Me.EnabledChanged
            Invalidate()
        End Sub

        Public Sub PerformMouseWheel(sender As Object, e As MouseEventArgs) Handles Me.MouseWheel
            滚动条.PerformMouseWheel(sender, e)
        End Sub

        <DefaultValue(1)>
        Public Property SmallChange As Integer
            Get
                Return 滚动条.SmallChange
            End Get
            Set(v As Integer)
                滚动条.SmallChange = v
            End Set
        End Property

        Public Event SelectedIndexChanged(sender As HLGroupList, e As HLValueEventArgs)

        <Browsable(False)>
        Public ReadOnly Property Groups As List(Of HLGroup)
            Get
                Return 物品
            End Get
        End Property

    End Class

    Public Class HLGroup

        Public Sub New(title As String, ParamArray str() As String)
            Me.Title = title
            Items = New List(Of HLGroupItem)
            Items.AddRange(str)
        End Sub

        Public Property Title As String

        Public Property Items As List(Of HLGroupItem)

    End Class

    Public Class HLGroupItem

        Public Sub New(title As String, Optional ico As Icon = Nothing)
            Me.Title = title
            Me.Ico = ico
        End Sub

        Public Property Title As String

        Public Property Ico As Icon

        Public ReadOnly Property HasIco As Boolean
            Get
                Return 非空(Ico)
            End Get
        End Property

        Public Shared Widening Operator CType(m As String) As HLGroupItem
            Return New HLGroupItem(m)
        End Operator

        Public Shared Widening Operator CType(m As HLGroupItem) As String
            Return m.Title
        End Operator

    End Class

End Namespace
