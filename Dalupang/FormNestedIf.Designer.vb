<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNestedIf
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNestedIf))
        OutlinedLabel1 = New OutlinedLabel()
        TextBoxInput = New TextBox()
        Label1 = New Label()
        ButtonCheck = New Button()
        RichTextBox1 = New RichTextBox()
        SuspendLayout()
        ' 
        ' OutlinedLabel1
        ' 
        OutlinedLabel1.AutoSize = True
        OutlinedLabel1.BackColor = Color.Transparent
        OutlinedLabel1.Font = New Font("Times New Roman", 49F, FontStyle.Bold)
        OutlinedLabel1.ForeColor = Color.White
        OutlinedLabel1.Location = New Point(12, 9)
        OutlinedLabel1.Name = "OutlinedLabel1"
        OutlinedLabel1.OutlineColor = Color.Black
        OutlinedLabel1.OutlineWidth = 2
        OutlinedLabel1.Size = New Size(590, 74)
        OutlinedLabel1.TabIndex = 3
        OutlinedLabel1.Text = "Nested If Statement"
        OutlinedLabel1.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' TextBoxInput
        ' 
        TextBoxInput.BackColor = Color.Black
        TextBoxInput.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        TextBoxInput.ForeColor = SystemColors.WindowFrame
        TextBoxInput.Location = New Point(12, 268)
        TextBoxInput.Multiline = True
        TextBoxInput.Name = "TextBoxInput"
        TextBoxInput.Size = New Size(225, 32)
        TextBoxInput.TabIndex = 9
        TextBoxInput.Text = "Enter a number.."
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Location = New Point(23, 93)
        Label1.Name = "Label1"
        Label1.Size = New Size(0, 15)
        Label1.TabIndex = 10
        ' 
        ' ButtonCheck
        ' 
        ButtonCheck.BackColor = Color.Black
        ButtonCheck.Font = New Font("Arial Black", 9.75F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        ButtonCheck.ForeColor = Color.Lime
        ButtonCheck.Location = New Point(12, 316)
        ButtonCheck.Name = "ButtonCheck"
        ButtonCheck.Size = New Size(127, 34)
        ButtonCheck.TabIndex = 11
        ButtonCheck.Text = "Check Number"
        ButtonCheck.UseVisualStyleBackColor = False
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.BackColor = Color.Black
        RichTextBox1.Font = New Font("Arial", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        RichTextBox1.ForeColor = Color.White
        RichTextBox1.Location = New Point(18, 93)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.Size = New Size(219, 141)
        RichTextBox1.TabIndex = 12
        RichTextBox1.Text = resources.GetString("RichTextBox1.Text")
        ' 
        ' FormNestedIf
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.DeWatermark_ai_1756810305918
        ClientSize = New Size(800, 450)
        Controls.Add(RichTextBox1)
        Controls.Add(ButtonCheck)
        Controls.Add(Label1)
        Controls.Add(TextBoxInput)
        Controls.Add(OutlinedLabel1)
        Name = "FormNestedIf"
        Text = "FormNestedIf"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents OutlinedLabel1 As OutlinedLabel
    Friend WithEvents TextBoxInput As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents ButtonCheck As Button
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
