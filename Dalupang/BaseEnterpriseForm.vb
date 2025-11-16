Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

''' <summary>
''' Base form class providing enterprise-grade styling and functionality
''' All demo forms should inherit from this for consistent UI/UX
''' </summary>
Public Class BaseEnterpriseForm
    Inherits Form

#Region "Private Fields"

    Private _headerPanel As Panel
    Private _contentPanel As Panel
    Private _footerPanel As Panel
    Private _titleLabel As Label
    Private _descriptionLabel As Label
    Private _closeButton As Button
    Private _isDarkMode As Boolean = False

#End Region

#Region "Public Properties"

    ''' <summary>
    ''' Gets or sets the form title displayed in header
    ''' </summary>
    Public Property FormTitle As String
        Get
            Return If(_titleLabel IsNot Nothing, _titleLabel.Text, "Demo Form")
        End Get
        Set(value As String)
            If _titleLabel IsNot Nothing Then
                _titleLabel.Text = value
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the form description displayed in header
    ''' </summary>
    Public Property FormDescription As String
        Get
            Return If(_descriptionLabel IsNot Nothing, _descriptionLabel.Text, "")
        End Get
        Set(value As String)
            If _descriptionLabel IsNot Nothing Then
                _descriptionLabel.Text = value
                _descriptionLabel.Visible = Not String.IsNullOrWhiteSpace(value)
            End If
        End Set
    End Property

    ''' <summary>
    ''' Gets the content panel where controls should be added
    ''' </summary>
    Public ReadOnly Property ContentPanel As Panel
        Get
            Return _contentPanel
        End Get
    End Property

    ''' <summary>
    ''' Gets or sets whether dark mode is enabled
    ''' </summary>
    Public Property IsDarkMode As Boolean
        Get
            Return _isDarkMode
        End Get
        Set(value As Boolean)
            _isDarkMode = value
            ApplyTheme()
        End Set
    End Property

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeBaseComponents()
        ApplyModernStyling()
    End Sub

#End Region

