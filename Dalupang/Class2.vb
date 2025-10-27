Imports System.Drawing.Drawing2D
Imports System.Drawing.Imaging
Imports System.Windows.Forms

Public Class BlurredMenuStrip
    Inherits MenuStrip

    Public Property MosaicBlockSize As Integer = 8

    Protected Overrides Sub OnPaintBackground(e As PaintEventArgs)
        MyBase.OnPaintBackground(e)

        If Parent Is Nothing Then Return

        ' Capture the parent background
        Dim bmp As New Bitmap(Me.Width, Me.Height)
        Parent.DrawToBitmap(bmp, Me.Bounds)

        ' Apply mosaic blur
        Dim blurred = ApplyMosaicBlur(bmp, MosaicBlockSize)

        ' Draw blurred background
        e.Graphics.DrawImage(blurred, 0, 0)
    End Sub

    Private Function ApplyMosaicBlur(src As Bitmap, blockSize As Integer) As Bitmap
        Dim bmp As New Bitmap(src.Width, src.Height)

        Using g As Graphics = Graphics.FromImage(bmp)
            For y As Integer = 0 To src.Height - 1 Step blockSize
                For x As Integer = 0 To src.Width - 1 Step blockSize
                    Dim avgColor As Color = GetAverageColor(src, x, y, blockSize)
                    Using brush As New SolidBrush(avgColor)
                        g.FillRectangle(brush, x, y, blockSize, blockSize)
                    End Using
                Next
            Next
        End Using

        Return bmp
    End Function

    Private Function GetAverageColor(src As Bitmap, startX As Integer, startY As Integer, blockSize As Integer) As Color
        Dim r, g, b, count As Integer
        For y As Integer = startY To Math.Min(startY + blockSize - 1, src.Height - 1)
            For x As Integer = startX To Math.Min(startX + blockSize - 1, src.Width - 1)
                Dim pixel = src.GetPixel(x, y)
                r += pixel.R
                g += pixel.G
                b += pixel.B
                count += 1
            Next
        Next
        If count = 0 Then Return Color.Transparent
        Return Color.FromArgb(r \ count, g \ count, b \ count)
    End Function
End Class
