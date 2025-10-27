<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
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
        txtDisplay = New TextBox()
        btnexponent = New Button()
        btnintdiv = New Button()
        btnmod = New Button()
        btnc = New Button()
        btnplus = New Button()
        btn9 = New Button()
        btn8 = New Button()
        btn7 = New Button()
        btnsubtract = New Button()
        btn6 = New Button()
        btn5 = New Button()
        btn4 = New Button()
        btnmultiply = New Button()
        btn3 = New Button()
        btn2 = New Button()
        btn1 = New Button()
        btndivide = New Button()
        btndot = New Button()
        btn0 = New Button()
        btnsroot = New Button()
        btndelete = New Button()
        btnequals = New Button()
        explnrslt = New TextBox()
        SuspendLayout()
        ' 
        ' txtDisplay
        ' 
        txtDisplay.BackColor = Color.Black
        txtDisplay.Font = New Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        txtDisplay.ForeColor = Color.White
        txtDisplay.Location = New Point(368, 12)
        txtDisplay.Name = "txtDisplay"
        txtDisplay.ReadOnly = True
        txtDisplay.Size = New Size(270, 71)
        txtDisplay.TabIndex = 0
        txtDisplay.Text = "0"
        txtDisplay.TextAlign = HorizontalAlignment.Right
        ' 
        ' btnexponent
        ' 
        btnexponent.BackColor = Color.Black
        btnexponent.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btnexponent.ForeColor = Color.White
        btnexponent.Location = New Point(368, 102)
        btnexponent.Name = "btnexponent"
        btnexponent.Size = New Size(64, 50)
        btnexponent.TabIndex = 1
        btnexponent.Text = "^"
        btnexponent.UseVisualStyleBackColor = False
        ' 
        ' btnintdiv
        ' 
        btnintdiv.BackColor = Color.Black
        btnintdiv.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnintdiv.ForeColor = Color.White
        btnintdiv.Location = New Point(438, 102)
        btnintdiv.Name = "btnintdiv"
        btnintdiv.Size = New Size(64, 50)
        btnintdiv.TabIndex = 2
        btnintdiv.Text = "INT DIV"
        btnintdiv.UseVisualStyleBackColor = False
        ' 
        ' btnmod
        ' 
        btnmod.BackColor = Color.Black
        btnmod.Font = New Font("Segoe UI", 12F, FontStyle.Bold)
        btnmod.ForeColor = Color.White
        btnmod.Location = New Point(508, 102)
        btnmod.Name = "btnmod"
        btnmod.Size = New Size(64, 50)
        btnmod.TabIndex = 3
        btnmod.Text = "MOD"
        btnmod.UseVisualStyleBackColor = False
        ' 
        ' btnc
        ' 
        btnc.BackColor = Color.Black
        btnc.Font = New Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btnc.ForeColor = Color.FromArgb(CByte(192), CByte(255), CByte(255))
        btnc.Location = New Point(644, 66)
        btnc.Name = "btnc"
        btnc.Size = New Size(125, 42)
        btnc.TabIndex = 4
        btnc.Text = "Clear"
        btnc.UseVisualStyleBackColor = False
        ' 
        ' btnplus
        ' 
        btnplus.BackColor = Color.Black
        btnplus.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btnplus.ForeColor = Color.White
        btnplus.Location = New Point(574, 102)
        btnplus.Name = "btnplus"
        btnplus.Size = New Size(64, 50)
        btnplus.TabIndex = 8
        btnplus.Text = "+"
        btnplus.UseVisualStyleBackColor = False
        ' 
        ' btn9
        ' 
        btn9.BackColor = Color.Black
        btn9.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn9.ForeColor = Color.White
        btn9.Location = New Point(508, 171)
        btn9.Name = "btn9"
        btn9.Size = New Size(64, 50)
        btn9.TabIndex = 7
        btn9.Text = "9"
        btn9.UseVisualStyleBackColor = False
        ' 
        ' btn8
        ' 
        btn8.BackColor = Color.Black
        btn8.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn8.ForeColor = Color.White
        btn8.Location = New Point(438, 171)
        btn8.Name = "btn8"
        btn8.Size = New Size(64, 50)
        btn8.TabIndex = 6
        btn8.Text = "8"
        btn8.UseVisualStyleBackColor = False
        ' 
        ' btn7
        ' 
        btn7.BackColor = Color.Black
        btn7.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn7.ForeColor = Color.White
        btn7.Location = New Point(368, 171)
        btn7.Name = "btn7"
        btn7.Size = New Size(64, 50)
        btn7.TabIndex = 5
        btn7.Text = "7"
        btn7.UseVisualStyleBackColor = False
        ' 
        ' btnsubtract
        ' 
        btnsubtract.BackColor = Color.Black
        btnsubtract.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btnsubtract.ForeColor = Color.White
        btnsubtract.Location = New Point(574, 171)
        btnsubtract.Name = "btnsubtract"
        btnsubtract.Size = New Size(64, 50)
        btnsubtract.TabIndex = 12
        btnsubtract.Text = "-"
        btnsubtract.UseVisualStyleBackColor = False
        ' 
        ' btn6
        ' 
        btn6.BackColor = Color.Black
        btn6.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn6.ForeColor = Color.White
        btn6.Location = New Point(508, 236)
        btn6.Name = "btn6"
        btn6.Size = New Size(64, 50)
        btn6.TabIndex = 11
        btn6.Text = "6"
        btn6.UseVisualStyleBackColor = False
        ' 
        ' btn5
        ' 
        btn5.BackColor = Color.Black
        btn5.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn5.ForeColor = Color.White
        btn5.Location = New Point(438, 236)
        btn5.Name = "btn5"
        btn5.Size = New Size(64, 50)
        btn5.TabIndex = 10
        btn5.Text = "5"
        btn5.UseVisualStyleBackColor = False
        ' 
        ' btn4
        ' 
        btn4.BackColor = Color.Black
        btn4.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn4.ForeColor = Color.White
        btn4.Location = New Point(368, 236)
        btn4.Name = "btn4"
        btn4.Size = New Size(64, 50)
        btn4.TabIndex = 9
        btn4.Text = "4"
        btn4.UseVisualStyleBackColor = False
        ' 
        ' btnmultiply
        ' 
        btnmultiply.BackColor = Color.Black
        btnmultiply.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btnmultiply.ForeColor = Color.White
        btnmultiply.Location = New Point(574, 236)
        btnmultiply.Name = "btnmultiply"
        btnmultiply.Size = New Size(64, 50)
        btnmultiply.TabIndex = 16
        btnmultiply.Text = "*"
        btnmultiply.UseVisualStyleBackColor = False
        ' 
        ' btn3
        ' 
        btn3.BackColor = Color.Black
        btn3.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn3.ForeColor = Color.White
        btn3.Location = New Point(508, 303)
        btn3.Name = "btn3"
        btn3.Size = New Size(64, 50)
        btn3.TabIndex = 15
        btn3.Text = "3"
        btn3.UseVisualStyleBackColor = False
        ' 
        ' btn2
        ' 
        btn2.BackColor = Color.Black
        btn2.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn2.ForeColor = Color.White
        btn2.Location = New Point(438, 303)
        btn2.Name = "btn2"
        btn2.Size = New Size(64, 50)
        btn2.TabIndex = 14
        btn2.Text = "2"
        btn2.UseVisualStyleBackColor = False
        ' 
        ' btn1
        ' 
        btn1.BackColor = Color.Black
        btn1.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn1.ForeColor = Color.White
        btn1.Location = New Point(368, 303)
        btn1.Name = "btn1"
        btn1.Size = New Size(64, 50)
        btn1.TabIndex = 13
        btn1.Text = "1"
        btn1.UseVisualStyleBackColor = False
        ' 
        ' btndivide
        ' 
        btndivide.BackColor = Color.Black
        btndivide.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btndivide.ForeColor = Color.White
        btndivide.Location = New Point(574, 303)
        btndivide.Name = "btndivide"
        btndivide.Size = New Size(64, 50)
        btndivide.TabIndex = 20
        btndivide.Text = "/"
        btndivide.UseVisualStyleBackColor = False
        ' 
        ' btndot
        ' 
        btndot.BackColor = Color.Black
        btndot.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btndot.ForeColor = Color.White
        btndot.Location = New Point(508, 368)
        btndot.Name = "btndot"
        btndot.Size = New Size(64, 50)
        btndot.TabIndex = 19
        btndot.Text = "."
        btndot.UseVisualStyleBackColor = False
        ' 
        ' btn0
        ' 
        btn0.BackColor = Color.Black
        btn0.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btn0.ForeColor = Color.White
        btn0.Location = New Point(438, 368)
        btn0.Name = "btn0"
        btn0.Size = New Size(64, 50)
        btn0.TabIndex = 18
        btn0.Text = "0"
        btn0.UseVisualStyleBackColor = False
        ' 
        ' btnsroot
        ' 
        btnsroot.BackColor = Color.Black
        btnsroot.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btnsroot.ForeColor = Color.White
        btnsroot.Location = New Point(368, 368)
        btnsroot.Name = "btnsroot"
        btnsroot.Size = New Size(64, 50)
        btnsroot.TabIndex = 17
        btnsroot.Text = "√"
        btnsroot.UseVisualStyleBackColor = False
        ' 
        ' btndelete
        ' 
        btndelete.BackColor = Color.Black
        btndelete.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        btndelete.ForeColor = Color.Red
        btndelete.Location = New Point(644, 12)
        btndelete.Name = "btndelete"
        btndelete.Size = New Size(125, 48)
        btndelete.TabIndex = 21
        btndelete.Text = "<- BackSpace"
        btndelete.UseVisualStyleBackColor = False
        ' 
        ' btnequals
        ' 
        btnequals.BackColor = Color.Black
        btnequals.Font = New Font("Segoe UI", 21.75F, FontStyle.Bold)
        btnequals.ForeColor = Color.White
        btnequals.Location = New Point(574, 368)
        btnequals.Name = "btnequals"
        btnequals.Size = New Size(64, 50)
        btnequals.TabIndex = 22
        btnequals.Text = "="
        btnequals.UseVisualStyleBackColor = False
        ' 
        ' explnrslt
        ' 
        explnrslt.BackColor = Color.Black
        explnrslt.Font = New Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        explnrslt.ForeColor = Color.White
        explnrslt.Location = New Point(12, 12)
        explnrslt.Multiline = True
        explnrslt.Name = "explnrslt"
        explnrslt.ReadOnly = True
        explnrslt.Size = New Size(350, 437)
        explnrslt.TabIndex = 23
        explnrslt.Text = "Result Explanation"
        explnrslt.TextAlign = HorizontalAlignment.Center
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = SystemColors.Control
        BackgroundImage = My.Resources.Resources.DeWatermark_ai_1756810305918
        ClientSize = New Size(800, 450)
        Controls.Add(explnrslt)
        Controls.Add(btnequals)
        Controls.Add(btndelete)
        Controls.Add(btndivide)
        Controls.Add(btndot)
        Controls.Add(btn0)
        Controls.Add(btnsroot)
        Controls.Add(btnmultiply)
        Controls.Add(btn3)
        Controls.Add(btn2)
        Controls.Add(btn1)
        Controls.Add(btnsubtract)
        Controls.Add(btn6)
        Controls.Add(btn5)
        Controls.Add(btn4)
        Controls.Add(btnplus)
        Controls.Add(btn9)
        Controls.Add(btn8)
        Controls.Add(btn7)
        Controls.Add(btnc)
        Controls.Add(btnmod)
        Controls.Add(btnintdiv)
        Controls.Add(btnexponent)
        Controls.Add(txtDisplay)
        Name = "Form2"
        Text = "Form2"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents txtDisplay As TextBox
    Friend WithEvents btnexponent As Button
    Friend WithEvents btnintdiv As Button
    Friend WithEvents btnmod As Button
    Friend WithEvents btnc As Button
    Friend WithEvents btnplus As Button
    Friend WithEvents btn9 As Button
    Friend WithEvents btn8 As Button
    Friend WithEvents btn7 As Button
    Friend WithEvents btnsubtract As Button
    Friend WithEvents btn6 As Button
    Friend WithEvents btn5 As Button
    Friend WithEvents btn4 As Button
    Friend WithEvents btnmultiply As Button
    Friend WithEvents btn3 As Button
    Friend WithEvents btn2 As Button
    Friend WithEvents btn1 As Button
    Friend WithEvents btndivide As Button
    Friend WithEvents btndot As Button
    Friend WithEvents btn0 As Button
    Friend WithEvents btnsroot As Button
    Friend WithEvents btndelete As Button
    Friend WithEvents btnequals As Button
    Friend WithEvents explnrslt As TextBox
End Class
