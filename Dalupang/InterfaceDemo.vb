Public Class InterfaceDemo
    Private Sub IntfaceDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ReadOnly = True
        TextBox1.Multiline = True
        TextBox1.Text = "Interfaces define a contract that types implement." & vbCrLf &
                        "Example: IPrintable with Print() implemented by Document/Photo/Report." & vbCrLf & vbCrLf &
                        "Click the button to run the demo and append results below."
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Simple interface example when button is clicked
        Dim doc As New Document
        Dim photo As New Photo
        Dim report As New Report

        ' Call Print method on different objects that implement IPrintable
        Dim result = "" & Environment.NewLine & "--- Interface Demo ---" & Environment.NewLine
        result += doc.Print() & vbNewLine
        result += photo.Print() & vbNewLine
        result += report.Print()

        TextBox1.AppendText(result & Environment.NewLine)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub

End Class

Public Interface IPrintable
    Function Print() As String
End Interface

Public Class Document
    Implements IPrintable

    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Document..."
    End Function
End Class

Public Class Photo
    Implements IPrintable

    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Photo..."
    End Function
End Class

Public Class Report
    Implements IPrintable

    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Report..."
    End Function
End Class