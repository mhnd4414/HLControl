''' <summary>
''' 文件信息处理模块
''' </summary>
Public Module 文件

    ''' <summary>
    ''' 把路径进行标准化处理，最后带一个\
    ''' </summary>
    Public Function 路径标准化(路径 As String) As String
        If 路径.Length > 2 Then
            路径 = 文本标准化(路径).Trim
            Dim f As String = "\"
            路径 = 替换(路径, "/", f)
            If Not 尾(路径, f) Then 路径 += f
        End If
        Return 路径
    End Function

    ''' <summary>
    ''' 返回文本当中的小写盘符
    ''' </summary>
    Public Function 盘符(文件 As String) As String
        If 文件.Length > 2 Then Return 去除(Regex.Match(文件.ToLower, "[a-z]*?:").ToString, ":")
        Return ""
    End Function

    ''' <summary>
    ''' 如果是文件夹就返回上层路径，如果是文件就返回路径
    ''' </summary>
    Public Function 路径(文件 As String) As String
        If 文件.Length > 2 Then
            If 文件.EndsWith("\") Then 文件 = 去右(文件, 1)
            Return 路径标准化(Regex.Match(文件, "(\S|\s)+\\").ToString)
        End If
        Return ""
    End Function

    ''' <summary>
    ''' 如果是文件夹就返回文件夹名，如果是文件就返回文件名，默认包括后缀
    ''' </summary>
    Public Function 文件名(文件 As String, Optional 包含后缀 As Boolean = True) As String
        If 文件.Length > 2 Then
            If 文件.EndsWith("\") Then 文件 = 去右(文件, 1)
            文件 = 去除(文件, 路径(文件)).Trim
            If 包含后缀 = False AndAlso 文件.Length > 0 Then
                文件 = Regex.Match(文件, ".*?\.").ToString
                If 文件.EndsWith(".") Then 文件 = 去右(文件, 1)
            End If
            Return 文件
        End If
        Return ""
    End Function

    ''' <summary>
    ''' 返回文件的小写后缀，包括第一个点
    ''' </summary>
    Public Function 文件后缀(文件 As String) As String
        If 文件.Length > 2 Then
            If 文件.EndsWith("\") Then 文件 = 去右(文件, 1)
            文件 = 去除(文件, 路径(文件)).Trim
            If 文件.Length > 2 Then Return Regex.Match(去除(文件, 路径(文件)).Trim, "\.[\S]+").ToString.ToLower
        End If
        Return ""
    End Function

    ''' <summary>
    ''' 检查这个文件是否存在 
    ''' </summary>
    Public Function 文件存在(文件 As String) As Boolean
        If 文件.Length < 3 Then Return False
        Return File.Exists(文件)
    End Function

    ''' <summary>
    ''' 检查这个文件夹是否存在 
    ''' </summary>
    Public Function 文件夹存在(文件夹 As String) As Boolean
        If 文件夹.Length < 3 Then Return False
        Return Directory.Exists(文件夹)
    End Function

    ''' <summary>
    ''' 返回这个文件的大小，单位为Byte，如果文件不存在则返回0
    ''' </summary>
    Public Function 文件大小Byte(文件 As String) As UInteger
        If 文件存在(文件) Then Return FileLen(文件)
        Return 0
    End Function

    ''' <summary>
    ''' 返回这个文件的大小，单位为KB，如果文件不存在则返回0
    ''' </summary>
    Public Function 文件大小KB(文件 As String) As Single
        Return 文件大小Byte(文件) / 1024
    End Function

    ''' <summary>
    ''' 返回这个文件的大小，单位为MB，如果文件不存在则返回0
    ''' </summary>
    Public Function 文件大小MB(文件 As String) As Single
        Return 文件大小Byte(文件) / 1024 / 1024
    End Function

    ''' <summary>
    ''' 读取文件的内容为字节数组，如果无法读取，则返回nothing
    ''' </summary>
    Public Function 读文件为字节数组(文件 As String) As Byte()
        If 文件存在(文件) Then
            Dim b() As Byte = Nothing
            If 尝试(Sub()
                      Dim s As Stream = File.OpenRead(文件), c As Integer = s.Length - 1
                      ReDim b(c)
                      For i As Integer = 0 To c
                          b(i) = s.ReadByte
                      Next
                      s.Close()
                  End Sub) Then
                Return b
            End If
        End If
        Return Nothing
    End Function

    ''' <summary>
    ''' 读取文件的内容为字符串，并且会进行标准化处理
    ''' </summary>
    Public Function 读文件为文本(文件 As String, Optional 编码 As Encoding = Nothing) As String
        Dim b() As Byte = 读文件为字节数组(文件)
        If IsNothing(b) Then Return ""
        Return 字节数组转文本(b, 编码)
    End Function

    ''' <summary>
    ''' 删除文件或文件夹，返回删除是否成功，如果不存在也算删除成功
    ''' </summary>
    Public Function 删除文件(文件 As String) As Boolean
        尝试(Sub()
               If 文件存在(文件) Then File.Delete(文件)
               If 文件夹存在(文件) Then Directory.Delete(文件, True)
           End Sub)
        Return 文件存在(文件) = False AndAlso 文件夹存在(文件) = False
    End Function

    ''' <summary>
    ''' 把文件复制到目的地，返回是否复制成功
    ''' </summary>
    Public Function 复制文件(文件 As String, 目的文件 As String) As Boolean
        If 文件存在(文件) AndAlso 创建文件夹(路径(目的文件)) Then
            If 文件存在(目的文件) = False OrElse 删除文件(目的文件) Then
                If 尝试(Sub()
                          File.Copy(文件, 目的文件, True)
                      End Sub) Then
                    Return 文件大小Byte(目的文件) = 文件大小Byte(文件)
                End If
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' 尝试创建文件夹，返回文件夹是否已经成功存在
    ''' </summary>
    Public Function 创建文件夹(路径 As String) As Boolean
        If 文件夹存在(路径) Then Return True
        Dim ok As Boolean = False
        If Not 尝试(Sub()
                      Directory.CreateDirectory(路径)
                  End Sub) Then
            Return False
        Else
            Return 文件夹存在(路径)
        End If
    End Function

    ''' <summary>
    ''' 删除文件，然后重新写入对应的字节数组，返回是否写入成功
    ''' </summary>
    Public Function 写字节数组到文件(文件 As String, 字节数组() As Byte) As Boolean
        If 删除文件(文件) AndAlso 创建文件夹(路径(文件)) Then
            Dim ok As Boolean = False
            If 尝试(Sub()
                      Dim s As Stream = File.OpenWrite(文件)
                      Dim c As Integer = 字节数组.Length
                      s.Write(字节数组, 0, c)
                      s.Close()
                      ok = 文件大小Byte(文件) = c
                  End Sub) Then
                Return ok
            End If
        End If
        Return False
    End Function

    ''' <summary>
    ''' 删除文件，然后重新写入对应的文本，返回是否写入成功
    ''' </summary>
    Public Function 写文本到文件(文件 As String, 文本 As String, Optional 编码 As Encoding = Nothing) As Boolean
        Return 写字节数组到文件(文件, 文本转字节数组(文本, 编码))
    End Function

End Module
