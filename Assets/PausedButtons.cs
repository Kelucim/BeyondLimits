using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PausedButtons : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.gameStatus = 1;
    }
}
