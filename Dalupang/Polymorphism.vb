Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Polymorphism Educational Demonstration
''' Enterprise-grade OOP learning tool with professional UI/UX
''' </summary>
Public Class Polymorphism
    Inherits Form

#Region "Private Fields"

    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private pnlFooter As Panel
    Private lblTitle As Label
    Private lblDescription As Label
    Private txtOutput As TextBox
    Private btnRun As Button
    Private btnClear As Button
    Private pnlInstructions As Panel

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()

        ' CRITICAL: Clear any designer-created controls immediately
        Me.Controls.Clear()
        Me.BackgroundImage = Nothing

        ' Now build the enterprise UI
        InitializeEnterpriseUI()
    End Sub

#End Region

#Region "Form Initialization"

    Private Sub Polymorphism_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayWelcomeMessage()
    End Sub

    Private Sub InitializeEnterpriseUI()
        ' Apply enterprise design system
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
        Me.BackgroundImage = Nothing ' Force remove background

        ' Enable performance optimizations
        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
         ControlStyles.AllPaintingInWmPaint Or
     ControlStyles.UserPaint, True)
        End If

        ' CRITICAL: Add panels in reverse dock order (bottom-to-top)
        CreateFooter()    ' Add footer first (bottom)
        CreateButtons()      ' Then buttons (bottom)
        CreateOutputArea()   ' Then content (fill)
        CreateInstructions() ' Then instructions (top)
        CreateHeader()       ' Finally header (top)
    End Sub

    Private Sub CreateHeader()
        pnlHeader = New Panel With {
          .Dock = DockStyle.Top,
            .Height = 110,
            .BackColor = EnterpriseDesignSystem.ModuleColors.OOP,
.Padding = New Padding(24, 20, 24, 20)
        }

        lblTitle = New Label With {
    .Text = "🔄 Polymorphism Demonstration",
  .Font = New Font("Segoe UI", 18, FontStyle.Bold),
 .ForeColor = Color.White,
       .AutoSize = True,
            .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
    .Text = "Learn how objects of different types respond to the same method calls",
     .Font = New Font("Segoe UI", 10),
 .ForeColor = Color.FromArgb(240, 240, 240),
            .AutoSize = True,
     .Location = New Point(24, 50)
        }

        pnlHeader.Controls.AddRange({lblTitle, lblDescription})
        Me.Controls.Add(pnlHeader)
    End Sub

    Private Sub CreateInstructions()
        pnlInstructions = New Panel With {
            .Dock = DockStyle.Top,
            .Height = 150,
      .BackColor = Color.White,
            .Padding = New Padding(32, 24, 32, 24)
        }

        Dim lblTitle = New Label With {
            .Text = "💡 What is Polymorphism?",
    .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.FromArgb(45, 55, 72),
       .AutoSize = True,
       .Location = New Point(32, 20)
        }

        Dim lblText = New Label With {
.Text = "Polymorphism allows objects of different types to be treated through a common base type." & vbCrLf & vbCrLf &
    "Example: Call Speak() on an Animal reference pointing to Dog, Cat, or Bird objects.",
    .Font = New Font("Segoe UI", 10),
            .ForeColor = Color.FromArgb(100, 116, 139),
            .AutoSize = False,
            .Size = New Size(900, 80),
            .Location = New Point(32, 52)
        }

        pnlInstructions.Controls.AddRange({lblTitle, lblText})
        Me.Controls.Add(pnlInstructions)
    End Sub

    Private Sub CreateOutputArea()
        pnlContent = New Panel With {
            .Dock = DockStyle.Fill,
          .BackColor = EnterpriseDesignSystem.LightTheme.Background,
            .Padding = New Padding(32, 24, 32, 24)
        }

        txtOutput = New TextBox With {
  .Multiline = True,
      .ScrollBars = ScrollBars.Vertical,
            .ReadOnly = True,
      .Dock = DockStyle.Fill,
        .Font = New Font("Consolas", 10),
.BackColor = Color.White,
      .ForeColor = Color.FromArgb(45, 55, 72),
            .BorderStyle = BorderStyle.FixedSingle,
     .Padding = New Padding(16)
     }

        pnlContent.Controls.Add(txtOutput)
        Me.Controls.Add(pnlContent)
    End Sub

    Private Sub CreateButtons()
        Dim pnlButtons = New Panel With {
       .Dock = DockStyle.Bottom,
          .Height = 80,
     .BackColor = Color.White,
            .Padding = New Padding(32, 16, 32, 16)
        }

        btnRun = New Button With {
     .Text = "▶️ Run Demonstration",
            .Size = New Size(180, 40),
    .Location = New Point(32, 16),
      .FlatStyle = FlatStyle.Flat,
   .BackColor = Color.FromArgb(34, 197, 94),
  .ForeColor = Color.White,
        .Font = New Font("Segoe UI", 10, FontStyle.Bold),
     .Cursor = Cursors.Hand
        }
        btnRun.FlatAppearance.BorderSize = 0

        btnClear = New Button With {
            .Text = "🗑️ Clear",
   .Size = New Size(120, 40),
            .Location = New Point(224, 16),
   .FlatStyle = FlatStyle.Flat,
       .BackColor = Color.FromArgb(251, 191, 36),
 .ForeColor = Color.White,
  .Font = New Font("Segoe UI", 10, FontStyle.Bold),
        .Cursor = Cursors.Hand
   }
        btnClear.FlatAppearance.BorderSize = 0

        AddButtonHoverEffect(btnRun, Color.FromArgb(34, 197, 94))
        AddButtonHoverEffect(btnClear, Color.FromArgb(251, 191, 36))

        AddHandler btnRun.Click, AddressOf RunDemo_Click
        AddHandler btnClear.Click, AddressOf ClearOutput_Click

        pnlButtons.Controls.AddRange({btnRun, btnClear})
        Me.Controls.Add(pnlButtons)
    End Sub

    Private Sub CreateFooter()
        pnlFooter = New Panel With {
            .Dock = DockStyle.Bottom,
      .Height = 36,
  .BackColor = EnterpriseDesignSystem.ModuleColors.OOP
     }

        Dim lblFooter = New Label With {
   .Text = "Enterprise Learning Platform  |  Object-Oriented Programming Module",
.Font = New Font("Segoe UI", 8),
          .ForeColor = Color.FromArgb(220, 220, 220),
      .Dock = DockStyle.Fill,
    .TextAlign = ContentAlignment.MiddleCenter
        }

        pnlFooter.Controls.Add(lblFooter)
        Me.Controls.Add(pnlFooter)
    End Sub

    Private Sub AddButtonHoverEffect(btn As Button, originalColor As Color)
        AddHandler btn.MouseEnter, Sub(s, e)
                                       btn.BackColor = ControlPaint.Light(originalColor, 0.2F)
                                   End Sub
        AddHandler btn.MouseLeave, Sub(s, e)
                                       btn.BackColor = originalColor
                                   End Sub
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub DisplayWelcomeMessage()
        txtOutput.Text = "═══════════════════════════════════════════════════════════════" & vbCrLf &
              "  POLYMORPHISM DEMONSTRATION" & vbCrLf &
           "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
           "Welcome! This demonstration shows how polymorphism works in" & vbCrLf &
         "object-oriented programming." & vbCrLf & vbCrLf &
                 "Key Concepts:" & vbCrLf &
    "• Same method name, different implementations" & vbCrLf &
    "• Base class reference, derived class objects" & vbCrLf &
         "• Runtime method selection" & vbCrLf & vbCrLf &
        "Click 'Run Demonstration' to see polymorphism in action!" & vbCrLf & vbCrLf &
        "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub RunDemo_Click(sender As Object, e As EventArgs)
        Try
            txtOutput.Clear()

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  🔄 POLYMORPHISM IN ACTION")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("Creating different animals using Animal reference type...")
            output.AppendLine()

            ' Dog demonstration
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("1️⃣  DOG INSTANCE")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            Dim animal As Animal = New Dog()
            output.AppendLine("   Dim animal As Animal = New Dog()")
            output.AppendLine()
            output.AppendLine("   Calling: animal.Speak()")
            output.AppendLine($"   🐕 Result: {animal.Speak()}")
            output.AppendLine()
            output.AppendLine("   Calling: animal.Eat()")
            output.AppendLine($"   🍖 Result: {animal.Eat()}")
            output.AppendLine()

            ' Cat demonstration
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("2️⃣  CAT INSTANCE")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            animal = New Cat()
            output.AppendLine("   animal = New Cat()")
            output.AppendLine()
            output.AppendLine("   Calling: animal.Speak()")
            output.AppendLine($"   🐱 Result: {animal.Speak()}")
            output.AppendLine()
            output.AppendLine("Calling: animal.Eat()")
            output.AppendLine($"   🐟 Result: {animal.Eat()}")
            output.AppendLine()

            ' Bird demonstration
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("3️⃣  BIRD INSTANCE")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            animal = New Bird()
            output.AppendLine("   animal = New Bird()")
            output.AppendLine()
            output.AppendLine("   Calling: animal.Speak()")
            output.AppendLine($"   🐦 Result: {animal.Speak()}")
            output.AppendLine()
            output.AppendLine("   Calling: animal.Eat()")
            output.AppendLine($"   🌾 Result: {animal.Eat()}")
            output.AppendLine("   Note: Bird uses base class implementation")
            output.AppendLine()

            ' Summary
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  ✅ KEY OBSERVATIONS")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("✓ Same reference type (Animal) throughout")
            output.AppendLine("✓ Different object types (Dog, Cat, Bird)")
            output.AppendLine("✓ Same method calls produce different results")
            output.AppendLine("✓ Each type provides unique implementation")
            output.AppendLine("✓ Method selection happens at runtime")
            output.AppendLine()
            output.AppendLine("This is the power of Polymorphism! 🎯")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Polymorphism demo executed successfully")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Polymorphism error: {ex.Message}")
            End If
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
             MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearOutput_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
    End Sub

