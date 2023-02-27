using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    private int hMode = 0;
    public int scoreAddSpeed = 20;
    public static int gameStatus = 2;
    public static float gameSpeedIncrease = 0.4f;
    public GameObject inGameMenu;

    public GameObject pauseMenu;

    public GameObject lostMenu;

    static public float maxScore;
    static public float currentScore;
    public TextMeshProUGUI scoreShow;
    static public float gameSpeed = 1f;
    public TextMeshProUGUI maxScoreText;
    public GameObject hardModeToggle;
    
    void Awake()
    {
        Application.targetFrameRate = 60;
        gameStatus = 2;
        maxScore = PlayerPrefs.GetFloat("MaxScore", 0);
        HModeTest();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStatus == 1)
        {
            GameRunning();
            AddScore();
            if(hMode == 1)
            {
                IncreaseGameSpeedHard();   
            }
            else
            {
                IncreaseGameSpeed();
            }
            
        }
        else if(gameStatus == 2)
        {
            GamePaused();
            BestScore();
        }
        else if(gameStatus == 3)
        {
            GameLost();
            if(gameSpeedIncrease != 0.4f)
            {
                gameSpeedIncrease = 0.4f;
            }
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
        currentScore += (1 * Time.deltaTime) * gameSpeedIncrease * 10;
        scoreShow.text = currentScore.ToString("0");
    }

    void BestScore()
    {
        if(maxScoreText.text != maxScore.ToString("0"))
        {
            maxScoreText.text = "PB: " + maxScore.ToString("0");
        }
    }

    void IncreaseGameSpeedHard()
    {
        if(gameSpeedIncrease <= 1f)
        {
            gameSpeedIncrease += 0.05f * Time.deltaTime;
        }
        else
        {
            return;
        }
    }
    void IncreaseGameSpeed()
    {
        if(gameSpeedIncrease <= 0.75f)
        {
            gameSpeedIncrease += 0.05f * Time.deltaTime;
        }
        else
        {
            return;
        }
    }
    public void HModeSet(bool currentHmode)
    {
        if(currentHmode)
        {
            hMode = 1;
            PlayerPrefs.SetInt("hMode", 1);
        }
        else if(!currentHmode)
        {
            hMode = 0;
            PlayerPrefs.SetInt("hMode", 0);
        }
    }

    void HModeTest()
    {
        hMode = PlayerPrefs.GetInt("hMode", 0);

        if(hMode == 1)
        {   
            hardModeToggle.GetComponent<Toggle>().isOn = true;
        }
        else if(hMode == 0)
        {
            hardModeToggle.GetComponent<Toggle>().isOn = false;
        }
    }
}
