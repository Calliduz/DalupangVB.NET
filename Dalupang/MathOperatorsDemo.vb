Imports System.Windows.Forms

Public Class MathOperatorsDemo
    Private Sub MathOperatorsDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Open the Math Operators demo form when the user clicks "Click Me!"
        Try
            Dim demo As New FormMathOperators()
            demo.ShowDialog(Me)
        Catch ex As Exception
            MessageBox.Show("Could not open the math operators demo: " & ex.Message,
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class