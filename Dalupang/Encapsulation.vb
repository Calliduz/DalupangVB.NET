Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Encapsulation Educational Demonstration
''' Enterprise-grade OOP learning tool with professional UI/UX
''' Demonstrates data hiding and controlled access
''' </summary>
Public Class Encapsulation
    Inherits Form

#Region "Private Fields"

    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private pnlFooter As Panel
    Private lblTitle As Label
    Private lblDescription As Label
    Private txtOutput As TextBox
    Private btnRun As Button
    Private btnClear As Button
    Private pnlInstructions As Panel
    Private account As BankAccount

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()

        ' CRITICAL: Clear any designer-created controls immediately
        Me.Controls.Clear()
        Me.BackgroundImage = Nothing

        ' Now build the enterprise UI
        InitializeEnterpriseUI()
    End Sub

#End Region

#Region "Form Initialization"

    Private Sub Encapsulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayWelcomeMessage()
    End Sub

    Private Sub InitializeEnterpriseUI()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
        Me.BackgroundImage = Nothing ' Force remove background

        ' Enable performance optimizations
        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
                        ControlStyles.AllPaintingInWmPaint Or
                        ControlStyles.UserPaint, True)
        End If

        ' CRITICAL: Reverse dock order (bottom-to-top)
        CreateFooter()
        CreateButtons()
        CreateOutputArea()
        CreateInstructions()
        CreateHeader()
    End Sub

    Private Sub CreateHeader()
        ' Header panel with gradient feel
        pnlHeader = New Panel With {
        .Dock = DockStyle.Top,
        .Height = 120,
        .BackColor = EnterpriseDesignSystem.ModuleColors.OOP,
        .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
    }

        ' Title label
        lblTitle = New Label With {
        .Text = "🔐 Encapsulation Demonstration",
        .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H2, FontStyle.Bold),
        .ForeColor = EnterpriseDesignSystem.NeutralColors.White,
        .AutoSize = False,
        .Size = New Size(900, 35),
        .Location = New Point(EnterpriseDesignSystem.Spacing.XLarge, EnterpriseDesignSystem.Spacing.Large)
    }

        ' Description label
        lblDescription = New Label With {
        .Text = "Learn how to protect data and control access through encapsulation",
        .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body),
        .ForeColor = ColorHelper.Lighten(EnterpriseDesignSystem.NeutralColors.White, 0.2),
        .AutoSize = False,
        .Size = New Size(900, 25),
        .Location = New Point(EnterpriseDesignSystem.Spacing.XLarge, 65)
    }

        pnlHeader.Controls.AddRange({lblTitle, lblDescription})
        Me.Controls.Add(pnlHeader)
    End Sub

    Private Sub CreateInstructions()
        ' Instructions panel
        pnlInstructions = New Panel With {
   .Dock = DockStyle.Top,
     .Height = 200,
            .BackColor = EnterpriseDesignSystem.LightTheme.Surface,
 .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
    }

        Dim lblInstructionsTitle = New Label With {
  .Text = "💡 What is Encapsulation?",
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H4, FontStyle.Bold),
            .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary,
        .AutoSize = False,
   .Size = New Size(900, 30),
     .Location = New Point(EnterpriseDesignSystem.Spacing.XLarge, EnterpriseDesignSystem.Spacing.Large)
      }

        Dim lblInstructionsText = New Label With {
      .Text = "Encapsulation bundles data and methods together while restricting direct access to internal data." & vbCrLf & vbCrLf &
     "Example: BankAccount class with private balance field and public methods (Deposit, Withdraw, GetBalance) that control all access. Invalid operations are automatically rejected.",
  .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body),
      .ForeColor = EnterpriseDesignSystem.LightTheme.TextSecondary,
       .AutoSize = False,
      .Size = New Size(900, 110),
      .Location = New Point(EnterpriseDesignSystem.Spacing.XLarge, 60)
      }

        pnlInstructions.Controls.AddRange({lblInstructionsTitle, lblInstructionsText})
        Me.Controls.Add(pnlInstructions)
    End Sub

    Private Sub CreateOutputArea()
        ' Content panel
        pnlContent = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = EnterpriseDesignSystem.LightTheme.Background,
            .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
        }

        ' Output text box
        txtOutput = New TextBox With {
            .Multiline = True,
            .ScrollBars = ScrollBars.Vertical,
            .ReadOnly = True,
            .Dock = DockStyle.Fill,
            .Font = EnterpriseDesignSystem.CreateMonospaceFont(EnterpriseDesignSystem.FontSizes.Body),
            .BackColor = EnterpriseDesignSystem.LightTheme.Surface,
            .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary,
            .BorderStyle = BorderStyle.None,
            .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.Large)
        }

        ' Border panel
        Dim pnlTextBoxBorder = New Panel With {
            .Dock = DockStyle.Fill,
            .BackColor = EnterpriseDesignSystem.LightTheme.Border,
            .Padding = New Padding(1)
        }
        pnlTextBoxBorder.Controls.Add(txtOutput)

        pnlContent.Controls.Add(pnlTextBoxBorder)
        Me.Controls.Add(pnlContent)
    End Sub

    Private Sub CreateButtons()
        ' Button panel
        Dim pnlButtons = New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = EnterpriseDesignSystem.ControlSizes.ButtonMedium.Height + (EnterpriseDesignSystem.Spacing.XLarge * 2),
            .BackColor = EnterpriseDesignSystem.LightTheme.Surface,
            .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
        }

        ' Run button
        btnRun = New Button With {
            .Text = "🏦 Run Bank Account Demo",
            .Size = New Size(220, EnterpriseDesignSystem.ControlSizes.ButtonMedium.Height),
            .Location = New Point(EnterpriseDesignSystem.Spacing.XLarge, EnterpriseDesignSystem.Spacing.Large),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = EnterpriseDesignSystem.SemanticColors.Success,
            .ForeColor = EnterpriseDesignSystem.NeutralColors.White,
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        btnRun.FlatAppearance.BorderSize = 0

        ' Clear button
        btnClear = New Button With {
            .Text = "🗑️ Clear Output",
            .Size = New Size(150, EnterpriseDesignSystem.ControlSizes.ButtonMedium.Height),
            .Location = New Point(btnRun.Right + EnterpriseDesignSystem.Spacing.Medium, EnterpriseDesignSystem.Spacing.Large),
            .FlatStyle = FlatStyle.Flat,
            .BackColor = EnterpriseDesignSystem.SemanticColors.Warning,
            .ForeColor = EnterpriseDesignSystem.NeutralColors.White,
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        btnClear.FlatAppearance.BorderSize = 0

        ' Add hover effects
        AddButtonHoverEffect(btnRun, EnterpriseDesignSystem.SemanticColors.Success)
        AddButtonHoverEffect(btnClear, EnterpriseDesignSystem.SemanticColors.Warning)

        ' Wire up events
        AddHandler btnRun.Click, AddressOf RunDemo_Click
        AddHandler btnClear.Click, AddressOf ClearOutput_Click

        pnlButtons.Controls.AddRange({btnRun, btnClear})
        Me.Controls.Add(pnlButtons)
    End Sub

    Private Sub CreateFooter()
        pnlFooter = New Panel With {
            .Dock = DockStyle.Bottom,
            .Height = 40,
            .BackColor = EnterpriseDesignSystem.ModuleColors.OOP
        }

        Dim lblFooter = New Label With {
            .Text = "Enterprise Learning Platform | Object-Oriented Programming Module",
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Caption),
            .ForeColor = ColorHelper.Lighten(EnterpriseDesignSystem.NeutralColors.White, 0.2),
            .Dock = DockStyle.Fill,
            .TextAlign = ContentAlignment.MiddleCenter
        }

        pnlFooter.Controls.Add(lblFooter)
        Me.Controls.Add(pnlFooter)
    End Sub

    Private Sub AddButtonHoverEffect(btn As Button, originalColor As Color)
        AddHandler btn.MouseEnter, Sub(s, e)
                                       btn.BackColor = ControlPaint.Light(originalColor, 0.2F)
                                   End Sub
        AddHandler btn.MouseLeave, Sub(s, e)
                                       btn.BackColor = originalColor
                                   End Sub
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub DisplayWelcomeMessage()
        txtOutput.Text = "═══════════════════════════════════════════════════════════════" & vbCrLf &
                         "  ENCAPSULATION DEMONSTRATION" & vbCrLf &
                         "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
                         "Welcome! This demonstration shows how encapsulation protects" & vbCrLf &
                         "data and provides controlled access." & vbCrLf & vbCrLf &
                         "Key Concepts:" & vbCrLf &
                         "• Private fields hide implementation details" & vbCrLf &
                         "• Public methods provide controlled access" & vbCrLf &
                         "• Validation prevents invalid operations" & vbCrLf &
                         "• Internal state is protected from external modification" & vbCrLf & vbCrLf &
                         "Click 'Run Bank Account Demo' to see encapsulation in action!" & vbCrLf & vbCrLf &
                         "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub RunDemo_Click(sender As Object, e As EventArgs)
        Try
            txtOutput.Clear()
            account = New BankAccount()

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  🏦 BANK ACCOUNT ENCAPSULATION DEMO")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("Creating new BankAccount instance...")
            output.AppendLine($"Initial Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}")
            output.AppendLine()

            ' Deposit operations
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("DEPOSIT OPERATIONS")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()

            output.AppendLine("Operation: Deposit(1000)")
            account.Deposit(1000)
            output.AppendLine($"✓ Success! New Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}")
            output.AppendLine()

            output.AppendLine("Operation: Deposit(500)")
            account.Deposit(500)
            output.AppendLine($"✓ Success! New Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}")
            output.AppendLine()

            ' Withdrawal operation
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("WITHDRAWAL OPERATION")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()

            output.AppendLine("Operation: Withdraw(300)")
            account.Withdraw(300)
            output.AppendLine($"✓ Success! New Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}")
            output.AppendLine()

            ' Testing encapsulation
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("TESTING ENCAPSULATION (Invalid Operations)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()

            output.AppendLine("Attempting: Deposit(-100)")
            Dim balanceBefore = account.GetBalance()
            account.Deposit(-100)
            output.AppendLine($"✗ Rejected! Negative deposits not allowed")
            output.AppendLine($"  Balance Unchanged: {FormattingHelper.FormatCurrency(account.GetBalance())}")
            output.AppendLine()

            output.AppendLine("Attempting: Withdraw(2000) - more than available")
            account.Withdraw(2000)
            output.AppendLine($"✗ Rejected! Insufficient funds")
            output.AppendLine($"  Balance Unchanged: {FormattingHelper.FormatCurrency(account.GetBalance())}")
            output.AppendLine()

            ' Property access
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("PROPERTY ACCESS (Read-Only)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()

            output.AppendLine($"CurrentBalance Property: {FormattingHelper.FormatCurrency(account.CurrentBalance)}")
            output.AppendLine("Note: Property provides read-only access to private field")
            output.AppendLine()

            ' Summary
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  ✅ ENCAPSULATION BENEFITS DEMONSTRATED")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("✓ Private 'balance' field protected from direct access")
            output.AppendLine("✓ Public methods provide controlled access")
            output.AppendLine("✓ Invalid operations automatically rejected")
            output.AppendLine("✓ Business rules enforced (no negative amounts, no overdrafts)")
            output.AppendLine("✓ Implementation can change without affecting external code")
            output.AppendLine()
            output.AppendLine("This is the power of Encapsulation! 🎯")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Encapsulation demo executed successfully")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Encapsulation error: {ex.Message}")
            End If
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearOutput_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
    End Sub

    ' Preserve existing event handlers
    Private Sub Button1_Click_1(sender As Object, e As EventArgs)
        RunDemo_Click(sender, e)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        ' Compatibility handler
    End Sub

    Private Sub OutlinedLabel1_Click(sender As Object, e As EventArgs)
        ' Compatibility handler
    End Sub

#End Region

End Class

#Region "BankAccount Class"

''' <summary>
''' BankAccount class demonstrating encapsulation principles
''' Private data with public controlled access methods
''' </summary>
Public Class BankAccount
    ' Private field - encapsulated (hidden from outside)
    Private balance As Decimal

    ''' <summary>
    ''' Deposit money - validates amount before modifying balance
    ''' </summary>
    Public Sub Deposit(amount As Decimal)
        If amount > 0 Then
            balance += amount
        End If
    End Sub

    ''' <summary>
    ''' Withdraw money - validates amount and sufficient balance
    ''' </summary>
    Public Sub Withdraw(amount As Decimal)
        If amount > 0 AndAlso amount <= balance Then
            balance -= amount
        End If
    End Sub

    ''' <summary>
    ''' Get current balance - read-only access
    ''' </summary>
    Public Function GetBalance() As Decimal
        Return balance
    End Function

    ''' <summary>
    ''' Property providing read-only access to private field
    ''' </summary>
    Public ReadOnly Property CurrentBalance As Decimal
        Get
            Return balance
        End Get
    End Property
End Class

#End Region