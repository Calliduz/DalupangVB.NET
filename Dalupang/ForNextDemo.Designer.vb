<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ForNextDemo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents lblEnd As System.Windows.Forms.Label
    Friend WithEvents lblStep As System.Windows.Forms.Label
    Friend WithEvents txtStart As System.Windows.Forms.TextBox
    Friend WithEvents txtEnd As System.Windows.Forms.TextBox
    Friend WithEvents txtStep As System.Windows.Forms.TextBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents txtExample As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.lblEnd = New System.Windows.Forms.Label()
        Me.lblStep = New System.Windows.Forms.Label()
        Me.txtStart = New System.Windows.Forms.TextBox()
        Me.txtEnd = New System.Windows.Forms.TextBox()
        Me.txtStep = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.txtExample = New System.Windows.Forms.TextBox()

        Me.SuspendLayout()
        '
        ' lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.Location = New System.Drawing.Point(12, 12)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(35, 13)
        Me.lblStart.TabIndex = 0
        Me.lblStart.Text = "Start:"
        '
        ' lblEnd
        '
        Me.lblEnd.AutoSize = True
        Me.lblEnd.Location = New System.Drawing.Point(12, 42)
        Me.lblEnd.Name = "lblEnd"
        Me.lblEnd.Size = New System.Drawing.Size(29, 13)
        Me.lblEnd.TabIndex = 1
        Me.lblEnd.Text = "End:"
        '
        ' lblStep
        '
        Me.lblStep.AutoSize = True
        Me.lblStep.Location = New System.Drawing.Point(12, 72)
        Me.lblStep.Name = "lblStep"
        Me.lblStep.Size = New System.Drawing.Size(32, 13)
        Me.lblStep.TabIndex = 2
        Me.lblStep.Text = "Step:"
        '
        ' txtStart
        '
        Me.txtStart.Location = New System.Drawing.Point(60, 9)
        Me.txtStart.Name = "txtStart"
        Me.txtStart.Size = New System.Drawing.Size(120, 20)
        Me.txtStart.TabIndex = 3
        Me.txtStart.Text = "1"
        '
        ' txtEnd
        '
        Me.txtEnd.Location = New System.Drawing.Point(60, 39)
        Me.txtEnd.Name = "txtEnd"
        Me.txtEnd.Size = New System.Drawing.Size(120, 20)
        Me.txtEnd.TabIndex = 4
        Me.txtEnd.Text = "5"
        '
        ' txtStep
        '
        Me.txtStep.Location = New System.Drawing.Point(60, 69)
        Me.txtStep.Name = "txtStep"
        Me.txtStep.Size = New System.Drawing.Size(120, 20)
        Me.txtStep.TabIndex = 5
        Me.txtStep.Text = "1"
        '
        ' btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(200, 8)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(80, 23)
        Me.btnRun.TabIndex = 6
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        ' btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(200, 36)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 23)
        Me.btnClear.TabIndex = 7
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        ' lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.HorizontalScrollbar = True
        Me.lstOutput.Location = New System.Drawing.Point(15, 105)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(360, 160)
        Me.lstOutput.TabIndex = 8
        '
        ' txtExample
        '
        Me.txtExample.Location = New System.Drawing.Point(15, 275)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExample.Size = New System.Drawing.Size(360, 80)
        Me.txtExample.TabIndex = 9
        '
        ' btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(295, 365)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 10
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        ' ForNextDemo
        '
        Me.ClientSize = New System.Drawing.Size(394, 400)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.txtStep)
        Me.Controls.Add(Me.txtEnd)
        Me.Controls.Add(Me.txtStart)
        Me.Controls.Add(Me.lblStep)
        Me.Controls.Add(Me.lblEnd)
        Me.Controls.Add(Me.lblStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "ForNextDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "For...Next Loop — Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Wire up events
        AddHandler Me.Load, AddressOf Me.ForNextDemo_Load
        AddHandler Me.btnRun.Click, AddressOf Me.btnRun_Click
        AddHandler Me.btnClear.Click, AddressOf Me.btnClear_Click
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
    End Sub
End Class
