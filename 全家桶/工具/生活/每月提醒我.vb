Public Class 每月提醒我

    Private tr As 计时器

    Private Sub 日历_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dates.MinDate = New Date(Year(Now), 1, 1)
        ListT.AddColumn("日期", 200)
        ListT.AddColumn("事件")
        Dates.Value = Now
        ListOften.SelectedIndex = 0
        Dim s As String = 配置.字符串("日历列表")
        For Each i As String In 分行(s)
            Dim a As String = 提取最之前(i, " ")
            Dim b As String = 提取之后(i, " ")
            If 非空全部(a, b) Then ListT.AddItem(a, b)

        Next
        tr = New 计时器(5000, Sub()
                               If 当日时间戳() < 5 Then
                                   提醒我()
                               End If
                           End Sub)
        tr.启用 = True
        提醒我()
    End Sub

    Private Sub 提醒我()
        Dim job As String = "", day As Integer = 9999, a As String = ""
        For Each i As HLListViewItem In ListT.Items
            a = i.Title
            Dim d As Date = Now
            If a.StartsWith("每年") Then
                d = New Date(Year(Today), Val(提取之间(a, "年", "月")), Val(提取之间(a, "月", "日")))
                If d >= Now Then
                    Dim ds As Integer = DateDiff(DateInterval.Day, Today, d)
                    If ds < day Then
                        job = i.Items(0)
                        day = ds
                    End If
                End If
            ElseIf a.StartsWith("每月") Then
                d = New Date(Year(Today), Month(Today), Val(提取之间(a, "月", "日")))
                If d >= Now Then
                    Dim ds As Integer = DateDiff(DateInterval.Day, Today, d)
                    If ds < day Then
                        job = i.Items(0)
                        day = ds
                    End If
                End If
            End If
        Next
        If day < 28 Then
            If day < 1 Then
                a = "今天就是："
            ElseIf day < 2 Then
                a = "明天就是："
            Else
                a = day & "天后就是："
            End If
            弹出消息(a + job, "切莫忘记！")
        End If
    End Sub

    Private Sub 日历_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Dim s As String = ""
        For Each i As HLListViewItem In ListT.Items
            s += i.Title + " " + i.Items.Item(0) + vbCrLf
        Next
        配置.字符串("日历列表") = s
    End Sub

    Private Sub TxtJob_TextChanged() Handles TxtJob.TextChanged, Dates.ValueChanged, ListOften.SelectedIndexChanged
        设最小值(ListOften.SelectedIndex, 0)
        Dim ok As Boolean = TxtJob.Text.Trim.Length > 0
        ButAdd.Enabled = ok
    End Sub

    Private Sub ButAdd_Click(sender As Object, e As EventArgs) Handles ButAdd.Click
        Dim a As String = ""
        Select Case ListOften.SelectedIndex
            Case 0
                a = "每年M月D日"
            Case 1
                a = "每月D日"
        End Select
        a = 时间格式化(Dates.Value, a)
        Dim g As New HLListViewItem(a, TxtJob.Text.Trim)
        If Not ListT.Items.Contains(g) Then ListT.Items.Add(g)
        TxtJob.Text = ""
        ListT.SelectedIndex = ListT.Items.Count - 1
    End Sub

    Private Sub ListT_SelectedIndexChanged(sender As HLListView, e As HLValueEventArgs) Handles ListT.SelectedIndexChanged
        ButRemove.Enabled = ListT.SelectedIndex >= 0
    End Sub

    Private Sub ButRemove_Click(sender As Object, e As EventArgs) Handles ButRemove.Click
        ListT.Items.Remove(ListT.SelectedItem)
        ButRemove.Enabled = ListT.Items.Count > 0
    End Sub

    Private Sub TxtJob_KeyUp(sender As Object, e As KeyEventArgs) Handles TxtJob.KeyUp
        If e.KeyCode = Keys.Enter AndAlso ButAdd.Enabled = True Then
            ButAdd.PerformClick()
        End If
    End Sub

    Private Sub ButImportCSV_Click(sender As Object, e As EventArgs) Handles ButImportCSV.Click

    End Sub

End Class
