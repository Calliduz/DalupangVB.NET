Public Class ClassAndMethods
    Private Sub ClassAndMethods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox1.ReadOnly = True
        TextBox1.Multiline = True
        TextBox1.Text = "Classes and methods define types and behaviors." & vbCrLf &
                        "Example: Person class with Name/Age and methods GetInfo/CelebrateBirthday." & vbCrLf & vbCrLf &
                        "Click the button to run the demo and append results below."
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Simple classes and methods example when button is clicked
        Dim p As New Person()
        p.Name = "Alice"
        p.Age = 30

        ' Call methods on the person object
        Dim info As String = p.GetInfo()
        p.CelebrateBirthday()

        ' Append the result to the textbox
        TextBox1.AppendText(Environment.NewLine & "--- Classes and Methods Demo ---" & Environment.NewLine)
        TextBox1.AppendText($"Person Info: {info}" & Environment.NewLine)
        TextBox1.AppendText($"After birthday: {p.Name} is now {p.Age} years old" & Environment.NewLine)
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub
End Class

Public Class Person
    Public Name As String
    Public Age As Integer

    ' Method to get person information
    Public Function GetInfo() As String
        Return $"{Name} is {Age} years old"
    End Function

    ' Method to celebrate birthday (increases age)
    Public Sub CelebrateBirthday()
        Age += 1
    End Sub

    ' Method to introduce the person
    Public Function Introduce() As String
        Return $"Hello, my name is {Name} and I am {Age} years old."
    End Function

    ' Method with parameters
    Public Sub SetPersonInfo(personName As String, personAge As Integer)
        Name = personName
        Age = personAge
    End Sub

    ' Method that returns a boolean
    Public Function IsAdult() As Boolean
        Return Age >= 18
    End Function
End Class