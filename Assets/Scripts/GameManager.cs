using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public GameObject PausePanel;

    public GameObject VictoryText;

    public GameObject CaptureText; 
    
    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.escapeKey.wasPressedThisFrame || Keyboard.current.pKey.wasPressedThisFrame)
        {
            if (Time.timeScale > 0)
            {
                Time.timeScale = 0; 
            }
            else
            {
                Time.timeScale = 1;
            }
            PausePanel.SetActive(!PausePanel.activeInHierarchy);
        }
    }


    public void GameWon()
    {
        VictoryText.SetActive(true);
        Time.timeScale = 0;
        MainMenu();
    }
    
    public void GameLost()
    {
        CaptureText.SetActive(true);
        MainMenu();
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        StartCoroutine(GoToMenu());
    }

    public void MainMenuInstant()
    {
        SceneManager.LoadScene("MenuScene");
    }

    IEnumerator GoToMenu()
    {
        yield return new WaitForSeconds(5.0f);
        Time.timeScale = 1;
        SceneManager.LoadScene("MenuScene");
    }
}
