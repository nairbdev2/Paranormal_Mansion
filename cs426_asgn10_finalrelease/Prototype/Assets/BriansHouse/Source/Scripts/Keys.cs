using UnityEngine;
using System.Collections;
using GabroMedia;

[RequireComponent(typeof(Collider))]
public class Keys : MonoBehaviour {

	//Drag this class to your key, and choose which key you want it to open. (Also drag the key object to its respective slot to Brianshouse)

	public BriansEngine.Doors doorKeyType;

	void Start() {
		if (!GetComponent<Collider>().isTrigger) {
			Debug.Log("Pickupable item should have trigger collider!");
		}
	}

	void OnTriggerEnter(Collider other) {
		if (BriansEngine.IsItPlayer(other)) {
			for (int i = 0; i < BriansEngine.openable.Count; i++) {
				if (this.gameObject.Equals(BriansEngine.openable[i].doorKey) && doorKeyType.Equals(BriansEngine.openable[i].doorType)) {
					BriansEngine.openable[i].doorState = false;
					Debug.Log(BriansEngine.openable[i].doorType + " unlocked: " + !BriansEngine.openable[i].doorState);
					Destroy(this.gameObject);
				}
			}
		}
	}

}
