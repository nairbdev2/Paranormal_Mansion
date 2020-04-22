using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GabroMedia;

public class BriansHouse : MonoBehaviour {

	//GABROMEDIA@GMAIL.COM

	//Custom editor BHEditor.cs handles the inspector interface of this class. Most important is it fills BriansEngine's List<>
	//TODO Note: This script's Awake() method has to be called first. If you have a complex scene and get an error, make sure 
	//to check script execution order and give priority to this class. (It has to create the List<> for the doors).

	public bool mainDoorLocked;
	public bool room1Locked;
	public bool room2Locked;
	public bool room3Locked;
	public bool bathroomLocked;
	public bool glassDoor1Locked;
	public bool glassDoor2Locked;
	public bool backDoorLocked;
	public bool garagelocked;

	public AudioClip[] doorOpen;
	public AudioClip[] dropSounds;
	public AudioClip garageDoorSound;
	public int dropSoundNumber;

	public bool enableAudio;
	public bool playMusic;
	public bool showPickupAbleClips;

	AudioLowPassFilter alpf;

	public GameObject mainDoorKey;
	public GameObject room1Key;
	public GameObject room2Key;
	public GameObject room3Key;
	public GameObject bathroomKey;
	public GameObject glassDoorKey;
	public GameObject backDoorKey;
	public GameObject garageKey;

	public BriansEngine.Room1Variant room1Variant;

	void Awake() {
		FillListValues();
	}

	void Start() {
		alpf = FindObjectOfType<AudioLowPassFilter>();
		if (alpf)
			alpf.cutoffFrequency = BriansEngine.CORRIDOR_LOWPASS;
		Debugger();
	}

	void Debugger() {
		if (!FindObjectOfType<Interactions>()) {
			Debug.Log("Interactions class not found in scene. Proceeding without interactions..");
		}
		if (FindObjectsOfType<DoorTrigger>()[0] == null) {
			Debug.Log("No doortrigger found in scene. Proceeding without door opening functionality..");
		}
		for (int i = 0; i < BriansEngine.openable.Count; i++) {
			if (BriansEngine.openable[i].doorState == true) {
				BriansEngine.Doors door = BriansEngine.openable[i].doorType;
				GameObject key = BriansEngine.openable[i].doorKey;
				if (key == null) {
					Debug.Log("<color=yellow>Closed door found but there's no key assigned to open it! Door: " + door.ToString() + "Door will be closed in game..</color>");
				}
				else {
					Keys[] sceneKeys = FindObjectsOfType<Keys>();
					if (sceneKeys != null) {
						foreach ( Keys k in sceneKeys) {
							if (k.gameObject.Equals(BriansEngine.openable[i].doorKey)) {
								Debug.Log("<color=green>Closed door: " + door.ToString() + " Marked door to open: " + key.ToString() + " Assigned key object in scene: " + k.name + "</color>");
							}
						}
					}
				}
			}
		}
	}

	void FillListValues() {
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.Main, mainDoorLocked, mainDoorKey));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.Room1, room1Locked, room1Key));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.Room2, room2Locked, room2Key));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.Room3, room3Locked, room3Key));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.Bathroom, bathroomLocked, bathroomKey));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.GlassDoor1, glassDoor1Locked, glassDoorKey));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.GlassDoor2, glassDoor2Locked, glassDoorKey));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.Back, backDoorLocked, backDoorKey));
		BriansEngine.openable.Add(new DoorStateChecker(BriansEngine.Doors.GarageDoor, garagelocked, garageKey));
	}
}
