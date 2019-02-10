Namespace HLControl
    <DefaultEvent("TextChanged")>
    Public Class HLTextBox
        Inherits Control

        Private tb As TextBox

        Public Sub New()
            DoubleBuffered = True
            HighLightLabel = Nothing
            tb = New TextBox
            With tb
                .BackColor = 内容绿
                .HideSelection = False
                .TextAlign = HorizontalAlignment.Left
                .ImeMode = ImeMode
                .BorderStyle = BorderStyle.None
            End With
            Controls.Add(tb)
            AddHandler tb.TextChanged, Sub()
                                           MyBase.OnTextChanged(Nothing)
                                       End Sub
            AddHandler tb.KeyDown, Sub(sender As Object, e As KeyEventArgs)
                                       If e.Control Then
                                           Select Case e.KeyCode
                                               Case Keys.A
                                                   tb.SelectAll()
                                               Case Keys.V
                                                   If 剪贴板.有文本 Then tb.SelectedText = 剪贴板.文本
                                               Case Keys.C
                                                   If tb.SelectionLength > 0 Then 剪贴板.文本 = tb.SelectedText
                                               Case Keys.Z
                                                   If tb.CanUndo Then tb.Undo()
                                           End Select
                                       End If
                                   End Sub
            AddHandler tb.GotFocus, Sub()
                                        If 非空(HighLightLabel) Then HighLightLabel.HighLight = True
                                    End Sub
            AddHandler tb.LostFocus, Sub()
                                         If 非空(HighLightLabel) Then HighLightLabel.HighLight = False
                                     End Sub
        End Sub

        Private Sub FixSize()
            With tb
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
            If Not Multiline Then Height = tb.Height + 6 * DPI
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
                Return tb.Text
            End Get
            Set(value As String)
                tb.Text = value
            End Set
        End Property

        <Browsable(False)>
        Public ReadOnly Property TextLength As Integer
            Get
                Return tb.TextLength
            End Get
        End Property

        <DefaultValue(False)>
        Public Property AcceptsTab As Boolean
            Get
                Return tb.AcceptsTab
            End Get
            Set(v As Boolean)
                tb.AcceptsTab = v
            End Set
        End Property

        <DefaultValue(True)>
        Public Property HideSelection As Boolean
            Get
                Return tb.HideSelection
            End Get
            Set(v As Boolean)
                tb.HideSelection = v
            End Set
        End Property

        Public Property Lines As String()
            Get
                Return tb.Lines
            End Get
            Set(v As String())
                tb.Lines = v
            End Set
        End Property

        Public Overloads ReadOnly Property Handle As IntPtr
            Get
                Return tb.Handle
            End Get
        End Property

        <DefaultValue(32767)>
        Public Overridable Property MaxLength As Integer
            Get
                Return tb.MaxLength
            End Get
            Set(v As Integer)
                tb.MaxLength = v
            End Set
        End Property

        <Browsable(False)>
        Public Property Modified As Boolean
            Get
                Return tb.Modified
            End Get
            Set(v As Boolean)
                tb.Modified = v
            End Set
        End Property

        <DefaultValue(False)>
        Public Overridable Property Multiline As Boolean
            Get
                Return tb.Multiline
            End Get
            Set(v As Boolean)
                tb.Multiline = v
                AcceptsReturn = v
            End Set
        End Property

        <DefaultValue(False)>
        Public Property [ReadOnly] As Boolean
            Get
                Return tb.[ReadOnly]
            End Get
            Set(v As Boolean)
                tb.[ReadOnly] = v
                FixSize()
            End Set
        End Property

        <Browsable(False)>
        Public Overridable Property SelectedText As String
            Get
                Return tb.SelectedText
            End Get
            Set(v As String)
                tb.SelectedText = v
            End Set
        End Property

        <Browsable(False)>
        Public Property SelectionStart As Integer
            Get
                Return tb.SelectionStart
            End Get
            Set(v As Integer)
                tb.SelectionStart = v
            End Set
        End Property

        <Browsable(False)>
        Public Overridable Property SelectionLength As Integer
            Get
                Return tb.SelectionLength
            End Get
            Set(v As Integer)
                tb.SelectionLength = v
            End Set
        End Property

        <DefaultValue(True)>
        Public Property WordWrap As Boolean
            Get
                Return tb.WordWrap
            End Get
            Set(v As Boolean)
                tb.WordWrap = v
            End Set
        End Property

        <DefaultValue(ScrollBars.None)>
        Public Property ScrollBars As ScrollBars
            Get
                Return tb.ScrollBars
            End Get
            Set(v As ScrollBars)
                tb.ScrollBars = v
            End Set
        End Property

        <DefaultValue(CharacterCasing.Normal)>
        Public Property CharacterCasing As CharacterCasing
            Get
                Return tb.CharacterCasing
            End Get
            Set(v As CharacterCasing)
                tb.CharacterCasing = v
            End Set
        End Property

        <Browsable(True)> <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> <Editor("System.Windows.Forms.Design.ListControlStringCollectionEditor, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a", GetType(UITypeEditor))> <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoCompleteCustomSource As AutoCompleteStringCollection
            Get
                Return tb.AutoCompleteCustomSource
            End Get
            Set(v As AutoCompleteStringCollection)
                tb.AutoCompleteCustomSource = v
            End Set
        End Property

        <Browsable(True)> <DefaultValue(AutoCompleteSource.None)> <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoCompleteSource As AutoCompleteSource
            Get
                Return tb.AutoCompleteSource
            End Get
            Set(v As AutoCompleteSource)
                tb.AutoCompleteSource = v
            End Set
        End Property

        <Browsable(True)> <DefaultValue(AutoCompleteMode.None)> <EditorBrowsable(EditorBrowsableState.Always)>
        Public Property AutoCompleteMode As AutoCompleteMode
            Get
                Return tb.AutoCompleteMode
            End Get
            Set(v As AutoCompleteMode)
                tb.AutoCompleteMode = v
            End Set
        End Property

        <DefaultValue(False)> <RefreshProperties(RefreshProperties.Repaint)>
        Public Property UseSystemPasswordChar As Boolean
            Get
                Return tb.UseSystemPasswordChar
            End Get
            Set(v As Boolean)
                tb.UseSystemPasswordChar = v
                tb.PasswordChar = IFF(v, "*", "")
            End Set
        End Property

        <DefaultValue(False)>
        Public Property AcceptsReturn As Boolean
            Get
                Return tb.AcceptsReturn
            End Get
            Set(v As Boolean)
                tb.AcceptsReturn = v
            End Set
        End Property

        Public Sub Copy()
            tb.Copy()
        End Sub

        Public Sub Undo()
            tb.Undo()
        End Sub

        Public Sub AppendText(text As String)
            tb.AppendText(text)
        End Sub

        Public Sub Clear()
            tb.Clear()
        End Sub

        Public Sub SelectAll()
            tb.SelectAll()
        End Sub

        Public Overloads Sub [Select](start As Integer, length As Integer)
            tb.[Select](start, length)
        End Sub

        Public Sub DeselectAll()
            tb.DeselectAll()
        End Sub

        Public Sub ScrollToCaret()
            tb.ScrollToCaret()
        End Sub

        Public Sub ClearUndo()
            tb.ClearUndo()
        End Sub

        Public Sub Cut()
            tb.Cut()
        End Sub

        Public Sub Paste()
            tb.Paste()
        End Sub

#End Region

    End Class

End Namespace