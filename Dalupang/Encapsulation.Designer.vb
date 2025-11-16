<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Encapsulation
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

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.SuspendLayout()
        ' 
        ' Encapsulation
        ' 
        Me.AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        Me.AutoScaleMode = AutoScaleMode.Font
        Me.ClientSize = New Size(1000, 700)
        Me.MinimumSize = New Size(800, 600)
        Me.Name = "Encapsulation"
        Me.Text = "Encapsulation - OOP Demonstration"
        Me.StartPosition = FormStartPosition.CenterScreen
        Me.ResumeLayout(False)
    End Sub
End Class