#End Region

End Class

#Region "Animal Class Hierarchy"

''' <summary>
''' Base Animal class - demonstrates abstraction
''' </summary>
Public MustInherit Class Animal
    Public MustOverride Function Speak() As String
    Public Overridable Function Eat() As String
        Return "Animal is eating"
    End Function
End Class

''' <summary>
''' Dog class - demonstrates polymorphism through method overriding
''' </summary>
Public Class Dog
    Inherits Animal
    Public Overrides Function Speak() As String
        Return "Woof! Woof! (Dog barking)"
    End Function
    Public Overrides Function Eat() As String
        Return "Dog is eating dog food"
    End Function
End Class

''' <summary>
''' Cat class - demonstrates polymorphism through method overriding
''' </summary>
Public Class Cat
    Inherits Animal
    Public Overrides Function Speak() As String
        Return "Meow! Meow! (Cat meowing)"
    End Function
    Public Overrides Function Eat() As String
        Return "Cat is eating fish"
    End Function
End Class

''' <summary>
''' Bird class - demonstrates use of base class implementation
''' </summary>
Public Class Bird
    Inherits Animal
    Public Overrides Function Speak() As String
        Return "Tweet! Tweet! (Bird chirping)"
    End Function
    ' Note: Eat() not overridden, uses base implementation
End Class

#End Region