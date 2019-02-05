''' <summary>
''' 和电脑系统相关操作的模块
''' </summary>
Public Module 系统


    ''' <summary>
    ''' 从剪贴板内获得字符串或图片
    ''' </summary>
    Public NotInheritable Class 剪贴板

        Protected Sub New()
        End Sub

        ''' <summary>
        ''' 清空剪贴板的内容
        ''' </summary>
        Public Shared Sub 清空()
            尝试(Sub()
                   My.Computer.Clipboard.Clear()
               End Sub)
        End Sub

        ''' <summary>
        ''' 获取或设置剪贴板的字符串
        ''' </summary>
        Public Shared Property 文本 As String
            Get
                Dim s As String = ""
                尝试(Sub()
                       If My.Computer.Clipboard.ContainsText Then s = My.Computer.Clipboard.GetText
                   End Sub)
                Return s
            End Get
            Set(内容 As String)
                If IsNothing(内容) OrElse 内容.Length < 1 Then
                    清空()
                    Exit Property
                End If
                尝试(Sub()
                       My.Computer.Clipboard.SetText(内容)
                   End Sub)
            End Set
        End Property

        ''' <summary>
        ''' 获取或设置剪贴板的图片
        ''' </summary>
        Public Shared Property 图片 As Image
            Get
                Dim g As Image = Nothing
                尝试(Sub()
                       If My.Computer.Clipboard.ContainsImage Then g = My.Computer.Clipboard.GetImage
                   End Sub)
                Return g
            End Get
            Set(内容 As Image)
                If IsNothing(内容) Then
                    清空()
                    Exit Property
                End If
                尝试(Sub()
                       My.Computer.Clipboard.SetImage(内容)
                   End Sub)
            End Set
        End Property

        ''' <summary>
        ''' 获取剪贴板里存储的 Windows Explorer 的复制文件列表
        ''' </summary>
        Public Shared ReadOnly Property 文件列表 As List(Of String)
            Get
                Dim g As New List(Of String)
                尝试(Sub()
                       If My.Computer.Clipboard.ContainsFileDropList Then
                           For Each i As String In My.Computer.Clipboard.GetFileDropList()
                               If i.Length > 2 AndAlso g.Contains(i) = False Then g.Add(i)
                           Next
                       End If
                   End Sub)
                Return g
            End Get
        End Property

    End Class

    ''' <summary>
    ''' 获取电脑系统的一些信息
    ''' </summary>
    Public NotInheritable Class 系统信息

        Protected Sub New()
        End Sub

        ''' <summary>
        ''' 获取电脑CPU的名字字符串，如果获取失败就返回 Unknown CPU
        ''' </summary>
        Public Shared ReadOnly Property CPU型号 As String
            Get
                Static s As String = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "ProcessorNameString", "未知").ToString.Trim
                Return s
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑CPU的频率，单位为MHZ
        ''' </summary>
        Public Shared ReadOnly Property CPU频率 As UInteger
            Get
                Static s As UInteger = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "~MHz", 0)
                Return s
            End Get
        End Property

        ''' <summary>
        ''' 返回CPU的核心数量
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property CPU核心数量 As UInteger
            Get
                Static m As UInteger = Registry.LocalMachine.OpenSubKey("HARDWARE\DESCRIPTION\System\CentralProcessor", False).SubKeyCount
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回CPU的类型
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property CPU类型 As String
            Get
                Static s As String = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\CentralProcessor\0", "Identifier", "未知").ToString.Trim
                Return s
            End Get
        End Property

        ''' <summary>
        ''' 获取电脑的显示器的分辨率，单位是像素
        ''' </summary>
        Public Shared ReadOnly Property 屏幕分辨率 As Size
            Get
                Static m As Size = My.Computer.Screen.Bounds.Size
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 获取电脑的显示DPI，并强制转换为0.25的倍数
        ''' </summary>
        Public Shared ReadOnly Property DPI As Single
            Get
                Static d As Single = 0
                If d = 0 Then
                    Dim n As Integer = Registry.GetValue("HKEY_CURRENT_USER\Control Panel\Desktop\WindowMetrics", "AppliedDPI", 100)
                    If n < 100 Then n = 100
                    For i As Integer = 50 To 2000 Step 25
                        If Math.Abs(i - n) < 12.5 Then
                            n = i
                            Exit For
                        End If
                    Next
                    d = n / 100
                End If
                Return d
            End Get
        End Property

        ''' <summary>
        ''' 获取电脑的名字
        ''' </summary>
        Public Shared ReadOnly Property 电脑名 As String
            Get
                Static m As String = My.Computer.Name
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回当前的系统用户的用户名
        ''' </summary>
        Public Shared ReadOnly Property 用户名 As String
            Get
                Static m As String = 提取之后(My.User.Name, "\")
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 内存的大小，只包括物理内存，单位为MB
        ''' </summary>
        Public Shared ReadOnly Property 内存大小 As ULong
            Get
                Static m As ULong = My.Computer.Info.TotalPhysicalMemory / 1024 / 1024
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑的显卡的型号，不包括品牌名
        ''' </summary>
        Public Shared ReadOnly Property 显卡型号 As String
            Get
                Static m As String = ""
                If m.Length < 1 Then
                    Dim ra As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Video\", False)
                    Dim r As RegistryKey = Nothing
                    If Not IsNothing(ra) Then
                        For Each i As String In ra.GetSubKeyNames
                            r = ra.OpenSubKey(i)
                            If IsNothing(r) = False Then
                                r = r.OpenSubKey("0000")
                                If IsNothing(r) = False Then
                                    Dim o As Object = r.GetValue("HardwareInformation.AdapterString", Nothing)
                                    If IsNothing(o) = False AndAlso o.GetType = GetType(String) Then
                                        m = 文本标准化(o.ToString).Trim
                                    End If
                                    If m.Length > 0 Then Exit For
                                End If
                            End If
                        Next
                    End If
                End If
                If m.Length < 1 Then m = "未知"
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑的显卡的品牌
        ''' </summary>
        Public Shared ReadOnly Property 显卡品牌 As String
            Get
                Static m As String = ""
                If m.Length < 1 Then
                    Dim ra As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Video\", False)
                    Dim r As RegistryKey = Nothing
                    If Not IsNothing(ra) Then
                        For Each i As String In ra.GetSubKeyNames
                            r = ra.OpenSubKey(i)
                            If IsNothing(r) = False Then
                                r = r.OpenSubKey("0000")
                                If IsNothing(r) = False Then
                                    m = 文本标准化(r.GetValue("ProviderName", "")).Trim
                                    If m.Length > 0 Then Exit For
                                End If
                            End If
                        Next
                    End If
                End If
                If m.Length < 1 Then m = "未知"
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑的显卡的内存，单位为MB
        ''' </summary>
        Public Shared ReadOnly Property 显卡内存大小 As ULong
            Get
                Static m As ULong = 0
                If m < 1 Then
                    Dim ra As RegistryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\CurrentControlSet\Control\Video\", False)
                    Dim r As RegistryKey = Nothing
                    If Not IsNothing(ra) Then
                        For Each i As String In ra.GetSubKeyNames
                            r = ra.OpenSubKey(i)
                            If IsNothing(r) = False Then
                                r = r.OpenSubKey("0000")
                                If IsNothing(r) = False Then
                                    m = Math.Abs(Val(r.GetValue("HardwareInformation.MemorySize", 0).ToString)) / 1024 / 1024
                                    If m > 0 Then Exit For
                                End If
                            End If
                        Next
                    End If
                End If
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑的主板的型号
        ''' </summary>
        Public Shared ReadOnly Property 主板型号 As String
            Get
                Static m As String = ""
                If m.Length < 1 Then
                    m = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BaseBoardProduct", "未知").ToString.Trim
                End If
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑的主板生产厂家的名字
        ''' </summary>
        Public Shared ReadOnly Property 主板品牌 As String
            Get
                Static m As String = ""
                If m.Length < 1 Then
                    m = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BaseBoardManufacturer", "未知").ToString.Trim
                End If
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 返回电脑的主板生产厂家的名字
        ''' </summary>
        Public Shared ReadOnly Property BIOS类型 As String
            Get
                Static m As String = ""
                If m.Length < 1 Then
                    m = Registry.GetValue("HKEY_LOCAL_MACHINE\HARDWARE\DESCRIPTION\System\BIOS", "BIOSVendor", "未知").ToString.Trim
                End If
                Return m
            End Get
        End Property

    End Class

    ''' <summary>
    ''' 获取电脑网络相关的一些信息
    ''' </summary>
    Public NotInheritable Class 网络信息

        Protected Sub New()
        End Sub

        ''' <summary>
        ''' 是否存在任意可用本地或互联网的网络连接
        ''' </summary>
        ''' <returns></returns>
        Public Shared ReadOnly Property 存在连接 As Boolean
            Get
                Return My.Computer.Network.IsAvailable
            End Get
        End Property

        ''' <summary>
        ''' 获取本地的所以网卡的IP列表，包括ipv4和ipv6
        ''' </summary>
        Public Shared ReadOnly Property 本地IP列表 As List(Of String)
            Get
                Dim m As New List(Of String), s As String
                If 存在连接 Then
                    For Each ip As IPAddress In Dns.GetHostEntry(Dns.GetHostName).AddressList
                        s = ip.ToString
                        If s.Length > 4 Then m.Add(s)
                    Next
                End If
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 获取本地的所以网卡的IPv4列表
        ''' </summary>
        Public Shared ReadOnly Property 本地IPv4列表 As List(Of String)
            Get
                Dim m As New List(Of String), s As String
                If 存在连接 Then
                    For Each ip As IPAddress In Dns.GetHostEntry(Dns.GetHostName).AddressList
                        s = ip.ToString
                        If s.Length > 4 AndAlso 包含(s, ":") = False Then m.Add(s)
                    Next
                End If
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 获取本地的所以网卡的IPv6列表
        ''' </summary>
        Public Shared ReadOnly Property 本地IPv6列表 As List(Of String)
            Get
                Dim m As New List(Of String), s As String
                If 存在连接 Then
                    For Each ip As IPAddress In Dns.GetHostEntry(Dns.GetHostName).AddressList
                        s = ip.ToString
                        If s.Length > 4 AndAlso 包含(s, ":") Then m.Add(s)
                    Next
                End If
                Return m
            End Get
        End Property

        ''' <summary>
        ''' 获取本地的首选ipv4地址
        ''' </summary>
        Public Shared ReadOnly Property 首选IPv4地址 As String
            Get
                If 存在连接 Then
                    Dim s As String = PowerShell运行脚本("ipconfig")
                    If s.Length > 100 Then
                        s = s.ToLower()
                        s = 提取最之前(提取之后(s, "windows", "ipv4", ":"), vbCrLf).Trim
                    End If
                    Return s
                End If
                Return ""
            End Get
        End Property

        ''' <summary>
        ''' 获取本地的首选ipv4地址
        ''' </summary>
        Public Shared ReadOnly Property 首选IPv6地址 As String
            Get
                If 存在连接 Then
                    Dim s As String = PowerShell运行脚本("ipconfig")
                    If s.Length > 100 Then
                        s = s.ToLower()
                        s = 提取最之前(提取之后(s, "windows", "ipv6", ":"), vbCrLf).Trim
                    End If
                    Return s
                End If
                Return ""
            End Get
        End Property

    End Class

End Module
