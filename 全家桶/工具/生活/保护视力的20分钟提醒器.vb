Public Class 保护视力的20分钟提醒器

    Private tm As Long = 0
    Private ReadOnly all As Long = 21 * 60

    Private Sub 保护视力的20分钟提醒器_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        配置.绑定控件(CheckOn, 控件值类型.Checked, False)
    End Sub

    Private Sub ButRead_Click(sender As Object, e As EventArgs) Handles ButRead.Click
        打开程序("https://www.healthline.com/health/eye-health/20-20-20-rule")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LabNext.Text = "距离下次提醒还剩" & (all - tm) & "秒。"
        tm += 1
        If tm > all Then
            ButTest.PerformClick()
            tm = 0
        End If
    End Sub

    Private Sub CheckOn_CheckedChanged(sender As HLCheckBox, e As HLValueEventArgs) Handles CheckOn.CheckedChanged
        LabNext.Text = ""
        Timer1.Enabled = e.NewValue
        If Timer1.Enabled Then Timer1_Tick(Nothing, Nothing)
        tm = 0
    End Sub

    Private Sub ButTest_Click(sender As Object, e As EventArgs) Handles ButTest.Click
        弹出消息("20分钟了！", "站起来保护你的视力！", ToolTipIcon.Warning)
    End Sub

End Class