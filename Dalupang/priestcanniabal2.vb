''' <summary>
''' Missionaries and Cannibals River Crossing Puzzle
''' A classic logic puzzle demonstrating state management and game logic
''' </summary>
Public Class priestcanniabal2

#Region "Constants and Configuration"

    Private Const MAX_PEOPLE As Integer = 3
    Private Const BOAT_CAPACITY As Integer = 2
    Private Const ANIMATION_DURATION As Integer = 500 ' milliseconds

#End Region

#Region "Game State Variables"

    ' Character counts by location
    Private _missionariesLeft As Integer = MAX_PEOPLE
    Private _cannibalsLeft As Integer = MAX_PEOPLE
    Private _missionariesRight As Integer = 0
    Private _cannibalsRight As Integer = 0

    ' Boat state
    Private _isBoatOnLeft As Boolean = True
    Private _missionariesOnBoat As Integer = 0
    Private _cannibalsOnBoat As Integer = 0

    ' Game statistics
    Private _moveCount As Integer = 0
    Private _gameStartTime As DateTime

#End Region

#Region "Position Constants"

    ' Left shore positions for missionaries
    Private ReadOnly MissionaryLeftPositions As Point() = {
     New Point(-5, 156),
        New Point(100, 156),
        New Point(211, 156)
    }

    ' Left shore positions for cannibals
    Private ReadOnly CannibalLeftPositions As Point() = {
        New Point(-3, 321),
        New Point(102, 321),
New Point(211, 321)
    }

    ' Right shore positions for missionaries
    Private ReadOnly MissionaryRightPositions As Point() = {
  New Point(680, 156),
      New Point(785, 156),
        New Point(890, 156)
    }

    ' Right shore positions for cannibals
    Private ReadOnly CannibalRightPositions As Point() = {
        New Point(680, 321),
        New Point(785, 321),
        New Point(890, 321)
    }

    ' Boat positions
    Private ReadOnly BoatLeftPosition As New Point(223, 143)
    Private ReadOnly BoatRightPosition As New Point(550, 143)

    ' Boat passenger positions (when on boat)
    Private ReadOnly BoatLeftSeats As Point() = {
 New Point(280, 250),
        New Point(380, 250)
    }

    Private ReadOnly BoatRightSeats As Point() = {
New Point(607, 250),
        New Point(707, 250)
 }

#End Region

#Region "Form Initialization"

    Private Sub priestcanniabal2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        InitializeGameUI()
        ResetGame()
    End Sub

    ''' <summary>
    ''' Configure UI elements for optimal user experience
    ''' </summary>
    Private Sub InitializeGameUI()
        ' Configure form
        Me.Text = "Missionaries & Cannibals - River Crossing Puzzle"
        Me.StartPosition = FormStartPosition.CenterScreen

        ' Set all character PictureBoxes as clickable with hand cursor
        ConfigureCharacterPictureBox(PictureBox1, "Missionary 1")
        ConfigureCharacterPictureBox(PictureBox2, "Missionary 2")
        ConfigureCharacterPictureBox(PictureBox3, "Missionary 3")
        ConfigureCharacterPictureBox(PictureBox5, "Cannibal 1")
        ConfigureCharacterPictureBox(PictureBox6, "Cannibal 2")
        ConfigureCharacterPictureBox(PictureBox7, "Cannibal 3")

        ' Configure boat
        PictureBox4.Cursor = Cursors.Hand
        PictureBox4.AccessibleName = "Boat - Click to sail"

        ' Set proper z-order
        PictureBox4.SendToBack() ' Boat behind characters

        ' Wire up new button handlers
        AddHandler btnReset.Click, AddressOf btnReset_Click
        AddHandler btnHelp.Click, AddressOf btnHelp_Click
    End Sub

    ''' <summary>
    ''' Configure individual character PictureBox for accessibility and usability
    ''' </summary>
    Private Sub ConfigureCharacterPictureBox(pictureBox As PictureBox, accessibleName As String)
        pictureBox.Cursor = Cursors.Hand
        pictureBox.AccessibleName = accessibleName
        pictureBox.TabStop = True
    End Sub

