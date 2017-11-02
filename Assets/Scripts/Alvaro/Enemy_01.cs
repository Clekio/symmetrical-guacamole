using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_01 : MonoBehaviour {

    public GameObject drop;

    public Logica romperArma;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		


	}

    
    private void OnTriggerEnter(Collider Weapon)
    {

        drop.SetActive(true);

        romperArma.hasDamaged = true;

        Destroy(this.gameObject);

    }
}
