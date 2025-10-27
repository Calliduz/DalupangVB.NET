Imports System.Drawing
Imports System.Windows.Forms

Public Class OutlinedLabel
    Inherits Label

    Public Property OutlineColor As Color = Color.Black
    Public Property OutlineWidth As Integer = 2

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        e.Graphics.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias
        Dim format As New StringFormat()
        format.Alignment = StringAlignment.Near
        format.LineAlignment = StringAlignment.Center

        Using graphicsPath As New Drawing2D.GraphicsPath()
            graphicsPath.AddString(Me.Text, Me.Font.FontFamily, CInt(Me.Font.Style), Me.Font.SizeInPoints * 1.33F,
                                   Me.ClientRectangle, format)

            ' Draw outline
            Using pen As New Pen(OutlineColor, OutlineWidth)
                pen.LineJoin = Drawing2D.LineJoin.Round
                e.Graphics.DrawPath(pen, graphicsPath)
            End Using

            ' Fill text
            Using brush As New SolidBrush(Me.ForeColor)
                e.Graphics.FillPath(brush, graphicsPath)
            End Using
        End Using
    End Sub
End Class
