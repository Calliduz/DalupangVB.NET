Imports System.Globalization
Imports System.Text

''' <summary>
''' For...Next Loop Educational Demonstration
''' Interactive tool for learning iteration and counting loops
''' </summary>
Public Class ForNextDemo
    Inherits Form

#Region "Constants"

    Private Const MAX_SAFE_ITERATIONS As Integer = 10000
    Private Const DEFAULT_STEP As Integer = 1
    Private Const MIN_VALUE As Integer = -1000
    Private Const MAX_VALUE As Integer = 1000

#End Region

#Region "Form Initialization"

    Public Sub New()
        InitializeComponent()
    End Sub

    ''' <summary>
    ''' Initialize form and display educational content
    ''' </summary>
    Private Sub ForNextDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        DisplayInstructions()
        SetDefaultValues()
    End Sub

    ''' <summary>
    ''' Configure UI elements for optimal user experience
    ''' </summary>
    Private Sub InitializeUI()
        Me.Text = "For...Next Loop - Iteration Demonstration"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Configure text boxes
        ConfigureInstructionTextBox()
        ConfigureInputTextBoxes()

        ' Configure list box
        ConfigureOutputListBox()

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
                .BackColor = Color.FromArgb(255, 248, 240)
                .ForeColor = Color.FromArgb(50, 50, 50)
                .BorderStyle = BorderStyle.FixedSingle
            End With
        End If
    End Sub

    ''' <summary>
    ''' Configure input text boxes
    ''' </summary>
    Private Sub ConfigureInputTextBoxes()
        ConfigureInputBox(txtStart, "Start value")
        ConfigureInputBox(txtEnd, "End value")
        ConfigureInputBox(txtStep, "Step value (optional)")
    End Sub

    ''' <summary>
    ''' Configure individual input box
    ''' </summary>
    Private Sub ConfigureInputBox(textBox As TextBox, placeholder As String)
        If textBox IsNot Nothing Then
            With textBox
                .Font = New Font("Segoe UI", 11, FontStyle.Regular)
                .TextAlign = HorizontalAlignment.Center
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(50, 50, 50)
            End With
        End If
    End Sub

    ''' <summary>
    ''' Configure output list box
    ''' </summary>
    Private Sub ConfigureOutputListBox()
        If lstOutput IsNot Nothing Then
            With lstOutput
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
        ConfigureButton(btnRun, "▶️ Run Loop", Color.FromArgb(40, 167, 69))
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
    "🔁 FOR...NEXT LOOP DEMONSTRATION" & vbCrLf &
            "═══════════════════════════════════════" & vbCrLf & vbCrLf &
          "For...Next repeats code a specific number of times." & vbCrLf &
            "Perfect for counting, iteration, and predictable loops!" & vbCrLf & vbCrLf &
          "📌 Syntax:" & vbCrLf &
            "  For counter = start To end Step increment" & vbCrLf &
       "    ' Loop body executes" & vbCrLf &
    "  Next" & vbCrLf & vbCrLf &
            "📝 Examples:" & vbCrLf &
            "• Count up:   For i = 1 To 10 (step = 1)" & vbCrLf &
            "  • Count down: For i = 10 To 1 Step -1" & vbCrLf &
         "• Skip:     For i = 0 To 20 Step 2 (even)" & vbCrLf &
   "  • Skip:       For i = 1 To 20 Step 2 (odd)" & vbCrLf & vbCrLf &
            "💡 Enter Start, End, and Step values, then click Run!"
    End Sub

    ''' <summary>
    ''' Set default example values
    ''' </summary>
    Private Sub SetDefaultValues()
        txtStart.Text = "1"
        txtEnd.Text = "10"
        txtStep.Text = "1"
    End Sub

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' Execute For...Next loop with user parameters
    ''' </summary>
    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        ' Clear previous output
        lstOutput.Items.Clear()

        ' Validate and parse inputs
        Dim startValue As Integer
        Dim endValue As Integer
        Dim stepValue As Integer

        If Not ValidateInputs(startValue, endValue, stepValue) Then
            Return
        End If

        ' Display loop configuration
        AddLoopHeader(startValue, endValue, stepValue)

        ' Execute the loop
        ExecuteForNextLoop(startValue, endValue, stepValue)
    End Sub

    ''' <summary>
    ''' Clear all output
    ''' </summary>
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        lstOutput.Items.Clear()
        SetDefaultValues()
        txtStart.Focus()
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
    ''' Validate all user inputs
    ''' </summary>
    Private Function ValidateInputs(ByRef startVal As Integer, ByRef endVal As Integer, ByRef stepVal As Integer) As Boolean
        ' Validate start value
        If Not ValidateInteger(txtStart.Text, "Start", startVal) Then
            txtStart.Focus()
            Return False
        End If

        ' Validate end value
        If Not ValidateInteger(txtEnd.Text, "End", endVal) Then
            txtEnd.Focus()
            Return False
        End If

        ' Validate step value (optional, default to 1)
        If String.IsNullOrWhiteSpace(txtStep.Text) Then
            stepVal = DEFAULT_STEP
        ElseIf Not ValidateInteger(txtStep.Text, "Step", stepVal) Then
            txtStep.Focus()
            Return False
        End If

        ' Validate step is not zero
        If stepVal = 0 Then
            ShowValidationError("Step value cannot be zero." & vbCrLf & vbCrLf &
        "💡 Use 1 for counting up, -1 for counting down")
            txtStep.SelectAll()
            txtStep.Focus()
            Return False
        End If

        ' Validate step direction matches start/end
        If Not ValidateStepDirection(startVal, endVal, stepVal) Then
            Return False
        End If

        ' Estimate iterations to prevent infinite loops
        Dim estimatedIterations As Integer = EstimateIterations(startVal, endVal, stepVal)
        If estimatedIterations > MAX_SAFE_ITERATIONS Then
            Dim result = MessageBox.Show(
                $"This will perform approximately {estimatedIterations:N0} iterations." & vbCrLf & vbCrLf &
                   "This may take a while. Continue?",
             "Large Loop Warning",
            MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning
                    )
            If result = DialogResult.No Then
                Return False
            End If
        End If

        Return True
    End Function

    ''' <summary>
    ''' Validate and parse integer input
    ''' </summary>
    Private Function ValidateInteger(text As String, fieldName As String, ByRef value As Integer) As Boolean
        If String.IsNullOrWhiteSpace(text) Then
            ShowValidationError($"{fieldName} value is required.")
            Return False
        End If

        If Not Integer.TryParse(text.Trim(), NumberStyles.Integer, CultureInfo.CurrentCulture, value) Then
            ShowValidationError($"{fieldName} must be a valid integer." & vbCrLf & vbCrLf &
             $"💡 Example: 1, -5, 100")
            Return False
        End If

        If value < MIN_VALUE Or value > MAX_VALUE Then
            ShowValidationError($"{fieldName} must be between {MIN_VALUE} and {MAX_VALUE}.")
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Validate step direction matches start and end values
    ''' </summary>
    Private Function ValidateStepDirection(startVal As Integer, endVal As Integer, stepVal As Integer) As Boolean
        If startVal < endVal And stepVal < 0 Then
            ShowValidationError("When Start < End, Step must be positive." & vbCrLf & vbCrLf &
            "💡 To count up from " & startVal & " to " & endVal & ", use a positive step.")
            txtStep.SelectAll()
            txtStep.Focus()
            Return False
        End If

        If startVal > endVal And stepVal > 0 Then
            ShowValidationError("When Start > End, Step must be negative." & vbCrLf & vbCrLf &
  "💡 To count down from " & startVal & " to " & endVal & ", use a negative step.")
            txtStep.SelectAll()
            txtStep.Focus()
            Return False
        End If

        Return True
    End Function

    ''' <summary>
    ''' Estimate number of iterations
    ''' </summary>
    Private Function EstimateIterations(startVal As Integer, endVal As Integer, stepVal As Integer) As Integer
        If stepVal = 0 Then Return 0
        Dim range As Integer = Math.Abs(endVal - startVal)
        Dim stepAbs As Integer = Math.Abs(stepVal)
        Return (range \ stepAbs) + 1
    End Function

    ''' <summary>
    ''' Show validation error message
    ''' </summary>
    Private Sub ShowValidationError(message As String)
        MessageBox.Show(
    message,
                "Input Validation",
             MessageBoxButtons.OK,
        MessageBoxIcon.Warning
            )
    End Sub

