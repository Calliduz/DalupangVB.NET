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

        ' Enable performance optimizations
        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
               ControlStyles.AllPaintingInWmPaint Or
             ControlStyles.UserPaint, True)
        End If

        CreateHeader()
        CreateInstructions()
        CreateOutputArea()
        CreateButtons()
        CreateFooter()
    End Sub

    Private Sub CreateHeader()
        ' Header panel
        pnlHeader = New Panel With {
               .Dock = DockStyle.Top,
               .Height = 100,
             .BackColor = EnterpriseDesignSystem.ModuleColors.OOP,
               .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.Large)
           }

        ' Title label
        lblTitle = New Label With {
    .Text = "🔄 Polymorphism Demonstration",
      .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Hero, FontStyle.Bold),
        .ForeColor = EnterpriseDesignSystem.NeutralColors.White,
            .AutoSize = True,
            .Location = New Point(EnterpriseDesignSystem.Spacing.Large, EnterpriseDesignSystem.Spacing.Large)
      }

        ' Description label
        lblDescription = New Label With {
        .Text = "Learn how objects of different types respond to the same method calls",
   .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body),
        .ForeColor = ColorHelper.Lighten(EnterpriseDesignSystem.NeutralColors.White, 0.2),
            .AutoSize = True,
     .Location = New Point(EnterpriseDesignSystem.Spacing.Large, 55)
        }

        pnlHeader.Controls.AddRange({lblTitle, lblDescription})
        Me.Controls.Add(pnlHeader)
    End Sub

    Private Sub CreateInstructions()
        ' Instructions panel with proper spacing
        pnlInstructions = New Panel With {
              .Dock = DockStyle.Top,
     .Height = 150,
           .BackColor = EnterpriseDesignSystem.LightTheme.Surface,
              .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
          }

        Dim lblInstructionsTitle = New Label With {
        .Text = "💡 What is Polymorphism?",
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.H3, FontStyle.Bold),
    .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary,
     .Dock = DockStyle.Top,
    .Height = 30
 }

        Dim lblInstructionsText = New Label With {
                 .Text = "Polymorphism allows objects of different types to be treated through a common base type." & vbCrLf & vbCrLf &
                   "Example: Call Speak() on an Animal reference that points to Dog, Cat, or Bird objects." & vbCrLf &
                   "Each type responds differently, demonstrating polymorphic behavior.",
                 .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body),
                 .ForeColor = EnterpriseDesignSystem.LightTheme.TextSecondary,
           .Dock = DockStyle.Fill,
                 .AutoSize = False
           }

        pnlInstructions.Controls.AddRange({lblInstructionsText, lblInstructionsTitle})
        Me.Controls.Add(pnlInstructions)
    End Sub

    Private Sub CreateOutputArea()
        ' Content panel
        pnlContent = New Panel With {
      .Dock = DockStyle.Fill,
            .BackColor = EnterpriseDesignSystem.LightTheme.Background,
            .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
 }

        ' Output text box with professional styling
        txtOutput = New TextBox With {
.Multiline = True,
            .ScrollBars = ScrollBars.Vertical,
       .ReadOnly = True,
       .Dock = DockStyle.Fill,
        .Font = EnterpriseDesignSystem.CreateMonospaceFont(EnterpriseDesignSystem.FontSizes.Body),
            .BackColor = EnterpriseDesignSystem.LightTheme.Surface,
  .ForeColor = EnterpriseDesignSystem.LightTheme.TextPrimary,
     .BorderStyle = BorderStyle.None,
  .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.Large)
        }

        ' Add subtle border effect using a panel
        Dim pnlTextBoxBorder = New Panel With {
                   .Dock = DockStyle.Fill,
                   .BackColor = EnterpriseDesignSystem.LightTheme.Border,
                   .Padding = New Padding(1)
               }
        pnlTextBoxBorder.Controls.Add(txtOutput)

        pnlContent.Controls.Add(pnlTextBoxBorder)
        Me.Controls.Add(pnlContent)
    End Sub

    Private Sub CreateButtons()
        ' Button panel
        Dim pnlButtons = New Panel With {
       .Dock = DockStyle.Bottom,
            .Height = EnterpriseDesignSystem.ControlSizes.ButtonMedium.Height + (EnterpriseDesignSystem.Spacing.XLarge * 2),
    .BackColor = EnterpriseDesignSystem.LightTheme.Surface,
      .Padding = EnterpriseDesignSystem.CreatePadding(EnterpriseDesignSystem.Spacing.XLarge)
        }

        ' Run button
        btnRun = New Button With {
        .Text = "▶️ Run Demonstration",
      .Size = New Size(200, EnterpriseDesignSystem.ControlSizes.ButtonMedium.Height),
              .Location = New Point(EnterpriseDesignSystem.Spacing.XLarge, EnterpriseDesignSystem.Spacing.Large),
              .FlatStyle = FlatStyle.Flat,
         .BackColor = EnterpriseDesignSystem.SemanticColors.Success,
    .ForeColor = EnterpriseDesignSystem.NeutralColors.White,
         .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold),
              .Cursor = Cursors.Hand
       }
        btnRun.FlatAppearance.BorderSize = 0

        ' Clear button
        btnClear = New Button With {
    .Text = "🗑️ Clear Output",
          .Size = New Size(150, EnterpriseDesignSystem.ControlSizes.ButtonMedium.Height),
        .Location = New Point(btnRun.Right + EnterpriseDesignSystem.Spacing.Medium, EnterpriseDesignSystem.Spacing.Large),
 .FlatStyle = FlatStyle.Flat,
            .BackColor = EnterpriseDesignSystem.SemanticColors.Warning,
        .ForeColor = EnterpriseDesignSystem.NeutralColors.White,
            .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body, FontStyle.Bold),
            .Cursor = Cursors.Hand
        }
        btnClear.FlatAppearance.BorderSize = 0

        ' Add hover effects
        AddButtonHoverEffect(btnRun, EnterpriseDesignSystem.SemanticColors.Success)
        AddButtonHoverEffect(btnClear, EnterpriseDesignSystem.SemanticColors.Warning)

        ' Wire up events
        AddHandler btnRun.Click, AddressOf RunDemo_Click
        AddHandler btnClear.Click, AddressOf ClearOutput_Click

        pnlButtons.Controls.AddRange({btnRun, btnClear})
        Me.Controls.Add(pnlButtons)
    End Sub

    Private Sub CreateFooter()
        pnlFooter = New Panel With {
      .Dock = DockStyle.Bottom,
   .Height = 40,
     .BackColor = EnterpriseDesignSystem.ModuleColors.OOP
           }

        Dim lblFooter = New Label With {
            .Text = "Enterprise Learning Platform | Object-Oriented Programming Module",
   .Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Caption),
.ForeColor = ColorHelper.Lighten(EnterpriseDesignSystem.NeutralColors.White, 0.2),
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
            output.AppendLine("   Calling: animal.Eat()")
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