Imports System.Drawing
Imports System.Windows.Forms
Imports System.ComponentModel

Public Class TruthTableDemonstration
    Inherits Form

#Region "Private Fields"

    Private pnlHeader As Panel
    Private pnlContent As Panel
    Private pnlFooter As Panel
    Private lblTitle As Label
    Private lblDescription As Label
    Private dgvTruthTable As DataGridView
    Private btnGenerate As Button
    Private btnClear As Button
    Private pnlInstructions As Panel
    Private pnlInteractive As Panel
    Private chkInputA As CheckBox
    Private chkInputB As CheckBox
    Private lblResults As Label

#End Region

#Region "Constructor"

    Public Sub New()
        InitializeComponent()
        Me.Controls.Clear()
        Me.BackgroundImage = Nothing
        InitializeEnterpriseUI()
    End Sub

#End Region

#Region "Form Initialization"

    Private Sub TruthTableDemonstration_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GenerateTruthTable()
        UpdateInteractiveResults()
    End Sub

    Private Sub InitializeEnterpriseUI()
        Me.BackColor = EnterpriseDesignSystem.LightTheme.Background
        Me.BackgroundImage = Nothing

        If AppConfiguration.Performance.EnableDoubleBuffering Then
            Me.DoubleBuffered = True
            Me.SetStyle(ControlStyles.OptimizedDoubleBuffer Or
           ControlStyles.AllPaintingInWmPaint Or
  ControlStyles.UserPaint, True)
        End If

        CreateFooter()
        CreateButtons()
        CreateContentArea()
        CreateInteractive()
        CreateInstructions()
        CreateHeader()
    End Sub

    Private Sub CreateHeader()
        pnlHeader = New Panel With {
   .Dock = DockStyle.Top,
     .Height = 110,
            .BackColor = EnterpriseDesignSystem.ModuleColors.Games,
            .Padding = New Padding(24, 20, 24, 20)
        }

        lblTitle = New Label With {
         .Text = "✓❌ Truth Table Generator",
       .Font = New Font("Segoe UI", 18, FontStyle.Bold),
         .ForeColor = Color.White,
            .AutoSize = True,
      .Location = New Point(24, 16)
        }

        lblDescription = New Label With {
    .Text = "Interactive boolean logic demonstration and truth table generator",
            .Font = New Font("Segoe UI", 10),
         .ForeColor = Color.FromArgb(240, 240, 240),
 .AutoSize = True,
            .Location = New Point(24, 50)
   }

        pnlHeader.Controls.AddRange({lblTitle, lblDescription})
        Me.Controls.Add(pnlHeader)
    End Sub

    Private Sub CreateInstructions()
        pnlInstructions = New Panel With {
            .Dock = DockStyle.Top,
            .Height = 110,
.BackColor = Color.White,
   .Padding = New Padding(32, 20, 32, 20)
     }

        Dim lblTitle = New Label With {
   .Text = "💡 Boolean Logic Demonstration",
            .Font = New Font("Segoe UI", 13, FontStyle.Bold),
         .ForeColor = Color.FromArgb(45, 55, 72),
   .AutoSize = True,
       .Location = New Point(32, 16)
        }

        Dim lblText = New Label With {
  .Text = "Explore all boolean operations (AND, OR, NOT, XOR). Toggle inputs to see results update in real-time!",
    .Font = New Font("Segoe UI", 10),
      .ForeColor = Color.FromArgb(100, 116, 139),
     .AutoSize = False,
            .Size = New Size(900, 40),
            .Location = New Point(32, 48)
        }

        pnlInstructions.Controls.AddRange({lblTitle, lblText})
        Me.Controls.Add(pnlInstructions)
    End Sub

    Private Sub CreateInteractive()
        pnlInteractive = New Panel With {
            .Dock = DockStyle.Top,
            .Height = 100,
  .BackColor = Color.FromArgb(248, 250, 252),
  .Padding = New Padding(32, 20, 32, 20)
  }

        chkInputA = New CheckBox With {
               .Text = "Input A (Boolean)",
               .Location = New Point(32, 25),
               .AutoSize = True,
        .Font = New Font("Segoe UI", 11, FontStyle.Bold),
               .Checked = True,
               .Cursor = Cursors.Hand
        }

        chkInputB = New CheckBox With {
 .Text = "Input B (Boolean)",
    .Location = New Point(250, 25),
            .AutoSize = True,
            .Font = New Font("Segoe UI", 11, FontStyle.Bold),
            .Checked = False,
          .Cursor = Cursors.Hand
        }

        lblResults = New Label With {
  .Location = New Point(450, 20),
  .AutoSize = False,
.Size = New Size(400, 50),
            .Font = New Font("Consolas", 10, FontStyle.Bold),
      .ForeColor = Color.FromArgb(45, 55, 72),
          .Text = "Results update automatically..."
        }

        AddHandler chkInputA.CheckedChanged, AddressOf CheckBox_Changed
        AddHandler chkInputB.CheckedChanged, AddressOf CheckBox_Changed

        pnlInteractive.Controls.AddRange({chkInputA, chkInputB, lblResults})
        Me.Controls.Add(pnlInteractive)
    End Sub

    Private Sub CreateContentArea()
        pnlContent = New Panel With {
       .Dock = DockStyle.Fill,
            .BackColor = EnterpriseDesignSystem.LightTheme.Background,
            .Padding = New Padding(32, 24, 32, 24)
  }

        dgvTruthTable = New DataGridView With {
            .Dock = DockStyle.Fill,
         .AllowUserToAddRows = False,
            .AllowUserToDeleteRows = False,
   .ReadOnly = True,
            .SelectionMode = DataGridViewSelectionMode.FullRowSelect,
  .BackgroundColor = Color.White,
       .BorderStyle = BorderStyle.FixedSingle,
 .AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
            .RowHeadersVisible = False,
            .Font = New Font("Consolas", 10)
        }

        dgvTruthTable.ColumnHeadersDefaultCellStyle.BackColor = EnterpriseDesignSystem.ModuleColors.Games
        dgvTruthTable.ColumnHeadersDefaultCellStyle.ForeColor = Color.White
        dgvTruthTable.ColumnHeadersDefaultCellStyle.Font = New Font("Segoe UI", 10, FontStyle.Bold)
        dgvTruthTable.ColumnHeadersHeight = 40
        dgvTruthTable.RowTemplate.Height = 30

        ConfigureDataGridColumns()

        pnlContent.Controls.Add(dgvTruthTable)
        Me.Controls.Add(pnlContent)
    End Sub

    Private Sub ConfigureDataGridColumns()
        dgvTruthTable.Columns.Clear()
        dgvTruthTable.Columns.Add("A", "A")
        dgvTruthTable.Columns.Add("B", "B")
        dgvTruthTable.Columns.Add("NotA", "NOT A")
        dgvTruthTable.Columns.Add("And", "A AND B")
        dgvTruthTable.Columns.Add("Or", "A OR B")
        dgvTruthTable.Columns.Add("Xor", "A XOR B")

        For i = 0 To 1
            dgvTruthTable.Columns(i).DefaultCellStyle.BackColor = Color.FromArgb(200, 230, 255)
        Next
        For i = 2 To 5
            dgvTruthTable.Columns(i).DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 200)
        Next
    End Sub

    Private Sub CreateButtons()
        Dim pnlButtons = New Panel With {
     .Dock = DockStyle.Bottom,
            .Height = 80,
  .BackColor = Color.White,
     .Padding = New Padding(32, 16, 32, 16)
        }

        btnGenerate = New Button With {
            .Text = "🔄 Regenerate Table",
            .Size = New Size(180, 40),
   .Location = New Point(32, 16),
  .FlatStyle = FlatStyle.Flat,
            .BackColor = Color.FromArgb(34, 197, 94),
   .ForeColor = Color.White,
 .Font = New Font("Segoe UI", 10, FontStyle.Bold),
  .Cursor = Cursors.Hand
  }
        btnGenerate.FlatAppearance.BorderSize = 0

        btnClear = New Button With {
        .Text = "🗑️ Reset",
          .Size = New Size(120, 40),
            .Location = New Point(224, 16),
            .FlatStyle = FlatStyle.Flat,
         .BackColor = Color.FromArgb(251, 191, 36),
 .ForeColor = Color.White,
      .Font = New Font("Segoe UI", 10, FontStyle.Bold),
    .Cursor = Cursors.Hand
        }
        btnClear.FlatAppearance.BorderSize = 0

        AddHandler btnGenerate.Click, AddressOf btnGenerate_Click
        AddHandler btnClear.Click, AddressOf btnClear_Click

        pnlButtons.Controls.AddRange({btnGenerate, btnClear})
        Me.Controls.Add(pnlButtons)
    End Sub

    Private Sub CreateFooter()
        pnlFooter = New Panel With {
           .Dock = DockStyle.Bottom,
                  .Height = 36,
         .BackColor = EnterpriseDesignSystem.ModuleColors.Games
              }

        Dim lblFooter = New Label With {
   .Text = "Enterprise Learning Platform  |  Logic Games Module",
   .Font = New Font("Segoe UI", 8),
        .ForeColor = Color.FromArgb(220, 220, 220),
               .Dock = DockStyle.Fill,
       .TextAlign = ContentAlignment.MiddleCenter
           }

        pnlFooter.Controls.Add(lblFooter)
        Me.Controls.Add(pnlFooter)
    End Sub

