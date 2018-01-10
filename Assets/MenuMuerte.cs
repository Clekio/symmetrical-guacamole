using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuMuerte : MonoBehaviour {

	// Use this for initialization
	public void Retry () {
        SceneManager.LoadScene("Tutorial");
	}
    public void Menu()
    {
        SceneManager.LoadScene("MENU");
    }
    public void Quit()
    {
        Application.Quit();
    }


}
