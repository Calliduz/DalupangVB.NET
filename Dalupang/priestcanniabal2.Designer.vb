<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class priestcanniabal2
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(priestcanniabal2))
        PictureBox3 = New PictureBox()
        PictureBox4 = New PictureBox()
        PictureBox7 = New PictureBox()
        PictureBox5 = New PictureBox()
        PictureBox6 = New PictureBox()
        PictureBox1 = New PictureBox()
        PictureBox2 = New PictureBox()
        lblTitle = New Label()
        lblInstructions = New Label()
        lblStatus = New Label()
        pnlControls = New Panel()
        btnReset = New Button()
        btnHelp = New Button()
        CType(PictureBox3, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).BeginInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).BeginInit()
        pnlControls.SuspendLayout()
        SuspendLayout()
        ' 
        ' PictureBox3
        ' 
        PictureBox3.BackColor = Color.Transparent
        PictureBox3.Image = My.Resources.Resources.Priest
        PictureBox3.Location = New Point(-5, 156)
        PictureBox3.Name = "PictureBox3"
        PictureBox3.Size = New Size(115, 171)
        PictureBox3.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox3.TabIndex = 2
        PictureBox3.TabStop = False
        ' 
        ' PictureBox4
        ' 
        PictureBox4.BackColor = Color.Transparent
        PictureBox4.Image = My.Resources.Resources.Boat
        PictureBox4.Location = New Point(276, 137)
        PictureBox4.Name = "PictureBox4"
        PictureBox4.Size = New Size(466, 373)
        PictureBox4.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox4.TabIndex = 3
        PictureBox4.TabStop = False
        ' 
        ' PictureBox7
        ' 
        PictureBox7.BackColor = Color.Transparent
        PictureBox7.Image = My.Resources.Resources.Devil
        PictureBox7.Location = New Point(211, 321)
        PictureBox7.Name = "PictureBox7"
        PictureBox7.Size = New Size(115, 162)
        PictureBox7.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox7.TabIndex = 5
        PictureBox7.TabStop = False
        ' 
        ' PictureBox5
        ' 
        PictureBox5.BackColor = Color.Transparent
        PictureBox5.Image = My.Resources.Resources.Devil
        PictureBox5.Location = New Point(102, 321)
        PictureBox5.Name = "PictureBox5"
        PictureBox5.Size = New Size(115, 162)
        PictureBox5.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox5.TabIndex = 6
        PictureBox5.TabStop = False
        ' 
        ' PictureBox6
        ' 
        PictureBox6.BackColor = Color.Transparent
        PictureBox6.Image = My.Resources.Resources.Devil
        PictureBox6.Location = New Point(-3, 321)
        PictureBox6.Name = "PictureBox6"
        PictureBox6.Size = New Size(115, 162)
        PictureBox6.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox6.TabIndex = 7
        PictureBox6.TabStop = False
        ' 
        ' PictureBox1
        ' 
        PictureBox1.BackColor = Color.Transparent
        PictureBox1.Image = My.Resources.Resources.Priest
        PictureBox1.Location = New Point(100, 156)
        PictureBox1.Name = "PictureBox1"
        PictureBox1.Size = New Size(115, 171)
        PictureBox1.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox1.TabIndex = 8
        PictureBox1.TabStop = False
        ' 
        ' PictureBox2
        ' 
        PictureBox2.BackColor = Color.Transparent
        PictureBox2.Image = My.Resources.Resources.Priest
        PictureBox2.Location = New Point(211, 156)
        PictureBox2.Name = "PictureBox2"
        PictureBox2.Size = New Size(115, 171)
        PictureBox2.SizeMode = PictureBoxSizeMode.Zoom
        PictureBox2.TabIndex = 9
        PictureBox2.TabStop = False
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.BackColor = Color.Transparent
        lblTitle.Font = New Font("Segoe UI", 24.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(200, 20)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(602, 45)
        lblTitle.TabIndex = 10
        lblTitle.Text = "Missionaries && Cannibals Puzzle"
        lblTitle.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblInstructions
        ' 
        lblInstructions.AutoSize = True
        lblInstructions.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(128))
        lblInstructions.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        lblInstructions.ForeColor = Color.White
        lblInstructions.Location = New Point(150, 75)
        lblInstructions.MaximumSize = New Size(700, 0)
        lblInstructions.Name = "lblInstructions"
        lblInstructions.Padding = New Padding(10, 8, 10, 8)
        lblInstructions.Size = New Size(676, 80)
        lblInstructions.TabIndex = 11
        lblInstructions.Text = "Transport all missionaries and cannibals across the river. " & "Cannibals must never outnumber missionaries on either shore. " & "Click characters to board, click the boat to sail. Max 2 passengers per trip."
        lblInstructions.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblStatus
        ' 
        lblStatus.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblStatus.BackColor = Color.FromArgb(CByte(0), CByte(0), CByte(0), CByte(100))
        lblStatus.Font = New Font("Segoe UI", 12.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblStatus.ForeColor = Color.Lime
        lblStatus.Location = New Point(12, 850)
        lblStatus.Name = "lblStatus"
        lblStatus.Padding = New Padding(10, 5, 10, 5)
        lblStatus.Size = New Size(978, 40)
        lblStatus.TabIndex = 12
        lblStatus.Text = "Game Ready - Click to Start"
        lblStatus.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' pnlControls
        ' 
        pnlControls.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        pnlControls.BackColor = Color.Transparent
        pnlControls.Controls.Add(btnReset)
        pnlControls.Controls.Add(btnHelp)
        pnlControls.Location = New Point(750, 900)
        pnlControls.Name = "pnlControls"
        pnlControls.Size = New Size(240, 50)
        pnlControls.TabIndex = 13
        ' 
        ' btnReset
        ' 
        btnReset.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        btnReset.Cursor = Cursors.Hand
        btnReset.FlatStyle = FlatStyle.Flat
        btnReset.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        btnReset.ForeColor = Color.White
        btnReset.Location = New Point(3, 3)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(110, 44)
        btnReset.TabIndex = 0
        btnReset.Text = "🔄 Reset"
        btnReset.UseVisualStyleBackColor = False
        ' 
        ' btnHelp
        ' 
        btnHelp.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        btnHelp.Cursor = Cursors.Hand
        btnHelp.FlatStyle = FlatStyle.Flat
        btnHelp.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        btnHelp.ForeColor = Color.White
        btnHelp.Location = New Point(125, 3)
        btnHelp.Name = "btnHelp"
        btnHelp.Size = New Size(110, 44)
        btnHelp.TabIndex = 1
        btnHelp.Text = "❓ Help"
        btnHelp.UseVisualStyleBackColor = False
        ' 
        ' priestcanniabal2
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = My.Resources.Resources.Background
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(1002, 968)
        Controls.Add(pnlControls)
        Controls.Add(lblStatus)
        Controls.Add(lblInstructions)
        Controls.Add(lblTitle)
        Controls.Add(PictureBox2)
        Controls.Add(PictureBox1)
        Controls.Add(PictureBox6)
        Controls.Add(PictureBox5)
        Controls.Add(PictureBox3)
        Controls.Add(PictureBox7)
        Controls.Add(PictureBox4)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(1020, 1015)
        Name = "priestcanniabal2"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Missionaries & Cannibals - River Crossing Puzzle"
        CType(PictureBox3, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox4, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox7, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox5, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox6, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox1, ComponentModel.ISupportInitialize).EndInit()
        CType(PictureBox2, ComponentModel.ISupportInitialize).EndInit()
        pnlControls.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents PictureBox3 As PictureBox
    Friend WithEvents PictureBox4 As PictureBox
    Friend WithEvents PictureBox7 As PictureBox
    Friend WithEvents PictureBox5 As PictureBox
    Friend WithEvents PictureBox6 As PictureBox
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents PictureBox2 As PictureBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblInstructions As Label
    Friend WithEvents lblStatus As Label
    Friend WithEvents pnlControls As Panel
    Friend WithEvents btnReset As Button
    Friend WithEvents btnHelp As Button
End Class
