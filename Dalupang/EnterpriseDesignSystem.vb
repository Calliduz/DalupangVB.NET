Imports System.Drawing

''' <summary>
''' Enterprise Design System - Centralized styling and configuration
''' Provides consistent colors, fonts, spacing, and UI constants across the application
''' </summary>
Public Module EnterpriseDesignSystem

#Region "Color Palette"

    ''' <summary>
    ''' Primary brand colors for key actions and highlights
    ''' </summary>
    Public Class PrimaryColors
        Public Shared ReadOnly Property Blue As Color = Color.FromArgb(52, 152, 219)     ' #3498DB
        Public Shared ReadOnly Property BlueHover As Color = Color.FromArgb(41, 128, 185) ' #2980B9
        Public Shared ReadOnly Property BlueDark As Color = Color.FromArgb(52, 73, 94)    ' #34495E
    End Class

    ''' <summary>
    ''' Semantic colors for status and feedback
    ''' </summary>
    Public Class SemanticColors
        Public Shared ReadOnly Property Success As Color = Color.FromArgb(46, 204, 113)   ' #2ECC71
        Public Shared ReadOnly Property SuccessHover As Color = Color.FromArgb(39, 174, 96) ' #27AE60
        Public Shared ReadOnly Property Warning As Color = Color.FromArgb(241, 196, 15)   ' #F1C40F
        Public Shared ReadOnly Property WarningHover As Color = Color.FromArgb(243, 156, 18) ' #F39C12
        Public Shared ReadOnly Property Danger As Color = Color.FromArgb(231, 76, 60)     ' #E74C3C
        Public Shared ReadOnly Property DangerHover As Color = Color.FromArgb(192, 57, 43) ' #C0392B
        Public Shared ReadOnly Property Info As Color = Color.FromArgb(52, 152, 219)      ' #3498DB
    End Class

    ''' <summary>
    ''' Neutral colors for backgrounds and borders
    ''' </summary>
    Public Class NeutralColors
        Public Shared ReadOnly Property White As Color = Color.White      ' #FFFFFF
        Public Shared ReadOnly Property Gray100 As Color = Color.FromArgb(248, 249, 250)  ' #F8F9FA
        Public Shared ReadOnly Property Gray200 As Color = Color.FromArgb(236, 240, 241)  ' #ECF0F1
        Public Shared ReadOnly Property Gray300 As Color = Color.FromArgb(220, 225, 230)  ' #DCE1E6
        Public Shared ReadOnly Property Gray400 As Color = Color.FromArgb(189, 195, 199)  ' #BDC3C7
        Public Shared ReadOnly Property Gray500 As Color = Color.FromArgb(149, 165, 166)  ' #95A5A6
        Public Shared ReadOnly Property Gray600 As Color = Color.FromArgb(127, 140, 141)  ' #7F8C8D
        Public Shared ReadOnly Property Gray700 As Color = Color.FromArgb(99, 110, 114)   ' #636E72
        Public Shared ReadOnly Property Gray800 As Color = Color.FromArgb(52, 73, 94)     ' #34495E
        Public Shared ReadOnly Property Gray900 As Color = Color.FromArgb(44, 62, 80)     ' #2C3E50
        Public Shared ReadOnly Property Black As Color = Color.FromArgb(45, 52, 54)       ' #2D3436
    End Class

    ''' <summary>
    ''' Dark theme colors
    ''' </summary>
    Public Class DarkTheme
        Public Shared ReadOnly Property Background As Color = Color.FromArgb(32, 33, 36)  ' #202124
        Public Shared ReadOnly Property Surface As Color = Color.FromArgb(50, 51, 54)     ' #323336
        Public Shared ReadOnly Property SurfaceHover As Color = Color.FromArgb(55, 56, 59) ' #37383B
        Public Shared ReadOnly Property Border As Color = Color.FromArgb(70, 71, 74)      ' #46474A
        Public Shared ReadOnly Property TextPrimary As Color = Color.FromArgb(232, 234, 237) ' #E8EAED
        Public Shared ReadOnly Property TextSecondary As Color = Color.FromArgb(154, 160, 166) ' #9AA0A6
        Public Shared ReadOnly Property TextTertiary As Color = Color.FromArgb(120, 130, 140) ' #78828C
    End Class

    ''' <summary>
    ''' Light theme colors
    ''' </summary>
    Public Class LightTheme
        Public Shared ReadOnly Property Background As Color = Color.FromArgb(240, 242, 245) ' #F0F2F5
        Public Shared ReadOnly Property Surface As Color = Color.White ' #FFFFFF
        Public Shared ReadOnly Property SurfaceHover As Color = Color.FromArgb(248, 250, 252) ' #F8FAFC
        Public Shared ReadOnly Property Border As Color = Color.FromArgb(220, 225, 230)    ' #DCE1E6
        Public Shared ReadOnly Property TextPrimary As Color = Color.FromArgb(45, 52, 54)  ' #2D3436
        Public Shared ReadOnly Property TextSecondary As Color = Color.FromArgb(99, 110, 114) ' #636E72
        Public Shared ReadOnly Property TextTertiary As Color = Color.FromArgb(149, 165, 166) ' #95A5A6
    End Class

    ''' <summary>
    ''' Module-specific accent colors
    ''' </summary>
    Public Class ModuleColors
        Public Shared ReadOnly Property OOP As Color = Color.FromArgb(52, 152, 219)       ' Blue
        Public Shared ReadOnly Property Loops As Color = Color.FromArgb(155, 89, 182)     ' Purple
        Public Shared ReadOnly Property Decisions As Color = Color.FromArgb(52, 73, 94)   ' Dark Blue
        Public Shared ReadOnly Property Operators As Color = Color.FromArgb(230, 126, 34) ' Orange
        Public Shared ReadOnly Property DataStructures As Color = Color.FromArgb(26, 188, 156) ' Teal
        Public Shared ReadOnly Property Games As Color = Color.FromArgb(231, 76, 60) ' Red
    End Class

