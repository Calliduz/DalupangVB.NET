Imports System.ComponentModel

''' <summary>
''' Truth Table Generator and Interactive Boolean Logic Demonstrator
''' Educational tool for visualizing boolean operations and logical operators
''' </summary>
Public Class TruthTableDemonstration
    Inherits Form

#Region "Constants"

    Private Const COLUMN_INPUT_A As String = "InputA"
    Private Const COLUMN_INPUT_B As String = "InputB"
    Private Const COLUMN_NOT_A As String = "NotA"
    Private Const COLUMN_AND As String = "And"
    Private Const COLUMN_OR As String = "Or"
    Private Const COLUMN_XOR As String = "Xor"

#End Region

#Region "Form Initialization"

    Private Sub TruthTableDemonstration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeUI()
        ConfigureDataGridView()
        GenerateTruthTable()
        UpdateInteractiveResults()
    End Sub

    ''' <summary>
    ''' Configure UI elements for optimal user experience
    ''' </summary>
    Private Sub InitializeUI()
        Me.Text = "Boolean Logic - Truth Table Demonstration"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Configure interactive controls
        ConfigureCheckBox(chkInputA, "Input A", "Toggle boolean value A")
        ConfigureCheckBox(chkInputB, "Input B", "Toggle boolean value B")

        ' Configure button
        btnGenerate.FlatStyle = FlatStyle.Flat
        btnGenerate.BackColor = Color.FromArgb(70, 130, 180)
        btnGenerate.ForeColor = Color.White
        btnGenerate.Font = New Font("Segoe UI", 11, FontStyle.Bold)
        btnGenerate.Cursor = Cursors.Hand

        ' Configure group box
        grpInteractive.Text = "Interactive Boolean Logic Tester"
        grpInteractive.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        grpInteractive.ForeColor = Color.FromArgb(70, 130, 180)

        ' Configure result labels
        ConfigureResultLabel(lblNotResult, "NOT Result")
        ConfigureResultLabel(lblAndResult, "AND Result")
        ConfigureResultLabel(lblOrResult, "OR Result")
        ConfigureResultLabel(lblXorResult, "XOR Result")
    End Sub

    ''' <summary>
    ''' Configure checkbox properties for consistency
    ''' </summary>
    Private Sub ConfigureCheckBox(checkBox As CheckBox, text As String, accessibleName As String)
        checkBox.Text = text
        checkBox.Font = New Font("Segoe UI", 10, FontStyle.Regular)
        checkBox.AccessibleName = accessibleName
        checkBox.Cursor = Cursors.Hand
    End Sub

    ''' <summary>
    ''' Configure result label styling
    ''' </summary>
    Private Sub ConfigureResultLabel(label As Label, accessibleName As String)
        label.Font = New Font("Consolas", 10, FontStyle.Bold)
        label.ForeColor = Color.White
        label.BackColor = Color.FromArgb(50, 50, 50)
        label.Padding = New Padding(5)
        label.AutoSize = False
        label.Width = 200
        label.AccessibleName = accessibleName
    End Sub

    ''' <summary>
    ''' Configure DataGridView for optimal display
    ''' </summary>
    Private Sub ConfigureDataGridView()
        With dgvTruthTable
            .AllowUserToAddRows = False
            .AllowUserToDeleteRows = False
            .AllowUserToResizeRows = False
            .ReadOnly = True
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect
            .MultiSelect = False
            .RowHeadersVisible = False
            .BackgroundColor = Color.White
            .BorderStyle = BorderStyle.Fixed3D
            .EnableHeadersVisualStyles = False
            .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill

            ' Header styling
            .ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(70, 130, 180)
            .ColumnHeadersDefaultCellStyle.ForeColor = Color.White
            .ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
            .ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .ColumnHeadersHeight = 40

            ' Cell styling
            .DefaultCellStyle.Font = New Font("Consolas", 10)
            .DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            .DefaultCellStyle.SelectionBackColor = Color.FromArgb(100, 149, 237)
            .DefaultCellStyle.SelectionForeColor = Color.White
            .RowTemplate.Height = 30

            ' Alternating row colors
            .AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240)
        End With

        ' Add columns
        AddTruthTableColumns()
    End Sub

    ''' <summary>
    ''' Add columns to the truth table grid
    ''' </summary>
    Private Sub AddTruthTableColumns()
        dgvTruthTable.Columns.Clear()

        ' Input columns with blue background
        AddStyledColumn(COLUMN_INPUT_A, "A", Color.FromArgb(200, 230, 255))
        AddStyledColumn(COLUMN_INPUT_B, "B", Color.FromArgb(200, 230, 255))

        ' Operation columns with yellow background
        AddStyledColumn(COLUMN_NOT_A, "NOT A", Color.FromArgb(255, 255, 200))
        AddStyledColumn(COLUMN_AND, "A AND B", Color.FromArgb(200, 255, 200))
        AddStyledColumn(COLUMN_OR, "A OR B", Color.FromArgb(255, 230, 200))
        AddStyledColumn(COLUMN_XOR, "A XOR B", Color.FromArgb(230, 200, 255))
    End Sub

    ''' <summary>
    ''' Add styled column to DataGridView
    ''' </summary>
    Private Sub AddStyledColumn(columnName As String, headerText As String, backColor As Color)
        Dim column As New DataGridViewTextBoxColumn()
        column.Name = columnName
        column.HeaderText = headerText
        column.DefaultCellStyle.BackColor = backColor
        dgvTruthTable.Columns.Add(column)
    End Sub

