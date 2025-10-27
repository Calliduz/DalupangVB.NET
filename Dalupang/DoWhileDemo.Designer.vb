<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DoWhileDemo
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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

    Friend WithEvents lblLimit As System.Windows.Forms.Label
    Friend WithEvents lblAdd As System.Windows.Forms.Label
    Friend WithEvents txtLimit As System.Windows.Forms.TextBox
    Friend WithEvents txtAdd As System.Windows.Forms.TextBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnClose As System.Windows.Forms.Button
    Friend WithEvents lstOutput As System.Windows.Forms.ListBox
    Friend WithEvents txtExample As System.Windows.Forms.TextBox

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblLimit = New System.Windows.Forms.Label()
        Me.lblAdd = New System.Windows.Forms.Label()
        Me.txtLimit = New System.Windows.Forms.TextBox()
        Me.txtAdd = New System.Windows.Forms.TextBox()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.lstOutput = New System.Windows.Forms.ListBox()
        Me.txtExample = New System.Windows.Forms.TextBox()

        Me.SuspendLayout()
        '
        ' lblLimit
        '
        Me.lblLimit.AutoSize = True
        Me.lblLimit.Location = New System.Drawing.Point(12, 12)
        Me.lblLimit.Name = "lblLimit"
        Me.lblLimit.Size = New System.Drawing.Size(32, 13)
        Me.lblLimit.TabIndex = 0
        Me.lblLimit.Text = "Limit:"
        '
        ' lblAdd
        '
        Me.lblAdd.AutoSize = True
        Me.lblAdd.Location = New System.Drawing.Point(12, 42)
        Me.lblAdd.Name = "lblAdd"
        Me.lblAdd.Size = New System.Drawing.Size(54, 13)
        Me.lblAdd.TabIndex = 1
        Me.lblAdd.Text = "Add value:"
        '
        ' txtLimit
        '
        Me.txtLimit.Location = New System.Drawing.Point(80, 9)
        Me.txtLimit.Name = "txtLimit"
        Me.txtLimit.Size = New System.Drawing.Size(120, 20)
        Me.txtLimit.TabIndex = 2
        Me.txtLimit.Text = "10"
        '
        ' txtAdd
        '
        Me.txtAdd.Location = New System.Drawing.Point(80, 39)
        Me.txtAdd.Name = "txtAdd"
        Me.txtAdd.Size = New System.Drawing.Size(120, 20)
        Me.txtAdd.TabIndex = 3
        Me.txtAdd.Text = "1"
        '
        ' btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(220, 8)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(80, 23)
        Me.btnRun.TabIndex = 4
        Me.btnRun.Text = "Run"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        ' btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(220, 34)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(80, 23)
        Me.btnClear.TabIndex = 5
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        ' lstOutput
        '
        Me.lstOutput.FormattingEnabled = True
        Me.lstOutput.HorizontalScrollbar = True
        Me.lstOutput.Location = New System.Drawing.Point(15, 75)
        Me.lstOutput.Name = "lstOutput"
        Me.lstOutput.Size = New System.Drawing.Size(360, 160)
        Me.lstOutput.TabIndex = 6
        '
        ' txtExample
        '
        Me.txtExample.Location = New System.Drawing.Point(15, 245)
        Me.txtExample.Multiline = True
        Me.txtExample.Name = "txtExample"
        Me.txtExample.ReadOnly = True
        Me.txtExample.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtExample.Size = New System.Drawing.Size(360, 80)
        Me.txtExample.TabIndex = 7
        '
        ' btnClose
        '
        Me.btnClose.Location = New System.Drawing.Point(295, 335)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(80, 23)
        Me.btnClose.TabIndex = 8
        Me.btnClose.Text = "Close"
        Me.btnClose.UseVisualStyleBackColor = True
        '
        ' DoWhileDemo
        '
        Me.ClientSize = New System.Drawing.Size(394, 375)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.txtExample)
        Me.Controls.Add(Me.lstOutput)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnRun)
        Me.Controls.Add(Me.txtAdd)
        Me.Controls.Add(Me.txtLimit)
        Me.Controls.Add(Me.lblAdd)
        Me.Controls.Add(Me.lblLimit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.Name = "DoWhileDemo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Do...Loop While — Demo"
        Me.ResumeLayout(False)
        Me.PerformLayout()

        ' Wire up events
        AddHandler Me.Load, AddressOf Me.DoWhileDemo_Load
        AddHandler Me.btnRun.Click, AddressOf Me.btnRun_Click
        AddHandler Me.btnClear.Click, AddressOf Me.btnClear_Click
        AddHandler Me.btnClose.Click, AddressOf Me.btnClose_Click
    End Sub
End Class
