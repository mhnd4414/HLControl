Namespace 基础

    ''' <summary>
    ''' 关于控件的一些计算
    ''' </summary>
    Public Module 控件

        ''' <summary>
        ''' 返回一个文本框不滚动可以显示的行数
        ''' </summary>
        Public Function 文本框可见行数(T As Object) As Integer
            If 为空(T) OrElse T.TextLength < 1 Then Return 0
            If Not 包含(T.Text, vbCr, vbLf) Then Return 1
            With T
                Dim h As Integer = T.Height
                Dim h2 As Integer = T.Font.GetHeight
                h = Fix(h / h2)
                Return h
            End With
        End Function

        ''' <summary>
        ''' 把文本框滚动到指定的行数为显示可见范围内
        ''' </summary>
        Public Sub 滚动文本框(T As Object, 行数 As UInteger)
            If 为空(T) OrElse 包含(T.Text, vbCr, vbLf) = False Then Exit Sub
            With T
                Dim l As Integer = .Lines.Length, se As Integer = 文本框可见行数(T)
                If l < se Then Exit Sub
                Dim st As Integer = .SelectionStart, sl As Integer = .SelectionLength, g As Integer = 0
                If 行数 >= l - se Then
                    g = .TextLength
                Else
                    If .TextLength < 2000 Then
                        .Select(.TextLength, 0)
                        .ScrollToCaret()
                    End If
                    For i As Integer = 0 To 行数 - 2
                        g += .Lines(i).Length + 2
                    Next
                End If
                .Select(g, 0)
                .ScrollToCaret()
                .Select(st, sl)
            End With
        End Sub

    End Module

End Namespace
