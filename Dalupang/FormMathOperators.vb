Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class FormMathOperators
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormMathOperators_Load(sender As Object, e As EventArgs)
        txtExample.Text =
"Math operators perform arithmetic between numbers.
Examples:
  +   : addition
  -   : subtraction
  *   : multiplication
  /   : division (floating point)
  \   : integer division
  Mod : remainder
  ^   : power

Type two numbers and click Evaluate. Division by zero is handled."
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()

        Dim s1 = txtValue1.Text.Trim()
        Dim s2 = txtValue2.Text.Trim()
        Dim n1 As Double
        Dim n2 As Double

        If Not Double.TryParse(s1, NumberStyles.Any, CultureInfo.CurrentCulture, n1) Then
            MessageBox.Show("Value 1 is not a valid number.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not Double.TryParse(s2, NumberStyles.Any, CultureInfo.CurrentCulture, n2) Then
            MessageBox.Show("Value 2 is not a valid number.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        lstResults.Items.Add(String.Format("Inputs: {0} and {1}", n1, n2))
        lstResults.Items.Add(String.Format("{0} + {1} = {2}", n1, n2, (n1 + n2).ToString()))
        lstResults.Items.Add(String.Format("{0} - {1} = {2}", n1, n2, (n1 - n2).ToString()))
        lstResults.Items.Add(String.Format("{0} * {1} = {2}", n1, n2, (n1 * n2).ToString()))

        If n2 = 0 Then
            lstResults.Items.Add(String.Format("{0} / {1} = <division by zero>", n1, n2))
            lstResults.Items.Add(String.Format("{0} \ {1} = <integer division by zero>", n1, n2))
            lstResults.Items.Add(String.Format("{0} Mod {1} = <mod by zero>", n1, n2))
        Else
            lstResults.Items.Add(String.Format("{0} / {1} = {2}", n1, n2, (n1 / n2).ToString()))
            lstResults.Items.Add(String.Format("{0} \ {1} = {2}", n1, n2, (Convert.ToInt64(Math.Truncate(n1)) \ Convert.ToInt64(Math.Truncate(n2))).ToString()))
            lstResults.Items.Add(String.Format("{0} Mod {1} = {2}", n1, n2, (Convert.ToInt64(Math.Truncate(n1)) Mod Convert.ToInt64(Math.Truncate(n2))).ToString()))
        End If

        ' Power operator
        Try
            Dim pow = Math.Pow(n1, n2)
            lstResults.Items.Add(String.Format("{0} ^ {1} = {2}", n1, n2, pow.ToString()))
        Catch ex As Exception
            lstResults.Items.Add(String.Format("Error computing power: {0}", ex.Message))
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class