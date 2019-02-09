Namespace 控件

    Public Class 计时器
        Implements IDisposable

        Private tm As System.Windows.Forms.Timer, t1 As EventHandler

        Public Sub New(间隔 As Integer, Optional 事件 As EventHandler = Nothing)
            tm = New Windows.Forms.Timer
            tm.Enabled = False
            Me.间隔 = 间隔
            If 非空(事件) Then
                t1 = 事件
                AddHandler tm.Tick, t1
            End If
        End Sub

        Public Sub Dispose() Implements IDisposable.Dispose
            tm.Dispose()
            t1 = Nothing
            Finalize()
        End Sub

        Public Property 间隔 As Integer
            Get
                Return tm.Interval
            End Get
            Set(v As Integer)
                tm.Interval = v
            End Set
        End Property

        Public Property 启用 As Boolean
            Get
                Return tm.Enabled
            End Get
            Set(v As Boolean)
                tm.Enabled = v
            End Set
        End Property

        Public Property 事件 As EventHandler
            Get
                Return t1
            End Get
            Set(v As EventHandler)
                Dim b As Boolean = tm.Enabled
                tm.Enabled = False
                RemoveHandler tm.Tick, t1
                t1 = v
                AddHandler tm.Tick, v
                If b Then tm.Enabled = True
            End Set
        End Property

    End Class

End Namespace
