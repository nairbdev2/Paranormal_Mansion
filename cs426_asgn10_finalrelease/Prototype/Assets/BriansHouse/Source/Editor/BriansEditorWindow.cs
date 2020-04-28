using UnityEngine;
using UnityEditor;
using System.Collections;

public class BriansEditorWindow : EditorWindow {

	[MenuItem("Window/Brians House/Remove all game mechanics")]
	public static void removeAllMechanics() {
		if (EditorUtility.DisplayDialog("Removing all game mechanics", "Are you sure you want to remove all game mechanics (scripting, audio, animators) from Brians' house and build it by yourself? This can NOT be undone!",
		                            "Delete all", "No, keep them for now")) {
			Debug.Log("Initiating delete");
			BriansHouse bh = FindObjectOfType<BriansHouse>();
				
			Interactions i = FindObjectOfType<Interactions>();
			DoorTrigger[] dt = FindObjectsOfType<DoorTrigger>();
			Keys[] ks = FindObjectsOfType<Keys>();

			//pickupable cleanup
			foreach ( Rigidbody rb in FindObjectsOfType<Rigidbody>() ) {
				if (rb.GetComponent<Pickupable>())	DestroyImmediate(rb.GetComponent<Pickupable>());
				if (rb.GetComponent<Destructible>()) DestroyImmediate(rb.GetComponent<Destructible>());
			}

			//Livingroomaudiopass cleanup
			/*GameObject music = GameObject.Find("Music");
			if (music == null) {
				Debug.Log("Ignoring music, can't be found");
			}
			else {
				DestroyImmediate(music);
				Debug.Log("Music zone removed!");
			}*/

			//interactions delete
			if (i == null) {
				Debug.Log("Ignoring interactions class, can't be found");
			}
			else {
				DestroyImmediate(i.gameObject);
				Debug.Log("Interactions removed");
			}

			//Doortrigger removal
			foreach ( DoorTrigger dts in dt ) {
				DestroyImmediate(dts.gameObject);
			}
			Debug.Log("Doortrigger zones removed");

			//Keys removal

			foreach ( Keys key in ks ) {
				DestroyImmediate(key.gameObject);
			}
			Debug.Log("Keys removed");

			//Resetting point lights
			Light[] lights = bh.GetComponentsInChildren<Light>();
			foreach ( Light light in lights ) {
				light.shadows = LightShadows.None;
				light.color = Color.white;
				light.intensity = 0.8f;
			}

			foreach ( Lightswitch ls in FindObjectsOfType<Lightswitch>() ) {
				DestroyImmediate(ls);
			}

			DestroyImmediate(bh);

			if (EditorUtility.DisplayDialog("Operation complete", "All game mechanics have been removed from the asset in your scene. Note: The prefab in the project folder is not affected, it still has everything in case you need them!", "Ok")) {
				return;
			}
			Debug.Log("cleanup complete!");

		}
	}

}
