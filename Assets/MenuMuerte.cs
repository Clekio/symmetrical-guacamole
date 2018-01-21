using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour {

    public static bool GameIsCredited = false;

    //estas referencias son solo para el menu de inicio
    public GameObject creditCam;
    public GameObject Cam;
    public GameObject eventsys;


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void Update()
    {
        if (GameIsCredited)
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                eventsys.SetActive(true);
                creditCam.SetActive(false);
                Cam.SetActive(true);
                GameIsCredited = false;
            }
        }
    }

    // Use this for initialization
    public void Retry () {
        SceneManager.LoadScene("Tutorial");
	}
    public void Menu()
    {
        SceneManager.LoadScene("MENU");
    }
    public void level2()
    {
        SceneManager.LoadScene("Level 2");
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void level3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void credit()
    {
        eventsys.SetActive(false);
        creditCam.SetActive(true);
        Cam.SetActive(false);
        GameIsCredited = true;
    }


}
