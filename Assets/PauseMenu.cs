using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

    public static bool GameIsPaused = false;

    public GameObject pauseMenu;
    public GameObject gameCam;
    public GameObject pauseCam;
    public GameObject winMenu;
    public GameObject looseMenu;

    // Update is called once per frame
    void Update () {
        if ((winMenu.active == false) && (looseMenu.active == false))
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                if (GameIsPaused)
                {
                    Resume();
                }
                else
                {
                    Pause();
                }
            }
        }
	}

    public void Resume ()
    {
        pauseMenu.SetActive(false);
        pauseCam.SetActive(false);
        gameCam.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenu.SetActive(true);
        pauseCam.SetActive(true);
        gameCam.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
