using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(Interactions))]
public class InteractEditor : Editor {

	public override void OnInspectorGUI() {
		if (Camera.main == null) {
			EditorGUILayout.HelpBox("No main camera tag found in scene", MessageType.Error);
		}
		else {
			EditorGUILayout.LabelField("This class finds main camera and casts ray", EditorStyles.whiteLabel);
			GUILayout.Space(5);
			base.DrawDefaultInspector();
			var t = target as Interactions;
			if (t.throwForce > 7) {
				EditorGUILayout.HelpBox("High throw force might cause objects to fall through walls/floor", MessageType.Info);
			}
		}

	}
}
