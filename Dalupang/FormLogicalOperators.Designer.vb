Partial Class FormLogicalOperators
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents chkValue1 As System.Windows.Forms.CheckBox
    Friend WithEvents chkValue2 As System.Windows.Forms.CheckBox
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents btnEvaluate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents txtExample As System.Windows.Forms.TextBox
    Friend WithEvents lblA As System.Windows.Forms.Label
    Friend WithEvents lblB As System.Windows.Forms.Label

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.chkValue1 = New System.Windows.Forms.CheckBox()
        Me.chkValue2 = New System.Windows.Forms.CheckBox()
        Me.txtValue1 = New System.Windows.Forms.TextBox()
        Me.txtValue2 = New System.Windows.Forms.TextBox()
        Me.btnEvaluate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.txtExample = New System.Windows.Forms.TextBox()
        Me.lblA = New System.Windows.Forms.Label()
        Me.lblB = New System.Windows.Forms.Label()

        Me.SuspendLayout()
        '
        'chkValue1
        '
        Me.chkValue1.AutoSize = True
        Me.chkValue1.Location = New System.Drawing.Point(15, 12)
        Me.chkValue1.Name = "chkValue1"
        Me.chkValue1.Size = New System.Drawing.Size(59, 17)
        Me.chkValue1.TabIndex = 0
        Me.chkValue1.Text = "Input A"
        Me.chkValue1.UseVisualStyleBackColor = True
        '
        'chkValue2
        '
        Me.chkValue2.AutoSize = True
        Me.chkValue2.Location = New System.Drawing.Point(15, 38)
        Me.chkValue2.Name = "chkValue2"
        Me.chkValue2.Size = New System.Drawing.Size(59, 17)
        Me.chkValue2.TabIndex = 1
        Me.chkValue2.Text = "Input B"
        Me.chkValue2.UseVisualStyleBackColor = True
        '
        'txtValue1
        '
        Me.txtValue1.Location = New System.Drawing.Point(100, 10)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(200, 20)
        Me.txtValue1.TabIndex = 2
        Me.txtValue1.PlaceholderText = "Optional: True or False"
        '
        'txtValue2
        '
        Me.txtValue2.Location = New System.Drawing.Point(100, 36)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(200, 20)
        Me.txtValue2.TabIndex = 3
        Me.txtValue2.PlaceholderText = "Optional: True or False"
        '
        'btnEvaluate
        '
        Me.btnEvaluate.Location = New System.Drawing.Point(320, 8)
        Me.btnEvaluate.Name = "btnEvaluate"
        Me.btnEvaluate.Size = New System.Drawing.Size(80, 23)
        Me.btnEvaluate.TabIndex = 4
        Me.btnEvaluate.Text = "Evaluate"
        Me.btnEvaluate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(320, 34)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lstResults
        '
        Me.lstResults.FormattingEnabled = True
        Me.lstResults.HorizontalScrollbar = True
        Me.lstResults.Location = New System.Drawing.Point(15, 70)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(385, 160)
        Me.lstResults.TabIndex = 6
        '
        'txtExample
        '
        Me.txtExample.Location = New System.Drawing.Point(15, 240)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExample.Size = New System.Drawing.Size(385, 100)
        Me.txtExample.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(320, 350)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'lblA
        '
        Me.lblA.AutoSize = True
        Me.lblA.Location = New System.Drawing.Point(15, -3)
        Me.lblA.Name = "lblA"
        Me.lblA.Size = New System.Drawing.Size(0, 13)
        Me.lblA.TabIndex = 9
        '
        'lblB
        '
        Me.lblB.AutoSize = True
        Me.lblB.Location = New System.Drawing.Point(15, 22)
        Me.lblB.Name = "lblB"
        Me.lblB.Size = New System.Drawing.Size(0, 13)
        Me.lblB.TabIndex = 10
        '
        'FormLogicalOperators
        '
        Me.ClientSize = New System.Drawing.Size(414, 385)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEvaluate)
        Me.Controls.Add(Me.txtValue2)
        Me.Controls.Add(Me.txtValue1)
        Me.Controls.Add(Me.chkValue2)
        Me.Controls.Add(Me.chkValue1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormLogicalOperators"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Logical Operators — Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Wire up events
        AddHandler Me.Load, AddressOf Me.FormLogicalOperators_Load
        AddHandler Me.btnEvaluate.Click, AddressOf Me.btnEvaluate_Click
        AddHandler Me.btnClear.Click, AddressOf Me.btnClear_Click
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
    End Sub
End Class