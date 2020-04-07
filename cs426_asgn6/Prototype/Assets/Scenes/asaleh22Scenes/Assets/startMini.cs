using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class startMini : MonoBehaviour
{
    public GameObject interactableText;
    private void OnTriggerEnter(Collider other)
    {
        interactableText.SetActive(true);
    }
    private void OnTriggerExit(Collider other)
    {
        interactableText.SetActive(false);
    }
}
