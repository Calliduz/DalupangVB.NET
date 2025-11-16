Imports System
Imports System.Globalization
Imports System.Windows.Forms

''' <summary>
''' Nested If Statement Educational Demonstration
''' Interactive tool for understanding multi-level conditional logic
''' Enterprise-grade implementation with design system integration
''' </summary>
Public Class NestedIfDemo
    Inherits Form

#Region "Constants"

    Private Const PASSING_THRESHOLD As Integer = 50
    Private Const NEAR_MISS_THRESHOLD As Integer = 45
    Private Const GRADE_A_THRESHOLD As Integer = 90
    Private Const GRADE_B_THRESHOLD As Integer = 75
    Private Const GRADE_C_THRESHOLD As Integer = 60
    Private Const MAX_SCORE As Integer = 100
    Private Const MIN_SCORE As Integer = 0

#End Region

#Region "Form Initialization"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NestedIfDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        DisplayInstructions()
    End Sub

    Private Sub InitializeUI()
        Me.Text = "Nested If - Multi-Level Conditional Logic"
        Me.StartPosition = AppConfiguration.UISettings.StartupPositionValue
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)

        ' Enable performance features
        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or ControlStyles.AllPaintingInWmPaint, True)
        End If

        ConfigureInstructionTextBox()
        ConfigureInputTextBox()
        ConfigureResultsListBox()
        ConfigureButtons()
    End Sub

    Private Sub ConfigureInstructionTextBox()
        If txtExample IsNot Nothing Then
            With txtExample
                .ReadOnly = True
                .Multiline = True
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
                .BackColor = ColorHelper.Lighten(EnterpriseDesignSystem.ModuleColors.Decisions, 0.9)
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .BorderStyle = BorderStyle.FixedSingle
            End With
        End If
    End Sub

    Private Sub ConfigureInputTextBox()
        If txtScore IsNot Nothing Then
            With txtScore
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H4, FontStyle.Bold)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = EnterpriseDesignSystem.LightTheme.Surface
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .Height = EnterpriseDesignSystem.ControlSizes.TextBoxHeight
            End With
        End If
    End Sub

    Private Sub ConfigureResultsListBox()
        If lstResults IsNot Nothing Then
            With lstResults
                .Font = EnterpriseDesignSystem.CreateMonospaceFont(EnterpriseDesignSystem.FontSizes.Body)
                .BackColor = EnterpriseDesignSystem.LightTheme.Surface
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .BorderStyle = BorderStyle.FixedSingle
                .SelectionMode = SelectionMode.None
            End With
        End If
    End Sub

    Private Sub ConfigureButtons()
        ConfigureButton(btnEvaluate, "📊 Evaluate Score", EnterpriseDesignSystem.SemanticColors.Success)
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
  "📚 NESTED IF STATEMENT DEMONSTRATION" & vbCrLf &
      "═══════════════════════════════════════" & vbCrLf & vbCrLf &
         "Nested IF places one conditional inside another." & vbCrLf &
        "This allows complex, multi-level decision making." & vbCrLf & vbCrLf &
     "🎯 Student Grading Scenario:" & vbCrLf &
      "  • Outer If: Check if student passed (≥50)" & vbCrLf &
         "  • Nested If: Determine grade level (A/B/C/D)" & vbCrLf &
     "  • Outer Else: Handle failing scores" & vbCrLf &
  "  • Nested in Else: Check for near-miss" & vbCrLf & vbCrLf &
 "📝 Grading Scale:" & vbCrLf &
            $"  • A: {GRADE_A_THRESHOLD}+ (Excellent)" & vbCrLf &
            $"  • B: {GRADE_B_THRESHOLD}-{GRADE_A_THRESHOLD - 1} (Very Good)" & vbCrLf &
    $"  • C: {GRADE_C_THRESHOLD}-{GRADE_B_THRESHOLD - 1} (Good)" & vbCrLf &
       $"  • D: {PASSING_THRESHOLD}-{GRADE_C_THRESHOLD - 1} (Pass)" & vbCrLf &
  $"  • F: Below {PASSING_THRESHOLD} (Fail)" & vbCrLf & vbCrLf &
     "💡 Enter a score (0-100) and click Evaluate!"
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs) Handles btnEvaluate.Click
        lstResults.Items.Clear()

        Dim score As Integer
        If Not ValidateInput(score) Then
            Return
        End If

        AddResultHeader(score)
        ExecuteNestedIfLogic(score)
        AddVisualSummary(score)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstResults.Items.Clear()
        txtScore.Clear()
        txtScore.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Input Validation"

    Private Function ValidateInput(ByRef outputScore As Integer) As Boolean
        ' Use enterprise validation helper
        Dim validation = ValidationHelper.ValidateAll(
            ValidationHelper.IsNotEmpty(txtScore.Text, "Score"),
  ValidationHelper.IsInteger(txtScore.Text, "Score")
        )

        If Not validation.IsValid Then
            MessageBox.Show(validation.ErrorMessage, "Validation Error",
      MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtScore.Focus()
            Return False
        End If

        outputScore = Integer.Parse(txtScore.Text)

        ' Check range using validation helper
        Dim rangeValidation = ValidationHelper.IsInRange(outputScore, MIN_SCORE, MAX_SCORE, "Score")
        If Not rangeValidation.IsValid Then
            MessageBox.Show(rangeValidation.ErrorMessage, "Validation Error",
         MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtScore.SelectAll()
            txtScore.Focus()
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Nested IF Logic Execution"

    Private Sub AddResultHeader(score As Integer)
        lstResults.Items.Add("═══════════════════════════════════════")
        lstResults.Items.Add($"📊 Student Score: {FormattingHelper.FormatNumber(score, 0)}/{MAX_SCORE}")
        lstResults.Items.Add("═══════════════════════════════════════")
        lstResults.Items.Add("")
    End Sub

    Private Sub ExecuteNestedIfLogic(score As Integer)
        lstResults.Items.Add("🔍 NESTED IF EVALUATION:")
        lstResults.Items.Add("")

        ' OUTER IF: Check passing threshold
        lstResults.Items.Add($"┌─ OUTER IF: Is score >= {PASSING_THRESHOLD}?")

        If score >= PASSING_THRESHOLD Then
            ' PASSED - Enter nested IF for grading
            lstResults.Items.Add($"│  ✓ YES - Score {score} meets passing threshold")
            lstResults.Items.Add("│")
            lstResults.Items.Add("├─ NESTED IF: Determine grade level...")

            If score >= GRADE_A_THRESHOLD Then
                lstResults.Items.Add($"│  └─ If score >= {GRADE_A_THRESHOLD}? ✓ YES")
                lstResults.Items.Add("│     🏆 Grade: A (Excellent!)")
                lstResults.Items.Add("│     Outstanding performance!")
            Else
                If score >= GRADE_B_THRESHOLD Then
                    lstResults.Items.Add($"│  └─ If score >= {GRADE_B_THRESHOLD}? ✓ YES")
                    lstResults.Items.Add("│     ⭐ Grade: B (Very Good)")
                    lstResults.Items.Add("│     Above average performance!")
                Else
                    If score >= GRADE_C_THRESHOLD Then
                        lstResults.Items.Add($"│  └─ If score >= {GRADE_C_THRESHOLD}? ✓ YES")
                        lstResults.Items.Add("│     👍 Grade: C (Good)")
                        lstResults.Items.Add("│     Satisfactory performance!")
                    Else
                        lstResults.Items.Add($"│  └─ Score is between {PASSING_THRESHOLD}-{GRADE_C_THRESHOLD - 1}")
                        lstResults.Items.Add("│     😐 Grade: D (Barely Passed)")
                        lstResults.Items.Add("│     Passed, but needs improvement!")
                    End If
                End If
            End If
        Else
            ' FAILED - Enter nested IF in ELSE block
            lstResults.Items.Add($"│  ✗ NO - Score {score} below passing threshold")
            lstResults.Items.Add("│")
            lstResults.Items.Add("└─ OUTER ELSE: Student did not pass")
            lstResults.Items.Add("")
            lstResults.Items.Add("├─ NESTED IF in ELSE: Check severity...")

            If score >= NEAR_MISS_THRESHOLD Then
                lstResults.Items.Add($"   │  └─ If score >= {NEAR_MISS_THRESHOLD}? ✓ YES")
                lstResults.Items.Add("   │ ⚠️ Status: Near Miss")
                lstResults.Items.Add("   │     Consider remedial work or retake")
            Else
                lstResults.Items.Add($"   │  └─ Score < {NEAR_MISS_THRESHOLD}? ✓ YES")
                lstResults.Items.Add("   │ ❌ Status: Significant Gap")
                lstResults.Items.Add("   │   Retake required")
            End If
        End If

        lstResults.Items.Add("")
    End Sub

    Private Sub AddVisualSummary(score As Integer)
        lstResults.Items.Add("═══════════════════════════════════════")
        lstResults.Items.Add("📈 VISUAL SUMMARY:")
        lstResults.Items.Add("")

        ' Progress bar representation
        Dim progressBar As String = GenerateProgressBar(score)
        lstResults.Items.Add($"Progress: {progressBar} {FormattingHelper.FormatPercentage(score / 100.0)}")
        lstResults.Items.Add("")

        ' Grade badge
        Dim gradeBadge As String = GetGradeBadge(score)
        lstResults.Items.Add($"Final Grade: {gradeBadge}")
        lstResults.Items.Add("")

        ' Recommendation
        Dim recommendation As String = GetRecommendation(score)
        lstResults.Items.Add($"💡 Recommendation: {recommendation}")
        lstResults.Items.Add("═══════════════════════════════════════")
    End Sub

#End Region

#Region "Helper Methods"

    Private Function GenerateProgressBar(score As Integer) As String
        Dim barLength As Integer = 20
        Dim filledLength As Integer = CInt((score / 100.0) * barLength)
        Dim emptyLength As Integer = barLength - filledLength

        Dim bar As String = New String("█"c, filledLength) & New String("░"c, emptyLength)
        Return $"[{bar}]"
    End Function

    Private Function GetGradeBadge(score As Integer) As String
        If score >= GRADE_A_THRESHOLD Then
            Return "🏆 A - Excellent"
        ElseIf score >= GRADE_B_THRESHOLD Then
            Return "⭐ B - Very Good"
        ElseIf score >= GRADE_C_THRESHOLD Then
            Return "👍 C - Good"
        ElseIf score >= PASSING_THRESHOLD Then
            Return "😐 D - Pass"
        ElseIf score >= NEAR_MISS_THRESHOLD Then
            Return "⚠️ F - Near Miss"
        Else
            Return "❌ F - Fail"
        End If
    End Function

    Private Function GetRecommendation(score As Integer) As String
        If score >= GRADE_A_THRESHOLD Then
            Return "Keep up the excellent work! Consider advanced courses."
        ElseIf score >= GRADE_B_THRESHOLD Then
            Return "Great job! A bit more effort could get you to an A."
        ElseIf score >= GRADE_C_THRESHOLD Then
            Return "Good work! Focus on weak areas for improvement."
        ElseIf score >= PASSING_THRESHOLD Then
            Return "You passed, but review material and practice more."
        ElseIf score >= NEAR_MISS_THRESHOLD Then
            Return "Very close! A little more study and you'll pass."
        Else
            Return "Significant review needed. Consider tutoring or retake."
        End If
    End Function

#End Region

End Class