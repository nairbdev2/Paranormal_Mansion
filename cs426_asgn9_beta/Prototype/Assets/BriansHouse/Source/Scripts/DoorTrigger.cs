using UnityEngine;
using System.Collections;
using GabroMedia;

public class DoorTrigger : MonoBehaviour {

	//Class held by all door trigger zones in scene. Handles animator state that's assigned manually in the inspector.
	//Modify coroutine float to change door close delay time!

	const string ANIM_BOOL = "openDoor";
	public Animator animator;

	BriansHouse bh;

	void Start() {
		bh = FindObjectOfType<BriansHouse>();
	}

	void OnTriggerEnter(Collider other) {
		StopAllCoroutines();
		PlayAudio(other, bh.doorOpen);
		ToggleAnimatorState(other, true);
	}

	void OnTriggerExit(Collider other) {
		ToggleAnimatorState(other, false);
	}

	void ToggleAnimatorState(Collider c, bool boolean) {
		if (BriansEngine.IsItPlayer(c) && BriansEngine.IsItUnlocked(this)) {
			if (!boolean) 	StartCoroutine(DelayedDoorClose(10.0f));
			else 			animator.SetBool(ANIM_BOOL, boolean);
		}
	}

	void PlayAudio(Collider c, AudioClip[] ac) {
		if (BriansEngine.IsItPlayer(c) && BriansEngine.IsItUnlocked(this)) {
			if (!animator.name.Contains("Garage")) {
				int randIndex = Random.Range(0, ac.Length);
				AudioSource.PlayClipAtPoint(ac[randIndex], this.transform.position);
			}
			else {
				AudioSource.PlayClipAtPoint(bh.garageDoorSound, this.transform.position);
			}
		}
	}

	IEnumerator DelayedDoorClose(float secs) {
		yield return new WaitForSeconds(secs);
		animator.SetBool(ANIM_BOOL, false);
		if (animator.name.Contains("Garage")) {
			AudioSource.PlayClipAtPoint(bh.garageDoorSound, this.transform.position);
		}
	}
}
