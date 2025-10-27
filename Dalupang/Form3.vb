Public Class Form3

    ' === Animal classes ===
    Public MustInherit Class Animal
        Public Overridable Function Speak() As String
            Return "Animal speaks"
        End Function
    End Class

    Public Class Dog
        Inherits Animal
        Public Overrides Function Speak() As String
            Return "Dog barks"
        End Function
    End Class

    Public Class Cat
        Inherits Animal
        Public Overrides Function Speak() As String
            Return "Cat meows"
        End Function
    End Class

    ' === Form controls ===
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show explanation in the textbox
        TextBox1.ReadOnly = True
        TextBox1.Multiline = True
        TextBox1.Text = "Inheritance lets a class reuse and extend another class." & vbCrLf &
                        "Example: Dog and Cat inherit from Animal and override Speak()." & vbCrLf & vbCrLf &
                        "Click the button to run the demo and append results below."
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Append demo output to the textbox instead of showing message boxes
        TextBox1.AppendText(Environment.NewLine & "--- Inheritance Demo ---" & Environment.NewLine)

        Dim a As Animal

        a = New Dog()
        TextBox1.AppendText("Dog via Animal.Speak(): " & a.Speak() & Environment.NewLine)

        a = New Cat()
        TextBox1.AppendText("Cat via Animal.Speak(): " & a.Speak() & Environment.NewLine)
    End Sub

End Class
