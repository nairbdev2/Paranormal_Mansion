using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSeeker : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnpoint;
    private GameObject intruder;
    private GameObject flashlight;
    private void Start()
    {
        flashlight = GameObject.Find("Flashlight");
    }
    //attached to the GHOSTS
    private void Update()
    {

        if(intruder != null)
        {
            transform.LookAt(intruder.transform);
            transform.Translate(Vector3.forward * 3f * Time.deltaTime);

            if (intruder.GetComponent<Light>().intensity == 0f)
            {
                intruder = null;

                //move back to position A. 
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Loses a Life! - (Trap Script)");
            player.transform.position = spawnpoint.transform.position;
        }
        if(other.gameObject.tag == "Light")
        {
            Debug.Log("Light detected. Attacking. ");

            
            intruder = other.gameObject;

        }

    }
}
