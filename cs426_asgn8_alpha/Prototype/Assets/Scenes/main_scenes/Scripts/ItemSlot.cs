using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    Texture CLEAR;
    private void Start()
    {
        CLEAR = GameObject.Find("CLEAR").GetComponent<RawImage>().texture;
    }
    public void OnDrop(PointerEventData eventData){

        //Remember, the eventData.pointerDrag is not the draggable gameobject(thats the clone) 
        //This is the original slot the item is being dragged from. 
        // 

        if(eventData.pointerDrag != null && eventData.pointerDrag.GetComponent<DragnDrop>().myTexture != CLEAR && eventData.pointerDrag.GetComponent<DragnDrop>().isEmpty == false)
        {


            if (GetComponent<RawImage>().texture == CLEAR)
            {   //if the user is placing an item into an empty slot, then place the item in the slot then clear the original slot the item came from. 
                GetComponent<RawImage>().texture = eventData.pointerDrag.GetComponent<DragnDrop>().myTexture;
                eventData.pointerDrag.GetComponent<RawImage>().texture = CLEAR;
                eventData.pointerDrag.GetComponent<DragnDrop>().success = true;
            }
            else
            { //if the item is being placed in a slot with an item there already, then we switch both items with each other. 
                Texture tmp = GetComponent<RawImage>().texture;
                GetComponent<RawImage>().texture = eventData.pointerDrag.GetComponent<DragnDrop>().myTexture;
                eventData.pointerDrag.GetComponent<RawImage>().texture = tmp;
                eventData.pointerDrag.GetComponent<DragnDrop>().success = true;
            }
        }


    }
}
