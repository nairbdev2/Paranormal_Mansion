using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrioMove : MonoBehaviour
{
    //these three are ALWAYS. Attrached to light... be careful. Based on intensity(more implementations later). 

    public GameObject FlashLight;
    public Transform[] targets;
    public float speed;
    bool directionSwitch;
    int curr;
    private GameObject intruder;
    private GameManager GM;

    private void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        speed = 3f;
        curr = 0; directionSwitch = false;
    }

    private void Update()
    {
        if (intruder != null)
        {
            transform.LookAt(intruder.transform);
            transform.Translate(Vector3.forward * 3f * Time.deltaTime);

            if (intruder.GetComponent<Light>() != null && intruder.GetComponent<Light>().intensity == 0f)
            {
                intruder = null;

                //move back to position A. 
            }
            else if(intruder.GetComponent<Light>() == null && !FlashLight.activeInHierarchy)
            {
                intruder = null;

            }

        }

            FindCatEasy();

       // Vector3.Distance(FlashLight.GetComponent<Light>().transform.position, transform.position);
       // Scan();
        //otherwise, find the nearest light source

    }
    void FindCatEasy(){ //the cat takes a predetermined path

            if (transform.position != targets[curr].position)
            {
                //Rotates to Target's Position
                transform.LookAt(new Vector3(targets[curr].position.x, transform.position.y, targets[curr].position.z));
                Vector3 pos = Vector3.MoveTowards(transform.position, targets[curr].position, speed * Time.deltaTime);
                GetComponent<Rigidbody>().MovePosition(pos);
            }
            else
            {
            ++curr;

            if (curr == targets.Length)
               {
                    curr = 0;
               }
            }

        
    }


    void FindCatHard(){ // this time the ghosts will search based on intensity of light. 
        

    }

    void Scan()
    {
       // Vector3.Distance(light to obj),
       // Vector3.
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "Player")
        {
            GM.loseLife();
            GM.kill();
        }
        if (other.gameObject.tag == "Light")
        {
            intruder = other.gameObject;

        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<Light>() == null)
        {
            intruder = null;
        }
    }
}
