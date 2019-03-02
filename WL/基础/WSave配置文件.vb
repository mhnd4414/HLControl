Namespace 基础

    ''' <summary>
    ''' WSave配置文件的模块
    ''' </summary>
    Public Module WSave配置文件

        ''' <summary>
        ''' WSave配置文件
        ''' </summary>
        Public Class WSave

            Private En As 走過去加密
            Private Di As Dictionary(Of String, String)

            ''' <summary>
            ''' 本地文件的位置，通常为 .wsave 后缀
            ''' </summary>
            Public Property 本地文件 As String

            ''' <summary>
            ''' 新建一个WSave配置文件类
            ''' </summary>
            Public Sub New(Optional 本地文件 As String = "")
                En = New 走過去加密("戈登走過去只是个平凡的人")
                Di = New Dictionary(Of String, String)
                If 本地文件.Length > 4 Then
                    Me.本地文件 = 本地文件
                    从文件读取()
                End If
            End Sub

            ''' <summary>
            ''' 清空，并从本地读取文件
            ''' </summary>
            Public Sub 从文件读取()
                Di.Clear()
                If 文件大小Byte(本地文件) > 5 Then
                    Try
                        Dim m As New StreamReader(File.OpenRead(本地文件))
                        m.ReadLine()
                        Dim s1 As String, s2 As String
                        Do While True
                            s1 = En.解密为字符串(m.ReadLine).Trim.ToLower
                            If m.EndOfStream Then Exit Do
                            s2 = En.解密为字符串(m.ReadLine)
                            If 非空全部(s1, s2) Then
                                If Not Di.ContainsKey(s1) Then
                                    Di.Add(s1, s2)
                                End If
                            End If
                            If m.EndOfStream Then Exit Do
                        Loop
                        m.Dispose()
                    Catch ex As Exception
                        出错(ex)
                    End Try
                End If
            End Sub

            ''' <summary>
            ''' 保存内容到本地文件
            ''' </summary>
            Public Sub 保存到本地()
                If 删除文件(本地文件) Then
                    Try
                        Dim m As New StreamWriter(File.OpenWrite(本地文件))
                        m.WriteLine("戈登走過去的配置文件，请勿乱修改。 " + 本程序.文件名 + ".exe")
                        For Each i As String In Di.Keys
                            Dim s1 As String = Di.Item(i)
                            If 非空全部(i, s1) Then
                                m.WriteLine(En.加密(i))
                                m.WriteLine(En.加密(s1))
                            End If
                        Next
                        m.Dispose()
                    Catch ex As Exception
                        出错(ex)
                    End Try
                End If
            End Sub

            ''' <summary>
            ''' 从配置文件里读取或写入字符串
            ''' </summary>
            Public Property 字符串(名字 As String) As String
                Get
                    名字 = 名字.ToLower.Trim
                    If 名字.Length > 0 AndAlso Di.ContainsKey(名字) Then Return Di.Item(名字)
                    Return ""
                End Get
                Set(值 As String)
                    If 名字.Length < 1 Then Exit Property
                    名字 = 名字.ToLower.Trim
                    If Di.ContainsKey(名字) Then
                        Di.Remove(名字)
                    End If
                    If 值.Length > 0 Then
                        Di.Add(名字, 值)
                    End If
                End Set
            End Property

            ''' <summary>
            ''' 从配置文件里读取或写入数字
            ''' </summary>
            Public Property 数字(名字 As String) As Double
                Get
                    Return Val(字符串(名字))
                End Get
                Set(值 As Double)
                    If 值 <> 0 Then
                        字符串(名字) = 值.ToString
                    Else
                        字符串(名字) = ""
                    End If
                End Set
            End Property

            ''' <summary>
            ''' 从配置文件里读取或写入真假
            ''' </summary>
            Public Property 真假(名字 As String) As Boolean
                Get
                    Return 字符串(名字).Length = 1
                End Get
                Set(值 As Boolean)
                    字符串(名字) = IIf(值, "T", "")
                End Set
            End Property

            ''' <summary>
            ''' 从配置文件里读取或写入日期
            ''' </summary>
            Public Property 日期(名字 As String) As Date
                Get
                    Dim s As String = 字符串(名字)
                    Try
                        Dim m As List(Of String) = 分割(s, "_")
                        If m.Count = 6 Then
                            Return New Date(Val(m(0)), Val(m(1)), Val(m(2)), Val(m(3)), Val(m(4)), Val(m(5)))
                        End If
                    Catch ex As Exception
                        出错(ex, s)
                    End Try
                    Return #2000-01-01 00:00:00#
                End Get
                Set(值 As Date)
                    字符串(名字) = 时间格式化(值, "Y_M_D_h_m_s")
                End Set
            End Property

        End Class

    End Module

End Namespace
