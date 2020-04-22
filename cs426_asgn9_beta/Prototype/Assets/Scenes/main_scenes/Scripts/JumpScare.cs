using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpScare : MonoBehaviour
{

    public AudioSource scream_sfx;
    public GameObject flashImg;
    public GameObject thisObject;

    void OnTriggerEnter()
    {
        scream_sfx.Play();
        flashImg.SetActive(true);
        StartCoroutine(EndJump());
    }

    IEnumerator EndJump()
    {
        yield return new WaitForSeconds(4.05f);
        flashImg.SetActive(false);
        thisObject.SetActive(false);
    }




}
