Imports System
Imports System.Globalization
Imports System.Text
Imports System.Windows.Forms

''' <summary>
''' Do...While Loop Educational Demonstration
''' Interactive tool for learning condition-based loops
''' Enterprise-grade implementation with design system integration
''' </summary>
Public Class DoWhileDemo
    Inherits Form

#Region "Constants"

    Private ReadOnly MAX_SAFE_ITERATIONS As Integer = AppConfiguration.ValidationRules.MaxSafeIterations
    Private Const DEFAULT_ADD_VALUE As Integer = 1
    Private ReadOnly MIN_VALUE As Integer = AppConfiguration.ValidationRules.MinIntegerValue
    Private ReadOnly MAX_VALUE As Integer = AppConfiguration.ValidationRules.MaxIntegerValue

#End Region

#Region "Form Initialization"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub DoWhileDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        DisplayInstructions()
        SetDefaultValues()
    End Sub

    Private Sub InitializeUI()
        Me.Text = "Do...While Loop - Condition-Based Iteration"
        Me.StartPosition = AppConfiguration.UISettings.StartupPositionValue
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)

        ' Enable performance features
        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        End If

        ConfigureInstructionTextBox()
        ConfigureInputTextBoxes()
        ConfigureOutputListBox()
        ConfigureButtons()
    End Sub

    Private Sub ConfigureInstructionTextBox()
        If txtExample IsNot Nothing Then
            With txtExample
                .ReadOnly = True
                .Multiline = True
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
                .BackColor = ColorHelper.Lighten(EnterpriseDesignSystem.ModuleColors.Loops, 0.9)
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .BorderStyle = BorderStyle.FixedSingle
            End With
        End If
    End Sub

    Private Sub ConfigureInputTextBoxes()
        ConfigureInputBox(txtLimit, "Target limit")
        ConfigureInputBox(txtAdd, "Value to add each iteration")
    End Sub

    Private Sub ConfigureInputBox(textBox As TextBox, tooltip As String)
        If textBox IsNot Nothing Then
            With textBox
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.BodyLarge)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = EnterpriseDesignSystem.LightTheme.Surface
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .Height = EnterpriseDesignSystem.ControlSizes.TextBoxHeight
            End With
        End If
    End Sub

    Private Sub ConfigureOutputListBox()
        If lstOutput IsNot Nothing Then
            With lstOutput
                .Font = EnterpriseDesignSystem.CreateMonospaceFont(EnterpriseDesignSystem.FontSizes.Body)
                .BackColor = EnterpriseDesignSystem.LightTheme.Surface
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .BorderStyle = BorderStyle.FixedSingle
                .SelectionMode = SelectionMode.None
            End With
        End If
    End Sub

    Private Sub ConfigureButtons()
        ConfigureButton(btnRun, "▶️ Run Loop", EnterpriseDesignSystem.ModuleColors.Loops)
        ConfigureButton(btnClear, "🗑️ Clear", EnterpriseDesignSystem.SemanticColors.Danger)
        ConfigureButton(btnClose, "❌ Close", EnterpriseDesignSystem.NeutralColors.Gray600)
    End Sub

    Private Sub ConfigureButton(button As Button, text As String, backColor As Color)
        If button IsNot Nothing Then
            With button
                .Text = text
                .FlatStyle = FlatStyle.Flat
                .BackColor = backColor
                .ForeColor = EnterpriseDesignSystem.NeutralColors.White
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold)
                .Size = EnterpriseDesignSystem.ControlSizes.ButtonMedium
                .Cursor = Cursors.Hand
            End With
            button.FlatAppearance.BorderSize = 0

            ' Add hover effect
            Dim originalColor = backColor
            AddHandler button.MouseEnter, Sub(s, e)
                                              button.BackColor = ControlPaint.Light(originalColor, 0.1F)
                                          End Sub
            AddHandler button.MouseLeave, Sub(s, e)
                                              button.BackColor = originalColor
                                          End Sub
        End If
    End Sub

    Private Sub DisplayInstructions()
        txtExample.Text =
        "🔄 DO...WHILE LOOP DEMONSTRATION" & vbCrLf &
        "═══════════════════════════════════════" & vbCrLf & vbCrLf &
   "Do...While loops continue while a condition is True." & vbCrLf &
            "Great for unknown iteration counts!" & vbCrLf & vbCrLf &
            "📌 Two Variants:" & vbCrLf & vbCrLf &
 "1️⃣ PRE-TEST (Do While):" & vbCrLf &
        "   Do While condition" & vbCrLf &
            "     ' Execute if True" & vbCrLf &
            "   Loop" & vbCrLf &
       "   → Checks BEFORE first iteration" & vbCrLf & vbCrLf &
         "2️⃣ POST-TEST (Do...Loop While):" & vbCrLf &
            "   Do" & vbCrLf &
         "     ' Always executes once" & vbCrLf &
        "   Loop While condition" & vbCrLf &
            "   → Checks AFTER each iteration" & vbCrLf & vbCrLf &
         "🎯 Scenario: Accumulate sum until limit reached" & vbCrLf &
        "💡 Enter target limit and value to add!"
    End Sub

    Private Sub SetDefaultValues()
        txtLimit.Text = "100"
        txtAdd.Text = "7"
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        lstOutput.Items.Clear()

        Dim limitValue As Integer
        Dim addValue As Integer

        If Not ValidateInputs(limitValue, addValue) Then
            Return
        End If

        AddLoopHeader(limitValue, addValue)
        ExecuteDoLoopWhile(limitValue, addValue)
        lstOutput.Items.Add("")
        ExecuteDoWhileLoop(limitValue, addValue)
        lstOutput.Items.Add("")
        ShowVariantComparison(limitValue, addValue)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstOutput.Items.Clear()
        SetDefaultValues()
        txtLimit.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Input Validation"

    Private Function ValidateInputs(ByRef limitVal As Integer, ByRef addVal As Integer) As Boolean
        ' Use enterprise validation helpers
        Dim limitValidation = ValidationHelper.IsInteger(txtLimit.Text, "Limit")
        If Not limitValidation.IsValid Then
            MessageBox.Show(limitValidation.ErrorMessage, "Validation Error",
           MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLimit.Focus()
            Return False
        End If
        limitVal = Integer.Parse(txtLimit.Text)

        If String.IsNullOrWhiteSpace(txtAdd.Text) Then
            addVal = DEFAULT_ADD_VALUE
        Else
            Dim addValidation = ValidationHelper.IsInteger(txtAdd.Text, "Add Value")
            If Not addValidation.IsValid Then
                MessageBox.Show(addValidation.ErrorMessage, "Validation Error",
   MessageBoxButtons.OK, MessageBoxIcon.Warning)
                txtAdd.Focus()
                Return False
            End If
            addVal = Integer.Parse(txtAdd.Text)
        End If

        If addVal = 0 Then
            MessageBox.Show("Add value cannot be zero." & vbCrLf & vbCrLf &
          "💡 This would create an infinite loop!",
        "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdd.SelectAll()
            txtAdd.Focus()
            Return False
        End If

        Return ValidateLoopConvergence(limitVal, addVal)
    End Function

    Private Function ValidateLoopConvergence(limitVal As Integer, addVal As Integer) As Boolean
        If limitVal > 0 And addVal < 0 Then
            Dim result = MessageBox.Show(
            "Warning: Adding negative values to reach positive limit." & vbCrLf &
        "This will create many iterations or infinite loop!" & vbCrLf & vbCrLf &
       "Continue anyway?",
    "Loop Convergence Warning",
       MessageBoxButtons.YesNo,
       MessageBoxIcon.Warning
         )
            Return result = DialogResult.Yes
        ElseIf limitVal < 0 And addVal > 0 Then
            MessageBox.Show("Cannot reach negative limit by adding positive values!" & vbCrLf & vbCrLf &
    "💡 Use a negative 'Add' value instead.",
     "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtAdd.SelectAll()
            txtAdd.Focus()
            Return False
        End If

        If addVal <> 0 Then
            Dim estimatedIterations As Integer = Math.Abs(limitVal \ addVal) + 1
            If estimatedIterations > MAX_SAFE_ITERATIONS Then
                Dim result = MessageBox.Show(
       $"This will perform approximately {estimatedIterations:N0} iterations." & vbCrLf & vbCrLf &
             "This may take a while. Continue?",
        "Large Loop Warning",
           MessageBoxButtons.YesNo,
 MessageBoxIcon.Warning
   )
                Return result = DialogResult.Yes
            End If
        End If

        Return True
    End Function

#End Region

#Region "Loop Execution"

    Private Sub AddLoopHeader(limitVal As Integer, addVal As Integer)
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("🔄 DO...WHILE LOOP EXECUTION")
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("")
        lstOutput.Items.Add($"📝 Configuration:")
        lstOutput.Items.Add($"   Target Limit: {FormattingHelper.FormatNumber(limitVal, 0)}")
        lstOutput.Items.Add($"   Add Per Iteration: {FormattingHelper.FormatNumber(addVal, 0)}")
        lstOutput.Items.Add($"   Stop When: sum >= {limitVal}")
        lstOutput.Items.Add("")
    End Sub

    Private Sub ExecuteDoLoopWhile(limitVal As Integer, addVal As Integer)
        lstOutput.Items.Add("🔵 VARIANT 1: Do...Loop While (POST-TEST)")
        lstOutput.Items.Add("   Checks condition AFTER each iteration")
        lstOutput.Items.Add("   → Always executes at least once")
        lstOutput.Items.Add("───────────────────────────────────────")

        Try
            Dim sum As Integer = 0
            Dim iteration As Integer = 0

            lstOutput.BeginUpdate()

            Do
                sum += addVal
                iteration += 1
                Dim status As String = If(sum >= limitVal, "STOP ✓", "CONTINUE")
                lstOutput.Items.Add($"   Iteration {iteration:D3}: sum = {sum,6} | {status}")

                If iteration >= MAX_SAFE_ITERATIONS Then
                    lstOutput.Items.Add($"   ⚠️ Safety limit ({MAX_SAFE_ITERATIONS:N0} iterations)")
                    Exit Do
                End If
            Loop While sum < limitVal

            lstOutput.EndUpdate()

            lstOutput.Items.Add("───────────────────────────────────────")
            lstOutput.Items.Add($" ✓ Stopped: sum ({FormattingHelper.FormatNumber(sum, 0)}) >= limit ({FormattingHelper.FormatNumber(limitVal, 0)})")
            lstOutput.Items.Add($"   ✓ Total Iterations: {FormattingHelper.FormatNumber(iteration, 0)}")

        Catch ex As Exception
            lstOutput.Items.Add($"   ❌ Error: {ex.Message}")
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] DoLoopWhile Error: {ex.Message}")
            End If
        End Try
    End Sub

    Private Sub ExecuteDoWhileLoop(limitVal As Integer, addVal As Integer)
        lstOutput.Items.Add("🟢 VARIANT 2: Do While...Loop (PRE-TEST)")
        lstOutput.Items.Add("   Checks condition BEFORE each iteration")
        lstOutput.Items.Add("   → May not execute if condition false initially")
        lstOutput.Items.Add("───────────────────────────────────────")

        Try
            Dim sum As Integer = 0
            Dim iteration As Integer = 0

            lstOutput.BeginUpdate()

            Do While sum < limitVal
                sum += addVal
                iteration += 1
                Dim status As String = If(sum >= limitVal, "STOP ✓", "CONTINUE")
                lstOutput.Items.Add($"   Iteration {iteration:D3}: sum = {sum,6} | {status}")

                If iteration >= MAX_SAFE_ITERATIONS Then
                    lstOutput.Items.Add($"   ⚠️ Safety limit ({MAX_SAFE_ITERATIONS:N0} iterations)")
                    Exit Do
                End If
            Loop

            lstOutput.EndUpdate()

            lstOutput.Items.Add("───────────────────────────────────────")
            lstOutput.Items.Add($"   ✓ Stopped: sum ({FormattingHelper.FormatNumber(sum, 0)}) >= limit ({FormattingHelper.FormatNumber(limitVal, 0)})")
            lstOutput.Items.Add($"   ✓ Total Iterations: {FormattingHelper.FormatNumber(iteration, 0)}")

            If iteration = 0 Then
                lstOutput.Items.Add($"   ℹ️ Loop never executed (condition false from start)")
            End If

        Catch ex As Exception
            lstOutput.Items.Add($"   ❌ Error: {ex.Message}")
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] DoWhileLoop Error: {ex.Message}")
            End If
        End Try
    End Sub

    Private Sub ShowVariantComparison(limitVal As Integer, addVal As Integer)
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("📊 VARIANT COMPARISON")
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("")
        lstOutput.Items.Add("🔵 Do...Loop While (POST-TEST):")
        lstOutput.Items.Add("   ✓ Executes body first, then checks")
        lstOutput.Items.Add("   ✓ Guaranteed to run at least once")
        lstOutput.Items.Add("   ✓ Good for: User input, menu systems")
        lstOutput.Items.Add("")
        lstOutput.Items.Add("🟢 Do While...Loop (PRE-TEST):")
        lstOutput.Items.Add("   ✓ Checks condition first, then executes")
        lstOutput.Items.Add("   ✓ May not run at all if false")
        lstOutput.Items.Add("   ✓ Good for: Data processing, validation")
        lstOutput.Items.Add("")
        lstOutput.Items.Add("💡 Key Difference:")
        lstOutput.Items.Add("   Post-test: 'Do first, ask later'")
        lstOutput.Items.Add("   Pre-test: 'Ask first, then do'")
    End Sub

#End Region

End Class