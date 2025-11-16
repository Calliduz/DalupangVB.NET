Imports System.Runtime.InteropServices
Imports System.ComponentModel

''' <summary>
''' Main Navigation Hub - Enterprise Learning Platform
''' Modern responsive card-based interface with sidebar navigation
''' Implements: Responsive Design, Theme Management, Search, Lazy Loading
''' </summary>
Public Class Form1
    Inherits Form

#Region "Private Fields"

    Private _sidebarExpanded As Boolean = AppConfiguration.UISettings.SidebarDefaultExpanded
    Private _currentTheme As AppTheme = AppTheme.Light
    Private _sidebarAnimationStep As Integer = 0
    Private _targetSidebarWidth As Integer = EnterpriseDesignSystem.SidebarSettings.WidthExpanded
    Private _allModuleCards As New List(Of ModuleCardInfo)
    Private _isDarkMode As Boolean = False
    Private ReadOnly _logger As New SimpleLogger()

#End Region

#Region "Form Initialization"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            _logger.Log($"{AppConfiguration.AppInfo.Name} v{AppConfiguration.AppInfo.Version} starting...")
            InitializeModernUI()
            ApplyModernTheme()
            InitializeModuleData()
            LoadModules()
            CreateSidebarNavigation()
            ShowWelcomeAnimation()
            AddHandler Me.Resize, AddressOf Form1_Resize
            _logger.Log("Application initialized successfully")
        Catch ex As Exception
            _logger.LogError("Initialization error", ex)
            ShowErrorMessage("Failed to initialize application", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Initialize modern UI components with performance optimizations
    ''' </summary>
    Private Sub InitializeModernUI()
        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
  ControlStyles.AllPaintingInWmPaint Or
            ControlStyles.UserPaint Or
       ControlStyles.ResizeRedraw, True)
            Me.UpdateStyles()
        End If

        ' Enable smooth animations
        If Not DesignMode Then
            animationTimer.Enabled = False
            animationTimer.Interval = EnterpriseDesignSystem.GetTimerInterval(EnterpriseDesignSystem.FrameRates.Smooth)
        End If
    End Sub

    ''' <summary>
    ''' Initialize module data structure for search and filtering
    ''' </summary>
    Private Sub InitializeModuleData()
        _allModuleCards.Clear()

        ' Define all modules with metadata using design system colors
        If AppConfiguration.Modules.OOPEnabled Then
            _allModuleCards.Add(New ModuleCardInfo With {
                .Title = "🎯 Object-Oriented Programming",
       .Description = AppConfiguration.Modules.OOPDescription,
      .Topics = "Polymorphism • Encapsulation • Inheritance • Interfaces",
                .AccentColor = EnterpriseDesignSystem.ModuleColors.OOP,
     .Category = "Core Concepts",
      .Keywords = "oop object oriented class polymorphism encapsulation inheritance interface",
        .ClickAction = Sub() ShowOOPModule(Nothing, Nothing)
            })
        End If

        If AppConfiguration.Modules.LoopsEnabled Then
            _allModuleCards.Add(New ModuleCardInfo With {
       .Title = "🔁 Loops & Iteration",
        .Description = AppConfiguration.Modules.LoopsDescription,
  .Topics = "For...Next • Do...While • Nested Loops • For Each",
        .AccentColor = EnterpriseDesignSystem.ModuleColors.Loops,
      .Category = "Core Concepts",
  .Keywords = "loop iteration for next do while foreach repeat",
       .ClickAction = Sub() ShowLoopsModule(Nothing, Nothing)
            })
        End If

        If AppConfiguration.Modules.DecisionsEnabled Then
            _allModuleCards.Add(New ModuleCardInfo With {
              .Title = "🎯 Decision Logic",
            .Description = AppConfiguration.Modules.DecisionsDescription,
          .Topics = "If Statements • Select Case • Nested Conditions",
     .AccentColor = EnterpriseDesignSystem.ModuleColors.Decisions,
           .Category = "Core Concepts",
.Keywords = "if else decision condition select case switch logic",
  .ClickAction = Sub() ShowDecisionsModule(Nothing, Nothing)
            })
        End If

        If AppConfiguration.Modules.OperatorsEnabled Then
            _allModuleCards.Add(New ModuleCardInfo With {
     .Title = "🔢 Operators & Expressions",
  .Description = AppConfiguration.Modules.OperatorsDescription,
     .Topics = "Math • Logical • Relational • Boolean Logic",
     .AccentColor = EnterpriseDesignSystem.ModuleColors.Operators,
        .Category = "Core Concepts",
 .Keywords = "operator math logical relational expression calculation",
    .ClickAction = Sub() ShowOperatorsModule(Nothing, Nothing)
     })
        End If

        If AppConfiguration.Modules.DataStructuresEnabled Then
            _allModuleCards.Add(New ModuleCardInfo With {
    .Title = "📊 Data Structures",
    .Description = AppConfiguration.Modules.DataStructuresDescription,
                .Topics = "Arrays • Lists • Collections • For Each Loop",
  .AccentColor = EnterpriseDesignSystem.ModuleColors.DataStructures,
                .Category = "Practical",
                .Keywords = "array list data structure collection months days",
      .ClickAction = Sub() ShowArraysModule(Nothing, Nothing)
            })
        End If

        If AppConfiguration.Modules.GamesEnabled Then
            _allModuleCards.Add(New ModuleCardInfo With {
  .Title = "🎮 Logic Games & Puzzles",
             .Description = AppConfiguration.Modules.GamesDescription,
          .Topics = "Truth Tables • Missionaries & Cannibals • Algorithms",
  .AccentColor = EnterpriseDesignSystem.ModuleColors.Games,
      .Category = "Practical",
      .Keywords = "game puzzle logic truth table missionaries cannibals problem",
   .ClickAction = Sub() ShowGamesModule(Nothing, Nothing)
            })
        End If
    End Sub

#End Region

#Region "Responsive Design"

    Private Sub Form1_Resize(sender As Object, e As EventArgs)
        Try
            AdjustLayoutForScreenSize()
        Catch ex As Exception
            _logger.LogError("Resize error", ex)
        End Try
    End Sub

    Private Sub AdjustLayoutForScreenSize()
        Dim availableWidth As Integer = pnlContent.Width - (EnterpriseDesignSystem.Spacing.Large * 2)
        Dim cardWidth As Integer = EnterpriseDesignSystem.GetResponsiveCardWidth(availableWidth)

        ' Update card widths with min/max constraints
        For Each ctrl As Control In flpModules.Controls
            If TypeOf ctrl Is Panel Then
                ctrl.Width = EnterpriseDesignSystem.Clamp(cardWidth,
     EnterpriseDesignSystem.LayoutSettings.CardMinWidth,
          EnterpriseDesignSystem.LayoutSettings.CardMaxWidth)
            End If
        Next

        ' Adjust header title size for smaller screens
        If Me.Width < EnterpriseDesignSystem.Breakpoints.Desktop Then
            lblTitle.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H2, FontStyle.Bold)
            lblSubtitle.Visible = False
        Else
            lblTitle.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Hero, FontStyle.Bold)
            lblSubtitle.Visible = True
        End If
    End Sub

#End Region

#Region "Search Functionality"

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs)
        Try
            If AppConfiguration.Features.EnableSearch Then
                FilterModules(txtSearch.Text.Trim())
            End If
        Catch ex As Exception
            _logger.LogError("Search error", ex)
        End Try
    End Sub

    Private Sub FilterModules(searchQuery As String)
        If String.IsNullOrWhiteSpace(searchQuery) Then
            LoadModules()
            Return
        End If

        ' Filter modules based on search query
        Dim filteredModules = _allModuleCards.Where(Function(m) _
       m.Title.ToLower().Contains(searchQuery.ToLower()) OrElse
         m.Description.ToLower().Contains(searchQuery.ToLower()) OrElse
    m.Topics.ToLower().Contains(searchQuery.ToLower()) OrElse
  m.Keywords.ToLower().Contains(searchQuery.ToLower())
   ).Take(AppConfiguration.Performance.MaxSearchResults).ToList()

        LoadFilteredModules(filteredModules)
    End Sub

    Private Sub LoadFilteredModules(filteredModules As List(Of ModuleCardInfo))
        flpModules.SuspendLayout()
        flpModules.Controls.Clear()

        If filteredModules.Count = 0 Then
            Dim lblNoResults As New Label With {
     .Text = "No modules found matching your search.",
      .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H4),
  .ForeColor = EnterpriseDesignSystem.NeutralColors.Gray500,
        .AutoSize = True,
 .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.Large)
          }
            flpModules.Controls.Add(lblNoResults)
        Else
            For Each moduleInfo In filteredModules
                Dim card = CreateModuleCard(
      moduleInfo.Title,
          moduleInfo.Description,
          moduleInfo.Topics,
        moduleInfo.AccentColor,
      moduleInfo.ClickAction
    )
                flpModules.Controls.Add(card)
            Next
        End If

        flpModules.ResumeLayout()
        AdjustLayoutForScreenSize()
    End Sub

#End Region

#Region "Theme Management"

    Private Sub btnThemeToggle_Click(sender As Object, e As EventArgs)
        Try
            If Not AppConfiguration.Features.EnableDarkMode Then Return

            _isDarkMode = Not _isDarkMode
            ApplyTheme(_isDarkMode)
            _logger.Log($"Theme changed to: {If(_isDarkMode, "Dark", "Light")}")
        Catch ex As Exception
            _logger.LogError("Theme toggle error", ex)
        End Try
    End Sub

    Private Sub ApplyTheme(isDark As Boolean)
        If isDark Then
            ' Dark theme using design system
            pnlContent.BackColor = EnterpriseDesignSystem.DarkTheme.Background
            lblWelcome.ForeColor = EnterpriseDesignSystem.DarkTheme.TextPrimary
            txtSearch.BackColor = EnterpriseDesignSystem.DarkTheme.Surface
            txtSearch.ForeColor = EnterpriseDesignSystem.DarkTheme.TextPrimary
            btnThemeToggle.Text = "☀️"
            tooltipProvider.SetToolTip(btnThemeToggle, "Switch to Light Theme")
        Else
            ' Light theme using design system
            pnlContent.BackColor = EnterpriseDesignSystem.LightTheme.Background
            lblWelcome.ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
            txtSearch.BackColor = EnterpriseDesignSystem.LightTheme.Surface
            txtSearch.ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
            btnThemeToggle.Text = "🌙"
            tooltipProvider.SetToolTip(btnThemeToggle, "Switch to Dark Theme")
        End If

        ' Reload modules to apply theme to cards
        If String.IsNullOrWhiteSpace(txtSearch.Text) Then
            LoadModules()
        Else
            FilterModules(txtSearch.Text)
        End If
    End Sub

    Private Sub ApplyModernTheme()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        _currentTheme = AppTheme.Light
    End Sub

#End Region

#Region "Sidebar Navigation"

    Private Sub CreateSidebarNavigation()
        pnlSidebar.Controls.Clear()

        Dim yPos As Integer = EnterpriseDesignSystem.Spacing.Large

        ' Navigation Categories
        AddNavigationCategory("CORE CONCEPTS", yPos)
        yPos += 40

        AddNavButton("📦 OOP Fundamentals", yPos, AddressOf ShowOOPModule, "Learn Object-Oriented Programming")
        yPos += 55
        AddNavButton("🔁 Loops & Iteration", yPos, AddressOf ShowLoopsModule, "Master loop structures")
        yPos += 55
        AddNavButton("🎯 Decision Logic", yPos, AddressOf ShowDecisionsModule, "Conditional statements")
        yPos += 55
        AddNavButton("🔢 Operators", yPos, AddressOf ShowOperatorsModule, "Math & logic operators")
        yPos += 55

        AddNavigationCategory("PRACTICAL", yPos)
        yPos += 40

        AddNavButton("📊 Data Structures", yPos, AddressOf ShowArraysModule, "Arrays and collections")
        yPos += 55
        AddNavButton("🎮 Logic Games", yPos, AddressOf ShowGamesModule, "Programming puzzles")
        yPos += 55
        AddNavButton("🧮 Calculator", yPos, AddressOf ShowCalculatorModule, "Interactive calculator")
        yPos += 55

        AddNavigationCategory("RESOURCES", yPos)
        yPos += 40

        AddNavButton("❓ Help & Docs", yPos, AddressOf ShowHelpModule, "View documentation")
        yPos += 55
        AddNavButton("ℹ️ About", yPos, AddressOf ShowAboutModule, "About this application")
        yPos += 55
        AddNavButton("🚪 Exit", yPos, AddressOf ExitApplication, "Close application")
    End Sub

    Private Sub AddNavigationCategory(text As String, yPos As Integer)
        Dim lbl As New Label With {
.Text = text,
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Caption, FontStyle.Bold),
          .ForeColor = EnterpriseDesignSystem.DarkTheme.TextTertiary,
            .Location = New Point(EnterpriseDesignSystem.Spacing.Large, yPos),
    .AutoSize = True
        }
        pnlSidebar.Controls.Add(lbl)
    End Sub

    Private Sub AddNavButton(text As String, yPos As Integer, clickHandler As EventHandler, tooltipText As String)
        Dim btn As New Button With {
   .Text = text,
            .Location = New Point(10, yPos),
            .Size = New Size(260, 45),
  .FlatStyle = FlatStyle.Flat,
         .BackColor = EnterpriseDesignSystem.NeutralColors.Gray900,
          .ForeColor = EnterpriseDesignSystem.DarkTheme.TextSecondary,
    .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Regular),
       .TextAlign = ContentAlignment.MiddleLeft,
 .Padding = New Padding(15, 0, 0, 0),
            .Cursor = Cursors.Hand
   }

        btn.FlatAppearance.BorderSize = 0
        btn.FlatAppearance.MouseOverBackColor = EnterpriseDesignSystem.PrimaryColors.Blue
        btn.FlatAppearance.MouseDownBackColor = EnterpriseDesignSystem.PrimaryColors.BlueHover

        If AppConfiguration.Features.EnableTooltips Then
            tooltipProvider.SetToolTip(btn, tooltipText)
        End If

        AddHandler btn.Click, clickHandler
        AddHandler btn.MouseEnter, Sub(s, e)
                                       btn.BackColor = EnterpriseDesignSystem.PrimaryColors.Blue
                                       btn.ForeColor = Color.White
                                   End Sub
        AddHandler btn.MouseLeave, Sub(s, e)
                                       btn.BackColor = EnterpriseDesignSystem.NeutralColors.Gray900
                                       btn.ForeColor = EnterpriseDesignSystem.DarkTheme.TextSecondary
                                   End Sub

        pnlSidebar.Controls.Add(btn)
    End Sub

    Private Sub btnMenuToggle_Click(sender As Object, e As EventArgs)
        Try
            _sidebarExpanded = Not _sidebarExpanded
            _targetSidebarWidth = If(_sidebarExpanded,
     EnterpriseDesignSystem.SidebarSettings.WidthExpanded,
   EnterpriseDesignSystem.SidebarSettings.WidthCollapsed)
            _sidebarAnimationStep = 0

            If AppConfiguration.Features.EnableAnimations Then
                animationTimer.Enabled = True
            Else
                pnlSidebar.Width = _targetSidebarWidth
            End If

            _logger.Log($"Sidebar toggled: {_sidebarExpanded}")
        Catch ex As Exception
            _logger.LogError("Sidebar toggle error", ex)
        End Try
    End Sub

    Private Sub AnimationTimer_Tick(sender As Object, e As EventArgs)
        Try
            Const ANIMATION_STEPS As Integer = 10
            _sidebarAnimationStep += 1

            Dim startWidth As Integer = If(_sidebarExpanded,
       EnterpriseDesignSystem.SidebarSettings.WidthCollapsed,
                EnterpriseDesignSystem.SidebarSettings.WidthExpanded)
            Dim widthDiff As Integer = _targetSidebarWidth - startWidth
            Dim progress As Double = _sidebarAnimationStep / ANIMATION_STEPS

            ' Easing function from design system
            progress = EnterpriseDesignSystem.EaseOutCubic(progress)

            pnlSidebar.Width = CInt(startWidth + (widthDiff * progress))

            If _sidebarAnimationStep >= ANIMATION_STEPS Then
                pnlSidebar.Width = _targetSidebarWidth
                animationTimer.Enabled = False

                ' Hide/show button text when collapsed
                For Each ctrl As Control In pnlSidebar.Controls
                    If TypeOf ctrl Is Button Then
                        If Not _sidebarExpanded Then
                            Dim btn = DirectCast(ctrl, Button)
                            btn.Text = btn.Text.Split(" "c)(0)
                            btn.TextAlign = ContentAlignment.MiddleCenter
                            btn.Padding = New Padding(0)
                        End If
                    End If
                Next

                If _sidebarExpanded Then
                    CreateSidebarNavigation()
                End If
            End If
        Catch ex As Exception
            animationTimer.Enabled = False
            _logger.LogError("Animation error", ex)
        End Try
    End Sub

#End Region

#Region "Module Cards"

    Private Sub CreateModuleCards()
        flpModules.SuspendLayout()
        flpModules.Controls.Clear()

        For Each moduleInfo In _allModuleCards
            Dim card = CreateModuleCard(
    moduleInfo.Title,
moduleInfo.Description,
       moduleInfo.Topics,
        moduleInfo.AccentColor,
     moduleInfo.ClickAction
         )
            flpModules.Controls.Add(card)
        Next

        flpModules.ResumeLayout()
    End Sub

    Private Function CreateModuleCard(title As String, description As String, topics As String,
        accentColor As Color, clickAction As Action) As Panel
        Dim card As New Panel With {
 .Size = New Size(420, 220),
   .Margin = EnterpriseDesignSystem.CreatePadding(10),
  .BackColor = If(_isDarkMode, EnterpriseDesignSystem.DarkTheme.Surface, EnterpriseDesignSystem.LightTheme.Surface),
  .Cursor = Cursors.Hand,
         .Tag = New With {title, description, topics, accentColor}
        }

        ' Custom paint for shadow and border
        AddHandler card.Paint, Sub(s, e)
                                   DrawCardBackground(e.Graphics, card, accentColor)
                               End Sub

        ' Title Label
        Dim lblTitle As New Label With {
            .Text = title,
  .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H4, FontStyle.Bold),
   .ForeColor = If(_isDarkMode, EnterpriseDesignSystem.DarkTheme.TextPrimary, EnterpriseDesignSystem.LightTheme.TextPrimary),
     .Location = New Point(EnterpriseDesignSystem.Spacing.Large, EnterpriseDesignSystem.Spacing.Large),
       .Size = New Size(380, 35),
            .AutoEllipsis = True
  }

        ' Description Label
        Dim lblDesc As New Label With {
            .Text = description,
    .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body),
      .ForeColor = If(_isDarkMode, EnterpriseDesignSystem.DarkTheme.TextSecondary, EnterpriseDesignSystem.LightTheme.TextSecondary),
       .Location = New Point(EnterpriseDesignSystem.Spacing.Large, 60),
        .Size = New Size(380, 40),
        .AutoEllipsis = True
 }

        ' Topics Label
        Dim lblTopics As New Label With {
      .Text = topics,
     .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Caption, FontStyle.Italic),
      .ForeColor = If(_isDarkMode, EnterpriseDesignSystem.DarkTheme.TextTertiary, EnterpriseDesignSystem.LightTheme.TextTertiary),
        .Location = New Point(EnterpriseDesignSystem.Spacing.Large, 110),
  .Size = New Size(380, 45),
        .AutoEllipsis = True
      }

        ' Action Button
        Dim btnExplore As New Button With {
         .Text = "Explore Module →",
       .Location = New Point(EnterpriseDesignSystem.Spacing.Large, 165),
        .Size = EnterpriseDesignSystem.ControlSizes.ButtonMedium,
   .FlatStyle = FlatStyle.Flat,
    .BackColor = accentColor,
    .ForeColor = Color.White,
       .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold),
     .Cursor = Cursors.Hand
        }
        btnExplore.FlatAppearance.BorderSize = 0

        AddHandler btnExplore.Click, Sub(s, e) clickAction()
        AddHandler btnExplore.MouseEnter, Sub(s, e)
                                              btnExplore.BackColor = ControlPaint.Light(accentColor, 0.1F)
                                          End Sub
        AddHandler btnExplore.MouseLeave, Sub(s, e)
                                              btnExplore.BackColor = accentColor
                                          End Sub

        AddHandler card.Click, Sub(s, e) clickAction()

        ' Hover effects for card
        AddHandler card.MouseEnter, Sub(s, e)
                                        card.BackColor = If(_isDarkMode,
  EnterpriseDesignSystem.DarkTheme.SurfaceHover,
       EnterpriseDesignSystem.LightTheme.SurfaceHover)
                                        card.Invalidate()
                                    End Sub
        AddHandler card.MouseLeave, Sub(s, e)
                                        card.BackColor = If(_isDarkMode,
      EnterpriseDesignSystem.DarkTheme.Surface,
     EnterpriseDesignSystem.LightTheme.Surface)
                                        card.Invalidate()
                                    End Sub

        card.Controls.AddRange({lblTitle, lblDesc, lblTopics, btnExplore})

        Return card
    End Function

    Private Sub DrawCardBackground(g As Graphics, card As Panel, accentColor As Color)
        g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

        ' Draw subtle shadow
        If AppConfiguration.UISettings.CardShadowEnabled Then
            Using shadowBrush As New SolidBrush(EnterpriseDesignSystem.ShadowSettings.Medium)
                g.FillRectangle(shadowBrush, 3, 3, card.Width - 3, card.Height - 3)
            End Using
        End If

        ' Draw card background
        Using cardBrush As New SolidBrush(card.BackColor)
            g.FillRectangle(cardBrush, 0, 0, card.Width - 6, card.Height - 6)
        End Using

        ' Draw accent bar
        Using accentBrush As New SolidBrush(accentColor)
            g.FillRectangle(accentBrush, 0, 0, 5, card.Height - 6)
        End Using

        ' Draw border
        Dim borderColor = If(_isDarkMode,
   EnterpriseDesignSystem.DarkTheme.Border,
           EnterpriseDesignSystem.LightTheme.Border)
        Using borderPen As New Pen(borderColor, EnterpriseDesignSystem.Borders.WidthThin)
            g.DrawRectangle(borderPen, 0, 0, card.Width - 6, card.Height - 6)
        End Using
    End Sub

    Private Sub LoadModules()
        CreateModuleCards()
        AdjustLayoutForScreenSize()
    End Sub

#End Region

#Region "Module Navigation Handlers"

    Private Sub ShowOOPModule(sender As Object, e As EventArgs)
        Try
            Dim oopMenu As New ContextMenuStrip With {
    .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
     }
            oopMenu.Items.Add(CreateMenuItem("📦 Polymorphism", Sub() OpenDemoForm(New Polymorphism(), "Polymorphism Demo")))
            oopMenu.Items.Add(CreateMenuItem("🔒 Encapsulation", Sub() OpenDemoForm(New Encapsulation(), "Encapsulation Demo")))
            oopMenu.Items.Add(CreateMenuItem("🧬 Inheritance", Sub() OpenDemoForm(New Form3(), "Inheritance Demo")))
            oopMenu.Items.Add(CreateMenuItem("🔌 Interfaces", Sub() OpenDemoForm(New InterfaceDemo(), "Interface Demo")))
            oopMenu.Items.Add(CreateMenuItem("🏗️ Classes & Methods", Sub() OpenDemoForm(New ClassandMethods(), "Classes and Methods")))
            oopMenu.Show(Cursor.Position)
        Catch ex As Exception
            _logger.LogError("Error showing OOP menu", ex)
        End Try
    End Sub

    Private Sub ShowLoopsModule(sender As Object, e As EventArgs)
        Try
            Dim loopsMenu As New ContextMenuStrip With {
    .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
      }
            loopsMenu.Items.Add(CreateMenuItem("🔁 For...Next Loop", Sub() OpenDemoForm(New ForNextDemo(), "For...Next Loop")))
            loopsMenu.Items.Add(CreateMenuItem("🔄 Do...While Loop", Sub() OpenDemoForm(New DoWhileDemo(), "Do...While Loop")))
            loopsMenu.Show(Cursor.Position)
        Catch ex As Exception
            _logger.LogError("Error showing Loops menu", ex)
        End Try
    End Sub

    Private Sub ShowDecisionsModule(sender As Object, e As EventArgs)
        Try
            Dim decisionsMenu As New ContextMenuStrip With {
              .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
         }
            decisionsMenu.Items.Add(CreateMenuItem("❓ If Statement", Sub() OpenDemoForm(New IfStatementDemo(), "If Statement")))
            decisionsMenu.Items.Add(CreateMenuItem("🔀 Nested If", Sub() OpenDemoForm(New NestedIfDemo(), "Nested If")))
            decisionsMenu.Items.Add(CreateMenuItem("🎯 Select Case", Sub() OpenDemoForm(New SelectCaseDemo(), "Select Case")))
            decisionsMenu.Show(Cursor.Position)
        Catch ex As Exception
            _logger.LogError("Error showing Decisions menu", ex)
        End Try
    End Sub

    Private Sub ShowOperatorsModule(sender As Object, e As EventArgs)
        Try
            Dim opsMenu As New ContextMenuStrip With {
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
    }
            opsMenu.Items.Add(CreateMenuItem("➕ Math Operators", Sub() OpenDemoForm(New FormMathOperators(), "Math Operators")))
            opsMenu.Items.Add(CreateMenuItem("⚖️ Relational Operators", Sub() OpenDemoForm(New FormRelationalOperators(), "Relational Operators")))
            opsMenu.Items.Add(CreateMenuItem("🔗 Logical Operators", Sub() OpenDemoForm(New FormLogicalOperators(), "Logical Operators")))
            opsMenu.Show(Cursor.Position)
        Catch ex As Exception
            _logger.LogError("Error showing Operators menu", ex)
        End Try
    End Sub

    Private Sub ShowArraysModule(sender As Object, e As EventArgs)
        Try
            Dim arraysMenu As New ContextMenuStrip With {
    .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
            }
            arraysMenu.Items.Add(CreateMenuItem("📅 Months in a Year", Sub() OpenDemoForm(New monthsinayear(), "Months Demo")))
            arraysMenu.Items.Add(CreateMenuItem("📆 Days in a Week", Sub() OpenDemoForm(New daysinaweek(), "Days Demo")))
            arraysMenu.Show(Cursor.Position)
        Catch ex As Exception
            _logger.LogError("Error showing Arrays menu", ex)
        End Try
    End Sub

    Private Sub ShowGamesModule(sender As Object, e As EventArgs)
        Try
            Dim gamesMenu As New ContextMenuStrip With {
       .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
            }
            gamesMenu.Items.Add(CreateMenuItem("✓❌ Truth Table", Sub() OpenDemoForm(New TruthTableDemonstration(), "Truth Table")))
            gamesMenu.Items.Add(CreateMenuItem("⛪ Missionaries & Cannibals", Sub() OpenDemoForm(New priestcanniabal2(), "River Crossing Puzzle")))
            gamesMenu.Show(Cursor.Position)
        Catch ex As Exception
            _logger.LogError("Error showing Games menu", ex)
        End Try
    End Sub

    Private Sub ShowCalculatorModule(sender As Object, e As EventArgs)
        Try
            OpenDemoForm(New Form2(), "Calculator")
        Catch ex As Exception
            _logger.LogError("Error showing Calculator", ex)
        End Try
    End Sub

    Private Sub ShowHelpModule(sender As Object, e As EventArgs)
        Try
            MessageBox.Show(
            $"{AppConfiguration.AppInfo.Name}" & vbCrLf & vbCrLf &
 $"{AppConfiguration.AppInfo.Edition}" & vbCrLf & vbCrLf &
      "📚 Features:" & vbCrLf &
   "• Interactive OOP demonstrations" & vbCrLf &
    "• Loop and iteration examples" & vbCrLf &
      "• Decision logic tutorials" & vbCrLf &
     "• Operator demonstrations" & vbCrLf &
  "• Logic games and puzzles" & vbCrLf &
     "• Search and filter modules" & vbCrLf &
   "• Dark/Light theme support" & vbCrLf &
       "• Responsive layout" & vbCrLf & vbCrLf &
     "💡 Tips:" & vbCrLf &
        "• Use the search box to find modules quickly" & vbCrLf &
        "• Toggle the sidebar for more space" & vbCrLf &
    "• Switch between light and dark themes" & vbCrLf &
    "• Resize the window - the layout adapts!",
      "Help & Documentation",
       MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        Catch ex As Exception
            _logger.LogError("Error showing Help", ex)
        End Try
    End Sub

    Private Sub ShowAboutModule(sender As Object, e As EventArgs)
        Try
            MessageBox.Show(
        AppConfiguration.GetFullTitle() & vbCrLf & vbCrLf &
         AppConfiguration.GetVersionString() & vbCrLf &
       $"Build: {AppConfiguration.AppInfo.Build}" & vbCrLf & vbCrLf &
      AppConfiguration.AppInfo.Copyright & vbCrLf & vbCrLf &
    "Enterprise Features:" & vbCrLf &
 "• Responsive card-based design" & vbCrLf &
  "• Smooth animations and transitions" & vbCrLf &
       "• Professional dark/light themes" & vbCrLf &
  "• Real-time search and filtering" & vbCrLf &
        "• Comprehensive error handling" & vbCrLf &
      "• Activity logging" & vbCrLf &
    "• Modern glassmorphism effects" & vbCrLf &
      "• Touch-friendly responsive layout",
    $"About {AppConfiguration.AppInfo.ShortName}",
    MessageBoxButtons.OK,
                MessageBoxIcon.Information
            )
        Catch ex As Exception
            _logger.LogError("Error showing About", ex)
        End Try
    End Sub

    Private Sub ExitApplication(sender As Object, e As EventArgs)
        Try
            Dim result = MessageBox.Show(
 AppConfiguration.Messages.ExitConfirmation,
   "Confirm Exit",
      MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
            )

            If result = DialogResult.Yes Then
                _logger.Log("Application closing...")
                Application.Exit()
            End If
        Catch ex As Exception
            _logger.LogError("Error during exit", ex)
            Application.Exit()
        End Try
    End Sub

    Private Function CreateMenuItem(text As String, clickAction As Action) As ToolStripMenuItem
        Dim item As New ToolStripMenuItem(text) With {
  .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
  }
        AddHandler item.Click, Sub(s, e) clickAction()
        Return item
    End Function

#End Region

#Region "Animation & Effects"

    Private Sub ShowWelcomeAnimation()
        Try
            If Not AppConfiguration.Features.EnableAnimations Then
                lblWelcome.Left = 0
                Return
            End If

            lblWelcome.Location = New Point(-500, lblWelcome.Location.Y)

            Dim timer As New Timer With {.Interval = 10}
            Dim targetX As Integer = lblWelcome.Parent.Padding.Left

            AddHandler timer.Tick, Sub(s, e)
                                       lblWelcome.Left += 25
                                       If lblWelcome.Left >= targetX Then
                                           lblWelcome.Left = targetX
                                           timer.Stop()
                                           timer.Dispose()
                                       End If
                                   End Sub
            timer.Start()
        Catch ex As Exception
            lblWelcome.Left = 0
            _logger.LogError("Animation error", ex)
        End Try
    End Sub

#End Region

#Region "Helper Methods"

    Private Sub OpenDemoForm(form As Form, title As String)
        Try
            _logger.Log($"Opening: {title}")
            form.Text = title
            form.StartPosition = FormStartPosition.CenterScreen

            If Me.Icon IsNot Nothing Then
                form.Icon = Me.Icon
            End If

            form.Show()
        Catch ex As Exception
            _logger.LogError($"Error opening {title}", ex)
            ShowErrorMessage($"Error opening {title}", ex)
        End Try
    End Sub

    Private Sub ShowErrorMessage(message As String, ex As Exception)
        MessageBox.Show(
            $"{message}{vbCrLf}{vbCrLf}Details: {ex.Message}",
    "Error",
 MessageBoxButtons.OK,
      MessageBoxIcon.Error
        )
    End Sub

#End Region

#Region "Data Structures"

    Private Class ModuleCardInfo
        Public Property Title As String
        Public Property Description As String
        Public Property Topics As String
        Public Property AccentColor As Color
        Public Property Category As String
        Public Property Keywords As String
        Public Property ClickAction As Action
    End Class

    Private Class SimpleLogger
        Private ReadOnly _logs As New List(Of String)
        Private ReadOnly _maxLogs As Integer = AppConfiguration.Performance.MaxLogEntries

        Public Sub Log(message As String)
            If Not AppConfiguration.Features.EnableLogging Then Return

            Dim logEntry = $"[{DateTime.Now.ToString(AppConfiguration.Logging.TimestampFormat)}] {message}"

            If _logs.Count >= _maxLogs Then
                _logs.RemoveAt(0)
            End If

            _logs.Add(logEntry)

            If AppConfiguration.Logging.EnableConsoleLogging Then
                Debug.WriteLine(logEntry)
            End If
        End Sub

        Public Sub LogError(message As String, ex As Exception)
            If Not AppConfiguration.Features.EnableLogging Then Return

            Dim logEntry = $"[{DateTime.Now.ToString(AppConfiguration.Logging.TimestampFormat)}] ERROR: {message} - {ex.Message}"

            If _logs.Count >= _maxLogs Then
                _logs.RemoveAt(0)
            End If

            _logs.Add(logEntry)

            If AppConfiguration.Logging.EnableConsoleLogging Then
                Debug.WriteLine(logEntry)
                If AppConfiguration.Logging.IncludeStackTrace Then
                    Debug.WriteLine(ex.StackTrace)
                End If
            End If
        End Sub

        Public Function GetLogs() As List(Of String)
            Return New List(Of String)(_logs)
        End Function
    End Class

#End Region

#Region "Enums"

    Private Enum AppTheme
        Light
        Dark
        System
    End Enum

#End Region

End Class


