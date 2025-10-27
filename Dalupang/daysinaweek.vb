Public Class daysinaweek
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Clear old items
        ListBox1.Items.Clear()

        ' Array of days
        Dim days() As String = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"}

        ' Loop through and add to ListBox
        For i As Integer = 0 To days.Length - 1
            ListBox1.Items.Add(days(i))
        Next
    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class