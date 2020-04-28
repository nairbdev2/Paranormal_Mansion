using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


//Attach this script to any object that is interactable by the user. Doors... items to pick up...
public class Interactable : MonoBehaviour
{
    public GameObject PromptPanel;
    Text Prompt;
    private void Start()
    {
        Prompt = PromptPanel.GetComponentInChildren<Text>(); //this is the actual text
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag != "Player") return;

       // if (this.gameObject.tag == "Light") return;
        if (this.gameObject.tag != "PickUp" && this.gameObject.tag != "Open" && this.gameObject.tag != "Door" && this.gameObject.tag != "Pull" && this.gameObject.tag != "Cut") return;

        if (this.gameObject.tag == "Cut") handleCut();
        else PromptPanel.SetActive(true);
        
        FindObjectOfType<ThirdPersonCharacterControl>().other = this.gameObject;
            //sets the "other" gameobject equal to the collided object inside the thirdpersoncharactercontrol script. That way we could interact with it over there. 
        MessageToSend();
    }
    private void OnTriggerExit(Collider other)
    {
        PromptPanel.SetActive(false);
        
    }

    void MessageToSend(){

        if (this.gameObject.tag == "PickUp") { //if the object is something I could pick up. Let user know the name of it. 
            Prompt.text= this.gameObject.name + " [E]";
            
        }
        else if(this.gameObject.tag == "Open"){
            if (this.gameObject.name == "Swords")
            {
                Prompt.text = "Take Swords [E]";
            }
            else
            {
                Prompt.text = "Press [E] to open.";
            }
        }
        else if(this.gameObject.tag == "Door"){
            Prompt.text = "Press [E]";
        }
        else if(this.gameObject.tag == "Pull")
        {
            Prompt.text = "Pull Chain. [E]";
        }
        else if(this.gameObject.tag == "Cut")
        {
            Prompt.text = "Use Sword";
        }

    }

    public void FollowUpMessage()
    {
        if (this.gameObject.tag == "Open")
        {
            Prompt.text = "Empty";
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponent<Interactable>().enabled = true;
        Debug.Log(this.name);
    }


    void handleCut()
    {
        Inventory inventory = GameObject.Find("GameManager").GetComponent<Inventory>();
        if(inventory.Contains("Sword"))
            PromptPanel.SetActive(true);
    }
}
