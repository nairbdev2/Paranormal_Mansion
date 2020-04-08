using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
[AddComponentMenu("Brians House/Destructible object")]
public class Destructible : MonoBehaviour {
	
	public GameObject fracturedPrefab;
	public float removeShards = 30;
	public AudioClip[] breakSound;
	
	Rigidbody rb;
	Vector3 dir;

	void Start() {
		rb = GetComponent<Rigidbody>();
	}

	void OnCollisionEnter(Collision c) {
		if (c.relativeVelocity.magnitude > 5.5) {
			dir = c.relativeVelocity;
			Fracture();
		}
	}


	void Fracture () {
		Vector3 pos = rb.transform.position;
		Quaternion rot = rb.transform.rotation;

		rb.GetComponent<Pickupable>().enabled = false;
		rb.GetComponent<Collider>().enabled = false;
		Destroy(rb.GetComponent<MeshFilter>());

		GameObject go = (GameObject) Instantiate ( fracturedPrefab, pos, rot);

		AudioSource.PlayClipAtPoint(breakSound[Random.Range(0, breakSound.Length)],rb.transform.position);
		Rigidbody[] rbs = go.GetComponentsInChildren<Rigidbody>();

		foreach ( Rigidbody r in rbs ) {
			r.AddForceAtPosition(-dir, rb.transform.position, ForceMode.Impulse);
			Destroy(r, 3);
			Destroy(r.GetComponent<MeshCollider>(), 3);
		}
		Destroy(go, removeShards);
		Destroy(rb.gameObject);

	}
}
