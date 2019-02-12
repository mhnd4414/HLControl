Namespace 基础

    ''' <summary>
    ''' 引用其他的DLL的函数，并封装好一些常用的用法
    ''' </summary>
    Public Module 引用

        Public Const WM_SYSCOMMAND = &H112
        Public Const EM_SCROLL = &HB5
        Public Const EM_LINESCROLL = &HB6
        Public Const EM_SCROLLCARET = &HB7
        Public Const EM_GETLINECOUNT = &HBA

        <DllImport("user32.dll")>
        Public Function ReleaseCapture() As Boolean
        End Function

        <DllImport("user32.dll")>
        Public Function SendMessage(HWnd As IntPtr, Msg As Integer, WParam As Integer, IParam As Integer) As Integer
        End Function

        ''' <summary>
        ''' 对窗口进行拖放，通常用于无边框的窗体，写在MouseDown事件里使用
        ''' </summary>
        Public Sub 拖动窗口(f As Form)
            If 为空(f) Then Exit Sub
            Try
                ReleaseCapture()
                SendMessage(f.Handle, &H112, &HF012, 0)
            Catch ex As Exception
                出错(ex)
            End Try
        End Sub

        ''' <summary>
        ''' 对控件发送滚动信号
        ''' </summary>
        Public Sub 滚动(控件 As Control, 垂直 As Boolean, 数量 As Integer)
            If 为空(控件) Then Exit Sub
            Dim m As Integer = 0, n As Integer = 0
            If 垂直 Then
                m = 数量
            Else
                n = 数量
            End If
            Try
                SendMessage(控件.Handle, EM_LINESCROLL, n, m)
            Catch ex As Exception
                出错(ex)
            End Try
        End Sub

    End Module

End Namespace
