using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int totalScore;
    
    public Text scoreText;

    public Text record;
    
    public static bool save;
    public GameObject gameOver;

    // pause
    private bool isPaused;
    public GameObject pausePanel;

    public static GameController instance;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        Time.timeScale = 1f;
        //save = false;
        //totalScore = PlayerPrefs.GetInt("record");

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseScreen();
        }
        //saveScore();
    }
    
    //public void saveScore()
    //{
    //    if(save==true)
       // {
          //  PlayerPrefs.SetInt("record", totalScore);
           // PlayerPrefs.Save();
       // }
   // }

    public void UpScoretxt()
    {
        scoreText.text = totalScore.ToString();
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartGame(string lvlname)
    {
        SceneManager.LoadScene(lvlname);
    }

    public void ShowMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    void PauseScreen()
    {
        if(isPaused)
        {
            isPaused = false;
            Time.timeScale = 1f;
            pausePanel.SetActive(false); 
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            isPaused = true;
            Time.timeScale = 0f;
            pausePanel.SetActive(true); 
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void PlayG()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }
}
