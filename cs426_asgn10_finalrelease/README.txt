/*
 * CS426 Assignment #10 (Final Release)
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
	Lives, Flashlight
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

Summary Assignment #10:
	Polished the Final Puzzle's look and feel. Added Occlusion Culling in an attempt to increase framerate.
	Added the Caged Room puzzle. Added Hint onto Mirror. Hid mouse cursor in game.
	

	

