using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	// Use this for initialization
	public void LoadScene () {
		SceneManager.LoadScene (1);
	}
	public void Quit () {
		Application.Quit ();
	}
    public void MainMenu ()
    {
        SceneManager.LoadScene (0);
    }

}
