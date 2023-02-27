using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    public int scoreAddSpeed = 20;
    public static int gameStatus = 1;

    public GameObject inGameMenu;

    public GameObject pauseMenu;

    public GameObject lostMenu;

    private int nowAdd = 2;
    private float scoreNum;
    public TextMeshProUGUI scoreShow;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStatus == 1)
        {
            GameRunning();
            AddScore();
        }
        else if(gameStatus == 2)
        {
            GamePaused();
        }
        else if(gameStatus == 3)
        {
            GameLost();
        }
    }

    void GameLost()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(false);
        inGameMenu.SetActive(false);
        lostMenu.SetActive(true);
    }

    void GameRunning()
    {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pauseMenu.SetActive(false);
        inGameMenu.SetActive(true);
        lostMenu.SetActive(false);
    }

    void GamePaused()
    {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pauseMenu.SetActive(true);
        inGameMenu.SetActive(false);
        lostMenu.SetActive(false);
    }

    void AddScore()
    {
        scoreNum += (1 * Time.deltaTime) * scoreAddSpeed;
        scoreShow.text = scoreNum.ToString("0");
    }
}
