using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace GabroMedia {
	public static class BriansEngine {

		//Static class that stores all strings and values, holds List<> of doors - finds them and handles openable functionality.

		//GABROMEDIA@GMAIL.COM

		public enum Doors {
			Main,
			Back,
			Room1,
			Room2,
			Room3,
			Bathroom,
			GlassDoor1,
			GlassDoor2,
			GarageDoor
		}

		public enum Room1Variant {
			Regular,
			KidsRoom
		}

		//Player tag defined here
		public const string PLAYER = "Player";

		//Don't modify these strings - the engine looks for meshfilter names NOT gameobjects, therefore can't be changed anyhow. They will always match.
		public const string MAINDOOR = "Door_Main";
		public const string ROOM1 = "Door_Interior";
		public const string BATHROOM = "Door_Interior.001";
		public const string ROOM2 = "Door_Interior.002";
		public const string ROOM3 = "Door_Interior.003";
		public const string GLASSDOOR = "Door_Interior_Glass";
		public const string GLASSDOOR2 = "Door_Interior_Glass2";
		public const string BACKDOOR = "Door_Back.001";
		public const string GARAGEDOOR = "GarageDoor";

		//Low pass filter frequency default configuration. Modify these to get different results
		public const int DEF_LOWPASS = 8000;
		public const int CORRIDOR_LOWPASS = 1000;

		public static List<DoorStateChecker> openable = new List<DoorStateChecker>();

		public static Doors FindDoorType(DoorTrigger doorTrigger) {
			MeshFilter mf = doorTrigger.animator.GetComponent<MeshFilter>();
			if (mf.name.Equals(MAINDOOR))			return Doors.Main;
			else if (mf.name.Equals(ROOM1))			return Doors.Room1;
			else if (mf.name.Equals(ROOM2))			return Doors.Room2;
			else if (mf.name.Equals(ROOM3))			return Doors.Room3;
			else if (mf.name.Equals(BATHROOM))		return Doors.Bathroom;
			else if (mf.name.Equals(BACKDOOR))		return Doors.Back;
			else if (mf.name.Equals(GLASSDOOR))		return Doors.GlassDoor1;
			else if (mf.name.Equals(GLASSDOOR2))	return Doors.GlassDoor2;
			else if (mf.name.Equals(GARAGEDOOR)) 	return Doors.GarageDoor;
			else {
					
			}		throw new UnityException("Unknown return type, mesh filter name provided in BriansEngine doesn't match");
		}

		public static bool IsItUnlocked(DoorTrigger dt) {
			Doors thisDoorIs = BriansEngine.FindDoorType(dt);
			for ( int i = 0; i < BriansEngine.openable.Count; i++) {
				if (thisDoorIs.Equals(BriansEngine.openable[i].doorType)) {
					return !BriansEngine.openable[i].doorState;
				}
			}
			throw new UnityException("Not implemented");
		}

		public static bool IsItPlayer(Collider colliderHittingTrigger) {
			if (colliderHittingTrigger.CompareTag(BriansEngine.PLAYER)) return true;
			else return false;
		}
	}
}

