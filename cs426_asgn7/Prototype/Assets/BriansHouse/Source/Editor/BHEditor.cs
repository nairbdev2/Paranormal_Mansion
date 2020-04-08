using UnityEngine;
using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using GabroMedia;

[CustomEditor(typeof(BriansHouse))]
public class BHEditor : Editor {
	
	Light[] lights;
	bool showRawInspector;

	public override void OnInspectorGUI() {
				
		if (Application.isPlaying) {
			EditorGUILayout.LabelField("Exit play mode to modify settings");
		}
		
		else {

			showRawInspector = GUILayout.Toggle(showRawInspector, "Access raw inspector");

			if (!showRawInspector) {			
				CheckEditorConfiguration();
				LockDoorOptions();
				
				EditorGUILayout.Separator();

				var bh = target as BriansHouse;

				GUILayout.Space(4);


				ListPointLights();
				WarnLightMapMode();
				LookForNonStatics();
				
				EditorGUILayout.Space();


				if (bh.GetComponentsInChildren<Rigidbody>() != null) {
					CheckRigidbodies();
				}
											
			}
			else {
				DrawDefaultInspector();
			}
		}
	}

	/*void AudioOptions() {
		var bh = target as BriansHouse;
		bh.enableAudio = GUILayout.Toggle(bh.enableAudio, "Show door audio clips");
		
		if (bh.enableAudio)			{
			DrawDefaultInspector();
		}

	}*/

	void CheckRigidbodies () {
		List<Pickupable> rbs = new List<Pickupable>();
		var bh = target as BriansHouse;
		foreach ( Pickupable p in bh.GetComponentsInChildren<Pickupable>()) {
			if (!p.GetComponent<Rigidbody>()) {
				rbs.Add (p);
			}
		}
		if (rbs.Count > 0) {
			EditorGUILayout.BeginHorizontal ();
			EditorGUILayout.LabelField ("pickupable found that's not a rigidbody!");
			GUI.backgroundColor = Color.green;
			if (GUILayout.Button("Fix")) {
				foreach (Pickupable ps in rbs) {
					ps.gameObject.AddComponent<Rigidbody>();
				}
			}
			EditorGUILayout.EndHorizontal();
		}
		List<GameObject> gos = new List<GameObject>();
		foreach ( MeshFilter mf in FindObjectsOfType<MeshFilter>()) {
			if (mf.gameObject.GetComponent<Rigidbody>()) {
				if (mf.gameObject.isStatic) {
					gos.Add(mf.gameObject);
				}
			}
		}
		if (gos.Count > 0) {
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Some rigidbodies are marked as static!");
			Color c = GUI.backgroundColor;
			GUI.backgroundColor = Color.red;
			if (GUILayout.Button("Fix now")) {
				foreach ( GameObject go in gos ) {
					go.isStatic = false;
				}
			}
			GUI.backgroundColor = c;
			EditorGUILayout.EndHorizontal();
		}
	}
	
	/*void OfferAdvancedOptions () {
		advanced = GUILayout.Toggle(advanced, "Advanced options");
		if (advanced) {
			AudioOptions();
			GUI.backgroundColor = Color.red;
			if (GUILayout.Button("Remove all game mechanics")) {
				BriansEditorWindow.removeAllMechanics();
			}
		}
	}*/

	/*void CheckIfPickupableIsAssigned ()	{
		var bh = target as BriansHouse;
		Rigidbody[] rbs = bh.GetComponentsInChildren<Rigidbody>();
		List<GameObject> list = new List<GameObject>();
		foreach ( Rigidbody rb in rbs ) {
			if (!rb.GetComponent<Pickupable>()) {
				list.Add(rb.gameObject);
			}
		}
		if (list.Count > 0) {
			EditorGUILayout.LabelField("Go's are rigidbodies but pickupable not assigned");
			foreach ( GameObject go in list ) {
				EditorGUILayout.BeginHorizontal();
				if (GUILayout.Button(go.name)) {
					Selection.activeGameObject = go;
				}
				GUI.backgroundColor = Color.green;
				if (GUILayout.Button("Fix")) {
					go.gameObject.AddComponent<Pickupable>();
				}
				EditorGUILayout.EndHorizontal();
			}
		}
	}*/
		
	void GetAudioClips () {
		var bh = target as BriansHouse;
		EditorGUILayout.LabelField("Door sound clips", EditorStyles.whiteLargeLabel);
		
		for ( int i = 0; i < bh.doorOpen.Length; i++) {
			bh.doorOpen[i] = (AudioClip)EditorGUILayout.ObjectField(bh.doorOpen[i], typeof(AudioClip), false, GUILayout.Width(150));
		}
		GUILayout.Space(5);
		EditorGUILayout.LabelField("Garage door sound", EditorStyles.whiteLargeLabel);
		bh.garageDoorSound = (AudioClip)EditorGUILayout.ObjectField(bh.garageDoorSound, typeof(AudioClip), false, GUILayout.Width(150));
		EditorUtility.SetDirty(bh);
	}
	
	
	void CheckEditorConfiguration() {
		if (Lightmapping.isRunning) {
			EditorGUILayout.LabelField("Scene baking in progress! Please wait", EditorStyles.helpBox);
		}
		
		if (PlayerSettings.colorSpace != ColorSpace.Linear) {
			EditorGUILayout.LabelField("Please change to Linear Color space for best results", EditorStyles.helpBox);
		}
		
		if (!GameObject.FindGameObjectWithTag(BriansEngine.PLAYER)) {
			EditorGUILayout.LabelField("No player found! Please tag 'Player' in scene!", EditorStyles.largeLabel);
		}
	}
	
