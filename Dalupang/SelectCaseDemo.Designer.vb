Partial Class SelectCaseDemo
    Inherits System.Windows.Forms.Form

    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblValue As System.Windows.Forms.Label
    Friend WithEvents txtValue As System.Windows.Forms.TextBox
    Friend WithEvents btnEvaluate As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstResults As System.Windows.Forms.ListBox
    Friend WithEvents txtExample As System.Windows.Forms.TextBox

    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblValue = New System.Windows.Forms.Label()
        Me.txtValue = New System.Windows.Forms.TextBox()
        Me.btnEvaluate = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstResults = New System.Windows.Forms.ListBox()
        Me.txtExample = New System.Windows.Forms.TextBox()

        Me.SuspendLayout()
        '
        ' lblValue
        '
        Me.lblValue.AutoSize = True
        Me.lblValue.Location = New System.Drawing.Point(12, 12)
        Me.lblValue.Name = "lblValue"
        Me.lblValue.Size = New System.Drawing.Size(67, 13)
        Me.lblValue.TabIndex = 0
        Me.lblValue.Text = "Enter value:"
        '
        ' txtValue
        '
        Me.txtValue.Location = New System.Drawing.Point(85, 9)
        Me.txtValue.Name = "txtValue"
        Me.txtValue.Size = New System.Drawing.Size(160, 20)
        Me.txtValue.TabIndex = 1
        Me.txtValue.Text = "3"
        '
        ' btnEvaluate
        '
        Me.btnEvaluate.Location = New System.Drawing.Point(260, 7)
        Me.btnEvaluate.Name = "btnEvaluate"
        Me.btnEvaluate.Size = New System.Drawing.Size(80, 23)
        Me.btnEvaluate.TabIndex = 2
        Me.btnEvaluate.Text = "Evaluate"
        Me.btnEvaluate.UseVisualStyleBackColor = True
        '
        ' btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(260, 33)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 23)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        ' lstResults
        '
        Me.lstResults.FormattingEnabled = True
        Me.lstResults.HorizontalScrollbar = True
        Me.lstResults.Location = New System.Drawing.Point(15, 70)
        Me.lstResults.Name = "lstResults"
        Me.lstResults.Size = New System.Drawing.Size(360, 160)
        Me.lstResults.TabIndex = 4
        '
        ' txtExample
        '
        Me.txtExample.Location = New System.Drawing.Point(15, 245)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExample.Size = New System.Drawing.Size(360, 80)
        Me.txtExample.TabIndex = 5
        '
        ' btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(295, 335)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 6
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        ' SelectCaseDemo
        '
        Me.ClientSize = New System.Drawing.Size(394, 370)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lstResults)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnEvaluate)
        Me.Controls.Add(Me.txtValue)
        Me.Controls.Add(Me.lblValue)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "SelectCaseDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Select Case — Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Wire up events
        AddHandler Me.Load, AddressOf Me.SelectCaseDemo_Load
        AddHandler Me.btnEvaluate.Click, AddressOf Me.btnEvaluate_Click
        AddHandler Me.btnClear.Click, AddressOf Me.btnClear_Click
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
    End Sub
End Class