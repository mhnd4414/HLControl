''' <summary>
''' 和时间有关的模块
''' </summary>
Public Module 时间

    ''' <summary>
    ''' 把时间转换为 UNIX 时间，默认不包括毫秒（毫秒是伪造的）
    ''' </summary>
    Public Function 转时间戳(时间 As Date, Optional 包括毫秒 As Boolean = False) As ULong
        Dim n As ULong = DateDiff(DateInterval.Second, #1970-1-1 0:0:0#, 时间.ToUniversalTime)
        If 包括毫秒 Then
            Dim g As Single = Microsoft.VisualBasic.Timer
            n = (n + g - CLng(g)) * 1000
        End If
        Return n
    End Function

    ''' <summary>
    ''' 把当前时间转换为 UNIX 时间，精确到秒
    ''' </summary>
    Public Function 当前时间戳(Optional 包括毫秒 As Boolean = False) As ULong
        Return 转时间戳(Now, 包括毫秒)
    End Function

    ''' <summary>
    ''' 把时间戳变成 DateTime，只支持秒级别的时间戳
    ''' </summary>
    Public Function 时间戳转出(时间戳 As ULong) As Date
        Dim t As Date = #1970-1-1 00:00:00#
        If 时间戳 > 1000484608441 Then 时间戳 /= 1000
        Return t.AddSeconds(时间戳).ToLocalTime
    End Function

    ''' <summary>
    ''' 把秒数变成时间文字
    ''' </summary>
    Public Function 时间文字(秒数 As ULong) As String
        Select Case 秒数
            Case < 1
                Return "瞬间"
            Case < 100
                Return 秒数 & "秒"
            Case < 60 * 100
                Return Math.Round(秒数 / 60) & "分钟"
            Case < 60 * 60 * 50
                Return Math.Round(秒数 / 60 / 60) & "小时"
            Case < 60 * 60 * 24 * 80
                Return Math.Round(秒数 / 60 / 60 / 24) & "天"
            Case < 60 * 60 * 24 * 380
                Return Math.Round(秒数 / 60 / 60 / 24 / 30) & "个月"
            Case Else
                Return Math.Round(秒数 / 60 / 60 / 24 / 365) & "年"
        End Select
    End Function

End Module
