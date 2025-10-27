Public Class RelationalOperatorsDemo
    Private Sub RelationalOperatorsDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Opens the relational operators example/demo form.
        ' Uses ShowDialog so the demo pops up in front of this form.
        Try
            Dim demo As New FormRelationalOperators()
            demo.ShowDialog(Me)
        Catch ex As Exception
            ' If the demo form doesn't exist, inform the developer at runtime.
            MessageBox.Show("Could not open the relational operators demo: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class