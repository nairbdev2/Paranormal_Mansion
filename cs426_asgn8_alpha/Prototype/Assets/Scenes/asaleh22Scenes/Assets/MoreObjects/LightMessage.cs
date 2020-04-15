using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMessage : MonoBehaviour
{
    private GameObject user_flashlight;

    
    private void Update()
    {
        if(user_flashlight != null && !user_flashlight.activeInHierarchy)
        {
            adjustedExit();

        }
    }


    private void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "Light")
        {
            if(other.GetComponent<AudioSource>() != null)
            {
                Debug.Log("Player");
                user_flashlight = other.gameObject.transform.GetChild(0).gameObject;
                Debug.Log(user_flashlight.name);
            }

            GetComponent<MeshRenderer>().enabled = true;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Light")
        {
            GetComponent<MeshRenderer>().enabled = false;
        }
    }



    void adjustedExit()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}

