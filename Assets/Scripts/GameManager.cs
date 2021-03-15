using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;


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

    public void ExitGame()
    {
        Application.Quit();
    }
}
