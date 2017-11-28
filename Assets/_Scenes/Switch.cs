using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Switch : MonoBehaviour {
	public Camera[] cams;
	public GameObject Controller;
	public float coolDown = 10;
	public float coolDownTimer;
	public Text timeText;
	public GameObject texto;
	public GameObject Crosshairs1;
	public GameObject Crosshairs2;

	void Start (){
		//StartCoroutine ("waitXSeconds");
	}
		
	void Update ()
	{
			if (coolDownTimer > 0) {
				coolDownTimer -= Time.deltaTime;
		
			}
			if (coolDownTimer < 0) {
				coolDownTimer = 0;
		
			}
			if (Input.GetKey ("e") && coolDownTimer == 0) {
				cams [0].enabled = true;
				cams [1].enabled = false;
				Controller.SetActive (false);
				coolDownTimer = coolDown;
				texto.gameObject.SetActive (false);
				Crosshairs1.gameObject.SetActive (false);
				Crosshairs2.gameObject.SetActive (false);
				StartCoroutine ("waitXSeconds");
			}
		timeText.text = ("Up in " + coolDownTimer.ToString("F"));

	}
	IEnumerator waitXSeconds(){
			yield return new WaitForSeconds (3.0f);
				cams [0].enabled = false;
				cams [1].enabled = true;
				Controller.SetActive (true);
				texto.gameObject.SetActive (true);
				Crosshairs1.gameObject.SetActive (true);
				Crosshairs2.gameObject.SetActive (true);
		//timeText.text = ("Up in " + coolDownTimer.ToString("F"));
			}
		
	}
	
