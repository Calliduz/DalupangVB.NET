Public Class Form2
    ' UI reference (we find this at runtime so code compiles even if designer names differ)
    Private txtDisplayControl As TextBox

    ' Calculator state
    Private currentTotal As Double = 0
    Private lastOperator As String = ""
    Private isNewEntry As Boolean = True   ' when true, next digit replaces display



    ' ---------- Form load: find display and wire buttons ----------
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Find existing txtDisplay or fallback to first TextBox
        txtDisplayControl = FindControl(Of TextBox)("txtDisplay")
        If txtDisplayControl Is Nothing Then
            txtDisplayControl = FindFirstTextBox()
        End If

        ' If still Nothing, create a simple display at top of the form so the calculator is usable
        If txtDisplayControl Is Nothing Then
            txtDisplayControl = New TextBox() With {
                .Name = "txtDisplay",
                .ReadOnly = True,
                .Text = "0",
                .TextAlign = HorizontalAlignment.Right,
                .Font = New Font("Segoe UI", 14.0F),
                .Dock = DockStyle.Top
            }
            Me.Controls.Add(txtDisplayControl)
        End If

        ' Wire up buttons found anywhere on the form (recursively)
        For Each c As Control In GetAllControls(Me)
            If TypeOf c Is Button Then
                Dim b As Button = CType(c, Button)
                Dim t As String = b.Text.Trim().ToLowerInvariant()
                Dim n As String = b.Name.ToLowerInvariant()

                ' Numeric buttons (0..9) and decimal point
                If (t.Length = 1 AndAlso Char.IsDigit(t(0))) OrElse t = "." Then
                    AddHandler b.Click, AddressOf Number_Click
                    Continue For
                End If

                ' Operators (including "mod" or "%")
                If t = "+" OrElse t = "-" OrElse t = "×" OrElse t = "x" OrElse t = "*" OrElse t = "÷" OrElse t = "/" OrElse t = "mod" OrElse t = "%" Then
                    AddHandler b.Click, AddressOf Operator_Click
                    Continue For
                End If

                ' Equals (by text or name)
                If t = "=" OrElse n.Contains("equals") OrElse n.Contains("eq") OrElse t = "enter" Then
                    AddHandler b.Click, AddressOf Equals_Click
                    Continue For
                End If

                ' Clear (C / Clear) — also accept common name btnc
                If t = "c" OrElse t = "clear" OrElse n.Contains("btnc") OrElse n = "btnc" Then
                    AddHandler b.Click, AddressOf Clear_Click
                    Continue For
                End If

                ' Backspace (by name or text)
                If n.Contains("back") OrElse t = "⌫" OrElse t = "back" Then
                    AddHandler b.Click, AddressOf Back_Click
                    Continue For
                End If

                ' If control name explicitly "btnmod" (some forms use this) — ensure it's treated as operator
                If n.Contains("btnmod") Then
                    AddHandler b.Click, AddressOf Operator_Click
                    Continue For
                End If
            End If
        Next

        ' Keyboard support
        Me.KeyPreview = True
        AddHandler Me.KeyDown, AddressOf Form2_KeyDown
    End Sub

    ' ---------- Helper: recursive control enumerator ----------
    Private Iterator Function GetAllControls(parent As Control) As IEnumerable(Of Control)
        For Each c As Control In parent.Controls
            Yield c
            For Each child In GetAllControls(c)
                Yield child
            Next
        Next
    End Function

    ' ---------- Helper: find control by name and type ----------
    Private Function FindControl(Of T As Control)(name As String) As T
        For Each c As Control In GetAllControls(Me)
            If String.Equals(c.Name, name, StringComparison.OrdinalIgnoreCase) AndAlso TypeOf c Is T Then
                Return CType(c, T)
            End If
        Next
        Return Nothing
    End Function

    ' ---------- Helper: find first TextBox (fallback) ----------
    Private Function FindFirstTextBox() As TextBox
        For Each c As Control In GetAllControls(Me)
            If TypeOf c Is TextBox Then
                Return CType(c, TextBox)
            End If
        Next
        Return Nothing
    End Function

    ' ---------- Number / decimal click ----------
    Private Sub Number_Click(sender As Object, e As EventArgs)
        Dim b As Button = CType(sender, Button)
        Dim ch As String = b.Text.Trim()

        If txtDisplayControl Is Nothing Then Return

        If isNewEntry Then
            If ch = "." Then
                txtDisplayControl.Text = "0."
                isNewEntry = False
                Return
            End If
            txtDisplayControl.Text = ch
            isNewEntry = False
        Else
            If ch = "." AndAlso txtDisplayControl.Text.Contains(".") Then
                Return
            End If
            txtDisplayControl.Text &= ch
        End If
    End Sub

    ' ---------- Operator (+ - * / mod) ----------
    Private Sub Operator_Click(sender As Object, e As EventArgs)
        Dim b As Button = CType(sender, Button)
        Dim opText As String = b.Text.Trim().ToLowerInvariant()

        ' Normalize operator tokens
        Dim op As String = opText
        If op = "x" Then op = "*"
        If op = "×" Then op = "*"
        If op = "÷" Then op = "/"
        If op = "%" Then op = "mod"
        If op = "mod" Then op = "mod"

        Dim val As Double = 0
        Double.TryParse(GetDisplayText(), val)

        If lastOperator = "" Then
            currentTotal = val
        Else
            currentTotal = Calculate(currentTotal, val, lastOperator)
            SetDisplayText(currentTotal.ToString())
        End If

        lastOperator = op
        isNewEntry = True
    End Sub

    ' ---------- Equals ----------
    Private Sub Equals_Click(sender As Object, e As EventArgs)
        Dim val As Double = 0
        Double.TryParse(GetDisplayText(), val)

        If lastOperator <> "" Then
            currentTotal = Calculate(currentTotal, val, lastOperator)
            SetDisplayText(currentTotal.ToString())
            lastOperator = ""
            isNewEntry = True
        End If
    End Sub

    ' ---------- Clear ----------
    Private Sub Clear_Click(sender As Object, e As EventArgs)
        currentTotal = 0
        lastOperator = ""
        SetDisplayText("0")
        explnrslt.Text = ""
        isNewEntry = True
    End Sub

    ' ---------- Backspace ----------
    Private Sub Back_Click(sender As Object, e As EventArgs)
        If txtDisplayControl Is Nothing Then Return

        If isNewEntry Then
            SetDisplayText("0")
            isNewEntry = True
            Return
        End If

        Dim t = txtDisplayControl.Text
        If t.Length > 1 Then
            txtDisplayControl.Text = t.Substring(0, t.Length - 1)
        Else
            txtDisplayControl.Text = "0"
            isNewEntry = True
        End If
    End Sub

    ' ---------- Explanation Functions ----------
    Private Sub ShowExplanation(op As String, a As Double, b As Double, result As Double)
        Select Case op
            Case "+"
                explnrslt.Text = $"Adding {a} + {b}" & vbCrLf &
                                 $"Step 1: Line up numbers." & vbCrLf &
                                 $"Step 2: Add → {a} + {b} = {result}" & vbCrLf &
                                 $"Final Answer: {result}"
            Case "-"
                explnrslt.Text = $"Subtracting {a} - {b}" & vbCrLf &
                                 $"Step 1: Start with {a}." & vbCrLf &
                                 $"Step 2: Subtract {b}." & vbCrLf &
                                 $"Final Answer: {result}"
            Case "*"
                explnrslt.Text = $"Multiplying {a} × {b}" & vbCrLf &
                                 $"Step 1: Multiply directly." & vbCrLf &
                                 $"Final Answer: {result}"
            Case "/"
                If b = 0 Then
                    explnrslt.Text = "Division by zero is undefined."
                Else
                    explnrslt.Text = $"Dividing {a} ÷ {b}" & vbCrLf &
                                     $"Step 1: Perform division." & vbCrLf &
                                     $"Final Answer: {result}"
                End If
            Case "mod"
                explnrslt.Text = $"Modulo operation {a} Mod {b}" & vbCrLf &
                                 $"Step 1: Divide {a} by {b}." & vbCrLf &
                                 $"Step 2: Take remainder = {result}" & vbCrLf &
                                 $"Final Answer: {result}"
            Case "\"
                explnrslt.Text = $"Integer Division {a} \ {b}" & vbCrLf &
                                 $"Step 1: Divide {a} by {b}." & vbCrLf &
                                 $"Step 2: Discard remainder." & vbCrLf &
                                 $"Final Answer: {result}"
            Case "^"
                explnrslt.Text = $"{a} raised to {b}" & vbCrLf &
                                 $"Step 1: Multiply {a} by itself {b} times." & vbCrLf &
                                 $"Final Answer: {result}"
        End Select
    End Sub

    ' ---------- Calculation logic ----------
    Private Function Calculate(a As Double, b As Double, op As String) As Double
        Dim result As Double = 0

        Select Case op
            Case "+", "＋"
                result = a + b
            Case "-", "−"
                result = a - b
            Case "*", "×"
                result = a * b
            Case "/", "÷"
                If b = 0 Then
                    MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    explnrslt.Text = "Division by zero is undefined."
                    Return a
                End If
                result = a / b
            Case "mod"
                If b = 0 Then
                    MessageBox.Show("Cannot modulo by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    explnrslt.Text = "Modulo by zero is undefined."
                    Return a
                End If
                result = a Mod b
            Case "\"
                If b = 0 Then
                    MessageBox.Show("Cannot divide by zero", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                    explnrslt.Text = "Integer division by zero is undefined."
                    Return a
                End If
                result = a \ b
            Case "^"
                result = Math.Pow(a, b)
            Case Else
                result = b
        End Select

        ' Show explanation
        ShowExplanation(op, a, b, result)

        Return result
    End Function

    ' ---------- Keyboard support ----------
    Private Sub Form2_KeyDown(sender As Object, e As KeyEventArgs)
        ' Numeric keys
        If e.KeyCode >= Keys.D0 AndAlso e.KeyCode <= Keys.D9 Then
            Dim digit As String = (e.KeyCode - Keys.D0).ToString()
            SimulateTextInput(digit)
            e.Handled = True
            Return
        End If
        If e.KeyCode >= Keys.NumPad0 AndAlso e.KeyCode <= Keys.NumPad9 Then
            Dim digit As String = (e.KeyCode - Keys.NumPad0).ToString()
            SimulateTextInput(digit)
            e.Handled = True
            Return
        End If

        Select Case e.KeyCode
            Case Keys.OemPeriod, Keys.Decimal
                SimulateTextInput(".")
            Case Keys.Add
                SimulateOperator("+")
            Case Keys.Subtract
                SimulateOperator("-")
            Case Keys.Multiply
                SimulateOperator("*")
            Case Keys.Divide
                SimulateOperator("/")
            Case Keys.Enter
                Equals_Click(Nothing, EventArgs.Empty)
            Case Keys.Back
                Back_Click(Nothing, EventArgs.Empty)
            Case Keys.Escape
                Clear_Click(Nothing, EventArgs.Empty)
        End Select
    End Sub

    Private Sub SimulateTextInput(ch As String)
        If txtDisplayControl Is Nothing Then Return

        If isNewEntry Then
            If ch = "." Then
                txtDisplayControl.Text = "0."
                isNewEntry = False
            Else
                txtDisplayControl.Text = ch
                isNewEntry = False
            End If
        Else
            If ch = "." AndAlso txtDisplayControl.Text.Contains(".") Then Return
            txtDisplayControl.Text &= ch
        End If
    End Sub

    Private Sub SimulateOperator(op As String)
        ' Try to find a button matching that operator and raise its click; else call the operator logic directly
        For Each c As Control In GetAllControls(Me)
            If TypeOf c Is Button Then
                Dim b As Button = CType(c, Button)
                Dim t As String = b.Text.Trim()
                If t = op OrElse (op = "*" And (t = "x" Or t = "×" Or t = "*")) OrElse (op = "/" And (t = "/" Or t = "÷")) Then
                    Operator_Click(b, EventArgs.Empty)
                    Return
                End If
            End If
        Next

        ' fallback: call operator logic with a temporary button-like sender
        Dim fake As New Button() With {.Text = op}
        Operator_Click(fake, EventArgs.Empty)
    End Sub

    ' ---------- Safe display helpers ----------
    Private Function GetDisplayText() As String
        If txtDisplayControl Is Nothing Then Return "0"
        Return txtDisplayControl.Text
    End Function

    Private Sub SetDisplayText(v As String)
        If txtDisplayControl Is Nothing Then Return
        txtDisplayControl.Text = v
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles explnrslt.TextChanged

    End Sub

    Private Sub btndelete_Click(sender As Object, e As EventArgs) Handles btndelete.Click
        If txtDisplayControl Is Nothing Then Return

        If isNewEntry Then
            SetDisplayText("0")
            isNewEntry = True
            Return
        End If

        Dim t = txtDisplayControl.Text
        If t.Length > 1 Then
            txtDisplayControl.Text = t.Substring(0, t.Length - 1)
        Else
            txtDisplayControl.Text = "0"
            isNewEntry = True
        End If
    End Sub

    Private Sub btnexponent_Click(sender As Object, e As EventArgs) Handles btnexponent.Click
        Try
            Dim parts() As String = txtDisplay.Text.Split("^"c)

            ' If user already typed "base ^ exponent"
            If parts.Length = 2 Then
                Dim baseNum As Double = Double.Parse(parts(0))
                Dim expNum As Double = Double.Parse(parts(1))
                Dim result As Double = Math.Pow(baseNum, expNum)

                txtDisplay.Text = result.ToString()
                explnrslt.Text = $"{baseNum} raised to the power of {expNum} = {result}"
            Else
                ' Otherwise, prepare input like "number^"
                txtDisplay.Text &= "^"
            End If

        Catch ex As Exception
            MessageBox.Show("Invalid input for exponentiation")
        End Try
    End Sub

    Private Sub btnintdiv_Click(sender As Object, e As EventArgs) Handles btnintdiv.Click
        Try
            Dim parts() As String = txtDisplay.Text.Split("\"c)

            If parts.Length = 2 Then
                Dim num1 As Integer = Integer.Parse(parts(0))
                Dim num2 As Integer = Integer.Parse(parts(1))

                If num2 = 0 Then
                    MessageBox.Show("Cannot divide by zero")
                    Return
                End If

                Dim result As Integer = num1 \ num2
                txtDisplay.Text = result.ToString()
                explnrslt.Text = $"{num1} \ {num2} = {result}" & vbCrLf & "Integer division discards the remainder."
            Else
                txtDisplay.Text &= "\"
            End If

        Catch ex As Exception
            MessageBox.Show("Invalid input for integer division")
        End Try
    End Sub

    Private Sub btnmod_Click(sender As Object, e As EventArgs) Handles btnmod.Click
        Try
            Dim parts() As String = txtDisplay.Text.Split("M"c) ' user should type "aModb"

            If txtDisplay.Text.ToLower().Contains("mod") Then
                parts = txtDisplay.Text.ToLower().Split(New String() {"mod"}, StringSplitOptions.None)

                If parts.Length = 2 Then
                    Dim num1 As Integer = Integer.Parse(parts(0))
                    Dim num2 As Integer = Integer.Parse(parts(1))

                    If num2 = 0 Then
                        MessageBox.Show("Cannot modulo by zero")
                        Return
                    End If

                    Dim result As Integer = num1 Mod num2
                    txtDisplay.Text = result.ToString()
                    explnrslt.Text = $"{num1} Mod {num2} = {result}" & vbCrLf & "Remainder after division."
                End If
            Else
                txtDisplay.Text &= "Mod"
            End If

        Catch ex As Exception
            MessageBox.Show("Invalid input for modulo")
        End Try
    End Sub

    Private Sub btnsroot_Click(sender As Object, e As EventArgs) Handles btnsroot.Click
        Try
            Dim num As Double = Double.Parse(txtDisplay.Text)

            If num < 0 Then
                MessageBox.Show("Cannot take square root of a negative number")
                Return
            End If

            Dim result As Double = Math.Sqrt(num)
            explnrslt.Text = $"Square root of {num} = {result}" & vbCrLf &
                             $"Step 1: Find number that multiplies by itself to get {num}" & vbCrLf &
                             $"Final Answer: {result}"
            txtDisplay.Text = result.ToString()

        Catch ex As Exception
            MessageBox.Show("Invalid input for square root")
        End Try
    End Sub

    Private Sub btndot_Click(sender As Object, e As EventArgs) Handles btndot.Click

    End Sub
End Class
