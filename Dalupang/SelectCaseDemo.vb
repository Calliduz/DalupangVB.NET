Imports System.Globalization

''' <summary>
''' Select Case Educational Demonstration
''' Interactive tool for learning switch/case conditional logic
''' Enterprise-grade implementation with design system integration
''' </summary>
Public Class SelectCaseDemo
    Inherits Form

#Region "Constants"

    Private Const MONDAY As Integer = 1
    Private Const FRIDAY As Integer = 5
    Private Const SATURDAY As Integer = 6
    Private Const SUNDAY As Integer = 7
    Private Const GRADE_A_MIN As Integer = 90
    Private Const GRADE_B_MIN As Integer = 80
    Private Const GRADE_C_MIN As Integer = 70
    Private Const GRADE_D_MIN As Integer = 60

#End Region

#Region "Form Initialization"

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SelectCaseDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        DisplayInstructions()
    End Sub

    Private Sub InitializeUI()
        Me.Text = "Select Case - Multi-Way Branching Demonstration"
        Me.StartPosition = AppConfiguration.UISettings.StartupPositionValue
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)

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
                .BackColor = ColorHelper.Lighten(EnterpriseDesignSystem.ModuleColors.Decisions, 0.85)
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
                .BorderStyle = BorderStyle.FixedSingle
            End With
        End If
    End Sub

    Private Sub ConfigureInputTextBox()
        If txtValue IsNot Nothing Then
            With txtValue
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H4)
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
        ConfigureButton(btnEvaluate, "🔄 Evaluate", EnterpriseDesignSystem.PrimaryColors.Blue)
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
    "🔀 SELECT CASE DEMONSTRATION" & vbCrLf &
            "═══════════════════════════════════════" & vbCrLf & vbCrLf &
   "Select Case provides elegant multi-way branching." & vbCrLf &
  "Cleaner than multiple If...ElseIf statements!" & vbCrLf & vbCrLf &
      "📌 Syntax:" & vbCrLf &
            "  Select Case expression" & vbCrLf &
     "    Case value1" & vbCrLf &
            "      ' Execute for value1" & vbCrLf &
"  Case value2 To value3" & vbCrLf &
     "      ' Execute for range" & vbCrLf &
       "    Case Is >= value4" & vbCrLf &
    "      ' Execute for condition" & vbCrLf &
            "    Case Else" & vbCrLf &
"' Default case" & vbCrLf &
        "  End Select" & vbCrLf & vbCrLf &
     "💡 Try These Examples:" & vbCrLf &
  "  • Numbers: 1-7 (days of week)" & vbCrLf &
   "  • Numbers: 0-100 (grades)" & vbCrLf &
            "  • Text: 'red', 'green', 'blue' (colors)" & vbCrLf &
            "  • Text: 'monday', 'friday', etc. (days)"
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs) Handles btnEvaluate.Click
        Try
            lstResults.Items.Clear()

            Dim validation = ValidationHelper.IsNotEmpty(txtValue.Text, "Value")
            If Not validation.IsValid Then
                MessageBox.Show(validation.ErrorMessage & vbCrLf & vbCrLf &
    "💡 Examples: 1, 75, 'red', 'monday'",
     "Input Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
                txtValue.Focus()
                Return
            End If

            Dim inputText As String = txtValue.Text.Trim()
            AddResultHeader(inputText)

            Dim numericValue As Integer
            If Integer.TryParse(inputText, NumberStyles.Integer, CultureInfo.CurrentCulture, numericValue) Then
                DemonstrateNumericCases(numericValue)
            Else
                DemonstrateTextCases(inputText)
            End If

            AddSummary()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] SelectCase evaluated: {inputText}")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] SelectCase error: {ex.Message}")
            End If
            MessageBox.Show(AppConfiguration.Messages.GenericError, "Error",
           MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstResults.Items.Clear()
        txtValue.Clear()
        txtValue.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Numeric Select Case Demonstrations"

    Private Sub DemonstrateNumericCases(value As Integer)
        lstResults.Items.Add("🔢 NUMERIC SELECT CASE EVALUATION")
        lstResults.Items.Add("")
        DemonstrateExactValueMatching(value)
        DemonstrateRangeMatching(value)
        DemonstrateConditionalMatching(value)
        DemonstrateMultipleValues(value)
        DemonstrateGradingSystem(value)
    End Sub

    Private Sub DemonstrateExactValueMatching(value As Integer)
        lstResults.Items.Add("1️⃣ EXACT VALUE MATCHING (Days of Week)")
        lstResults.Items.Add("   Select Case value")

        Select Case value
            Case 1
                lstResults.Items.Add("   Case 1 → ✓ 📅 Monday (Start of work week)")
            Case 2
                lstResults.Items.Add("   Case 2 → ✓ 📅 Tuesday")
            Case 3
                lstResults.Items.Add("   Case 3 → ✓ 📅 Wednesday (Hump day!)")
            Case 4
                lstResults.Items.Add("   Case 4 → ✓ 📅 Thursday")
            Case 5
                lstResults.Items.Add("   Case 5 → ✓ 📅 Friday (Weekend approaching!)")
            Case 6
                lstResults.Items.Add("   Case 6 → ✓ 🌴 Saturday (Weekend!)")
            Case 7
                lstResults.Items.Add("   Case 7 → ✓ 🌅 Sunday (Weekend!)")
            Case Else
                lstResults.Items.Add($"   Case Else → ✓ Invalid day number: {FormattingHelper.FormatNumber(value, 0)}")
        End Select
        lstResults.Items.Add("")
    End Sub

    Private Sub DemonstrateRangeMatching(value As Integer)
        lstResults.Items.Add("2️⃣ RANGE MATCHING (To)")
        lstResults.Items.Add("   Select Case value")

        Select Case value
            Case 1 To 5
                lstResults.Items.Add($"   Case 1 To 5 → ✓ Weekday ({GetDayName(value)})")
            Case 6 To 7
                lstResults.Items.Add($" Case 6 To 7 → ✓ Weekend ({GetDayName(value)})")
            Case Is < 1
                lstResults.Items.Add($"   Case Is < 1 → ✓ Below range ({FormattingHelper.FormatNumber(value, 0)})")
            Case Is > 7
                lstResults.Items.Add($"   Case Is > 7 → ✓ Above range ({FormattingHelper.FormatNumber(value, 0)})")
        End Select
        lstResults.Items.Add("")
    End Sub

    Private Sub DemonstrateConditionalMatching(value As Integer)
        lstResults.Items.Add("3️⃣ CONDITIONAL MATCHING (Is)")
        lstResults.Items.Add("   Select Case value")

        Select Case value
            Case Is < 0
                lstResults.Items.Add($"   Case Is < 0 → ✓ Negative number: {FormattingHelper.FormatNumber(value, 0)}")
            Case Is = 0
                lstResults.Items.Add("   Case Is = 0 → ✓ Zero (neutral)")
            Case Is > 0 And value <= 50
                lstResults.Items.Add($"   Case 1-50 → ✓ Small positive: {FormattingHelper.FormatNumber(value, 0)}")
            Case Is > 50 And value <= 100
                lstResults.Items.Add($"   Case 51-100 → ✓ Large positive: {FormattingHelper.FormatNumber(value, 0)}")
            Case Is > 100
                lstResults.Items.Add($"   Case Is > 100 → ✓ Very large: {FormattingHelper.FormatNumber(value, 0)}")
        End Select
        lstResults.Items.Add("")
    End Sub

    Private Sub DemonstrateMultipleValues(value As Integer)
        lstResults.Items.Add("4️⃣ MULTIPLE VALUES (Comma-separated)")
        lstResults.Items.Add("   Select Case value")

        Select Case value
            Case 1, 3, 5, 7, 9
                lstResults.Items.Add($"   Case 1,3,5,7,9 → ✓ Odd single digit: {value}")
            Case 2, 4, 6, 8
                lstResults.Items.Add($"   Case 2,4,6,8 → ✓ Even single digit: {value}")
            Case 0, 10, 20, 30, 40, 50
                lstResults.Items.Add($"   Case 0,10,20,30... → ✓ Multiple of 10: {value}")
            Case Else
                lstResults.Items.Add($"   Case Else → ✓ Other number: {value}")
        End Select
        lstResults.Items.Add("")
    End Sub

    Private Sub DemonstrateGradingSystem(value As Integer)
        lstResults.Items.Add("5️⃣ GRADING SYSTEM (Practical Example)")
        lstResults.Items.Add("   Select Case score")

        If value >= 0 And value <= 100 Then
            Select Case value
                Case 90 To 100
                    lstResults.Items.Add("   Case 90 To 100 → 🏆 Grade A (Excellent!)")
                Case 80 To 89
                    lstResults.Items.Add("   Case 80 To 89 → ⭐ Grade B (Very Good)")
                Case 70 To 79
                    lstResults.Items.Add("   Case 70 To 79 → 👍 Grade C (Good)")
                Case 60 To 69
                    lstResults.Items.Add("   Case 60 To 69 → 😐 Grade D (Pass)")
                Case 0 To 59
                    lstResults.Items.Add("   Case 0 To 59 → ❌ Grade F (Fail)")
            End Select
        Else
            lstResults.Items.Add($"   Score {value} is out of valid range (0-100)")
        End If
        lstResults.Items.Add("")
    End Sub

#End Region

#Region "Text Select Case Demonstrations"

    Private Sub DemonstrateTextCases(value As String)
        lstResults.Items.Add("📝 TEXT SELECT CASE EVALUATION")
        lstResults.Items.Add("")
        DemonstrateColorMatching(value)
        DemonstrateDayNameMatching(value)
        DemonstrateCommandMatching(value)
    End Sub

    Private Sub DemonstrateColorMatching(value As String)
        lstResults.Items.Add("1️⃣ COLOR MATCHING")
        lstResults.Items.Add($"   Select Case ""{value.ToLowerInvariant()}""")

        Select Case value.ToLowerInvariant()
            Case "red"
                lstResults.Items.Add("   Case 'red' → ✓ 🔴 Red (Primary color)")
            Case "green"
                lstResults.Items.Add("   Case 'green' → ✓ 🟢 Green (Primary color)")
            Case "blue"
                lstResults.Items.Add("   Case 'blue' → ✓ 🔵 Blue (Primary color)")
            Case "yellow"
                lstResults.Items.Add("   Case 'yellow' → ✓ 🟡 Yellow (Secondary color)")
            Case "orange"
                lstResults.Items.Add("   Case 'orange' → ✓ 🟠 Orange (Secondary color)")
            Case "purple", "violet"
                lstResults.Items.Add("   Case 'purple' → ✓ 🟣 Purple (Secondary color)")
            Case Else
                lstResults.Items.Add($"   Case Else → ✓ Unknown color: '{FormattingHelper.TruncateString(value, 20)}'")
        End Select
        lstResults.Items.Add("")
    End Sub

    Private Sub DemonstrateDayNameMatching(value As String)
        lstResults.Items.Add("2️⃣ DAY NAME MATCHING")
        lstResults.Items.Add($"   Select Case ""{value.ToLowerInvariant()}""")

        Select Case value.ToLowerInvariant()
            Case "monday", "mon"
                lstResults.Items.Add("   Case 'monday' → ✓ 💼 Start of work week")
            Case "tuesday", "tue"
                lstResults.Items.Add("   Case 'tuesday' → ✓ 📊 Second work day")
            Case "wednesday", "wed"
                lstResults.Items.Add("   Case 'wednesday' → ✓ 🐫 Hump day!")
            Case "thursday", "thu"
                lstResults.Items.Add("   Case 'thursday' → ✓ ⚡ Almost there!")
            Case "friday", "fri"
                lstResults.Items.Add("   Case 'friday' → ✓ 🎉 Weekend incoming!")
            Case "saturday", "sat"
                lstResults.Items.Add("   Case 'saturday' → ✓ 🌴 Weekend!")
            Case "sunday", "sun"
                lstResults.Items.Add("   Case 'sunday' → ✓ 🌅 Rest day!")
            Case Else
                lstResults.Items.Add($"   Case Else → ✓ Not a day name: '{FormattingHelper.TruncateString(value, 20)}'")
        End Select
        lstResults.Items.Add("")
    End Sub

    Private Sub DemonstrateCommandMatching(value As String)
        lstResults.Items.Add("3️⃣ COMMAND MATCHING")
        lstResults.Items.Add($"   Select Case ""{value.ToLowerInvariant()}""")

        Select Case value.ToLowerInvariant()
            Case "start", "begin", "go"
                lstResults.Items.Add("   Case 'start/begin/go' → ✓ ▶️ Start command")
            Case "stop", "end", "quit"
                lstResults.Items.Add("   Case 'stop/end/quit' → ✓ ⏹️ Stop command")
            Case "pause", "wait"
                lstResults.Items.Add("   Case 'pause/wait' → ✓ ⏸️ Pause command")
            Case "help", "?"
                lstResults.Items.Add("   Case 'help or ?' → ✓ ❓ Help requested")
            Case Else
                lstResults.Items.Add($"   Case Else → ✓ Unknown command: '{FormattingHelper.TruncateString(value, 20)}'")
        End Select
        lstResults.Items.Add("")
    End Sub

#End Region

#Region "Helper Methods"

    Private Sub AddResultHeader(value As String)
        lstResults.Items.Add("═══════════════════════════════════════")
        lstResults.Items.Add($"📥 Input: {FormattingHelper.TruncateString(value, 30)}")
        lstResults.Items.Add("═══════════════════════════════════════")
        lstResults.Items.Add("")
    End Sub

    Private Sub AddSummary()
        lstResults.Items.Add("═══════════════════════════════════════")
        lstResults.Items.Add("✅ Select Case Evaluation Complete!")
        lstResults.Items.Add("💡 Try different values to explore more patterns")
    End Sub

    Private Function GetDayName(dayNumber As Integer) As String
        Select Case dayNumber
            Case 1 : Return "Monday"
            Case 2 : Return "Tuesday"
            Case 3 : Return "Wednesday"
            Case 4 : Return "Thursday"
            Case 5 : Return "Friday"
            Case 6 : Return "Saturday"
            Case 7 : Return "Sunday"
            Case Else : Return "Unknown"
        End Select
    End Function

#End Region

End Class