#End Region

#Region "Typography"

    ''' <summary>
    ''' Font family constants
    ''' </summary>
    Public Class Fonts
        Public Const PrimaryFamily As String = "Segoe UI"
        Public Const MonospaceFamily As String = "Consolas"
        Public Const FallbackFamily As String = "Arial"
    End Class

    ''' <summary>
    ''' Font size scale
    ''' </summary>
    Public Class FontSizes
        Public Const Hero As Single = 28.0F       ' Main titles
        Public Const H1 As Single = 24.0F      ' Page headers
        Public Const H2 As Single = 20.0F           ' Section headers
        Public Const H3 As Single = 18.0F       ' Subsection headers
        Public Const H4 As Single = 16.0F  ' Card titles
        Public Const H5 As Single = 14.0F           ' Small headers
        Public Const Body As Single = 12.0F       ' Body text
        Public Const BodyLarge As Single = 13.0F    ' Large body text
        Public Const BodySmall As Single = 11.0F    ' Small body text
        Public Const Caption As Single = 10.0F      ' Captions
        Public Const Tiny As Single = 9.0F          ' Tiny text
    End Class

    ''' <summary>
    ''' Create font with specified size and style
    ''' </summary>
    Public Function CreateFont(size As Single, Optional style As FontStyle = FontStyle.Regular) As Font
        Return New Font(Fonts.PrimaryFamily, size, style)
    End Function

    ''' <summary>
    ''' Create monospace font (for code display)
    ''' </summary>
    Public Function CreateMonospaceFont(size As Single) As Font
        Return New Font(Fonts.MonospaceFamily, size, FontStyle.Regular)
    End Function

#End Region

#Region "Spacing & Sizing"

    ''' <summary>
    ''' Spacing scale (in pixels)
    ''' </summary>
    Public Class Spacing
        Public Const Tiny As Integer = 4
        Public Const Small As Integer = 8
        Public Const Medium As Integer = 12
        Public Const Base As Integer = 16
        Public Const Large As Integer = 20
        Public Const XLarge As Integer = 24
        Public Const XXLarge As Integer = 32
        Public Const Huge As Integer = 48
    End Class

    ''' <summary>
    ''' Standard control sizes
    ''' </summary>
    Public Class ControlSizes
        Public Shared ReadOnly Property ButtonSmall As Size = New Size(100, 35)
        Public Shared ReadOnly Property ButtonMedium As Size = New Size(150, 45)
        Public Shared ReadOnly Property ButtonLarge As Size = New Size(200, 50)

        ' Text boxes
        Public Const TextBoxHeight As Integer = 35
        Public Const TextBoxMultilineMinHeight As Integer = 100

        ' Icons
        Public Const IconSmall As Integer = 16
        Public Const IconMedium As Integer = 24
        Public Const IconLarge As Integer = 32

        ' Touch targets (minimum for accessibility)
        Public Const MinTouchTarget As Integer = 40
    End Class

    ''' <summary>
    ''' Border and corner radius
    ''' </summary>
    Public Class Borders
        Public Const RadiusSmall As Integer = 4
        Public Const RadiusMedium As Integer = 8
        Public Const RadiusLarge As Integer = 12
        Public Const RadiusRound As Integer = 50

        Public Const WidthThin As Integer = 1
        Public Const WidthMedium As Integer = 2
        Public Const WidthThick As Integer = 3
    End Class

#End Region

#Region "Effects"

    ''' <summary>
    ''' Shadow definitions
    ''' </summary>
    Public Class ShadowSettings
        Public Shared ReadOnly Property Light As Color = Color.FromArgb(10, 0, 0, 0)
        Public Shared ReadOnly Property Medium As Color = Color.FromArgb(20, 0, 0, 0)
        Public Shared ReadOnly Property Strong As Color = Color.FromArgb(30, 0, 0, 0)
        Public Const OffsetSmall As Integer = 2
        Public Const OffsetMedium As Integer = 4
        Public Const OffsetLarge As Integer = 8
    End Class

    ''' <summary>
    ''' Opacity levels (0-255)
    ''' </summary>
    Public Class OpacityLevels
        Public Const Transparent As Integer = 0
        Public Const Light As Integer = 64       ' 25%
        Public Const Medium As Integer = 128     ' 50%
        Public Const Strong As Integer = 191     ' 75%
        Public Const Opaque As Integer = 255     ' 100%
    End Class

#End Region

#Region "Animation & Timing"

    ''' <summary>
    ''' Animation durations (in milliseconds)
    ''' </summary>
    Public Class AnimationDuration
        Public Const Instant As Integer = 0
        Public Const Fast As Integer = 150
        Public Const Normal As Integer = 300
        Public Const Slow As Integer = 500
        Public Const VerySlow As Integer = 800
    End Class

    ''' <summary>
    ''' Animation frame rates
    ''' </summary>
    Public Class FrameRates
        Public Const Smooth As Integer = 60      ' 60 FPS
        Public Const Standard As Integer = 30    ' 30 FPS
        Public Const Low As Integer = 15         ' 15 FPS
    End Class

    ''' <summary>
    ''' Calculate timer interval for desired FPS
    ''' </summary>
    Public Function GetTimerInterval(fps As Integer) As Integer
        Return 1000 \ fps
    End Function

