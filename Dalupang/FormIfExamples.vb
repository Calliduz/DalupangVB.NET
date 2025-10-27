Public Class FormIfExamples

    Private Sub FormIfExamples_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup form text
        Me.Text = "IF Statement Examples"
    End Sub

    ' === IF Statement ===
    Private Sub ButtonIf_Click(sender As Object, e As EventArgs) Handles ButtonIf.Click
        Dim number As Integer = CInt(TextBoxInput.Text)

        ' Just an IF (executes only if condition is true)
        If number > 10 Then
            MessageBox.Show("Number is greater than 10")
        End If
    End Sub

    ' === IF...THEN Statement ===
    Private Sub ButtonIfThen_Click(sender As Object, e As EventArgs) Handles ButtonIfThen.Click
        If TextBoxInput.Text <> "" Then
            Dim number As Integer = CInt(TextBoxInput.Text)

            ' IF...THEN example
            If number = 5 Then
                MessageBox.Show("Number is exactly 5")
            End If
        Else
            MessageBox.Show("Please enter a number first")
        End If
    End Sub

    ' === IF...THEN...ELSE Statement ===
    Private Sub ButtonIfElse_Click(sender As Object, e As EventArgs) Handles ButtonIfElse.Click
        Dim number As Integer = CInt(TextBoxInput.Text)

        If number Mod 2 = 0 Then
            MessageBox.Show("Number is Even")
        Else
            MessageBox.Show("Number is Odd")
        End If
    End Sub

End Class
