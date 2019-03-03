Friend Module 公共成员

    Public ReadOnly 版本 As New Version(1, 0)
    Public ReadOnly 标题 As String = "走過去的全家桶 v" + 版本.ToString
    Public ReadOnly 图标 As Icon = My.Resources.主图标
    Public ReadOnly 配置 As New WSave(本程序.路径 + "wbin.wsave")
    Public ReadOnly 缓存文件夹 As String = 本程序.路径 + "wbin_temp\"

End Module
