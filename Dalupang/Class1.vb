Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

''' <summary>
''' Custom label control that renders text with an outlined/stroked appearance
''' Provides high-contrast text perfect for overlaying on images or complex backgrounds
''' </summary>
<ToolboxBitmap(GetType(Label))>
Public Class OutlinedLabel
    Inherits Label

#Region "Properties"

    Private _outlineColor As Color = Color.Black
    Private _outlineWidth As Integer = 2

    ''' <summary>
    ''' Gets or sets the color of the text outline
    ''' </summary>
    <Category("Appearance")>
    <Description("The color used for the text outline")>
    Public Property OutlineColor As Color
        Get
            Return _outlineColor
        End Get
        Set(value As Color)
            _outlineColor = value
            Invalidate() ' Trigger repaint
        End Set
    End Property

    ''' <summary>
    ''' Gets or sets the width of the text outline in pixels
    ''' </summary>
    <Category("Appearance")>
    <Description("The width of the text outline in pixels")>
    Public Property OutlineWidth As Integer
        Get
            Return _outlineWidth
        End Get
        Set(value As Integer)
            _outlineWidth = Math.Max(1, value) ' Minimum width of 1
            Invalidate() ' Trigger repaint
        End Set
    End Property

#End Region

#Region "Rendering"

    ''' <summary>
    ''' Custom paint logic to render outlined text
    ''' </summary>
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        ' Enable anti-aliasing for smooth text rendering
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        e.Graphics.TextRenderingHint = Drawing.Text.TextRenderingHint.AntiAlias

        ' Setup text format
        Dim format As New StringFormat()
        format.Alignment = GetHorizontalAlignment()
        format.LineAlignment = GetVerticalAlignment()

        Using graphicsPath As New Drawing2D.GraphicsPath()
            ' Add text to path (converting points to device units)
            graphicsPath.AddString(
                Me.Text,
                Me.Font.FontFamily,
                CInt(Me.Font.Style),
                Me.Font.SizeInPoints * 1.33F, ' Convert to device units
                Me.ClientRectangle,
                format
            )

            ' Draw outline (stroke)
            Using pen As New Pen(_outlineColor, _outlineWidth)
                pen.LineJoin = Drawing2D.LineJoin.Round ' Smooth corners
                e.Graphics.DrawPath(pen, graphicsPath)
            End Using

            ' Fill text interior
            Using brush As New SolidBrush(Me.ForeColor)
                e.Graphics.FillPath(brush, graphicsPath)
            End Using
        End Using
    End Sub

    ''' <summary>
    ''' Convert TextAlign to StringAlignment for horizontal alignment
    ''' </summary>
    Private Function GetHorizontalAlignment() As StringAlignment
        Select Case Me.TextAlign
            Case ContentAlignment.TopLeft, ContentAlignment.MiddleLeft, ContentAlignment.BottomLeft
                Return StringAlignment.Near
            Case ContentAlignment.TopCenter, ContentAlignment.MiddleCenter, ContentAlignment.BottomCenter
                Return StringAlignment.Center
            Case ContentAlignment.TopRight, ContentAlignment.MiddleRight, ContentAlignment.BottomRight
                Return StringAlignment.Far
            Case Else
                Return StringAlignment.Near
        End Select
    End Function

    ''' <summary>
    ''' Convert TextAlign to StringAlignment for vertical alignment
    ''' </summary>
    Private Function GetVerticalAlignment() As StringAlignment
        Select Case Me.TextAlign
            Case ContentAlignment.TopLeft, ContentAlignment.TopCenter, ContentAlignment.TopRight
                Return StringAlignment.Near
            Case ContentAlignment.MiddleLeft, ContentAlignment.MiddleCenter, ContentAlignment.MiddleRight
                Return StringAlignment.Center
            Case ContentAlignment.BottomLeft, ContentAlignment.BottomCenter, ContentAlignment.BottomRight
                Return StringAlignment.Far
            Case Else
                Return StringAlignment.Center
        End Select
    End Function

#End Region

End Class
