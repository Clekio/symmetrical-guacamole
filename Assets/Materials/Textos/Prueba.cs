using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Prueba : MonoBehaviour {

	public Image cooldown;
	public bool coolingDown = false;
	public float waitTime = 30.0f;

	// Update is called once per frame
	void Update()
	{
		if (coolingDown == true)
		{
			//Reduce fill amount over 30 seconds
			cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
		}
	}
	void OnTriggerEnter (Collider other){
		if (other.tag == "Player")
	{
			coolingDown = true;
	}
}
}
