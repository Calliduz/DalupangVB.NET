Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class ForNextDemo
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub ForNextDemo_Load(sender As Object, e As EventArgs)
        txtExample.Text =
"For...Next repeats a block of code a specific number of times.
Syntax:
  For i As Integer = start To [end] Step [step]
    ' body
  Next

Examples:
 - Count up: For i = 1 To 5
 - Count down: For i = 5 To 1 Step -1
 - Custom step: For i = 0 To 10 Step 2

Enter Start, End and optional Step then click Run to see the iterations."
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs)
        lstOutput.Items.Clear()

        Dim startVal As Integer
        Dim endVal As Integer
        Dim stepVal As Integer = 1

        If Not Integer.TryParse(txtStart.Text.Trim(), startVal) Then
            MessageBox.Show("Start value must be an integer.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If Not Integer.TryParse(txtEnd.Text.Trim(), endVal) Then
            MessageBox.Show("End value must be an integer.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If
        If txtStep.Text.Trim() <> String.Empty Then
            If Not Integer.TryParse(txtStep.Text.Trim(), stepVal) Then
                MessageBox.Show("Step value must be an integer.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
            If stepVal = 0 Then
                MessageBox.Show("Step cannot be zero.", "Input error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If
        End If

        lstOutput.Items.Add(String.Format("For i = {0} To {1} Step {2}", startVal, endVal, stepVal))
        Try
            ' Demonstrate the For...Next loop
            Dim count As Integer = 0
            For i As Integer = startVal To endVal Step stepVal
                lstOutput.Items.Add(String.Format("Iteration {0}: i = {1}", count + 1, i))
                count += 1
                ' Safety: avoid infinite loops caused by incorrect step direction
                If count > 10000 Then
                    lstOutput.Items.Add("Aborting after 10,000 iterations (safety). Check start/end/step values.")
                    Exit For
                End If
            Next
            lstOutput.Items.Add(String.Format("Completed {0} iterations.", count))
        Catch ex As Exception
            lstOutput.Items.Add("Error running loop: " & ex.Message)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstOutput.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class