#End Region

#Region "Truth Table Generation"

    ''' <summary>
    ''' Generate complete truth table for all boolean combinations
    ''' </summary>
    Private Sub GenerateTruthTable()
        dgvTruthTable.Rows.Clear()

        Dim booleanValues As Boolean() = {True, False}

        For Each valueA In booleanValues
            For Each valueB In booleanValues
                AddTruthTableRow(valueA, valueB)
            Next
        Next

        ' Auto-adjust column widths after data is loaded
        dgvTruthTable.AutoResizeColumns()
    End Sub

    ''' <summary>
    ''' Add a single row to the truth table with calculated results
    ''' </summary>
    Private Sub AddTruthTableRow(a As Boolean, b As Boolean)
        Dim row As New DataGridViewRow()
        row.CreateCells(dgvTruthTable)

        ' Set values with formatting
        row.Cells(0).Value = FormatBooleanValue(a)
        row.Cells(1).Value = FormatBooleanValue(b)
        row.Cells(2).Value = FormatBooleanValue(Not a)
        row.Cells(3).Value = FormatBooleanValue(a And b)
        row.Cells(4).Value = FormatBooleanValue(a Or b)
        row.Cells(5).Value = FormatBooleanValue(a Xor b)

        ' Color code results
        ColorCodeCell(row.Cells(2), Not a)
        ColorCodeCell(row.Cells(3), a And b)
        ColorCodeCell(row.Cells(4), a Or b)
        ColorCodeCell(row.Cells(5), a Xor b)

        dgvTruthTable.Rows.Add(row)
    End Sub

    ''' <summary>
    ''' Format boolean value for display
    ''' </summary>
    Private Function FormatBooleanValue(value As Boolean) As String
        Return If(value, "TRUE", "FALSE")
    End Function

    ''' <summary>
    ''' Color code cell based on boolean result
    ''' </summary>
    Private Sub ColorCodeCell(cell As DataGridViewCell, result As Boolean)
        If result Then
            cell.Style.Font = New Font("Consolas", 10, FontStyle.Bold)
            cell.Style.ForeColor = Color.DarkGreen
        Else
            cell.Style.ForeColor = Color.DarkRed
        End If
    End Sub

#End Region

#Region "Interactive Logic Testing"

    ''' <summary>
    ''' Update interactive results based on checkbox states
    ''' </summary>
    Private Sub UpdateInteractiveResults()
        Dim a As Boolean = chkInputA.Checked
        Dim b As Boolean = chkInputB.Checked

        ' Calculate all operations
        Dim notResult As Boolean = Not a
        Dim andResult As Boolean = a And b
        Dim orResult As Boolean = a Or b
        Dim xorResult As Boolean = a Xor b

        ' Update labels with color coding
        UpdateResultLabel(lblNotResult, "NOT A", notResult)
        UpdateResultLabel(lblAndResult, "A AND B", andResult)
        UpdateResultLabel(lblOrResult, "A OR B", orResult)
        UpdateResultLabel(lblXorResult, "A XOR B", xorResult)

        ' Highlight corresponding row in truth table
        HighlightMatchingRow(a, b)
    End Sub

    ''' <summary>
    ''' Update result label with formatted text and color
    ''' </summary>
    Private Sub UpdateResultLabel(label As Label, operation As String, result As Boolean)
        label.Text = $"{operation} = {FormatBooleanValue(result)}"
        label.BackColor = If(result, Color.FromArgb(0, 128, 0), Color.FromArgb(128, 0, 0))
    End Sub

    ''' <summary>
    ''' Highlight the truth table row matching current interactive values
    ''' </summary>
    Private Sub HighlightMatchingRow(a As Boolean, b As Boolean)
        For Each row As DataGridViewRow In dgvTruthTable.Rows
            Dim rowA As String = row.Cells(0).Value.ToString()
            Dim rowB As String = row.Cells(1).Value.ToString()

            If rowA = FormatBooleanValue(a) AndAlso rowB = FormatBooleanValue(b) Then
                dgvTruthTable.ClearSelection()
                row.Selected = True
                dgvTruthTable.FirstDisplayedScrollingRowIndex = row.Index
                Exit For
            End If
        Next
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs) Handles btnGenerate.Click
        GenerateTruthTable()
        MessageBox.Show(
            "Truth table regenerated successfully!" & Environment.NewLine & Environment.NewLine &
            "The table shows all possible combinations of two boolean inputs (A and B) " +
            "and the results of various logical operations.",
            "Truth Table Generated",
            MessageBoxButtons.OK,
            MessageBoxIcon.Information
        )
    End Sub

    Private Sub chkInputA_CheckedChanged(sender As Object, e As EventArgs) Handles chkInputA.CheckedChanged
        UpdateInteractiveResults()
    End Sub

    Private Sub chkInputB_CheckedChanged(sender As Object, e As EventArgs) Handles chkInputB.CheckedChanged
        UpdateInteractiveResults()
    End Sub

#End Region

End Class
