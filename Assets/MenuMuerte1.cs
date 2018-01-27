using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte1 : MonoBehaviour {

    public static bool GameIsCredited = false;

    //estas referencias son solo para el menu de inicio
    public GameObject winCam;
    public GameObject Cam;
    public GameObject eventsys;
    public GameObject WinText;



    private void Start()
    {
        Cursor.visible = false;
    }

    public void Update()
    {
        {
            if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7))
            {
                eventsys.SetActive(true);
                winCam.SetActive(false);
                Cam.SetActive(true);
                WinText.SetActive(false);
                GameIsCredited = false;
            }
        }
    }
}
