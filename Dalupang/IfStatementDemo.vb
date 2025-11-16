Imports System
Imports System.Globalization
Imports System.Windows.Forms

''' <summary>
''' If Statement Educational Demonstration
''' Interactive tool for learning conditional logic and decision structures
''' </summary>
Public Class IfStatementDemo
    Inherits Form

#Region "Constants"

    Private Const GRADE_A_THRESHOLD As Integer = 90
    Private Const GRADE_B_THRESHOLD As Integer = 75
    Private Const GRADE_C_THRESHOLD As Integer = 50
    Private Const GRADE_D_THRESHOLD As Integer = 40

#End Region

#Region "Form Initialization"

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Initialize form and display educational content
    ''' </summary>
    Private Sub IfStatementDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        DisplayInstructions()
    End Sub

    ''' <summary>
    ''' Configure UI elements for optimal user experience
    ''' </summary>
    Private Sub InitializeUI()
        Me.Text = "If Statement - Conditional Logic Demonstration"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Configure text boxes
        ConfigureInstructionTextBox()
        ConfigureInputTextBox()

        ' Configure list box
        ConfigureResultsListBox()

        ' Configure buttons
        ConfigureButtons()
    End Sub

    ''' <summary>
    ''' Configure instruction text box
    ''' </summary>
    Private Sub ConfigureInstructionTextBox()
        If txtExample IsNot Nothing Then
            With txtExample
                .ReadOnly = True
                .Multiline = True
                .Font = New Font("Segoe UI", 10, FontStyle.Regular)
                .BackColor = Color.FromArgb(240, 248, 255)
                .ForeColor = Color.FromArgb(50, 50, 50)
                .BorderStyle = BorderStyle.FixedSingle
            End With
        End If
    End Sub

    ''' <summary>
    ''' Configure input text box
    ''' </summary>
    Private Sub ConfigureInputTextBox()
        If txtValue IsNot Nothing Then
            With txtValue
                .Font = New Font("Segoe UI", 12, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(50, 50, 50)
            End With
        End If
    End Sub

    ''' <summary>
    ''' Configure results list box
    ''' </summary>
    Private Sub ConfigureResultsListBox()
        If lstResults IsNot Nothing Then
            With lstResults
                .Font = New Font("Consolas", 10, FontStyle.Regular)
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(50, 50, 50)
                .BorderStyle = BorderStyle.FixedSingle
                .SelectionMode = SelectionMode.None
            End With
        End If
    End Sub

    ''' <summary>
    ''' Configure button styling
    ''' </summary>
    Private Sub ConfigureButtons()
        ConfigureButton(btnEvaluate, "🔍 Evaluate", Color.FromArgb(70, 130, 180))
        ConfigureButton(btnClear, "🗑️ Clear", Color.FromArgb(220, 53, 69))
        ConfigureButton(btnClose, "❌ Close", Color.FromArgb(108, 117, 125))
    End Sub

    ''' <summary>
    ''' Configure individual button
    ''' </summary>
    Private Sub ConfigureButton(button As Button, text As String, backColor As Color)
        If button IsNot Nothing Then
            With button
                .Text = text
                .FlatStyle = FlatStyle.Flat
                .BackColor = backColor
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 10, FontStyle.Bold)
                .Cursor = Cursors.Hand
            End With
        End If
    End Sub

    ''' <summary>
    ''' Display instructional content
    ''' </summary>
    Private Sub DisplayInstructions()
        txtExample.Text =
       "📘 IF STATEMENT DEMONSTRATION" & vbCrLf &
      "═══════════════════════════════════" & vbCrLf & vbCrLf &
        "The IF statement evaluates a condition and executes code when True." & vbCrLf & vbCrLf &
  "📌 Syntax Patterns:" & vbCrLf &
     "  • Simple If: If condition Then ... End If" & vbCrLf &
        "  • If-Else: If condition Then ... Else ... End If" & vbCrLf &
      "  • If-ElseIf-Else: If ... ElseIf ... Else ... End If" & vbCrLf & vbCrLf &
          "💡 Instructions:" & vbCrLf &
            "  1. Enter a number (0-100)" & vbCrLf &
    "  2. Click 'Evaluate' to see conditional logic in action" & vbCrLf &
          "  3. Observe multiple IF statement variations" & vbCrLf & vbCrLf &
    "✨ Try different values to see how conditions work!"
    End Sub

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' Evaluate input and demonstrate various IF statement patterns
    ''' </summary>
    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs) Handles btnEvaluate.Click
        ' Clear previous results
        lstResults.Items.Clear()

        ' Validate and parse input
        Dim inputValue As Integer
        If Not ValidateInput(inputValue) Then
            Return
        End If

        ' Display results header
        AddResultHeader(inputValue)

        ' Demonstrate different IF patterns
        DemonstrateSimpleIf(inputValue)
        DemonstrateIfElse(inputValue)
        DemonstrateIfElseIf(inputValue)
        DemonstrateComplexConditions(inputValue)
        DemonstrateLogicalOperators(inputValue)

        ' Add summary
        AddResultsSummary()
    End Sub

    ''' <summary>
    ''' Clear all results
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstResults.Items.Clear()
        txtValue.Clear()
        txtValue.Focus()
    End Sub

    ''' <summary>
    ''' Close the demonstration form
    ''' </summary>
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

#End Region

#Region "Input Validation"

    ''' <summary>
    ''' Validate user input and parse to integer
    ''' </summary>
    Private Function ValidateInput(ByRef outputValue As Integer) As Boolean
        Dim inputText As String = txtValue.Text.Trim()

        ' Check for empty input
        If String.IsNullOrWhiteSpace(inputText) Then
            ShowValidationError("Please enter a number.")
            txtValue.Focus()
            Return False
        End If

        ' Try to parse as integer
        If Not Integer.TryParse(inputText, NumberStyles.Integer, CultureInfo.CurrentCulture, outputValue) Then
            ShowValidationError("Please enter a valid integer value.")
            txtValue.SelectAll()
            txtValue.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Display validation error message
    ''' </summary>
    Private Sub ShowValidationError(message As String)
        MessageBox.Show(
   message & vbCrLf & vbCrLf &
      "💡 Tip: Enter any integer (e.g., 85, -10, 0)",
            "Input Validation",
            MessageBoxButtons.OK,
            MessageBoxIcon.Warning
        )
    End Sub

#End Region

#Region "IF Statement Demonstrations"

    ''' <summary>
    ''' Add results header with input value
    ''' </summary>
    Private Sub AddResultHeader(value As Integer)
        lstResults.Items.Add("═══════════════════════════════════")
        lstResults.Items.Add($"📊 Input Value: {value}")
        lstResults.Items.Add("═══════════════════════════════════")
        lstResults.Items.Add("")
    End Sub

    ''' <summary>
    ''' Demonstrate simple IF statement
    ''' </summary>
    Private Sub DemonstrateSimpleIf(value As Integer)
        lstResults.Items.Add("1️⃣ SIMPLE IF STATEMENT")
        lstResults.Items.Add("   If value > 0 Then")

        If value > 0 Then
            lstResults.Items.Add("   ✓ Result: POSITIVE number")
        Else
            lstResults.Items.Add("   ✗ Result: NOT positive (zero or negative)")
        End If
        lstResults.Items.Add("")
    End Sub

    ''' <summary>
    ''' Demonstrate IF...ELSE statement
    ''' </summary>
    Private Sub DemonstrateIfElse(value As Integer)
        lstResults.Items.Add("2️⃣ IF...ELSE STATEMENT")
        lstResults.Items.Add(" If value = 0 Then")

        If value = 0 Then
            lstResults.Items.Add("   ✓ Result: ZERO")
        Else
            lstResults.Items.Add("   ✗ Result: NOT zero")
        End If
        lstResults.Items.Add("")
    End Sub

    ''' <summary>
    ''' Demonstrate IF...ELSEIF...ELSE statement (grading system)
    ''' </summary>
    Private Sub DemonstrateIfElseIf(value As Integer)
        lstResults.Items.Add("3️⃣ IF...ELSEIF...ELSE STATEMENT (Grading)")

        Dim grade As String
        Dim gradeEmoji As String

        If value >= GRADE_A_THRESHOLD Then
            grade = "A - Excellent!"
            gradeEmoji = "🏆"
        ElseIf value >= GRADE_B_THRESHOLD Then
            grade = "B - Good"
            gradeEmoji = "⭐"
        ElseIf value >= GRADE_C_THRESHOLD Then
            grade = "C - Average"
            gradeEmoji = "👍"
        ElseIf value >= GRADE_D_THRESHOLD Then
            grade = "D - Below Average"
            gradeEmoji = "😐"
        Else
            grade = "F - Failing"
            gradeEmoji = "❌"
        End If

        lstResults.Items.Add($"   {gradeEmoji} Grade: {grade}")
        lstResults.Items.Add("")
    End Sub

    ''' <summary>
    ''' Demonstrate complex conditions
    ''' </summary>
    Private Sub DemonstrateComplexConditions(value As Integer)
        lstResults.Items.Add("4️⃣ COMPLEX CONDITIONS")

        ' Even/Odd check
        Dim isEven As Boolean = (value Mod 2 = 0)
        lstResults.Items.Add($"   Even number: {If(isEven, "✓ YES", "✗ NO")}")

        ' Range check
        Dim inRange As Boolean = (value >= 0 AndAlso value <= 100)
        lstResults.Items.Add($"   In range [0-100]: {If(inRange, "✓ YES", "✗ NO")}")

        ' Multiple of 10
        Dim multipleOf10 As Boolean = (value Mod 10 = 0)
        lstResults.Items.Add($"   Multiple of 10: {If(multipleOf10, "✓ YES", "✗ NO")}")

        lstResults.Items.Add("")
    End Sub

    ''' <summary>
    ''' Demonstrate logical operators with IF statements
    ''' </summary>
    Private Sub DemonstrateLogicalOperators(value As Integer)
        lstResults.Items.Add("5️⃣ LOGICAL OPERATORS")

        ' AND operator
        If value > 0 And value < 100 Then
            lstResults.Items.Add("   AND: Value is between 0 and 100 ✓")
        Else
            lstResults.Items.Add("   AND: Value is NOT between 0 and 100 ✗")
        End If

        ' OR operator
        If value < 0 Or value > 100 Then
            lstResults.Items.Add("   OR: Value is outside [0-100] range ✓")
        Else
            lstResults.Items.Add("   OR: Value is within [0-100] range ✗")
        End If

        ' NOT operator
        If Not (value = 0) Then
            lstResults.Items.Add("   NOT: Value is not zero ✓")
        Else
            lstResults.Items.Add("   NOT: Value is zero ✗")
        End If

        lstResults.Items.Add("")
    End Sub

    ''' <summary>
    ''' Add summary section
    ''' </summary>
    Private Sub AddResultsSummary()
        lstResults.Items.Add("═══════════════════════════════════")
        lstResults.Items.Add("✅ Evaluation Complete!")
        lstResults.Items.Add("💡 Try different values to explore conditions")
    End Sub

#End Region

#Region "Helper Methods"

    ''' <summary>
    ''' Get descriptive text for grade based on value
    ''' </summary>
    Private Function GetGradeDescription(value As Integer) As String
        If value >= GRADE_A_THRESHOLD Then
            Return "Outstanding performance"
        ElseIf value >= GRADE_B_THRESHOLD Then
            Return "Above average performance"
        ElseIf value >= GRADE_C_THRESHOLD Then
            Return "Satisfactory performance"
        ElseIf value >= GRADE_D_THRESHOLD Then
            Return "Needs improvement"
        Else
            Return "Unsatisfactory performance"
        End If
    End Function

    ''' <summary>
    ''' Determine if number is prime (for educational purposes)
    ''' </summary>
    Private Function IsPrime(number As Integer) As Boolean
        If number < 2 Then Return False
        If number = 2 Then Return True
        If number Mod 2 = 0 Then Return False

        Dim limit As Integer = Math.Sqrt(number)
        For i As Integer = 3 To limit Step 2
            If number Mod i = 0 Then Return False
        Next

        Return True
    End Function

#End Region

End Class