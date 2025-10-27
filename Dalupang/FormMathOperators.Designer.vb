Partial Class FormMathOperators
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblValue1 As System.Windows.Forms.Label
    Friend WithEvents lblValue2 As System.Windows.Forms.Label
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents btnEvaluate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents txtExample As System.Windows.Forms.TextBox

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblValue1 = New System.Windows.Forms.Label()
        Me.lblValue2 = New System.Windows.Forms.Label()
        Me.txtValue1 = New System.Windows.Forms.TextBox()
        Me.txtValue2 = New System.Windows.Forms.TextBox()
        Me.btnEvaluate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.txtExample = New System.Windows.Forms.TextBox()

        Me.SuspendLayout()
        '
        'lblValue1
        '
        Me.lblValue1.AutoSize = True
        Me.lblValue1.Location = New System.Drawing.Point(12, 12)
        Me.lblValue1.Name = "lblValue1"
        Me.lblValue1.Size = New System.Drawing.Size(48, 13)
        Me.lblValue1.TabIndex = 0
        Me.lblValue1.Text = "Value 1:"
        '
        'lblValue2
        '
        Me.lblValue2.AutoSize = True
        Me.lblValue2.Location = New System.Drawing.Point(12, 42)
        Me.lblValue2.Name = "lblValue2"
        Me.lblValue2.Size = New System.Drawing.Size(48, 13)
        Me.lblValue2.TabIndex = 1
        Me.lblValue2.Text = "Value 2:"
        '
        'txtValue1
        '
        Me.txtValue1.Location = New System.Drawing.Point(70, 9)
        Me.txtValue1.Name = "txtValue1"
        Me.txtValue1.Size = New System.Drawing.Size(200, 20)
        Me.txtValue1.TabIndex = 2
        '
        'txtValue2
        '
        Me.txtValue2.Location = New System.Drawing.Point(70, 39)
        Me.txtValue2.Name = "txtValue2"
        Me.txtValue2.Size = New System.Drawing.Size(200, 20)
        Me.txtValue2.TabIndex = 3
        '
        'btnEvaluate
        '
        Me.btnEvaluate.Location = New System.Drawing.Point(290, 8)
        Me.btnEvaluate.Name = "btnEvaluate"
        Me.btnEvaluate.Size = New System.Drawing.Size(80, 23)
        Me.btnEvaluate.TabIndex = 4
        Me.btnEvaluate.Text = "Evaluate"
        Me.btnEvaluate.UseVisualStyleBackColor = True
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(290, 34)
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
        Me.lstResults.Location = New System.Drawing.Point(15, 75)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(355, 160)
        Me.lstResults.TabIndex = 6
        '
        'txtExample
        '
        Me.txtExample.Location = New System.Drawing.Point(15, 240)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExample.Size = New System.Drawing.Size(355, 100)
        Me.txtExample.TabIndex = 7
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(290, 350)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FormMathOperators
        '
        Me.ClientSize = New System.Drawing.Size(384, 385)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEvaluate)
        Me.Controls.Add(Me.txtValue2)
        Me.Controls.Add(Me.txtValue1)
        Me.Controls.Add(Me.lblValue2)
        Me.Controls.Add(Me.lblValue1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormMathOperators"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Math Operators — Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Wire up events
        AddHandler Me.Load, AddressOf Me.FormMathOperators_Load
        AddHandler Me.btnEvaluate.Click, AddressOf Me.btnEvaluate_Click
        AddHandler Me.btnClear.Click, AddressOf Me.btnClear_Click
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
    End Sub
End Class