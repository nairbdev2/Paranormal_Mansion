using UnityEngine;
using System.Collections;
using GabroMedia;

public class DoorStateChecker {

	//List that stores Door enum values paired to booleans (openable or not). Pairing is done in BriansHouse.cs Awake() method.
	//The gameobject it takes in is the key you will use to unlock the doors. If not assigned, value is null

	public BriansEngine.Doors doorType;
	public bool doorState;
	public GameObject doorKey;

	public DoorStateChecker ( BriansEngine.Doors newDoor, bool newState, GameObject newKey) {
		doorType = newDoor;
		doorState = newState;
		doorKey = newKey;
	}
}
