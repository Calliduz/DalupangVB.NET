<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class priestcannibal
    Inherits System.Windows.Forms.Form

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    ' Designer-managed controls
    Friend leftPanel As System.Windows.Forms.Panel
    Friend rightPanel As System.Windows.Forms.Panel
    Friend boatPanel As System.Windows.Forms.Panel
    Friend moveBoatButton As System.Windows.Forms.Button
    Friend resetButton As System.Windows.Forms.Button
    Friend statusLabel As System.Windows.Forms.Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        leftPanel = New Panel()
        leftLbl = New Label()
        rightPanel = New Panel()
        rightLbl = New Label()
        boatPanel = New Panel()
        boatLbl = New Label()
        moveBoatButton = New Button()
        resetButton = New Button()
        statusLabel = New Label()
        livesLabel = New Label()
        leftPanel.SuspendLayout()
        rightPanel.SuspendLayout()
        boatPanel.SuspendLayout()
        SuspendLayout()
        ' 
        ' leftPanel
        ' 
        leftPanel.BackColor = Color.SandyBrown
        leftPanel.BorderStyle = BorderStyle.FixedSingle
        leftPanel.Controls.Add(leftLbl)
        leftPanel.Location = New Point(10, 10)
        leftPanel.Name = "leftPanel"
        leftPanel.Size = New Size(260, 350)
        leftPanel.TabIndex = 0
        ' 
        ' leftLbl
        ' 
        leftLbl.AutoSize = True
        leftLbl.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        leftLbl.Location = New Point(10, 10)
        leftLbl.Name = "leftLbl"
        leftLbl.Size = New Size(77, 19)
        leftLbl.TabIndex = 0
        leftLbl.Text = "Left Shore"
        ' 
        ' rightPanel
        ' 
        rightPanel.BackColor = Color.SandyBrown
        rightPanel.BorderStyle = BorderStyle.FixedSingle
        rightPanel.Controls.Add(rightLbl)
        rightPanel.Location = New Point(610, 10)
        rightPanel.Name = "rightPanel"
        rightPanel.Size = New Size(260, 350)
        rightPanel.TabIndex = 1
        ' 
        ' rightLbl
        ' 
        rightLbl.AutoSize = True
        rightLbl.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        rightLbl.Location = New Point(10, 10)
        rightLbl.Name = "rightLbl"
        rightLbl.Size = New Size(87, 19)
        rightLbl.TabIndex = 0
        rightLbl.Text = "Right Shore"
        ' 
        ' boatPanel
        ' 
        boatPanel.BackColor = Color.Brown
        boatPanel.BorderStyle = BorderStyle.Fixed3D
        boatPanel.Controls.Add(boatLbl)
        boatPanel.Location = New Point(320, 150)
        boatPanel.Name = "boatPanel"
        boatPanel.Size = New Size(220, 80)
        boatPanel.TabIndex = 2
        ' 
        ' boatLbl
        ' 
        boatLbl.AutoSize = True
        boatLbl.ForeColor = Color.White
        boatLbl.Location = New Point(10, 10)
        boatLbl.Name = "boatLbl"
        boatLbl.Size = New Size(97, 15)
        boatLbl.TabIndex = 0
        boatLbl.Text = "Boat (Capacity 2)"
        ' 
        ' moveBoatButton
        ' 
        moveBoatButton.Location = New Point(295, 250)
        moveBoatButton.Name = "moveBoatButton"
        moveBoatButton.Size = New Size(100, 30)
        moveBoatButton.TabIndex = 3
        moveBoatButton.Text = "Move Boat"
        moveBoatButton.UseVisualStyleBackColor = True
        ' 
        ' resetButton
        ' 
        resetButton.Location = New Point(480, 250)
        resetButton.Name = "resetButton"
        resetButton.Size = New Size(100, 30)
        resetButton.TabIndex = 4
        resetButton.Text = "Reset"
        resetButton.UseVisualStyleBackColor = True
        ' 
        ' statusLabel
        ' 
        statusLabel.Font = New Font("Segoe UI", 10F, FontStyle.Bold)
        statusLabel.Location = New Point(10, 400)
        statusLabel.Name = "statusLabel"
        statusLabel.Size = New Size(860, 30)
        statusLabel.TabIndex = 5
        statusLabel.Visible = False
        ' 
        ' livesLabel
        ' 
        livesLabel.Anchor = AnchorStyles.Top
        livesLabel.AutoSize = True
        livesLabel.BackColor = Color.Transparent
        livesLabel.Font = New Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        livesLabel.ForeColor = Color.FromArgb(CByte(192), CByte(0), CByte(0))
        livesLabel.Location = New Point(352, 21)
        livesLabel.Name = "livesLabel"
        livesLabel.Size = New Size(146, 32)
        livesLabel.TabIndex = 6
        livesLabel.Text = "Lives: ♥ ♥ ♥"
        ' 
        ' priestcannibal
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.LightBlue
        ClientSize = New Size(884, 561)
        Controls.Add(livesLabel)
        Controls.Add(leftPanel)
        Controls.Add(rightPanel)
        Controls.Add(boatPanel)
        Controls.Add(moveBoatButton)
        Controls.Add(resetButton)
        Controls.Add(statusLabel)
        Name = "priestcannibal"
        Text = "Priests and Devils - VB.NET"
        leftPanel.ResumeLayout(False)
        leftPanel.PerformLayout()
        rightPanel.ResumeLayout(False)
        rightPanel.PerformLayout()
        boatPanel.ResumeLayout(False)
        boatPanel.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents leftLbl As Label
    Friend WithEvents rightLbl As Label
    Friend WithEvents boatLbl As Label
    Friend WithEvents livesLabel As Label

End Class
