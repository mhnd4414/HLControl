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

    End Module

End Namespace
