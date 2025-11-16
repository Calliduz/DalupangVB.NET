Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization

Public Class FormRelationalOperators
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

    Private Sub FormRelationalOperators_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            .Text = "?? Relational Operators",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = True,
            .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
            .Text = "Compare values: >, <, >=, <=, =, <>",
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
            .Text = "?? Relational Operators in VB.NET",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.FromArgb(45, 55, 72),
            .AutoSize = True,
            .Location = New Point(32, 16)
        }

        Dim lblText = New Label With {
            .Text = "> (greater) < (less) >= (greater/equal) <= (less/equal) = (equal) <> (not equal)" & vbCrLf &
                        "Enter two values to compare - works with numbers and text!",
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
            .Text = "5"
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
            .Text = "?? Compare Values",
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
            .Text = "??? Clear",
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
        AddHandler btnClear.Click, AddressOf btnExampleClear_Click

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

#End Region

#Region "Event Handlers"

    Private Sub DisplayWelcomeMessage()
        txtOutput.Text = "???????????????????????????????????????????????????????????????" & vbCrLf &
                        "  RELATIONAL OPERATORS DEMONSTRATION" & vbCrLf &
                        "???????????????????????????????????????????????????????????????" & vbCrLf & vbCrLf &
                        "Enter two values above and click 'Compare Values' to see" & vbCrLf &
                        "how relational operators work!" & vbCrLf & vbCrLf &
                        "Operators:" & vbCrLf &
                        "  >   Greater than" & vbCrLf &
                        "  <   Less than" & vbCrLf &
                        "  >=  Greater than or equal" & vbCrLf &
                        "  <=  Less than or equal" & vbCrLf &
                        "  =   Equal to" & vbCrLf &
                        "  <>  Not equal to" & vbCrLf & vbCrLf &
                        "Works with numbers and text (lexical comparison)!" & vbCrLf & vbCrLf &
                        "???????????????????????????????????????????????????????????????"
    End Sub

    Private Sub btnEvaluate_Click(sender As Object, e As EventArgs)
        Try
            Dim s1 = txtValue1.Text.Trim()
            Dim s2 = txtValue2.Text.Trim()

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("???????????????????????????????????????????????????????????????")
            output.AppendLine("?? RELATIONAL OPERATORS RESULTS")
            output.AppendLine("???????????????????????????????????????????????????????????????")
            output.AppendLine()

            Dim n1, n2 As Double
            Dim bothNumbers = Double.TryParse(s1, NumberStyles.Any, CultureInfo.CurrentCulture, n1) AndAlso
                            Double.TryParse(s2, NumberStyles.Any, CultureInfo.CurrentCulture, n2)

            If bothNumbers Then
                output.AppendLine($"Numeric comparison: {n1} and {n2}")
                output.AppendLine()
                output.AppendLine("???????????????????????????????????????????????????????????????")
                output.AppendLine($"{n1} >  {n2}  ?  {n1 > n2}")
                output.AppendLine($"{n1} <  {n2}  ?  {n1 < n2}")
                output.AppendLine($"{n1} >= {n2}  ?  {n1 >= n2}")
                output.AppendLine($"{n1} <= {n2}?  {n1 <= n2}")
                output.AppendLine($"{n1} =  {n2}  ?  {n1 = n2}")
                output.AppendLine($"{n1} <> {n2}  ?  {n1 <> n2}")
            Else
                output.AppendLine($"String comparison (lexical): ""{s1}"" and ""{s2}""")
                output.AppendLine()
                output.AppendLine("???????????????????????????????????????????????????????????????")
                output.AppendLine($"""{s1}"" >  ""{s2}""  ?  {s1 > s2}")
                output.AppendLine($"""{s1}"" <  ""{s2}""  ?  {s1 < s2}")
                output.AppendLine($"""{s1}"" >= ""{s2}""  ?  {s1 >= s2}")
                output.AppendLine($"""{s1}"" <= ""{s2}""  ?  {s1 <= s2}")
                output.AppendLine($"""{s1}"" =  ""{s2}""  ?  {s1 = s2}")
                output.AppendLine($"""{s1}"" <> ""{s2}""  ?  {s1 <> s2}")
                output.AppendLine()
                Dim cmp = String.Compare(s1, s2, StringComparison.CurrentCulture)
                output.AppendLine($"String.Compare result: {cmp}")
                output.AppendLine("(negative: first < second, 0: equal, positive: first > second)")
            End If

            output.AppendLine()
            output.AppendLine("???????????????????????????????????????????????????????????????")

            txtOutput.Text = output.ToString()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExampleClear_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
        txtValue1.Text = "10"
        txtValue2.Text = "5"
        txtValue1.Focus()
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

#End Region

End Class