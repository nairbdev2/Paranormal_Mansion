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



Summary Assignment #7:
	Created a new hallway connecting to the Living Room. Decorate the hallway with traps and ghosts.
	Bedroom has 3 yellow ghosts and 1 spider. There are 3 Floating Lanterns. Each spiked trap has a spotlight.
	Added a feature where the player can sprint / dash. Adjusted the bed collider. Added Red Curtain cloth physics.

	Textures:
		Floor Texture
		Bed Texture
		Rug Texture
		Rug2 Texture		
		Ghost Texture
		TV Texture
		Couch Texture
		Table Texture
		Chair Texture
		Shelf Texture
		Plant Texture
		Wall Texture

	Lighting:
		x3 Floating Lanterns
		x3 Trap Spotlights
		x1 Flashlight Spotlight

	Mecanim and AI:
		White Ghost (AI: Predetermined Path) (Created by Brian De Villa)
		Yellow Ghost (AI: Runs away from Flashlight) (Created by Ali Saleh)
		Spider (AI: Runs towards player) (Created by Jay Patel)
		Tom the Cat (Player Mecanim) (Ali Saleh)
	
	Physics:
		Red Curtain cloth physics
		Door opens after player solves the puzzle
		Added 'Gallop' feature for the player which are able to sprint / dash fairly fast
		Food Bowl

	Sounds:
		Ghost wailing repeatedly
		Flashlight clicking on or off
		Door unlocking sound
	
	The components above come together with respect to gameplay and the theme because the Tom the cat is in a haunted mansion.
	Inside the haunted mansion Tom sees ghosts, spiders, traps, floating lanterns, a curtain, and many more unusual things.

	What worked and didn't work:
		We finally fixed the issue where the player is able to rotate to where the camera is looking.
		We had some issues with the jump feature and instead created a sprint / dash feature.
		The Spider currently can go through walls which is an issue due to spiders are not able to go through walls in real life.
		We were able to add a new feature where the player is able to actiavte / deactivate their flashlight by pressing 'R'
		


	

