using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveArrow : MonoBehaviour
{


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Debug.Log("hit payer");
            GetComponentInChildren<Transform>().gameObject.SetActive(false);

        }
    }
}
