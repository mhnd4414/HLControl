''' <summary>
''' Walkedby's Config 走過去的配置文件模块
''' </summary>
Public Module WBC模块

    ''' <summary>
    ''' WBC文件类
    ''' </summary>
    Public Class WBC

        Private m As Dictionary(Of String, String)
        Private Const head As String = "这是戈登走過去的配置文件，请不要乱修改"

        ''' <summary>
        ''' 新建一个空白的WBC文件
        ''' </summary>
        Public Sub New(Optional 本地文件 As String = "")
            m = New Dictionary(Of String, String)
            Me.本地文件 = 本地文件
        End Sub

        ''' <summary>
        ''' 读取或保存的时候用的本地文件，后缀必须是.wbc
        ''' </summary>
        Public Property 本地文件 As String

        ''' <summary>
        ''' 清空内部，从本地文件进行读取
        ''' </summary>
        Public Sub 从本地读取()
            m.Clear()
            If 文件后缀(本地文件) <> ".wbc" OrElse 文件存在(本地文件) = False Then Exit Sub
            Dim s As String = 读文件为文本(本地文件)
            If 头(s, head) Then
                s = 替换(s, head, "", vbCrLf, " ")
                Dim l As List(Of String) = 分割(s, " ")
                Dim c As Integer = l.Count - 1
                If c > 0 Then
                    If 是偶数(c) Then c -= 1
                    For i As Integer = 0 To c Step 2
                        字符串(Base64.解密文本(l(i))) = Base64.解密文本(l(i + 1))
                    Next
                End If
            End If
        End Sub

        ''' <summary>
        ''' 保存WBC文件的内容到本地
        ''' </summary>
        Public Sub 保存到本地()
            If 文件后缀(本地文件) <> ".wbc" Then Exit Sub
            Dim n As String = head, m1 As String, m2 As String
            Dim g As New List(Of String), i As String
            For Each i In m.Keys
                g.Add(i)
            Next
            For Each i In g
                m1 = Base64.加密文本(i)
                m2 = Base64.加密文本(GetV(i))
                If m1.Length > 0 AndAlso m2.Length > 0 Then
                    n += m1 + " " + m2 + " "
                End If
            Next
            写文本到文件(本地文件, n)
        End Sub

        Private Function GenName(ParamArray 名字() As String) As String
            Dim s As String = "", i As String
            For Each i In 名字
                If i.Length > 0 Then s += 去除(i, "=") + "="
            Next
            Return 去右(s.ToLower, 1)
        End Function

        Private Function GetV(名字 As String) As String
            If 名字.Length < 1 OrElse m.ContainsKey(名字) = False Then Return ""
            Return 文本标准化(m.Item(名字))
        End Function

        ''' <summary>
        ''' 根据名字（不分大小写）读取或保存值，返回的是字符串，如果不存在就返回""
        ''' </summary>
        Private Property 字符串(ParamArray 名字() As String) As String
            Get
                Return GetV(GenName(名字))
            End Get
            Set(值 As String)
                Dim s As String = GenName(名字)
                If s.Length > 0 Then
                    If m.ContainsKey(s) Then m.Remove(s)
                    值 = 文本标准化(值)
                    If 值.Length > 0 Then
                        m.Add(s, 值)
                    End If
                End If
            End Set
        End Property

        ''' <summary>
        ''' 根据名字（不分大小写）读取或保存值，返回的是 Double，如果不存在就返回0
        ''' </summary>
        Public Property 数字(ParamArray 名字() As String) As Double
            Get
                Return Val(字符串(名字))
            End Get
            Set(值 As Double)
                字符串(名字) = 值.ToString
            End Set
        End Property

        ''' <summary>
        ''' 根据名字（不分大小写）读取或保存值，返回的是 Boolean，如果不存在就返回False
        ''' </summary>
        Public Property 真假(ParamArray 名字() As String) As Boolean
            Get
                Return 字符串(名字).Length = 1
            End Get
            Set(值 As Boolean)
                字符串(名字) = IIf(值, "t", "")
            End Set
        End Property

        ''' <summary>
        ''' 根据名字（不分大小写）读取或保存值，返回的是 Date，如果不存在就返回#1970-01-01 00:00:00#
        ''' </summary>
        Public Property 时间(ParamArray 名字() As String) As Date
            Get
                Return 时间戳转出(Val(字符串(名字)))
            End Get
            Set(值 As Date)
                字符串(名字) = 转时间戳(值, False)
            End Set
        End Property

        ''' <summary>
        ''' 预览存储的全部内容
        ''' </summary>
        Public Overrides Function ToString() As String
            Return Me.GetType.ToString + vbCrLf + 本地文件 + vbCrLf + 字典转文本(m)
        End Function

    End Class

End Module
