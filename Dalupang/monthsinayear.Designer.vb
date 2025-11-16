<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class monthsinayear
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
     components.Dispose()
   End If
Finally
  MyBase.Dispose(disposing)
        End Try
  End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        ' 
        ' monthsinayear
        ' 
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1000, 700)
        Me.MinimumSize = New Size(800, 600)
        Me.Name = "monthsinayear"
        Me.Text = "Months in a Year - Data Structures Module"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
    End Sub
End Class
