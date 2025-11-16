Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Interface Educational Demonstration
''' Enterprise-grade OOP learning tool with professional UI/UX
''' </summary>
Public Class InterfaceDemo
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
        Me.Controls.Clear()
        Me.BackgroundImage = Nothing
        InitializeEnterpriseUI()
    End Sub

#End Region

#Region "Form Initialization"

    Private Sub IntfaceDemo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
     .Text = "🔌 Interface Demonstration",
       .Font = New Font("Segoe UI", 18, FontStyle.Bold),
       .ForeColor = Color.White,
        .AutoSize = True,
        .Location = New Point(24, 16)
        }

   lblDescription = New Label With {
   .Text = "Learn how interfaces define contracts that classes must implement",
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
 .Height = 160,
       .BackColor = Color.White,
.Padding = New Padding(32, 24, 32, 24)
 }

     Dim lblTitle = New Label With {
 .Text = "💡 What is an Interface?",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
 .ForeColor = Color.FromArgb(45, 55, 72),
            .AutoSize = True,
         .Location = New Point(32, 20)
        }

    Dim lblText = New Label With {
.Text = "Interfaces define a contract that types must implement." & vbCrLf & vbCrLf &
       "Example: IPrintable interface with Print() method. Document, Photo, and Report all implement it.",
   .Font = New Font("Segoe UI", 10),
    .ForeColor = Color.FromArgb(100, 116, 139),
         .AutoSize = False,
   .Size = New Size(900, 90),
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
        "  INTERFACE DEMONSTRATION" & vbCrLf &
         "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
      "Welcome! This demonstration shows how interfaces work in" & vbCrLf &
       "object-oriented programming." & vbCrLf & vbCrLf &
      "Key Concepts:" & vbCrLf &
       "• Interfaces define contracts (method signatures)" & vbCrLf &
       "• Classes implement interfaces" & vbCrLf &
         "• Multiple classes can implement same interface" & vbCrLf &
      "• Enables polymorphism and loose coupling" & vbCrLf & vbCrLf &
            "Click 'Run Demonstration' to see interfaces in action!" & vbCrLf & vbCrLf &
           "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            txtOutput.Clear()

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  🔌 INTERFACE IN ACTION")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("Creating instances that implement IPrintable interface...")
            output.AppendLine()

            ' Document
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("1️⃣  DOCUMENT (implements IPrintable)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            Dim doc As New Document()
            output.AppendLine("   Dim doc As New Document()")
            output.AppendLine("   Calling: doc.Print()")
            output.AppendLine($"   📄 Result: {doc.Print()}")
            output.AppendLine()

            ' Photo
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("2️⃣  PHOTO (implements IPrintable)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            Dim photo As New Photo()
            output.AppendLine("   Dim photo As New Photo()")
            output.AppendLine("   Calling: photo.Print()")
            output.AppendLine($"   📷 Result: {photo.Print()}")
            output.AppendLine()

            ' Report
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("3️⃣  REPORT (implements IPrintable)")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            Dim report As New Report()
            output.AppendLine("   Dim report As New Report()")
            output.AppendLine("   Calling: report.Print()")
            output.AppendLine($"   📊 Result: {report.Print()}")
            output.AppendLine()

            ' Polymorphic usage
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("4️⃣  POLYMORPHIC USAGE")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()
            output.AppendLine("   Using interface reference for different types:")
            output.AppendLine()

            Dim printables As IPrintable() = {doc, photo, report}
            For Each item As IPrintable In printables
                output.AppendLine($"   → {item.Print()}")
            Next
            output.AppendLine()

            ' Summary
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  ✅ INTERFACE BENEFITS")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("✓ Common Contract: All implement Print() method")
            output.AppendLine("✓ Flexibility: Can add new printable types easily")
            output.AppendLine("✓ Polymorphism: Treat different types through same interface")
            output.AppendLine("✓ Loose Coupling: Code depends on interface, not concrete types")
            output.AppendLine()
            output.AppendLine("This is the power of Interfaces! 🎯")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Interface demo executed successfully")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Interface error: {ex.Message}")
            End If
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
              MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub ClearOutput_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
    End Sub

    ' Compatibility handlers
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)
    End Sub

#End Region

End Class

#Region "Interface and Implementations"

''' <summary>
''' IPrintable interface definition
''' </summary>
Public Interface IPrintable
    Function Print() As String
End Interface

''' <summary>
''' Document class implements IPrintable
''' </summary>
Public Class Document
    Implements IPrintable

    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Document... [Pages: 1-10]"
    End Function
End Class

''' <summary>
''' Photo class implements IPrintable
''' </summary>
Public Class Photo
    Implements IPrintable

    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Photo... [Resolution: 1920x1080]"
    End Function
End Class

''' <summary>
''' Report class implements IPrintable
''' </summary>
Public Class Report
    Implements IPrintable

    Public Function Print() As String Implements IPrintable.Print
        Return "Printing Report... [Format: PDF]"
    End Function
End Class

#End Region