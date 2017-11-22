using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnoOnPasillo : MonoBehaviour {

    public Logica encender;

    public GameObject bloque;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
        if (encender.hasWeapon == true) {

            

            StartCoroutine(Count0());

        }

	}


    IEnumerator Count0()
    {


        yield return new WaitForSeconds(0.4f);

        bloque.SetActive(true);

        yield return null;

    }


}
