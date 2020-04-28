using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackGate : MonoBehaviour
{
    // Start is called before the first frame update
    private GameManager GM;
    private bool TrackSong = false;
    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Animation>().isPlaying)
        {
            TrackSong = true;
        }

        if (TrackSong)
        {
            if (!GetComponent<Animation>().isPlaying)
            {
                GM.GateRoutineOver();
                TrackSong = false;
            }
        }
    }
}
