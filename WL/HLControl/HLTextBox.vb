Namespace HLControl
    <DefaultEvent("TextChanged")>
    Public Class HLTextBox
        Inherits Control

        Private 文本框 As TextBox

        Public Sub New()
            DoubleBuffered = True
            HighLightLabel = Nothing
            文本框 = New TextBox
            With 文本框
                .BackColor = 内容绿
                .HideSelection = False
                .TextAlign = HorizontalAlignment.Left
                .ImeMode = ImeMode
                .BorderStyle = BorderStyle.None
            End With
            Controls.Add(文本框)
            AddHandler 文本框.TextChanged, Sub()
                                            MyBase.OnTextChanged(Nothing)
                                        End Sub
            AddHandler 文本框.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                        If e.Control Then
                                            Select Case e.KeyCode
                                                Case Keys.A
                                                    文本框.SelectAll()
                                                Case Keys.V
                                                    If 剪贴板.有文本 Then 文本框.SelectedText = 剪贴板.文本
                                                Case Keys.C
                                                    If 文本框.SelectionLength > 0 Then 剪贴板.文本 = 文本框.SelectedText
                                                Case Keys.Z
                                                    If 文本框.CanUndo Then 文本框.Undo()
                                            End Select
                                        End If
                                    End Sub
            AddHandler 文本框.GotFocus, Sub()
                                         If 非空(HighLightLabel) Then HighLightLabel.HighLight = True
                                     End Sub
            AddHandler 文本框.LostFocus, Sub()
                                          If 非空(HighLightLabel) Then HighLightLabel.HighLight = False
                                      End Sub
        End Sub

        Private Sub FixSize()
            With 文本框
                .ForeColor = IFF([ReadOnly], 淡色, 内容白)
                .Font = Font
                Dim i As Single = 3 * DPI
                .Left = i
                .Top = i
                .Width = Width - 2 * i
                .Height = Height - 2 * i
            End With
        End Sub

        Private Sub _NeedRePaint() Handles Me.SizeChanged, Me.Resize, Me.AutoSizeChanged, Me.FontChanged, Me.EnabledChanged, MyBase.TextChanged
            Invalidate()
        End Sub

        Public Property HighLightLabel As HLLabel

        Protected Overrides Sub OnPaint(e As PaintEventArgs)
            修正Dock(Me, True, Multiline)
            If Not Multiline Then Height = 文本框.Height + 6 * DPI
            FixSize()
            MyBase.OnPaint(e)
            With e.Graphics
                绘制基础矩形(e.Graphics, ClientRectangle, True, False, True)
            End With
        End Sub