	void LockDoorOptions() {
		var bh = target as BriansHouse;
		
		EditorGUILayout.LabelField("Lock marked doors on startup", EditorStyles.whiteLargeLabel);
		
		EditorGUILayout.BeginHorizontal();
		bh.mainDoorLocked = GUILayout.Toggle(bh.mainDoorLocked, "Main Door");
		if (bh.mainDoorLocked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.mainDoorKey = (GameObject)EditorGUILayout.ObjectField(bh.mainDoorKey, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		bh.backDoorLocked = GUILayout.Toggle(bh.backDoorLocked, " Backdoor");
		if (bh.backDoorLocked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.backDoorKey = (GameObject)EditorGUILayout.ObjectField(bh.backDoorKey, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		bh.room1Locked = GUILayout.Toggle(bh.room1Locked, " Room 1");
		if (bh.room1Locked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.room1Key = (GameObject)EditorGUILayout.ObjectField(bh.room1Key, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		bh.room2Locked = GUILayout.Toggle(bh.room2Locked, " Room 2");
		if (bh.room2Locked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.room2Key = (GameObject)EditorGUILayout.ObjectField(bh.room2Key, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		bh.room3Locked = GUILayout.Toggle(bh.room3Locked, " Room 3");
		if (bh.room3Locked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.room3Key = (GameObject)EditorGUILayout.ObjectField(bh.room3Key, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		bh.bathroomLocked = GUILayout.Toggle(bh.bathroomLocked, " Bathroom");
		if (bh.bathroomLocked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.bathroomKey = (GameObject)EditorGUILayout.ObjectField(bh.bathroomKey, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		EditorGUILayout.BeginHorizontal();
		bh.glassDoor1Locked = GUILayout.Toggle(bh.glassDoor1Locked, " Glass doors");
		if (bh.glassDoor1Locked || bh.glassDoor2Locked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.glassDoorKey = (GameObject)EditorGUILayout.ObjectField(bh.glassDoorKey, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();

		EditorGUILayout.BeginHorizontal();
		bh.garagelocked = GUILayout.Toggle(bh.garagelocked, " Garage");
		if (bh.garagelocked) {
			EditorGUILayout.LabelField("Key:", EditorStyles.boldLabel, GUILayout.Width(30));
			bh.garageKey = (GameObject)EditorGUILayout.ObjectField(bh.garageKey, typeof(GameObject), true);
		}
		EditorGUILayout.EndHorizontal();
		
		bh.glassDoor2Locked = bh.glassDoor1Locked;
		EditorUtility.SetDirty(bh);
	}
	
	void ListPointLights() {
		EditorGUILayout.LabelField("Lights in the house", EditorStyles.whiteLargeLabel);
		
		var bh = target as BriansHouse;
		lights = bh.GetComponentsInChildren<Light>();
		
		EditorGUILayout.BeginHorizontal();
		EditorGUILayout.LabelField("Object", EditorStyles.whiteLabel, GUILayout.Width(80));
		EditorGUILayout.LabelField("Shadows", EditorStyles.whiteLabel, GUILayout.Width(60));
		EditorGUILayout.LabelField("Color", EditorStyles.whiteLabel, GUILayout.Width(50));
		EditorGUILayout.LabelField("Intens", EditorStyles.whiteLabel, GUILayout.Width(40));
		
		EditorGUILayout.EndHorizontal();
		if (lights != null) {
			foreach ( Light light in lights) {
				Color c = GUI.backgroundColor;
				EditorGUILayout.BeginHorizontal();
				if (GUILayout.Button(light.transform.parent.name, GUILayout.Width(80))) {
					Selection.activeGameObject = light.transform.parent.gameObject;
				}
				if (light.shadows.Equals (LightShadows.None)) {
					GUI.backgroundColor = Color.green;
				}
				else {
					GUI.backgroundColor = Color.yellow;
				}
				light.shadows = (LightShadows)EditorGUILayout.EnumPopup(light.shadows, GUILayout.Width(60));
				GUI.backgroundColor = c;
				light.color = EditorGUILayout.ColorField(light.color, GUILayout.Width(50));
				light.intensity = EditorGUILayout.FloatField(light.intensity, GUILayout.Width(30));
				light.enabled = EditorGUILayout.Toggle(light.enabled);
				EditorGUILayout.EndHorizontal();
			}
		}
	}
	
	void WarnLightMapMode() {
		if (Lightmapping.giWorkflowMode != Lightmapping.GIWorkflowMode.Iterative) {
			Lightmapping.giWorkflowMode = (Lightmapping.GIWorkflowMode)EditorGUILayout.EnumPopup("Bake mode", Lightmapping.giWorkflowMode);
		}
	}
	
	void LookForNonStatics() {
		int nonStaticCounter = 0;
		var bh = target as BriansHouse;
		MeshFilter[] mfs = bh.GetComponentsInChildren<MeshFilter>();
		
		foreach ( MeshFilter mf in mfs ) {
			if (!mf.name.Contains("Door") && !mf.name.Contains("Fan") && !mf.gameObject.isStatic && !mf.GetComponent<Rigidbody>()) {
				nonStaticCounter++;
			}
		}
		if (nonStaticCounter > 0) {
			EditorGUILayout.LabelField("Doors, fans and rigidbodies are excluded from global batching", EditorStyles.helpBox);
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField(nonStaticCounter + " non-statics found!");
			if (GUILayout.Button("Fix")) {
				foreach ( MeshFilter mf in mfs ) {
					if (!mf.name.Contains("Door") && !mf.name.Contains("Fan") && !mf.gameObject.isStatic && !mf.GetComponent<Rigidbody>()) {
						mf.gameObject.isStatic = true;
					}
				}
			}
			EditorGUILayout.EndHorizontal();
			
			
		}
	}
}
