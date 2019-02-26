Imports System.Drawing.Imaging
Imports System.Windows.Media.Imaging

Namespace 基础

    ''' <summary>
    ''' 图片处理模块
    ''' </summary>
    Public Module 图片

        ''' <summary>
        ''' 把字节数组变成图片
        ''' </summary>
        Public Function 字节数组转图片(字节数组 As Byte()) As Bitmap
            If 非空(字节数组) Then
                Try
                    Dim m As New MemoryStream
                    m.Write(字节数组, 0, 字节数组.Length)
                    Dim b As Bitmap = Bitmap.FromStream(m)
                    m.Dispose()
                    Return b
                Catch ex As Exception
                    出错(ex)
                End Try
            End If
            Return Nothing
        End Function

        ''' <summary>
        ''' 把图片的指定范围裁剪出来成新的图片
        ''' </summary>
        Public Function 裁剪(图片 As Bitmap, 范围 As Rectangle) As Bitmap
            If 为空(图片) Then Return Nothing
            Return 图片.Clone(范围, 图片.PixelFormat)
        End Function

        ''' <summary>
        ''' 获取Bitmap的帧数
        ''' </summary>
        Public Function 获取帧数(图片 As Bitmap) As UInteger
            If 为空(图片) Then Return 0
            Dim fd As New FrameDimension(图片.FrameDimensionsList(0))
            Return 图片.GetFrameCount(fd)
        End Function

        ''' <summary>
        ''' 根据图片格式，获取 ImageCodecInfo 的 Encoder
        ''' </summary>
        Public Function 获取图片编码器(格式 As ImageFormat) As ImageCodecInfo
            If 为空(格式) Then Return Nothing
            Try
                For Each i As ImageCodecInfo In ImageCodecInfo.GetImageEncoders
                    If i.FormatID = 格式.Guid Then
                        Return i
                    End If
                Next
            Catch ex As Exception
                出错(ex)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' 把图片变成字节数组
        ''' </summary>
        Public Function 图片转字节数组(图片 As Bitmap, Optional 格式 As ImageFormat = Nothing) As Byte()
            If 为空(图片) Then Return Nothing
            Dim m As New MemoryStream
            Dim f As ImageFormat
            If 非空(格式) Then
                f = 格式
            Else
                f = 图片.RawFormat
            End If
            图片.Save(m, f)
            Return 读取完整流(m)
        End Function

        ''' <summary>
        ''' 把图片文件进行读取，并且不占用实际的本地文件 
        ''' </summary>
        Public Function 读图片为文件(文件 As String) As Bitmap
            Dim g As Byte() = 读文件为字节数组(文件)
            If 为空(g) Then Return Nothing
            Try
                Dim m As New MemoryStream
                m.Write(g, 0, g.Length)
                Dim b As Bitmap = Bitmap.FromStream(m)
                Return b
            Catch ex As Exception
                出错(ex)
            End Try
            Return Nothing
        End Function

        ''' <summary>
        ''' GIF动态图片处理类，一个大缺点，保存出来的GIF是无压缩的，文件比较大
        ''' </summary>
        Public Class GIF图片

            Protected Sub New(b As Bitmap)
                帧 = New List(Of Bitmap)
                Try
                    Dim fd As New FrameDimension(b.FrameDimensionsList(0))
                    Dim c As Integer = b.GetFrameCount(fd) - 1
                    For i As Integer = 0 To c
                        b.SelectActiveFrame(fd, i)
                        Dim m As New MemoryStream
                        b.Save(m, ImageFormat.Png)
                        Dim p As Bitmap = Bitmap.FromStream(m)
                        If 非空(p) Then 帧.Add(p)
                    Next
                Catch ex As Exception
                    出错(ex)
                End Try
            End Sub

            ''' <summary>
            ''' GIF的每一帧
            ''' </summary>
            Public Property 帧 As List(Of Bitmap)

            ''' <summary>
            ''' 包含的帧的数量
            ''' </summary>
            Public ReadOnly Property 帧数 As UInteger
                Get
                    Return 帧.Count
                End Get
            End Property

            ''' <summary>
            ''' 从本地文件读取GIF
            ''' </summary>
            Public Shared Function 从文件读取(文件 As String) As GIF图片
                Try
                    Dim m As Bitmap = Bitmap.FromFile(文件)
                    If 非空(m) Then Return New GIF图片(m)
                Catch ex As Exception
                    出错(ex)
                End Try
                Return Nothing
            End Function

            ''' <summary>
            ''' 把Bitmap类读取成GIF图片
            ''' </summary>
            Public Shared Function 读取Bitmap(图片 As Bitmap) As GIF图片
                If 为空(图片) Then Return Nothing
                Return New GIF图片(图片)
            End Function

            ''' <summary>
            ''' 针对图片进行批量处理
            ''' </summary>
            Public Sub 批量处理(内容 As Func(Of Bitmap, Bitmap))
                Dim g As New List(Of Bitmap)
                For Each i As Bitmap In 帧
                    g.Add(内容(i))
                Next
                帧 = g
            End Sub

            ''' <summary>
            ''' 生成空白的GIF
            ''' </summary>
            Public Shared Function 生成空GIF(宽 As Integer, 高 As Integer) As GIF图片
                Dim m As New Bitmap(CInt(设最小值(宽, 1)), CInt(设最小值(高, 1)))
                Return New GIF图片(m)
            End Function

            Private Function BitmapToFrame(b As Bitmap) As BitmapFrame
                Dim m As New MemoryStream
                b.Save(m, ImageFormat.Png)
                Return BitmapFrame.Create(m)
            End Function

            ''' <summary>
            ''' 保存GIF内容为字节数组
            ''' </summary>
            Public Function 保存为字节数组() As Byte()
                If 帧数 < 1 Then Return Nothing
                Dim g As New GifBitmapEncoder
                For Each i As Bitmap In 帧
                    g.Frames.Add(BitmapToFrame(i))
                Next
                Dim s As New MemoryStream
                g.Save(s)
                Return 读取完整流(s)
            End Function

            ''' <summary>
            ''' 保存到本地文件，返回保存是否成功
            ''' </summary>
            Public Function 保存到文件(文件 As String) As Boolean
                Dim m As Byte() = 保存为字节数组()
                If 为空(m) Then Return False
                Return 写字节数组到文件(文件, m)
            End Function

        End Class

    End Module

End Namespace
