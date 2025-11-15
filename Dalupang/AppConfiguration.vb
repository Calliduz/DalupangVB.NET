''' <summary>
''' Application Configuration and Settings
''' Centralized configuration management for the enterprise application
''' </summary>
Public Module AppConfiguration

#Region "Application Information"

    Public Class AppInfo
        Public Const Name As String = "Programming Fundamentals 101"
        Public Const ShortName As String = "PF101"
        Public Const Version As String = "2.0.0"
        Public Const Build As String = "2024.01.15"
        Public Const Platform As String = ".NET 8.0"
        Public Const Edition As String = "Enterprise Learning Platform"
        Public Const Copyright As String = "© 2024 All Rights Reserved"
        Public Const Website As String = "https://github.com/Calliduz/DalupangVB.NET"
    End Class

    Public Function GetFullTitle() As String
        Return $"{AppInfo.ShortName} - {AppInfo.Name} | {AppInfo.Edition}"
    End Function

    Public Function GetVersionString() As String
        Return $"Version {AppInfo.Version} | {AppInfo.Platform}"
    End Function

#End Region

#Region "Feature Flags"

    Public Class Features
        Public Const EnableDarkMode As Boolean = True
        Public Const EnableSearch As Boolean = True
        Public Const EnableAnimations As Boolean = True
        Public Const EnableLogging As Boolean = True
        Public Const EnableTooltips As Boolean = True
        Public Const EnableKeyboardShortcuts As Boolean = True
        Public Const EnableResponsiveDesign As Boolean = True
        Public Const EnableErrorReporting As Boolean = True
        Public Const ShowDebugInfo As Boolean = False
        Public Const EnableAutoSave As Boolean = False
    End Class

#End Region

#Region "UI Configuration"

    Public Class UISettings
        Public Const DefaultWindowWidth As Integer = 1400
        Public Const DefaultWindowHeight As Integer = 850
        Public Const MinimumWindowWidth As Integer = 1200
        Public Const MinimumWindowHeight As Integer = 700
        Public Const StartupPositionValue As FormStartPosition = FormStartPosition.CenterScreen
        Public Const SidebarDefaultExpanded As Boolean = True
        Public Const SidebarAnimationDuration As Integer = 300
        Public Const SidebarExpandedWidth As Integer = 280
        Public Const SidebarCollapsedWidth As Integer = 60
        Public Const DefaultTheme As String = "Light"
        Public Const AllowThemeToggle As Boolean = True
        Public Const CardsPerRowLarge As Integer = 3
        Public Const CardsPerRowMedium As Integer = 2
        Public Const CardsPerRowSmall As Integer = 1
        Public Const CardAnimationOnHover As Boolean = True
        Public Const CardShadowEnabled As Boolean = True
        Public Const GlobalAnimationSpeed As Integer = 300
        Public Const AnimationFrameRate As Integer = 60
        Public Const EnableTransitions As Boolean = True
        Public Const DefaultFontFamily As String = "Segoe UI"
        Public Const DefaultFontSize As Single = 10.0F
        Public Const MonospaceFontFamily As String = "Consolas"
    End Class

#End Region

#Region "Performance Settings"

    Public Class Performance
        Public Const EnableDoubleBuffering As Boolean = True
        Public Const OptimizePainting As Boolean = True
        Public Const MaxConcurrentForms As Integer = 10
        Public Const SearchDebounceMs As Integer = 300
        Public Const MaxSearchResults As Integer = 50
        Public Const EnableFormCaching As Boolean = False
        Public Const CacheTimeout As Integer = 300000
        Public Const MaxLogEntries As Integer = 1000
        Public Const MaxUndoSteps As Integer = 50
    End Class

#End Region

#Region "Module Configuration"

    Public Class Modules
        Public Const OOPEnabled As Boolean = True
        Public Const OOPDescription As String = "Master the fundamentals of OOP with Visual Basic .NET"
        Public Const LoopsEnabled As Boolean = True
        Public Const LoopsDescription As String = "Learn different loop structures and iteration patterns"
        Public Const DecisionsEnabled As Boolean = True
        Public Const DecisionsDescription As String = "Master conditional statements and branching logic"
        Public Const OperatorsEnabled As Boolean = True
        Public Const OperatorsDescription As String = "Understand mathematical, logical, and relational operators"
        Public Const DataStructuresEnabled As Boolean = True
        Public Const DataStructuresDescription As String = "Work with arrays, lists, and collections"
        Public Const GamesEnabled As Boolean = True
        Public Const GamesDescription As String = "Apply programming concepts to solve classic problems"
        Public Const CalculatorEnabled As Boolean = True
        Public Const CalculatorDescription As String = "Interactive calculator with step-by-step explanations"
    End Class

#End Region

#Region "Validation Rules"

    Public Class ValidationRules
        Public Const MinIntegerValue As Integer = -1000000
        Public Const MaxIntegerValue As Integer = 1000000
        Public Const MinDoubleValue As Double = -1000000.0
        Public Const MaxDoubleValue As Double = 1000000.0
        Public Const MaxTextLength As Integer = 500
        Public Const MinPasswordLength As Integer = 8
        Public Const MaxUsernameLength As Integer = 50
        Public Const MaxSafeIterations As Integer = 10000
        Public Const WarnThreshold As Integer = 1000
        Public Const MaxFileSizeBytes As Integer = 10485760
        Public Const AllowedFileExtensions As String = ".txt,.csv,.json"
    End Class

