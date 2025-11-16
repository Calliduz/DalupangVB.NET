Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization

Public Class monthsinayear
    Inherits Form

#Region "Private Fields"

    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private pnlFooter As Panel
    Private lblTitle As Label
    Private lblDescription As Label
    Private txtOutput As TextBox
    Private btnGenerate As Button
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

    Private Sub monthsinayear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        CreateInstructions()
        CreateHeader()
    End Sub

    Private Sub CreateHeader()
        pnlHeader = New Panel With {
                   .Dock = DockStyle.Top,
        .Height = 110,
                   .BackColor = EnterpriseDesignSystem.ModuleColors.DataStructures,
       .Padding = New Padding(24, 20, 24, 20)
               }

        lblTitle = New Label With {
          .Text = "📅 Months in a Year",
         .Font = New Font("Segoe UI", 18, FontStyle.Bold),
                  .ForeColor = Color.White,
        .AutoSize = True,
                  .Location = New Point(24, 16)
          }

        lblDescription = New Label With {
     .Text = "Learn arrays and iteration with calendar data",
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
            .Text = "💡 Array Demonstration",
              .Font = New Font("Segoe UI", 13, FontStyle.Bold),
              .ForeColor = Color.FromArgb(45, 55, 72),
          .AutoSize = True,
                .Location = New Point(32, 16)
          }

        Dim lblText = New Label With {
          .Text = "This demonstrates array iteration and date/time manipulation." & vbCrLf &
          "Click 'Display Months' to see all 12 months with day counts and seasonal information.",
      .Font = New Font("Segoe UI", 10),
     .ForeColor = Color.FromArgb(100, 116, 139),
           .AutoSize = False,
        .Size = New Size(900, 60),
          .Location = New Point(32, 48)
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

        btnGenerate = New Button With {
                 .Text = "📅 Display Months",
      .Size = New Size(180, 40),
         .Location = New Point(32, 16),
          .FlatStyle = FlatStyle.Flat,
     .BackColor = Color.FromArgb(34, 197, 94),
            .ForeColor = Color.White,
          .Font = New Font("Segoe UI", 10, FontStyle.Bold),
              .Cursor = Cursors.Hand
             }
        btnGenerate.FlatAppearance.BorderSize = 0

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

        AddHandler btnGenerate.Click, AddressOf Button1_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click

        pnlButtons.Controls.AddRange({btnGenerate, btnClear})
        Me.Controls.Add(pnlButtons)
    End Sub

    Private Sub CreateFooter()
        pnlFooter = New Panel With {
  .Dock = DockStyle.Bottom,
   .Height = 36,
            .BackColor = EnterpriseDesignSystem.ModuleColors.DataStructures
    }

        Dim lblFooter = New Label With {
    .Text = "Enterprise Learning Platform  |  Data Structures Module",
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
   "  MONTHS IN A YEAR" & vbCrLf &
      "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
   "Welcome! This demonstrates array iteration and date/time" & vbCrLf &
   "manipulation in VB.NET." & vbCrLf & vbCrLf &
        "Click 'Display Months' to see:" & vbCrLf &
   "• All 12 months of the year" & vbCrLf &
       "• Number of days in each month" & vbCrLf &
      "• Seasonal information" & vbCrLf &
"• Quarter assignments" & vbCrLf & vbCrLf &
  $"Current Year: {DateTime.Now.Year}" & vbCrLf & vbCrLf &
       "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine($"📅 MONTHS OF {DateTime.Now.Year}")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()

            Dim cultureInfo As CultureInfo = CultureInfo.CurrentCulture
            Dim dateTimeFormat As DateTimeFormatInfo = cultureInfo.DateTimeFormat
            Dim currentYear As Integer = DateTime.Now.Year

            For monthNumber As Integer = 1 To 12
                Dim monthName As String = dateTimeFormat.GetMonthName(monthNumber)
                Dim daysInMonth As Integer = DateTime.DaysInMonth(currentYear, monthNumber)
                Dim quarter As Integer = CInt(Math.Ceiling(monthNumber / 3.0))
                Dim season As String = GetSeason(monthNumber)
                Dim firstDay As DateTime = New DateTime(currentYear, monthNumber, 1)

                output.AppendLine(monthNumber.ToString("00") & ". " & monthName)
                output.AppendLine($" Days: {daysInMonth}")
                output.AppendLine($"     Quarter: Q{quarter}")
                output.AppendLine($"   Season: {season}")
                output.AppendLine($"     Starts: {firstDay:dddd}")
                output.AppendLine()
            Next

            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("SUMMARY")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine($"Total Days in Year: {If(DateTime.IsLeapYear(currentYear), 366, 365)}")
            output.AppendLine($"Leap Year: {If(DateTime.IsLeapYear(currentYear), "Yes", "No")}")
            output.AppendLine($"Current Month: {dateTimeFormat.GetMonthName(DateTime.Now.Month)}")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()
        Catch ex As Exception
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        DisplayWelcomeMessage()
    End Sub

    Private Function GetSeason(monthNumber As Integer) As String
        Select Case monthNumber
            Case 12, 1, 2
                Return "Winter ❄️"
            Case 3, 4, 5
                Return "Spring 🌸"
            Case 6, 7, 8
                Return "Summer ☀️"
            Case 9, 10, 11
                Return "Fall 🍂"
            Case Else
                Return "Unknown"
        End Select
    End Function

#End Region

End Class