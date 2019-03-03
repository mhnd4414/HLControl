Public Class 中小学生学习水平估测

    Private Sub 中小学学习水平估测_Load(sender As Object, e As EventArgs) Handles Me.Load
        配置.绑定控件(TxtAll, 控件值类型.Text, "1000")
        配置.绑定控件(TxtYourPos, 控件值类型.Text, "10")
        配置.绑定控件(TxtUp, 控件值类型.Text, "50")
    End Sub

    Private Sub ButCalc_Click(sender As Object, e As EventArgs) Handles ButCalc.Click
        Dim s As String = "结果：" + vbCrLf
        Dim a As Long = Val(TxtYourPos.Text)
        If a < 1 Then
            s += "你的排名不能高于第一名！"
        Else
            Dim b As Long = Val(TxtAll.Text)
            If b < a Then
                s += "你的排名不能高于总人数。"
            Else
                Dim c As Integer = Val(TxtUp.Text)
                If c > 99 OrElse c < 1 Then
                    s = "升学到重点的概率应该在[1%-99%]。"
                Else
                    Dim v As Single = a / b / c * 100
                    If v > 1 Then
                        v = v / 2 + 50
                    Else
                        v = v * 50
                    End If
                    v = 100 - v
                    设最小值(v, 0.000001)
                    Dim w As String = "学霸"
                    Select Case v
                        Case < 25
                            w = "学渣"
                        Case < 50
                            w = "中下"
                        Case < 90
                            w = "中上"
                    End Select
                    s += Format(v, "#0.000000")
                    Do While s.EndsWith("0")
                        If s.EndsWith(".0") Then
                            s = 去右(s, 2)
                            Exit Do
                        End If
                        s = 去右(s, 1)
                    Loop
                    s += " （" + w + "）"
                End If
            End If
        End If
        LabOut.HighLight = True
        LabOut.Text = s
    End Sub

    Private Sub ButGood_Click(sender As Object, e As EventArgs) Handles ButGood.Click
        TxtYourPos.Text = "1"
        TxtAll.Text = 重复("9", TxtAll.MaxLength)
        TxtUp.Text = "99"
        ButCalc.PerformClick()
    End Sub

    Private Sub ButBad_Click(sender As Object, e As EventArgs) Handles ButBad.Click
        TxtAll.Text = 重复("9", TxtAll.MaxLength)
        TxtYourPos.Text = TxtAll.Text
        TxtUp.Text = "1"
        ButCalc.PerformClick()
    End Sub

End Class