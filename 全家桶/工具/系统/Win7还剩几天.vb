Public Class Win7还剩几天

    Private Sub Win7还剩几天_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Timer1_Tick(Nothing, Nothing)
        Timer1.Enabled = True
    End Sub

    Private Sub ButRead_Click(sender As Object, e As EventArgs) Handles ButRead.Click
        打开程序("https://www.microsoft.com/zh-cn/windowsforbusiness/end-of-windows-7-support")
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Visible Then
            LabTime.Text = "距离 Windows 7 
被微软彻底放弃支持还剩：" + DateDiff(DateInterval.Day, Now, #2020-01-14#).ToString + "天，
Windows 7 已经发售了：" + DateDiff(DateInterval.Day, #2009-07-22#, Now).ToString + "天。"
        End If
    End Sub

    Private Sub ButLTT_Click(sender As Object, e As EventArgs) Handles ButLTT.Click
        打开程序("https://www.bilibili.com/video/av46121490")
    End Sub

End Class