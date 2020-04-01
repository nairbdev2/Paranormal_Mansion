using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBullet : MonoBehaviour
{
    public float speed = 3f;

    void Update()
    {
        this.transform.position += new Vector3(0, speed * Time.deltaTime,0 );    
    }
}
