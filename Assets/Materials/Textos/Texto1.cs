using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Texto1 : MonoBehaviour {
	[Header("----- REFERENCIAS")]
	public Image cooldown;

	public bool coolingDown = true;
	public float waitTime = 30.0f;


	void update()
	{
		if (coolingDown == true)
		{
			
			//Reduce fill amount over 30 seconds
			cooldown.fillAmount += 1.0f / waitTime * Time.deltaTime;
		}
	}

//	private void OnTriggerEnter(Collider other)
//	{
//		if (other.tag == "Player"){
//			coolingDown = true;
//		}
//	}
}

