using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{

    public static bool paused;

    public GameObject pauseGameMenu;

    // Start is called before the first frame update
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
          
        if (paused)
        {
            ResumeGame();
        }
        else
        {
                PauseGame();
        }

    }
}

     void ResumeGame()
    {
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        paused = false;
    }

     void PauseGame()
    {
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        paused = true;
        
     }

    public void LoadMenu() {
        Debug.Log("Returning to main menu");
        Time.timeScale = 1f;
        SceneManager.LoadScene("Splash");
    }

    public void QuitGame() {
        Debug.Log("Quitting game");
        Application.Quit();
    }
}