#End Region

#Region "Character Click Handlers"

    ' Missionary click handlers
    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click
        HandleMissionaryClick(0)
    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        HandleMissionaryClick(1)
    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click
        HandleMissionaryClick(2)
    End Sub

    ' Cannibal click handlers
    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click
        HandleCannibalClick(0)
    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click
        HandleCannibalClick(1)
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        HandleCannibalClick(2)
    End Sub

    ' Boat click handler
    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
        ExecuteBoatCrossing()
    End Sub

#End Region

#Region "Button Event Handlers"

    ''' <summary>
    ''' Handle Reset button click
    ''' </summary>
    Private Sub btnReset_Click(sender As Object, e As EventArgs)
        Dim result = MessageBox.Show(
            "Are you sure you want to reset the game?",
      "Confirm Reset",
            MessageBoxButtons.YesNo,
     MessageBoxIcon.Question
   )

        If result = DialogResult.Yes Then
            ResetGame()
            UpdateStatusMessage("Game reset - Let's try again!", Color.Yellow)
        End If
    End Sub

    ''' <summary>
    ''' Handle Help button click
    ''' </summary>
    Private Sub btnHelp_Click(sender As Object, e As EventArgs)
        Dim helpMessage As String =
            "🎯 OBJECTIVE" & Environment.NewLine &
  "Transport all 3 missionaries and 3 cannibals across the river." & Environment.NewLine & Environment.NewLine &
   "📜 RULES" & Environment.NewLine &
        "1. The boat can carry maximum 2 people per trip" & Environment.NewLine &
            "2. At least 1 person must be in the boat to sail" & Environment.NewLine &
            "3. Cannibals must NEVER outnumber missionaries on either shore" & Environment.NewLine &
   "   (unless there are no missionaries on that shore)" & Environment.NewLine & Environment.NewLine &
          "🎮 HOW TO PLAY" & Environment.NewLine &
       "• Click on missionaries or cannibals to board them" & Environment.NewLine &
         "• Click the boat to sail across the river" & Environment.NewLine &
            "• Plan your moves carefully to avoid losing!" & Environment.NewLine & Environment.NewLine &
            "💡 TIP" & Environment.NewLine &
       "Think ahead! The puzzle requires strategic planning."

        MessageBox.Show(helpMessage, "Game Instructions", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Game Logic - Character Boarding"

    ''' <summary>
    ''' Handle missionary attempting to board or leave the boat
    ''' </summary>
    Private Sub HandleMissionaryClick(missionaryIndex As Integer)
        Dim totalOnBoat As Integer = _missionariesOnBoat + _cannibalsOnBoat

        ' Check if this missionary is currently on the same side as the boat
        If _isBoatOnLeft Then
            If missionaryIndex < _missionariesLeft Then
                If CanBoardBoat(totalOnBoat) Then
                    _missionariesOnBoat += 1
                    ShowBoardingMessage("Missionary", totalOnBoat + 1)
                    UpdateGameDisplay()
                    UpdateStatusMessage($"Missionary boarded | On boat: {_missionariesOnBoat}M + {_cannibalsOnBoat}C", Color.Cyan)
                End If
            End If
        Else
            If missionaryIndex < _missionariesRight Then
                If CanBoardBoat(totalOnBoat) Then
                    _missionariesOnBoat += 1
                    ShowBoardingMessage("Missionary", totalOnBoat + 1)
                    UpdateGameDisplay()
                    UpdateStatusMessage($"Missionary boarded | On boat: {_missionariesOnBoat}M + {_cannibalsOnBoat}C", Color.Cyan)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Handle cannibal attempting to board or leave the boat
    ''' </summary>
    Private Sub HandleCannibalClick(cannibalIndex As Integer)
        Dim totalOnBoat As Integer = _missionariesOnBoat + _cannibalsOnBoat

        ' Check if this cannibal is currently on the same side as the boat
        If _isBoatOnLeft Then
            If cannibalIndex < _cannibalsLeft Then
                If CanBoardBoat(totalOnBoat) Then
                    _cannibalsOnBoat += 1
                    ShowBoardingMessage("Cannibal", totalOnBoat + 1)
                    UpdateGameDisplay()
                    UpdateStatusMessage($"Cannibal boarded | On boat: {_missionariesOnBoat}M + {_cannibalsOnBoat}C", Color.Orange)
                End If
            End If
        Else
            If cannibalIndex < _cannibalsRight Then
                If CanBoardBoat(totalOnBoat) Then
                    _cannibalsOnBoat += 1
                    ShowBoardingMessage("Cannibal", totalOnBoat + 1)
                    UpdateGameDisplay()
                    UpdateStatusMessage($"Cannibal boarded | On boat: {_missionariesOnBoat}M + {_cannibalsOnBoat}C", Color.Orange)
                End If
            End If
        End If
    End Sub

    ''' <summary>
    ''' Validate if a character can board the boat
    ''' </summary>
    Private Function CanBoardBoat(currentOccupants As Integer) As Boolean
        If currentOccupants >= BOAT_CAPACITY Then
            MessageBox.Show(
      $"The boat is at full capacity ({BOAT_CAPACITY} passengers).{Environment.NewLine}" &
      "Click the boat to sail across, or click passengers to remove them.",
                "Boat Full",
    MessageBoxButtons.OK,
      MessageBoxIcon.Information
            )
            UpdateStatusMessage("Boat is full! Click boat to sail or remove passengers", Color.Red)
            Return False
        End If
        Return True
    End Function

    ''' <summary>
    ''' Display boarding confirmation message
    ''' </summary>
    Private Sub ShowBoardingMessage(characterType As String, currentOccupants As Integer)
        ' Removed the MessageBox to make gameplay smoother - status bar now shows info
        ' MessageBox.Show(message, "Boarding Confirmed", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

#End Region

#Region "Game Logic - Boat Movement"

    ''' <summary>
    ''' Execute the boat crossing with validation
    ''' </summary>
    Private Sub ExecuteBoatCrossing()
        Dim totalPassengers As Integer = _missionariesOnBoat + _cannibalsOnBoat

        ' Validation: boat needs at least one passenger
        If totalPassengers = 0 Then
            MessageBox.Show(
     "The boat requires at least 1 passenger to sail." & Environment.NewLine &
 "Click on missionaries or cannibals to board them.",
                "Empty Boat",
    MessageBoxButtons.OK,
    MessageBoxIcon.Warning
     )
            UpdateStatusMessage("Empty boat! Add at least 1 passenger to sail", Color.Yellow)
            Return
        End If

        ' Transfer passengers
        TransferPassengers()

        ' Toggle boat side
        _isBoatOnLeft = Not _isBoatOnLeft

        ' Clear boat
        _missionariesOnBoat = 0
        _cannibalsOnBoat = 0

        ' Increment move counter
        _moveCount += 1

        ' Update display and check game state
        UpdateGameDisplay()
        UpdateStatusMessage($"Move #{_moveCount} | Boat sailed to {If(_isBoatOnLeft, "LEFT", "RIGHT")} shore", Color.LightGreen)
        EvaluateGameState()
    End Sub

    ''' <summary>
    ''' Transfer passengers from boat to shore
    ''' </summary>
    Private Sub TransferPassengers()
        If _isBoatOnLeft Then
            ' Moving from left to right
            _missionariesLeft -= _missionariesOnBoat
            _cannibalsLeft -= _cannibalsOnBoat
            _missionariesRight += _missionariesOnBoat
            _cannibalsRight += _cannibalsOnBoat
        Else
            ' Moving from right to left
            _missionariesRight -= _missionariesOnBoat
            _cannibalsRight -= _cannibalsOnBoat
            _missionariesLeft += _missionariesOnBoat
            _cannibalsLeft += _cannibalsOnBoat
        End If
    End Sub

#End Region

#Region "Display Updates"

    ''' <summary>
    ''' Update all visual elements to reflect current game state
    ''' </summary>
    Private Sub UpdateGameDisplay()
        UpdateMissionaryPositions()
        UpdateCannibalPositions()
        UpdateBoatPosition()
        BringCharactersToFront()
    End Sub

    ''' <summary>
    ''' Update missionary PictureBox positions and visibility
    ''' </summary>
    Private Sub UpdateMissionaryPositions()
        ' Missionaries on left shore
        UpdateCharacterPosition(PictureBox3, 0, _missionariesLeft, MissionaryLeftPositions)
        UpdateCharacterPosition(PictureBox1, 1, _missionariesLeft, MissionaryLeftPositions)
        UpdateCharacterPosition(PictureBox2, 2, _missionariesLeft, MissionaryLeftPositions)

        ' Missionaries on right shore (reuse same PictureBoxes)
        If _missionariesLeft < 1 And _missionariesRight >= 1 Then
            PictureBox3.Location = MissionaryRightPositions(0)
            PictureBox3.Visible = True
        End If

        If _missionariesLeft < 2 And _missionariesRight >= 2 Then
            PictureBox1.Location = MissionaryRightPositions(1)
            PictureBox1.Visible = True
        End If

        If _missionariesLeft < 3 And _missionariesRight >= 3 Then
            PictureBox2.Location = MissionaryRightPositions(2)
            PictureBox2.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Update cannibal PictureBox positions and visibility
    ''' </summary>
    Private Sub UpdateCannibalPositions()
        ' Cannibals on left shore
        UpdateCharacterPosition(PictureBox6, 0, _cannibalsLeft, CannibalLeftPositions)
        UpdateCharacterPosition(PictureBox5, 1, _cannibalsLeft, CannibalLeftPositions)
        UpdateCharacterPosition(PictureBox7, 2, _cannibalsLeft, CannibalLeftPositions)

        ' Cannibals on right shore (reuse same PictureBoxes)
        If _cannibalsLeft < 1 And _cannibalsRight >= 1 Then
            PictureBox6.Location = CannibalRightPositions(0)
            PictureBox6.Visible = True
        End If

        If _cannibalsLeft < 2 And _cannibalsRight >= 2 Then
            PictureBox5.Location = CannibalRightPositions(1)
            PictureBox5.Visible = True
        End If

        If _cannibalsLeft < 3 And _cannibalsRight >= 3 Then
            PictureBox7.Location = CannibalRightPositions(2)
            PictureBox7.Visible = True
        End If
    End Sub

    ''' <summary>
    ''' Helper method to update individual character position
    ''' </summary>
    Private Sub UpdateCharacterPosition(pictureBox As PictureBox, index As Integer, count As Integer, positions As Point())
        If index < count Then
            pictureBox.Location = positions(index)
            pictureBox.Visible = True
        Else
            pictureBox.Visible = False
        End If
    End Sub

    ''' <summary>
    ''' Update boat position based on current side
    ''' </summary>
    Private Sub UpdateBoatPosition()
        PictureBox4.Location = If(_isBoatOnLeft, BoatLeftPosition, BoatRightPosition)
    End Sub

    ''' <summary>
    ''' Ensure characters are rendered above the boat
    ''' </summary>
    Private Sub BringCharactersToFront()
        PictureBox1.BringToFront()
        PictureBox2.BringToFront()
        PictureBox3.BringToFront()
        PictureBox5.BringToFront()
        PictureBox6.BringToFront()
        PictureBox7.BringToFront()
    End Sub

    ''' <summary>
    ''' Update the status message label with custom text and color
    ''' </summary>
    Private Sub UpdateStatusMessage(message As String, color As Color)
        lblStatus.Text = message
        lblStatus.ForeColor = color
        lblStatus.Refresh()
    End Sub

#End Region

#Region "Game State Evaluation"

    ''' <summary>
    ''' Check win/loss conditions and respond accordingly
    ''' </summary>
    Private Sub EvaluateGameState()
        ' Check for loss conditions on each shore
        If IsInvalidState(_missionariesLeft, _cannibalsLeft, "left") Then
            HandleGameLoss("left")
            Return
        End If

        If IsInvalidState(_missionariesRight, _cannibalsRight, "right") Then
            HandleGameLoss("right")
            Return
        End If

        ' Check for win condition
        If _missionariesRight = MAX_PEOPLE And _cannibalsRight = MAX_PEOPLE Then
            HandleGameWin()
        End If
    End Sub

    ''' <summary>
    ''' Determine if a shore configuration is invalid (cannibals outnumber missionaries)
    ''' </summary>
    Private Function IsInvalidState(missionaries As Integer, cannibals As Integer, shore As String) As Boolean
        ' If there are missionaries present, they must not be outnumbered
        Return missionaries > 0 AndAlso cannibals > missionaries
    End Function

    ''' <summary>
    ''' Handle game loss scenario
    ''' </summary>
    Private Sub HandleGameLoss(shore As String)
        Dim elapsedTime As TimeSpan = DateTime.Now - _gameStartTime
        Dim message As String = $"Game Over!{Environment.NewLine}{Environment.NewLine}" &
            $"The cannibals outnumbered the missionaries on the {shore} shore.{Environment.NewLine}" &
      $"The missionaries have been eaten.{Environment.NewLine}{Environment.NewLine}" &
$"Moves made: {_moveCount}{Environment.NewLine}" &
   $"Time elapsed: {elapsedTime:mm\:ss}{Environment.NewLine}{Environment.NewLine}" &
            "The game will now reset. Try again!"

        MessageBox.Show(message, "Puzzle Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        ResetGame()
    End Sub

    ''' <summary>
    ''' Handle game win scenario
    ''' </summary>
    Private Sub HandleGameWin()
        Dim elapsedTime As TimeSpan = DateTime.Now - _gameStartTime
        Dim message As String = $"🎉 Congratulations! 🎉{Environment.NewLine}{Environment.NewLine}" &
            $"You successfully transported everyone across the river!{Environment.NewLine}{Environment.NewLine}" &
         $"📊 Final Statistics:{Environment.NewLine}" &
            $"   • Total moves: {_moveCount}{Environment.NewLine}" &
      $"   • Time taken: {elapsedTime:mm\:ss}{Environment.NewLine}{Environment.NewLine}" &
            "The game will now reset so you can try to beat your score!"

        MessageBox.Show(message, "Puzzle Solved!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ResetGame()
    End Sub

#End Region

#Region "Game Control"

    ''' <summary>
    ''' Reset the game to initial state
    ''' </summary>
    Private Sub ResetGame()
        ' Reset character counts
        _missionariesLeft = MAX_PEOPLE
        _cannibalsLeft = MAX_PEOPLE
        _missionariesRight = 0
        _cannibalsRight = 0

        ' Reset boat state
        _isBoatOnLeft = True
        _missionariesOnBoat = 0
        _cannibalsOnBoat = 0

        ' Reset statistics
        _moveCount = 0
        _gameStartTime = DateTime.Now

        ' Update display
        UpdateGameDisplay()
        UpdateStatusMessage($"Game Ready | Left: {_missionariesLeft}M + {_cannibalsLeft}C | Right: {_missionariesRight}M + {_cannibalsRight}C | Moves: {_moveCount}", Color.Lime)
    End Sub

#End Region

End Class