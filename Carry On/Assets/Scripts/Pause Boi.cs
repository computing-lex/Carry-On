using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseBoi : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }
    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    void Pause()
    {
        {
            pauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            isPaused = true;

        }
       

    } 
    public void LoadMenu()
        { 

            Time.timeScale = 1f;
            SceneManager.LoadScene("MainMenu");

        }
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}
