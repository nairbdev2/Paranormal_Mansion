using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CeilingCrash : MonoBehaviour
{
    AudioSource pAudio;
    bool first = false;
    private void Start()
    {
        
        pAudio = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if(first == true)
        {
            if(pAudio.isPlaying == false)
            {
                pAudio.enabled = false;
                this.gameObject.GetComponent<CeilingCrash>().enabled = false;
            }
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            pAudio.Play();
            first = true;
            Debug.Log("FLOOR");
        }
    }
}
