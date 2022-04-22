using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReloadGame : MonoBehaviour
{
    ReloadGame instance;
    GameObject pauseScreen;
    private void Awake()
    {
        instance = this;
        pauseScreen = GameObject.Find("PauseScreen");
        pauseScreen.active = false;
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
                pauseScreen.active = true;
            }
            else
            {
                Time.timeScale = 1;
                pauseScreen.active = false;
            }

        }
    }
    public void RestartGame()
    {
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1;
    }
    public void ExitGame()
    {
        Application.Quit();
    }

}
