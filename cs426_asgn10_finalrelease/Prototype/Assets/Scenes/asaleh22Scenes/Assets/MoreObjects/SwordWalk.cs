using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWalk : MonoBehaviour
{

    public GameObject player;
    public GameObject sword;
    float walkPosition;
    // Update is called once per frame
    private void Update()
    {
        walkPosition = player.transform.position.z;
        if (Input.GetButtonDown("Fire1"))
        {
            this.GetComponent<Animation>().Play("Swing");
        }
    }

    void LateUpdate()
    {
        
        if(player.transform.position.z != walkPosition)
        {
            sword.GetComponent<Animation>().Play("SwordWalk");

        }
        else
        {
            sword.GetComponent<Animation>().Stop("SwordWalk");
        }
    }
}
