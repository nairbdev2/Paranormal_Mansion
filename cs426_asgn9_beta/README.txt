/*
 * CS426 Assignment #9 (Beta)
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



Summary Assignment #9:
	Made various changes as per the assignment 9 requirements, as well as alpha test feedback. Added 3 shaders, and
	multiple forms of writing by creating an opening scene, controls page, and credits page. Made minor quality of life changes as well.
	
	Shaders:
		Shader added to trios of ghosts to increase their emission, and provide that natural ghost glow
		Shader added to ceiling of the map to give a faint blue tint and some roughness to contrast the floor
		Shader added to cat to give a fur like look instead of a flat cartoon look

	UI:
		Added controls page to main menu
		Added credits page to main menu
		Added opening scene that provides the premise and scenario of the game briefly upon application launch
	
	

	What worked and didn't work:
		Some sound bugs, i.e. pressing the control and credits button, the spooky sound does not play. Lunge feature was broken
		and in the process of being fixed. Fixed box colliders as some testers broke free of the environment. Also made overall lighting and UI
		fixes to make the game more visually appealing. Added another obstacle as well.


	

