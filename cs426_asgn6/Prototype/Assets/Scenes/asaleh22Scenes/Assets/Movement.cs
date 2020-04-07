using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update(){

        if (Input.GetKeyDown(KeyCode.W))
        {
            this.gameObject.transform.position += Vector3.forward;
            Debug.Log(Vector3.forward);
        }


    }
}
