Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class IfStatementDemo
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub IfStatementDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtExample.Text =
"IF statement evaluates a condition and runs code only when the condition is True.
Examples:
  If condition Then
    ' body
  End If

  If condition Then
    ' when true
  Else
    ' when false
  End If

  If ... ElseIf ... Else ... End If

Type a number and click Evaluate to see common IF examples."
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()

        Dim s = txtValue.Text.Trim()
        Dim n As Integer
        If Not Integer.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, n) Then
            MessageBox.Show("Please enter a valid integer.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        lstResults.Items.Add(String.Format("Input value: {0}", n))

        ' Simple If
        If n > 0 Then
            lstResults.Items.Add("Simple If: n > 0  -> True (positive)")
        Else
            lstResults.Items.Add("Simple If: n > 0  -> False (not positive)")
        End If

        ' If...Else
        If n = 0 Then
            lstResults.Items.Add("If...Else: n = 0 -> Zero")
        Else
            lstResults.Items.Add("If...Else: n = 0 -> Not zero")
        End If

        ' If...ElseIf...Else
        If n >= 90 Then
            lstResults.Items.Add("If...ElseIf: n >= 90 -> Grade A")
        ElseIf n >= 75 Then
            lstResults.Items.Add("If...ElseIf: 75 <= n < 90 -> Grade B")
        ElseIf n >= 50 Then
            lstResults.Items.Add("If...ElseIf: 50 <= n < 75 -> Grade C")
        Else
            lstResults.Items.Add("If...ElseIf: n < 50 -> Grade F")
        End If

        ' Inline single-line If (IIf not recommended) - show example with Boolean
        Dim isEven As Boolean = (n Mod 2 = 0)
        lstResults.Items.Add(String.Format("Is n even? -> {0}", isEven.ToString()))
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class