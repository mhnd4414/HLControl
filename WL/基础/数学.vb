Namespace 基础

    ''' <summary>
    ''' 数学相关的模块
    ''' </summary>
    Public Module 数学

        ''' <summary>
        ''' 判断这个数字是否为整数
        ''' </summary>
        Public Function 是整数(数字 As Object) As Boolean
            If Not 是数字(数字.GetType) Then Return False
            Return 数字 = Fix(数字)
        End Function

        ''' <summary>
        ''' 判断这个数字是否为小数
        ''' </summary>
        Public Function 是小数(数字 As Object) As Boolean
            Return Not 是整数(数字)
        End Function

        ''' <summary>
        ''' 判断这个数字是否为偶整数
        ''' </summary>
        Public Function 是偶数(数字 As Object) As Boolean
            Return 是整数(数字 / 2)
        End Function

        ''' <summary>
        ''' 判断这个数字是否为奇整数
        ''' </summary>
        Public Function 是奇数(数字 As Object) As Boolean
            Return Not 是偶数(数字)
        End Function

        ''' <summary>
        ''' 随机生成一些物品的类
        ''' </summary>
        Public NotInheritable Class 随机

            ''' <summary>
            ''' 随机获得一个0到0.9999之间的小数
            ''' </summary>
            Public Shared Function 小数() As Single
                Randomize()
                Return Rnd()
            End Function

            ''' <summary>
            ''' 随机获得True或False
            ''' </summary>
            Public Shared Function 真假() As Boolean
                Return 小数() < 0.5
            End Function

            ''' <summary>
            ''' 获得指定范围内的一个整数
            ''' </summary>
            Public Shared Function 整数(A As Integer, B As Integer) As Integer
                If A = B Then Return A
                If B > A Then 互换(A, B)
                Return Int((A - B + 1) * 小数()) + B
            End Function

            ''' <summary>
            ''' 获得列表当中的随机一个物品
            ''' </summary>
            Public Shared Function 当中一个(ParamArray 列表() As Object) As Object
                If 列表.Length < 1 Then Return Nothing
                Return 列表(整数(0, 列表.Length - 1))
            End Function

            ''' <summary>
            ''' 随机获得文本当中的指定个数个字符，可能会重复，默认为1个
            ''' </summary>
            Public Shared Function 当中字符(文本 As String, Optional 个数 As UInteger = 1) As String
                Dim n As Integer = 文本.Length - 1, s As String = ""
                If n >= 0 AndAlso 个数 > 0 Then
                    For i As Integer = 1 To 个数
                        s += 文本.Chars(整数(0, n)).ToString
                    Next
                End If
                Return s
            End Function

            ''' <summary>
            ''' 返回指定个数阿拉伯数字组成的字符串
            ''' </summary>
            Public Shared Function 阿拉伯数字(Optional 个数 As UInteger = 1) As String
                Return 当中字符(字符串常量.阿拉伯数字, 个数)
            End Function

            ''' <summary>
            ''' 返回指定个数阿拉伯数字、小写英文字母、大写英文字母组成的字符串
            ''' </summary>
            Public Shared Function 西文(Optional 个数 As UInteger = 1) As String
                Return 当中字符(字符串常量.阿拉伯数字 + 字符串常量.小写英文字母 + 字符串常量.大写英文字母, 个数)
            End Function

            ''' <summary>
            ''' 返回指定个数小写英文字母、大写英文字母组成的字符串
            ''' </summary>
            Public Shared Function 英文字母(Optional 个数 As UInteger = 1) As String
                Return 当中字符(字符串常量.小写英文字母 + 字符串常量.大写英文字母, 个数)
            End Function

            ''' <summary>
            ''' 返回指定个数小写英文字母组成的字符串
            ''' </summary>
            Public Shared Function 小写英文字母(Optional 个数 As UInteger = 1) As String
                Return 当中字符(字符串常量.小写英文字母, 个数)
            End Function

            ''' <summary>
            ''' 返回指定个数大写英文字母组成的字符串
            ''' </summary>
            Public Shared Function 大写英文字母(Optional 个数 As UInteger = 1) As String
                Return 当中字符(字符串常量.大写英文字母, 个数)
            End Function

        End Class

    End Module

End Namespace