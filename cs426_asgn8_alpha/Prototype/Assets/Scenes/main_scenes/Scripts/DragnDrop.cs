using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragnDrop : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private GameObject original;
    private GameManager GM;
    private Canvas canvas;
    private GameObject clone;
    private CanvasGroup CG;
    private Texture CLEAR;
    public Texture myTexture;
    private RectTransform rectTransform;
    public bool isEmpty;
    
    public bool success;

    void Awake(){
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        success = false;
        isEmpty = true;
        CLEAR = GameObject.Find("CLEAR").GetComponent<RawImage>().texture;
        canvas = GameObject.Find("Canvas").GetComponent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (isEmpty)
            return;

        CG = clone.GetComponent<CanvasGroup>();
        CG.alpha = .6f;
        CG.blocksRaycasts = false;


        myTexture = GetComponent<RawImage>().texture;
        GetComponent<RawImage>().texture = CLEAR;
    }
    public void OnDrag(PointerEventData eventData)
    {
        if (isEmpty)
            return;

        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
                                        
    }

    public void OnEndDrag(PointerEventData eventData)
    {

        if (isEmpty)
            return;

        Destroy(clone);

        if (!success)
        {
            handleObject();
        }
            

        success = false;

    }

    public void OnPointerDown(PointerEventData eventData)
    { //OnPointerDown, create clone to manipulate. 
        checkit();

        if (isEmpty)
            return;

        clone = Instantiate(this.gameObject, canvas.transform, true);
        rectTransform = clone.GetComponent<RectTransform>();
        clone.GetComponent<DragnDrop>().original = this.gameObject;
        //then change texture of original to be clear

        myTexture = this.gameObject.GetComponent<RawImage>().texture;
    }

    void checkit()
    { //I dont want the user to be able to drag the empty texture because I want it to look like the slot is empty. 
        if (GetComponent<RawImage>().texture == CLEAR) {
            isEmpty = true;
            return;
        }
        isEmpty = false;
    }

    void handleObject()
    {
        GetComponent<RawImage>().texture = myTexture;


        //here is where we will handle giving the user the option to get rid of an inventory object all together. 
        //for now, keep it blank. 


    }
}
