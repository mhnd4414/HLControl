Namespace 基础

    ''' <summary>
    ''' 引用其他的DLL的函数，并封装好一些常用的用法
    ''' </summary>
    Public Module 引用

        <DllImport("user32.dll")>
        Public Function ReleaseCapture() As Boolean
        End Function

        <DllImport("user32.dll")>
        Public Function SendMessage(HWnd As IntPtr, Msg As Integer, WParam As Integer, IParam As Integer) As Boolean
        End Function

        ''' <summary>
        ''' 对窗口进行拖放，通常用于无边框的窗体，写在MouseDown事件里使用
        ''' </summary>
        Public Sub 拖动窗口(f As Form)
            If 为空(f) OrElse f.IsHandleCreated = False Then Exit Sub
            ReleaseCapture()
            SendMessage(f.Handle, &H112, &HF012, 0)
        End Sub

    End Module

End Namespace
