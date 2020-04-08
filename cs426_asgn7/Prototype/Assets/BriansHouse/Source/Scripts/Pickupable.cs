using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Pickupable : MonoBehaviour {

	BriansHouse bh;
	bool warmUp;

	void Start() {
		if (GetComponent<Collider>().isTrigger) {
			Debug.Log("This instance won't make sound because it's a trigger collider");
		}
		bh = FindObjectOfType<BriansHouse>();
		if (bh == null) {
			Debug.Log("Brians house class not found for Pickupable class!");
		}
		StartCoroutine(WarmUp());
	}

	void OnCollisionEnter() {
		if (!warmUp) {
			int myIndex = UnityEngine.Random.Range(0, bh.dropSounds.Length -2);
			AudioSource.PlayClipAtPoint(bh.dropSounds[myIndex], transform.position);
		}
	}

	IEnumerator WarmUp() {
		warmUp = true;
		yield return new WaitForSeconds(2f);
		warmUp = false;
	}
}