#End Region

#Region "Loop Execution"

    ''' <summary>
    ''' Add loop configuration header
    ''' </summary>
    Private Sub AddLoopHeader(startVal As Integer, endVal As Integer, stepVal As Integer)
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("🔁 FOR...NEXT LOOP EXECUTION")
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("")
        lstOutput.Items.Add($"📝 Loop Configuration:")
        lstOutput.Items.Add($"   For i = {startVal} To {endVal} Step {stepVal}")
        lstOutput.Items.Add("")
        lstOutput.Items.Add("🔄 Iterations:")
        lstOutput.Items.Add("───────────────────────────────────────")
    End Sub

    ''' <summary>
    ''' Execute the For...Next loop and display results
    ''' </summary>
    Private Sub ExecuteForNextLoop(startVal As Integer, endVal As Integer, stepVal As Integer)
        Try
            Dim iterationCount As Integer = 0
            Dim sum As Integer = 0
            Dim valuesList As New List(Of Integer)

            lstOutput.BeginUpdate()

            For i As Integer = startVal To endVal Step stepVal
                iterationCount += 1
                sum += i
                valuesList.Add(i)

                ' Display iteration
                Dim emoji As String = GetIterationEmoji(iterationCount)
                lstOutput.Items.Add($"{emoji} Iteration {iterationCount:D3}: i = {i,5} | Sum = {sum,8}")

                ' Safety check
                If iterationCount >= MAX_SAFE_ITERATIONS Then
                    lstOutput.Items.Add("")
                    lstOutput.Items.Add($"⚠️ Safety limit reached ({MAX_SAFE_ITERATIONS:N0} iterations)")
                    lstOutput.Items.Add("   Loop terminated to prevent hanging.")
                    Exit For
                End If
            Next

            lstOutput.EndUpdate()

            ' Display summary
            AddLoopSummary(iterationCount, sum, valuesList, startVal, endVal, stepVal)

        Catch ex As Exception
            lstOutput.Items.Add("")
            lstOutput.Items.Add($"❌ Error executing loop: {ex.Message}")
        End Try
    End Sub

    ''' <summary>
    ''' Add loop execution summary
    ''' </summary>
    Private Sub AddLoopSummary(iterations As Integer, sum As Integer, values As List(Of Integer),
      startVal As Integer, endVal As Integer, stepVal As Integer)
        lstOutput.Items.Add("")
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add("📊 LOOP SUMMARY")
        lstOutput.Items.Add("═══════════════════════════════════════")
        lstOutput.Items.Add($"✓ Total Iterations: {iterations:N0}")
        lstOutput.Items.Add($"✓ Sum of Values: {sum:N0}")

        If iterations > 0 Then
            Dim average As Double = sum / CDbl(iterations)
            lstOutput.Items.Add($"✓ Average Value: {average:F2}")
            lstOutput.Items.Add($"✓ First Value: {values.First()}")
            lstOutput.Items.Add($"✓ Last Value: {values.Last()}")

            ' Additional insights
            AddLoopInsights(values, stepVal)
        End If

        lstOutput.Items.Add("")
        lstOutput.Items.Add("💡 Try different Start, End, and Step values!")
    End Sub

    ''' <summary>
    ''' Add additional insights about the loop
    ''' </summary>
    Private Sub AddLoopInsights(values As List(Of Integer), stepVal As Integer)
        lstOutput.Items.Add("")
        lstOutput.Items.Add("📈 Additional Insights:")

        ' Pattern detection
        If stepVal = 1 Then
            lstOutput.Items.Add("   • Sequential counting (step = 1)")
        ElseIf stepVal = -1 Then
            lstOutput.Items.Add("   • Reverse sequential (step = -1)")
        ElseIf stepVal = 2 Then
            Dim isEven = values(0) Mod 2 = 0
            lstOutput.Items.Add($"   • {If(isEven, "Even", "Odd")} numbers only (step = 2)")
        ElseIf Math.Abs(stepVal) > 1 Then
            lstOutput.Items.Add($"   • Skipping by {Math.Abs(stepVal)}")
        End If

        ' Check for positive/negative
        Dim allPositive = values.All(Function(v) v >= 0)
        Dim allNegative = values.All(Function(v) v < 0)
        If allPositive Then
            lstOutput.Items.Add("   • All values are non-negative")
        ElseIf allNegative Then
            lstOutput.Items.Add("   • All values are negative")
        End If
    End Sub

#End Region

#Region "Helper Methods"

    ''' <summary>
    ''' Get emoji for iteration number
    ''' </summary>
    Private Function GetIterationEmoji(iteration As Integer) As String
        Select Case iteration Mod 5
            Case 0 : Return "⭐"
            Case 1 : Return "🔵"
            Case 2 : Return "🟢"
            Case 3 : Return "🟡"
            Case 4 : Return "🟠"
            Case Else : Return "●"
        End Select
    End Function

#End Region

End Class