<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterfaceDemo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(InterfaceDemo))
        Button1 = New Button()
        TextBox1 = New TextBox()
        OutlinedLabel1 = New OutlinedLabel()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Black
        Button1.ForeColor = Color.White
        Button1.Location = New Point(12, 312)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 56)
        Button1.TabIndex = 8
        Button1.Text = "Click Me!"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' TextBox1
        ' 
        TextBox1.BackColor = Color.Black
        TextBox1.Font = New Font("Arial", 17F)
        TextBox1.ForeColor = Color.White
        TextBox1.Location = New Point(12, 105)
        TextBox1.Multiline = True
        TextBox1.Name = "TextBox1"
        TextBox1.Size = New Size(720, 201)
        TextBox1.TabIndex = 7
        TextBox1.TabStop = False
        TextBox1.Text = resources.GetString("TextBox1.Text")
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
        OutlinedLabel1.Size = New Size(288, 74)
        OutlinedLabel1.TabIndex = 6
        OutlinedLabel1.Text = "Interface"
        ' 
        ' InterfaceDemo
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.DeWatermark_ai_1756810305918
        ClientSize = New Size(800, 450)
        Controls.Add(Button1)
        Controls.Add(TextBox1)
        Controls.Add(OutlinedLabel1)
        ForeColor = SystemColors.ControlText
        Name = "InterfaceDemo"
        Text = "InterfaceDemo"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents OutlinedLabel1 As OutlinedLabel
End Class
