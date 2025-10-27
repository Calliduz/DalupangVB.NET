Public Class monthsinayear
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        ListBox1.Items.Clear()

        Dim months() As String = {" ", "January", "February", "March", "April",
                                  "May", "June", "July", "August",
                                  "September", "October", "November", "December"}

        For i As Integer = 1 To months.Length - 1
            ListBox1.Items.Add(months(i))
        Next

    End Sub
End Class