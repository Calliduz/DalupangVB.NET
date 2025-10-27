Imports System.Runtime.InteropServices

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles MenuStrip1.ItemClicked

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub OutlinedLabel1_Click(sender As Object, e As EventArgs) Handles OutlinedLabel1.Click

    End Sub

    Private Sub BlurredMenuStrip1_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs)

    End Sub

    Private Sub CalculatorToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CalculatorToolStripMenuItem.Click
        Dim frm As New Form2()
        frm.Show()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Application.Exit()
    End Sub

    Private Sub DecisionStatementsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DecisionStatementsToolStripMenuItem.Click

    End Sub

    Private Sub InheritanceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InheritanceToolStripMenuItem.Click
        Dim frm As New Form3()
        frm.Show()
    End Sub

    Private Sub PolymorphismToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PolymorphismToolStripMenuItem.Click
        Dim frm As New Polymorphism()
        frm.Show()
    End Sub

    Private Sub EncapsulationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EncapsulationToolStripMenuItem.Click
        Dim frm As New Encapsulation()
        frm.Show()
    End Sub

    Private Sub ClassesAndMethodsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ClassesAndMethodsToolStripMenuItem.Click
        Dim frm As New ClassandMethods()
        frm.Show()
    End Sub

    Private Sub InterfaceToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InterfaceToolStripMenuItem.Click
        Dim frm As New InterfaceDemo()
        frm.Show()
    End Sub

    Private Sub ConsoleApplicationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ConsoleApplicationToolStripMenuItem.Click
        AllocConsole()
        Console.WriteLine("This is my first console application")
    End Sub

    Private Sub IfThenStatementToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub IfStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IfStatementToolStripMenuItem.Click
        Dim frm As New IfStatementDemo()
        frm.Show()
    End Sub

    Private Sub NestedIfToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles NestedIfToolStripMenuItem.Click
        Dim frm As New NestedIfDemo()
        frm.Show()
    End Sub

    Private Sub BASICOFVBToolStripMenuItem_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub BASICOFVBToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BASICOFVBToolStripMenuItem1.Click
        ' Close any other open forms so we're "back" to this main form
        For i As Integer = Application.OpenForms.Count - 1 To 0 Step -1
            Dim f As Form = Application.OpenForms(i)
            If Not Object.ReferenceEquals(f, Me) Then
                f.Close()
            End If
        Next

        ' Ensure this form is visible and focused
        If Not Me.Visible Then
            Me.Show()
        End If
        Me.BringToFront()
        Me.Focus()

        ' Close any open dropdowns on the MenuStrip
        For Each item As ToolStripItem In MenuStrip1.Items
            Dim dd = TryCast(item, ToolStripDropDownItem)
            If dd IsNot Nothing AndAlso dd.DropDown.Visible Then
                dd.DropDown.Close()
            End If
        Next

        ' Hide the menu strip (closes the strip)
        'MenuStrip1.Visible = False
    End Sub

    Private Sub LoopingStatementToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LoopingStatementToolStripMenuItem.Click
        Dim frm As New LogicalOperatorsDemo()
        frm.Show()
    End Sub

    Private Sub RelationalOperatorsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles RelationalOperatorsToolStripMenuItem.Click
        Dim frm As New RelationalOperatorsDemo()
        frm.Show()
    End Sub

    Private Sub ToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem1.Click

    End Sub

    Private Sub ToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles ToolStripMenuItem2.Click
        Dim frm As New MathOperatorsDemo()
        frm.Show()
    End Sub

    Private Sub ForNextToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ForNextToolStripMenuItem.Click
        Dim frm As New ForNextDemo()
        frm.Show()
    End Sub

    Private Sub DoWhileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DoWhileToolStripMenuItem.Click
        Dim frm As New DoWhileDemo()
        frm.Show()
    End Sub

    Private Sub Week6ToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Week6ToolStripMenuItem.Click

    End Sub

    Private Sub SelectCaseToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SelectCaseToolStripMenuItem.Click
        Dim frm As New SelectCaseDemo()
        frm.Show()
    End Sub

    Private Sub MonthsInAYearToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthsInAYearToolStripMenuItem.Click
        Dim frm As New monthsinayear()
        frm.Show()
    End Sub

    Private Sub DaysInAWeekToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DaysInAWeekToolStripMenuItem.Click
        Dim frm As New daysinaweek()
        frm.Show()
    End Sub

    Private Sub Priest3CannibalToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles Priest3CannibalToolStripMenuItem.Click
        Dim frm As New priestcannibal()
        frm.Show()
    End Sub

    Private Sub TruthTableToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TruthTableToolStripMenuItem.Click
        Dim frm As New ttable()
        frm.Show()
    End Sub
End Class


