using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool isGamePaused = false;
    private static bool inVolumeSettings = false;

    public GameObject pauseMenuUI;
    public GameObject VolumeUI;


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isGamePaused)
            {
                if (inVolumeSettings) Back();
                else Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
        Cursor.visible = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
        Cursor.visible = true;
    }

    public void ExitToMenu()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Back()
    {
        inVolumeSettings = false;
        VolumeUI.SetActive(false);
        pauseMenuUI.SetActive(true);
    }

    public void ChangeVolume()
    {
        inVolumeSettings = true;
        pauseMenuUI.SetActive(false);
        VolumeUI.SetActive(true);
    }


    public void QuitGame()
    {
        Debug.Log("Quitting game");
        Application.Quit();
    }


}
