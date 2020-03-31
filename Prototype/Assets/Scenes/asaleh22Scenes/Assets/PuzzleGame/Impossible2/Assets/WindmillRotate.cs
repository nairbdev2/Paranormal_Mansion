using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindmillRotate : MonoBehaviour
{
    public float rotater = 0f;
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        rotater -= 2f;
        Quaternion target = Quaternion.Euler(0, 0, rotater);

        // Dampen towards the target rotation
        transform.rotation = Quaternion.Slerp(transform.rotation, target, Time.deltaTime * 5f);
    }


}
