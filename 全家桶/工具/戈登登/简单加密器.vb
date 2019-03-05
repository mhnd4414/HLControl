Public Class 简单加密器

    Private M As 走過去加密

    Private Sub 简单加密器_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        M = New 走過去加密
        配置.绑定控件(TxtKey, 控件值类型.Text, "五个汉字可以当密钥")
    End Sub

    Private Sub ButEn_Click(sender As Object, e As EventArgs) Handles ButEn.Click
        M.密钥 = TxtKey.Text
        TxtOut.Text = M.加密(TxtIn.Text)
    End Sub

    Private Sub ButDE_Click(sender As Object, e As EventArgs) Handles ButDE.Click
        M.密钥 = TxtKey.Text
        TxtOut.Text = M.解密为字符串(TxtIn.Text)
    End Sub

End Class