Imports System.Globalization

''' <summary>
''' Monthly Calendar Information Display
''' Educational demonstration of array iteration and date/time manipulation
''' </summary>
Public Class monthsinayear
    Inherits Form

#Region "Constants"

    Private Const DAYS_PER_MONTH_MIN As Integer = 28
    Private Const DAYS_PER_MONTH_MAX As Integer = 31
    Private Const MONTHS_PER_YEAR As Integer = 12

#End Region

#Region "Form Initialization"

    Private Sub monthsinayear_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
    End Sub

    ''' <summary>
    ''' Configure UI elements for optimal user experience
    ''' </summary>
    Private Sub InitializeUI()
        Me.Text = "Monthly Calendar - Educational Demonstration"
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
                .Text = "📅 Display All Months"
            End With
        End If
    End Sub

#End Region

#Region "Month Population"

    ''' <summary>
    ''' Populate the list with all twelve months
    ''' </summary>
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ListBox1.Items.Clear()
        ListBox1.BeginUpdate()

        ' Use CultureInfo for proper month names
        Dim cultureInfo As CultureInfo = CultureInfo.CurrentCulture
        Dim dateTimeFormat As DateTimeFormatInfo = cultureInfo.DateTimeFormat

        ' Add all months with day count
        For monthNumber As Integer = 1 To MONTHS_PER_YEAR
            Dim monthName As String = dateTimeFormat.GetMonthName(monthNumber)
            Dim daysInMonth As Integer = DateTime.DaysInMonth(DateTime.Now.Year, monthNumber)

            ' Format: "01. January (31 days)"
            Dim displayText As String = $"{monthNumber:00}. {monthName} ({daysInMonth} days)"
            ListBox1.Items.Add(displayText)
        Next

        ListBox1.EndUpdate()

        ' Show success message
        MessageBox.Show(
         $"All {MONTHS_PER_YEAR} months of the year have been loaded.{Environment.NewLine}{Environment.NewLine}" &
      "Each entry shows the month name and the number of days in that month " &
$"for the current year ({DateTime.Now.Year}).",
        "Months Loaded Successfully",
            MessageBoxButtons.OK,
MessageBoxIcon.Information
 )
    End Sub

    ''' <summary>
    ''' Handle month selection to show details
    ''' </summary>
    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged
        If ListBox1.SelectedIndex >= 0 Then
            ShowMonthDetails(ListBox1.SelectedIndex + 1)
        End If
    End Sub

    ''' <summary>
    ''' Display detailed information about selected month
    ''' </summary>
    Private Sub ShowMonthDetails(monthNumber As Integer)
        Dim currentYear As Integer = DateTime.Now.Year
        Dim monthName As String = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(monthNumber)
        Dim daysInMonth As Integer = DateTime.DaysInMonth(currentYear, monthNumber)
        Dim firstDay As DateTime = New DateTime(currentYear, monthNumber, 1)
        Dim lastDay As DateTime = New DateTime(currentYear, monthNumber, daysInMonth)
        Dim quarter As Integer = Math.Ceiling(monthNumber / 3.0)

        Dim details As String = $"📅 {monthName} Details{Environment.NewLine}" &
      $"━━━━━━━━━━━━━━━━━━━━━{Environment.NewLine}" &
          $"Month Number: {monthNumber} of {MONTHS_PER_YEAR}{Environment.NewLine}" &
            $"Year: {currentYear}{Environment.NewLine}" &
            $"Days in Month: {daysInMonth}{Environment.NewLine}" &
      $"First Day: {firstDay:dddd, MMMM d, yyyy}{Environment.NewLine}" &
    $"Last Day: {lastDay:dddd, MMMM d, yyyy}{Environment.NewLine}" &
            $"Quarter: Q{quarter}{Environment.NewLine}" &
            $"Season: {GetSeason(monthNumber)}"

        MessageBox.Show(details, $"{monthName} Information", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Helper Methods"

    ''' <summary>
    ''' Get season for a given month (Northern Hemisphere)
    ''' </summary>
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