using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    public AudioSource GameMusic;

    // Update is called once per frame
    void Update()
    {
        if(GameManager.gameStatus == 1)
        {
            GameMusic.enabled = true;
        }
        else
        {
            GameMusic.enabled = false;
        }
    }
}
