Imports System.Drawing
Imports System.Windows.Forms

Public Class FormLogicalOperators
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
    Private chkValue1 As CheckBox
    Private chkValue2 As CheckBox

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

    Private Sub FormLogicalOperators_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DisplayWelcomeMessage()
    End Sub

    Private Sub InitializeEnterpriseUI()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.BackgroundImage = Nothing

        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
                              ControlStyles.AllPaintingInWmPaint Or
                           ControlStyles.UserPaint, True)
        End If

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
            .Text = "🔗 Logical Operators",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
        .AutoSize = True,
    .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
          .Text = "Boolean logic: And, Or, Not, Xor, AndAlso, OrElse",
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
            .Height = 130,
               .BackColor = Color.White,
               .Padding = New Padding(32, 20, 32, 20)
           }

        Dim lblTitle = New Label With {
    .Text = "💡 Logical Operators in VB.NET",
       .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.FromArgb(45, 55, 72),
.AutoSize = True,
            .Location = New Point(32, 16)
        }

        Dim lblText = New Label With {
   .Text = "And (both true)  Or (either true)  Not (inverse)  Xor (exactly one true)" & vbCrLf &
            "AndAlso/OrElse (short-circuit evaluation)  •  Toggle checkboxes to test!",
        .Font = New Font("Segoe UI", 10),
      .ForeColor = Color.FromArgb(100, 116, 139),
       .AutoSize = False,
          .Size = New Size(900, 60),
           .Location = New Point(32, 48)
           }

        pnlInstructions.Controls.AddRange({lblTitle, lblText})
        Me.Controls.Add(pnlInstructions)
    End Sub

    Private Sub CreateInputSection()
        pnlInputs = New Panel With {
          .Dock = DockStyle.Top,
        .Height = 80,
            .BackColor = Color.FromArgb(248, 250, 252),
  .Padding = New Padding(32, 16, 32, 16)
        }

        chkValue1 = New CheckBox With {
            .Text = "Input A (Boolean)",
            .Location = New Point(32, 20),
            .AutoSize = True,
       .Font = New Font("Segoe UI", 11, FontStyle.Bold),
     .Checked = True,
            .Cursor = Cursors.Hand
        }

        chkValue2 = New CheckBox With {
.Text = "Input B (Boolean)",
  .Location = New Point(250, 20),
   .AutoSize = True,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Checked = False,
            .Cursor = Cursors.Hand
        }

        AddHandler chkValue1.CheckedChanged, AddressOf CheckBox_Changed
        AddHandler chkValue2.CheckedChanged, AddressOf CheckBox_Changed

        pnlInputs.Controls.AddRange({chkValue1, chkValue2})
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
        .Text = "⚡ Evaluate Logic",
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
            .Text = "Enterprise Learning Platform|  Operators Module",
     .Font = New Font("Segoe UI", 8),
            .ForeColor = Color.FromArgb(220, 220, 220),
            .Dock = DockStyle.Fill,
    .TextAlign = ContentAlignment.MiddleCenter
        }

        pnlFooter.Controls.Add(lblFooter)
        Me.Controls.Add(pnlFooter)
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub DisplayWelcomeMessage()
        txtOutput.Text = "═══════════════════════════════════════════════════════════════" & vbCrLf &
       "  LOGICAL OPERATORS DEMONSTRATION" & vbCrLf &
         "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
           "Toggle the checkboxes above and click 'Evaluate Logic' to see" & vbCrLf &
            "how logical operators work!" & vbCrLf & vbCrLf &
       "Operators:" & vbCrLf &
              "  And      Both must be True" & vbCrLf &
      "  Or       At least one must be True" & vbCrLf &
                "  Not      Inverts the value" & vbCrLf &
        "  Xor      Exactly one must be True" & vbCrLf &
         "  AndAlso  Short-circuit And" & vbCrLf &
          "  OrElse   Short-circuit Or" & vbCrLf & vbCrLf &
           "Current: A = " & chkValue1.Checked.ToString() & ", B = " & chkValue2.Checked.ToString() & vbCrLf & vbCrLf &
             "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub CheckBox_Changed(sender As Object, e As EventArgs)
        ' Auto-update display when checkboxes change
        DisplayWelcomeMessage()
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        Try
            Dim a = chkValue1.Checked
            Dim b = chkValue2.Checked

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("🔗 LOGICAL OPERATORS RESULTS")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine($"Input Values: A = {a}, B = {b}")
            output.AppendLine()
            output.AppendLine("───────────────────────────────────────────────────────────────")

            ' And
            output.AppendLine("AND - Both must be True")
            output.AppendLine($"   {a} And {b}  →  {a And b}")
            output.AppendLine()

            ' Or
            output.AppendLine("OR - At least one must be True")
            output.AppendLine($"   {a} Or {b}  →  {a Or b}")
            output.AppendLine()

            ' Not
            output.AppendLine("NOT - Inverts the value")
            output.AppendLine($"   Not {a}  →  {Not a}")
            output.AppendLine($"   Not {b}  →  {Not b}")
            output.AppendLine()

            ' Xor
            output.AppendLine("XOR - Exactly one must be True")
            output.AppendLine($"   {a} Xor {b}  →  {a Xor b}")
            output.AppendLine()

            ' AndAlso
            output.AppendLine("ANDALSO - Short-circuit And (stops if first is False)")
            output.AppendLine($"   {a} AndAlso {b}  →  {a AndAlso b}")
            output.AppendLine()

            ' OrElse
            output.AppendLine("ORELSE - Short-circuit Or (stops if first is True)")
            output.AppendLine($"   {a} OrElse {b}  →  {a OrElse b}")
            output.AppendLine()

            ' Truth table summary
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("TRUTH TABLE SUMMARY")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine($"A={a,-6}  B={b,-6}  And={a And b,-6}  Or={a Or b,-6}  Xor={a Xor b,-6}")
            output.AppendLine()
            output.AppendLine("Try different combinations by toggling the checkboxes!")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        chkValue1.Checked = True
        chkValue2.Checked = False
        DisplayWelcomeMessage()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

#End Region

End Class