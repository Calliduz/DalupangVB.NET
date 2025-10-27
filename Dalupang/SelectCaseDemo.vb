Imports System
Imports System.Globalization
Imports System.Windows.Forms

Public Class SelectCaseDemo
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub SelectCaseDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtExample.Text =
"Select Case chooses a branch based on an expression's value.
Syntax:
  Select Case expr
    Case value1
      ' ...
    Case value2 To value3
      ' ...
    Case Else
      ' ...
  End Select

Enter a number (or text) and click Evaluate to see how Select Case routes execution."
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()

        Dim s = txtValue.Text.Trim()
        Dim n As Integer
        If Integer.TryParse(s, NumberStyles.Integer, CultureInfo.CurrentCulture, n) Then
            lstResults.Items.Add("Evaluating numeric Select Case for: " & n.ToString())
            Select Case n
                Case 1
                    lstResults.Items.Add("Case 1 -> One")
                Case 2 To 4
                    lstResults.Items.Add("Case 2 To 4 -> Between two and four")
                Case Is >= 5
                    lstResults.Items.Add("Case Is >= 5 -> Five or more")
                Case Else
                    lstResults.Items.Add("Case Else -> Unexpected numeric value")
            End Select
        Else
            lstResults.Items.Add("Evaluating textual Select Case for: """ & s & """")
            Select Case s.ToLowerInvariant()
                Case "red"
                    lstResults.Items.Add("Case 'red' -> Color is red")
                Case "green", "blue"
                    lstResults.Items.Add("Case 'green' or 'blue' -> Primary color")
                Case Else
                    lstResults.Items.Add("Case Else -> Unknown text")
            End Select
        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        lstResults.Items.Clear()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub
End Class