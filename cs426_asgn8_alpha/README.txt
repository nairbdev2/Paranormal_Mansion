/*
 * CS426 Assignment #8 (Alpha)
 * Names: Brian De Villa, Jay Patel, Ali Saleh
 * Group: 1
 * 
 * Paranormal Mansion
 */

Player Interaction Pattern: 
	Single-player Vs. Game
Objective: 
	Rescue, Solution
Procedures:
        'W'        - Move Forward
        'S'        - Move Backwards
        'A'        - Strafe Left
        'D'        - Strafe Right
        'Esc'      - Start / Pause Game
        'E'        - Interact with object
        'R'        - Turn On / Off Flashlight
        'I' 	   - Show Inventory
	'Spacebar' - Dash / Sprint
        Mouse      - Look Around
Resources: 
	Lives, Flashlight, Paranormal Detector
Conflict: 
	Obstacles (Puzzles), Opponents (Non-Players: Ghost)
Boundary: 
	Mansion Interior Walls
Outcome: 
	Binary Decisions

Rules:
    Unable to Leave the Mansion without trying to save their friend
    Avoid Ghost or Creatures roaming the Mansion
    Avoid Traps placed around the mansion
    Unable to access new area unless they correctly solve the puzzle
    Player is unable to move through walls
    Player is able to climb certain surfaces of walls
    Player is able to stun or neutralize a ghost with the flashlight
    Ghost will always alert the Paranormal Detector



Summary Assignment #8:
	Created the map level similar to the map design. Added Win Scene. Added Gameover Scene. Added Lives System.
	Added Inventory System. Added Sounds. Main Menu Scene. Added new puzzle to unlock a door.
	
	UI:
		Current Player Lives (Top right corner)
		Inventory System (Bottom left Corner)

	Sounds:
		Ghost wailing repeatedly
		Flashlight clicking on or off
		Door unlocking sound
		Main Menu Ambient Sound
		Main Menu Play/Quit Sound
		Cat Meowing after losing a life
		Win Scene Ambient Sound
		Game Over Scene Ambient Sound
		Dueling Swords Sound
	
	The components above come together with respect to gameplay and the theme because the Tom the cat is in a haunted mansion.
	Inside the haunted mansion Tom sees ghosts, spiders, traps, floating lanterns, a curtain, and many more unusual things.

	What worked and didn't work:
		The GUI is not scaling properly to the resolution and the best solution is to play the game at a very low resolution.
		


	

