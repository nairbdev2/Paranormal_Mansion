using UnityEngine;
using System.Collections;

[AddComponentMenu("Brians House/Light switch")]
[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshFilter))]
public class Lightswitch : MonoBehaviour {

	public AudioClip lightOn;
	public AudioClip lightOff;

	public ReflectionProbe probe;
	Light roomLight;
	public GameObject lamp;

	public Material lampsMat;
	public Material lampsEmissionMat;

	public bool itsOn;

	Renderer r;
	Material[] offStateMaterials;
	Material[] onStateMaterials;
	
	void Start () {
		if (lightOn == null || lightOff == null || probe == null || lamp == null || lampsMat == null || lampsEmissionMat == null) {
			Debug.Log("Lightswitch has missing assignments in inspector. Ignoring this lightswitch: " + this.GetInstanceID().ToString());
			Destroy(this);
		}
		roomLight = lamp.GetComponentInChildren<Light>();
		r = lamp.GetComponentInChildren<Renderer>();

		offStateMaterials = new Material[2];
		offStateMaterials[0] = lampsMat;
		offStateMaterials[1] = lampsMat;

		onStateMaterials = new Material[2];
		onStateMaterials[0] = lampsMat;
		onStateMaterials[1] = lampsEmissionMat;

	}

	public void SwitchLight() {
		if (itsOn) {
			AudioSource.PlayClipAtPoint(lightOff, this.transform.position);
			roomLight.enabled = false;
			r.materials = offStateMaterials;
			probe.RenderProbe();
			itsOn = !itsOn;
		}
		else {
			AudioSource.PlayClipAtPoint(lightOn, this.transform.position);
			roomLight.enabled = true;
			r.materials = onStateMaterials;
			probe.RenderProbe();
			itsOn = !itsOn;
		}
	}
}
