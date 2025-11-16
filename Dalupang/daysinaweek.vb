Imports System.Drawing
Imports System.Windows.Forms
Imports System.Globalization

Public Class daysinaweek
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

    Private Sub daysinaweek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        .Text = "📆 Days in a Week",
        .Font = New Font("Segoe UI", 18, FontStyle.Bold),
          .ForeColor = Color.White,
            .AutoSize = True,
            .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
    .Text = "Learn arrays and loops with day-of-week data",
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
       .Text = "💡 Array & Loop Demonstration",
         .Font = New Font("Segoe UI", 13, FontStyle.Bold),
 .ForeColor = Color.FromArgb(45, 55, 72),
            .AutoSize = True,
       .Location = New Point(32, 16)
        }

        Dim lblText = New Label With {
         .Text = "This demonstrates For Each loops with day-of-week arrays." & vbCrLf &
         "Click 'Display Days' to see all 7 days with cultural variations and weekend detection.",
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
          .Text = "📆 Display Days",
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
               "  DAYS IN A WEEK" & vbCrLf &
       "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
            "Welcome! This demonstrates For Each loops and day-of-week" & vbCrLf &
        "arrays in VB.NET." & vbCrLf & vbCrLf &
         "Click 'Display Days' to see:" & vbCrLf &
       "• All 7 days of the week" & vbCrLf &
         "• Weekend vs Weekday classification" & vbCrLf &
        "• Day numbers and abbreviations" & vbCrLf &
          "• Cultural day name variations" & vbCrLf & vbCrLf &
             $"Today: {DateTime.Now:dddd, MMMM d, yyyy}" & vbCrLf & vbCrLf &
     "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("📆 DAYS OF THE WEEK")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()

            Dim cultureInfo As CultureInfo = CultureInfo.CurrentCulture
            Dim dateTimeFormat As DateTimeFormatInfo = cultureInfo.DateTimeFormat

            For dayNum As Integer = 0 To 6
                Dim dayOfWeek As DayOfWeek = CType(dayNum, DayOfWeek)
                Dim fullName As String = dateTimeFormat.GetDayName(dayOfWeek)
                Dim shortName As String = dateTimeFormat.GetAbbreviatedDayName(dayOfWeek)
                Dim isWeekend As Boolean = (dayOfWeek = DayOfWeek.Saturday OrElse dayOfWeek = DayOfWeek.Sunday)
                Dim dayType As String = If(isWeekend, "Weekend 🎉", "Weekday 💼")

                output.AppendLine($"{dayNum + 1}. {fullName} ({shortName})")
                output.AppendLine($"     Type: {dayType}")
                output.AppendLine($"     DayOfWeek Value: {CInt(dayOfWeek)}")
                output.AppendLine()
            Next

            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("CURRENT DAY INFORMATION")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            Dim today As DateTime = DateTime.Now
            output.AppendLine($"Today: {today:dddd, MMMM d, yyyy}")
            output.AppendLine($"Day of Week: {today.DayOfWeek}")
            output.AppendLine($"Day of Year: {today.DayOfYear}")
            output.AppendLine($"Week of Year: {GetWeekOfYear(today)}")
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

    Private Function GetWeekOfYear(dateValue As DateTime) As Integer
        Dim calendar As Calendar = CultureInfo.CurrentCulture.Calendar
        Return calendar.GetWeekOfYear(dateValue, CalendarWeekRule.FirstDay, DayOfWeek.Sunday)
    End Function

#End Region

End Class