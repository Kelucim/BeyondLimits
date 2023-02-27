using UnityEngine;
using UnityEngine.SceneManagement;

public class Loss : MonoBehaviour
{
    void Update()
    {
        if(transform.position.x <= -18 || transform.position.x >= 18 || transform.position.y <= -10 || transform.position.y >= 10)
        {
            if(GameManager.maxScore < GameManager.currentScore)
            {
                PlayerPrefs.SetFloat("MaxScore", GameManager.currentScore);
            }
            //Debug.Log("Lost");
            GameManager.currentScore = 0;
            GameManager.gameStatus = 3;
        }
    }
}
