Public Class Polymorphism
    Private Sub Polymorphism_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Show explanation in the textbox
        TextBox1.ReadOnly = True
        TextBox1.Multiline = True
        TextBox1.Text = "Polymorphism allows objects of different types to be treated through a common base type." & vbCrLf &
                        "Example: call Speak() on an Animal reference that points to different derived types." & vbCrLf & vbCrLf &
                        "Click the button to run the demo and append results below."
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Demonstrate polymorphism and append results to the textbox
        TextBox1.AppendText(vbCrLf & "--- Polymorphism Demo ---" & vbCrLf)

        Dim a As Animal = New Dog()
        TextBox1.AppendText("Dog via Animal.Speak(): " & a.Speak() & vbCrLf)
        TextBox1.AppendText("Dog Eat(): " & a.Eat() & vbCrLf)

        a = New Cat()
        TextBox1.AppendText("Cat via Animal.Speak(): " & a.Speak() & vbCrLf)
        TextBox1.AppendText("Cat Eat(): " & a.Eat() & vbCrLf)

        a = New Bird()
        TextBox1.AppendText("Bird via Animal.Speak(): " & a.Speak() & vbCrLf)
        TextBox1.AppendText("Bird Eat() (uses base implementation): " & a.Eat() & vbCrLf)
    End Sub

    ' keep textbox read-only behavior consistent
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub
End Class

' Base class Animal
Public MustInherit Class Animal
    ' Abstract method that must be implemented by derived classes
    Public MustOverride Function Speak() As String

    ' Virtual method that can be overridden
    Public Overridable Function Eat() As String
        Return "Animal is eating"
    End Function

    ' Regular method
    Public Function Sleep() As String
        Return "Animal is sleeping"
    End Function
End Class

' Derived class Dog
Public Class Dog
    Inherits Animal

    ' Override the abstract method
    Public Overrides Function Speak() As String
        Return "Dog barks"
    End Function

    ' Override the virtual method
    Public Overrides Function Eat() As String
        Return "Dog is eating dog food"
    End Function
End Class

' Derived class Cat
Public Class Cat
    Inherits Animal

    ' Override the abstract method
    Public Overrides Function Speak() As String
        Return "Cat meows"
    End Function

    ' Override the virtual method
    Public Overrides Function Eat() As String
        Return "Cat is eating fish"
    End Function
End Class

' Derived class Bird
Public Class Bird
    Inherits Animal

    ' Override the abstract method
    Public Overrides Function Speak() As String
        Return "Bird chirps"
    End Function

    ' This class doesn't override Eat(), so it uses the base implementation
End Class