Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Inheritance Educational Demonstration
''' Enterprise-grade OOP learning tool with professional UI/UX
''' </summary>
Public Class Form3
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

        ' CRITICAL: Clear designer controls and remove background
        Me.Controls.Clear()
        Me.BackgroundImage = Nothing

        InitializeEnterpriseUI()
    End Sub

#End Region

#Region "Form Initialization"

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayWelcomeMessage()
    End Sub

    Private Sub InitializeEnterpriseUI()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
  Me.Font = EnterpriseDesignSystem.CreateFont(EnterpriseDesignSystem.FontSizes.Body)
    Me.BackgroundImage = Nothing
     
 If AppConfiguration.Performance.EnableDoubleBuffering Then
       Me.DoubleBuffered = True
    Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or 
      ControlStyles.AllPaintingInWmPaint Or 
          ControlStyles.UserPaint, True)
        End If

        ' CRITICAL: Reverse dock order
     CreateFooter()
    CreateButtons()
  CreateOutputArea()
        CreateInstructions()
        CreateHeader()
    End Sub

    Private Sub CreateHeader()
      pnlHeader = New Panel With {
  .Dock = DockStyle.Top,
    .Height = 110,
       .BackColor = EnterpriseDesignSystem.ModuleColors.OOP,
     .Padding = New Padding(24, 20, 24, 20)
     }

        lblTitle = New Label With {
    .Text = "🔗 Inheritance Demonstration",
.Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
   .AutoSize = True,
    .Location = New Point(24, 16)
        }

    lblDescription = New Label With {
   .Text = "Learn how classes inherit properties and methods from base classes",
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
      .Text = "💡 What is Inheritance?",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
         .ForeColor = Color.FromArgb(45, 55, 72),
        .AutoSize = True,
            .Location = New Point(32, 20)
    }

     Dim lblText = New Label With {
  .Text = "Inheritance lets a class reuse and extend another class's functionality." & vbCrLf & vbCrLf &
    "Example: Dog and Cat inherit from Animal base class. Both override Speak() for custom behavior.",
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

        AddHandler btnRun.Click, AddressOf Button1_Click
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
      "  INHERITANCE DEMONSTRATION" & vbCrLf &
          "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
             "Welcome! This demonstration shows how inheritance works in" & vbCrLf &
            "object-oriented programming." & vbCrLf & vbCrLf &
                 "Key Concepts:" & vbCrLf &
                 "• Base class defines common functionality" & vbCrLf &
              "• Derived classes inherit and extend" & vbCrLf &
                 "• Override methods for specific behavior" & vbCrLf &
                 "• Code reuse and hierarchical organization" & vbCrLf & vbCrLf &
     "Click 'Run Demonstration' to see inheritance in action!" & vbCrLf & vbCrLf &
            "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            txtOutput.Clear()

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  🔗 INHERITANCE IN ACTION")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("Creating Dog and Cat instances that inherit from Animal...")
            output.AppendLine()

            ' Dog demonstration
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("1️⃣  DOG (inherits from Animal)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            Dim dog As Animal = New Dog()
            output.AppendLine("   Dim dog As Animal = New Dog()")
            output.AppendLine()
            output.AppendLine("   Calling: dog.Speak()")
            output.AppendLine($"   🐕 Result: {dog.Speak()}")
            output.AppendLine("   Note: Dog overrides the Speak() method")
            output.AppendLine()

            ' Cat demonstration
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("2️⃣  CAT (inherits from Animal)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            Dim cat As Animal = New Cat()
            output.AppendLine("   Dim cat As Animal = New Cat()")
            output.AppendLine()
            output.AppendLine("   Calling: cat.Speak()")
            output.AppendLine($"   🐱 Result: {cat.Speak()}")
            output.AppendLine("   Note: Cat overrides the Speak() method")
            output.AppendLine()

            ' Summary
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  ✅ INHERITANCE BENEFITS")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("✓ Code Reuse: Both Dog and Cat inherit from Animal")
            output.AppendLine("✓ Method Overriding: Each provides specific Speak() behavior")
            output.AppendLine("✓ Common Interface: Both can be treated as Animal type")
            output.AppendLine("✓ Maintainability: Changes to Animal affect all descendants")
            output.AppendLine()
            output.AppendLine("This is the power of Inheritance! 🎯")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Inheritance demo executed successfully")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Inheritance error: {ex.Message}")
            End If
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
                     MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearOutput_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
    End Sub

    ' Preserve compatibility
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
        ' Compatibility handler
    End Sub

#End Region

#Region "Animal Class Hierarchy"

    ''' <summary>
    ''' Base Animal class
    ''' </summary>
    Public MustInherit Class Animal
        Public Overridable Function Speak() As String
            Return "Animal speaks"
        End Function
    End Class

    ''' <summary>
    ''' Dog class inherits from Animal
    ''' </summary>
    Public Class Dog
        Inherits Animal
        Public Overrides Function Speak() As String
            Return "Woof! Woof! (Dog barks)"
        End Function
    End Class

    ''' <summary>
    ''' Cat class inherits from Animal
    ''' </summary>
    Public Class Cat
        Inherits Animal
        Public Overrides Function Speak() As String
            Return "Meow! Meow! (Cat meows)"
        End Function
    End Class

#End Region

End Class
