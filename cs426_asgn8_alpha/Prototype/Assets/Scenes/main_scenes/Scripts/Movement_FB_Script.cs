/*
 * className:           Movement_FB_Script
 * desc:                Having the GameObject move through a select path
 * Additonal Notes:     Main Parent Object must have Rigidbody (GRAVITY OFF), Y Coordinates of all Targets should be the same as parent otherwise it will not move.
 */
 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Movement_FB_Script : MonoBehaviour
{

    public Transform[] targets;
    public float speed;

    private int curr;
    private bool directionSwitch;

    void Start()
    {
        //transform.LookAt(targets[curr].transform);
        //transform.LookAt(new Vector3(targets[curr].position.x, transform.position.y, targets[curr].position.z));
        directionSwitch = false;
    }


    // Update is called once per frame
    void Update()
    {
        //Check if Transform is the same as one of the Targets on the map. 
        //if ((transform.position.x != targets[curr].position.x) && (transform.position.z != targets[curr].position.z))
        if (transform.position != targets[curr].position)
        {
            //Rotates to Target's Position
            transform.LookAt(new Vector3(targets[curr].position.x, transform.position.y, targets[curr].position.z));
            Vector3 pos = Vector3.MoveTowards(transform.position, targets[curr].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else
        {
            if (curr == targets.Length - 1)
            {
                directionSwitch = true;
            } else if (curr == 0) 
            {
                directionSwitch = false;
            }

            //Switch Directions
            if (directionSwitch == false)
            {
                if (curr < targets.Length)
                {
                    curr++;
                }
            } else if (directionSwitch == true)
            {
                if (curr > 0)
                {
                    curr--;
                }
            } else
            {
                Debug.Log("Error: DirectionSwitch failed to switch. Therefore, curr cannot proceed to next in data structure.");
            }

            //curr = (curr + 1) % targets.Length;
        }


    }
}
