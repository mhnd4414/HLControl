Imports Microsoft.VisualBasic.ApplicationServices

Namespace My

    Partial Friend Class MyApplication

        Private 缓存文件夹保护文件 As Stream

        Private Sub MyApplication_Startup(sender As Object, e As StartupEventArgs) Handles Me.Startup
            Dim s As String = 本程序.路径.ToLower
            If 包含全部(s, "c:\users\", "local\temp") Then
                报错退出("请勿在压缩包内直接打开本软件！")
            End If
            删除文件(缓存文件夹)
            Directory.CreateDirectory(缓存文件夹)
            缓存文件夹保护文件 = File.OpenWrite(缓存文件夹 + "8ccccc.txt")
            Dim t As New 计时器(100, Sub()
                                      Dim a As Integer = 0
                                      For Each i As Form In My.Application.OpenForms
                                          If i.Visible Then
                                              a += 1
                                          End If
                                      Next
                                      If a < 1 Then
                                          MyApplication_Shutdown(Nothing, Nothing)
                                          本程序.退出()
                                      End If
                                  End Sub)
            t.启用 = True
        End Sub

        Private Sub MyApplication_Shutdown(sender As Object, e As EventArgs) Handles Me.Shutdown
            缓存文件夹保护文件.Close()
            配置.保存到本地()
            删除文件(缓存文件夹)
        End Sub

        Private Sub MyApplication_UnhandledException(sender As Object, e As UnhandledExceptionEventArgs) Handles Me.UnhandledException
            Dim s As String = e.Exception.Message + vbCrLf + e.Exception.StackTrace
            报错退出(s)
        End Sub

        Public Sub 报错退出(s As String)
            MessageBox.Show(s, "出错了！" + 标题)
            本程序.退出()
        End Sub

    End Class

End Namespace
