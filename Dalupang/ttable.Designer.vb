<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class TruthTableDemonstration
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(TruthTableDemonstration))
        dgvTruthTable = New DataGridView()
        btnGenerate = New Button()
        chkInputA = New CheckBox()
        chkInputB = New CheckBox()
        grpInteractive = New GroupBox()
        lblXorResult = New Label()
        lblOrResult = New Label()
        lblAndResult = New Label()
        lblNotResult = New Label()
        pnlTitle = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        CType(dgvTruthTable, ComponentModel.ISupportInitialize).BeginInit()
        grpInteractive.SuspendLayout()
        pnlTitle.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgvTruthTable
        ' 
        dgvTruthTable.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvTruthTable.BackgroundColor = SystemColors.ButtonHighlight
        dgvTruthTable.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvTruthTable.Location = New Point(12, 130)
        dgvTruthTable.Name = "dgvTruthTable"
        dgvTruthTable.Size = New Size(560, 300)
        dgvTruthTable.TabIndex = 0
        ' 
        ' btnGenerate
        ' 
        btnGenerate.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        btnGenerate.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        btnGenerate.FlatStyle = FlatStyle.Flat
        btnGenerate.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold, GraphicsUnit.Point)
        btnGenerate.ForeColor = Color.White
        btnGenerate.Location = New Point(12, 445)
        btnGenerate.Name = "btnGenerate"
        btnGenerate.Size = New Size(200, 45)
        btnGenerate.TabIndex = 1
        btnGenerate.Text = "🔄 Regenerate Table"
        btnGenerate.UseVisualStyleBackColor = False
        ' 
        ' chkInputA
        ' 
        chkInputA.AutoSize = True
        chkInputA.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        chkInputA.Location = New Point(20, 35)
        chkInputA.Name = "chkInputA"
        chkInputA.Size = New Size(73, 23)
        chkInputA.TabIndex = 2
        chkInputA.Text = "Input A"
        chkInputA.UseVisualStyleBackColor = True
        ' 
        ' chkInputB
        ' 
        chkInputB.AutoSize = True
        chkInputB.Font = New Font("Segoe UI", 10.0F, FontStyle.Regular, GraphicsUnit.Point)
        chkInputB.Location = New Point(20, 65)
        chkInputB.Name = "chkInputB"
        chkInputB.Size = New Size(72, 23)
        chkInputB.TabIndex = 3
        chkInputB.Text = "Input B"
        chkInputB.UseVisualStyleBackColor = True
        ' 
        ' grpInteractive
        ' 
        grpInteractive.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        grpInteractive.BackColor = Color.FromArgb(CByte(240), CByte(240), CByte(240))
        grpInteractive.Controls.Add(lblXorResult)
        grpInteractive.Controls.Add(lblOrResult)
        grpInteractive.Controls.Add(lblAndResult)
        grpInteractive.Controls.Add(lblNotResult)
        grpInteractive.Controls.Add(chkInputB)
        grpInteractive.Controls.Add(chkInputA)
        grpInteractive.Font = New Font("Segoe UI", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        grpInteractive.ForeColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        grpInteractive.Location = New Point(590, 130)
        grpInteractive.Name = "grpInteractive"
        grpInteractive.Padding = New Padding(10)
        grpInteractive.Size = New Size(350, 300)
        grpInteractive.TabIndex = 4
        grpInteractive.TabStop = False
        grpInteractive.Text = "Interactive Boolean Logic Tester"
        ' 
        ' lblXorResult
        ' 
        lblXorResult.AutoSize = False
        lblXorResult.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        lblXorResult.Font = New Font("Consolas", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblXorResult.ForeColor = Color.White
        lblXorResult.Location = New Point(20, 220)
        lblXorResult.Name = "lblXorResult"
        lblXorResult.Padding = New Padding(5)
        lblXorResult.Size = New Size(310, 35)
        lblXorResult.TabIndex = 8
        lblXorResult.Text = "A XOR B = FALSE"
        lblXorResult.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblOrResult
        ' 
        lblOrResult.AutoSize = False
        lblOrResult.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        lblOrResult.Font = New Font("Consolas", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblOrResult.ForeColor = Color.White
        lblOrResult.Location = New Point(20, 175)
        lblOrResult.Name = "lblOrResult"
        lblOrResult.Padding = New Padding(5)
        lblOrResult.Size = New Size(310, 35)
        lblOrResult.TabIndex = 7
        lblOrResult.Text = "A OR B = FALSE"
        lblOrResult.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblAndResult
        ' 
        lblAndResult.AutoSize = False
        lblAndResult.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        lblAndResult.Font = New Font("Consolas", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblAndResult.ForeColor = Color.White
        lblAndResult.Location = New Point(20, 130)
        lblAndResult.Name = "lblAndResult"
        lblAndResult.Padding = New Padding(5)
        lblAndResult.Size = New Size(310, 35)
        lblAndResult.TabIndex = 6
        lblAndResult.Text = "A AND B = FALSE"
        lblAndResult.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblNotResult
        ' 
        lblNotResult.AutoSize = False
        lblNotResult.BackColor = Color.FromArgb(CByte(50), CByte(50), CByte(50))
        lblNotResult.Font = New Font("Consolas", 10.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblNotResult.ForeColor = Color.White
        lblNotResult.Location = New Point(20, 95)
        lblNotResult.Name = "lblNotResult"
        lblNotResult.Padding = New Padding(5)
        lblNotResult.Size = New Size(310, 35)
        lblNotResult.TabIndex = 5
        lblNotResult.Text = "NOT A = TRUE"
        lblNotResult.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' pnlTitle
        ' 
        pnlTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        pnlTitle.BackColor = Color.FromArgb(CByte(70), CByte(130), CByte(180))
        pnlTitle.Controls.Add(lblTitle)
        pnlTitle.Controls.Add(lblSubtitle)
        pnlTitle.Location = New Point(0, 0)
        pnlTitle.Name = "pnlTitle"
        pnlTitle.Size = New Size(952, 115)
        pnlTitle.TabIndex = 5
        ' 
        ' lblTitle
        ' 
        lblTitle.AutoSize = True
        lblTitle.Font = New Font("Segoe UI", 26.0F, FontStyle.Bold, GraphicsUnit.Point)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(12, 15)
        lblTitle.Name = "lblTitle"
        lblTitle.Size = New Size(544, 47)
        lblTitle.TabIndex = 0
        lblTitle.Text = "Boolean Logic Truth Tables"
        ' 
        ' lblSubtitle
        ' 
        lblSubtitle.AutoSize = True
        lblSubtitle.Font = New Font("Segoe UI", 11.0F, FontStyle.Regular, GraphicsUnit.Point)
        lblSubtitle.ForeColor = Color.White
        lblSubtitle.Location = New Point(15, 67)
        lblSubtitle.Name = "lblSubtitle"
        lblSubtitle.Size = New Size(652, 20)
        lblSubtitle.TabIndex = 1
        lblSubtitle.Text = "Explore logical operations: NOT, AND, OR, XOR | Toggle inputs to see real-time results"
        ' 
        ' TruthTableDemonstration
        ' 
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), Image)
        BackgroundImageLayout = ImageLayout.Stretch
        ClientSize = New Size(952, 505)
        Controls.Add(pnlTitle)
        Controls.Add(grpInteractive)
        Controls.Add(btnGenerate)
        Controls.Add(dgvTruthTable)
        MinimumSize = New Size(968, 544)
        Name = "TruthTableDemonstration"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Boolean Logic - Truth Table Demonstration"
        CType(dgvTruthTable, ComponentModel.ISupportInitialize).EndInit()
        grpInteractive.ResumeLayout(False)
        grpInteractive.PerformLayout()
        pnlTitle.ResumeLayout(False)
        pnlTitle.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents dgvTruthTable As DataGridView
    Friend WithEvents btnGenerate As Button
    Friend WithEvents chkInputA As CheckBox
    Friend WithEvents chkInputB As CheckBox
    Friend WithEvents grpInteractive As GroupBox
    Friend WithEvents lblNotResult As Label
    Friend WithEvents lblAndResult As Label
    Friend WithEvents lblOrResult As Label
    Friend WithEvents lblXorResult As Label
    Friend WithEvents pnlTitle As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
End Class
