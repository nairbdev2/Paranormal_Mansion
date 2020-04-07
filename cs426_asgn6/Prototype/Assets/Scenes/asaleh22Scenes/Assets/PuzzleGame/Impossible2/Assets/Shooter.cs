using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject Bullet;
    public GameObject myCube;
    void Update()
    {
        
        if (Input.GetKey(KeyCode.W))
            Instantiate(Bullet, myCube.transform.position, new Quaternion());
        
    }
}
