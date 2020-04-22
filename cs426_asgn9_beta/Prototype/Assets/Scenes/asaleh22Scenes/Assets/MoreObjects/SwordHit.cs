using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHit : MonoBehaviour
{

    private GameObject spawn;
    private GameManager GM;
    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        spawn = GameObject.Find("Spawnpoint_1");
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GM.loseLife();
            GM.kill();
            
        }
        /*
        if(other.gameObject.tag == "Ghost")
        {
            Destroy(other.gameObject);
        }
        */
    }
}
