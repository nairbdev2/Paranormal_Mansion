using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFight : MonoBehaviour
{
    private GameObject duels;

    private void Start()
    {
        duels = GameObject.Find("DuelingGhosts");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            duels.GetComponent<AudioSource>().Play();
        }
    }
}
