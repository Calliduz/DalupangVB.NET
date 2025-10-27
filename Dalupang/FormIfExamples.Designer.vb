<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIfExamples
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        OutlinedLabel1 = New OutlinedLabel()
        TextBoxInput = New TextBox()
        ButtonIf = New Button()
        ButtonIfThen = New Button()
        ButtonIfElse = New Button()
        SuspendLayout()
        ' 
        ' OutlinedLabel1
        ' 
        OutlinedLabel1.AutoSize = True
        OutlinedLabel1.BackColor = Color.Transparent
        OutlinedLabel1.Font = New Font("Times New Roman", 45F, FontStyle.Bold)
        OutlinedLabel1.ForeColor = Color.White
        OutlinedLabel1.Location = New Point(12, 9)
        OutlinedLabel1.Name = "OutlinedLabel1"
        OutlinedLabel1.OutlineColor = Color.Black
        OutlinedLabel1.OutlineWidth = 2
        OutlinedLabel1.Size = New Size(368, 68)
        OutlinedLabel1.TabIndex = 3
        OutlinedLabel1.Text = "If Statements"
        OutlinedLabel1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxInput
        ' 
        TextBoxInput.BackColor = Color.Black
        TextBoxInput.Font = New Font("Arial", 17F, FontStyle.Bold)
        TextBoxInput.ForeColor = Color.White
        TextBoxInput.Location = New Point(12, 118)
        TextBoxInput.Multiline = True
        TextBoxInput.Name = "TextBoxInput"
        TextBoxInput.PlaceholderText = "Enter a number."
        TextBoxInput.Size = New Size(248, 42)
        TextBoxInput.TabIndex = 4
        ' 
        ' ButtonIf
        ' 
        ButtonIf.BackColor = Color.Black
        ButtonIf.ForeColor = Color.White
        ButtonIf.Location = New Point(12, 176)
        ButtonIf.Name = "ButtonIf"
        ButtonIf.Size = New Size(124, 56)
        ButtonIf.TabIndex = 5
        ButtonIf.Text = "Test IF"
        ButtonIf.UseVisualStyleBackColor = False
        ' 
        ' ButtonIfThen
        ' 
        ButtonIfThen.BackColor = Color.Black
        ButtonIfThen.ForeColor = Color.White
        ButtonIfThen.Location = New Point(12, 249)
        ButtonIfThen.Name = "ButtonIfThen"
        ButtonIfThen.Size = New Size(124, 56)
        ButtonIfThen.TabIndex = 6
        ButtonIfThen.Text = "Test IF-THEN"
        ButtonIfThen.UseVisualStyleBackColor = False
        ' 
        ' ButtonIfElse
        ' 
        ButtonIfElse.BackColor = Color.Black
        ButtonIfElse.ForeColor = Color.White
        ButtonIfElse.Location = New Point(12, 323)
        ButtonIfElse.Name = "ButtonIfElse"
        ButtonIfElse.Size = New Size(124, 56)
        ButtonIfElse.TabIndex = 7
        ButtonIfElse.Text = "Test IF-THEN-ELSE"
        ButtonIfElse.UseVisualStyleBackColor = False
        ' 
        ' FormIfExamples
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.DeWatermark_ai_1756810305918
        ClientSize = New Size(800, 450)
        Controls.Add(ButtonIfElse)
        Controls.Add(ButtonIfThen)
        Controls.Add(ButtonIf)
        Controls.Add(TextBoxInput)
        Controls.Add(OutlinedLabel1)
        Name = "FormIfExamples"
        Text = "FormIfExamples"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents OutlinedLabel1 As OutlinedLabel
    Friend WithEvents TextBoxInput As TextBox
    Friend WithEvents ButtonIf As Button
    Friend WithEvents ButtonIfThen As Button
    Friend WithEvents ButtonIfElse As Button
End Class
