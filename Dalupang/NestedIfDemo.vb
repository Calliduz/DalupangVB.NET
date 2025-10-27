Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class NestedIfDemo
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub NestedIfDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtExample.Text =
"Nested IF is placing an If (or If...Else) inside another If block.
Use nested conditions when the second test is meaningful only if the first is true.
Example scenario: evaluate a student's score with additional remarks inside branches."
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()

        Dim s = txtScore.Text.Trim()
        Dim score As Integer
        If Not Integer.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, score) Then
            MessageBox.Show("Please enter a valid integer score.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        lstResults.Items.Add(String.Format("Score: {0}", score))

        ' Outer decision: pass threshold 50
        If score >= 50 Then
            lstResults.Items.Add("Outer If: Passed basic threshold (>= 50).")
            ' Nested checks for grade bands
            If score >= 90 Then
                lstResults.Items.Add("Nested If: Excellent (A).")
            Else
                If score >= 75 Then
                    lstResults.Items.Add("Nested If: Very Good (B).")
                Else
                    If score >= 60 Then
                        lstResults.Items.Add("Nested If: Good (C).")
                    Else
                        lstResults.Items.Add("Nested If: Barely Passed (D).")
                    End If
                End If
            End If
        Else
            lstResults.Items.Add("Outer Else: Did not meet passing threshold.")
            ' Nested inside else: check for near-miss
            If score >= 45 Then
                lstResults.Items.Add("Nested in Else: Near miss — consider remedial work.")
            Else
                lstResults.Items.Add("Nested in Else: Low score — retake required.")
            End If
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class