using UnityEngine;
using UnityEngine.SceneManagement;

public class Loss : MonoBehaviour
{
    bool gameEnd = false;

    void OnTriggerEnter()
    {
        Debug.Log("Lost");
        GameManager.gameStatus = 3;
    }

    void OpenMenu()
    {

    }
}
