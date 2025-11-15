Imports System.Globalization

''' <summary>
''' Weekly Days Display and Information
''' Educational demonstration of array operations and date/time concepts
''' </summary>
Public Class daysinaweek
    Inherits Form

#Region "Constants"

    Private Const DAYS_PER_WEEK As Integer = 7
    Private Const WORK_DAYS_PER_WEEK As Integer = 5
    Private Const WEEKEND_DAYS As Integer = 2

#End Region

#Region "Form Initialization"

    Private Sub daysinaweek_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
    End Sub

    ''' <summary>
    ''' Configure UI elements for optimal user experience
    ''' </summary>
    Private Sub InitializeUI()
        Me.Text = "Days of the Week - Educational Demonstration"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Configure ListBox
        ConfigureListBox()

        ' Configure Generate Button
        ConfigureButton()
    End Sub

    ''' <summary>
    ''' Configure ListBox styling and behavior
    ''' </summary>
    Private Sub ConfigureListBox()
        If ListBox1 IsNot Nothing Then
            With ListBox1
                .Font = New Font("Segoe UI", 12, FontStyle.Regular)
                .BackColor = Color.White
                .ForeColor = Color.FromArgb(50, 50, 50)
                .BorderStyle = BorderStyle.FixedSingle
                .SelectionMode = SelectionMode.One
                .IntegralHeight = False
            End With
        End If
    End Sub

    ''' <summary>
    ''' Configure button styling
    ''' </summary>
    Private Sub ConfigureButton()
        If Button1 IsNot Nothing Then
            With Button1
                .FlatStyle = FlatStyle.Flat
                .BackColor = Color.FromArgb(70, 130, 180)
                .ForeColor = Color.White
                .Font = New Font("Segoe UI", 11, FontStyle.Bold)
                .Cursor = Cursors.Hand
                .Text = "📆 Display All Days"
            End With
        End If
    End Sub

#End Region

#Region "Day Population"

    ''' <summary>
    ''' Populate the list with all seven days of the week
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        ListBox1.BeginUpdate()

        ' Use CultureInfo for proper day names
        Dim cultureInfo As CultureInfo = CultureInfo.CurrentCulture
        Dim dateTimeFormat As DateTimeFormatInfo = cultureInfo.DateTimeFormat

        ' Get all day names starting with Sunday (DayOfWeek.Sunday = 0)
        For dayNumber As Integer = 0 To DAYS_PER_WEEK - 1
            Dim dayOfWeek As DayOfWeek = CType(dayNumber, DayOfWeek)
            Dim dayName As String = dateTimeFormat.GetDayName(dayOfWeek)
            Dim dayType As String = GetDayType(dayOfWeek)
            Dim emoji As String = GetDayEmoji(dayOfWeek)

            ' Format: "🌅 Sunday (Weekend)"
            Dim displayText As String = $"{emoji} {dayName} ({dayType})"
            ListBox1.Items.Add(displayText)
        Next

        ListBox1.EndUpdate()

        ' Show success message
        MessageBox.Show(
         $"All {DAYS_PER_WEEK} days of the week have been loaded.{Environment.NewLine}{Environment.NewLine}" &
  $"• Weekdays: {WORK_DAYS_PER_WEEK} (Monday-Friday){Environment.NewLine}" &
              $"• Weekend: {WEEKEND_DAYS} (Saturday-Sunday){Environment.NewLine}{Environment.NewLine}" &
    "Select any day to view more information.",
   "Days Loaded Successfully",
         MessageBoxButtons.OK,
              MessageBoxIcon.Information
          )
    End Sub

    ''' <summary>
    ''' Get day type classification (Weekday/Weekend)
    ''' </summary>
    Private Function GetDayType(day As DayOfWeek) As String
        Select Case day
            Case DayOfWeek.Saturday, DayOfWeek.Sunday
                Return "Weekend"
            Case Else
                Return "Weekday"
        End Select
    End Function

    ''' <summary>
    ''' Get emoji representation for each day
    ''' </summary>
    Private Function GetDayEmoji(day As DayOfWeek) As String
        Select Case day
            Case DayOfWeek.Sunday
                Return "🌅" ' Sunrise
            Case DayOfWeek.Monday
                Return "💼" ' Briefcase
            Case DayOfWeek.Tuesday
                Return "📊" ' Chart
            Case DayOfWeek.Wednesday
                Return "🐫" ' Camel (hump day)
            Case DayOfWeek.Thursday
                Return "⚡" ' Lightning
            Case DayOfWeek.Friday
                Return "🎉" ' Party
            Case DayOfWeek.Saturday
                Return "🌴" ' Palm tree
            Case Else
                Return "📅"
        End Select
    End Function

#End Region

#Region "Event Handlers"

    ''' <summary>
    ''' Handle day selection to show details
    ''' </summary>
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex >= 0 Then
            Dim selectedDay As DayOfWeek = CType(ListBox1.SelectedIndex, DayOfWeek)
            ShowDayDetails(selectedDay)
        End If
    End Sub

    ''' <summary>
    ''' Display detailed information about selected day
    ''' </summary>
    Private Sub ShowDayDetails(day As DayOfWeek)
        Dim dayName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetDayName(day)
        Dim dayType As String = GetDayType(day)
        Dim isWeekend As Boolean = (day = DayOfWeek.Saturday OrElse day = DayOfWeek.Sunday)
        Dim dayNumber As Integer = CInt(day) + 1

        ' Get next occurrence of this day
        Dim today As Date = Date.Today
        Dim daysUntil As Integer = (CInt(day) - CInt(today.DayOfWeek) + 7) Mod 7
        Dim nextOccurrence As Date = today.AddDays(daysUntil)

        Dim details As String = $"📆 {dayName} Details{Environment.NewLine}" &
    $"━━━━━━━━━━━━━━━━━━━━━{Environment.NewLine}" &
            $"Day Number: {dayNumber} of {DAYS_PER_WEEK}{Environment.NewLine}" &
    $"Type: {dayType}{Environment.NewLine}" &
$"Weekend: {If(isWeekend, "Yes ✓", "No ✗")}{Environment.NewLine}" &
$"Next {dayName}: {nextOccurrence:MMMM d, yyyy}{Environment.NewLine}" &
      $"Days Until: {If(daysUntil = 0, "Today!", $"{daysUntil} days")}{Environment.NewLine}" &
 GetDayFact(day)

        MessageBox.Show(details, $"{dayName} Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Helper Methods"

    ''' <summary>
    ''' Get an interesting fact about the day
    ''' </summary>
    Private Function GetDayFact(day As DayOfWeek) As String
        Select Case day
            Case DayOfWeek.Sunday
                Return $"{Environment.NewLine}💡 Fun Fact: Named after the Sun"
            Case DayOfWeek.Monday
                Return $"{Environment.NewLine}💡 Fun Fact: Named after the Moon"
            Case DayOfWeek.Tuesday
                Return $"{Environment.NewLine}💡 Fun Fact: Named after Tiw (Norse god of war)"
            Case DayOfWeek.Wednesday
                Return $"{Environment.NewLine}💡 Fun Fact: Also called 'Hump Day' (middle of work week)"
            Case DayOfWeek.Thursday
                Return $"{Environment.NewLine}💡 Fun Fact: Named after Thor (Norse god of thunder)"
            Case DayOfWeek.Friday
                Return $"{Environment.NewLine}💡 Fun Fact: Named after Freya (Norse goddess of love)"
            Case DayOfWeek.Saturday
                Return $"{Environment.NewLine}💡 Fun Fact: Named after Saturn (Roman god)"
            Case Else
                Return ""
        End Select
    End Function

#End Region

End Class