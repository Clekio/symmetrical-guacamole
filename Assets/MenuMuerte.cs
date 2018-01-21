using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour {


    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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


}
