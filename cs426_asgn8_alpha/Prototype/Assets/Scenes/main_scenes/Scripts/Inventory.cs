using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Inventory : MonoBehaviour
{
    
    public GameObject[] i_Items; //items in the inventory. 
    public GameObject[] b_Items; //items in the bag.
    public GameObject[] throwables;
    Texture CLEAR;

    void Start()
    {
        CLEAR = GameObject.Find("CLEAR").GetComponent<RawImage>().texture;
        throwables = new GameObject[4];
    }


    private void Update()
    {
        for(int i = 0; i < b_Items.Length; ++i){
            if(b_Items[i].GetComponent<RawImage>().texture != CLEAR)
            {
                throwables[i] = GameObject.Find(b_Items[i].GetComponent<RawImage>().texture.name);
            }
            else
            {
                throwables[i] = null;
            }
        }
   
    }

    public void addItem(GameObject other)
    { //add other object's texture to our bag 

        //if the item is throwable, then Ill store a reference to the gameobject so i can spawn it and throw it when applicable.
        //if it has a rigidbody then i could throw it, so I should keep note of that. 

        foreach (GameObject b in b_Items)
        {
            if (b.GetComponent<RawImage>().texture == CLEAR) //this is equivalent to asking if this slot is empty to place an item in
            {
                b.GetComponent<RawImage>().texture = other.GetComponent<RawImage>().texture;  //place the item in this empty slot
                return;

            }
        }

        // If I get here then the bag is full. Time to put it into the inventory. 
        foreach (GameObject i in i_Items) {
            if(i.GetComponent<RawImage>().texture == CLEAR) //this is equivalent to asking if this slot is empty to place an item in
            {
                i.GetComponent<RawImage>().texture = other.GetComponent<RawImage>().texture;
                return;
             
            }
        }

        //If I get here, then both the bag and the inventory are full. User must discard of something to add the current object...
        Debug.Log("Inventory is full");
    }





    /*
    this removeItem code will be used on two instances. 
    If the index is '0' then the user is trying to remove something from the inventory.   
    if the index is the 1-4, then the user is trying to use an item in the bag. 
    The code handling the using of the item should be somewhere else, for here we will just remove the item. 
     
    */
    public void removeItem(int index){

        b_Items[index].GetComponent<RawImage>().texture = CLEAR; //I am clearing this slot... emptying it out. 
        throwables[index] = null;

    }

}
