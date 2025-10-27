Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class DoWhileDemo
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub DoWhileDemo_Load(sender As Object, e As EventArgs)
        txtExample.Text =
"Do...Loop While repeats the block and checks the condition after each iteration.
Variants:
  Do While condition
    ' body (condition checked before first iteration)
  Loop

  Do
    ' body
  Loop While condition  (condition checked after each iteration)

Example: Keep adding numbers until sum >= limit."
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs)
        lstOutput.Items.Clear()

        Dim limit As Integer
        Dim addValue As Integer = 1

        If Not Integer.TryParse(txtLimit.Text.Trim(), limit) Then
            MessageBox.Show("Limit must be an integer.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtAdd.Text.Trim() <> String.Empty Then
            If Not Integer.TryParse(txtAdd.Text.Trim(), addValue) Then
                MessageBox.Show("Add value must be an integer.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If addValue = 0 Then
                MessageBox.Show("Add value should not be zero for this demo.", "Input note", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        End If

        lstOutput.Items.Add(String.Format("Do...Loop While demo: keep adding {0} until sum >= {1}", addValue, limit))

        Dim sum As Integer = 0
        Dim iter As Integer = 0
        ' Demonstrate Do...Loop While (post-check)
        Do
            sum += addValue
            iter += 1
            lstOutput.Items.Add(String.Format("Iteration {0}: sum = {1}", iter, sum))
            If iter > 10000 Then
                lstOutput.Items.Add("Aborting after 10,000 iterations (safety). Check inputs.")
                Exit Do
            End If
        Loop While sum < limit

        lstOutput.Items.Add(String.Format("Stopped after {0} iterations. Final sum = {1}", iter, sum))
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstOutput.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class