#End Region

#Region "Logging Configuration"

    Public Class Logging
        Public Const EnableFileLogging As Boolean = False
        Public Const EnableConsoleLogging As Boolean = True
        Public Const LogLevel As String = "Info"
        Public Const LogFilePath As String = "logs\app.log"
        Public Const MaxLogFileSize As Integer = 5242880
        Public Const LogRotationEnabled As Boolean = True
        Public Const TimestampFormat As String = "yyyy-MM-dd HH:mm:ss"
        Public Const IncludeStackTrace As Boolean = True
    End Class

#End Region

#Region "Messages & Text"

    Public Class Messages
        Public Const WelcomeTitle As String = "Welcome to Programming Fundamentals 101!"
        Public Const WelcomeMessage As String = "Choose a module to begin your learning journey."
        Public Const GenericError As String = "An unexpected error occurred. Please try again."
        Public Const ValidationError As String = "Please check your input and try again."
        Public Const NetworkError As String = "Unable to connect. Please check your network."
        Public Const OperationSuccess As String = "Operation completed successfully!"
        Public Const SaveSuccess As String = "Your changes have been saved."
        Public Const ExitConfirmation As String = "Are you sure you want to exit?" & vbCrLf & "All open demonstrations will be closed."
        Public Const ResetConfirmation As String = "Are you sure you want to reset?" & vbCrLf & "This will clear all current progress."
        Public Const GeneralHelp As String = "Click any module card to begin learning. Use the search box to find specific topics."
    End Class

#End Region

#Region "Keyboard Shortcuts"

    Public Class KeyboardShortcuts
        Public Const ToggleSidebar As Keys = Keys.F2
        Public Const ToggleTheme As Keys = Keys.F3
        Public Const FocusSearch As Keys = Keys.Control Or Keys.F
        Public Const ShowHelp As Keys = Keys.F1
        Public Const CloseWindow As Keys = Keys.Escape
        Public Const RefreshKey As Keys = Keys.F5
    End Class

#End Region

#Region "Accessibility Settings"

    Public Class Accessibility
        Public Const HighContrastMode As Boolean = False
        Public Const MinimumFontSize As Single = 9.0F
        Public Const ShowFocusIndicators As Boolean = True
        Public Const AnimationReducedMotion As Boolean = False
        Public Const MinTouchTargetSize As Integer = 40
        Public Const EnableRightClickMenus As Boolean = True
        Public Const ShowTooltips As Boolean = True
        Public Const TooltipDelay As Integer = 500
        Public Const EnableAriaLabels As Boolean = True
        Public Const VerboseDescriptions As Boolean = False
    End Class

#End Region

#Region "Developer Settings"

    Public Class Developer
        Public Const DebugMode As Boolean = False
        Public Const ShowPerformanceMetrics As Boolean = False
        Public Const EnableHotReload As Boolean = False
        Public Const LogAllEvents As Boolean = False
        Public Const ShowBoundingBoxes As Boolean = False
        Public Const EnableDevTools As Boolean = False
    End Class

#End Region

#Region "Help & Support"

    Public Class Support
        Public Const HelpUrl As String = "https://github.com/Calliduz/DalupangVB.NET/wiki"
        Public Const IssuesUrl As String = "https://github.com/Calliduz/DalupangVB.NET/issues"
        Public Const DocumentationUrl As String = "https://github.com/Calliduz/DalupangVB.NET"
        Public Const SupportEmail As String = "support@example.com"
        Public Const ShowOnlineHelp As Boolean = False
    End Class

#End Region

#Region "Runtime Configuration"

    Public Class RuntimeSettings
        Public Shared Property CurrentTheme As String = UISettings.DefaultTheme
        Public Shared Property SidebarExpanded As Boolean = UISettings.SidebarDefaultExpanded
        Public Shared Property AnimationsEnabled As Boolean = Features.EnableAnimations
        Public Shared Property LastSelectedModule As String = ""
        Public Shared Property WindowWidth As Integer = UISettings.DefaultWindowWidth
        Public Shared Property WindowHeight As Integer = UISettings.DefaultWindowHeight
    End Class

#End Region

#Region "Helper Methods"

    Public Function IsFeatureEnabled(featureName As String) As Boolean
        Select Case featureName.ToLowerInvariant()
            Case "darkmode" : Return Features.EnableDarkMode
            Case "search" : Return Features.EnableSearch
            Case "animations" : Return Features.EnableAnimations
            Case "logging" : Return Features.EnableLogging
            Case "tooltips" : Return Features.EnableTooltips
            Case Else : Return False
        End Select
    End Function

    Public Function GetSetting(key As String, Optional defaultValue As String = "") As String
        Return defaultValue
    End Function

    Public Function ValidatePrerequisites() As Boolean
        Return True
    End Function

    Public Function GetSystemInfo() As String
        Return $"OS: {Environment.OSVersion}{vbCrLf}" &
            $"Machine: {Environment.MachineName}{vbCrLf}" &
          $"User: {Environment.UserName}{vbCrLf}" &
   $".NET: {Environment.Version}{vbCrLf}" &
      $"64-bit: {Environment.Is64BitOperatingSystem}"
    End Function

#End Region

End Module
