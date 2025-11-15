''' <summary>
''' Polymorphism Educational Demonstration
''' Interactive tool for learning polymorphic behavior in OOP
''' Enterprise-grade implementation with design system integration
''' </summary>
Public Class Polymorphism
    Inherits Form

    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub Polymorphism_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ApplyEnterpriseStyles()
        DisplayInstructions()
    End Sub

    Private Sub ApplyEnterpriseStyles()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
        Me.StartPosition = AppConfiguration.UISettings.StartupPositionValue

        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
        End If

        If TextBox1 IsNot Nothing Then
            With TextBox1
                .ReadOnly = True
                .Multiline = True
                .Font = EnterpriseDesignSystem.CreateMonospaceFont(EnterpriseDesignSystem.FontSizes.Body)
                .BackColor = EnterpriseDesignSystem.LightTheme.Surface
                .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary
            End With
        End If

        If Button1 IsNot Nothing Then
            With Button1
                .Text = "▶️ Run Demo"
                .BackColor = EnterpriseDesignSystem.SemanticColors.Success
                .ForeColor = EnterpriseDesignSystem.NeutralColors.White
                .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold)
                .FlatStyle = FlatStyle.Flat
                .Size = EnterpriseDesignSystem.ControlSizes.ButtonMedium
                .Cursor = Cursors.Hand
            End With
            Button1.FlatAppearance.BorderSize = 0

            Dim originalColor = Button1.BackColor
            AddHandler Button1.MouseEnter, Sub(s, e)
                                               Button1.BackColor = ControlPaint.Light(originalColor, 0.1F)
                                           End Sub
            AddHandler Button1.MouseLeave, Sub(s, e)
                                               Button1.BackColor = originalColor
                                           End Sub
        End If
    End Sub

    Private Sub DisplayInstructions()
        TextBox1.Text = "═══════════════════════════════════════" & vbCrLf &
    "📚 POLYMORPHISM DEMONSTRATION" & vbCrLf &
         "═══════════════════════════════════════" & vbCrLf & vbCrLf &
       "Polymorphism allows objects of different types to be" & vbCrLf &
     "treated through a common base type." & vbCrLf & vbCrLf &
       "Example: call Speak() on an Animal reference that" & vbCrLf &
     "points to different derived types (Dog, Cat, Bird)." & vbCrLf & vbCrLf &
     "Click the button to run the demo and append results below." & vbCrLf & vbCrLf &
              "💡 Key Concept: Same interface, different behavior!"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            TextBox1.AppendText(vbCrLf & "═══════════════════════════════════════" & vbCrLf)
            TextBox1.AppendText("🔄 POLYMORPHISM DEMO - Running..." & vbCrLf)
            TextBox1.AppendText("═══════════════════════════════════════" & vbCrLf & vbCrLf)

            ' Demonstrate polymorphism with Dog
            TextBox1.AppendText("1️⃣ Dog via Animal reference:" & vbCrLf)
            Dim a As Animal = New Dog()
            TextBox1.AppendText($"   Speak(): {a.Speak()}" & vbCrLf)
            TextBox1.AppendText($"   Eat(): {a.Eat()}" & vbCrLf & vbCrLf)

            ' Demonstrate polymorphism with Cat
            TextBox1.AppendText("2️⃣ Cat via Animal reference:" & vbCrLf)
            a = New Cat()
            TextBox1.AppendText($"   Speak(): {a.Speak()}" & vbCrLf)
            TextBox1.AppendText($"   Eat(): {a.Eat()}" & vbCrLf & vbCrLf)

            ' Demonstrate polymorphism with Bird
            TextBox1.AppendText("3️⃣ Bird via Animal reference:" & vbCrLf)
            a = New Bird()
            TextBox1.AppendText($"   Speak(): {a.Speak()}" & vbCrLf)
            TextBox1.AppendText($"   Eat(): {a.Eat()} (uses base)" & vbCrLf & vbCrLf)

            TextBox1.AppendText("═══════════════════════════════════════" & vbCrLf)
            TextBox1.AppendText("✅ Demo Complete!" & vbCrLf)
            TextBox1.AppendText("💡 Same reference type, different behaviors" & vbCrLf)

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Polymorphism demo executed")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Polymorphism error: {ex.Message}")
            End If
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        TextBox1.ReadOnly = True
    End Sub
End Class

' Base class Animal
Public MustInherit Class Animal
    ''' <summary>
    ''' Abstract method that must be implemented by derived classes
    ''' </summary>
    Public MustOverride Function Speak() As String

    ''' <summary>
    ''' Virtual method that can be overridden
    ''' </summary>
    Public Overridable Function Eat() As String
        Return "Animal is eating"
    End Function

    ''' <summary>
    ''' Regular method
    ''' </summary>
    Public Function Sleep() As String
        Return "Animal is sleeping"
    End Function
End Class

' Derived class Dog
Public Class Dog
    Inherits Animal

    Public Overrides Function Speak() As String
        Return "Dog barks: Woof! Woof!"
    End Function

    Public Overrides Function Eat() As String
        Return "Dog is eating dog food"
    End Function
End Class

' Derived class Cat
Public Class Cat
    Inherits Animal

    Public Overrides Function Speak() As String
        Return "Cat meows: Meow! Meow!"
    End Function

    Public Overrides Function Eat() As String
        Return "Cat is eating fish"
    End Function
End Class

' Derived class Bird
Public Class Bird
    Inherits Animal

    Public Overrides Function Speak() As String
        Return "Bird chirps: Tweet! Tweet!"
    End Function

    ' This class doesn't override Eat(), so it uses the base implementation
End Class