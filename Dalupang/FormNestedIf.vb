Public Class FormNestedIf

    Private Sub FormNestedIf_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Text = "Nested IF Example"
    End Sub

    Private Sub ButtonCheck_Click(sender As Object, e As EventArgs) Handles ButtonCheck.Click
        If TextBoxInput.Text <> "" Then
            Dim number As Integer = CInt(TextBoxInput.Text)

            ' === Nested IF ===
            If number >= 0 Then
                ' Inside the first IF (positive)
                If number Mod 2 = 0 Then
                    MessageBox.Show("The number is Positive and Even")
                Else
                    MessageBox.Show("The number is Positive and Odd")
                End If
            Else
                ' Number is negative
                If number Mod 2 = 0 Then
                    MessageBox.Show("The number is Negative and Even")
                Else
                    MessageBox.Show("The number is Negative and Odd")
                End If
            End If
        Else
            MessageBox.Show("Please enter a number first")
        End If
    End Sub

End Class
