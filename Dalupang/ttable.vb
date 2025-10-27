Imports System.Reflection.Emit
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.Button

Public Class ttable
    Private Sub TruthTable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Setup DataGridView columns
        DataGridView1.Columns.Add("A", "A")
        DataGridView1.Columns.Add("B", "B")
        DataGridView1.Columns.Add("NotA", "NOT A")
        DataGridView1.Columns.Add("AandB", "A AND B")
        DataGridView1.Columns.Add("AorB", "A OR B")
        DataGridView1.Columns.Add("Xor", "A XOR B")

        ' Fill truth table once when form loads
        FillTruthTable()

        ' Update interactive results once
        UpdateInteractiveResults()
    End Sub

    Private Sub FillTruthTable()
        ' Clear old rows
        DataGridView1.Rows.Clear()

        ' Possible values for A and B
        Dim values As Boolean() = {True, False}

        For Each A In values
            For Each B In values
                Dim row As String() = {
                    A.ToString(),
                    B.ToString(),
                    (Not A).ToString(),
                    (A And B).ToString(),
                    (A Or B).ToString(),
                    (A Xor B).ToString()
                }
                DataGridView1.Rows.Add(row)
            Next
        Next
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FillTruthTable()
    End Sub

    ' --- INTERACTIVE CHECKBOX PART ---
    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        UpdateInteractiveResults()
    End Sub

    Private Sub CheckBox2_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox2.CheckedChanged
        UpdateInteractiveResults()
    End Sub

    Private Sub UpdateInteractiveResults()
        Dim A As Boolean = CheckBox1.Checked
        Dim B As Boolean = CheckBox2.Checked

        Label1.Text = "NOT A = " & (Not A).ToString()
        Label2.Text = "A AND B = " & (A And B).ToString()
        Label3.Text = "A OR B = " & (A Or B).ToString()
        Label4.Text = "A XOR B = " & (A Xor B).ToString()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
End Class
