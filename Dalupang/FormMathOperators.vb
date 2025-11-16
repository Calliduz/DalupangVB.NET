Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization

''' <summary>
''' Math Operators Educational Demonstration
''' Enterprise-grade operators learning tool with professional UI/UX
''' </summary>
Public Class FormMathOperators
    Inherits Form

#Region "Private Fields"

    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private pnlFooter As Panel
    Private lblTitle As Label
    Private lblDescription As Label
    Private txtOutput As TextBox
    Private btnEvaluate As Button
    Private btnClear As Button
    Private pnlInstructions As Panel
    Private pnlInputs As Panel
    Private txtValue1 As TextBox
    Private txtValue2 As TextBox
    Private lblValue1 As Label
    Private lblValue2 As Label

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

    Private Sub FormMathOperators_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        CreateInputSection()
        CreateInstructions()
        CreateHeader()
    End Sub

    Private Sub CreateHeader()
        pnlHeader = New Panel With {
    .Dock = DockStyle.Top,
      .Height = 110,
        .BackColor = EnterpriseDesignSystem.ModuleColors.Operators,
     .Padding = New Padding(24, 20, 24, 20)
        }

        lblTitle = New Label With {
          .Text = "➕ Math Operators",
 .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = True,
            .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
        .Text = "Learn arithmetic operators: +, -, *, /, \, Mod, ^",
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
        .Height = 120,
     .BackColor = Color.White,
            .Padding = New Padding(32, 20, 32, 20)
  }

        Dim lblTitle = New Label With {
            .Text = "💡 Math Operators in VB.NET",
          .Font = New Font("Segoe UI", 13, FontStyle.Bold),
        .ForeColor = Color.FromArgb(45, 55, 72),
 .AutoSize = True,
            .Location = New Point(32, 16)
        }

        Dim lblText = New Label With {
    .Text = "+ (addition)  - (subtraction)  * (multiplication)  / (division)" & vbCrLf &
         "\ (integer division)  Mod (remainder)  ^ (power)",
.Font = New Font("Segoe UI", 10),
       .ForeColor = Color.FromArgb(100, 116, 139),
            .AutoSize = False,
            .Size = New Size(900, 50),
            .Location = New Point(32, 48)
        }

        pnlInstructions.Controls.AddRange({lblTitle, lblText})
        Me.Controls.Add(pnlInstructions)
    End Sub

    Private Sub CreateInputSection()
        pnlInputs = New Panel With {
 .Dock = DockStyle.Top,
      .Height = 70,
   .BackColor = Color.FromArgb(248, 250, 252),
         .Padding = New Padding(32, 16, 32, 16)
     }

        lblValue1 = New Label With {
 .Text = "Value 1:",
        .Location = New Point(32, 22),
  .AutoSize = True,
    .Font = New Font("Segoe UI", 10, FontStyle.Bold)
   }

        txtValue1 = New TextBox With {
       .Location = New Point(110, 19),
      .Width = 150,
            .Font = New Font("Segoe UI", 11),
            .Text = "10"
      }

        lblValue2 = New Label With {
            .Text = "Value 2:",
            .Location = New Point(300, 22),
            .AutoSize = True,
        .Font = New Font("Segoe UI", 10, FontStyle.Bold)
      }

        txtValue2 = New TextBox With {
    .Location = New Point(378, 19),
   .Width = 150,
            .Font = New Font("Segoe UI", 11),
      .Text = "3"
        }

        pnlInputs.Controls.AddRange({lblValue1, txtValue1, lblValue2, txtValue2})
        Me.Controls.Add(pnlInputs)
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

        btnEvaluate = New Button With {
       .Text = "🔢 Calculate All",
 .Size = New Size(180, 40),
            .Location = New Point(32, 16),
            .FlatStyle = FlatStyle.Flat,
 .BackColor = Color.FromArgb(34, 197, 94),
      .ForeColor = Color.White,
  .Font = New Font("Segoe UI", 10, FontStyle.Bold),
   .Cursor = Cursors.Hand
        }
        btnEvaluate.FlatAppearance.BorderSize = 0

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

        AddButtonHoverEffect(btnEvaluate, Color.FromArgb(34, 197, 94))
        AddButtonHoverEffect(btnClear, Color.FromArgb(251, 191, 36))

        AddHandler btnEvaluate.Click, AddressOf btnEvaluate_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click

        pnlButtons.Controls.AddRange({btnEvaluate, btnClear})
        Me.Controls.Add(pnlButtons)
    End Sub

    Private Sub CreateFooter()
        pnlFooter = New Panel With {
         .Dock = DockStyle.Bottom,
            .Height = 36,
            .BackColor = EnterpriseDesignSystem.ModuleColors.Operators
        }

        Dim lblFooter = New Label With {
            .Text = "Enterprise Learning Platform  |  Operators Module",
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
        txtOutput.Text = "???????????????????????????????????????????????????????????????" & vbCrLf &
       "  MATH OPERATORS DEMONSTRATION" & vbCrLf &
         "???????????????????????????????????????????????????????????????" & vbCrLf & vbCrLf &
     "Enter two numbers above and click 'Calculate All' to see" & vbCrLf &
 "how all math operators work!" & vbCrLf & vbCrLf &
          "Operators:" & vbCrLf &
  "  +   Addition" & vbCrLf &
     "  -   Subtraction" & vbCrLf &
         "  *   Multiplication" & vbCrLf &
  "  /   Division" & vbCrLf &
        "  \   Integer Division" & vbCrLf &
        "  Mod Remainder (Modulus)" & vbCrLf &
 "  ^   Power (Exponentiation)" & vbCrLf & vbCrLf &
     "???????????????????????????????????????????????????????????????"
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        Try
            ' Validate inputs
            Dim val1Result = ValidationHelper.IsNumeric(txtValue1.Text, "Value 1")
            Dim val2Result = ValidationHelper.IsNumeric(txtValue2.Text, "Value 2")

            Dim validation = ValidationHelper.ValidateAll(val1Result, val2Result)
            If Not validation.IsValid Then
                MessageBox.Show(validation.ErrorMessage, "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Return
            End If

            Dim n1 As Double = Double.Parse(txtValue1.Text, CultureInfo.CurrentCulture)
            Dim n2 As Double = Double.Parse(txtValue2.Text, CultureInfo.CurrentCulture)

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("???????????????????????????????????????????????????????????????")
            output.AppendLine("? MATH OPERATORS RESULTS")
            output.AppendLine("???????????????????????????????????????????????????????????????")
            output.AppendLine()
            output.AppendLine($"Input Values: {FormattingHelper.FormatNumber(n1, 2)} and {FormattingHelper.FormatNumber(n2, 2)}")
            output.AppendLine()

            ' Addition
            output.AppendLine("???????????????????????????????????????????????????????????????")
            output.AppendLine("? ADDITION (+)")
            output.AppendLine($"   {n1} + {n2} = {FormattingHelper.FormatNumber(n1 + n2, 2)}")
            output.AppendLine()

            ' Subtraction
            output.AppendLine("? SUBTRACTION (-)")
            output.AppendLine($"   {n1} - {n2} = {FormattingHelper.FormatNumber(n1 - n2, 2)}")
            output.AppendLine()

            ' Multiplication
            output.AppendLine("?? MULTIPLICATION (*)")
            output.AppendLine($"   {n1} * {n2} = {FormattingHelper.FormatNumber(n1 * n2, 2)}")
            output.AppendLine()

            ' Division
            output.AppendLine("? DIVISION (/)")
            If n2 = 0 Then
                output.AppendLine($"   {n1} / {n2} = ERROR (Division by zero!)")
            Else
                output.AppendLine($"   {n1} / {n2} = {FormattingHelper.FormatNumber(n1 / n2, 4)}")
            End If
            output.AppendLine()

            ' Integer Division
            output.AppendLine("?? INTEGER DIVISION (\)")
            If n2 = 0 Then
                output.AppendLine($"   {n1} \ {n2} = ERROR (Division by zero!)")
            Else
                Dim intDiv = Convert.ToInt64(Math.Truncate(n1)) \ Convert.ToInt64(Math.Truncate(n2))
                output.AppendLine($"   {Math.Truncate(n1)} \ {Math.Truncate(n2)} = {intDiv}")
                output.AppendLine("   (Truncates to integer, discards decimal)")
            End If
            output.AppendLine()

            ' Modulus
            output.AppendLine("?? MODULUS (Mod)")
            If n2 = 0 Then
                output.AppendLine($"   {n1} Mod {n2} = ERROR (Modulo by zero!)")
            Else
                Dim modResult = Convert.ToInt64(Math.Truncate(n1)) Mod Convert.ToInt64(Math.Truncate(n2))
                output.AppendLine($"   {Math.Truncate(n1)} Mod {Math.Truncate(n2)} = {modResult}")
                output.AppendLine("   (Remainder after integer division)")
            End If
            output.AppendLine()

            ' Power
            output.AppendLine("? POWER (^)")
            Try
                Dim powResult = Math.Pow(n1, n2)
                output.AppendLine($"   {n1} ^ {n2} = {FormattingHelper.FormatNumber(powResult, 4)}")
                output.AppendLine($"   ({n1} raised to the power of {n2})")
            Catch ex As Exception
                output.AppendLine($"   {n1} ^ {n2} = ERROR ({ex.Message})")
            End Try

            output.AppendLine()
            output.AppendLine("???????????????????????????????????????????????????????????????")

            txtOutput.Text = output.ToString()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Math operators evaluated: {n1}, {n2}")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Math operators error: {ex.Message}")
            End If
            MessageBox.Show($"An error occurred: {ex.Message}", "Error",
          MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
        txtValue1.Text = "10"
        txtValue2.Text = "3"
        txtValue1.Focus()
    End Sub

#End Region

End Class