#End Region

#Region "Truth Table Logic"

    Private Sub GenerateTruthTable()
        dgvTruthTable.Rows.Clear()
        Dim values() As Boolean = {True, False}

        For Each a In values
            For Each b In values
                Dim row = New DataGridViewRow()
                row.CreateCells(dgvTruthTable)
                row.Cells(0).Value = If(a, "TRUE", "FALSE")
                row.Cells(1).Value = If(b, "TRUE", "FALSE")
                row.Cells(2).Value = If(Not a, "TRUE", "FALSE")
                row.Cells(3).Value = If(a And b, "TRUE", "FALSE")
                row.Cells(4).Value = If(a Or b, "TRUE", "FALSE")
                row.Cells(5).Value = If(a Xor b, "TRUE", "FALSE")

                For i = 2 To 5
                    Dim val = row.Cells(i).Value.ToString()
                    If val = "TRUE" Then
                        row.Cells(i).Style.ForeColor = Color.DarkGreen
                        row.Cells(i).Style.Font = New Font("Consolas", 10, FontStyle.Bold)
                    Else
                        row.Cells(i).Style.ForeColor = Color.DarkRed
                    End If
                Next

                dgvTruthTable.Rows.Add(row)
            Next
        Next
    End Sub

    Private Sub UpdateInteractiveResults()
        Dim a = chkInputA.Checked
        Dim b = chkInputB.Checked

        lblResults.Text = $"NOT A={Not a}  AND={a And b}  OR={a Or b}  XOR={a Xor b}"

        For Each row As DataGridViewRow In dgvTruthTable.Rows
            Dim match = row.Cells(0).Value.ToString() = If(a, "TRUE", "FALSE") AndAlso
       row.Cells(1).Value.ToString() = If(b, "TRUE", "FALSE")
            If match Then
                dgvTruthTable.ClearSelection()
                row.Selected = True
                Exit For
            End If
        Next
    End Sub

#End Region

#Region "Event Handlers"

    Private Sub CheckBox_Changed(sender As Object, e As EventArgs)
        UpdateInteractiveResults()
    End Sub

    Private Sub btnGenerate_Click(sender As Object, e As EventArgs)
        GenerateTruthTable()
        UpdateInteractiveResults()
        MessageBox.Show("Truth table regenerated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs)
        chkInputA.Checked = True
        chkInputB.Checked = False
        UpdateInteractiveResults()
    End Sub

#End Region

End Class
