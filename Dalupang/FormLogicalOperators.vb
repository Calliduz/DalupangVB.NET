Imports System
Imports System.Windows.Forms

Public Class FormLogicalOperators
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub FormLogicalOperators_Load(sender As Object, e As EventArgs)
        txtExample.Text =
"Logical operators combine or invert boolean values and return True or False.
Examples:
  AndAlso / And : logical AND
  OrElse  / Or  : logical OR
  Xor           : exclusive OR
  Not           : logical NOT

Use the checkboxes (or enter True/False) and click Evaluate."
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()

        ' Read boolean inputs - prefer CheckBoxes; also allow text parsing
        Dim b1 As Boolean = chkValue1.Checked
        Dim b2 As Boolean = chkValue2.Checked

        ' If text boxes are populated, try parse them (gives flexibility)
        Dim parsed As Boolean
        If Boolean.TryParse(txtValue1.Text.Trim(), parsed) Then b1 = parsed
        If Boolean.TryParse(txtValue2.Text.Trim(), parsed) Then b2 = parsed

        lstResults.Items.Add(String.Format("Input A = {0}, Input B = {1}", b1, b2))
        lstResults.Items.Add(String.Format("A And B     -> {0}", (b1 And b2).ToString()))
        lstResults.Items.Add(String.Format("A AndAlso B -> {0}", (b1 AndAlso b2).ToString()))
        lstResults.Items.Add(String.Format("A Or B      -> {0}", (b1 Or b2).ToString()))
        lstResults.Items.Add(String.Format("A OrElse B  -> {0}", (b1 OrElse b2).ToString()))
        lstResults.Items.Add(String.Format("A Xor B     -> {0}", (b1 Xor b2).ToString()))
        lstResults.Items.Add(String.Format("Not A       -> {0}", (Not b1).ToString()))
        lstResults.Items.Add(String.Format("Not B       -> {0}", (Not b2).ToString()))

        ' Show short examples using relational comparisons
        lstResults.Items.Add("--- Examples with relational expressions ---")
        lstResults.Items.Add(String.Format("(5 > 3) And (2 < 1) -> {0}", ((5 > 3) And (2 < 1)).ToString()))
        lstResults.Items.Add(String.Format("(5 > 3) Or (2 < 1)  -> {0}", ((5 > 3) Or (2 < 1)).ToString()))
        lstResults.Items.Add(String.Format("Not (5 > 3)         -> {0}", (Not (5 > 3)).ToString()))
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class