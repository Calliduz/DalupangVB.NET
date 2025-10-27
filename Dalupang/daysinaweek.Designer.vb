<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class daysinaweek
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

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Button1 = New Button()
        ListBox1 = New ListBox()
        Label1 = New Label()
        SuspendLayout()
        ' 
        ' Button1
        ' 
        Button1.BackColor = Color.Black
        Button1.Font = New Font("Constantia", 14.25F, FontStyle.Bold)
        Button1.ForeColor = Color.White
        Button1.Location = New Point(135, 136)
        Button1.Name = "Button1"
        Button1.Size = New Size(222, 59)
        Button1.TabIndex = 0
        Button1.Text = "Click to Print 7 days"
        Button1.UseVisualStyleBackColor = False
        ' 
        ' ListBox1
        ' 
        ListBox1.BackColor = Color.Black
        ListBox1.Font = New Font("Constantia", 14.25F, FontStyle.Bold)
        ListBox1.ForeColor = Color.White
        ListBox1.FormattingEnabled = True
        ListBox1.ItemHeight = 23
        ListBox1.Location = New Point(487, 100)
        ListBox1.Name = "ListBox1"
        ListBox1.Size = New Size(241, 234)
        ListBox1.TabIndex = 1
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.BackColor = Color.Black
        Label1.Font = New Font("Constantia", 24F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        Label1.ForeColor = Color.White
        Label1.Location = New Point(275, 24)
        Label1.Name = "Label1"
        Label1.Size = New Size(225, 39)
        Label1.TabIndex = 2
        Label1.Text = "7 Days a Week"
        ' 
        ' daysinaweek
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.Black
        BackgroundImage = My.Resources.Resources.DeWatermark_ai_1756810305918
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(800, 450)
        Controls.Add(Label1)
        Controls.Add(ListBox1)
        Controls.Add(Button1)
        ForeColor = Color.White
        Name = "daysinaweek"
        Text = "daysaweek"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
End Class
