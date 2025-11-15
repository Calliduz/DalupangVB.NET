''' <summary>
''' Encapsulation Educational Demonstration
''' Interactive tool for learning data hiding and access control in OOP
''' Enterprise-grade implementation with design system integration
''' </summary>
Public Class Encapsulation
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Encapsulation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyEnterpriseStyles()
        DisplayInstructions()
    End Sub

    Private Sub ApplyEnterpriseStyles()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
        Me.StartPosition = AppConfiguration.UISettings.StartupPositionValue

        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
        End If

        If TextBox1 IsNot Nothing Then
            With TextBox1
                .ReadOnly = True
                .Multiline = True
                .Font = EnterpriseDesignSystem.CreateMonospaceFont(EnterpriseDesignSystem.FontSizes.Body)
                .BackColor = EnterpriseDesignSystem.LightTheme.Surface
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
            End With
        End If

        If Button1 IsNot Nothing Then
            With Button1
                .Text = "🔐 Run Encapsulation Demo"
                .BackColor = EnterpriseDesignSystem.ModuleColors.OOP
                .ForeColor = EnterpriseDesignSystem.NeutralColors.White
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold)
                .FlatStyle = FlatStyle.Flat
                .Size = EnterpriseDesignSystem.ControlSizes.ButtonMedium
                .Cursor = Cursors.Hand
            End With
            Button1.FlatAppearance.BorderSize = 0

            Dim originalColor = Button1.BackColor
            AddHandler Button1.MouseEnter, Sub(s, e)
                                              Button1.BackColor = ControlPaint.Light(originalColor, 0.1F)
                                          End Sub
            AddHandler Button1.MouseLeave, Sub(s, e)
                                             Button1.BackColor = originalColor
                                         End Sub
        End If
    End Sub

    Private Sub DisplayInstructions()
        TextBox1.Text = "═══════════════════════════════════════" & vbCrLf &
                        "🔐 ENCAPSULATION DEMONSTRATION" & vbCrLf &
                        "═══════════════════════════════════════" & vbCrLf & vbCrLf &
                        "Encapsulation bundles data and methods together" & vbCrLf &
                        "and restricts direct access to internal data." & vbCrLf & vbCrLf &
                        "Example: BankAccount class" & vbCrLf &
                        "• Private balance field (hidden)" & vbCrLf &
                        "• Public Deposit method (controlled access)" & vbCrLf &
                        "• Public Withdraw method (controlled access)" & vbCrLf &
                        "• Public GetBalance method (controlled read)" & vbCrLf & vbCrLf &
                        "Benefits:" & vbCrLf &
                        "✓ Data protection" & vbCrLf &
                        "✓ Controlled access" & vbCrLf &
                        "✓ Implementation hiding" & vbCrLf &
                        "✓ Easier maintenance" & vbCrLf & vbCrLf &
                        "Click the button to see encapsulation in action!"
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            TextBox1.AppendText(vbCrLf & "═══════════════════════════════════════" & vbCrLf)
            TextBox1.AppendText("🔄 ENCAPSULATION DEMO - Running..." & vbCrLf)
            TextBox1.AppendText("═══════════════════════════════════════" & vbCrLf & vbCrLf)

            ' Create bank account
            TextBox1.AppendText("1️⃣ Creating new BankAccount..." & vbCrLf)
            Dim account As New BankAccount
            TextBox1.AppendText($"   Initial Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}" & vbCrLf & vbCrLf)

            ' Deposit operations
            TextBox1.AppendText("2️⃣ Performing deposits..." & vbCrLf)
            account.Deposit(1000)
            TextBox1.AppendText($"   Deposited: {FormattingHelper.FormatCurrency(1000)}" & vbCrLf)
            TextBox1.AppendText($"   New Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}" & vbCrLf & vbCrLf)

            account.Deposit(500)
            TextBox1.AppendText($"   Deposited: {FormattingHelper.FormatCurrency(500)}" & vbCrLf)
            TextBox1.AppendText($" New Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}" & vbCrLf & vbCrLf)

            ' Withdraw operation
            TextBox1.AppendText("3️⃣ Performing withdrawal..." & vbCrLf)
            account.Withdraw(300)
            TextBox1.AppendText($"   Withdrew: {FormattingHelper.FormatCurrency(300)}" & vbCrLf)
            TextBox1.AppendText($"   New Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}" & vbCrLf & vbCrLf)

            ' Try invalid operations
            TextBox1.AppendText("4️⃣ Testing encapsulation..." & vbCrLf)

            TextBox1.AppendText("   Attempting negative deposit..." & vbCrLf)
            account.Deposit(-100)
            TextBox1.AppendText($"   ✓ Rejected! Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}" & vbCrLf & vbCrLf)

            TextBox1.AppendText("   Attempting overdraw (withdraw 2000)..." & vbCrLf)
            account.Withdraw(2000)
            TextBox1.AppendText($"   ✓ Rejected! Balance: {FormattingHelper.FormatCurrency(account.GetBalance())}" & vbCrLf & vbCrLf)

            ' Property access
            TextBox1.AppendText("5️⃣ Using property accessor..." & vbCrLf)
            TextBox1.AppendText($"   CurrentBalance property: {FormattingHelper.FormatCurrency(account.CurrentBalance)}" & vbCrLf & vbCrLf)

            TextBox1.AppendText("═══════════════════════════════════════" & vbCrLf)
            TextBox1.AppendText("✅ ENCAPSULATION SUMMARY" & vbCrLf)
            TextBox1.AppendText("═══════════════════════════════════════" & vbCrLf & vbCrLf)

            TextBox1.AppendText("💡 Key Points:" & vbCrLf)
            TextBox1.AppendText("• Private 'balance' field is protected" & vbCrLf)
            TextBox1.AppendText("• Public methods control all access" & vbCrLf)
            TextBox1.AppendText("• Invalid operations are rejected" & vbCrLf)
            TextBox1.AppendText("• Implementation can change without" & vbCrLf)
            TextBox1.AppendText("  affecting external code" & vbCrLf & vbCrLf)
            TextBox1.AppendText("🎯 This is Encapsulation in action!")

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Encapsulation demo executed")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Encapsulation error: {ex.Message}")
            End If
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub

    Private Sub OutlinedLabel1_Click(sender As Object, e As EventArgs) Handles OutlinedLabel1.Click
        ' Event handler preserved
    End Sub
End Class

''' <summary>
''' BankAccount class demonstrating encapsulation
''' Private data with public controlled access methods
''' </summary>
Public Class BankAccount
    Private balance As Decimal ' Private field - encapsulated (hidden from outside)

    ''' <summary>
    ''' Deposit money into the account
    ''' Validates amount before modifying balance
    ''' </summary>
    Public Sub Deposit(amount As Decimal)
        If amount > 0 Then
            balance += amount
        End If
    End Sub

    ''' <summary>
    ''' Withdraw money from the account
    ''' Validates amount and sufficient balance
    ''' </summary>
    Public Sub Withdraw(amount As Decimal)
        If amount > 0 AndAlso amount <= balance Then
            balance -= amount
        End If
    End Sub

    ''' <summary>
    ''' Get current balance
    ''' Read-only access to private field
    ''' </summary>
    Public Function GetBalance() As Decimal
        Return balance
    End Function

    ''' <summary>
    ''' Property example - alternative way to access private data
    ''' Read-only property provides controlled access
    ''' </summary>
    Public ReadOnly Property CurrentBalance As Decimal
        Get
            Return balance
        End Get
    End Property
End Class