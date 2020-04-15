using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OnButtonClick : MonoBehaviour
{

    private GameManager GM;
    private Text child;
    // Start is called before the first frame update
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
        child = GetComponentInChildren<Text>();
    }


    public void UserInput()
    {
        GM.CatchAnswer(child.text);
    }
}
