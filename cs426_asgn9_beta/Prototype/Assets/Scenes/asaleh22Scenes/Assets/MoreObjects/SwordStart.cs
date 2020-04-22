using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordStart : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("SwordStart");
        GetComponent<Animation>().Play("SwordAnim");
    }
}
