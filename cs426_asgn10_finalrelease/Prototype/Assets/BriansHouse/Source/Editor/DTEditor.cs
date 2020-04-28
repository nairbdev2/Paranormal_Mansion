using UnityEngine;
using UnityEditor;
using System.Collections;
using GabroMedia;

[CustomEditor(typeof(DoorTrigger))]
public class DTEditor : Editor {

	bool mod;

	public override void OnInspectorGUI () {
		var dt = target as DoorTrigger;

		if (dt.animator == null) {
			dt.animator = (Animator)EditorGUILayout.ObjectField(dt.animator, typeof(Animator), true);
		}
		else {
			EditorGUILayout.LabelField("This instance is assigned to " + BriansEngine.FindDoorType(dt), EditorStyles.whiteLargeLabel);

			GUILayout.Space(10);
			mod = GUILayout.Toggle(mod, "Modify assignment (advanced)");

			if (mod) {
				dt.animator = (Animator)EditorGUILayout.ObjectField(dt.animator, typeof(Animator), true);
			}
		}
	}
}
