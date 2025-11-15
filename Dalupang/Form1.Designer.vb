<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))

        ' Main UI Components
        pnlSidebar = New Panel()
        pnlHeader = New Panel()
        lblTitle = New Label()
        lblSubtitle = New Label()
        btnMenuToggle = New Button()
        btnThemeToggle = New Button()
        pnlContent = New Panel()
        lblWelcome = New Label()
        txtSearch = New TextBox()
        flpModules = New FlowLayoutPanel()
        pnlFooter = New Panel()
        lblFooter = New Label()
        lblVersion = New Label()
        animationTimer = New Timer(components)
        tooltipProvider = New ToolTip(components)

        pnlSidebar.SuspendLayout()
        pnlHeader.SuspendLayout()
        pnlContent.SuspendLayout()
        flpModules.SuspendLayout()
        pnlFooter.SuspendLayout()
        SuspendLayout()

        ' 
        ' pnlHeader - Modern Header with Responsive Design
        ' 
        pnlHeader.BackColor = Color.FromArgb(45, 52, 54)
        pnlHeader.Dock = DockStyle.Top
        pnlHeader.Height = 100
        pnlHeader.Controls.Add(lblTitle)
        pnlHeader.Controls.Add(lblSubtitle)
        pnlHeader.Controls.Add(btnMenuToggle)
        pnlHeader.Controls.Add(btnThemeToggle)
        pnlHeader.Padding = New Padding(20, 10, 20, 10)

        ' 
        ' lblTitle - Hero Title with Auto-resize
        ' 
        lblTitle.AutoSize = False
        lblTitle.Text = "Programming Fundamentals 101"
        lblTitle.Font = New Font("Segoe UI", 28, FontStyle.Bold)
        lblTitle.ForeColor = Color.White
        lblTitle.Location = New Point(80, 15)
        lblTitle.Size = New Size(700, 45)
        lblTitle.TextAlign = ContentAlignment.MiddleLeft
        lblTitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' 
        ' lblSubtitle - Responsive Subtitle
        ' 
        lblSubtitle.AutoSize = False
        lblSubtitle.Text = "Object-Oriented Programming · Visual Basic .NET · Enterprise Edition"
        lblSubtitle.Font = New Font("Segoe UI", 11, FontStyle.Regular)
        lblSubtitle.ForeColor = Color.FromArgb(178, 190, 195)
        lblSubtitle.Location = New Point(80, 60)
        lblSubtitle.Size = New Size(700, 25)
        lblSubtitle.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right

        ' 
        ' btnMenuToggle - Hamburger Menu with Hover Effects
        ' 
        btnMenuToggle.BackColor = Color.FromArgb(52, 152, 219)
        btnMenuToggle.FlatStyle = FlatStyle.Flat
        btnMenuToggle.FlatAppearance.BorderSize = 0
        btnMenuToggle.Font = New Font("Segoe UI", 18, FontStyle.Bold)
        btnMenuToggle.ForeColor = Color.White
        btnMenuToggle.Location = New Point(15, 25)
        btnMenuToggle.Size = New Size(50, 50)
        btnMenuToggle.Text = "☰"
        btnMenuToggle.Cursor = Cursors.Hand
        btnMenuToggle.Anchor = AnchorStyles.Top Or AnchorStyles.Left
        tooltipProvider.SetToolTip(btnMenuToggle, "Toggle Navigation Menu")
        AddHandler btnMenuToggle.Click, AddressOf btnMenuToggle_Click
        AddHandler btnMenuToggle.MouseEnter, Sub(s, e)
                                                 btnMenuToggle.BackColor = Color.FromArgb(41, 128, 185)
                                             End Sub
        AddHandler btnMenuToggle.MouseLeave, Sub(s, e)
                                                 btnMenuToggle.BackColor = Color.FromArgb(52, 152, 219)
                                             End Sub

        ' 
        ' btnThemeToggle - Dark/Light Mode Toggle
        ' 
        btnThemeToggle.BackColor = Color.FromArgb(46, 204, 113)
        btnThemeToggle.FlatStyle = FlatStyle.Flat
        btnThemeToggle.FlatAppearance.BorderSize = 0
        btnThemeToggle.Font = New Font("Segoe UI", 14, FontStyle.Bold)
        btnThemeToggle.ForeColor = Color.White
        btnThemeToggle.Location = New Point(1320, 25)
        btnThemeToggle.Size = New Size(50, 50)
        btnThemeToggle.Text = "🌙"
        btnThemeToggle.Cursor = Cursors.Hand
        btnThemeToggle.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        tooltipProvider.SetToolTip(btnThemeToggle, "Toggle Dark/Light Theme")
        AddHandler btnThemeToggle.Click, AddressOf btnThemeToggle_Click
        AddHandler btnThemeToggle.MouseEnter, Sub(s, e)
                                                  btnThemeToggle.BackColor = Color.FromArgb(39, 174, 96)
                                              End Sub
        AddHandler btnThemeToggle.MouseLeave, Sub(s, e)
                                                  btnThemeToggle.BackColor = Color.FromArgb(46, 204, 113)
                                              End Sub

        ' 
        ' pnlSidebar - Modern Sidebar Navigation with Responsive Width
        ' 
        pnlSidebar.BackColor = Color.FromArgb(37, 41, 46)
        pnlSidebar.Dock = DockStyle.Left
        pnlSidebar.Width = 280
        pnlSidebar.Padding = New Padding(0, 120, 0, 0)
        pnlSidebar.MinimumSize = New Size(60, 0)
        pnlSidebar.AutoScroll = True

        ' 
        ' pnlContent - Main Content Area with Responsive Layout
        ' 
        pnlContent.BackColor = Color.FromArgb(240, 242, 245)
        pnlContent.Dock = DockStyle.Fill
        pnlContent.Padding = New Padding(30, 20, 30, 20)
        pnlContent.Controls.Add(flpModules)
        pnlContent.Controls.Add(txtSearch)
        pnlContent.Controls.Add(lblWelcome)
        pnlContent.AutoScroll = True

        ' 
        ' lblWelcome - Section Header
        ' 
        lblWelcome.Dock = DockStyle.Top
        lblWelcome.Text = "📚 Learning Modules"
        lblWelcome.Font = New Font("Segoe UI", 20, FontStyle.Bold)
        lblWelcome.ForeColor = Color.FromArgb(45, 52, 54)
        lblWelcome.Height = 50
        lblWelcome.Padding = New Padding(0, 10, 0, 10)

        ' 
        ' txtSearch - Modern Search Box
        ' 
        txtSearch.Dock = DockStyle.Top
        txtSearch.Font = New Font("Segoe UI", 12, FontStyle.Regular)
        txtSearch.ForeColor = Color.FromArgb(99, 110, 114)
        txtSearch.BackColor = Color.White
        txtSearch.Height = 40
        txtSearch.BorderStyle = BorderStyle.None
        txtSearch.Margin = New Padding(0, 10, 0, 10)
        txtSearch.Padding = New Padding(15, 10, 15, 10)
        txtSearch.PlaceholderText = "🔍 Search modules..."
        txtSearch.MaxLength = 100
        AddHandler txtSearch.TextChanged, AddressOf txtSearch_TextChanged

        ' 
        ' flpModules - Responsive Card Container
        ' 
        flpModules.Dock = DockStyle.Fill
        flpModules.Padding = New Padding(0, 10, 0, 0)
        flpModules.AutoScroll = True
        flpModules.WrapContents = True

        ' 
        ' pnlFooter - Modern Footer
        ' 
        pnlFooter.BackColor = Color.FromArgb(45, 52, 54)
        pnlFooter.Dock = DockStyle.Bottom
        pnlFooter.Height = 45
        pnlFooter.Controls.Add(lblFooter)
        pnlFooter.Controls.Add(lblVersion)

        ' 
        ' lblFooter
        ' 
        lblFooter.Dock = DockStyle.Left
        lblFooter.Text = "© 2024 Programming Fundamentals 101 | Enterprise Edition"
        lblFooter.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblFooter.ForeColor = Color.FromArgb(178, 190, 195)
        lblFooter.TextAlign = ContentAlignment.MiddleLeft
        lblFooter.Padding = New Padding(30, 0, 0, 0)
        lblFooter.AutoSize = True

        ' 
        ' lblVersion
        ' 
        lblVersion.Dock = DockStyle.Right
        lblVersion.Text = "Version 2.0.0 | .NET 8.0"
        lblVersion.Font = New Font("Segoe UI", 9, FontStyle.Regular)
        lblVersion.ForeColor = Color.FromArgb(178, 190, 195)
        lblVersion.TextAlign = ContentAlignment.MiddleRight
        lblVersion.Padding = New Padding(0, 0, 30, 0)
        lblVersion.AutoSize = True

        ' 
        ' animationTimer - For smooth animations
        ' 
        animationTimer.Interval = 16  ' ~60 FPS
        AddHandler animationTimer.Tick, AddressOf AnimationTimer_Tick

        ' 
        ' tooltipProvider - Enterprise tooltips
        ' 
        tooltipProvider.AutoPopDelay = 5000
        tooltipProvider.InitialDelay = 500
        tooltipProvider.ReshowDelay = 100
        tooltipProvider.ShowAlways = True
        tooltipProvider.ToolTipIcon = ToolTipIcon.Info

        ' 
        ' Form1 - Main Application Window
        ' 
        AutoScaleDimensions = New SizeF(96.0F, 96.0F)
        AutoScaleMode = AutoScaleMode.Dpi
        ClientSize = New Size(1400, 850)
        Controls.Add(pnlContent)
        Controls.Add(pnlSidebar)
        Controls.Add(pnlHeader)
        Controls.Add(pnlFooter)
        StartPosition = FormStartPosition.CenterScreen
        Text = "PF101 - Programming Fundamentals | Enterprise Learning Platform"
        MinimumSize = New Size(1200, 700)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)

        pnlSidebar.ResumeLayout(False)
        pnlHeader.ResumeLayout(False)
        pnlContent.ResumeLayout(False)
        pnlContent.PerformLayout()
        flpModules.ResumeLayout(False)
        pnlFooter.ResumeLayout(False)
        pnlFooter.PerformLayout()
        ResumeLayout(False)
    End Sub

    ' Modern UI Components
    Friend WithEvents pnlHeader As Panel
    Friend WithEvents pnlSidebar As Panel
    Friend WithEvents pnlContent As Panel
    Friend WithEvents pnlFooter As Panel
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblSubtitle As Label
    Friend WithEvents lblWelcome As Label
    Friend WithEvents lblFooter As Label
    Friend WithEvents lblVersion As Label
    Friend WithEvents btnMenuToggle As Button
    Friend WithEvents btnThemeToggle As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents flpModules As FlowLayoutPanel
    Friend WithEvents animationTimer As Timer
    Friend WithEvents tooltipProvider As ToolTip

    ' Module Cards
    Friend cardOOP As Panel
    Friend cardLoops As Panel
    Friend cardDecisions As Panel
    Friend cardOperators As Panel
    Friend cardArrays As Panel
    Friend cardGames As Panel

End Class
