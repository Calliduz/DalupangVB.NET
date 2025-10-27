Partial Class FormRelationalOperators
    Inherits System.Windows.Forms.Form

    ''' <summary>
    ''' Required designer variable.
    ''' </summary>
    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblValue1 As System.Windows.Forms.Label
    Friend WithEvents lblValue2 As System.Windows.Forms.Label
    Friend WithEvents txtValue1 As System.Windows.Forms.TextBox
    Friend WithEvents txtValue2 As System.Windows.Forms.TextBox
    Friend WithEvents btnEvaluate As System.Windows.Forms.Button
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents txtExample As System.Windows.Forms.TextBox
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents btnExampleClear As System.Windows.Forms.Button

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblValue1 = New System.Windows.Forms.Label()
        Me.lblValue2 = New System.Windows.Forms.Label()
        Me.txtValue1 = New System.Windows.Forms.TextBox()
        Me.txtValue2 = New System.Windows.Forms.TextBox()
        Me.btnEvaluate = New System.Windows.Forms.Button()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.txtExample = New System.Windows.Forms.TextBox()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnExampleClear = New System.Windows.Forms.Button()
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
        Me.btnEvaluate.Location = New System.Drawing.Point(290, 9)
        Me.btnEvaluate.Name = "btnEvaluate"
        Me.btnEvaluate.Size = New System.Drawing.Size(100, 23)
        Me.btnEvaluate.TabIndex = 4
        Me.btnEvaluate.Text = "Evaluate"
        Me.btnEvaluate.UseVisualStyleBackColor = True
        '
        'btnExampleClear
        '
        Me.btnExampleClear.Location = New System.Drawing.Point(290, 38)
        Me.btnExampleClear.Name = "btnExampleClear"
        Me.btnExampleClear.Size = New System.Drawing.Size(100, 23)
        Me.btnExampleClear.TabIndex = 8
        Me.btnExampleClear.Text = "Clear Results"
        Me.btnExampleClear.UseVisualStyleBackColor = True
        '
        'lstResults
        '
        Me.lstResults.FormattingEnabled = True
        Me.lstResults.HorizontalScrollbar = True
        Me.lstResults.Location = New System.Drawing.Point(15, 75)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(375, 160)
        Me.lstResults.TabIndex = 5
        '
        'txtExample
        '
        Me.txtExample.Location = New System.Drawing.Point(15, 245)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExample.Size = New System.Drawing.Size(375, 100)
        Me.txtExample.TabIndex = 6
        '
        'btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(310, 355)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        'FormRelationalOperators
        '
        Me.ClientSize = New System.Drawing.Size(404, 390)
        Me.Controls.Add(Me.btnExampleClear)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.btnEvaluate)
        Me.Controls.Add(Me.txtValue2)
        Me.Controls.Add(Me.txtValue1)
        Me.Controls.Add(Me.lblValue2)
        Me.Controls.Add(Me.lblValue1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "FormRelationalOperators"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Relational Operators — Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Wire up events
        AddHandler Me.btnEvaluate.Click, AddressOf Me.btnEvaluate_Click
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
        AddHandler Me.btnExampleClear.Click, AddressOf Me.btnExampleClear_Click
        AddHandler Me.Load, AddressOf Me.FormRelationalOperators_Load
    End Sub
End Class