#End Region

#Region "Layout & Breakpoints"

    ''' <summary>
    ''' Responsive breakpoints
    ''' </summary>
    Public Class Breakpoints
        Public Const Mobile As Integer = 480
        Public Const Tablet As Integer = 768
        Public Const Desktop As Integer = 1024
        Public Const LargeDesktop As Integer = 1440
        Public Const ExtraLarge As Integer = 1920
    End Class

    ''' <summary>
    ''' Content widths
    ''' </summary>
    Public Class ContentWidth
        Public Const Narrow As Integer = 600
        Public Const Medium As Integer = 900
        Public Const Wide As Integer = 1200
        Public Const Full As Integer = 1600
    End Class

    ''' <summary>
    ''' Sidebar dimensions
    ''' </summary>
    Public Class SidebarSettings
        Public Const WidthExpanded As Integer = 280
        Public Const WidthCollapsed As Integer = 60
        Public Const AnimationSteps As Integer = 10
    End Class

    ''' <summary>
    ''' Header/Footer dimensions
    ''' </summary>
    Public Class LayoutSettings
        Public Const HeaderHeight As Integer = 100
        Public Const HeaderSmallHeight As Integer = 80
        Public Const FooterHeight As Integer = 45
        Public Const CardMinWidth As Integer = 350
        Public Const CardMaxWidth As Integer = 450
    End Class

#End Region

#Region "Z-Index / Layer Order"

    ''' <summary>
    ''' Z-index for layering controls
    ''' </summary>
    Public Class ZIndex
        Public Const Base As Integer = 0
        Public Const Content As Integer = 1
        Public Const Header As Integer = 10
        Public Const SidebarLayer As Integer = 20
        Public Const Modal As Integer = 100
        Public Const Tooltip As Integer = 200
        Public Const Top As Integer = 1000
    End Class

#End Region

#Region "Validation & Limits"

    ''' <summary>
    ''' Input validation limits
    ''' </summary>
    Public Class InputLimits
        Public Const MaxTextLength As Integer = 500
        Public Const MaxNumberValue As Integer = 1000000
        Public Const MinNumberValue As Integer = -1000000
        Public Const MaxIterations As Integer = 10000
        Public Const MaxFileSize As Integer = 10485760  ' 10 MB
    End Class

#End Region

#Region "Helper Functions"

    Public Function CreatePadding(size As Integer) As Padding
        Return New Padding(size)
    End Function

    Public Function CreatePadding(left As Integer, top As Integer, right As Integer, bottom As Integer) As Padding
        Return New Padding(left, top, right, bottom)
    End Function

    Public Function CreateContentPadding() As Padding
        Return New Padding(Spacing.Large)
    End Function

    Public Function GetResponsiveCardWidth(containerWidth As Integer) As Integer
        If containerWidth >= Breakpoints.Desktop Then
            Return (containerWidth - 60) \ 3
        ElseIf containerWidth >= Breakpoints.Tablet Then
            Return (containerWidth - 40) \ 2
        Else
            Return containerWidth - 20
        End If
    End Function

    Public Function Clamp(value As Integer, min As Integer, max As Integer) As Integer
        Return Math.Max(min, Math.Min(max, value))
    End Function

    Public Function Lerp(start As Double, [end] As Double, amount As Double) As Double
        Return start + (([end] - start) * amount)
    End Function

    Public Function EaseOutCubic(progress As Double) As Double
        Return 1 - Math.Pow(1 - progress, 3)
    End Function

#End Region

End Module
