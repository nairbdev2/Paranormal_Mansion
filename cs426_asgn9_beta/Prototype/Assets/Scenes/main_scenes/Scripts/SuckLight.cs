using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SuckLight : MonoBehaviour
{
    // Start is called before the first frame update

    //Attached to the light withint the ball
    bool lightSuck = false;
    Texture EMPTY;
    private void Start()
    {
        EMPTY = GameObject.Find("LightBallEmpty").GetComponent<RawImage>().texture;
        
    }

    private void Update()
    {
        if (lightSuck)
        {

            GetComponent<Light>().intensity -= .02f;
        }
        if(GetComponent<Light>().intensity == 0f)
        {
            GetComponentInParent<RawImage>().texture = EMPTY;
            GetComponent<Collider>().enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Ghost")
        {
            lightSuck = true;
            GetComponentInParent<Collider>().isTrigger =true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
   
        if (other.tag == "Ghost")
        {
            lightSuck = false;
        }
    }
}
