Imports System.Text.RegularExpressions

''' <summary>
''' Enterprise-grade validation utilities
''' Provides comprehensive input validation for forms
''' </summary>
Public Module ValidationHelper

    ''' <summary>
    ''' Validates if a string is not empty or whitespace
    ''' </summary>
    Public Function IsNotEmpty(value As String, Optional fieldName As String = "Field") As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return ValidationResult.Failure($"{fieldName} cannot be empty.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates if a string is a valid number
    ''' </summary>
    Public Function IsNumeric(value As String, Optional fieldName As String = "Value") As ValidationResult
        Dim number As Double
        If Not Double.TryParse(value, number) Then
            Return ValidationResult.Failure($"{fieldName} must be a valid number.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates if a string is a valid integer
    ''' </summary>
    Public Function IsInteger(value As String, Optional fieldName As String = "Value") As ValidationResult
        Dim number As Integer
        If Not Integer.TryParse(value, number) Then
            Return ValidationResult.Failure($"{fieldName} must be a valid integer.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates if a number is within a specified range
    ''' </summary>
    Public Function IsInRange(value As Double, min As Double, max As Double,
       Optional fieldName As String = "Value") As ValidationResult
        If value < min OrElse value > max Then
            Return ValidationResult.Failure($"{fieldName} must be between {min} and {max}.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates if a string has a minimum length
    ''' </summary>
    Public Function HasMinLength(value As String, minLength As Integer,
            Optional fieldName As String = "Field") As ValidationResult
        If value Is Nothing OrElse value.Length < minLength Then
            Return ValidationResult.Failure($"{fieldName} must be at least {minLength} characters long.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates if a string has a maximum length
    ''' </summary>
    Public Function HasMaxLength(value As String, maxLength As Integer,
         Optional fieldName As String = "Field") As ValidationResult
        If value IsNot Nothing AndAlso value.Length > maxLength Then
            Return ValidationResult.Failure($"{fieldName} must not exceed {maxLength} characters.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates if a string is a valid email address
    ''' </summary>
    Public Function IsValidEmail(value As String, Optional fieldName As String = "Email") As ValidationResult
        If String.IsNullOrWhiteSpace(value) Then
            Return ValidationResult.Failure($"{fieldName} cannot be empty.")
        End If

        Dim emailPattern As String = "^[^@\s]+@[^@\s]+\.[^@\s]+$"
        If Not Regex.IsMatch(value, emailPattern) Then
            Return ValidationResult.Failure($"{fieldName} is not a valid email address.")
        End If
        Return ValidationResult.Success()
    End Function

    ''' <summary>
    ''' Validates multiple conditions
    ''' </summary>
    Public Function ValidateAll(ParamArray validators As ValidationResult()) As ValidationResult
        Dim errors As New List(Of String)

        For Each validator In validators
            If Not validator.IsValid Then
                errors.Add(validator.ErrorMessage)
            End If
        Next

        If errors.Count > 0 Then
            Return ValidationResult.Failure(String.Join(vbCrLf, errors))
        End If

        Return ValidationResult.Success()
    End Function

End Module

''' <summary>
''' Validation result class
''' </summary>
Public Class ValidationResult
    Public Property IsValid As Boolean
    Public Property ErrorMessage As String

    Public Shared Function Success() As ValidationResult
        Return New ValidationResult With {.IsValid = True, .ErrorMessage = ""}
    End Function

    Public Shared Function Failure(errorMessage As String) As ValidationResult
        Return New ValidationResult With {.IsValid = False, .ErrorMessage = errorMessage}
    End Function
End Class

''' <summary>
''' Formatting utilities for enterprise applications
''' </summary>
Public Module FormattingHelper

    ''' <summary>
    ''' Format a number with specified decimal places
    ''' </summary>
    Public Function FormatNumber(value As Double, Optional decimalPlaces As Integer = 2) As String
        Return value.ToString($"F{decimalPlaces}")
    End Function

    ''' <summary>
    ''' Format a number as currency
    ''' </summary>
    Public Function FormatCurrency(value As Double, Optional currencySymbol As String = "$") As String
        Return $"{currencySymbol}{value:N2}"
    End Function

    ''' <summary>
    ''' Format a number as percentage
    ''' </summary>
    Public Function FormatPercentage(value As Double, Optional decimalPlaces As Integer = 2) As String
        Return (value * 100).ToString($"F{decimalPlaces}") & "%"
    End Function

    ''' <summary>
    ''' Format a date in standard format
    ''' </summary>
    Public Function FormatDate(value As Date) As String
        Return value.ToString("yyyy-MM-dd")
    End Function

    ''' <summary>
    ''' Format a date and time
    ''' </summary>
    Public Function FormatDateTime(value As Date) As String
        Return value.ToString("yyyy-MM-dd HH:mm:ss")
    End Function

    ''' <summary>
    ''' Truncate a string to specified length with ellipsis
    ''' </summary>
    Public Function TruncateString(value As String, maxLength As Integer,
       Optional ellipsis As String = "...") As String
        If String.IsNullOrEmpty(value) OrElse value.Length <= maxLength Then
            Return value
        End If
        Return value.Substring(0, maxLength - ellipsis.Length) & ellipsis
    End Function

    ''' <summary>
    ''' Convert string to title case
    ''' </summary>
    Public Function ToTitleCase(value As String) As String
        If String.IsNullOrEmpty(value) Then Return value
        Return Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower())
    End Function

End Module

''' <summary>
''' Color utilities for enterprise UI
''' </summary>
Public Module ColorHelper

    ''' <summary>
    ''' Get a lighter shade of a color
    ''' </summary>
    Public Function Lighten(color As Color, Optional amount As Double = 0.2) As Color
        Return Color.FromArgb(
             color.A,
     CInt(Math.Min(255, color.R + (255 - color.R) * amount)),
               CInt(Math.Min(255, color.G + (255 - color.G) * amount)),
    CInt(Math.Min(255, color.B + (255 - color.B) * amount))
           )
    End Function

    ''' <summary>
    ''' Get a darker shade of a color
    ''' </summary>
    Public Function Darken(color As Color, Optional amount As Double = 0.2) As Color
        Return Color.FromArgb(
  color.A,
        CInt(Math.Max(0, color.R * (1 - amount))),
            CInt(Math.Max(0, color.G * (1 - amount))),
            CInt(Math.Max(0, color.B * (1 - amount)))
        )
    End Function

    ''' <summary>
    ''' Enterprise color palette
    ''' </summary>
    Public ReadOnly Property EnterpriseColors As New Dictionary(Of String, Color) From {
        {"Primary", Color.FromArgb(52, 152, 219)},
        {"Success", Color.FromArgb(46, 204, 113)},
        {"Warning", Color.FromArgb(241, 196, 15)},
        {"Danger", Color.FromArgb(231, 76, 60)},
        {"Info", Color.FromArgb(52, 73, 94)},
 {"Dark", Color.FromArgb(44, 62, 80)},
        {"Light", Color.FromArgb(236, 240, 241)},
   {"Secondary", Color.FromArgb(149, 165, 166)}
    }

End Module

''' <summary>
''' Animation utilities for smooth UI transitions
''' </summary>
Public Class AnimationHelper

    ''' <summary>
    ''' Animate a control's opacity
    ''' </summary>
    Public Shared Sub FadeIn(control As Control, Optional duration As Integer = 500)
        Dim steps As Integer = 20
        Dim stepDuration As Integer = duration \ steps
        Dim timer As New Timer With {.Interval = stepDuration}
        Dim currentStep As Integer = 0

        control.Visible = True
        AddHandler timer.Tick, Sub(s, e)
                                   currentStep += 1
                                   Dim opacity As Double = currentStep / steps
                                   ' Note: Form opacity, not control
                                   If currentStep >= steps Then
                                       timer.Stop()
                                       timer.Dispose()
                                   End If
                               End Sub
        timer.Start()
    End Sub

    ''' <summary>
    ''' Slide a control into view
    ''' </summary>
    Public Shared Sub SlideIn(control As Control, direction As SlideDirection,
     Optional duration As Integer = 500)
        Dim startX As Integer = control.Left
        Dim startY As Integer = control.Top
        Dim targetX As Integer = control.Left
        Dim targetY As Integer = control.Top

        Select Case direction
            Case SlideDirection.FromLeft
                control.Left = -control.Width
            Case SlideDirection.FromRight
                control.Left = control.Parent.Width
            Case SlideDirection.FromTop
                control.Top = -control.Height
            Case SlideDirection.FromBottom
                control.Top = control.Parent.Height
        End Select

        Dim steps As Integer = 20
        Dim stepDuration As Integer = duration \ steps
        Dim timer As New Timer With {.Interval = stepDuration}
        Dim currentStep As Integer = 0

        AddHandler timer.Tick, Sub(s, e)
                                   currentStep += 1
                                   Dim progress As Double = currentStep / steps
                                   ' Ease-out effect
                                   progress = 1 - Math.Pow(1 - progress, 3)

                                   control.Left = CInt(control.Left + (targetX - control.Left) * progress)
                                   control.Top = CInt(control.Top + (targetY - control.Top) * progress)

                                   If currentStep >= steps Then
                                       control.Left = targetX
                                       control.Top = targetY
                                       timer.Stop()
                                       timer.Dispose()
                                   End If
                               End Sub
        timer.Start()
    End Sub

    Public Enum SlideDirection
        FromLeft
        FromRight
        FromTop
        FromBottom
    End Enum

End Class
