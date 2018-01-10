using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class MenuMuerte : MonoBehaviour {

	// Use this for initialization
	public void Retry () {
        EditorSceneManager.LoadScene("Tutorial");
	}
    public void Menu()
    {
        EditorSceneManager.LoadScene("MENU");
    }
    public void Quit()
    {
        Application.Quit();
    }


}
