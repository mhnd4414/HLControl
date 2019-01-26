''' <summary>
''' 文本处理模块
''' </summary>
Public Module 文本

    ''' <summary>
    ''' 对文本进行标准化处理，包括修正CRLF，把多余的控制符替换为空格，把tab换成4个空格
    ''' </summary>
    Public Function 文本标准化(ByRef 文本 As String) As String
        If 文本 Is Nothing Then
            文本 = ""
        Else
            If 文本.Length > 0 Then
                If 文本.IsNormalized = False Then 文本 = 文本.Normalize
                If 包含(文本, vbCr, vbLf) Then 文本 = 替换(文本, vbCrLf, vbLf, vbCr, vbLf, vbLf, vbCrLf)
                If 包含(文本, vbTab) Then 文本 = 替换(文本, vbTab, "    ")
                Dim i As Integer
                For i = 0 To 31
                    If i <> 10 AndAlso i <> 13 Then
                        文本 = 替换(文本, ChrW(i), " ")
                    End If
                Next
            End If
        End If
        Return 文本
    End Function

    ''' <summary>
    ''' 检查文本内是否包含要寻找的内容的当中一项
    ''' </summary>
    Public Function 包含(文本 As String, ParamArray 内容() As String) As Boolean
        If 文本.Length < 1 Then Return False
        For Each i As String In 内容
            If i.Length > 0 AndAlso 文本.Contains(i) Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' 检查文本内是否包含要寻找的内容的每一项
    ''' </summary>
    Public Function 包含全部(文本 As String, ParamArray 内容() As String) As Boolean
        If 文本.Length < 1 Then Return False
        For Each i As String In 内容
            If i.Length > 0 AndAlso 文本.Contains(i) = False Then Return False
        Next
        Return True
    End Function

    ''' <summary>
    ''' 一一对应替换掉文本中的相关内容
    ''' </summary>
    Public Function 替换(文本 As String, ParamArray 内容() As String) As String
        Dim c As Integer = 内容.Length - 1
        If c > 0 Then
            If 是偶数(c) Then c -= 1
            For i As Integer = 0 To c Step 2
                If 内容(i).Length > 0 Then 文本 = 文本.Replace(内容(i), 内容(i + 1))
                If 文本.Length < 1 Then Exit For
            Next
        End If
        Return 文本
    End Function

    ''' <summary>
    ''' 返回文本左边指定长度的字符串
    ''' </summary>
    Public Function 左(文本 As String, 长度 As UInteger) As String
        If 文本.Length < 1 OrElse 长度 < 1 Then Return ""
        Return Left(文本, 长度)
    End Function

    ''' <summary>
    ''' 返回文本右边指定长度的字符串
    ''' </summary>
    Public Function 右(文本 As String, 长度 As UInteger) As String
        If 文本.Length < 1 OrElse 长度 < 1 Then Return ""
        Return Right(文本, 长度)
    End Function

    ''' <summary>
    ''' 返回文本去掉右边指定长度的字符串
    ''' </summary>
    Public Function 去右(文本 As String, 长度 As UInteger) As String
        If 文本.Length < 1 OrElse 长度 >= 文本.Length Then Return ""
        Return 左(文本, 文本.Length - 长度)
    End Function

    ''' <summary>
    ''' 返回文本去掉左边指定长度的字符串
    ''' </summary>
    Public Function 去左(文本 As String, 长度 As UInteger) As String
        If 文本.Length < 1 OrElse 长度 >= 文本.Length Then Return ""
        Return 右(文本, 文本.Length - 长度)
    End Function

    ''' <summary>
    ''' 检查文本是否以相关内容开头
    ''' </summary>
    Public Function 头(文本 As String, ParamArray 内容() As String) As Boolean
        If 文本.Length < 1 Then Return False
        For Each i As String In 内容
            If i.Length > 0 AndAlso 文本.StartsWith(i) Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' 检查文本是否以相关内容结尾
    ''' </summary>
    Public Function 尾(文本 As String, ParamArray 内容() As String) As Boolean
        If 文本.Length < 1 Then Return False
        For Each i As String In 内容
            If i.Length > 0 AndAlso 文本.EndsWith(i) Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' 从前向后寻找，提取需要寻找的全部字符串之后的文本，如果不存在要寻找的就返回空字符串
    ''' </summary>
    Public Function 提取之后(文本 As String, ParamArray 寻找() As String) As String
        If 文本.Length < 1 OrElse 寻找.Length < 1 Then Return ""
        Dim g As Integer
        For Each i As String In 寻找
            If i.Length > 0 Then
                g = InStr(文本, i)
                If g < 1 Then Return ""
                文本 = 文本.Substring(g + i.Length - 1)
            Else
                Return ""
            End If
        Next
        Return 文本
    End Function

    ''' <summary>
    ''' 从后向前寻找，提取需要寻找的全部字符串之前的文本，如果不存在要寻找的就返回空字符串
    ''' </summary>
    Public Function 提取之前(文本 As String, ParamArray 寻找() As String) As String
        If 文本.Length < 1 OrElse 寻找.Length < 1 Then Return ""
        Dim g As Integer
        For Each i As String In 寻找
            If i.Length > 0 Then
                g = InStrRev(文本, i)
                If g < 1 Then Return ""
                文本 = Left(文本, g - 1)
            Else
                Return ""
            End If
        Next
        Return 文本
    End Function

    ''' <summary>
    ''' 从前向后寻找，第一次找到要寻找的字符串之后提取之前的部分
    ''' </summary>
    Public Function 提取最之前(文本 As String, 寻找 As String) As String
        If 文本.Length < 1 OrElse 寻找.Length < 1 Then Return ""
        Dim g As Integer = InStr(文本, 寻找)
        If g < 1 Then Return ""
        Return Left(文本, g - 1)
    End Function

    ''' <summary>
    ''' 从后向前寻找，第一次找到要寻找的字符串之后提取之后的部分
    ''' </summary>
    Public Function 提取最之后(文本 As String, 寻找 As String) As String
        If 文本.Length < 1 OrElse 寻找.Length < 1 Then Return ""
        Dim g As Integer = InStrRev(文本, 寻找)
        If g < 1 Then Return ""
        Return 文本.Substring(g + 寻找.Length - 1)
    End Function

    ''' <summary>
    ''' 提取文本当中指定开头和结尾之间的文字，开头是第一次出现的那个开头，结尾是开头之后出现的第一次结尾
    ''' </summary>
    Public Function 提取之间(文本 As String, 开头 As String, 结尾 As String) As String
        If 文本.Length < 1 OrElse 开头.Length < 1 OrElse 结尾.Length < 1 Then Return ""
        Return 提取最之前(提取之后(文本, 开头), 结尾)
    End Function

    ''' <summary>
    ''' 从文本中去除对应的内容
    ''' </summary>
    Public Function 去除(文本 As String, ParamArray 内容() As String) As String
        For Each i As String In 内容
            If 包含(文本, i) Then 文本 = 文本.Replace(i, "")
        Next
        Return 文本
    End Function

    ''' <summary>
    ''' 没有 BOM 标识的 UTF-8 编码
    ''' </summary>
    ''' <returns></returns>
    Public Function 无BOM的UTF8编码() As Encoding
        Static m As New UTF8Encoding(False)
        Return m
    End Function

    ''' <summary>
    ''' 把文本转为字节数组
    ''' </summary>
    Public Function 文本转字节数组(文本 As String, Optional 编码 As Encoding = Nothing) As Byte()
        If 文本.Length < 1 Then Return Nothing
        If IsNothing(编码) Then 编码 = 无BOM的UTF8编码()
        Return 编码.GetBytes(文本)
    End Function

    ''' <summary>
    ''' 把字节数组转为文本，并且会进行标准化处理
    ''' </summary>
    Public Function 字节数组转文本(字节数组 As Byte(), Optional 编码 As Encoding = Nothing) As String
        If IsNothing(字节数组) OrElse 字节数组.Length < 1 Then Return ""
        If IsNothing(编码) Then 编码 = 无BOM的UTF8编码()
        Dim g As Integer
        For i As Integer = 0 To 字节数组.Length - 1
            g = 字节数组(i)
            If g < 31 Then
                If g <> 9 AndAlso g <> 10 AndAlso g <> 13 Then
                    g = 32
                End If
            End If
        Next
        Return 文本标准化(编码.GetString(字节数组))
    End Function

    ''' <summary>
    ''' 如果文本里存在连续2个及以上个数的内容，就替换成只有一个
    ''' </summary>
    Public Function 去连续重复(文本 As String, ParamArray 内容() As String) As String
        Dim m As String
        For Each i As String In 内容
            m = i + i
            Do While 包含(文本, m)
                文本 = 替换(文本, m, i)
            Loop
        Next
        Return 文本
    End Function

    ''' <summary>
    ''' 把文本进行分割并生成列表，如果不包含间隔字符串，就返回本体，不保留中间的零长度内容，且默认自动trim每一项内容
    ''' </summary>
    Public Function 分割(文本 As String, 间隔 As String, Optional trim内容 As Boolean = True) As List(Of String)
        Dim g As New List(Of String)
        If 包含(文本, 间隔) = False Then
            g.Add(文本)
        Else
            文本 = 去连续重复(文本)
            Dim a As Integer = 间隔.Length, t As String
            If 头(文本, 间隔) Then 文本 = 去左(文本, a)
            If Not 尾(文本, 间隔) Then 文本 += 间隔
            Do While 文本.Length > 0
                t = 提取最之前(文本, 间隔)
                文本 = 去左(文本, t.Length + a)
                If trim内容 Then t = Trim(t)
                If t.Length > 0 Then g.Add(t)
            Loop
        End If
        Return g
    End Function

    ''' <summary>
    ''' 提取文字中的数字
    ''' </summary>
    Public Function 仅数字(文本 As String) As String
        If 文本.Length < 1 Then Return ""
        Dim t As String = ""
        For Each m As Match In Regex.Matches(文本, "[0-9]*")
            t += m.ToString
        Next
        Return t
    End Function

    ''' <summary>
    ''' 提取文字中的字母，大小写不限
    ''' </summary>
    Public Function 仅字母(文本 As String) As String
        If 文本.Length < 1 Then Return ""
        Dim t As String = ""
        For Each m As Match In Regex.Matches(文本, "([A-Z]|[a-z])")
            t += m.ToString
        Next
        Return t
    End Function

    ''' <summary>
    ''' 提取文字中的大写字母
    ''' </summary>
    Public Function 仅大写字母(文本 As String) As String
        If 文本.Length < 1 Then Return ""
        Dim t As String = ""
        For Each m As Match In Regex.Matches(文本, "[A-Z]")
            t += m.ToString
        Next
        Return t
    End Function

    ''' <summary>
    ''' 提取文字中的小写字母
    ''' </summary>
    Public Function 仅小写字母(文本 As String) As String
        If 文本.Length < 1 Then Return ""
        Dim t As String = ""
        For Each m As Match In Regex.Matches(文本, "[a-z]")
            t += m.ToString
        Next
        Return t
    End Function

    ''' <summary>
    ''' 把文本变成 "文本"
    ''' </summary>
    Public Function 引(文本 As String) As String
        Return 引号 + 文本 + 引号
    End Function

    ''' <summary>
    ''' 把字典的每一项的名字和值tostring都转成一行，连接符默认是:，然后拼在一起
    ''' </summary>
    Public Function 字典转文本(字典 As IDictionary, Optional 连接符 As String = ":") As String
        Dim s As String = ""
        If 字典.Count > 0 Then
            For Each i As Object In 字典.Keys
                If IsNothing(i) = False AndAlso IsNothing(字典.Item(i)) = False Then
                    s += i.ToString + 连接符 + 字典.Item(i).ToString + vbCrLf
                End If
            Next
        End If
        Return 去右(s, 2)
    End Function

    ''' <summary>
    ''' 把列表的每一项的tostring都转成一行，然后拼在一起
    ''' </summary>
    Public Function 列表转文本(列表 As IList) As String
        Dim s As String = ""
        If 列表.Count > 0 Then
            For Each i As Object In 列表
                If IsNothing(i) = False Then s += i.ToString + vbCrLf
            Next
        End If
        Return 去右(s, 2)
    End Function

    ''' <summary>
    ''' 对字符串进行URLencode
    ''' </summary>
    Public Function URL编码(文本 As String) As String
        If 文本.Length < 1 Then Return ""
        Return HttpUtility.UrlEncode(文本)
    End Function

    ''' <summary>
    ''' 对字符串进行URLdncode
    ''' </summary>
    Public Function URL解码(URL文本 As String) As String
        If URL文本.Length < 1 Then Return ""
        Return HttpUtility.UrlDecode(URL文本)
    End Function

    ''' <summary>
    ''' 对转义后的文本进行反转义
    ''' </summary>
    Public Function 反转义(文本 As String) As String
        If 文本.Length < 3 Then Return 文本
        Dim t As String = 文本, i As String
        t = 替换(t, "\r\n", vbCrLf, "\r", vbCr, "\n", vbLf, "\/", "/", "\t", "    ")
        For Each m As Match In Regex.Matches(t, "\\u([0-9]|[a-f]){4}")
            i = m.ToString
            t = 替换(t, i, ChrW(Convert.ToInt32(右(i, 4), 16)))
        Next
        Return 文本标准化(t)
    End Function

    ''' <summary>
    ''' Base64加密解密类
    ''' </summary>
    Public NotInheritable Class Base64

        Protected Sub New()
        End Sub

        ''' <summary>
        ''' 对字节数组进行加密
        ''' </summary>
        Public Shared Function 加密字节数组(字节数组() As Byte) As String
            If IsNothing(字节数组) OrElse 字节数组.Length < 1 Then Return ""
            Return Convert.ToBase64String(字节数组)
        End Function

        ''' <summary>
        ''' 对字符串进行加密
        ''' </summary>
        Public Shared Function 加密文本(文本 As String, Optional 编码 As Encoding = Nothing) As String
            Return 加密字节数组(文本转字节数组(文本, 编码))
        End Function

        ''' <summary>
        ''' 对Base64字符串进行解密，解密到字节数组
        ''' </summary>
        Public Shared Function 解密字节数组(B64 As String) As Byte()
            Dim b() As Byte = Nothing
            If B64.Length > 0 AndAlso 尝试(Sub()
                                             b = Convert.FromBase64String(B64)
                                         End Sub) Then
                Return b
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' 对Base64字符串进行解密，解密到字符串
        ''' </summary>
        Public Shared Function 解密文本(B64 As String, Optional 编码 As Encoding = Nothing) As String
            Return 字节数组转文本(解密字节数组(B64), 编码)
        End Function

    End Class

End Module