#Region "Textbox 复刻内容"

        <Editor("System.ComponentModel.Design.MultilineStringEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> <Localizable(True)>
        Public Overrides Property Text As String
            Get
                Return 文本框.Text
            End Get
            Set(value As String)
                文本框.Text = value
            End Set
        End Property

        <Browsable(False)>
        Public ReadOnly Property TextLength As Integer
            Get
                Return 文本框.TextLength
            End Get
        End Property

        <DefaultValue(False)>
        Public Property AcceptsTab As Boolean
            Get
                Return 文本框.AcceptsTab
            End Get
            Set(v As Boolean)
                文本框.AcceptsTab = v
            End Set
        End Property

        <DefaultValue(True)>
        Public Property HideSelection As Boolean
            Get
                Return 文本框.HideSelection
            End Get
            Set(v As Boolean)
                文本框.HideSelection = v
            End Set
        End Property

        Public Property Lines As String()
            Get
                Return 文本框.Lines
            End Get
            Set(v As String())
                文本框.Lines = v
            End Set
        End Property

        Public Overloads ReadOnly Property Handle As IntPtr
            Get
                Return 文本框.Handle
            End Get
        End Property

        <DefaultValue(32767)>
        Public Overridable Property MaxLength As Integer
            Get
                Return 文本框.MaxLength
            End Get
            Set(v As Integer)
                文本框.MaxLength = v
            End Set
        End Property

        <Browsable(False)>
        Public Property Modified As Boolean
            Get
                Return 文本框.Modified
            End Get
            Set(v As Boolean)
                文本框.Modified = v
            End Set
        End Property

        <DefaultValue(False)>
        Public Overridable Property Multiline As Boolean
            Get
                Return 文本框.Multiline
            End Get
            Set(v As Boolean)
                文本框.Multiline = v
                AcceptsReturn = v
            End Set
        End Property

        <DefaultValue(False)>
        Public Property [ReadOnly] As Boolean
            Get
                Return 文本框.[ReadOnly]
            End Get
            Set(v As Boolean)
                文本框.[ReadOnly] = v
                FixSize()
            End Set
        End Property

        <Browsable(False)>
        Public Overridable Property SelectedText As String
            Get
                Return 文本框.SelectedText
            End Get
            Set(v As String)
                文本框.SelectedText = v
            End Set
        End Property

        <Browsable(False)>
        Public Property SelectionStart As Integer
            Get
                Return 文本框.SelectionStart
            End Get
            Set(v As Integer)
                文本框.SelectionStart = v
            End Set
        End Property

        <Browsable(False)>
        Public Overridable Property SelectionLength As Integer
            Get
                Return 文本框.SelectionLength
            End Get
            Set(v As Integer)
                文本框.SelectionLength = v
            End Set
        End Property

        <DefaultValue(True)>
        Public Property WordWrap As Boolean
            Get
                Return 文本框.WordWrap
            End Get
            Set(v As Boolean)
                文本框.WordWrap = v
            End Set
        End Property

        <DefaultValue(ScrollBars.None)>
        Public Property ScrollBars As ScrollBars
            Get
                Return 文本框.ScrollBars
            End Get
            Set(v As ScrollBars)
                文本框.ScrollBars = v
            End Set
        End Property

        <DefaultValue(CharacterCasing.Normal)>
        Public Property CharacterCasing As CharacterCasing
            Get
                Return 文本框.CharacterCasing
            End Get
            Set(v As CharacterCasing)
                文本框.CharacterCasing = v
            End Set
        End Property

        <Browsable(True)> <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> <Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoCompleteCustomSource As AutoCompleteStringCollection
            Get
                Return 文本框.AutoCompleteCustomSource
            End Get
            Set(v As AutoCompleteStringCollection)
                文本框.AutoCompleteCustomSource = v
            End Set
        End Property

        <Browsable(True)> <DefaultValue(AutoCompleteSource.None)> <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoCompleteSource As AutoCompleteSource
            Get
                Return 文本框.AutoCompleteSource
            End Get
            Set(v As AutoCompleteSource)
                文本框.AutoCompleteSource = v
            End Set
        End Property

        <Browsable(True)> <DefaultValue(AutoCompleteMode.None)> <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoCompleteMode As AutoCompleteMode
            Get
                Return 文本框.AutoCompleteMode
            End Get
            Set(v As AutoCompleteMode)
                文本框.AutoCompleteMode = v
            End Set
        End Property

        <DefaultValue(False)> <RefreshProperties(RefreshProperties.Repaint)>
        Public Property UseSystemPasswordChar As Boolean
            Get
                Return 文本框.UseSystemPasswordChar
            End Get
            Set(v As Boolean)
                文本框.UseSystemPasswordChar = v
                文本框.PasswordChar = IFF(v, "*", "")
            End Set
        End Property

        <DefaultValue(False)>
        Public Property AcceptsReturn As Boolean
            Get
                Return 文本框.AcceptsReturn
            End Get
            Set(v As Boolean)
                文本框.AcceptsReturn = v
            End Set
        End Property

        Public Sub Copy()
            文本框.Copy()
        End Sub

        Public Sub Undo()
            文本框.Undo()
        End Sub

        Public Sub AppendText(text As String)
            文本框.AppendText(text)
        End Sub

        Public Sub Clear()
            文本框.Clear()
        End Sub

        Public Sub SelectAll()
            文本框.SelectAll()
        End Sub

        Public Overloads Sub [Select](start As Integer, length As Integer)
            文本框.[Select](start, length)
        End Sub

        Public Sub DeselectAll()
            文本框.DeselectAll()
        End Sub

        Public Sub ScrollToCaret()
            文本框.ScrollToCaret()
        End Sub

        Public Sub ClearUndo()
            文本框.ClearUndo()
        End Sub

        Public Sub Cut()
            文本框.Cut()
        End Sub

        Public Sub Paste()
            文本框.Paste()
        End Sub

#End Region

    End Class

End Namespace