Imports System.Drawing
Imports System.Windows.Forms
Imports System.Linq

Partial Public Class priestcannibal
    Inherits Form

    Private Const CHAR_WIDTH As Integer = 60
    Private Const CHAR_HEIGHT As Integer = 30

    ' NOTE: UI controls (leftPanel, rightPanel, boatPanel, moveBoatButton, resetButton, livesLabel, statusLabel)
    ' are declared in the Designer partial. Don't redeclare them here.

    Private characters As New List(Of GameCharacter)
    Private boatSide As String = "left"
    Private boatCapacity As Integer = 2
    Private lives As Integer = 3

    Private Class GameCharacter
        Public Property Id As Integer
        Public Property TypeName As String ' Priest or Devil
        Public Property Location As String ' left, right, or boat
        Public Property Btn As Button
    End Class

    Public Sub New()
        ' Designer initialization (creates controls)
        InitializeComponent()

        ' Wire up event handlers for Designer-created controls
        AddHandler moveBoatButton.Click, AddressOf MoveBoatButton_Click
        AddHandler resetButton.Click, AddressOf ResetButton_Click

        ' Continue with game-specific initialization
        InitializeCharacters()
        UpdateUI()
        UpdateLivesDisplay()

        ' Ensure lives label stays in place on load/resize
        AddHandler Me.Load, AddressOf OnFormLoad
        AddHandler Me.Resize, AddressOf OnFormResize
    End Sub

    Private Sub OnFormLoad(sender As Object, e As EventArgs)
        PositionLivesLabel()
    End Sub

    Private Sub OnFormResize(sender As Object, e As EventArgs)
        PositionLivesLabel()
    End Sub

    Private Sub PositionLivesLabel()
        ' place it top-right using PreferredWidth so it fits even with fonts/DPI
        If livesLabel Is Nothing Then Return
        Dim labelWidth As Integer = livesLabel.PreferredWidth
        Dim x As Integer = Math.Max(10, Me.ClientSize.Width - labelWidth - 20)
        Dim y As Integer = 10
        livesLabel.Location = New Point(x, y)
        livesLabel.BringToFront()
    End Sub

    Private Sub UpdateLivesDisplay()
        Dim hearts As String = ""
        For i As Integer = 1 To Math.Max(0, lives)
            hearts &= "♥ "
        Next
        livesLabel.Text = "Lives: " & hearts.TrimEnd()
        PositionLivesLabel()
    End Sub

    Private Sub InitializeCharacters()
        characters.Clear()

        ' Priests
        For i As Integer = 1 To 3
            Dim c As New GameCharacter With {
                .Id = i,
                .TypeName = "Priest",
                .Location = "left",
                .Btn = CreateCharacterButton("P" & i, Color.White)
            }
            AddHandler c.Btn.Click, Sub(s, e) CharacterButton_Click(c)
            characters.Add(c)
        Next

        ' Devils
        For i As Integer = 1 To 3
            Dim c As New GameCharacter With {
                .Id = i + 3,
                .TypeName = "Devil",
                .Location = "left",
                .Btn = CreateCharacterButton("D" & i, Color.Red)
            }
            AddHandler c.Btn.Click, Sub(s, e) CharacterButton_Click(c)
            characters.Add(c)
        Next
    End Sub

    Private Function CreateCharacterButton(text As String, backColor As Color) As Button
        Dim b As New Button() With {
            .Text = text,
            .Size = New Size(CHAR_WIDTH, CHAR_HEIGHT),
            .TextAlign = ContentAlignment.MiddleCenter,
            .Font = New Font("Segoe UI", 9, FontStyle.Bold),
            .BackColor = backColor
        }
        Return b
    End Function

    Private Sub UpdateUI()
        ' Remove any existing character buttons from panels
        For Each p As Panel In New Panel() {leftPanel, rightPanel, boatPanel}
            Dim toRemove As New List(Of Control)
            For Each c As Control In p.Controls
                If TypeOf c Is Button Then toRemove.Add(c)
            Next
            For Each r As Control In toRemove
                p.Controls.Remove(r)
            Next
        Next

        ' Place characters
        Dim leftY As Integer = 40
        Dim rightY As Integer = 40
        Dim boatX As Integer = 10
        Dim boatY As Integer = 35
        Dim boatCount As Integer = 0

        For Each ch In characters.OrderBy(Function(cc) cc.TypeName).ThenBy(Function(cc) cc.Id)
            Dim btn = ch.Btn
            Select Case ch.Location
                Case "left"
                    btn.Location = New Point(10, leftY)
                    leftPanel.Controls.Add(btn)
                    leftY += CHAR_HEIGHT + 10
                Case "right"
                    btn.Location = New Point(10, rightY)
                    rightPanel.Controls.Add(btn)
                    rightY += CHAR_HEIGHT + 10
                Case "boat"
                    btn.Location = New Point(boatX + (boatCount * (CHAR_WIDTH + 4)), boatY)
                    If Not boatPanel.Controls.Contains(btn) Then boatPanel.Controls.Add(btn)
                    boatCount += 1
            End Select
        Next

        ' Move boat graphic position depending on side
        If boatSide = "left" Then
            boatPanel.Location = New Point(280, 150)
        Else
            boatPanel.Location = New Point(500, 150)
        End If

        PositionLivesLabel() ' ensure lives label stays visible
    End Sub

    Private Sub CharacterButton_Click(ch As GameCharacter)
        If ch.Location = "boat" Then
            ch.Location = boatSide
            UpdateUI()
            CheckRulesAndWin()
            Return
        End If

        If ch.Location = boatSide Then
            Dim onBoatCount = characters.Where(Function(c) c.Location = "boat").Count()
            If onBoatCount >= boatCapacity Then
                MessageBox.Show("Boat is full.", "Can't board")
                Return
            End If
            ch.Location = "boat"
            UpdateUI()
            CheckRulesAndWin()
        Else
            MessageBox.Show("That character is not on the same side as the boat.", "Cannot board")
        End If
    End Sub

    Private Sub MoveBoatButton_Click(sender As Object, e As EventArgs)
        Dim onBoatCount = characters.Where(Function(c) c.Location = "boat").Count()
        If onBoatCount = 0 Then
            MessageBox.Show("The boat needs at least 1 person to move.", "Can't move")
            Return
        End If

        If boatSide = "left" Then boatSide = "right" Else boatSide = "left"

        For Each c In characters.Where(Function(cc) cc.Location = "boat")
            c.Location = boatSide
        Next

        UpdateUI()
        CheckRulesAndWin()
    End Sub

    Private Sub ResetButton_Click(sender As Object, e As EventArgs)
        lives = 3
        UpdateLivesDisplay()
        ResetGame()
    End Sub

    Private Sub ResetGame()
        boatSide = "left"
        For Each c In characters
            c.Location = "left"
        Next
        UpdateUI()
        CheckRulesAndWin()
    End Sub

    Private Sub LoseLife()
        lives -= 1
        UpdateLivesDisplay()

        If lives > 0 Then
            MessageBox.Show("You lost a life. Remaining: " & lives, "Try again")
            ResetGame()
        Else
            ShowGameOver()
        End If
    End Sub

    Private Sub ShowGameOver()
        Dim gameOverForm As New Form() With {
            .FormBorderStyle = FormBorderStyle.None,
            .StartPosition = FormStartPosition.CenterParent,
            .Size = New Size(400, 250),
            .BackColor = Color.Black,
            .Opacity = 0.95
        }

        Dim gameOverLabel As New Label() With {
            .Text = "GAME OVER",
            .Font = New Font("Segoe UI", 32, FontStyle.Bold),
            .ForeColor = Color.Red,
            .AutoSize = False,
            .Size = New Size(400, 80),
            .Location = New Point(0, 50),
            .TextAlign = ContentAlignment.MiddleCenter
        }
        gameOverForm.Controls.Add(gameOverLabel)

        Dim restartButton As New Button() With {
            .Text = "Play Again",
            .Size = New Size(150, 40),
            .Location = New Point(125, 150),
            .Font = New Font("Segoe UI", 12, FontStyle.Bold),
            .UseVisualStyleBackColor = True
        }
        AddHandler restartButton.Click, Sub(s, e)
                                            gameOverForm.Close()
                                            lives = 3
                                            UpdateLivesDisplay()
                                            ResetGame()
                                            statusLabel.Text = ""
                                            statusLabel.Visible = False
                                        End Sub
        gameOverForm.Controls.Add(restartButton)

        gameOverForm.ShowDialog(Me)
    End Sub

    Private Sub CheckRulesAndWin()
        Dim leftPriests = characters.Where(Function(c) (((c.Location = "left") Or (c.Location = "boat" AndAlso boatSide = "left")) AndAlso c.TypeName = "Priest")).Count()
        Dim leftDevils = characters.Where(Function(c) (((c.Location = "left") Or (c.Location = "boat" AndAlso boatSide = "left")) AndAlso c.TypeName = "Devil")).Count()
        Dim rightPriests = characters.Where(Function(c) (((c.Location = "right") Or (c.Location = "boat" AndAlso boatSide = "right")) AndAlso c.TypeName = "Priest")).Count()
        Dim rightDevils = characters.Where(Function(c) (((c.Location = "right") Or (c.Location = "boat" AndAlso boatSide = "right")) AndAlso c.TypeName = "Devil")).Count()

        Dim shouldLoseLife As Boolean = False

        If leftPriests > 0 AndAlso leftDevils > leftPriests Then
            MessageBox.Show("You lose! On the left shore devils outnumber priests.", "Lost a Life")
            shouldLoseLife = True
        End If

        If rightPriests > 0 AndAlso rightDevils > rightPriests Then
            MessageBox.Show("You lose! On the right shore devils outnumber priests.", "Lost a Life")
            shouldLoseLife = True
        End If

        If shouldLoseLife Then
            LoseLife()
            Return
        End If

        If characters.All(Function(c) c.Location = "right") Then
            MessageBox.Show("Congratulations — you win!", "You Win")
            lives = 3
            UpdateLivesDisplay()
            ResetGame()
        End If

        UpdateLivesDisplay() ' ✅ keep lives synced
    End Sub

    ' Fixed: correct label name
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles livesLabel.Click
        ' Optional: no action needed
    End Sub
End Class
