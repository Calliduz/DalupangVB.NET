Imports System.Drawing
Imports System.Windows.Forms

''' <summary>
''' Classes and Methods Educational Demonstration
''' Enterprise-grade OOP learning tool with professional UI/UX
''' </summary>
Public Class ClassandMethods
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

    Private Sub ClassAndMethods_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            .Text = "🏗️ Classes and Methods",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = True,
            .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
            .Text = "Learn how classes define types and methods define behaviors",
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
            .Text = "💡 What are Classes and Methods?",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
            .ForeColor = Color.FromArgb(45, 55, 72),
            .AutoSize = True,
            .Location = New Point(32, 20)
        }

        Dim lblText = New Label With {
            .Text = "Classes define types and their behaviors." & vbCrLf & vbCrLf &
                      "Example: Person class with Name/Age properties. Methods: GetInfo(), CelebrateBirthday(), Introduce(), IsAdult().",
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
                         "  CLASSES AND METHODS DEMONSTRATION" & vbCrLf &
                         "═══════════════════════════════════════════════════════════════" & vbCrLf & vbCrLf &
                         "Welcome! Learn the fundamentals of classes and methods." & vbCrLf & vbCrLf &
                         "Key Concepts:" & vbCrLf &
                         "• Classes define object types" & vbCrLf &
                         "• Properties store data (Name, Age)" & vbCrLf &
                         "• Methods define behaviors" & vbCrLf &
                         "• Methods can return values or perform actions" & vbCrLf & vbCrLf &
                         "Click 'Run Demonstration' to see classes and methods in action!" & vbCrLf & vbCrLf &
                         "═══════════════════════════════════════════════════════════════"
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Try
            txtOutput.Clear()

            Dim output As New System.Text.StringBuilder()
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  🏗️ CLASSES AND METHODS IN ACTION")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()

            ' Create Person instance
            output.AppendLine("Creating Person object...")
            output.AppendLine()
            Dim p As New Person()
            p.Name = "Alice"
            p.Age = 30

            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine("CALLING METHODS")
            output.AppendLine("───────────────────────────────────────────────────────────────")
            output.AppendLine()

            ' Call various methods
            output.AppendLine("1️⃣  GetInfo() - Returns string")
            Dim info As String = p.GetInfo()
            output.AppendLine($"   Result: {info}")
            output.AppendLine()

            output.AppendLine("2️⃣  Introduce() - Returns greeting")
            Dim intro As String = p.Introduce()
            output.AppendLine($"   Result: {intro}")
            output.AppendLine()

            output.AppendLine("3️⃣  IsAdult() - Returns boolean")
            Dim isAdult As Boolean = p.IsAdult()
            output.AppendLine($"   Result: {isAdult} (Age >= 18)")
            output.AppendLine()

            output.AppendLine("4️⃣  CelebrateBirthday() - Modifies state")
            output.AppendLine($"   Before: Age = {p.Age}")
            p.CelebrateBirthday()
            output.AppendLine($"   After:  Age = {p.Age} (incremented)")
            output.AppendLine()

            output.AppendLine("5️⃣  SetPersonInfo() - Method with parameters")
            output.AppendLine("   Calling: SetPersonInfo(""Bob"", 25)")
            p.SetPersonInfo("Bob", 25)
            output.AppendLine($"   Result: {p.GetInfo()}")
            output.AppendLine()

            ' Summary
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine("  ✅ CLASSES AND METHODS SUMMARY")
            output.AppendLine("═══════════════════════════════════════════════════════════════")
            output.AppendLine()
            output.AppendLine("✓ Classes: Blueprints for objects (Person)")
            output.AppendLine("✓ Properties: Store data (Name, Age)")
            output.AppendLine("✓ Methods: Define behaviors")
            output.AppendLine("  • Return values (GetInfo, Introduce, IsAdult)")
            output.AppendLine("  • Modify state (CelebrateBirthday)")
            output.AppendLine("  • Accept parameters (SetPersonInfo)")
            output.AppendLine()
            output.AppendLine("This is Object-Oriented Programming! 🎯")
            output.AppendLine()
            output.AppendLine("═══════════════════════════════════════════════════════════════")

            txtOutput.Text = output.ToString()

            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Classes/Methods demo executed")
            End If

        Catch ex As Exception
            If AppConfiguration.Features.EnableLogging Then
                Debug.WriteLine($"[{DateTime.Now}] Classes/Methods error: {ex.Message}")
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

#Region "Person Class"

''' <summary>
''' Person class demonstrating properties and methods
''' </summary>
Public Class Person
    Public Property Name As String
    Public Property Age As Integer

    ''' <summary>
    ''' Returns person information as string
    ''' </summary>
    Public Function GetInfo() As String
        Return $"{Name} is {Age} years old"
    End Function

    ''' <summary>
    ''' Increments age by 1
    ''' </summary>
    Public Sub CelebrateBirthday()
        Age += 1
    End Sub

    ''' <summary>
    ''' Returns introduction string
    ''' </summary>
    Public Function Introduce() As String
        Return $"Hello, my name is {Name} and I am {Age} years old."
    End Function

    ''' <summary>
    ''' Sets person information using parameters
    ''' </summary>
    Public Sub SetPersonInfo(personName As String, personAge As Integer)
        Name = personName
        Age = personAge
    End Sub

    ''' <summary>
    ''' Checks if person is adult (18+)
    ''' </summary>
    Public Function IsAdult() As Boolean
        Return Age >= 18
    End Function
End Class

#End Region