Brian's house V1.6

Thank you for purchasing Brian's house asset!

The main prefab in the asset root directory is the demo scene house, game ready and configured.

Use the Prefabs/_Empty houses folder to find the empty versions (They don't have any coding attached, you can build your own interior).

Everything works out of the box - all prefabs have colliders attached and their pivots are
placed correctly so you can conventiently drag and drop them into your house. Note that all interactive models have scripts on them (which can be
pickupable.cs or lightswitch.cs)

The two different house meshes are static, but you are free to furnish them at your ease.

If you choose to use the complete house prefabs, navigate to Window/Brians House/Remove all game mechanics to easily delete any game mechanics that
are created by me.




Lighting 
========
Each light has 2 different prefabs; on and off state. Use them as desired for baked scenes. (If using realtime light switch, always make sure to have
a point light nested to the lamp object.)

Lightswitch: Changes materials, re-bakes reflection probes, and toggles point light realtime. Use the lightswitch prefab and assign the required
components. (light switch sounds, two materials: lamps.mat, lamps.emissive mat to their respective spot, then the lamp object itself (its child is always a point light)
Note that for the lightswitch to work, logically the assigned reflection probe and the point light have to be realtime.

Kids room theme (1.0f1) (House variant 1)
===============
You can change room 1's theme to kids room - check the materials folder for Room1.mat and Room1_kidsvariant.mat.

Scripting
=========
Doors use two different animator controllers. One facing left and one facing right. There's a trigger
zone GameObject added around every door - they have DoorTrigger class on them.
Logic: BriansEngine.cs creates a List<> of all 8 doors, and stores a bool value together with them (whether they are openable or not), along with a key (if you assign it). 
See added key functionality below.
Every door is recognized by an enum Doors - also in BriansEngine.
Trigger zones rely on animator components they got externally in the inspector. Should you have any problems
with it, disable or delete DTEditor.CS from the Editor folder to have full access to DoorTrigger class, and be able to
manually feed an animator component to it.
Hint: If you are using your own method, delete mine, as it's easier to create a new one than merging two different ideas in a particular case.

Door key functionality (1.0f1)
=============================
Simply create your key object with a trigger collider, and drag Keys class onto it. Then from its
popup menu, choose which door it is assigned to. Also, assign that object instance to the main editor on the prefab at its respective
field. (It will check if player picked up the right key for a certain door)
Once picked up by player, the door will be openable.

Pickupability (1.01f)
=====================
Interactions prefab gameobject must be present in scene for it work (preferrably hierarchy root). If you want a gameobject to be pickupable, 
add Pickupable class to it!
 
NOTE: Should you want to start it all over and code it the way you like, navigate to Window/Brians house/Remove game mechanics 
tab. Executing that, you'll only have 3D art left with no mechanics.


The main prefab holds BriansHouse.cs, which fills up BriansEngine's generic List with values at startup. Please be aware that
it has to happen first. If you have a complex scene with other scripts, BriansEngine might throw a UnityException.
In that case, be sure to check script execution order in your project, and give BriansHouse.cs a priority. It initializes
the List<> in its Awake() method.

Editor
======
Everything else is self-explanatory in the custom editor script - it searches for lights in scene and lets you modify
their properties from there. Also warns you if something's missing, or not configured right. - Don't forget to adjust the respective lightswitch (if there's one assigned)


NOTE: Player must be tagged as 'Player' for the scripts to recognize the character. If you want to use a different tag
for any reason, the appropriate constant string is stored in BriansEngine.cs - simply modify that, every other script will act accordingly.


Hope you have as much fun exploring and coding the asset as much I did when creating it!
 

Customers form future updates, and you are now one of them! Always feel free to share suggestions, ideas!

Support e-mail: GABROMEDIA@GMAIL.COM
Twitter news feed: @GabroMedia
Website: www.facebook.com/gabromedia

Stay tuned for updates and new products!
Happy game developing!
GabroMedia


Special thanks to
Nikolett Fischer
Peter Tulipan