#Region "Initialization"

    ''' <summary>
    ''' Initialize base form components
    ''' </summary>
    Private Sub InitializeBaseComponents()
        ' Form settings
        Me.Size = New Size(900, 700)
        Me.MinimumSize = New Size(700, 500)
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.FormBorderStyle = FormBorderStyle.Sizable
        Me.AutoScaleMode = AutoScaleMode.Dpi

        ' Performance optimizations
        Me.DoubleBuffered = True
        Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
          ControlStyles.AllPaintingInWmPaint Or
           ControlStyles.UserPaint Or
            ControlStyles.ResizeRedraw, True)

        ' Create header panel
        _headerPanel = New Panel With {
                .Dock = DockStyle.Top,
           .Height = 80,
        .BackColor = Color.FromArgb(52, 73, 94),
           .Padding = New Padding(20, 10, 20, 10)
            }

        ' Create title label
        _titleLabel = New Label With {
         .Text = "Demo Form",
            .Font = New Font("Segoe UI", 18, FontStyle.Bold),
            .ForeColor = Color.White,
            .AutoSize = True,
     .Location = New Point(20, 15)
      }

        ' Create description label
        _descriptionLabel = New Label With {
          .Text = "",
     .Font = New Font("Segoe UI", 10, FontStyle.Regular),
        .ForeColor = Color.FromArgb(189, 195, 199),
             .AutoSize = True,
            .Location = New Point(20, 45),
        .Visible = False
             }

        ' Create close button
        _closeButton = New Button With {
          .Text = "✕",
         .Size = New Size(40, 40),
               .FlatStyle = FlatStyle.Flat,
               .BackColor = Color.FromArgb(231, 76, 60),
        .ForeColor = Color.White,
      .Font = New Font("Segoe UI", 14, FontStyle.Bold),
        .Cursor = Cursors.Hand,
               .Anchor = AnchorStyles.Top Or AnchorStyles.Right
           }
        _closeButton.FlatAppearance.BorderSize = 0
        _closeButton.Location = New Point(_headerPanel.Width - 60, 20)

        AddHandler _closeButton.Click, AddressOf CloseButton_Click
        AddHandler _closeButton.MouseEnter, Sub(s, e)
                                                _closeButton.BackColor = Color.FromArgb(192, 57, 43)
                                            End Sub
        AddHandler _closeButton.MouseLeave, Sub(s, e)
                                                _closeButton.BackColor = Color.FromArgb(231, 76, 60)
                                            End Sub

        ' Add controls to header
        _headerPanel.Controls.AddRange({_titleLabel, _descriptionLabel, _closeButton})

        ' Create content panel
        _contentPanel = New Panel With {
            .Dock = DockStyle.Fill,
        .BackColor = Color.FromArgb(236, 240, 241),
            .Padding = New Padding(20),
         .AutoScroll = True
        }

        ' Create footer panel
        _footerPanel = New Panel With {
         .Dock = DockStyle.Bottom,
       .Height = 40,
    .BackColor = Color.FromArgb(52, 73, 94)
        }

        Dim footerLabel As New Label With {
              .Text = "Enterprise Learning Platform | Programming Fundamentals 101",
                .Font = New Font("Segoe UI", 8, FontStyle.Regular),
                .ForeColor = Color.FromArgb(189, 195, 199),
          .Dock = DockStyle.Fill,
                .TextAlign = ContentAlignment.MiddleCenter
         }
        _footerPanel.Controls.Add(footerLabel)

        ' Add panels to form
        Me.Controls.Add(_contentPanel)
        Me.Controls.Add(_headerPanel)
        Me.Controls.Add(_footerPanel)

        ' Handle resize for close button position
        AddHandler Me.Resize, Sub(s, e)
                                  _closeButton.Location = New Point(_headerPanel.Width - 60, 20)
                              End Sub
    End Sub

    ''' <summary>
    ''' Apply modern styling to the form
    ''' </summary>
    Private Sub ApplyModernStyling()
        ' Set default font
        Me.Font = New Font("Segoe UI", 10, FontStyle.Regular)
    End Sub

    ''' <summary>
    ''' Apply theme (light or dark mode)
    ''' </summary>
    Private Sub ApplyTheme()
        If _isDarkMode Then
            ' Dark theme
            _contentPanel.BackColor = Color.FromArgb(44, 62, 80)
            _headerPanel.BackColor = Color.FromArgb(23, 32, 42)
            _footerPanel.BackColor = Color.FromArgb(23, 32, 42)
            Me.BackColor = Color.FromArgb(44, 62, 80)
        Else
            ' Light theme
            _contentPanel.BackColor = Color.FromArgb(236, 240, 241)
            _headerPanel.BackColor = Color.FromArgb(52, 73, 94)
            _footerPanel.BackColor = Color.FromArgb(52, 73, 94)
            Me.BackColor = Color.FromArgb(236, 240, 241)
        End If
    End Sub

#End Region

#Region "Public Methods"

    ''' <summary>
    ''' Create a styled button for the form
    ''' </summary>
    Public Function CreateStyledButton(text As String, Optional backgroundColor As Color = Nothing) As Button
        If backgroundColor = Nothing Then
            backgroundColor = Color.FromArgb(52, 152, 219)
        End If

        Dim btn As New Button With {
      .Text = text,
            .Font = New Font("Segoe UI", 11, FontStyle.Regular),
          .BackColor = backgroundColor,
   .ForeColor = Color.White,
    .FlatStyle = FlatStyle.Flat,
 .Size = New Size(150, 45),
 .Cursor = Cursors.Hand
        }
        btn.FlatAppearance.BorderSize = 0

        ' Add hover effects
        Dim originalColor = backgroundColor
        AddHandler btn.MouseEnter, Sub(s, e)
                                       btn.BackColor = ControlPaint.Light(originalColor, 0.1)
                                   End Sub
        AddHandler btn.MouseLeave, Sub(s, e)
                                       btn.BackColor = originalColor
                                   End Sub

        Return btn
    End Function

    ''' <summary>
    ''' Create a styled text box for the form
    ''' </summary>
    Public Function CreateStyledTextBox(Optional placeholder As String = "") As TextBox
        Dim txt As New TextBox With {
       .Font = New Font("Segoe UI", 11, FontStyle.Regular),
            .BackColor = Color.White,
  .ForeColor = Color.FromArgb(52, 73, 94),
            .BorderStyle = BorderStyle.None,
        .Height = 35
        }

        If Not String.IsNullOrWhiteSpace(placeholder) Then
            txt.PlaceholderText = placeholder
        End If

        Return txt
    End Function

    ''' <summary>
    ''' Create a styled label for the form
    ''' </summary>
    Public Function CreateStyledLabel(text As String, Optional fontSize As Integer = 11,
              Optional fontStyle As FontStyle = FontStyle.Regular) As Label
        Return New Label With {
      .Text = text,
           .Font = New Font("Segoe UI", fontSize, fontStyle),
          .ForeColor = If(_isDarkMode, Color.FromArgb(236, 240, 241), Color.FromArgb(52, 73, 94)),
   .AutoSize = True
   }
    End Function

    ''' <summary>
    ''' Create a styled group box for the form
    ''' </summary>
    Public Function CreateStyledGroupBox(text As String) As GroupBox
        Return New GroupBox With {
              .Text = text,
        .Font = New Font("Segoe UI", 11, FontStyle.Bold),
              .ForeColor = If(_isDarkMode, Color.FromArgb(236, 240, 241), Color.FromArgb(52, 73, 94)),
              .Padding = New Padding(10)
          }
    End Function

    ''' <summary>
    ''' Create a styled panel for organizing content
    ''' </summary>
    Public Function CreateStyledPanel(Optional backColor As Color = Nothing) As Panel
        If backColor = Nothing Then
            backColor = If(_isDarkMode, Color.FromArgb(52, 73, 94), Color.White)
        End If

        Return New Panel With {
                .BackColor = backColor,
                .Padding = New Padding(15)
            }
    End Function

    ''' <summary>
    ''' Show a success message
    ''' </summary>
    Public Sub ShowSuccess(message As String)
        MessageBox.Show(message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    ''' <summary>
    ''' Show an error message
    ''' </summary>
    Public Sub ShowError(message As String)
        MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    End Sub

    ''' <summary>
    ''' Show a warning message
    ''' </summary>
    Public Sub ShowWarning(message As String)
        MessageBox.Show(message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning)
    End Sub

    ''' <summary>
    ''' Ask for confirmation
    ''' </summary>
    Public Function ShowConfirmation(message As String) As Boolean
        Return MessageBox.Show(message, "Confirm", MessageBoxButtons.YesNo,
  MessageBoxIcon.Question) = DialogResult.Yes
    End Function

#End Region

#Region "Event Handlers"

    Private Sub CloseButton_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

#End Region

End Class
