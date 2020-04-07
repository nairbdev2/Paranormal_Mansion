using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnpoint;

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Player Loses a Life! - (Trap Script)");
            player.transform.position = spawnpoint.transform.position;
        }

    }
}
