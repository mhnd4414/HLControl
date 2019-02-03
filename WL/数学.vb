''' <summary>
''' 数学运算的模块
''' </summary>
Public Module 数学

    ''' <summary>
    ''' 比较两个东西之间是否相等的办法
    ''' </summary>
    Public Enum 比较方法

        ''' <summary>
        ''' 直接使用 = 来比较
        ''' </summary>
        等于

        ''' <summary>
        ''' 只比较两个对象的 HashCode 是否相等
        ''' </summary>
        HashCode

        ''' <summary>
        ''' 只比较对象的 Tostring 是否相等
        ''' </summary>
        Tostring

        ''' <summary>
        ''' 使用 Equals 来比较
        ''' </summary>
        Equals

        ''' <summary>
        ''' 只比较两个对象的 Type 是否相等
        ''' </summary>
        Type

        ''' <summary>
        ''' 使用 Is 关键字来比较，判断两个对象是否引用自同一对象
        ''' </summary>
        [Is]

    End Enum

    ''' <summary>
    ''' 用指定的比较方法来比较A和B两个对象是否相等，如果比较出错，只返回 A.Equals(B)
    ''' </summary>
    Public Function 比较(A As Object, B As Object, 方法 As 比较方法) As Boolean
        If IsNothing(A) OrElse IsNothing(B) Then
            Return IsNothing(A) AndAlso IsNothing(B)
        End If
        Dim ok As Boolean
        If 尝试(Sub()
                  Select Case 方法
                      Case 比较方法.等于
                          ok = A = B
                      Case 比较方法.Tostring
                          ok = A.ToString = B.ToString
                      Case 比较方法.Is
                          ok = A Is B
                      Case 比较方法.Type
                          ok = A.GetType = B.GetType
                      Case 比较方法.HashCode
                          ok = A.GetHashCode = B.GetHashCode
                  End Select
              End Sub) Then
            Return ok
        Else
            Return A.Equals(B)
        End If
    End Function

    ''' <summary>
    ''' 用指定的办法来判断这个物品是否在列表内
    ''' </summary>
    ''' <returns></returns>
    Public Function 在列表(列表 As IList, 物品 As Object, 比较方法 As 比较方法) As Boolean
        If Not (IsNothing(列表) OrElse 列表.Count < 1 OrElse IsNothing(物品)) Then
            For Each i As Object In 列表
                If 比较(i, 物品, 比较方法) Then Return True
            Next
        End If
        Return False
    End Function

    ''' <summary>
    ''' 针对list进行去重
    ''' </summary>
    Public Sub 列表去重(列表 As IList, 比较方法 As 比较方法)
        If Not (IsNothing(列表) OrElse 列表.Count < 1) Then
            Dim m As New List(Of Object), i As Object
            For Each i In 列表
                If IsNothing(i) = False AndAlso 在列表(m, i, 比较方法) = False Then m.Add(i)
            Next
            列表.Clear()
            For Each i In m
                列表.Add(i)
            Next
        End If
    End Sub

    ''' <summary>
    ''' 对提供的字符串内容数组进行两两分组，""会被读入，nothing或者多出的单个不会被处理，返回一个字符串字典
    ''' </summary>
    Public Function 两两分组(ParamArray 内容() As String) As Dictionary(Of String, String)
        Dim c As Integer = 内容.Length - 1, d As New Dictionary(Of String, String)
        If c > 0 Then
            If 是偶数(c) Then c -= 1
            Dim i As Integer, a As String, b As String
            For i = 0 To c Step 2
                a = 内容(i)
                b = 内容(i + 1)
                If IsNothing(a) = False AndAlso IsNothing(b) = False Then
                    d.Add(a, b)
                End If
            Next
        End If
        Return d
    End Function

    ''' <summary>
    ''' 判断这个变量是否是数字相关的类型
    ''' </summary>
    Public Function 是数字类型(变量 As Object) As Boolean
        If IsNothing(变量) Then Return False
        Dim m As New List(Of Type) From {
            GetType(Byte),
            GetType(Integer),
            GetType(UInteger),
            GetType(Long),
            GetType(ULong),
            GetType(Single),
            GetType(Double),
            GetType(Short),
            GetType(UShort),
            GetType(Decimal)
        }
        Return m.Contains(变量.GetType)
    End Function

    ''' <summary>
    ''' 判断这个数字是否为整数
    ''' </summary>
    Public Function 是整数(数字 As Object) As Boolean
        Return 数字 = CLng(数字)
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
        Return 是小数(数字 / 2)
    End Function

    ''' <summary>
    ''' 判断寻找的对象是否是内容当中的一个
    ''' </summary>
    Public Function 是当中一个(寻找 As Object, ParamArray 内容() As Object) As Boolean
        If IsNothing(寻找) Then Return False
        For Each i As Object In 内容
            If 比较(i, 寻找, 比较方法.等于) Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' 判断寻找的对象是否是内容当中的一个，并使用对应的比较办法
    ''' </summary>
    Public Function 是当中一个(比较办法 As 比较方法, 寻找 As Object, ParamArray 内容() As Object) As Boolean
        If IsNothing(寻找) Then Return False
        For Each i As Object In 内容
            If 比较(i, 寻找, 比较办法) Then Return True
        Next
        Return False
    End Function

    ''' <summary>
    ''' 互换AB两个对象
    ''' </summary>
    Public Sub 互换(ByRef A As Object, ByRef B As Object)
        Dim C As Object = B
        B = A
        A = C
    End Sub

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

    End Class

End Module
