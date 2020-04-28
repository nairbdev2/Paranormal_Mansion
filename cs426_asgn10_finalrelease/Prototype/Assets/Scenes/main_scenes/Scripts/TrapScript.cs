using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnpoint;

    private GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GM.loseLife();
            Debug.Log("Player Loses a Life! - (Trap Script)");
            player.transform.position = spawnpoint.transform.position;
        }

    }
}
