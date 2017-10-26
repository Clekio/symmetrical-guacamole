using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_GM: MonoBehaviour {

    public GameObject drop;

    public Logica_GM romperArma;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


	}

    
    private void OnTriggerEnter(Collider Weapon)
    {

        drop.SetActive(true);

        romperArma.hasWeapon = false;

        Destroy(this.gameObject);

    }
}
